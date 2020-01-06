// //Author Maxim Kuzmin//makc//

import { AppCoreExecutionResultWithData } from '@app/core/execution/core-execution-result-with-data';
import { AppHostPartAuthUser } from '../../../host-part-auth-user';

/** Хост. Часть "Auth". Общее. Задания. Регистрация. Результат. */
export interface AppHostPartAuthCommonJobRegisterResult
  extends AppCoreExecutionResultWithData<AppHostPartAuthUser> {
}
