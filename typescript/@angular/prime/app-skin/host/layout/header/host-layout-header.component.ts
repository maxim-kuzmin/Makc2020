// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostLayoutHeaderPresenter} from '@app/host/layout/header/host-layout-header-presenter';
import {AppHostLayoutHeaderContext} from '@app/host/layout/header/host-layout-header-context';
import {AppSkinHostLayoutHeaderView} from '@app-skin/host/layout/header/host-layout-header-view';

/** Хост. Разметка. Шапка. Компонент. */
@Component({
  selector: '[app-skin-host-layout-header]',
  templateUrl: './host-layout-header.component.html',
  styleUrls: ['./host-layout-header.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinHostLayoutHeaderComponent.name},
    AppCoreLoggingService,
    AppHostLayoutHeaderContext
  ]
})
export class AppSkinHostLayoutHeaderComponent implements AfterViewInit, OnDestroy, OnInit {

  /**
   * Мой представитель.
   * @type {AppHostLayoutHeaderPresenter}
   */
  myPresenter: AppHostLayoutHeaderPresenter;

  /**
   * Мой вид.
   * @type {AppSkinHostLayoutHeaderView}
   */
  myView: AppSkinHostLayoutHeaderView;

  /**
   * Конструктор.
   * @param {AppHostLayoutHeaderContext} context Контекст.
   */
  constructor(
    context: AppHostLayoutHeaderContext
  ) {
    this.myView = new AppSkinHostLayoutHeaderView();

    this.myPresenter = new AppHostLayoutHeaderPresenter(
      context,
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
