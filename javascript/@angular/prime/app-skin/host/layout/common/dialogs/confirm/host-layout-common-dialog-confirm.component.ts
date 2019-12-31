// //Author Maxim Kuzmin//makc//

import {Component, OnDestroy} from '@angular/core';
import {DynamicDialogConfig, DynamicDialogRef} from 'primeng/api';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreDialogConfirmPresenter} from '@app/core/dialog/confirm/core-dialog-confirm-presenter';
import {AppSkinHostLayoutCommonDialogConfirmView} from './host-layout-common-dialog-confirm-view';

/** ост. Разметка. Диалоги. Подтверждение. Компонент. */
@Component({
  selector: 'app-common-confirm-dialog', // 'app-skin-host-layout-common--dialog-confirm',
  templateUrl: './host-layout-common-dialog-confirm.component.html',
  styleUrls: ['./host-layout-common-dialog-confirm.component.css']
})
export class AppSkinHostLayoutCommonDialogConfirmComponent implements OnDestroy {

  /**
   * Мой представитель.
   * @type {AppCoreDialogConfirmPresenter}
   */
  myPresenter: AppCoreDialogConfirmPresenter;

  /**
   * Мой вид.
   * @type {AppSkinHostLayoutCommonDialogConfirmView}
   */
  myView: AppSkinHostLayoutCommonDialogConfirmView;

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
    this.myView = new AppSkinHostLayoutCommonDialogConfirmView(
      extDialogConfig.data.text,
      extDialogRef
    );

    this.myPresenter = new AppCoreDialogConfirmPresenter(
      appLocalizer,
      this.myView
    );
  }

  /** @inheritDoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }
}
