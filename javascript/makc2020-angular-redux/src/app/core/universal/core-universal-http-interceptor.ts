// //Author Maxim Kuzmin//makc//

import {Inject, Injectable, Optional} from '@angular/core';
import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Request} from 'express';
import {REQUEST} from '@nguniversal/express-engine/tokens';
import {Observable} from 'rxjs';

@Injectable()
export class AppCoreUniversalHttpInterceptor implements HttpInterceptor {

  /**
   * Конструктор.
   * @param {Request} request Запрос.
   */
  constructor(
    @Optional() @Inject(REQUEST) protected request: Request
  ) {
  }

  /** @inheritDoc */
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (this.request && request.url.startsWith('/')) {
      let url = `${this.request.protocol}://${this.request.get('host')}`;

      url += request.url;

      request = request.clone({url});
    }

    return next.handle(request);
  }
}
