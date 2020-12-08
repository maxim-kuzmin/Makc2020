// //Author Maxim Kuzmin//makc//

import {Component, Inject} from '@angular/core';
import {MAT_SNACK_BAR_DATA} from '@angular/material/snack-bar';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppSkinCoreNotificationData} from '../core-notification-data';
import {AppSkinCoreNotificationView} from '../core-notification-view';
import {AppCoreNotificationPresenter} from '@app/core/notification/core-notification-presenter';
import {AppCoreNotificationErrorSettings} from '@app/core/notification/error/core-notification-error-settings';

/** Ядро. Извещение. Об ошибке. Компонент. */
@Component({
  selector: 'app-skin-core-notification-error',
  templateUrl: '../core-notification.component.html',
  styleUrls: ['../core-notification.component.css']
})
export class AppSkinCoreNotificationErrorComponent {

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
      'css-error'
    );

    this.myPresenter = new AppCoreNotificationPresenter(
      appLocalizer,
      new AppCoreNotificationErrorSettings(),
      this.myView
    );
  }

  /** Закрыть. */
  close() {
    this.data.messageRef.dispose();
  }
}
