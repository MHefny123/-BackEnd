using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEnd.Models
{
       public partial class MHefny_TaskDBContext : DbContext
    {
      
        public MHefny_TaskDBContext(DbContextOptions<MHefny_TaskDBContext> options)
            : base(options)
        {
        }

        
        
        

        public virtual DbSet<User> user  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=HefnyDB;User Id=SA;Password=MHefny@550; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");
             modelBuilder.Entity<User>(entity =>
            {

                entity.ToTable("User");
                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.FName).HasColumnName("FName");
                entity.Property(e => e.LName).HasColumnName("LName");
                entity.Property(e => e.Username).HasColumnName("Username");
                entity.Property(e => e.Password).HasColumnName("Password");
                entity.Property(e => e.Email).HasColumnName("Email");
                entity.Property(e => e.Phone).HasColumnName("Phone");
            });
        }
    }
}