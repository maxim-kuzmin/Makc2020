// //Author Maxim Kuzmin//makc//

import {AppModAuthResources} from './mod-auth-resources';
import {AppModAuthModel} from './mod-auth-model';

/** Мод "Auth". Представитель. */
export class AppModAuthPresenter {

  /**
   * Ресурсы.
   * @type {AppModAuthResources}
   */
  get resources(): AppModAuthResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModAuthModel} model Модель.
   */
  constructor(
    private model: AppModAuthModel
  ) {
  }

  /** Обработчик события после инициализации представления. */
  onAfterViewInit() {
    this.model.onAfterViewInit();
  }

  /** Обработчик события уничтожения. */
  onDestroy() {
    this.model.onDestroy();
  }
}
