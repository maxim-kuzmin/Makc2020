//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2020.Core.Base.Ext
{
    /// <summary>
    /// Ядро. Основа. Расширение. Коллекция.
    /// </summary>
    public static class CoreBaseExtCollection
    {
        #region Public methods

        /// <summary>
        /// Ядро. Основа. Расширение. Коллекция. Добавить диапазон.
        /// </summary>
        /// <typeparam name="T">Тип элементов.</typeparam>
        /// <param name="collection">Коллекция.</param>
        /// <param name="items">Элементы.</param>
        public static void CoreBaseExtCollectionAddRange<T>(this HashSet<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        #endregion Public methods
    }
}
