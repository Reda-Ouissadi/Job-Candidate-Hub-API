using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Job_Candidate_Hub_API.Models;

public partial class JobCandidateHubContext : DbContext
{
    public JobCandidateHubContext()
    {
    }

    public JobCandidateHubContext(DbContextOptions<JobCandidateHubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidat> Candidats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:CANDIDAT");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidat>(entity =>
        {
            entity.HasKey(e => e.CandidatId).HasName("PK__CANDIDAT__154DE7BCA740B98A");

            entity.ToTable("CANDIDAT");

            entity.HasIndex(e => e.Email, "UQ__CANDIDAT__161CF724B38CED4D").IsUnique();

            entity.Property(e => e.CandidatId).HasColumnName("CANDIDAT_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("EMAIL");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.GithubProfilUrl)
                .HasMaxLength(500)
                .HasColumnName("GITHUB_PROFIL_URL");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.LinkedinProfilUrl)
                .HasMaxLength(500)
                .HasColumnName("LINKEDIN_PROFIL_URL");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.TextComment)
                .HasMaxLength(1000)
                .IsRequired()
                .HasColumnName("TEXT_COMMENT");
            entity.Property(e => e.TimeInterval)
                .HasMaxLength(20)
                .HasColumnName("TIME_INTERVAL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
