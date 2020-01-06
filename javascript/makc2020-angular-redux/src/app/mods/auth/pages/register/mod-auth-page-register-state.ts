// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppHostPartAuthCommonJobRegisterInput} from '@app/host/parts/auth/common/jobs/register/host-part-auth-common-job-register-input';
import {AppHostPartAuthCommonJobRegisterResult} from '@app/host/parts/auth/common/jobs/register/host-part-auth-common-job-register-result';
import {AppModAuthPageRegisterEnumActions} from './enums/mod-auth-page-register-enum-actions';

/** Мод "Auth". Страницы. Регистрация. Состояние. */
export class AppModAuthPageRegisterState extends AppCoreCommonState<AppModAuthPageRegisterEnumActions> {

  /**
   * Ввод задания на регистрацию.
   * @type {AppHostPartAuthCommonJobRegisterInput}
   */
  jobRegisterInput: AppHostPartAuthCommonJobRegisterInput;

  /**
   * Результат выполнения задания на регистрацию.
   * @type {AppHostPartAuthCommonJobRegisterResult}
   */
  jobRegisterResult: AppHostPartAuthCommonJobRegisterResult;
}
