// //Author Maxim Kuzmin//makc//

/** Хост. Элементы управления. Валидация. Сообщение. Настройки. Тексты. */
export class AppHostControlValidationMessageSettingTexts {

  /**
   * Текст об обязательности выбора чекбокса.
   * @type {string}
   */
  textCheckBoxResourceKey = 'Чекбокс <br> должен быть выбран';

  /**
   * Текст о некорректном адресе электронной почты.
   * @type {string}
   */
  textEmailResourceKey = 'Укажите корректный адрес электронной почты';

  /**
   * Текст о нарушении требования минимальной длины.
   * @type {string}
   */
  textMinLengthResourceKey = 'В поле <strong>{{label}}</strong> не может быть меньше {{number}} символов';

  /**
   * Текст о нарушении требования обязательности.
   * @type {string}
   */
  textRequiredResourceKey = 'Поле <strong>{{label}}</strong> обязательно для заполнения';
}
