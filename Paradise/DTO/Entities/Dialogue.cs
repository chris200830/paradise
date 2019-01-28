using System.Collections.Generic;

namespace DTO.Entities
{
    public class Dialogue
    {
        public int DialogueId { get; set; }

        public string DialogueText { get; set; }

        public virtual ICollection<DialogueOption> DialogueOptions { get; set; }

        public int DialogueCharacterId { get; set; }
        public virtual Character DialogueCharacter { get; set; }
    }
}
