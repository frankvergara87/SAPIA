using System;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Configuration;
using Claro.SisAct.Common;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de VasNegocios.
	/// </summary>
	public class ServicioVasNegocios
	{
		public ServicioVasNegocios()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public ArrayList ListaPaqueteVas(int vas_codigo)
		{
			ServicioVasDatos objvas = new ServicioVasDatos();
			return objvas.ListaPaqueteVas(vas_codigo);
		}	

		public bool InsertarVas(ServicioVas objDetalle)
		{
			ServicioVasDatos obj = new ServicioVasDatos();
			return obj.InsertarVas(objDetalle);
		}

		public ArrayList ListarParametroConfig(int intCodigoParametro)
		{
			ServicioVasDatos obj = new ServicioVasDatos();
			return obj.ListarParametroConfig(intCodigoParametro);
		}

		public bool validarActivacionVas(string idTransaccion, string ipAplicacion, string msisdn, string imsi, 
										 string servicio, string tipoLinea, string nombreGrupo, string trama,
										 out string mensajeRespuesta, out string estado, out string codigoRespuesta)
		{	
			try
			{
				string nombreAplicacion = Funciones.CheckStr(ConfigurationSettings.AppSettings["constAplicacion"]);	
				
				ActivacionVasWS.ebsActivacionVASService objVas = new ActivacionVasWS.ebsActivacionVASService();
				
				objVas.Url = Funciones.CheckStr(ConfigurationSettings.AppSettings["consRutaWS_VAS"]);
				objVas.Credentials= System.Net.CredentialCache.DefaultCredentials;
				objVas.Timeout = Funciones.CheckInt(ConfigurationSettings.AppSettings["consRutaWS_VAS_Timeout"]);				
								
				codigoRespuesta = objVas.activarServiciosVAS(ref idTransaccion, ipAplicacion, nombreAplicacion, 
									msisdn, imsi, servicio, tipoLinea, nombreGrupo, trama, 
									out mensajeRespuesta, out estado);
			}
			catch (Exception ex)
			{
				mensajeRespuesta = "Error: " + ex.Message;
                estado = string.Empty;
				codigoRespuesta = string.Empty;
			}			

			return (codigoRespuesta.Equals("0") ? true : false);

		}

		//**************************************** INICIO WHZR ****************************************************

		public string ListarOpcionVas(int intCodigoVas)
		{
			ServicioVasDatos obj = new ServicioVasDatos();
			return obj.ListarOpcionVas(intCodigoVas);
		}

		//**************************************** FIN WHZR ****************************************************
	}
}
