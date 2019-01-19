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
            modelBuilder.Entity<Character>().ToTable("Characters");
            modelBuilder.Entity<MainCharacter>().ToTable("MainCharacters");
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<InteractableObject>().HasRequired(i => i.InteractableObjectRoom).WithMany(r => r.RoomInteractableObjects)
                .HasForeignKey(i => i.InteractableObjectRoomId);
            modelBuilder.Entity<Interaction>().HasRequired(i => i.InteractableObject).WithMany(r => r.Interactions)
                .HasForeignKey(i => i.InteractableObjectId);
            modelBuilder.Entity<Dialogue>().HasRequired(i => i.DialogueCharacter).WithMany(r => r.CharacterDialogues)
                .HasForeignKey(i => i.DialogueCharacterId);
            modelBuilder.Entity<DialogueOption>().HasRequired(i => i.Dialogue).WithMany(r => r.DialogueOptions)
                .HasForeignKey(i => i.DialogueId);
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<InteractableObject> InteractableObjects { get; set; }
        public DbSet<Dialogue> Dialogues { get; set; }
        public DbSet<DialogueOption> DialogueOptions { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<MainCharacter> MainCharacters { get; set; }
    }
}