// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppModAuthStoreState} from '@app/mods/auth/store/mod-auth-store.state';
import {AppModAuthPageRedirectState} from './mod-auth-page-redirect-state';
import {AppModAuthPageRedirectStoreActionClear} from './store/actions/mod-auth-page-redirect-store-action-clear';
import {appModAuthPageRedirectStoreSelector} from './store/mod-auth-page-redirect-store.selectors';
import {AppModAuthPageRedirectStoreActionLoad} from '@app/mods/auth/pages/redirect/store/actions/mod-auth-page-redirect-store-action-load';
import { Injectable } from "@angular/core";

/** Мод "Auth". Страницы. Перенаправление. Хранилище состояния. */
@Injectable()
export class AppModAuthPageRedirectStore {

  /** @type {AppModAuthPageRedirectState} */
  private state = new AppModAuthPageRedirectState();

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
   * @returns {AppModAuthPageRedirectState} Состояние.
   */
  getState(): AppModAuthPageRedirectState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModAuthPageRedirectState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppModAuthPageRedirectState> {
    return this.extStore.pipe(
      select(appModAuthPageRedirectStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppModAuthPageRedirectStoreActionClear());
  }

  /** Запустить действие "Загрузка". */
  runActionLoad() {
    this.extStore.dispatch(new AppModAuthPageRedirectStoreActionLoad());
  }

  /**
   * @param {AppModAuthPageRedirectState} state
   * @returns {AppModAuthPageRedirectState}
   */
  private onStateMap(state: AppModAuthPageRedirectState): AppModAuthPageRedirectState {
    this.state = state;

    return this.state;
  }
}
