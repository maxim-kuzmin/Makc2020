// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {Paginator, Table} from 'primeng';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppModDummyTreePageListPresenter} from '@app/mods/dummy-tree/pages/list/mod-dummy-tree-page-list-presenter';
import {AppModDummyTreePageListModel} from '@app/mods/dummy-tree/pages/list/mod-dummy-tree-page-list-model';
import {AppModDummyTreePageListStore} from '@app/mods/dummy-tree/pages/list/mod-dummy-tree-page-list-store';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppSkinModDummyTreePageListView} from './mod-dummy-tree-page-list-view';

/** Мод "DummyTree". Страницы. Список. Компонент. */
@Component({
  templateUrl: './mod-dummy-tree-page-list.component.html',
  styleUrls: ['./mod-dummy-tree-page-list.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModDummyTreePageListComponent.name},
    AppCoreLoggingService,
    AppModDummyTreePageListModel,
    AppModDummyTreePageListStore
  ]
})
export class AppSkinModDummyTreePageListComponent implements AfterViewInit, OnDestroy, OnInit {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  @ViewChild('ctrlLoading') private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /** @type {Paginator} */
  @ViewChild('ctrlPaginator', {static: true}) private ctrlPaginator: Paginator;

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  @ViewChild('ctrlRefresh', {static: true}) private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {Table} */
  @ViewChild('ctrlTable', {static: true}) private ctrlTable: Table;

  /**
   * Мой представитель.
   * @type {AppModDummyTreePageListPresenter}
   */
  myPresenter: AppModDummyTreePageListPresenter;

  /**
   * Мой вид.
   * @type {AppSkinModDummyTreePageListView}
   */
  myView: AppSkinModDummyTreePageListView;

  /**
   * Конструктор.
   * @param {AppModDummyTreePageListModel} model Модель.
   */
  constructor(
    model: AppModDummyTreePageListModel
  ) {
    this.myView = new AppSkinModDummyTreePageListView(
      model.resources.columns,
      model.getSettingColumns(),
      model.getSettingFields(),
      model.getSettingPageSizeOptions()
    );

    this.myPresenter = new AppModDummyTreePageListPresenter(
      model,
      this.myView
    );
  }

  /** @inheritDoc */
  ngAfterViewInit() {
    this.myView.init(
      this.ctrlLoading,
      this.ctrlRefresh,
      this.ctrlPaginator,
      this.ctrlTable
    );

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
