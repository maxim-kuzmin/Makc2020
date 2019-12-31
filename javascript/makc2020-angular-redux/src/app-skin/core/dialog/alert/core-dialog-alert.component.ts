// //Author Maxim Kuzmin//makc//

import {Component} from '@angular/core';
import {DynamicDialogConfig, DynamicDialogRef} from 'primeng/api';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreDialogAlertPresenter} from '@app/core/dialog/alert/core-dialog-alert-presenter';
import {AppSkinCoreDialogAlertView} from './core-dialog-alert-view';

/** Ядро. Диалог. Подтверждение. Компонент. */
@Component({
  templateUrl: './core-dialog-alert.component.html',
  styleUrls: ['./core-dialog-alert.component.css']
})
export class AppSkinCoreDialogAlertComponent {

  /**
   * Мой представитель.
   * @type {AppCoreDialogAlertPresenter}
   */
  myPresenter: AppCoreDialogAlertPresenter;

  /**
   * Мой вид.
   * @type {AppSkinCoreDialogAlertView}
   */
  myView: AppSkinCoreDialogAlertView;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {DynamicDialogConfig} extDialogConfig Конфигурация диалога.
   * @param {DynamicDialogRef} extDialogRef Ссылка на диалог.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    extDialogConfig: DynamicDialogConfig,
    extDialogRef: DynamicDialogRef
  ) {
    this.myView = new AppSkinCoreDialogAlertView(
      extDialogConfig.data.text,
      extDialogRef
    );

    this.myPresenter = new AppCoreDialogAlertPresenter(
      appLocalizer,
      this.myView
    );
  }
}
