// //Author Maxim Kuzmin//makc//

import {AppRootPageErrorModel} from './root-page-error-model';
import {AppRootPageErrorResources} from './root-page-error-resources';
import {AppRootPageErrorState} from './root-page-error-state';
import {AppRootPageErrorView} from './root-page-error-view';

/** Корень. Страницы. Ошибка. Представитель. */
export class AppRootPageErrorPresenter {

  /**
   * Ресурсы.
   * @type {AppRootPageErrorResources}
   */
  get resources(): AppRootPageErrorResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppRootPageErrorModel} model Модель.
   * @param {AppRootPageErrorView} view Вид.
   */
  constructor(
    private model: AppRootPageErrorModel,
    private view: AppRootPageErrorView
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
    this.model.onInit();
  }

  /** @param {AppRootPageErrorState} state */
  private onGetState(state: AppRootPageErrorState) {
    if (state) {
      const {
        action
      } = state;
    }
  }
}
