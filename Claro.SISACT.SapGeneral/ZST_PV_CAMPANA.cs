
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

  [RfcStructure(AbapName ="ZST_PV_CAMPANA" , Length = 44)]
  public class ZST_PV_CAMPANA : SAPStructure
  {
    
    [RfcField(AbapName = "CAMPANA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 0)]
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

    [RfcField(AbapName = "DESCRIPCION", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Offset = 4)]
    [XmlElement("DESCRIPCION")]
    public string Descripcion
    { 
       get
       {
          return _Descripcion;
       }
       set
       {
          _Descripcion = value;
       }
    }
    private string _Descripcion;

  }

}
