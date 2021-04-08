using System;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Configuration;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de ClienteNegocio.
	/// </summary>
	public class ClienteNegocio
	{
		public ClienteNegocio()
		{		
		}

		public Cliente ObtenerCliente(string vPHONE,string vACCOUNT,string vCONTACTOBJID_1,string vFLAG_REG,ref  string vFLAG_CONSULTA,ref string vMSG_TEXT)
		{
			
			ClienteDatos obDatos = new ClienteDatos(); 
			return obDatos.ObtenerCliente(vPHONE,vACCOUNT,vCONTACTOBJID_1,vFLAG_REG,ref  vFLAG_CONSULTA,ref vMSG_TEXT);
		}

		public void registrarDOL(string msisdn, string tipoDocumento, string numDocumento, 
			string usuario, string oficina, string ruta, string sistema,
			string estado, string flagDummy, string fechaNac, ref string strMensaje)
		{
			LineaDatosDatos objDatos = new LineaDatosDatos();
			objDatos.registrarDOL(msisdn, tipoDocumento, numDocumento, usuario, oficina, ruta, 
				sistema, estado, flagDummy, fechaNac, ref  strMensaje);
		}

		public ArrayList obtieneDatosDolMMS(string msisdn, ref string strMensaje)
		{
			LineaDatosDatos objDatos = new LineaDatosDatos();
			return objDatos.obtieneDatosDolMMS(msisdn, ref strMensaje);
		}

		public void cambiaEstadoDolMMS(int codRegistro, string msisdn, string estado)
		{
			LineaDatosDatos objDatos = new LineaDatosDatos();
			objDatos.cambiaEstadoDolMMS(codRegistro, msisdn, estado);
		}
		/*  JAZ	*/		
		public int registrarPeriodoRenovaciones(string linea, string fecha, string clase)
		{
			LineaDatosDatos objDatos = new LineaDatosDatos();
			return objDatos.registrarPeriodoRenovaciones(linea, fecha, clase);
		}

		public int consultarPeriodoRenovaciones(string linea)
		{
			LineaDatosDatos objDatos = new LineaDatosDatos();
			return objDatos.consultarPeriodoRenovaciones(linea);
		}
		/*		*/

		public int Manten_Periodo_Renov(int Cantidad, int Periodo)
		{
			RenovacionPre obDatos = new RenovacionPre(); 
			int res;
		
				res = obDatos.Manten_Periodo_Renov(Cantidad,Periodo);
		
			return res;
		}

		public string ObtienePeriodoRenov()
		{
			RenovacionPre obDatos = new RenovacionPre(); 
			string res;
		
				res = obDatos.ObtienePeriodoRenov();
		
			return res;
		}

		public string ObtieneUsrSisact(string vUsrNT)
		{
			RenovacionPre obDatos = new RenovacionPre(); 
			string res;
		
				res = obDatos.ObtieneUsrSisact(vUsrNT);
		
			return res;
		}
		//INI PROY 31636 RENTESEG
		public static bool ClienteNacionalidad_Actualizar(string strClienteNacionalidad)
		{
			ClienteDatos objClienteDatos = new ClienteDatos();
			return  objClienteDatos.ClienteNacionalidad_Actualizar(strClienteNacionalidad);
		}
		//FIN PROY 31636 RENTESEG
	}
}
