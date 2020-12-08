// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy} from '@angular/core';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppModDummyTreePresenter} from '@app/mods/dummy-tree/mod-dummy-tree-presenter';
import {AppModDummyTreeModel} from '@app/mods/dummy-tree/mod-dummy-tree-model';

/** Мод "DummyTree". Компонент. */
@Component({
  templateUrl: './mod-dummy-tree.component.html',
  styleUrls: ['./mod-dummy-tree.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModDummyTreeComponent.name},
    AppCoreLoggingService,
    AppModDummyTreeModel
  ]
})
export class AppSkinModDummyTreeComponent implements AfterViewInit, OnDestroy {

  /**
   * Мой представитель.
   * @type {AppModDummyTreePresenter}
   */
  myPresenter: AppModDummyTreePresenter;

  /**
   * Конструктор.
   * @param {AppModDummyTreeModel} model Модель.
   */
  constructor(
    private model: AppModDummyTreeModel
  ) {
    this.myPresenter = new AppModDummyTreePresenter(
      model
    );
  }

  /** @inheritDoc */
  ngAfterViewInit() {
    this.myPresenter.onAfterViewInit();
  }

  /** @inheritDoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }
}
