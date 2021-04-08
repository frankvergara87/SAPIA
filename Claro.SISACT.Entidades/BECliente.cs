using System;
using System.Text;
 

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de BECliente.
	/// </summary>
	public class BECliente
	{
		private string _Cliente;
		public string Cliente
		{
			get{ return _Cliente;}
			set{ _Cliente = value;}
		}
		private string _TipoDocCliente;
		public string TipoDocCliente
		{
			get{ return _TipoDocCliente;}
			set{ _TipoDocCliente = value;}
		}
		private string _TipoCliente;
		public string TipoCliente
		{
			get{ return _TipoCliente;}
			set{ _TipoCliente = value;}
		}
		private string _Nombre;
		public string Nombre
		{
			get{ return _Nombre;}
			set{ _Nombre = value;}
		}
		private string _ApellidoPaterno;
		public string ApellidoPaterno
		{
			get{ return _ApellidoPaterno;}
			set{ _ApellidoPaterno = value;}
		}
		private string _ApellidoMaterno;
		public string ApellidoMaterno
		{
			get{ return _ApellidoMaterno;}
			set{ _ApellidoMaterno = value;}
		}
		private string _RazonSocial;
		public string RazonSocial
		{
			get{ return _RazonSocial;}
			set{ _RazonSocial = value;}
		}
		private DateTime _FechaNacimiento;
		public DateTime FechaNacimiento
		{
			get{ return _FechaNacimiento;}
			set{ _FechaNacimiento = value;}
		}

		private string _Telefono;
		public string Telefono
		{
			get{ return _Telefono;}
			set{ _Telefono = value;}
		}
		private string _Fax;
		public string Fax
		{
			get{ return _Fax;}
			set{ _Fax = value;}
		}
		private string _EMail;
		public string EMail
		{
			get{ return _EMail;}
			set{ _EMail = value;}
		}

		public string NombreConyuge ;
		public string ApePatConyuge ;
		public string ApeMatConyuge ;
		public string CargaFamiliar ;
		public string Sexo ;
		public string titulo ;
		public string CalleLegal ;
		public string DireccionLegal ;
		public string DireccionLegalRef ;
		public string TelefFactPref ;
		public string TeleFact ;
		public string UbigeoLegal ;
		public string CalleFact ;
		public string UbigeoFact ;
		public string ReplegalTipDoc ;
		public string ReplegalNroDoc ;
		public string ReplegalNombre ;
		public string ReplegalApePat ;
		public string ReplegalApeMat ;
		public string ReplegalTelefon ;
		public string ContactoTipDoc ;
		public string ContactoNroDoc ;
		public string ContactoNombre ;
		public string ContactoApePat ;
		public string ContactoApeMat ;
		public string ContactoTelefon ;
		public string Cargo ;
		public string Dependiente ;
		public string EmpresaLabora ;
		public string EmpresaCargo ;
		public string EmpresaTelefono ;
		public string Actividad ;
		public Decimal IngBruto ; //decimal
		public Decimal OtrosIngresos ; //decimal
		public string TarjetaCredito ;
		public string NumTarjCredito ;
		public string MonedaTcred ;
		public Decimal LineaCredito ; //decimal
		public string FechaVencTcred ;
		public string Clasificacion ;
		public string ClaseCliente ;
		public string Ramo ;
		public string Observaciones ;
		public string EstadoCivil ;
		public string TitCliente ;
		public string ReplegalTit ;
		public DateTime ReplegalFnac ;
		public string RlegalFnac;//dga
		public string ReplegalSexo ;
		public string ReplegalEstCiv ;
		public string Ktokd ;
		public string ReferDireccion ;
		public string TelfPref ;
		public string FaxPref ;
		public string TelefLegal ;
		public string Operador ;
		public string DenomOperador ;
		public string TipoProdOperad ;
		public string DenomTpoProdOp ;
		public string TelefLegalPref ;
		public string ReferLegal ;
		public string Kunnr ;
		public string codigosap ;
		public string vendsap ;
		public string usuario ;
		public string fechacrea ;

       
		public string ReplegalTitulo ;
		public string Tipocredito ;


		// Estos parametros no son los que sap devuelve
		public string DireccionLegalPref ; // Nuevo
		public string DireccionFactPref ; // Nuevo 
		public string DireccionFact ; // Nuevo 
		public string DireccionFactRef ; // Nuevo 
		public int ClienCondCliente ; // Nuevo  

		//Sinergia SAP
		public string TvencCodigo ;
		public string TdoccCodigo ;
		public string ClievPreTelLeg ;
		public string ClievTelLeg ;
		public string ClievPreDir ;
		private string _ClievCodDep;
		public string ClievCodDep
		{
			get{ return _ClievCodDep;}
			set{ _ClievCodDep = value;}
		}


		public string CliCodigSap;
		public string  VendedorSap;
		public string UsuarioCrea;

	}
}
