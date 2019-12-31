// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppRootStoreState} from '@app/root/store/root-store.state';
import {AppRootPageAdministrationState} from './root-page-administration-state';
import {AppRootPageAdministrationStoreActionClear} from './store/actions/root-page-administration-store-action-clear';
import {appRootPageAdministrationStoreSelector} from './store/root-page-administration-store.selectors';

/** Корень. Страницы. Администрирование. Хранилище состояния. */
export class AppRootPageAdministrationStore {

  /** @type {AppRootPageAdministrationState} */
  private state: AppRootPageAdministrationState;

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
   * @returns {AppRootPageAdministrationState} Состояние.
   */
  getState(): AppRootPageAdministrationState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppRootPageAdministrationState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppRootPageAdministrationState> {
    return this.extStore.pipe(
      select(appRootPageAdministrationStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppRootPageAdministrationStoreActionClear());
  }

  /**
   * @param {AppRootPageAdministrationState} state
   * @returns {AppRootPageAdministrationState}
   */
  private onStateMap(state: AppRootPageAdministrationState): AppRootPageAdministrationState {
    this.state = state;

    return this.state;
  }
}
