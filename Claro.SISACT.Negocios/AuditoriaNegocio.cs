using System;
using System.Xml.Serialization;
using System.Collections;
using Claro.SisAct.Common;
using Claro.SisAct.Entidades;
using System.Configuration;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Auditoria.
	/// </summary>
	public class AuditoriaNegocio
	{
		
		public AuditoriaNegocio()
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

			string strResultado = objResponseAuditoria.resultado;

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

		public AuditoriaWS.AccesoResponse leerDatoUsuario(string vUsuario, string vAplicacion)
		{
			AuditoriaWS.EbsAuditoriaService objAuditoria = new AuditoriaWS.EbsAuditoriaService();
			objAuditoria.Url = ConfigurationSettings.AppSettings["consRutaWSSeguridad"];
			AuditoriaWS.AccesoRequest objUsuarioRequest = new AuditoriaWS.AccesoRequest();
			objUsuarioRequest.usuario = vUsuario;
			objUsuarioRequest.aplicacion =vAplicacion;
			AuditoriaWS.AccesoResponse objUsuarioResponse = new AuditoriaWS.AccesoResponse();     
			objUsuarioResponse =objAuditoria.leerDatosUsuario(objUsuarioRequest);
			
			//0-Error    1-Éxito
	
		
			return objUsuarioResponse; 
		}
	
		public ArrayList LeerPaginaOpcionesPorUsuario(Int64 idUsuario)
		{
			
				ArrayList lista = new ArrayList();
				AuditoriaWS.PaginaOpcionesUsuarioRequest objRequest = new AuditoriaWS.PaginaOpcionesUsuarioRequest();
				AuditoriaWS.PaginaOpcionesUsuarioResponse objResponse = new AuditoriaWS.PaginaOpcionesUsuarioResponse();
				AuditoriaWS.PaginaOpcionType[] objOpcion;

				objRequest.user = Funciones.CheckInt(idUsuario);
				objRequest.aplicCod = Funciones.CheckInt(ConfigurationSettings.AppSettings["CodigoAplicacion"].ToString());

				AuditoriaWS.EbsAuditoriaService objAuditoria = new AuditoriaWS.EbsAuditoriaService();
				objAuditoria.Url = ConfigurationSettings.AppSettings["consRutaWSSeguridad"];
				objAuditoria.Credentials= System.Net.CredentialCache.DefaultCredentials;

				objResponse = objAuditoria.leerPaginaOpcionesPorUsuario(objRequest);

				objOpcion = objResponse.listaOpciones;
				if (objResponse.resultado == "0")
				{
					if (objOpcion != null)
					{
						for (int i = 0; i < objOpcion.Length; i++)
						{
							ItemGenerico item = new ItemGenerico();
							item.Codigo = objOpcion[i].opcicCod;
							item.Codigo2 = objOpcion[i].clave;
							item.Descripcion = objOpcion[i].opcicDes;
							lista.Add(item);
						}
					}
				}
				return lista;
		
		}
	
		public ArrayList LeerPerfilesPorApp(string cod_aplicacion, ref string errorMsg, ref string codError)
		{
			AuditoriaWS.PerfilType[] objSeg;
			ArrayList lista = new ArrayList();
			AuditoriaWS.PerfilRequest objRequest = new AuditoriaWS.PerfilRequest();
			AuditoriaWS.PerfilResponse objResponse = new AuditoriaWS.PerfilResponse();

			objRequest.codAplicacion = cod_aplicacion;

			AuditoriaWS.EbsAuditoriaService objAuditoria = new AuditoriaWS.EbsAuditoriaService();
			objAuditoria.Url = ConfigurationSettings.AppSettings["consRutaWSSeguridad"];
			objAuditoria.Credentials= System.Net.CredentialCache.DefaultCredentials;

			objResponse = objAuditoria.leerPerfilesPorApp(objRequest);
			
			errorMsg = objResponse.resultado.mensaje;
			codError = objResponse.resultado.estado;
			objSeg = objResponse.perfiles.item;



			if (codError == "1")
			{
				if (objSeg != null)
				{
					for (int i = 0; i < objSeg.Length; i++)
					{
						NivelAprobacion item = new NivelAprobacion();
						item.CODIGO = objSeg[i].codigo;
						item.CANAL = objSeg[i].descripcion;
						item.DIASMINIMO = "0";
						lista.Add(item);
					}
				}

			}
			return lista;		
		}

	}
}
