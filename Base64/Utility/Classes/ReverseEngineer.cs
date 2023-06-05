using Base64.Utility.Models;
using Microsoft.EntityFrameworkCore;

namespace Base64.Utility.Classes
{
    public class MhSanaeiConfigsContext : DbContext
    {
        public DbSet<InboundModel> Inbounds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!Directory.Exists(@"DB\"))
                Directory.CreateDirectory(@"DB\");
            optionsBuilder.UseSqlite(@"Data Source=DB\yourDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InboundModel>(entity =>
            {
                entity.ToTable("inbounds");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Up).HasColumnName("up");
                entity.Property(e => e.Down).HasColumnName("down");
                entity.Property(e => e.Total).HasColumnName("total");
                entity.Property(e => e.Remark).HasColumnName("remark");
                entity.Property(e => e.Enable).HasColumnName("enable");
                entity.Property(e => e.ExpiryTime).HasColumnName("expiry_time");
                entity.Property(e => e.Listen).HasColumnName("listen");
                entity.Property(e => e.Port).HasColumnName("port");
                entity.Property(e => e.Protocol).HasColumnName("protocol");
                entity.Property(e => e.Settings).HasColumnName("settings");
                entity.Property(e => e.StreamSettings).HasColumnName("stream_settings");
                entity.Property(e => e.Tag).HasColumnName("tag");
                entity.Property(e => e.Sniffing).HasColumnName("sniffing");
            });
        }
    }
    public class KafkaConfigsContext : DbContext
    {
        public DbSet<InboundModel> Inbounds { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!Directory.Exists(@"DB\"))
                Directory.CreateDirectory(@"DB\");
            optionsBuilder.UseSqlite(@"Data Source=DB\yourDB.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InboundModel>(entity =>
            {
                entity.ToTable("inbounds");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Up).HasColumnName("up");
                entity.Property(e => e.Down).HasColumnName("down");
                entity.Property(e => e.Total).HasColumnName("total");
                entity.Property(e => e.Remark).HasColumnName("remark");
                entity.Property(e => e.Enable).HasColumnName("enable");
                entity.Property(e => e.ExpiryTime).HasColumnName("expiry_time");
                entity.Property(e => e.autoreset).HasColumnName("autoreset");
                entity.Property(e => e.IPalert).HasColumnName("ip_alert");
                entity.Property(e => e.IPLimit).HasColumnName("ip_limit");
                entity.Property(e => e.Listen).HasColumnName("listen");
                entity.Property(e => e.Port).HasColumnName("port");
                entity.Property(e => e.Protocol).HasColumnName("protocol");
                entity.Property(e => e.Settings).HasColumnName("settings");
                entity.Property(e => e.StreamSettings).HasColumnName("stream_settings");
                entity.Property(e => e.Tag).HasColumnName("tag");
                entity.Property(e => e.Sniffing).HasColumnName("sniffing");
            });
        }
    }
}
