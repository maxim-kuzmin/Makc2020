// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPagePresenter} from '@app/core/common/page/core-common-page-presenter';
import {AppRootPageAdministrationModel} from './root-page-administration-model';
import {AppRootPageAdministrationResources} from './root-page-administration-resources';
import {AppRootPageAdministrationState} from './root-page-administration-state';
import {AppRootPageAdministrationView} from './root-page-administration-view';

/** Корень. Страницы. Администрирование. Представитель. */
export class AppRootPageAdministrationPresenter extends AppCoreCommonPagePresenter<AppRootPageAdministrationModel> {

  /**
   * Ресурсы.
   * @type {AppRootPageAdministrationResources}
   */
  get resources(): AppRootPageAdministrationResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppRootPageAdministrationModel} model Модель.
   * @param {AppRootPageAdministrationView} view Вид.
   */
  constructor(
    model: AppRootPageAdministrationModel,
    private view: AppRootPageAdministrationView
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
    this.view.routerLinkToModDummyMainPageIndex = this.model.createRouterLinkToModDummyMainPageIndex();

    super.onInit();
  }

  /** @param {AppRootPageAdministrationState} state */
  private onGetState(state: AppRootPageAdministrationState) {
    if (state) {
      const {
        action
      } = state;
    }
  }
}
