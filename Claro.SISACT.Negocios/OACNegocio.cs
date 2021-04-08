using System;
using Claro.SisAct.Entidades;
using Claro.SisAct.Negocios.ReglasCrediticiaWS;
using Claro.SisAct.Common;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Data;
using System.Text;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de OACNegocio.
	/// </summary>
	public class OACNegocio
	{
		OACWS.ConsultaDeudaCuenta _oTransaccion = new OACWS.ConsultaDeudaCuenta();

		public OACNegocio()
		{
			_oTransaccion.Url = ConfigurationSettings.AppSettings["RutaWS_OAC"].ToString();
			_oTransaccion.Credentials= System.Net.CredentialCache.DefaultCredentials;
			_oTransaccion.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["TimeOut_OAC"].ToString());
		}

		public OACWS.DetalleClienteType[] DetalleClienteOAC(string pId, string pTipoDoc, string pNroDoc, ref string mensaje)
		{
		    OACWS.AuditType oAuditType;
			OACWS.DetalleClienteType[] oDetClienteType = null;
			try
			{                
				string strCodAplicacion = ConfigurationSettings.AppSettings["CodigoAplicacion"].ToString();
				string strUsuAplicacion = ConfigurationSettings.AppSettings["constUsuarioAplicacion"].ToString();

				oAuditType = _oTransaccion.consultaDeuda(pId, strCodAplicacion, strUsuAplicacion, pTipoDoc, pNroDoc, out oDetClienteType);
				mensaje = oAuditType.txId + "|" + oAuditType.errorCode + "|" + oAuditType.errorMsg;
			}
			catch(Exception ex)
			{
				mensaje = ex.Message;
			}
		    
			return oDetClienteType;
		}
	}
}
