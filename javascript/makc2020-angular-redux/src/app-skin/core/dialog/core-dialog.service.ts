// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {DialogService} from 'primeng/dynamicdialog';
import {Observable} from 'rxjs';
import {AppCoreDialogDefault} from '@app/core/dialog/core-dialog-default';
import {AppCoreDialogService} from '@app/core/dialog/core-dialog.service';
import {AppSkinCoreDialogAlertComponent} from './alert/core-dialog-alert.component';
import {AppSkinCoreDialogConfirmComponent} from './confirm/core-dialog-confirm.component';

/** Ядро. Диалог. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppSkinCoreDialogService extends AppCoreDialogService {

  /**
   * Конструктор.
   * @param {AppCoreDialogDefault} appDialogDefault Умолчание диалога.
   * @param {DialogService} extDialog Диалог.
   */
  constructor(
    appDialogDefault: AppCoreDialogDefault,
    private extDialog: DialogService
  ) {
    super(
      appDialogDefault
    );
  }

  /**
   * @inheritDoc
   * @param {?string} message
   * @returns {Observable<any>}
   */
  alert$(message?: string): Observable<any> {
    const ref = this.extDialog.open(AppSkinCoreDialogAlertComponent, {
      showHeader: false,
      data: {
        text: message
      }
    });

    return ref.onClose;
  }

  /**
   * @inheritDoc
   * @param {?string} message
   * @returns {Observable<boolean>}
   */
  confirm$(message?: string): Observable<boolean> {
    const ref = this.extDialog.open(AppSkinCoreDialogConfirmComponent, {
      showHeader: false,
      data: {
        text: message
      }
    });

    return ref.onClose;
  }
}
