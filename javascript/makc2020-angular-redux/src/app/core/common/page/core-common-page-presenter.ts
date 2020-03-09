// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPageModel} from '@app/core/common/page/core-common-page-model';
import {AppCoreExceptionEnumActions} from '@app/core/exception/enums/core-exception-enum-actions';
import {AppCoreExceptionState} from '@app/core/exception/core-exception-state';
import {AppCoreExecutableAsync} from '@app/core/executable/core-executable-async';

/**
 * Ядро. Общее. Страница. Представитель.
 * @param {TModel} Тип модели
 */
export abstract class AppCoreCommonPagePresenter<TModel extends AppCoreCommonPageModel> {

  /** @type {AppCoreExecutableAsync} */
  private onExceptionActionThrowAsync: AppCoreExecutableAsync;

  /**
   * Конструктор.
   * @param {TModel} model Модель.
   */
  protected constructor(
    protected model: TModel
  ) {
    this.onExceptionActionThrow = this.onExceptionActionThrow.bind(this);
    this.onExceptionActionThrowAsync = new AppCoreExecutableAsync(this.onExceptionActionThrow);

    this.onGetExceptionState = this.onGetExceptionState.bind(this);
  }

  /** Обработчик события после инициализации представления. */
  onAfterViewInit() {
    this.model.getExceptionState$().subscribe(this.onGetExceptionState);

    this.model.onAfterViewInit();
  }

  /** Обработчик события уничтожения. */
  onDestroy() {
    this.model.onDestroy();
  }

  /**
   * Обработчик исключения.
   * @param {string} message Сообщение.
   * @param {any} error Ошибка.
   */
  protected onException(message: string, error: any) {
  }

  /** Обработчик события инициализации. */
  onInit() {
    this.model.onInit();
  }

  /** @param {AppCoreExceptionState} state */
  private onGetExceptionState(state: AppCoreExceptionState) {
    if (state) {
      const {
        action
      } = state;

      if (action === AppCoreExceptionEnumActions.Throw) {
        this.onExceptionActionThrowAsync.execute();
      }
    }
  }

  private onExceptionActionThrow() {
    const {
      error,
      message
    } = this.model.getExceptionState();

    this.onException(message, error);
  }
}
