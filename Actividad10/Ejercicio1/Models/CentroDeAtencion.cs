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

        public void ExportarCSVHistoriaDelResoluciones(FileStream fs)
        {
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Descripción Resolución;Número de Solicitud;Descripción Solicitud");
          
            foreach(Resolucion res in pilaHistorica)
            {
                sw.WriteLine(res.Exportar());
            }
            sw.Close();

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
        
        public void ResolverSolicitudEnEspera()
        {
            if(colaDeAtencion.Count > 0)
            {
                Solicitud solicitud = colaDeAtencion.Dequeue();
                string descripcion = "Solucionado";
                Resolucion resolucion = new Resolucion(descripcion, solicitud);
                pilaHistorica.Push(resolucion);
            } 
        }

        public string[] VerDescripcionPilaHistorica()
        {
            string[] descripcion = new string[pilaHistorica.Count];
            int i = 0;
            foreach(Resolucion r in  pilaHistorica)
            {
                descripcion[i++] = r.ToString();
            }
            return descripcion;
        }
    }
}
