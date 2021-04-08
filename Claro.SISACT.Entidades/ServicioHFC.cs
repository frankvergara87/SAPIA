using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de ServicioSGA.
	/// </summary>
	public class ServicioHFC
	{
		public ServicioHFC()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		private Int64 _IDDET;
		private Int64 _IdProducto;
		private Int64 _IdLinea;
		private string _Producto;
		private int _Grupo;
		private string _IdServicio;
		private string _Servicio;
		private string _IdEquipo;
		private string _Equipo;
		private double _CF_Precio;
		private double _CF_Linea;
		private string _FlagPrincipal;
		private string _FlagOpcional;
		private string _FlagDefecto;
		private int _CantVenta;
		//Renovacion
		private string _FlagVOD;

		public Int64 IDDET
		{
			get { return this._IDDET; }
			set { this._IDDET = value; }
		}

		public Int64 IdProducto
		{
			get { return this._IdProducto; }
			set { this._IdProducto = value; }
		}

		public Int64 IdLinea
		{
			get { return this._IdLinea; }
			set { this._IdLinea = value; }
		}

		public string Producto
		{
			get { return this._Producto; }
			set { this._Producto = value; }
		}

		public int Grupo
		{
			get { return this._Grupo; }
			set { this._Grupo = value; }
		}

		public string IdServicio
		{
			get { return this._IdServicio; }
			set { this._IdServicio = value; }
		}

		public string Servicio
		{
			get { return this._Servicio; }
			set { this._Servicio = value; }
		}

		public string IdEquipo
		{
			get { return this._IdEquipo; }
			set { this._IdEquipo = value; }
		}

		public string Equipo
		{
			get { return this._Equipo; }
			set { this._Equipo = value; }
		}

		public double CF_Precio
		{
			get { return this._CF_Precio; }
			set { this._CF_Precio = value; }
		}

		public double CF_Linea
		{
			get { return this._CF_Linea; }
			set { this._CF_Linea = value; }
		}

		public string FlagPrincipal
		{
			get { return this._FlagPrincipal; }
			set { this._FlagPrincipal = value; }
		}

		public string FlagOpcional
		{
			get { return this._FlagOpcional; }
			set { this._FlagOpcional = value; }
		}

		public string FlagDefecto
		{
			get { return this._FlagDefecto; }
			set { this._FlagDefecto = value; }
		}		

		public int CantVenta
		{
			get { return this._CantVenta; }
			set { this._CantVenta = value; }
		}

		//Renovacion
		public string FlagVOD
		{
			get { return this._FlagVOD; }
			set { this._FlagVOD = value; }
		}

	}
}
