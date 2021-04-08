using System;
using System.Collections; 
using Claro.SisAct.Datos; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using System.Configuration;

namespace Claro.SisAct.Negocios
{
	public class GeneralNegocios
	{
		public GeneralNegocios()
		{
		}
		
		public ArrayList ListarTipoDocumentoCliente() 
		{ 
			GeneralDatos oGral = new GeneralDatos(); 
			return oGral.ListarTipoDocumentoCliente(); 
		} 
				
		public ArrayList ListarNacionalidad() 
		{ 
			GeneralDatos oGral = new GeneralDatos(); 
			return oGral.ListarNacionalidad(); 
		}
 
		public Usuario DatosUsuario(string p_cod_usuario, string p_cod_red)
		{
			Usuario eUsuario = null;
			//HelperLog objlog = new HelperLog();
		
			string strIdentifyLog = p_cod_usuario + "-" + p_cod_red;
			string valordevuelto=string.Empty;
			//objlog.CrearArchivolog("ServicesNegocios","Antes de llamar el WS para obtener datos del empleado","Cod. Usuario: " +p_cod_usuario + " Cta. red: " + p_cod_red, "","");
      
				DatosEmpleadoWS.EbsDatosEmpleadoService objEmpleado = new DatosEmpleadoWS.EbsDatosEmpleadoService();
				DatosEmpleadoWS.DatosEmpleadoRequest requestDatosEmpleados = new DatosEmpleadoWS.DatosEmpleadoRequest();
				DatosEmpleadoWS.DatosEmpleadoResponse responseDatosEmpleados= new DatosEmpleadoWS.DatosEmpleadoResponse();

				requestDatosEmpleados.idUsu = p_cod_usuario;
				requestDatosEmpleados.loginNt = p_cod_red;
				objEmpleado.Url = ConfigurationSettings.AppSettings["urlWS"].ToString();
				objEmpleado.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["timeDatosEmpleado"].ToString()); ;


				responseDatosEmpleados = objEmpleado.obtenerDatosEmpleadoPorId(requestDatosEmpleados);
				eUsuario = new Usuario();
				if(responseDatosEmpleados.codRes.Equals("0"))
				{
					eUsuario.Nombre = responseDatosEmpleados.empleado.nombre;
					eUsuario.Apellidos = responseDatosEmpleados.empleado.apellido + " " + responseDatosEmpleados.empleado.apellidoMaterno;
					eUsuario.CodigoVendedor = responseDatosEmpleados.empleado.idCodvendedorSap;
					eUsuario.OficinaId = responseDatosEmpleados.empleado.idArea;
					eUsuario.AreaUsuario = responseDatosEmpleados.empleado.descArea;
					eUsuario.Login= responseDatosEmpleados.empleado.login;
					
					valordevuelto += "Nombre: " + responseDatosEmpleados.empleado.nombre;
					valordevuelto += "Apellidos: " + responseDatosEmpleados.empleado.apellido + " " + responseDatosEmpleados.empleado.apellidoMaterno;
					valordevuelto += "CodVendedorSap: "+responseDatosEmpleados.empleado.idCodvendedorSap;
					valordevuelto += "Id Area: " + responseDatosEmpleados.empleado.idArea;
					valordevuelto +="Desc. Area: "+ responseDatosEmpleados.empleado.descArea;
					valordevuelto +="Login: "+ responseDatosEmpleados.empleado.login;

					//objlog.CrearArchivolog("ServicesNegocios","Despues de llamar el WS para obtener datos del empleado","Cod. Usuario: " +p_cod_usuario + " Cta. red: " + p_cod_red,valordevuelto,"");
      
				}
				else
				{
					//objlog.CrearArchivolog("ServicesNegocios","Despues de llamar el WS para obtener datos del empleado","Cod. Usuario: " +p_cod_usuario + " Cta. red: " + p_cod_red,valordevuelto,responseDatosEmpleados.mensaje);
      
					eUsuario= null;

				}
				
				return eUsuario;
			
		}

		public ArrayList ListarTipoDocumento()
		{
			return new GeneralDatos().ListarTipoDocumento();
		}

		public ArrayList ListarParametroGeneral(string strCodigo)
		{
			return new GeneralDatos().ListarParametroGeneral(strCodigo);
		}
		

		public string ListaPrefijosApellidoCompuesto()
		{
			return new GeneralDatos().ListaPrefijosApellidoCompuesto();
		}

		public ArrayList ListarTipoCuota()
		{
			return new GeneralDatos().ListarTipoCuota();
		}

		public void ConsultarDatosDireccion(string idDepartamento, string idProvincia, string idDistrito,ref string strDepartamento, ref string strProvincia, ref string strDistrito)
		{
			new GeneralDatos().ConsultarDatosDireccion(idDepartamento, idProvincia, idDistrito, ref strDepartamento, ref strProvincia, ref strDistrito);
		}

		public ArrayList ListarPlazoAcuerdo(string strCasoEspecial)
		{
			return new GeneralDatos().ListarPlazoAcuerdo(strCasoEspecial);
		}

		public ArrayList ListarProducto()
		{
			return new GeneralDatos().ListarProducto();
		}

		public ArrayList ListarTipoGarantia(string strTipoGarantia, string strEstado)
		{
			return new GeneralDatos().ListarTipoGarantia(strTipoGarantia, strEstado);
		}

	}
}
