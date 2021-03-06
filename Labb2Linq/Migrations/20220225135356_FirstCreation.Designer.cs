// <auto-generated />
using System;
using Labb2Linq.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Labb2Linq.Migrations
{
    [DbContext(typeof(SkolaDbContext))]
    [Migration("20220225135356_FirstCreation")]
    partial class FirstCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Labb2Linq.Elev", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KlassId")
                        .HasColumnType("int");

                    b.Property<string>("efterNamn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("förNamn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KlassId");

                    b.ToTable("Elever");
                });

            modelBuilder.Entity("Labb2Linq.Klass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("klassNamn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Klasser");
                });

            modelBuilder.Entity("Labb2Linq.Kurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KlassId")
                        .HasColumnType("int");

                    b.Property<int?>("LärareId")
                        .HasColumnType("int");

                    b.Property<string>("kursNamn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KlassId");

                    b.HasIndex("LärareId");

                    b.ToTable("Kurser");
                });

            modelBuilder.Entity("Labb2Linq.Lärare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("efterNamn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("förNamn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lärare");
                });

            modelBuilder.Entity("Labb2Linq.Elev", b =>
                {
                    b.HasOne("Labb2Linq.Klass", "Klass")
                        .WithMany("Elever")
                        .HasForeignKey("KlassId");
                });

            modelBuilder.Entity("Labb2Linq.Kurs", b =>
                {
                    b.HasOne("Labb2Linq.Klass", "Klass")
                        .WithMany("Kurser")
                        .HasForeignKey("KlassId");

                    b.HasOne("Labb2Linq.Lärare", "Lärare")
                        .WithMany("Kurser")
                        .HasForeignKey("LärareId");
                });
#pragma warning restore 612, 618
        }
    }
}
