// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Title} from '@angular/platform-browser';
import {Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreTitleDataItem} from './data/core-title-data-item';
import {AppCoreTitleStore} from './core-title-store';

/** Ядро. Заголовок. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreTitleService {

  /** @type {Map<string, number[]>} */
  private lookupIndexesByKey = new Map<string, number[]>();

  /**
   * Конструктор.
   * @param {AppCoreTitleStore} appStore Хранилище состояния.
   * @param {Title} extTitle Заголовок.
   */
  constructor(
    private appStore: AppCoreTitleStore,
    private extTitle: Title
  ) {
    this.runActionItemUpdate = this.runActionItemUpdate.bind(this);
  }

  /**
   * Выполнить действие "Элемент. Добавление".
   * @param {string} title Заголовок.
   * @param {Observable<string>} titleTranslated$ Событие, возникающее после перевода заголовка.
   * @param {Subject<boolean>} unsubscribe$
   */
  executeActionItemAdd(
    title: string,
    titleTranslated$: Observable<string>,
    unsubscribe$: Subject<boolean>
  ) {
    this.runActionItemAdd(title, '');

    titleTranslated$.pipe(
      takeUntil(unsubscribe$)
    ).subscribe(translatedTitle => {
      this.runActionItemUpdate(title, translatedTitle);
    });
  }

  /** Запустить действие "Элемент. Добавление". */
  runActionItemAdd(key: string, value: string) {
    const items = this.getItems();

    const item = new AppCoreTitleDataItem(key, value);

    items.push(item);

    this.refreshLookupIndexesByKey(items, key);

    this.refreshTitle(items);

    this.appStore.runActionItemAdd(items);
  }

  /** Запустить действие "Элемент. Обновление". */
  runActionItemUpdate(key: string, value: string) {
    const items = this.getItems();

    this.refreshItems(items, key, value);

    this.refreshTitle(items);

    this.appStore.runActionItemUpdate(items);
  }

  /** Запустить действие "Последние элементы. Удаление". */
  runActionLastItemsRemove(count: number) {
    let items = this.getItems();

    const len = items.length;

    if (count < len) {
      items = items.slice(0, len - count);
    } else {
      items = [];
    }

    this.refreshLookupIndexesByKey(items);

    this.refreshTitle(items);

    this.appStore.runActionLastItemsRemove(items);
  }

  /** @returns {AppCoreTitleDataItem[]} */
  private getItems(): AppCoreTitleDataItem[] {
    const state = this.appStore.getState();

    return state ? [...state.items] : [];
  }

  /**
   * @param {AppCoreTitleDataItem[]} items
   * @param {string} key
   * @param {string} value
   */
  private refreshItems(items: AppCoreTitleDataItem[], key: string, value: string) {
    const indexes: number[] = this.lookupIndexesByKey[key];

    if (items.length > 0 && indexes && indexes.length > 0) {
      indexes.forEach((index) => {
        items[index].value = value;
      });
    }
  }

  /**
   * @param {AppCoreTitleDataItem[]} items
   * @param {string} key
   */
  private refreshLookupIndexesByKey(items: AppCoreTitleDataItem[], key: string = null) {
    const indexes: number[] = [];

    const refreshedKeys: string[] = [];

    if (key !== null) {
      refreshedKeys.push(key);
    } else {
      for (const lookupKey of this.lookupIndexesByKey.keys()) {
        refreshedKeys.push(lookupKey);
      }
    }

    refreshedKeys.forEach((refreshedKey) => {
      items.forEach((item, index) => {
        if (item.key === refreshedKey) {
          indexes.push(index);
        }
      });
    });

    this.lookupIndexesByKey[key] = indexes;
  }

  /** @param {AppCoreTitleDataItem[]} items */
  private refreshTitle(items: AppCoreTitleDataItem[]) {
    const title = items.slice().reverse().map(x => x.value).join('-');

    this.extTitle.setTitle(title);
  }
}
