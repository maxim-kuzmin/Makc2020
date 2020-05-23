// //Author Maxim Kuzmin//makc//

import { Injectable } from '@angular/core';
import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppCoreCommonModJobItemGetInput} from '@app/core/common/mod/jobs/item/get/core-common-mod-job-item-get-input';
import {AppModDummyTreeJobListGetInput} from '@app/mods/dummy-tree/jobs/list/get/mod-dummy-tree-job-list-get-input';
import {AppModDummyTreeStoreState} from '@app/mods/dummy-tree/store/mod-dummy-tree-store.state';
import {AppModDummyTreePageListState} from './mod-dummy-tree-page-list-state';
import {AppModDummyTreePageListStoreActionClear} from './store/actions/mod-dummy-tree-page-list-store-action-clear';
import {AppModDummyTreePageListStoreActionDelete} from './store/actions/mod-dummy-tree-page-list-store-action-delete';
import {AppModDummyTreePageListStoreActionLoad} from './store/actions/mod-dummy-tree-page-list-store-action-load';
import {appModDummyTreePageListStoreSelector} from './store/mod-dummy-tree-page-list-store.selectors';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. */
@Injectable()
export class AppModDummyTreePageListStore {

  /** @type {AppModDummyTreePageListState} */
  private state = new AppModDummyTreePageListState();

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
   * @returns {AppModDummyTreePageListState} Состояние.
   */
  getState(): AppModDummyTreePageListState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModDummyTreePageListState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppModDummyTreePageListState> {
    return this.extStore.pipe(
      select(appModDummyTreePageListStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppModDummyTreePageListStoreActionClear());
  }

  /**
   * Запустить действие "Удаление".
   * @param {AppCoreCommonModJobItemGetInput} input Ввод.
   */
  runActionDelete(input: AppCoreCommonModJobItemGetInput) {
    this.extStore.dispatch(new AppModDummyTreePageListStoreActionDelete(input));
  }

  /**
   * Запустить действие "Загрузка".
   * @param {AppModDummyTreeJobListGetInput} input Ввод.
   */
  runActionLoad(input: AppModDummyTreeJobListGetInput) {
    this.extStore.dispatch(new AppModDummyTreePageListStoreActionLoad(input));
  }

  /**
   * @param {AppModDummyTreePageListState} state
   * @returns {AppModDummyTreePageListState}
   */
  private onStateMap(state: AppModDummyTreePageListState): AppModDummyTreePageListState {
    this.state = state;

    return this.state;
  }
}
