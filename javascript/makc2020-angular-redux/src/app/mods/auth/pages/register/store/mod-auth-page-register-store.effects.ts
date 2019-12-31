// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Action} from '@ngrx/store';
import {Observable} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostAuthService} from '@app/host/auth/host-auth.service';
import {AppModAuthPageRegisterEnumActions} from '../enums/mod-auth-page-register-enum-actions';
import {AppModAuthPageRegisterStoreActionSaveSuccess} from './actions/mod-auth-page-register-store-action-save-success';
import {AppModAuthPageRegisterStoreActions} from './mod-auth-page-register-store.actions';

/** Мод "Auth". Страницы. Вход в систему. Хранилище состояния. Эффекты. */
@Injectable()
export class AppModAuthPageRegisterStoreEffects {

  /**
   * Сохранение.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  save$: Observable<Action> = this.extActions$.pipe(
    ofType(AppModAuthPageRegisterEnumActions.Save),
    switchMap(
      action =>
        this.appAuth.register$(
          this.appLogger,
          action.jobRegisterInput
        ).pipe(
          map(
            result =>
              new AppModAuthPageRegisterStoreActionSaveSuccess(result)
          )
        )
    )
  );

  /**
   * Конструктор.
   * @param {AppHostAuthService} appAuth Аутентификация.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {Actions<AppModAuthPageRegisterStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private appAuth: AppHostAuthService,
    private appLogger: AppCoreLoggingService,
    private extActions$: Actions<AppModAuthPageRegisterStoreActions>
  ) { }
}
