using System;
using InmobiliariaArrow.Models;

namespace InmobiliariaArrow.Models
{
    public class InmuebleTemp
    {
        public int Id {get; set; }
        public string Inmueble {get; set;}
        public decimal Precio {get; set; }
        public string Descripcion {get; set; }
        public string Estatus {get; set; }
        public string Tipo_vivienda {get; set; }
    }
}