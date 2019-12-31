// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '../../localization/core-localization.service';
import {AppCoreDialogPresenter} from '../core-dialog-presenter';
import {AppCoreDialogConfirmResources} from './core-dialog-confirm-resources';
import {AppCoreDialogConfirmSettings} from './core-dialog-confirm-settings';
import {AppCoreDialogView} from '../core-dialog-view';

/** Ядро. Диалог. Подтверждение. Представитель. */
export class AppCoreDialogConfirmPresenter extends AppCoreDialogPresenter<AppCoreDialogConfirmResources> {

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreDialogView} Вид.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    view: AppCoreDialogView
  ) {
    super(
      appLocalizer,
      view
    );
  }

  /**
   * @inheritDoc
   * @returns {AppCoreDialogConfirmResources}
   */
  protected createResources(): AppCoreDialogConfirmResources {
    return new AppCoreDialogConfirmResources(
      this.appLocalizer,
      new AppCoreDialogConfirmSettings(),
      this.unsubscribe$
    );
  }
}
