using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    public class Item
    {
        public int ItemId { get; set; }

        public string Name { get; set; }

        public int ItemRoomId { get; set; }
        public Room ItemRoom { get; set; }

        public Item()
        {

        }

        public Item(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
