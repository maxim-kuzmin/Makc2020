//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2020.Core.Base.Common.Jobs.Item.Get.Item
{
    /// <summary>
    /// Ядро. Основа. Общее. Задания. Элемент. Получить. Ввод.
    /// </summary>
    public abstract class CoreBaseCommonJobItemGetInput
    {
        #region Properties

        /// <summary>
        /// Идентификатор данных.
        /// </summary>
        public long DataId { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Нормализовать.
        /// </summary>
        public virtual void Normalize()
        {
            if (DataId < 0)
            {
                DataId = 0;
            }
        }

        /// <summary>
        /// Получить список свойств с недействительными значениями.
        /// </summary>
        /// <returns>Список свойств.</returns>
        public virtual List<string> GetInvalidProperties()
        {
            var result = new List<string>();

            if (DataId < 1)
            {
                result.Add(nameof(DataId));
            }

            return result;
        }

        #endregion Public methods
    }
}
