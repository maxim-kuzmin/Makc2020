// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, CanActivateChild, CanLoad, Route, Router, RouterStateSnapshot} from '@angular/router';
import {Observable, of} from 'rxjs';
import {take} from 'rxjs/operators';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostAuthService} from './host-auth.service';
import {AppHostAuthStore} from '@app/host/auth/host-auth-store';

/** Хост. Аутентификация. Защитник. */
@Injectable({
  providedIn: 'root'
})
export class AppHostAuthGuard implements CanActivate, CanActivateChild, CanLoad {

  /**
   * Конструктор.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {AppHostAuthService} appAuth Аутентификация.
   * @param {AppHostAuthStore} appAuthStore Хранилище состояния аутентификации.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    private appLogger: AppCoreLoggingService,
    private appAuth: AppHostAuthService,
    private appAuthStore: AppHostAuthStore,
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
