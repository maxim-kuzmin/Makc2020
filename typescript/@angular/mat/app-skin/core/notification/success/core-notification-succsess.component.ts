// //Author Maxim Kuzmin//makc//

import {Component, Inject} from '@angular/core';
import {MAT_SNACK_BAR_DATA} from '@angular/material/snack-bar';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppSkinCoreNotificationData} from '../core-notification-data';
import {AppSkinCoreNotificationView} from '../core-notification-view';
import {AppCoreNotificationPresenter} from '@app/core/notification/core-notification-presenter';
import {AppCoreNotificationSuccessSettings} from '@app/core/notification/success/core-notification-success-settings';

/** Ядро. Извещение. Об успехе. Компонент. */
@Component({
  selector: 'app-skin-core-notification-success',
  templateUrl: '../core-notification.component.html',
  styleUrls: ['../core-notification.component.css']
})
export class AppSkinCoreNotificationSuccessComponent {

  /**
   * Мой представитель.
   * @type {AppCoreNotificationPresenter}
   */
  myPresenter: AppCoreNotificationPresenter;

  /**
   * Мой вид.
   * @type {AppSkinCoreNotificationView}
   */
  myView: AppSkinCoreNotificationView;

  /**
   * Конструктор.
   * @param {AppSkinCoreNotificationData} data Данные.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   */
  constructor(
    @Inject(MAT_SNACK_BAR_DATA) private data: AppSkinCoreNotificationData,
    appLocalizer: AppCoreLocalizationService
  ) {
    this.myView = new AppSkinCoreNotificationView(
      data.messages,
      'css-success'
    );

    this.myPresenter = new AppCoreNotificationPresenter(
      appLocalizer,
      new AppCoreNotificationSuccessSettings(),
      this.myView
    );
  }

  /** Закрыть. */
  close() {
    this.data.messageRef.dispose();
  }
}
