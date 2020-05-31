// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {TranslateService} from '@ngx-translate/core';
import {appCoreLocalizationConfigDefaultLanguage, appCoreLocalizationConfigLanguages} from './core-localization-config';
import {AppCoreLocalizationStore} from './core-localization-store';
import {AppCoreLocalizationTranslator} from './core-localization-translator';

/** Ядро. Локализация. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreLocalizationService {

  /**
   * Конструктор.
   * @param {AppCoreLocalizationStore} appStore Хранилище состояния.
   * @param {TranslateService} extTranslator Переводчик.
   */
  constructor(
    private appStore: AppCoreLocalizationStore,
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
    parameters?: Object
  ): AppCoreLocalizationTranslator {
    return new AppCoreLocalizationTranslator(
      this.extTranslator,
      resourceKey,
      parameters
    );
  }

  /** Обработчик события запуска приложения. */
  onApplicationStart() {
    const languageKeys = appCoreLocalizationConfigLanguages.map(x => x.key);

    this.extTranslator.addLangs(languageKeys);

    let languageKey = appCoreLocalizationConfigDefaultLanguage.key;

    this.extTranslator.setDefaultLang(languageKey);

    const browserLang = this.extTranslator.getBrowserLang();

    if (this.languageKeyIsAllowed(browserLang)) {
      languageKey = browserLang;
    }

    this.executeActionLanguageSet(languageKey);
  }

  /**
   * Выполнить действие "Язык. Установка".
   * @param {string} languageKey Ключ языка.
   */
  executeActionLanguageSet(languageKey: string) {
    this.extTranslator.use(languageKey);

    this.appStore.runActionLanguageSet(languageKey);
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
