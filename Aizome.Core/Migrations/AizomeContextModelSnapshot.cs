﻿// <auto-generated />
using System;
using Aizome.Core.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Aizome.Core.Migrations
{
    [DbContext(typeof(AizomeContext))]
    partial class AizomeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Aizome.Core.DataAccess.Entities.Blob", b =>
                {
                    b.Property<string>("FileId")
                        .HasColumnType("text");

                    b.Property<string>("ContainerName")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("JeanForeignKey")
                        .HasColumnType("integer");

                    b.HasKey("FileId");

                    b.HasIndex("JeanForeignKey");

                    b.ToTable("Blobs");
                });

            modelBuilder.Entity("Aizome.Core.DataAccess.Entities.Jean", b =>
                {
                    b.Property<int>("JeanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<DateTime>("DateAdded")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("UserForeignKey")
                        .HasColumnType("integer");

                    b.HasKey("JeanId");

                    b.HasIndex("UserForeignKey");

                    b.ToTable("Jeans");
                });

            modelBuilder.Entity("Aizome.Core.DataAccess.Entities.Timeline", b =>
                {
                    b.Property<Guid>("TimelineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("JeanForeignKey")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimelineDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("TimelineId");

                    b.HasIndex("JeanForeignKey");

                    b.ToTable("Timelines");
                });

            modelBuilder.Entity("Aizome.Core.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Aizome.Core.DataAccess.Entities.Blob", b =>
                {
                    b.HasOne("Aizome.Core.DataAccess.Entities.Jean", "Jean")
                        .WithMany("Blobs")
                        .HasForeignKey("JeanForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jean");
                });

            modelBuilder.Entity("Aizome.Core.DataAccess.Entities.Jean", b =>
                {
                    b.HasOne("Aizome.Core.DataAccess.Entities.User", "User")
                        .WithMany("Jeans")
                        .HasForeignKey("UserForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Aizome.Core.DataAccess.Entities.Timeline", b =>
                {
                    b.HasOne("Aizome.Core.DataAccess.Entities.Jean", "Jean")
                        .WithMany("Timelines")
                        .HasForeignKey("JeanForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jean");
                });

            modelBuilder.Entity("Aizome.Core.DataAccess.Entities.Jean", b =>
                {
                    b.Navigation("Blobs");

                    b.Navigation("Timelines");
                });

            modelBuilder.Entity("Aizome.Core.DataAccess.Entities.User", b =>
                {
                    b.Navigation("Jeans");
                });
#pragma warning restore 612, 618
        }
    }
}
