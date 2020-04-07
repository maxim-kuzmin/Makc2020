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
        /// Номер страницы.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Размер страницы.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Поле сортировки.
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        /// Направление сортировки.
        /// </summary>
        public string SortDirection { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Нормализовать.
        /// </summary>
        public virtual void Normalize()
        {
            if (PageNumber < 1)
            {
                PageNumber = 1;
            }

            if (PageSize < 1)
            {
                PageSize = int.MaxValue;
            }
        }

        #endregion Public methods
    }
}
