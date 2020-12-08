// //Author Maxim Kuzmin//makc//

import {appModAuthConfigFullPath} from '@app/mods/auth/mod-auth-config';

/** Мод "Auth". Страницы. Перенаправление. Конфигурация. Путь. */
const appModAuthPageRedirectConfigPath = 'redirect';

/** Мод "Auth". Страницы. Перенаправление. Конфигурация. Маршрут. Путь. */
export const appModAuthPageRedirectConfigRoutePath = appModAuthPageRedirectConfigPath;

/** Мод "Auth". Страницы. Перенаправление. Конфигурация. Полный путь. */
export const appModAuthPageRedirectConfigFullPath =
  `${appModAuthConfigFullPath}/${appModAuthPageRedirectConfigPath}`;

/** Мод "Auth". Страницы. Перенаправление. Конфигурация. Ключ. */
export const appModAuthPageRedirectConfigKey = 'ModAuthPageRedirect';

/** Мод "Auth". Страницы. Перенаправление. Конфигурация. Заголовок. Ресурс. Ключ. */
export const appModAuthPageRedirectConfigTitleResourceKey = 'Перенаправление';
