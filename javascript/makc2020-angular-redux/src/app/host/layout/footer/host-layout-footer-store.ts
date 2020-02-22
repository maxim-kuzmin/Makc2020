// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppHostStoreState} from '@app/host/store/host-store.state';
import {AppHostLayoutFooterState} from './host-layout-footer-state';
import {AppHostLayoutFooterStoreActionClear} from './store/actions/host-layout-footer-store-action-clear';
import {AppHostLayoutFooterStoreActionLoad} from './store/actions/host-layout-footer-store-action-load';
import {appHostLayoutFooterStoreSelector} from './store/host-layout-footer-store.selectors';
import {AppHostLayoutFooterJobContentLoadInput} from '@app/host/layout/footer/jobs/content/load/host-layout-footer-job-content-load-input';
import { Injectable } from '@angular/core';

/** Хост. Разметка. Подвал. Хранилище состояния. */
@Injectable()
export class AppHostLayoutFooterStore {

  /** @type {AppHostLayoutFooterState} */
  private state: AppHostLayoutFooterState;

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
   * @returns {AppHostLayoutFooterState} Состояние.
   */
  getState(): AppHostLayoutFooterState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppHostLayoutFooterState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppHostLayoutFooterState> {
    return this.extStore.pipe(
      select(appHostLayoutFooterStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppHostLayoutFooterStoreActionClear());
  }

  /**
   * Запустить действие "Загрузка".
   * @param {AppHostLayoutFooterJobContentLoadInput} input Ввод.
   */
  runActionLoad(input: AppHostLayoutFooterJobContentLoadInput) {
    this.extStore.dispatch(new AppHostLayoutFooterStoreActionLoad(input));
  }

  /**
   * @param {AppHostLayoutFooterState} state
   * @returns {AppHostLayoutFooterState}
   */
  private onStateMap(state: AppHostLayoutFooterState): AppHostLayoutFooterState {
    this.state = state;

    return this.state;
  }
}
