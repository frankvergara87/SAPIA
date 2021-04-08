using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using Claro.SisAct.Datos;
using System;

namespace Claro.SisAct.Negocios
{
	public class BLConsultaMssap
	{
		public BLConsultaMssap()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public BEParametroOficina ParametrosOficina(string sCodigoOficina)
		{
			DAConsultaMsSap obj = new DAConsultaMsSap();
			return obj.ParametrosOficina(sCodigoOficina);			
		}
		public DataSet ConsultaPedido(string nropedido, string codoficina)
		{
			ConsultaMsSap obj = new ConsultaMsSap();
			return obj.ConsultaPedido(nropedido, codoficina);
		}
		public double ConsultaDetallePrecio(string nropedido, string strNroSerie, ref string strNroError, ref string strDesError) //SD_644347 - CUOTAS - INICIO
		{
			ConsultaMsSap obj = new ConsultaMsSap();
			return obj.ConsultaDetallePrecio(nropedido, strNroSerie, ref strNroError, ref strDesError);
		} //SD_644347 - CUOTAS - FIN
		public string ConsultaPrecioApadece(string strCodMaterial)
		{
			ConsultaMsSap obj = new ConsultaMsSap();
			return obj.ConsultaPrecioApadece(strCodMaterial);
		}

//		public ArrayList ConsultaPoolPagos(string pedicestado, string fechadocumento, string codoficina)
//		{
//			ConsultaMssap  obj = new ConsultaMssap();
//			return obj.ConsultaPoolPagos(pedicestado, fechadocumento, codoficina);
//		}
		
		public ArrayList ConsultarStock(string pcodOficina, string pdesOficina, string pTipoOficina)
		{
			DAConsultaMsSap obj = new DAConsultaMsSap();
			return obj.ConsultarStock(pcodOficina,pdesOficina,pTipoOficina);
		}
				
		public ArrayList ConsultarSerieMaterial(string pCodOficina,string pDesOficina,string pCodCentro,string pcodAlmacen,string pcodMaterial, string pdescMaterial,string pTipoOficina)
		{
			DAConsultaMsSap obj = new DAConsultaMsSap();
			return obj.ConsultarSerieMaterial(pCodOficina,pDesOficina,pCodCentro,pcodAlmacen,pcodMaterial,pdescMaterial,pTipoOficina);
		}


		public ArrayList ConsultaMaterialXOficina(string pCodOficina,string pDesOficina,string pCodCentro,string pcodAlmacen,string pTipoOficina)
		{
			DAConsultaMsSap obj = new DAConsultaMsSap();
			return obj.ConsultaMaterialXOficina(pCodOficina, pDesOficina, pCodCentro, pcodAlmacen, pTipoOficina);
		}

		public ItemGenerico ConsultarSerie(string pcodSerie)
		{
			DAConsultaMsSap obj = new DAConsultaMsSap();
			return obj.ConsultarSerie(pcodSerie);
		}		
		public DataSet ConsultaClienteDT(string tipoDocCliente, string nroDocCliente)
		{
			DAConsultaMsSap obj = new DAConsultaMsSap();
			return obj.ConsultaCliente(tipoDocCliente,nroDocCliente);
		}

		public ItemGenerico ConsultaPrecioBase(string codMaterial, string desMaterial)
		{
			DAConsultaMsSap obj = new DAConsultaMsSap();
			return obj.ConsultaPrecioBase(codMaterial,desMaterial);
		}

		public ItemGenerico ConsultaPrecioVenta(string codMaterial,string codSerie,double preBase,double preVenta)
		{
			DAConsultaMsSap obj = new DAConsultaMsSap();
			return obj.ConsultaPrecioVenta(codMaterial,codSerie,preBase,preVenta);
		}

		public static ArrayList ConsultarPoolPagos(string strCadenaParametros)
		{
			return new DAConsultaMsSap().ConsultarPoolPagos(strCadenaParametros);
		}
		public String CambiarEstadoSerie(string codSerie, string codMaterial, string codOficina, string pestado)
		{
			ConsultaMsSap obj = new ConsultaMsSap();
			return obj.CambiarEstadoSerie(codSerie,codMaterial,codOficina,pestado);
		}

        public ArrayList PlanXServicios(string tipoproducto,string tipoventa)
		{
			ConsultaMsSap obj = new ConsultaMsSap();
			return obj.PlanXServicios(tipoproducto, tipoventa);
		}
		
		public ArrayList ListarPlanesTarifarios(string tipoproducto,string tipoventa)
		{
			ConsultaMsSap obj = new ConsultaMsSap();
			return obj.ListarPlanesTarifarios(tipoproducto, tipoventa);
		}

		public ArrayList ListarCuotas()
		{
			ConsultaMsSap obj = new ConsultaMsSap();
			return obj.ListarCuotas();
		}

        public BECliente ConsultaCliente(string nroDocCliente, string tipodoccliente)
		{
			ConsultaMsSap objDAL = new ConsultaMsSap();
			return objDAL.ConsultaCliente(nroDocCliente, tipodoccliente);
		}
//		public String ActualizaCliente(BECliente beClienteSap)
//		{
//			ConsultaMsSap objDAL = new ConsultaMsSap();
//			return objDAL.ActualizarCliente(beClienteSap);
//		}

		public ArrayList ListarCampanias(string codigo, string descripcion, string tipoventa, string estado)
		{
			ConsultaMsSap obj = new ConsultaMsSap();
			return obj.ListarCampanias(codigo, descripcion,  tipoventa, estado);
		}

	    public bool AnularPedido(Int64 p_nroPedido, string tipoficina)
		{
			ConsultaMsSap obj = new ConsultaMsSap();
			return obj.AnularPedido(p_nroPedido, tipoficina);
		}

		//05102015

		public ItemGenerico ConsultarSerieXPDV(string strCodOficina, string strDesOficina)
		{
			DAConsultaMsSap obj = new DAConsultaMsSap();
			return obj.ConsultarSerieXPDV(strCodOficina, strDesOficina);

		}
		//05102015
		
		//Flujo DRA 14/10/2015
		public bool ObtenerInterlocutorPadre(string codInterlocutor, ref string codInterlocutorPadre)
		{
			DAConsultaMsSap obj = new DAConsultaMsSap();
			return obj.ObtenerInterlocutorPadre(codInterlocutor, ref codInterlocutorPadre);
		}
		

    }
}
