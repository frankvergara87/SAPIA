using System;
using System.Configuration;
using System.Collections;
using System.Net;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de ConsulSeguridad.
	/// </summary>
	public class ConsulSeguridad
	{
		public ConsulSeguridad()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public ArrayList verificaUsuario(ref string idTrans, string IpAplicacion, string Aplicacion, string usuario, long appCod, ref string errorMsg, ref string codError)
		{
			ArrayList lista = new ArrayList();			
			try
			{
				ConsultaSeguridad.ConsultaSeguridad ConsSegur = new ConsultaSeguridad.ConsultaSeguridad();
				ConsSegur.Url = ConfigurationSettings.AppSettings["strWebServiceDBAUDIT"];
				ConsSegur.Credentials = System.Net.CredentialCache.DefaultCredentials;
				ConsultaSeguridad.seguridadType[] objSeg;
				codError = ConsSegur.verificaUsuario(ref idTrans, IpAplicacion, Aplicacion, usuario, appCod, out errorMsg, out objSeg);
				
				if (objSeg != null)
				{
					for(int i=0; i< objSeg.Length ; i++)
					{
						Claro.SisAct.Entidades.ConsulSeguridad item = new Claro.SisAct.Entidades.ConsulSeguridad();
						item.USUACCOD = objSeg[i].UsuacCod;
						item.PERFCCOD = objSeg[i].PerfcCod;
						item.USUACCODVENSAP = objSeg[i].UsuacCodVenSap;
						lista.Add(item);
					}
				}
				
			}
			catch(Exception e)
			{
				
				errorMsg = e.Message.ToString();
			}
			return lista;
		}
	}
}
