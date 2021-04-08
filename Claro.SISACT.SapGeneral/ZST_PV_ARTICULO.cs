
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

  [RfcStructure(AbapName ="ZST_PV_ARTICULO" , Length = 71)]
  public class ZST_PV_ARTICULO : SAPStructure
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

    [RfcField(AbapName = "MAKTX", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Offset = 18)]
    [XmlElement("MAKTX")]
    public string Maktx
    { 
       get
       {
          return _Maktx;
       }
       set
       {
          _Maktx = value;
       }
    }
    private string _Maktx;

    [RfcField(AbapName = "SERNP", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 58)]
    [XmlElement("SERNP")]
    public string Sernp
    { 
       get
       {
          return _Sernp;
       }
       set
       {
          _Sernp = value;
       }
    }
    private string _Sernp;

    [RfcField(AbapName = "MATKL", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 9, Offset = 62)]
    [XmlElement("MATKL")]
    public string Matkl
    { 
       get
       {
          return _Matkl;
       }
       set
       {
          _Matkl = value;
       }
    }
    private string _Matkl;

  }

}
