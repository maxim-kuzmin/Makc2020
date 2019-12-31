// //Author Maxim Kuzmin//makc//

import {AppRootPageAdministrationModel} from './root-page-administration-model';
import {AppRootPageAdministrationResources} from './root-page-administration-resources';
import {AppRootPageAdministrationState} from './root-page-administration-state';
import {AppRootPageAdministrationView} from './root-page-administration-view';

/** Корень. Страницы. Администрирование. Представитель. */
export class AppRootPageAdministrationPresenter {

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
    private model: AppRootPageAdministrationModel,
    private view: AppRootPageAdministrationView
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
    this.view.routerLinkToModDummyMainPageIndex = this.model.createRouterLinkToModDummyMainPageIndex();

    this.model.onInit();
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
