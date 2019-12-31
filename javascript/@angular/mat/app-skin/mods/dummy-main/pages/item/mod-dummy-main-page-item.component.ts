// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {appCoreConfigSkinSelectorGet} from '@app/core/core-config';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appModDummyMainPageItemComponentName} from '@app/mods/dummy-main/pages/item/mod-dummy-main-page-item.component';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppSkinModDummyMainPageItemView} from './mod-dummy-main-page-item-view';
import {AppCoreDeactivatingAbility} from '@app/core/deactivating/core-deactivating-ability';
import {Observable} from 'rxjs';
import {AppModDummyMainPageItemPresenter} from '@app/mods/dummy-main/pages/item/mod-dummy-main-page-item-presenter';
import {AppModDummyMainPageItemContext} from '@app/mods/dummy-main/pages/item/mod-dummy-main-page-item-context';

/** Мод "DummyMain". Страницы. Элемент. Компонент. */
@Component({
  selector: appCoreConfigSkinSelectorGet(appModDummyMainPageItemComponentName),
  templateUrl: './mod-dummy-main-page-item.component.html',
  styleUrls: ['./mod-dummy-main-page-item.component.css'],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModDummyMainPageItemComponent.name },
    AppCoreLoggingService,
    AppModDummyMainPageItemContext
  ]
})
export class AppSkinModDummyMainPageItemComponent implements AfterViewInit, OnDestroy, AppCoreDeactivatingAbility {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  @ViewChild('ctrlLoading', { static: false }) private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  @ViewChild('ctrlRefresh', { static: true }) private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {NgForm} */
  @ViewChild('ctrlForm', { static: true }) private ctrlForm: NgForm;

  /**
   * Мой представитель.
   * @type {AppModDummyMainPageItemPresenter}
   */
  myPresenter: AppModDummyMainPageItemPresenter;

  /**
   * Мой вид.
   * @type {AppSkinModDummyMainPageItemView}
   */
  myView: AppSkinModDummyMainPageItemView;

  /**
   * Конструктор.
   * @param {AppModDummyMainPageItemContext} context Контекст.
   */
  constructor(
    context: AppModDummyMainPageItemContext
  ) {
    const {
      appPage
    } = context;

    this.myView = new AppSkinModDummyMainPageItemView(
      appPage.settings.errors,
      appPage.settings.fields
    );

    this.myPresenter = new AppModDummyMainPageItemPresenter(
      context,
      this.myView
    );
  }

  /**
   * @inheritdoc
   * @returns {Observable<boolean> | Promise<boolean> | boolean}
   */
  canDeactivate(): Observable<boolean> | Promise<boolean> | boolean {
    return this.myPresenter.canDeactivate();
  }

  /** @inheritdoc */
  ngAfterViewInit() {
    this.myView.init(
      this.ctrlLoading,
      this.ctrlRefresh,
      this.ctrlForm
    );

    this.myPresenter.onAfterViewInit();
  }

  /** @inheritdoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }
}
