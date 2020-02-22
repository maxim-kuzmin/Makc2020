// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppRootStoreState} from '@app/root/store/root-store.state';
import {AppRootPageIndexState} from './root-page-index-state';
import {AppRootPageIndexStoreActionClear} from './store/actions/root-page-index-store-action-clear';
import {appRootPageIndexStoreSelector} from './store/root-page-index-store.selectors';
import { Injectable } from '@angular/core';

/** Корень. Страницы. Начало. Хранилище состояния. */
@Injectable()
export class AppRootPageIndexStore {

  /** @type {AppRootPageIndexState} */
  private state: AppRootPageIndexState;

  /**
   * Конструктор.
   * @param {Store<AppRootStoreState>} extStore Хранилище состояния.
   */
  constructor(
    private extStore: Store<AppRootStoreState>
  ) {
    this.onStateMap = this.onStateMap.bind(this);
  }

  /**
   * Получить состояние.
   * @returns {AppRootPageIndexState} Состояние.
   */
  getState(): AppRootPageIndexState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppRootPageIndexState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppRootPageIndexState> {
    return this.extStore.pipe(
      select(appRootPageIndexStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppRootPageIndexStoreActionClear());
  }

  /**
   * @param {AppRootPageIndexState} state
   * @returns {AppRootPageIndexState}
   */
  private onStateMap(state: AppRootPageIndexState): AppRootPageIndexState {
    this.state = state;

    return this.state;
  }
}
