// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, Input, OnDestroy, OnInit} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostLayoutFooterModel} from '@app/host/layout/footer/host-layout-footer-model';
import {AppHostLayoutFooterPresenter} from '@app/host/layout/footer/host-layout-footer-presenter';
import {AppHostLayoutFooterStore} from '@app/host/layout/footer/host-layout-footer-store';
import {AppHostLayoutFooterView} from '@app/host/layout/footer/host-layout-footer-view';

/** Хост. Разметка. Меню. Компонент. */
@Component({
  selector: 'app-skin-host-layout-footer',
  templateUrl: './host-layout-footer.component.html',
  styleUrls: ['./host-layout-footer.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinHostLayoutFooterComponent.name},
    AppCoreLoggingService,
    AppHostLayoutFooterModel,
    AppHostLayoutFooterStore
  ]
})
export class AppSkinHostLayoutFooterComponent implements AfterViewInit, OnDestroy, OnInit {

  /**
   * Уровень меню.
   * @type {number}
   */
  @Input() menuLevel: number;

  /**
   * Мой представитель.
   * @type {AppHostLayoutFooterPresenter}
   */
  myPresenter: AppHostLayoutFooterPresenter;

  /**
   * Мой вид.
   * @type {AppHostLayoutFooterView}
   */
  myView: AppHostLayoutFooterView;

  /**
   * Конструктор.
   * @param {AppHostLayoutFooterModel} model Модель.
   */
  constructor(
    private model: AppHostLayoutFooterModel
  ) {
  }

  /** @inheritDoc */
  ngAfterViewInit() {
    this.myPresenter.onAfterViewInit();
  }

  /** @inheritDoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }

  ngOnInit() {
    this.myView = new AppHostLayoutFooterView();

    this.myPresenter = new AppHostLayoutFooterPresenter(
      this.model,
      this.myView
    );
  }
}
