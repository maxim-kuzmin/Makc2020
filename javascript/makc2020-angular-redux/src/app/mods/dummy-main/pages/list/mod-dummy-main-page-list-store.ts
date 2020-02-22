// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppModDummyMainJobItemGetInput} from '@app/mods/dummy-main/jobs/item/get/mod-dummy-main-job-item-get-input';
import {AppModDummyMainJobListGetInput} from '@app/mods/dummy-main/jobs/list/get/mod-dummy-main-job-list-get-input';
import {AppModDummyMainStoreState} from '@app/mods/dummy-main/store/mod-dummy-main-store.state';
import {AppModDummyMainPageListState} from './mod-dummy-main-page-list-state';
import {AppModDummyMainPageListStoreActionClear} from './store/actions/mod-dummy-main-page-list-store-action-clear';
import {AppModDummyMainPageListStoreActionDelete} from './store/actions/mod-dummy-main-page-list-store-action-delete';
import {AppModDummyMainPageListStoreActionLoad} from './store/actions/mod-dummy-main-page-list-store-action-load';
import {appModDummyMainPageListStoreSelector} from './store/mod-dummy-main-page-list-store.selectors';
import { Injectable } from "@angular/core";

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. */
@Injectable()
export class AppModDummyMainPageListStore {

  /** @type {AppModDummyMainPageListState} */
  private state = new AppModDummyMainPageListState();

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
   * @returns {AppModDummyMainPageListState} Состояние.
   */
  getState(): AppModDummyMainPageListState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModDummyMainPageListState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppModDummyMainPageListState> {
    return this.extStore.pipe(
      select(appModDummyMainPageListStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppModDummyMainPageListStoreActionClear());
  }

  /**
   * Запустить действие "Удаление".
   * @param {AppModDummyMainJobItemGetInput} input Ввод.
   */
  runActionDelete(input: AppModDummyMainJobItemGetInput) {
    this.extStore.dispatch(new AppModDummyMainPageListStoreActionDelete(input));
  }

  /**
   * Запустить действие "Загрузка".
   * @param {AppModDummyMainJobListGetInput} input Ввод.
   */
  runActionLoad(input: AppModDummyMainJobListGetInput) {
    this.extStore.dispatch(new AppModDummyMainPageListStoreActionLoad(input));
  }

  /**
   * @param {AppModDummyMainPageListState} state
   * @returns {AppModDummyMainPageListState}
   */
  private onStateMap(state: AppModDummyMainPageListState): AppModDummyMainPageListState {
    this.state = state;

    return this.state;
  }
}
