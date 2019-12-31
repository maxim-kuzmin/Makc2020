// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationEnumActions} from './enums/core-localization-enum-actions';
import {AppCoreLocalizationState} from './core-localization-state';

/** Ядро. Локализация. Хранилище состояния. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreLocalizationStore {

  /** @type {AppCoreLocalizationState} */
  private state = new AppCoreLocalizationState();

  /** @type {BehaviorSubject<AppCoreLocalizationState>} */
  private readonly stateChanged$: BehaviorSubject<AppCoreLocalizationState>;

  /** Конструктор. */
  constructor() {
    this.stateChanged$ = new BehaviorSubject<AppCoreLocalizationState>(this.state);
  }

  /**
   * Получить состояние.
   * @type {AppCoreLocalizationState} Состояние.
   */
  getState(): AppCoreLocalizationState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @type {Observable<AppCoreLocalizationState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppCoreLocalizationState> {
    return this.stateChanged$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.setState({
      ...this.state,
      action: AppCoreLocalizationEnumActions.Clear,
      languageKey: undefined
    });
  }

  /**
   * Запустить действие "Язык. Установка".
   * @param {string} languageKey Ключ языка.
   */
  runActionLanguageSet(languageKey: string) {
    this.setState({
      ...this.state,
      action: AppCoreLocalizationEnumActions.LanguageSet,
      languageKey
    });
  }

  /** @param {AppCoreLocalizationState} state */
  private setState(state: AppCoreLocalizationState) {
    this.state = state;

    this.stateChanged$.next(this.state);
  }
}
