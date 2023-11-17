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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Crear una instancia de la clase Trasporte
            Trasporte trasporte = new Trasporte();

            // Crear un DataTable para almacenar los resultados de la búsqueda
            DataTable dt = new DataTable();

            // Obtener los valores de los controles txtAño, cboMes y txtChofer
            int aa = int.Parse(txtAño.Text);
            int mm = cboMes.SelectedIndex + 1;
            int chofer = Convert.ToInt32(txtChofer.Text);

            // Realizar la búsqueda con los valores obtenidos
            dt = trasporte.buscar(aa, mm, chofer);

            // Recorrer el resultado y asignar el valor de "litros" a txtLitros.Text
            foreach (DataRow D in dt.Rows)
            {
                txtLitros.Text = D["litros"].ToString();
            }




        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtAño.Text, out int aa) && int.TryParse(txtLitros.Text, out int litros) && cboMes.SelectedIndex != -1)
            {
                int mm = cboMes.SelectedIndex + 1;

                // Supongo que txtChofer es un control TextBox que contiene el ID del chofer
                if (int.TryParse(txtChofer.Text, out int chofer))
                {
                    Trasporte t = new Trasporte();
                    t.Grabar(aa, mm, chofer, litros);
                }
                else
                {
                    MessageBox.Show("El valor del chofer no es válido.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese valores válidos para el año, mes y litros.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Crear instancias de las clases Combustible y Trasporte
            Combustible c = new Combustible();
            Trasporte t = new Trasporte();

            // Obtener los valores de los controles txtAño, cboMes y txtChofer
            int aa = int.Parse(txtAño.Text);
            int mm = cboMes.SelectedIndex + 1;
            int chofer = Convert.ToInt32(txtChofer.Text);

            // Llamar al método Buscar2 de la clase Trasporte con los valores obtenidos
            int litros = t.Buscar2(aa, mm, chofer);

            // Verificar si se encontró la información
            if (litros == 0)
            {
                MessageBox.Show("No existe");
            }
            else
            {
                // Mostrar el valor encontrado en txtLitros
                txtLitros.Text = litros.ToString();
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
