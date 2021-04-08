using System;
using System.Collections;
using Claro.SisAct.Datos;
using System.Data;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de VentaNegocios.
	/// </summary>
	public class VentaNegocios
	{
		public VentaNegocios()
		{
		}
		public String ObtenerNroHLR(string Msisdn)
		{
			VentaDatos obj = new VentaDatos();
			return obj.ObtenerNroHLR(Msisdn);
		}
		public bool ConsultaValidacionCliente(string tipoDocumento, string nroDocumento, string nroTelefono, ref string flag_valida, ref string msg_text)
		{
			VentaDatos obj = new VentaDatos();		
			return obj.ConsultaValidacionCliente(tipoDocumento, nroDocumento, nroTelefono,ref flag_valida, ref msg_text);
		}
		public ArrayList ListaTipoDocumento(string flag_ruc)
		{
			VentaDatos obj = new VentaDatos();
			return obj.ListaTipoDocumento(flag_ruc);
		}
		public ArrayList ListaPDVUsuario(Int64 cod_usuario,string cod_producto)
		{
			VentaDatos obj = new VentaDatos();
			return obj.ListaPDVUsuario(cod_usuario,cod_producto);
		}

		public bool ConsultaValidacionClientePostpago(string tipoDocumento, string nroDocumento, string nroTelefono, ref string flag_valida, ref string msg_text)
		{
			VentaDatos obj = new VentaDatos();		
			return obj.ConsultaValidacionClientePostpago(tipoDocumento, nroDocumento, nroTelefono,ref flag_valida, ref msg_text);
		}
			public string ConsultaLineaBloqueada(int p_co_id, int p_sncode)
		{
			VentaDatos obj = new VentaDatos();
			return obj.ConsultaLineaBloqueada(p_co_id, p_sncode);		
		}
		// FES *****

		public Boolean ConsultaStatusContrato(int p_co_id, ref string estadoContrato, ref string estadoBloqueo)
		{
			VentaDatos obj = new VentaDatos();
			return obj.ConsultaStatusContrato(p_co_id, ref estadoContrato, ref estadoBloqueo);		
		}

		public DataTable ConsultaVentaCuotas(string strTipoDocumento, string strNroDocumento, string strIMEI, string strLinea)
		{	
			VentaDatos obj = new VentaDatos();		
			return obj.ConsultaVentaCuotas(strTipoDocumento, strNroDocumento, strIMEI, strLinea);
		}

	}
}
