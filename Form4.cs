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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Trasporte t = new Trasporte();//CLASE TRASPORTE CREO UN OBJETO
            DataTable tabla = t.totalLitros();//UTILIZO LA FUNCION LITROS
            Grilla.DataSource = tabla;//LO MUESTRO EN LA TABLA
        }
    }
}
