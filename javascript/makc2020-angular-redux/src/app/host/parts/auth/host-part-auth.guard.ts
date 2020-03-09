// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, CanActivateChild, CanLoad, Route, Router, RouterStateSnapshot} from '@angular/router';
import {Observable} from 'rxjs';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';
import {AppHostPartAuthService} from './host-part-auth.service';

/** Хост. Часть "Auth". Защитник. */
@Injectable({
  providedIn: 'root'
})
export class AppHostPartAuthGuard implements CanActivate, CanActivateChild, CanLoad {

  /** @type {AppCoreExecutionHandler} */
  private readonly executionHandlerOnTryLoginAndReturn = new AppCoreExecutionHandler();

  /**
   * Конструктор.
   * @param {AppHostPartAuthService} appAuth Аутентификация.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {AppCoreNotificationService} appNotification Извещение.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    private appAuth: AppHostPartAuthService,
    appLogger: AppCoreLoggingService,
    appNotification: AppCoreNotificationService,
    private extRouter: Router
  ) {
    this.executionHandlerOnTryLoginAndReturn.logger = appLogger;
    this.executionHandlerOnTryLoginAndReturn.notification = appNotification;
  }

  /** @inheritDoc */
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    return this.appAuth.tryLoginAndReturn$(state.url, this.executionHandlerOnTryLoginAndReturn);
  }

  /** @inheritDoc */
  canActivateChild(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    return this.appAuth.tryLoginAndReturn$(state.url, this.executionHandlerOnTryLoginAndReturn);
  }

  /** @inheritDoc */
  canLoad(
    route: Route
  ): Observable<boolean> | Promise<boolean> | boolean {
    return this.appAuth.tryLoginAndReturn$(`/${route.path}`, this.executionHandlerOnTryLoginAndReturn);
  }
}
