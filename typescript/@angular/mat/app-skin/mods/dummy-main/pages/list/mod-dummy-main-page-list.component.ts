// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {appCoreConfigSkinSelectorGet} from '@app/core/core-config';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appModDummyMainPageListComponentName} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list.component';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppSkinModDummyMainPageListView} from './mod-dummy-main-page-list-view';
import {AppModDummyMainPageListPresenter} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list-presenter';
import {AppModDummyMainPageListContext} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list-context';

/** Мод "DummyMain". Страницы. Список. Компонент. */
@Component({
  selector: appCoreConfigSkinSelectorGet(appModDummyMainPageListComponentName),
  templateUrl: './mod-dummy-main-page-list.component.html',
  styleUrls: ['./mod-dummy-main-page-list.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModDummyMainPageListComponent.name},
    AppCoreLoggingService,
    AppModDummyMainPageListContext
  ]
})
export class AppSkinModDummyMainPageListComponent implements AfterViewInit, OnDestroy {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  @ViewChild('ctrlLoading', { static: false }) private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  @ViewChild('ctrlRefresh', { static: true }) private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {MatPaginator} */
  @ViewChild('ctrlPaginator', { static: true }) private ctrlPaginator: MatPaginator;

  /** @type {MatSort} */
  @ViewChild(MatSort, { static: true }) private ctrlSort: MatSort;

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
    const {
      appCore,
      appPage
    } = context;

    this.myView = new AppSkinModDummyMainPageListView(
      appPage.settings.columns,
      appCore.settings.pageSizeOptions
    );

    this.myPresenter = new AppModDummyMainPageListPresenter(
      context,
      this.myView
    );
  }

  /** @inheritdoc */
  ngAfterViewInit() {
    this.myView.init(
      this.ctrlLoading,
      this.ctrlRefresh,
      this.ctrlPaginator,
      this.ctrlSort
    );

    this.myPresenter.onAfterViewInit();
  }

  /** @inheritdoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }
}
