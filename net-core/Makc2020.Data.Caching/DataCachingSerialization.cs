//Author Maxim Kuzmin//makc//

using Makc2020.Core.Caching.ProtoBufs;
using Makc2020.Data.Base.Objects;

namespace Makc2020.Data.Caching
{
    /// <summary>
    /// Данные. Кэширование. Сериализация.
    /// </summary>
    public static class DataCachingSerialization
    {
        #region Public methods

        /// <summary>
        /// Инициализировать.
        /// </summary>
        public static void Init()
        {
            var model = ProtoBuf.Meta.RuntimeTypeModel.Default;

            CoreCachingProtoBufDateTimeOffset.Register(model);

            InitDummyMain(model);
            InitDummyMainDummyManyToMany(model);
            InitDummyManyToMany(model);
            InitDummyOneToMany(model);
            InitDummyTree(model);
            InitRole(model);
            InitRoleClaim(model);
            InitUser(model);
            InitUserClaim(model);
            InitUserLogin(model);
            InitUserRole(model);
            InitUserToken(model);
        }

        #endregion Public methods

        #region Private methods

        private static void InitDummyMain(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            DataBaseObjectDummyMain obj;

            model.Add(typeof(DataBaseObjectDummyMain), false).Add(
                nameof(obj.Id),
                nameof(obj.Name),
                nameof(obj.ObjectDummyOneToManyId),
                nameof(obj.PropBoolean),
                nameof(obj.PropDate),
                nameof(obj.PropDateNullable),
                nameof(obj.PropDateTimeOffset),
                nameof(obj.PropDateTimeOffsetNullable),
                nameof(obj.PropDecimal),
                nameof(obj.PropDecimalNullable),
                nameof(obj.PropInt32),
                nameof(obj.PropInt32Nullable),
                nameof(obj.PropInt64),
                nameof(obj.PropInt64Nullable),
                nameof(obj.PropString),
                nameof(obj.PropStringNullable)
                );
        }

        private static void InitDummyMainDummyManyToMany(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            DataBaseObjectDummyMainDummyManyToMany obj;

            model.Add(typeof(DataBaseObjectDummyMainDummyManyToMany), false).Add(
                nameof(obj.ObjectDummyMainId),
                nameof(obj.ObjectDummyManyToManyId)
                );
        }

        private static void InitDummyManyToMany(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            DataBaseObjectDummyManyToMany obj;

            model.Add(typeof(DataBaseObjectDummyManyToMany), false).Add(
                nameof(obj.Id),
                nameof(obj.Name)
                );
        }

        private static void InitDummyOneToMany(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            DataBaseObjectDummyOneToMany obj;

            model.Add(typeof(DataBaseObjectDummyOneToMany), false).Add(
                nameof(obj.Id),
                nameof(obj.Name)
                );
        }

        private static void InitDummyTree(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            DataBaseObjectDummyTree obj;

            model.Add(typeof(DataBaseObjectDummyTree), false).Add(
                nameof(obj.Id),
                nameof(obj.ChildCount),
                nameof(obj.DescendantCount),
                nameof(obj.Level),
                nameof(obj.ObjectDummyMainId),
                nameof(obj.ParentId)
                );
        }

        private static void InitRole(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            DataBaseObjectRole obj;

            model.Add(typeof(DataBaseObjectRole), false).Add(
                nameof(obj.ConcurrencyStamp),
                nameof(obj.Id),
                nameof(obj.Name),
                nameof(obj.NormalizedName)
                );
        }

        private static void InitRoleClaim(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            DataBaseObjectRoleClaim obj;

            model.Add(typeof(DataBaseObjectRoleClaim), false).Add(
                nameof(obj.ClaimType),
                nameof(obj.ClaimValue),
                nameof(obj.Id),
                nameof(obj.RoleId)
                );
        }

        private static void InitUser(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            DataBaseObjectUser obj;

            model.Add(typeof(DataBaseObjectUser), false).Add(
                nameof(obj.AccessFailedCount),
                nameof(obj.ConcurrencyStamp),
                nameof(obj.Email),
                nameof(obj.EmailConfirmed),
                nameof(obj.FullName),
                nameof(obj.Id),
                nameof(obj.LockoutEnabled),
                nameof(obj.LockoutEnd),
                nameof(obj.NormalizedEmail),
                nameof(obj.NormalizedUserName),
                nameof(obj.PasswordHash),
                nameof(obj.PhoneNumber),
                nameof(obj.PhoneNumberConfirmed),
                nameof(obj.SecurityStamp),
                nameof(obj.TwoFactorEnabled),
                nameof(obj.UserName)
                );
        }

        private static void InitUserClaim(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            DataBaseObjectUserClaim obj;

            model.Add(typeof(DataBaseObjectUserClaim), false).Add(
                nameof(obj.ClaimType),
                nameof(obj.ClaimValue),
                nameof(obj.Id),
                nameof(obj.UserId)
                );
        }

        private static void InitUserLogin(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            DataBaseObjectUserLogin obj;

            model.Add(typeof(DataBaseObjectUserLogin), false).Add(
                nameof(obj.LoginProvider),
                nameof(obj.ProviderDisplayName),
                nameof(obj.ProviderKey),
                nameof(obj.UserId)
                );
        }

        private static void InitUserRole(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            DataBaseObjectUserRole obj;

            model.Add(typeof(DataBaseObjectUserRole), false).Add(
                nameof(obj.RoleId),
                nameof(obj.UserId)
                );
        }

        private static void InitUserToken(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            DataBaseObjectUserToken obj;

            model.Add(typeof(DataBaseObjectUserToken), false).Add(
                nameof(obj.LoginProvider),
                nameof(obj.Name),
                nameof(obj.UserId),
                nameof(obj.Value)
                );
        }

        #endregion Private methods
    }
}