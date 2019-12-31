// //Author Maxim Kuzmin//makc//

import {AppCoreCommonDisposable} from '@app/core/common/core-common-disposable';
import {MatSnackBarRef} from '@angular/material/snack-bar';
import {AppSkinCoreNotificationErrorComponent} from './error/core-notification-error.component';

/** Ядро. Извещение. Ссылка. */
export class AppSkinCoreNotificationRef implements AppCoreCommonDisposable {

  /**
   * Конструктор.
   * @param {MatSnackBarRef<AppSkinCoreNotificationErrorComponent>} snackBarRef
   */
  constructor(
    private snackBarRef: MatSnackBarRef<AppSkinCoreNotificationErrorComponent>
  ) { }

  /** @inheritdoc */
  dispose() {
    this.snackBarRef.dismiss();
  }
}
