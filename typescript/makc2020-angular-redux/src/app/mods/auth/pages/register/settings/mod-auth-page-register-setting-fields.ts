// //Author Maxim Kuzmin//makc//

/** Мод "Auth". Страницы. Регистрация. Настройки. Поля. */
export class AppModAuthPageRegisterSettingFields {

  /** Поле "E-mail". */
  fieldEmail = {
    name: 'dataEmail',
    labelResourceKey: 'Адрес электронной почты',
    placeholderResourceKey: 'Введите адрес электронной почты'
  };

  /** Поле "Полное имя". */
  fieldFullName = {
    name: 'fullName',
    labelResourceKey: 'Ф.И.О',
    placeholderResourceKey: 'Введите Ф.И.О'
  };

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

  /** Поле "Подтверждение пароля". */
  fieldPasswordConfirm = {
    name: 'passwordConfirm',
    labelResourceKey: 'Подтверждение пароля',
    placeholderResourceKey: 'Введите пароль ещё раз',
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
    name: 'userName',
    labelResourceKey: 'Имя',
    placeholderResourceKey: 'Введите имя'
  };
}
