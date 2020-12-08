// //Author Maxim Kuzmin//makc//

/** Ядро. Выполнение. Результат. */
export interface AppCoreExecutionResult {

  /**
   * Признак успешности выполнения.
   * @type {boolean}
   */
  isOk: boolean;

  /**
   * Сообщения об ошибках.
   * @type {string[]}
   */
  errorMessages: string[];

  /**
   * Сообщения об успехах.
   * @type {string[]}
   */
  successMessages: string[];

  /**
   * Сообщения о предупреждениях.
   * @type {string[]}
   */
  warningMessages: string[];
}

/** Ядро. Выполнение. Результат. Копировать. */
export function appCoreExecutionResultCopy(
  source: AppCoreExecutionResult
): AppCoreExecutionResult {
  return {
    isOk: source.isOk,
    errorMessages: source.errorMessages,
    successMessages: source.successMessages,
    warningMessages: source.warningMessages
  } as AppCoreExecutionResult;
}

/** Ядро. Выполнение. Результат. Создать. */
export function appCoreExecutionResultCreate(): AppCoreExecutionResult {
  return {
    isOk: false,
    errorMessages: [],
    successMessages: [],
    warningMessages: []
  } as AppCoreExecutionResult;
}
