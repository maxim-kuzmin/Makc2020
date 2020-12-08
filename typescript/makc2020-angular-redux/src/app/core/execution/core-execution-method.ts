// //Author Maxim Kuzmin//makc//

/** Ядро. Логирование. Вид записи в журнале. Значение. */
export type AppCoreExecutionMethodValue = 'GET' | 'POST' | 'PUT' | 'DELETE';

/** Ядро. Выполнение. Метод. */
export class AppCoreExecutionMethod {

  /**
   * Удалить.
   * @type {string}
   */
  ['delete']: AppCoreExecutionMethodValue = 'DELETE';

  /**
   * Получить.
   * @type {string}
   */
  get: AppCoreExecutionMethodValue = 'GET';

  /**
   * Добавить.
   * @type {string}
   */
  post: AppCoreExecutionMethodValue = 'POST';

  /**
   * Обновить.
   * @type {string}
   */
  put: AppCoreExecutionMethodValue = 'PUT';
}

/** Ядро. Выполнение. Метод. */
export const appCoreExecutionMethod = new AppCoreExecutionMethod();
