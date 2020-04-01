// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit} from '@angular/core';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppModDummyTreePageIndexModel} from '@app/mods/dummy-tree/pages/index/mod-dummy-tree-page-index-model';
import {AppModDummyTreePageIndexPresenter} from '@app/mods/dummy-tree/pages/index/mod-dummy-tree-page-index-presenter';
import {AppModDummyTreePageIndexStore} from '@app/mods/dummy-tree/pages/index/mod-dummy-tree-page-index-store';
import {AppModDummyTreePageIndexView} from '@app/mods/dummy-tree/pages/index/mod-dummy-tree-page-index-view';

/** Мод "DummyTree". Страницы. Начало. Компонент. */
@Component({
  templateUrl: './mod-dummy-tree-page-index.component.html',
  styleUrls: ['./mod-dummy-tree-page-index.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModDummyTreePageIndexComponent.name},
    AppCoreLoggingService,
    AppModDummyTreePageIndexModel,
    AppModDummyTreePageIndexStore
  ]
})
export class AppSkinModDummyTreePageIndexComponent implements AfterViewInit, OnDestroy, OnInit {

  /**
   * Мой представитель.
   * @type {AppModDummyTreePageIndexPresenter}
   */
  myPresenter: AppModDummyTreePageIndexPresenter;

  /**
   * Мой вид.
   * @type {AppModDummyTreePageIndexView}
   */
  myView: AppModDummyTreePageIndexView;

  /**
   * Конструктор.
   * @param {AppModDummyTreePageIndexModel} model Модель.
   */
  constructor(
    model: AppModDummyTreePageIndexModel
  ) {
    this.myView = new AppModDummyTreePageIndexView();

    this.myPresenter = new AppModDummyTreePageIndexPresenter(
      model,
      this.myView
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

  /** @inheritDoc */
  ngOnInit() {
    this.myPresenter.onInit();
  }
}
