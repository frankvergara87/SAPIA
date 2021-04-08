using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for BEParametrosMSSAP.
	/// </summary>
	public class BEParametrosMSSAP
	{
		public BEParametrosMSSAP()
		{			
		}

		private Int64 _IdPedidoMSSAP;	
		public Int64 IdPedidoMSSAP
		{
			get 
			{
				return _IdPedidoMSSAP;
			}
			set
			{
				_IdPedidoMSSAP=value;
			}
		}

		private string _EstadoPedidoMSSAP;
		public string EstadoPedidoMSSAP {
			get{
				return _EstadoPedidoMSSAP;
			}
			set
			{
				_EstadoPedidoMSSAP=value;
			}
		}

		private DateTime _FechaPedido;
		public DateTime FechaPedido {
			get
			{
				return _FechaPedido;
			}
			set
			{
				_FechaPedido=value;
			}
		}


		private string _TipoOficina;
		public string TipoOficina
		{
			get
			{
				return _TipoOficina;
			}
			set
			{
				_TipoOficina=value;
			}
		}
	}
}
