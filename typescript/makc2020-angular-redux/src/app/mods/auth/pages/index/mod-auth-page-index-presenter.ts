// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPagePresenter} from '@app/core/common/page/core-common-page-presenter';
import {AppModAuthPageIndexModel} from './mod-auth-page-index-model';
import {AppModAuthPageIndexResources} from './mod-auth-page-index-resources';
import {AppModAuthPageIndexState} from './mod-auth-page-index-state';
import {AppModAuthPageIndexView} from './mod-auth-page-index-view';

/** Мод "Auth". Страницы. Начало. Представитель. */
export class AppModAuthPageIndexPresenter extends AppCoreCommonPagePresenter<AppModAuthPageIndexModel> {

  /**
   * Ресурсы.
   * @type {AppModAuthPageIndexResources}
   */
  get resources(): AppModAuthPageIndexResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModAuthPageIndexModel} model Модель.
   * @param {AppModAuthPageIndexView} view Вид.
   */
  constructor(
    model: AppModAuthPageIndexModel,
    private view: AppModAuthPageIndexView
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
    this.view.routerLinkToModAuthPageLogon = this.model.createRouterLinkToPageLogon();
    this.view.routerLinkToModAuthPageRegister = this.model.createRouterLinkToPageRegister();

    super.onInit();
  }

  /** @param {AppModAuthPageIndexState} state */
  private onGetState(state: AppModAuthPageIndexState) {
    if (state) {
      const {
        action
      } = state;
    }
  }
}
