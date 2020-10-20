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
                    TreeChildCount = table.Column<long>(nullable: false, defaultValue: 0L),
                    TreeDescendantCount = table.Column<long>(nullable: false, defaultValue: 0L),
                    TreeLevel = table.Column<long>(nullable: false, defaultValue: 0L),
                    TreePath = table.Column<string>(unicode: false, maxLength: 900, nullable: false, defaultValue: ""),
                    TreePosition = table.Column<int>(nullable: false, defaultValue: 0),
                    TreeSort = table.Column<string>(unicode: false, maxLength: 900, nullable: false, defaultValue: "")
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
                    ParentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DummyTreeLink", x => new { x.Id, x.ParentId });
                    table.ForeignKey(
                        name: "FK_DummyTreeLink_DummyTree",
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
                name: "IX_DummyTree_Name",
                schema: "dbo",
                table: "DummyTree",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_DummyTree_ParentId",
                schema: "dbo",
                table: "DummyTree",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_DummyTree_TreeSort",
                schema: "dbo",
                table: "DummyTree",
                column: "TreeSort");

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
                name: "UX_RoleClaim_RoleId",
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
