/*
 * Created by SharpDevelop.
 * User: Mousepower
 * Date: 06/10/2014
 * Time: 09:57 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasificacionLibros.BO
{
	/// <summary>
	/// Description of librosBO.
	/// </summary>
	public class librosBO
	{
		
		int codigo;
		int salon;
		string categoria;
		string familia;
		string titulo;
		string autor;
		string editorial;
		string fecha;
		string ejemplar;
		
		
		public librosBO()
		{
		}
		public int Codigo{
			get {return this.codigo;}
			set{this.codigo = value;}
		}
		public int Salon
		{
			get {return this.salon;}
			set {this.salon = value;}
		}
		public string Categoria
		{
			get {return this.categoria;}
			set{this.categoria = value;}
		}
		public string Familia
		{
			get {return this.familia;}
			set {this.familia = value;}
		}
		public string Titulo
		{
			get{return this.titulo;}
			set{this.titulo = value;}
		}
		public string Autor
		{
			get{return this.autor;}
			set{this.autor = value;}
		}
		public string Editorial
		{
			get {return this.editorial;}
			set{this.editorial = value;}
		}
		public string Fecha
		{
			get{return this.fecha;}
			set{this.fecha = value;}
		}
		public string Ejemplar
		{
			get{return this.ejemplar;}
			set{this.ejemplar = value;}
		}
	}
}
