// //Author Maxim Kuzmin//makc//

import {AppCoreStorageDefault} from '@app/core/storage/core-storage-default';
import {Inject} from '@angular/core';
import {appBaseDiTokenLocalStorage, appBaseDiTokenSessionStorage} from '../base-di';

/** Основа. Хранилище. Умолчание. */
export class AppBaseStorageDefault extends AppCoreStorageDefault {

  /**
   * Конструктор.
   * @param {Storage} localStorage Локальное хранилище.
   * @param {Storage} sessionStorage Сессионное хранилище.
   */
  constructor(
    @Inject(appBaseDiTokenLocalStorage) private localStorage: Storage,
    @Inject(appBaseDiTokenSessionStorage) private sessionStorage: Storage
  ) {
    super();
  }

  /**
   * @inheritDoc
   * @returns {Storage} Хранилище.
   */
  getLocalStorage(): Storage {
    return this.localStorage;
  }

  /**
   * @inheritDoc
   * @returns {Storage} Хранилище.
   */
  getSessionStorage(): Storage {
    return this.sessionStorage;
  }
}
