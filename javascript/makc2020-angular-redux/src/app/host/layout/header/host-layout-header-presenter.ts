// //Author Maxim Kuzmin//makc//

import {appCoreLocalizationConfigLanguages} from '@app/core/localization/core-localization-config';
import {AppHostLayoutHeaderModel} from './host-layout-header-model';
import {AppHostLayoutHeaderResources} from './host-layout-header-resources';
import {AppHostLayoutHeaderView} from './host-layout-header-view';

/** Хост. Разметка. Шапка. Представитель. */
export class AppHostLayoutHeaderPresenter {

  /**
   * Ресурсы.
   * @type {AppHostLayoutHeaderResources}
   */
  get resources(): AppHostLayoutHeaderResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppHostLayoutHeaderModel} model Модель.
   * @param {AppHostLayoutHeaderView} view Вид.
   */
  constructor(
    private model: AppHostLayoutHeaderModel,
    private view: AppHostLayoutHeaderView
  ) {
    this.onLanguageChange = this.onLanguageChange.bind(this);
  }

  /** Обработчик события после инициализации вида. */
  onAfterViewInit() {
  }

  /** Обработчик события уничтожения. */
  onDestroy() {
    this.model.onDestroy();
  }

  /** Обработчик события инициализации. */
  onInit() {
    this.view.languages = appCoreLocalizationConfigLanguages;
    this.view.routerLinkToRootPageIndex = this.model.createRouterLinkToRootPageIndexCreate();

    const {
      fieldLanguage
    } = this.view;

    this.model.subscribeToEvent(fieldLanguage.valueChanges, this.onLanguageChange);

    this.view.build();

    this.model.getLanguageKey$().subscribe(
      languageKey => {
        fieldLanguage.setValue(languageKey, {emitEvent: false});
      }
    );
  }

  /** @type {string} languageKey */
  onLanguageChange(languageKey: string) {
    this.model.executeActionLanguageSet(languageKey);
  }
}
