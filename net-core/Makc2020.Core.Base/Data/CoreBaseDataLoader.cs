//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2020.Core.Base.Data
{
    /// <summary>
    /// Ядро. Основа. Данные. Загрузчик.
    /// </summary>
    /// <typeparam name="TData">Тип загружаемых данных.</typeparam>
    public abstract class CoreBaseDataLoader<TData>
    {
        #region Properties

        /// <summary>
        /// Загружаемые свойства.
        /// </summary>
        protected HashSet<string> LoadableDataProperties { get; set; }

        /// <summary>
        /// Данные.
        /// </summary>
        public TData Data { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public CoreBaseDataLoader(TData data)
        {
            Data = data;            
        }

        #endregion Constructors

        #region Protected methods

        /// <summary>
        /// Гарантировать ненулевое значение.
        /// </summary>
        /// <param name="props">Загружаемые свойства.</param>
        /// <returns>Ненулевое значение.</returns>
        protected HashSet<string> EnsureNotNullValue(HashSet<string> props)
        {
            if (props != null)
            {
                return props;
            }
            else
            {
                if (LoadableDataProperties == null)
                {
                    LoadableDataProperties = CreateLoadableDataProperties();
                }

                return LoadableDataProperties;
            }
        }

        /// <summary>
        /// Создать загружаемые свойства.
        /// </summary>
        /// <returns>Загружаемые свойства.</returns>
        protected virtual HashSet<string> CreateLoadableDataProperties()
        {
            return null;
        }

        #endregion Protected methods
    }
}