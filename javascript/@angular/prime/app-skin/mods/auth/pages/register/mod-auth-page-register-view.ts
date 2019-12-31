// //Author Maxim Kuzmin//makc//

import {NgForm} from '@angular/forms';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppModAuthPageRegisterView} from '@app/mods/auth/pages/register/mod-auth-page-register-view';
import {AppModAuthPageRegisterSettingErrors} from '@app/mods/auth/pages/register/settings/mod-auth-page-register-setting-errors';
import {AppModAuthPageRegisterSettingFields} from '@app/mods/auth/pages/register/settings/mod-auth-page-register-setting-fields';

/** Мод "Auth". Страницы. Регистрация. Представление. */
export class AppSkinModAuthPageRegisterView extends AppModAuthPageRegisterView {

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {NgForm} */
  private ctrlForm: NgForm;

  /**
   * Конструктор.
   * @param {AppModAuthPageRegisterSettingErrors} settingErrors Ресурсы.
   * @param {AppModAuthPageRegisterSettingFields} settingFields Настройки.
   */
  constructor(
    settingErrors: AppModAuthPageRegisterSettingErrors,
    settingFields: AppModAuthPageRegisterSettingFields,
  ) {
    super(
      settingErrors,
      settingFields
    );
  }

  /**
   * Инициализировать.
   * @param {AppSkinCoreProgressSpinnerDirective} ctrlRefresh Элемент управления "Спиннер обновления".
   * @param {NgForm} ctrlForm Элемент управления "Форма".
   */
  init(
    ctrlRefresh: AppSkinCoreProgressSpinnerDirective,
    ctrlForm: NgForm
  ) {
    this.ctrlRefresh = ctrlRefresh;
    this.ctrlForm = ctrlForm;
  }

  /** @inheritDoc */
  hideRefreshSpinner() {
    this.ctrlRefresh.hide();
  }

  /** @inheritDoc */
  initRefreshSpinner() {
    this.ctrlRefresh.init();
  }

  /** @inheritDoc */
  resetForm() {
    this.ctrlForm.resetForm();
  }

  /** @inheritDoc */
  showRefreshSpinner() {
    this.ctrlRefresh.show();
  }
}
