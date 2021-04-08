using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for ReciboDeposito.
	/// </summary>
	public class ReciboDeposito
	{
		private int _RECIBO_ID;
		private string _NRO_OPERACION;
		private double _MONTO_DEPOSITO;
		private DateTime _FECHA_DEPOSITO;
		private int _BANCO_ID;
		private string _BANCO_DES;
		private Int64 _SOLIN_CODIGO;
		private string _LOGIN;
		private string _TERMINAL;
		private string _ESTADO;

		public ReciboDeposito()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public int RECIBO_ID{set{_RECIBO_ID = value;} get{ return _RECIBO_ID;}}
		public string NRO_OPERACION{set{_NRO_OPERACION = value;} get{ return _NRO_OPERACION;}}
		public double MONTO_DEPOSITO{set{_MONTO_DEPOSITO = value;} get{ return _MONTO_DEPOSITO;}}
		public DateTime FECHA_DEPOSITO{set{_FECHA_DEPOSITO = value;} get{ return _FECHA_DEPOSITO;}}
		public int BANCO_ID{set{_BANCO_ID = value;} get{ return _BANCO_ID;}}
		public string BANCO_DES{set{_BANCO_DES = value;} get{ return _BANCO_DES;}}
		public Int64 SOLIN_CODIGO{set{_SOLIN_CODIGO = value;} get{ return _SOLIN_CODIGO;}}
		public string LOGIN{set{_LOGIN = value;} get{ return _LOGIN;}}
		public string TERMINAL{set{_TERMINAL = value;} get{ return _TERMINAL;}}
		public string ESTADO{set{_ESTADO = value;} get{ return _ESTADO;}}

	}
}
