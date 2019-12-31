// //Author Maxim Kuzmin//makc//

import {AppRootPageIndexModel} from './root-page-index-model';
import {AppRootPageIndexResources} from './root-page-index-resources';
import {AppRootPageIndexState} from './root-page-index-state';
import {AppRootPageIndexView} from './root-page-index-view';

/** Корень. Страницы. Начало. Представитель. */
export class AppRootPageIndexPresenter {

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
    private model: AppRootPageIndexModel,
    private view: AppRootPageIndexView
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
    this.view.routerLinkToRootPageAdministration = this.model.createRouterLinkToRootPageAdministration();
    this.view.routerLinkToRootPageSite = this.model.createRouterLinkToRootPageSite();

    this.model.onInit();
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
