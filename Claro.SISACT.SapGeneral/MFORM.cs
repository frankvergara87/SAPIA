
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

  [RfcStructure(AbapName ="MFORM" , Length = 134)]
  public class MFORM : SAPStructure
  {
    
    [RfcField(AbapName = "LTYPE", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 2, Offset = 0)]
    [XmlElement("LTYPE")]
    public string Ltype
    { 
       get
       {
          return _Ltype;
       }
       set
       {
          _Ltype = value;
       }
    }
    private string _Ltype;

    [RfcField(AbapName = "LINDA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 132, Offset = 2)]
    [XmlElement("LINDA")]
    public string Linda
    { 
       get
       {
          return _Linda;
       }
       set
       {
          _Linda = value;
       }
    }
    private string _Linda;

  }

}
