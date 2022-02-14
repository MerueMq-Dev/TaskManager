﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManager;

#nullable disable

namespace TaskManager.Migrations
{
    [DbContext(typeof(TaskAppContext))]
    partial class TaskAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TaskManager.Entities.ProjectEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime?>("EndOfProject")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Priority")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartProject")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TaskManager.Entities.TaskEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Desciption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Priority")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProjectEntityId")
                        .HasColumnType("bigint");

                    b.Property<int>("stateTask")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectEntityId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManager.Entities.TaskEntity", b =>
                {
                    b.HasOne("TaskManager.Entities.ProjectEntity", "ProjectEntity")
                        .WithMany("ProjectTasks")
                        .HasForeignKey("ProjectEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ProjectEntity");
                });

            modelBuilder.Entity("TaskManager.Entities.ProjectEntity", b =>
                {
                    b.Navigation("ProjectTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
