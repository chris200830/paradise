using System.Collections.Generic;

namespace DTO.Entities
{
    public class Dialogue
    {
        public int DialogueId { get; set; }

        public string DialogueText { get; set; }

        public ICollection<DialogueOption> DialogueOptions { get; set; }

        public int DialogueCharacterId { get; set; }
        public Character DialogueCharacter { get; set; }
    }
}
