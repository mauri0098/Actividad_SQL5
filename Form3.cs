using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad_SQL5
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Instancia de la clase 'Trasporte'
            Trasporte t = new Trasporte();

            // Se obtiene un DataTable con los datos de los choferes
            DataTable tabla = t.Choferes();

            // Configuración del ComboBox 'cboChofer'
            cboChofer.ValueMember = "chofer"; // La columna 'chofer' será el valor
            cboChofer.DisplayMember = "nombre"; // La columna 'nombre' será mostrada al usuario
            cboChofer.DataSource = tabla; // Asignación de los datos al ComboBox
        }

        private void cboChofer_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Instancia de la clase 'Trasporte'
            Trasporte t = new Trasporte();

            // Se obtiene el valor seleccionado del ComboBox (ID del chofer)
            int idChofer = Convert.ToInt32(cboChofer.SelectedValue);

            // Se obtienen los detalles del chofer seleccionado en un DataTable
            DataTable tabla = t.BuscarChofer(idChofer);

            // Los detalles del chofer se muestran en el DataGridView 'Grilla'
            Grilla.DataSource = tabla;
        }
    }
}
