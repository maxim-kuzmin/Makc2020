// //Author Maxim Kuzmin//makc//

import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppHostPartMenuEnumActions} from './enums/host-part-menu-enum-actions';
import {AppHostPartMenuOption} from './host-part-menu-option';
import {AppHostPartMenuState} from './host-part-menu-state';

/** Хост. Часть "Menu". Хранилище состояния. */
export class AppHostPartMenuStore {

  /** @type {AppHostPartMenuState} */
  private state = new AppHostPartMenuState();

  /** @type {BehaviorSubject<AppHostPartMenuState>} */
  private readonly stateChanged$: BehaviorSubject<AppHostPartMenuState>;

  /** Конструктор */
  constructor() {
    this.stateChanged$ = new BehaviorSubject<AppHostPartMenuState>(this.state);
  }

  /**
   * Получить состояние.
   * @returns {AppHostPartMenuState} Состояние.
   */
  getState(): AppHostPartMenuState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppHostPartMenuState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppHostPartMenuState> {
    return this.stateChanged$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.setState({
      ...this.state,
      action: AppHostPartMenuEnumActions.Clear,
      menuNodeKey: undefined,
      lookupOptionByMenuNodeKey: undefined
    });
  }

  /**
   * Запустить действие "Установка".
   * @param {string} menuNodeKey Ключ узла меню.
   * @param {[key: string]: AppHostMenuOption} lookupOptionByMenuNodeKey Поиск варианта по ключу узла меню.
   */
  runActionSet(menuNodeKey: string, lookupOptionByMenuNodeKey: { [key: string]: AppHostPartMenuOption }) {
    this.setState({
      ...this.state,
      action: AppHostPartMenuEnumActions.Set,
      menuNodeKey,
      lookupOptionByMenuNodeKey
    });
  }

  /** @param {AppHostPartMenuState} state */
  private setState(state: AppHostPartMenuState) {
    this.state = state;

    this.stateChanged$.next(this.state);
  }
}
