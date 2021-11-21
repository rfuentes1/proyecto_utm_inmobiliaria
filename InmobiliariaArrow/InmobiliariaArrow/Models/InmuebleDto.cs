using System;
namespace InmobiliariaArrow.Models
{
    public class InmuebleDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public Boolean EstaDisponible { get; set; }
        public string Operacion { get; set; }
        public int IdTipoPropiedad { get; set; }
        public string NumBanios { get; set; }
        public string NumRecamaras { get; set; }
        public Decimal Superficie { get; set; }
        
        public string VistaPreviaFoto { get; set; }
        public string Direccion { get; set; }
    }

}
