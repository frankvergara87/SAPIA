using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de MaterialSiscad.
	/// </summary>
	public class MaterialSiscad
	{
		public MaterialSiscad()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		private string _Matnr;
		private string _Sernr;
		private string _Vkaus;
		private string _Pos;

		public string Matnr
		{
			set{_Matnr = value;}
			get{return _Matnr;}
		}
		public string Sernr
		{
			set{_Sernr = value;}
			get{return _Sernr;}
		}
		public string Vkaus
		{
			set{_Vkaus = value;}
			get{return _Vkaus;}
		}
		public string Pos
		{
			set{_Pos = value;}
			get{return _Pos;}
		}
	}
}
