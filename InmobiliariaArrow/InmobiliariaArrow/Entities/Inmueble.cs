﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InmobiliariaArrow.Entities
{
    [Table("Inmueble")]
    public class Inmueble
    {
        [Key]
        public int IdInmueble { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Decimal Precio { get; set; }
        [Column("esta_disponible")]
        public Boolean EstaDisponible { get; set; }
        public string Operacion { get; set; }
        [Column("id_tipo_propiedad")]
        public int IdTipoPropiedad { get; set; }
        [Column("num_banios")]
        public string NumBanios { get; set; }
        [Column("num_recamaras")]
        public string NumRecamaras { get; set; }
        public string Superficie { get; set; }

    }
   
}
