// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import {AppCoreDialogConfig} from '@app/core/dialog/core-dialog-config';
import {AppCoreDialogService} from '@app/core/dialog/core-dialog.service';
import {AppSkinCoreDialogConfirmComponent} from './confirm/core-dialog-confirm.component';

/** Ядро. Диалог. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppSkinCoreDialogService extends AppCoreDialogService {

  /**
   * Конструктор.
   * @param {AppCoreDialogConfig} appDialogConfig Конфигурация диалога.
   * @param {MatDialog} dialog Диалог.
   */
  constructor(
    appDialogConfig: AppCoreDialogConfig,
    private dialog: MatDialog
  ) {
    super(
      appDialogConfig
    );
  }

  /**
   * @inheritdoc
   * @param {?string} message
   * @returns {Observable<boolean>}
   */
  confirm$(message?: string): Observable<boolean> {
    const dialogRef = this.dialog.open(AppSkinCoreDialogConfirmComponent, { data: message });

    return dialogRef.afterClosed().pipe(
      map(result => result as boolean)
    );
  }
}
