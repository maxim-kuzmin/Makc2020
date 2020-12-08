// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionResultWithData} from '@app/core/execution/core-execution-result-with-data';
import {AppHostPartAuthCommonJobLoginJwtOutput} from './host-part-auth-common-job-login-jwt-output';

/** Хост. Часть "Auth". Общее. Задания. Вход в систему. JWT. Результат. */
export interface AppHostPartAuthCommonJobLoginJwtResult
  extends AppCoreExecutionResultWithData<AppHostPartAuthCommonJobLoginJwtOutput> {
}
