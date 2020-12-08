// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '../localization/core-localization.service';
import {AppCoreNotificationView} from './core-notification-view';
import {AppCoreNotificationResources} from './core-notification-resources';
import {AppCoreNotificationSettings} from './core-notification-settings';
import {AppCoreCommonUnsubscribable} from '@app/core/common/core-common-unsubscribable';

/** Ядро. Извещение. Представитель. */
export class AppCoreNotificationPresenter extends AppCoreCommonUnsubscribable {

  /**
   * Ресурсы.
   * @type {AppCoreNotificationResources}
   */
  resources: AppCoreNotificationResources;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreNotificationSettings} settings Настройки.
   * @param {AppCoreNotificationView} view Вид.
   */
  constructor(
    protected appLocalizer: AppCoreLocalizationService,
    settings: AppCoreNotificationSettings,
    private view: AppCoreNotificationView
  ) {
    super();

    this.resources = new AppCoreNotificationResources(
      this.appLocalizer,
      settings,
      this.unsubscribe$
    );
  }
}
