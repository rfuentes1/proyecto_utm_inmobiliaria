using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InmobiliariaArrow.Entities
{
    [Table("tipo_propiedad")]
    public class TipoPropiedad
    {
        [Key]
        [Column("id_tipo_propiedad")]
        public int IdTipoPropiedad { get; set; }
        public string Nombre { get; set; }
    }
}