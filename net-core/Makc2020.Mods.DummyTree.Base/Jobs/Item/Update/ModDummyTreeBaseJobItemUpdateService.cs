//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Insert;
using Makc2020.Mods.DummyTree.Base.Resources.Errors;
using Makc2020.Mods.DummyTree.Base.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyTree.Base.Jobs.Item.Update
{
    /// <summary>
    /// Мод "DummyTree". Основа. Задания. Элемент. Обновление. Сервис.
    /// </summary>
    public class ModDummyTreeBaseJobItemUpdateService : ModDummyTreeBaseJobItemInsertService
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
        public ModDummyTreeBaseJobItemUpdateService(
            Func<ModDummyTreeBaseJobItemGetOutput, Task<ModDummyTreeBaseJobItemGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModDummyTreeBaseResourceSuccesses resourceSuccesses,
            ModDummyTreeBaseResourceErrors resourceErrors,
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
            ModDummyTreeBaseJobItemGetOutput input,
            ModDummyTreeBaseJobItemGetOutput output
            )
        {
            return new[]
            {
                ResourceSuccesses.GetStringIsUpdated(output.ObjectDummyTree.Name)
            };
        }

        #endregion Protected methods
    }
}