using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de RazonesEvaluacion.
	/// </summary>
	public class RazonesEvaluacion
	{

		private string _solic_reglas_duras_dc;
		private string _SRDUV_DESCRIPCION;
		private string _solic_alerta_comportamiento_dc;
		private string _SACOV_DESCRIPCION;
		private int _solic_alertas_dc;
		private string _solic_correspondencia_saldo_dc;
		private string _SCSAV_DESCRIPCION_DE_RANGO ;

		public RazonesEvaluacion()
		{}

		public string solic_reglas_duras_dc 
		{
			get{ return _solic_reglas_duras_dc;}
			set{ _solic_reglas_duras_dc = value; }
		}
		public string SRDUV_DESCRIPCION 
		{
			get{ return _SRDUV_DESCRIPCION;}
			set{ _SRDUV_DESCRIPCION = value; }
		}
		public string solic_alerta_comportamiento_dc 
		{
			get{ return _solic_alerta_comportamiento_dc;}
			set{ _solic_alerta_comportamiento_dc = value; }
		}
		public string SACOV_DESCRIPCION 
		{
			get{ return _SACOV_DESCRIPCION;}
			set{ _SACOV_DESCRIPCION = value; }
		}
		public int solic_alertas_dc 
		{
			get{ return _solic_alertas_dc;}
			set{ _solic_alertas_dc = value; }
		}
		public string solic_correspondencia_saldo_dc 
		{
			get{ return _solic_correspondencia_saldo_dc;}
			set{ _solic_correspondencia_saldo_dc = value; }
		}
		public string SCSAV_DESCRIPCION_DE_RANGO 
		{
			get{ return _SCSAV_DESCRIPCION_DE_RANGO;}
			set{ _SCSAV_DESCRIPCION_DE_RANGO = value; }
		}
	}
}
