// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionResultWithData} from '@app/core/execution/core-execution-result-with-data';
import {AppModDummyMainJobListGetOutput} from './mod-dummy-main-job-list-get-output';

/** Мод "DummyMain". Задания. Список. Получение. Результат. */
export interface AppModDummyMainJobListGetResult
  extends AppCoreExecutionResultWithData<AppModDummyMainJobListGetOutput> {
}
