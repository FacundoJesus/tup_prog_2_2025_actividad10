namespace Ejercicio1
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnResolverSolicitud = new Button();
            lsbColaSolicitudesAAtender = new ListBox();
            label3 = new Label();
            lbSolicitudSeleccionada = new Label();
            btnConfirmarAtencion = new Button();
            lsbVerSolicitudesImportadas = new ListBox();
            label1 = new Label();
            btnImportarSolicitudes = new Button();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            groupBox2 = new GroupBox();
            lsbHistorialResoluciones = new ListBox();
            btnExportarSolicitudes = new Button();
            label4 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnResolverSolicitud);
            groupBox1.Controls.Add(lsbColaSolicitudesAAtender);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lbSolicitudSeleccionada);
            groupBox1.Controls.Add(btnConfirmarAtencion);
            groupBox1.Controls.Add(lsbVerSolicitudesImportadas);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnImportarSolicitudes);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(769, 292);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Atencion de Solicitudes";
            // 
            // btnResolverSolicitud
            // 
            btnResolverSolicitud.Location = new Point(622, 205);
            btnResolverSolicitud.Name = "btnResolverSolicitud";
            btnResolverSolicitud.Size = new Size(136, 74);
            btnResolverSolicitud.TabIndex = 7;
            btnResolverSolicitud.Text = "Resolver Solicitud";
            btnResolverSolicitud.UseVisualStyleBackColor = true;
            btnResolverSolicitud.Click += btnResolverSolicitud_Click;
            // 
            // lsbColaSolicitudesAAtender
            // 
            lsbColaSolicitudesAAtender.FormattingEnabled = true;
            lsbColaSolicitudesAAtender.HorizontalScrollbar = true;
            lsbColaSolicitudesAAtender.ItemHeight = 15;
            lsbColaSolicitudesAAtender.Location = new Point(385, 112);
            lsbColaSolicitudesAAtender.Name = "lsbColaSolicitudesAAtender";
            lsbColaSolicitudesAAtender.ScrollAlwaysVisible = true;
            lsbColaSolicitudesAAtender.Size = new Size(231, 169);
            lsbColaSolicitudesAAtender.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(377, 92);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 5;
            label3.Text = "Cola de Atención";
            // 
            // lbSolicitudSeleccionada
            // 
            lbSolicitudSeleccionada.BackColor = SystemColors.ActiveBorder;
            lbSolicitudSeleccionada.Location = new Point(243, 112);
            lbSolicitudSeleccionada.Name = "lbSolicitudSeleccionada";
            lbSolicitudSeleccionada.Size = new Size(136, 91);
            lbSolicitudSeleccionada.TabIndex = 4;
            lbSolicitudSeleccionada.Text = "Seleccione desde la Lista";
            // 
            // btnConfirmarAtencion
            // 
            btnConfirmarAtencion.Location = new Point(243, 206);
            btnConfirmarAtencion.Name = "btnConfirmarAtencion";
            btnConfirmarAtencion.Size = new Size(136, 74);
            btnConfirmarAtencion.TabIndex = 3;
            btnConfirmarAtencion.Text = "Confirmar Seleccion hacia Cola de Atención";
            btnConfirmarAtencion.UseVisualStyleBackColor = true;
            btnConfirmarAtencion.Click += btnConfirmarAtencion_Click;
            // 
            // lsbVerSolicitudesImportadas
            // 
            lsbVerSolicitudesImportadas.FormattingEnabled = true;
            lsbVerSolicitudesImportadas.HorizontalScrollbar = true;
            lsbVerSolicitudesImportadas.ItemHeight = 15;
            lsbVerSolicitudesImportadas.Location = new Point(6, 110);
            lsbVerSolicitudesImportadas.Name = "lsbVerSolicitudesImportadas";
            lsbVerSolicitudesImportadas.ScrollAlwaysVisible = true;
            lsbVerSolicitudesImportadas.Size = new Size(231, 169);
            lsbVerSolicitudesImportadas.TabIndex = 2;
            lsbVerSolicitudesImportadas.SelectedValueChanged += lsbVerSolicitudesImportadas_SelectedValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 92);
            label1.Name = "label1";
            label1.Size = new Size(159, 15);
            label1.TabIndex = 1;
            label1.Text = "Lista de Solicitudes Entrantes";
            // 
            // btnImportarSolicitudes
            // 
            btnImportarSolicitudes.Location = new Point(6, 31);
            btnImportarSolicitudes.Name = "btnImportarSolicitudes";
            btnImportarSolicitudes.Size = new Size(231, 43);
            btnImportarSolicitudes.TabIndex = 0;
            btnImportarSolicitudes.Text = "Importar Solicitudes";
            btnImportarSolicitudes.UseVisualStyleBackColor = true;
            btnImportarSolicitudes.Click += btnImportarSolicitudes_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lsbHistorialResoluciones);
            groupBox2.Controls.Add(btnExportarSolicitudes);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(787, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(445, 292);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Historial de Resoluciones";
            // 
            // lsbHistorialResoluciones
            // 
            lsbHistorialResoluciones.FormattingEnabled = true;
            lsbHistorialResoluciones.HorizontalScrollbar = true;
            lsbHistorialResoluciones.ItemHeight = 15;
            lsbHistorialResoluciones.Location = new Point(6, 110);
            lsbHistorialResoluciones.Name = "lsbHistorialResoluciones";
            lsbHistorialResoluciones.ScrollAlwaysVisible = true;
            lsbHistorialResoluciones.Size = new Size(433, 169);
            lsbHistorialResoluciones.TabIndex = 8;
            // 
            // btnExportarSolicitudes
            // 
            btnExportarSolicitudes.Location = new Point(6, 31);
            btnExportarSolicitudes.Name = "btnExportarSolicitudes";
            btnExportarSolicitudes.Size = new Size(87, 43);
            btnExportarSolicitudes.TabIndex = 7;
            btnExportarSolicitudes.Text = "Exportar Solicitudes";
            btnExportarSolicitudes.UseVisualStyleBackColor = true;
            btnExportarSolicitudes.Click += btnExportarSolicitudes_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 92);
            label4.Name = "label4";
            label4.Size = new Size(117, 15);
            label4.TabIndex = 7;
            label4.Text = "Pila de Resoluciones:";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1244, 317);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Actividad 10";
            FormClosing += FormPrincipal_FormClosing;
            Load += FormPrincipal_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnImportarSolicitudes;
        private ListBox lsbVerSolicitudesImportadas;
        private Label label1;
        private Button btnConfirmarAtencion;
        private ListBox lsbColaSolicitudesAAtender;
        private Label label3;
        private Label lbSolicitudSeleccionada;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private GroupBox groupBox2;
        private ListBox lsbHistorialResoluciones;
        private Button btnExportarSolicitudes;
        private Label label4;
        private Button btnResolverSolicitud;
    }
}
