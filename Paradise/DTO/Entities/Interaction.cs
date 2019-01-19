using DTO.Entities.Enums;

namespace DTO.Entities
{
    public class Interaction
    {
        public int InteractionId { get; set; }

        public string InteractionText { get; set; }
        public InteractionType InteractionType { get; set; }

        public int InteractableObjectId { get; set; }
        public InteractableObject InteractableObject { get; set; }
    }
}
