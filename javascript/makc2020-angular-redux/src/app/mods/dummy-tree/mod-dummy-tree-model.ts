// //Author Maxim Kuzmin//makc//

import {AppCoreCommonTitlable} from '@app/core/common/core-common-titlable';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppModDummyTreeResources} from './mod-dummy-tree-resources';
import {AppModDummyTreeService} from './mod-dummy-tree.service';
import { Injectable } from '@angular/core';

/** Мод "DummyTree". Модель. */
@Injectable()
export class AppModDummyTreeModel extends AppCoreCommonTitlable {

  /**
   * Ресурсы.
   * @type {AppModDummyTreeResources}
   */
  resources: AppModDummyTreeResources;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyTreeService} appModDummyTree Страница.
   * @param {AppCoreTitleService} appTitle Заголовок.
   */
  constructor(
    public appLocalizer: AppCoreLocalizationService,
    public appModDummyTree: AppModDummyTreeService,
    appTitle: AppCoreTitleService
  ) {
    super(
      appTitle
    );

    this.resources = new AppModDummyTreeResources(
      this.appLocalizer,
      this.appModDummyTree.settings,
      this.unsubscribe$
    );
  }

  /** Обработчик события после инициализации представления. */
  onAfterViewInit() {
    this.executeTitleActionItemAdd();
  }

  private executeTitleActionItemAdd() {
    this.appTitle.executeActionItemAdd(
      this.appModDummyTree.settings.titleResourceKey,
      this.resources.titleTranslated$,
      this.unsubscribe$
    );

    this.titleItemsCount = 1;
  }
}
