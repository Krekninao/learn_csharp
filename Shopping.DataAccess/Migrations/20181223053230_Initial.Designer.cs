﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopping.DataAccess;

namespace Shopping.Frontend.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20181223053230_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Shopping")
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shopping.Book", b =>
                {
                    b.Property<int>("ProductIdentificator")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("Name")
                        .HasMaxLength(30);

                    b.Property<double>("Price");

                    b.Property<int>("Rating");

                    b.HasKey("ProductIdentificator");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Shopping.Device", b =>
                {
                    b.Property<int>("ProductIdentificator")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<string>("ProducingCountry");

                    b.Property<int>("Rating");

                    b.HasKey("ProductIdentificator");

                    b.ToTable("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}