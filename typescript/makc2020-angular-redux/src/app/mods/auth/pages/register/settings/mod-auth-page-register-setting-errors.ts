// //Author Maxim Kuzmin//makc//

/** Мод "Auth". Страницы. Регистрация. Настройки. Ошибки. */
export class AppModAuthPageRegisterSettingErrors {

  /** Ошибка "E-mail". */
  errorEmail = {
    code: 'fieldEmail',
    messageResourceKey: 'Поле должно содержать правильный адрес электронной почты'
  };

  /** Ошибка "Подтверждение пароля". */
  errorPasswordConfirm = {
    messageResourceKey: 'Пароль не совпадает с его подтверждением'
  };

  /** Ошибка "Обязательно". */
  errorRequired = {
    code: 'required',
    messageResourceKey: 'Поле обязательно для заполнения'
  };
}
