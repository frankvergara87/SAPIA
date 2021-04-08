using System;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Data;
using System.Configuration;
using Claro.SisAct.Common;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de VentaExpressNegocios.
	/// </summary>
	public class VentaExpressNegocios
	{
		public VentaExpressNegocios()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		//<!-- INICIO PROY-9067 - IDEA-11443 Mejora en procesos de Cambio de Plan para renovaciones -->
		public void WSValidaApadeceCAC(BEGestionAcuerdoWS oGestionAcuerdo,ref bool vLibre, ref bool vExito,
			string nroTelefono, string canal, int MesesMaxAS,ref string sMessage)			
		{
			vExito = false;
			vLibre = false;					
			sMessage="";
						
			string nameArchivo = "LOG_POS_APADECE";	
			string initFormatLog = nroTelefono + " " + string.Format("{0:dd-MM-yyyy hh:mm:ss}", DateTime.Now) + " | ";
				
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "***************** Inicio WSValidaApadeceCAC", false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "MesesMaxAS:" + Funciones.CheckStr(MesesMaxAS) , false);
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);

			//INIIC
			string strtipocontrato = Funciones.CheckStr(ConfigurationSettings.AppSettings["constDescAcuerdoLibre"]);
			int strparametros = Funciones.CheckInt(ConfigurationSettings.AppSettings["consGrupo_Vigencia_diasXcanal"]);
			string[] strtipocontratoN = strtipocontrato.Split(Convert.ToChar(";"));
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Tipos de Contrato:" + strtipocontrato , false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Vigencia de dias" + strparametros , false);
			try
			{
				VentaExpressDatos obj = new VentaExpressDatos();

				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "Pasa Flujo GESTIONACUERDOWS", false);
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "Valores Acuerdo:", false);
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- FECHA INICIO = " + oGestionAcuerdo.acuerdoFechaInicio , false);
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- FECHA FIN = " + oGestionAcuerdo.acuerdoFechaFin , false);
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- MONTO APADECE = " + oGestionAcuerdo.acuerdoMontoApacedeTotal , false);
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- COD PLAZO ACUERDO = " + oGestionAcuerdo.codPlazoAcuerdo , false);
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- PLAZO ACUERDO = " + oGestionAcuerdo.descPlazoAcuerdo , false);				
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- ESTADO ACUERDO = " + oGestionAcuerdo.acuerdoEstado , false);
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- DESCRIPCION ESTADO ACUERDO = " + oGestionAcuerdo.descripcionEstadoAcuerdo , false);
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- ID ACUERDO = " + oGestionAcuerdo.acuerdoId , false);
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- ORIGEN ACUERDO = " + oGestionAcuerdo.acuerdoOrigen , false);
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- COID = " + oGestionAcuerdo.coId , false);
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- CUSTOMER = " + oGestionAcuerdo.customerId , false);
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- NRO DIAS PENDIENTE = " + oGestionAcuerdo.diasPendientes , false);
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- NRO MESES PENDIENTE = " + oGestionAcuerdo.mesesPendientes , false);
				
				if (oGestionAcuerdo.acuerdoOrigen == "COBSDB")
				{
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "***************** ORIGEN COBS", false);
					HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);

					for(int i=0; i< strtipocontratoN.Length;i++)
					{
						if(strtipocontratoN[i] == Funciones.CheckStr(oGestionAcuerdo.descPlazoAcuerdo))
						{
							if(strtipocontratoN[i] == "LIBRE")
							{
								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Entra flujo acuerdo libre"  , false);
								DataTable dtDias = obj.ConsultaVigenciaLibre(strparametros);

								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- cumple condicion de acuerdo libre"  , false); 	
								vLibre = true;

								if (dtDias.Rows.Count > 0)
								{	
									for (int j=0; j<dtDias.Rows.Count; j++)
									{
										DataRow dDias = dtDias.Rows[j];
										if (canal == dDias["PARAV_VALOR"].ToString())
										{
											if(Funciones.CheckInt(dDias["PARAV_VALOR1"].ToString()) <= oGestionAcuerdo.diasVigentes)
											{
												vExito = true;											
												HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Pasa flujo de acuerdo libre/dias de vigencia = " + oGestionAcuerdo.acuerdoVigenciaMeses , false);
												return;
												//												break;
											}
											else
											{
												//Mensaje02
												sMessage = "La línea ingresada debe tener más de " + dDias["PARAV_VALOR1"].ToString() + " día(s) activa para permitir renovación con Acuerdo Libre.";
												vExito = false;												
												HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- No Pasa flujo de acuerdo libre/dias de vigencia = " + oGestionAcuerdo.acuerdoVigenciaMeses , false);
												HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- No hay canal configurado para acuerdo libre" , false);

												return;
												//												break;													
											}
										}
										else
										{	
											vExito = false;											
											//Mensaje01
											sMessage = "El canal " + canal + " " +ConfigurationSettings.AppSettings["constRenoLibreCanal"];
											HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- No Pasa flujo de acuerdo libre/dias de vigencia: no hay canal configurado = " + canal , false);
											//return;
										}
									}
								}
								else
								{
									vExito=false;
									//Mensaje01
									sMessage = "El canal " + canal + " " +ConfigurationSettings.AppSettings["constRenoLibreCanal"];
									return;
								}

							}//TERMIN LIBRE
							else
							{//si no es libre
								vLibre=false;
								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Entra flujo que no es acuerdo libre (sinergia)"  , false);
								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- no es acuerdo libre"  , false); 

								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- tiene meses de vigencia configurable ==> " + Funciones.CheckStr(ConfigurationSettings.AppSettings["mesesMaxRenoAnticipada"])  , false);
								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Meses pendiente flujo sinergia ==> " + Funciones.CheckStr(oGestionAcuerdo.mesesPendientes)  , false);
								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Meses maximo flujo sinergia ==> " + Funciones.CheckStr(MesesMaxAS) , false);

								if( oGestionAcuerdo.mesesPendientes <= MesesMaxAS )
								{
									HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- cumple para hacer un renovacion anticipada"  , false);
									vExito=true;	
								}
								else if(oGestionAcuerdo.mesesPendientes > MesesMaxAS)
								{
									//Inicio Renovacion anticipada
									HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- cumple para hacer un renovacion anticipada, pero excede el tiempo autorizado"  , false);									
									vExito = true;
									//Fin Renovacion anticipada
								}
								else
								{
									vExito = false;
									HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- No pasa validacion de sinergia"  , false); 
									HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- No cumple con los meses para renovar: " + Funciones.CheckStr(sMessage) , false);
									//Mensaje05
									sMessage = ConfigurationSettings.AppSettings["msjErrorRevPoAPEDECEMaxMeses"];
									return;
								}

							}//termina si no es libre
						}// PLAZO ACEURDO FIN
					}//TERMINA FOR
							
					//VALIDACION NUEVA -- CUANDO NO TIENE CONTRATO EN LISTA.. EJ. 6 MESES CONTRATO EQ Y LISTA 6 MESES 
					if (vLibre == false)
					{
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Entra flujo que no es acuerdo libre (sinergia)"  , false);
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- no es acuerdo libre"  , false); 
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- tiene meses de vigencia configurable ==> " + Funciones.CheckStr(ConfigurationSettings.AppSettings["mesesMaxRenoAnticipada"])  , false);
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Meses pendiente flujo sinergia ==> " + Funciones.CheckStr(oGestionAcuerdo.mesesPendientes)  , false);
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Meses maximo flujo sinergia ==> " + Funciones.CheckStr(MesesMaxAS) , false);

						if( oGestionAcuerdo.mesesPendientes <= Funciones.CheckInt(MesesMaxAS) )						
						{
							HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- cumple para hacer un renovacion anticipada"  , false);
							vExito = true;
						}
						else if(oGestionAcuerdo.mesesPendientes > MesesMaxAS)
						{
							//Inicio Renovacion anticipada
							HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- cumple para hacer un renovacion anticipada, pero excede el tiempo autorizado"  , false);									
							vExito = true;
							//Fin Renovacion anticipada
						}
						else
						{
							vExito = false;
							HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- No pasa validacion de sinergia"  , false); 
							HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- No cumple con los meses para renovar: " + Funciones.CheckStr(sMessage) , false);
							//Mensaje05
							sMessage = ConfigurationSettings.AppSettings["msjErrorRevPoAPEDECEMaxMeses"];
							return;
						}
					}

				}// TEMRINA COBS
				else
				{ // PVU
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "***************** ORIGEN PVU", false);
					HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);

					if (oGestionAcuerdo.acuerdoVigenciaMeses == String.Empty)
					{
						//Mensaje04
						vExito=false;
						sMessage=ConfigurationSettings.AppSettings["constRenoAntiValoresWS"]+ "Vigencia";
						return;
					}
					else
					{
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- tiene meses de vigencia"  , false);
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- tiene meses de vigencia configurable ==> " + Funciones.CheckStr(ConfigurationSettings.AppSettings["constMesesPendientes"])  , false);

						// en pvu contratos vencidos = 2013 a 2014.. pro lo tanto no hay anticipada y esta validacion esta de mas.
						if(oGestionAcuerdo.mesesPendientes <= MesesMaxAS)
						{
							HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- renovacion anticipada"  , false);
							vExito=true;
							// en pvu contratos vencidos = 2013 a 2014.. pro lo tanto no hay anticipada y esta validacion esta de mas.
						}
						else if (oGestionAcuerdo.mesesPendientes  >  MesesMaxAS)
						{				
							//Inicio Renovacion anticipada					
							HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- ha excedido el límite de meses a renovar"  , false);
							vExito = true;
							//Fin Renovacion anticipada					
						}
						else
						{
							if(oGestionAcuerdo.mesesPendientes <= 0)
							{
								vExito=true;
								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "contrato vencido"  , false);
							}
							else
							{
								vExito=false;
								//Mensaje05
								sMessage=ConfigurationSettings.AppSettings["msjErrorRevPoAPEDECEMaxMeses"];
								return;
							}
						}   
					}
				
				} // TERMINA PVU
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "***************** Fin ValidacionApadeceCAC", false);
			}
			catch(Exception ex)
			{
				sMessage = "Error. " + ex.Message;
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + sMessage, false);
			}		
            
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- CUMPLE CONDICION = " + (vExito ? "si" : "NO") , false);			

			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "***************** Fin ValidacionApadeceCAC", false);	
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);

			// termina..
		}
		
		
		
		public void WSValidaApadece(BEGestionAcuerdoWS oGestionAcuerdo,ref bool vLibre, ref bool vExito,
			string nroTelefono, string canal, int MesesMaxAS,ref string sMessage)
		{
			vExito = false;
			vLibre = false;                          
			sMessage="";
                                   
			string nameArchivo = "LOG_POS_APADECE";
			string initFormatLog = nroTelefono + " " + string.Format("{0:dd-MM-yyyy hh:mm:ss}", DateTime.Now) + " | ";
                        
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "***************** Inicio WSValidaApadece", false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "MesesMaxAS:" + Funciones.CheckStr(MesesMaxAS) , false);
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);

			string strtipocontrato = Funciones.CheckStr(ConfigurationSettings.AppSettings["constDescAcuerdoLibre"]);
			int strparametros = Funciones.CheckInt(ConfigurationSettings.AppSettings["consGrupo_Vigencia_diasXcanal"]);
			string[] strtipocontratoN = strtipocontrato.Split(Convert.ToChar(";"));
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Tipos de Contrato:" + strtipocontrato , false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Vigencia de dias" + strparametros , false);
                  
			VentaExpressDatos obj = new VentaExpressDatos();

			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "Pasa Flujo GESTIONACUERDOWS", false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "Valores Acuerdo:", false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- FECHA INICIO = " + oGestionAcuerdo.acuerdoFechaInicio , false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- FECHA FIN = " + oGestionAcuerdo.acuerdoFechaFin , false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- MONTO APADECE = " + oGestionAcuerdo.acuerdoMontoApacedeTotal , false);                      
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- COD PLAZO ACUERDO = " + oGestionAcuerdo.codPlazoAcuerdo , false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- PLAZO ACUERDO = " + oGestionAcuerdo.descPlazoAcuerdo , false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- ESTADO ACUERDO = " + oGestionAcuerdo.acuerdoEstado , false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- DESCRIPCION ESTADO ACUERDO = " + oGestionAcuerdo.descripcionEstadoAcuerdo , false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- ID ACUERDO = " + oGestionAcuerdo.acuerdoId , false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- ORIGEN ACUERDO = " + oGestionAcuerdo.acuerdoOrigen , false);                      
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- COID = " + oGestionAcuerdo.coId , false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- CUSTOMER = " + oGestionAcuerdo.customerId , false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- NRO DIAS PENDIENTE = " + oGestionAcuerdo.diasPendientes , false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- NRO MESES PENDIENTE = " + oGestionAcuerdo.mesesPendientes , false);

                  
			try
			{
				if (oGestionAcuerdo.acuerdoOrigen == "COBSDB")
				{
					for(int i=0; i< strtipocontratoN.Length;i++)
					{
						if(strtipocontratoN[i] == Funciones.CheckStr(oGestionAcuerdo.descPlazoAcuerdo))
						{
							if(strtipocontratoN[i] == "LIBRE")
							{
								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Entra flujo acuerdo libre"  , false);
								DataTable dtDias = obj.ConsultaVigenciaLibre(strparametros);

								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- cumple condicion de acuerdo libre"  , false);      
								vLibre = true;

								if (dtDias.Rows.Count > 0)
								{     
									for (int j=0; j<dtDias.Rows.Count; j++)
									{
										DataRow dDias = dtDias.Rows[j];
										if (canal == dDias["PARAV_VALOR"].ToString())
										{
											if(Funciones.CheckInt(dDias["PARAV_VALOR1"].ToString()) <= Funciones.CheckInt(oGestionAcuerdo.diasVigentes))
											{
												vExito = true;                                                               
												HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Pasa flujo de acuerdo libre/dias de vigencia = " + oGestionAcuerdo.acuerdoVigenciaMeses , false);
												return;
												//                                                                     break;
											}
											else
											{
												//Mensaje02
												sMessage = "La línea ingresada debe tener más de " + dDias["PARAV_VALOR1"].ToString() + " día(s) activa para permitir renovación con Acuerdo Libre.";
												vExito = false;                                                                    
												HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- No Pasa flujo de acuerdo libre/dias de vigencia = " + oGestionAcuerdo.acuerdoVigenciaMeses , false);
												return;
												//                                                                     break;                                                                            
											}
										}
										else
										{     
											vExito = false;                                                              
											//Mensaje01
											sMessage = "El canal " + canal + " " +ConfigurationSettings.AppSettings["constRenoLibreCanal"];
											HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- No Pasa flujo de acuerdo libre/dias de vigencia: no hay canal configurado = " + canal , false);
											//return;
										}
									}
								}
								else
								{
									vExito=false;
									//Mensaje01
									sMessage = "El canal " + canal + " " +ConfigurationSettings.AppSettings["constRenoLibreCanal"];                                                   
									return;
								}

							}
							else
							{ // no es libre
								vLibre = false;
//gaa20170628:Cambio pedido para que deje pasar en dac y cadena reno anticipada
									vExito=true;
//								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Entra al flujo de validacion de DAC's y cadenas"  , false);                                      
//								//INICIO IMP SD_758800
//								//if(Convert.ToDateTime(oGestionAcuerdo.acuerdoFechaInicio) <= DateTime.Now.AddMonths(-6))   
//								if (oGestionAcuerdo.mesesPendientes > 0)
//								{
//									vExito=false;
//									//Mensaje08
//									sMessage=ConfigurationSettings.AppSettings["constRenoMeses"];
//									HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "-no cumple condicion de seis meses de antiguedad de DAC's y cadenas"  , false); 
//									return;									
//								}
//								else
//								{
//									vExito=true;
//									HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- cumple condicion de seis meses de antiguedad de DAC's y cadenas"  , false);     
//								}								
//fin gaa20170628:Cambio pedido para que deje pasar en dac y cadena reno anticipada			
							}
						}
                                         
                                   
                                      
                                      
					}
                     
					/*
					//TERMINA FOR????
					if (vLibre == false)
					{
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Entra flujo que no es acuerdo libre (sinergia)"  , false);
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- no es acuerdo libre"  , false); 
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- tiene meses de vigencia configurable ==> " + Funciones.CheckStr(ConfigurationSettings.AppSettings["mesesMaxRenoAnticipada"])  , false);
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Meses pendiente flujo sinergia ==> " + Funciones.CheckStr(oGestionAcuerdo.mesesPendientes)  , false);
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Meses maximo flujo sinergia ==> " + Funciones.CheckStr(MesesMaxAS) , false);

						if( oGestionAcuerdo.mesesPendientes <= 0 && Funciones.CheckDate(oGestionAcuerdo.acuerdoFechaFin) < DateTime.Now )
						{
							HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- cumple para hacer un renovacion anticipada"  , false);
							vExito = true;
						}
						else
						{
							vExito = false;
							HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- No pasa validacion de sinergia"  , false); 
							HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- No cumple con los meses para renovar: " + Funciones.CheckStr(sMessage) , false);
							//Mensaje07
							sMessage = ConfigurationSettings.AppSettings["constRenoMeses"];
							return;
						}
					}*/
					//FIN IMP SD_758800
                           
				}                            
				else 
				{     //es PVU
					if(oGestionAcuerdo.acuerdoVigenciaMeses == String.Empty)
					{
						vExito=false;
						//mensaje 03
						sMessage=ConfigurationSettings.AppSettings["constRenoAntiWS"];
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- no tiene datos de acuerdo - ", false);
					}
					else
					{
//gaa20170628:Cambio pedido para que deje pasar en dac y cadena reno anticipada	
							vExito=true;
//						if(Convert.ToInt64(oGestionAcuerdo.mesesPendientes) <= 0)
//						{
//							vExito=true;
//						}
//						else
//						{
//							vExito=false;
//							//mensaje 05
//							sMessage=ConfigurationSettings.AppSettings["msjErrorRevPoAPEDECEMaxMeses"];
//						}
//fin gaa20170628:Cambio pedido para que deje pasar en dac y cadena reno anticipada	
					}
                             
				}

			}                 
			catch(Exception ex)
			{
				string MensajeError = "Error. " + ex.Message;
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + MensajeError, false);
			}           
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- CUMPLE CONDICION = " + (vExito ? "si" : "NO") , false);               

			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "***************** Fin validarAcuerdoAPADECE", false); 
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
		}
		//<!-- FIN PROY-9067 - IDEA-11443 Mejora en procesos de Cambio de Plan para renovaciones -->

       static VentaExpressDatos objOficinaVenta = new VentaExpressDatos();

		public MigracionWL ValidacionWhitelist(string nroDocumento, string nroLinea)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
            return objOficinaVenta.ValidacionWhitelist(nroDocumento, nroLinea); 
		}

		public ArrayList ListaPlanesMaxCF(string strTipoCliente, double cargo_fijo)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ListaPlanesMaxCF(strTipoCliente,cargo_fijo); 
		}

		public ArrayList Get_ConsultaPlanServicio(string plan, string servicio)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.Get_ConsultaPlanServicio(plan,servicio);
		}

		public bool Set_Actualiza_Contrato_Solicitud(Int64 nroSEC,string strNumContrato)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.Set_Actualiza_Contrato_Solicitud(nroSEC,strNumContrato);
		}

		public void insertarLogMigracion(string[] arrLog)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			objOficinaVenta.insertarLogMigracion(arrLog);
		}
		public void actualiza_MigracionWL(string P_NRO_DOCUM, string P_NRO_LINEA,string P_ESTADO,out string P_RPTA)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			objOficinaVenta.actualiza_MigracionWL(P_NRO_DOCUM,P_NRO_LINEA,P_ESTADO,out P_RPTA);
		}

		public bool ActualizarPagoSolicitud(Int64 p_nroSEC, string p_flag_pago)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ActualizarPagoSolicitud(p_nroSEC, p_flag_pago);
		}
		//JAZ : Renov Prepago
		public PuntoVenta ObtenerDatosOficinaventa(string puntoventa)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ObtenerDatosOficinaventa(puntoventa);
		}
		public string ObtenerEstMat(string serie,string codmaterial, string puntoventa)
		{

            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ObtenerEstMat(serie,codmaterial,puntoventa);
		}
		public ArrayList ListarPlanes(string p_codigo_plan, string p_tipo_venta, string p_tipo_cliente, string p_flag_vigencia, string p_mandt)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ListarPlanes(p_codigo_plan, p_tipo_venta, p_tipo_cliente, p_flag_vigencia, p_mandt);
		}
		public ArrayList ConsultarListaCampanias(string p_tipo_venta, string p_fecha, string p_mandt)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ConsultarListaCampanias(p_tipo_venta, p_fecha, p_mandt);
		}

		public string ObtenerCargoFijoPlan(string p_codigo_plan)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ObtenerCargoFijoPlan(p_codigo_plan);
		}
		public bool ValidarIccidMsisdn(string vTelefono, string vICCID, int intTimeOut, string vStrURL, string vStrURL_contingencia, ref string MensajeError)
		{
			bool retorno = false;
			try
			{
				retorno = InvocarVentasWS(vTelefono, vICCID, intTimeOut, vStrURL, ref MensajeError);
			}
			catch (Exception)
			{
				try
				{
					retorno = InvocarVentasWS(vTelefono, vICCID, intTimeOut, vStrURL_contingencia, ref MensajeError);
				}
				catch (Exception exp2)
				{
					MensajeError = "El servicio esta temporalmente fuera de servicio. "+ exp2.Message;
				}
			}
			return retorno;
		}

		private bool InvocarVentasWS(string p_msisdn, string p_iccid, int p_TimeOut, string p_URL, ref string mensajeError)
		{
			bool respuesta = false;
			mensajeError = "";

				VentasWS.VentasWSService objVentas = new VentasWS.VentasWSService();
				objVentas.Url = p_URL;
				objVentas.Timeout = p_TimeOut;
				objVentas.Credentials= System.Net.CredentialCache.DefaultCredentials;
				VentasWS.EstadoTelefonoRequestType objTelefonoReq = new VentasWS.EstadoTelefonoRequestType();
				VentasWS.EstadoTelefonoResponseType objTelefonoResp = new VentasWS.EstadoTelefonoResponseType();
				objTelefonoReq.iccid = p_iccid;
				objTelefonoReq.numero = p_msisdn;
				objTelefonoResp = objVentas.validaTelefonoDisponible(objTelefonoReq);

				// 1-DISPONIBLE          2-NO DISPONIBLE
				respuesta = (objTelefonoResp.retorno.resultado == "1");

				if (!respuesta)
				{
					mensajeError = objTelefonoResp.retorno.mensaje;
				}
			return respuesta; 
		}
		public bool CrearVenta(VentaSiscad oVenta, ref string NroTicket)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.CrearVenta(oVenta, ref NroTicket);
		}

		public string CrearOrdenVenta(OrdenVentaSiscad oOrdenVenta)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.CrearOrdenVenta(oOrdenVenta);
		}
		
		public AlertaSiscad CorreoAlertasSiscad(string codPdv)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.CorreoAlertasSiscad(codPdv);
		}
		public string ConsultaParamConfigSiscad(string cod)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ConsultaParamConfigSiscad(cod);
		}

		public string GrabarVentaRenovacion(string oficina, string doc_tipo, string doc_nro, string vendedor, string doc_sap,
			string cont_sap, string correo, string plan_act, string telefono, 
			string plan_nuevo, string tope_cons, string servidor, double limite, string ciclo_fact)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.GrabarVentaRenovacion(oficina, doc_tipo, doc_nro, vendedor, doc_sap, 
				cont_sap, correo, plan_act, telefono, plan_nuevo, tope_cons, servidor, limite,ciclo_fact);
		}

		public bool validaAPADECE(int co_id)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.validaAPADECE(co_id);
		}
		
		public string GrabarVentaRenovacionCAC(string oficina, string doc_tipo, string doc_nro, string vendedor, string doc_sap,
			string cont_sap, string correo, string plan_act, string telefono, 
			string plan_nuevo, string tope_cons, string servidor, double limite, string ciclo_fact, string canal, string pedido_sap, string tipo_renovacion, int flag_exoneracion, int flag_descuento, string titular, string representante, double descuento, string usuarioValidador, 
			string RetenidoFidelizado)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.GrabarVentaRenovacionCAC(oficina, doc_tipo, doc_nro, vendedor, doc_sap, 
				cont_sap, correo, plan_act, telefono, plan_nuevo, tope_cons, servidor, limite,ciclo_fact,canal,pedido_sap,tipo_renovacion,flag_exoneracion,flag_descuento, titular, representante, descuento, usuarioValidador, 
				RetenidoFidelizado); // E77568, agregado campo RetenidoFidelizado
		}

		public bool EliminarVentaRenovacionPostpago(string doc_sap)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.EliminarVentaRenovacionPostpago( doc_sap);
		}

		public AcuerdoApadece ConsultarAPADECE(string nroTelefono)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ConsultarAPADECE(nroTelefono);
		}

		//FMES
		public DataTable ConsultaEstadoSOT()
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ConsultaEstadoSOT();

		}

		public DataTable reporteVentasxPtoVenta(int intSec,string strNumeroDocumento,string strTipoDocumento, string strFechaInicio, string strFechaFin, string strPuntoVenta, string strEstadoSot)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.reporteVentasxPtoVenta(intSec, strNumeroDocumento, strTipoDocumento,  strFechaInicio,  strFechaFin,  strPuntoVenta,  strEstadoSot);

		}

		//FMES
		public void ObtenerMontoMaxDescuentoAS(ref double MontoMaxDesAS, ref double MesesMaxDesAS)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			objOficinaVenta.ObtenerMontoMaxDescuentoAS(ref MontoMaxDesAS, ref MesesMaxDesAS);
		}

		//Inicio 25-11-2013 apadece
		public bool validarAcuerdoAPADECE(string nroTelefono, string canal, ref AcuerdoApadece objAcuerdo, ref bool strVigencia, int mesesMaxAS, ref string strLibre,ref string strcanal)
		{
			bool vExito = false;
			bool vLibre = false;
			strVigencia = true;
            strcanal = "";
			strLibre = "";
			int diasxsupension = 0;
			string nameArchivo = "LOG_POS_APADECE";	
			string initFormatLog = nroTelefono + " " + string.Format("{0:dd-MM-yyyy hh:mm:ss}", DateTime.Now) + " | ";
				
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "***************** Inicio validarAcuerdoAntiguoAPADECE", false);
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);


			//INIIC
			string strtipocontrato = Funciones.CheckStr(ConfigurationSettings.AppSettings["constDescAcuerdoLibre"]);
			int strparametros = Funciones.CheckInt(ConfigurationSettings.AppSettings["consGrupo_Vigencia_diasXcanal"]);
			string[] strtipocontratoN = strtipocontrato.Split(Convert.ToChar(";"));
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Vigencia de dias" + strparametros , false);

			try
			{
                if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
				objAcuerdo = objOficinaVenta.ConsultarAPADECE(nroTelefono);

				if (objAcuerdo != null)
				{
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "Pasa flujo del antiguo SIGA:", false);
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "Valores Acuerdo:", false);
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- COD PLAZO ACUERDO = " + objAcuerdo.COD_PLAZO_ACUERDO , false);				
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- PLAZO ACUERDO = " + objAcuerdo.PLAZO_ACUERDO , false);
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- COD ESTADO ACUERDO = " + objAcuerdo.COD_ESTADO_ACUERDO , false);
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- ESTADO ACUERDO = " + objAcuerdo.ESTADO_ACUERDO , false);
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- NRO MESES PENDIENTE = " + objAcuerdo.NRO_MESES_PENDIENTE.ToString() , false);
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- FECHA FIN = " + objAcuerdo.FECHA_FIN.ToShortDateString() , false);
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- DESCRIPCION ACUERDO = " + objAcuerdo.PLAZO_ACUERDO.ToString() , false);

					if(objAcuerdo.FECHA_FIN >= Funciones.CheckDate("01/01/2015"))
					{
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- cumple condicion de fechas"  , false);
						for(int i=0; i< strtipocontratoN.Length;i++)
						{
							if(strtipocontratoN[i] == Funciones.CheckStr(objAcuerdo.PLAZO_ACUERDO))
							{
								if(strtipocontratoN[i] == "LIBRE")
								{
                                  HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Entra flujo acuerdo libre"  , false);
									DataTable dtDias = objOficinaVenta.ConsultaVigenciaLibre(strparametros);

								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- cumple condicion de acuerdo libre"  , false); 	
								vLibre = true;

									 String tipo = ConfigurationSettings.AppSettings["constTipoCedeTelefono"];
                                     DataTable dtCede  = ConsultaDetalleAcuerdo(tipo, nroTelefono);
									if (dtCede.Rows.Count > 0)
									{
										DataRow dCede = dtCede.Rows[0];
                                        diasxsupension = Funciones.CheckInt(dCede["DIAS_BLOQ_SUSP"]);
										
										HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Dias de suspension = " + diasxsupension.ToString() , false);

										
									}
									

									TimeSpan time= DateTime.Now - objAcuerdo.FECHA_INICIO;

									int vigencia= 	time.Days - diasxsupension;
									if (dtDias.Rows.Count > 0)
									{	
										for (int j=0; j<dtDias.Rows.Count; j++)
										{
											DataRow dDias = dtDias.Rows[j];
												if (canal == dDias["PARAV_VALOR"].ToString())
												{
													if(Funciones.CheckInt(dDias["PARAV_VALOR1"].ToString()) <= vigencia)
													{
														vExito = true;
														strVigencia = false;
														strLibre = "";
														strcanal = "";
														HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Pasa flujo de acuerdo libre/dias de vigencia = " + vigencia , false);
														break;
														

													
													}
													else
													{
														strLibre = "La línea ingresada debe tener más de " + dDias["PARAV_VALOR1"].ToString() + " día(s) activa para permitir renovación con Acuerdo Libre.";
														vExito = false;
														strVigencia = false;
														strcanal = "";
														HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- No Pasa flujo de acuerdo libre/dias de vigencia = " + vigencia , false);

														break;
													
													}
												}else
												{
													strLibre = "";
													vExito = false;
													strVigencia = false;
													strcanal = "El canal " + canal + " " +ConfigurationSettings.AppSettings["constRenoLibreCanal"];
													HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- No Pasa flujo de acuerdo libre/dias de vigencia: no hay canal configurado = " + strcanal , false);
												}
										    }
										}
										else{
												strcanal = "El canal " + canal + " " +ConfigurationSettings.AppSettings["constRenoLibreCanal"];
										}
									
									
								}
								else
								{

								  if(canal != "01"){
									HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Entra al flujo de validacion de DAC's y cadenas"  , false); 
								if(objAcuerdo.FECHA_INICIO <= DateTime.Now.AddMonths(-6))	
								{
										HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- cumple condicion de seis meses de antiguedad de DAC's y cadenas"  , false); 	
									vExito = true;
									strVigencia = true;
								}
								else
								{
										HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "-no cumple condicion de seis meses de antiguedad de DAC's y cadenas"  , false); 
									vExito = false;
									strVigencia = false;
								}
								break;
							}	 									   										   
						}
					}
						}
					}

					if(vLibre == false)
					{
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Entra flujo que no es acuerdo libre (sinergia)"  , false);
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- no es acuerdo libre"  , false); 
						if(canal == "01")
						{
							HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- es cac"  , false); 
							if(objAcuerdo.FECHA_FIN >= Funciones.CheckDate("01/01/2015"))
							{
								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- cumple condicion de fechas"  , false); 
								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- tiene meses de vigencia configurable ==> " + Funciones.CheckStr(ConfigurationSettings.AppSettings["mesesMaxRenoAnticipada"])  , false);
								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Meses pendiente flujo sinergia ==> " + Funciones.CheckStr(objAcuerdo.NRO_MESES_PENDIENTE)  , false);
								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- Meses maximo flujo sinergia ==> " + Funciones.CheckStr(mesesMaxAS)  , false);
								if((Convert.ToInt32(objAcuerdo.NRO_MESES_PENDIENTE) <= Funciones.CheckInt(mesesMaxAS) ))
								{
									HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- cumple para hacer un renovacion anticipada"  , false);
									vExito = true;
								}
								else
								{
									//Inicio Renovacion anticipada Jaz
									HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- cumple para hacer un renovacion anticipada, pero excede el tiempo autorizado"  , false);									
									vExito = true;
									//Fin Renovacion anticipada Jaz
								}

							}
							else 
							{
								vExito = false;
								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- No pasa validacion de sinergia"  , false); 
							}
						}
						else 
						{
							if(objAcuerdo.FECHA_FIN >= Funciones.CheckDate("01/01/2015"))
							{
								if(objAcuerdo.NRO_MESES_PENDIENTE <= 0 && objAcuerdo.FECHA_FIN < DateTime.Now)
								{
									vExito = true;
								}
							}
						}
					}
				}
				else 
				{
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "El objeto acuerdo no trae datos. No esta referenciado", false);					
				}			
							
			}
			catch(Exception ex)
			{
				string MensajeError = "Error. " + ex.Message;
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + MensajeError, false);
			}		
            
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- CUMPLE CONDICION = " + (vExito ? "si" : "NO") , false);			

			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "***************** Fin validarAcuerdoAPADECE", false);	
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);

			return vExito;
		}
		//Fin 25-11-2013 apadece

		//inicio whzr 02102014
		public bool Consultar_APADECE_NUEVO(int intMSISDN, int intCOD_ID, int intACUERDO_ID, DateTime dtFECHA_TRANSACCION, int intTIPO_ACUERDO,
			int intMOTIVO_APADECE, int intCF_NUEVO, int intFLG_EQUIPO, int intACUERDO_VIGENTE,
			ref int intMONTO_APADECE, ref string strTIPO_PRODUCTO, ref int intCODERROR, ref string strDESERROR, ref AcuerdoApadece objAcuerdo,string canal, ref string strMensajeNSIGA, int MesesMaxAS)
		{
			bool vExito = false;			
			objAcuerdo = null;
			strMensajeNSIGA = string.Empty;
			string nameArchivo = "LOG_POS_NUEVO_APADECE";	
			string initFormatLog = intMSISDN + " " + string.Format("{0:dd-MM-yyyy hh:mm:ss}", DateTime.Now) + " | ";
			string strMesesVigenciaNSIGA = Funciones.CheckStr(System.Configuration.ConfigurationSettings.AppSettings["consMesesVigenciaNSIGA"]);	
			string strFechaFin;
			string strMesesPendientes;
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "***************** Inicio validarAcuerdoNUEVOAPADECE", false);
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			 
			try
			{
                if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
				objAcuerdo = objOficinaVenta.Consultar_APADECE_NUEVO(intMSISDN, intCOD_ID, intACUERDO_ID, dtFECHA_TRANSACCION, intTIPO_ACUERDO, intMOTIVO_APADECE, intCF_NUEVO, intFLG_EQUIPO, intACUERDO_VIGENTE,
					ref intMONTO_APADECE, ref strTIPO_PRODUCTO, ref intCODERROR, ref strDESERROR);
				

			

				if (objAcuerdo != null)
				{
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "Valores Acuerdo:", false);
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- COD PLAZO ACUERDO = " + objAcuerdo.NCA_IDACUERDO , false);				
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- PLAZO ACUERDO = " + objAcuerdo.NCA_COD_PLAZO_ACUERDO , false);


					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- NRO MESES PENDIENTE = " + objAcuerdo.NCA_VIGENCIA_MESES.ToString() , false);
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- FECHA ACUERDO = " + objAcuerdo.NCA_FECHA_ACUERDO.ToString() , false);
					
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- si tiene acuerdo"  , false);
					strFechaFin = string.Format("{0:dd/MM/yyyy}", Funciones.CheckDate(objAcuerdo.NCA_FECHA_ACUERDO).AddMonths(Funciones.CheckInt(objAcuerdo.NCA_VIGENCIA_MESES)));
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- FECHA FIN = " + strFechaFin , false);
					
					DateTime dtFechaFin = Funciones.CheckDate(strFechaFin);
					DateTime dtFechaAct = DateTime.Now;
					int cont = 0;
					while(dtFechaAct < dtFechaFin)
					{
						dtFechaAct = dtFechaAct.AddMonths(1);
						cont++;
					}
					strMesesPendientes = Funciones.CheckStr(cont);

					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- MESES PENDIENTES = " + strMesesPendientes , false);

					if(canal == "01")
					{
						HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- es cac"  , false);
						if(Funciones.CheckDate(objAcuerdo.NCA_FECHA_ACUERDO) >= Funciones.CheckDate("13/12/2013") && Funciones.CheckDate(objAcuerdo.NCA_FECHA_ACUERDO) <= Funciones.CheckDate("31/12/2014"))
						{
							HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- cumple con  las fechas"  , false);
							if (objAcuerdo.NCA_VIGENCIA_MESES != String.Empty)
							{
								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- tiene meses de vigencia"  , false);
								HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- tiene meses de vigencia configurable ==> " + Funciones.CheckStr(ConfigurationSettings.AppSettings["constMesesPendientes"])  , false);
								
								if((Convert.ToInt32(strMesesPendientes) <= Funciones.CheckInt(MesesMaxAS) ))
								{
									HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- renovacion anticipada"  , false);
									vExito = true;
									strMensajeNSIGA = "";
								}
								else if (Convert.ToInt32(strMesesPendientes) >  Funciones.CheckInt(MesesMaxAS))
								{									
									//Inicio Renovacion anticipada JAZ
									HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- ha excedido el límite de meses a renovar"  , false);
									vExito = true;
									strMensajeNSIGA = "";
									//Inicio Renovacion anticipada JAZ
								}
								else if (Convert.ToInt32(strMesesPendientes)  <= 0)
								{
									vExito = true;
									strMensajeNSIGA = "";
								}
								else
								{
									strMensajeNSIGA = "V";
								}

							}
							else
							{
								strMensajeNSIGA = "V";
							}

						}
						else
						{
							vExito = false;
							strMensajeNSIGA = "";
						}	
					}
					else
					{
						if(Funciones.CheckDate(objAcuerdo.NCA_FECHA_ACUERDO) >= Funciones.CheckDate("13/12/2013") && Funciones.CheckDate(objAcuerdo.NCA_FECHA_ACUERDO) <= Funciones.CheckDate("31/12/2014"))
						{
							if (objAcuerdo.NCA_VIGENCIA_MESES != String.Empty)
							{

								if(Convert.ToInt32(strMesesPendientes)  <= 0)
								{
									vExito = true;
									strMensajeNSIGA = "";
								}
								else
								{
									vExito = false;
									strMensajeNSIGA = "V";
								}

							}
							else
							{
								vExito = false;
								strMensajeNSIGA = "";
							}	
						}	
						else{
							vExito = false;
							strMensajeNSIGA = "";
					}	
					}
							
				}
				else{
					HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- no tiene datos de acuerdo - ", false);
					vExito = false;
					strMensajeNSIGA = "";
				}		
							
			}
			catch(Exception ex)
			{
				string MensajeError = "Error. " + ex.Message;
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + MensajeError, false);
			}		
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- CUMPLE CONDICION = " + (vExito ? "si" : "NO") , false);			

			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "***************** Fin validarAcuerdoAPADECE", false);	
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			 

			return vExito;
		}




		//fin whzr 02102014
		
		//INICIO - WHZR
		public PuntoVenta  ListaOficinaVentaxID(string id)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
          
				return objOficinaVenta.ListaOficinaVentaxID(id);
		}


		//	SISCAD_PKG_VENTA.SISCAD_REGISTRO_HIST_VENTA 
		public bool RegistroHistoricoVenta(int idVenta, string estado, string usuario)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
          
				return objOficinaVenta.RegistroHistoricoVenta(idVenta, estado, usuario);
		}

		public bool ANULACION_VENTA(string NRO_DOCUMENTO,string PTO_VENTA)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ANULACION_VENTA(NRO_DOCUMENTO,PTO_VENTA);
		}

		//FIN - WHZR

		//inicio whzr 06112014

		public int ValidaClaveVendedor(string PI_VEN_TIPO_DOCU,
			string PI_VEN_NUME_DOCU,
			string PI_VEN_PDV,
			string PI_VEN_USUA,
			string PI_VEN_CLAV_ACTU,
			int PI_CODI_APLI,
			ref string PO_VENDEDOR) 
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }

			return objOficinaVenta.ValidaClaveVendedor(PI_VEN_TIPO_DOCU,
				PI_VEN_NUME_DOCU,
				PI_VEN_PDV,
				PI_VEN_USUA,
				PI_VEN_CLAV_ACTU,
				PI_CODI_APLI, ref PO_VENDEDOR);
		}

		public int ObtenerCantidadVentas(string strDocumento, string strtelefono, int intDias)
		{
			
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ObtenerCantidadVentas(strDocumento,strtelefono, intDias);
		}
		//fin whzr 06112014

		//inicio PPV 12012017

		public int ObtenerLineasVendidasPVU(string strDocumento, string strtelefono, int intDias)
		{
			if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ObtenerLineasVendidasPVU(strDocumento,strtelefono, intDias);
		}
        //fin PPV 12012017

		//consolidado 06012015
		public string getFlagIdValidator(string nroDoc,string  nroSec)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.getFlagIdValidator( nroDoc, nroSec);
		}

		//consolidado 06012015
		//Inicio RIHU 30122014 Desbloqueo Equipo
		public int intValidarEquipoBloqueado(string p_strIMEI, string p_strMaterial, out string p_strDescripcionResp)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			string imei15 = "";

			if(p_strIMEI.Length>15)
			{
				imei15=p_strIMEI.Substring(3);
			}
			else
			{
				imei15=p_strIMEI;
			}
			return objOficinaVenta.intValidarEquipoBloqueado(imei15, p_strMaterial, out p_strDescripcionResp);
		}

		public bool booDesbloqueoEquipo(string k_imei, ref string k_simlock, ref string k_cod_error, ref string k_msg_error)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			string imei15 = "";
			if(k_imei.Length>15)
			{
				imei15=k_imei.Substring(3);
			}
			else
			{
				imei15=k_imei;
			}
			return objOficinaVenta.booDesbloqueoEquipo(imei15, ref k_simlock, ref k_cod_error, ref k_msg_error);
		}
	
		//consolidado 16012015

		public bool ActualizarContratoSolicitud(Int64 p_nroSEC, string p_nroContrato)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ActualizarContratoSolicitud(p_nroSEC, p_nroContrato);
		}

		//consolidado 16012015

		public DataTable ConsultaDetalleAcuerdo(string tipo, string valor)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ConsultaDetalleAcuerdo(tipo,valor);
		}

		public bool actualizarDepositoGarantia(string nroSEC,string nroDeposito, string customerId, string tipoDeposito)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.actualizarDepositoGarantia(nroSEC,nroDeposito,customerId,tipoDeposito);
		}

		public Int64 GrabarVenta(string cadenaCabecera, string cadenaDetalle)
		{
			Int64 idVenta = 0;
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			idVenta = objOficinaVenta.GrabarVenta(cadenaCabecera);
			if (idVenta > 0)
			{
				foreach (string sDatosAcuerdoDet in cadenaDetalle.Split('|'))
				{
					VentaExpressDatos.GrabarVentaDetalle(idVenta, sDatosAcuerdoDet);
				}
			}
			return idVenta;
		}

		public Int64 GenerarAcuerdo(string datosAcuerdo, string datosAcuerdoDet, string datosAcuerdoServ, string datosAcuerdoEquipo)
		{
			Int64 nroAcuerdo = 0;
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			string sMensaje = "";
			nroAcuerdo = objOficinaVenta.GenerarAcuerdo(datosAcuerdo, ref sMensaje);
			if (nroAcuerdo > 0)
			{
				foreach (string sDatosAcuerdoDet in datosAcuerdoDet.Split('|'))
				{
					if (objOficinaVenta.GenerarAcuerdoDet(nroAcuerdo, sDatosAcuerdoDet, ref sMensaje) != "0")
						throw new Exception(sMensaje);
				}
				foreach (string sDatosAcuerdoServ in datosAcuerdoServ.Split('|'))
				{
					if (sDatosAcuerdoServ != "")
					{
						if (objOficinaVenta.GenerarAcuerdoServ(nroAcuerdo, sDatosAcuerdoServ, ref sMensaje) != "0")
						{
							throw new Exception(sMensaje);
						}
					}

				}
				foreach (string sDatosAcuerdoEquipo in datosAcuerdoEquipo.Split('|'))
				{
					if (sDatosAcuerdoEquipo != "")
					{
						if (objOficinaVenta.GenerarAcuerdoEquipo(nroAcuerdo, sDatosAcuerdoEquipo, ref sMensaje) != "0")
						{
							throw new Exception(sMensaje);
						}
					}
				}
			}
			else
			{
				throw new Exception(sMensaje);
			}
			return nroAcuerdo;
		}

		public void GrabarGarantia(string cadenaDeposito, ref string nroGarantiaSisact)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			objOficinaVenta.GrabarGarantia(cadenaDeposito, ref nroGarantiaSisact);
		}

		public string RollBackVenta(Int64 idVenta, ref string strMensaje)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.RollBackVenta( idVenta, ref strMensaje);
		}

		public string GrabarInfoVentaSap(Int64 p_id_venta, Int64 p_id_contrato, string p_recibo,
			string p_nro_documento, string p_tipo_documento, double p_monto_documento)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.GrabarInfoVentaSap(p_id_venta, p_id_contrato, p_recibo,
				p_nro_documento, p_tipo_documento, p_monto_documento);
		}

		public Boolean insertaCuotas(Cuota itemCuota)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.insertaCuotas(itemCuota);
		}

		public Boolean GrabarCuotas(Cuota itemCuota)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.GrabarCuotas(itemCuota);
		}

		public static bool ActualizarPlanVenta(Int64 idSolPlan, string telefono, string equipo, double precioEquipo)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ActualizarPlanVenta(idSolPlan, telefono, equipo, precioEquipo);
		}

		//Inicio RNP 16/09/2015
		public string InsertaVtaFidelizacion(string nroDocumento, Int64 idVenta, string nroContrato, Int64 idPedidoMsSap, double montoDescuentoDivididoFidelizacion, string idOficina, string codUsuario)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.InsertaVtaFidelizacion(nroDocumento, idVenta, nroContrato, idPedidoMsSap, montoDescuentoDivididoFidelizacion, idOficina, codUsuario);
		}

		public string ActualizaEstadoFidelizacion(Int64 idVenta, string nroContrato, Int64 idPedidoMsSap, int iEstado)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ActualizaEstadoFidelizacion(idVenta, nroContrato, idPedidoMsSap, iEstado);
		}
		//Fin RNP 16/09/2015
		public void ObtenerMontoMaxMinDescuentoAS(ref double MontoMaxDesASMax, ref double MesesMaxDesASMax, ref double MontoMaxDesAS, ref double MesesMaxDesAS)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			objOficinaVenta.ObtenerMontoMaxMinDescuentoAS(ref MontoMaxDesASMax, ref MesesMaxDesASMax, ref MontoMaxDesAS, ref MesesMaxDesAS);
		}

		//INICIO PLAN NO VIGENTE 28102015
		public void ObtenerPlanNoVigente(string strIdPlanNoVig, ref string strplanIdNoVig_Out, ref string strplanDesNoVig, ref string strIdPlanVig, ref string strplanDesVig, ref  string strCampanasPlan)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			objOficinaVenta.ObtenerPlanNoVigente(strIdPlanNoVig, ref strplanIdNoVig_Out, ref strplanDesNoVig, ref strIdPlanVig, ref strplanDesVig,ref strCampanasPlan);
		}
		//FIN PLAN NO VIGENTE 28102015
