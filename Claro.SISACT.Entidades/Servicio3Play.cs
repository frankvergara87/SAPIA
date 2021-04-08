using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Servicio3Play.
	/// </summary>
	public class Servicio3Play
	{
		public Servicio3Play()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		private string _SERVV_CODIGO;
		private string _SERVV_DESCRIPCION;
		private string _GSRVC_PADRE;
		private string _GSRVV_DESCRIPCION;

		public string SERVV_CODIGO
		{
			set{_SERVV_CODIGO = value;}
			get{ return _SERVV_CODIGO;}		
		}

		public string SERVV_DESCRIPCION
		{
			set{_SERVV_DESCRIPCION = value;}
			get{ return _SERVV_DESCRIPCION;}		
		}

		public string GSRVC_PADRE
		{
			set{_GSRVC_PADRE = value;}
			get{ return _GSRVC_PADRE;}		
		}

		public string GSRVV_DESCRIPCION
		{
			set{_GSRVV_DESCRIPCION = value;}
			get{ return _GSRVV_DESCRIPCION;}		
		}

	}
}
