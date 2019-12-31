// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Action} from '@ngrx/store';
import {Observable} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostLayoutMenuActions} from '../host-layout-menu-actions';
import {AppHostLayoutMenuStoreActionLoadSuccess} from './actions/host-layout-menu-store-action-load-success';
import {AppHostLayoutMenuStoreActions} from './host-layout-menu-store.actions';
import {AppHostMenuJobNodesFindService} from '@app/host/menu/jobs/nodes/find/host-menu-job-nodes-find.service';

/** Хост. Разметка. Меню. Хранилище состояния. Эффекты. */
@Injectable()
export class AppHostLayoutMenuStoreEffects {

  /**
   * Загрузка.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  load$: Observable<Action> = this.extActions$.pipe(
    ofType(AppHostLayoutMenuActions.Load),
    switchMap(
      action =>
        this.appJobNodesFind.execute$(
          this.appLogger,
          action.jobNodesFindInput
        ).pipe(
          map(
            result =>
              new AppHostLayoutMenuStoreActionLoadSuccess(result, action.menuLevel)
          )
        )
    )
  );

  /**
   * Конструктор.
   * @param {AppHostMenuJobNodesFindService} appJobNodesFind Задание на поиск узлов.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {Actions<AppHostLayoutMenuStoreActions>} extActions$ Поток действий.
   */
  constructor(
    protected appJobNodesFind: AppHostMenuJobNodesFindService,
    private appLogger: AppCoreLoggingService,
    private extActions$: Actions<AppHostLayoutMenuStoreActions>
  ) {
  }
}
