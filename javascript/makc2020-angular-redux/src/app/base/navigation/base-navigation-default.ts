// //Author Maxim Kuzmin//makc//

import {Inject} from '@angular/core';
import {AppCoreNavigationDefault} from '@app/core/navigation/core-navigation-default';
import {appBaseDiTokenWindow} from '../base-di';
import {appCoreConfigApiUrl, appCoreConfigHostUrlWithoutBasePath} from '../../core/core-config';

/** Основа. Навигация. Умолчание. */
export class AppBaseNavigationDefault extends AppCoreNavigationDefault {

  /**
   * Конструктор.
   * @param {Window} window Окно.
   */
  constructor(
    @Inject(appBaseDiTokenWindow) window: Window
  ) {
    const base = window.document.getElementsByTagName('base')[0];

    const basePath = base.getAttribute('href');

    let hostUrl = base.href;

    if (!hostUrl) {
      hostUrl = appCoreConfigHostUrlWithoutBasePath + basePath;
    }

    let apiUrl = appCoreConfigApiUrl;

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
