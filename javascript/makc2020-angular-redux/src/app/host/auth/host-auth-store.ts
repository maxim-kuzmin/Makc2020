// //Author Maxim Kuzmin//makc//

import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppHostAuthEnumActions} from './enums/host-auth-enum-actions';
import {AppHostAuthState} from './host-auth-state';
import {AppHostAuthUser} from './host-auth-user';
import {Injectable} from '@angular/core';

/** Хост. Аутентификация. Хранилище состояния. */
@Injectable({
  providedIn: 'root'
})
export class AppHostAuthStore {

  /** @type {AppHostAuthUser} */
  private unknownUser = {
    id: 0,
    userName: 'UNKNOWN',
    email: '',
    fullName: 'Unknown user'
  } as AppHostAuthUser;

  /** @type {AppHostAuthState} */
  private state = new AppHostAuthState();

  /** @type {BehaviorSubject<AppHostAuthState>} */
  private readonly stateChanged$: BehaviorSubject<AppHostAuthState>;

  /** Конструктор. */
  constructor() {
    this.stateChanged$ = new BehaviorSubject<AppHostAuthState>(this.state);
  }

  /**
   * Получить состояние.
   * @type {AppHostAuthState} Состояние.
   */
  getState(): AppHostAuthState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @type {Observable<AppHostAuthState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppHostAuthState> {
    return this.stateChanged$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.setState({
      ...this.state,
      action: AppHostAuthEnumActions.Clear,
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
      action: AppHostAuthEnumActions.Init,
      logonUrl: logonUrl,
      registerUrl: registerUrl
    });
  }

  /**
   * Запустить действие "Текущий пользователь. Установка".
   * @param {AppHostAuthUser} currentUser Текущий пользователь.
   */
  runActionCurrentUserSet(currentUser: AppHostAuthUser = null) {
    if (!currentUser) {
      currentUser = this.unknownUser;
    }

    const isLoggedIn = currentUser.id > 0;

    this.setState({
      ...this.state,
      action: AppHostAuthEnumActions.CurrentUserSet,
      currentUser: currentUser,
      isLoggedIn: isLoggedIn
    });
  }

  /**
   * URL для перенаправления после входа в систему. Установка.
   * @param {AppHostAuthUser} redirectUrl URL для перенаправления после входа в систему.
   */
  runActionRedirectUrlSet(redirectUrl: string) {
    this.setState({
      ...this.state,
      action: AppHostAuthEnumActions.RedirectUrlSet,
      redirectUrl: redirectUrl
    });
  }

  /** @param {AppHostAuthState} state */
  private setState(state: AppHostAuthState) {
    this.state = state;

    this.stateChanged$.next(this.state);
  }
}
