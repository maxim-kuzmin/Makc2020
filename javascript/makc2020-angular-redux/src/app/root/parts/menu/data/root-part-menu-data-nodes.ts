// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppCoreTreeNodes} from '@app/core/tree/core-tree-nodes';
import {AppHostPartMenuDataItem, appHostMenuDataItemCreate} from '@app/host/parts/menu/data/host-part-menu-data-item';
import {AppHostPartMenuDataNode, appHostMenuDataNodeCreate} from '@app/host/parts/menu/data/host-part-menu-data-node';
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
  appModDummyTreePageIndexConfigFullPath,
  appModDummyTreePageIndexConfigKey,
  appModDummyTreePageIndexConfigTitleResourceKey
} from '@app/mods/dummy-tree/pages/index/mod-dummy-tree-page-index-config';
import {
  appModDummyTreePageItemCreateConfigFullPath,
  appModDummyTreePageItemCreateConfigKey,
  appModDummyTreePageItemCreateConfigTitleResourceKey,
  appModDummyTreePageItemEditConfigFullPath,
  appModDummyTreePageItemEditConfigKey,
  appModDummyTreePageItemEditConfigTitleResourceKey,
  appModDummyTreePageItemViewConfigFullPath,
  appModDummyTreePageItemViewConfigKey,
  appModDummyTreePageItemViewConfigTitleResourceKey
} from '@app/mods/dummy-tree/pages/item/mod-dummy-tree-page-item-config';
import {
  appModDummyTreePageListConfigFullPath,
  appModDummyTreePageListConfigKey,
  appModDummyTreePageListConfigTitleResourceKey
} from '@app/mods/dummy-tree/pages/list/mod-dummy-tree-page-list-config';
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

/** Корень. Часть "Menu". Данные. Узлы. */
export class AppRootPartMenuDataNodes extends AppCoreTreeNodes<AppHostPartMenuDataItem, AppHostPartMenuDataNode> {

  /**
   * Элемент "ModAuthPageIndex".
   * @type {AppHostPartMenuDataNode}
   */
  nodeModAuthPageIndex: AppHostPartMenuDataNode;

  /**
   * Элемент "ModAuthPageLogon".
   * @type {AppHostPartMenuDataNode}
   */
  nodeModAuthPageLogon: AppHostPartMenuDataNode;

  /**
   * Элемент "ModAuthPageRedirect".
   * @type {AppHostPartMenuDataNode}
   */
  nodeModAuthPageRedirect: AppHostPartMenuDataNode;

  /**
   * Элемент "ModAuthPageRegister".
   * @type {AppHostPartMenuDataNode}
   */
  nodeModAuthPageRegister: AppHostPartMenuDataNode;

  /**
   * Элемент "ModDummyMainPageIndex".
   * @type {AppHostPartMenuDataNode}
   */
  nodeModDummyMainPageIndex: AppHostPartMenuDataNode;

  /**
   * Элемент "ModDummyMainPageItemCreate".
   * @type {AppHostPartMenuDataNode}
   */
  nodeModDummyMainPageItemCreate: AppHostPartMenuDataNode;

  /**
   * Элемент "ModDummyMainPageItemEdit".
   * @type {AppHostPartMenuDataNode}
   */
  nodeModDummyMainPageItemEdit: AppHostPartMenuDataNode;

  /**
   * Элемент "ModDummyMainPageItemView".
   * @type {AppHostPartMenuDataNode}
   */
  nodeModDummyMainPageItemView: AppHostPartMenuDataNode;

  /**
   * Элемент "ModDummyMainPageList".
   * @type {AppHostPartMenuDataNode}
   */
  nodeModDummyMainPageList: AppHostPartMenuDataNode;

  /**
   * Элемент "ModDummyTreePageIndex".
   * @type {AppHostPartMenuDataNode}
   */
  nodeModDummyTreePageIndex: AppHostPartMenuDataNode;

  /**
   * Элемент "ModDummyTreePageItemCreate".
   * @type {AppHostPartMenuDataNode}
   */
  nodeModDummyTreePageItemCreate: AppHostPartMenuDataNode;

  /**
   * Элемент "ModDummyTreePageItemEdit".
   * @type {AppHostPartMenuDataNode}
   */
  nodeModDummyTreePageItemEdit: AppHostPartMenuDataNode;

