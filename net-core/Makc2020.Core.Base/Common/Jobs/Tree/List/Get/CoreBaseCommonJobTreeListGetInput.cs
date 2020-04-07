//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Enums;
using Makc2020.Core.Base.Common.Jobs.List.Get;

namespace Makc2020.Core.Base.Common.Jobs.Tree.List.Get
{
    /// <summary>
    /// Ядро. Основа. Общее. Задания. Дерево. Список. Получить. Ввод.
    /// </summary>
    public abstract class CoreBaseCommonJobTreeListGetInput : CoreBaseCommonJobListGetInput
    {
        #region Properties

        /// <summary>
        /// Ось.
        /// </summary>
        public CoreBaseCommonEnumTreeAxis Axis { get; set; }

        /// <summary>
        /// Данные: максимальный уровень узла дерева.
        /// </summary>
        public long DataTreeLevelMax { get; set; }

        /// <summary>
        /// Данные: минимальный уровень узла дерева.
        /// </summary>
        public long DataTreeLevelMin { get; set; }

        /// <summary>
        /// Идентификатор корневого узла дерева.
        /// </summary>
        public long RootId { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Нормализовать.
        /// </summary>
        public override void Normalize()
        {
            base.Normalize();

            if (RootId < 0)
            {
                RootId = 0;
            }

            if (DataTreeLevelMax < 0)
            {
                DataTreeLevelMax = 0;
            }

            if (DataTreeLevelMin < 0)
            {
                DataTreeLevelMin = 0;
            }
        }

        #endregion Public methods
    }
}
