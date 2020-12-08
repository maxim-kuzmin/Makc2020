// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppModDummyTreeStoreState} from '@app/mods/dummy-tree/store/mod-dummy-tree-store.state';
import {AppModDummyTreePageIndexState} from './mod-dummy-tree-page-index-state';
import {AppModDummyTreePageIndexStoreActionClear} from './store/actions/mod-dummy-tree-page-index-store-action-clear';
import {appModDummyTreePageIndexStoreSelector} from './store/mod-dummy-tree-page-index-store.selectors';
import { Injectable } from '@angular/core';

/** Мод "DummyTree". Страницы. Начало. Хранилище состояния. */
@Injectable()
export class AppModDummyTreePageIndexStore {

  /** @type {AppModDummyTreePageIndexState} */
  private state = new AppModDummyTreePageIndexState();

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
   * @returns {AppModDummyTreePageIndexState} Состояние.
   */
  getState(): AppModDummyTreePageIndexState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModDummyTreePageIndexState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppModDummyTreePageIndexState> {
    return this.extStore.pipe(
      select(appModDummyTreePageIndexStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppModDummyTreePageIndexStoreActionClear());
  }

  /**
   * @param {AppModDummyTreePageIndexState} state
   * @returns {AppModDummyTreePageIndexState}
   */
  private onStateMap(state: AppModDummyTreePageIndexState): AppModDummyTreePageIndexState {
    this.state = state;

    return this.state;
  }
}
