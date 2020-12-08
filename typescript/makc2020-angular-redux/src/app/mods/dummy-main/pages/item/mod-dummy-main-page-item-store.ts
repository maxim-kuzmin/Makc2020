// //Author Maxim Kuzmin//makc//

import { Injectable } from '@angular/core';
import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppModDummyMainJobItemGetInput} from '@app/mods/dummy-main/jobs/item/get/mod-dummy-main-job-item-get-input';
import {AppModDummyMainJobItemGetOutput} from '@app/mods/dummy-main/jobs/item/get/mod-dummy-main-job-item-get-output';
import {AppModDummyMainStoreState} from '../../store/mod-dummy-main-store.state';
import {AppModDummyMainPageItemState} from './mod-dummy-main-page-item-state';
import {AppModDummyMainPageItemStoreActionClear} from './store/actions/mod-dummy-main-page-item-store-action-clear';
import {AppModDummyMainPageItemStoreActionLoad} from './store/actions/mod-dummy-main-page-item-store-action-load';
import {AppModDummyMainPageItemStoreActionSave} from './store/actions/mod-dummy-main-page-item-store-action-save';
import {appModDummyMainPageItemStoreSelector} from './store/mod-dummy-main-page-item-store.selectors';

/** Мод "DummyMain". Страницы. Элемент. Хранилище состояния. */
@Injectable()
export class AppModDummyMainPageItemStore {

  /** @type {AppModDummyMainPageItemState} */
  private state = new AppModDummyMainPageItemState();

  /**
   * Конструктор.
   * @param {Store<AppModDummyMainStoreState>} extStore Хранилище состояния.
   */
  constructor(
    private extStore: Store<AppModDummyMainStoreState>
  ) {
    this.onStateMap = this.onStateMap.bind(this);
  }

  /**
   * Получить состояние.
   * @returns {AppModDummyMainPageItemState} Состояние.
   */
  getState(): AppModDummyMainPageItemState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModDummyMainPageItemState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppModDummyMainPageItemState> {
    return this.extStore.pipe(
      select(appModDummyMainPageItemStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppModDummyMainPageItemStoreActionClear());
  }

  /**
   * Запустить действие "Загрузка".
   * @param {AppModDummyMainJobItemGetInput} input Ввод.
   */
  runActionLoad(input: AppModDummyMainJobItemGetInput) {
    this.extStore.dispatch(new AppModDummyMainPageItemStoreActionLoad(input));
  }

  /**
   * Запустить действие "Сохранение".
   * @param {AppModDummyMainJobItemGetOutput} input Ввод.
   */
  runActionSave(input: AppModDummyMainJobItemGetOutput) {
    this.extStore.dispatch(new AppModDummyMainPageItemStoreActionSave(input));
  }

  /**
   * @param {AppModDummyMainPageItemState} state
   * @returns {AppModDummyMainPageItemState}
   */
  private onStateMap(state: AppModDummyMainPageItemState): AppModDummyMainPageItemState {
    this.state = state;

    return this.state;
  }
}
