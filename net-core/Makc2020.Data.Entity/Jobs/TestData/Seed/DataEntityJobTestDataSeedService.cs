//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Resources.Errors;
using System;
using System.Threading.Tasks;

namespace Makc2020.Data.Entity.Jobs.TestData.Seed
{
    /// <summary>
    /// Данные. Entity Framework. Задания. База данных. Тестовые данные. Посев. Сервис.
    /// </summary>
    public class DataEntityJobTestDataSeedService : CoreBaseExecutableServiceAsyncWithoutInputAndOutput
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>     
        public DataEntityJobTestDataSeedService(
            Func<Task> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
        }

        #endregion Constructors
    }
}
