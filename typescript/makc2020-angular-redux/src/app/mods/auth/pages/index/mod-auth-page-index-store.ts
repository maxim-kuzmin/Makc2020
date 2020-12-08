// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppModAuthStoreState} from '@app/mods/auth/store/mod-auth-store.state';
import {AppModAuthPageIndexState} from './mod-auth-page-index-state';
import {AppModAuthPageIndexStoreActionClear} from './store/actions/mod-auth-page-index-store-action-clear';
import {appModAuthPageIndexStoreSelector} from './store/mod-auth-page-index-store.selectors';
import { Injectable } from '@angular/core';

/** Мод "Auth". Страницы. Начало. Хранилище состояния. */
@Injectable()
export class AppModAuthPageIndexStore {

  /** @type {AppModAuthPageIndexState} */
  private state = new AppModAuthPageIndexState();

  /**
   * Конструктор.
   * @param {Store<AppModAuthStoreState>} extStore Хранилище состояния.
   */
  constructor(
    private extStore: Store<AppModAuthStoreState>
  ) {
    this.onStateMap = this.onStateMap.bind(this);
  }

  /**
   * Получить состояние.
   * @returns {AppModAuthPageIndexState} Состояние.
   */
  getState(): AppModAuthPageIndexState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModAuthPageIndexState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppModAuthPageIndexState> {
    return this.extStore.pipe(
      select(appModAuthPageIndexStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppModAuthPageIndexStoreActionClear());
  }

  /**
   * @param {AppModAuthPageIndexState} state
   * @returns {AppModAuthPageIndexState}
   */
  private onStateMap(state: AppModAuthPageIndexState): AppModAuthPageIndexState {
    this.state = state;

    return this.state;
  }
}
