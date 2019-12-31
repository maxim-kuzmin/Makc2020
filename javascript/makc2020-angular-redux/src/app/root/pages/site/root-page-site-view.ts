// //Author Maxim Kuzmin//makc//

import {appModAuthPageIndexConfigFullPath} from '@app/mods/auth/pages/index/mod-auth-page-index-config';
import {appRootPageContactsConfigFullPath} from '@app/root/pages/contacts/root-page-contacts-config';

/** Корень. Страницы. Сайт. Вид. */
export class AppRootPageSiteView {

  /**
   * Ссылка маршрутизатора на страницу "ModAuthPageIndex".
   * @type {any[]}
   */
  routerLinkToModAuthPageIndex: any[];

  /**
   * Ссылка маршрутизатора на страницу "RootPageContacts".
   * @type {any[]}
   */
  routerLinkToRootPageContacts: any[];
}
