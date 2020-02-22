// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppRootStoreState} from '@app/root/store/root-store.state';
import {AppRootPageSiteState} from './root-page-site-state';
import {AppRootPageSiteStoreActionClear} from './store/actions/root-page-site-store-action-clear';
import {appRootPageSiteStoreSelector} from './store/root-page-site-store.selectors';
import { Injectable } from "@angular/core";

/** Корень. Страницы. Сайт. Хранилище состояния. */
@Injectable()
export class AppRootPageSiteStore {

  /** @type {AppRootPageSiteState} */
  private state: AppRootPageSiteState;

  /**
   * Конструктор.
   * @param {Store<AppRootStoreState>} extStore Хранилище состояния.
   */
  constructor(
    private extStore: Store<AppRootStoreState>
  ) {
    this.onStateMap = this.onStateMap.bind(this);
  }

  /**
   * Получить состояние.
   * @returns {AppRootPageSiteState} Состояние.
   */
  getState(): AppRootPageSiteState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppRootPageSiteState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppRootPageSiteState> {
    return this.extStore.pipe(
      select(appRootPageSiteStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppRootPageSiteStoreActionClear());
  }

  /**
   * @param {AppRootPageSiteState} state
   * @returns {AppRootPageSiteState}
   */
  private onStateMap(state: AppRootPageSiteState): AppRootPageSiteState {
    this.state = state;

    return this.state;
  }
}
