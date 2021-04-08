using System;

namespace Claro.SisAct.Entidades
{
	public class OrdenVentaSiscad
	{
		public OrdenVentaSiscad()
		{
			
		}

		private string _TicketPreventa;
		private string _CodigoMaterial;
		private string _DescMaterial;
		private string _Serie;
		private decimal _Precio;
		private string _ListaPrecio;
		private string _DesListaPrecio;
		private string _PuntoVenta;		
		private int _Identificador;
		private string _NroTelefono;
		private string _EstadoMaterial;
		private string _OrigenVenta;

		public string TicketPreventa
		{
			get { return _TicketPreventa; }
			set { _TicketPreventa = value; }
		}
		public string CodigoMaterial
		{
			get { return _CodigoMaterial; }
			set { _CodigoMaterial = value; }
		}
		
		public string DescMaterial
		{
			get { return _DescMaterial; }
			set { _DescMaterial = value; }
		}
		public string Serie
		{
			get { return _Serie; }
			set { _Serie = value; }
		}
		public decimal Precio
		{
			get { return _Precio; }
			set { _Precio = value; }
		}
		public string ListaPrecio
		{
			get { return _ListaPrecio; }
			set { _ListaPrecio = value; }
		}
		
		public string DesListaPrecio
		{
			get { return _DesListaPrecio; }
			set { _DesListaPrecio = value; }
		}
		public string PuntoVenta
		{
			get { return _PuntoVenta; }
			set { _PuntoVenta = value; }
		}
		public int Identificador
		{
			get { return _Identificador; }
			set { _Identificador = value; }
		}
		public string NroTelefono
		{
			get { return _NroTelefono; }
			set { _NroTelefono = value; }
		}
		
		public string EstadoMaterial
		{
			get { return _EstadoMaterial; }
			set { _EstadoMaterial = value; }
		}
		public string OrigenVenta
		{
			get { return _OrigenVenta; }
			set { _OrigenVenta = value; }
		}
	}
}
