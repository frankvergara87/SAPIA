using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de DatosCreditos.
	/// </summary>
	public class DatosCreditos
	{
		private Int64 _SOLIN_CODIGO;
		private double _FACT_PROMEDIO;
		private string _PRODUCTO_LC;
		private string _PRODUCTO_FACT;
		private string _MSJ_AUTONOMIA;
		private string _MOTIVO;
		private string _USUARIO_CREA;
		private string _PRODUCTO_MONTO;
		private double _LC_DISPONIBLE;
		//--------------------------------------------------------
		private string _RANGO_LC_DISPONIBLE;
		private int _nroLineas;
		private int _nroLineaMenor7Dia;
		private int _nroLineaMenor30Dia;
		private int _nroLineaMenor90Dia;
		private int _nroLineaMenor180Dia;
		private int _nroLineaMayor180Dia;



		public string RANGO_LC_DISPONIBLE {get{ return _RANGO_LC_DISPONIBLE;} set{_RANGO_LC_DISPONIBLE = value;}}
		public int nroLineas {get{ return _nroLineas;} set{_nroLineas = value;}}
		public int nroLineaMenor7Dia {get{ return _nroLineaMenor7Dia;} set{_nroLineaMenor7Dia = value;}}
		public int nroLineaMenor30Dia {get{ return _nroLineaMenor30Dia;} set{_nroLineaMenor30Dia = value;}}
		public int nroLineaMenor90Dia {get{ return _nroLineaMenor90Dia;} set{_nroLineaMenor90Dia = value;}}
		public int nroLineaMenor180Dia {get{ return _nroLineaMenor180Dia;} set{_nroLineaMenor180Dia = value;}}
		public int nroLineaMayor180Dia {get{ return _nroLineaMayor180Dia;} set{_nroLineaMayor180Dia = value;}}

		public string PRODUCTO_MONTO {get{ return _PRODUCTO_MONTO;} set{_PRODUCTO_MONTO = value;}}
		public double LC_DISPONIBLE {get{ return _LC_DISPONIBLE;} set{_LC_DISPONIBLE = value;}}

		//---------------------------------------------------------

		public DatosCreditos()
		{
		}

		public Int64 SOLIN_CODIGO
		{
			get { return this._SOLIN_CODIGO; }
			set { this._SOLIN_CODIGO = value; }
		}

		public double FACT_PROMEDIO
		{
			get { return this._FACT_PROMEDIO; }
			set { this._FACT_PROMEDIO = value; }
		}

		public string PRODUCTO_LC
		{
			get { return this._PRODUCTO_LC; }
			set { this._PRODUCTO_LC = value; }
		}

		public string PRODUCTO_FACT
		{
			get { return this._PRODUCTO_FACT; }
			set { this._PRODUCTO_FACT = value; }
		}

		public string MSJ_AUTONOMIA
		{
			get { return this._MSJ_AUTONOMIA; }
			set { this._MSJ_AUTONOMIA = value; }
		}

		public string MOTIVO
		{
			get { return this._MOTIVO; }
			set { this._MOTIVO = value; }
		}

		public string USUARIO_CREA
		{
			get { return this._USUARIO_CREA; }
			set { this._USUARIO_CREA = value; }
		}
	}
}