  /**
   * Элемент "ModDummyTreePageItemView".
   * @type {AppHostPartMenuDataNode}
   */
  nodeModDummyTreePageItemView: AppHostPartMenuDataNode;

  /**
   * Элемент "ModDummyTreePageList".
   * @type {AppHostPartMenuDataNode}
   */
  nodeModDummyTreePageList: AppHostPartMenuDataNode;

  /**
   * Элемент "RootPageAdministration".
   * @type {AppHostPartMenuDataNode}
   */
  nodeRootPageAdministration: AppHostPartMenuDataNode;

  /**
   * Элемент "RootPageContacts".
   * @type {AppHostPartMenuDataNode}
   */
  nodeRootPageContacts: AppHostPartMenuDataNode;

  /**
   * Элемент "RootPageError".
   * @type {AppHostPartMenuDataNode}
   */
  nodeRootPageError: AppHostPartMenuDataNode;

  /**
   * Элемент "RootPageIndex".
   * @type {AppHostPartMenuDataNode}
   */
  nodeRootPageIndex: AppHostPartMenuDataNode;

  /**
   * Элемент "RootPageSite".
   * @type {AppHostPartMenuDataNode}
   */
  nodeRootPageSite: AppHostPartMenuDataNode;

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

    // Menu: 2: RootPageIndex / RootPageAdministration / ModDummyTreePageIndex

    this.nodeModDummyTreePageIndex = this.createNode(
      appModDummyTreePageIndexConfigKey,
      this.nodeRootPageAdministration,
      appModDummyTreePageIndexConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appModDummyTreePageIndexConfigFullPath),
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

    // Menu: 3: RootPageIndex / RootPageAdministration / ModDummyTreePageIndex / ModDummyTreePageList

    this.nodeModDummyTreePageList = this.createNode(
      appModDummyTreePageListConfigKey,
      this.nodeModDummyTreePageIndex,
      appModDummyTreePageListConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appModDummyTreePageListConfigFullPath),
      ''
    );

    // Menu: 3: RootPageIndex / RootPageAdministration / ModDummyTreePageIndex / ModDummyTreePageItemCreate

    this.nodeModDummyTreePageItemCreate = this.createNode(
      appModDummyTreePageItemCreateConfigKey,
      this.nodeModDummyTreePageIndex,
      appModDummyTreePageItemCreateConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appModDummyTreePageItemCreateConfigFullPath),
      '',
      true
    );

    // Menu: 3: RootPageIndex / RootPageAdministration / ModDummyTreePageIndex / ModDummyTreePageItemEdit

    this.nodeModDummyTreePageItemEdit = this.createNode(
      appModDummyTreePageItemEditConfigKey,
      this.nodeModDummyTreePageIndex,
      appModDummyTreePageItemEditConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appModDummyTreePageItemEditConfigFullPath),
      '',
      true
    );

    // Menu: 3: RootPageIndex / RootPageAdministration / ModDummyTreePageIndex / ModDummyTreePageItemView

    this.nodeModDummyTreePageItemView = this.createNode(
      appModDummyTreePageItemViewConfigKey,
      this.nodeModDummyTreePageIndex,
      appModDummyTreePageItemViewConfigTitleResourceKey,
      this.createRouterLinkByFullPath(appModDummyTreePageItemViewConfigFullPath),
      '',
      true
    );
  }

  /**
   * @param key {string}
   * @param parent {AppHostPartMenuDataNode}
   * @param {string} titleResourceKey
   * @param {string} routerLink
   * @param {string} icon
   * @param {boolean} isNeedToRemove
   */
  private createNode(
    key: string,
    parent: AppHostPartMenuDataNode,
    titleResourceKey: string,
    routerLink: any[],
    icon: string,
    isNeedToRemove = false
  ): AppHostPartMenuDataNode {
    const data = appHostMenuDataItemCreate(
      titleResourceKey,
      routerLink,
      null,
      icon,
      this.appLocalizer,
      this.unsubscribe$,
    );

    const parentKey = parent ? parent.key : '';

    const result = appHostMenuDataNodeCreate(
      key,
      data,
      parentKey,
      null,
      null,
      null,
      null,
      isNeedToRemove
    );

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
