// //Author Maxim Kuzmin//makc//

import {AppCoreExecutionResult} from './core-execution-result';

/** Ядро. Выполнение. Результат. С данными. */
export interface AppCoreExecutionResultWithData<TData> extends AppCoreExecutionResult {

  /**
   * Данные.
   * @type {TData}
   */
  data: TData;
}

/** Ядро. Выполнение. Результат. С данными. Копировать. */
export function appCoreExecutionResultWithDataCopy<TData>(
  source: AppCoreExecutionResultWithData<TData>
): AppCoreExecutionResultWithData<TData> {
  return {
    isOk: source.isOk,
    errorMessages: source.errorMessages,
    successMessages: source.successMessages,
    warningMessages: source.warningMessages,
    data: source.data
  } as AppCoreExecutionResultWithData<TData>;
}

/** Ядро. Выполнение. Результат. С данными. Создать. */
export function appCoreExecutionResultWithDataCreate<TData>(): AppCoreExecutionResultWithData<TData> {
  return {
    isOk: false,
    errorMessages: [],
    successMessages: [],
    warningMessages: []
  } as AppCoreExecutionResultWithData<TData>;
}
