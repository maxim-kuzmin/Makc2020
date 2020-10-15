// //Author Maxim Kuzmin//makc//

import { Injectable } from '@angular/core';
import {AppCoreCommonTitlable} from '@app/core/common/core-common-titlable';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppModDummyMainResources} from './mod-dummy-main-resources';
import {AppModDummyMainService} from './mod-dummy-main.service';

/** Мод "DummyMain". Модель. */
@Injectable()
export class AppModDummyMainModel extends AppCoreCommonTitlable {

  /**
   * Ресурсы.
   * @type {AppModDummyMainResources}
   */
  resources: AppModDummyMainResources;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyMainService} appModDummyMain Страница.
   * @param {AppCoreTitleService} appTitle Заголовок.
   */
  constructor(
    public appLocalizer: AppCoreLocalizationService,
    public appModDummyMain: AppModDummyMainService,
    appTitle: AppCoreTitleService
  ) {
    super(
      appTitle
    );

    this.resources = new AppModDummyMainResources(
      this.appLocalizer,
      this.appModDummyMain.settings,
      this.unsubscribe$
    );
  }

  /** Обработчик события после инициализации представления. */
  onAfterViewInit() {
    this.executeTitleActionItemAdd();
  }

  private executeTitleActionItemAdd() {
    if (this.titleItemsCount === 0) {
      const {
        titleResourceKey
      } = this.appModDummyMain.settings;

      if (titleResourceKey) {
        this.appTitle.executeActionItemAdd(
          titleResourceKey,
          this.resources.titleTranslated$,
          this.unsubscribe$
        );

        this.titleItemsCount = 1;
      }
    }
  }
}
