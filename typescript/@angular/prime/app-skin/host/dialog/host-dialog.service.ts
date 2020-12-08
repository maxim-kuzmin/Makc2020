// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {DialogService} from 'primeng/api';
import {Observable} from 'rxjs';
import {AppCoreDialogConfig} from '@app/core/dialog/core-dialog-config';
import {AppCoreDialogService} from '@app/core/dialog/core-dialog.service';
import {AppSkinHostLayoutCommonDialogAlertComponent} from '../layout/common/dialogs/alert/host-layout-common-dialog-alert.component';
import {AppSkinHostLayoutCommonDialogConfirmComponent} from '../layout/common/dialogs/confirm/host-layout-common-dialog-confirm.component';

/** Хост. Диалог. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppSkinHostDialogService extends AppCoreDialogService {

  /**
   * Конструктор.
   * @param {AppCoreDialogConfig} appDialogConfig Конфигурация диалога.
   * @param {DialogService} extDialog Диалог.
   */
  constructor(
    appDialogConfig: AppCoreDialogConfig,
    private extDialog: DialogService
  ) {
    super(
      appDialogConfig
    );
  }

  /**
   * @inheritDoc
   * @param {?string} message
   * @returns {Observable<any>}
   */
  alert$(message?: string): Observable<any> {
    const ref = this.extDialog.open(AppSkinHostLayoutCommonDialogAlertComponent, {
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
    const ref = this.extDialog.open(AppSkinHostLayoutCommonDialogConfirmComponent, {
      showHeader: false,
      data: {
        text: message
      }
    });

    return ref.onClose;
  }
}
