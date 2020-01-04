// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppHostAuthCommonJobRegisterInput} from '@app/host/parts/auth/common/jobs/register/host-auth-common-job-register-input';
import {AppHostAuthCommonJobRegisterResult} from '@app/host/parts/auth/common/jobs/register/host-auth-common-job-register-result';
import {AppModAuthPageRegisterEnumActions} from './enums/mod-auth-page-register-enum-actions';

/** Мод "Auth". Страницы. Регистрация. Состояние. */
export class AppModAuthPageRegisterState extends AppCoreCommonState<AppModAuthPageRegisterEnumActions> {

  /**
   * Ввод задания на регистрацию.
   * @type {AppHostAuthCommonJobRegisterInput}
   */
  jobRegisterInput: AppHostAuthCommonJobRegisterInput;

  /**
   * Результат выполнения задания на регистрацию.
   * @type {AppHostAuthCommonJobRegisterResult}
   */
  jobRegisterResult: AppHostAuthCommonJobRegisterResult;
}
