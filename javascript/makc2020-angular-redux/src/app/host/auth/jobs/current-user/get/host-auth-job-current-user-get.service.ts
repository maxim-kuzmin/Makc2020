// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
// tslint:disable-next-line:max-line-length
import {AppCoreAuthTypeOidcJobCurrentUserGetService} from '@app/core/auth/types/oidc/jobs/current-user/get/core-auth-type-oidc-job-current-user-get.service';
import {AppCoreAuthTypeOidcService} from '@app/core/auth/types/oidc/core-auth-type-oidc.service';
import {AppCoreAuthTypeOidcStore} from '@app/core/auth/types/oidc/core-auth-type-oidc-store';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppHostAuthUser} from '@app/host/auth/host-auth-user';
import {AppHostAuthJobCurrentUserGetResult, appHostAuthJobCurrentUserGetResultCreate} from './host-auth-job-current-user-get-result';

/** Хост. Аутентификация. Задания. Текущий пользователь. Получение. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppHostAuthJobCurrentUserGetService {

  /**
   * Конструктор.
   * @param {AppCoreAuthTypeOidcService} appAuthTypeOidc Аутентификация типа OIDC.
   * @param {AppCoreAuthTypeOidcJobCurrentUserGetService} appAuthTypeOidcJobCurrentUserGet
   * Задание на получение текущего пользователя для аутентификации типа OIDC.
   * @param {AppCoreAuthTypeOidcStore} appAuthTypeOidcStore Хранилище состояния аутентификации типа OIDC.
   * @param {AppCoreExecutionService} appExecution Выполнение.
   * @param {AppCoreHttpService} appHttp HTTP.
   * @param {AppCoreNavigationService} appNavigation Навигация.
   */
  constructor(
    private appAuthTypeOidc: AppCoreAuthTypeOidcService,
    private appAuthTypeOidcJobCurrentUserGet: AppCoreAuthTypeOidcJobCurrentUserGetService,
    private appAuthTypeOidcStore: AppCoreAuthTypeOidcStore,
    private appExecution: AppCoreExecutionService,
    private appHttp: AppCoreHttpService,
    private appNavigation: AppCoreNavigationService
  ) {
  }

  /**
   * Выполнить.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @returns {Observable<AppHostAuthJobCurrentUserGetResult>} Результирующий поток.
   */
  execute$(
    logger: AppCoreLoggingService
  ): Observable<AppHostAuthJobCurrentUserGetResult> {
    if (this.appAuthTypeOidc.isEnabled) {
      const url = 'AppCoreAuthTypeOidcJobCurrentUserGetService.execute$';

      const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url);

      return this.appAuthTypeOidcJobCurrentUserGet.execute$(logger).pipe(
        map(
          output => {
            const result = appHostAuthJobCurrentUserGetResultCreate();

            if (output.data) {
              result.data = JSON.parse(output.data) as AppHostAuthUser;
            }

            result.isOk = true;

            return this.appExecution.onSuccess<AppHostAuthJobCurrentUserGetResult>(
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
      const url = this.appNavigation.createAbsoluteUrlOfApi('auth/current-user');

      const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url);

      return this.appHttp.get<AppHostAuthJobCurrentUserGetResult>(url)
        .pipe(
          map(
            result => this.appExecution.onSuccess<AppHostAuthJobCurrentUserGetResult>(
              jobName,
              result,
              logger
            )
          ),
          catchError(
            error => this.appExecution.onError$(
              jobName,
              error,
              logger
            )
          )
        );
    }
  }
}