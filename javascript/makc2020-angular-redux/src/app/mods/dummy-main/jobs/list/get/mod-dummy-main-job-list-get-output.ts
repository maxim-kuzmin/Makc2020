// //Author Maxim Kuzmin//makc//

import {AppCoreCommonModJobListGetOutput} from '@app/core/common/mod/jobs/list/get/core-common-mod-job-list-get-output';
import {AppModDummyMainJobItemGetOutput} from '../../item/get/mod-dummy-main-job-item-get-output';

/** Мод "DummyMain". Задания. Список. Получение. Вывод. */
export interface AppModDummyMainJobListGetOutput
  extends AppCoreCommonModJobListGetOutput<AppModDummyMainJobItemGetOutput> {
}
