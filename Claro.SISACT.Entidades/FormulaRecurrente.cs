using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for FormulaRecurrente.
	/// </summary>
	public class FormulaRecurrente
	{
		private string _TMCODE;
		private string _DES;
		private int _CF;
		private int _ACTIVOS;

		public FormulaRecurrente()
		{
		}
		
		public string TMCODE
		{
			set{ _TMCODE = value;}
			get{ return _TMCODE;}
		}

		public string DES
		{
			set{ _DES = value;}
			get{ return _DES;}
		}

		public int CF
		{
			set{ _CF = value;}
			get{ return _CF;}
		}

		public int ACTIVOS
		{
			set{ _ACTIVOS = value;}
			get{ return _ACTIVOS;}
		}
	}
}
