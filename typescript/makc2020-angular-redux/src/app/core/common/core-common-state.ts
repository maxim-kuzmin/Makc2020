// //Author Maxim Kuzmin//makc//

/**
 * Ядро. Общее. Состояние.
 * @param <TAction> Тип действия.
 */
export abstract class AppCoreCommonState<TAction> {

  /**
   * Действие.
   * @type {TAction}
   */
  action: TAction;
}
