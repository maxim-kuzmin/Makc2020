// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, Input, OnDestroy, OnInit} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostLayoutMenuPresenter} from '@app/host/layout/menu/host-layout-menu-presenter';
import {AppHostLayoutMenuContext} from '@app/host/layout/menu/host-layout-menu-context';
import {AppSkinHostLayoutMenuView} from './host-layout-menu-view';

/** Хост. Разметка. Меню. Компонент. */
@Component({
  selector: 'app-skin-host-layout-menu',
  templateUrl: './host-layout-menu.component.html',
  styleUrls: ['./host-layout-menu.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinHostLayoutMenuComponent.name},
    AppCoreLoggingService,
    AppHostLayoutMenuContext
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
   * @type {AppSkinHostLayoutMenuView}
   */
  myView: AppSkinHostLayoutMenuView;

  /**
   * Конструктор.
   * @param {AppHostLayoutMenuContext} context Контекст.
   */
  constructor(
    private context: AppHostLayoutMenuContext
  ) {
  }

  /** @inheritdoc */
  ngAfterViewInit() {
    this.myPresenter.onAfterViewInit();
  }

  /** @inheritdoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }

  ngOnInit() {
    this.myView = new AppSkinHostLayoutMenuView(this.menuLevel);

    this.myPresenter = new AppHostLayoutMenuPresenter(
      this.context,
      this.myView
    );
  }
}
