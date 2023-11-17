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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando cambia la selección en el ComboBox...

            empresita em = new empresita(); // Se crea una instancia de la clase empresita
                                            // Se llama al método Empleado con el SectorID seleccionado del ComboBox
            DataTable Empleados = em.Empleado(Convert.ToInt32(comboBox1.SelectedValue));
            dataGridView1.DataSource = Empleados; // Se asigna el DataTable al DataGridVie


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Al cargar el formulario...

            empresita em = new empresita(); // Se crea una instancia de la clase empresita
            DataTable tabla = em.getdata(); // Se llama al método getdata para obtener datos

            // Configuración del ComboBox para mostrar datos del DataTable obtenido
            comboBox1.DisplayMember = "Nombre"; // Muestra el campo Nombre en el ComboBox
            comboBox1.ValueMember = "SectorID"; // Usa el campo SectorID como valor del ComboBox
            comboBox1.DataSource = tabla; // Establece los datos del DataTable en el ComboBox
            comboBox1.SelectedIndex = -1; // Desmarca la selección del ComboBox al inicio

        }



    }
}
