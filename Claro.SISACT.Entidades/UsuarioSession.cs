using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de UsuarioSession.
	/// </summary>
	public class UsuarioSession
	{

		private string _CodigoUsuario;
		private string _CodigoUsuarioSisact;
		private string _CodigoVendedorSap;
		private string _CodigoUsuarioRed ;
		private string _EstadoAcceso;
		private string _NombreCompleto;
		private string _CodigoPerfil;
		private string _CadenaPerfil;
		private string _CadenaOpciones;
		private string _AreaId;
		private string _AreaDes;
		private string _Host;
		private string _OficinaVenta ;
		private string _OficinaVentaDescripcion ;
		private string _CanalVenta;
		private string _CanalVentaDescripcion;
		private string _Terminar;

		public UsuarioSession()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public string CodigoUsuario 
		{
			get{ return _CodigoUsuario;}
			set{ 	 _CodigoUsuario = value; }
		}

		
		
		public string CodigoUsuarioSisact 
		{
			get{ return _CodigoUsuarioSisact;}
			set{ 	 _CodigoUsuarioSisact = value; }
		}
		
		public string CodigoVendedorSap 
		{
			get{ return _CodigoVendedorSap;}
			set{ 	 _CodigoVendedorSap = value; }
		}
		
		public string CodigoUsuarioRed 
		{
			get{ return _CodigoUsuarioRed;}
			set{ 	 _CodigoUsuarioRed = value; }
		}
		
		public string EstadoAcceso 
		{
			get{ return _EstadoAcceso;}
			set{ 	 _EstadoAcceso = value; }
		}
	
		public string NombreCompleto 
		{
			get{ return _NombreCompleto;}
			set{ 	 _NombreCompleto = value; }
		}
		
		public string CodigoPerfil 
		{
			get{ return _CodigoPerfil;}
			set{ 	 _CodigoPerfil = value; }
		}
		
		public string CadenaPerfil 
		{
			get{ return _CadenaPerfil;}
			set{ 	 _CadenaPerfil = value; }
		}
		
		public string CadenaOpciones 
		{
			get{ return _CadenaOpciones;}
			set{ 	 _CadenaOpciones = value; }
		}
		
		public string AreaId 
		{
			get{ return _AreaId;}
			set{ 	 _AreaId = value; }
		}
		
		public string AreaDes 
		{
			get{ return _AreaDes;}
			set{ 	 _AreaDes = value; }
		}
		
		public string Host 
		{
			get{ return _Host;}
			set{ 	 _Host = value; }
		}
		
		public string OficinaVenta 
		{
			get{ return _OficinaVenta;}
			set{ 	 _OficinaVenta = value; }
		}
		
		public string OficinaVentaDescripcion 
		{
			get{ return _OficinaVentaDescripcion;}
			set{ 	 _OficinaVentaDescripcion = value; }
		}
		
		public string CanalVenta 
		{
			get{ return _CanalVenta;}
			set{ 	 _CanalVenta = value; }
		}
		
		public string CanalVentaDescripcion 
		{
			get{ return _CanalVentaDescripcion;}
			set{ 	 _CanalVentaDescripcion = value; }
		}
		
		public string Terminar 
		{
			get{ return _Terminar;}
			set{ 	 _Terminar = value; }
		}
		

	}
}
