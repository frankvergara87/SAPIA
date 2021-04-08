using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de ConsultaMsSapNegocio.
	/// </summary>
	public class ConsultaMsSapNegocio
	{
		public ConsultaMsSapNegocio()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public ArrayList ConsultaVendedores(string oficinaVenta)
		{
			ConsultaMsSap obj = new ConsultaMsSap();	
			return obj.ConsultaVendedores(oficinaVenta);
		}

		public ArrayList ConsultarListaPrecio(string strCodProducto, string strTipoVenta, string strTipoOficina, string strCodDepartamento,
											  string strCodMaterial, string strCodCampania, string intTipoOperacion, string strCodPlazo, string strCodPlan)
		{
			ConsultaMsSap obj = new ConsultaMsSap();
			return obj.ConsultarListaPrecio(strCodProducto, strTipoVenta, strTipoOficina, strCodDepartamento, strCodMaterial, strCodCampania, intTipoOperacion, strCodPlazo, strCodPlan);
		}

		public ArrayList ConsultarStock(string strCodigoOficinaMSSAP,string strDescOficina , string strTipoVenta)
		{
			ConsultaMsSap obj = new ConsultaMsSap();
			return obj.ConsultarStock(strCodigoOficinaMSSAP,strDescOficina ,strTipoVenta);

		}

		public ArrayList ConsultarSerieMaterial(string strCodigoOficinaMSSAP,string strCodigoAlmacen, string strCodigoCentro,Int32 intCantidad, string strCodigoMaterial,string strTipoVenta)
		{
			ConsultaMsSap obj = new ConsultaMsSap();
			return obj.ConsultarSerieMaterial(strCodigoOficinaMSSAP,strCodigoAlmacen,strCodigoCentro,intCantidad,strCodigoMaterial,strTipoVenta);
		}

		public PreciosMateriales Get_PrecioVenta(string strCodigoMaterial,string strSerieMaterial,decimal dblPrecioBaseMaterial,decimal dblPrecioVentaMaterial)
		{
			ConsultaMsSap obj = new ConsultaMsSap();
			return obj.Get_PrecioVenta(strCodigoMaterial,strSerieMaterial,dblPrecioBaseMaterial,dblPrecioVentaMaterial);

		}

		public ArrayList ConsultaPrecioBaseMaterial(string strCodigoMaterial)
		{
			ConsultaMsSap obj = new ConsultaMsSap();
			return obj.ConsultaPrecioBaseMaterial(strCodigoMaterial);

		}

		public ArrayList ConsultarPrecioMaterial(string codLista, string codMaterial)
		{
			ConsultaMsSap obj = new ConsultaMsSap();
			return obj.ConsultarPrecioMaterial(codLista,codMaterial);
		}

		public DataSet ParametrosOficinaVenta(string oficina)
		{
			ConsultaMsSap obj = new ConsultaMsSap();
			return obj.ParametrosOficinaVenta(oficina);
		}

		public BECliente ConsultaCliente(string nroDocCliente, string tipodoccliente)
		{
			ConsultaMsSap objDAL = new ConsultaMsSap();
			return objDAL.ConsultaCliente(nroDocCliente, tipodoccliente);
		}

		public void RegistrarPedido(string CadenaCabecera, string CadenaDetalle, ref Int64 idPedidoMsSap ,ref string codResp, ref string msgResp)
		{
			
			ConsultaMsSap objDAL = new ConsultaMsSap();
			idPedidoMsSap = objDAL.RegistrarPedido(CadenaCabecera, ref codResp, ref msgResp);
			if (idPedidoMsSap > 0)
			{
				foreach (string sDatosVentaDet in CadenaDetalle.Split('|'))
				{
					objDAL.RegistrarPedidoDetalle(idPedidoMsSap, sDatosVentaDet);
				}
			}
			
		}

		public static bool GrabarInfoRentaSAP(Int64 nroPedidoMSSAP, Int32 nroCuotasSEC, double dblMontoRenta, string strNroRentaSAP)
		{
			ConsultaMsSap objDAL = new ConsultaMsSap();
			return objDAL.GrabarInfoRentaSAP(nroPedidoMSSAP, nroCuotasSEC, dblMontoRenta, strNroRentaSAP);
		}

		public DataSet ConsultaAcuerdo(string nrocontrato, string nrosubcontrato)
		{
			ConsultaMsSap objDAL = new ConsultaMsSap();
			return objDAL.ConsultaAcuerdo(nrocontrato, nrosubcontrato);
		}
		public ArrayList ConsultaVendedoresPVU(string oficinaVenta, string estado)
		{
			ConsultaMsSap obj = new ConsultaMsSap();	
			return obj.ConsultaVendedoresPVU(oficinaVenta,estado);
		}

		public BEParametroOficina ParametrosOficina(string sCodigoOficina)
		{
			ConsultaMsSap objDAL = new ConsultaMsSap();
			return objDAL.ParametrosOficina(sCodigoOficina);

		}

		public BEParametroOficina ConsultaParametrosOficina(string pCodOficina,string pdesoficina)
		{
			ConsultaMsSap objDAL = new ConsultaMsSap();
			return objDAL.ConsultaParametrosOficina(pCodOficina,pdesoficina);
		}
		public string actualizaPedido(string nroPedido)
		{
			ConsultaMsSap objDAL = new ConsultaMsSap();
			return objDAL.actualizaPedido(nroPedido);
		}

		public Int64 RegistrarDevolucion(string CadenaCabecera, string CadenaDetalle, ref string codResp, ref string msgResp)
		{
			Int64 idPedidoMsSap = 0;
			ConsultaMsSap objDAL = new ConsultaMsSap();
			idPedidoMsSap = objDAL.RegistrarDevolucion(CadenaCabecera, ref codResp, ref msgResp);
			if (idPedidoMsSap > 0)
			{
				foreach (string sDatosVentaDet in CadenaDetalle.Split('|'))
				{
					objDAL.RegistrarDevolucionDetalle(idPedidoMsSap, sDatosVentaDet, ref codResp, ref msgResp);
					if (codResp!="0")
					{
						throw new Exception( idPedidoMsSap.ToString() + "|" +   msgResp);
					}                                                    
				}
			}
			return idPedidoMsSap;
		}

		public string reservaSerieMaterial(string codSerie)
		{
			ConsultaMsSap objDAL = new ConsultaMsSap();
			return objDAL.reservaSerieMaterial(codSerie);
		}
		//añadido 26082015

		public void ActualizarDescuentoPedido(int pNropedido, int pConsecutivo, string pCodEsquema, string pClaseCondicion, decimal pDesctMonto, out string pNrolog, out string pDeslog)
		{
			DATrsMsSap objDAL = new DATrsMsSap();
			objDAL.ActualizarDescuentoPedido(pNropedido, pConsecutivo, pCodEsquema, pClaseCondicion, pDesctMonto, out  pNrolog, out pDeslog);
			//obj.ActualizarDescuentoPedido(pNropedido, pConsecutivo, pCodEsquema, pClaseCondicion, pDesctMonto, out  pNrolog, out pDeslog);
		}

		public void RecalculaEsquema(int pNropedido, int pCodConsecutivo, string pEsquemaCalcu, out string pNrolog, out string pDeslog)
		{
			DATrsMsSap objDAL = new DATrsMsSap();
			objDAL.RecalculaEsquema(pNropedido, pCodConsecutivo, pEsquemaCalcu, out pNrolog, out pDeslog);
		}

		public void RecalculaDescuento(int pNropedido, string pEsquemaCalcu, ref string pNrolog, ref string pDeslog)
		{
			DATrsMsSap objDAL = new DATrsMsSap();
			objDAL.RecalculaDescuento(pNropedido, pEsquemaCalcu, out pNrolog, out pDeslog);

		}
		//añadido 26082015

		public string ActualizaCliente(BECliente oBEClienteSAP)
		{
			return new DATrsMsSap().ActualizaCliente(oBEClienteSAP);
		}

		public  ItemGenerico ConsultaMaterial46(string strCodMaterial)
		{
		return new ConsultaMsSap().ConsultaMaterial46(strCodMaterial);
		}
        
		//Flujo DRA 14/10/2015
		public bool ActualizarPedidoDRA(int nroGeneradoSap, string nroAsociadoDRA, ref string oNroError, ref string oDescError)
		{
			DATrsMsSap objDAL = new DATrsMsSap();
			return objDAL.ActualizarPedidoDRA(nroGeneradoSap, nroAsociadoDRA, ref oNroError, ref oDescError);
		}

		public bool EliminarPedidoMSSASP(Int64 p_nroPedido, string tipoficina)
		{			
			return new DATrsMsSap().EliminarPedidoMSSASP(p_nroPedido,tipoficina);
		}

		
		//PROY-24724-IDEA-28174 - INICIO 
		public Int64 RegistrarPedidoPM(string strCadenaCabecera, string strCadenaDetalle, ref string strCodResp, ref string strMsgResp,ref Int64 intIdPedidoMsSapRef)
		{
			Int64 IntIdPedidoMsSap = 0;
			ConsultaMsSap objDAL = new ConsultaMsSap();
			IntIdPedidoMsSap = objDAL.RegistrarPedido(strCadenaCabecera, ref strCodResp, ref strMsgResp);
			if (IntIdPedidoMsSap > 0)
			{
				intIdPedidoMsSapRef=IntIdPedidoMsSap;
				foreach (string strDatosVentaDet in strCadenaDetalle.Split('|'))
				{
					objDAL.RegistrarPedidoDetalle(IntIdPedidoMsSap, strDatosVentaDet);
				}
			}
			return IntIdPedidoMsSap;
		}
		//PROY-24724-IDEA-28174 - FIN 

		//INI PROY 31636 RENTESEG
		public static bool MSSAP_ClienteNacionalidad_Actualizar(string strClienteNacionalidad)
		{
			return new ConsultaMsSap().MSSAP_ClienteNacionalidad_Actualizar(strClienteNacionalidad);
		}
		//FIN PROY 31636 RENTESEG
	}
}
