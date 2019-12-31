// //Author Maxim Kuzmin//makc//

/** Мод "Auth". Страницы. Вход в систему. Настройки. Поля. */
export class AppModAuthPageLogonSettingFields {

  /** Поле "Пароль". */
  fieldPassword = {
    name: 'password',
    labelResourceKey: 'Пароль',
    placeholderResourceKey: 'Введите пароль',
    visibility: {
      off: {
        icon: 'visibility_off',
        type: 'password'
      },
      on: {
        icon: 'visibility',
        type: 'text'
      }
    }
  };

  /** Поле "Имя пользователя". */
  fieldUserName = {
    name: 'fieldUserName',
    labelResourceKey: 'Имя',
    placeholderResourceKey: 'Введите имя'
  };
}
