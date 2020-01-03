//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Common.Jobs.List.Get
{
    /// <summary>
    /// Ядро. Основа. Общее. Задания. Список. Получить. Ввод.
    /// </summary>
    public abstract class CoreBaseCommonJobListGetInput
    {
        #region Properties

        /// <summary>
        /// Номер страницы данных.
        /// </summary>
        public int DataPageNumber { get; set; }

        /// <summary>
        /// Размер страницы данных.
        /// </summary>
        public int DataPageSize { get; set; }

        /// <summary>
        /// Поле сортировки данных.
        /// </summary>
        public string DataSortField { get; set; }

        /// <summary>
        /// Направление сортировки данных.
        /// </summary>
        public string DataSortDirection { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Нормализовать.
        /// </summary>
        public virtual void Normalize()
        {
            if (DataPageNumber < 1)
            {
                DataPageNumber = 1;
            }

            if (DataPageSize < 1)
            {
                DataPageSize = int.MaxValue;
            }
        }

        #endregion Public methods
    }
}
