using System;

namespace Claro.SisAct.Entidades
{
	public class VentaSiscad
	{
		public VentaSiscad()
		{
		}

		private int _IdVenta = 0;
		private string _TipoDocCliente = "";
		private string _NroDocCliente = "";
		private string _TicketPreventa = "";
		private string _PuntoVenta = "";
		private string _NroPedidoSap = "";
		private string _NroEntregaSap = "";
		private string _NroContratoSap = "";
		private string _NroDocumentoSap = "";
		private string _TipoVenta = "";
		private string _EstadoVenta = "";
		private string _TicketVenta = "";
		private string _TipoOperacion = "";
		private string _Usuario = "";
		private string _CodAplicacion = "";
		private string _FechaCierre = "";
		private string _nroDocVendedor = "";
		private string _nombreVendedor = "";

		private string _nropedido_mssap = "";

		public string nropedido_mssap
		{
			get { return _nropedido_mssap; }
			set { _nropedido_mssap = value; }
		}

		public string NroDocVendedor
		{
			get { return _nroDocVendedor; }
			set { _nroDocVendedor = value; }
		}

		public string NombreVendedor
		{
			get { return _nombreVendedor; }
			set { _nombreVendedor = value; }
		}


		public int IdVenta
		{
			get { return _IdVenta; }
			set { _IdVenta = value; }
		}
		public string TipoDocCliente
		{
			get { return _TipoDocCliente; }
			set { _TipoDocCliente = value; }
		}
		public string NroDocCliente
		{
			get { return _NroDocCliente; }
			set { _NroDocCliente = value; }
		}
		public string TicketPreventa
		{
			get { return _TicketPreventa; }
			set { _TicketPreventa = value; }
		}
		public string PuntoVenta
		{
			get { return _PuntoVenta; }
			set { _PuntoVenta = value; }
		}
		public string NroPedidoSap
		{
			get { return _NroPedidoSap; }
			set { _NroPedidoSap = value; }
		}
		public string NroEntregaSap
		{
			get { return _NroEntregaSap; }
			set { _NroEntregaSap = value; }
		}
		public string NroContratoSap
		{
			get { return _NroContratoSap; }
			set { _NroContratoSap = value; }
		}
		public string NroDocumentoSap
		{
			get { return _NroDocumentoSap; }
			set { _NroDocumentoSap = value; }
		}
		public string TipoVenta
		{
			get { return _TipoVenta; }
			set { _TipoVenta = value; }
		}
		public string EstadoVenta
		{
			get { return _EstadoVenta; }
			set { _EstadoVenta = value; }
		}
		public string TicketVenta
		{
			get { return _TicketVenta; }
			set { _TicketVenta = value; }
		}

		public string TipoOperacion
		{
			get { return _TipoOperacion; }
			set { _TipoOperacion = value; }
		}
		public string Usuario
		{
			get { return _Usuario; }
			set { _Usuario = value; }
		}
		public string CodAplicacion
		{
			get { return _CodAplicacion; }
			set { _CodAplicacion = value; }
		}
		public string FechaCierre
		{
			get { return _FechaCierre; }
			set { _FechaCierre = value; }
		}
	}
}
