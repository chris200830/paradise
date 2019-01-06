using System.Collections.Generic;

namespace DTO.Entities
{
    public class InteractableObject
    {
        public int InteractableObjectId { get; set; }

        public List<Interaction> Interactions { get; set; }

        public string ObjectName { get; set; }
    }
}
