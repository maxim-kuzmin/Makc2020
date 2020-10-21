// //Author Maxim Kuzmin//makc//

import { Injectable } from '@angular/core';
import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppModDummyMainJobItemDeleteInput} from '../../jobs/item/delete/mod-dummy-main-job-item-delete-input';
import {AppModDummyMainJobListDeleteInput} from '../../jobs/list/delete/mod-dummy-main-job-list-delete-input';
import {AppModDummyMainJobListGetInput} from '../../jobs/list/get/mod-dummy-main-job-list-get-input';
import {AppModDummyMainStoreState} from '../../store/mod-dummy-main-store.state';
import {AppModDummyMainPageListStateParameters} from './state/mod-dummy-main-page-list-state-parameters';
import {AppModDummyMainPageListStoreActionClear} from './store/actions/mod-dummy-main-page-list-store-action-clear';
import {AppModDummyMainPageListStoreActionItemDelete} from './store/actions/mod-dummy-main-page-list-store-action-item-delete';
import {AppModDummyMainPageListStoreActionFilteredDelete} from './store/actions/mod-dummy-main-page-list-store-action-filtered-delete';
import {AppModDummyMainPageListStoreActionListDelete} from './store/actions/mod-dummy-main-page-list-store-action-list-delete';
import {AppModDummyMainPageListStoreActionLoad} from './store/actions/mod-dummy-main-page-list-store-action-load';
import {AppModDummyMainPageListStoreActionParametersSet} from './store/actions/mod-dummy-main-page-list-store-action-parameters-set';
import {appModDummyMainPageListStoreSelector} from './store/mod-dummy-main-page-list-store.selectors';
import {AppModDummyMainPageListState} from './mod-dummy-main-page-list-state';

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
   * Запустить действие "Отфильтрованное. Удаление".
   * @param {AppModDummyMainJobListGetInput} input Ввод.
   */
  runActionFilteredDelete(input: AppModDummyMainJobListGetInput) {
    this.extStore.dispatch(new AppModDummyMainPageListStoreActionFilteredDelete(input));
  }

  /**
   * Запустить действие "Элемент. Удаление".
   * @param {AppModDummyMainJobItemDeleteInput} input Ввод.
   */
  runActionItemDelete(input: AppModDummyMainJobItemDeleteInput) {
    this.extStore.dispatch(new AppModDummyMainPageListStoreActionItemDelete(input));
  }

  /**
   * Запустить действие "Список. Удаление".
   * @param {AppModDummyMainJobListDeleteInput} input Ввод.
   */
  runActionListDelete(input: AppModDummyMainJobListDeleteInput) {
    this.extStore.dispatch(new AppModDummyMainPageListStoreActionListDelete(input));
  }

  /**
   * Запустить действие "Загрузка".
   * @param {AppModDummyMainJobListGetInput} input Ввод.
   */
  runActionLoad(input: AppModDummyMainJobListGetInput) {
    this.extStore.dispatch(new AppModDummyMainPageListStoreActionLoad(input));
  }

  /**
   * Запустить действие "Параметры. Установка".
   * @param {AppModDummyMainPageListStateParameters} parameters Параметры.
   */
  runActionParametersSet(parameters: AppModDummyMainPageListStateParameters) {
    this.extStore.dispatch(new AppModDummyMainPageListStoreActionParametersSet(parameters));
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
