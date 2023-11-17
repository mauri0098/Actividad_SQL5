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
    internal class Trasporte
    {
        // Declaración de variables de la clase Trasporte
        SQLiteCommand Comando; // Objeto para ejecutar comandos SQL
        SQLiteConnection Conector; // Objeto para la conexión a la base de datos
        string sql; // Variable para almacenar consultas SQL
        DataTable tabla; // Objeto para almacenar datos en forma de tabla

        // Constructor de la clase Trasporte
        public Trasporte()
        {
            // Configuración de la conexión a la base de datos TRANSPORTE.db
            Conector = new SQLiteConnection("Data Source=TRANSPORTE.db;");
            Comando = new SQLiteCommand(); // Inicialización del objeto Comando
            sql = ""; // Inicialización de la variable para consultas SQL
        }

        // Método para buscar litros en la tabla Combustible según los parámetros aa, mm y chofer
        public int Buscar2(int aa, int mm, int chofer)
        {
            Combustible c = new Combustible(); // Creación de una instancia de la clase Combustible
            int litros; // Variable para almacenar el valor de litros

            Conector.Open(); // Apertura de la conexión a la base de datos TRANSPORTE.db

            // Consulta SQL para buscar litros en la tabla Combustible según los parámetros
            sql = $"SELECT litros FROM Combustible WHERE aa={aa} AND mm={mm} AND chofer={chofer}";

            Comando.Connection = Conector; // Asignación de la conexión al objeto Comando
            Comando.CommandType = CommandType.Text; // Establecimiento del tipo de comando como texto
            Comando.CommandText = sql; // Asignación de la consulta SQL al objeto Comando

            SQLiteDataReader dr = Comando.ExecuteReader(); // Ejecución de la consulta y obtención de los resultados

            // Verificación de si existen filas en los resultados obtenidos
            if (dr.HasRows == true)
            {
                dr.Read(); // Lectura del primer registro
                litros = Convert.ToInt32(dr["litros"]); // Obtención del valor de litros
                return litros; // Retorno del valor de litros
            }

            Conector.Close(); // Cierre de la conexión a la base de datos
            return 0; // Retorno de 0 en caso de no encontrar resultados
        }


        public DataTable buscar(int aa, int mm, int chofer)
        {
            // Se crea un objeto DataTable para almacenar los resultados de la consulta
            DataTable tabla = new DataTable();

            // Se construye la consulta SQL para seleccionar 'litros' de la tabla 'Combustible'
            // Utiliza los parámetros aa, mm y chofer para filtrar los datos
            string sql = $"SELECT litros FROM Combustible WHERE aa={aa} AND mm={mm} AND chofer={chofer}";

            // Cadena de conexión que indica la ubicación de la base de datos SQLite
            string cadena = "Data Source=TRANSPORTE.db";

            // Se crea un adaptador de datos SQLiteDataAdapter para ejecutar la consulta SQL
            SQLiteDataAdapter ada = new SQLiteDataAdapter(sql, cadena);

            // Se llena el objeto DataTable 'tabla' con los resultados de la consulta
            ada.Fill(tabla);

            // Se devuelve el DataTable 'tabla' que contiene los valores de litros obtenidos de la consulta
            return tabla;
        }








        public void Grabar(int aa, int mm, int chofer, int litros)
        {
            string connectionString = "Data Source=TRANSPORTE.db";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = $"INSERT INTO Combustible (aa, mm, chofer, litros) VALUES(@aa, @mm, @chofer, @litros)";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@aa", aa);
                    command.Parameters.AddWithValue("@mm", mm);
                    command.Parameters.AddWithValue("@chofer", chofer);
                    command.Parameters.AddWithValue("@litros", litros);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        // Manejar el resultado según sea necesario
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Filas afectadas: " + rowsAffected);
                        }
                        else
                        {
                            Console.WriteLine("No se insertaron filas.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar datos: " + ex.Message);
                    }
                }
            }
        }

        public DataTable BuscarChofer(int chofer)
        {
            // Se crea un objeto DataTable para almacenar los resultados de la consulta
            DataTable tabla = new DataTable();

            // Se agregan columnas 'aa', 'mm' y 'litros' al objeto DataTable 'tabla'
            tabla.Columns.Add("aa");
            tabla.Columns.Add("mm");
            tabla.Columns.Add("litros");

            // Se abre la conexión a la base de datos
            Conector.Open();

            // Se construye la consulta SQL para seleccionar 'aa', 'mm' y 'litros' de la tabla 'Combustible'
            // Utiliza el parámetro 'chofer' para filtrar los datos por un chofer específico
            sql = $"SELECT aa, mm, litros FROM Combustible WHERE chofer={chofer}";

            // Se configura el comando con la conexión, tipo de comando y consulta SQL
            Comando.Connection = Conector;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = sql;

            // Se ejecuta el comando y se obtiene un SQLiteDataReader con los resultados de la consulta
            SQLiteDataReader dr = Comando.ExecuteReader();

            // Se itera a través de los resultados obtenidos y se agregan al DataTable 'tabla'
            foreach (var f in dr)
            {
                tabla.Rows.Add(dr["aa"], dr["mm"], dr["litros"]);
            }

            // Se cierra la conexión a la base de datos
            Conector.Close();

            // Se devuelve el DataTable 'tabla' que contiene los valores 'aa', 'mm' y 'litros' del chofer
            return tabla;
        }


        public DataTable Choferes()
        {
            // Se crea un objeto DataTable para almacenar los resultados de la consulta
            tabla = new DataTable();

            // Se agregan columnas 'chofer' y 'nombre' al objeto DataTable 'tabla'
            tabla.Columns.Add("chofer");
            tabla.Columns.Add("nombre");

            // Se abre la conexión a la base de datos
            Conector.Open();

            // Se construye la consulta SQL para seleccionar todas las columnas de la tabla 'Choferes'
            sql = "SELECT * FROM Choferes";

            // Se configura el comando con la conexión, tipo de comando y consulta SQL
            Comando.Connection = Conector;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = sql;

            // Se ejecuta el comando y se obtiene un SQLiteDataReader con los resultados de la consulta
            SQLiteDataReader dr = Comando.ExecuteReader();

            // Se itera a través de los resultados obtenidos y se agregan al DataTable 'tabla'
            foreach (var f in dr)
            {
                tabla.Rows.Add(dr["chofer"], dr["nombre"]);
            }

            // Se cierra la conexión a la base de datos
            Conector.Close();

            // Se devuelve el DataTable 'tabla' que contiene los valores 'chofer' y 'nombre' de la tabla 'Choferes'
            return tabla;
        }



        public DataTable totalLitros()//acumulo los litros
        {
            tabla = new DataTable();
            tabla.Columns.Add("AA");
            tabla.Columns.Add("Litros");
            Conector.Open();

            sql = "SELECT aa, SUM(litros) AS litros FROM Combustible GROUP BY aa";
            Comando.Connection = Conector;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = sql;

            SQLiteDataReader dr = Comando.ExecuteReader();
            foreach (var f in dr)
            {
                tabla.Rows.Add(dr["aa"], dr["litros"]);
            }
            Conector.Close();
            return tabla;
        }







    }
}
