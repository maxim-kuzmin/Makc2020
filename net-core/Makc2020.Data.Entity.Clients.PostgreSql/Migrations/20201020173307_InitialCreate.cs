using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Makc2020.Data.Entity.Clients.PostgreSql.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "dummy_many_to_many",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dummy_many_to_many", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dummy_one_to_many",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dummy_one_to_many", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dummy_tree",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 256, nullable: false),
                    parent_id = table.Column<long>(nullable: true),
                    tree_child_count = table.Column<long>(nullable: false, defaultValue: 0L),
                    tree_descendant_count = table.Column<long>(nullable: false, defaultValue: 0L),
                    tree_level = table.Column<long>(nullable: false, defaultValue: 0L),
                    tree_path = table.Column<string>(unicode: false, maxLength: 900, nullable: false, defaultValue: ""),
                    tree_position = table.Column<int>(nullable: false, defaultValue: 0),
                    tree_sort = table.Column<string>(unicode: false, maxLength: 900, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dummy_tree", x => x.id);
                    table.ForeignKey(
                        name: "fk_dummy_tree_dummy_tree_parent_id",
                        column: x => x.parent_id,
                        principalSchema: "public",
                        principalTable: "dummy_tree",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(maxLength: 256, nullable: true),
                    email = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(nullable: false),
                    password_hash = table.Column<string>(nullable: true),
                    security_stamp = table.Column<string>(nullable: true),
                    concurrency_stamp = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    phone_number_confirmed = table.Column<bool>(nullable: false),
                    two_factor_enabled = table.Column<bool>(nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(nullable: true),
                    lockout_enabled = table.Column<bool>(nullable: false),
                    access_failed_count = table.Column<int>(nullable: false),
                    full_name = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dummy_main",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 256, nullable: false),
                    dummy_one_to_many_id = table.Column<long>(nullable: false),
                    prop_boolean = table.Column<bool>(nullable: false),
                    prop_boolean_nullable = table.Column<bool>(nullable: true),
                    prop_date = table.Column<DateTime>(nullable: false),
                    prop_date_nullable = table.Column<DateTime>(nullable: true),
                    prop_date_time_offset = table.Column<DateTimeOffset>(nullable: false),
                    prop_date_time_offset_nullable = table.Column<DateTimeOffset>(nullable: true),
                    prop_decimal = table.Column<decimal>(nullable: false),
                    prop_decimal_nullable = table.Column<decimal>(nullable: true),
                    prop_int_32 = table.Column<int>(nullable: false),
                    prop_int_32_nullable = table.Column<int>(nullable: true),
                    prop_int_64 = table.Column<long>(nullable: false),
                    prop_int_64_nullable = table.Column<long>(nullable: true),
                    prop_string = table.Column<string>(nullable: false),
                    prop_string_nullable = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dummy_main", x => x.id);
                    table.ForeignKey(
                        name: "fk_dummy_main_dummy_one_to_many",
                        column: x => x.dummy_one_to_many_id,
                        principalSchema: "public",
                        principalTable: "dummy_one_to_many",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dummy_tree_link",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false),
                    parent_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dummy_tree_link", x => new { x.id, x.parent_id });
                    table.ForeignKey(
                        name: "fk_dummy_tree_link_dummy_tree",
                        column: x => x.id,
                        principalSchema: "public",
                        principalTable: "dummy_tree",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_claim",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<long>(nullable: false),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_claim", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_claim_role",
                        column: x => x.role_id,
                        principalSchema: "public",
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_claim",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(nullable: false),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_claim", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_claim_user",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_login",
                schema: "public",
                columns: table => new
                {
                    login_provider = table.Column<string>(nullable: false),
                    provider_key = table.Column<string>(nullable: false),
                    provider_display_name = table.Column<string>(nullable: true),
                    user_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_login", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_user_login_user",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                schema: "public",
                columns: table => new
                {
                    user_id = table.Column<long>(nullable: false),
                    role_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_role", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_user_role_role",
                        column: x => x.role_id,
                        principalSchema: "public",
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_role_user",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_token",
                schema: "public",
                columns: table => new
                {
                    user_id = table.Column<long>(nullable: false),
                    login_provider = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_token", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_user_token_user",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dummy_main_dummy_many_to_many",
                schema: "public",
                columns: table => new
                {
                    dummy_main_id = table.Column<long>(nullable: false),
                    dummy_many_to_many_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dummy_main_dummy_many_to_many", x => new { x.dummy_main_id, x.dummy_many_to_many_id });
                    table.ForeignKey(
                        name: "fk_dummy_main_dummy_many_to_many_dummy_main",
                        column: x => x.dummy_main_id,
                        principalSchema: "public",
                        principalTable: "dummy_main",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dummy_main_dummy_many_to_many_dummy_many_to_many",
                        column: x => x.dummy_many_to_many_id,
                        principalSchema: "public",
                        principalTable: "dummy_many_to_many",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ux_dummy_main_name",
                schema: "public",
                table: "dummy_main",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_dummy_main_dummy_one_to_many_id",
                schema: "public",
                table: "dummy_main",
                column: "dummy_one_to_many_id");

            migrationBuilder.CreateIndex(
                name: "ix_dummy_main_dummy_many_to_many_dummy_many_to_many_id",
                schema: "public",
                table: "dummy_main_dummy_many_to_many",
                column: "dummy_many_to_many_id");

            migrationBuilder.CreateIndex(
                name: "ux_dummy_many_to_many_name",
                schema: "public",
                table: "dummy_many_to_many",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_dummy_one_to_many_name",
                schema: "public",
                table: "dummy_one_to_many",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_dummy_tree_name",
                schema: "public",
                table: "dummy_tree",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_dummy_tree_parent_id",
                schema: "public",
                table: "dummy_tree",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "ix_dummy_tree_tree_sort",
                schema: "public",
                table: "dummy_tree",
                column: "tree_sort");

            migrationBuilder.CreateIndex(
                name: "ux_dummy_tree_parent_id_name",
                schema: "public",
                table: "dummy_tree",
                columns: new[] { "parent_id", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_role_normalized_name",
                schema: "public",
                table: "role",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_role_claim_role_id",
                schema: "public",
                table: "role_claim",
                column: "role_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_normalized_email",
                schema: "public",
                table: "user",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "ux_user_normalized_user_name",
                schema: "public",
                table: "user",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_claim_user_id",
                schema: "public",
                table: "user_claim",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_login_user_id",
                schema: "public",
                table: "user_login",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_role_role_id",
                schema: "public",
                table: "user_role",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dummy_main_dummy_many_to_many",
                schema: "public");

            migrationBuilder.DropTable(
                name: "dummy_tree_link",
                schema: "public");

            migrationBuilder.DropTable(
                name: "role_claim",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user_claim",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user_login",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user_role",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user_token",
                schema: "public");

            migrationBuilder.DropTable(
                name: "dummy_main",
                schema: "public");

            migrationBuilder.DropTable(
                name: "dummy_many_to_many",
                schema: "public");

            migrationBuilder.DropTable(
                name: "dummy_tree",
                schema: "public");

            migrationBuilder.DropTable(
                name: "role",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user",
                schema: "public");

            migrationBuilder.DropTable(
                name: "dummy_one_to_many",
                schema: "public");
        }
    }
}
