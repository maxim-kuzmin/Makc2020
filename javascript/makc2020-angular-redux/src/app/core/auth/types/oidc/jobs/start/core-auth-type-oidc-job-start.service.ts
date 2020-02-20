// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {from, Observable} from 'rxjs';
import {catchError, map, take} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionResult, appCoreExecutionResultCreate} from '@app/core/execution/core-execution-result';
import {AppCoreAuthTypeOidcService} from '@app/core/auth/types/oidc/core-auth-type-oidc.service';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreAuthTypeOidcJobStartInput} from './core-auth-type-oidc-job-start-input';

/** Ядро. Аутентификация. Типы. OIDC. Задания. Запуск. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreAuthTypeOidcJobStartService {

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
   * @param {AppCoreLoggingService} logger Регистратор.
   * @param {AppCoreAuthTypeOidcJobStartInput} input Ввод.
   * @returns {Observable<AppCoreExecutionResult>} Результирующий поток.
   */
  execute$(
    logger: AppCoreLoggingService,
    input: AppCoreAuthTypeOidcJobStartInput
  ): Observable<AppCoreExecutionResult> {
    const url = 'AppCoreAuthTypeOidcService.start';

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url, input);

    return from(this.appAuthTypeOidc.start(input.redirectUrl)).pipe(
      take(1),
      map(isLoggedIn => {
        const result = appCoreExecutionResultCreate();

        result.isOk = true;

        return result;
      }),
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
