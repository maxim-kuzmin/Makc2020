// //Author Maxim Kuzmin//makc//

import {AppRootPageContactsState} from '@app/root/pages/contacts/root-page-contacts-state';
import {AppRootPageIndexState} from '@app/root/pages/index/root-page-index-state';
import {AppRootPageAdministrationState} from '@app/root/pages/administration/root-page-administration-state';
import {AppRootPageSiteState} from '@app/root/pages/site/root-page-site-state';
import {AppRootPageErrorState} from '@app/root/pages/error/root-page-error-state';

/** Корень. Хранилище состояния. Состояния. */
export interface AppRootStoreStates {

  /**
   * Страница "Администрирование".
   * @type {AppRootPageContactsState}
   */
  pageAdministration: AppRootPageAdministrationState;

  /**
   * Страница "Контакты".
   * @type {AppRootPageContactsState}
   */
  pageContacts: AppRootPageContactsState;

  /**
   * Страница "Ошибка".
   * @type {AppRootPageErrorState}
   */
  pageError: AppRootPageErrorState;

  /**
   * Страница "Начало".
   * @type {AppRootPageIndexState}
   */
  pageIndex: AppRootPageIndexState;

  /**
   * Страница "Сайт".
   * @type {AppRootPageSiteState}
   */
  pageSite: AppRootPageSiteState;
}
