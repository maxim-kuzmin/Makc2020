// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppCoreAuthTypeOidcJobLoginInput} from './core-auth-type-oidc-job-login-input';
import {AppCoreAuthTypeOidcService} from '@app/core/auth/types/oidc/core-auth-type-oidc.service';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';

/** Ядро. Аутентификация. Типы. OIDC. Задания. Вход в систему. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreAuthTypeOidcJobLoginService {

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
   * @param {AppCoreAuthTypeOidcJobLoginInput} input Ввод.
   * @param {AppCoreExecutionHandler} handler Обработчик.
   */
  execute(
    input: AppCoreAuthTypeOidcJobLoginInput,
    handler: AppCoreExecutionHandler
  ) {
    const url = 'AppCoreAuthTypeOidcService.login';

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url);

    try {
      this.appAuthTypeOidc.login(input.returnUrl);
    } catch (error) {
      this.appExecution.onError(
        jobName,
        error,
        handler
      );
    }
  }
}
