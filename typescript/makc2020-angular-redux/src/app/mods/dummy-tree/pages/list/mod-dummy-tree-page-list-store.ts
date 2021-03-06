// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppModDummyTreeJobItemDeleteInput} from '../../jobs/item/delete/mod-dummy-tree-job-item-delete-input';
import {AppModDummyTreeJobListDeleteInput} from '../../jobs/list/delete/mod-dummy-tree-job-list-delete-input';
import {AppModDummyTreeJobListGetInput} from '../../jobs/list/get/mod-dummy-tree-job-list-get-input';
import {AppModDummyTreeStoreState} from '../../store/mod-dummy-tree-store.state';
import {AppModDummyTreePageListStateParameters} from './state/mod-dummy-tree-page-list-state-parameters';
import {AppModDummyTreePageListStoreActionClear} from './store/actions/mod-dummy-tree-page-list-store-action-clear';
import {AppModDummyTreePageListStoreActionItemDelete} from './store/actions/mod-dummy-tree-page-list-store-action-item-delete';
import {AppModDummyTreePageListStoreActionFilteredDelete} from './store/actions/mod-dummy-tree-page-list-store-action-filtered-delete';
import {AppModDummyTreePageListStoreActionListDelete} from './store/actions/mod-dummy-tree-page-list-store-action-list-delete';
import {AppModDummyTreePageListStoreActionLoad} from './store/actions/mod-dummy-tree-page-list-store-action-load';
import {AppModDummyTreePageListStoreActionParametersSet} from './store/actions/mod-dummy-tree-page-list-store-action-parameters-set';
import {appModDummyTreePageListStoreSelector} from './store/mod-dummy-tree-page-list-store.selectors';
import {AppModDummyTreePageListState} from './mod-dummy-tree-page-list-state';

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
   * Запустить действие "Отфильтрованное. Удаление".
   * @param {AppModDummyTreeJobListGetInput} input Ввод.
   */
  runActionFilteredDelete(input: AppModDummyTreeJobListGetInput) {
    this.extStore.dispatch(new AppModDummyTreePageListStoreActionFilteredDelete(input));
  }

  /**
   * Запустить действие "Элемент. Удаление".
   * @param {AppModDummyTreeJobItemDeleteInput} input Ввод.
   */
  runActionItemDelete(input: AppModDummyTreeJobItemDeleteInput) {
    this.extStore.dispatch(new AppModDummyTreePageListStoreActionItemDelete(input));
  }

  /**
   * Запустить действие "Список. Удаление".
   * @param {AppModDummyTreeJobListDeleteInput} input Ввод.
   */
  runActionListDelete(input: AppModDummyTreeJobListDeleteInput) {
    this.extStore.dispatch(new AppModDummyTreePageListStoreActionListDelete(input));
  }

  /**
   * Запустить действие "Загрузка".
   * @param {AppModDummyTreeJobListGetInput} input Ввод.
   */
  runActionLoad(input: AppModDummyTreeJobListGetInput) {
    this.extStore.dispatch(new AppModDummyTreePageListStoreActionLoad(input));
  }

  /**
   * Запустить действие "Параметры. Установка".
   * @param {AppModDummyTreePageListStateParameters} parameters Параметры.
   */
  runActionParametersSet(parameters: AppModDummyTreePageListStateParameters) {
    this.extStore.dispatch(new AppModDummyTreePageListStoreActionParametersSet(parameters));
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
