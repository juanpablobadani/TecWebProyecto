using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalTecWeb.Data.Entities
{
    public class RoomEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public virtual IEnumerable<GuestEntity> Guests { get; set; }

    }
}
