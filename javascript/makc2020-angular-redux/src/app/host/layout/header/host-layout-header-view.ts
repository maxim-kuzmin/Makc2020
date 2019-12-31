// //Author Maxim Kuzmin//makc//

import {FormControl} from '@angular/forms';
import {AppCoreLocalizationLanguage} from '@app/core/localization/core-localization-language';

/** Хост. Разметка. Шапка. Вид. */
export abstract class AppHostLayoutHeaderView {

  /**
   * Элемент управления для ввода языка.
   * @type {FormControl}
   */
  fieldLanguage = new FormControl();

  /**
   * Языки.
   * @type {AppCoreLocalizationLanguage[]}
   */
  languages: AppCoreLocalizationLanguage[];

  /**
   * Ссылка маршрутизатора на страницу "RootPageIndex".
   * @type {any[]}
   */
  routerLinkToRootPageIndex: any[];

  /** Построить. */
  abstract build();
}
