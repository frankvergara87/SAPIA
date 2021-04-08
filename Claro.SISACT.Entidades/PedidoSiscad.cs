using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de PedidoSiscadSap.
	/// </summary>
	public class PedidoSiscad
	{
		public PedidoSiscad()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		private string _Werks;
		private string _Lgort;
		private string _Auart;
		private string _Vkorg;
		private string _Kunnr;
		private string _Kunag;
		private string _Vtweg;
		private string _Spart;
		private string _Matnr;
		private string _Vkbur;
		private int _Menge;
		private string _Vkaus;
		private string _Pos;

		public string Werks
		{
			set{_Werks = value;}
			get{return _Werks;}
		}
		public string Lgort
		{
			set{_Lgort = value;}
			get{return _Lgort;}
		}
		public string Auart
		{
			set{_Auart = value;}
			get{return _Auart;}
		}
		public string Vkorg
		{
			set{_Vkorg = value;}
			get{return _Vkorg;}
		}
		public string Kunnr
		{
			set{_Kunnr = value;}
			get{return _Kunnr;}
		}
		public string Kunag
		{
			set{_Kunag = value;}
			get{return _Kunag;}
		}
		public string Vtweg
		{
			set{_Vtweg = value;}
			get{return _Vtweg;}
		}
		public string Spart
		{
			set{_Spart = value;}
			get{return _Spart;}
		}
		public string Matnr
		{
			set{_Matnr = value;}
			get{return _Matnr;}
		}
		public string Vkbur
		{
			set{_Vkbur = value;}
			get{return _Vkbur;}
		}
		public string Vkaus
		{
			set{_Vkaus = value;}
			get{return _Vkaus;}
		}
		public int Menge
		{
			set{_Menge = value;}
			get{return _Menge;}
		}
		public string Pos
		{
			set{_Pos = value;}
			get{return _Pos;}
		}
	}
}
