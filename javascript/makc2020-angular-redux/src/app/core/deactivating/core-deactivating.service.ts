// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';

/** Ядро. Деактивация. Защитник. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreDeactivatingService {

  /**
   * Признак включения.
   * @type {boolean}
   */
  isEnabled = false;
}
