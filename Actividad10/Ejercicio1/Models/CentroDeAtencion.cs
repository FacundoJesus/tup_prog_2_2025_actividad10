using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    
    [Serializable]
    public class CentroDeAtencion
    {
        private LinkedList<Solicitud> solicitudesEntrantes = new LinkedList<Solicitud>();
        public void ImportarCSVSolicitudesEntrantes(FileStream fs)
        {
            StreamReader sr = new StreamReader(fs);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string linea = sr.ReadLine();
                Solicitud solicitud = new Solicitud();
                solicitud.Importar(linea);

                solicitudesEntrantes.AddLast(solicitud);
            }
            sr.Close();
        }

        public string ExportarCSVHistoriaDelResoluciones(FileStream fs)
        {
            return $"";
        }

        public LinkedListNode<Solicitud> GetSolicitudPendiente()
        {
            return solicitudesEntrantes.First;
        }

        public void Atender(Solicitud solicitud)
        {

        }

        public string[] VerDescripcionColaAtencion()
        {
            return null;
        }
    }
}
