// //Author Maxim Kuzmin//makc//

import {Component} from '@angular/core';
import {AppSkinHostLayoutCommonMessageView} from './host-layout-common-message-view';

/** Хост. Разметка. Общее. Сообщение. Компонент. */
@Component({
  selector: 'app-skin-host-layout-common-message',
  templateUrl: './host-layout-common-message.component.html',
  styleUrls: ['./host-layout-common-message.component.css']
})
export class AppSkinHostLayoutCommonMessageComponent {

  /**
   * Мой вид.
   * @type {AppSkinHostLayoutCommonMessageView}
   */
  myView = new AppSkinHostLayoutCommonMessageView({marginTop: '80px', width: '450px'});
}
