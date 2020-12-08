// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionResultWithData, appCoreExecutionResultWithDataCreate} from '@app/core/execution/core-execution-result-with-data';

/** Хост. Разметка. Подвал. Задания. Содержимое. Загрузка. Результат. */
export interface AppHostLayoutFooterJobContentLoadResult
  extends AppCoreExecutionResultWithData<string> {
}

/** Хост. Разметка. Подвал. Задания. Содержимое. Загрузка. Создать. */
export function appHostLayoutFooterJobContentLoadResultCreate(): AppHostLayoutFooterJobContentLoadResult {
  return appCoreExecutionResultWithDataCreate<string>();
}
