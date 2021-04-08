using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de ItemMensaje.
	/// </summary>
	public class ItemMensaje
	{
		public ItemMensaje()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
			this.exito = true;    
		}

		public string _id ;
		public string _codigo ;
		public string _descripcion ;
		public string _mensajeSistema ;
		public string _mensajeCliente ;
		public bool exito;
		public string id 
		{
			set{_id= value;}
			get{ return _id;}
		}
		public string codigo 
		{
			set{_codigo= value;}
			get{ return _codigo;}
		}
		public string descripcion 
		{
			set{_descripcion= value;}
			get{ return _descripcion;}
		}
		public string mensajeSistema 
		{
			set{_mensajeSistema= value;}
			get{ return _mensajeSistema;}
		}
		public string mensajeCliente 
		{
			set{_mensajeCliente= value;}
			get{ return _mensajeCliente;}
		}
		
		

		public ItemMensaje(bool exito)
		{
			this.exito = exito;
		}

		public ItemMensaje(string codigo, string mensajeSistema, bool exito)
		{
			this.codigo = codigo;
			this.mensajeSistema = mensajeSistema;
			this.exito = exito;
		}
	}
}
