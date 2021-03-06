// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TimeSheets.Data;

namespace TimeSheets.Migrations
{
    [DbContext(typeof(TimeSheetDbContext))]
    [Migration("20210604104153_7_Migration_Aggregates_Added")]
    partial class _7_Migration_Aggregates_Added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TimeSheets.Domain.Aggregates.InvoiceAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<Guid>("ContractId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Sum")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("invoices");
                });

            modelBuilder.Entity("TimeSheets.Domain.Aggregates.SheetAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ApprovedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ContractId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("InvoiceId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("sheets");
                });

            modelBuilder.Entity("TimeSheets.Models.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("clients");
                });

            modelBuilder.Entity("TimeSheets.Models.Entities.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("contracts");
                });

            modelBuilder.Entity("TimeSheets.Models.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("employees");
                });

            modelBuilder.Entity("TimeSheets.Models.Entities.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("services");
                });

            modelBuilder.Entity("TimeSheets.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("TimeSheets.Domain.Aggregates.InvoiceAggregate", b =>
                {
                    b.HasOne("TimeSheets.Models.Entities.Contract", "Contract")
                        .WithMany("Invoices")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("TimeSheets.Domain.Aggregates.SheetAggregate", b =>
                {
                    b.HasOne("TimeSheets.Models.Entities.Contract", "Contract")
                        .WithMany("Sheets")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeSheets.Models.Entities.Employee", "Employee")
                        .WithMany("Sheets")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeSheets.Domain.Aggregates.InvoiceAggregate", "Invoice")
                        .WithMany("Sheets")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("TimeSheets.Models.Entities.Service", "Service")
                        .WithMany("Sheets")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("Employee");

                    b.Navigation("Invoice");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("TimeSheets.Models.Entities.Client", b =>
                {
                    b.HasOne("TimeSheets.Models.Entities.User", "User")
                        .WithOne("Client")
                        .HasForeignKey("TimeSheets.Models.Entities.Client", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TimeSheets.Models.Entities.Employee", b =>
                {
                    b.HasOne("TimeSheets.Models.Entities.User", "User")
                        .WithOne("Employee")
                        .HasForeignKey("TimeSheets.Models.Entities.Employee", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TimeSheets.Domain.Aggregates.InvoiceAggregate", b =>
                {
                    b.Navigation("Sheets");
                });

            modelBuilder.Entity("TimeSheets.Models.Entities.Contract", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("Sheets");
                });

            modelBuilder.Entity("TimeSheets.Models.Entities.Employee", b =>
                {
                    b.Navigation("Sheets");
                });

            modelBuilder.Entity("TimeSheets.Models.Entities.Service", b =>
                {
                    b.Navigation("Sheets");
                });

            modelBuilder.Entity("TimeSheets.Models.Entities.User", b =>
                {
                    b.Navigation("Client");

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
