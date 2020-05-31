// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {CookieService} from 'ngx-cookie-service';
import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationEnumActions} from './enums/core-localization-enum-actions';
import {AppCoreLocalizationState} from './core-localization-state';
import {appCoreSettings} from '@app/core/core-settings';

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
  constructor(
    private cookieService: CookieService
  ) {
    this.state.languageKey = this.cookieService.get(appCoreSettings.hostLangParamName);

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
    this.cookieService.delete(appCoreSettings.hostLangParamName);

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
    if (this.state.languageKey !== languageKey) {
      this.cookieService.set(appCoreSettings.hostLangParamName, languageKey);
    }

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
