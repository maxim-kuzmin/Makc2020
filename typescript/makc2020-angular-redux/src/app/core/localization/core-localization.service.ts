// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {TranslateService} from '@ngx-translate/core';
import 'core-js/features/url-search-params';
import {
  appCoreLocalizationConfigDefaultLanguage,
  appCoreLocalizationConfigLanguageRu,
  appCoreLocalizationConfigLanguages
} from './core-localization-config';
import {AppCoreLocalizationStore} from './core-localization-store';
import {AppCoreLocalizationTranslator} from './core-localization-translator';
import {appCoreSettings} from '@app/core/core-settings';

/** Ядро. Локализация. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreLocalizationService {

  /**
   * Конструктор.
   * @param {AppCoreLocalizationStore} appLocalizerStore Хранилище состояния локализатора.
   * @param {TranslateService} extTranslator Переводчик.
   */
  constructor(
    private appLocalizerStore: AppCoreLocalizationStore,
    private extTranslator: TranslateService
  ) {
  }

  /**
   * Создать переводчик.
   * @param {string} resourceKey Ключ ресурса.
   * @param {?Object} parameters Параметры.
   * @returns {AppCoreLocalizationTranslator} Переводчик.
   */
  createTranslator(
    resourceKey: string,
    parameters?: {}
  ): AppCoreLocalizationTranslator {
    return new AppCoreLocalizationTranslator(
      this.extTranslator,
      resourceKey,
      parameters
    );
  }

  /** Обработчик события запуска приложения. */
  onApplicationStart() {
    const urlParams = new URLSearchParams(window.location.search);

    let languageKey = urlParams.get(appCoreSettings.hostLangParamName);

    if (!languageKey) {
      languageKey = this.appLocalizerStore.getState().languageKey;
    }

    if (!languageKey) {
      const languageKeys = appCoreLocalizationConfigLanguages.map(x => x.key);

      this.extTranslator.addLangs(languageKeys);

      languageKey = appCoreLocalizationConfigDefaultLanguage.key;

      this.extTranslator.setDefaultLang(languageKey);

      // const browserLang = this.extTranslator.getBrowserLang();
      //
      // if (this.languageKeyIsAllowed(browserLang)) {
      //   languageKey = browserLang;
      // }
    }

    this.executeActionLanguageSet(languageKey);
  }

  /**
   * Выполнить действие "Язык. Установка".
   * @param {string} languageKey Ключ языка.
   */
  executeActionLanguageSet(languageKey: string) {
    if (this.extTranslator.currentLang !== languageKey) {
      if (languageKey === appCoreLocalizationConfigLanguageRu.key) {
        this.extTranslator.resetLang(this.extTranslator.currentLang);
      }

      this.extTranslator.use(languageKey);
    }

    this.appLocalizerStore.runActionLanguageSet(languageKey);
  }

  /**
   * Получить признак того, что ключ языка является разрешённым.
   * @param {string} languageKey Ключ языка.
   * @returns {boolean}
   */
  languageKeyIsAllowed(languageKey: string): boolean {
    let result = false;

    if (languageKey) {
      const languageKeys = appCoreLocalizationConfigLanguages.map(x => x.key);

      for (const lang of languageKeys) {
        if (lang === languageKey) {
          result = true;
          break;
        }
      }
    }

    return result;
  }
}
