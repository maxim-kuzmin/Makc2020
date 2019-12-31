// //Author Maxim Kuzmin//makc//

import {AppCoreExecutableAsync} from '@app/core/executable/core-executable-async';
import {AppModDummyMainPageIndexModel} from './mod-dummy-main-page-index-model';
import {AppModDummyMainPageIndexResources} from './mod-dummy-main-page-index-resources';
import {AppModDummyMainPageIndexState} from './mod-dummy-main-page-index-state';
import {AppModDummyMainPageIndexView} from './mod-dummy-main-page-index-view';

/** Мод "DummyMain". Страницы. Начало. Представитель. */
export class AppModDummyMainPageIndexPresenter {

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
    private model: AppModDummyMainPageIndexModel,
    private view: AppModDummyMainPageIndexView
  ) {
    this.onGetState = this.onGetState.bind(this);
  }

  /** Обработчик события после инициализации представления. */
  onAfterViewInit() {
    this.model.getState$().subscribe(this.onGetState);

    this.model.onAfterViewInit();
  }

  /** Обработчик события уничтожения. */
  onDestroy() {
    this.model.onDestroy();
  }

  /** Обработчик события инициализации. */
  onInit() {
    this.view.routerLinkToModDummyMainPageItemCreate = this.model.createRouterLinkToPageItemCreate();
    this.view.routerLinkToModDummyMainPageItemEdit = this.model.createRouterLinkToPageItemEdit();
    this.view.routerLinkToModDummyMainPageItemView = this.model.createRouterLinkToPageItemView();
    this.view.routerLinkToModDummyMainPageList = this.model.createRouterLinkToPageList();

    this.model.onInit();
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
