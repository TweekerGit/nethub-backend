﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetHub.Data.SqlServer.Context;

#nullable disable

namespace NetHub.Data.SqlServer.Migrations
{
    [DbContext(typeof(SqlServerDbContext))]
    [Migration("20220529205128_EntitiesRefactoring")]
    partial class EntitiesRefactoring
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.ArticleEntities.Article", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("AuthorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.ArticleEntities.ArticleAuthor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("LocalizationArticleId")
                        .HasColumnType("bigint");

                    b.Property<string>("LocalizationLanguageCode")
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("LocalizationArticleId", "LocalizationLanguageCode");

                    b.ToTable("ArticleAuthors");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.ArticleEntities.ArticleLocalization", b =>
                {
                    b.Property<long>("ArticleId")
                        .HasColumnType("bigint");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Html")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("TranslatedArticleLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArticleId", "LanguageCode");

                    b.HasIndex("LanguageCode");

                    b.ToTable("ArticleLocalizations");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.ArticleEntities.ArticleResource", b =>
                {
                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("ArticleId")
                        .HasColumnType("bigint");

                    b.HasKey("ResourceId");

                    b.HasIndex("ArticleId");

                    b.ToTable("ArticleResources");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Language", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Code");

                    b.ToTable("Languages", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<byte[]>("Bytes")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Mimetype")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Resources", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.UserProfile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("Registered")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.ArticleEntities.Article", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.UserProfile", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.ArticleEntities.ArticleAuthor", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.UserProfile", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHub.Data.SqlServer.Entities.ArticleEntities.ArticleLocalization", "Localization")
                        .WithMany("Authors")
                        .HasForeignKey("LocalizationArticleId", "LocalizationLanguageCode");

                    b.Navigation("Author");

                    b.Navigation("Localization");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.ArticleEntities.ArticleLocalization", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.ArticleEntities.Article", "Article")
                        .WithMany("Localizations")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHub.Data.SqlServer.Entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.ArticleEntities.ArticleResource", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.ArticleEntities.Article", "ArticleLocalization")
                        .WithMany("Images")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHub.Data.SqlServer.Entities.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArticleLocalization");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.ArticleEntities.Article", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Localizations");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.ArticleEntities.ArticleLocalization", b =>
                {
                    b.Navigation("Authors");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.UserProfile", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
