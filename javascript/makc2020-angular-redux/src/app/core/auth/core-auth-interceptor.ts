// //Author Maxim Kuzmin//makc//

import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {AppCoreAuthTypeJwtService} from './types/jwt/core-auth-type-jwt.service';
import {appCoreConfigAuthType} from '@app/core/core-config';
import {AppCoreAuthEnumTypes} from '@app/core/auth/enums/core-auth-enum-types';
import {AppCoreAuthTypeJwtInterceptor} from '@app/core/auth/types/jwt/core-auth-type-jwt-interceptor';

/** Ядро. Аутентификация. Перехватчик. */
@Injectable()
export class AppCoreAuthInterceptor implements HttpInterceptor {

  /**
   * Конструктор.
   * @param {AppCoreAuthTypeJwtService} appAuthTypeJwtInterceptor Перехватчик аутентификации типа JWT.
   */
  constructor(
    private appAuthTypeJwtInterceptor: AppCoreAuthTypeJwtInterceptor
  ) {
  }

  /** @inheritDoc */
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    switch (appCoreConfigAuthType) {
      case AppCoreAuthEnumTypes.Jwt:
        return this.appAuthTypeJwtInterceptor.intercept(request, next);
      case AppCoreAuthEnumTypes.Oidc:
      default:
        return next.handle(request);
    }
  }
}
