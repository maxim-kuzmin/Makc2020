// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {Observable} from 'rxjs';
import {AppCoreDeactivatingAbility} from '@app/core/deactivating/core-deactivating-ability';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppModDummyMainPageItemModel} from '@app/mods/dummy-main/pages/item/mod-dummy-main-page-item-model';
import {AppModDummyMainPageItemPresenter} from '@app/mods/dummy-main/pages/item/mod-dummy-main-page-item-presenter';
import {AppModDummyMainPageItemStore} from '@app/mods/dummy-main/pages/item/mod-dummy-main-page-item-store';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppSkinModDummyMainPageItemView} from './mod-dummy-main-page-item-view';

/** Мод "DummyMain". Страницы. Элемент. Компонент. */
@Component({
  templateUrl: './mod-dummy-main-page-item.component.html',
  styleUrls: ['./mod-dummy-main-page-item.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModDummyMainPageItemComponent.name},
    AppCoreLoggingService,
    AppModDummyMainPageItemModel,
    AppModDummyMainPageItemStore
  ]
})
export class AppSkinModDummyMainPageItemComponent implements AfterViewInit, OnDestroy, OnInit, AppCoreDeactivatingAbility {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  @ViewChild('ctrlLoading') private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  @ViewChild('ctrlRefresh', {static: true}) private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {NgForm} */
  @ViewChild('ctrlForm', {static: true}) private ctrlForm: NgForm;

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
   * @param {AppModDummyMainPageItemModel} model Модель.
   */
  constructor(
    model: AppModDummyMainPageItemModel
  ) {
    this.myView = new AppSkinModDummyMainPageItemView(
      model.getSettingErrors(),
      model.getSettingFields()
    );

    this.myPresenter = new AppModDummyMainPageItemPresenter(
      model,
      this.myView
    );
  }

  /**
   * @inheritDoc
   * @returns {Observable<boolean> | Promise<boolean> | boolean}
   */
  canDeactivate(): Observable<boolean> | Promise<boolean> | boolean {
    return this.myPresenter.canDeactivate();
  }

  /** @inheritDoc */
  ngAfterViewInit() {
    this.myView.init(
      this.ctrlLoading,
      this.ctrlRefresh,
      this.ctrlForm
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
