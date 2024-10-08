﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VibeGamingWeb.DAL;

#nullable disable

namespace VibeGamingWeb.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20240514120949_VMig")]
    partial class VMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeBuy", b =>
                {
                    b.Property<int>("IdBuy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBuy"), 1L, 1);

                    b.Property<string>("BuyAgeRestrict")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("BuyGameEdition")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("BuyName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("BuyPlatImgPath")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<float>("BuyPrice")
                        .HasColumnType("real");

                    b.Property<string>("BuyStockGame")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("BuyWallImgPath")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("IdCart")
                        .HasColumnType("int");

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<int?>("IdSpec")
                        .HasColumnType("int");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int");

                    b.HasKey("IdBuy");

                    b.HasIndex("IdCart");

                    b.HasIndex("IdGame");

                    b.HasIndex("IdSpec");

                    b.HasIndex("IdUser");

                    b.ToTable("Buys");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeCart", b =>
                {
                    b.Property<int>("IdCart")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCart"), 1L, 1);

                    b.Property<string>("CartEmail")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CartGameName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<float>("CartGamePrice")
                        .HasColumnType("real");

                    b.Property<int>("CartGameQty")
                        .HasColumnType("int");

                    b.Property<string>("CartImgPath")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.HasKey("IdCart");

                    b.HasIndex("IdGame");

                    b.HasIndex("IdUser");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeCate", b =>
                {
                    b.Property<int>("IdCate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCate"), 1L, 1);

                    b.Property<string>("CateDev")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CateDigKey")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CateGameSupp")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CateOfOn")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CatePlayer")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CateRevNum")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("IdBuy")
                        .HasColumnType("int");

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.HasKey("IdCate");

                    b.HasIndex("IdBuy");

                    b.HasIndex("IdGame");

                    b.ToTable("Cates");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeGall", b =>
                {
                    b.Property<int>("IdGall")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGall"), 1L, 1);

                    b.Property<string>("GallImgDesc")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("GallImgPath")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("GallImgTitle")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<int?>("IdTip")
                        .HasColumnType("int");

                    b.HasKey("IdGall");

                    b.HasIndex("IdGame");

                    b.HasIndex("IdTip");

                    b.ToTable("Galls");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeGames", b =>
                {
                    b.Property<int>("IdGame")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGame"), 1L, 1);

                    b.Property<string>("GameImgPath")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("GamePlatform")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<float>("GamePrice")
                        .HasColumnType("real");

                    b.HasKey("IdGame");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeOrder", b =>
                {
                    b.Property<int>("IdOrd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrd"), 1L, 1);

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("OrdAddress")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("OrdFirstName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("OrdGameName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<float>("OrdGamePrice")
                        .HasColumnType("real");

                    b.Property<int>("OrdGameQty")
                        .HasColumnType("int");

                    b.Property<string>("OrdImgPath")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("OrdLastName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("OrdPhoneNum")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<float>("OrdTotalNum")
                        .HasColumnType("real");

                    b.HasKey("IdOrd");

                    b.HasIndex("IdGame");

                    b.HasIndex("IdUser");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeSpec", b =>
                {
                    b.Property<int>("IdSpec")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSpec"), 1L, 1);

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<int?>("IdTra")
                        .HasColumnType("int");

                    b.Property<string>("SpecGrapMax")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("SpecGrapMin")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("SpecMemMax")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("SpecMemMin")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("SpecOSMax")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("SpecOSMin")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("SpecProcMax")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("SpecProcMin")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("SpecStorMax")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("SpecStorMin")
                        .HasColumnType("varchar(200)");

                    b.HasKey("IdSpec");

                    b.HasIndex("IdGame");

                    b.HasIndex("IdTra");

                    b.ToTable("Specs");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeTip", b =>
                {
                    b.Property<int>("IdTip")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTip"), 1L, 1);

                    b.Property<int?>("IdCate")
                        .HasColumnType("int");

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<string>("TipAboutGame")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TipBannPath")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("TipGame1")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TipGame2")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TipGame3")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TipGame4")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TipTextGame")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("IdTip");

                    b.HasIndex("IdCate");

                    b.HasIndex("IdGame");

                    b.ToTable("Tips");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeTrailer", b =>
                {
                    b.Property<int>("IdTra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTra"), 1L, 1);

                    b.Property<int?>("IdGall")
                        .HasColumnType("int");

                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<string>("TraImgPath")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("TraLink")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("IdTra");

                    b.HasIndex("IdGall");

                    b.HasIndex("IdGame");

                    b.ToTable("Trailers");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeUsers", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeBuy", b =>
                {
                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeCart", "VibeCart")
                        .WithMany()
                        .HasForeignKey("IdCart");

                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeGames", "VibeGames")
                        .WithMany()
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeSpec", "VibeSpec")
                        .WithMany()
                        .HasForeignKey("IdSpec");

                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeUsers", "VibeUsers")
                        .WithMany()
                        .HasForeignKey("IdUser");

                    b.Navigation("VibeCart");

                    b.Navigation("VibeGames");

                    b.Navigation("VibeSpec");

                    b.Navigation("VibeUsers");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeCart", b =>
                {
                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeGames", "VibeGames")
                        .WithMany()
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeUsers", "VibeUsers")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VibeGames");

                    b.Navigation("VibeUsers");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeCate", b =>
                {
                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeBuy", "VibeBuy")
                        .WithMany()
                        .HasForeignKey("IdBuy");

                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeGames", "VibeGames")
                        .WithMany()
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VibeBuy");

                    b.Navigation("VibeGames");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeGall", b =>
                {
                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeGames", "VibeGames")
                        .WithMany()
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeTip", "VibeTip")
                        .WithMany()
                        .HasForeignKey("IdTip");

                    b.Navigation("VibeGames");

                    b.Navigation("VibeTip");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeOrder", b =>
                {
                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeGames", "VibeGames")
                        .WithMany()
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeUsers", "VibeUsers")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VibeGames");

                    b.Navigation("VibeUsers");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeSpec", b =>
                {
                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeGames", "VibeGames")
                        .WithMany()
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeTrailer", "VibeTrailer")
                        .WithMany()
                        .HasForeignKey("IdTra");

                    b.Navigation("VibeGames");

                    b.Navigation("VibeTrailer");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeTip", b =>
                {
                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeCate", "VibeCate")
                        .WithMany()
                        .HasForeignKey("IdCate");

                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeGames", "VibeGames")
                        .WithMany()
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VibeCate");

                    b.Navigation("VibeGames");
                });

            modelBuilder.Entity("VibeGamingWeb.Models.DBEntities.VibeTrailer", b =>
                {
                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeGall", "VibeGall")
                        .WithMany()
                        .HasForeignKey("IdGall");

                    b.HasOne("VibeGamingWeb.Models.DBEntities.VibeGames", "VibeGames")
                        .WithMany()
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VibeGall");

                    b.Navigation("VibeGames");
                });
#pragma warning restore 612, 618
        }
    }
}
