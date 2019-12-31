// //Author Maxim Kuzmin//makc//

/** Ядро. Извещение. Вид. */
export abstract class AppCoreNotificationView {

  /**
   * Конструктор.
   * @param {string[]} messages Сообщения.
   */
  protected constructor(
    public messages: string[],
  ) {
  }
}
