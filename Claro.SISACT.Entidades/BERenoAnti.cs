using System;

namespace Claro.SisAct.Entidades
{
	public class BERenoAnti
	{
		public BERenoAnti()
		{
			
		}

		private	Int64	_N_NRO_PEDIDO	;
		private	Int64	_N_NRO_CONTRATO	;
		private	string	_V_MSISDN	;
		private	Int64	_V_CO_ID	;
		private	Int64	_N_CUSTOMER_ID	;
		private	string	_V_TIPO_DOCUMENTO	;
		private	string	_N_NRO_DOCUMENTO	;
		private	string	_V_TIPO_CLIENTE	;
		private	string	_V_COD_EQUIPO	;
		private	string	_V_COD_MATERIAL	;
		private	string	_V_ESTADO	;
		private	string	_V_TIPO_RENOVACION	;
		private	Int64	_N_NRO_SEC	;
		private	Int64	_N_ID_ACUERDO	;
		private	DateTime _D_FECHA_ACUERDO	;
		private	string	_V_ESTADO_ACUERDO	;
		private	Double	_N_MONTO_ORIGINAL	;
		private	Double	_N_MONTO_REINTEGRO	;
		private	Double	_N_MONTO_FIDELIZA	;
		private	string	_V_FLAG_APLICA_REINTEGRO	;
		private	string	_V_FLAG_FIDELIZA	;
		private	string	_CL_DATOS_ACTUALIZA	;
		private	string	_V_BD_ORIGEN	;
		private	string	_V_CANAL	;
		private	string	_V_USU_CREACION	; 

		
		public Int64 N_NRO_PEDIDO
		{
			get { return _N_NRO_PEDIDO; }
			set { _N_NRO_PEDIDO = value; }
		}

		public Int64 N_NRO_CONTRATO
		{
			get { return _N_NRO_CONTRATO; }
			set { _N_NRO_CONTRATO = value; }
		}

		public string V_MSISDN
		{
			get { return _V_MSISDN; }
			set { _V_MSISDN = value; }
		}

		public Int64 V_CO_ID
		{
			get { return _V_CO_ID; }
			set { _V_CO_ID = value; }
		}
		public Int64 N_CUSTOMER_ID
		{
			get { return _N_CUSTOMER_ID; }
			set { _N_CUSTOMER_ID = value; }
		}

		public string V_TIPO_DOCUMENTO
		{
			get { return _V_TIPO_DOCUMENTO; }
			set { _V_TIPO_DOCUMENTO = value; }
		}

		public string N_NRO_DOCUMENTO
		{
			get { return _N_NRO_DOCUMENTO; }
			set { _N_NRO_DOCUMENTO = value; }
		}

		public string V_TIPO_CLIENTE
		{
			get { return _V_TIPO_CLIENTE; }
			set { _V_TIPO_CLIENTE = value; }
		}

		public string V_COD_EQUIPO
		{
			get { return _V_COD_EQUIPO; }
			set { _V_COD_EQUIPO = value; }
		}

		public string V_COD_MATERIAL
		{
			get { return _V_COD_MATERIAL; }
			set { _V_COD_MATERIAL = value; }
		}

		public string V_ESTADO
		{
			get { return _V_ESTADO; }
			set { _V_ESTADO = value; }
		}

		public string V_TIPO_RENOVACION
		{
			get { return _V_TIPO_RENOVACION; }
			set { _V_TIPO_RENOVACION = value; }
		}		
		public Int64 N_NRO_SEC
		{
			get { return _N_NRO_SEC; }
			set { _N_NRO_SEC = value; }
		}
		public Int64 N_ID_ACUERDO
		{
			get { return _N_ID_ACUERDO; }
			set { _N_ID_ACUERDO = value; }
		}

		public DateTime D_FECHA_ACUERDO
		{
			get { return _D_FECHA_ACUERDO; }
			set { _D_FECHA_ACUERDO = value; }
		}
		public string V_ESTADO_ACUERDO
		{
			get { return _V_ESTADO_ACUERDO; }
			set { _V_ESTADO_ACUERDO = value; }
		}
		
		public Double N_MONTO_ORIGINAL
		{
			get { return _N_MONTO_ORIGINAL; }
			set { _N_MONTO_ORIGINAL = value; }
		}
		public Double N_MONTO_REINTEGRO
		{
			get { return _N_MONTO_REINTEGRO; }
			set { _N_MONTO_REINTEGRO = value; }
		}
		public Double N_MONTO_FIDELIZA
		{
			get { return _N_MONTO_FIDELIZA; }
			set { _N_MONTO_FIDELIZA = value; }
		}

		public string V_FLAG_APLICA_REINTEGRO
		{
			get { return _V_FLAG_APLICA_REINTEGRO; }
			set { _V_FLAG_APLICA_REINTEGRO = value; }
		}

		public string V_FLAG_FIDELIZA
		{
			get { return _V_FLAG_FIDELIZA; }
			set { _V_FLAG_FIDELIZA = value; }
		}

		public string CL_DATOS_ACTUALIZA
		{
			get { return _CL_DATOS_ACTUALIZA; }
			set { _CL_DATOS_ACTUALIZA = value; }
		}

		public string V_BD_ORIGEN
		{
			get { return _V_BD_ORIGEN; }
			set { _V_BD_ORIGEN = value; }
		}

		public string V_CANAL
		{
			get { return _V_CANAL; }
			set { _V_CANAL = value; }
		}

		public string V_USU_CREACION
		{
			get { return _V_USU_CREACION; }
			set { _V_USU_CREACION = value; }
		}



	}
}
