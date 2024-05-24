﻿// <auto-generated />
using System;
using EarnMoney.Models.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EarnMoney.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.18");

            modelBuilder.Entity("EarnMoney.Models.Entities.EarnMoneyHistoryWD", b =>
                {
                    b.Property<string>("DeviceId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NoHP")
                        .HasColumnType("TEXT");

                    b.Property<string>("Response")
                        .HasColumnType("TEXT");

                    b.HasKey("DeviceId");

                    b.ToTable("EarnMoneyHistoryWDs");
                });

            modelBuilder.Entity("EarnMoney.Models.Entities.EarnMoneyMissions", b =>
                {
                    b.Property<string>("DeviceId")
                        .HasColumnType("TEXT");

                    b.Property<string>("MissionId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("DeviceId", "MissionId");

                    b.ToTable("EarnMoneyMissions");
                });

            modelBuilder.Entity("EarnMoney.Models.Entities.EarnMoneyPriorityMission", b =>
                {
                    b.Property<string>("MissionId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Success")
                        .HasColumnType("INTEGER");

                    b.HasKey("MissionId");

                    b.ToTable("EarnMoneyPriorityMissions");
                });

            modelBuilder.Entity("EarnMoney.Models.Entities.EarnMoneyUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Balance")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeviceId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FinishToday")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GoogleId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsWD")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MissionToday")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NoHP")
                        .HasColumnType("TEXT");

                    b.Property<string>("Token")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EarnMoneyUsers");
                });

            modelBuilder.Entity("EarnMoney.Models.Entities.MasterDana", b =>
                {
                    b.Property<string>("NoDana")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JumlahWD")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nama")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TodayWD")
                        .HasColumnType("INTEGER");

                    b.HasKey("NoDana");

                    b.ToTable("MasterDanas");
                });
#pragma warning restore 612, 618
        }
    }
}
