﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace hosApp.Migrations
{
    [DbContext(typeof(hospital))]
    partial class hospitalModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("hosApp.Models.Case", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientRef")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("PatientRef")
                        .IsUnique();

                    b.ToTable("Case");
                });

            modelBuilder.Entity("hosApp.Models.Consultation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CaseID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<float>("Height")
                        .HasColumnType("REAL");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.Property<string>("diagnostic")
                        .HasColumnType("TEXT");

                    b.Property<int?>("doctorID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("idCase")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CaseID");

                    b.HasIndex("doctorID");

                    b.ToTable("Consultation");
                });

            modelBuilder.Entity("hosApp.Models.Doctor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Speciality")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tel")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("hosApp.Models.Patient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tel")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("hosApp.Models.Prescription", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("idConsul")
                        .HasColumnType("INTEGER");

                    b.Property<string>("prescription")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("idConsul")
                        .IsUnique();

                    b.ToTable("Prescription");
                });

            modelBuilder.Entity("hosApp.Models.Case", b =>
                {
                    b.HasOne("hosApp.Models.Patient", "Patient")
                        .WithOne("Case")
                        .HasForeignKey("hosApp.Models.Case", "PatientRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("hosApp.Models.Consultation", b =>
                {
                    b.HasOne("hosApp.Models.Case", "Case")
                        .WithMany("Consultations")
                        .HasForeignKey("CaseID");

                    b.HasOne("hosApp.Models.Doctor", "doctor")
                        .WithMany("consultations")
                        .HasForeignKey("doctorID");

                    b.Navigation("Case");

                    b.Navigation("doctor");
                });

            modelBuilder.Entity("hosApp.Models.Prescription", b =>
                {
                    b.HasOne("hosApp.Models.Consultation", "Consultation")
                        .WithOne("Prescription")
                        .HasForeignKey("hosApp.Models.Prescription", "idConsul")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consultation");
                });

            modelBuilder.Entity("hosApp.Models.Case", b =>
                {
                    b.Navigation("Consultations");
                });

            modelBuilder.Entity("hosApp.Models.Consultation", b =>
                {
                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("hosApp.Models.Doctor", b =>
                {
                    b.Navigation("consultations");
                });

            modelBuilder.Entity("hosApp.Models.Patient", b =>
                {
                    b.Navigation("Case");
                });
#pragma warning restore 612, 618
        }
    }
}
