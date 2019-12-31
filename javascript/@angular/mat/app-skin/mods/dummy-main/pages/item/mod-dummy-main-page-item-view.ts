// //Author Maxim Kuzmin//makc//

import {NgForm} from '@angular/forms';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppModDummyMainPageItemView} from '@app/mods/dummy-main/pages/item/mod-dummy-main-page-item-view';
import {AppModDummyMainPageItemSettingErrors} from '@app/mods/dummy-main/pages/item/settings/mod-dummy-main-page-item-setting-errors';
import {AppModDummyMainPageItemSettingFields} from '@app/mods/dummy-main/pages/item/settings/mod-dummy-main-page-item-setting-fields';

/** Мод "DummyMain". Страницы. Элемент. Представление. */
export class AppSkinModDummyMainPageItemView extends AppModDummyMainPageItemView {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {NgForm} */
  private ctrlForm: NgForm;

  /**
   * Конструктор.
   * @param {AppModDummyMainPageItemSettingErrors} settingErrors Настройка ошибок.
   * @param {AppModDummyMainPageItemSettingFields} settingFields Настройка полей.
   */
  constructor(
    settingErrors: AppModDummyMainPageItemSettingErrors,
    settingFields: AppModDummyMainPageItemSettingFields
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
