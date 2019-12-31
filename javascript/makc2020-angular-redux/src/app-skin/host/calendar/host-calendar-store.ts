// //Author Maxim Kuzmin//makc//

import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppHostCalendarLocale} from './host-calendar-locale';
import {AppSkinHostCalendarState} from './host-calendar-state';
import {AppHostCalendarEnumActions} from '@app/host/calendar/enums/host-calendar-enum-actions';
import {Injectable} from '@angular/core';

/** Хост. Календарь. Хранилище состояния. */
@Injectable({
  providedIn: 'root'
})
export class AppSkinHostCalendarStore {

  /** @type {AppSkinHostCalendarState} */
  private state = new AppSkinHostCalendarState();

  /** @type {BehaviorSubject<AppSkinHostCalendarState>} */
  private readonly stateChanged$: BehaviorSubject<AppSkinHostCalendarState>;

  /** Конструктор. */
  constructor() {
    this.stateChanged$ = new BehaviorSubject<AppSkinHostCalendarState>(this.state);
  }

  /**
   * Получить состояние.
   * @returns {AppRootPageContactsState} Состояние.
   */
  getState(): AppSkinHostCalendarState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppSkinHostCalendarState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppSkinHostCalendarState> {
    return this.stateChanged$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.setState({
      ...this.state,
      action: AppHostCalendarEnumActions.Clear,
      languageKey: undefined,
      locale: undefined
    });
  }

  /**
   * Запустить действие "Загрузка".
   * @type {string} languageKey Ключ языка.
   * @type {AppHostCalendarLocale} locale Локаль.
   */
  runActionLoad(languageKey: string, locale: AppHostCalendarLocale) {
    this.setState({
      ...this.state,
      action: AppHostCalendarEnumActions.Load,
      languageKey,
      locale
    });
  }

  /** @param {AppSkinHostCalendarState} state */
  private setState(state: AppSkinHostCalendarState) {
    this.state = state;

    this.stateChanged$.next(this.state);
  }
}
