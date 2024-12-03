using Hotel.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DataAccess
{
    public class HotelDbContext : DbContext
    {
        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<HotelEntity> Hotels { get; set; }
        public DbSet<HotelRoomEntity> HotelRooms { get; set; }
        public DbSet<PhotoEntity> Photos { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public HotelDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //default identity server tables
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("user_claims");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("user_logins").HasNoKey();
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("user_tokens").HasNoKey(); ;
            modelBuilder.Entity<UserRoleEntity>().ToTable("user_roles");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("user_role_claims");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("user_role_owners").HasNoKey();

            modelBuilder.Entity<AdminEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<AdminEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<HotelEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<HotelEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<HotelRoomEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<HotelRoomEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<HotelRoomEntity>().HasOne(x => x.Hotel).WithMany(x => x.HotelRooms).HasForeignKey(x => x.HotelId);

            modelBuilder.Entity<PhotoEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<PhotoEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<PhotoEntity>().HasOne(x => x.Hotel).WithMany(x => x.Photos).HasForeignKey(x => x.HotelId);
            modelBuilder.Entity<PhotoEntity>().HasOne(x => x.HotelRoom).WithMany(x => x.Photos).HasForeignKey(x => x.HotelRoomId);

            modelBuilder.Entity<ReservationEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ReservationEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<ReservationEntity>().HasOne(x => x.User).WithMany(x => x.Reservations).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<ReservationEntity>().HasOne(x => x.HotelRoom).WithMany(x => x.Reservations).HasForeignKey(x => x.HotelRoomId);

            modelBuilder.Entity<ReviewEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ReviewEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<ReviewEntity>().HasOne(x => x.User).WithMany(x => x.Reviews).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<ReviewEntity>().HasOne(x => x.Hotel).WithMany(x => x.Reviews).HasForeignKey(x => x.HotelId);

            modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();
        }
    }
}