// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {MatSnackBar} from '@angular/material/snack-bar';
import {AppCoreCommonDisposable} from '@app/core/common/core-common-disposable';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';
import {AppSkinCoreNotificationData} from './core-notification-data';
import {AppSkinCoreNotificationRef} from './core-notification-ref';
import {AppSkinCoreNotificationErrorComponent} from './error/core-notification-error.component';
import {AppSkinCoreNotificationInfoComponent} from './info/core-notification-info.component';
import {AppSkinCoreNotificationSuccessComponent} from './success/core-notification-succsess.component';

/** Ядро. Извещение. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppSkinCoreNotificationService extends AppCoreNotificationService {

  /**
   * Конструктор.
   * @param {MatSnackBar} snackBar Снэк-бар.
   */
  constructor(
    private snackBar: MatSnackBar
  ) {
    super();
  }

  /**
   * @inheritdoc
   * @param {string[]} messages
   * @returns {AppCoreCommonDisposable}
   */
  showError(messages: string[]): AppCoreCommonDisposable {
    return this.createNotificationRef(AppSkinCoreNotificationErrorComponent, messages);
  }

  /**
   * @inheritdoc
   * @param {string[]} messages
   * @returns {AppCoreCommonDisposable}
   */
  showInfo(messages: string[]): AppCoreCommonDisposable {
    return this.createNotificationRef(AppSkinCoreNotificationInfoComponent, messages);
  }

  /**
   * @inheritdoc
   * @param {string[]} messages
   * @returns {AppCoreCommonDisposable}
   */
  showSuccess(messages: string[]): AppCoreCommonDisposable {
    return this.createNotificationRef(AppSkinCoreNotificationSuccessComponent, messages);
  }

  private createNotificationRef(componentType: any, messages: string[]): AppSkinCoreNotificationRef {
    const data = new AppSkinCoreNotificationData(messages);

    const result = new AppSkinCoreNotificationRef(
      this.snackBar.openFromComponent(componentType, {data})
    );

    data.messageRef = result;

    return result;
  }
}
