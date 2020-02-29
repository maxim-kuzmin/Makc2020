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
  private onLoggerActionLogDebugAsync: AppCoreExecutableAsync;

  /** @type {AppCoreExecutableAsync} */
  private onLoggerActionLogErrorAsync: AppCoreExecutableAsync;

  /** @type {AppCoreExecutableAsync} */
  private onLoggerActionLogSuccessAsync: AppCoreExecutableAsync;

  /** @type {AppCoreExecutableAsync} */
  private onLoggerActionLogWarningAsync: AppCoreExecutableAsync;

  /**
   * Конструктор.
   * @param {TModel} model Модель.
   */
  protected constructor(
    protected model: TModel
  ) {
    this.onLoggerActionLogDebug = this.onLoggerActionLogDebug.bind(this);
    this.onLoggerActionLogDebugAsync = new AppCoreExecutableAsync(this.onLoggerActionLogDebug);

    this.onLoggerActionLogError = this.onLoggerActionLogError.bind(this);
    this.onLoggerActionLogErrorAsync = new AppCoreExecutableAsync(this.onLoggerActionLogError);

    this.onLoggerActionLogSuccess = this.onLoggerActionLogSuccess.bind(this);
    this.onLoggerActionLogSuccessAsync = new AppCoreExecutableAsync(this.onLoggerActionLogSuccess);

    this.onLoggerActionLogWarning = this.onLoggerActionLogWarning.bind(this);
    this.onLoggerActionLogWarningAsync = new AppCoreExecutableAsync(this.onLoggerActionLogWarning);

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
   * Обработчик события регистрации отладочного сообщения.
   * @param {string[]} debugMessages Отладочные сообщения.
   */
  protected onLogDebug(debugMessages: string[]) {
  }

  /**
   * Обработчик события регистрации ошибки.
   * @param {string[]} errorMessages Сообщения об ошибках.
   * @param {any} errorData Данные ошибки.
   */
  protected onLogError(errorMessages: string[], errorData: any) {
  }

  /**
   * Обработчик события регистрации предупреждения.
   * @param {string[]} warningMessages Предупреждающие сообщения.
   */
  protected onLogWarning(warningMessages: string[]) {
  }

  /**
   * Обработчик события регистрации успеха.
   * @param {string[]} successMessages Сообщения об успехах.
   */
  protected onLogSuccess(successMessages: string[]) {
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

  private onLoggerActionLogDebug() {
    const {
      debugMessages
    } = this.model.getLoggerState();

    this.onLogDebug(debugMessages);
  }

  private onLoggerActionLogError() {
    const {
      errorData,
      errorIsUnhandled,
      errorMessages
    } = this.model.getLoggerState();

    if (errorIsUnhandled) {
      this.onLogError(errorMessages, errorData);
    }
  }

  private onLoggerActionLogSuccess() {
    const {
      successMessages
    } = this.model.getLoggerState();

    this.onLogSuccess(successMessages);
  }

  private onLoggerActionLogWarning() {
    const {
      warningMessages
    } = this.model.getLoggerState();

    this.onLogWarning(warningMessages);
  }
}
