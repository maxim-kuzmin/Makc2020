// //Author Maxim Kuzmin//makc//

import {BreakpointObserver, Breakpoints} from '@angular/cdk/layout';
import {map} from 'rxjs/operators';
import {Observable} from 'rxjs';
import {AppView} from '@app/app-view';

/** Приложение. Оболочка. Вид. */
export class AppSkinView extends AppView {

  /**
   * Заголовок.
   * @type {Observable<boolean>}
   */
  isHandset$: Observable<boolean>;

  constructor(
    breakpointObserver: BreakpointObserver
  ) {
    super();

    this.isHandset$ = breakpointObserver.observe(Breakpoints.Handset)
      .pipe(
        map(result => result.matches)
      );
  }
}
