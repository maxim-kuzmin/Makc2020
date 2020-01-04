// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionResultWithData} from '@app/core/execution/core-execution-result-with-data';
import {AppHostPartAuthUser} from '@app/host/parts/auth/host-part-auth-user';

/** Хост. Часть "Auth". Задания. Текущий пользователь. Получение. Результат. */
export interface AppHostPartAuthJobCurrentUserGetResult
  extends AppCoreExecutionResultWithData<AppHostPartAuthUser> {
}

/**
 * Хост. Часть "Auth". Задания. Текущий пользователь. Получение. Результат. Создать.
 * @returns {AppHostPartAuthJobCurrentUserGetResult}
 */
export function appHostAuthJobCurrentUserGetResultCreate(): AppHostPartAuthJobCurrentUserGetResult {
  return {
    isOk: false,
    errorMessages: [],
    successMessages: [],
    warningMessages: []
  } as AppHostPartAuthJobCurrentUserGetResult;
}

