using System.Collections.Generic;

namespace DTO.Entities
{
    public class InteractableObject
    {
        public int InteractableObjectId { get; set; }

        public ICollection<Interaction> Interactions { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int InteractableObjectRoomId { get; set; }
        public Room InteractableObjectRoom { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
