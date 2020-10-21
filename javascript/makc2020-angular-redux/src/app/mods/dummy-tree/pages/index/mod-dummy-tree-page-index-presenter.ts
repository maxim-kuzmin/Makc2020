// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPagePresenter} from '@app/core/common/page/core-common-page-presenter';
import {AppModDummyTreePageIndexModel} from './mod-dummy-tree-page-index-model';
import {AppModDummyTreePageIndexResources} from './mod-dummy-tree-page-index-resources';
import {AppModDummyTreePageIndexState} from './mod-dummy-tree-page-index-state';
import {AppModDummyTreePageIndexView} from './mod-dummy-tree-page-index-view';

/** Мод "DummyTree". Страницы. Начало. Представитель. */
export class AppModDummyTreePageIndexPresenter extends AppCoreCommonPagePresenter<AppModDummyTreePageIndexModel> {

  /**
   * Ресурсы.
   * @type {AppModDummyTreePageIndexResources}
   */
  get resources(): AppModDummyTreePageIndexResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModDummyTreePageIndexModel} model Модель.
   * @param {AppModDummyTreePageIndexView} view Вид.
   */
  constructor(
    model: AppModDummyTreePageIndexModel,
    private view: AppModDummyTreePageIndexView
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
    this.view.routerLinkToModDummyTreePageItemCreate = this.model.createRouterLinkToPageItemCreate();
    this.view.routerLinkToModDummyTreePageList = this.model.createRouterLinkToPageList();

    super.onInit();
  }

  /** @param {AppModDummyTreePageIndexState} state */
  private onGetState(state: AppModDummyTreePageIndexState) {
    if (state) {
      const {
        action
      } = state;
    }
  }
}
