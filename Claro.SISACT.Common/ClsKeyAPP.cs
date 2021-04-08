using System;
using System.Configuration;
using System.Collections;


namespace Claro.SisAct.Common
{
	/// <summary>
	/// Summary description for ClsKeyAPP.
	/// </summary>
	public class ClsKeyAPP
	{
		private static string _strCanalPM;
		private static string _strClasePedidoPM;
		private static string _strMotivoPedidoPM;
		private static string _strSectorPM;
		private static string _strClaseDocumentoPM;
		private static string _strDescTOperacionPM;
		private static string _strCodTOperacionPM;
		private static string _strSINERGIAEsquemaPM;
		private static string _strDesc_MaterialServProtMovil;
		private static string _strCodMaterial_ServProtMovil;
		private static string _strDescListaPrecioProtMovil;
		private static string _strCodListaPrecio;
		private static string _strEnvioCorreoHtmlFlag;
		private static string _strMensajeProtMovil;
		private static string _strAsuntoProtMovil;
		private static string _strDestinatarioProtMovil;
		private static string _strRemitenteProtMovil;
		private static string _strMsjPMOfrecerSeguro;
		private static string _strMsjSeleccionarEquipo;
		private static string _strMsjEquipoEvaluado;
		private static string _strConfirmEliminarProtMovil;
		private static string _strMontoPrimaMayor;
		private static string _strErrorGrabarProtMovil;
		private static string _strErrorGrabarEvalProtMovil; 
		private static string _strNoCumpleRequisito;
		private static string _strNoCalificaProt;
		private static string _strTClienteB2E;
		private static string _strTClienteBusiness;
		private static string _strTClienteMasivo;
		private static string _strTCodClienteB2E;
		private static string _strTCodClienteBusiness;
		private static string _strTCodClienteMasivo;
		private static string _strCodPrecioPrepagoMinimo;
		private static string _strCodListaPrecioPrepagoMes; 
		private static string _strCanalesPermitidosProtMovil;
		private static string _strFlagEstado;
		private static string _strDesServProteccionMovil;
		private static string _strCodServProteccionMovil;
		public static bool bolParamProteccionMovil;
		public static Int64 intParamGrupo = Convert.ToInt64(ConfigurationSettings.AppSettings["consParametroGrupo"]); //'44444508"


		public static ArrayList ListParametros =null;

