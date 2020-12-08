// //Author Maxim Kuzmin//makc//

import {AppModel} from './app-model';
import {AppResources} from './app-resources';
import {AppView} from '@app/app-view';

/** Приложение. Представитель. */
export class AppPresenter {

  /**
   * Ресурсы.
   * @type {AppResources}
   */
  get resources(): AppResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModel} model Модель.
   * @param {AppView} view Вид.
   */
  constructor(
    private model: AppModel,
    private  view: AppView
  ) {
    this.onGetIsAdminModeEnabled = this.onGetIsAdminModeEnabled.bind(this);

    this.model.getIsAdminModeEnabled$().subscribe(this.onGetIsAdminModeEnabled);
  }

  /** Обработчик события уничтожения. */
  onDestroy() {
    this.model.onDestroy();
  }

  /** Обработчик события инициализации. */
  onInit() {
    this.model.onInit();
  }

  /** @param {boolean} isAdminModeEnabled */
  private onGetIsAdminModeEnabled(isAdminModeEnabled: boolean) {
    this.view.setAdminMode(isAdminModeEnabled);
  }
}
