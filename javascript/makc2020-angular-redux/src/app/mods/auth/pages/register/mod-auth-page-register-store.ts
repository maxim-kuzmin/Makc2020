// //Author Maxim Kuzmin//makc//

import {select, Store} from '@ngrx/store';
import {Observable, Subject} from 'rxjs';
import {map, takeUntil} from 'rxjs/operators';
import {AppHostAuthCommonJobRegisterInput} from '@app/host/auth/common/jobs/register/host-auth-common-job-register-input';
import {AppModAuthStoreState} from '../../store/mod-auth-store.state';
import {AppModAuthPageRegisterState} from './mod-auth-page-register-state';
import {AppModAuthPageRegisterStoreActionClear} from './store/actions/mod-auth-page-register-store-action-clear';
import {AppModAuthPageRegisterStoreActionSave} from './store/actions/mod-auth-page-register-store-action-save';
import {appModAuthPageRegisterStoreSelector} from './store/mod-auth-page-register-store.selectors';

/** Мод "Auth". Страницы. Регистрация. Хранилище состояния. */
export class AppModAuthPageRegisterStore {

  /** @type {AppModAuthPageRegisterState} */
  private state = new AppModAuthPageRegisterState();

  /**
   * Конструктор.
   * @param {Store<AppModAuthStoreState>} extStore Хранилище состояния.
   */
  constructor(
    private extStore: Store<AppModAuthStoreState>
  ) {
    this.onStateMap = this.onStateMap.bind(this);
  }
  /**
   * Получить состояние.
   * @returns {AppModAuthPageRegisterState} Состояние.
   */
  getState(): AppModAuthPageRegisterState {
    return this.state;
  }

  /**
   * Получить поток состояния.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModAuthPageRegisterState>} Поток состояния.
   */
  getState$(unsubscribe$: Subject<boolean>): Observable<AppModAuthPageRegisterState> {
    return this.extStore.pipe(
      select(appModAuthPageRegisterStoreSelector),
      map(this.onStateMap),
      takeUntil(unsubscribe$)
    );
  }

  /** Запустить действие "Очистка". */
  runActionClear() {
    this.extStore.dispatch(new AppModAuthPageRegisterStoreActionClear());
  }

  /**
   * Запустить действие "Сохранение".
   * @param {AppHostAuthCommonJobRegisterInput} input Ввод.
   */
  runActionSave(input: AppHostAuthCommonJobRegisterInput) {
    this.extStore.dispatch(new AppModAuthPageRegisterStoreActionSave(input));
  }

  /**
   * @param {AppModAuthPageRegisterState} state
   * @returns {AppModAuthPageRegisterState}
   */
  private onStateMap(state: AppModAuthPageRegisterState): AppModAuthPageRegisterState {
    this.state = state;

    return this.state;
  }
}
