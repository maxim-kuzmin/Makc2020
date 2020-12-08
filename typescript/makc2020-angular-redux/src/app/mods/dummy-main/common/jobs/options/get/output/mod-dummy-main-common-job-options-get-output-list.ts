// //Author Maxim Kuzmin//makc//

import {AppCoreCommonModJobOptionsGetOutputList} from '@app/core/common/mod/jobs/options/get/output/core-common-mod-job-options-get-output-list';
import {AppModDummyMainCommonJobOptionsGetOutputItem} from './mod-dummy-main-common-job-options-get-output-item';

/** Мод "DummyMain". Общее. Задания. Варианты выбора. Получение. Вывод. Список. */
export interface AppModDummyMainCommonJobOptionsGetOutputList
  extends AppCoreCommonModJobOptionsGetOutputList<AppModDummyMainCommonJobOptionsGetOutputItem> {
}

/** Мод "DummyMain". Общее. Задания. Варианты выбора. Получение. Вывод. Список. Создать. */
export function appModDummyMainCommonJobOptionsGetOutputListCreate(): AppModDummyMainCommonJobOptionsGetOutputList {
  return {
    items: []
  } as AppModDummyMainCommonJobOptionsGetOutputList;
}
