using System;
using System.Configuration;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using System.Xml;
using System.Text;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de SansNegocio.
	/// </summary>
	public class SansNegocio
	{
		SimCardsWS.ebsSimcards objSimCards = new  SimCardsWS.ebsSimcards();
		string idAplicacion = Funciones.CheckStr(ConfigurationSettings.AppSettings["CodigoAplicacion"]);
		string nombreAplicacion = Funciones.CheckStr(ConfigurationSettings.AppSettings["constAplicacion"]);		
		string nameArchivo = "LOG_POS_SANS" + "_" + string.Format("{0:dd-MM-yyyy}", DateTime.Now) + ".txt";		

		public SansNegocio()
		{
			objSimCards.Url = Funciones.CheckStr(ConfigurationSettings.AppSettings["consRutaWS_Sans"]);
			objSimCards.Credentials= System.Net.CredentialCache.DefaultCredentials;
			objSimCards.Timeout = Funciones.CheckInt(ConfigurationSettings.AppSettings["consRutaWS_Sans_Timeout"]);
		}          
		
		public DataSet ConsultarPrecio(string p_oficina, string p_documento_origen, string p_consecutivo, string p_material,
			string p_utilizacion,decimal p_cantidad, string p_fecha, string p_serie, string p_nro_telefono, string p_tipo_doc_venta,
			string p_cadena_series, string p_canal, string p_org_vnt, string p_disp_IMEI, out decimal p_descuento, out decimal p_prec_incIGV,
			out decimal p_precio, out decimal p_subTotal, string usuarioAplicacion)
		{

			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, "------------ " + DateTime.Now.ToShortTimeString() + " | Metodo ConsultarPrecio: Inicia Invocacion WS. obtenerDatosNroTelef ------------", false);
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			
			HelperLog.EscribirLog("", nameArchivo, "Parametros del metodo", false);
			HelperLog.EscribirLog("", nameArchivo, "- oficina: " + p_oficina, false);
			HelperLog.EscribirLog("", nameArchivo, "- documento_origen: " + p_documento_origen, false);
			HelperLog.EscribirLog("", nameArchivo, "- consecutivo: " + p_consecutivo, false);
			HelperLog.EscribirLog("", nameArchivo, "- cantidad: " + p_cantidad, false);
			HelperLog.EscribirLog("", nameArchivo, "- fecha: " + p_fecha, false);
			HelperLog.EscribirLog("", nameArchivo, "- serie: " + p_serie, false);
			HelperLog.EscribirLog("", nameArchivo, "- tipo_doc_venta: " + p_tipo_doc_venta, false);
			HelperLog.EscribirLog("", nameArchivo, "- cadena_series: " + p_cadena_series, false);
			HelperLog.EscribirLog("", nameArchivo, "- canal: " + p_canal, false);
			HelperLog.EscribirLog("", nameArchivo, "- org_vnt: " + p_org_vnt, false);
			HelperLog.EscribirLog("", nameArchivo, "- disp_IMEI: " + p_disp_IMEI, false);		
			HelperLog.EscribirLog("", nameArchivo, "- Nro telefono: " + p_nro_telefono, false);
			HelperLog.EscribirLog("", nameArchivo, "- Material: " + p_material, false);
			HelperLog.EscribirLog("", nameArchivo, "- Serie: " + p_serie, false);

			string ws_nroTelefono = string.Empty;
			string ws_material = string.Empty;
			string ws_serie = string.Empty;
			string ws_materialAntiguo = string.Empty;
			int cantReg = 0;
			bool obtieneDatosWS = true;

			try 
			{
				//Se valida el material
				string constCadenaMaterialChipRep = ConfigurationSettings.AppSettings["constCadenaMaterialChipRep"].ToString();						
				if (p_material.StartsWith("PS") && constCadenaMaterialChipRep.IndexOf(p_material) == -1)
				{
					string idTransaccion = string.Empty;
					string mensajeResultado = string.Empty;
					SimCardsWS.itReturnType[] itReturn;
					SimCardsWS.nroSimcardsDataType[] nroSimcardsDataType;

					string result = objSimCards.obtenerDatosNroTelef(ref idTransaccion, idAplicacion, nombreAplicacion, usuarioAplicacion,
						p_nro_telefono, p_material, p_serie, out mensajeResultado, out nroSimcardsDataType, out itReturn);

					//Validar registro
					cantReg = nroSimcardsDataType.Length;

					HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);				
					HelperLog.EscribirLog("", nameArchivo, "Datos obtenidos del WS", false);
					HelperLog.EscribirLog("", nameArchivo, "- Cantidad de Registro: " + cantReg.ToString(), false);

					if (cantReg > 0) 
					{            
						ws_nroTelefono = nroSimcardsDataType[0].nroTelef;
						ws_material = nroSimcardsDataType[0].matNr;
						ws_serie = nroSimcardsDataType[0].serNr;
						ws_materialAntiguo = nroSimcardsDataType[0].matNrAntig;

						HelperLog.EscribirLog("", nameArchivo, "- Nro telefono: " + ws_nroTelefono, false);
						HelperLog.EscribirLog("", nameArchivo, "- Material: " + ws_material, false);
						HelperLog.EscribirLog("", nameArchivo, "- Serie: " + ws_serie, false);
						HelperLog.EscribirLog("", nameArchivo, "- Material Antiguo: " + ws_materialAntiguo, false);			
					}
					else
					{
						obtieneDatosWS = false;
						HelperLog.EscribirLog("", nameArchivo, "***** El WS no devuelve datos. Por lo cual no se consultará SAP.", false);
					}

					HelperLog.EscribirLog("", nameArchivo, "- Mensaje Resultado: " + mensajeResultado, false);
					HelperLog.EscribirLog("", nameArchivo, "- Resultado Metodo WS: " + result, false);
					HelperLog.EscribirLog("", nameArchivo, "- Mensaje ItReturn: " + itReturn[0].mensaje, false);					
					HelperLog.EscribirLog("", nameArchivo, "- Tipo ItReturn: " + itReturn[0].tipo, false);
				}
				else
				{
					ws_serie = p_serie;	
					HelperLog.EscribirLog("", nameArchivo, "***** El material no es chip con telefono. Por lo cual se consultará a SAP el precio con los parametros de entrada.", false);
					HelperLog.EscribirLog("", nameArchivo, "** Serie (parametro de entrada): " + ws_serie, false);
				}
			}
			catch(Exception ex)
			{		
				obtieneDatosWS = false;
				HelperLog.EscribirLog("", nameArchivo, ex.Message, false);
				HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
				HelperLog.EscribirLog("", nameArchivo, ex.StackTrace, false);
			}

			//Metodo SAP
			DataSet resultSAP = null;			
			p_descuento = 0;
			p_prec_incIGV = 0;
			p_precio = 0;
			p_subTotal = 0;

			if (obtieneDatosWS) 
			{
				resultSAP = new SapGeneralNegocios().ConsultarPrecio(p_oficina, p_documento_origen, p_consecutivo, p_material,
					p_utilizacion, p_cantidad, p_fecha, ws_serie, p_nro_telefono, p_tipo_doc_venta,
					p_cadena_series, p_canal, p_org_vnt, p_disp_IMEI, out p_descuento, out p_prec_incIGV, out p_precio, out p_subTotal);

				HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
				HelperLog.EscribirLog("", nameArchivo, "Datos de salida del SAP", false);
				HelperLog.EscribirLog("", nameArchivo, "- Cantidad de resultados: " + resultSAP.Tables[0].Rows.Count, false);
				HelperLog.EscribirLog("", nameArchivo, "- descuento OUT: " + p_descuento, false);
				HelperLog.EscribirLog("", nameArchivo, "- prec_incIGV OUT: " + p_prec_incIGV, false);
				HelperLog.EscribirLog("", nameArchivo, "- precio OUT: " + p_precio, false);
				HelperLog.EscribirLog("", nameArchivo, "- p_subTotal OUT: " + p_subTotal, false);
			}

			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, "------------ Metodo ConsultarPrecio: Finaliza Invocacion WS. obtenerDatosNroTelef ------------", false);
    

			return resultSAP;
		}        
		
		
		public ArrayList get_seriesxMaterial(string oficina,string material,string resultados,string telefono, string usuarioAplicacion)
		{
			//Metodo SAP
			ArrayList resultSAP = new SapGeneralNegocios().get_seriesxMaterial(oficina, material, resultados, telefono);
			ArrayList arrSeries = new ArrayList();

			try 
			{
				int cont = 0;
				int cantRegSAP = resultSAP.Count;			

				HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
				HelperLog.EscribirLog("", nameArchivo, "------------ " + DateTime.Now.ToShortTimeString() + " | Metodo get_seriesxMaterial: Inicia Invocacion WS. obtenerNroTelef ------------", false);            
			
				HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
				HelperLog.EscribirLog("", nameArchivo, "Parametros del metodo", false);
				HelperLog.EscribirLog("", nameArchivo, "- Oficina: " + oficina, false);
				HelperLog.EscribirLog("", nameArchivo, "- Material: " + material, false);
				HelperLog.EscribirLog("", nameArchivo, "- Resultados: " + resultados, false);
				HelperLog.EscribirLog("", nameArchivo, "- Telefono: " + telefono, false);

				//SAP
				HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
				HelperLog.EscribirLog("", nameArchivo, "Resultado SAP", false);
				HelperLog.EscribirLog("", nameArchivo, "- Cantidad registros: " + cantRegSAP, false);

				if (cantRegSAP > 0) 
				{
					string constCadenaMaterialChipRep = ConfigurationSettings.AppSettings["constCadenaMaterialChipRep"].ToString();						
					if (material.StartsWith("PS") && constCadenaMaterialChipRep.IndexOf(material) == -1)
					{
						SimCardsWS.itMatSerType[] itInputArray = new SimCardsWS.itMatSerType[cantRegSAP];

						foreach(ItemGenerico _item in resultSAP)
						{
							SimCardsWS.itMatSerType itInputItem = new SimCardsWS.itMatSerType();
							itInputItem.material = _item.Codigo2;
							itInputItem.nroSerie = _item.Codigo;
							itInputArray[cont] = itInputItem;
							cont++;
						}


						string idTransaccion = string.Empty;				
						string mensajeResultado = string.Empty;
						SimCardsWS.itTelSerType[] itOutPut;
						SimCardsWS.itReturnType[] itReturn;

						string result = objSimCards.obtenerNroTelef(ref idTransaccion, idAplicacion, nombreAplicacion, usuarioAplicacion,
							itInputArray, out mensajeResultado, out itOutPut , out itReturn);

						HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
						HelperLog.EscribirLog("", nameArchivo, "Datos obtenidos del WS", false);
						HelperLog.EscribirLog("", nameArchivo, "- Cantidad registros WS: " + itOutPut.Length, false);
						HelperLog.EscribirLog("", nameArchivo, "- Mensaje Resultado: " + mensajeResultado, false);
						HelperLog.EscribirLog("", nameArchivo, "- Resultado WS: " + result, false);
						HelperLog.EscribirLog("", nameArchivo, "- Mensaje ItReturn: " + itReturn[0].mensaje, false);

					
						//Se construye el ArrayList 
						foreach(SimCardsWS.itTelSerType _itemOut in itOutPut)
						{
							ItemGenerico item = new ItemGenerico();							
							item.Codigo = _itemOut.nroSerie;
							item.Descripcion = _itemOut.nroTelef;
							item.Codigo2 = material;
							arrSeries.Add(item);
						}
					}
					else 
					{
						HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
						HelperLog.EscribirLog("", nameArchivo, "El material no es un chip con telefono. Por lo cual, no se consulto al WS Sans y se tomaron los datos de SAP", false);
						arrSeries = resultSAP;
					}
				}

				HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
				HelperLog.EscribirLog("", nameArchivo, "------------ Metodo get_seriesxMaterial: Finaliza Invocacion WS. obtenerNroTelef ------------", false);

			}
			catch(Exception ex)
			{
				arrSeries = null;
				throw ex;
			}
			return arrSeries;				
				
		}

		
		public bool Get_RegistroAcuerdoPCS(string[] arrAcuerdo, string CadenaServAdic,out string Nro_Contrato, ref string mensaje, string p_nro_telefono, string p_material, string p_serie, string usuarioAplicacion)
		{
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, "------------ " + DateTime.Now.ToShortTimeString() + " | Metodo Get_RegistroAcuerdoPCS: Inicia Invocacion WS. obtenerDatosNroTelef ------------", false);
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, "Parametros del metodo", false);
			HelperLog.EscribirLog("", nameArchivo, "- arrAcuerdo: " + arrAcuerdo, false);
			HelperLog.EscribirLog("", nameArchivo, "- CadenaServAdic: " + CadenaServAdic, false);			
			HelperLog.EscribirLog("", nameArchivo, "- Nro telefono: " + p_nro_telefono, false);
			HelperLog.EscribirLog("", nameArchivo, "- Material: " + p_material, false);
			HelperLog.EscribirLog("", nameArchivo, "- Serie: " + p_serie, false);

			string ws_nroTelefono = string.Empty;
			string ws_material = string.Empty;
			string ws_serie = string.Empty;
			string ws_materialAntiguo = string.Empty;
			int cantReg = 0;

			try 
			{
				//Se valida el material
				if (p_material.StartsWith("PS"))
				{
					string idTransaccion = string.Empty;
					string mensajeResultado = string.Empty;
					SimCardsWS.itReturnType[] itReturn;
					SimCardsWS.nroSimcardsDataType[] nroSimcardsDataType;

					string result = objSimCards.obtenerDatosNroTelef(ref idTransaccion, idAplicacion, nombreAplicacion, usuarioAplicacion,
						p_nro_telefono, p_material, p_serie, out mensajeResultado, out nroSimcardsDataType, out itReturn);


					HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
					HelperLog.EscribirLog("", nameArchivo, "Datos obtenidos del WS", false);

					//Validar registro
					cantReg = nroSimcardsDataType.Length;

					if (cantReg > 0) 
					{				
						ws_nroTelefono = nroSimcardsDataType[0].nroTelef;
						ws_material = nroSimcardsDataType[0].matNr;
						ws_serie = nroSimcardsDataType[0].serNr;
						ws_materialAntiguo = nroSimcardsDataType[0].matNrAntig;
					
						HelperLog.EscribirLog("", nameArchivo, "- Nro telefono: " + ws_nroTelefono, false);
						HelperLog.EscribirLog("", nameArchivo, "- Material: " + ws_material, false);
						HelperLog.EscribirLog("", nameArchivo, "- Serie: " + ws_serie, false);
						HelperLog.EscribirLog("", nameArchivo, "- Material Antiguo: " + ws_materialAntiguo, false);
					}
					HelperLog.EscribirLog("", nameArchivo, "- Mensaje Resultado: " + mensajeResultado, false);
					HelperLog.EscribirLog("", nameArchivo, "- Resultado Metodo WS: " + result, false);
					HelperLog.EscribirLog("", nameArchivo, "- ItReturn Tipo: " + itReturn[0].tipo, false);
					HelperLog.EscribirLog("", nameArchivo, "- ItReturn Mensaje: " + itReturn[0].mensaje, false);
				}

			}
			catch(Exception ex)
			{		
				HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
				HelperLog.EscribirLog("", nameArchivo, "Exception Message: " + ex.Message, false);
				HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
				HelperLog.EscribirLog("", nameArchivo, "Exception StackTrace: " + ex.StackTrace, false);
			}

			bool resultSAP = new SapGeneralNegocios().Get_RegistroAcuerdoPCS(arrAcuerdo, CadenaServAdic,out Nro_Contrato, ref mensaje);

			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, "Datos de salida del SAP", false);
			HelperLog.EscribirLog("", nameArchivo, "- Resultado Metodo: " + resultSAP, false);
			HelperLog.EscribirLog("", nameArchivo, "- Nro Contrato OUT: " + Nro_Contrato, false);

			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, "------------ Metodo Get_RegistroAcuerdoPCS: Finaliza Invocacion WS. obtenerDatosNroTelef ------------", false);
    
			return resultSAP;		
		}

		
		public string ConsultarIccid(string Clase_Venta, string Nro_Telefono, string Tipo_Venta, string p_material, string p_serie, string usuarioAplicacion)
		{
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, "------------ " + DateTime.Now.ToShortTimeString() + " | Metodo ConsultarIccid: Inicia Invocacion WS. obtenerDatosNroTelef ------------", false);
			
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, "Parametros del metodo", false);
			HelperLog.EscribirLog("", nameArchivo, "- Clase Venta: " + Clase_Venta, false);
			HelperLog.EscribirLog("", nameArchivo, "- Tipo Venta: " + Tipo_Venta, false);
			HelperLog.EscribirLog("", nameArchivo, "- Nro telefono: " + Nro_Telefono, false);
			HelperLog.EscribirLog("", nameArchivo, "- Material: " + p_material, false);
			HelperLog.EscribirLog("", nameArchivo, "- Serie: " + p_serie, false);

			string ws_nroTelefono = string.Empty;
			string ws_material = string.Empty;
			string ws_serie = string.Empty;
			string ws_materialAntiguo = string.Empty;
			string ws_fechacambio = string.Empty;
			int cantReg = 0;
			bool obtieneDatosWS = true;

			try 
			{
				//Se valida el material
				string constCadenaMaterialChipRep = ConfigurationSettings.AppSettings["constCadenaMaterialChipRep"].ToString();						
				if (p_material.StartsWith("PS") && constCadenaMaterialChipRep.IndexOf(p_material) == -1)
				{
					string idTransaccion = string.Empty;         
					string mensajeResultado = string.Empty;
					SimCardsWS.itReturnType[] itReturn;
					SimCardsWS.nroSimcardsDataType[] nroSimcardsDataType;

					string result = objSimCards.obtenerDatosNroTelef(ref idTransaccion, idAplicacion, nombreAplicacion, usuarioAplicacion,
						Nro_Telefono, p_material, p_serie, out mensajeResultado, out nroSimcardsDataType, out itReturn);

					//Validar registro
					cantReg = nroSimcardsDataType.Length;

					if (cantReg > 0)
					{
						ws_nroTelefono = nroSimcardsDataType[0].nroTelef;
						ws_material = nroSimcardsDataType[0].matNr;
						ws_serie = nroSimcardsDataType[0].serNr;
						ws_materialAntiguo = nroSimcardsDataType[0].matNrAntig;
						ws_fechacambio = nroSimcardsDataType[0].fecCambio.ToShortDateString();

						HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
						HelperLog.EscribirLog("", nameArchivo, "Datos obtenidos del WS", false);
						HelperLog.EscribirLog("", nameArchivo, "- Nro telefono: " + ws_nroTelefono, false);
						HelperLog.EscribirLog("", nameArchivo, "- Material: " + ws_material, false);
						HelperLog.EscribirLog("", nameArchivo, "- Serie: " + ws_serie, false);
						HelperLog.EscribirLog("", nameArchivo, "- Material Antiguo: " + ws_materialAntiguo, false);
						HelperLog.EscribirLog("", nameArchivo, "- Fecha Cambio: " + ws_fechacambio, false);
					}
					else
					{
						obtieneDatosWS = false;
						HelperLog.EscribirLog("", nameArchivo, "***** El WS no devuelve datos. Por lo no cual se consultará SAP.", false);
					}
					HelperLog.EscribirLog("", nameArchivo, "- Mensaje Resultado: " + mensajeResultado, false);
					HelperLog.EscribirLog("", nameArchivo, "- Resultado Metodo WS: " + result, false);
					HelperLog.EscribirLog("", nameArchivo, "- Mensaje ItReturn: " + itReturn[0].mensaje, false);
					HelperLog.EscribirLog("", nameArchivo, "- Tipo ItReturn: " + itReturn[0].tipo, false);
				}
				else
				{
					ws_serie = p_serie;	
					HelperLog.EscribirLog("", nameArchivo, "***** El material no es chip con telefono. Por lo cual se consultará a SAP el precio con los parametros de entrada.", false);
					HelperLog.EscribirLog("", nameArchivo, "** Serie (parametro de entrada): " + ws_serie, false);
				}
			}
			catch(Exception ex)
			{		
				obtieneDatosWS = false;
				HelperLog.EscribirLog("", nameArchivo, ex.Message, false);
				HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
				HelperLog.EscribirLog("", nameArchivo, ex.StackTrace, false);
			}

			string resultNewSAP = string.Empty;

			if (obtieneDatosWS)
			{
				//Metodo SAP			
				resultNewSAP = new SapGeneralNegocios().ConsultarIccid_Zs(Clase_Venta, Nro_Telefono, Tipo_Venta, ws_fechacambio, p_material, ws_materialAntiguo, ws_serie);

				HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
				HelperLog.EscribirLog("", nameArchivo, "Datos de salida del SAP", false);
				HelperLog.EscribirLog("", nameArchivo, "- Imei: " + resultNewSAP, false);
			}

			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, "------------ Metodo ConsultarIccid: Finaliza Invocacion WS. obtenerDatosNroTelef ------------", false);
    			
			return resultNewSAP;

		}
	}
}
