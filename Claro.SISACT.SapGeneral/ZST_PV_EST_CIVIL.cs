
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

  [RfcStructure(AbapName ="ZST_PV_EST_CIVIL" , Length = 7)]
  public class ZST_PV_EST_CIVIL : SAPStructure
  {
    
    [RfcField(AbapName = "FAMST", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 0)]
    [XmlElement("FAMST")]
    public string Famst
    { 
       get
       {
          return _Famst;
       }
       set
       {
          _Famst = value;
       }
    }
    private string _Famst;

    [RfcField(AbapName = "FTEXT", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 6, Offset = 1)]
    [XmlElement("FTEXT")]
    public string Ftext
    { 
       get
       {
          return _Ftext;
       }
       set
       {
          _Ftext = value;
       }
    }
    private string _Ftext;

  }

}