using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de AcuerdoPortIN.
	/// </summary>
	public class AcuerdoPortIN
	{
		private string _PK_ACPOT_ACPON_ID;
		private string _ACPOC_SEC;
		private string _ACPOC_ACUERDO_PVU;
		private string _ACPOC_DOCUMENTO_VENTA;
		private string _ACPOT_FECHA_PROGRAMA;
		private string _ACPOT_FECHA_EJECUCION;
		private int _ACPON_ESTA_ACTIVACION;
		private string _ACPOV_PROGRAMADOR;
		private string _ACPOT_FECHA_CREACION;
		private string _ACPOV_USUARIO_CREA;

		public AcuerdoPortIN() { }

		public string PK_ACPOT_ACPON_ID
		{
			set { _PK_ACPOT_ACPON_ID = value; }
			get { return _PK_ACPOT_ACPON_ID; }
		}
		public string SEC
		{
			set { _ACPOC_SEC = value; }
			get { return _ACPOC_SEC; }
		}
		public string ACUERDO_PVU
		{
			set { _ACPOC_ACUERDO_PVU = value; }
			get { return _ACPOC_ACUERDO_PVU; }
		}
		public string DOCUMENTO_VENTA
		{
			set { _ACPOC_DOCUMENTO_VENTA = value; }
			get { return _ACPOC_DOCUMENTO_VENTA; }
		}
		public string FECHA_PROGRAMA
		{
			set { _ACPOT_FECHA_PROGRAMA = value; }
			get { return _ACPOT_FECHA_PROGRAMA; }
		}
		public string FECHA_EJECUCION
		{
			set { _ACPOT_FECHA_EJECUCION = value; }
			get { return _ACPOT_FECHA_EJECUCION; }
		}
		public int ESTA_ACTIVACION
		{
			set { _ACPON_ESTA_ACTIVACION = value; }
			get { return _ACPON_ESTA_ACTIVACION; }
		}
		public string PROGRAMADOR
		{
			set { _ACPOV_PROGRAMADOR = value; }
			get { return _ACPOV_PROGRAMADOR; }
		}
		public string FECHA_CREACION
		{
			set { _ACPOT_FECHA_CREACION = value; }
			get { return _ACPOT_FECHA_CREACION; }
		}
		public string USUARIO_CREA
		{
			set { _ACPOV_USUARIO_CREA = value; }
			get { return _ACPOV_USUARIO_CREA; }
		}
	}
}
