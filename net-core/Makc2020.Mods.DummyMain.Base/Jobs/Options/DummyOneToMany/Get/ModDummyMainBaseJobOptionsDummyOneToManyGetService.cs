//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.DummyMain.Base.Common.Jobs.Options.Get.Output;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyMain.Base.Jobs.Options.DummyOneToMany.Get
{
    /// <summary>
    /// Мод "DummyMain". Задания. Варианты выбора. Сущность "DummyManyToMany". Получение. Сервис.
    /// </summary>
    public class ModDummyMainBaseJobOptionsDummyOneToManyGetService : CoreBaseExecutableServiceAsyncWithOutput
        <
            ModDummyMainBaseCommonJobOptionsGetOutputList
        >
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public ModDummyMainBaseJobOptionsDummyOneToManyGetService(
            Func<Task<ModDummyMainBaseCommonJobOptionsGetOutputList>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
        }

        #endregion Constructors
    }
}