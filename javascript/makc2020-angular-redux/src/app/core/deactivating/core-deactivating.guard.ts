// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {CanDeactivate} from '@angular/router';
import {AppCoreDeactivatingAbility} from './core-deactivating-ability';

/** Ядро. Деактивация. Защитник. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreDeactivatingGuard implements CanDeactivate<AppCoreDeactivatingAbility> {

  /** @inheritDoc */
  canDeactivate(component: AppCoreDeactivatingAbility) {
    return component.canDeactivate ? component.canDeactivate() : true;
  }
}
