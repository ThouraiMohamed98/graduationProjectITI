using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GP.Models
{
    public partial class GPContext : DbContext
    {
        public GPContext()
        {
        }

        public GPContext(DbContextOptions<GPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientRole> ClientRoles { get; set; }
        public virtual DbSet<Freelancer> Freelancers { get; set; }
        public virtual DbSet<FreelancerHire> FreelancerHires { get; set; }
        public virtual DbSet<FreelancerRole> FreelancerRoles { get; set; }
        public virtual DbSet<Gig> Gigs { get; set; }
        public virtual DbSet<Profession> Professions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=GP;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Phone)
                    .HasName("PK__client__B43B145E73DABC41");

                entity.ToTable("client");

                entity.Property(e => e.Phone)
                    .ValueGeneratedNever()
                    .HasColumnName("phone");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<ClientRole>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.ClientPho })
                    .HasName("c1");

                entity.ToTable("clientRole");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.ClientPho).HasColumnName("clientPho");

                entity.HasOne(d => d.ClientPhoNavigation)
                    .WithMany(p => p.ClientRoles)
                    .HasForeignKey(d => d.ClientPho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__clientRol__clien__48CFD27E");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ClientRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__clientRol__roleI__47DBAE45");
            });

            modelBuilder.Entity<Freelancer>(entity =>
            {
                entity.HasKey(e => e.Phone)
                    .HasName("PK__freelanc__B43B145E65E7A09D");

                entity.ToTable("freelancer");

                entity.Property(e => e.Phone)
                    .ValueGeneratedNever()
                    .HasColumnName("phone");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("password");

                entity.Property(e => e.ProfId).HasColumnName("profId");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WorkCity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("workCity");

                entity.Property(e => e.WorkCountry)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("workCountry");

                entity.Property(e => e.WorkDistrict)
                    .HasMaxLength(50)
                    .HasColumnName("workDistrict");

                entity.HasOne(d => d.Prof)
                    .WithMany(p => p.Freelancers)
                    .HasForeignKey(d => d.ProfId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__freelance__profI__3E52440B");
            });

            modelBuilder.Entity<FreelancerHire>(entity =>
            {
                entity.HasKey(e => new { e.ClientPho, e.FreelancerPho, e.HireDate })
                    .HasName("PK_Person");

                entity.ToTable("freelancerHire");

                entity.Property(e => e.ClientPho).HasColumnName("clientPho");

                entity.Property(e => e.FreelancerPho).HasColumnName("freelancerPho");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hireDate");

                entity.HasOne(d => d.ClientPhoNavigation)
                    .WithMany(p => p.FreelancerHires)
                    .HasForeignKey(d => d.ClientPho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__freelance__clien__412EB0B6");

                entity.HasOne(d => d.FreelancerPhoNavigation)
                    .WithMany(p => p.FreelancerHires)
                    .HasForeignKey(d => d.FreelancerPho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__freelance__freel__4222D4EF");
            });

            modelBuilder.Entity<FreelancerRole>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.FreelancerPho })
                    .HasName("c2");

                entity.ToTable("freelancerRole");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.FreelancerPho).HasColumnName("freelancerPho");

                entity.HasOne(d => d.FreelancerPhoNavigation)
                    .WithMany(p => p.FreelancerRoles)
                    .HasForeignKey(d => d.FreelancerPho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__freelance__freel__4CA06362");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.FreelancerRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__freelance__roleI__4BAC3F29");
            });

            modelBuilder.Entity<Gig>(entity =>
            {
                entity.ToTable("gig");

                entity.Property(e => e.GigId).HasColumnName("gigId");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.FreelancerPho).HasColumnName("freelancerPho");

                entity.Property(e => e.GigName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("gigName");

                entity.Property(e => e.MaxPrice).HasColumnName("maxPrice");

                entity.Property(e => e.MinPrice).HasColumnName("minPrice");

                entity.HasOne(d => d.FreelancerPhoNavigation)
                    .WithMany(p => p.Gigs)
                    .HasForeignKey(d => d.FreelancerPho)
                    .HasConstraintName("FK__gig__freelancerP__44FF419A");
            });

            modelBuilder.Entity<Profession>(entity =>
            {
                entity.ToTable("profession");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ProfName)
                    .HasMaxLength(50)
                    .HasColumnName("profName");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("roleName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
