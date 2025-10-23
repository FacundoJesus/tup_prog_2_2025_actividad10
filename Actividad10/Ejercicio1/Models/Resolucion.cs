using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Resolucion:IExportable
    {
        public string Descripcion { get; set; }

        public Solicitud Solicitud;

        public Resolucion(string descripcion, Solicitud solicitud)
        {
            this.Descripcion = descripcion;
            this.Solicitud = solicitud;
        }

        public string Exportar()
        {
            throw new NotImplementedException();
        }

        public void Importar(string datos)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"";
        }
    }
}
