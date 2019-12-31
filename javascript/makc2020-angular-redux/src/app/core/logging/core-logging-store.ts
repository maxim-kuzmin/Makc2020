// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLoggingEnumActions} from './enums/core-logging-enum-actions';
import {AppCoreLoggingState} from './core-logging-state';

/** Ядро. Ошибка. Хранилище состояния. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreLoggingStore {

  /** @type {AppCoreLoggingState} */
  private state = new AppCoreLoggingState();

  /** @type {BehaviorSubject<AppCoreLoggingState>} */
  private readonly stateChanged$: BehaviorSubject<AppCoreLoggingState>;

  /** Конструктор. */
  constructor() {
    this.stateChanged$ = new BehaviorSubject<AppCoreLoggingState>(this.state);
  }

  /**
   * Получить состояние.
   * @type {AppCoreLoggingState} Состояние.
   */
  getState(): AppCoreLoggingState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @type {Observable<AppCoreLoggingState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppCoreLoggingState> {
    return this.stateChanged$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.setState({
      ...this.state,
      action: AppCoreLoggingEnumActions.Clear,
      errorData: undefined,
      errorMessage: undefined
    });
  }

  /**
   * Запустить действие "Зарегистрировать ошибку".
   * @param {boolean} errorIsUnhandled Признак того, что ошибка не обработана.
   * @param {string} errorMessage Сообщение об ошибке.
   * @param {any} errorData Данные ошибки.
   */
  runActionLogError(errorIsUnhandled: boolean, errorMessage: string, errorData: any) {
    this.setState({
      ...this.state,
      action: AppCoreLoggingEnumActions.LogError,
      errorData,
      errorIsUnhandled,
      errorMessage
    });
  }

  /** @param {AppCoreLoggingState} state */
  private setState(state: AppCoreLoggingState) {
    this.state = state;

    this.stateChanged$.next(this.state);
  }
}
