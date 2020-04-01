// //Author Maxim Kuzmin//makc//

import {AppDataObjectDummyTree} from '@app/data/objects/data-object-dummy-tree';

/** Мод "DummyTree". Задания. Элемент. Получение. Вывод. */
export interface AppModDummyTreeJobItemGetOutput {

  /**
   * Объект, где хранятся данные сущности "DummyTree".
   * @type {?AppDataObjectDummyTree}
   */
  objectDummyTree?: AppDataObjectDummyTree;
}

/** Мод "DummyTree". Задания. Элемент. Получение. Вывод. Создать. */
export function appModDummyTreeJobItemGetOutputCreate(): AppModDummyTreeJobItemGetOutput {
  return {} as AppModDummyTreeJobItemGetOutput;
}
