﻿// <auto-generated />
using System;
using Makc2020.Data.Entity.Clients.PostgreSql.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Makc2020.Data.Entity.Clients.PostgreSql.Migrations
{
    [DbContext(typeof(DataEntityClientPostgreSqlDbContext))]
    [Migration("20201008153322_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyMain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.Property<long>("ObjectDummyOneToManyId")
                        .HasColumnName("dummy_one_to_many_id")
                        .HasColumnType("bigint");

                    b.Property<bool>("PropBoolean")
                        .HasColumnName("prop_boolean")
                        .HasColumnType("boolean");

                    b.Property<bool?>("PropBooleanNullable")
                        .HasColumnName("prop_boolean_nullable")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("PropDate")
                        .HasColumnName("prop_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("PropDateNullable")
                        .HasColumnName("prop_date_nullable")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTimeOffset>("PropDateTimeOffset")
                        .HasColumnName("prop_date_time_offset")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("PropDateTimeOffsetNullable")
                        .HasColumnName("prop_date_time_offset_nullable")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("PropDecimal")
                        .HasColumnName("prop_decimal")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("PropDecimalNullable")
                        .HasColumnName("prop_decimal_nullable")
                        .HasColumnType("numeric");

                    b.Property<int>("PropInt32")
                        .HasColumnName("prop_int_32")
                        .HasColumnType("integer");

                    b.Property<int?>("PropInt32Nullable")
                        .HasColumnName("prop_int_32_nullable")
                        .HasColumnType("integer");

                    b.Property<long>("PropInt64")
                        .HasColumnName("prop_int_64")
                        .HasColumnType("bigint");

                    b.Property<long?>("PropInt64Nullable")
                        .HasColumnName("prop_int_64_nullable")
                        .HasColumnType("bigint");

                    b.Property<string>("PropString")
                        .IsRequired()
                        .HasColumnName("prop_string")
                        .HasColumnType("text")
                        .IsUnicode(true);

                    b.Property<string>("PropStringNullable")
                        .HasColumnName("prop_string_nullable")
                        .HasColumnType("text")
                        .IsUnicode(true);

                    b.HasKey("Id")
                        .HasName("pk_dummy_main");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("ux_dummy_main_name");

                    b.HasIndex("ObjectDummyOneToManyId")
                        .HasName("ix_dummy_main_dummy_one_to_many_id");

                    b.ToTable("dummy_main","public");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyMainDummyManyToMany", b =>
                {
                    b.Property<long>("ObjectDummyMainId")
                        .HasColumnName("dummy_main_id")
                        .HasColumnType("bigint");

                    b.Property<long>("ObjectDummyManyToManyId")
                        .HasColumnName("dummy_many_to_many_id")
                        .HasColumnType("bigint");

                    b.HasKey("ObjectDummyMainId", "ObjectDummyManyToManyId")
                        .HasName("pk_dummy_main_dummy_many_to_many");

                    b.HasIndex("ObjectDummyManyToManyId")
                        .HasName("ix_dummy_main_dummy_many_to_many_dummy_many_to_many_id");

                    b.ToTable("dummy_main_dummy_many_to_many","public");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyManyToMany", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.HasKey("Id")
                        .HasName("pk_dummy_many_to_many");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("ux_dummy_many_to_many_name");

                    b.ToTable("dummy_many_to_many","public");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyOneToMany", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.HasKey("Id")
                        .HasName("pk_dummy_one_to_many");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("ux_dummy_one_to_many_name");

                    b.ToTable("dummy_one_to_many","public");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyTree", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.Property<long?>("ParentId")
                        .HasColumnName("parent_id")
                        .HasColumnType("bigint");

                    b.Property<long>("TreeChildCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tree_child_count")
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<long>("TreeDescendantCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tree_descendant_count")
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<long>("TreeLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tree_level")
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<string>("TreePath")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tree_path")
                        .HasColumnType("character varying(900)")
                        .HasMaxLength(900)
                        .IsUnicode(false)
                        .HasDefaultValue("");

                    b.Property<int>("TreePosition")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tree_position")
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("TreeSort")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tree_sort")
                        .HasColumnType("character varying(900)")
                        .HasMaxLength(900)
                        .IsUnicode(false)
                        .HasDefaultValue("");

                    b.HasKey("Id")
                        .HasName("pk_dummy_tree");

                    b.HasIndex("Name")
                        .HasName("ix_dummy_tree_name");

                    b.HasIndex("ParentId")
                        .HasName("ix_dummy_tree_parent_id");

                    b.HasIndex("TreeSort")
                        .HasName("ix_dummy_tree_tree_sort");

                    b.ToTable("dummy_tree","public");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyTreeLink", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<long>("ParentId")
                        .HasColumnName("parent_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id", "ParentId")
                        .HasName("pk_dummy_tree_link");

                    b.ToTable("dummy_tree_link","public");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("concurrency_stamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnName("normalized_name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasName("pk_role");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("ux_role_normalized_name");

                    b.ToTable("role","public");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value")
                        .HasColumnType("text");

                    b.Property<long>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("pk_role_claim");

                    b.HasIndex("RoleId")
                        .IsUnique()
                        .HasName("ux_role_claim_role_id");

                    b.ToTable("role_claim","public");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnName("access_failed_count")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("concurrency_stamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnName("email_confirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FullName")
                        .HasColumnName("full_name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnName("lockout_enabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnName("lockout_end")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnName("normalized_email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnName("normalized_user_name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("password_hash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("phone_number")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnName("phone_number_confirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnName("security_stamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnName("two_factor_enabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnName("user_name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.HasIndex("NormalizedEmail")
                        .HasName("ix_user_normalized_email");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("ux_user_normalized_user_name");

                    b.ToTable("user","public");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("pk_user_claim");

                    b.HasIndex("UserId")
                        .HasName("ix_user_claim_user_id");

                    b.ToTable("user_claim","public");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnName("provider_key")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnName("provider_display_name")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_user_login");

                    b.HasIndex("UserId")
                        .HasName("ix_user_login_user_id");

                    b.ToTable("user_login","public");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUserRole", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_user_role");

                    b.HasIndex("RoleId")
                        .HasName("ix_user_role_role_id");

                    b.ToTable("user_role","public");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUserToken", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnName("value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_user_token");

                    b.ToTable("user_token","public");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyMain", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectDummyOneToMany", "ObjectDummyOneToMany")
                        .WithMany("ObjectsDummyMain")
                        .HasForeignKey("ObjectDummyOneToManyId")
                        .HasConstraintName("fk_dummy_main_dummy_one_to_many")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyMainDummyManyToMany", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectDummyMain", "ObjectDummyMain")
                        .WithMany("ObjectsDummyMainDummyManyToMany")
                        .HasForeignKey("ObjectDummyMainId")
                        .HasConstraintName("fk_dummy_main_dummy_many_to_many_dummy_main")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectDummyManyToMany", "ObjectDummyManyToMany")
                        .WithMany("ObjectsDummyMainDummyManyToMany")
                        .HasForeignKey("ObjectDummyManyToManyId")
                        .HasConstraintName("fk_dummy_main_dummy_many_to_many_dummy_many_to_many")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyTree", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectDummyTree", "ObjectDummyTreeParent")
                        .WithMany("ObjectsDummyTreeChild")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("fk_dummy_tree_dummy_tree_parent_id");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyTreeLink", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectDummyTree", "ObjectDummyTree")
                        .WithMany("ObjectsDummyTreeLink")
                        .HasForeignKey("Id")
                        .HasConstraintName("fk_dummy_tree_link_dummy_tree")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectRoleClaim", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectRole", "ObjectRole")
                        .WithMany("ObjectsRoleClaim")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_role_claim_role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUserClaim", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectUser", "ObjectUser")
                        .WithMany("ObjectsUserClaim")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_claim_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUserLogin", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectUser", "ObjectUser")
                        .WithMany("ObjectsUserLogin")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_login_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUserRole", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectRole", "ObjectRole")
                        .WithMany("ObjectsUserRole")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_user_role_role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectUser", "ObjectUser")
                        .WithMany("ObjectsUserRole")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_role_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUserToken", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectUser", "ObjectUser")
                        .WithMany("ObjectsUserToken")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_token_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
