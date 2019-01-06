using System.Data.Entity;
using DTO.Entities;
using MySql.Data.EntityFramework;

namespace DAL.Database
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class WpfAppContext : DbContext
    {
        public WpfAppContext()
            : base("dbContext")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>().HasRequired(i => i.ItemRoom).WithMany(r => r.RoomItems)
                .HasForeignKey(i => i.ItemRoomId);
            modelBuilder.Entity<Character>().HasRequired(i => i.CharacterRoom).WithMany(r => r.RoomCharacters)
                .HasForeignKey(i => i.CharacterRoomId);

        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Character> Characters { get; set; }
    }
}