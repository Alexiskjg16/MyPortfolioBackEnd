using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlogPortfolioAPI.Models;

namespace BlogPortfolioAPI
{
    public partial class RSSFeedContext : DbContext
    {
        public RSSFeedContext()
        {
        }

        public RSSFeedContext(DbContextOptions<RSSFeedContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("server=localhost;database=RSSFeed");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}
        public DbSet<RSSFeed> RSSFeed{ get; set; }
    }
}
