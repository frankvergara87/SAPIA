using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for BEItemMensaje.
	/// </summary>
	public class BEItemMensaje
	{
			//PROY-24724-IDEA-28174 - CLASE NUEVA
		public string _id ;
		public string _codigo;
		public string _descripcion ;
		public string _mensajeSistema ;
		public string _mensajeCliente;
		public bool _exito;


		
		public BEItemMensaje() 
		{
			this._exito= true;        
		}

		public BEItemMensaje(bool exito)
		{
			this._exito = _exito;
		}

		public BEItemMensaje(string codigo, string mensajeSistema, bool exito)
		{
			this._codigo = _codigo;
			this._mensajeSistema = _mensajeSistema;
			this._exito = _exito;
		}

		public string id
		{
			get{ return _id;}
			set{ _id = value;}
		}

		public string codigo
		{
			get{ return _codigo;}
			set{ _codigo = value;}
		}

		public string descripcion
		{
			get{ return _descripcion;}
			set{ _descripcion = value;}
		}

		public string mensajeSistema
		{
			get{ return _mensajeSistema;}
			set{ _mensajeSistema = value;}
		}
		public string mensajeCliente
		{
			get{ return _mensajeCliente;}
			set{ _mensajeCliente = value;}
		}
		public bool exito
		{
			get{ return _exito;}
			set{ _exito = value;}
		}

		
	}
}
