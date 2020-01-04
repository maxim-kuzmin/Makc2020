// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppHostPartMenuJobNodesFindInput} from '@app/host/parts/menu/jobs/nodes/find/host-part-menu-job-nodes-find-input';
import {AppHostStoreState} from '@app/host/store/host-store.state';
import {AppHostLayoutMenuState} from './host-layout-menu-state';
import {AppHostLayoutMenuStoreActionClear} from './store/actions/host-layout-menu-store-action-clear';
import {AppHostLayoutMenuStoreActionLoad} from './store/actions/host-layout-menu-store-action-load';
import {appHostLayoutMenuStoreSelector} from './store/host-layout-menu-store.selectors';

/** Хост. Разметка. Меню. Хранилище состояния. */
export class AppHostLayoutMenuStore {

  /** @type {number} */
  private menuLevel: number;

  /** @type {AppHostLayoutMenuState} */
  private state: AppHostLayoutMenuState;

  /**
   * Конструктор.
   * @param {Store<AppHostStoreState>} extStore Хранилище состояния.
   */
  constructor(
    private extStore: Store<AppHostStoreState>
  ) {
    this.onStateMap = this.onStateMap.bind(this);
  }

  /**
   * Получить состояние.
   * @returns {AppHostLayoutMenuState} Состояние.
   */
  getState(): AppHostLayoutMenuState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {number} menuLevel Уровень меню.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppHostLayoutMenuState>} Поток состояния.
   */
  getState$(menuLevel: number, unsubscribe$: Subject<boolean>): Observable<AppHostLayoutMenuState> {
    this.menuLevel = menuLevel;

    return this.extStore.pipe(
      select(appHostLayoutMenuStoreSelector, {menuLevel}),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /**
   * Запустить действие "Очистка".
   */
  runActionClear() {
    this.extStore.dispatch(new AppHostLayoutMenuStoreActionClear(this.menuLevel));
  }

  /**
   * Запустить действие "Загрузка".
   * @param {AppHostPartMenuJobNodesFindInput} input Ввод.
   */
  runActionLoad(input: AppHostPartMenuJobNodesFindInput) {
    this.extStore.dispatch(new AppHostLayoutMenuStoreActionLoad(input, this.menuLevel));
  }

  /**
   * @param {AppHostLayoutMenuState} state
   * @returns {AppHostLayoutMenuState}
   */
  private onStateMap(state: AppHostLayoutMenuState): AppHostLayoutMenuState {
    this.state = state;

    return this.state;
  }
}
