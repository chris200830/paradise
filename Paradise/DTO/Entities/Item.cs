namespace DTO.Entities
{
    public class Item : InteractableObject
    {
        public int ItemId { get; set; }

        public string Name { get; set; }

        public int ItemRoomId { get; set; }
        public Room ItemRoom { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
