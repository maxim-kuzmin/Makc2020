//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.IdentityServer.Base.Enums
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Перечисления. Способы входа в систему.
    /// </summary>
    public enum ModIdentityServerBaseEnumLoginMethods
    {
        /// <summary>
        /// Проверка пароля через LDAP.
        /// </summary>
        Ldap = 1,
        /// <summary>
        /// Проверка пароля через базу данных приложения.
        /// </summary>
        Local = 2,
        /// <summary>
        /// Windows-аутентификация.
        /// </summary>
        Windows = 3
    }
}
