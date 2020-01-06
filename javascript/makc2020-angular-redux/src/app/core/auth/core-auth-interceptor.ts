// //Author Maxim Kuzmin//makc//

import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {AppCoreAuthTypeJwtService} from './types/jwt/core-auth-type-jwt.service';
import {AppCoreAuthEnumTypes} from '@app/core/auth/enums/core-auth-enum-types';
import {AppCoreAuthTypeJwtInterceptor} from '@app/core/auth/types/jwt/core-auth-type-jwt-interceptor';
import {AppCoreSettings} from '@app/core/core-settings';

/** Ядро. Аутентификация. Перехватчик. */
@Injectable()
export class AppCoreAuthInterceptor implements HttpInterceptor {

  /**
   * Конструктор.
   * @param {AppCoreAuthTypeJwtService} appAuthTypeJwtInterceptor Перехватчик аутентификации типа JWT.
   * @param {AppCoreSettings} appSettings Настройки.
   */
  constructor(
    private appAuthTypeJwtInterceptor: AppCoreAuthTypeJwtInterceptor,
    private appSettings: AppCoreSettings
  ) {
  }

  /** @inheritDoc */
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const {
      authType
    } = this.appSettings;

    switch (authType) {
      case AppCoreAuthEnumTypes.Jwt:
        return this.appAuthTypeJwtInterceptor.intercept(request, next);
      case AppCoreAuthEnumTypes.Oidc:
      default:
        return next.handle(request);
    }
  }
}
