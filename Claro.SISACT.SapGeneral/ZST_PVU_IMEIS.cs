
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

  [RfcStructure(AbapName ="ZST_PVU_IMEIS" , Length = 51)]
  public class ZST_PVU_IMEIS : SAPStructure
  {
    
    [RfcField(AbapName = "MATNR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 18, Offset = 0)]
    [XmlElement("MATNR")]
    public string Matnr
    { 
       get
       {
          return _Matnr;
       }
       set
       {
          _Matnr = value;
       }
    }
    private string _Matnr;

    [RfcField(AbapName = "SERNR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 18, Offset = 18)]
    [XmlElement("SERNR")]
    public string Sernr
    { 
       get
       {
          return _Sernr;
       }
       set
       {
          _Sernr = value;
       }
    }
    private string _Sernr;

    [RfcField(AbapName = "NRO_TELEF", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 15, Offset = 36)]
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

  }

}
