// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionResultWithData, appCoreExecutionResultWithDataCreate} from '@app/core/execution/core-execution-result-with-data';
import {AppHostPartMenuJobNodesFindOutput} from './host-part-menu-job-nodes-find-output';

/** Хост. Часть "Menu". Задания. Узлы. Поиск. Результат. */
export interface AppHostPartMenuJobNodesFindResult
  extends AppCoreExecutionResultWithData<AppHostPartMenuJobNodesFindOutput> {
}

/** Хост. Часть "Menu". Задания. Узлы. Поиск. Результат. Создать. */
export function appHostPartMenuJobTreeGetResultCreate(): AppHostPartMenuJobNodesFindResult {
  return appCoreExecutionResultWithDataCreate<AppHostPartMenuJobNodesFindOutput>();
}
