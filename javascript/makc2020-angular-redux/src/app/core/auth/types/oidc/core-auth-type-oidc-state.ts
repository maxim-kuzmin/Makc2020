// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreAuthTypeOidcEnumActions} from './enums/core-auth-type-oidc-enum-actions';

/** Ядро. Аутентификация. Типы. OIDC. Состояние. */
export class AppCoreAuthTypeOidcState extends AppCoreCommonState<AppCoreAuthTypeOidcEnumActions> {

  /**
   * Признак завершения инициализации.
   * @type {boolean}
   */
  isInitialized: boolean;
}
