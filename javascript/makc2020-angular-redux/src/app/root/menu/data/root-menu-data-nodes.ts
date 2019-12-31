// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppCoreTreeNodes} from '@app/core/tree/core-tree-nodes';
import {AppHostMenuDataItem, appHostMenuDataItemCreate} from '@app/host/menu/data/host-menu-data-item';
import {AppHostMenuDataNode, appHostMenuDataNodeCreate} from '@app/host/menu/data/host-menu-data-node';
import {
  appModAuthPageIndexConfigFullPath,
  appModAuthPageIndexConfigKey,
  appModAuthPageIndexConfigTitleResourceKey
} from '@app/mods/auth/pages/index/mod-auth-page-index-config';
import {
  appModAuthPageLogonConfigFullPath,
  appModAuthPageLogonConfigKey,
  appModAuthPageLogonConfigTitleResourceKey
} from '@app/mods/auth/pages/logon/mod-auth-page-logon-config';
import {
  appModAuthPageRedirectConfigFullPath,
  appModAuthPageRedirectConfigTitleResourceKey
} from '@app/mods/auth/pages/redirect/mod-auth-page-redirect-config';
import {
  appModAuthPageRegisterConfigFullPath,
  appModAuthPageRegisterConfigKey,
  appModAuthPageRegisterConfigTitleResourceKey
} from '@app/mods/auth/pages/register/mod-auth-page-register-config';
import {
  appModDummyMainPageIndexConfigFullPath,
  appModDummyMainPageIndexConfigKey,
  appModDummyMainPageIndexConfigTitleResourceKey
} from '@app/mods/dummy-main/pages/index/mod-dummy-main-page-index-config';
import {
  appModDummyMainPageItemCreateConfigFullPath,
  appModDummyMainPageItemCreateConfigKey,
  appModDummyMainPageItemCreateConfigTitleResourceKey,
  appModDummyMainPageItemEditConfigFullPath,
  appModDummyMainPageItemEditConfigKey,
  appModDummyMainPageItemEditConfigTitleResourceKey,
  appModDummyMainPageItemViewConfigFullPath,
  appModDummyMainPageItemViewConfigKey,
  appModDummyMainPageItemViewConfigTitleResourceKey
} from '@app/mods/dummy-main/pages/item/mod-dummy-main-page-item-config';
import {
  appModDummyMainPageListConfigFullPath,
  appModDummyMainPageListConfigKey,
  appModDummyMainPageListConfigTitleResourceKey
} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list-config';
import {
  appRootPageAdministrationConfigFullPath,
  appRootPageAdministrationConfigKey,
  appRootPageAdministrationConfigTitleResourceKey
} from '@app/root/pages/administration/root-page-administration-config';
import {
  appRootPageContactsConfigFullPath,
  appRootPageContactsConfigKey,
  appRootPageContactsConfigTitleResourceKey
} from '@app/root/pages/contacts/root-page-contacts-config';
import {appRootPageIndexConfigFullPath, appRootPageIndexConfigKey} from '@app/root/pages/index/root-page-index-config';
import {
  appRootPageSiteConfigFullPath,
  appRootPageSiteConfigKey,
  appRootPageSiteConfigTitleResourceKey
} from '@app/root/pages/site/root-page-site-config';

/** Корень. Меню. Данные. Узлы. */
export class AppRootMenuDataNodes extends AppCoreTreeNodes<AppHostMenuDataItem, AppHostMenuDataNode> {

  /**
   * Элемент "ModAuthPageIndex".
   * @type {AppHostMenuDataNode}
   */
  nodeModAuthPageIndex: AppHostMenuDataNode;

  /**
   * Элемент "ModAuthPageLogon".
   * @type {AppHostMenuDataNode}
   */
  nodeModAuthPageLogon: AppHostMenuDataNode;

