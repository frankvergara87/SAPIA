using System;
using System.Text.RegularExpressions;
using System.Data;
using System.Configuration;
namespace Claro.SisAct.Common
{
	/// <summary>
	/// Summary description for SIACFunciones.
	/// </summary>
	public class Funciones
	{
		public Funciones()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		static public bool isNumeric(object value) 
		{
			bool resultado;
			double numero;

			resultado = Double.TryParse(Convert.ToString(value), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out numero);
			return resultado;

		}
		//funcion adicionada para validar
		static public string ConvertSoles(object value)
		{
			string salida = "0";
			if (value == null || value == System.DBNull.Value)
			{
				salida = "0";
			}
			else 
			{
				if (Convert.ToString(value) == "")
					salida = "0";
				else
					salida = Convert.ToString((Convert.ToDouble(value)/100));					
			}            
			return salida;
		}

		static public bool IsNumeric(string input)
		{
			bool flag = true;
			//Valid user input 
			string pattern = @"^[0-9]*$";
			Regex validate = new Regex(pattern);
			//Check the user input format 
			if (!validate.IsMatch(input))
			{
				flag = false;
			}
			return flag;
		}
		bool IsNumeric2(string inputString)
		{
			return Regex.IsMatch(inputString, "^[0-9]+$");
		}


		static public string CheckStr(object value) 
		{ 
			string salida="";
			if (value == null || value == System.DBNull.Value)
				salida = "";			
			else
				salida = value.ToString();			
			return salida.Trim();
		}

		static public Int64 CheckInt64(object value)
		{
			Int64 salida = 0;
			if (value == null || value == System.DBNull.Value)
			{
				salida = 0;
			}
			else 
			{
				if (Convert.ToString(value) == "")
					salida = 0;
				else
					salida = Convert.ToInt64(value);
			}            
			return salida;
		}

		static public float CheckFloat(object value)
		{
			int salida = 0;
			if (value == null || value == System.DBNull.Value)
			{
				salida = 0;
			}
			else 
			{
				if (Convert.ToString(value) == "")
					salida = 0;
				else
					salida = Convert.ToInt32(value);
			}            
			return salida;
		}


		static public int CheckInt(object value)
		{
			int salida = 0;
			if (value == null || value == System.DBNull.Value)
			{
				salida = 0;
			}
			else 
			{
				if (Convert.ToString(value) == "" || Convert.ToString(value) == "&nbsp;" || Convert.ToString(value) == "&nbsp")
					salida = 0;
				else
					salida = Convert.ToInt32(value);
			}            
			return salida;
		}

		static public double CheckDbl(object value)
		{
			double salida = 0;
			if (value == null || value == System.DBNull.Value)
			{
				salida = 0;
			}
			else{
				if (Convert.ToString(value) == "" || Convert.ToString(value) == "&nbsp;" || Convert.ToString(value) == "&nbsp")
					salida = 0;
				else
					salida =  Convert.ToDouble(value);
			}            
			return salida;
		}		
		static public double CheckDbl(object value, int nroDecimales){
			double salida = CheckDbl(value);
			if (salida==0) return salida;
			return redondearMontos(salida, nroDecimales);
		}

		static public Single CheckSng(object value)
		{
			Single salida = 0;
			if (value == null || value == System.DBNull.Value)
			{
				salida = 0;
			}
			else
			{
				if (Convert.ToString(value) == "" || Convert.ToString(value) == "&nbsp;" || Convert.ToString(value) == "&nbsp")
					salida = 0;
				else
					salida =  Convert.ToSingle(value);
			}            
			return salida;
		}

		static public decimal CheckDecimal(object value)
		{
			decimal salida = 0;
			if (value == null || value == System.DBNull.Value)
			{
				salida = 0;
			}
			else 
			{
				if (Convert.ToString(value) == "" || Convert.ToString(value) == "&nbsp;" || Convert.ToString(value) == "&nbsp")
					salida = 0;
				else
					salida =  Convert.ToDecimal(value);
			}            
			return salida;
		}				
		
		static public double redondearMontos(double value,int nroDecimales) 
		{
			return Math.Round(value, nroDecimales);
		}
		static public DateTime CheckDate(object value)
		{			
			if (value == null || value == System.DBNull.Value )
				return new DateTime(1,1,1);
			
			if ( value.ToString() == "" )
				return new DateTime(1,1,1);
			return Convert.ToDateTime(value);			
		}	
		public static System.Data.DataTable dtParams()
		{
			System.Data.DbType tipo = new System.Data.DbType();
			System.Data.ParameterDirection direccion = new System.Data.ParameterDirection();
			System.Data.DataTable dt = new System.Data.DataTable();
			dt.Columns.Add("Nombre", System.Type.GetType("System.String"));
			dt.Columns.Add("Tipo", tipo.GetType());
			dt.Columns.Add("Size", System.Type.GetType("System.Int32"));
			dt.Columns.Add("Direccion", direccion.GetType());
			dt.Columns.Add("Valor", System.Type.GetType("System.Object"));
            
			return dt;
		}
		public static bool InsertarParam(System.Data.DataTable vdtParams, 
			string vName , 
			System.Data.DbType vType , 
			int vSize , 
			System.Data.ParameterDirection vDirection , 
			object vValue )
		{

