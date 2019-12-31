// //Author Maxim Kuzmin//makc//

import {AppCoreExecutableAsync} from '@app/core/executable/core-executable-async';
import {AppRootPageContactsEnumActions} from './enums/root-page-contacts-enum-actions';
import {AppRootPageContactsModel} from './root-page-contacts-model';
import {AppRootPageContactsResources} from './root-page-contacts-resources';
import {AppRootPageContactsState} from './root-page-contacts-state';
import {AppRootPageContactsView} from './root-page-contacts-view';

/** Корень. Страницы. Контакты. Представитель. */
export class AppRootPageContactsPresenter {

  /** @type {AppCoreExecutableAsync} */
  private onActionLoadSuccessAsync: AppCoreExecutableAsync;

  /**
   * Ресурсы.
   * @type {AppRootPageContactsResources}
   */
  get resources(): AppRootPageContactsResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppRootPageContactsModel} model Модель.
   * @param {AppRootPageContactsView} view Вид.
   */
  constructor(
    private model: AppRootPageContactsModel,
    private view: AppRootPageContactsView
  ) {
    this.onActionLoadSuccess = this.onActionLoadSuccess.bind(this);
    this.onActionLoadSuccessAsync = new AppCoreExecutableAsync(this.onActionLoadSuccess);

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

  private onActionLoadSuccess() {
    const {
      jobContentLoadResult: result
    } = this.model.getState();

    if (result) {
      const {
        data
      } = result;

      if (data) {
        this.view.content = data;
      }
    }
  }

  /** @param {AppRootPageContactsState} state */
  private onGetState(state: AppRootPageContactsState) {
    if (state) {
      const {
        action
      } = state;

      if (action === AppRootPageContactsEnumActions.LoadSuccess) {
        this.onActionLoadSuccessAsync.execute();
      }
    }
  }
}
