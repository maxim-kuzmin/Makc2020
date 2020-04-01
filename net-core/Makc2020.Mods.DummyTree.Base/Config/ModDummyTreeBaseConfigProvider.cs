//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common.Config.Providers;

namespace Makc2020.Mods.DummyTree.Base.Config
{
    /// <summary>
    /// Мод "DummyTree". Основа. Конфигурация. Поставщик.
    /// </summary>
    public class ModDummyTreeBaseConfigProvider : CoreBaseCommonConfigProviderJson<ModDummyTreeBaseConfigSettings>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public ModDummyTreeBaseConfigProvider(
            ModDummyTreeBaseConfigSettings settings,
            string filePath,
            CoreBaseEnvironment environment
            )
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
