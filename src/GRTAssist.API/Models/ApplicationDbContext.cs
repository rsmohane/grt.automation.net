using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GRTAssist.API.Models;

namespace GRTAssist.API.Models
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApiKey> ApiKeys { get; set; }
        public DbSet<AutomationJob> AutomationJobs { get; set; }
        public DbSet<AIRequest> AIRequests { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<MarketData> MarketData { get; set; }
        public DbSet<SEOKeyword> SEOKeywords { get; set; }
        public DbSet<SearchLog> SearchLogs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<HistoryLog> HistoryLogs { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }

        // marketplace tables
        public DbSet<ApiListing> ApiListings { get; set; }
        public DbSet<DataSet> DataSets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure relationships
            builder.Entity<ApiKey>()
                .HasOne(ak => ak.User)
                .WithMany(u => u.ApiKeys)
                .HasForeignKey(ak => ak.UserId);

            builder.Entity<AutomationJob>()
                .HasOne(aj => aj.User)
                .WithMany(u => u.AutomationJobs)
                .HasForeignKey(aj => aj.UserId);

            builder.Entity<AIRequest>()
                .HasOne(ar => ar.User)
                .WithMany(u => u.AIRequests)
                .HasForeignKey(ar => ar.UserId);

            builder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId);

            builder.Entity<Transaction>()
                .HasOne(t => t.Payment)
                .WithMany(p => p.Transactions)
                .HasForeignKey(t => t.PaymentId);

            builder.Entity<SearchLog>()
                .HasOne(sl => sl.User)
                .WithMany()
                .HasForeignKey(sl => sl.UserId)
                .IsRequired(false);

            builder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId);

            builder.Entity<HistoryLog>()
                .HasOne(hl => hl.User)
                .WithMany(u => u.HistoryLogs)
                .HasForeignKey(hl => hl.UserId);

            // Configure Role-Permission many-to-many
            builder.Entity<Role>()
                .HasMany(r => r.Permissions)
                .WithMany(p => p.Roles)
                .UsingEntity(j => j.ToTable("RolePermissions"));
        }
    }
}