//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Insert;
using Makc2020.Mods.DummyMain.Base.Resources.Errors;
using Makc2020.Mods.DummyMain.Base.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyMain.Base.Jobs.Item.Update
{
    /// <summary>
    /// Мод "DummyMain". Основа. Задания. Элемент. Обновление. Сервис.
    /// </summary>
    public class ModDummyMainBaseJobItemUpdateService : ModDummyMainBaseJobItemInsertService
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы. Успехи.</param>
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        /// <param name="dataBaseSettings">Данные. Основа. Настройки.</param>
        public ModDummyMainBaseJobItemUpdateService(
            Func<ModDummyMainBaseJobItemGetOutput, Task<ModDummyMainBaseJobItemGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModDummyMainBaseResourceSuccesses resourceSuccesses,
            ModDummyMainBaseResourceErrors resourceErrors,
            DataBaseSettings dataBaseSettings
            ) : base(
                executable,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors,
                dataBaseSettings
                )
        {
        }

        #endregion Constructors

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override IEnumerable<string> GetSuccessMessages(
            ModDummyMainBaseJobItemGetOutput input,
            ModDummyMainBaseJobItemGetOutput output
            )
        {
            return new[]
            {
                ResourceSuccesses.GetStringIsUpdated(output.ObjectDummyMain.Name)
            };
        }

        #endregion Protected methods
    }
}