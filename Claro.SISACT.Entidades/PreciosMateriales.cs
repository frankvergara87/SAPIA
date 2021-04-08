using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de PreciosMateriales.
	/// </summary>
	public class PreciosMateriales
	{
		
		public string _CodigoOficina; 
		public string _CodigoMaterial;
		public string _descripcionMaterial;
		public string _tipoMaterial;
		public string _SerieMaterial;
		public decimal _PrecioBaseMaterial;
		public decimal _decPrecioBase;
		public decimal _decPrecioVenta;
		public decimal _decDescuentos;
		public decimal _decValorIgv;
		public decimal _decTotal;

		public string CodigoOficina 
		{
			get{ return _CodigoOficina;}
			set{ _CodigoOficina = value; }
		}

		public string CodigoMaterial 
		{
			get{ return _CodigoMaterial;}
			set{ _CodigoMaterial = value; }
		}

		public string descripcionMaterial 
		{
			get{ return descripcionMaterial;}
			set{ _descripcionMaterial = value; }
		}

		public string tipoMaterial 
		{
			get{ return _tipoMaterial;}
			set{ _tipoMaterial = value; }
		}

		public string SerieMaterial 
		{
			get{ return _SerieMaterial;}
			set{ _SerieMaterial = value; }
		}

		public decimal PrecioBaseMaterial 
		{
			get{ return _PrecioBaseMaterial;}
			set{ _PrecioBaseMaterial = value; }
		}

		public decimal decPrecioBase 
		{
			get{ return _decPrecioBase;}
			set{ _decPrecioBase = value; }
		}

		public decimal decPrecioVenta 
		{
			get{ return _decPrecioVenta;}
			set{ _decPrecioVenta = value; }
		}

		public decimal decDescuentos 
		{
			get{ return _decDescuentos;}
			set{ _decDescuentos = value; }
		}

		public decimal decValorIgv 
		{
			get{ return _decValorIgv;}
			set{ _decValorIgv = value; }
		}

		public decimal decTotal 
		{
			get{ return _decTotal;}
			set{ _decTotal = value; }
		}

	}
}
