// //Author Maxim Kuzmin//makc//

import {Component, Inject} from '@angular/core';
import {MAT_SNACK_BAR_DATA} from '@angular/material/snack-bar';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppSkinCoreNotificationData} from '../core-notification-data';
import {AppSkinCoreNotificationView} from '../core-notification-view';
import {AppCoreNotificationPresenter} from '@app/core/notification/core-notification-presenter';
import {AppCoreNotificationInfoSettings} from '@app/core/notification/info/core-notification-info-settings';

/** Ядро. Извещение. Информационное. Компонент. */
@Component({
  selector: 'app-skin-core-notification-info',
  templateUrl: '../core-notification.component.html',
  styleUrls: ['../core-notification.component.css']
})
export class AppSkinCoreNotificationInfoComponent {

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
      'css-info'
    );

    this.myPresenter = new AppCoreNotificationPresenter(
      appLocalizer,
      new AppCoreNotificationInfoSettings(),
      this.myView
    );
  }

  /** Закрыть. */
  close() {
    this.data.messageRef.dispose();
  }
}
