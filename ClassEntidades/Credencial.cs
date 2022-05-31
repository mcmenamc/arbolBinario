using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidades
{
    public class Credencial
    {
        public string Curp { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public int Seccion { get; set; }
        public int Vigencia { get; set; }

        public string Mostrar()
        {
            return "Credencial-> Curp: " + this.Curp + 
                " Nombre: " + this.Nombre + 
                " Domicilio: " + this.Domicilio + 
                " Estado: " + this.Estado + 
                " Municipio: " + this.Municipio + 
                " Sección: " + this.Seccion + 
                " Vigencia: " + this.Vigencia;
        }
    }
}
