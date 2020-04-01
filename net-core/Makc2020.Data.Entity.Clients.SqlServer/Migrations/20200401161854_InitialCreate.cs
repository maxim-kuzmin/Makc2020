using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Makc2020.Data.Entity.Clients.SqlServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "DummyManyToMany",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DummyManyToMany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DummyOneToMany",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DummyOneToMany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DummyTree",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    ParentId = table.Column<long>(nullable: true),
                    ChildCount = table.Column<long>(nullable: false, defaultValue: 0L),
                    DescendantCount = table.Column<long>(nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DummyTree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DummyTree_DummyTree_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "dbo",
                        principalTable: "DummyTree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DummyMain",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    DummyOneToManyId = table.Column<long>(nullable: false),
                    PropBoolean = table.Column<bool>(nullable: false),
                    PropBooleanNullable = table.Column<bool>(nullable: true),
                    PropDate = table.Column<DateTime>(nullable: false),
                    PropDateNullable = table.Column<DateTime>(nullable: true),
                    PropDateTimeOffset = table.Column<DateTimeOffset>(nullable: false),
                    PropDateTimeOffsetNullable = table.Column<DateTimeOffset>(nullable: true),
                    PropDecimal = table.Column<decimal>(nullable: false),
                    PropDecimalNullable = table.Column<decimal>(nullable: true),
                    PropInt32 = table.Column<int>(nullable: false),
                    PropInt32Nullable = table.Column<int>(nullable: true),
                    PropInt64 = table.Column<long>(nullable: false),
                    PropInt64Nullable = table.Column<long>(nullable: true),
                    PropString = table.Column<string>(nullable: false),
                    PropStringNullable = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DummyMain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DummyMain_DummyOneToMany",
                        column: x => x.DummyOneToManyId,
                        principalSchema: "dbo",
                        principalTable: "DummyOneToMany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DummyTreeLink",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    ParentId = table.Column<long>(nullable: false),
                    Level = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DummyTreeLink", x => new { x.Id, x.ParentId });
                    table.ForeignKey(
                        name: "FK_DummyTreeLink_DummyMain_Id",
                        column: x => x.Id,
                        principalSchema: "dbo",
                        principalTable: "DummyTree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DummyMainDummyManyToMany",
                schema: "dbo",
                columns: table => new
                {
                    DummyMainId = table.Column<long>(nullable: false),
                    DummyManyToManyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DummyMainDummyManyToMany", x => new { x.DummyMainId, x.DummyManyToManyId });
                    table.ForeignKey(
                        name: "FK_DummyMainDummyManyToMany_DummyMain",
                        column: x => x.DummyMainId,
                        principalSchema: "dbo",
                        principalTable: "DummyMain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DummyMainDummyManyToMany_DummyManyToMany",
                        column: x => x.DummyManyToManyId,
                        principalSchema: "dbo",
                        principalTable: "DummyManyToMany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DummyManyToMany",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Name-1" },
                    { 2L, "Name-2" },
                    { 3L, "Name-3" },
                    { 4L, "Name-4" },
                    { 5L, "Name-5" },
                    { 6L, "Name-6" },
                    { 7L, "Name-7" },
                    { 8L, "Name-8" },
                    { 9L, "Name-9" },
                    { 10L, "Name-10" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DummyOneToMany",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10L, "Name-10" },
                    { 9L, "Name-9" },
                    { 8L, "Name-8" },
                    { 7L, "Name-7" },
                    { 6L, "Name-6" },
                    { 2L, "Name-2" },
                    { 4L, "Name-4" },
                    { 3L, "Name-3" },
                    { 1L, "Name-1" },
                    { 5L, "Name-5" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DummyTree",
                columns: new[] { "Id", "ChildCount", "DescendantCount", "Name", "ParentId" },
                values: new object[,]
                {
                    { 11L, 3L, 12L, "Name-11", null },
                    { 1L, 3L, 12L, "Name-1", null },
                    { 21L, 3L, 12L, "Name-21", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DummyMain",
                columns: new[] { "Id", "Name", "DummyOneToManyId", "PropBoolean", "PropBooleanNullable", "PropDate", "PropDateNullable", "PropDateTimeOffset", "PropDateTimeOffsetNullable", "PropDecimal", "PropDecimalNullable", "PropInt32", "PropInt32Nullable", "PropInt64", "PropInt64Nullable", "PropString", "PropStringNullable" },
                values: new object[,]
                {
                    { 2L, "Name-2", 1L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1002.02m, 2002.01m, 1002, 1002, 3002L, 3002L, "PropString-2", "PropStringNullable-2" },
                    { 35L, "Name-35", 7L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1035.35m, null, 1035, null, 3035L, null, "PropString-35", null },
                    { 33L, "Name-33", 7L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1033.33m, null, 1033, null, 3033L, null, "PropString-33", null },
                    { 16L, "Name-16", 7L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1016.16m, 2016.08m, 1016, 1016, 3016L, 3016L, "PropString-16", "PropStringNullable-16" },
                    { 11L, "Name-11", 7L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1011.11m, null, 1011, null, 3011L, null, "PropString-11", null },
                    { 9L, "Name-9", 7L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1009.09m, null, 1009, null, 3009L, null, "PropString-9", null },
                    { 4L, "Name-4", 7L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1004.04m, 2004.02m, 1004, 1004, 3004L, 3004L, "PropString-4", "PropStringNullable-4" },
                    { 1L, "Name-1", 7L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1001.01m, null, 1001, null, 3001L, null, "PropString-1", null },
                    { 93L, "Name-93", 6L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1093.93m, null, 1093, null, 3093L, null, "PropString-93", null },
                    { 89L, "Name-89", 6L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1089.89m, null, 1089, null, 3089L, null, "PropString-89", null },
                    { 85L, "Name-85", 6L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1085.85m, null, 1085, null, 3085L, null, "PropString-85", null },
                    { 62L, "Name-62", 6L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1062.62m, 2062.31m, 1062, 1062, 3062L, 3062L, "PropString-62", "PropStringNullable-62" },
                    { 48L, "Name-48", 6L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1048.48m, 2048.24m, 1048, 1048, 3048L, 3048L, "PropString-48", "PropStringNullable-48" },
                    { 41L, "Name-41", 6L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1041.41m, null, 1041, null, 3041L, null, "PropString-41", null },
                    { 23L, "Name-23", 6L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1023.23m, null, 1023, null, 3023L, null, "PropString-23", null },
                    { 18L, "Name-18", 6L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1018.18m, 2018.09m, 1018, 1018, 3018L, 3018L, "PropString-18", "PropStringNullable-18" },
                    { 13L, "Name-13", 6L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1013.13m, null, 1013, null, 3013L, null, "PropString-13", null },
                    { 98L, "Name-98", 5L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1098.98m, 2098.49m, 1098, 1098, 3098L, 3098L, "PropString-98", "PropStringNullable-98" },
                    { 94L, "Name-94", 5L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1094.94m, 2094.47m, 1094, 1094, 3094L, 3094L, "PropString-94", "PropStringNullable-94" },
                    { 68L, "Name-68", 5L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1068.68m, 2068.34m, 1068, 1068, 3068L, 3068L, "PropString-68", "PropStringNullable-68" },
                    { 59L, "Name-59", 5L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1059.59m, null, 1059, null, 3059L, null, "PropString-59", null },
                    { 50L, "Name-50", 5L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1050.5m, 2050.25m, 1050, 1050, 3050L, 3050L, "PropString-50", "PropStringNullable-50" },
                    { 39L, "Name-39", 7L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1039.39m, null, 1039, null, 3039L, null, "PropString-39", null },
                    { 55L, "Name-55", 7L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1055.55m, null, 1055, null, 3055L, null, "PropString-55", null },
                    { 73L, "Name-73", 7L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1073.73m, null, 1073, null, 3073L, null, "PropString-73", null },
                    { 75L, "Name-75", 7L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1075.75m, null, 1075, null, 3075L, null, "PropString-75", null },
                    { 90L, "Name-90", 9L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1090.9m, 2090.45m, 1090, 1090, 3090L, 3090L, "PropString-90", "PropStringNullable-90" },
                    { 86L, "Name-86", 9L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1086.86m, 2086.43m, 1086, 1086, 3086L, 3086L, "PropString-86", "PropStringNullable-86" },
                    { 76L, "Name-76", 9L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1076.76m, 2076.38m, 1076, 1076, 3076L, 3076L, "PropString-76", "PropStringNullable-76" },
                    { 67L, "Name-67", 9L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1067.67m, null, 1067, null, 3067L, null, "PropString-67", null },
                    { 49L, "Name-49", 9L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1049.49m, null, 1049, null, 3049L, null, "PropString-49", null },
                    { 45L, "Name-45", 9L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1045.45m, null, 1045, null, 3045L, null, "PropString-45", null },
                    { 44L, "Name-44", 9L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1044.44m, 2044.22m, 1044, 1044, 3044L, 3044L, "PropString-44", "PropStringNullable-44" },
                    { 38L, "Name-38", 9L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1038.38m, 2038.19m, 1038, 1038, 3038L, 3038L, "PropString-38", "PropStringNullable-38" },
                    { 36L, "Name-36", 9L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1036.36m, 2036.18m, 1036, 1036, 3036L, 3036L, "PropString-36", "PropStringNullable-36" },
                    { 12L, "Name-12", 9L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1012.12m, 2012.06m, 1012, 1012, 3012L, 3012L, "PropString-12", "PropStringNullable-12" },
                    { 22L, "Name-22", 5L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1022.22m, 2022.11m, 1022, 1022, 3022L, 3022L, "PropString-22", "PropStringNullable-22" },
                    { 78L, "Name-78", 8L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1078.78m, 2078.39m, 1078, 1078, 3078L, 3078L, "PropString-78", "PropStringNullable-78" },
                    { 69L, "Name-69", 8L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1069.69m, null, 1069, null, 3069L, null, "PropString-69", null },
                    { 27L, "Name-27", 8L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1027.27m, null, 1027, null, 3027L, null, "PropString-27", null },
                    { 24L, "Name-24", 8L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1024.24m, 2024.12m, 1024, 1024, 3024L, 3024L, "PropString-24", "PropStringNullable-24" },
                    { 21L, "Name-21", 8L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1021.21m, null, 1021, null, 3021L, null, "PropString-21", null },
                    { 17L, "Name-17", 8L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1017.17m, null, 1017, null, 3017L, null, "PropString-17", null },
                    { 10L, "Name-10", 8L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1010.1m, 2010.05m, 1010, 1010, 3010L, 3010L, "PropString-10", "PropStringNullable-10" },
                    { 7L, "Name-7", 8L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1007.07m, null, 1007, null, 3007L, null, "PropString-7", null },
                    { 5L, "Name-5", 8L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1005.05m, null, 1005, null, 3005L, null, "PropString-5", null },
                    { 99L, "Name-99", 7L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1099.99m, null, 1099, null, 3099L, null, "PropString-99", null },
                    { 88L, "Name-88", 7L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1088.88m, 2088.44m, 1088, 1088, 3088L, 3088L, "PropString-88", "PropStringNullable-88" },
                    { 70L, "Name-70", 8L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1070.7m, 2070.35m, 1070, 1070, 3070L, 3070L, "PropString-70", "PropStringNullable-70" },
                    { 14L, "Name-14", 5L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1014.14m, 2014.07m, 1014, 1014, 3014L, 3014L, "PropString-14", "PropStringNullable-14" },
                    { 92L, "Name-92", 5L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1092.92m, 2092.46m, 1092, 1092, 3092L, 3092L, "PropString-92", "PropStringNullable-92" },
                    { 97L, "Name-97", 4L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1097.97m, null, 1097, null, 3097L, null, "PropString-97", null },
                    { 80L, "Name-80", 2L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1080.8m, 2080.4m, 1080, 1080, 3080L, 3080L, "PropString-80", "PropStringNullable-80" },
                    { 77L, "Name-77", 2L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1077.77m, null, 1077, null, 3077L, null, "PropString-77", null },
                    { 65L, "Name-65", 2L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1065.65m, null, 1065, null, 3065L, null, "PropString-65", null },
                    { 6L, "Name-6", 5L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1006.06m, 2006.03m, 1006, 1006, 3006L, 3006L, "PropString-6", "PropStringNullable-6" },
                    { 63L, "Name-63", 2L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1063.63m, null, 1063, null, 3063L, null, "PropString-63", null },
                    { 61L, "Name-61", 2L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1061.61m, null, 1061, null, 3061L, null, "PropString-61", null },
                    { 60L, "Name-60", 2L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1060.6m, 2060.3m, 1060, 1060, 3060L, 3060L, "PropString-60", "PropStringNullable-60" },
                    { 57L, "Name-57", 2L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1057.57m, null, 1057, null, 3057L, null, "PropString-57", null },
                    { 53L, "Name-53", 2L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1053.53m, null, 1053, null, 3053L, null, "PropString-53", null },
                    { 40L, "Name-40", 2L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1040.4m, 2040.2m, 1040, 1040, 3040L, 3040L, "PropString-40", "PropStringNullable-40" },
                    { 84L, "Name-84", 2L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1084.84m, 2084.42m, 1084, 1084, 3084L, 3084L, "PropString-84", "PropStringNullable-84" },
                    { 29L, "Name-29", 2L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1029.29m, null, 1029, null, 3029L, null, "PropString-29", null },
                    { 83L, "Name-83", 1L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1083.83m, null, 1083, null, 3083L, null, "PropString-83", null },
                    { 79L, "Name-79", 1L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1079.79m, null, 1079, null, 3079L, null, "PropString-79", null },
                    { 71L, "Name-71", 1L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1071.71m, null, 1071, null, 3071L, null, "PropString-71", null },
                    { 56L, "Name-56", 1L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1056.56m, 2056.28m, 1056, 1056, 3056L, 3056L, "PropString-56", "PropStringNullable-56" },
                    { 42L, "Name-42", 1L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1042.42m, 2042.21m, 1042, 1042, 3042L, 3042L, "PropString-42", "PropStringNullable-42" },
                    { 34L, "Name-34", 1L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1034.34m, 2034.17m, 1034, 1034, 3034L, 3034L, "PropString-34", "PropStringNullable-34" },
                    { 31L, "Name-31", 1L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1031.31m, null, 1031, null, 3031L, null, "PropString-31", null },
                    { 28L, "Name-28", 1L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1028.28m, 2028.14m, 1028, 1028, 3028L, 3028L, "PropString-28", "PropStringNullable-28" },
                    { 19L, "Name-19", 1L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1019.19m, null, 1019, null, 3019L, null, "PropString-19", null },
                    { 15L, "Name-15", 1L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1015.15m, null, 1015, null, 3015L, null, "PropString-15", null },
                    { 8L, "Name-8", 2L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1008.08m, 2008.04m, 1008, 1008, 3008L, 3008L, "PropString-8", "PropStringNullable-8" },
                    { 100L, "Name-100", 2L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1101m, 2100.5m, 1100, 1100, 3100L, 3100L, "PropString-100", "PropStringNullable-100" },
                    { 64L, "Name-64", 2L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1064.64m, 2064.32m, 1064, 1064, 3064L, 3064L, "PropString-64", "PropStringNullable-64" },
                    { 26L, "Name-26", 3L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1026.26m, 2026.13m, 1026, 1026, 3026L, 3026L, "PropString-26", "PropStringNullable-26" },
                    { 96L, "Name-96", 4L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1096.96m, 2096.48m, 1096, 1096, 3096L, 3096L, "PropString-96", "PropStringNullable-96" },
                    { 95L, "Name-95", 4L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1095.95m, null, 1095, null, 3095L, null, "PropString-95", null },
                    { 87L, "Name-87", 4L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1087.87m, null, 1087, null, 3087L, null, "PropString-87", null },
                    { 82L, "Name-82", 4L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1082.82m, 2082.41m, 1082, 1082, 3082L, 3082L, "PropString-82", "PropStringNullable-82" },
                    { 25L, "Name-25", 3L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1025.25m, null, 1025, null, 3025L, null, "PropString-25", null },
                    { 66L, "Name-66", 4L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1066.66m, 2066.33m, 1066, 1066, 3066L, 3066L, "PropString-66", "PropStringNullable-66" },
                    { 58L, "Name-58", 4L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1058.58m, 2058.29m, 1058, 1058, 3058L, 3058L, "PropString-58", "PropStringNullable-58" },
                    { 52L, "Name-52", 4L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1052.52m, 2052.26m, 1052, 1052, 3052L, 3052L, "PropString-52", "PropStringNullable-52" },
                    { 46L, "Name-46", 4L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1046.46m, 2046.23m, 1046, 1046, 3046L, 3046L, "PropString-46", "PropStringNullable-46" },
                    { 43L, "Name-43", 4L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1043.43m, null, 1043, null, 3043L, null, "PropString-43", null },
                    { 81L, "Name-81", 4L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1081.81m, null, 1081, null, 3081L, null, "PropString-81", null },
                    { 3L, "Name-3", 4L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1003.03m, null, 1003, null, 3003L, null, "PropString-3", null },
                    { 91L, "Name-91", 3L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1091.91m, null, 1091, null, 3091L, null, "PropString-91", null },
                    { 74L, "Name-74", 3L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1074.74m, 2074.37m, 1074, 1074, 3074L, 3074L, "PropString-74", "PropStringNullable-74" },
                    { 72L, "Name-72", 3L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1072.72m, 2072.36m, 1072, 1072, 3072L, 3072L, "PropString-72", "PropStringNullable-72" },
                    { 54L, "Name-54", 3L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1054.54m, 2054.27m, 1054, 1054, 3054L, 3054L, "PropString-54", "PropStringNullable-54" },
                    { 51L, "Name-51", 3L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1051.51m, null, 1051, null, 3051L, null, "PropString-51", null },
                    { 47L, "Name-47", 3L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1047.47m, null, 1047, null, 3047L, null, "PropString-47", null },
                    { 37L, "Name-37", 3L, false, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2018, 3, 1, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, 1037.37m, null, 1037, null, 3037L, null, "PropString-37", null },
                    { 32L, "Name-32", 3L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1032.32m, 2032.16m, 1032, 1032, 3032L, 3032L, "PropString-32", "PropStringNullable-32" },
                    { 30L, "Name-30", 3L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1030.3m, 2030.15m, 1030, 1030, 3030L, 3030L, "PropString-30", "PropStringNullable-30" },
                    { 20L, "Name-20", 4L, true, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2018, 3, 2, 6, 32, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1020.2m, 2020.1m, 1020, 1020, 3020L, 3020L, "PropString-20", "PropStringNullable-20" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DummyTree",
                columns: new[] { "Id", "ChildCount", "DescendantCount", "Name", "ParentId" },
                values: new object[,]
                {
                    { 23L, 3L, 3L, "Name-21-23", 21L },
                    { 22L, 3L, 3L, "Name-21-22", 21L },
                    { 14L, 3L, 3L, "Name-11-14", 11L },
                    { 13L, 3L, 3L, "Name-11-13", 11L },
                    { 2L, 3L, 3L, "Name-1-2", 1L },
                    { 4L, 3L, 3L, "Name-1-4", 1L },
                    { 3L, 3L, 3L, "Name-1-3", 1L },
                    { 24L, 3L, 3L, "Name-21-24", 21L },
                    { 12L, 3L, 3L, "Name-11-12", 11L }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DummyTreeLink",
                columns: new[] { "Id", "ParentId", "Level" },
                values: new object[,]
                {
                    { 1L, 0L, 0L },
                    { 11L, 0L, 0L },
                    { 21L, 0L, 0L }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DummyMainDummyManyToMany",
                columns: new[] { "DummyMainId", "DummyManyToManyId" },
                values: new object[,]
                {
                    { 2L, 3L },
                    { 11L, 5L },
                    { 11L, 4L },
                    { 11L, 2L },
                    { 9L, 10L },
                    { 9L, 9L },
                    { 9L, 8L },
                    { 9L, 7L },
                    { 9L, 4L },
                    { 9L, 3L },
                    { 9L, 2L },
                    { 9L, 1L },
                    { 4L, 10L },
                    { 4L, 9L },
                    { 4L, 8L },
                    { 4L, 7L },
                    { 4L, 3L },
                    { 1L, 10L },
                    { 1L, 7L },
                    { 1L, 6L },
                    { 1L, 5L },
                    { 1L, 2L },
                    { 93L, 10L },
                    { 93L, 6L },
                    { 93L, 5L },
                    { 93L, 3L },
                    { 93L, 2L },
                    { 89L, 9L },
                    { 89L, 7L },
                    { 89L, 6L },
                    { 11L, 6L },
                    { 11L, 7L },
                    { 11L, 10L },
                    { 16L, 2L },
                    { 55L, 8L },
                    { 55L, 7L },
                    { 55L, 5L },
                    { 55L, 4L },
                    { 55L, 3L },
                    { 55L, 2L },
                    { 55L, 1L },
                    { 39L, 8L },
                    { 39L, 7L },
                    { 39L, 6L },
                    { 39L, 2L },
                    { 39L, 1L },
                    { 35L, 7L },
                    { 35L, 6L },
                    { 89L, 4L },
                    { 35L, 4L },
                    { 35L, 2L },
                    { 35L, 1L },
                    { 33L, 10L },
                    { 33L, 9L },
                    { 33L, 7L },
                    { 33L, 4L },
                    { 33L, 1L },
                    { 16L, 10L },
                    { 16L, 9L },
                    { 16L, 8L },
                    { 16L, 7L },
                    { 16L, 6L },
                    { 16L, 5L },
                    { 16L, 4L },
                    { 35L, 3L },
                    { 89L, 2L },
                    { 89L, 1L },
                    { 85L, 9L },
                    { 98L, 10L },
                    { 98L, 6L },
                    { 98L, 1L },
                    { 94L, 8L },
                    { 94L, 7L },
                    { 94L, 6L },
                    { 94L, 4L },
                    { 94L, 3L },
                    { 92L, 9L },
                    { 92L, 8L },
                    { 92L, 6L },
                    { 92L, 3L },
                    { 92L, 2L },
                    { 68L, 9L },
                    { 13L, 1L },
                    { 68L, 7L },
                    { 68L, 5L },
                    { 68L, 4L },
                    { 68L, 2L },
                    { 68L, 1L },
                    { 59L, 9L },
                    { 59L, 8L },
                    { 59L, 7L },
                    { 59L, 6L },
                    { 59L, 5L },
                    { 59L, 3L },
                    { 50L, 8L },
                    { 50L, 5L },
                    { 50L, 4L },
                    { 50L, 3L },
                    { 68L, 6L },
                    { 55L, 9L },
                    { 13L, 2L },
                    { 13L, 5L },
                    { 85L, 8L },
                    { 85L, 4L },
                    { 85L, 3L },
                    { 85L, 2L },
                    { 62L, 9L },
                    { 62L, 8L },
                    { 62L, 3L },
                    { 62L, 2L },
                    { 48L, 10L },
                    { 48L, 8L },
                    { 48L, 7L },
                    { 48L, 4L },
                    { 48L, 3L },
                    { 48L, 2L },
                    { 13L, 4L },
                    { 41L, 10L },
                    { 41L, 8L },
                    { 41L, 6L },
                    { 41L, 3L },
                    { 23L, 10L },
                    { 23L, 7L },
                    { 23L, 3L },
                    { 23L, 2L },
                    { 18L, 10L },
                    { 18L, 9L },
                    { 18L, 8L },
                    { 18L, 5L },
                    { 13L, 10L },
                    { 13L, 7L },
                    { 13L, 6L },
                    { 41L, 9L },
                    { 55L, 10L },
                    { 73L, 1L },
                    { 73L, 4L },
                    { 44L, 10L },
                    { 44L, 9L },
                    { 44L, 8L },
                    { 44L, 7L },
                    { 44L, 6L },
                    { 44L, 4L },
                    { 44L, 3L },
                    { 44L, 2L },
                    { 44L, 1L },
                    { 38L, 6L },
                    { 38L, 4L },
                    { 36L, 10L },
                    { 36L, 9L },
                    { 36L, 8L },
                    { 45L, 2L },
                    { 36L, 5L },
                    { 36L, 3L },
                    { 36L, 2L },
                    { 12L, 9L },
                    { 12L, 8L },
                    { 12L, 7L },
                    { 12L, 6L },
                    { 12L, 5L },
                    { 12L, 4L },
                    { 12L, 2L },
                    { 78L, 8L },
                    { 78L, 6L },
                    { 78L, 5L },
                    { 78L, 4L },
                    { 70L, 9L },
                    { 36L, 4L },
                    { 70L, 8L },
                    { 45L, 3L },
                    { 45L, 6L },
                    { 90L, 9L },
                    { 90L, 8L },
                    { 90L, 6L },
                    { 90L, 5L },
                    { 90L, 1L },
                    { 86L, 10L },
                    { 86L, 8L },
                    { 86L, 7L },
                    { 86L, 6L },
                    { 86L, 3L },
                    { 76L, 10L },
                    { 76L, 6L },
                    { 76L, 5L },
                    { 76L, 4L },
                    { 45L, 4L },
                    { 76L, 3L },
                    { 76L, 1L },
                    { 67L, 10L },
                    { 67L, 9L },
                    { 67L, 5L },
                    { 67L, 4L },
                    { 67L, 2L },
                    { 67L, 1L },
                    { 49L, 8L },
                    { 49L, 5L },
                    { 49L, 4L },
                    { 49L, 3L },
                    { 49L, 2L },
                    { 45L, 10L },
                    { 45L, 9L },
                    { 76L, 2L },
                    { 22L, 7L },
                    { 70L, 7L },
                    { 70L, 3L },
                    { 5L, 7L },
                    { 5L, 5L },
                    { 5L, 4L },
                    { 5L, 3L },
                    { 5L, 2L },
                    { 5L, 1L },
                    { 99L, 8L },
                    { 99L, 7L },
                    { 99L, 6L },
                    { 99L, 5L },
                    { 99L, 4L },
                    { 99L, 3L },
                    { 88L, 10L },
                    { 88L, 8L },
                    { 5L, 9L },
                    { 88L, 6L },
                    { 88L, 4L },
                    { 88L, 3L },
                    { 88L, 1L },
                    { 75L, 10L },
                    { 75L, 9L },
                    { 75L, 7L },
                    { 75L, 6L },
                    { 75L, 5L },
                    { 75L, 2L },
                    { 75L, 1L },
                    { 73L, 10L },
                    { 73L, 9L },
                    { 73L, 7L },
                    { 73L, 5L },
                    { 88L, 5L },
                    { 70L, 4L },
                    { 7L, 4L },
                    { 7L, 8L },
                    { 70L, 2L },
                    { 70L, 1L },
                    { 69L, 9L },
                    { 69L, 8L },
                    { 69L, 5L },
                    { 69L, 4L },
                    { 69L, 3L },
                    { 27L, 9L },
                    { 27L, 7L },
                    { 27L, 6L },
                    { 27L, 4L },
                    { 27L, 1L },
                    { 24L, 10L },
                    { 24L, 6L },
                    { 7L, 7L },
                    { 24L, 5L },
                    { 21L, 8L },
                    { 21L, 6L },
                    { 21L, 5L },
                    { 21L, 4L },
                    { 17L, 9L },
                    { 17L, 8L },
                    { 17L, 6L },
                    { 17L, 4L },
                    { 10L, 10L },
                    { 10L, 7L },
                    { 10L, 6L },
                    { 10L, 4L },
                    { 7L, 10L },
                    { 7L, 9L },
                    { 24L, 3L },
                    { 22L, 5L },
                    { 92L, 5L },
                    { 22L, 2L },
                    { 63L, 4L },
                    { 63L, 3L },
                    { 63L, 1L },
                    { 61L, 9L },
                    { 61L, 5L },
                    { 61L, 4L },
                    { 61L, 1L },
                    { 60L, 10L },
                    { 60L, 9L },
                    { 60L, 7L },
                    { 60L, 5L },
                    { 60L, 2L },
                    { 60L, 1L },
                    { 57L, 7L },
                    { 63L, 5L },
                    { 57L, 6L },
                    { 57L, 3L },
                    { 53L, 9L },
                    { 53L, 8L },
                    { 53L, 6L },
                    { 53L, 4L },
                    { 53L, 3L },
                    { 53L, 2L },
                    { 40L, 8L },
                    { 40L, 5L },
                    { 40L, 4L },
                    { 29L, 8L },
                    { 29L, 4L },
                    { 29L, 3L },
                    { 29L, 2L },
                    { 57L, 4L },
                    { 29L, 1L },
                    { 63L, 7L },
                    { 64L, 9L },
                    { 25L, 5L },
                    { 25L, 4L },
                    { 25L, 3L },
                    { 25L, 2L },
                    { 25L, 1L },
                    { 100L, 9L },
                    { 100L, 8L },
                    { 100L, 4L },
                    { 100L, 3L },
                    { 84L, 10L },
                    { 84L, 9L },
                    { 84L, 8L },
                    { 84L, 7L },
                    { 84L, 6L },
                    { 64L, 2L },
                    { 84L, 5L },
                    { 80L, 10L },
                    { 80L, 7L },
                    { 80L, 6L },
                    { 22L, 4L },
                    { 77L, 10L },
                    { 77L, 7L },
                    { 77L, 6L },
                    { 77L, 4L },
                    { 77L, 2L },
                    { 65L, 10L },
                    { 65L, 9L },
                    { 65L, 8L },
                    { 65L, 6L },
                    { 65L, 2L },
                    { 84L, 4L },
                    { 25L, 8L },
                    { 8L, 10L },
                    { 8L, 7L },
                    { 34L, 7L },
                    { 34L, 6L },
                    { 34L, 5L },
                    { 34L, 3L },
                    { 34L, 2L },
                    { 34L, 1L },
                    { 31L, 10L },
                    { 31L, 9L },
                    { 31L, 7L },
                    { 31L, 5L },
                    { 31L, 2L },
                    { 31L, 1L },
                    { 28L, 9L },
                    { 28L, 7L },
                    { 34L, 8L },
                    { 28L, 5L },
                    { 28L, 2L },
                    { 28L, 1L },
                    { 19L, 6L },
                    { 19L, 5L },
                    { 19L, 4L },
                    { 19L, 2L },
                    { 15L, 10L },
                    { 15L, 9L },
                    { 15L, 7L },
                    { 15L, 6L },
                    { 15L, 5L },
                    { 2L, 10L },
                    { 2L, 7L },
                    { 2L, 4L },
                    { 28L, 4L },
                    { 8L, 9L },
                    { 42L, 1L },
                    { 42L, 3L },
                    { 8L, 4L },
                    { 83L, 9L },
                    { 83L, 8L },
                    { 83L, 4L },
                    { 83L, 3L },
                    { 83L, 2L },
                    { 83L, 1L },
                    { 79L, 10L },
                    { 79L, 7L },
                    { 79L, 6L },
                    { 79L, 4L },
                    { 71L, 10L },
                    { 71L, 7L },
                    { 71L, 6L },
                    { 42L, 2L },
                    { 71L, 5L },
                    { 71L, 2L },
                    { 71L, 1L },
                    { 56L, 10L },
                    { 56L, 9L },
                    { 56L, 8L },
                    { 56L, 6L },
                    { 56L, 5L },
                    { 56L, 4L },
                    { 56L, 3L },
                    { 42L, 10L },
                    { 42L, 9L },
                    { 42L, 8L },
                    { 42L, 6L },
                    { 42L, 4L },
                    { 71L, 3L },
                    { 25L, 9L },
                    { 80L, 1L },
                    { 26L, 3L },
                    { 82L, 7L },
                    { 82L, 6L },
                    { 82L, 5L },
                    { 81L, 10L },
                    { 81L, 9L },
                    { 81L, 8L },
                    { 81L, 6L },
                    { 81L, 5L },
                    { 81L, 3L },
                    { 26L, 1L },
                    { 81L, 1L },
                    { 66L, 10L },
                    { 66L, 8L },
                    { 66L, 7L },
                    { 82L, 8L },
                    { 66L, 6L },
                    { 66L, 3L },
                    { 66L, 1L },
                    { 58L, 10L },
                    { 58L, 9L },
                    { 58L, 8L },
                    { 58L, 7L },
                    { 52L, 9L },
                    { 52L, 7L },
                    { 52L, 6L },
                    { 52L, 5L },
                    { 52L, 3L },
                    { 52L, 1L },
                    { 46L, 9L },
                    { 46L, 8L },
                    { 66L, 4L },
                    { 46L, 6L },
                    { 82L, 9L },
                    { 87L, 4L },
                    { 14L, 10L },
                    { 14L, 9L },
                    { 14L, 8L },
                    { 14L, 5L },
                    { 14L, 3L },
                    { 14L, 2L },
                    { 14L, 1L },
                    { 6L, 10L },
                    { 6L, 6L },
                    { 6L, 5L },
                    { 6L, 2L },
                    { 6L, 1L },
                    { 97L, 9L },
                    { 97L, 8L },
                    { 82L, 10L },
                    { 97L, 2L },
                    { 96L, 8L },
                    { 96L, 6L },
                    { 96L, 5L },
                    { 96L, 4L },
                    { 96L, 3L },
                    { 96L, 2L },
                    { 96L, 1L },
                    { 95L, 10L },
                    { 95L, 9L },
                    { 95L, 8L },
                    { 95L, 6L },
                    { 95L, 3L },
                    { 87L, 7L },
                    { 87L, 5L },
                    { 96L, 10L },
                    { 46L, 5L },
                    { 81L, 2L },
                    { 46L, 3L },
                    { 54L, 1L },
                    { 51L, 9L },
                    { 51L, 8L },
                    { 51L, 7L },
                    { 51L, 4L },
                    { 51L, 3L },
                    { 51L, 2L },
                    { 47L, 10L },
                    { 47L, 9L },
                    { 47L, 3L },
                    { 47L, 2L },
                    { 37L, 10L },
                    { 37L, 7L },
                    { 37L, 5L },
                    { 54L, 3L },
                    { 37L, 4L },
                    { 32L, 10L },
                    { 32L, 9L },
                    { 32L, 8L },
                    { 46L, 4L },
                    { 30L, 10L },
                    { 30L, 8L },
                    { 30L, 7L },
                    { 30L, 6L },
                    { 30L, 5L },
                    { 30L, 4L },
                    { 30L, 1L },
                    { 26L, 10L },
                    { 26L, 8L },
                    { 26L, 5L },
                    { 37L, 2L },
                    { 54L, 4L },
                    { 32L, 4L },
                    { 54L, 7L },
                    { 54L, 6L },
                    { 43L, 7L },
                    { 20L, 6L },
                    { 20L, 4L },
                    { 20L, 3L },
                    { 20L, 1L },
                    { 3L, 10L },
                    { 3L, 8L },
                    { 3L, 5L },
                    { 3L, 3L },
                    { 91L, 6L },
                    { 91L, 5L },
                    { 91L, 3L },
                    { 91L, 1L },
                    { 74L, 10L },
                    { 3L, 4L },
                    { 74L, 5L },
                    { 74L, 8L },
                    { 72L, 1L },
                    { 72L, 2L },
                    { 72L, 3L },
                    { 72L, 5L },
                    { 72L, 7L },
                    { 72L, 8L },
                    { 72L, 6L },
                    { 74L, 1L },
                    { 74L, 2L },
                    { 74L, 3L },
                    { 74L, 4L },
                    { 72L, 9L },
                    { 54L, 9L }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DummyTree",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 39L, "Name-11-13-39", 13L },
                    { 26L, "Name-21-22-26", 22L },
                    { 19L, "Name-11-13-19", 13L },
                    { 20L, "Name-11-14-20", 14L },
                    { 33L, "Name-11-14-33", 14L },
                    { 34L, "Name-11-14-34", 14L },
                    { 25L, "Name-21-22-25", 22L },
                    { 36L, "Name-21-24-36", 24L },
                    { 28L, "Name-21-23-28", 23L },
                    { 29L, "Name-21-23-29", 23L },
                    { 40L, "Name-21-23-40", 23L },
                    { 35L, "Name-21-24-35", 24L },
                    { 18L, "Name-11-13-18", 13L },
                    { 37L, "Name-21-24-37", 24L },
                    { 27L, "Name-21-22-27", 22L },
                    { 17L, "Name-11-12-17", 12L },
                    { 9L, "Name-1-3-9", 3L },
                    { 15L, "Name-11-12-15", 12L },
                    { 5L, "Name-1-2-5", 2L },
                    { 6L, "Name-1-2-6", 2L },
                    { 32L, "Name-1-4-32", 4L },
                    { 7L, "Name-1-2-7", 2L },
                    { 31L, "Name-1-4-31", 4L },
                    { 10L, "Name-1-4-10", 4L },
                    { 16L, "Name-11-12-16", 12L },
                    { 38L, "Name-1-3-38", 3L },
                    { 8L, "Name-1-3-8", 3L }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DummyTreeLink",
                columns: new[] { "Id", "ParentId", "Level" },
                values: new object[,]
                {
                    { 24L, 0L, 0L },
                    { 23L, 21L, 1L },
                    { 23L, 0L, 0L },
                    { 2L, 0L, 0L },
                    { 2L, 1L, 1L },
                    { 22L, 21L, 1L },
                    { 3L, 0L, 0L },
                    { 14L, 11L, 1L },
                    { 14L, 0L, 0L },
                    { 3L, 1L, 1L },
                    { 13L, 11L, 1L },
                    { 13L, 0L, 0L },
                    { 4L, 0L, 0L },
                    { 4L, 1L, 1L },
                    { 12L, 11L, 1L },
                    { 12L, 0L, 0L },
                    { 22L, 0L, 0L },
                    { 24L, 21L, 1L }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DummyTreeLink",
                columns: new[] { "Id", "ParentId", "Level" },
                values: new object[,]
                {
                    { 5L, 0L, 0L },
                    { 26L, 0L, 0L },
                    { 25L, 22L, 2L },
                    { 25L, 21L, 1L },
                    { 25L, 0L, 0L },
                    { 34L, 14L, 2L },
                    { 34L, 11L, 1L },
                    { 34L, 0L, 0L },
                    { 26L, 21L, 1L },
                    { 33L, 14L, 2L },
                    { 33L, 0L, 0L },
                    { 20L, 14L, 2L },
                    { 20L, 11L, 1L },
                    { 20L, 0L, 0L },
                    { 39L, 13L, 2L },
                    { 39L, 11L, 1L },
                    { 39L, 0L, 0L },
                    { 33L, 11L, 1L },
                    { 26L, 22L, 2L },
                    { 27L, 0L, 0L },
                    { 27L, 21L, 1L },
                    { 37L, 0L, 0L },
                    { 36L, 24L, 2L },
                    { 36L, 21L, 1L },
                    { 36L, 0L, 0L },
                    { 35L, 24L, 2L },
                    { 35L, 21L, 1L },
                    { 35L, 0L, 0L },
                    { 40L, 23L, 2L },
                    { 40L, 21L, 1L },
                    { 40L, 0L, 0L },
                    { 29L, 23L, 2L },
                    { 29L, 21L, 1L },
                    { 29L, 0L, 0L },
                    { 28L, 23L, 2L },
                    { 28L, 21L, 1L },
                    { 28L, 0L, 0L },
                    { 27L, 22L, 2L },
                    { 19L, 13L, 2L },
                    { 37L, 21L, 1L },
                    { 19L, 11L, 1L },
                    { 18L, 13L, 2L },
                    { 38L, 1L, 1L },
                    { 38L, 0L, 0L },
                    { 9L, 3L, 2L },
                    { 9L, 1L, 1L },
                    { 9L, 0L, 0L },
                    { 8L, 3L, 2L },
                    { 8L, 1L, 1L },
                    { 38L, 3L, 2L },
                    { 8L, 0L, 0L },
                    { 7L, 1L, 1L },
                    { 7L, 0L, 0L },
                    { 6L, 2L, 2L },
                    { 6L, 1L, 1L },
                    { 6L, 0L, 0L },
                    { 5L, 2L, 2L },
                    { 5L, 1L, 1L },
                    { 7L, 2L, 2L },
                    { 10L, 0L, 0L },
                    { 10L, 1L, 1L },
                    { 10L, 4L, 2L },
                    { 18L, 11L, 1L },
                    { 18L, 0L, 0L },
                    { 17L, 12L, 2L },
                    { 17L, 11L, 1L },
                    { 17L, 0L, 0L },
                    { 16L, 12L, 2L },
                    { 16L, 11L, 1L },
                    { 16L, 0L, 0L },
                    { 15L, 12L, 2L },
                    { 15L, 11L, 1L },
                    { 15L, 0L, 0L },
                    { 32L, 4L, 2L },
                    { 32L, 1L, 1L },
                    { 32L, 0L, 0L },
                    { 31L, 4L, 2L },
                    { 31L, 1L, 1L },
                    { 31L, 0L, 0L },
                    { 19L, 0L, 0L },
                    { 37L, 24L, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "UX_DummyMain_Name",
                schema: "dbo",
                table: "DummyMain",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DummyMain_DummyOneToManyId",
                schema: "dbo",
                table: "DummyMain",
                column: "DummyOneToManyId");

            migrationBuilder.CreateIndex(
                name: "IX_DummyMainDummyManyToMany_DummyManyToManyId",
                schema: "dbo",
                table: "DummyMainDummyManyToMany",
                column: "DummyManyToManyId");

            migrationBuilder.CreateIndex(
                name: "UX_DummyManyToMany_Name",
                schema: "dbo",
                table: "DummyManyToMany",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_DummyOneToMany_Name",
                schema: "dbo",
                table: "DummyOneToMany",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_DummyTree_Id_ParentId",
                schema: "dbo",
                table: "DummyTree",
                columns: new[] { "Id", "ParentId" },
                unique: true,
                filter: "[ParentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UX_DummyTree_ParentId_Name",
                schema: "dbo",
                table: "DummyTree",
                columns: new[] { "ParentId", "Name" },
                unique: true,
                filter: "[ParentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UX_Role_NormalizedName",
                schema: "dbo",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                schema: "dbo",
                table: "RoleClaim",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_NormalizedEmail",
                schema: "dbo",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UX_User_NormalizedUserName",
                schema: "dbo",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                schema: "dbo",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                schema: "dbo",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "dbo",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DummyMainDummyManyToMany",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DummyTreeLink",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleClaim",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserClaim",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserLogin",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserToken",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DummyMain",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DummyManyToMany",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DummyTree",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DummyOneToMany",
                schema: "dbo");
        }
    }
}
