//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Jobs.Item.Get.Item;

namespace Makc2020.Core.Base.Common.Jobs.Tree.Item.Get
{
    /// <summary>
    /// Ядро. Основа. Общее. Задания. Дерево. Элемент. Получить. Ввод.
    /// </summary>
    public abstract class CoreBaseCommonJobTreeItemGetInput : CoreBaseCommonJobItemGetInput
    {
        #region Properties

        /// <summary>
        /// Идентификатор узла дерева.
        /// </summary>
        public long TreeId { get; set; }

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

            if (TreeId > 0)
            {
                DataId = 0;
            }
        }

        #endregion Public methods
    }
}
