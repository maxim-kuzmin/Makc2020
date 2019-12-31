// //Author Maxim Kuzmin//makc//

import { AppCoreExecutionResultWithData } from '@app/core/execution/core-execution-result-with-data';
import { AppHostAuthUser } from '../../../host-auth-user';

/** Хост. Аутентификация. Общее. Задания. Регистрация. Результат. */
export interface AppHostAuthCommonJobRegisterResult
  extends AppCoreExecutionResultWithData<AppHostAuthUser> {
}
