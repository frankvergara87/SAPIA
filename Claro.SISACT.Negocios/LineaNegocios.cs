using System;
using System.Xml.Serialization;
using System.Collections;
using Claro.SisAct.Common;
using Claro.SisAct.Datos;
using Claro.SisAct.Entidades;
using System.Configuration;
using System.Data;

namespace Claro.SisAct.Negocios
{
	public class LineaNegocios
	{
		public LineaNegocios()
		{
		}
		public bool EjecutaDOL(Cliente oCliente, string msisdn, string codEmpleado, string codSistema, string strNotas, ref string strMensaje)
		{
			try
			{				
				DolWS.EbsDolWS objDOL = new DolWS.EbsDolWS();
				
				objDOL.Url= ConfigurationSettings.AppSettings["strURLWSDOL"];
				objDOL.Credentials= System.Net.CredentialCache.DefaultCredentials;			
				DolWS.DOLRequest objReq = new DolWS.DOLRequest();

				objReq.nroTransaccion = "0";
				objReq.msisdn = msisdn;
				objReq.nombres = oCliente.NOMBRES;
				objReq.apellidos= oCliente.APELLIDOS;
				objReq.tipoDocumento = oCliente.TIPO_DOC;
				objReq.numeroDocumento = oCliente.NRO_DOC;
				objReq.telefonoReferencia = Funciones.CheckStr(oCliente.TELEF_REFERENCIA);
				objReq.fechaNacimiento = Funciones.CheckStr(oCliente.FECHA_NAC);
				objReq.lugarNacimiento = Funciones.CheckStr(oCliente.LUGAR_NACIMIENTO_DES);
				objReq.motivoRegistro = Funciones.CheckStr(oCliente.MOTIVO_REGISTRO);
				objReq.direccionCompleta = Funciones.CheckStr(oCliente.DOMICILIO);
				objReq.ciudad = Funciones.CheckStr(oCliente.CIUDAD);
				objReq.codigoEmpleado = codEmpleado ;
				objReq.codigoSistema = codSistema;
				objReq.tipo = ConfigurationSettings.AppSettings["strConstTraDolTipo"];
				objReq.texto = ConfigurationSettings.AppSettings["strConstTraDolTexto"] + " | " + strNotas;
				DolWS.DOLResponse objRes = new DolWS.DOLResponse();
				objRes = objDOL.dol(objReq);	

				string resultado;
				resultado = objRes.resultado.ToString();

				if(resultado == "0"){
					strMensaje = objRes.descripcion;
					return true;
				}
				else
				{
					strMensaje = objRes.descripcion;
					return false;
				}
					
			}
			catch(Exception ex)
			{
				strMensaje = ex.Message.ToString();
				return false;
			}

		}
		
	}
}
