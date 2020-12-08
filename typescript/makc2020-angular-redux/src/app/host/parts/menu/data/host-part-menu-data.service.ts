// //Author Maxim Kuzmin//makc//

import {Observable, Subject} from 'rxjs';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppHostPartMenuJobNodeFindInput} from '@app/host/parts/menu/jobs/node/find/host-part-menu-job-node-find-input';
import {AppHostPartMenuJobNodeFindResult} from '@app/host/parts/menu/jobs/node/find/host-part-menu-job-node-find-result';
import {AppHostPartMenuJobNodesFindInput} from '@app/host/parts/menu/jobs/nodes/find/host-part-menu-job-nodes-find-input';
import {AppHostPartMenuJobNodesFindResult} from '@app/host/parts/menu/jobs/nodes/find/host-part-menu-job-nodes-find-result';

/** Хост. Меню. Данные. Сервис. */
export abstract class AppHostPartMenuDataService {

  /**
   * Найти узел.
   * @param {AppHostPartMenuJobNodeFindInput} input Ввод.
   * @returns {Observable<AppHostPartMenuJobNodeFindResult>} Результирующий поток.
   */
  abstract findNode$(input: AppHostPartMenuJobNodeFindInput): Observable<AppHostPartMenuJobNodeFindResult>;

  /**
   * Найти узлы.
   * @param {AppHostPartMenuJobNodesFindInput} input Ввод.
   * @returns {Observable<AppHostPartMenuJobNodesFindResult>} Результирующий поток.
   */
  abstract findNodes$(input: AppHostPartMenuJobNodesFindInput): Observable<AppHostPartMenuJobNodesFindResult>;

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
