// //Author Maxim Kuzmin//makc//

import {Component, ComponentFactoryResolver, Input, Type, ViewChild} from '@angular/core';
import {AppCoreViewHostDirective} from './core-view-host.directive';

/** Ядро. Представление. Компонент. */
@Component({
  selector: 'app-core-view',
  template: '<ng-template appCoreViewHost></ng-template>'
})
export class AppCoreViewComponent {
  @Input()
  type: Type<any>;

  @ViewChild(AppCoreViewHostDirective, { static: true }) host: AppCoreViewHostDirective;

  constructor(
    private componentFactoryResolver: ComponentFactoryResolver
  ) {
    const componentFactory = this.componentFactoryResolver.resolveComponentFactory(this.type);

    this.host.viewContainerRef.clear();

    this.host.viewContainerRef.createComponent(componentFactory);
  }
}
