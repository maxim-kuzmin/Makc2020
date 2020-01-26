// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPagePresenter} from '@app/core/common/page/core-common-page-presenter';
import {AppRootPageSiteModel} from './root-page-site-model';
import {AppRootPageSiteResources} from './root-page-site-resources';
import {AppRootPageSiteState} from './root-page-site-state';
import {AppRootPageSiteView} from './root-page-site-view';

/** Корень. Страницы. Сайт. Представитель. */
export class AppRootPageSitePresenter extends AppCoreCommonPagePresenter<AppRootPageSiteModel> {

  /**
   * Ресурсы.
   * @type {AppRootPageSiteResources}
   */
  get resources(): AppRootPageSiteResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppRootPageSiteModel} model Модель.
   * @param {AppRootPageSiteView} view Вид.
   */
  constructor(
    model: AppRootPageSiteModel,
    private view: AppRootPageSiteView
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
    this.view.routerLinkToModAuthPageIndex = this.model.createRouterLinkToModAuthPageIndex();
    this.view.routerLinkToRootPageContacts = this.model.createRouterLinkToRootPageContacts();

    super.onInit();
  }

  /** @param {AppRootPageSiteState} state */
  private onGetState(state: AppRootPageSiteState) {
    if (state) {
      const {
        action
      } = state;
    }
  }
}
