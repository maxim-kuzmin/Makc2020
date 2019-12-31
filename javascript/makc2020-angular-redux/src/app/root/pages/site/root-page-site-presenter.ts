// //Author Maxim Kuzmin//makc//

import {AppRootPageSiteModel} from './root-page-site-model';
import {AppRootPageSiteResources} from './root-page-site-resources';
import {AppRootPageSiteState} from './root-page-site-state';
import {AppRootPageSiteView} from './root-page-site-view';

/** Корень. Страницы. Сайт. Представитель. */
export class AppRootPageSitePresenter {

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
    private model: AppRootPageSiteModel,
    private view: AppRootPageSiteView
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
    this.view.routerLinkToModAuthPageIndex = this.model.createRouterLinkToModAuthPageIndex();
    this.view.routerLinkToRootPageContacts = this.model.createRouterLinkToRootPageContacts();

    this.model.onInit();
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
