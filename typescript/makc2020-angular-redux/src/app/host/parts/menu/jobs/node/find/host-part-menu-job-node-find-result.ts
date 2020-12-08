// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionResultWithData, appCoreExecutionResultWithDataCreate} from '@app/core/execution/core-execution-result-with-data';
import {AppHostPartMenuJobNodeFindOutput} from './host-part-menu-job-node-find-output';

/** Хост. Часть "Menu". Задания. Узел. Поиск. Результат. */
export interface AppHostPartMenuJobNodeFindResult
  extends AppCoreExecutionResultWithData<AppHostPartMenuJobNodeFindOutput> {
}

/** Хост. Часть "Menu". Задания. Узел. Поиск. Результат. Создать. */
export function appHostPartMenuJobListGetResultCreate(): AppHostPartMenuJobNodeFindResult {
  return appCoreExecutionResultWithDataCreate<AppHostPartMenuJobNodeFindOutput>();
}
