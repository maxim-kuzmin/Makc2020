// //Author Maxim Kuzmin//makc//

import {AppModAuthPageRegisterStoreActionClear} from './actions/mod-auth-page-register-store-action-clear';
import {AppModAuthPageRegisterStoreActionSave} from './actions/mod-auth-page-register-store-action-save';
import {AppModAuthPageRegisterStoreActionSaveSuccess} from './actions/mod-auth-page-register-store-action-save-success';

/** Мод "Auth". Страницы. Регистрация. Хранилище состояния. Действия. */
export type AppModAuthPageRegisterStoreActions =
  | AppModAuthPageRegisterStoreActionClear
  | AppModAuthPageRegisterStoreActionSave
  | AppModAuthPageRegisterStoreActionSaveSuccess;
