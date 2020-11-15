using System;

namespace Makc2020.Mods.IdentityServer.Base.Exceptions
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Исключения. Возникла ошибка при попытке поиска групп Active Directory.
    /// </summary>
    public class ModIdentityServerBaseExceptionLdapGroupsSearchFailed : Exception
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        public ModIdentityServerBaseExceptionLdapGroupsSearchFailed(string message)
            : base(message)
        {
        }
    }
}