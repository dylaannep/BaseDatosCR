using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea4DylanEspinozaPereira.Models
{
    public class Canton
    {
        //Prueba commit
        // Clave primaria
        [Key]
        // Clave foránea a la provincia
        public int CantonPK { get; set; }
        // Nombre del cantón
        public string Nombre { get; set; }
        // Clave foránea a la provincia
        public int ProvinciaFK { get; set; }

        [ForeignKey("ProvinciaFK")]
        public Provincia Provincia { get; set; }

        // Relación 1:N con Distritos
        public ICollection<Distrito> Distritos { get; set; }
    }
}

