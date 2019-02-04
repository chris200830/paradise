using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DTO.Entities.Enums;

namespace DTO.Entities
{
    [Table("dialogues")]
    public class Dialogue
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("dialogue_text")]
        public string DialogueText { get; set; }

        [Column("dialogue_reply_id")]
        public int DialogueReplyId { get; set; }
        [ForeignKey("DialogueReplyId")]
        public Dialogue DialogueReply { get; set; }
        [InverseProperty("DialogueReply")]
        public virtual ICollection<Dialogue> DialogueReplies { get; set; }

        [Column("next_dialogue_id")]
        public int NextDialogueId { get; set; }
        [ForeignKey("NextDialogueId")]
        public virtual Dialogue NextDialogue { get; set; }

        [Column("dialogue_character_id")]
        public int DialogueCharacterId { get; set; }
        [ForeignKey("DialogueCharacterId")]
        public virtual Character DialogueCharacter { get; set; }

        [Column("dialogue_option_type")]
        public DialogueOptionType DialogueOptionType { get; set; }

        public override string ToString()
        {
            return Id + ": " + DialogueText;
        }
    }
}
