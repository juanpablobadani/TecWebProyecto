using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalTecWeb.Data.Entities
{
    public class GuestEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Ci { get; set; }
        [Required]
        public string Gender { get; set; }

        [ForeignKey("RoomId")]
        public virtual RoomEntity Room { get; set; }

    }
}
