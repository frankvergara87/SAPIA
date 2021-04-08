using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	public class HistorialDataCreditoCorp
	{
		
		public HistorialDataCreditoCorp() {}

		#region Propiedades SERVICIO 12

		private string _ws12_In_TipoDocumento = "";
		private string _ws12_In_NumeroDocumento = "";
		private string _ws12_In_ApellidoPaterno = "";
		private string _ws12_In_ApellidoMaterno = "";
		private string _ws12_In_Nombres = "";
		private string _ws12_In_TipoPersona = "";
		private string _ws12_In_TipoServicio = "";
		private string _ws12_Out_Header_Transaccion = "";
		private string _ws12_Out_Header_TipoServicio = "";
		private string _ws12_Out_Header_CodigoRetorno = "";
		private string _ws12_Out_Header_NumeroOperacion = "";
		private string _ws12_Out_Error_CodigoMensajes = "";
		private string _ws12_Out_Error_Mensaje = "";
		
		public string ws12_In_TipoDocumento
		{
			set{ _ws12_In_TipoDocumento = value; }
			get{ return _ws12_In_TipoDocumento; }
		}
		public string ws12_In_NumeroDocumento
		{
			set{ _ws12_In_NumeroDocumento = value; }
			get{ return _ws12_In_NumeroDocumento; }
		}
		public string ws12_In_ApellidoPaterno
		{
			set{ _ws12_In_ApellidoPaterno = value; }
			get{ return _ws12_In_ApellidoPaterno; }
		}
		public string ws12_In_ApellidoMaterno
		{
			set{ _ws12_In_ApellidoMaterno = value; }
			get{ return _ws12_In_ApellidoMaterno; }
		}
		public string ws12_In_Nombres
		{
			set{ _ws12_In_Nombres = value; }
			get{ return _ws12_In_Nombres; }
		}
		public string ws12_In_TipoPersona
		{
			set{ _ws12_In_TipoPersona = value; }
			get{ return _ws12_In_TipoPersona; }
		}
		public string ws12_In_TipoServicio
		{
			set{ _ws12_In_TipoServicio = value; }
			get{ return _ws12_In_TipoServicio; }
		}
		public string ws12_Out_Header_Transaccion
		{
			set{ _ws12_Out_Header_Transaccion = value; }
			get{ return _ws12_Out_Header_Transaccion; }
		}
		public string ws12_Out_Header_TipoServicio
		{
			set{ _ws12_Out_Header_TipoServicio = value; }
			get{ return _ws12_Out_Header_TipoServicio; }
		}
		public string ws12_Out_Header_CodigoRetorno
		{
			set{ _ws12_Out_Header_CodigoRetorno = value; }
			get{ return _ws12_Out_Header_CodigoRetorno; }
		}
		public string ws12_Out_Header_NumeroOperacion
		{
			set{ _ws12_Out_Header_NumeroOperacion = value; }
			get{ return _ws12_Out_Header_NumeroOperacion; }
		}
		public string ws12_Out_Error_CodigoMensajes
		{
			set{ _ws12_Out_Error_CodigoMensajes = value; }
			get{ return _ws12_Out_Error_CodigoMensajes; }
		}
		public string ws12_Out_Error_Mensaje
		{
			set{ _ws12_Out_Error_Mensaje = value; }
			get{ return _ws12_Out_Error_Mensaje; }
		}

		#endregion

		#region Propiedades SERVICIO 50

		private string _ws50_In_TipoServicio = "";
		private string _ws50_In_NumeroOperacion = "";
		private string _ws50_Out_Header_Transaccion = "";
		private string _ws50_Out_Header_TipoServicio = "";
		private string _ws50_Out_Header_CodigoRetorno = "";
		private string _ws50_Out_Header_NumeroOperacion = "";
		private string _ws50_Out_GrupoIntegrantes_IntegranteTipoDocumento = "";
		private string _ws50_Out_GrupoIntegrantes_IntegranteNumeroDocumento = "";
		private string _ws50_Out_GrupoIntegrantes_IntegranteNombres = "";
		private string _ws50_Out_CampoNombre_Accion = "";
		private string _ws50_Out_CampoExisteCampo_Accion = "";
		private string _ws50_Out_CampoValor_Accion = "";
		private string _ws50_Out_CampoNombre_MsgIngTarjeta = "";
		private string _ws50_Out_CampoExisteCampo_MsgIngTarjeta = "";
		private string _ws50_Out_CampoValor_MsgIngTarjeta = "";
		private string _ws50_Out_CampoNombre_MsgIngDHipotecaria = "";
		private string _ws50_Out_CampoExisteCampo_MsgIngDHipotecaria = "";
		private string _ws50_Out_CampoValor_MsgIngDHipotecaria = "";
		private string _ws50_Out_CampoNombre_MsgIngDnHipoTarjeta = "";
		private string _ws50_Out_CampoExisteCampo_MsgIngDnHipoTarjeta = "";
		private string _ws50_Out_CampoValor_MsgIngDnHipoTarjeta = "";
		private string _ws50_Out_CampoNombre_Explicacion = "";
		private string _ws50_Out_CampoExisteCampo_Explicacion = "";
		private string _ws50_Out_CampoValor_Explicacion = "";
		private string _ws50_Out_CampoNombre_ExplicacionAuxiliar = "";
		private string _ws50_Out_CampoExisteCampo_ExplicacionAuxiliar = "";
		private string _ws50_Out_CampoValor_ExplicacionAuxiliar = "";
		
		public string ws50_In_TipoServicio
		{
			set{ _ws50_In_TipoServicio = value; }
			get{ return _ws50_In_TipoServicio; }
		}
		public string ws50_In_NumeroOperacion
		{
			set{ _ws50_In_NumeroOperacion = value; }
			get{ return _ws50_In_NumeroOperacion; }
		}
		public string ws50_Out_Header_Transaccion
		{
			set{ _ws50_Out_Header_Transaccion = value; }
			get{ return _ws50_Out_Header_Transaccion; }
		}
		public string ws50_Out_Header_TipoServicio
		{
			set{ _ws50_Out_Header_TipoServicio = value; }
			get{ return _ws50_Out_Header_TipoServicio; }
		}
		public string ws50_Out_Header_CodigoRetorno
		{
			set{ _ws50_Out_Header_CodigoRetorno = value; }
			get{ return _ws50_Out_Header_CodigoRetorno; }
		}
		public string ws50_Out_Header_NumeroOperacion
		{
			set{ _ws50_Out_Header_NumeroOperacion = value; }
			get{ return _ws50_Out_Header_NumeroOperacion; }
		}
		public string ws50_Out_GrupoIntegrantes_IntegranteTipoDocumento
		{
			set{ _ws50_Out_GrupoIntegrantes_IntegranteTipoDocumento = value; }
			get{ return _ws50_Out_GrupoIntegrantes_IntegranteTipoDocumento; }
		}
		public string ws50_Out_GrupoIntegrantes_IntegranteNumeroDocumento
		{
			set{ _ws50_Out_GrupoIntegrantes_IntegranteNumeroDocumento = value; }
			get{ return _ws50_Out_GrupoIntegrantes_IntegranteNumeroDocumento; }
		}
		public string ws50_Out_GrupoIntegrantes_IntegranteNombres
		{
			set{ _ws50_Out_GrupoIntegrantes_IntegranteNombres = value; }
			get{ return _ws50_Out_GrupoIntegrantes_IntegranteNombres; }
		}
		public string ws50_Out_CampoNombre_Accion
		{
			set{ _ws50_Out_CampoNombre_Accion = value; }
			get{ return _ws50_Out_CampoNombre_Accion; }
		}
		public string ws50_Out_CampoExisteCampo_Accion
		{
			set{ _ws50_Out_CampoExisteCampo_Accion = value; }
			get{ return _ws50_Out_CampoExisteCampo_Accion; }
		}
		public string ws50_Out_CampoValor_Accion
		{
			set{ _ws50_Out_CampoValor_Accion = value; }
			get{ return _ws50_Out_CampoValor_Accion; }
		}
		public string ws50_Out_CampoNombre_MsgIngTarjeta
		{
			set{ _ws50_Out_CampoNombre_MsgIngTarjeta = value; }
			get{ return _ws50_Out_CampoNombre_MsgIngTarjeta; }
		}
		public string ws50_Out_CampoExisteCampo_MsgIngTarjeta
		{
			set{ _ws50_Out_CampoExisteCampo_MsgIngTarjeta = value; }
			get{ return _ws50_Out_CampoExisteCampo_MsgIngTarjeta; }
		}
		public string ws50_Out_CampoValor_MsgIngTarjeta
		{
			set{ _ws50_Out_CampoValor_MsgIngTarjeta = value; }
			get{ return _ws50_Out_CampoValor_MsgIngTarjeta; }
		}
		public string ws50_Out_CampoNombre_MsgIngDHipotecaria
		{
			set{ _ws50_Out_CampoNombre_MsgIngDHipotecaria = value; }
			get{ return _ws50_Out_CampoNombre_MsgIngDHipotecaria; }
		}
		public string ws50_Out_CampoExisteCampo_MsgIngDHipotecaria
		{
			set{ _ws50_Out_CampoExisteCampo_MsgIngDHipotecaria = value; }
			get{ return _ws50_Out_CampoExisteCampo_MsgIngDHipotecaria; }
		}
		public string ws50_Out_CampoValor_MsgIngDHipotecaria
		{
			set{ _ws50_Out_CampoValor_MsgIngDHipotecaria = value; }
			get{ return _ws50_Out_CampoValor_MsgIngDHipotecaria; }
		}

		public string ws50_Out_CampoNombre_MsgIngDnHipoTarjeta
		{
			set{ _ws50_Out_CampoNombre_MsgIngDnHipoTarjeta = value; }
			get{ return _ws50_Out_CampoNombre_MsgIngDnHipoTarjeta; }
		}
		public string ws50_Out_CampoExisteCampo_MsgIngDnHipoTarjeta
		{
			set{ _ws50_Out_CampoExisteCampo_MsgIngDnHipoTarjeta = value; }
			get{ return _ws50_Out_CampoExisteCampo_MsgIngDnHipoTarjeta; }
		}
		public string ws50_Out_CampoValor_MsgIngDnHipoTarjeta
		{
			set{ _ws50_Out_CampoValor_MsgIngDnHipoTarjeta = value; }
			get{ return _ws50_Out_CampoValor_MsgIngDnHipoTarjeta; }
		}

		public string ws50_Out_CampoNombre_Explicacion
		{
			set{ _ws50_Out_CampoNombre_Explicacion = value; }
			get{ return _ws50_Out_CampoNombre_Explicacion; }
		}
		public string ws50_Out_CampoExisteCampo_Explicacion
		{
			set{ _ws50_Out_CampoExisteCampo_Explicacion = value; }
			get{ return _ws50_Out_CampoExisteCampo_Explicacion; }
		}
		public string ws50_Out_CampoValor_Explicacion
		{
			set{ _ws50_Out_CampoValor_Explicacion = value; }
			get{ return _ws50_Out_CampoValor_Explicacion; }
		}
		public string ws50_Out_CampoNombre_ExplicacionAuxiliar
		{
			set{ _ws50_Out_CampoNombre_ExplicacionAuxiliar = value; }
			get{ return _ws50_Out_CampoNombre_ExplicacionAuxiliar; }
		}
		public string ws50_Out_CampoExisteCampo_ExplicacionAuxiliar
		{
			set{ _ws50_Out_CampoExisteCampo_ExplicacionAuxiliar = value; }
			get{ return _ws50_Out_CampoExisteCampo_ExplicacionAuxiliar; }
		}
		public string ws50_Out_CampoValor_ExplicacionAuxiliar
		{
			set{ _ws50_Out_CampoValor_ExplicacionAuxiliar = value; }
			get{ return _ws50_Out_CampoValor_ExplicacionAuxiliar; }
		}

		#endregion

		#region Propiedades SERVICIO 53
		
		private string _ws53_In_TipoServicio = "";
		private string _ws53_In_NumeroOperacion = "";
		private string _ws53_Out_Header_Transaccion = "";
		private string _ws53_Out_Header_TipoServicio = "";
		private string _ws53_Out_Header_CodigoRetorno = "";
		private string _ws53_Out_Header_NumeroOperacion = "";
		
		public string ws53_In_TipoServicio
		{
			set{ _ws53_In_TipoServicio = value; }
			get{ return _ws53_In_TipoServicio; }
		}
		public string ws53_In_NumeroOperacion
		{
			set{ _ws53_In_NumeroOperacion = value; }
			get{ return _ws53_In_NumeroOperacion; }
		}
		public string ws53_Out_Header_Transaccion
		{
			set{ _ws53_Out_Header_Transaccion = value; }
			get{ return _ws53_Out_Header_Transaccion; }
		}
		public string ws53_Out_Header_TipoServicio
		{
			set{ _ws53_Out_Header_TipoServicio = value; }
			get{ return _ws53_Out_Header_TipoServicio; }
		}
		public string ws53_Out_Header_CodigoRetorno
		{
			set{ _ws53_Out_Header_CodigoRetorno = value; }
			get{ return _ws53_Out_Header_CodigoRetorno; }
		}
		public string ws53_Out_Header_NumeroOperacion
		{
			set{ _ws53_Out_Header_NumeroOperacion = value; }
			get{ return _ws53_Out_Header_NumeroOperacion; }
		}
		#endregion

		#region Lista Representantes Legales
		
		private ArrayList _RepresentantesLegales = new ArrayList();
		
		public ArrayList RepresentantesLegales
		{
			get{ return _RepresentantesLegales;}
			set{ _RepresentantesLegales= value;}
		}

		#endregion

		//INICIO: PROY-20054-IDEA-23849
		private int _buro_consultado;
		public int buro_consultado 
		{
			get{ return _buro_consultado;}
			set{ _buro_consultado = value; }
		}
		//FIN
	}
}