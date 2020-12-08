// //Author Maxim Kuzmin//makc//

import {appModDummyMainConfigFullPath} from '@app/mods/dummy-main/mod-dummy-main-config';

/** Мод "DummyMain". Страницы. Элемент. Путь. */
const appModDummyMainPageItemConfigPath = 'item';

/** Мод "DummyMain". Страницы. Элемент. Конфигурация. Индекс. */
export const appModDummyMainPageItemConfigIndex = '1';

/** Мод "DummyMain". Страницы. Элемент. Конфигурация. Маршрут. Путь. */
export const appModDummyMainPageItemConfigRoutePath = appModDummyMainPageItemConfigPath;

/** Мод "DummyMain". Страницы. Элемент. Конфигурация. Полный путь. */
const appModDummyMainPageItemConfigFullPath =
  `${appModDummyMainConfigFullPath}/${appModDummyMainPageItemConfigPath}`;

/** Мод "DummyMain". Страницы. Элемент. Редактирование. Конфигурация. Ключ. */
export const appModDummyMainPageItemConfigKey = 'ModDummyMainPageItem';

// Create

/** Мод "DummyMain". Страницы. Элемент. Создание. Конфигурация. Путь. */
const appModDummyMainPageItemCreateConfigPath = 'create';

/** Мод "DummyMain". Страницы. Элемент. Создание. Конфигурация. Маршрут. Путь. */
export const appModDummyMainPageItemCreateConfigRoutePath = appModDummyMainPageItemCreateConfigPath;

/** Мод "DummyMain". Страницы. Элемент. Создание. Конфигурация. Полный путь. */
export const appModDummyMainPageItemCreateConfigFullPath =
  `${appModDummyMainPageItemConfigFullPath}/${appModDummyMainPageItemCreateConfigPath}`;

/** Мод "DummyMain". Страницы. Элемент. Создание. Конфигурация. Ключ. */
export const appModDummyMainPageItemCreateConfigKey = 'ModDummyMainPageItemCreate';

/** Мод "DummyMain". Страницы. Элемент. Создание. Конфигурация. Заголовок. Ресурс. Ключ. */
export const appModDummyMainPageItemCreateConfigTitleResourceKey = 'Создать';

// Edit

/** Мод "DummyMain". Страницы. Элемент. Редактирование. Конфигурация. Путь. */
const appModDummyMainPageItemEditConfigPath = 'edit';

/** Мод "DummyMain". Страницы. Элемент. Редактирование. Конфигурация. Маршрут. Путь. */
export const appModDummyMainPageItemEditConfigRoutePath =
  `${appModDummyMainPageItemEditConfigPath}/:id${appModDummyMainPageItemConfigIndex}`;

/** Мод "DummyMain". Страницы. Элемент. Редактирование. Конфигурация. Полный путь. */
export const appModDummyMainPageItemEditConfigFullPath =
  `${appModDummyMainPageItemConfigFullPath}/${appModDummyMainPageItemEditConfigPath}`;

/** Мод "DummyMain". Страницы. Элемент. Редактирование. Конфигурация. Ключ. */
export const appModDummyMainPageItemEditConfigKey = 'ModDummyMainPageItemEdit';

/** Мод "DummyMain". Страницы. Элемент. Редактирование. Конфигурация. Заголовок. Ресурс. Ключ. */
export const appModDummyMainPageItemEditConfigTitleResourceKey = 'Изменить';

// View

/** Мод "DummyMain". Страницы. Элемент. Просмотр. Конфигурация. Путь. */
const appModDummyMainPageItemViewConfigPath = 'view';

/** Мод "DummyMain". Страницы. Элемент. Просмотр. Конфигурация. Маршрут. Путь. */
export const appModDummyMainPageItemViewConfigRoutePath =
  `${appModDummyMainPageItemViewConfigPath}/:id${appModDummyMainPageItemConfigIndex}`;

/** Мод "DummyMain". Страницы. Элемент. Просмотр. Конфигурация. Полный путь. */
export const appModDummyMainPageItemViewConfigFullPath =
  `${appModDummyMainPageItemConfigFullPath}/${appModDummyMainPageItemViewConfigPath}`;

/** Мод "DummyMain". Страницы. Элемент. Просмотр. Конфигурация. Ключ. */
export const appModDummyMainPageItemViewConfigKey = 'ModDummyMainPageItemView';

/** Мод "DummyMain". Страницы. Элемент. Просмотр. Конфигурация. Заголовок. Ресурс. Ключ. */
export const appModDummyMainPageItemViewConfigTitleResourceKey = 'Просмотреть';