  /**
   * Элемент "ModAuthPageRedirect".
   * @type {AppHostMenuDataNode}
   */
  nodeModAuthPageRedirect: AppHostMenuDataNode;

  /**
   * Элемент "ModAuthPageRegister".
   * @type {AppHostMenuDataNode}
   */
  nodeModAuthPageRegister: AppHostMenuDataNode;

  /**
   * Элемент "ModDummyMainPageIndex".
   * @type {AppHostMenuDataNode}
   */
  nodeModDummyMainPageIndex: AppHostMenuDataNode;

  /**
   * Элемент "ModDummyMainPageItemCreate".
   * @type {AppHostMenuDataNode}
   */
  nodeModDummyMainPageItemCreate: AppHostMenuDataNode;

  /**
   * Элемент "ModDummyMainPageItemEdit".
   * @type {AppHostMenuDataNode}
   */
  nodeModDummyMainPageItemEdit: AppHostMenuDataNode;

  /**
   * Элемент "ModDummyMainPageItemView".
   * @type {AppHostMenuDataNode}
   */
  nodeModDummyMainPageItemView: AppHostMenuDataNode;

  /**
   * Элемент "ModDummyMainPageList".
   * @type {AppHostMenuDataNode}
   */
  nodeModDummyMainPageList: AppHostMenuDataNode;

  /**
   * Элемент "RootPageAdministration".
   * @type {AppHostMenuDataNode}
   */
  nodeRootPageAdministration: AppHostMenuDataNode;

  /**
   * Элемент "RootPageContacts".
   * @type {AppHostMenuDataNode}
   */
  nodeRootPageContacts: AppHostMenuDataNode;

  /**
   * Элемент "RootPageError".
   * @type {AppHostMenuDataNode}
   */
  nodeRootPageError: AppHostMenuDataNode;

  /**
   * Элемент "RootPageIndex".
   * @type {AppHostMenuDataNode}
   */
  nodeRootPageIndex: AppHostMenuDataNode;

