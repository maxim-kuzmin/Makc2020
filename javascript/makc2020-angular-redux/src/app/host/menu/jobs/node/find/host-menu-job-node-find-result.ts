// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionResultWithData, appCoreExecutionResultWithDataCreate} from '@app/core/execution/core-execution-result-with-data';
import {AppHostMenuJobNodeFindOutput} from './host-menu-job-node-find-output';

/** Хост. Меню. Задания. Узел. Поиск. Результат. */
export interface AppHostMenuJobNodeFindResult
  extends AppCoreExecutionResultWithData<AppHostMenuJobNodeFindOutput> {
}

/** Хост. Меню. Задания. Узел. Поиск. Результат. Создать. */
export function appHostMenuJobListGetResultCreate(): AppHostMenuJobNodeFindResult {
  return appCoreExecutionResultWithDataCreate<AppHostMenuJobNodeFindOutput>();
}
