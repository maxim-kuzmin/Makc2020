// //Author Maxim Kuzmin//makc//

import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppHostPartCalendarLocale} from './host-part-calendar-locale';
import {AppSkinHostPartCalendarState} from './host-part-calendar-state';
import {AppHostPartCalendarEnumActions} from '@app/host/parts/calendar/enums/host-part-calendar-enum-actions';
import {Injectable} from '@angular/core';

/** Хост. Часть "Calendar". Хранилище состояния. */
@Injectable({
  providedIn: 'root'
})
export class AppSkinHostPartCalendarStore {

  /** @type {AppSkinHostPartCalendarState} */
  private state = new AppSkinHostPartCalendarState();

  /** @type {BehaviorSubject<AppSkinHostPartCalendarState>} */
  private readonly stateChanged$: BehaviorSubject<AppSkinHostPartCalendarState>;

  /** Конструктор. */
  constructor() {
    this.stateChanged$ = new BehaviorSubject<AppSkinHostPartCalendarState>(this.state);
  }

  /**
   * Получить состояние.
   * @returns {AppRootPageContactsState} Состояние.
   */
  getState(): AppSkinHostPartCalendarState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppSkinHostPartCalendarState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppSkinHostPartCalendarState> {
    return this.stateChanged$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.setState({
      ...this.state,
      action: AppHostPartCalendarEnumActions.Clear,
      languageKey: undefined,
      locale: undefined
    });
  }

  /**
   * Запустить действие "Загрузка".
   * @type {string} languageKey Ключ языка.
   * @type {AppHostPartCalendarLocale} locale Локаль.
   */
  runActionLoad(languageKey: string, locale: AppHostPartCalendarLocale) {
    this.setState({
      ...this.state,
      action: AppHostPartCalendarEnumActions.Load,
      languageKey,
      locale
    });
  }

  /** @param {AppSkinHostPartCalendarState} state */
  private setState(state: AppSkinHostPartCalendarState) {
    this.state = state;

    this.stateChanged$.next(this.state);
  }
}
