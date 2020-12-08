// //Author Maxim Kuzmin//makc//

import {Component, OnDestroy} from '@angular/core';
import {DynamicDialogConfig, DynamicDialogRef} from 'primeng/dynamicdialog';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreDialogConfirmPresenter} from '@app/core/dialog/confirm/core-dialog-confirm-presenter';
import {AppSkinCoreDialogConfirmView} from './core-dialog-confirm-view';

/** Ядро. Диалог. Подтверждение. Компонент. */
@Component({
  templateUrl: './core-dialog-confirm.component.html',
  styleUrls: ['./core-dialog-confirm.component.css']
})
export class AppSkinCoreDialogConfirmComponent implements OnDestroy {

  /**
   * Мой представитель.
   * @type {AppCoreDialogConfirmPresenter}
   */
  myPresenter: AppCoreDialogConfirmPresenter;

  /**
   * Мой вид.
   * @type {AppSkinCoreDialogConfirmView}
   */
  myView: AppSkinCoreDialogConfirmView;

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
    this.myView = new AppSkinCoreDialogConfirmView(
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
