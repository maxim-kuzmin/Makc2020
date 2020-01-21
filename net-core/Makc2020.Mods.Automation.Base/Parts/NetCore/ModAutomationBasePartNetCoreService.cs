//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Common;
using Makc2020.Mods.Automation.Base.Common.Code.Generate;
using Makc2020.Mods.Automation.Base.Parts.NetCore.Config;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Makc2020.Mods.Automation.Base.Parts.NetCore
{
    /// <summary>
    /// Мод "Automation". Основа. Часть "NetCore". Сервис.
    /// </summary>
    public class ModAutomationBasePartNetCoreService : ModAutomationBaseCommonService<IModAutomationBasePartNetCoreConfigSettings>
    {
        #region Constructors

        /// <inheritdoc/>
        public ModAutomationBasePartNetCoreService(IModAutomationBasePartNetCoreConfigSettings configSettings)
            : base(configSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Генерировать код.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача.</returns>
        public Task GenerateCode(ModAutomationBaseCommonJobCodeGenerateInput input)
        {
            InitJobCodeGenerateInput(input);

            var excludedFolderNames = new HashSet<string>
            {
                ".vs",
                "bin",
                "doc",
                "obj",
            };

            var filePaths = GetFilePaths("*.cs", input.Path, excludedFolderNames);

            HandleFiles(filePaths, input.Progress, HandleFile);

            return Task.CompletedTask;
        }

        #endregion Public methods

        #region Private methods

        private void HandleFile(string filePath)
        {
        }

        #endregion Private methods
    }
}
