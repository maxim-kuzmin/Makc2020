// //Author Maxim Kuzmin//makc//

import {AppCoreCommonTitlable} from '@app/core/common/core-common-titlable';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppModAuthResources} from './mod-auth-resources';
import {AppModAuthService} from './mod-auth.service';
import { Injectable } from '@angular/core';

/** Мод "Auth". Модель. */
@Injectable()
export class AppModAuthModel extends AppCoreCommonTitlable {

  /**
   * Ресурсы.
   * @type {AppModAuthResources}
   */
  resources: AppModAuthResources;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModAuthService} appModAuth Страница.
   * @param {AppCoreTitleService} appTitle Заголовок.
   */
  constructor(
    public appLocalizer: AppCoreLocalizationService,
    public appModAuth: AppModAuthService,
    appTitle: AppCoreTitleService
  ) {
    super(
      appTitle
    );

    this.resources = new AppModAuthResources(
      this.appLocalizer,
      this.appModAuth.settings,
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
      } = this.appModAuth.settings;

      if (!!titleResourceKey) {
        this.appTitle.executeActionItemAdd(
          titleResourceKey,
          this.resources.titleTranslated$,
          this.unsubscribe$
        );

        this.titleItemsCount++;
      }
    }
  }
}
