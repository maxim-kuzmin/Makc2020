//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Jobs.Item.Get.Item;
using System.Collections.Generic;

namespace Makc2020.Mods.DummyTree.Base.Jobs.Item.Delete
{
    /// <summary>
    /// Мод "DummyTree". Задания. Элемент. Удаление. Ввод.
    /// </summary>
    public class ModDummyTreeBaseJobItemDeleteInput : CoreBaseCommonJobItemGetInput
    {
        #region Properties

        /// <summary>
        /// Данные: имя.
        /// </summary>
        public string DataName { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить список свойств с недействительными значениями.
        /// </summary>
        /// <returns>Список свойств.</returns>
        public sealed override List<string> GetInvalidProperties()
        {
            var result = base.GetInvalidProperties();

            if (string.IsNullOrWhiteSpace(DataName))
            {
                result.Add(nameof(DataName));
            }

            return result;
        }

        #endregion Public methods
    }
}