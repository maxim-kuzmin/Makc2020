//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Enums.Tree.Item;
using System.Collections.Generic;

namespace Makc2020.Core.Base.Common.Jobs.Tree.Item.Get
{
    /// <summary>
    /// Ядро. Основа. Общее. Задания. Дерево. Элемент. Получить. Ввод.
    /// </summary>
    public class CoreBaseCommonJobTreeItemGetInput
    {
        #region Properties

        /// <summary>
        /// Ось.
        /// </summary>
        public CoreBaseCommonEnumTreeItemAxis Axis { get; set; }

        /// <summary>
        /// Идентификатор корневого узла дерева.
        /// </summary>
        public long RootId { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить список свойств с недействительными значениями.
        /// </summary>
        /// <returns>Список свойств.</returns>
        public virtual List<string> GetInvalidProperties()
        {
            var result = new List<string>();

            if (RootId < 1)
            {
                result.Add(nameof(RootId));
            }

            return result;
        }

        /// <summary>
        /// Нормализовать.
        /// </summary>
        public virtual void Normalize()
        {
            if (RootId < 0)
            {
                RootId = 0;
            }
        }

        #endregion Public methods
    }
}
