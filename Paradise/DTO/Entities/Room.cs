using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DTO.Entities.Enums;

namespace DTO.Entities
{
    [Table("rooms")]
    public class Room
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("room_name")]
        public string RoomName { get; set; }

        [Column("room_description")]
        public string RoomDescription { get; set; }

        [InverseProperty("InteractiveObjectRoom")]
        public virtual ICollection<InteractiveObject> RoomInteractiveObjects { get; set; }

        [Column("room_up_id")]
        public int RoomUpId { get; set; }
        [ForeignKey("RoomUpId")]
        public virtual Room RoomUp { get; set; }

        [Column("room_right_id")]
        public int RoomRightId { get; set; }
        [ForeignKey("RoomRightId")]
        public virtual Room RoomRight { get; set; }

        [Column("room_down_id")]
        public int RoomDownId { get; set; }
        [ForeignKey("RoomDownId")]
        public virtual Room RoomDown { get; set; }

        [Column("room_left_id")]
        public int RoomLeftId { get; set; }
        [ForeignKey("RoomLeftId")]
        public virtual Room RoomLeft { get; set; }

        [Column("location")]
        public Location Location { get; set; }

        public override string ToString()
        {
            return RoomName;
        }
    }
}
