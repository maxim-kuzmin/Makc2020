// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPagePresenter} from '@app/core/common/page/core-common-page-presenter';
import {AppRootPageIndexModel} from './root-page-index-model';
import {AppRootPageIndexResources} from './root-page-index-resources';
import {AppRootPageIndexState} from './root-page-index-state';
import {AppRootPageIndexView} from './root-page-index-view';

/** Корень. Страницы. Начало. Представитель. */
export class AppRootPageIndexPresenter extends AppCoreCommonPagePresenter<AppRootPageIndexModel> {

  /**
   * Ресурсы.
   * @type {AppRootPageIndexResources}
   */
  get resources(): AppRootPageIndexResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppRootPageIndexModel} model Модель.
   * @param {AppRootPageIndexView} view Вид.
   */
  constructor(
    model: AppRootPageIndexModel,
    private view: AppRootPageIndexView
  ) {
    super(model);

    this.onGetState = this.onGetState.bind(this);
  }

  /** @inheritDoc */
  onAfterViewInit() {
    this.model.getState$().subscribe(this.onGetState);

    super.onAfterViewInit();
  }

  /** @inheritDoc */
  onInit() {
    this.view.routerLinkToRootPageAdministration = this.model.createRouterLinkToRootPageAdministration();
    this.view.routerLinkToRootPageSite = this.model.createRouterLinkToRootPageSite();

    super.onInit();
  }

  /** @param {AppRootPageIndexState} state */
  private onGetState(state: AppRootPageIndexState) {
    if (state) {
      const {
        action
      } = state;
    }
  }
}
