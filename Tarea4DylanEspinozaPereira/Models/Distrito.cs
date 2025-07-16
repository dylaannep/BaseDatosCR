using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea4DylanEspinozaPereira.Models
{
    public class Distrito
    {
        // Clave primaria
        [Key]
        public int DistritoPK { get; set; }
        // Nombre del distrito
        public string Nombre { get; set; }
        // Clave foránea al cantón
        public int CantonFK { get; set; }

        [ForeignKey("CantonFK")]
        public Canton Canton { get; set; }
    }
}

