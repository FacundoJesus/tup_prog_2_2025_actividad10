using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    [Serializable]
    public class Solicitud:IExportable
    {
        public int Numero { get; set;}
        public string Motivo { get; set;}

        public Solicitud() { }
        public Solicitud(int numero, string motivo)
        {
            this.Numero = numero;
            this.Motivo = motivo;
        }

        public string Exportar()
        {
            return $"{this.Numero};{this.Motivo}";
        }

        public void Importar(string datos)
        {
            string[] splitResult = datos.Split(';');
            this.Numero = Convert.ToInt32(splitResult[0]);
            this.Motivo = splitResult[1];
        }

        public override string ToString()
        {
            return $"{this.Numero}({this.Motivo})";
        }
    }
}
