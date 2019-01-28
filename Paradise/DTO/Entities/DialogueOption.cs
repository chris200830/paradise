using DTO.Entities.Enums;

namespace DTO.Entities
{
    public class DialogueOption
    {
        public int DialogueOptionId { get; set; }

        public string DialogueOptionText { get; set; }

        public int DialogueId { get; set; }
        public virtual Dialogue Dialogue { get; set; }

        public Dialogue NextDialogue { get; set; }

        public DialogueOptionType DialogueOptionType { get; set; }
    }
}
