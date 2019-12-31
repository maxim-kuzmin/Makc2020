// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppCoreStorageBase} from '../core-storage-base';
import {AppCoreStorageDefault} from '../core-storage-default';

/** Ядро. Хранилище. Локальное. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreStorageLocalService extends AppCoreStorageBase {

  /**
   * Конструктор.
   * @param {AppCoreStorageDefault} appStorageDefault Умолчание хранилища.
   */
  constructor(
    appStorageDefault: AppCoreStorageDefault
  ) {
    super(appStorageDefault.getLocalStorage());
  }
}
