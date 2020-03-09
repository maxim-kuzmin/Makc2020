// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppCoreAuthTypeOidcService} from '@app/core/auth/types/oidc/core-auth-type-oidc.service';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';

/** Ядро. Аутентификация. Типы. OIDC. Задания. Выход из системы. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreAuthTypeOidcJobLogoutService {

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
   */
  execute(
    handler: AppCoreExecutionHandler
  ) {
    const url = 'AppCoreAuthTypeOidcService.logout';

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url);

    try {
      this.appAuthTypeOidc.logout();
    } catch (error) {
      this.appExecution.onError(
        jobName,
        error,
        handler
      );
    }
  }
}
