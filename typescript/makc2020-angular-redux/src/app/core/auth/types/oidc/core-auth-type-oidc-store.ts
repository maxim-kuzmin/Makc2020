// //Author Maxim Kuzmin//makc//

import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreAuthTypeOidcEnumActions} from './enums/core-auth-type-oidc-enum-actions';
import {AppCoreAuthTypeOidcState} from './core-auth-type-oidc-state';
import {Injectable} from '@angular/core';

/** Ядро. Аутентификация. Типы. OIDC. Хранилище состояния. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreAuthTypeOidcStore {

  /** @type {AppCoreAuthTypeOidcState} */
  private state = new AppCoreAuthTypeOidcState();

  /** @type {BehaviorSubject<AppHostAuthState>} */
  private readonly stateChanged$: BehaviorSubject<AppCoreAuthTypeOidcState>;

  /** Конструктор. */
  constructor() {
    this.stateChanged$ = new BehaviorSubject<AppCoreAuthTypeOidcState>(this.state);
  }

  /**
   * Получить состояние.
   * @type {AppCoreAuthTypeOidcState} Состояние.
   */
  getState(): AppCoreAuthTypeOidcState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @type {Observable<AppCoreAuthTypeOidcState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppCoreAuthTypeOidcState> {
    return this.stateChanged$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.setState({
      ...this.state,
      action: AppCoreAuthTypeOidcEnumActions.Clear,
      isInitialized: undefined
    });
  }

  /**
   * Запустить действие "Признак завершения инициализации. Установка".
   * @param {boolean} isInitialized Признак завершения инициализации.
   */
  runActionIsInitializedSet(isInitialized: boolean) {
    this.setState({
      ...this.state,
      action: AppCoreAuthTypeOidcEnumActions.IsInitializedSet,
      isInitialized: isInitialized
    });
  }

  /** @param {AppHostAuthState} state */
  private setState(state: AppCoreAuthTypeOidcState) {
    this.state = state;

    this.stateChanged$.next(this.state);
  }
}
