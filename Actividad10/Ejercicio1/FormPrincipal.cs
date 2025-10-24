using Ejercicio1.Models;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Authentication.ExtendedProtection;

namespace Ejercicio1
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        #region Defino e instancio la clase CentroDeAtencion (Servicio/Sistema)
        CentroDeAtencion centro = new CentroDeAtencion();
        #endregion

        #region ACTUALIZAR LISTBOX DE SOLICITUDES PENDIENTES
        protected void VerSolicitudesPendientes()
        {
            lsbVerSolicitudesImportadas.Items.Clear();

            LinkedListNode<Solicitud> nodo = centro.GetSolicitudPendiente();

            while (nodo != null)
            {
                lsbVerSolicitudesImportadas.Items.Add(nodo.Value);
                nodo = nodo.Next;
            }
        }
        #endregion

        #region ACTUALIZAR LISTBOX DE SOLICITUDES A ATENDER
        protected void VerSolicitudesAAtender()
        {
            lsbColaSolicitudesAAtender.Items.Clear();

            lsbColaSolicitudesAAtender.Items.AddRange(centro.VerDescripcionColaAtencion());
        }
        #endregion

        #region ACTUALIZAR LISTBOX DE HISTORIAL DE RESOLUCIONES
        protected void VerHitorialResoluciones()
        {
            lsbHistorialResoluciones.Items.Clear();

            lsbHistorialResoluciones.Items.AddRange(centro.VerDescripcionPilaHistorica());
        }
        #endregion


        private void btnImportarSolicitudes_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(csv)|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                FileStream fs = null;
                try
                {
                    fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    centro.ImportarCSVSolicitudesEntrantes(fs);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR AL IMPORTAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (fs != null) fs.Close();
                }

                VerSolicitudesPendientes();
            }
        }
        private void btnConfirmarAtencion_Click(object sender, EventArgs e)
        {
            Solicitud solSeleccionada = lsbVerSolicitudesImportadas.SelectedItem as Solicitud;
            if (solSeleccionada != null)
            {
                centro.Atender(solSeleccionada);
                VerSolicitudesPendientes();
                VerSolicitudesAAtender();

                lsbVerSolicitudesImportadas.SelectedItem = null;
                lbSolicitudSeleccionada.Text = solSeleccionada.ToString();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una solicitud de la lista.");
            }

        }

        private void lsbVerSolicitudesImportadas_SelectedValueChanged(object sender, EventArgs e)
        {
            Solicitud solSeleccionada = lsbVerSolicitudesImportadas.SelectedItem as Solicitud;
            if (solSeleccionada != null)
            {
                lbSolicitudSeleccionada.Text = solSeleccionada.ToString();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una solicitud de la lista.");
            }
        }

        private void btnResolverSolicitud_Click(object sender, EventArgs e)
        {
            
            centro.ResolverSolicitudEnEspera();

            VerSolicitudesAAtender();

            VerHitorialResoluciones();
        }

        private void btnExportarSolicitudes_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "(csv)|*.csv";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                FileStream fs = null;
                try
                {
                    fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write);
                    centro.ExportarCSVHistoriaDelResoluciones(fs);

                    MessageBox.Show("Exportado Satisfactoriamente!","Exportación",MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR AL EXPORTAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (fs != null) fs.Close();
                }
            }

        }


        #region SERIALIZACION Y DESERIALIZACION
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            FileStream fs = null;
            string path = "datos.dat";
            if(File.Exists(path))
            {
                try
                {
                    fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    #pragma warning disable SYSLIB0011
                    BinaryFormatter bf = new BinaryFormatter();
                    centro = bf.Deserialize(fs) as CentroDeAtencion;
                    #pragma warning restore SYSLIB0011
 
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.Message,"ERROR AL SERIALIZAR LOS DATOS",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }finally
                {
                    if (fs != null) fs.Close();
                }

                VerSolicitudesPendientes();
                VerSolicitudesAAtender();
                VerHitorialResoluciones();
            } 
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fs = null;
            string path = "datos.dat";
            try
            {
                fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                #pragma warning disable SYSLIB0011
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs,centro);
                #pragma warning restore SYSLIB0011
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR AL DESERIALIZAR LOS DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }
        #endregion
    }
}
