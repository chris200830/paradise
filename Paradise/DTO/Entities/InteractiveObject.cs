using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Entities
{
    [Table("interactive_objects")]
    public class InteractiveObject
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("interactive_object_room_id")]
        public int InteractiveObjectRoomId { get; set; }
        [ForeignKey("InteractiveObjectRoomId")]
        public virtual Room InteractiveObjectRoom { get; set; }

        [InverseProperty("InteractiveObject")]
        public virtual ICollection<Interaction> Interactions { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
