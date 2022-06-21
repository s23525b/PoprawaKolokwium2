using System;
using Microsoft.EntityFrameworkCore;

namespace PoprawaKolokwium2.DTO
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }

        public DbSet<File> Files { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Team> Teams { get; set; }

        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organization>(o =>
            {
                o.HasKey(e => e.OrganizationID);
                o.Property(e => e.OrganizationName).IsRequired().HasMaxLength(100);
                o.Property(e => e.OrganizationDomain).IsRequired().HasMaxLength(50);

                o.HasData(
                    new Organization { OrganizationID = 1, OrganizationName = "Glashy", OrganizationDomain = "G.pl" },
                    new Organization { OrganizationID = 2, OrganizationName = "MNE", OrganizationDomain = "MNE.pl" }
                );
            });

            modelBuilder.Entity<Member>(m =>
            {

                m.HasKey(e => e.MemberID);
                m.Property(e => e.MemberName).IsRequired().HasMaxLength(20);
                m.Property(e => e.MemberSurname).IsRequired().HasMaxLength(50);
                m.Property(e => e.MemberNickName).HasMaxLength(20);
                m.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.OrganizationID);

                m.HasData(
                    new Member
                    {
                        MemberID = 1, MemberName = "Jan", MemberSurname = "Kowalski", MemberNickName = "Soda",
                        OrganizationID = 1
                    },
                    new Member
                    {
                        MemberID = 2, MemberName = "Ewa", MemberSurname = "Janinowicz", MemberNickName = "Jana",
                        OrganizationID = 2
                    }
                );
            });

            modelBuilder.Entity<Team>(m =>
            {

                m.HasKey(e => e.TeamID);
                m.Property(e => e.TeamName).IsRequired().HasMaxLength(50);
                m.Property(e => e.TeamDescription).HasMaxLength(500);
                m.HasOne(e => e.Organization).WithMany(e => e.Teams).HasForeignKey(e => e.OrganizationID);


                m.HasData(
                    new Member
                    {
                        MemberID = 1, MemberName = "Jan", MemberSurname = "Kowalski", MemberNickName = "Soda",
                        OrganizationID = 1
                    },
                    new Member
                    {
                        MemberID = 2, MemberName = "Ewa", MemberSurname = "Janinowicz", MemberNickName = "Jana",
                        OrganizationID = 2
                    }
                );
            });

            modelBuilder.Entity<File>(m =>
            {

                m.HasKey(e => e.FileID);
                m.Property(e => e.FileExtension).IsRequired().HasMaxLength(4);
                m.Property(e => e.FileName).IsRequired().HasMaxLength(100);
                m.Property(e => e.FileSize).IsRequired();
                m.HasOne(e => e.Team).WithMany(e => e.Files).HasForeignKey(e => e.TeamID);


                m.HasData(
                    new File { FileID = 1, FileName = "extensions", FileExtension = "pdf", FileSize = 3, TeamID = 1 }
                );
            });

            modelBuilder.Entity<Membership>(m =>
            {
                m.HasKey(e => new { e.Member.MemberID, e.Team.TeamID });
                m.HasOne(e => e.Member).WithMany(e => e.Memberships).HasForeignKey(e => e.MemberID);
                m.HasOne(e => e.Team).WithMany(e => e.Memberships).HasForeignKey(e => e.MemberID);
                m.Property(e => e.MembershipDate).IsRequired();


                m.HasData(
                    new Membership { MemberID = 1, TeamID = 1, MembershipDate = DateTime.Parse("2022-06-20") }
                );
            });
            
        }
    }
}