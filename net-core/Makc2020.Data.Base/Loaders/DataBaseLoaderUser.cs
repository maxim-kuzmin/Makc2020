//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Makc2020.Data.Base.Loaders
{
    /// <summary>
    /// Данные. Основа. Загрузчики. Сущность "User".
    /// </summary>
    public class DataBaseLoaderUser : CoreBaseDataLoader<DataBaseObjectUser>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DataBaseLoaderUser(DataBaseObjectUser data = null)
            : base(data ?? new DataBaseObjectUser())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void LoadDataFrom(DataBaseObjectUser source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.AccessFailedCount)))
            {
                Data.AccessFailedCount = source.AccessFailedCount;
            }

            if (props.Contains(nameof(Data.ConcurrencyStamp)))
            {
                Data.ConcurrencyStamp = source.ConcurrencyStamp;
            }

            if (props.Contains(nameof(Data.Email)))
            {
                Data.Email = source.Email;
            }

            if (props.Contains(nameof(Data.EmailConfirmed)))
            {
                Data.EmailConfirmed = source.EmailConfirmed;
            }

            if (props.Contains(nameof(Data.FullName)))
            {
                Data.FullName = source.FullName;
            }

            if (props.Contains(nameof(Data.Id)))
            {
                Data.Id = source.Id;
            }

            if (props.Contains(nameof(Data.LockoutEnabled)))
            {
                Data.LockoutEnabled = source.LockoutEnabled;
            }

            if (props.Contains(nameof(Data.LockoutEnd)))
            {
                Data.LockoutEnd = source.LockoutEnd;
            }

            if (props.Contains(nameof(Data.NormalizedEmail)))
            {
                Data.NormalizedEmail = source.NormalizedEmail;
            }

            if (props.Contains(nameof(Data.NormalizedUserName)))
            {
                Data.NormalizedUserName = source.NormalizedUserName;
            }

            if (props.Contains(nameof(Data.PasswordHash)))
            {
                Data.PasswordHash = source.PasswordHash;
            }

            if (props.Contains(nameof(Data.PhoneNumber)))
            {
                Data.PhoneNumber = source.PhoneNumber;
            }

            if (props.Contains(nameof(Data.PhoneNumberConfirmed)))
            {
                Data.PhoneNumberConfirmed = source.PhoneNumberConfirmed;
            }

            if (props.Contains(nameof(Data.SecurityStamp)))
            {
                Data.SecurityStamp = source.SecurityStamp;
            }

            if (props.Contains(nameof(Data.TwoFactorEnabled)))
            {
                Data.TwoFactorEnabled = source.TwoFactorEnabled;
            }

            if (props.Contains(nameof(Data.UserName)))
            {
                Data.UserName = source.UserName;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Создать загружаемые свойства данных.
        /// </summary>
        /// <returns>Загружаемые свойства данных.</returns>
        protected override HashSet<string> CreateLoadableDataProperties()
        {
            return new HashSet<string>
            {
                nameof(Data.AccessFailedCount),
                nameof(Data.ConcurrencyStamp),
                nameof(Data.Email),
                nameof(Data.EmailConfirmed),
                nameof(Data.FullName),
                nameof(Data.Id),
                nameof(Data.LockoutEnabled),
                nameof(Data.LockoutEnd),
                nameof(Data.NormalizedEmail),
                nameof(Data.NormalizedUserName),
                nameof(Data.PasswordHash),
                nameof(Data.PhoneNumber),
                nameof(Data.PhoneNumberConfirmed),
                nameof(Data.SecurityStamp),
                nameof(Data.TwoFactorEnabled),
                nameof(Data.UserName)
            };
        }

        #endregion Protected methods
    }
}
