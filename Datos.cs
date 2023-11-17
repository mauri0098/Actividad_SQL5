using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Actividad_SQL5
{
    internal class Datos
    {
        SQLiteCommand comando;
        SQLiteConnection conector;
        SQLiteDataAdapter adaptador;
        string sql;
        DataTable tabla;

        public Datos()
        {
            conector = new SQLiteConnection("Data Source=Empresita.db;");
            comando = new SQLiteCommand();
            //adaptador = new SQLiteDataAdapter(comando);
            sql = "";
        }


        public DataTable getData()
        {
            tabla = new DataTable();
            tabla.Columns.Add("SectorID");
            tabla.Columns.Add("Nombre");
            conector.Open();
            sql = "SELECT * FROM Sectores";

            comando.Connection = conector;
            comando.CommandType = CommandType.Text;
            comando.CommandText = sql;

            //adaptador.Fill(tabla);

            SQLiteDataReader dr = comando.ExecuteReader();
            //while (dr.HasRows == true && dr != null)
            //{

            //    dr.Read();
            //    if (true)
            //    {

            //    }
            //    int ID = int.Parse(dr["SectorID"].ToString());
            //    string Nombre = (dr["Nombre"].ToString());
            //    tabla.Rows.Add(ID, Nombre);
            //}
            //tabla = dr.GetValues();

            foreach (var f in dr)
            {
                int ID = int.Parse(dr["SectorID"].ToString());
                string Nombre = (dr["Nombre"].ToString());
                tabla.Rows.Add(dr["SectorID"], dr["Nombre"]);
            }
            conector.Close();
            return tabla;
        }

        public DataTable Empleados(int SectorID)
        {
            tabla = new DataTable();
            tabla.Columns.Add("EmpleadoID");
            tabla.Columns.Add("Nombre");
            conector.Open();
            sql = $"SELECT EmpleadoID, Nombre FROM Empleados Where SectorID = {SectorID}";

            comando.Connection = conector;
            comando.CommandType = CommandType.Text;
            comando.CommandText = sql;
            SQLiteDataReader dr = comando.ExecuteReader();

            foreach (var f in dr)
            {
                tabla.Rows.Add(dr["EmpleadoID"], dr["Nombre"]);
            }
            conector.Close();
            return tabla;
        }



    }
}
