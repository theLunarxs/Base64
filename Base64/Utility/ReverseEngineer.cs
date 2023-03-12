using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Base64.Utility
{
    public class Inbound
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Up { get; set; }
        public int Down { get; set; }
        public int Total { get; set; }
        public string Remark { get; set; }
        public bool Enable { get; set; }
        public int ExpiryTime { get; set; }
        public string Listen { get; set; }
        public int Port { get; set; }
        public string Protocol { get; set; }
        public string Settings { get; set; }
        public string StreamSettings { get; set; }
        public string Tag { get; set; }
        public string Sniffing { get; set; }
    }
    public class ConfigsContext : DbContext
    {
        public DbSet<Inbound> Inbounds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=P:\sshkey\test.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inbound>(entity =>
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

}
