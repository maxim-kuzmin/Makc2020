// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {from, Observable, of} from 'rxjs';
import {catchError, map, take} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreAuthTypeOidcService} from '@app/core/auth/types/oidc/core-auth-type-oidc.service';
import {AppCoreAuthTypeOidcStore} from '@app/core/auth/types/oidc/core-auth-type-oidc-store';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {
  AppCoreAuthTypeOidcJobCurrentUserGetResult,
  appCoreAuthTypeOidcJobCurrentUserGetResultCreate
} from './core-auth-type-oidc-job-current-user-get-result';

/** Ядро. Аутентификация. Типы. OIDC. Задания. Текущий пользователь. Получение. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreAuthTypeOidcJobCurrentUserGetService {

  /**
   * Конструктор.
   * @param {AppCoreAuthTypeOidcService} appAuthTypeOidc Аутентификация типа OIDC.
   * @param {AppCoreAuthTypeOidcStore} appAuthTypeOidcStore Хранилище состояния аутентификации типа OIDC.
   * @param {AppCoreExecutionService} appExecution Выполнение.
   */
  constructor(
    private appAuthTypeOidc: AppCoreAuthTypeOidcService,
    private appAuthTypeOidcStore: AppCoreAuthTypeOidcStore,
    private appExecution: AppCoreExecutionService,
  ) {
  }

  /**
   * Выполнить.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @returns {Observable<AppCoreAuthTypeOidcJobCurrentUserGetResult>} Результирующий поток.
   */
  execute$(
    logger: AppCoreLoggingService
  ): Observable<AppCoreAuthTypeOidcJobCurrentUserGetResult> {
    const url = 'AppCoreAuthTypeOidcService.loadUserProfile';

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url);

    if (this.appAuthTypeOidc.hasValidAccessToken()) {
      return from(this.appAuthTypeOidc.loadUserProfile()).pipe(
        take(1),
        map(
          obj => {
            const result = appCoreAuthTypeOidcJobCurrentUserGetResultCreate();

            if (obj) {
              result.data = obj['User'];
            }

            result.isOk = true;

            return this.appExecution.onSuccess<AppCoreAuthTypeOidcJobCurrentUserGetResult>(
              jobName,
              result,
              logger
            );
          }
        ),
        catchError(
          error => this.appExecution.onError$(
            jobName,
            error,
            logger
          )
        )
      );
    } else {
      const result = appCoreAuthTypeOidcJobCurrentUserGetResultCreate();

      result.isOk = true;

      return of(this.appExecution.onSuccess<AppCoreAuthTypeOidcJobCurrentUserGetResult>(
        jobName,
        result,
        logger
      ));
    }
  }
}
