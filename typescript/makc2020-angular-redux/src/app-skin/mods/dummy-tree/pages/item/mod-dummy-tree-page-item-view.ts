// //Author Maxim Kuzmin//makc//

import {NgForm} from '@angular/forms';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppModDummyTreePageItemView} from '@app/mods/dummy-tree/pages/item/mod-dummy-tree-page-item-view';
import {AppModDummyTreePageItemSettingErrors} from '@app/mods/dummy-tree/pages/item/settings/mod-dummy-tree-page-item-setting-errors';
import {AppModDummyTreePageItemSettingFields} from '@app/mods/dummy-tree/pages/item/settings/mod-dummy-tree-page-item-setting-fields';

/** Мод "DummyTree". Страницы. Элемент. Представление. */
export class AppSkinModDummyTreePageItemView extends AppModDummyTreePageItemView {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {NgForm} */
  private ctrlForm: NgForm;

  /**
   * Конструктор.
   * @param {AppModDummyTreePageItemSettingErrors} settingErrors Настройка ошибок.
   * @param {AppModDummyTreePageItemSettingFields} settingFields Настройка полей.
   */
  constructor(
    settingErrors: AppModDummyTreePageItemSettingErrors,
    settingFields: AppModDummyTreePageItemSettingFields
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

  /** @inheritDoc */
  hideLoadingSpinner() {
    this.ctrlLoading.hide();
  }

  /** @inheritDoc */
  hideRefreshSpinner() {
    this.ctrlRefresh.hide();
  }

  /**
   * @inheritDoc
   * @param {() => void} callback
   */
  initLoadingSpinner(callback: () => void) {
    this.ctrlLoading.init(callback);
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
  showLoadingSpinner() {
    this.ctrlLoading.show();
  }

  /** @inheritDoc */
  showRefreshSpinner() {
    this.ctrlRefresh.show();
  }
}
