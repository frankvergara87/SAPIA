using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de AP_Campana.
	/// </summary>
	public class AP_Campana
	{
		public AP_Campana()
		{
		}
		private string _CAMPV_CODIGO;
		private string _CAMPV_DESCRIPCION;

		public string CAMPV_CODIGO
		{
			set{_CAMPV_CODIGO = value;}
			get{return _CAMPV_CODIGO;}
		}

		public string CAMPV_DESCRIPCION
		{
			set{_CAMPV_DESCRIPCION = value;}
			get{return _CAMPV_DESCRIPCION;}
		}
	}
}
