using System;
using System.Configuration;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for ConsultaLinea.
	/// </summary>
	public class ConsultaLinea
	{
		public ConsultaLinea()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		
		

		public bool ConsultaPostpago(string nroTelefono)
		{	bool retorno=false;
			
		

				ConsultaPostpagoWS.datosClienteResponse  objDatos = new Claro.SisAct.Negocios.ConsultaPostpagoWS.datosClienteResponse();
				ConsultaPostpagoWS.SIACPostpagoConsultasWSService  objPostpago = new Claro.SisAct.Negocios.ConsultaPostpagoWS.SIACPostpagoConsultasWSService();
				objPostpago.Url = ConfigurationSettings.AppSettings["RutaWS_DatosPostpago"];
				objPostpago.Credentials = System.Net.CredentialCache.DefaultCredentials;
				objPostpago.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["TIME_POSTPAGO_PREPAGO"]);
					

				objDatos = objPostpago.datosCliente("",nroTelefono);
			
				if (objDatos.errorsql.Length == 0 && objDatos.cliente != null)
				{
					if (objDatos.cliente.Length > 0)
					{
						retorno =true;
					}				
				}
	

			return retorno;
		}
			

		public bool ConsultaPrepago(string nroTelefono)
		{
			bool retorno = false;
		
	
				DatosPrepagoWS.DatosPrepago objDatos = new DatosPrepagoWS.DatosPrepago();
				DatosPrepagoWS.INDatosPrepagoResponse objINDatosPrepagoResponse = new Claro.SisAct.Negocios.DatosPrepagoWS.INDatosPrepagoResponse();
				DatosPrepagoWS.INDatosPrepagoRequest  objPrepagoRequest = new Claro.SisAct.Negocios.DatosPrepagoWS.INDatosPrepagoRequest();
				DatosPrepagoWS.EbsDatosPrepagoService objPrepago = new DatosPrepagoWS.EbsDatosPrepagoService();
				objPrepago.Url = ConfigurationSettings.AppSettings["RutaWS_DatosPrepago"];
				objPrepago.Credentials = System.Net.CredentialCache.DefaultCredentials;
				objPrepago.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["TIME_POSTPAGO_PREPAGO"]);


				objPrepagoRequest.telefono=nroTelefono;
				objINDatosPrepagoResponse = objPrepago.leerDatosPrepago(objPrepagoRequest);
				if ( objINDatosPrepagoResponse.resultado != "-1")
				{
					if (objINDatosPrepagoResponse.datosPrePago.customerID.Length !=0)
					{
						retorno = true;	
					}
		        }
		

			return retorno;
		}

	}
}