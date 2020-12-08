// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPagePresenter} from '@app/core/common/page/core-common-page-presenter';
import {AppRootPageErrorModel} from './root-page-error-model';
import {AppRootPageErrorResources} from './root-page-error-resources';
import {AppRootPageErrorState} from './root-page-error-state';
import {AppRootPageErrorView} from './root-page-error-view';

/** Корень. Страницы. Ошибка. Представитель. */
export class AppRootPageErrorPresenter extends AppCoreCommonPagePresenter<AppRootPageErrorModel> {

  /**
   * Ресурсы.
   * @type {AppRootPageErrorResources}
   */
  get resources(): AppRootPageErrorResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppRootPageErrorModel} model Модель.
   * @param {AppRootPageErrorView} view Вид.
   */
  constructor(
    model: AppRootPageErrorModel,
    private view: AppRootPageErrorView
  ) {
    super(model);

    this.onGetState = this.onGetState.bind(this);
  }

  /** @inheritDoc */
  onAfterViewInit() {
    this.model.getState$().subscribe(this.onGetState);

    super.onAfterViewInit();
  }

  /** @param {AppRootPageErrorState} state */
  private onGetState(state: AppRootPageErrorState) {
    if (state) {
      const {
        action
      } = state;
    }
  }
}
