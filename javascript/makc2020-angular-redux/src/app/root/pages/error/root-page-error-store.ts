// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppRootStoreState} from '@app/root/store/root-store.state';
import {AppRootPageErrorState} from './root-page-error-state';
import {AppRootPageErrorStoreActionClear} from './store/actions/root-page-error-store-action-clear';
import {appRootPageErrorStoreSelector} from './store/root-page-error-store.selectors';
import { Injectable } from '@angular/core';

/** Корень. Страницы. Ошибка. Хранилище состояния. */
@Injectable()
export class AppRootPageErrorStore {

  /** @type {AppRootPageErrorState} */
  private state: AppRootPageErrorState;

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
   * @returns {AppRootPageErrorState} Состояние.
   */
  getState(): AppRootPageErrorState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppRootPageErrorState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppRootPageErrorState> {
    return this.extStore.pipe(
      select(appRootPageErrorStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppRootPageErrorStoreActionClear());
  }

  /**
   * @param {AppRootPageErrorState} state
   * @returns {AppRootPageErrorState}
   */
  private onStateMap(state: AppRootPageErrorState): AppRootPageErrorState {
    this.state = state;

    return this.state;
  }
}
