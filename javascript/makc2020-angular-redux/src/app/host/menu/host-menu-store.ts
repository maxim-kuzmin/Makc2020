// //Author Maxim Kuzmin//makc//

import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppHostMenuEnumActions} from './enums/host-menu-enum-actions';
import {AppHostMenuOption} from './host-menu-option';
import {AppHostMenuState} from './host-menu-state';

/** Хост. Меню. Хранилище состояния. */
export class AppHostMenuStore {

  /** @type {AppHostMenuState} */
  private state = new AppHostMenuState();

  /** @type {BehaviorSubject<AppHostMenuState>} */
  private readonly stateChanged$: BehaviorSubject<AppHostMenuState>;

  /** Конструктор */
  constructor() {
    this.stateChanged$ = new BehaviorSubject<AppHostMenuState>(this.state);
  }

  /**
   * Получить состояние.
   * @returns {AppHostMenuState} Состояние.
   */
  getState(): AppHostMenuState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppHostMenuState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppHostMenuState> {
    return this.stateChanged$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.setState({
      ...this.state,
      action: AppHostMenuEnumActions.Clear,
      menuNodeKey: undefined,
      lookupOptionByMenuNodeKey: undefined
    });
  }

  /**
   * Запустить действие "Установка".
   * @param {string} menuNodeKey Ключ узла меню.
   * @param {[key: string]: AppHostMenuOption} lookupOptionByMenuNodeKey Поиск варианта по ключу узла меню.
   */
  runActionSet(menuNodeKey: string, lookupOptionByMenuNodeKey: {[key: string]: AppHostMenuOption}) {
    this.setState({
      ...this.state,
      action: AppHostMenuEnumActions.Set,
      menuNodeKey,
      lookupOptionByMenuNodeKey
    });
  }

  /** @param {AppHostMenuState} state */
  private setState(state: AppHostMenuState) {
    this.state = state;

    this.stateChanged$.next(this.state);
  }
}
