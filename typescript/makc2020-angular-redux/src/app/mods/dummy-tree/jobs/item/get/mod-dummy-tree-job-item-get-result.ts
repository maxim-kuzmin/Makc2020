// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionResultWithData} from '@app/core/execution/core-execution-result-with-data';
import {AppModDummyTreeJobItemGetOutput} from './mod-dummy-tree-job-item-get-output';

/** Мод "DummyTree". Задания. Элемент. Получение. Результат. */
export interface AppModDummyTreeJobItemGetResult
  extends AppCoreExecutionResultWithData<AppModDummyTreeJobItemGetOutput> {
}
