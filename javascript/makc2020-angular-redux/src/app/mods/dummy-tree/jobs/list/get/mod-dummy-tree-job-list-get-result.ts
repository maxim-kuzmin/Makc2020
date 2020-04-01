// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionResultWithData} from '@app/core/execution/core-execution-result-with-data';
import {AppModDummyTreeJobListGetOutput} from './mod-dummy-tree-job-list-get-output';

/** Мод "DummyTree". Задания. Список. Получение. Результат. */
export interface AppModDummyTreeJobListGetResult
  extends AppCoreExecutionResultWithData<AppModDummyTreeJobListGetOutput> {
}
