using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de ServicioAlineacion.
	/// </summary>
	public class Servicio
	{
		private string _Plan_Tarifario;
		private string _Servicio_Solicit;
		private string _Descripcion;
		private Int32 _Orden;
		private string _Grupo;
		private Int32 _Cargo_Fijo;
		private string _Seleccionable;

		public Servicio()
		{
		}

		public Servicio(string codigo,string descripcion)
		{
			this._Servicio_Solicit=codigo;
			this._Descripcion=descripcion;
		}

		public string Plan_Tarifario
		{
			set{_Plan_Tarifario = value;}
			get{return _Plan_Tarifario;}
		}
		public string Servicio_Solicit
		{
			set{_Servicio_Solicit = value;}
			get{return _Servicio_Solicit;}
		}
		public string Descripcion
		{
			set{_Descripcion = value;}
			get{return _Descripcion;}
		}
		public Int32 Orden
		{
			set{_Orden = value;}
			get{return _Orden;}
		}
		public string Grupo
		{
			set{_Grupo = value;}
			get{return _Grupo;}
		}
		public Int32 Cargo_Fijo
		{
			set{ _Cargo_Fijo = value;}
			get{return  _Cargo_Fijo;}
		}
		public string Seleccionable
		{
			set{_Seleccionable = value;}
			get{return _Seleccionable;}
		}
	}
}
