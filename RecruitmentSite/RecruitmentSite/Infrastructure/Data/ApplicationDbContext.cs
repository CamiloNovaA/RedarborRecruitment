using Microsoft.EntityFrameworkCore;
using RecruitmentSite.Domain.Entities;

namespace RecruitmentSite.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidateExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.HasKey(e => e.IdCandidate);
                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Surname).HasMaxLength(150).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(250).IsRequired();
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<CandidateExperience>(entity =>
            {
                entity.HasKey(e => e.IdCandidateExperience);
                entity.Property(e => e.Company).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Job).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(4000);
                entity.Property(e => e.Salary).HasColumnType("bigint");

                entity.HasOne(e => e.Candidate)
                    .WithMany(c => c.Experiences)
                    .HasForeignKey(e => e.IdCandidate)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}