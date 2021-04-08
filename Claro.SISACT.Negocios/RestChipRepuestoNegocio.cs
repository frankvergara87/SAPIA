using System;
using System.Xml.Serialization;
using System.Collections;
using Claro.SisAct.Common;
using Claro.SisAct.Entidades;
using System.Configuration;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for RestChipRepuestoNegocio.
	/// </summary>
	public class RestChipRepuestoNegocio
	{
		
		public RestChipRepuestoNegocio()
		{
			//
			// TODO: Add constructor logic here
			//			
		}


		public string validarBloqueo(string vidTransaccion, string vipApp, string vnomApp, string vmsisdn, string vusuario, out string vmensajeRep)
		{
			string codRespuesta = "";

			try
			{

				RestriccionChipRepuesto.EsbRestriccionReposicionSIMCARDService objRestChipRep = new RestriccionChipRepuesto.EsbRestriccionReposicionSIMCARDService();
				objRestChipRep.Url = ConfigurationSettings.AppSettings["consRutaWSRestChipRep"];

			    codRespuesta = objRestChipRep.validarBloqueoPrepago(ref vidTransaccion, vipApp, vnomApp, vusuario, vmsisdn, out vmensajeRep);
			}
			catch(Exception ex)
			{
				codRespuesta = "999";
				vmensajeRep = "Ocurrio un error al consultar numero. " + ex.Message.ToString();
	     		throw ex;
			}

			return codRespuesta;
		}

		public string validarBloqueoPostpago(string vidTransaccion, string vipApp, string vnomApp, string vmsisdn, out string vmensajeRep)
		{
			string codRespuesta = "";

			try
			{

				RestriccionChipRepuesto.EsbRestriccionReposicionSIMCARDService objRestChipRep = new RestriccionChipRepuesto.EsbRestriccionReposicionSIMCARDService();
				objRestChipRep.Url = ConfigurationSettings.AppSettings["consRutaWSRestChipRep"];

				codRespuesta = objRestChipRep.validarBloqueoPostpago(ref vidTransaccion, vipApp, vnomApp, vmsisdn, out vmensajeRep);
			}
			catch(Exception ex)
			{
				codRespuesta = "999";
				vmensajeRep = "Ocurrio un error al consultar numero. " + ex.Message.ToString();
				throw ex;
			}

			return codRespuesta;
		}
	}
}
