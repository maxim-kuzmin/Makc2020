// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {EMPTY, from, Observable, of} from 'rxjs';
import {catchError, map, take} from 'rxjs/operators';
import {AppCoreAuthTypeOidcService} from '@app/core/auth/types/oidc/core-auth-type-oidc.service';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionResult, appCoreExecutionResultCreate} from '@app/core/execution/core-execution-result';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';

/** Ядро. Аутентификация. Типы. OIDC. Задания. Освежение токена. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreAuthTypeOidcJobRefreshTokenService {

  /**
   * Конструктор.
   * @param {AppCoreAuthTypeOidcService} appAuthTypeOidc Аутентификация типа OIDC.
   * @param {AppCoreExecutionService} appExecution Выполнение.
   */
  constructor(
    private appAuthTypeOidc: AppCoreAuthTypeOidcService,
    private appExecution: AppCoreExecutionService
  ) {
  }

  /**
   * Выполнить.
   * @param {AppCoreExecutionHandler} handler Обработчик.
   * @returns {Observable<AppCoreExecutionResult>} Результирующий поток.
   */
  execute$(
    handler: AppCoreExecutionHandler
  ): Observable<AppCoreExecutionResult> {
    if (this.appAuthTypeOidc.hasValidAccessToken()) {
      const result = appCoreExecutionResultCreate();

      result.isOk = true;

      return of(result);
    } else {
      const url = 'AppCoreAuthTypeOidcService.refreshToken';

      const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url);

      return from(this.appAuthTypeOidc.refreshToken()).pipe(
        take(1),
        map(obj => {
          const result = appCoreExecutionResultCreate();

          result.isOk = this.appAuthTypeOidc.hasValidAccessToken();

          return this.appExecution.onSuccess(
            jobName,
            result,
            handler
          );
        }),
        catchError(
          error => {
            if (error.status === 400) {
              return EMPTY;
            }

            return this.appExecution.onError$(
              jobName,
              error,
              handler
            );
          }
        )
      );
    }
  }
}
