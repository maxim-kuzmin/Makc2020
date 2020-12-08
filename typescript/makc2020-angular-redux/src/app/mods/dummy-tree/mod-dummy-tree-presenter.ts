// //Author Maxim Kuzmin//makc//

import {AppModDummyTreeResources} from './mod-dummy-tree-resources';
import {AppModDummyTreeModel} from './mod-dummy-tree-model';

/** Мод "DummyTree". Представитель. */
export class AppModDummyTreePresenter {

  /**
   * Ресурсы.
   * @type {AppModDummyTreeResources}
   */
  get resources(): AppModDummyTreeResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModDummyTreeModel} model Модель.
   */
  constructor(
    private model: AppModDummyTreeModel
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
