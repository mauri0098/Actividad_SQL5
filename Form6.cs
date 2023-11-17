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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Grila.Rows.Clear();
            Trasporte t = new Trasporte();
            DataTable tabla = t.totalLitros2();

            foreach (DataRow f in tabla.Rows)
            {
                int chofer = Convert.ToInt32(f["Chofer"]);
                string nombre = t.Chofer(chofer);
                if (nombre != "")
                {
                    Grila.Rows.Add(nombre, f["AA"], f["Total litros"]);

                }
            }
        }
    }
}
