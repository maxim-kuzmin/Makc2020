// //Author Maxim Kuzmin//makc//

import {Inject} from '@angular/core';
import {appBaseDiTokenDocument} from '../base-di';
import {AppCoreNavigationDefault} from '@app/core/navigation/core-navigation-default';
import {AppCoreSettings} from '@app/core/core-settings';

/** Основа. Навигация. Умолчание. */
export class AppBaseNavigationDefault extends AppCoreNavigationDefault {

  /**
   * Конструктор.
   * @param {AppCoreSettings} appSettings Настройки.
   * @param {Document} appDocument Окно.
   */
  constructor(
    appSettings: AppCoreSettings,
    @Inject(appBaseDiTokenDocument) appDocument: Document
  ) {
    const base = appDocument.getElementsByTagName('base')[0];

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
