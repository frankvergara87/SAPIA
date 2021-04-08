using System;
using System.Collections;
using System.Configuration;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using Claro.SisAct.Negocios.LineasTecnologiaClienteWS;


using System.Data;
using Claro.SisAct.Datos;


namespace Claro.SisAct.Negocios
{
	public class ConsultaLineasTecnologiaNegocio
	{
		private string _NOMBRE_SERVER;
		private string _IP_SERVER;
		private string _APLICACION;
		private int _TIMEOUT;

		public string NOMBRE_SERVER
		{
			set { _NOMBRE_SERVER = value; }
			get { return _NOMBRE_SERVER; }
		}
		public string IP_SERVER
		{
			set { _IP_SERVER = value; }
			get { return _IP_SERVER; }
		}

		public string APLICACION
		{
			set { _APLICACION = value; }
			get { return _APLICACION; }
		}

		public ConsultaLineasTecnologiaNegocio()
		{
			//llena las propiedades
			_NOMBRE_SERVER = System.Net.Dns.GetHostName();
			IP_SERVER = System.Net.Dns.GetHostByName(_NOMBRE_SERVER).AddressList[0].ToString();
			APLICACION = ConfigurationSettings.AppSettings["constAplicacion"].ToString();
			obtenerTimeOut();
		}

		public ListaLineaTypeListaLineas[] consultarLineasPrePost(string K_TIPO_DOC,
			string K_NUM_DOC, out string codMensaje, out string strMensaje)
		{
            HelperLog.CrearArchivolog("Metodo consultarLineasPrePost", "Iniciando proceso: TipoDocumento: " + K_TIPO_DOC + " Documento: " + K_NUM_DOC, "", "", "");
			MED_LineasTecnologiaCliente servicio= new MED_LineasTecnologiaCliente();
			servicio.Url=ConfigurationSettings.AppSettings["RutaWSConsultaLineas3G"];
            HelperLog.CrearArchivolog("Metodo consultarLineasPrePost", "El servicio es : " + ConfigurationSettings.AppSettings["RutaWSConsultaLineas3G"], "", "", "");
            HelperLog.CrearArchivolog("Metodo consultarLineasPrePost", "preparando parametros...", "", "", "");
			servicio.Timeout=_TIMEOUT;
			servicio.headerRequest=new HeaderRequestType();
			servicio.headerRequest.fechaInicio=DateTime.Now;
			servicio.headerRequest.nodoAdicional="";
			consultarLineasPrePostRequestType request=new consultarLineasPrePostRequestType();
			request.tipoDocumento=K_TIPO_DOC;
			request.numeroDocumento=K_NUM_DOC;
			servicio.headerRequest.fechaInicio=DateTime.Now;
			servicio.headerRequest.nodoAdicional="";

            HelperLog.CrearArchivolog("Metodo consultarLineasPrePost", "Iniciando consulta WS consultarLineasPrePost:  TipoDocumento: " + K_TIPO_DOC + " Documento :" + K_NUM_DOC, "", "", "");
			consultarLineasPrePostResponseType WSresponse=servicio.consultarLineasPrePost(request);		
			codMensaje=WSresponse.responseStatus.codigoRespuesta;
			strMensaje=WSresponse.responseStatus.descripcionRespuesta;
            HelperLog.CrearArchivolog("Metodo consultarLineasPrePost", "Finalizando consulta WS consultarLineasPrePost:  codMensaje: " + codMensaje + " strMensaje :" + strMensaje, "", "", "");

            ListaLineaTypeListaLineas[] lineasdev = null;

			if (codMensaje == "0")
            {
                HelperLog.CrearArchivolog("Metodo consultarLineasPrePost", "Obteniendo las lineas", "", "", "");
                lineasdev = WSresponse.responseDataConsultarLineasPrePost.listaLineasType;
            }
            else
            {
                HelperLog.CrearArchivolog("Metodo consultarLineasPrePost", "No tiene lineas", "", "", "");
                lineasdev = null;
            }

            HelperLog.CrearArchivolog("Metodo consultarLineasPrePost", "Fin del Mètodo - consultarLineasPrePost ", "", "", "");
			return lineasdev;
		}

		private void obtenerTimeOut()
		{
			long codGrupoLineas3G, codTimeoutWSLineas3G;
			codGrupoLineas3G= Funciones.CheckInt64(ConfigurationSettings.AppSettings["codGrupoLineas3g"]);
			ArrayList lista= (new MaestroNegocio()).ListaParametrosGrupo(codGrupoLineas3G);
			//obtengo los parametros de lineasTecnologia3g
			foreach (Parametro sisactParam in lista)
			{
				//busco de la lista el timeout.
				if(sisactParam.Valor1 == "36") 
				{
					_TIMEOUT=Funciones.CheckInt(sisactParam.Valor);
					break;
				}
			}
		}
	}
}
