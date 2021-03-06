// <auto-generated />
using System;
using FloraTransAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FloraTransAPI.Migrations
{
    [DbContext(typeof(FloraTransAPIContext))]
    [Migration("20210817062851_namechange")]
    partial class namechange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FloraTransAPI.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CVR")
                        .HasColumnType("int");

                    b.Property<int?>("ContactID")
                        .HasColumnType("int");

                    b.HasKey("ClientID");

                    b.HasIndex("ContactID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("FloraTransAPI.Models.Contact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("FloraTransAPI.Models.Container", b =>
                {
                    b.Property<int>("CCTag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<bool>("Lost")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Rented")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Returned")
                        .HasColumnType("datetime2");

                    b.HasKey("CCTag");

                    b.HasIndex("ClientID");

                    b.ToTable("Container");
                });

            modelBuilder.Entity("FloraTransAPI.Models.ContainerAssignment", b =>
                {
                    b.Property<int>("ContainerID")
                        .HasColumnType("int");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.HasKey("ContainerID", "ClientID");

                    b.HasIndex("ClientID");

                    b.ToTable("ContainerAssignment");
                });

            modelBuilder.Entity("FloraTransAPI.Models.Warehouse", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableContainers")
                        .HasColumnType("int");

                    b.Property<int>("RentedContainersCC")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Warehouse");
                });

            modelBuilder.Entity("FloraTransAPI.Models.Client", b =>
                {
                    b.HasOne("FloraTransAPI.Models.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactID");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("FloraTransAPI.Models.Container", b =>
                {
                    b.HasOne("FloraTransAPI.Models.Client", null)
                        .WithMany("RentedContainer")
                        .HasForeignKey("ClientID");
                });

            modelBuilder.Entity("FloraTransAPI.Models.ContainerAssignment", b =>
                {
                    b.HasOne("FloraTransAPI.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FloraTransAPI.Models.Container", "Container")
                        .WithMany("ClientHistory")
                        .HasForeignKey("ContainerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Container");
                });

            modelBuilder.Entity("FloraTransAPI.Models.Client", b =>
                {
                    b.Navigation("RentedContainer");
                });

            modelBuilder.Entity("FloraTransAPI.Models.Container", b =>
                {
                    b.Navigation("ClientHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
