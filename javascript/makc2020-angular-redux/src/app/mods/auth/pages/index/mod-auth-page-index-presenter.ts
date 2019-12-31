// //Author Maxim Kuzmin//makc//

import {AppModAuthPageIndexModel} from './mod-auth-page-index-model';
import {AppModAuthPageIndexResources} from './mod-auth-page-index-resources';
import {AppModAuthPageIndexState} from './mod-auth-page-index-state';
import {AppModAuthPageIndexView} from './mod-auth-page-index-view';

/** Мод "Auth". Страницы. Начало. Представитель. */
export class AppModAuthPageIndexPresenter {

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
    private model: AppModAuthPageIndexModel,
    private view: AppModAuthPageIndexView
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
    this.view.routerLinkToModAuthPageLogon = this.model.createRouterLinkToPageLogon();
    this.view.routerLinkToModAuthPageRegister = this.model.createRouterLinkToPageRegister();

    this.model.onInit();
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
