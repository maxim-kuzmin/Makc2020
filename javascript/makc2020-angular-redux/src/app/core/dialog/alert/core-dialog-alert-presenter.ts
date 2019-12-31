// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '../../localization/core-localization.service';
import {AppCoreDialogPresenter} from '../core-dialog-presenter';
import {AppCoreDialogAlertResources} from './core-dialog-alert-resources';
import {AppCoreDialogAlertSettings} from './core-dialog-alert-settings';
import {AppCoreDialogView} from '../core-dialog-view';

/** Ядро. Диалог. Предупреждение. Представитель. */
export class AppCoreDialogAlertPresenter extends AppCoreDialogPresenter<AppCoreDialogAlertResources> {

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
   * @returns {AppCoreDialogAlertResources}
   */
  protected createResources(): AppCoreDialogAlertResources {
    return new AppCoreDialogAlertResources(
      this.appLocalizer,
      new AppCoreDialogAlertSettings(),
      this.unsubscribe$
    );
  }
}
