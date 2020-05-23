// //Author Maxim Kuzmin//makc//

import { Injectable } from '@angular/core';
import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppCoreCommonModJobTreeItemGetInput} from '@app/core/common/mod/jobs/tree/item/get/core-common-mod-job-tree-item-get-input';
import {AppModDummyTreeJobItemGetOutput} from '@app/mods/dummy-tree/jobs/item/get/mod-dummy-tree-job-item-get-output';
import {AppModDummyTreeStoreState} from '../../store/mod-dummy-tree-store.state';
import {AppModDummyTreePageItemState} from './mod-dummy-tree-page-item-state';
import {appModDummyTreePageItemStoreSelector} from './store/mod-dummy-tree-page-item-store.selectors';
import {AppModDummyTreePageItemStoreActionClear} from './store/actions/mod-dummy-tree-page-item-store-action-clear';
import {AppModDummyTreePageItemStoreActionLoad} from './store/actions/mod-dummy-tree-page-item-store-action-load';
import {AppModDummyTreePageItemStoreActionSave} from './store/actions/mod-dummy-tree-page-item-store-action-save';

/** Мод "DummyTree". Страницы. Элемент. Хранилище состояния. */
@Injectable()
export class AppModDummyTreePageItemStore {

  /** @type {AppModDummyTreePageItemState} */
  private state = new AppModDummyTreePageItemState();

  /**
   * Конструктор.
   * @param {Store<AppModDummyTreeStoreState>} extStore Хранилище состояния.
   */
  constructor(
    private extStore: Store<AppModDummyTreeStoreState>
  ) {
    this.onStateMap = this.onStateMap.bind(this);
  }

  /**
   * Получить состояние.
   * @returns {AppModDummyTreePageItemState} Состояние.
   */
  getState(): AppModDummyTreePageItemState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModDummyTreePageItemState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppModDummyTreePageItemState> {
    return this.extStore.pipe(
      select(appModDummyTreePageItemStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppModDummyTreePageItemStoreActionClear());
  }

  /**
   * Запустить действие "Загрузка".
   * @param {AppCoreCommonModJobTreeItemGetInput} input Ввод.
   */
  runActionLoad(input: AppCoreCommonModJobTreeItemGetInput) {
    this.extStore.dispatch(new AppModDummyTreePageItemStoreActionLoad(input));
  }

  /**
   * Запустить действие "Сохранение".
   * @param {AppModDummyTreeJobItemGetOutput} input Ввод.
   */
  runActionSave(input: AppModDummyTreeJobItemGetOutput) {
    this.extStore.dispatch(new AppModDummyTreePageItemStoreActionSave(input));
  }

  /**
   * @param {AppModDummyTreePageItemState} state
   * @returns {AppModDummyTreePageItemState}
   */
  private onStateMap(state: AppModDummyTreePageItemState): AppModDummyTreePageItemState {
    this.state = state;

    return this.state;
  }
}
