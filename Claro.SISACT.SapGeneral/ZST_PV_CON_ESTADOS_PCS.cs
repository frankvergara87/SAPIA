
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

  [RfcStructure(AbapName ="ZST_PV_CON_ESTADOS_PCS" , Length = 285)]
  public class ZST_PV_CON_ESTADOS_PCS : SAPStructure
  {
    
    [RfcField(AbapName = "ESTADO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 0)]
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

    [RfcField(AbapName = "DES_ESTADO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 20, Offset = 1)]
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

    [RfcField(AbapName = "FEC_CREACION", RfcType = RFCTYPE.RFCTYPE_DATE, Length = 8, Offset = 21)]
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

    [RfcField(AbapName = "HOR_CREACION", RfcType = RFCTYPE.RFCTYPE_TIME, Length = 6, Offset = 29)]
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

    [RfcField(AbapName = "USU_CREACION", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Offset = 35)]
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

    [RfcField(AbapName = "NOMBRE_USUARIO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Offset = 45)]
    [XmlElement("NOMBRE_USUARIO")]
    public string Nombre_Usuario
    { 
       get
       {
          return _Nombre_Usuario;
       }
       set
       {
          _Nombre_Usuario = value;
       }
    }
    private string _Nombre_Usuario;

    [RfcField(AbapName = "OBSERVACION", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 200, Offset = 85)]
    [XmlElement("OBSERVACION")]
    public string Observacion
    { 
       get
       {
          return _Observacion;
       }
       set
       {
          _Observacion = value;
       }
    }
    private string _Observacion;

  }

}