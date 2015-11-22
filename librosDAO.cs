/*
 * Created by SharpDevelop.
 * User: Mousepower
 * Date: 06/10/2014
 * Time: 10:07 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using ClasificacionLibros.BO;


namespace ClasificacionLibros.DAO
{

	public class librosDAO
	{
		
		Conexion con;
			DataSet dsLibros = null;
			string sql;
			MySqlCommand cmd;
			MySqlDataAdapter da;
		public librosDAO()
		{
				
		}
		public int devuelveMAxLibros()
		{
			int result;
			//preparamos la conexion
			cmd = new MySqlCommand();
			da = new MySqlDataAdapter();
			//Creamos la conexion
			con = new Conexion();
			//Establecemos la conexion
			cmd.Connection = con.establecerConexion();
			con.abrirConexion();
			//Declaramos nuestra sentencia select para que nos regrese el maximop de libros
			sql = "SELECT IFNULL(MAX(Codigo_lib),0) + 1 FROM Libros";
			cmd.CommandText = sql;
			result = Convert.ToInt32(cmd.ExecuteScalar().ToString());
			//con.cerrarConexion();
			return result;
			
		}
		//CREAR LIBROS
		
		public int creaLibros(object obj)
		{
			//convertimos nuestro objeto a tipo libros
			librosBO data = (librosBO) obj;
			//preparamos la conexion
			cmd = new MySqlCommand();
			da = new MySqlDataAdapter();
			//Creamos la conexion
			con = new Conexion();
			//Establecemos la conexion
			cmd.Connection = con.establecerConexion();
			con.abrirConexion();
			
			//Declaramos nuestra sentencia select
			sql = "INSERT INTO libros (`salon`,`categoria`,`familia`,`titulo`,`autor`,`editorial`,`fecha`,`ejemplar`) VALUES(" + data.Salon + ",'" + data.Categoria.Trim() + "','" + data.Familia.Trim() + "','" +data.Titulo.Trim() + "','" + data.Autor.Trim() + "','" + data.Editorial.Trim() + "','" + data.Fecha.Trim() + "','"+ data.Ejemplar.Trim() + "');";
			cmd.CommandText = sql;
            int i = Convert.ToInt32(cmd.ExecuteNonQuery().ToString());

            con.cerrarConexion();
            // validamos si se  insertó de manera correcta
            if(i <= 0)
                {
                return 0;
                }
            return 1;
            }
		
		
		//MODIFICA Libros

        public int modificaLibros(object obj)
            {
            // convertimos nuestro objeto a tipo  Libros 
            librosBO data = (librosBO) obj;
            // preparamos la conexion
            cmd = new MySqlCommand();
            dsLibros = new DataSet();
           
            da = new MySqlDataAdapter();
            con = new Conexion();
            // Establecemos la conexion
            cmd.Connection = con.establecerConexion();
            // Abrimos la conexion
            con.abrirConexion();

            // Declaramos nuestra sentencia select
            
            sql = "UPDATE libros SET salon='" + data.Salon + "',categoria='" + data.Categoria.Trim() + "',familia='" + data.Familia.Trim() + "',titulo='" + data.Titulo.Trim() + "',autor='" +data.Autor.Trim() + "',editorial='" +data.Editorial.Trim() + "',fecha='" +data.Fecha.Trim() + "',ejemplar='" + data.Ejemplar.Trim() +"'" +" WHERE codigo=" + Convert.ToString(data.Codigo).Trim();

            cmd.CommandText = sql;
            int i = cmd.ExecuteNonQuery();
            // validamos si se  modifico de manera correcta
            if(i <= 0)
                {
                return 0;
                }
            return 1;
            }





        //ELIMINA Libros

        public int eliminaLibros(object obj)
            {
            // convertimos nuestro objeto a tipo  Libros 
            librosBO data = (librosBO) obj;
            // preparamos la conexion
            cmd = new MySqlCommand();
            dsLibros = new DataSet();
            da = new MySqlDataAdapter();
            con = new Conexion();
            // Establecemos la conexion
            cmd.Connection = con.establecerConexion();
            // Abrimos la conexion
            con.abrirConexion();
            // Declaramos nuestra sentencia select
            sql = "DELETE FROM libros WHERE codigo=" + Convert.ToString(data.Codigo).Trim();
            cmd.CommandText = sql;
            int i = cmd.ExecuteNonQuery();
            // validamos si se  eliminó de manera correcta
            if(i <= 0)
                {
                return 0;
                }
            return 1;
            }



        //AKI TERMINA EL CODIGO DE LA MAESTRA EN EL DAO

		
        public DataSet devuelveLibro(object obj)
        {
        	//Variables para hacer una busqueda dinamica
        	string cadenaWhere = "";
        	bool edo = false;
        	//convertimos nuestro objeto a tipo articulo
        	librosBO data = (librosBO) obj;
        	//preparamos la conexion
        	cmd = new MySqlCommand();
        	
            dsLibros = new DataSet();
            da = new MySqlDataAdapter();
            // Creamos la conexion
            con = new Conexion();
            // Establecemos la conexion       
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            
            
            if(data.Codigo > 0)
            {
            	cadenaWhere = cadenaWhere + " Codigo=" + data.Codigo + " and";
            	edo = true;
            }
            if(data.Salon > 0)
            {
            	cadenaWhere = cadenaWhere + " Salon=" + data.Salon + " and";
            	edo = true;
            }
            if(data.Categoria != null)
            {
            	cadenaWhere = cadenaWhere + " Categoria='" + data.Categoria + "' and";
                edo = true;
            }
            if(data.Familia !=null)
            {
            	cadenaWhere = cadenaWhere + " Familia='" + data.Familia + "' and";
                edo = true;
            }
            if(data.Titulo !=null)
            {
            	cadenaWhere = cadenaWhere + " Titulo='" + data.Titulo + "' and";
                edo = true;
            }
            if(data.Autor !=null)
            {
            	cadenaWhere = cadenaWhere + " Autor='" + data.Autor + "' and";
                edo = true;
            }
            if(data.Editorial !=null)
            {
            	cadenaWhere = cadenaWhere + " Editorial='" + data.Editorial + "' and";
                edo = true;
            }
            if(data.Fecha !=null)
            {
            	cadenaWhere = cadenaWhere + " Fecha='" + data.Fecha + "' and";
                edo = true;
            }
            if(data.Ejemplar !=null)
            {
            	cadenaWhere = cadenaWhere + " Ejemplar='" + data.Ejemplar + "' and";
                edo = true;
            }
            
            
            // si la variable edo cambio a true quiere decir que hay un criterio de filtrado activo
            if(edo == true)
                {
                // Con  remove quitamos el ultimo and de sobra de la cadenaWhere
                cadenaWhere = " WHERE " + cadenaWhere.Remove(cadenaWhere.Length - 3 , 3);
                }
            sql = " SELECT * FROM libros " + cadenaWhere;
            cmd.CommandText = sql;
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsLibros);
            con.cerrarConexion();
            return dsLibros;
            
		
		
		
		}
	}
}