			System.Data.DataRow dr = vdtParams.NewRow();            
			dr["Nombre"] = vName;
			dr["Tipo"] = vType;
			if (vSize == 0) 
				dr["Size"] = 0;
			else
				dr["Size"] = vSize;

			dr["Direccion"] = vDirection;
                
			if (vValue == null)
				dr["Valor"] = DBNull.Value;
			else
				dr["Valor"] = vValue;
                            
			vdtParams.Rows.Add(dr);
			return true;
		}

		public static double ConvertSolesToCentimos(double vMonto){
			return (vMonto * 100);
		}

		public static DataTable TablaActividad()
		{
			DataTable dt;
			dt= new DataTable();
			dt.Columns.Add("start", typeof(DateTime));
			dt.Columns.Add("end", typeof(DateTime));
			dt.Columns.Add("name", typeof(string));
			dt.Columns.Add("id", typeof(string));
			dt.Columns.Add("eventColor", typeof(string));

			return dt;
		}
		public static int UltimoDiaMes(int mes,int anno){
			int dia=0;
			if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 10 || mes == 12) { 
				dia = 31; 
			} 
			else if (mes == 4 || mes == 6 || mes == 8 || mes == 9 || mes == 11) { 
				dia = 30; 
			} 
			else if (mes == 2){ 
				if ((anno % 4) == 0 & (anno % 100) == 0) { 
					dia = 29; 
				} 
				else { 
					dia = 28; 
				} 
			}
			return dia;
		}
		public static string NVLString(string valor1, string valor2){
			string v1 = CheckStr(valor1);
			string v2 =CheckStr(valor2);
			if (v1!="")
				return v1;
			else
				return v2;
		}
		public static DateTime NVLDate(DateTime valor1, DateTime valor2)
		{
			DateTime v1 = CheckDate(valor1);
			DateTime v2 = CheckDate(valor2);
			if (v1 != new DateTime(1,1,1))
				return v1;
			else
				return v2;
		}

		public static string NroDocumentoIdentidad(string tipo, string nro)
		{			
			if (nro == "") return "";
			string salida = nro;
			int longitud = -1;
			if (HelperLog.getValue("TipoDocumentoDNI") == tipo)
				longitud = CheckInt(HelperLog.getValue("LenTipoDocumentoDNI"));
			else if (HelperLog.getValue("TipoDocumentoRUC") == tipo)
				longitud = CheckInt(HelperLog.getValue("LenTipoDocumentoRUC"));
			else if (HelperLog.getValue("TipoDocumentoCIP") == tipo)
				longitud = CheckInt(HelperLog.getValue("LenTipoDocumentoCIP"));
			else if (HelperLog.getValue("TipoDocumentoCEX") == tipo)
				longitud = CheckInt(HelperLog.getValue("LenTipoDocumentoCEX"));
			else if (HelperLog.getValue("TipoDocumentoCFA") == tipo)
				longitud = CheckInt(HelperLog.getValue("LenTipoDocumentoCFA"));
			else if(AppSettings.Key_codigoDocMigraYPasaporte.IndexOf(tipo)>-1)//PROY 31636 RENTESEG
				longitud = CheckInt(AppSettings.Key_maxLengthDocMigratorios);//PROY 31636 RENTESEG

			if ( (longitud >-1) && (nro.Length > longitud) )
				salida = nro.Substring(nro.Length - longitud);
			return salida;
		}
		public static string FormarNroDocumentoIdentidad(string nro){
			string salida =  nro;
			if (salida.Equals("")) return "";
			salida = nro.PadLeft(16,'0');
			return salida;
		}

