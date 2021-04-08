
//------------------------------------------------------------------------------
// 
//     This code was generated by a SAP. NET Connector Proxy Generator Version 1.0
//     Created at 25/08/2011
//     Created from Windows 2000
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// 
//------------------------------------------------------------------------------
using System;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using SAP.Connector;

namespace Claro.SisAct.SapGeneral
{

  [RfcStructure(AbapName ="ZST_PV_CONSULTA_CONTRATO" , Length = 1294)]
  public class ZST_PV_CONSULTA_CONTRATO : SAPStructure
  {
    
    [RfcField(AbapName = "OFICINA_VENTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 0)]
    [XmlElement("OFICINA_VENTA")]
    public string Oficina_Venta
    { 
       get
       {
          return _Oficina_Venta;
       }
       set
       {
          _Oficina_Venta = value;
       }
    }
    private string _Oficina_Venta;

    [RfcField(AbapName = "DES_OF_VENTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 20, Offset = 4)]
    [XmlElement("DES_OF_VENTA")]
    public string Des_Of_Venta
    { 
       get
       {
          return _Des_Of_Venta;
       }
       set
       {
          _Des_Of_Venta = value;
       }
    }
    private string _Des_Of_Venta;

    [RfcField(AbapName = "NUMERO_CONTRATO", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 10, Offset = 24)]
    [XmlElement("NUMERO_CONTRATO")]
    public string Numero_Contrato
    { 
       get
       {
          return _Numero_Contrato;
       }
       set
       {
          _Numero_Contrato = value;
       }
    }
    private string _Numero_Contrato;

    [RfcField(AbapName = "NUMERO_PCS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 30, Offset = 34)]
    [XmlElement("NUMERO_PCS")]
    public string Numero_Pcs
    { 
       get
       {
          return _Numero_Pcs;
       }
       set
       {
          _Numero_Pcs = value;
       }
    }
    private string _Numero_Pcs;

    [RfcField(AbapName = "FECHA_CONTRATO", RfcType = RFCTYPE.RFCTYPE_DATE, Length = 8, Offset = 64)]
    [XmlElement("FECHA_CONTRATO")]
    public string Fecha_Contrato
    { 
       get
       {
          return _Fecha_Contrato;
       }
       set
       {
          _Fecha_Contrato = value;
       }
    }
    private string _Fecha_Contrato;

    [RfcField(AbapName = "ESTADO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 72)]
    [XmlElement("ESTADO")]
    public string Estado
    { 
       get
       {
          return _Estado;
       }
       set
       {
          _Estado = value;
       }
    }
    private string _Estado;

    [RfcField(AbapName = "DES_ESTADO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 20, Offset = 73)]
    [XmlElement("DES_ESTADO")]
    public string Des_Estado
    { 
       get
       {
          return _Des_Estado;
       }
       set
       {
          _Des_Estado = value;
       }
    }
    private string _Des_Estado;

    [RfcField(AbapName = "CLIENTE", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 16, Offset = 93)]
    [XmlElement("CLIENTE")]
    public string Cliente
    { 
       get
       {
          return _Cliente;
       }
       set
       {
          _Cliente = value;
       }
    }
    private string _Cliente;

    [RfcField(AbapName = "NOMBRE_CLIENTE", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Offset = 109)]
    [XmlElement("NOMBRE_CLIENTE")]
    public string Nombre_Cliente
    { 
       get
       {
          return _Nombre_Cliente;
       }
       set
       {
          _Nombre_Cliente = value;
       }
    }
    private string _Nombre_Cliente;

    [RfcField(AbapName = "VENDEDOR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Offset = 149)]
    [XmlElement("VENDEDOR")]
    public string Vendedor
    { 
       get
       {
          return _Vendedor;
       }
       set
       {
          _Vendedor = value;
       }
    }
    private string _Vendedor;

    [RfcField(AbapName = "NOM_VENDEDOR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Offset = 159)]
    [XmlElement("NOM_VENDEDOR")]
    public string Nom_Vendedor
    { 
       get
       {
          return _Nom_Vendedor;
       }
       set
       {
          _Nom_Vendedor = value;
       }
    }
    private string _Nom_Vendedor;

    [RfcField(AbapName = "TEL_VENDEDOR", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 15, Offset = 199)]
    [XmlElement("TEL_VENDEDOR")]
    public string Tel_Vendedor
    { 
       get
       {
          return _Tel_Vendedor;
       }
       set
       {
          _Tel_Vendedor = value;
       }
    }
    private string _Tel_Vendedor;

    [RfcField(AbapName = "CAMPANA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 214)]
    [XmlElement("CAMPANA")]
    public string Campana
    { 
       get
       {
          return _Campana;
       }
       set
       {
          _Campana = value;
       }
    }
    private string _Campana;

    [RfcField(AbapName = "DES_CAMPANA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Offset = 218)]
    [XmlElement("DES_CAMPANA")]
    public string Des_Campana
    { 
       get
       {
          return _Des_Campana;
       }
       set
       {
          _Des_Campana = value;
       }
    }
    private string _Des_Campana;

    [RfcField(AbapName = "PLAZO_ACUERDO", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 2, Offset = 258)]
    [XmlElement("PLAZO_ACUERDO")]
    public string Plazo_Acuerdo
    { 
       get
       {
          return _Plazo_Acuerdo;
       }
       set
       {
          _Plazo_Acuerdo = value;
       }
    }
    private string _Plazo_Acuerdo;

    [RfcField(AbapName = "MIGRACION", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 260)]
    [XmlElement("MIGRACION")]
    public string Migracion
    { 
       get
       {
          return _Migracion;
       }
       set
       {
          _Migracion = value;
       }
    }
    private string _Migracion;

    [RfcField(AbapName = "DEBITO_AUTOMATI", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 261)]
    [XmlElement("DEBITO_AUTOMATI")]
    public string Debito_Automati
    { 
       get
       {
          return _Debito_Automati;
       }
       set
       {
          _Debito_Automati = value;
       }
    }
    private string _Debito_Automati;

    [RfcField(AbapName = "TARJETA_CREDITO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 262)]
    [XmlElement("TARJETA_CREDITO")]
    public string Tarjeta_Credito
    { 
       get
       {
          return _Tarjeta_Credito;
       }
       set
       {
          _Tarjeta_Credito = value;
       }
    }
    private string _Tarjeta_Credito;

    [RfcField(AbapName = "NUM_TARJ_CREDITO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 20, Offset = 266)]
    [XmlElement("NUM_TARJ_CREDITO")]
    public string Num_Tarj_Credito
    { 
       get
       {
          return _Num_Tarj_Credito;
       }
       set
       {
          _Num_Tarj_Credito = value;
       }
    }
    private string _Num_Tarj_Credito;

    [RfcField(AbapName = "MONEDA_TCRED", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 286)]
    [XmlElement("MONEDA_TCRED")]
    public string Moneda_Tcred
    { 
       get
       {
          return _Moneda_Tcred;
       }
       set
       {
          _Moneda_Tcred = value;
       }
    }
    private string _Moneda_Tcred;

    [RfcField(AbapName = "LINEA_CREDITO", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 8, Decimals = 2, Offset = 287)]
    [XmlElement("LINEA_CREDITO")]
    public Decimal Linea_Credito
    { 
       get
       {
          return _Linea_Credito;
       }
       set
       {
          _Linea_Credito = value;
       }
    }
    private Decimal _Linea_Credito;

    [RfcField(AbapName = "FECHA_VENC_TCRED", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 8, Offset = 295)]
    [XmlElement("FECHA_VENC_TCRED")]
    public string Fecha_Venc_Tcred
    { 
       get
       {
          return _Fecha_Venc_Tcred;
       }
       set
       {
          _Fecha_Venc_Tcred = value;
       }
    }
    private string _Fecha_Venc_Tcred;

    [RfcField(AbapName = "ANALISTA_CREDITO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 303)]
    [XmlElement("ANALISTA_CREDITO")]
    public string Analista_Credito
    { 
       get
       {
          return _Analista_Credito;
       }
       set
       {
          _Analista_Credito = value;
       }
    }
    private string _Analista_Credito;

    [RfcField(AbapName = "NOM_ANALISTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Offset = 307)]
    [XmlElement("NOM_ANALISTA")]
    public string Nom_Analista
    { 
       get
       {
          return _Nom_Analista;
       }
       set
       {
          _Nom_Analista = value;
       }
    }
    private string _Nom_Analista;

    [RfcField(AbapName = "TIPO_DOCUMENTO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 347)]
    [XmlElement("TIPO_DOCUMENTO")]
    public string Tipo_Documento
    { 
       get
       {
          return _Tipo_Documento;
       }
       set
       {
          _Tipo_Documento = value;
       }
    }
    private string _Tipo_Documento;

    [RfcField(AbapName = "DOCUMENTO", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 10, Offset = 351)]
    [XmlElement("DOCUMENTO")]
    public string Documento
    { 
       get
       {
          return _Documento;
       }
       set
       {
          _Documento = value;
       }
    }
    private string _Documento;

    [RfcField(AbapName = "COD_OBSERVACION", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 3, Offset = 361)]
    [XmlElement("COD_OBSERVACION")]
    public string Cod_Observacion
    { 
       get
       {
          return _Cod_Observacion;
       }
       set
       {
          _Cod_Observacion = value;
       }
    }
    private string _Cod_Observacion;

    [RfcField(AbapName = "DES_OBSERVACION", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 30, Offset = 364)]
    [XmlElement("DES_OBSERVACION")]
    public string Des_Observacion
    { 
       get
       {
          return _Des_Observacion;
       }
       set
       {
          _Des_Observacion = value;
       }
    }
    private string _Des_Observacion;

    [RfcField(AbapName = "OBSERVACIONES", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 200, Offset = 394)]
    [XmlElement("OBSERVACIONES")]
    public string Observaciones
    { 
       get
       {
          return _Observaciones;
       }
       set
       {
          _Observaciones = value;
       }
    }
    private string _Observaciones;

    [RfcField(AbapName = "NRO_APROBACION", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 20, Offset = 594)]
    [XmlElement("NRO_APROBACION")]
    public string Nro_Aprobacion
    { 
       get
       {
          return _Nro_Aprobacion;
       }
       set
       {
          _Nro_Aprobacion = value;
       }
    }
    private string _Nro_Aprobacion;

    [RfcField(AbapName = "TIPO_RECHAZO", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 3, Offset = 614)]
    [XmlElement("TIPO_RECHAZO")]
    public string Tipo_Rechazo
    { 
       get
       {
          return _Tipo_Rechazo;
       }
       set
       {
          _Tipo_Rechazo = value;
       }
    }
    private string _Tipo_Rechazo;

    [RfcField(AbapName = "DES_TIPO_RECHAZO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 30, Offset = 617)]
    [XmlElement("DES_TIPO_RECHAZO")]
    public string Des_Tipo_Rechazo
    { 
       get
       {
          return _Des_Tipo_Rechazo;
       }
       set
       {
          _Des_Tipo_Rechazo = value;
       }
    }
    private string _Des_Tipo_Rechazo;

    [RfcField(AbapName = "TIPO_DOC_CLIENTE", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 2, Offset = 647)]
    [XmlElement("TIPO_DOC_CLIENTE")]
    public string Tipo_Doc_Cliente
    { 
       get
       {
          return _Tipo_Doc_Cliente;
       }
       set
       {
          _Tipo_Doc_Cliente = value;
       }
    }
    private string _Tipo_Doc_Cliente;

    [RfcField(AbapName = "VIA_DSF", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 649)]
    [XmlElement("VIA_DSF")]
    public string Via_Dsf
    { 
       get
       {
          return _Via_Dsf;
       }
       set
       {
          _Via_Dsf = value;
       }
    }
    private string _Via_Dsf;

    [RfcField(AbapName = "RESULTADO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Offset = 650)]
    [XmlElement("RESULTADO")]
    public string Resultado
    { 
       get
       {
          return _Resultado;
       }
       set
       {
          _Resultado = value;
       }
    }
    private string _Resultado;

    [RfcField(AbapName = "TELEF_RENOV", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 15, Offset = 690)]
    [XmlElement("TELEF_RENOV")]
    public string Telef_Renov
    { 
       get
       {
          return _Telef_Renov;
       }
       set
       {
          _Telef_Renov = value;
       }
    }
    private string _Telef_Renov;

    [RfcField(AbapName = "COD_BSCS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 25, Offset = 705)]
    [XmlElement("COD_BSCS")]
    public string Cod_Bscs
    { 
       get
       {
          return _Cod_Bscs;
       }
       set
       {
          _Cod_Bscs = value;
       }
    }
    private string _Cod_Bscs;

    [RfcField(AbapName = "PLAN_RENOV", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 3, Offset = 730)]
    [XmlElement("PLAN_RENOV")]
    public string Plan_Renov
    { 
       get
       {
          return _Plan_Renov;
       }
       set
       {
          _Plan_Renov = value;
       }
    }
    private string _Plan_Renov;

    [RfcField(AbapName = "CODIGO_BANCO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 15, Offset = 733)]
    [XmlElement("CODIGO_BANCO")]
    public string Codigo_Banco
    { 
       get
       {
          return _Codigo_Banco;
       }
       set
       {
          _Codigo_Banco = value;
       }
    }
    private string _Codigo_Banco;

    [RfcField(AbapName = "DENOM_BANCO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 60, Offset = 748)]
    [XmlElement("DENOM_BANCO")]
    public string Denom_Banco
    { 
       get
       {
          return _Denom_Banco;
       }
       set
       {
          _Denom_Banco = value;
       }
    }
    private string _Denom_Banco;

    [RfcField(AbapName = "RENOVACION", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 808)]
    [XmlElement("RENOVACION")]
    public string Renovacion
    { 
       get
       {
          return _Renovacion;
       }
       set
       {
          _Renovacion = value;
       }
    }
    private string _Renovacion;

    [RfcField(AbapName = "NRO_CLARIFY", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 10, Offset = 809)]
    [XmlElement("NRO_CLARIFY")]
    public string Nro_Clarify
    { 
       get
       {
          return _Nro_Clarify;
       }
       set
       {
          _Nro_Clarify = value;
       }
    }
    private string _Nro_Clarify;

    [RfcField(AbapName = "NUMERO_HDC", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 10, Offset = 819)]
    [XmlElement("NUMERO_HDC")]
    public string Numero_Hdc
    { 
       get
       {
          return _Numero_Hdc;
       }
       set
       {
          _Numero_Hdc = value;
       }
    }
    private string _Numero_Hdc;

    [RfcField(AbapName = "INDICADOR_ALQ", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 829)]
    [XmlElement("INDICADOR_ALQ")]
    public string Indicador_Alq
    { 
       get
       {
          return _Indicador_Alq;
       }
       set
       {
          _Indicador_Alq = value;
       }
    }
    private string _Indicador_Alq;

    [RfcField(AbapName = "REPOSICION", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 830)]
    [XmlElement("REPOSICION")]
    public string Reposicion
    { 
       get
       {
          return _Reposicion;
       }
       set
       {
          _Reposicion = value;
       }
    }
    private string _Reposicion;

    [RfcField(AbapName = "APROBADOR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 3, Offset = 831)]
    [XmlElement("APROBADOR")]
    public string Aprobador
    { 
       get
       {
          return _Aprobador;
       }
       set
       {
          _Aprobador = value;
       }
    }
    private string _Aprobador;

    [RfcField(AbapName = "LIM_CREDITO", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 8, Decimals = 2, Offset = 834)]
    [XmlElement("LIM_CREDITO")]
    public Decimal Lim_Credito
    { 
       get
       {
          return _Lim_Credito;
       }
       set
       {
          _Lim_Credito = value;
       }
    }
    private Decimal _Lim_Credito;

    [RfcField(AbapName = "EVAL_CRED_MANUAL", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 842)]
    [XmlElement("EVAL_CRED_MANUAL")]
    public string Eval_Cred_Manual
    { 
       get
       {
          return _Eval_Cred_Manual;
       }
       set
       {
          _Eval_Cred_Manual = value;
       }
    }
    private string _Eval_Cred_Manual;

    [RfcField(AbapName = "SCORE_CREDITICIO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 2, Offset = 843)]
    [XmlElement("SCORE_CREDITICIO")]
    public string Score_Crediticio
    { 
       get
       {
          return _Score_Crediticio;
       }
       set
       {
          _Score_Crediticio = value;
       }
    }
    private string _Score_Crediticio;

    [RfcField(AbapName = "CONTROL_FRAUDE", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 845)]
    [XmlElement("CONTROL_FRAUDE")]
    public string Control_Fraude
    { 
       get
       {
          return _Control_Fraude;
       }
       set
       {
          _Control_Fraude = value;
       }
    }
    private string _Control_Fraude;

    [RfcField(AbapName = "NRO_CARPETA_OBS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Offset = 849)]
    [XmlElement("NRO_CARPETA_OBS")]
    public string Nro_Carpeta_Obs
    { 
       get
       {
          return _Nro_Carpeta_Obs;
       }
       set
       {
          _Nro_Carpeta_Obs = value;
       }
    }
    private string _Nro_Carpeta_Obs;

    [RfcField(AbapName = "NRO_CONTRATO_ANT", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 10, Offset = 859)]
    [XmlElement("NRO_CONTRATO_ANT")]
    public string Nro_Contrato_Ant
    { 
       get
       {
          return _Nro_Contrato_Ant;
       }
       set
       {
          _Nro_Contrato_Ant = value;
       }
    }
    private string _Nro_Contrato_Ant;

    [RfcField(AbapName = "DOC_SUSTENTO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 2, Offset = 869)]
    [XmlElement("DOC_SUSTENTO")]
    public string Doc_Sustento
    { 
       get
       {
          return _Doc_Sustento;
       }
       set
       {
          _Doc_Sustento = value;
       }
    }
    private string _Doc_Sustento;

    [RfcField(AbapName = "OPERADOR", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 2, Offset = 871)]
    [XmlElement("OPERADOR")]
    public string Operador
    { 
       get
       {
          return _Operador;
       }
       set
       {
          _Operador = value;
       }
    }
    private string _Operador;

    [RfcField(AbapName = "DENOM_OPERADOR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 20, Offset = 873)]
    [XmlElement("DENOM_OPERADOR")]
    public string Denom_Operador
    { 
       get
       {
          return _Denom_Operador;
       }
       set
       {
          _Denom_Operador = value;
       }
    }
    private string _Denom_Operador;

    [RfcField(AbapName = "TIPO_PROD_OPERAD", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 2, Offset = 893)]
    [XmlElement("TIPO_PROD_OPERAD")]
    public string Tipo_Prod_Operad
    { 
       get
       {
          return _Tipo_Prod_Operad;
       }
       set
       {
          _Tipo_Prod_Operad = value;
       }
    }
    private string _Tipo_Prod_Operad;

    [RfcField(AbapName = "TIPO_PROD_OPERAD_DESC", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 60, Offset = 895)]
    [XmlElement("TIPO_PROD_OPERAD_DESC")]
    public string Tipo_Prod_Operad_Desc
    { 
       get
       {
          return _Tipo_Prod_Operad_Desc;
       }
       set
       {
          _Tipo_Prod_Operad_Desc = value;
       }
    }
    private string _Tipo_Prod_Operad_Desc;

    [RfcField(AbapName = "PLAN_ANTERIOR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 3, Offset = 955)]
    [XmlElement("PLAN_ANTERIOR")]
    public string Plan_Anterior
    { 
       get
       {
          return _Plan_Anterior;
       }
       set
       {
          _Plan_Anterior = value;
       }
    }
    private string _Plan_Anterior;

    [RfcField(AbapName = "DESC_PLAN_ANTERIOR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Offset = 958)]
    [XmlElement("DESC_PLAN_ANTERIOR")]
    public string Desc_Plan_Anterior
    { 
       get
       {
          return _Desc_Plan_Anterior;
       }
       set
       {
          _Desc_Plan_Anterior = value;
       }
    }
    private string _Desc_Plan_Anterior;

    [RfcField(AbapName = "TIPO_VENTA", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 2, Offset = 998)]
    [XmlElement("TIPO_VENTA")]
    public string Tipo_Venta
    { 
       get
       {
          return _Tipo_Venta;
       }
       set
       {
          _Tipo_Venta = value;
       }
    }
    private string _Tipo_Venta;

    [RfcField(AbapName = "DES_TIPO_VENTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Offset = 1000)]
    [XmlElement("DES_TIPO_VENTA")]
    public string Des_Tipo_Venta
    { 
       get
       {
          return _Des_Tipo_Venta;
       }
       set
       {
          _Des_Tipo_Venta = value;
       }
    }
    private string _Des_Tipo_Venta;

    [RfcField(AbapName = "CLASE_VENTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 2, Offset = 1040)]
    [XmlElement("CLASE_VENTA")]
    public string Clase_Venta
    { 
       get
       {
          return _Clase_Venta;
       }
       set
       {
          _Clase_Venta = value;
       }
    }
    private string _Clase_Venta;

    [RfcField(AbapName = "DES_CLASE_VENTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Offset = 1042)]
    [XmlElement("DES_CLASE_VENTA")]
    public string Des_Clase_Venta
    { 
       get
       {
          return _Des_Clase_Venta;
       }
       set
       {
          _Des_Clase_Venta = value;
       }
    }
    private string _Des_Clase_Venta;

    [RfcField(AbapName = "CS_LARGE", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 19, Offset = 1082)]
    [XmlElement("CS_LARGE")]
    public string Cs_Large
    { 
       get
       {
          return _Cs_Large;
       }
       set
       {
          _Cs_Large = value;
       }
    }
    private string _Cs_Large;

    [RfcField(AbapName = "CS_SUBCUENTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 19, Offset = 1101)]
    [XmlElement("CS_SUBCUENTA")]
    public string Cs_Subcuenta
    { 
       get
       {
          return _Cs_Subcuenta;
       }
       set
       {
          _Cs_Subcuenta = value;
       }
    }
    private string _Cs_Subcuenta;

    [RfcField(AbapName = "LIM_CRED_MAX", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 8, Decimals = 2, Offset = 1120)]
    [XmlElement("LIM_CRED_MAX")]
    public Decimal Lim_Cred_Max
    { 
       get
       {
          return _Lim_Cred_Max;
       }
       set
       {
          _Lim_Cred_Max = value;
       }
    }
    private Decimal _Lim_Cred_Max;

    [RfcField(AbapName = "SUM_PLANES_ACTUA", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 8, Decimals = 2, Offset = 1128)]
    [XmlElement("SUM_PLANES_ACTUA")]
    public Decimal Sum_Planes_Actua
    { 
       get
       {
          return _Sum_Planes_Actua;
       }
       set
       {
          _Sum_Planes_Actua = value;
       }
    }
    private Decimal _Sum_Planes_Actua;

    [RfcField(AbapName = "SUM_PLANES_VENDI", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 8, Decimals = 2, Offset = 1136)]
    [XmlElement("SUM_PLANES_VENDI")]
    public Decimal Sum_Planes_Vendi
    { 
       get
       {
          return _Sum_Planes_Vendi;
       }
       set
       {
          _Sum_Planes_Vendi = value;
       }
    }
    private Decimal _Sum_Planes_Vendi;

    [RfcField(AbapName = "RESPONS_PAGO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 1144)]
    [XmlElement("RESPONS_PAGO")]
    public string Respons_Pago
    { 
       get
       {
          return _Respons_Pago;
       }
       set
       {
          _Respons_Pago = value;
       }
    }
    private string _Respons_Pago;

    [RfcField(AbapName = "NRO_REFERENCIA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 16, Offset = 1145)]
    [XmlElement("NRO_REFERENCIA")]
    public string Nro_Referencia
    { 
       get
       {
          return _Nro_Referencia;
       }
       set
       {
          _Nro_Referencia = value;
       }
    }
    private string _Nro_Referencia;

    [RfcField(AbapName = "TELEF_LEGAL", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 14, Offset = 1161)]
    [XmlElement("TELEF_LEGAL")]
    public string Telef_Legal
    { 
       get
       {
          return _Telef_Legal;
       }
       set
       {
          _Telef_Legal = value;
       }
    }
    private string _Telef_Legal;

    [RfcField(AbapName = "TELEF_LEGAL_PREF", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 3, Offset = 1175)]
    [XmlElement("TELEF_LEGAL_PREF")]
    public string Telef_Legal_Pref
    { 
       get
       {
          return _Telef_Legal_Pref;
       }
       set
       {
          _Telef_Legal_Pref = value;
       }
    }
    private string _Telef_Legal_Pref;

    [RfcField(AbapName = "REFER_LEGAL", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Offset = 1178)]
    [XmlElement("REFER_LEGAL")]
    public string Refer_Legal
    { 
       get
       {
          return _Refer_Legal;
       }
       set
       {
          _Refer_Legal = value;
       }
    }
    private string _Refer_Legal;

    [RfcField(AbapName = "TIPO_ACTIV_CLTE", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 1218)]
    [XmlElement("TIPO_ACTIV_CLTE")]
    public string Tipo_Activ_Clte
    { 
       get
       {
          return _Tipo_Activ_Clte;
       }
       set
       {
          _Tipo_Activ_Clte = value;
       }
    }
    private string _Tipo_Activ_Clte;

    [RfcField(AbapName = "ACTIVACION_LINEA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 1219)]
    [XmlElement("ACTIVACION_LINEA")]
    public string Activacion_Linea
    { 
       get
       {
          return _Activacion_Linea;
       }
       set
       {
          _Activacion_Linea = value;
       }
    }
    private string _Activacion_Linea;

    [RfcField(AbapName = "ACUERDO_MANUAL", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 1220)]
    [XmlElement("ACUERDO_MANUAL")]
    public string Acuerdo_Manual
    { 
       get
       {
          return _Acuerdo_Manual;
       }
       set
       {
          _Acuerdo_Manual = value;
       }
    }
    private string _Acuerdo_Manual;

    [RfcField(AbapName = "TIPO_CLI_ACT", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 2, Offset = 1221)]
    [XmlElement("TIPO_CLI_ACT")]
    public string Tipo_Cli_Act
    { 
       get
       {
          return _Tipo_Cli_Act;
       }
       set
       {
          _Tipo_Cli_Act = value;
       }
    }
    private string _Tipo_Cli_Act;

    [RfcField(AbapName = "SERV_BLACKBERRY", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 1223)]
    [XmlElement("SERV_BLACKBERRY")]
    public string Serv_Blackberry
    { 
       get
       {
          return _Serv_Blackberry;
       }
       set
       {
          _Serv_Blackberry = value;
       }
    }
    private string _Serv_Blackberry;

    [RfcField(AbapName = "TIPO_VTA_ORI", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 2, Offset = 1224)]
    [XmlElement("TIPO_VTA_ORI")]
    public string Tipo_Vta_Ori
    { 
       get
       {
          return _Tipo_Vta_Ori;
       }
       set
       {
          _Tipo_Vta_Ori = value;
       }
    }
    private string _Tipo_Vta_Ori;

    [RfcField(AbapName = "MOTIVO_MIG", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 3, Offset = 1226)]
    [XmlElement("MOTIVO_MIG")]
    public string Motivo_Mig
    { 
       get
       {
          return _Motivo_Mig;
       }
       set
       {
          _Motivo_Mig = value;
       }
    }
    private string _Motivo_Mig;

    [RfcField(AbapName = "CON_SIN_EQ", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 50, Offset = 1229)]
    [XmlElement("CON_SIN_EQ")]
    public string Con_Sin_Eq
    { 
       get
       {
          return _Con_Sin_Eq;
       }
       set
       {
          _Con_Sin_Eq = value;
       }
    }
    private string _Con_Sin_Eq;

    [RfcField(AbapName = "TIPO_MONTO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 1279)]
    [XmlElement("TIPO_MONTO")]
    public string Tipo_Monto
    { 
       get
       {
          return _Tipo_Monto;
       }
       set
       {
          _Tipo_Monto = value;
       }
    }
    private string _Tipo_Monto;

    [RfcField(AbapName = "MONTO_A_PAGAR", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 8, Decimals = 2, Offset = 1280)]
    [XmlElement("MONTO_A_PAGAR")]
    public Decimal Monto_A_Pagar
    { 
       get
       {
          return _Monto_A_Pagar;
       }
       set
       {
          _Monto_A_Pagar = value;
       }
    }
    private Decimal _Monto_A_Pagar;

    [RfcField(AbapName = "PERIODO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 6, Offset = 1288)]
    [XmlElement("PERIODO")]
    public string Periodo
    { 
       get
       {
          return _Periodo;
       }
       set
       {
          _Periodo = value;
       }
    }
    private string _Periodo;

  }

}
