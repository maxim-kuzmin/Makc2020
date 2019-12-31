// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreTitleEnumActions} from './enums/core-title-enum-actions';
import {AppCoreTitleDataItem} from './data/core-title-data-item';
import {AppCoreTitleState} from './core-title-state';

/** Ядро. Заголовок. Хранилище состояния. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreTitleStore {

  /** @type {AppCoreTitleState} */
  private state = new AppCoreTitleState();

  /** @type {BehaviorSubject<AppCoreTitleState>} */
  private readonly stateChanged$: BehaviorSubject<AppCoreTitleState>;

  /** Конструктор. */
  constructor() {
    this.stateChanged$ = new BehaviorSubject<AppCoreTitleState>(this.state);
  }

  /**
   * Получить состояние.
   * @type {AppCoreTitleState} Состояние.
   */
  getState(): AppCoreTitleState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$
   * @type {Observable<AppCoreTitleState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppCoreTitleState> {
    return this.stateChanged$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.setState({
      ...this.state,
      action: AppCoreTitleEnumActions.Clear,
      items: undefined
    });
  }

  /**
   * Запустить действие "Элемент. Добавление".
   * @param {AppCoreTitleDataItem[]} items Элементы.
   */
  runActionItemAdd(items: AppCoreTitleDataItem[]) {
    this.setState({
      ...this.state,
      action: AppCoreTitleEnumActions.ItemAdd,
      items: items
    });
  }

  /**
   * Запустить действие "Элемент. Обновление".
   * @param {AppCoreTitleDataItem[]} items Элементы.
   */
  runActionItemUpdate(items: AppCoreTitleDataItem[]) {
    this.setState({
      ...this.state,
      action: AppCoreTitleEnumActions.ItemUpdate,
      items: items
    });
  }

  /**
   * Запустить действие "Последние элементы. Удаление".
   * @param {AppCoreTitleDataItem[]} items Элементы.
   */
  runActionLastItemsRemove(items: AppCoreTitleDataItem[]) {
    this.setState({
      ...this.state,
      action: AppCoreTitleEnumActions.LastItemsRemove,
      items: items
    });
  }

  /** @param {AppCoreTitleState} state */
  private setState(state: AppCoreTitleState) {
    this.state = state;

    this.stateChanged$.next(this.state);
  }
}
