// //Author Maxim Kuzmin//makc//

import {AppCoreCommonModJobOptionsGetOutputItem} from '@app/core/common/mod/jobs/options/get/output/core-common-mod-job-options-get-output-item';

/** Мод "DummyMain". Общее. Задания. Варианты выбора. Получение. Вывод. Элемент. */
export interface AppModDummyMainCommonJobOptionsGetOutputItem
  extends AppCoreCommonModJobOptionsGetOutputItem<number> {
}

/** Мод "DummyMain". Общее. Задания. Варианты выбора. Получение. Вывод. Элемент. Создать. */
export function appModDummyMainCommonJobOptionsGetOutputItemCreate(): AppModDummyMainCommonJobOptionsGetOutputItem {
  return {} as AppModDummyMainCommonJobOptionsGetOutputItem;
}
