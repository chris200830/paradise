namespace DTO.Entities
{
    public class Character : InteractableObject
    {
        public int CharacterId { get; set; }

        public int CharacterRoomId { get; set; }
        public Room CharacterRoom { get; set; }



        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
