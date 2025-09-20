using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Sport)
                .WithMany()
                .HasForeignKey(m => m.SportId);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Creator)
                .WithMany()
                .HasForeignKey(m => m.CreatorId);

            modelBuilder.Entity<Participation>()
                .HasOne(p => p.Match)
                .WithMany()
                .HasForeignKey(p => p.MatchId);

            modelBuilder.Entity<Participation>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Message>()
                .HasOne(msg => msg.Match)
                .WithMany()
                .HasForeignKey(msg => msg.MatchId);

            modelBuilder.Entity<Message>()
                .HasOne(msg => msg.User)
                .WithMany()
                .HasForeignKey(msg => msg.UserId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Match)
                .WithMany()
                .HasForeignKey(r => r.MatchId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Reviewer)
                .WithMany()
                .HasForeignKey(r => r.ReviewerId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Participant)
                .WithMany()
                .HasForeignKey(r => r.ParticipantId);
        }
    }
}