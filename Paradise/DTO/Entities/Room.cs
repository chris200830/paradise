using System.Collections.Generic;
using DTO.Entities.Enums;

namespace DTO.Entities
{
    public class Room
    {
        public int RoomId { get; set; }

        public string Name { get; set; }

        public ICollection<InteractableObject> RoomInteractableObjects { get; set; }

        public Room RoomUp { get; set; }
        public Room RoomRight { get; set; }
        public Room RoomDown { get; set; }
        public Room RoomLeft { get; set; }

        public Location Location { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
