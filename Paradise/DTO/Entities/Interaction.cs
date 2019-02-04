using System.ComponentModel.DataAnnotations.Schema;
using DTO.Entities.Enums;

namespace DTO.Entities
{
    [Table("interactions")]
    public class Interaction
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("interaction_text")]
        public string InteractionText { get; set; }

        [Column("interactive_object_id")]
        public int InteractiveObjectId { get; set; }
        [ForeignKey("InteractiveObjectId")]
        public virtual InteractiveObject InteractiveObject { get; set; }
    }
}
