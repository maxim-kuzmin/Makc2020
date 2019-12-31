//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data.Db;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace Makc2020.Data.Db.Loaders
{
    /// <summary>
    /// Данные. База данных. Загрузчики. Сущность "User".
    /// </summary>
    public class DataDbLoaderUser : DataBaseLoaderUser, ICoreBaseDataDbLoader
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DataDbLoaderUser(DataBaseObjectUser data = null)
            : base(data ?? new DataBaseObjectUser())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="ordinal">Порядковый номер, начиная с которого нужно считывать данные.</param>
        /// <param name="props">Загружаемые свойства.</param>
        /// <returns>Задача с порядковым номером, начиная с которого нужно считывать следующие данные.</returns>
        public async Task<int> LoadDataFrom(DbDataReader source, int ordinal, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.AccessFailedCount)))
            {
                Data.AccessFailedCount = await source.GetFieldValueAsync<int>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.ConcurrencyStamp)))
            {
                Data.ConcurrencyStamp = await source.CoreBaseExtDbDataReadStringNullableAsync(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.Email)))
            {
                Data.Email = await source.CoreBaseExtDbDataReadStringNullableAsync(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.EmailConfirmed)))
            {
                Data.EmailConfirmed = await source.GetFieldValueAsync<bool>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.FullName)))
            {
                Data.FullName = await source.GetFieldValueAsync<string>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.Id)))
            {
                Data.Id = await source.GetFieldValueAsync<long>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.LockoutEnabled)))
            {
                Data.LockoutEnabled = await source.GetFieldValueAsync<bool>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.LockoutEnd)))
            {
                Data.LockoutEnd = await source.CoreBaseExtDbDataReadDateTimeOffsetNullableAsync(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.NormalizedEmail)))
            {
                Data.NormalizedEmail = await source.CoreBaseExtDbDataReadStringNullableAsync(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.NormalizedUserName)))
            {
                Data.NormalizedUserName = await source.CoreBaseExtDbDataReadStringNullableAsync(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.PasswordHash)))
            {
                Data.PasswordHash = await source.CoreBaseExtDbDataReadStringNullableAsync(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.PhoneNumber)))
            {
                Data.PhoneNumber = await source.CoreBaseExtDbDataReadStringNullableAsync(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.PhoneNumberConfirmed)))
            {
                Data.PhoneNumberConfirmed = await source.GetFieldValueAsync<bool>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.SecurityStamp)))
            {
                Data.SecurityStamp = await source.CoreBaseExtDbDataReadStringNullableAsync(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.TwoFactorEnabled)))
            {
                Data.TwoFactorEnabled = await source.GetFieldValueAsync<bool>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.UserName)))
            {
                Data.UserName = await source.CoreBaseExtDbDataReadStringNullableAsync(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            return ordinal;
        }

        #endregion Public methods
    }
}