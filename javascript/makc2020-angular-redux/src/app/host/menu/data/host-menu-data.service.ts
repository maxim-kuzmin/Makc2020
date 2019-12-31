// //Author Maxim Kuzmin//makc//

import {Observable, Subject} from 'rxjs';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppHostMenuJobNodeFindInput} from '@app/host/menu/jobs/node/find/host-menu-job-node-find-input';
import {AppHostMenuJobNodeFindResult} from '@app/host/menu/jobs/node/find/host-menu-job-node-find-result';
import {AppHostMenuJobNodesFindInput} from '@app/host/menu/jobs/nodes/find/host-menu-job-nodes-find-input';
import {AppHostMenuJobNodesFindResult} from '@app/host/menu/jobs/nodes/find/host-menu-job-nodes-find-result';

/** Хост. Меню. Данные. Сервис. */
export abstract class AppHostMenuDataService {

  /**
   * Найти узел.
   * @param {AppHostMenuJobNodeFindInput} input Ввод.
   * @returns {Observable<AppHostMenuJobNodeFindResult>} Результирующий поток.
   */
  abstract findNode$(input: AppHostMenuJobNodeFindInput): Observable<AppHostMenuJobNodeFindResult>;

  /**
   * Найти узлы.
   * @param {AppHostMenuJobNodesFindInput} input Ввод.
   * @returns {Observable<AppHostMenuJobNodesFindResult>} Результирующий поток.
   */
  abstract findNodes$(input: AppHostMenuJobNodesFindInput): Observable<AppHostMenuJobNodesFindResult>;

  /**
   * Обработчик события запуска приложения.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreNavigationService} appNavigation Навигация.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  abstract onApplicationStart(
    appLocalizer: AppCoreLocalizationService,
    appNavigation: AppCoreNavigationService,
    unsubscribe$: Subject<boolean>
  );
}
