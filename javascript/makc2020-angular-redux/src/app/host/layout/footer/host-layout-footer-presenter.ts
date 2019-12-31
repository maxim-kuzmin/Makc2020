// //Author Maxim Kuzmin//makc//

import {AppCoreExecutableAsync} from '@app/core/executable/core-executable-async';
import {AppHostLayoutFooterActions} from './host-layout-footer-actions';
import {AppHostLayoutFooterModel} from './host-layout-footer-model';
import {AppHostLayoutFooterState} from './host-layout-footer-state';
import {AppHostLayoutFooterView} from './host-layout-footer-view';

/** Хост. Разметка. Подвал. Представитель. */
export class AppHostLayoutFooterPresenter {

  /** @type {AppCoreExecutableAsync} */
  private onActionLoadSuccessAsync: AppCoreExecutableAsync;

  /**
   * Конструктор.
   * @param {AppHostLayoutFooterModel} model Модель.
   * @param {AppHostLayoutFooterView} view Вид.
   */
  constructor(
    private model: AppHostLayoutFooterModel,
    private view: AppHostLayoutFooterView,
  ) {
    this.onActionLoadSuccess = this.onActionLoadSuccess.bind(this);
    this.onActionLoadSuccessAsync = new AppCoreExecutableAsync(this.onActionLoadSuccess);

    this.onGetState = this.onGetState.bind(this);
  }

  /** Обработчик события после инициализации вида. */
  onAfterViewInit() {
    this.model.getState$().subscribe(this.onGetState);

    this.model.onAfterViewInit();
  }

  /** Обработчик события уничтожения. */
  onDestroy() {
    this.model.onDestroy();
  }

  private onActionLoadSuccess() {
    const {
      jobContentLoadResult: result
    } = this.model.getState();

    if (result) {
      const {
        data
      } = result;

      if (data) {
        this.view.content = data.replace(
          new RegExp('{{year}}', 'g'),
          (new Date()).getFullYear().toString()
        );
      }
    }
  }

  /** @param {AppHostLayoutFooterState} state */
  private onGetState(state: AppHostLayoutFooterState) {
    if (state) {
      const {
        action
      } = state;

      if (action === AppHostLayoutFooterActions.LoadSuccess) {
        this.onActionLoadSuccessAsync.execute();
      }
    }
  }
}
