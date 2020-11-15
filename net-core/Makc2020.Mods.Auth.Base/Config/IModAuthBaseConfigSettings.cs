//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Auth.Enums;
using Makc2020.Mods.Auth.Base.Config.Settings;

namespace Makc2020.Mods.Auth.Base.Config
{
    /// <summary>
    /// Мод "Auth". Основа. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IModAuthBaseConfigSettings
    {
        #region Properties

        /// <summary>
        /// Таймаут команд базы данных.
        /// </summary>
        int DbCommandTimeout { get; }

        /// <summary>
        /// Тип.
        /// </summary>
        CoreBaseAuthEnumTypes Type { get; }

        /// <summary>
        /// Типы.
        /// </summary>
        IModAuthBaseConfigSettingTypes Types { get; }

        #endregion Properties
    }
}