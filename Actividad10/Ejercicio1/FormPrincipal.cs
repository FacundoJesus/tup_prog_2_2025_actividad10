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
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if(solSeleccionada != null)
            {
                lbSolicitudSeleccionada.Text = solSeleccionada.ToString();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una solicitud de la lista.");
            }
        }
    }
}
