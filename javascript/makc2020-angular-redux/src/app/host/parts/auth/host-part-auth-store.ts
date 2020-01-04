// //Author Maxim Kuzmin//makc//

import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppHostPartAuthEnumActions} from './enums/host-part-auth-enum-actions';
import {AppHostPartAuthState} from './host-part-auth-state';
import {AppHostPartAuthUser} from './host-part-auth-user';
import {Injectable} from '@angular/core';

/** Хост. Часть "Auth". Хранилище состояния. */
@Injectable({
  providedIn: 'root'
})
export class AppHostPartAuthStore {

  /** @type {AppHostPartAuthUser} */
  private unknownUser = {
    id: 0,
    userName: 'UNKNOWN',
    email: '',
    fullName: 'Unknown user'
  } as AppHostPartAuthUser;

  /** @type {AppHostPartAuthState} */
  private state = new AppHostPartAuthState();

  /** @type {BehaviorSubject<AppHostPartAuthState>} */
  private readonly stateChanged$: BehaviorSubject<AppHostPartAuthState>;

  /** Конструктор. */
  constructor() {
    this.stateChanged$ = new BehaviorSubject<AppHostPartAuthState>(this.state);
  }

  /**
   * Получить состояние.
   * @type {AppHostPartAuthState} Состояние.
   */
  getState(): AppHostPartAuthState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @type {Observable<AppHostPartAuthState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppHostPartAuthState> {
    return this.stateChanged$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.setState({
      ...this.state,
      action: AppHostPartAuthEnumActions.Clear,
      currentUser: undefined,
      isLoggedIn: undefined,
      logonUrl: undefined,
      redirectUrl: undefined,
      registerUrl: undefined
    });
  }

  /**
   * Запустить действие "Инициализация".
   * @param {string} logonUrl URL входа в систему.
   * @param {string} registerUrl URL регистрации.
   */
  runActionInit(logonUrl: string, registerUrl: string) {
    this.setState({
      ...this.state,
      action: AppHostPartAuthEnumActions.Init,
      logonUrl: logonUrl,
      registerUrl: registerUrl
    });
  }

  /**
   * Запустить действие "Текущий пользователь. Установка".
   * @param {AppHostPartAuthUser} currentUser Текущий пользователь.
   */
  runActionCurrentUserSet(currentUser: AppHostPartAuthUser = null) {
    if (!currentUser) {
      currentUser = this.unknownUser;
    }

    const isLoggedIn = currentUser.id > 0;

    this.setState({
      ...this.state,
      action: AppHostPartAuthEnumActions.CurrentUserSet,
      currentUser: currentUser,
      isLoggedIn: isLoggedIn
    });
  }

  /**
   * URL для перенаправления после входа в систему. Установка.
   * @param {AppHostPartAuthUser} redirectUrl URL для перенаправления после входа в систему.
   */
  runActionRedirectUrlSet(redirectUrl: string) {
    this.setState({
      ...this.state,
      action: AppHostPartAuthEnumActions.RedirectUrlSet,
      redirectUrl: redirectUrl
    });
  }

  /** @param {AppHostPartAuthState} state */
  private setState(state: AppHostPartAuthState) {
    this.state = state;

    this.stateChanged$.next(this.state);
  }
}
