using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for BLConsulta.
	/// </summary>
	public class BLConsulta
	{
		public BLConsulta()
		{	
		}


		public ArrayList ConsultaVendedor(string codOficina, out int result)
		{
			DAConsulta obj = new DAConsulta();
			return obj.ConsultaVendedor(codOficina, out result);			
		}
		
		public DataSet ConsultaClaseDocumentoOficina(string tipOficina, out int result)
		{
//			DAConsulta obj = new DAConsulta();
//			DataSet ds = new DataSet();
//			ds.Tables.Add(obj.ConsultaClaseDocumentoOficina(tipOficina, out result));
//			return ds;

			DAConsulta obj = new DAConsulta();
			return obj.ConsultaClaseDocumentoOficina(tipOficina, out result);
		}

		public ArrayList ConsultaListaPrecios( string codProducto, string codTipoVenta, string codCanal, string departamento, string codMaterial, string codCampania, int codTipOperacion ,string codPlazo, string plan )
		{
			DAConsulta obj = new DAConsulta();
			return obj.ConsultaListaPrecios(codProducto, codTipoVenta, codCanal, departamento, codMaterial, codCampania, codTipOperacion ,codPlazo, plan);
		}

		public ArrayList ConsultaServiciosXPlan(string sTipProducto,string sPlanCodigo)
		{
			DAConsulta obj = new DAConsulta();
			return obj.ConsultaServiciosXPlan(sTipProducto,sPlanCodigo);			
		}
		
//		public void ConsultaCierreCajaPVU(string pFecha,string pUsuario, string poficina, out string CierreReal)
//		{
//			DAConsulta obj = new DAConsulta();
//			obj.ConsultaCierreCajaPVU( pFecha, pUsuario,  poficina, out CierreReal);			
//		}

		public ArrayList ConsultaEquiposAlternativos()
		{
			DAConsulta obj = new DAConsulta();
			return obj.ConsultaEquiposAlternativos();
		}
		//'PROY-24724-IDEA-28174 - INICIO
		public void ConsultarPrecioListaPrepago(string strP_MATERIAL,Int64 intP_LISTAPRECIO, ref double dblP_PRECIOPREPAGO,ref string strMsg)
		{
			DAConsulta obj = new DAConsulta();
			obj.ConsultarPrecioListaPrepago(strP_MATERIAL, intP_LISTAPRECIO, ref dblP_PRECIOPREPAGO,ref strMsg);
		}
		//'PROY-24724-IDEA-28174 - FIN
		//gaa20170327
		public string ObtenerBuroDescripcion(string strBuroCodigo)
		{
			DAConsulta obj = new DAConsulta();
			return obj.ObtenerBuroDescripcion(strBuroCodigo);
		}
		//fin gaa20170327
	}
}
