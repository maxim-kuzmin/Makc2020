// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {Observable} from 'rxjs';
import {AppCoreDeactivatingAbility} from '@app/core/deactivating/core-deactivating-ability';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppModDummyTreePageItemModel} from '@app/mods/dummy-tree/pages/item/mod-dummy-tree-page-item-model';
import {AppModDummyTreePageItemPresenter} from '@app/mods/dummy-tree/pages/item/mod-dummy-tree-page-item-presenter';
import {AppModDummyTreePageItemStore} from '@app/mods/dummy-tree/pages/item/mod-dummy-tree-page-item-store';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppSkinModDummyTreePageItemView} from './mod-dummy-tree-page-item-view';

/** Мод "DummyTree". Страницы. Элемент. Компонент. */
@Component({
  templateUrl: './mod-dummy-tree-page-item.component.html',
  styleUrls: ['./mod-dummy-tree-page-item.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModDummyTreePageItemComponent.name},
    AppCoreLoggingService,
    AppModDummyTreePageItemModel,
    AppModDummyTreePageItemStore
  ]
})
export class AppSkinModDummyTreePageItemComponent implements AfterViewInit, OnDestroy, OnInit, AppCoreDeactivatingAbility {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  @ViewChild('ctrlLoading') private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  @ViewChild('ctrlRefresh', {static: true}) private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {NgForm} */
  @ViewChild('ctrlForm', {static: true}) private ctrlForm: NgForm;

  /**
   * Мой представитель.
   * @type {AppModDummyTreePageItemPresenter}
   */
  myPresenter: AppModDummyTreePageItemPresenter;

  /**
   * Мой вид.
   * @type {AppSkinModDummyTreePageItemView}
   */
  myView: AppSkinModDummyTreePageItemView;

  /**
   * Конструктор.
   * @param {AppModDummyTreePageItemModel} model Модель.
   */
  constructor(
    model: AppModDummyTreePageItemModel
  ) {
    this.myView = new AppSkinModDummyTreePageItemView(
      model.getSettingErrors(),
      model.getSettingFields()
    );

    this.myPresenter = new AppModDummyTreePageItemPresenter(
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
