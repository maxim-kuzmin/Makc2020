//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;
using Makc2020.Core.Base.Ext;
using Makc2020.Core.Base.Common.Jobs.List.Get;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace Makc2020.Core.Base.Common.Data.Db.Loaders
{
    /// <summary>
    /// Ядро. Основа. Общее. Данные. База данных. Загрузчик списка.
    /// </summary>
    /// <typeparam name="TDataList">Тип данных списка.</typeparam>
    /// <typeparam name="TDataItem">Тип данных элемента.</typeparam>
    public abstract class CoreBaseCommonDataDbLoaderList<TDataList, TDataItem> :
        CoreBaseDataLoader<TDataList>
        where TDataList : CoreBaseCommonJobListGetOutput<TDataItem>, new()
        where TDataItem : class, new()
    {
        #region Properties

        private Func<TDataItem, DbDataReader, int, Task> FuncLoadItem { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="funcLoadItem">Функция загрузки данных элемента.</param>
        /// <param name="data">Данные.</param>
        public CoreBaseCommonDataDbLoaderList(
            Func<TDataItem, DbDataReader, int, Task> funcLoadItem,
            TDataList data
            )
            : base(data)
        {
            FuncLoadItem = funcLoadItem;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Задача.</returns>
        public async Task LoadDataFrom(DbDataReader source)
        {
            Data.TotalCount = await source.GetFieldValueAsync<long>(0).CoreBaseExtTaskWithCurrentCulture(false);

            var list = new List<TDataItem>();

            if (Data.TotalCount > 0)
            {
                await source.NextResultAsync().CoreBaseExtTaskWithCurrentCulture(false);

                while (true)
                {
                    if (!await source.ReadAsync()) break;

                    var dataItem = new TDataItem();

                    await FuncLoadItem(dataItem, source, 0).CoreBaseExtTaskWithCurrentCulture(false);

                    list.Add(dataItem);
                }
            }

            Data.Items = list.ToArray();
        }

        #endregion Public methods
    }
}