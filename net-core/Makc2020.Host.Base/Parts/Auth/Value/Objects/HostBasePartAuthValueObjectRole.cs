//Author Maxim Kuzmin//makc//

namespace Makc2020.Host.Base.Parts.Auth.Value.Objects
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Значение. Объекты. Роль.
    /// </summary>
    public class HostBasePartAuthValueObjectRole
    {
        #region Properties

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public HostBasePartAuthValueObjectRole()
        {
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="name">Имя.</param>
        public HostBasePartAuthValueObjectRole(long id, string name)
        {
            Id = id;
            Name = name;
        }

        #endregion Constructors
    }
}