// //Author Maxim Kuzmin//makc//

import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreDialogConfirmPresenter} from '@app/core/dialog/confirm/core-dialog-confirm-presenter';
import {AppCoreDialogView} from '@app/core/dialog/core-dialog-view';

/** Ядро. Диалог. Подтверждение. Компонент. */
@Component({
  selector: 'app-skin-core-dialog-confirm',
  templateUrl: './core-dialog-confirm.component.html',
  styleUrls: ['./core-dialog-confirm.component.css']
})
export class AppSkinCoreDialogConfirmComponent {

  /**
   * Мой представитель.
   * @type {AppCoreDialogConfirmPresenter}
   */
  myPresenter: AppCoreDialogConfirmPresenter;

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

    this.myPresenter = new AppCoreDialogConfirmPresenter(
      appLocalizer,
      this.myView
    );
  }
}
