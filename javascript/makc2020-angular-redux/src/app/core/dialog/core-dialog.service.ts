// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable, of} from 'rxjs';
import {AppCoreDialogDefault} from './core-dialog-default';

/** Ядро. Диалог. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreDialogService {

  /**
   * Конструктор.
   * @param {AppCoreDialogDefault} appDialogDefault Умолчание диалога.
   */
  constructor(
    private appDialogDefault: AppCoreDialogDefault
  ) {
  }

  /**
   * Подтвердить.
   * @param {?string} message Сообщение с предупреждением.
   */
  alert(message?: string) {
    this.appDialogDefault.alert(message);
  }

  /**
   * Подтвердить.
   * @param {?string} message Сообщение с предупреждением.
   * @returns {Observable<any>} Результирующий поток.
   */
  alert$(message?: string): Observable<any> {
    return of(this.alert(message));
  }

  /**
   * Подтвердить.
   * @param {?string} message Сообщение, поясняющее, что нужно подтвердить.
   * @returns {Observable<boolean>} Результат подтверждения.
   */
  confirm(message?: string): boolean {
    return this.appDialogDefault.confirm(message || 'Is it OK?');
  }

  /**
   * Подтвердить.
   * @param {?string} message Сообщение, поясняющее, что нужно подтвердить.
   * @returns {Observable<boolean>} Поток с результатом подтверждения.
   */
  confirm$(message?: string): Observable<boolean> {
    return of(this.confirm(message));
  }
}
