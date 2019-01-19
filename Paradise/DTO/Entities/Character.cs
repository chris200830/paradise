using System.Collections.Generic;

namespace DTO.Entities
{
    public class Character : InteractableObject
    {
        public int CharacterId { get; set; }

        public ICollection<Dialogue> CharacterDialogues { get; set; }
    }
}
