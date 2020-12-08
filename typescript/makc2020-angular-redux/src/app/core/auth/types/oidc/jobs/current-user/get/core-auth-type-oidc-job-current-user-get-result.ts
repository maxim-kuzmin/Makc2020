// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionResultWithData} from '@app/core/execution/core-execution-result-with-data';

/** Ядро. Аутентификация. Типы. OIDC. Задания. Текущий пользователь. Получение. Результат. */
export interface AppCoreAuthTypeOidcJobCurrentUserGetResult
  extends AppCoreExecutionResultWithData<string> {
}

/**
 * Ядро. Аутентификация. Типы. OIDC. Задания. Текущий пользователь. Получение. Результат. Создать.
 * @returns {AppCoreAuthTypeOidcJobCurrentUserGetResult}
 */
export function appCoreAuthTypeOidcJobCurrentUserGetResultCreate(): AppCoreAuthTypeOidcJobCurrentUserGetResult {
  return {
    isOk: false,
    errorMessages: [],
    successMessages: [],
    warningMessages: []
  } as AppCoreAuthTypeOidcJobCurrentUserGetResult;
}

