// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppRootStoreState} from '@app/root/store/root-store.state';
import {AppRootPageContactsState} from './root-page-contacts-state';
import {AppRootPageContactsStoreActionClear} from './store/actions/root-page-contacts-store-action-clear';
import {appRootPageContactsStoreSelector} from './store/root-page-contacts-store.selectors';
import {AppRootPageContactsJobContentLoadInput} from './jobs/content/load/host-layout-footer-job-content-load-input';
import {AppRootPageContactsStoreActionLoad} from './store/actions/host-layout-footer-store-action-load';
import { Injectable } from '@angular/core';

/** Корень. Страницы. Контакты. Хранилище состояния. */
@Injectable()
export class AppRootPageContactsStore {

  /** @type {AppRootPageContactsState} */
  private state: AppRootPageContactsState;

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
   * @returns {AppRootPageContactsState} Состояние.
   */
  getState(): AppRootPageContactsState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppRootPageContactsState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppRootPageContactsState> {
    return this.extStore.pipe(
      select(appRootPageContactsStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppRootPageContactsStoreActionClear());
  }

  /**
   * Запустить действие "Загрузка".
   * @param {AppRootPageContactsJobContentLoadInput} input Ввод.
   */
  runActionLoad(input: AppRootPageContactsJobContentLoadInput) {
    this.extStore.dispatch(new AppRootPageContactsStoreActionLoad(input));
  }

  /**
   * @param {AppRootPageContactsState} state
   * @returns {AppRootPageContactsState}
   */
  private onStateMap(state: AppRootPageContactsState): AppRootPageContactsState {
    this.state = state;

    return this.state;
  }
}
