
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

  [RfcStructure(AbapName ="ZST_DEP_GARANTIA" , Length = 195)]
  public class ZST_DEP_GARANTIA : SAPStructure
  {
    
    [RfcField(AbapName = "NRO_DEP_GARANTIA", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 10, Offset = 0)]
    [XmlElement("NRO_DEP_GARANTIA")]
    public string Nro_Dep_Garantia
    { 
       get
       {
          return _Nro_Dep_Garantia;
       }
       set
       {
          _Nro_Dep_Garantia = value;
       }
    }
    private string _Nro_Dep_Garantia;

    [RfcField(AbapName = "TIPO_DOC_CLIENTE", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 2, Offset = 10)]
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

    [RfcField(AbapName = "CLIENTE", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 16, Offset = 12)]
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

    [RfcField(AbapName = "FECHA_DEPOSITO", RfcType = RFCTYPE.RFCTYPE_DATE, Length = 8, Offset = 28)]
    [XmlElement("FECHA_DEPOSITO")]
    public string Fecha_Deposito
    { 
       get
       {
          return _Fecha_Deposito;
       }
       set
       {
          _Fecha_Deposito = value;
       }
    }
    private string _Fecha_Deposito;

    [RfcField(AbapName = "FECHA_VENCIMIENT", RfcType = RFCTYPE.RFCTYPE_DATE, Length = 8, Offset = 36)]
    [XmlElement("FECHA_VENCIMIENT")]
    public string Fecha_Vencimient
    { 
       get
       {
          return _Fecha_Vencimient;
       }
       set
       {
          _Fecha_Vencimient = value;
       }
    }
    private string _Fecha_Vencimient;

    [RfcField(AbapName = "NUMERO_CONTRATO", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 10, Offset = 44)]
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

    [RfcField(AbapName = "DOCUMENTO", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 10, Offset = 54)]
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

    [RfcField(AbapName = "BELNR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Offset = 64)]
    [XmlElement("BELNR")]
    public string Belnr
    { 
       get
       {
          return _Belnr;
       }
       set
       {
          _Belnr = value;
       }
    }
    private string _Belnr;

    [RfcField(AbapName = "XBLNR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 16, Offset = 74)]
    [XmlElement("XBLNR")]
    public string Xblnr
    { 
       get
       {
          return _Xblnr;
       }
       set
       {
          _Xblnr = value;
       }
    }
    private string _Xblnr;

    [RfcField(AbapName = "MONTO_DEPOSITO", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Decimals = 2, Offset = 90)]
    [XmlElement("MONTO_DEPOSITO")]
    public Decimal Monto_Deposito
    { 
       get
       {
          return _Monto_Deposito;
       }
       set
       {
          _Monto_Deposito = value;
       }
    }
    private Decimal _Monto_Deposito;

    [RfcField(AbapName = "OFICINA_VENTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 97)]
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

    [RfcField(AbapName = "ANULADO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 101)]
    [XmlElement("ANULADO")]
    public string Anulado
    { 
       get
       {
          return _Anulado;
       }
       set
       {
          _Anulado = value;
       }
    }
    private string _Anulado;

    [RfcField(AbapName = "USU_CREACION", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 12, Offset = 102)]
    [XmlElement("USU_CREACION")]
    public string Usu_Creacion
    { 
       get
       {
          return _Usu_Creacion;
       }
       set
       {
          _Usu_Creacion = value;
       }
    }
    private string _Usu_Creacion;

    [RfcField(AbapName = "FEC_CREACION", RfcType = RFCTYPE.RFCTYPE_DATE, Length = 8, Offset = 114)]
    [XmlElement("FEC_CREACION")]
    public string Fec_Creacion
    { 
       get
       {
          return _Fec_Creacion;
       }
       set
       {
          _Fec_Creacion = value;
       }
    }
    private string _Fec_Creacion;

    [RfcField(AbapName = "HOR_CREACION", RfcType = RFCTYPE.RFCTYPE_TIME, Length = 6, Offset = 122)]
    [XmlElement("HOR_CREACION")]
    public string Hor_Creacion
    { 
       get
       {
          return _Hor_Creacion;
       }
       set
       {
          _Hor_Creacion = value;
       }
    }
    private string _Hor_Creacion;

    [RfcField(AbapName = "USU_MODIFICA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 12, Offset = 128)]
    [XmlElement("USU_MODIFICA")]
    public string Usu_Modifica
    { 
       get
       {
          return _Usu_Modifica;
       }
       set
       {
          _Usu_Modifica = value;
       }
    }
    private string _Usu_Modifica;

    [RfcField(AbapName = "FEC_MODIFICA", RfcType = RFCTYPE.RFCTYPE_DATE, Length = 8, Offset = 140)]
    [XmlElement("FEC_MODIFICA")]
    public string Fec_Modifica
    { 
       get
       {
          return _Fec_Modifica;
       }
       set
       {
          _Fec_Modifica = value;
       }
    }
    private string _Fec_Modifica;

    [RfcField(AbapName = "HOR_MODIFICA", RfcType = RFCTYPE.RFCTYPE_TIME, Length = 6, Offset = 148)]
    [XmlElement("HOR_MODIFICA")]
    public string Hor_Modifica
    { 
       get
       {
          return _Hor_Modifica;
       }
       set
       {
          _Hor_Modifica = value;
       }
    }
    private string _Hor_Modifica;

    [RfcField(AbapName = "CLDOC", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 2, Offset = 154)]
    [XmlElement("CLDOC")]
    public string Cldoc
    { 
       get
       {
          return _Cldoc;
       }
       set
       {
          _Cldoc = value;
       }
    }
    private string _Cldoc;

    [RfcField(AbapName = "NRO_CARGOS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 5, Offset = 156)]
    [XmlElement("NRO_CARGOS")]
    public string Nro_Cargos
    { 
       get
       {
          return _Nro_Cargos;
       }
       set
       {
          _Nro_Cargos = value;
       }
    }
    private string _Nro_Cargos;

    [RfcField(AbapName = "NRO_OPERACION", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 20, Offset = 161)]
    [XmlElement("NRO_OPERACION")]
    public string Nro_Operacion
    { 
       get
       {
          return _Nro_Operacion;
       }
       set
       {
          _Nro_Operacion = value;
       }
    }
    private string _Nro_Operacion;

    [RfcField(AbapName = "VIA_PAGO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 181)]
    [XmlElement("VIA_PAGO")]
    public string Via_Pago
    { 
       get
       {
          return _Via_Pago;
       }
       set
       {
          _Via_Pago = value;
       }
    }
    private string _Via_Pago;

    [RfcField(AbapName = "NRO_CARPETA_OBS", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Offset = 185)]
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

  }

}
