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
        private LinkedList<Solicitud> solicitudesPendientes = new LinkedList<Solicitud>();

        private Queue<Solicitud> colaDeAtencion = new Queue<Solicitud> ();
        private Stack<Resolucion> pilaHistorica = new Stack<Resolucion> (); 


        public void ImportarCSVSolicitudesEntrantes(FileStream fs)
        {
            StreamReader sr = new StreamReader(fs);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string linea = sr.ReadLine();
                Solicitud solicitud = new Solicitud();
                solicitud.Importar(linea);

                solicitudesPendientes.AddLast(solicitud);
            }
            sr.Close();
        }

        public void Atender(Solicitud solicitud)
        {
            if (solicitudesPendientes.Remove(solicitud)== true) colaDeAtencion.Enqueue(solicitud);         
        }

        public string ExportarCSVHistoriaDelResoluciones(FileStream fs)
        {
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Numero;Motivo");
            string linea="";
            foreach(Solicitud s in colaDeAtencion)
            {
                linea = s.Exportar();
                return linea;
            }
            return linea;
        }

        public LinkedListNode<Solicitud> GetSolicitudPendiente()
        {
            return solicitudesPendientes.First;
        }

        public string[] VerDescripcionColaAtencion()
        {
            string[] descripcion = new string[colaDeAtencion.Count];

            int i = 0;
            foreach(Solicitud s in colaDeAtencion)
            {
                descripcion[i++] = s.ToString();
            }
            return descripcion;

        }







    }
}
