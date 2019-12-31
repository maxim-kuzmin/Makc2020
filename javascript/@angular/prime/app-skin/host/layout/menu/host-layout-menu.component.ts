// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, Input, OnDestroy, OnInit} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostLayoutMenuContext} from '@app/host/layout/menu/host-layout-menu-context';
import {AppHostLayoutMenuPresenter} from '@app/host/layout/menu/host-layout-menu-presenter';
import {AppHostLayoutMenuStore} from '@app/host/layout/menu/host-layout-menu-store';
import {AppHostLayoutMenuView} from '@app/host/layout/menu/host-layout-menu-view';

/** Хост. Разметка. Меню. Компонент. */
@Component({
  selector: '[app-skin-host-layout-menu]',
  templateUrl: './host-layout-menu.component.html',
  styleUrls: ['./host-layout-menu.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinHostLayoutMenuComponent.name},
    AppCoreLoggingService,
    AppHostLayoutMenuContext,
    AppHostLayoutMenuStore
  ]
})
export class AppSkinHostLayoutMenuComponent implements AfterViewInit, OnDestroy, OnInit {

  /**
   * Уровень меню.
   * @type {number}
   */
  @Input() menuLevel: number;

  /**
   * Мой представитель.
   * @type {AppHostLayoutMenuPresenter}
   */
  myPresenter: AppHostLayoutMenuPresenter;

  /**
   * Мой вид.
   * @type {AppHostLayoutMenuView}
   */
  myView: AppHostLayoutMenuView;

  /**
   * Конструктор.
   * @param {AppHostLayoutMenuContext} context Контекст.
   */
  constructor(
    private context: AppHostLayoutMenuContext
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
    this.myView = new AppHostLayoutMenuView(this.menuLevel);

    this.myPresenter = new AppHostLayoutMenuPresenter(
      this.context,
      this.myView
    );
  }
}
