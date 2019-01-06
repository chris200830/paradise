namespace DTO.Entities
{
    public class DialogueOption
    {
        public int DialogueOptionId { get; set; }

        public string DialogueOptionText { get; set; }

        public int DialogueId { get; set; }
        public Dialogue Dialogue { get; set; }
        public DialogueOptionType DialogueOptionType { get; set; }
    }
}
