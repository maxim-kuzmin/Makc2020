// //Author Maxim Kuzmin//makc//

import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {TranslateService} from '@ngx-translate/core';
import {Observable} from 'rxjs';
import {appCoreConfigApiUrl} from '@app/core/core-config';

/** Ядро. HTTP. Перехватчик. */
@Injectable()
export class AppCoreHttpInterceptor implements HttpInterceptor {

  /** @inheritDoc */
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (request.url.startsWith(appCoreConfigApiUrl)) {
      let req = request.clone({
        headers: request.headers
          .set('Content-Type', 'application/json'),
        params: request.params
          .set('lang', this.translator.currentLang)
      });

      if (req.method === 'GET') {
        req = req.clone({
          headers: req.headers
            .set('Cache-Control', 'no-cache')
            .set('Pragma', 'no-cache')
        });
      }

      return next.handle(req);
    } else {
      return next.handle(request);
    }
  }

  /**
   * Конструктор.
   * @param {TranslateService} translator Переводчик.
   */
  constructor(
    private translator: TranslateService
  ) {
  }
}
