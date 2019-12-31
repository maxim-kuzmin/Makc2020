// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionResultWithData, appCoreExecutionResultWithDataCreate} from '@app/core/execution/core-execution-result-with-data';
import {AppHostMenuJobNodesFindOutput} from './host-menu-job-nodes-find-output';

/** Хост. Меню. Задания. Узлы. Поиск. Результат. */
export interface AppHostMenuJobNodesFindResult
  extends AppCoreExecutionResultWithData<AppHostMenuJobNodesFindOutput> {
}

/** Хост. Меню. Задания. Узлы. Поиск. Результат. Создать. */
export function appHostMenuJobTreeGetResultCreate(): AppHostMenuJobNodesFindResult {
  return appCoreExecutionResultWithDataCreate<AppHostMenuJobNodesFindOutput>();
}
