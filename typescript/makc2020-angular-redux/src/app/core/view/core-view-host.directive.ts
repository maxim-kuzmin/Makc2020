// //Author Maxim Kuzmin//makc//

import {Directive, ViewContainerRef} from '@angular/core';

/** Ядро. Представление. Хост. Директива. */
@Directive({
  selector: '[appCoreViewHost]'
})
export class AppCoreViewHostDirective {

  /**
   * Конструктор.
   * @param {ViewContainerRef} viewContainerRef Ссылка на представление контейнера.
   */
  constructor(
    public viewContainerRef: ViewContainerRef
  ) { }
}
