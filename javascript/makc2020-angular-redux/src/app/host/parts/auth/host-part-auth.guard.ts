// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, CanActivateChild, CanLoad, Route, Router, RouterStateSnapshot} from '@angular/router';
import {Observable} from 'rxjs';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostPartAuthService} from './host-part-auth.service';

/** Хост. Часть "Auth". Защитник. */
@Injectable({
  providedIn: 'root'
})
export class AppHostPartAuthGuard implements CanActivate, CanActivateChild, CanLoad {

  /**
   * Конструктор.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {AppHostPartAuthService} appAuth Аутентификация.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    private appLogger: AppCoreLoggingService,
    private appAuth: AppHostPartAuthService,
    private extRouter: Router
  ) {
  }

  /** @inheritDoc */
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    return this.appAuth.tryLoginAndReturn$(this.appLogger, state.url);
  }

  /** @inheritDoc */
  canActivateChild(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    return this.appAuth.tryLoginAndReturn$(this.appLogger, state.url);
  }

  /** @inheritDoc */
  canLoad(
    route: Route
  ): Observable<boolean> | Promise<boolean> | boolean {
    return this.appAuth.tryLoginAndReturn$(this.appLogger, `/${route.path}`);
  }
}
