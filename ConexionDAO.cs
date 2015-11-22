using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ClasificacionLibros.DAO
{
    public class Conexion
    {
        MySqlConnection con;
        public Conexion()
        {
        }
        public MySqlConnection establecerConexion()
        {
            string cs = "Server=localhost;User ID=root;Persist Security Info=true; password=toor; Database=yucatracho";
            con = new MySqlConnection(cs);
            return con;
        }
        public MySqlConnection establecerConexion(string conexionString)
        {
            string cs = conexionString;
            con = new MySqlConnection(cs);
            return con;
        }
        public void abrirConexion()
        {
            con.Open();
        }
        public void cerrarConexion()
        {
            con.Close();
        }
    }
}
