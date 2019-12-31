// //Author Maxim Kuzmin//makc//

import {AppModDummyMainResources} from './mod-dummy-main-resources';
import {AppModDummyMainModel} from './mod-dummy-main-model';

/** Мод "DummyMain". Представитель. */
export class AppModDummyMainPresenter {

  /**
   * Ресурсы.
   * @type {AppModDummyMainResources}
   */
  get resources(): AppModDummyMainResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModDummyMainModel} model Модель.
   */
  constructor(
    private model: AppModDummyMainModel
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
