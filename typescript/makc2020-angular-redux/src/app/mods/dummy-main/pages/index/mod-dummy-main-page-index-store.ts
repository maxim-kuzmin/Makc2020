// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppModDummyMainStoreState} from '@app/mods/dummy-main/store/mod-dummy-main-store.state';
import {AppModDummyMainPageIndexState} from './mod-dummy-main-page-index-state';
import {AppModDummyMainPageIndexStoreActionClear} from './store/actions/mod-dummy-main-page-index-store-action-clear';
import {appModDummyMainPageIndexStoreSelector} from './store/mod-dummy-main-page-index-store.selectors';
import { Injectable } from '@angular/core';

/** Мод "DummyMain". Страницы. Начало. Хранилище состояния. */
@Injectable()
export class AppModDummyMainPageIndexStore {

  /** @type {AppModDummyMainPageIndexState} */
  private state = new AppModDummyMainPageIndexState();

  /**
   * Конструктор.
   * @param {Store<AppModDummyMainStoreState>} extStore Хранилище состояния.
   */
  constructor(
    private extStore: Store<AppModDummyMainStoreState>
  ) {
    this.onStateMap = this.onStateMap.bind(this);
  }

  /**
   * Получить состояние.
   * @returns {AppModDummyMainPageIndexState} Состояние.
   */
  getState(): AppModDummyMainPageIndexState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModDummyMainPageIndexState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppModDummyMainPageIndexState> {
    return this.extStore.pipe(
      select(appModDummyMainPageIndexStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppModDummyMainPageIndexStoreActionClear());
  }

  /**
   * @param {AppModDummyMainPageIndexState} state
   * @returns {AppModDummyMainPageIndexState}
   */
  private onStateMap(state: AppModDummyMainPageIndexState): AppModDummyMainPageIndexState {
    this.state = state;

    return this.state;
  }
}
