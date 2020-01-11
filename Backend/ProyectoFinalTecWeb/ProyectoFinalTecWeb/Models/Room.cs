using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalTecWeb.Models
{
    public class Room
    {
        [Required]
        public int Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }
        public IEnumerable<Guest> guests { get; set; }
    }
}
