//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Base.Settings;
using System;

namespace Makc2020.Data.Entity.Clients.PostgreSql
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. PostgreSQL. Настройки.
    /// </summary>
    public sealed class DataEntityClientPostgreSqlSettings : DataBaseSettings
    {
        #region Fields

        private static readonly Lazy<DataEntityClientPostgreSqlSettings> lazy =
            new Lazy<DataEntityClientPostgreSqlSettings>(() => new DataEntityClientPostgreSqlSettings());

        #endregion Fields

        #region Properties

        /// <summary>
        /// Экземпляр.
        /// </summary>
        public static DataBaseSettings Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        #endregion Properties

        #region Constructors

        private DataEntityClientPostgreSqlSettings()
        {
            var defaults = new DataBaseDefaults
            {
                ColumnNameForId = "id",
                ColumnNameForName = "name",
                ColumnNameForParentId = "parent_id",
                ColumnNameForTreeChildCount = "tree_child_count",
                ColumnNameForTreeDescendantCount = "tree_descendant_count",
                ColumnNameForTreeLevel = "tree_level",
                ColumnNameForTreePath = "tree_path",
                ColumnNameForTreePosition = "tree_position",
                ColumnNameForTreeSort = "tree_sort",
                ForeignKeyPrefix = "fk",
                FullNamePartsSeparator = ".",
                IndexPrefix = "ix",
                NamePartsSeparator = "_",
                PrimaryKeyPrefix = "pk",
                Schema = "public",
                UniqueIndexPrefix = "ux"
            };

            DummyOneToMany = new DataBaseSettingDummyOneToMany(defaults, "dummy_one_to_many");

            DummyMain = new DataBaseSettingDummyMain(DummyOneToMany, defaults, "dummy_main")
            {
                DbColumnNameForPropBoolean = "prop_boolean",
                DbColumnNameForPropBooleanNullable = "prop_boolean_nullable",
                DbColumnNameForPropDate = "prop_date",
                DbColumnNameForPropDateNullable = "prop_date_nullable",
                DbColumnNameForPropDateTimeOffset = "prop_date_time_offset",
                DbColumnNameForPropDateTimeOffsetNullable = "prop_date_time_offset_nullable",
                DbColumnNameForPropDecimal = "prop_decimal",
                DbColumnNameForPropDecimalNullable = "prop_decimal_nullable",
                DbColumnNameForPropInt32 = "prop_int_32",
                DbColumnNameForPropInt32Nullable = "prop_int_32_nullable",
                DbColumnNameForPropInt64 = "prop_int_64",
                DbColumnNameForPropInt64Nullable = "prop_int_64_nullable",
                DbColumnNameForPropString = "prop_string",
                DbColumnNameForPropStringNullable = "prop_string_nullable"
            };

            DummyManyToMany = new DataBaseSettingDummyManyToMany(defaults, "dummy_many_to_many");

            DummyMainDummyManyToMany = new DataBaseSettingDummyMainDummyManyToMany(
                DummyMain,
                DummyManyToMany,
                defaults,
                "dummy_main_dummy_many_to_many"
                );

            DummyTree = new DataBaseSettingDummyTree(defaults, "dummy_tree");

            DummyTreeLink = new DataBaseSettingDummyTreeLink(defaults, "dummy_tree_link");

            Role = new DataBaseSettingRole(defaults, "role")
            {
                DbColumnNameForConcurrencyStamp = "concurrency_stamp",
                DbColumnNameForNormalizedName = "normalized_name"
            };

            RoleClaim = new DataBaseSettingRoleClaim(Role, defaults, "role_claim")
            {
                DbColumnNameForClaimType = "claim_type",
                DbColumnNameForClaimValue = "claim_value"
            };

            User = new DataBaseSettingUser(defaults, "user",
                dbColumnNameForNormalizedEmail: "normalized_email",
                dbColumnNameForNormalizedUserName: "normalized_user_name"
                )
            {
                DbColumnNameForAccessFailedCount = "access_failed_count",
                DbColumnNameForConcurrencyStamp = "concurrency_stamp",
                DbColumnNameForEmail = "email",
                DbColumnNameForEmailConfirmed = "email_confirmed",
                DbColumnNameForFullName = "full_name",
                DbColumnNameForLockoutEnabled = "lockout_enabled",
                DbColumnNameForLockoutEnd = "lockout_end",
                DbColumnNameForPasswordHash = "password_hash",
                DbColumnNameForPhoneNumber = "phone_number",
                DbColumnNameForPhoneNumberConfirmed = "phone_number_confirmed",
                DbColumnNameForSecurityStamp = "security_stamp",
                DbColumnNameForTwoFactorEnabled = "two_factor_enabled",
                DbColumnNameForUserName = "user_name"                
            };

            UserClaim = new DataBaseSettingUserClaim(User, defaults, "user_claim",
                dbColumnNameForUserId: "user_id"
                )
            {
                DbColumnNameForClaimType = "claim_type",
                DbColumnNameForClaimValue = "claim_value"
            };

            UserLogin = new DataBaseSettingUserLogin(User, defaults, "user_login",
                dbColumnNameForUserId: "user_id"
                )
            {
                DbColumnNameForLoginProvider = "login_provider",
                DbColumnNameForProviderKey = "provider_key",
                DbColumnNameForProviderDisplayName = "provider_display_name",
            };

            UserRole = new DataBaseSettingUserRole(Role, User, defaults, "user_role");

            UserToken = new DataBaseSettingUserToken(User, defaults, "user_token")
            {
                DbColumnNameForLoginProvider = "login_provider",
                DbColumnNameForUserId = "user_id",
                DbColumnNameForValue = "value"
            };
        }

        #endregion Constructors     
    }
}
