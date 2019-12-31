// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationLanguage} from '@app/core/localization/core-localization-language';

/**
 * Русский язык.
 * @type {AppCoreLocalizationLanguage}
 */
export const appCoreLocalizationConfigLanguageRu = new AppCoreLocalizationLanguage(
  'ru',
  'Русский'
);

/**
 * Английский язык.
 * @type {AppCoreLocalizationLanguage}
 */
export const appCoreLocalizationConfigLanguageEn = new AppCoreLocalizationLanguage(
  'en',
  'English'
);

/**
 * Языки.
 * @type {AppCoreLocalizationLanguage[]}
 */
export const appCoreLocalizationConfigLanguages = [
  appCoreLocalizationConfigLanguageRu,
  appCoreLocalizationConfigLanguageEn
];

/**
 * Язык по умолчанию.
 * @type {AppCoreLocalizationLanguage}
 */
export const appCoreLocalizationConfigDefaultLanguage = appCoreLocalizationConfigLanguageRu;
