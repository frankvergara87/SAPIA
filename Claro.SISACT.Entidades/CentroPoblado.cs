using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de CentroPoblado.
	/// </summary>
	public class CentroPoblado
	{
		public CentroPoblado()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		private Int64 _IDPOBLADO;
		private string _CODCLASIFICACION;
		private string _NOMBRE;
		private string _COBERTURA;

		public Int64 IDPOBLADO
		{
			set { _IDPOBLADO=value;}
			get { return _IDPOBLADO;}
		}

		public string CODCLASIFICACION
		{
			set	{ _CODCLASIFICACION= value;}
			get { return _CODCLASIFICACION;}
		}

		public string NOMBRE
		{
			set	{ _NOMBRE= value;}
			get { return _NOMBRE;}
		}
		public string COBERTURA
		{
			set	{ _COBERTURA= value;}
			get { return _COBERTURA;}
		}

		
	}
}
