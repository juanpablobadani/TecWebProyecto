using Microsoft.EntityFrameworkCore;
using ProyectoFinalTecWeb.Data.Entities;

namespace ProyectoFinalTecWeb.Data
{
    public class HotelDBContext : DbContext
    {
        public HotelDBContext(DbContextOptions<HotelDBContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoomEntity>().ToTable("Rooms");
            modelBuilder.Entity<RoomEntity>().HasMany(a => a.Guests).WithOne(b => b.Room);
            modelBuilder.Entity<GuestEntity>().Property(a => a.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<GuestEntity>().ToTable("Guests");
            modelBuilder.Entity<GuestEntity>().Property(b => b.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<GuestEntity>().HasOne(b => b.Room).WithMany(a => a.Guests);
        }

        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<GuestEntity> Guests { get; set; }
    }
}
