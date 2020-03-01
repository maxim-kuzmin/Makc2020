// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, CanActivateChild, CanLoad, Route, Router, RouterStateSnapshot} from '@angular/router';
import {Observable} from 'rxjs';

/** Хост. Часть "Localization". Защитник. */
@Injectable({
  providedIn: 'root'
})
export class AppHostPartLocalizationGuard implements CanActivate, CanActivateChild, CanLoad {

  /**
   * Конструктор.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    private extRouter: Router
  ) {
  }

  /** @inheritDoc */
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    return true;
  }

  /** @inheritDoc */
  canActivateChild(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    return true;
  }

  /** @inheritDoc */
  canLoad(
    route: Route
  ): Observable<boolean> | Promise<boolean> | boolean {
    return true;
  }
}
