using Microsoft.EntityFrameworkCore;
using VibeGamingWeb.Models.DBEntities;

namespace VibeGamingWeb.DAL
{
    public class MainDbContext : DbContext
    {
        // Constructor for creating an instance of MainDbContext
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) 
        { 
            Users = Set<VibeUsers>();
            Games = Set<VibeGames>();
            Buys = Set<VibeBuy>();
            Tips = Set<VibeTip>();
            Cates = Set<VibeCate>();
            Galls = Set<VibeGall>();
            Trailers = Set<VibeTrailer>();
            Specs = Set<VibeSpec>();
            Carts = Set<VibeCart>();
            Orders = Set<VibeOrder>();
        }
        // Enables access to and manipulation of data from the database
        public virtual DbSet<VibeUsers> Users { get; set; }
        public virtual DbSet<VibeGames> Games { get; set; }
        public virtual DbSet<VibeBuy> Buys { get; set; }
        public virtual DbSet<VibeTip> Tips { get; set; }
        public virtual DbSet<VibeCate> Cates { get; set; }
        public virtual DbSet<VibeGall> Galls { get; set; }
        public virtual DbSet<VibeTrailer> Trailers { get; set; }
        public virtual DbSet<VibeSpec> Specs { get; set; }
        public virtual DbSet<VibeCart> Carts { get; set; }
        public virtual DbSet<VibeOrder> Orders { get; set; }
    }
}
