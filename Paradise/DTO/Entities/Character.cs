using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    public class Character
    {
        public int CharacterId { get; set; }

        public int CharacterRoomId { get; set; }
        public Room CharacterRoom { get; set; }

        public string Name { get; set; }

        public Character()
        {

        }

        public Character(string name)
        {
            name = Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
