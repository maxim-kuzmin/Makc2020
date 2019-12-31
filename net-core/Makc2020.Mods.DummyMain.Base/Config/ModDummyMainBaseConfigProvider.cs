//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common.Config.Providers;

namespace Makc2020.Mods.DummyMain.Base.Config
{
    /// <summary>
    /// Мод "DummyMain". Основа. Конфигурация. Поставщик.
    /// </summary>
    public class ModDummyMainBaseConfigProvider : CoreBaseCommonConfigProviderJson<ModDummyMainBaseConfigSettings>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public ModDummyMainBaseConfigProvider(
            ModDummyMainBaseConfigSettings settings,
            string filePath,
            CoreBaseEnvironment environment
            )
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
