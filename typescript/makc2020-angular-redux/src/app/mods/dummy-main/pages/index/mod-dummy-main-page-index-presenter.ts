// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPagePresenter} from '@app/core/common/page/core-common-page-presenter';
import {AppModDummyMainPageIndexModel} from './mod-dummy-main-page-index-model';
import {AppModDummyMainPageIndexResources} from './mod-dummy-main-page-index-resources';
import {AppModDummyMainPageIndexState} from './mod-dummy-main-page-index-state';
import {AppModDummyMainPageIndexView} from './mod-dummy-main-page-index-view';

/** Мод "DummyMain". Страницы. Начало. Представитель. */
export class AppModDummyMainPageIndexPresenter extends AppCoreCommonPagePresenter<AppModDummyMainPageIndexModel> {

  /**
   * Ресурсы.
   * @type {AppModDummyMainPageIndexResources}
   */
  get resources(): AppModDummyMainPageIndexResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModDummyMainPageIndexModel} model Модель.
   * @param {AppModDummyMainPageIndexView} view Вид.
   */
  constructor(
    model: AppModDummyMainPageIndexModel,
    private view: AppModDummyMainPageIndexView
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
    this.view.routerLinkToModDummyMainPageItemCreate = this.model.createRouterLinkToPageItemCreate();
    this.view.routerLinkToModDummyMainPageList = this.model.createRouterLinkToPageList();

    super.onInit();
  }

  /** @param {AppModDummyMainPageIndexState} state */
  private onGetState(state: AppModDummyMainPageIndexState) {
    if (state) {
      const {
        action
      } = state;
    }
  }
}
