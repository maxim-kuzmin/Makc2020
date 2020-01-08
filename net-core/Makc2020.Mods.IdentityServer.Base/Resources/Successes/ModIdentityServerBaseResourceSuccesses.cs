//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.IdentityServer.Base.Resources.Successes
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Ресурсы. Успехи.
    /// </summary>
    public class ModIdentityServerBaseResourceSuccesses
    {
        #region Properties

        private IStringLocalizer<ModIdentityServerBaseResourceSuccesses> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ModIdentityServerBaseResourceSuccesses(IStringLocalizer<ModIdentityServerBaseResourceSuccesses> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку "Вход выполнен успешно".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringLoginIsSuccessful()
        {
            return Localizer["Вход выполнен успешно"];
        }

        #endregion Public methods
    }
}