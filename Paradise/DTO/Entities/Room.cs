using System.Collections.Generic;

namespace DTO.Entities
{
    public class Room
    {
        public int RoomId { get; set; }

        public string Name { get; set; }

        public ICollection<Item> RoomItems { get; set; }
        public ICollection<Character> RoomCharacters { get; set; }

        public Room RoomUp { get; set; }
        public Room RoomRight { get; set; }
        public Room RoomDown { get; set; }
        public Room RoomLeft { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
