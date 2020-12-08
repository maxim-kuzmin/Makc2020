// //Author Maxim Kuzmin//makc//

import {TranslateService} from '@ngx-translate/core';
import {Observable} from 'rxjs';
import {take} from 'rxjs/operators';

/** Ядро. Локализация. Пререводчик. */
export class AppCoreLocalizationTranslator {

  /**
   * Конструктор.
   * @param {TranslateService} translator Переводчик.
   * @param {string} resourceKey Ключ ресурса.
   * @param {?Object} parameters Параметры.
   */
  constructor(
    private translator: TranslateService,
    private resourceKey: string,
    private parameters?: Object
  ) {
  }

  /**
   * Перевести.
   * @param {(word: string) => void}
   * Функция обратного вызова с результатом перевода в качестве аргумента.
   */
  getString(callback: (word: string) => void) {
    this.translate$().pipe(
      take(1)
    ).subscribe(
      callback
    );
  }

  /**
   * Перевести.
   * @returns {Observable<string>} Поток строк результата перевода.
   */
  translate$(): Observable<string> {
    return this.translator.stream(
      this.resourceKey || ' ',
      this.parameters
    );
  }
}