public void insertarRepo4G(int co_id, string linea)
		{

            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			objOficinaVenta.insertarRepo4G(co_id, linea);
		}
//INICIO PROMOCION CAMPAÑA 23112015
		public ArrayList ListarGrupoProducto(string strFlujoRenov)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
		return objOficinaVenta.ListarGrupoProducto(strFlujoRenov);
		}

		public string ActualizaComboRenov(string strNroSEC, string strPlanAsoc)
		{
            if (objOficinaVenta == null) { objOficinaVenta = new VentaExpressDatos(); }
			return objOficinaVenta.ActualizaComboRenov(strNroSEC, strPlanAsoc);
		}
		//FIN PROMOCION CAMPAÑA 23112015


		public static string ObtenerFechaEmision(string strCiclo, ref string strFechaEmision, ref string codResp, ref string strMensaje)
		{
			VentaExpressDatos obj = new VentaExpressDatos();
			return obj.ConsultaFechaEmision(strCiclo, ref strFechaEmision, ref codResp, ref strMensaje);
		}


		//Inicio ListarEquivalenciaHLRyUDB - MVC
		public ArrayList ListarEquivalenciaHLRyUDB(int nHLR_1, int nHLR_2)
		{			
			//Retorno Lista Equivalencia
			return objOficinaVenta.ListarEquivalenciaHLRyUDB(nHLR_1,nHLR_2);
		}
		//Fin ListarEquivalenciaHLRyUDB - MVC
		
	}
}
