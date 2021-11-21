﻿// <auto-generated />
using System;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAL.Entities.A_Permission", b =>
                {
                    b.Property<long>("A_Permission_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("a_permission_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("A_Permission_ID"), 1L, 1);

                    b.Property<string>("A_Permission_Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("a_permission_type");

                    b.Property<long>("Album_ID")
                        .HasMaxLength(100)
                        .HasColumnType("bigint")
                        .HasColumnName("album_id");

                    b.Property<long>("User_ID")
                        .HasMaxLength(100)
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("A_Permission_ID");

                    b.HasIndex("Album_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("a_permission", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Album", b =>
                {
                    b.Property<long>("Album_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("album_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Album_ID"), 1L, 1);

                    b.Property<string>("Album_Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("album_description");

                    b.Property<string>("Album_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("album_name");

                    b.HasKey("Album_ID");

                    b.ToTable("album", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.I_Permission", b =>
                {
                    b.Property<long>("I_Permission_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("i_permission_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("I_Permission_ID"), 1L, 1);

                    b.Property<string>("I_Permission_Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("i_permission_type");

                    b.Property<long>("Image_ID")
                        .HasColumnType("bigint")
                        .HasColumnName("image_id");

                    b.Property<long>("User_ID")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("I_Permission_ID");

                    b.HasIndex("Image_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("i_permission", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Image", b =>
                {
                    b.Property<long>("Image_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("image_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Image_ID"), 1L, 1);

                    b.Property<long>("Album_ID")
                        .HasColumnType("bigint")
                        .HasColumnName("album_id");

                    b.Property<string>("Geolocation")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("geolocation");

                    b.Property<string>("Image_Captured_By")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("image_captured_by");

                    b.Property<DateTime>("Image_Captured_Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("image_capture_date");

                    b.Property<string>("Image_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("image_name");

                    b.Property<string>("Image_Tags")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("image_tags");

                    b.Property<string>("Other_Metadata")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("other_metadata");

                    b.HasKey("Image_ID");

                    b.HasIndex("Album_ID");

                    b.ToTable("image", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<long>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("User_ID"), 1L, 1);

                    b.Property<string>("User_Email")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("user_email");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("user_name");

                    b.Property<string>("User_Nickname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("user_nickname");

                    b.Property<string>("User_PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("user_passwordhash");

                    b.Property<string>("User_Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("user_surname");

                    b.HasKey("User_ID");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.A_Permission", b =>
                {
                    b.HasOne("DAL.Entities.Album", "Album")
                        .WithMany("A_Permissions")
                        .HasForeignKey("Album_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("A_Permissions")
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.I_Permission", b =>
                {
                    b.HasOne("DAL.Entities.Image", "Image")
                        .WithMany("I_Permissions")
                        .HasForeignKey("Image_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("I_Permissions")
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Image", b =>
                {
                    b.HasOne("DAL.Entities.Album", "Albums")
                        .WithMany("Images")
                        .HasForeignKey("Album_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Albums");
                });

            modelBuilder.Entity("DAL.Entities.Album", b =>
                {
                    b.Navigation("A_Permissions");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("DAL.Entities.Image", b =>
                {
                    b.Navigation("I_Permissions");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Navigation("A_Permissions");

                    b.Navigation("I_Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
