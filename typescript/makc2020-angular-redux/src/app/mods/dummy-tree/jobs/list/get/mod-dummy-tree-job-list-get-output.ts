// //Author Maxim Kuzmin//makc//

import {AppCoreCommonModJobListGetOutput} from '@app/core/common/mod/jobs/list/get/core-common-mod-job-list-get-output';
import {AppModDummyTreeJobItemGetOutput} from '../../item/get/mod-dummy-tree-job-item-get-output';

/** Мод "DummyTree". Задания. Список. Получение. Вывод. */
export interface AppModDummyTreeJobListGetOutput
  extends AppCoreCommonModJobListGetOutput<AppModDummyTreeJobItemGetOutput> {
}
