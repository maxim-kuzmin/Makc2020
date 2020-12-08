// //Author Maxim Kuzmin//makc//

// tslint:disable:no-bitwise

import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {parse} from 'url';
import {AppCoreAuthTypeJwtDefault} from './core-auth-type-jwt-default';
import {AppCoreAuthTypeJwtService} from './core-auth-type-jwt.service';

/** Ядро. Аутентификация. Типы. JWT. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreAuthTypeJwtInterceptor implements HttpInterceptor {

  /**
   * Конструктор.
   * @param {AppCoreAuthTypeJwtService} appAuthTypeJwt Аутентификация типа JWT.
   * @param {AppCoreAuthTypeJwtDefault} appAuthTypeJwtDefault Умолчание аутентификации типа JWT.
   */
  constructor(
    private appAuthTypeJwt: AppCoreAuthTypeJwtService,
    private appAuthTypeJwtDefault: AppCoreAuthTypeJwtDefault
  ) {
  }

  /** @inheritDoc */
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const token = this.appAuthTypeJwt.getAccessToken();

    if (token
      && this.isWhitelistedDomain(request)
      && !this.isBlacklistedRoute(request)
      && !this.appAuthTypeJwt.isTokenExpired(token)
    ) {
      const {
        authScheme,
        headerName
      } = this.appAuthTypeJwtDefault;

      const setHeaders = {
        [headerName]: `${authScheme} ${token}`
      };

      request = request.clone({setHeaders});
    }

    return next.handle(request);
  }

  /**
   * @param {HttpRequest<any>} request
   * @returns {boolean}
   */
  private isWhitelistedDomain(request: HttpRequest<any>): boolean {
    const {
      whitelistedDomains
    } = this.appAuthTypeJwtDefault;

    if (whitelistedDomains.length === 0) {
      return true;
    }

    const requestUrl: any = parse(request.url, false, true);

    return (
      requestUrl.host === null ||
      whitelistedDomains.findIndex(
        domain =>
          typeof domain === 'string'
            ? domain === requestUrl.host
            : domain instanceof RegExp
            ? domain.test(requestUrl.host)
            : false
      ) > -1
    );
  }

  /**
   * @param {HttpRequest<any>} request
   * @returns {boolean}
   */
  private isBlacklistedRoute(request: HttpRequest<any>): boolean {
    const {
      blacklistedRoutes
    } = this.appAuthTypeJwtDefault;

    if (blacklistedRoutes.length === 0) {
      return false;
    }

    const url = request.url;

    return (
      blacklistedRoutes.findIndex(
        route =>
          typeof route === 'string'
            ? route === url
            : route instanceof RegExp
            ? route.test(url)
            : false
      ) > -1
    );
  }
}
