using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for BECartaPoder.
	/// </summary>
	public class BECartaPoder
	{
		public BECartaPoder()
		{
		}

		private Int64  _SCPN_SOLIN_CODIGO;   
		private Int64  _SCPN_NRO_PEDIDO ;       
		private string _SCPV_ID_TX_P ;          
		private string _SCPV_TIPO_TRANSACCION ; 
		private string _SCPV_TIPO_OPERACION ;   
		private string _SCPV_DESC_OPERACION  ;  
		private string _SCPV_TIPO_DOCUMENTO_AP ;
		private string _SCPV_NRO_DOCUMENTO_AP ; 
		private string _SCPV_NOMBRES_AP  ;      
		private string _SCPV_APELLIDOS_PAT_AP ; 
		private string _SCPV_APELLIDOS_MAT_AP ; 
		private string _SCPV_OBSERVACION  ;     
		private string _SCPV_APLICACION ;       
		private string _SCPV_USUARIO_CREA ;   
  
		public Int64  SCPN_SOLIN_CODIGO{get{ return _SCPN_SOLIN_CODIGO;} set{ _SCPN_SOLIN_CODIGO = value;}}
		public Int64  SCPN_NRO_PEDIDO {get{ return _SCPN_NRO_PEDIDO;} set{ _SCPN_NRO_PEDIDO = value;}}
		public string SCPV_ID_TX_P {get{ return _SCPV_ID_TX_P;} set{ _SCPV_ID_TX_P = value;}}
		public string SCPV_TIPO_TRANSACCION {get{ return _SCPV_TIPO_TRANSACCION ; } set{ _SCPV_TIPO_TRANSACCION   = value;}}
		public string SCPV_TIPO_OPERACION{get{ return _SCPV_TIPO_OPERACION ;   } set{ _SCPV_TIPO_OPERACION    = value;}}
		public string SCPV_DESC_OPERACION{get{ return _SCPV_DESC_OPERACION  ;  } set{ _SCPV_DESC_OPERACION    = value;}}
		public string SCPV_TIPO_DOCUMENTO_AP{get{ return _SCPV_TIPO_DOCUMENTO_AP ;} set{ _SCPV_TIPO_DOCUMENTO_AP = value;}}
		public string SCPV_NRO_DOCUMENTO_AP{get{ return _SCPV_NRO_DOCUMENTO_AP ; } set{ _SCPV_NRO_DOCUMENTO_AP  = value;}}
		public string SCPV_NOMBRES_AP{get{ return _SCPV_NOMBRES_AP  ;      } set{ _SCPV_NOMBRES_AP       = value;}}
		public string SCPV_APELLIDOS_PAT_AP {get{ return _SCPV_APELLIDOS_PAT_AP ; } set{ _SCPV_APELLIDOS_PAT_AP  = value;}}
		public string SCPV_APELLIDOS_MAT_AP{get{ return _SCPV_APELLIDOS_MAT_AP ; } set{ _SCPV_APELLIDOS_MAT_AP  = value;}}
		public string SCPV_OBSERVACION{get{ return _SCPV_OBSERVACION  ;     } set{ _SCPV_OBSERVACION     = value;}}
		public string SCPV_APLICACION{get{ return _SCPV_APLICACION ;       } set{ _SCPV_APLICACION      = value;}}
		public string SCPV_USUARIO_CREA{get{ return _SCPV_USUARIO_CREA ;   }   set{ _SCPV_USUARIO_CREA   = value;}}



	}
}
