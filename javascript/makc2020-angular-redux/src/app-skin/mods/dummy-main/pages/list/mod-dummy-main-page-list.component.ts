// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {Paginator, Table} from 'primeng';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppModDummyMainPageListPresenter} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list-presenter';
import {AppModDummyMainPageListModel} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list-model';
import {AppModDummyMainPageListStore} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list-store';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppSkinModDummyMainPageListView} from './mod-dummy-main-page-list-view';

/** Мод "DummyMain". Страницы. Список. Компонент. */
@Component({
  templateUrl: './mod-dummy-main-page-list.component.html',
  styleUrls: ['./mod-dummy-main-page-list.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModDummyMainPageListComponent.name},
    AppCoreLoggingService,
    AppModDummyMainPageListModel,
    AppModDummyMainPageListStore
  ]
})
export class AppSkinModDummyMainPageListComponent implements AfterViewInit, OnDestroy, OnInit {

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
   * @type {AppModDummyMainPageListPresenter}
   */
  myPresenter: AppModDummyMainPageListPresenter;

  /**
   * Мой вид.
   * @type {AppSkinModDummyMainPageListView}
   */
  myView: AppSkinModDummyMainPageListView;

  /**
   * Конструктор.
   * @param {AppModDummyMainPageListModel} model Модель.
   */
  constructor(
    model: AppModDummyMainPageListModel
  ) {
    this.myView = new AppSkinModDummyMainPageListView(
      model.resources.columns,
      model.getSettingColumns(),
      model.getSettingPageSizeOptions()
    );

    this.myPresenter = new AppModDummyMainPageListPresenter(
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
