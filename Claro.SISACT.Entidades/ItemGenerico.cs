using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for TipoDocumento.
	/// </summary>
	public class ItemGenerico
	{
		private string _codigo;
		private string _descripcion;
		private string _codigo2;		
		private string _estado;
		private int _orden;

		//T12618 - Portabilidad - INICIO
		private string _numero;
		private string _tipo;
		//T12618 - Portabilidad - FIN

		//Pmarcos Inicio
		private string _descripcion2;
		//Pmarcos Fin
		
		private double _monto;
		private string _fecha2;
		
		//Pablo Zea - Vendedores 20/05/2009 Inicio
		private string _fecha;
                //Pablo Zea - Vendedores 20/05/2009 Fin

		//Renovacion
		private double _valor;

		//Temporal M
		private string _valor2;

		public ItemGenerico()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public ItemGenerico(string vCodigo,string vDescripcion)
		{			
			_codigo = vCodigo;
			_descripcion = vDescripcion;
			_codigo2 = "";
			_estado = "";
		}
		public ItemGenerico(string vCodigo,string vDescripcion,string vEstado)
		{
			_codigo = vCodigo;
			_descripcion = vDescripcion;
			_estado = vEstado;
		}
		public ItemGenerico(string vCodigo,string vCodigo2,string vDescripcion,string vEstado)
		{
			_codigo = vCodigo;
			_codigo2 = vCodigo2;
			_descripcion = vDescripcion;
			_estado = vEstado;
		}
		public string Codigo{
			set{_codigo= value;}
			get{ return _codigo;}
		}
		public string Descripcion{
			set{_descripcion= value;}
			get{ return _descripcion;}
		}
		public string Codigo2
		{
			set{_codigo2= value;}
			get{ return _codigo2;}
		}
		public string estado
		{
			set{_estado= value;}
			get{ return _estado;}
		}
		//Pmarcos Inicio
		public string Descripcion2
		{
			set{_descripcion2= value;}
			get{ return _descripcion2;}
		}
		//Pmarcos Fin		
		public int orden
		{
			set{_orden= value;}
			get{ return _orden;}
		}
		//Pablo Zea - Vendedores 20/05/2009 Inicio
		public string Fecha
		{
			set{ _fecha = value; }
			get{ return _fecha; }
		}
		//Pablo Zea - Vendedores 20/05/2009 Fin

		//T12618 - Portabilidad - INICIO
		public string Numero
		{
			set{_numero= value;}
			get{ return _numero;}
		}

		public string Tipo
		{
			set{_tipo= value;}
			get{ return _tipo;}
		}
		//T12618 - Portabilidad - FIN
		
		public double Monto
		{
			set{ _monto= value; }
			get{ return _monto; }
		}
		public string Fecha2
		{
			set{ _fecha2 = value; }
			get{ return _fecha2; }
		}

		//Renovacion

		public double Valor
		{
			set{_valor= value;}
			get{ return _valor;}
		}
		
		//MDE INI
		public string Valor2
		{
			set{_valor2= value;}
			get{ return _valor2;}
		}
		//MDE FIN

//--incio-dga-31072015
		//MUC - Inicio Sinergia
		private string _PuntoVenta;
		private double _PrecioBase;
		private double _PrecioCompra;
		private string _codCentro;
		private string _codAlmacen;
		private string _codOficina;
		private string _desOficina;
		private int _stockVenta ;
		private string _tipoMaterial;
		private string _serie;

		private string _CODMATERIAL_OUT;
		private string _DESCRIPCION_OUT;
		private string _CODSERIE_OUT;
		private decimal _PRECIOBASE_OUT;
		private decimal _PRECIOVENTA_OUT;
		private decimal _DESCUENTO_OUT;
		private decimal _IGV_OUT;
		private decimal _TOTAL_OUT;
		//MUC - Fin Sinergia

		//05102015
		private string _CodInterlocutor;
		private string _CodInterlocutorPadre;
		public string CodInterlocutor
		{
			set{_CodInterlocutor= value;}
			get{ return _CodInterlocutor;}
		}
		public string CodInterlocutorPadre
		{
			set{_CodInterlocutorPadre= value;}
			get{ return _CodInterlocutorPadre;}
		}
		//05102015
		public string PuntoVenta
		{
			set{_PuntoVenta= value;}
			get{ return _PuntoVenta;}
		}
		public double PrecioBase
		{
			set{_PrecioBase= value;}
			get{ return _PrecioBase;}
		}
		public double PrecioCompra
		{
			set{_PrecioCompra= value;}
			get{ return _PrecioCompra;}
		}

		public int stockVenta
		{
			set{_stockVenta= value;}
			get{ return _stockVenta;}
		}
		public string tipoMaterial
		{
			set{_tipoMaterial= value;}
			get{ return _tipoMaterial;}
		}
		
		public string codCentro
		{
			set{_codCentro= value;}
			get{ return _codCentro;}
		}

		public string codAlmacen
		{
			set{_codAlmacen= value;}
			get{ return _codAlmacen;}
		}

		public string codOficina
		{
			set{_codOficina= value;}
			get{ return _codOficina;}
		}

		public string desOficina
		{
			set{_desOficina= value;}
			get{ return _desOficina;}
		}

		public string serie
		{
			set{_serie= value;}
			get{ return _serie;}
		}


		public string CodMaterial_Out
		{
			set{_CODMATERIAL_OUT= value;}
			get{ return _CODMATERIAL_OUT;}
		}

		public string Descripcion_Out
		{
			set{_DESCRIPCION_OUT= value;}
			get{ return _DESCRIPCION_OUT;}
		}

		public string CodSerie_Out
		{
			set{_CODSERIE_OUT= value;}
			get{ return _CODSERIE_OUT;}
		}

		public decimal PrecioBase_Out
		{
			set{_PRECIOBASE_OUT= value;}
			get{ return _PRECIOBASE_OUT;}
		}

		public decimal PrecioVenta_Out
		{
			set{_PRECIOVENTA_OUT= value;}
			get{ return _PRECIOVENTA_OUT;}
		}
		
		public decimal Descuento_Out
		{
			set{_DESCUENTO_OUT= value;}
			get{ return _DESCUENTO_OUT;}
		}

		public decimal Igv_Out
		{
			set{_IGV_OUT= value;}
			get{ return _IGV_OUT;}
		}

		public decimal Total_Out
		{
			set{_TOTAL_OUT= value;}
			get{ return _TOTAL_OUT;}
		}

		private string _NRO_CELULAR = "";
		public string NRO_CELULAR
		{
			set{_NRO_CELULAR = value;}
			get{ return _NRO_CELULAR;}
		}

		private string _seguro_descto = "";
		public string seguro_descto
		{
			set{_seguro_descto = value;}
			get{ return _seguro_descto;}
		}
//--fin-dga-31072015

	}
}
