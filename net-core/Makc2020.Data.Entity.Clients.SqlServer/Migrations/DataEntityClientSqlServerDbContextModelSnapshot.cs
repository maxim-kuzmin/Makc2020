﻿// <auto-generated />
using System;
using Makc2020.Data.Entity.Clients.SqlServer.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Makc2020.Data.Entity.Clients.SqlServer.Migrations
{
    [DbContext(typeof(DataEntityClientSqlServerDbContext))]
    partial class DataEntityClientSqlServerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyMain", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.Property<long>("ObjectDummyOneToManyId")
                        .HasColumnName("DummyOneToManyId")
                        .HasColumnType("bigint");

                    b.Property<bool>("PropBoolean")
                        .HasColumnType("bit");

                    b.Property<bool?>("PropBooleanNullable")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PropDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PropDateNullable")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("PropDateTimeOffset")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("PropDateTimeOffsetNullable")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal>("PropDecimal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PropDecimalNullable")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PropInt32")
                        .HasColumnType("int");

                    b.Property<int?>("PropInt32Nullable")
                        .HasColumnType("int");

                    b.Property<long>("PropInt64")
                        .HasColumnType("bigint");

                    b.Property<long?>("PropInt64Nullable")
                        .HasColumnType("bigint");

                    b.Property<string>("PropString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<string>("PropStringNullable")
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.HasKey("Id")
                        .HasName("PK_DummyMain");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UX_DummyMain_Name");

                    b.HasIndex("ObjectDummyOneToManyId");

                    b.ToTable("DummyMain","dbo");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyMainDummyManyToMany", b =>
                {
                    b.Property<long>("ObjectDummyMainId")
                        .HasColumnName("DummyMainId")
                        .HasColumnType("bigint");

                    b.Property<long>("ObjectDummyManyToManyId")
                        .HasColumnName("DummyManyToManyId")
                        .HasColumnType("bigint");

                    b.HasKey("ObjectDummyMainId", "ObjectDummyManyToManyId")
                        .HasName("PK_DummyMainDummyManyToMany");

                    b.HasIndex("ObjectDummyManyToManyId");

                    b.ToTable("DummyMainDummyManyToMany","dbo");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyManyToMany", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.HasKey("Id")
                        .HasName("PK_DummyManyToMany");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UX_DummyManyToMany_Name");

                    b.ToTable("DummyManyToMany","dbo");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyOneToMany", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.HasKey("Id")
                        .HasName("PK_DummyOneToMany");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UX_DummyOneToMany_Name");

                    b.ToTable("DummyOneToMany","dbo");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyTree", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<long>("TreeChildCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<long>("TreeDescendantCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<long>("TreeLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<string>("TreePath")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<string>("TreeSort")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.HasKey("Id")
                        .HasName("PK_DummyTree");

                    b.HasIndex("Id", "ParentId")
                        .IsUnique()
                        .HasName("UX_DummyTree_Id_ParentId")
                        .HasFilter("[ParentId] IS NOT NULL");

                    b.HasIndex("ParentId", "Name")
                        .IsUnique()
                        .HasName("UX_DummyTree_ParentId_Name")
                        .HasFilter("[ParentId] IS NOT NULL");

                    b.ToTable("DummyTree","dbo");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyTreeLink", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("ParentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id", "ParentId")
                        .HasName("PK_DummyTreeLink");

                    b.ToTable("DummyTreeLink","dbo");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasName("PK_Role");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("UX_Role_NormalizedName")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role","dbo");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK_RoleClaim");

                    b.HasIndex("RoleId")
                        .IsUnique()
                        .HasName("IX_RoleClaim_RoleId");

                    b.ToTable("RoleClaim","dbo");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasName("PK_User");

                    b.HasIndex("NormalizedEmail")
                        .HasName("IX_User_NormalizedEmail");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UX_User_NormalizedUserName")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User","dbo");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK_UserClaim");

                    b.HasIndex("UserId")
                        .HasName("IX_UserClaim_UserId");

                    b.ToTable("UserClaim","dbo");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("PK_UserLogin");

                    b.HasIndex("UserId")
                        .HasName("IX_UserLogin_UserId");

                    b.ToTable("UserLogin","dbo");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUserRole", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnName("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnName("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId")
                        .HasName("PK_UserRole");

                    b.HasIndex("RoleId")
                        .HasName("IX_UserRole_RoleId");

                    b.ToTable("UserRole","dbo");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUserToken", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("PK_UserToken");

                    b.ToTable("UserToken","dbo");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyMain", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectDummyOneToMany", "ObjectDummyOneToMany")
                        .WithMany("ObjectsDummyMain")
                        .HasForeignKey("ObjectDummyOneToManyId")
                        .HasConstraintName("FK_DummyMain_DummyOneToMany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyMainDummyManyToMany", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectDummyMain", "ObjectDummyMain")
                        .WithMany("ObjectsDummyMainDummyManyToMany")
                        .HasForeignKey("ObjectDummyMainId")
                        .HasConstraintName("FK_DummyMainDummyManyToMany_DummyMain")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectDummyManyToMany", "ObjectDummyManyToMany")
                        .WithMany("ObjectsDummyMainDummyManyToMany")
                        .HasForeignKey("ObjectDummyManyToManyId")
                        .HasConstraintName("FK_DummyMainDummyManyToMany_DummyManyToMany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyTree", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectDummyTree", "ObjectDummyTreeParent")
                        .WithMany("ObjectsDummyTreeChild")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("FK_DummyTree_DummyTree_ParentId");
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectDummyTreeLink", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectDummyTree", "ObjectDummyTree")
                        .WithMany("ObjectsDummyTreeLink")
                        .HasForeignKey("Id")
                        .HasConstraintName("FK_DummyTreeLink_DummyTree_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectRoleClaim", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectRole", "ObjectRole")
                        .WithMany("ObjectsRoleClaim")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_RoleClaim_Role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUserClaim", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectUser", "ObjectUser")
                        .WithMany("ObjectsUserClaim")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserClaim_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUserLogin", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectUser", "ObjectUser")
                        .WithMany("ObjectsUserLogin")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserLogin_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUserRole", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectRole", "ObjectRole")
                        .WithMany("ObjectsUserRole")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_UserRole_Role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectUser", "ObjectUser")
                        .WithMany("ObjectsUserRole")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserRole_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Makc2020.Data.Entity.Objects.DataEntityObjectUserToken", b =>
                {
                    b.HasOne("Makc2020.Data.Entity.Objects.DataEntityObjectUser", "ObjectUser")
                        .WithMany("ObjectsUserToken")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserToken_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
