// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppCoreStorageBase} from '../core-storage-base';
import {AppCoreStorageDefault} from '../core-storage-default';

/** Ядро. Хранилище. Сессионное. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreStorageSessionService extends AppCoreStorageBase {

  /**
   * Конструктор.
   * @param {AppCoreStorageDefault} appStorageDefault Умолчание хранилища.
   */
  constructor(
    appStorageDefault: AppCoreStorageDefault
  ) {
    super(appStorageDefault.getSessionStorage());
  }
}
