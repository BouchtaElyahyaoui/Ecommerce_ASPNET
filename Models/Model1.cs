using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ECOMMERCE_Project_ASPNET.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Probleme> Problemes { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }

        public virtual DbSet<Historique> Historiques { get; set; }
        public virtual DbSet<History> Histories { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Problemes)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Produits)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categorie>()
                .Property(e => e.NomCat)
                .IsUnicode(false);

            modelBuilder.Entity<Categorie>()
                .HasMany(e => e.Produits)
                .WithRequired(e => e.Categorie)
                .HasForeignKey(e => e.CategorieId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Probleme>()
                .Property(e => e.MessageProb)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.LibelleProd)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.DescriptionProd)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.ImageProd)
                .IsUnicode(false);
        }
    }
}
