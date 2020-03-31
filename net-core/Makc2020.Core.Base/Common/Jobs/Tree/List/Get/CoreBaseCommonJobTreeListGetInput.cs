//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Core.Base.Common.Enums;
using Makc2020.Core.Base.Common.Jobs.List.Get;
using System.Linq;

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
        /// Идентификатор узла дерева.
        /// </summary>
        public long TreeId { get; set; }

        /// <summary>
        /// Список идентификаторов узлов дерева.
        /// </summary>
        public long[] TreeIds { get; set; }

        /// <summary>
        /// Строка идентификаторов узлов дерева.
        /// </summary>
        public string TreeIdsString { get; set; }

        /// <summary>
        /// Уровень узла дерева.
        /// </summary>
        public long TreeLevel { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Нормализовать.
        /// </summary>
        public override void Normalize()
        {
            base.Normalize();

            if (TreeId < 0)
            {
                TreeId = 0;
            }

            if (TreeLevel < 0)
            {
                TreeLevel = 0;
            }

            if (!string.IsNullOrWhiteSpace(TreeIdsString) && (TreeIds == null || !TreeIds.Any()))
            {
                TreeIds = TreeIdsString.CoreBaseExtConvertToNumericInt64Array();
            }
        }

        #endregion Public methods
    }
}
