// //Author Maxim Kuzmin//makc//

import {Component} from '@angular/core';
import {DynamicDialogConfig, DynamicDialogRef} from 'primeng/api';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreDialogAlertPresenter} from '@app/core/dialog/alert/core-dialog-alert-presenter';
import {AppSkinHostLayoutCommonDialogAlertView} from './host-layout-common-dialog-alert-view';

/** Хост. Разметка. Диалоги. Компонент. */
@Component({
  selector: 'app-common-alert-dialog', // 'app-skin-host-layout-common-dialog-confirm',
  templateUrl: './host-layout-common-dialog-alert.component.html',
  styleUrls: ['./host-layout-common-dialog-alert.component.css']
})
export class AppSkinHostLayoutCommonDialogAlertComponent {

  /**
   * Мой представитель.
   * @type {AppCoreDialogAlertPresenter}
   */
  myPresenter: AppCoreDialogAlertPresenter;

  /**
   * Мой вид.
   * @type {AppSkinHostLayoutCommonDialogAlertView}
   */
  myView: AppSkinHostLayoutCommonDialogAlertView;

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
    this.myView = new AppSkinHostLayoutCommonDialogAlertView(
      extDialogConfig.data.text,
      extDialogRef
    );

    this.myPresenter = new AppCoreDialogAlertPresenter(
      appLocalizer,
      this.myView
    );
  }
}
