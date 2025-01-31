﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineMedicine_api.Models
{
    public partial class dbOnlineMedicineContext : DbContext
    {
        public dbOnlineMedicineContext()
        {
        }

        public dbOnlineMedicineContext(DbContextOptions<dbOnlineMedicineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<Pharmacy> Pharmacy { get; set; }
        public virtual DbSet<PharmacyMedicines> PharmacyMedicines { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-F831UR2\\SQLEXPRESS2014;Database=dbOnlineMedicine;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(256);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.LastName).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.Property(e => e.ZipCode).HasMaxLength(50);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Manufacture).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Supplier).HasMaxLength(50);
            });

            modelBuilder.Entity<Pharmacy>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("addressId");

                entity.Property(e => e.PharmacyName)
                    .HasColumnName("pharmacyName")
                    .HasMaxLength(50);

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Pharmacy)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Pharmacy_Address");
            });

            modelBuilder.Entity<PharmacyMedicines>(entity =>
            {
                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.PharmacyMedicines)
                    .HasForeignKey(d => d.MedicineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PharmacyMedicines_Medicine");

                entity.HasOne(d => d.Pharmacy)
                    .WithMany(p => p.PharmacyMedicines)
                    .HasForeignKey(d => d.PharmacyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PharmacyMedicines_Pharmacy");
            });
        }
    }
}
