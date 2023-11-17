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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Trasporte t = new Trasporte();
            string nombre = t.Chofer(int.Parse(txtChofer.Text));

            if (nombre == "")
            {
                MessageBox.Show("El chofer no existe");
            }
            else
            {
                txtNombre.Text = nombre;

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Trasporte t = new Trasporte();
            t.modificar(txtNombre.Text, int.Parse(txtChofer.Text));
        }
    }
}
