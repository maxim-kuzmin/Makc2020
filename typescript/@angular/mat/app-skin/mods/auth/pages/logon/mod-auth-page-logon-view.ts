// //Author Maxim Kuzmin//makc//

import {NgForm} from '@angular/forms';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppModAuthPageLogonView} from '@app/mods/auth/pages/logon/mod-auth-page-logon-view';
import {AppModAuthPageLogonSettingErrors} from '@app/mods/auth/pages/logon/settings/mod-auth-page-logon-setting-errors';
import {AppModAuthPageLogonSettingFields} from '@app/mods/auth/pages/logon/settings/mod-auth-page-logon-setting-fields';

/** Мод "Auth". Страницы. Вход в систему. Вид. */
export class AppSkinModAuthPageLogonView extends AppModAuthPageLogonView {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {NgForm} */
  private ctrlForm: NgForm;

  /**
   * Конструктор.
   * @param {AppModAuthPageLogonSettingErrors} settingErrors Настройка ошибок.
   * @param {AppModAuthPageLogonSettingFields} settingFields Настройка полей.
   */
  constructor(
    settingErrors: AppModAuthPageLogonSettingErrors,
    settingFields: AppModAuthPageLogonSettingFields
  ) {
    super(
      settingErrors,
      settingFields
    );
  }

  /**
   * Инициализировать.
   * @param {AppSkinCoreProgressSpinnerComponent} ctrlLoading Элемент управления "Спиннер загрузки".
   * @param {AppSkinCoreProgressSpinnerDirective} ctrlRefresh Элемент управления "Спиннер обновления".
   * @param {NgForm} ctrlForm Элемент управления "Форма".
   */
  init(
    ctrlLoading: AppSkinCoreProgressSpinnerComponent,
    ctrlRefresh: AppSkinCoreProgressSpinnerDirective,
    ctrlForm: NgForm
  ) {
    this.ctrlLoading = ctrlLoading;
    this.ctrlRefresh = ctrlRefresh;
    this.ctrlForm = ctrlForm;
  }

  /** @inheritdoc */
  hideLoadingSpinner() {
    this.ctrlLoading.hide();
  }

  /** @inheritdoc */
  hideRefreshSpinner() {
    this.ctrlRefresh.hide();
  }

  /**
   * @inheritdoc
   * @param {() => void} callback
   */
  initLoadingSpinner(callback: () => void) {
    this.ctrlLoading.init(callback);
  }

  /** @inheritdoc */
  initRefreshSpinner() {
    this.ctrlRefresh.init();
  }

  /** @inheritdoc */
  resetForm() {
    this.ctrlForm.resetForm();
  }

  /** @inheritdoc */
  showLoadingSpinner() {
    this.ctrlLoading.show();
  }

  /** @inheritdoc */
  showRefreshSpinner() {
    this.ctrlRefresh.show();
  }
}
