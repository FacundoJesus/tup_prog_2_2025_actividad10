using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{

    [Serializable]
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
            return $"{this.Descripcion};{this.Solicitud.Numero};{this.Solicitud.Motivo}";
        }

        public void Importar(string datos)
        {
            string[] splitResult = datos.Split(';');

            this.Descripcion = splitResult[0].Trim();
            this.Solicitud.Numero = Convert.ToInt32(splitResult[1].Trim());
            this.Solicitud.Motivo = splitResult[2].Trim();
        }

        public override string ToString()
        {
            return $"Resol. Nro: {this.Solicitud.Numero} - Motivo: {this.Solicitud.Motivo} - Descrip.: {this.Descripcion}";

        }
    }
}
