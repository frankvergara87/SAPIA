using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for FormaPago.
	/// Author: Miguel Ayllón Samaniego
	/// </summary>
	public class FormaPago
	{
		//Tomado de los campos de la tabla
		//sect_forma_pago		
		
		//Código de Forma de Pago
		private string _FPAGC_CODIGO;
		//Descripción de Forma de Pago
		private string _FPAGV_DESCRIPCION;
		//Estado de registro de Forma de Pago
		private string _FPAGC_ESTADO;

		public FormaPago()
		{
		}

		public string FPAGC_CODIGO
		{
			set{ _FPAGC_CODIGO = value;}
			get{ return _FPAGC_CODIGO;}
		}
		
		public string FPAGV_DESCRIPCION
		{
			set{ _FPAGV_DESCRIPCION = value;}
			get{ return _FPAGV_DESCRIPCION;}		
		}
		
		public string FPAGC_ESTADO
		{
			set{ _FPAGC_ESTADO = value;}
			get{ return _FPAGC_ESTADO;}
		}
	}
}
