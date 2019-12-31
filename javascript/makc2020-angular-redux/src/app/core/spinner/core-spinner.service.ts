// //Author Maxim Kuzmin//makc//

import {ElementRef} from '@angular/core';
import {AppCoreCommonDisposable} from '../common/core-common-disposable';

/** Ядро. Спиннер. Сервис. */
export abstract class AppCoreSpinnerService {

  /**
   * Создать.
   * @param {?ElementRef} elRef Ссылка на элемент, внутри которого будет размещён спиннер.
   * @returns {AppCoreCommonDisposable} То, что позволит удалить созданное.
   */
  abstract create(elRef?: ElementRef): AppCoreCommonDisposable;
}
