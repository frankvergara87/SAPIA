//PROY-31948 INI
using System;
using System.Text;
using System.Configuration;
using System.Collections; 
using System.Xml;
using System.Xml.Serialization;
using Claro.SisAct.Datos; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using Claro.SisAct.Negocios.WSConsultaCuotaCliente;

namespace Claro.SisAct.Negocios

{
	
	public class BWConsultaCuotaCliente
	{
		ConsultaCuotaCliente _objTransaccion = new ConsultaCuotaCliente();

		ClienteCuenta objCliente = new ClienteCuenta();

		string  idTransaccionW = String.Format("{0:yyyyMMddhhmmss}", DateTime.Now);
		string  ipAplicacionW = null;
		string  aplicacionW = ConfigurationSettings.AppSettings["constAplicacion"].ToString();
		string  usrAplicacionW = null;

		public BWConsultaCuotaCliente()
		{
			_objTransaccion.Url = ConfigurationSettings.AppSettings["WSConsultaCuotaCliente_URL"].ToString();
			_objTransaccion.Credentials = System.Net.CredentialCache.DefaultCredentials;
			_objTransaccion.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["TimeOut_Consultacuotacliente"].ToString());
		}

		public Cuota ConsultarCuotaCliente(string strTipoDocumento, string strNroDocumento, string strNroLinea)
		{
			Cuota objCuota= new Cuota();
			
			ListaResponseOpcional[] listaResponseOpcional = null;
				
			WSConsultaCuotaCliente.AuditTypeResponse objResponse = new AuditTypeResponse();
			WSConsultaCuotaCliente.AuditTypeRequest objRequest = new AuditTypeRequest();

			objRequest.idTransaccion = idTransaccionW;
			objRequest.ipAplicacion = ipAplicacionW; 
			objRequest.aplicacion = aplicacionW;
			objRequest.usrAplicacion = usrAplicacionW;

			try
			{

				string totalPendCuo = "";
				string CantLineasCuoPend = "";
				string CantCuoPend = "";
				string CantCuoPendLinea = "";
				string MontoPendCuoLinea = "";
				string estado = "";
				string mensaje = "";
								
				objResponse = _objTransaccion.consultarCuotaCliente(objRequest, 
																	strTipoDocumento,
																	strNroDocumento, 
																	strNroLinea,
																	null,
																	out totalPendCuo,
																	out CantLineasCuoPend,
																	out CantCuoPend,
																	out CantCuoPendLinea,
																	out MontoPendCuoLinea, 
																	out estado, out mensaje,
																	out listaResponseOpcional);
										
				objCuota.CantCuotasPendLinea =Funciones.CheckStr(CantCuoPendLinea);
				objCuota.Estado = estado;
				objCuota.Mensaje = mensaje;
			}
			catch (Exception e)
			{
				throw e;
				
			}
			
			return objCuota;

		}
	}
}
//PROY-31948 FIN