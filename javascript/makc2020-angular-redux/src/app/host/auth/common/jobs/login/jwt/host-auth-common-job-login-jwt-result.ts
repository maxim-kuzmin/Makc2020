// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionResultWithData} from '@app/core/execution/core-execution-result-with-data';
import {AppHostAuthCommonJobLoginJwtOutput} from './host-auth-common-job-login-jwt-output';

/** Хост. Аутентификация. Общее. Задания. Вход в систему. JWT. Результат. */
export interface AppHostAuthCommonJobLoginJwtResult
  extends AppCoreExecutionResultWithData<AppHostAuthCommonJobLoginJwtOutput> {
}
