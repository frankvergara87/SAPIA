using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Descripción breve de PlantillaDatos.
	/// </summary>
	public class PlantillaDatos
	{
		public PlantillaDatos()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public bool InsertarPlantillaInteraccion(PlantillaInteraccion item,string vInteraccionId, ref string rFlagInsercion ,ref string rMsgText)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_NRO_INTERACCION",DbType.String,255,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_1",DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_2",DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_3",DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_4",DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_5",DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_6",DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_7",DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_8",DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_9",DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_10",DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_11",DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_12",DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_13",DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_14",DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_15",DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_16",DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_17",DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_18",DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_19",DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_20",DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_21",DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_22",DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_23",DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_24",DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_25",DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_26",DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_27",DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_28",DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_29",DbType.String,255,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_30",DbType.String,1000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLUS_INTER2INTERACT",DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ADJUSTMENT_AMOUNT",DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ADJUSTMENT_REASON",DbType.String,	20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ADDRESS",DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_AMOUNT_UNIT",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_BIRTHDAY",DbType.Date,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLARIFY_INTERACTION",DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLARO_LDN1",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLARO_LDN2",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLARO_LDN3",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLARO_LDN4",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLAROLOCAL1",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLAROLOCAL2",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLAROLOCAL3",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLAROLOCAL4",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLAROLOCAL5",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLAROLOCAL6",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONTACT_PHONE",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DNI_LEGAL_REP",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCUMENT_NUMBER",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EMAIL",DbType.String,30,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FIRST_NAME",DbType.String,30,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FIXED_NUMBER",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_CHANGE_USER",DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_LEGAL_REP",DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_OTHER",DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_TITULAR",DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IMEI",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LAST_NAME",DbType.String,30,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LASTNAME_REP",DbType.String,30,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LDI_NUMBER",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NAME_LEGAL_REP",DbType.String,30,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OLD_CLARO_LDN1",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OLD_CLARO_LDN2",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OLD_CLARO_LDN3",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OLD_CLARO_LDN4",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OLD_CLAROLOCAL1",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OLD_CLAROLOCAL2",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OLD_CLAROLOCAL3",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OLD_CLAROLOCAL4",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OLD_CLAROLOCAL5",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OLD_CLAROLOCAL6",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OLD_DOC_NUMBER",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OLD_FIRST_NAME",DbType.String,30,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OLD_FIXED_PHONE",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OLD_LAST_NAME",DbType.String,30,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OLD_LDI_NUMBER",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OLD_FIXED_NUMBER",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OPERATION_TYPE",DbType.String,50,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OTHER_DOC_NUMBER",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OTHER_FIRST_NAME",DbType.String,30,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OTHER_LAST_NAME",DbType.String,30,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OTHER_PHONE",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PHONE_LEGAL_REP",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REFERENCE_PHONE",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REASON",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MODEL",DbType.String,50,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LOT_CODE",DbType.String,50,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_REGISTERED",DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REGISTRATION_REASON",DbType.String,80,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLARO_NUMBER",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MONTH",DbType.String,30,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OST_NUMBER",DbType.String,30,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_BASKET",DbType.String,50,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EXPIRE_DATE",DbType.Date,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ADDRESS5",DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CHARGE_AMOUNT",DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CITY",DbType.String,30,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONTACT_SEX",DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DEPARTMENT",DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DISTRICT",DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EMAIL_CONFIRMATION",DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FAX",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_CHARGE",DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MARITAL_STATUS",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OCCUPATION",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_POSITION",DbType.String,30,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REFERENCE_ADDRESS",DbType.String,50,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TYPE_DOCUMENT",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ZIPCODE",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ICCID",DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("ID_INTERACCION",DbType.String,255,ParameterDirection.Output),
												   new DAABRequest.Parameter("FLAG_CREACION",DbType.String,255,ParameterDirection.Output),
												   new DAABRequest.Parameter("MSG_TEXT",DbType.String,255,ParameterDirection.Output)												  
											   };
			for(int j=0;j<arrParam.Length;j++)
				arrParam[j].Value = System.DBNull.Value;

			int i=0;
			DateTime dateInicio = new DateTime(1,1,1);
		

			if ( vInteraccionId != null )
			{
				arrParam[i].Value = vInteraccionId;// P_NRO_INTERACCION 
				item.X_PLUS_INTER2INTERACT = Funciones.CheckDbl(vInteraccionId);
			}

			i++;
			if ( item.X_INTER_1 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_INTER_1);// P_INTER_1 

			i++;
			if ( item.X_INTER_2 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_INTER_2);// P_INTER_2 

			i++;
			if ( item.X_INTER_3 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_INTER_3);// P_INTER_3 

			i++;
			if ( item.X_INTER_4 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_INTER_4);// P_INTER_4 

			i++;
			if ( item.X_INTER_5 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_INTER_5);// P_INTER_5 

			i++;
			if ( item.X_INTER_6 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_INTER_6);// P_INTER_6 

			i++;
			if ( item.X_INTER_7 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_INTER_7);// P_INTER_7 

			i++;
			//if ( item.X_INTER_8 != null )
			arrParam[i].Value = Funciones.CheckDbl(item.X_INTER_8);// P_INTER_8 

			i++;
			//if ( item.X_INTER_9 != null )
			arrParam[i].Value = Funciones.CheckDbl(item.X_INTER_9);// P_INTER_9 

			i++;
			//if ( item.X_INTER_10 != null )
			arrParam[i].Value = Funciones.CheckDbl(item.X_INTER_10);// P_INTER_10 

			i++;
			//if ( item.X_INTER_11 != null )
			arrParam[i].Value = Funciones.CheckDbl(item.X_INTER_11);// P_INTER_11 

			i++;
			//if ( item.X_INTER_12 != null )
			arrParam[i].Value = Funciones.CheckDbl(item.X_INTER_12);// P_INTER_12 

			i++;
			//if ( item.X_INTER_13 != null )
			arrParam[i].Value = Funciones.CheckDbl(item.X_INTER_13);// P_INTER_13 

			i++;
			//if ( item.X_INTER_14 != null )
			arrParam[i].Value = Funciones.CheckDbl(item.X_INTER_14);// P_INTER_14 

			i++;
			if ( item.X_INTER_15 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_INTER_15);// P_INTER_15 

			i++;
			if ( item.X_INTER_16 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_INTER_16);// P_INTER_16 

			i++;
			if ( item.X_INTER_17 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_INTER_17);// P_INTER_17 

			i++;
			if ( item.X_INTER_18 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_INTER_18);// P_INTER_18 

			i++;
			if ( item.X_INTER_19 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_INTER_19);// P_INTER_19 

			i++;
			if ( item.X_INTER_20 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_INTER_20);// P_INTER_20 

			i++;
			if ( item.X_INTER_21 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_INTER_21);// P_INTER_21 

			i++;
			//if ( item.X_INTER_22 != null )
			arrParam[i].Value = Funciones.CheckDbl(item.X_INTER_22);// P_INTER_22 

			i++;
			//if ( item.X_INTER_23 != null )
			arrParam[i].Value = Funciones.CheckDbl(item.X_INTER_23);// P_INTER_23 

			i++;
			//if ( item.X_INTER_24 != null )
			arrParam[i].Value = Funciones.CheckDbl(item.X_INTER_24);// P_INTER_24 

			i++;
			//if ( item.X_INTER_25 != null )
			arrParam[i].Value = Funciones.CheckDbl(item.X_INTER_25);// P_INTER_25 

			i++;
			//if ( item.X_INTER_26 != null )
			arrParam[i].Value = Funciones.CheckDbl(item.X_INTER_26);// P_INTER_26 

			i++;
			//if ( item.X_INTER_27 != null )
			arrParam[i].Value = Funciones.CheckDbl(item.X_INTER_27);// P_INTER_27 

			i++;
			//if ( item.X_INTER_28 != null )
			arrParam[i].Value = Funciones.CheckDbl(item.X_INTER_28);// P_INTER_28 

			i++;
			if ( item.X_INTER_29 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_INTER_29);// P_INTER_29 

			i++;
			if ( item.X_INTER_30 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_INTER_30);// P_INTER_30 

			i++;
			//if ( item.X_PLUS_INTER2INTERACT != null )
			arrParam[i].Value = Funciones.CheckDbl(item.X_PLUS_INTER2INTERACT);// P_PLUS_INTER2INTERACT 

			i++;
			//if ( item.X_ADJUSTMENT_AMOUNT != null )
			arrParam[i].Value = Funciones.CheckDbl(item.X_ADJUSTMENT_AMOUNT);// P_ADJUSTMENT_AMOUNT 

			i++;
			if ( item.X_ADJUSTMENT_REASON != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_ADJUSTMENT_REASON);// P_ADJUSTMENT_REASON 

			i++;
			if ( item.X_ADDRESS != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_ADDRESS);// P_ADDRESS

			i++;
			if ( item.X_AMOUNT_UNIT != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_AMOUNT_UNIT);// P_AMOUNT_UNIT 

			i++;
			if ( item.X_BIRTHDAY != dateInicio )
				arrParam[i].Value = Funciones.CheckDate(item.X_BIRTHDAY);// P_BIRTHDAY 

			i++;
			if ( item.X_CLARIFY_INTERACTION != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_CLARIFY_INTERACTION);// P_CLARIFY_INTERACTION 

			i++;
			if ( item.X_CLARO_LDN1 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_CLARO_LDN1);// P_CLARO_LDN1 

			i++;
			if ( item.X_CLARO_LDN2 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_CLARO_LDN2);// P_CLARO_LDN2 

			i++;
			if ( item.X_CLARO_LDN3 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_CLARO_LDN3);// P_CLARO_LDN3 

			i++;
			if ( item.X_CLARO_LDN4 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_CLARO_LDN4);// P_CLARO_LDN4 

			i++;
			if ( item.X_CLAROLOCAL1 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_CLAROLOCAL1);// P_CLAROLOCAL1 

			i++;
			if ( item.X_CLAROLOCAL2 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_CLAROLOCAL2);// P_CLAROLOCAL2 

			i++;
			if ( item.X_CLAROLOCAL3 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_CLAROLOCAL3);// P_CLAROLOCAL3 

			i++;
			if ( item.X_CLAROLOCAL4 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_CLAROLOCAL4);// P_CLAROLOCAL4 

			i++;
			if ( item.X_CLAROLOCAL5 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_CLAROLOCAL5);// P_CLAROLOCAL5 

			i++;
			if ( item.X_CLAROLOCAL6 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_CLAROLOCAL6);// P_CLAROLOCAL6 

			i++;
			if ( item.X_CONTACT_PHONE != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_CONTACT_PHONE);// P_CONTACT_PHONE 

			i++;
			if ( item.X_DNI_LEGAL_REP != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_DNI_LEGAL_REP);// P_DNI_LEGAL_REP 

			i++;
			if ( item.X_DOCUMENT_NUMBER != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_DOCUMENT_NUMBER);// P_DOCUMENT_NUMBER 

			i++;
			if ( item.X_EMAIL != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_EMAIL);// P_EMAIL 

			i++;
			if ( item.X_FIRST_NAME != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_FIRST_NAME);// P_FIRST_NAME 

			i++;
			if ( item.X_FIXED_NUMBER != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_FIXED_NUMBER);// P_FIXED_NUMBER 

			i++;
			if ( item.X_FLAG_CHANGE_USER != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_FLAG_CHANGE_USER);// P_FLAG_CHANGE_USER 

			i++;
			if ( item.X_FLAG_LEGAL_REP != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_FLAG_LEGAL_REP);// P_FLAG_LEGAL_REP 

			i++;
			if ( item.X_FLAG_OTHER != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_FLAG_OTHER);// P_FLAG_OTHER 

			i++;
			if ( item.X_FLAG_TITULAR != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_FLAG_TITULAR);// P_FLAG_TITULAR 

			i++;
			if ( item.X_IMEI != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_IMEI);// P_IMEI 

			i++;
			if ( item.X_LAST_NAME != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_LAST_NAME);// P_LAST_NAME 

			i++;
			if ( item.X_LASTNAME_REP != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_LASTNAME_REP);// P_LASTNAME_REP 

			i++;
			if ( item.X_LDI_NUMBER != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_LDI_NUMBER);// P_LDI_NUMBER 

			i++;
			if ( item.X_NAME_LEGAL_REP != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_NAME_LEGAL_REP);// P_NAME_LEGAL_REP 

			i++;
			if ( item.X_OLD_CLARO_LDN1 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OLD_CLARO_LDN1);// P_OLD_CLARO_LDN1 

			i++;
			if ( item.X_OLD_CLARO_LDN2 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OLD_CLARO_LDN2);// P_OLD_CLARO_LDN2 

			i++;
			if ( item.X_OLD_CLARO_LDN3 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OLD_CLARO_LDN3);// P_OLD_CLARO_LDN3 

			i++;
			if ( item.X_OLD_CLARO_LDN4 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OLD_CLARO_LDN4);// P_OLD_CLARO_LDN4 

			i++;
			if ( item.X_OLD_CLAROLOCAL1 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OLD_CLAROLOCAL1);// P_OLD_CLAROLOCAL1 

			i++;
			if ( item.X_OLD_CLAROLOCAL2 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OLD_CLAROLOCAL2);// P_OLD_CLAROLOCAL2 

			i++;
			if ( item.X_OLD_CLAROLOCAL3 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OLD_CLAROLOCAL3);// P_OLD_CLAROLOCAL3 

			i++;
			if ( item.X_OLD_CLAROLOCAL4 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OLD_CLAROLOCAL4);// P_OLD_CLAROLOCAL4 

			i++;
			if ( item.X_OLD_CLAROLOCAL5 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OLD_CLAROLOCAL5);// P_OLD_CLAROLOCAL5 

			i++;
			if ( item.X_OLD_CLAROLOCAL6 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OLD_CLAROLOCAL6);// P_OLD_CLAROLOCAL6 

			i++;
			if ( item.X_OLD_DOC_NUMBER != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OLD_DOC_NUMBER);// P_OLD_DOC_NUMBER 

			i++;
			if ( item.X_OLD_FIRST_NAME != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OLD_FIRST_NAME);// P_OLD_FIRST_NAME 

			i++;
			if ( item.X_OLD_FIXED_PHONE != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OLD_FIXED_PHONE);// P_OLD_FIXED_PHONE 

			i++;
			if ( item.X_OLD_LAST_NAME != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OLD_LAST_NAME);// P_OLD_LAST_NAME 

			i++;
			if ( item.X_OLD_LDI_NUMBER != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OLD_LDI_NUMBER);// P_OLD_LDI_NUMBER 

			i++;
			if ( item.X_OLD_FIXED_NUMBER != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OLD_FIXED_NUMBER);// P_OLD_FIXED_NUMBER 

			i++;
			if ( item.X_OPERATION_TYPE != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OPERATION_TYPE);// P_OPERATION_TYPE 

			i++;
			if ( item.X_OTHER_DOC_NUMBER != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OTHER_DOC_NUMBER);// P_OTHER_DOC_NUMBER 

			i++;
			if ( item.X_OTHER_FIRST_NAME != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OTHER_FIRST_NAME);// P_OTHER_FIRST_NAME 

			i++;
			if ( item.X_OTHER_LAST_NAME != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OTHER_LAST_NAME);// P_OTHER_LAST_NAME 

			i++;
			if ( item.X_OTHER_PHONE != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OTHER_PHONE);// P_OTHER_PHONE 

			i++;
			if ( item.X_PHONE_LEGAL_REP != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_PHONE_LEGAL_REP);// P_PHONE_LEGAL_REP 

			i++;
			if ( item.X_REFERENCE_PHONE != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_REFERENCE_PHONE);// P_REFERENCE_PHONE 

			i++;
			if ( item.X_REASON != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_REASON);// P_REASON 

			i++;
			if ( item.X_MODEL != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_MODEL);// P_MODEL 

			i++;
			if ( item.X_LOT_CODE != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_LOT_CODE);// P_LOT_CODE 

			i++;
			if ( item.X_FLAG_REGISTERED != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_FLAG_REGISTERED);// P_FLAG_REGISTERED 

			i++;
			if ( item.X_REGISTRATION_REASON != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_REGISTRATION_REASON);// P_REGISTRATION_REASON 

			i++;
			if ( item.X_CLARO_NUMBER != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_CLARO_NUMBER);// P_CLARO_NUMBER 

			i++;
			if ( item.X_MONTH != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_MONTH);// P_MONTH 

			i++;
			if ( item.X_OST_NUMBER != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OST_NUMBER);// P_OST_NUMBER 

			i++;
			if ( item.X_BASKET != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_BASKET);// P_BASKET

			i++;
			if ( item.X_EXPIRE_DATE != dateInicio )
				arrParam[i].Value = Funciones.CheckStr(item.X_EXPIRE_DATE);// P_EXPIRE_DATE

			i++;
			if ( item.X_ADDRESS5 != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_ADDRESS5);// P_ADDRESS5
			i++;
			arrParam[i].Value = Funciones.CheckDbl(item.X_CHARGE_AMOUNT);// P_CHARGE_AMOUNT
			i++;
			if ( item.X_CITY != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_CITY);// P_CITY
			i++;
			if ( item.X_CONTACT_SEX != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_CONTACT_SEX);// P_CONTACT_SEX
			i++;
			if ( item.X_DEPARTMENT != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_DEPARTMENT);// P_DEPARTMENT
			i++;
			if ( item.X_DISTRICT != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_DISTRICT);// P_DISTRICT
			i++;
			if ( item.X_EMAIL_CONFIRMATION != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_EMAIL_CONFIRMATION);// P_EMAIL_CONFIRMATION
			i++;
			if ( item.X_FAX != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_FAX);// P_FAX
			i++;
			if ( item.X_FLAG_CHARGE != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_FLAG_CHARGE);// P_FLAG_CHARGE
			i++;
			if ( item.X_MARITAL_STATUS != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_MARITAL_STATUS);// P_MARITAL_STATUS
			i++;
			if ( item.X_OCCUPATION != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_OCCUPATION);// P_OCCUPATION
			i++;
			if ( item.X_POSITION != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_POSITION);// P_POSITION
			i++;
			if ( item.X_REFERENCE_ADDRESS != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_REFERENCE_ADDRESS);// P_REFERENCE_ADDRESS
			i++;
			if ( item.X_TYPE_DOCUMENT != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_TYPE_DOCUMENT);// P_TYPE_DOCUMENT
			i++;
			if ( item.X_ZIPCODE != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_ZIPCODE);// P_ZIPCODE

			i++;
			if ( item.X_ICCID != null )
				arrParam[i].Value = Funciones.CheckStr(item.X_ICCID);// P_ICCID
			

			Clarify objClarify = new Clarify(BaseDatos.BD_CLARIFY);

			DAABRequest obRequest = objClarify.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;			
			obRequest.Command = BaseDatos.NOMBRE_PACKAGE_INTERCCION_CLFY + ".SP_CREATE_PLUS_INTER"; 
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				//log.Info(String.Format("Base de Datos : Correcto"));
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				//log.Info(String.Format("Error Base de Datos : {0}", ex.ToString()));
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1 ,parSalida2;
				parSalida1 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-2];
				parSalida2 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-1];
				rFlagInsercion = Funciones.CheckStr(parSalida1.Value);
				rMsgText = Funciones.CheckStr(parSalida2.Value);
				if (rMsgText == "")
					rMsgText = "No hay Errores";
				//log.Info(String.Format("Recibe Datos de Salida"));
				//log.Info(string.Format("Interaccion Id : {0}, Flag Insercion : {1}, Mensaje : {2}",vInteraccionId, rFlagInsercion, rMsgText));
				//log.Info(String.Format("Termina Operaciones Insertar Plantilla Interaccion"));
				//obRequest.Factory.Dispose();
			}			
			return true;		
		}

		
	}
}
