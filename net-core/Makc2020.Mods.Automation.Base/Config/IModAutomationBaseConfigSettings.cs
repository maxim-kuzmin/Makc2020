//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Parts.Angular.Config;
using Makc2020.Mods.Automation.Base.Parts.NetCore.Config;

namespace Makc2020.Mods.Automation.Base.Config
{
    /// <summary>
    /// Мод "Automation". Основа. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IModAutomationBaseConfigSettings
    {
        #region Properties

        /// <summary>
        /// Часть "Angular".
        /// </summary>
        IModAutomationBasePartAngularConfigSettings PartAngular { get; }

        /// <summary>
        /// Часть "NetCore".
        /// </summary>
        IModAutomationBasePartNetCoreConfigSettings PartNetCore { get; }

        #endregion Properties
    }
}