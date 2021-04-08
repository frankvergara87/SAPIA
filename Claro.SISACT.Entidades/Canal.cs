using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for Canal.
	/// Author: Miguel Ayllón Samaniego	/// 
	/// </summary>
	public class Canal
	{
		//Tomado de los campos de la tabla
		//sect_canal
		
		//Código de Canal
		private string _CANAC_CODIGO; 
		//Código de Tipo de Producto
		private string _TPROC_CODIGO;
		//Descripción de Canal
		private string _CANAV_DESCRIPCION;
		//Flag de Evaluación Crediticia
		private string _CANAC_FLA_EVA;
		//Número de Planes de Canal
		private Int64  _CANAN_NUM_PLA;
		//Cargo Fijo Máximo de Canal
		private Int64  _CANAN_CAR_FIJ_MAX;
		//Estado de Registro de Canal
		private string _CANAC_ESTADO; 

		public Canal()
		{			
		}

		public Canal(string vCodigo,string vDescripcion)
		{			
			_CANAC_CODIGO = vCodigo;
			_CANAV_DESCRIPCION = vDescripcion;
		}

		public string CANAC_CODIGO
		{
			set { _CANAC_CODIGO= value;}
			get { return _CANAC_CODIGO;}
		}

		public string TPROC_CODIGO
		{
			set { _TPROC_CODIGO=value;}
			get { return _TPROC_CODIGO;}
		}

		public string CANAV_DESCRIPCION
		{
			set { _CANAV_DESCRIPCION=value;}
			get { return _CANAV_DESCRIPCION;}
		}

		public string CANAC_FLA_EVA
		{
			set { _CANAC_FLA_EVA=value;}
			get { return _CANAC_FLA_EVA;}
		}

		public Int64 CANAN_NUM_PLA
		{
			set { _CANAN_NUM_PLA=value;}
			get { return _CANAN_NUM_PLA;}
		}
		
		public Int64 CANAN_CAR_FIJ_MAX
		{
			set { _CANAN_CAR_FIJ_MAX=value;}
			get { return _CANAN_CAR_FIJ_MAX;}
		}

		public string CANAC_ESTADO
		{
			set	{ _CANAC_ESTADO= value;}
			get { return _CANAC_ESTADO;}
		}

	}
}
