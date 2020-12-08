// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreExceptionEnumActions} from './enums/core-exception-enum-actions';
import {AppCoreExceptionState} from './core-exception-state';

/** Ядро. Исключение. Хранилище состояния. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreExceptionStore {

  /** @type {AppCoreExceptionState} */
  private state = new AppCoreExceptionState();

  /** @type {BehaviorSubject<AppCoreExceptionState>} */
  private readonly stateChanged$: BehaviorSubject<AppCoreExceptionState>;

  /** Конструктор. */
  constructor() {
    this.stateChanged$ = new BehaviorSubject<AppCoreExceptionState>(this.state);
  }

  /**
   * Получить состояние.
   * @type {AppCoreExceptionState} Состояние.
   */
  getState(): AppCoreExceptionState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @type {Observable<AppCoreExceptionState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppCoreExceptionState> {
    return this.stateChanged$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.setState({
      ...this.state,
      action: AppCoreExceptionEnumActions.Clear,
      error: undefined,
      message: undefined
    });
  }

  /**
   * Запустить действие "Зарегистрировать ошибку".
   * @param {string} message Сообщение.
   * @param {any} error Ошибка.
   */
  runActionThrow(message: string, error: any) {
    this.setState({
      ...this.state,
      action: AppCoreExceptionEnumActions.Throw,
      error,
      message
    });
  }

  /** @param {AppCoreExceptionState} state */
  private setState(state: AppCoreExceptionState) {
    this.state = state;

    this.stateChanged$.next(this.state);
  }
}
