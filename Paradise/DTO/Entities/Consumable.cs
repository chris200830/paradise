using System.ComponentModel.DataAnnotations.Schema;
using DTO.Interfaces;

namespace DTO.Entities
{
    [Table("consumables")]
    public class Consumable : InteractiveObject, IItem
    {

    }
}
