using System.Data.Entity;
using System.IO;
using DTO.Entities;

namespace DAL.Database
{
    public class WpfAppContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Consumable> Consumables { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<InteractiveObject> InteractiveObjects { get; set; }
        public DbSet<Dialogue> Dialogues { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<MainCharacter> MainCharacters { get; set; }

        private const string ScriptsPath = "../../../DAL/Database/Scripts/";
        private bool createDb = true;

        public WpfAppContext()
            : base("dbContext")
        {
            if (createDb)
            {
                if (File.Exists(ScriptsPath + "CreateDb.txt"))
                {
                    var sqlCommand = File.ReadAllText(ScriptsPath + "CreateDb.txt");
                    Database.ExecuteSqlCommand(sqlCommand);
                    SaveChanges();
                }
            }

            //var interaction = new Interaction() { InteractionText = "Trage" };

            //var rs = Rooms.ToList();
            //var obj = InteractiveObjects.ToList();
            //var chars = Characters.ToList();
            //var r = new Room() {RoomName = "Bedroom"};
            //r.RoomUpId = 9990;
            //r.RoomDownId = 9990;
            //r.RoomLeftId = 9990;
            //r.RoomRightId = 9990;
            //var intobj = new InteractiveObject()
            //{
            //    Name = "Vasileee",
            //    Description = "Magarul",
            //    InteractiveObjectRoom = r,
            //    Interactions = new List<Interaction>() { interaction}
            //};
            //var c = new Character(){Name = "Bolshevbiq", Description = "Prostul", Interactions = new List<Interaction>() { interaction } };
            //var i = new Item(){Name = "Cutitul", Description = "cutit de bucatari", Interactions = new List<Interaction>() { interaction } };
            //var mc = new MainCharacter(){Name = "JJ", Description = "mc", Interactions = new List<Interaction>() { interaction } };
            //Rooms.Add(r);
            //InteractiveObjects.Add(intobj);
            //InteractiveObjects.Add(c);
            //InteractiveObjects.Add(i);
            //MainCharacters.Add(mc);
            //Interactions.Add(interaction);

            //var dialogue = new Dialogue(){Id = 0, DialogueText = "Hi How Are you?",
            //    DialogueCharacter = c, NextDialogueId = 10, DialogueRepliesId = 14};
            ////var dialogueOptions = new List<Dialogue>();
            //var reply = new Dialogue() { Id = 100, DialogueText = "Fine Thanks", NextDialogueId = 101, DialogueCharacterId = 1231};
            //var reply2 = new Dialogue() { Id = 200, DialogueText = "Fine Thanks", NextDialogueId = 202, DialogueRepliesId = 99, DialogueCharacterId = 1231 };
            //dialogue.DialogueReplies = new List<Dialogue>();
            //dialogue.DialogueReplies.Add(reply);

            //dialogueOptions.Add(reply);
            //dialogue.DialogueReplies = dialogueOptions;
            //var next = new Dialogue() {Id = 2, DialogueText = "Ok Bye", DialogueCharacter = c };

            //next.NextDialogueId = 99;
            //reply.NextDialogue = next;
            //Dialogues.Add(dialogue);

            //Dialogues.Add(reply);
            //Dialogues.Add(reply2);
            //Dialogues.Add(next);
            //try
            //{
            //    SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}
        }
    }
}