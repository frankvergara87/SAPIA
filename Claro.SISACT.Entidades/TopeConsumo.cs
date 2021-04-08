using System;

namespace Claro.SisAct.Entidades
{
	public class TopeConsumo
	{
		private string _CODIGO;
		private string _CODPLAN;
		private string _NOMBRE;
		private string _DESCRIPCION;
		private string _ESTADO;
		private double _MONTO = 0.0;
		private double _CARGO_FIJO = 0.0;

		public TopeConsumo()
		{
		}
		public string CODIGO
		{
			set{_CODIGO = value;}
			get{ return _CODIGO;}
		}
		public string CODPLAN
		{
			set{_CODPLAN = value;}
			get{ return _CODPLAN;}
		}
		public string NOMBRE
		{
			set{_NOMBRE = value;}
			get{ return _NOMBRE;}
		}
		public string DESCRIPCION
		{
			set{_DESCRIPCION = value;}
			get{ return _DESCRIPCION;}
		}
		public string ESTADO
		{
			set{_ESTADO = value;}
			get{ return _ESTADO;}
		}

		public double MONTO
		{
			set{_MONTO =value;}
			get{return _MONTO;}
		}

		public double CARGO_FIJO
		{
			set{_CARGO_FIJO =value;}
			get{return _CARGO_FIJO;}
		}
	}
}
