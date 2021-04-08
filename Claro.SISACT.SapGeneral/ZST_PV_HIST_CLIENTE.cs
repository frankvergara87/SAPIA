
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

  [RfcStructure(AbapName ="ZST_PV_HIST_CLIENTE" , Length = 312)]
  public class ZST_PV_HIST_CLIENTE : SAPStructure
  {
    
    [RfcField(AbapName = "DOCUMENTO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Offset = 0)]
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

    [RfcField(AbapName = "REFERENCIA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 18, Offset = 10)]
    [XmlElement("REFERENCIA")]
    public string Referencia
    { 
       get
       {
          return _Referencia;
       }
       set
       {
          _Referencia = value;
       }
    }
    private string _Referencia;

    [RfcField(AbapName = "OFICINA_VENTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 28)]
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

    [RfcField(AbapName = "DES_OF_VTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 20, Offset = 32)]
    [XmlElement("DES_OF_VTA")]
    public string Des_Of_Vta
    { 
       get
       {
          return _Des_Of_Vta;
       }
       set
       {
          _Des_Of_Vta = value;
       }
    }
    private string _Des_Of_Vta;

    [RfcField(AbapName = "FECHA_DOCUMENTO", RfcType = RFCTYPE.RFCTYPE_DATE, Length = 8, Offset = 52)]
    [XmlElement("FECHA_DOCUMENTO")]
    public string Fecha_Documento
    { 
       get
       {
          return _Fecha_Documento;
       }
       set
       {
          _Fecha_Documento = value;
       }
    }
    private string _Fecha_Documento;

    [RfcField(AbapName = "DES_TIPO_VENTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 30, Offset = 60)]
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

    [RfcField(AbapName = "NUMERO_CONTRATO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 12, Offset = 90)]
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

    [RfcField(AbapName = "NOMBRE_VENDEDOR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 30, Offset = 102)]
    [XmlElement("NOMBRE_VENDEDOR")]
    public string Nombre_Vendedor
    { 
       get
       {
          return _Nombre_Vendedor;
       }
       set
       {
          _Nombre_Vendedor = value;
       }
    }
    private string _Nombre_Vendedor;

    [RfcField(AbapName = "CLASE_VENTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 2, Offset = 132)]
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

    [RfcField(AbapName = "DES_CLASE_VENTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 30, Offset = 134)]
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

    [RfcField(AbapName = "FKART", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 164)]
    [XmlElement("FKART")]
    public string Fkart
    { 
       get
       {
          return _Fkart;
       }
       set
       {
          _Fkart = value;
       }
    }
    private string _Fkart;

    [RfcField(AbapName = "DES_FACTURA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 20, Offset = 168)]
    [XmlElement("DES_FACTURA")]
    public string Des_Factura
    { 
       get
       {
          return _Des_Factura;
       }
       set
       {
          _Des_Factura = value;
       }
    }
    private string _Des_Factura;

    [RfcField(AbapName = "NRO_TELEF", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 15, Offset = 188)]
    [XmlElement("NRO_TELEF")]
    public string Nro_Telef
    { 
       get
       {
          return _Nro_Telef;
       }
       set
       {
          _Nro_Telef = value;
       }
    }
    private string _Nro_Telef;

    [RfcField(AbapName = "CLIENTE", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 16, Offset = 203)]
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

    [RfcField(AbapName = "TIPO_DOC_CLIENTE", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 2, Offset = 219)]
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

    [RfcField(AbapName = "NOMBRES", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Offset = 221)]
    [XmlElement("NOMBRES")]
    public string Nombres
    { 
       get
       {
          return _Nombres;
       }
       set
       {
          _Nombres = value;
       }
    }
    private string _Nombres;

    [RfcField(AbapName = "DES_TIPO_DOC_CLI", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 30, Offset = 261)]
    [XmlElement("DES_TIPO_DOC_CLI")]
    public string Des_Tipo_Doc_Cli
    { 
       get
       {
          return _Des_Tipo_Doc_Cli;
       }
       set
       {
          _Des_Tipo_Doc_Cli = value;
       }
    }
    private string _Des_Tipo_Doc_Cli;

    [RfcField(AbapName = "FACTURA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Offset = 291)]
    [XmlElement("FACTURA")]
    public string Factura
    { 
       get
       {
          return _Factura;
       }
       set
       {
          _Factura = value;
       }
    }
    private string _Factura;

    [RfcField(AbapName = "CUOTAS", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 2, Offset = 301)]
    [XmlElement("CUOTAS")]
    public string Cuotas
    { 
       get
       {
          return _Cuotas;
       }
       set
       {
          _Cuotas = value;
       }
    }
    private string _Cuotas;

    [RfcField(AbapName = "TIPO_VENTA", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 2, Offset = 303)]
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

    [RfcField(AbapName = "MAX_CUOTA", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Decimals = 2, Offset = 305)]
    [XmlElement("MAX_CUOTA")]
    public Decimal Max_Cuota
    { 
       get
       {
          return _Max_Cuota;
       }
       set
       {
          _Max_Cuota = value;
       }
    }
    private Decimal _Max_Cuota;

  }

}