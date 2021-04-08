using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de ParametroPortabilidad.
	/// </summary>
	public class ParametroPortabilidad
	{
		private string _PK_PARAT_PARAC_TP;
		private string _PK_PARAT_PARAC_COD;
		private string _PARAV_DESCRIPCION;
		private int _PARAN_STATUS;
		private string _PARAV_REF1;
		private string _PARAV_REF2;
		private string _PARAV_REF3;
		private string _PARAV_REF4;
		private string _PARAV_REF5;
		private string _PARAV_REF6;
		private string _PARAV_REF7;
		private DateTime _PARAT_FECHA_CREACION;
		private string _PARAV_USUARIO_CREA;
		
		public ParametroPortabilidad() { }

		public string PK_PARAT_PARAC_TP
		{
			set { _PK_PARAT_PARAC_TP = value; }
			get { return _PK_PARAT_PARAC_TP; }
		}
		public string PK_PARAT_PARAC_COD
		{
			set { _PK_PARAT_PARAC_COD = value; }
			get { return _PK_PARAT_PARAC_COD; }
		}
		public string DESCRIPCION
		{
			set { _PARAV_DESCRIPCION = value; }
			get { return _PARAV_DESCRIPCION; }
		}
		public int STATUS
		{
			set { _PARAN_STATUS = value; }
			get { return _PARAN_STATUS; }
		}
		public string REF1
		{
			set { _PARAV_REF1 = value; }
			get { return _PARAV_REF1; }
		}
		public string REF2
		{
			set { _PARAV_REF2 = value; }
			get { return _PARAV_REF2; }
		}
		public string REF3
		{
			set { _PARAV_REF3 = value; }
			get { return _PARAV_REF3; }
		}
		public string REF4
		{
			set { _PARAV_REF4 = value; }
			get { return _PARAV_REF4; }
		}
		public string REF5
		{
			set { _PARAV_REF5 = value; }
			get { return _PARAV_REF5; }
		}
		public string REF6
		{
			set { _PARAV_REF6 = value; }
			get { return _PARAV_REF6; }
		}
		public string REF7
		{
			set { _PARAV_REF7 = value; }
			get { return _PARAV_REF7; }
		}
		public DateTime FECHA_CREACION
		{
			set { _PARAT_FECHA_CREACION = value; }
			get { return _PARAT_FECHA_CREACION; }
		}
		public string USUARIO_CREA
		{
			set { _PARAV_USUARIO_CREA = value; }
			get { return _PARAV_USUARIO_CREA; }
		}
	}
}
