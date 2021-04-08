using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Collections;
using Claro.SisAct.Common;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de NivelAprobacionNegocio.
	/// </summary>
	public class NivelAprobacionNegocio
	{
		private NivelAprobacionDatos objDatosNivelesAprobacion;

		public NivelAprobacionNegocio()
		{
		}

		public DataTable ListarNivelesDeAprobacionXTipo(string v_tipo)
		{
			NivelAprobacionDatos obj = new NivelAprobacionDatos();
			return obj.ListarNivelesDeAprobacionXTipo(v_tipo);
		}

		public bool ActualizarNivelesDeAprobacion(int v_codigo, string v_estado, int v_cantidad, string v_usuario)
		{
			NivelAprobacionDatos obj = new NivelAprobacionDatos();
			return obj.ActualizarNivelesDeAprobacion(v_codigo, v_estado, v_cantidad, v_usuario);
		}

		public bool ObtenerPerfilPorMonto(string v_tipo, double v_cantidad, ref string v_perfil_codigo, ref string v_perfil_descripcion)
		{
			NivelAprobacionDatos obj = new NivelAprobacionDatos();
			return obj.ObtenerPerfilPorMonto( v_tipo, v_cantidad, ref v_perfil_codigo, ref v_perfil_descripcion);
		}
		public ArrayList ConsultarPerfilesMonto(string v_tipo, double v_cantidad )
		{
			NivelAprobacionDatos obj = new NivelAprobacionDatos();
			return obj.ConsultarPerfilesMonto( v_tipo, v_cantidad);
		}
		public ArrayList ConsultarPerfilesMontoMeses(string v_tipo, double v_cantidad )
		{
			NivelAprobacionDatos obj = new NivelAprobacionDatos();
			return obj.ConsultarPerfilesMontoMeses( v_tipo, v_cantidad);
		}
		public string ValidarPerfilesMeses(string pUsuario, string pClave, string pCadenaPerfiles, double vMonto)
		{
			string nameArchivo = "LOG_NivelAprobacionNegocio";	
			string initFormatLog = pUsuario + " " + string.Format("{0:dd-MM-yyyy hh:mm:ss}", DateTime.Now) + " | ";
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles + " ***************** Inicio ValidacionUsuario", false);
			string strTipo = System.Configuration.ConfigurationSettings.AppSettings["constTipoNivelMeses"];
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles + " PARAM strTipo: " + strTipo, false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles + " PARAM vMonto: " + vMonto, false);
			ArrayList listPerfil = ConsultarPerfilesMontoMeses(strTipo, vMonto);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles +" PARAM listPerfil: " + listPerfil.Count, false);
			bool resultado = false;
			string strCodPerfil = string.Empty;
			string[] sArrayPerfiles;
			string strcodAplicacion  = System.Configuration.ConfigurationSettings.AppSettings["CodigoAplicacion"];
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles + " PARAM CodigoAplicacion: " + strcodAplicacion, false);
			string sPerfilAutorizado = "-1";
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles + "***************** Inicio WSSeguridad", false);
				ConsulSeguridad cs = new ConsulSeguridad();
				string idTrans = string.Empty;
				string errorMsg = string.Empty;
				string codError = string.Empty;
				long codApp = Convert.ToInt64(System.Configuration.ConfigurationSettings.AppSettings["CodigoAplicacion"]);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles + " PARAM CodigoAplicacion: " + codApp, false);
				string ipApp = System.Configuration.ConfigurationSettings.AppSettings["strWebIpCod"];
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles + " PARAM strWebIpCod: " + ipApp, false);
				string nomApp = System.Configuration.ConfigurationSettings.AppSettings["NombreAplicacion"];
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles + " PARAM NombreAplicacion: " + nomApp, false);
				ArrayList lista;
				
				lista = cs.verificaUsuario(ref idTrans, ipApp, nomApp, pUsuario.Trim(), codApp, ref errorMsg, ref codError);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog + pCadenaPerfiles + " PARAM idTrans: " + idTrans, false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog + pCadenaPerfiles + " PARAM errorMsg: " + errorMsg, false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog + pCadenaPerfiles + " PARAM codError: " + codError, false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog + pCadenaPerfiles + "lista " + lista.Count, false);

				if(lista.Count > 0)
				{
					foreach(Claro.SisAct.Entidades.ConsulSeguridad item in lista)
					{
						strCodPerfil = strCodPerfil + item.PERFCCOD + ",";
					}
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles + " Perfiles WS: " + strCodPerfil, false);
				}
				else 
				{
					strCodPerfil = string.Empty;
					sPerfilAutorizado = "-1";
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles + "Perfiles WS: " + strCodPerfil, false);
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles + "PerfilAutorizado: " + sPerfilAutorizado + " (No)", false);
				}

				if(listPerfil.Count == 0)
				{
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles + " listPerfil: " + listPerfil.Count, false);
					sPerfilAutorizado = "-1";
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles + " PerfilAutorizado: " + sPerfilAutorizado + " (No)", false);
					return sPerfilAutorizado;
				}
				strCodPerfil = strCodPerfil.Substring(0, strCodPerfil.Length - 1);

				if(strCodPerfil.Length > 0)
				{
					sArrayPerfiles = strCodPerfil.ToString().Split(Convert.ToChar(","));
					foreach(ItemGenerico sPerfilJerarquico in listPerfil)
					{
						string sPerOri = sPerfilJerarquico.Descripcion2.ToString();
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles + " PARAM Perfil BD: " + sPerOri, false);
						foreach(string sPerfilWS in sArrayPerfiles)
						{
						HelperLog.EscribirLog("", nameArchivo, initFormatLog + pCadenaPerfiles + " PARAM Perfil WS: " + sPerfilWS, false);
						HelperLog.EscribirLog("", nameArchivo, initFormatLog + pCadenaPerfiles + " PARAM Perfiles Validados: " + sPerOri + "=" + sPerfilWS, false);
							if(sPerOri == sPerfilWS)
							{
								sPerfilAutorizado = sPerOri;
							resultado = true;
								break;  
							}
						}	
					if(resultado) 
						{
						HelperLog.EscribirLog("", nameArchivo, initFormatLog + pCadenaPerfiles + " PerfilAutorizado: " + sPerfilAutorizado + " (No)", false);
							break;
						}								
					}
				}
				else
				{
					sPerfilAutorizado = "-1";
				HelperLog.EscribirLog("", nameArchivo, initFormatLog + pCadenaPerfiles + " PerfilAutorizado: " + sPerfilAutorizado + " (No)", false);
			}
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles + " PARAM Retorno sPerfilAutorizado: " + sPerfilAutorizado, false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + pCadenaPerfiles + " ***************** Fin ValidacionUsuario", false);
			return sPerfilAutorizado;
		}

		public ArrayList ListarNivelesDeAprobacionMeses(string v_tipo)
		{
			objDatosNivelesAprobacion = new NivelAprobacionDatos();
			return objDatosNivelesAprobacion.ListarNivelesDeAprobacionMeses(v_tipo);
		}

		public int InsertarActualizaDatosNivelesAprobacionXtipo(string strPerfilVin, string strTipo, string strEstado, string strPerfilDesc, string strCantidad, string strUsuario, ref string msgerror, ref string iderror)
		{
			objDatosNivelesAprobacion = new NivelAprobacionDatos();
			return objDatosNivelesAprobacion.InsertarActualizaDatosNivelesAprobacionXtipo(strPerfilVin, strTipo, strEstado, strPerfilDesc, strCantidad, strUsuario, ref msgerror, ref iderror);
		}

		public void ObtenerCantidadMaxMinAutorizacion(ref double nCantidadMaxima, ref double nCantidadMinima)
		{
			NivelAprobacionDatos objNegocio = new NivelAprobacionDatos();
			objNegocio.ObtenerCantidadMaxMinAutorizacion(ref nCantidadMaxima, ref nCantidadMinima);
		}
	}
}
