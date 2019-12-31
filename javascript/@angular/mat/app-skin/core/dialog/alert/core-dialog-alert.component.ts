// //Author Maxim Kuzmin//makc//

import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreDialogConfirmPresenter} from '@app/core/dialog/confirm/core-dialog-confirm-presenter';
import {AppCoreDialogView} from '@app/core/dialog/core-dialog-view';
import {AppCoreDialogAlertPresenter} from '@app/core/dialog/alert/core-dialog-alert-presenter';

/** Ядро. Диалог. Предупреждение. Компонент. */
@Component({
  selector: 'app-skin-core-dialog-confirm',
  templateUrl: './core-dialog-alert.component.html',
  styleUrls: ['./core-dialog-alert.component.css']
})
export class AppSkinCoreDialogAlertComponent {

  /**
   * Мой представитель.
   * @type {AppCoreDialogConfirmPresenter}
   */
  myPresenter: AppCoreDialogAlertPresenter;

  /**
   * Мой вид.
   * @type {AppCoreDialogView}
   */
  myView: AppCoreDialogView;

  /**
   * Конструктор.
   * @param {string} message Сообщение.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   */
  constructor(
    @Inject(MAT_DIALOG_DATA) public message: string,
    appLocalizer: AppCoreLocalizationService
  ) {
    this.myView = new AppCoreDialogView(
      message
    );

    this.myPresenter = new AppCoreDialogAlertPresenter(
      appLocalizer,
      this.myView
    );
  }
}
