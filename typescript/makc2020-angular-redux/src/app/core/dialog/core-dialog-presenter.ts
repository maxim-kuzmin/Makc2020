// //Author Maxim Kuzmin//makc//

import {AppCoreCommonUnsubscribable} from '@app/core/common/core-common-unsubscribable';
import {AppCoreLocalizationService} from '../localization/core-localization.service';
import {AppCoreDialogView} from './core-dialog-view';

/** Ядро. Диалог. Представитель. */
export abstract class AppCoreDialogPresenter<TResources> extends AppCoreCommonUnsubscribable {

  /**
   * Ресурсы.
   * @type {TResources}
   */
  resources: TResources;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreDialogView} Вид.
   */
  protected constructor(
    protected appLocalizer: AppCoreLocalizationService,
    private view: AppCoreDialogView
  ) {
    super();

    this.resources = this.createResources();
  }

  /**
   * Создать модель.
   * @param {string} message Сообщение.
   * @returns {TView extends AppCoreDialogView} Модель.
   */
  protected abstract createResources(): TResources;
}
