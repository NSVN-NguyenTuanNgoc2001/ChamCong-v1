﻿// <auto-generated />
using System;
using ChamCong.API.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChamCong.API.Data.Migrations
{
    [DbContext(typeof(ImDbContext))]
    [Migration("20220405125343_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChamCong.API.Data.Data.Plan.im_Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("CompletionPercentage")
                        .HasColumnType("real");

                    b.Property<bool>("IsLate")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TimeCheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeCheckOut")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalTaskComplete")
                        .HasColumnType("int");

                    b.Property<int>("TotalTaskOutStandingCount")
                        .HasColumnType("int");

                    b.Property<int>("TotalTaskPlannedCount")
                        .HasColumnType("int");

                    b.Property<int>("TotalTimeWorkCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("im_Plan");
                });

            modelBuilder.Entity("ChamCong.API.Data.Data.Profile.im_User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmplyeeId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("GroudID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EmplyeeId")
                        .IsUnique();

                    b.HasIndex("GroudID");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("im_User");
                });

            modelBuilder.Entity("ChamCong.API.Data.Data.Profile.im_User_Credential", b =>
                {
                    b.Property<string>("UserGroupId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserRoleId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("UserGroupId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserRoleId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserGroupId", "UserRoleId");

                    b.HasIndex("UserGroupId1");

                    b.HasIndex("UserRoleId1");

                    b.ToTable("im_User_Credential");
                });

            modelBuilder.Entity("ChamCong.API.Data.Data.Profile.im_User_Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("im_User_Group");
                });

            modelBuilder.Entity("ChamCong.API.Data.Data.Profile.im_User_Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("im_User_Role");
                });

            modelBuilder.Entity("ChamCong.API.Data.Data.Task.im_Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TypeTask")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.ToTable("im_Task");
                });

            modelBuilder.Entity("ChamCong.API.Data.Data.Plan.im_Plan", b =>
                {
                    b.HasOne("ChamCong.API.Data.Data.Profile.im_User", "user")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("user");
                });

            modelBuilder.Entity("ChamCong.API.Data.Data.Profile.im_User", b =>
                {
                    b.HasOne("ChamCong.API.Data.Data.Profile.im_User_Group", "UserGroup")
                        .WithMany()
                        .HasForeignKey("GroudID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("ChamCong.API.Data.Data.Profile.im_User_Credential", b =>
                {
                    b.HasOne("ChamCong.API.Data.Data.Profile.im_User_Group", "UserGroup")
                        .WithMany("UserCredential")
                        .HasForeignKey("UserGroupId1");

                    b.HasOne("ChamCong.API.Data.Data.Profile.im_User_Role", "UserRole")
                        .WithMany("UserCredential")
                        .HasForeignKey("UserRoleId1");

                    b.Navigation("UserGroup");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("ChamCong.API.Data.Data.Task.im_Task", b =>
                {
                    b.HasOne("ChamCong.API.Data.Data.Plan.im_Plan", "Plan")
                        .WithMany("TaskListCode")
                        .HasForeignKey("PlanId");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("ChamCong.API.Data.Data.Plan.im_Plan", b =>
                {
                    b.Navigation("TaskListCode");
                });

            modelBuilder.Entity("ChamCong.API.Data.Data.Profile.im_User_Group", b =>
                {
                    b.Navigation("UserCredential");
                });

            modelBuilder.Entity("ChamCong.API.Data.Data.Profile.im_User_Role", b =>
                {
                    b.Navigation("UserCredential");
                });
#pragma warning restore 612, 618
        }
    }
}
