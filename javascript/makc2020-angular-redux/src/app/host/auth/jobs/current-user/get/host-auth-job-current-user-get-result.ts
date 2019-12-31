// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionResultWithData} from '@app/core/execution/core-execution-result-with-data';
import {AppHostAuthUser} from '@app/host/auth/host-auth-user';

/** Хост. Аутентификация. Задания. Текущий пользователь. Получение. Результат. */
export interface AppHostAuthJobCurrentUserGetResult
  extends AppCoreExecutionResultWithData<AppHostAuthUser> {
}

/**
 * Хост. Аутентификация. Задания. Текущий пользователь. Получение. Результат. Создать.
 * @returns {AppHostAuthJobCurrentUserGetResult}
 */
export function appHostAuthJobCurrentUserGetResultCreate(): AppHostAuthJobCurrentUserGetResult {
  return {
    isOk: false,
    errorMessages: [],
    successMessages: [],
    warningMessages: []
  } as AppHostAuthJobCurrentUserGetResult;
}

