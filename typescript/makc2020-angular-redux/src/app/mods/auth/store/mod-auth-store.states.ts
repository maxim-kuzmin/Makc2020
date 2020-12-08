// //Author Maxim Kuzmin//makc//

import {AppModAuthPageIndexState} from '../pages/index/mod-auth-page-index-state';
import {AppModAuthPageLogonState} from '../pages/logon/mod-auth-page-logon-state';
import {AppModAuthPageRedirectState} from '../pages/redirect/mod-auth-page-redirect-state';
import {AppModAuthPageRegisterState} from '../pages/register/mod-auth-page-register-state';

/** Мод "Auth". Хранилище состояния. Состояния. */
export interface AppModAuthStoreStates {

  /**
   * Страница. Начало.
   * @type {AppModAuthPageIndexState}
   */
  pageIndex: AppModAuthPageIndexState;

  /**
   * Страница. Ввод.
   * @type {AppModAuthPageLogonState}
   */
  pageLogon: AppModAuthPageLogonState;

  /**
   * Страница. Перенаправление.
   * @type {AppModAuthPageRedirectState}
   */
  pageRedirect: AppModAuthPageRedirectState;

  /**
   * Страница. Регистрация.
   * @type {AppModAuthPageRegisterState}
   */
  pageRegister: AppModAuthPageRegisterState;
}
