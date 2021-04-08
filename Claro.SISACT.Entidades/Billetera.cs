using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Billetera.
	/// </summary>
	public class Billetera
	{
		public Billetera()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public int _idBilletera ;
		public string _billetera;
		public int _nroPlanes ;
		public double _monto ;

		public int idBilletera
		{
			set{_idBilletera= value;}
			get{ return _idBilletera;}
		}

		public string billetera
		{
			set{_billetera= value;}
			get{ return _billetera;}
		}
		public int nroPlanes
		{
			set{_nroPlanes= value;}
			get{ return _nroPlanes;}
		}
		public double monto
		{
			set{_monto= value;}
			get{ return _monto;}
		}
		public Billetera(int idBilletera, string billetera) 
		{
			this.idBilletera = idBilletera;
			this.billetera = billetera;
		}
		public Billetera(int idBilletera, int nroPlanes)
		{
			this.idBilletera = idBilletera;
			this.nroPlanes = nroPlanes;
		}
		public enum TIPO_BILLETERA
		{
			MOVIL = 2,
			INTERNET = 4,
			CLAROTV = 8,
			TELEFONIA = 16,
			BAM = 32,
			TRIPLEPLAY = 28
		}
	}
}
