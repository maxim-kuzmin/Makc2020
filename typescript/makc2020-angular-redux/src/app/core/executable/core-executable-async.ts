// //Author Maxim Kuzmin//makc//

/** Ядро. Исполняемое. Асинхронно. */
export class AppCoreExecutableAsync {

  /**
   * Конструктор.
   * @param {() => void} action Действие.
   */
  constructor(private action: () => void) { }

  /** Выполнить. */
  execute() {
    Promise.resolve().then(() => this.action());
  }
}