  /**
   * Элемент "RootPageSite".
   * @type {AppHostMenuDataNode}
   */
  nodeRootPageSite: AppHostMenuDataNode;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreNavigationService} appNavigation Навигация.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    private appLocalizer: AppCoreLocalizationService,
    private appNavigation: AppCoreNavigationService,
    private unsubscribe$: Subject<boolean>
  ) {
    super();

    // Menu: 0: RootPageIndex

    this.nodeRootPageIndex = this.createNode(
      appRootPageIndexConfigKey,
      null,
      '',
      this.createRouterLinkByFullPath(appRootPageIndexConfigFullPath),
      'mdi-home-outline'
    );

    // Menu: 1: RootPageIndex / RootPageSite

    this.nodeRootPageSite = this.createNode(
      appRootPageSiteConfigKey,
      this.nodeRootPageIndex,
      appRootPageSiteConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appRootPageSiteConfigFullPath),
      ''
    );

    // Menu: 1: RootPageIndex / RootPageAdministration

    this.nodeRootPageAdministration = this.createNode(
      appRootPageAdministrationConfigKey,
      this.nodeRootPageIndex,
      appRootPageAdministrationConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appRootPageAdministrationConfigFullPath),
      ''
    );

    // Menu: 2: RootPageIndex / RootPageSite / RootPageContacts

    this.nodeRootPageContacts = this.createNode(
      appRootPageContactsConfigKey,
      this.nodeRootPageSite,
      appRootPageContactsConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appRootPageContactsConfigFullPath),
      ''
    );

    // Menu: 2: RootPageIndex / RootPageSite / ModAuthPageIndex

    this.nodeModAuthPageIndex = this.createNode(
      appModAuthPageIndexConfigKey,
      this.nodeRootPageSite,
      appModAuthPageIndexConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appModAuthPageIndexConfigFullPath),
      ''
    );

    // Menu: 2: RootPageIndex / RootPageAdministration / ModDummyMainPageIndex

    this.nodeModDummyMainPageIndex = this.createNode(
      appModDummyMainPageIndexConfigKey,
      this.nodeRootPageAdministration,
      appModDummyMainPageIndexConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appModDummyMainPageIndexConfigFullPath),
      ''
    );

    // Menu: 3: RootPageIndex / RootPageSite / ModAuthPageIndex / ModAuthPageRedirect

    this.nodeModAuthPageRedirect = this.createNode(
      appModAuthPageRegisterConfigKey,
      this.nodeModAuthPageIndex,
      appModAuthPageRedirectConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appModAuthPageRedirectConfigFullPath),
      ''
    );

    // Menu: 3: RootPageIndex / RootPageSite / ModAuthPageIndex / ModAuthPageRegister

    this.nodeModAuthPageRegister = this.createNode(
      appModAuthPageRegisterConfigKey,
      this.nodeModAuthPageIndex,
      appModAuthPageRegisterConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appModAuthPageRegisterConfigFullPath),
      ''
    );

    // Menu: 3: RootPageIndex / RootPageSite / ModAuthPageIndex / ModAuthPageLogon

    this.nodeModAuthPageLogon = this.createNode(
      appModAuthPageLogonConfigKey,
      this.nodeModAuthPageIndex,
      appModAuthPageLogonConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appModAuthPageLogonConfigFullPath),
      ''
    );

    // Menu: 3: RootPageIndex / RootPageAdministration / ModDummyMainPageIndex / ModDummyMainPageList

    this.nodeModDummyMainPageList = this.createNode(
      appModDummyMainPageListConfigKey,
      this.nodeModDummyMainPageIndex,
      appModDummyMainPageListConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appModDummyMainPageListConfigFullPath),
      ''
    );

    // Menu: 3: RootPageIndex / RootPageAdministration / ModDummyMainPageIndex / ModDummyMainPageItemCreate

    this.nodeModDummyMainPageItemCreate = this.createNode(
      appModDummyMainPageItemCreateConfigKey,
      this.nodeModDummyMainPageIndex,
      appModDummyMainPageItemCreateConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appModDummyMainPageItemCreateConfigFullPath),
      ''
    );

    // Menu: 3: RootPageIndex / RootPageAdministration / ModDummyMainPageIndex / ModDummyMainPageItemEdit

    this.nodeModDummyMainPageItemEdit = this.createNode(
      appModDummyMainPageItemEditConfigKey,
      this.nodeModDummyMainPageIndex,
      appModDummyMainPageItemEditConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appModDummyMainPageItemEditConfigFullPath),
      ''
    );

    // Menu: 3: RootPageIndex / RootPageAdministration / ModDummyMainPageIndex / ModDummyMainPageItemView

    this.nodeModDummyMainPageItemView = this.createNode(
      appModDummyMainPageItemViewConfigKey,
      this.nodeModDummyMainPageIndex,
      appModDummyMainPageItemViewConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appModDummyMainPageItemViewConfigFullPath),
      ''
    );
  }

  /**
   * @param key {string}
   * @param parent {AppHostMenuDataNode}
   * @param {string} titleResourceKey
   * @param {string} routerLink
   * @param {string} icon
   */
  private createNode(
    key: string,
    parent: AppHostMenuDataNode,
    titleResourceKey: string,
    routerLink: any[],
    icon: string
  ): AppHostMenuDataNode {
    const data = appHostMenuDataItemCreate(
      titleResourceKey,
      routerLink,
      null,
      icon,
      this.appLocalizer,
      this.unsubscribe$,
    );

    const parentKey = parent ? parent.key : '';

    const result = appHostMenuDataNodeCreate(key, data, parentKey);

    this.addNode(result);

    return result;
  }

  /**
   * @param {string} fullPath
   * @returns {any[]}
   */
  private createRouterLinkByFullPath(fullPath: string): any[] {
    return [fullPath];
  }
}
