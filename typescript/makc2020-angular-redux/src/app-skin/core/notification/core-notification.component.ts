// //Author Maxim Kuzmin//makc//

import {Component} from '@angular/core';
import {AppSkinCoreNotificationView} from './core-notification-view';

/** Ядро. Извещение. Компонент. */
@Component({
  selector: 'app-skin-core-notification',
  templateUrl: './core-notification.component.html',
  styleUrls: ['./core-notification.component.css']
})
export class AppSkinCoreNotificationComponent {

  /**
   * Мой вид.
   * @type {AppSkinCoreNotificationView}
   */
  myView = new AppSkinCoreNotificationView({marginTop: '80px', width: '450px'});
}
