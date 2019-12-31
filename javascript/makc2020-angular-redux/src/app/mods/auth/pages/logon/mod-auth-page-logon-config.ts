// //Author Maxim Kuzmin//makc//

import {appModAuthConfigFullPath} from '@app/mods/auth/mod-auth-config';

/** Мод "Auth". Страницы. Вход в систему. Конфигурация. Путь. */
const appModAuthPageLogonConfigPath = 'logon';

/** Мод "Auth". Страницы. Вход в систему. Конфигурация. Маршрут. Путь. */
export const appModAuthPageLogonConfigRoutePath = appModAuthPageLogonConfigPath;

/** Мод "Auth". Страницы. Вход в систему. Конфигурация. Полный путь. */
export const appModAuthPageLogonConfigFullPath =
  `${appModAuthConfigFullPath}/${appModAuthPageLogonConfigPath}`;

/** Мод "Auth". Страницы. Вход в систему. Конфигурация. Ключ. */
export const appModAuthPageLogonConfigKey = 'ModAuthPageLogon';

/** Мод "Auth". Страницы. Вход в систему. Конфигурация. Заголовок. Ресурс. Ключ. */
export const appModAuthPageLogonConfigTitleResourceKey = 'Вход в систему';
