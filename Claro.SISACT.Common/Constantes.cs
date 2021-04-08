using System;

namespace Claro.SisAct.Common
{
	public enum TOperacionCRUD: byte
	{
		crear = 1,
		actualizar =2,
		eliminar= 3,
		visualizar = 4
	}

	/// <summary>
	/// Summary description for Constantes.
	/// </summary>
	public sealed class Constantes
	{
		public const int ID_TABLA_TIPO_PDV = 1;
		public const int ID_TABLA_ESTADO_TABLA =2;
		public const int ID_TABLA_DESCUENTO_ESPECIAL = 3;
		public const int ID_TABLA_TIPO_BOLSA = 4;
		public const int ID_TABLA_NIVEL_HABILITACION = 5;
		public const int ID_TABLA_TIPO_VENTA = 6;
		public const int ID_TABLA_TIPO_ACUERDO = 7;
		public const int ID_TABLA_OPCION_ACUERDO_B01 = 8;
		public const int ID_TABLA_OPCION_ACUERDO_B03 = 9;
		public const int ID_TABLA_EXTENSION = 10;
		public const int ID_TABLA_DETALLE_AMP_RED = 11;
		public const int ID_TABLA_TIPO_CLIENTE = 12;

		public Constantes()
		{
		}

		public static string MSSapPedido = ".SSAPSI_PEDIDO";
		public static string MSSapDetallePedido = ".SSAPSI_DETALLEPEDIDO";
		public static string MSSapAnularPedido = ".SSAPSU_ANULARPEDIDO";
		public static string MSSapActualizarPedido = ".SSAPSU_ACTUALIZARPEDIDO"; // falta pasen store procedure en package

		public static string MSSapMateOficina = ".SSAPSS_MATERIALXOFICINA";		
		public static string MSSapStockDisponible = ".SSAPSS_STOCK";
		public static string MSSapSeriesMaterial = ".SSAPSS_SERIEXMATERIAL";
		public static string MSSapValidaSeries = ".SSAPSS_VALIDASERIE";
		public static string MSSapPreciosBase = ".SSAPSS_PRECIOBASE";
		public static string MSSapPrecioVenta = ".SSAPSS_PREVENTA";
		//public static string MSSapParametroOficina = ".SSAPSS_PARAMETROOFICINA";
		public static string MSSapParametroOficina = ".sisacs_datos_oficina";		
		public static string MSSapDatosCliente = ".SSAPSS_CLIENTE";

		public static string MSSapConsultaVendedor = ".SISACT_VENDEDORES_SAP_CONS";
		public static string MSSapConsultaClasePedidoOficina = ".SISACT_OFICINA_DOCU_CONS";
		public static string MSSapCampanasTipVentas = ".SP_CON_CAMPANHAS_TIPO_VENTA";
		public static string MSSapConsListaPrecios = ".SISACSS_CONSULTAR_LISTAPRECIOS";	
		public static string MSSapConsPlanServicio = ".SP_CON_PLAN_X_SERVICIO";	

		public static string SinergiaSapPago = ".SSAPSI_PAGO";
		public static string SinergiaSapDetallePago = ".SSAPSI_DETALLEPAGO";
		public static string SinergiaSapDatosCliente = ".SSAPSS_CLIENTE";

		#region PROY-26366 | Fidelizacion y Claro Puntos

		public static string SisactListarDatosNCxDocSAP = ".MANTS_SELECT_PUNTOS_CC_DOC_SAP";
		public static string SisactInsertarDetaClaroPuntos = ".SISAI_CANJE_PUNTOS_DET";

		#endregion  
	}
}
