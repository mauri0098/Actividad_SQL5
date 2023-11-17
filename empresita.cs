using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Actividad_SQL5
{
    internal class empresita
    {
        // Método que devuelve un DataTable con los empleados filtrados por SectorID
        public DataTable Empleado(int SectorID)
        {
            // Crear un objeto DataTable para almacenar los resultados de la consulta
            DataTable tabla = new DataTable();

            // Construir la consulta SQL para seleccionar EmpleadoID y Nombre de la tabla Empleados
            // Se filtra por el SectorID recibido como parámetro
            string sql = $"SELECT EmpleadoID, Nombre FROM Empleados Where SectorID = {SectorID}";

            // Cadena de conexión que indica la ubicación de la base de datos SQLite
            string cadena = "Data Source=Empresita.db";

            // Crear un adaptador de datos SQLiteDataAdapter para ejecutar la consulta SQL
            // y llenar el DataTable con los resultados
            SQLiteDataAdapter ada = new SQLiteDataAdapter(sql, cadena);
            ada.Fill(tabla); // Llenar el DataTable con los resultados de la consulta

            // Retornar el DataTable con los empleados filtrados por SectorID
            return tabla;
        }

        // Método que devuelve un DataTable con todos los datos de la tabla Sectores
        public DataTable getdata()
        {
            // Crear un objeto DataTable para almacenar los resultados de la consulta
            DataTable tabla = new DataTable();

            // Consulta SQL para seleccionar todos los datos de la tabla Sectores
            string sql = "SELECT * FROM Sectores";

            // Cadena de conexión que indica la ubicación de la base de datos SQLite
            string cadena = "Data Source=Empresita.db";

            // Crear un adaptador de datos SQLiteDataAdapter para ejecutar la consulta SQL
            // y llenar el DataTable con los resultados
            SQLiteDataAdapter ada = new SQLiteDataAdapter(sql, cadena);
            ada.Fill(tabla); // Llenar el DataTable con los resultados de la consulta

            // Retornar el DataTable con todos los datos de la tabla Sectores
            return tabla;
        }
    }




}
