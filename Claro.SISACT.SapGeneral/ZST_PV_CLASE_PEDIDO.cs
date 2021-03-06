
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

  [RfcStructure(AbapName ="ZST_PV_CLASE_PEDIDO" , Length = 44)]
  public class ZST_PV_CLASE_PEDIDO : SAPStructure
  {
    
    [RfcField(AbapName = "AUART", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 0)]
    [XmlElement("AUART")]
    public string Auart
    { 
       get
       {
          return _Auart;
       }
       set
       {
          _Auart = value;
       }
    }
    private string _Auart;

    [RfcField(AbapName = "BEZEI", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 25, Offset = 4)]
    [XmlElement("BEZEI")]
    public string Bezei
    { 
       get
       {
          return _Bezei;
       }
       set
       {
          _Bezei = value;
       }
    }
    private string _Bezei;

    [RfcField(AbapName = "FKART", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 29)]
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

    [RfcField(AbapName = "CD_DEVOL", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 33)]
    [XmlElement("CD_DEVOL")]
    public string Cd_Devol
    { 
       get
       {
          return _Cd_Devol;
       }
       set
       {
          _Cd_Devol = value;
       }
    }
    private string _Cd_Devol;

    [RfcField(AbapName = "KSCHL", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 37)]
    [XmlElement("KSCHL")]
    public string Kschl
    { 
       get
       {
          return _Kschl;
       }
       set
       {
          _Kschl = value;
       }
    }
    private string _Kschl;

    [RfcField(AbapName = "NRO_LIN_DOC", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 2, Offset = 41)]
    [XmlElement("NRO_LIN_DOC")]
    public string Nro_Lin_Doc
    { 
       get
       {
          return _Nro_Lin_Doc;
       }
       set
       {
          _Nro_Lin_Doc = value;
       }
    }
    private string _Nro_Lin_Doc;

    [RfcField(AbapName = "RECIBE_PAGO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 43)]
    [XmlElement("RECIBE_PAGO")]
    public string Recibe_Pago
    { 
       get
       {
          return _Recibe_Pago;
       }
       set
       {
          _Recibe_Pago = value;
       }
    }
    private string _Recibe_Pago;

  }

}
