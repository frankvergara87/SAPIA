using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

using System.Xml.Serialization;
using Claro.SisAct.Common;
using System.Configuration;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for sisact_auditoria.
	/// </summary>
	public class sisact_auditoria
	{
		public sisact_auditoria()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool registrarAuditoria(string vTransaccion,
			string vServicio,
			string vIPCliente,
			string vNombreCliente,
			string vIPServidor,
			string vNombreServidor,
			string vCuentaUsuario,
			string vTelefono,
			ref string vMonto,
			ref string vTexto)
		{
			bool Respuesta=false;                    
			AuditoriaWS.EbsAuditoriaService objAuditoria = new AuditoriaWS.EbsAuditoriaService();
			objAuditoria.Url = ConfigurationSettings.AppSettings["consRutaWSSeguridad"];
			objAuditoria.Credentials= System.Net.CredentialCache.DefaultCredentials;
			AuditoriaWS.RegistroRequest objRequestAuditoria = new  AuditoriaWS.RegistroRequest();                                   
			AuditoriaWS.RegistroResponse objResponseAuditoria = new  AuditoriaWS.RegistroResponse();                                  
 
			objRequestAuditoria.transaccion    = vTransaccion;
			objRequestAuditoria.servicio       = vServicio;              
			objRequestAuditoria.ipCliente      = vIPCliente;
			objRequestAuditoria.nombreCliente  = vNombreCliente;                            
			objRequestAuditoria.ipServidor     = vIPServidor;
			objRequestAuditoria.nombreServidor = vNombreServidor;
			objRequestAuditoria.cuentaUsuario  = vCuentaUsuario;
			objRequestAuditoria.telefono       = vTelefono;
			objRequestAuditoria.monto          = vMonto;                                                 
			objRequestAuditoria.texto          = vTexto;
                 
			objResponseAuditoria=objAuditoria.registroAuditoria(objRequestAuditoria);

			//0-Error    1-Éxito

			if(objResponseAuditoria.estado=="0")
			{
				Respuesta=false;
			}
			else
			{
				Respuesta=true;              
			}
			return Respuesta; 
		}
	}
}
