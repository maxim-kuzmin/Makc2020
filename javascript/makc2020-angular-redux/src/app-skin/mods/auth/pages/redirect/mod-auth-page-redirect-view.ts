// //Author Maxim Kuzmin//makc//

import {AppModAuthPageRedirectView} from '@app/mods/auth/pages/redirect/mod-auth-page-redirect-view';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';

/** Мод "Auth". Страницы. Перенаправление. Вид. */
export class AppSkinModAuthPageRedirectView extends AppModAuthPageRedirectView {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /**
   * Инициализировать.
   * @param {AppSkinCoreProgressSpinnerComponent} ctrlLoading Элемент управления "Спиннер загрузки".
   */
  init(
    ctrlLoading: AppSkinCoreProgressSpinnerComponent
  ) {
    this.ctrlLoading = ctrlLoading;
  }

  /** @inheritDoc */
  hideLoadingSpinner() {
    this.ctrlLoading.hide();
  }

  /** @inheritDoc */
  initLoadingSpinner(callback: () => void) {
    this.ctrlLoading.init(callback);
  }

  /** @inheritDoc */
  showLoadingSpinner() {
    this.ctrlLoading.show();
  }
}
