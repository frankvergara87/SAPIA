using System;
using System.Configuration;

namespace Claro.SisAct.Negocios
{
	///	<summary>
	///	Summary	description	for	BWConsultaClaves.
	///	</summary>
	public class BWConsultaClaves
	{
		WSConsultaClaves.ebsConsultaClavesService consultaClaves = new WSConsultaClaves.ebsConsultaClavesService();

		public BWConsultaClaves()
		{
			consultaClaves.Url = ConfigurationSettings.AppSettings["RutaWS_ConsultaClaves"];
			consultaClaves.Credentials = System.Net.CredentialCache.DefaultCredentials;
			consultaClaves.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["TimeOut_ConsultaClaves"]);

		}

		public string ConsultaClavesWS(string idTransaccion,
			string ipAplicacion,
			string ipTransicion,
			string usrAplicacion,
			string idAplicacion,
			string codigoAplicacion,
			string usuarioAplicacionEncriptado,
			string claveEncriptado,
			out	string mensajeResultado,
			out	string usuarioAplicacion,
			out	string clave)
		{
			string strCodigoResultado =	null;
			try
			{

				strCodigoResultado = consultaClaves.desencriptar(ref idTransaccion,
																 ipAplicacion,
																 ipTransicion,
																 usrAplicacion,
																 idAplicacion,
																 codigoAplicacion,
																 usuarioAplicacionEncriptado,
																 claveEncriptado,
																 out mensajeResultado,
																 out usuarioAplicacion,
																 out clave);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return strCodigoResultado;
		}
	}
}
