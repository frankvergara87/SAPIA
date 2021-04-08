using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for EmpresaExperto.
	/// </summary>
	public class EmpresaExperto
	{
		private string _strRazonSocial;
		private string _strNombres;
		private string _strApellidoPaterno;
		private string _strApellidoMaterno;
		private string _strRiesgo;
		private string _strNroOperacion;
		private string _strCodRetorno;
		private string _strCodError;
		private string _strMensajeError;
		private string _strMensaje;
		private string _strFlagInterno;
		private double _deuda_financiera;
		private string _estado_ruc;
		private string _origen_experto;
		private int _buro_consultado; //ADD PROY-20054-IDEA-23849
		
		private ArrayList _ListaRepresentanteLegal;
		public EmpresaExperto()
		{
		}
		public string strRazonSocial 
		{
			get{ return _strRazonSocial;}
			set{ _strRazonSocial = value; }
		}
		public string strNombres
		{
			get{ return _strNombres;}
			set{ _strNombres = value; }
		}
		public string strApellidoPaterno
		{
			get{ return _strApellidoPaterno;}
			set{ _strApellidoPaterno = value; }
		}
		public string strApellidoMaterno
		{
			get{ return _strApellidoMaterno;}
			set{ _strApellidoMaterno = value; }
		}
		public string strRiesgo
		{
			get{ return _strRiesgo;}
			set{ _strRiesgo = value; }
		}
		public string strNroOperacion
		{
			get{ return _strNroOperacion;}
			set{ _strNroOperacion = value; }
		}
		public string strCodRetorno
		{
			get{ return _strCodRetorno;}
			set{ _strCodRetorno = value; }
		}
		public string strCodError
		{
			get{ return _strCodError;}
			set{ _strCodError = value; }
		}		
		public string strMensajeError
		{
			get{ return _strMensajeError;}
			set{ _strMensajeError = value; }
		}
		public string strMensaje
		{
			get{ return _strMensaje;}
			set{ _strMensaje = value; }
		}
		public string strFlagInterno
		{
			get{ return _strFlagInterno;}
			set{ _strFlagInterno = value; }
		}
		public double deuda_financiera
		{
			get{ return _deuda_financiera;}
			set{ _deuda_financiera = value; }
		}
		public string estado_ruc{
			get{ return _estado_ruc;}
			set{ _estado_ruc = value; }
		}

		public ArrayList ListaRepresentanteLegal
		{
			get{ return _ListaRepresentanteLegal;}
			set{ _ListaRepresentanteLegal= value;}
		}

		public string origen_experto
		{
			get{ return _origen_experto;}
			set{ _origen_experto = value; }
		}
	
		//INICIO: PROY-20054-IDEA-23849
		public int buro_consultado 
		{
			get{ return _buro_consultado;}
			set{ _buro_consultado = value; }
		}
		//FIN
	}
}
