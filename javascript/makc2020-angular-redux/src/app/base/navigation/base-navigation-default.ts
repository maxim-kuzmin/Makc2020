// //Author Maxim Kuzmin//makc//

import {Inject} from '@angular/core';
import {appBaseDiTokenWindow} from '../base-di';
import {AppCoreNavigationDefault} from '@app/core/navigation/core-navigation-default';
import {AppCoreSettings} from '@app/core/core-settings';

/** Основа. Навигация. Умолчание. */
export class AppBaseNavigationDefault extends AppCoreNavigationDefault {

  /**
   * Конструктор.
   * @param {AppCoreSettings} appSettings Настройки.
   * @param {Window} appWindow Окно.
   */
  constructor(
    appSettings: AppCoreSettings,
    @Inject(appBaseDiTokenWindow) appWindow: Window
  ) {
    const base = appWindow.document.getElementsByTagName('base')[0];

    const basePath = base.getAttribute('href');

    let hostUrl = base.href;

    if (!hostUrl) {
      hostUrl = appSettings.hostUrl + basePath;
    }

    let apiUrl = appSettings.apiUrl;

    if (!apiUrl) {
      apiUrl = `${hostUrl}api/`;
    }

    super(
      apiUrl,
      basePath,
      hostUrl
    );
  }
}
