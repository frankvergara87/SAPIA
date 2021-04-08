using System;
using System.Collections;
using Claro.SisAct.Common;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de PlanDetalleHFC.
	/// </summary>
	public class PlanDetalleHFC
	{
		public PlanDetalleHFC()
		{
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
		private double _Precio;
		private double _CF_Linea;
		private string _FlagPrincipal;
		private int _Cantidad;
		private int _Orden;
		private string _Agrupa;
		private string _Tipo;
		private string _Promocion;

		private Int64 _IdSolucion;
		private Int64 _IdPaquete;
		private Int64 _IdPromocion;
		private string _Solucion;
		private string _Paquete;

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

		public double Precio
		{
			get { return this._Precio; }
			set { this._Precio = value; }
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

		public int Cantidad
		{
			get { return this._Cantidad; }
			set { this._Cantidad = value; }
		}

		public string Agrupa
		{
			get { return this._Agrupa; }
			set { this._Agrupa = value; }
		}

		public int Orden
		{
			get { return this._Orden; }
			set { this._Orden = value; }
		}

		public string Tipo
		{
			get { return this._Tipo; }
			set { this._Tipo = value; }
		}

		public string Promocion
		{
			get { return this._Promocion; }
			set { this._Promocion = value; }
		}

		public Int64 IdSolucion
		{
			get { return this._IdSolucion; }
			set { this._IdSolucion = value; }
		}

		public Int64 IdPaquete
		{
			get { return this._IdPaquete; }
			set { this._IdPaquete = value; }
		}

		public Int64 IdPromocion
		{
			get { return this._IdPromocion; }
			set { this._IdPromocion = value; }
		}

		public string Solucion
		{
			get { return this._Solucion; }
			set { this._Solucion = value; }
		}

		public string Paquete
		{
			get { return this._Paquete; }
			set { this._Paquete = value; }
		}
	}
}
