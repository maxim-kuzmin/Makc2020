//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.Automation.Base.Resources.Successes
{
    /// <summary>
    /// Мод "Automation". Основа. Ресурсы. Успехи.
    /// </summary>
    public class ModAutomationBaseResourceSuccesses
    {
        #region Properties

        private IStringLocalizer<ModAutomationBaseResourceSuccesses> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ModAutomationBaseResourceSuccesses(IStringLocalizer<ModAutomationBaseResourceSuccesses> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Сущность с именем 'Имя исходной сущности' сгенерирована из сущности с именем 'Имя целевой сущности'.
        /// </summary>
        /// <param name="sourceEntityName">Имя исходной сущности.</param>
        /// <param name="targetEntityName">Имя целевой сущности.</param>
        /// <returns>Строка.</returns>
        public string GetStringEntityIsGenerated(string targetEntityName, string sourceEntityName)
        {
            return string.Format(
                Localizer["Сущность с именем '{0}' сгенерирована из сущности с именем '{1}'"],
                targetEntityName,
                sourceEntityName
                );
        }

        #endregion Public methods
    }
}