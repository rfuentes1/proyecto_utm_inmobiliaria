using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InmobiliariaArrow.Entities
{
    [Table("Administrador")]
    public class Administrador
    {
        [Key]
        [Column("id_admin")]
        public int IdAdmin { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}