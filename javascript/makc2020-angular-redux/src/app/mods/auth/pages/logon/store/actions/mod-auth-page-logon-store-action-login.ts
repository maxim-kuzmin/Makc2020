// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppHostAuthCommonJobLoginInput} from '@app/host/auth/common/jobs/login/host-auth-common-job-login-input';
import {AppModAuthPageLogonEnumActions} from '../../enums/mod-auth-page-logon-enum-actions';

/** Мод "Auth". Страницы. Вход в систему. Хранилище состояния. Действия. Вход в систему. */
export class AppModAuthPageLogonStoreActionLogin implements Action {

  /** @inheritDoc */
  readonly type = AppModAuthPageLogonEnumActions.Login;

  /**
   * Конструктор.
   * @param {AppHostAuthCommonJobLoginInput} jobLoginInput
   * Ввод для задания на вход в систему.
   */
  constructor(
    public jobLoginInput: AppHostAuthCommonJobLoginInput
  ) {
  }
}
