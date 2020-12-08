// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppHostPartAuthCommonJobRegisterInput} from '@app/host/parts/auth/common/jobs/register/host-part-auth-common-job-register-input';
import {AppModAuthPageRegisterEnumActions} from '../../enums/mod-auth-page-register-enum-actions';

/** Мод "Auth". Страницы. Регистрация. Хранилище состояния. Действия. Сохранение. */
export class AppModAuthPageRegisterStoreActionSave implements Action {

  /** @inheritDoc */
  readonly type = AppModAuthPageRegisterEnumActions.Save;

  /**
   * Конструктор.
   * @param {AppHostPartAuthCommonJobRegisterInput} jobRegisterInput
   * Ввод задания на регистрацию.
   */
  constructor(
    public jobRegisterInput: AppHostPartAuthCommonJobRegisterInput
  ) { }
}
