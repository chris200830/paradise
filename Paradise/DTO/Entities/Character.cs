using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Entities
{
    [Table("characters")]
    public class Character : InteractiveObject
    {
        [InverseProperty("DialogueCharacter")]
        public virtual ICollection<Dialogue> CharacterDialogues { get; set; }
    }
}
