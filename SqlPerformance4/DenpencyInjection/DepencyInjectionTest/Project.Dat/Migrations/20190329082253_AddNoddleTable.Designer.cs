﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YayoiApp.Data.EF;

namespace Project.Dat.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190329082253_AddNoddleTable")]
    partial class AddNoddleTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project.Data.Entities.EggTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name");

                    b.Property<int>("value");

                    b.HasKey("Id");

                    b.ToTable("EggTable");
                });

            modelBuilder.Entity("Project.Data.Entities.NoddleTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("noddleName");

                    b.Property<int>("value");

                    b.HasKey("Id");

                    b.ToTable("NoddleTable");
                });

            modelBuilder.Entity("Project.Data.Entities.Test1Test2", b =>
                {
                    b.Property<int>("TestTable1Id");

                    b.Property<int>("TestTable2Id");

                    b.HasKey("TestTable1Id", "TestTable2Id");

                    b.HasIndex("TestTable2Id");

                    b.ToTable("Test1Test2");
                });

            modelBuilder.Entity("Project.Data.Entities.TestTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name");

                    b.Property<int>("value");

                    b.HasKey("Id");

                    b.ToTable("TestTable");
                });

            modelBuilder.Entity("Project.Data.Entities.TestTable1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TestTableId");

                    b.Property<string>("name");

                    b.Property<int>("value");

                    b.HasKey("Id");

                    b.HasIndex("TestTableId");

                    b.ToTable("TestTable1");
                });

            modelBuilder.Entity("Project.Data.Entities.TestTable2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name");

                    b.Property<int>("value");

                    b.HasKey("Id");

                    b.ToTable("TestTable2");
                });

            modelBuilder.Entity("Project.Data.Entities.Test1Test2", b =>
                {
                    b.HasOne("Project.Data.Entities.TestTable1", "TestTable1")
                        .WithMany("Test1Test2s")
                        .HasForeignKey("TestTable1Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project.Data.Entities.TestTable2", "TestTable2")
                        .WithMany("Test1Test2s")
                        .HasForeignKey("TestTable2Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project.Data.Entities.TestTable1", b =>
                {
                    b.HasOne("Project.Data.Entities.TestTable")
                        .WithMany("TestTable1s")
                        .HasForeignKey("TestTableId");
                });
#pragma warning restore 612, 618
        }
    }
}
