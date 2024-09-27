﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240926160535_intial")]
    partial class intial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("API.Data.Models.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT")
                        .HasColumnName("date_updated");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsEmailVerifed")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_email_verifed");

                    b.Property<bool>("IsMobileNumberVerified")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_mobile_number_verified");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("password");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("INTEGER")
                        .HasColumnName("phone_number");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_by");

                    b.HasKey("id")
                        .HasName("pk_user");

                    b.ToTable("user", "public");
                });

            modelBuilder.Entity("API.Data.Models.UserLock", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT")
                        .HasColumnName("date_updated");

                    b.Property<int>("FailedLogInCount")
                        .HasColumnType("INTEGER")
                        .HasColumnName("failed_log_in_count");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_locked");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_by");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_id");

                    b.HasKey("id")
                        .HasName("pk_user_lock");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasDatabaseName("ix_user_lock_user_id");

                    b.ToTable("user_lock", "public");
                });

            modelBuilder.Entity("API.Data.Models.UserLock", b =>
                {
                    b.HasOne("API.Data.Models.User", null)
                        .WithOne("UserLockId")
                        .HasForeignKey("API.Data.Models.UserLock", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_lock_user_user_id");
                });

            modelBuilder.Entity("API.Data.Models.User", b =>
                {
                    b.Navigation("UserLockId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
