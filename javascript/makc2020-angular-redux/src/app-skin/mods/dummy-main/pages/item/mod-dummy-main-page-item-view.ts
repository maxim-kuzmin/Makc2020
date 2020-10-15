// //Author Maxim Kuzmin//makc//

import {NgForm} from '@angular/forms';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppModDummyMainPageItemView} from '@app/mods/dummy-main/pages/item/mod-dummy-main-page-item-view';
import {AppModDummyMainPageItemSettingErrors} from '@app/mods/dummy-main/pages/item/settings/mod-dummy-main-page-item-setting-errors';
import {AppModDummyMainPageItemSettingFields} from '@app/mods/dummy-main/pages/item/settings/mod-dummy-main-page-item-setting-fields';
import {SelectItem} from 'primeng';
// tslint:disable-next-line:max-line-length
import {AppModDummyMainCommonJobOptionsGetOutputList} from '@app/mods/dummy-main/common/jobs/options/get/output/mod-dummy-main-common-job-options-get-output-list';

/** Мод "DummyMain". Страницы. Элемент. Представление. */
export class AppSkinModDummyMainPageItemView extends AppModDummyMainPageItemView {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {NgForm} */
  private ctrlForm: NgForm;

  /**
   * Вырианты выбора "DummyOneToMany".
   * @type {SelectItem[]}
   */
  selectItemsDummyOneToMany: SelectItem[] = [];

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

  /**
   * @inheritDoc
   * @param {AppModDummyMainCommonJobOptionsGetOutputList} data
   */
  loadOptionsDummyOneToMany(data?: AppModDummyMainCommonJobOptionsGetOutputList) {
    super.loadOptionsDummyOneToMany(data);

    if (this.optionsDummyOneToMany) {
      this.selectItemsDummyOneToMany = this.optionsDummyOneToMany.items.map(option => ({
        label: option.name,
        title: option.name,
        value: option.value
      } as SelectItem));
    }
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
