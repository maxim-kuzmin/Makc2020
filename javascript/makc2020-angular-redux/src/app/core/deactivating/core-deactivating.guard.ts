// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {CanDeactivate} from '@angular/router';
import {AppCoreDeactivatingAbility} from './core-deactivating-ability';
import {AppCoreDeactivatingService} from './core-deactivating.service';

/** Ядро. Деактивация. Защитник. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreDeactivatingGuard implements CanDeactivate<AppCoreDeactivatingAbility> {

  /**
   * Конструктор.
   * @param {AppCoreDeactivatingService} appDeactivating Деактивация.
   */
  constructor(
    private appDeactivating: AppCoreDeactivatingService
  ) {
  }

  /** @inheritDoc */
  canDeactivate(component: AppCoreDeactivatingAbility) {
    const isOk = this.appDeactivating.isEnabled;

    if (isOk) {
      this.appDeactivating.isEnabled = false;
    }

    return isOk && component.canDeactivate
      ? component.canDeactivate()
      : true;
  }
}
