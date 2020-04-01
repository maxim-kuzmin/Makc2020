// //Author Maxim Kuzmin//makc//

import {appModDummyTreeConfigFullPath} from '@app/mods/dummy-tree/mod-dummy-tree-config';

/** Мод "DummyTree". Страницы. Элемент. Путь. */
const appModDummyTreePageItemConfigPath = 'item';

/** Мод "DummyTree". Страницы. Элемент. Конфигурация. Индекс. */
export const appModDummyTreePageItemConfigIndex = '1';

/** Мод "DummyTree". Страницы. Элемент. Конфигурация. Маршрут. Путь. */
export const appModDummyTreePageItemConfigRoutePath = appModDummyTreePageItemConfigPath;

/** Мод "DummyTree". Страницы. Элемент. Конфигурация. Полный путь. */
const appModDummyTreePageItemConfigFullPath =
  `${appModDummyTreeConfigFullPath}/${appModDummyTreePageItemConfigPath}`;

/** Мод "DummyTree". Страницы. Элемент. Редактирование. Конфигурация. Ключ. */
export const appModDummyTreePageItemConfigKey = 'ModDummyTreePageItem';

// Create

/** Мод "DummyTree". Страницы. Элемент. Создание. Конфигурация. Путь. */
const appModDummyTreePageItemCreateConfigPath = 'create';

/** Мод "DummyTree". Страницы. Элемент. Создание. Конфигурация. Маршрут. Путь. */
export const appModDummyTreePageItemCreateConfigRoutePath = appModDummyTreePageItemCreateConfigPath;

/** Мод "DummyTree". Страницы. Элемент. Создание. Конфигурация. Полный путь. */
export const appModDummyTreePageItemCreateConfigFullPath =
  `${appModDummyTreePageItemConfigFullPath}/${appModDummyTreePageItemCreateConfigPath}`;

/** Мод "DummyTree". Страницы. Элемент. Создание. Конфигурация. Ключ. */
export const appModDummyTreePageItemCreateConfigKey = 'ModDummyTreePageItemCreate';

/** Мод "DummyTree". Страницы. Элемент. Создание. Конфигурация. Заголовок. Ресурс. Ключ. */
export const appModDummyTreePageItemCreateConfigTitleResourceKey = 'Создать';

// Edit

/** Мод "DummyTree". Страницы. Элемент. Редактирование. Конфигурация. Путь. */
const appModDummyTreePageItemEditConfigPath = 'edit';

/** Мод "DummyTree". Страницы. Элемент. Редактирование. Конфигурация. Маршрут. Путь. */
export const appModDummyTreePageItemEditConfigRoutePath =
  `${appModDummyTreePageItemEditConfigPath}/:id${appModDummyTreePageItemConfigIndex}`;

/** Мод "DummyTree". Страницы. Элемент. Редактирование. Конфигурация. Полный путь. */
export const appModDummyTreePageItemEditConfigFullPath =
  `${appModDummyTreePageItemConfigFullPath}/${appModDummyTreePageItemEditConfigPath}`;

/** Мод "DummyTree". Страницы. Элемент. Редактирование. Конфигурация. Ключ. */
export const appModDummyTreePageItemEditConfigKey = 'ModDummyTreePageItemEdit';

/** Мод "DummyTree". Страницы. Элемент. Редактирование. Конфигурация. Заголовок. Ресурс. Ключ. */
export const appModDummyTreePageItemEditConfigTitleResourceKey = 'Изменить';

// View

/** Мод "DummyTree". Страницы. Элемент. Просмотр. Конфигурация. Путь. */
const appModDummyTreePageItemViewConfigPath = 'view';

/** Мод "DummyTree". Страницы. Элемент. Просмотр. Конфигурация. Маршрут. Путь. */
export const appModDummyTreePageItemViewConfigRoutePath =
  `${appModDummyTreePageItemViewConfigPath}/:id${appModDummyTreePageItemConfigIndex}`;

/** Мод "DummyTree". Страницы. Элемент. Просмотр. Конфигурация. Полный путь. */
export const appModDummyTreePageItemViewConfigFullPath =
  `${appModDummyTreePageItemConfigFullPath}/${appModDummyTreePageItemViewConfigPath}`;

/** Мод "DummyTree". Страницы. Элемент. Просмотр. Конфигурация. Ключ. */
export const appModDummyTreePageItemViewConfigKey = 'ModDummyTreePageItemView';

/** Мод "DummyTree". Страницы. Элемент. Просмотр. Конфигурация. Заголовок. Ресурс. Ключ. */
export const appModDummyTreePageItemViewConfigTitleResourceKey = 'Просмотреть';
