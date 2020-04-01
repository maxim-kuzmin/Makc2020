//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Jobs.Item.Get.Item;
using System.Collections.Generic;
using System.Linq;

namespace Makc2020.Mods.DummyTree.Base.Jobs.Item.Get
{
    /// <summary>
    /// Мод "DummyTree". Основа. Задания. Элемент. Получение. Ввод.
    /// </summary>
    public class ModDummyTreeBaseJobItemGetInput : CoreBaseCommonJobItemGetInput
    {
        #region Properties

        /// <summary>
        /// Имя данных.
        /// </summary>
        public string DataName { get; set; }

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Normalize()
        {
            base.Normalize();

            if (DataId > 0)
            {
                DataName = null;
            }
        }

        /// <inheritdoc/>
        public sealed override List<string> GetInvalidProperties()
        {
            var result = base.GetInvalidProperties();

            if (result.Any())
            {
                if (DataName != null)
                {
                    result.Clear();
                }
                else
                {
                    result.Add(nameof(DataName));
                }
            }

            return result;
        }

        #endregion Public methods
    }
}
