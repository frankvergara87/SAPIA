
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

  [RfcStructure(AbapName ="ZST_PV_PLAZO_ACUERDO" , Length = 34)]
  public class ZST_PV_PLAZO_ACUERDO : SAPStructure
  {
    
    [RfcField(AbapName = "PLAZO_ACUERDO", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 2, Offset = 0)]
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

    [RfcField(AbapName = "DESCRIPCION", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 30, Offset = 2)]
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

    [RfcField(AbapName = "ACTIVO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 32)]
    [XmlElement("ACTIVO")]
    public string Activo
    { 
       get
       {
          return _Activo;
       }
       set
       {
          _Activo = value;
       }
    }
    private string _Activo;

    [RfcField(AbapName = "PRIORIDAD", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 33)]
    [XmlElement("PRIORIDAD")]
    public string Prioridad
    { 
       get
       {
          return _Prioridad;
       }
       set
       {
          _Prioridad = value;
       }
    }
    private string _Prioridad;

  }

}
