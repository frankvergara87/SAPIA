using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for BEItemGenerico.
	/// </summary>
	public class BEItemGenerico
	{
		//PROY-24724-IDEA-28174 - CLASE NUEVA
		public string _Codigo ;
		public string _Codigo2 ;
		public string _Codigo3;
		public string _Codigo4 ;
		public string _Descripcion;
		public string _Descripcion2;
		public string _Estado;
		public string _Tipo;
		public double _Monto;
		public string _Valor ;
		public int _Cantidad ;

	
		public BEItemGenerico()
		{
			
		}  

		public BEItemGenerico(string vCodigo, string vDescripcion)
		{
			_Codigo = vCodigo;
			_Descripcion = vDescripcion;
			_Codigo2 = "";
		}  

		public BEItemGenerico(string vCodigo, string vDescripcion, double vMonto)
		{
			_Codigo = vCodigo;
			_Descripcion = vDescripcion;
			_Codigo2 = string.Empty;
			_Monto = vMonto;
		}

		public string Codigo
		{
			get { return this._Codigo; }
			set { this._Codigo = value; }
		}

	
		public string Codigo2
		{
			get { return this._Codigo2; }
			set { this._Codigo2 = value; }
		}
		public string Codigo3
		{
			get { return this._Codigo3; }
			set { this._Codigo3 = value; }
		}
		public string Codigo4
		{
			get { return this._Codigo4; }
			set { this._Codigo4 = value; }
		}
		public string Descripcion
		{
			get { return this._Descripcion; }
			set { this._Descripcion = value; }
		}
		public string Descripcion2
		{
			get { return this._Descripcion2; }
			set { this._Descripcion2 = value; }
		}
		public string Estado
		{
			get { return this._Estado; }
			set { this._Estado = value; }
		}
		public string Tipo
		{
			get { return this._Tipo; }
			set { this._Tipo = value; }
		}
		public double Monto
		{
			get { return this._Monto; }
			set { this._Monto = value; }
		}
		public string Valor
		{
			get { return this._Valor; }
			set { this._Valor = value; }
		}

		public int Cantidad
		{
			get { return this._Cantidad; }
			set { this._Cantidad = value; }
		}


	}
}
