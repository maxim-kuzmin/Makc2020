//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Mod.Jobs.List.Get;
using System.Linq;

namespace Makc2020.Core.Base.Common.Mod.Ext
{
    /// <summary>
    /// Ядро. Основа. Общее. Мод. Расширение. Применить.
    /// </summary>
    public static class CoreBaseCommonModExtApply
    {
        #region Public methods

        /// <summary>
        /// Ядро. Основа. Общее. Мод. Расширение. Применить. Пагинацию.
        /// </summary>
        /// <typeparam name="T">Тип запрашиваемых данных.</typeparam>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Ввод.</param>
        /// <returns>Запрос страницы.</returns>
        public static IQueryable<T> CoreBaseCommonModExtApplyPagination<T>(
            this IQueryable<T> query,
            CoreBaseCommonModJobListGetInput input
            )
        {
            return query.Skip((input.DataPageNumber - 1) * input.DataPageSize).Take(input.DataPageSize);
        }

        #endregion Public methods
    }
}