		public static string strCodPrecioPrepagoMinimo
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strCodPrecioPrepagoMinimo;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strCodPrecioPrepagoMinimo;
				}
			}
			set { _strCodPrecioPrepagoMinimo = value; }
		}

		public static string strCanalPM
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strCanalPM;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strCanalPM;
				}
			}
			set { _strCanalPM = value; }
		}

		public static string strClasePedidoPM
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strClasePedidoPM;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strClasePedidoPM;
				}
			}
			set { _strClasePedidoPM = value; }
		}

		public static string strMotivoPedidoPM
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strMotivoPedidoPM;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strMotivoPedidoPM;
				}
			}
			set { _strMotivoPedidoPM = value; }
		}

		public static string strSectorPM
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strSectorPM;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strSectorPM;
				}
			}
			set { _strSectorPM = value; }
		}

		public static string strClaseDocumentoPM
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strClaseDocumentoPM;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strClaseDocumentoPM;
				}
			}
			set { _strClaseDocumentoPM = value; }
		}

		public static string strDescTOperacionPM
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strDescTOperacionPM;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strDescTOperacionPM;
				}
			}
			set { _strDescTOperacionPM = value; }
		}


		public static string strCodTOperacionPM
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strCodTOperacionPM;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strCodTOperacionPM;
				}
			}
			set { _strCodTOperacionPM = value; }
		}

		public static string strSINERGIAEsquemaPM
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strSINERGIAEsquemaPM;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strSINERGIAEsquemaPM;
				}
			}
			set { _strSINERGIAEsquemaPM = value; }
		}

		public static string strDesc_MaterialServProtMovil
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strDesc_MaterialServProtMovil;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strDesc_MaterialServProtMovil;
				}
			}
			set { _strDesc_MaterialServProtMovil = value; }
		}

		public static string strCodMaterial_ServProtMovil
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strCodMaterial_ServProtMovil;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strCodMaterial_ServProtMovil;
				}
			}
			set { _strCodMaterial_ServProtMovil = value; }
		}


		public static string strDescListaPrecioProtMovil
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strDescListaPrecioProtMovil;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strDescListaPrecioProtMovil;
				}
			}
			set { _strDescListaPrecioProtMovil = value; }
		}

		public static string strCodListaPrecio
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strCodListaPrecio;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strCodListaPrecio;
				}
			}
			set { _strCodListaPrecio = value; }
		}

		public static string strEnvioCorreoHtmlFlag
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strEnvioCorreoHtmlFlag;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strEnvioCorreoHtmlFlag;
				}
			}
			set { _strEnvioCorreoHtmlFlag = value; }
		}

		public static string strMensajeProtMovil
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strMensajeProtMovil;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strMensajeProtMovil;
				}
			}
			set { _strMensajeProtMovil = value; }
		}

		public static string strAsuntoProtMovil
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strAsuntoProtMovil;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strAsuntoProtMovil;
				}
			}
			set { _strAsuntoProtMovil = value; }
		}

		public static string strDestinatarioProtMovil
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strDestinatarioProtMovil;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strDestinatarioProtMovil;
				}
			}
			set { _strDestinatarioProtMovil = value; }
		}

		public static string strRemitenteProtMovil
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strRemitenteProtMovil;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strRemitenteProtMovil;
				}
			}
			set { _strRemitenteProtMovil = value; }
		}

		public static string strMsjPMOfrecerSeguro
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strMsjPMOfrecerSeguro;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strMsjPMOfrecerSeguro;
				}
			}
			set { _strMsjPMOfrecerSeguro = value; }
		}


		public static string strMsjSeleccionarEquipo 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strMsjSeleccionarEquipo;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strMsjSeleccionarEquipo;
				}
			}
			set { _strMsjSeleccionarEquipo = value; }
		}

		public static string strMsjEquipoEvaluado 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strMsjEquipoEvaluado;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strMsjEquipoEvaluado;
				}
			}
			set { _strMsjEquipoEvaluado = value; }
		}
		
		public static string strConfirmEliminarProtMovil 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strConfirmEliminarProtMovil;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strConfirmEliminarProtMovil;
				}
			}
			set { _strConfirmEliminarProtMovil = value; }
		}

		public static string strMontoPrimaMayor 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strMontoPrimaMayor;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strMontoPrimaMayor;
				}
			}
			set { _strMontoPrimaMayor = value; }
		}

		public static string strErrorGrabarProtMovil 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strErrorGrabarProtMovil;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strErrorGrabarProtMovil;
				}
			}
			set { _strErrorGrabarProtMovil = value; }
		}

		public static string strErrorGrabarEvalProtMovil 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strErrorGrabarEvalProtMovil;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strErrorGrabarEvalProtMovil;
				}
			}
			set { _strErrorGrabarEvalProtMovil = value; }
		}

		public static string strNoCumpleRequisito 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strNoCumpleRequisito;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strNoCumpleRequisito;
				}
			}
			set { _strNoCumpleRequisito = value; }
		}

		public static string strNoCalificaProt 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strNoCalificaProt;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strNoCalificaProt;
				}
			}
			set { _strNoCalificaProt = value; }
		}

		public static string strTClienteB2E 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strTClienteB2E;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strTClienteB2E;
				}
			}
			set { _strTClienteB2E = value; }
		}

		public static string strTClienteBusiness 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strTClienteBusiness;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strTClienteBusiness;
				}
			}
			set { _strTClienteBusiness = value; }
		}

		public static string strTClienteMasivo 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strTClienteMasivo;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strTClienteMasivo;
				}
			}
			set { _strTClienteMasivo = value; }
		}

		public static string strTCodClienteB2E 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strTCodClienteB2E;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strTCodClienteB2E;
				}
			}
			set { _strTCodClienteB2E = value; }
		}

		public static string strTCodClienteBusiness 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strTCodClienteBusiness;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strTCodClienteBusiness;
				}
			}
			set { _strTCodClienteBusiness = value; }
		}

		public static string strTCodClienteMasivo 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strTCodClienteMasivo;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strTCodClienteMasivo;
				}
			}
			set { _strTCodClienteMasivo = value; }
		}

		public static string strCodListaPrecioPrepagoMes 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strCodListaPrecioPrepagoMes;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strCodListaPrecioPrepagoMes;
				}
			}
			set { _strCodListaPrecioPrepagoMes = value; }
		}


		public static string strCanalesPermitidosProtMovil 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strCanalesPermitidosProtMovil;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strCanalesPermitidosProtMovil;
				}
			}
			set { _strCanalesPermitidosProtMovil = value; }
		}

		public static string strFlagEstado 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strFlagEstado;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strFlagEstado;
				}
			}
			set { _strFlagEstado = value; }
		}

		public static string strDesServProteccionMovil 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strDesServProteccionMovil;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strDesServProteccionMovil;
				}
			}
			set { _strDesServProteccionMovil = value; }
		}

		public static string strCodServProteccionMovil 
		{
			get 
			{
				if (bolParamProteccionMovil) 
				{
					return _strCodServProteccionMovil;
				} 
				else 
				{
					ObtenerParametro(intParamGrupo);
					return _strCodServProteccionMovil;
				}
			}
			set { _strCodServProteccionMovil = value; }
		}



		public static void ObtenerParametro(Int64 intCodGrupo)
		{

			bolParamProteccionMovil = false;
			string strCodigo = string.Empty;
			string strValor = string.Empty;

			if ((ListParametros != null)) 
			{
				foreach (string[] item in ListParametros)
				{
					strCodigo = item[1];
					strValor = item[0];

					switch (strCodigo) 
					{
						case "1":
							_strCodServProteccionMovil = strValor;
							// _strCodServProteccionMovil;
							break;
						case "2":
							_strDesServProteccionMovil = strValor;
							break;
						case "3":
							_strFlagEstado = strValor;
							break;
						case "6":
							_strCanalesPermitidosProtMovil = strValor;
							break;
						case "11":
							_strCodListaPrecioPrepagoMes = strValor;
							break;
						case "12":
							_strCodPrecioPrepagoMinimo = strValor;
							break;
						case "13":
							_strTCodClienteMasivo = strValor;
							break;
						case "14":
							_strTCodClienteBusiness = strValor;
							break;
						case "15":
							_strTCodClienteB2E = strValor;
							break;
						case "16":
							_strTClienteMasivo = strValor;
							break;
						case "17":
							_strTClienteBusiness= strValor;
							break;
						case "18":
							_strTClienteB2E = strValor;
							break;
						case "34":
							_strNoCalificaProt = strValor;
							break;
						case "35":
							_strNoCumpleRequisito = strValor;
							break;
						case "38":
							_strErrorGrabarEvalProtMovil = strValor;
							break;
						case "39":
							_strErrorGrabarProtMovil = strValor;
							break;
						case "41":
							_strMontoPrimaMayor = strValor;
							break;
						case "42":
							_strConfirmEliminarProtMovil = strValor;
							break;
						case "43":
							_strMsjEquipoEvaluado = strValor;
							break;
						case "44":
							_strMsjSeleccionarEquipo = strValor;
							break;
						case "45":
							_strMsjPMOfrecerSeguro = strValor;
							break;
						case "52":
							_strRemitenteProtMovil = strValor;
							break;
						case "53":
							_strDestinatarioProtMovil = strValor;
							break;
						case "54":
							_strAsuntoProtMovil = strValor;
							break;
						case "55":
							_strMensajeProtMovil = strValor;
							break;
						case "56":
							_strEnvioCorreoHtmlFlag = strValor;
							break;
						case "57":
							_strCodListaPrecio = strValor;
							break;
						case "58":
							_strDescListaPrecioProtMovil = strValor;
							break;
						case "59":
							_strCodMaterial_ServProtMovil = strValor;
							break;
						case "60":
							_strDesc_MaterialServProtMovil = strValor;
							break;
						case "61":
							_strSINERGIAEsquemaPM = strValor;
							break;
						case "62":
							_strCodTOperacionPM = strValor;
							break;
						case "63":
							_strDescTOperacionPM = strValor;
							break;
						case "64":
							_strClaseDocumentoPM = strValor;
							break;
						case "65":
							_strSectorPM = strValor;
							break;
						case "66":
							_strMotivoPedidoPM = strValor;
							break;
						case "67":
							_strClasePedidoPM = strValor;
							break;
						case "68":
							_strCanalPM = strValor;
							break;
					}
				}
				bolParamProteccionMovil = true;
			}
		}
	}
}
