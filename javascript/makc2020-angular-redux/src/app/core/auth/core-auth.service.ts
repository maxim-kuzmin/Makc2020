// //Author Maxim Kuzmin//makc//

import {AppCoreAuthEnumTypes} from '@app/core/auth/enums/core-auth-enum-types';
import {appCoreConfigAuthType} from '@app/core/core-config';

/** Ядро. Аутентификация. Сервис. */
export abstract class AppCoreAuthService {

  /**
   * Тип аутентификации.
   * @type {AppCoreAuthEnumTypes}
   */
  protected get authType(): AppCoreAuthEnumTypes {
    return appCoreConfigAuthType;
  }
}
