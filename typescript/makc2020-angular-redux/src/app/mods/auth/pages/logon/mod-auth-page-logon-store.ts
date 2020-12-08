// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppHostPartAuthCommonJobLoginInput} from '@app/host/parts/auth/common/jobs/login/host-part-auth-common-job-login-input';
import {AppHostPartAuthUser} from '@app/host/parts/auth/host-part-auth-user';
import {AppModAuthStoreState} from '../../store/mod-auth-store.state';
import {AppModAuthPageLogonState} from './mod-auth-page-logon-state';
import {AppModAuthPageLogonStoreActionClear} from './store/actions/mod-auth-page-logon-store-action-clear';
import {AppModAuthPageLogonStoreActionLoad} from './store/actions/mod-auth-page-logon-store-action-load';
import {AppModAuthPageLogonStoreActionLogin} from './store/actions/mod-auth-page-logon-store-action-login';
import {AppModAuthPageLogonStoreActionLogout} from './store/actions/mod-auth-page-logon-store-action-logout';
import {appModAuthPageLogonStoreSelector} from './store/mod-auth-page-logon-store.selectors';
import { Injectable } from '@angular/core';

/** Мод "Auth". Страницы. Вход в систему. Хранилище состояния. */
@Injectable()
export class AppModAuthPageLogonStore {

  /** @type {AppModAuthPageLogonState} */
  private state = new AppModAuthPageLogonState();

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
   * @returns {AppModAuthPageLogonState} Состояние.
   */
  getState(): AppModAuthPageLogonState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModAuthPageLogonState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppModAuthPageLogonState> {
    return this.extStore.pipe(
      select(appModAuthPageLogonStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppModAuthPageLogonStoreActionClear());
  }

  /**
   * Запустить действие "Загрузка".
   * @param {AppHostPartAuthUser} currentUser Текущий пользователь.
   * @param {boolean} isLoggedIn Признак того, что вход в систему выполнен.
   */
  runActionLoad(currentUser: AppHostPartAuthUser, isLoggedIn: boolean) {
    this.extStore.dispatch(new AppModAuthPageLogonStoreActionLoad(currentUser, isLoggedIn));
  }

  /**
   * Запустить действие "Вход в систему".
   * @param {AppHostPartAuthCommonJobLoginInput} input Ввод.
   */
  runActionLogin(input: AppHostPartAuthCommonJobLoginInput) {
    this.extStore.dispatch(new AppModAuthPageLogonStoreActionLogin(input));
  }

  /**
   * Запустить действие "Выход из системы".
   * @param {AppHostPartAuthUser} currentUser Текущий пользователь.
   * @param {boolean} isLoggedIn Признак того, что вход в систему выполнен.
   */
  runActionLogout(currentUser: AppHostPartAuthUser, isLoggedIn: boolean) {
    this.extStore.dispatch(new AppModAuthPageLogonStoreActionLogout(currentUser, isLoggedIn));
  }

  /**
   * @param {AppModAuthPageLogonState} state
   * @returns {AppModAuthPageLogonState}
   */
  private onStateMap(state: AppModAuthPageLogonState): AppModAuthPageLogonState {
    this.state = state;

    return this.state;
  }
}
