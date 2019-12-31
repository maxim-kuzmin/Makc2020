// //Author Maxim Kuzmin//makc//

import {Observable} from 'rxjs';

/** Ядро. Деактивация. Способность. */
export interface AppCoreDeactivatingAbility {

  /**
   * Получение разрешения на деактивацию.
   * @returns {Observable<boolean> | Promise<boolean> | boolean} True - если деактивация разрешена, False - в противном случае.
   */
  canDeactivate: () => Observable<boolean> | Promise<boolean> | boolean;
}
