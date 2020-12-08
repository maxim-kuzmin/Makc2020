// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {Paginator} from 'primeng/paginator';
import {Table} from 'primeng/table';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppModDummyMainPageListPresenter} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list-presenter';
import {AppModDummyMainPageListContext} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list-context';
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
    AppModDummyMainPageListContext,
    AppModDummyMainPageListStore
  ]
})
export class AppSkinModDummyMainPageListComponent implements AfterViewInit, OnDestroy, OnInit {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  @ViewChild('ctrlLoading', {static: false}) private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

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
   * @param {AppModDummyMainPageListContext} context Контекст.
   */
  constructor(
    context: AppModDummyMainPageListContext
  ) {
    this.myView = new AppSkinModDummyMainPageListView(
      context.resources.columns,
      context.getSettingColumns(),
      context.getSettingPageSizeOptions()
    );

    this.myPresenter = new AppModDummyMainPageListPresenter(
      context,
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
