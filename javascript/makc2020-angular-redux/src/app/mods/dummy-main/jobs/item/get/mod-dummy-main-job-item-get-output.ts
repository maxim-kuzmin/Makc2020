// //Author Maxim Kuzmin//makc//

import {AppDataObjectDummyMain} from '@app/data/objects/data-object-dummy-main';
import {AppDataObjectDummyMainDummyManyToMany} from '@app/data/objects/data-object-dummy-main-dummy-many-to-many';
import {AppDataObjectDummyManyToMany} from '@app/data/objects/data-object-dummy-many-to-many';
import {AppDataObjectDummyOneToMany} from '@app/data/objects/data-object-dummy-one-to-many';

/** Мод "DummyMain". Задания. Элемент. Получение. Вывод. */
export interface AppModDummyMainJobItemGetOutput {

  /**
   * Объект, где хранятся данные сущности "DummyMain".
   * @type {?AppDataObjectDummyMain}
   */
  objectDummyMain?: AppDataObjectDummyMain;

  /**
   * Объект, где хранятся данные сущности "DummyManyToMany".
   * @type {?AppDataObjectDummyManyToMany[]}
   */
  objectsDummyManyToMany?: AppDataObjectDummyManyToMany[];

  /**
   * Объект, где хранятся данные сущности "DummyMainDummyManyToMany".
   * @type {?AppDataObjectDummyMainDummyManyToMany[]}
   */
  objectsDummyMainDummyManyToMany?: AppDataObjectDummyMainDummyManyToMany[];

  /**
   * Объект, где хранятся данные сущности "DummyOneToMany".
   * @type {?AppDataObjectDummyOneToMany}
   */
  objectDummyOneToMany?: AppDataObjectDummyOneToMany;
}

/** Мод "DummyMain". Задания. Элемент. Получение. Вывод. Создать. */
export function appModDummyMainJobItemGetOutputCreate(): AppModDummyMainJobItemGetOutput {
  return {} as AppModDummyMainJobItemGetOutput;
}
