using Ejercicio1.Models;

namespace Ejercicio1
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        CentroDeAtencion centro = new CentroDeAtencion();

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

        protected void VerSolicitudesAAtender()
        {
            lsbColaSolicitudesAAtender.Items.Clear();

            lsbColaSolicitudesAAtender.Items.AddRange(centro.VerDescripcionColaAtencion());
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

        protected void VerHitorialResoluciones()
        {
            lsbHistorialResoluciones.Items.Clear();

            lsbHistorialResoluciones.Items.AddRange(centro.VerDescripcionPilaHistorica());
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

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            //DESERALIZAR
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SERIALIZAR
        }
    }
}
