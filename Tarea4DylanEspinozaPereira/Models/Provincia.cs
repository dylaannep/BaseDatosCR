using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea4DylanEspinozaPereira.Models
{
    public class Provincia {
        // Clave primaria
        [Key]
        // Clave primaria de la provincia
        public int ProvinciaPK { get; set; }

        // Nombre de la provincia
        public string Nombre { get; set; }

        // Relación 1:N con Cantones
        public ICollection<Canton> Cantones { get; set; }
    }
}

