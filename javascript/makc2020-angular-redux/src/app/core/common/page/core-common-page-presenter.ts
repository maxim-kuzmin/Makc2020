// //Author Maxim Kuzmin//makc//

import {AppCoreLoggingState} from '@app/core/logging/core-logging-state';
import {AppCoreCommonPageModel} from '@app/core/common/page/core-common-page-model';
import {AppCoreExecutableAsync} from '@app/core/executable/core-executable-async';
import {AppCoreLoggingEnumActions} from '@app/core/logging/enums/core-logging-enum-actions';

/**
 * Ядро. Общее. Страница. Представитель.
 * @param {TModel} Тип модели
 */
export abstract class AppCoreCommonPagePresenter<TModel extends AppCoreCommonPageModel> {

  /** @type {AppCoreExecutableAsync} */
  private onLoggerActionLogErrorAsync: AppCoreExecutableAsync;

  /**
   * Конструктор.
   * @param {TModel} model Модель.
   */
  protected constructor(
    protected model: TModel
  ) {
    this.onLoggerActionLogError = this.onLoggerActionLogError.bind(this);
    this.onLoggerActionLogErrorAsync = new AppCoreExecutableAsync(this.onLoggerActionLogError);

    this.onGetLoggerState = this.onGetLoggerState.bind(this);
  }

  /** Обработчик события после инициализации представления. */
  onAfterViewInit() {
    this.model.getLoggerState$().subscribe(this.onGetLoggerState);

    this.model.onAfterViewInit();
  }

  /** Обработчик события уничтожения. */
  onDestroy() {
    this.model.onDestroy();
  }

  /** Обработчик события инициализации. */
  onInit() {
    this.model.onInit();
  }

  /**
   * Обработчик события возникновения ошибки.
   * @param {string} errorMessage Сообщение об ошибке.
   * @param {any} errorData Данные ошибки.
   */
  protected onError(errorMessage: string, errorData: any ) {
  }

  /** @param {AppCoreLoggingState} state */
  private onGetLoggerState(state: AppCoreLoggingState) {
    if (state) {
      const {
        action
      } = state;

      if (action === AppCoreLoggingEnumActions.LogError) {
        this.onLoggerActionLogErrorAsync.execute();
      }
    }
  }

  private onLoggerActionLogError() {
    const {
      errorData,
      errorIsUnhandled,
      errorMessage
    } = this.model.getLoggerState();

    if (errorIsUnhandled) {
      this.onError(errorMessage, errorData);
    }
  }
}