		public static string ObtenerResultadoTelefono(string estado)
		{
			string Resultado;
			switch(estado)
			{
				case "1" :Resultado = "SE REGISTRÓ EXITOSAMENTE"; break;
				case "0" :Resultado = "NO SE REGISTRÓ EL TELEFONO "; break;
				case "N" :Resultado = "EL REGISTRO EXISTE COMO: NUEVO"; break;
				case "R" :Resultado = "EL REGISTRO EXISTE COMO: RESERVADO"; break;
				case "E" :Resultado = "EL REGISTRO EXISTE COMO: ENVIADO POR ACTIVACION"; break;
				case "A" :Resultado = "EL REGISTRO EXISTE COMO: ACTIVADO"; break;
				case "" :Resultado = "EL REGISTRO EXISTE"; break;
				default: Resultado = "VERIFICAR DATOS"; break;
			}
			return Resultado;
		}
		public static string ReemplazarCaracterInvalido(string valor)		
		{
			if (valor==null) return "";			
			if (valor.Trim()=="")  return "";
			int intPos =0 ;
			string strCadenaInvalida = "ñ,Ñ,á,é,í,ó,ú,Á,É,Í,Ó,Ú,ä,ë,ï,ö,ü,Ä,Ë,Ï,Ö,Ü";
			string strCadenaValida = "n,N,a,e,i,o,u,A,E,I,O,U,a,e,i,o,u,A,E,I,O,U";
			string[] ArrInvalida = strCadenaInvalida.Split(',');
			string[] ArrValida = strCadenaValida.Split(',');
			int i = 0;			
			for(i=0;i<ArrInvalida.Length;i++){
				intPos = valor.IndexOf(ArrInvalida[i]);
				if (intPos != -1){
					valor = valor.Replace(ArrInvalida[i], ArrValida[i]);
				}
			}
			return valor;
		}

		//Pablo Zea - Vendedores 20/05/2009 Inicio
		static public Int16 CheckInt16(object value)
		{
			Int16 salida = 0;
			if (value == null || value == System.DBNull.Value)
			{
				salida = 0;
			}
			else 
			{
				if (Convert.ToString(value) == "")
					salida = 0;
				else
					salida = Convert.ToInt16(value);
			}
			return salida;
		}
		//Pablo Zea - Vendedores 20/05/2009 Fin

		public static string CadenaAleatoria() 
		{
			string strValue="";
			Random objAleatorio = new Random();
			try
			{
				for(int i = 0; i<8 ;i++)
				{
					strValue=strValue + objAleatorio.Next(0,10).ToString();
				}                                              
			}
			catch(Exception)
			{
				return "";
			}
			finally
			{
				objAleatorio =null;
			}
			return strValue;
		}
		public static string FormatoTelefono(string strTelefono)
		{
			long lngTelefono=0;
			if(strTelefono==null)
			{
				return "";
			}
			lngTelefono = Convert.ToInt64(strTelefono);
			strTelefono = Convert.ToString(lngTelefono);
			if(strTelefono.Substring(0,1)=="1")
			{//Si es lima adicionar 0 adelante
				strTelefono = "0" + strTelefono;
			}
			return strTelefono;               
		}
		public static string Right(string param, int length)
		{
			int value = param.Length - length; 
			string result = param.Substring(value, length); 
			return result;
		}

		//Inicio RIHU 29122014 - EVERIS
		static public bool CheckBoo(object value) 
		{ 
			bool salida=false;
			if (value == null || value == System.DBNull.Value)
				salida = false;			
			else
				salida = Convert.ToBoolean( value);			
			return salida;
		}
		//Fin RIHU 29122014 - EVERIS

		public static string TipoRUC1020(string nroDocumento)
		{
			string strTipoDocumento = string.Empty;
			if (nroDocumento.Substring(0, 1) == ConfigurationSettings.AppSettings["constRUCInicio"])
			{
				strTipoDocumento = ConfigurationSettings.AppSettings["constTipoDocumentoRUC20"];
			}
			else
			{
				strTipoDocumento = ConfigurationSettings.AppSettings["constTipoDocumentoRUC10"];
			}
			return strTipoDocumento;
		}		

		public static string FormatoFechaSap(string fecha) 
		{ 
			bool val = false;
			string strFecha = "";
			try
			{
			if (fecha.Length > 0) 
				{ 
					strFecha =  fecha.Substring(0, 4) + "/" + fecha.Substring(4, 2) + "/" + fecha.Substring(6, 2); 
					CheckDate(strFecha);
				}
			else 
					strFecha =  "0000/00/00"; 

				val = true;
			}
			catch{
				val = false;
				strFecha = "";
			}
			
			if(val == false){
				try
				{
					if (fecha.Length > 0)
					{ 
						strFecha =  fecha.Substring(0, 2) + "/" + fecha.Substring(2, 2) + "/" + fecha.Substring(4, 4); 
						CheckDate(strFecha);
					}
					else 
						strFecha =  "00/00/0000"; 
					val = true;
				}
				catch
				{
					val = false;
					strFecha = "";
				}
			}
			return strFecha;
				
		}

		public static string FormatoFechaSap1(string fecha) 
		{ 
			if (fecha.Length > 0) 
				return fecha.Substring(0, 2) + "/" + fecha.Substring(2, 2) + "/" + fecha.Substring(4, 4); 
			else 
				return "00/00/0000"; 
		}

		//-inicio-dga-01082015
		static public bool IsContratoVacio(string sNroContrato)
		{
			sNroContrato = sNroContrato.Replace("0", "");
			return (sNroContrato.Trim().Equals(""));
		}
		//-inicio-dga-01082015

	}
}
