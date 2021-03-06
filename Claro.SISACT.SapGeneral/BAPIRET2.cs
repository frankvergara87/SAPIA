
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

  [RfcStructure(AbapName ="BAPIRET2" , Length = 548)]
  public class BAPIRET2 : SAPStructure
  {
    
    [RfcField(AbapName = "TYPE", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 0)]
    [XmlElement("TYPE")]
    public string Type
    { 
       get
       {
          return _Type;
       }
       set
       {
          _Type = value;
       }
    }
    private string _Type;

    [RfcField(AbapName = "ID", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 20, Offset = 1)]
    [XmlElement("ID")]
    public string Id
    { 
       get
       {
          return _Id;
       }
       set
       {
          _Id = value;
       }
    }
    private string _Id;

    [RfcField(AbapName = "NUMBER", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 3, Offset = 21)]
    [XmlElement("NUMBER")]
    public string Number
    { 
       get
       {
          return _Number;
       }
       set
       {
          _Number = value;
       }
    }
    private string _Number;

    [RfcField(AbapName = "MESSAGE", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 220, Offset = 24)]
    [XmlElement("MESSAGE")]
    public string Message
    { 
       get
       {
          return _Message;
       }
       set
       {
          _Message = value;
       }
    }
    private string _Message;

    [RfcField(AbapName = "LOG_NO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 20, Offset = 244)]
    [XmlElement("LOG_NO")]
    public string Log_No
    { 
       get
       {
          return _Log_No;
       }
       set
       {
          _Log_No = value;
       }
    }
    private string _Log_No;

    [RfcField(AbapName = "LOG_MSG_NO", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 6, Offset = 264)]
    [XmlElement("LOG_MSG_NO")]
    public string Log_Msg_No
    { 
       get
       {
          return _Log_Msg_No;
       }
       set
       {
          _Log_Msg_No = value;
       }
    }
    private string _Log_Msg_No;

    [RfcField(AbapName = "MESSAGE_V1", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 50, Offset = 270)]
    [XmlElement("MESSAGE_V1")]
    public string Message_V1
    { 
       get
       {
          return _Message_V1;
       }
       set
       {
          _Message_V1 = value;
       }
    }
    private string _Message_V1;

    [RfcField(AbapName = "MESSAGE_V2", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 50, Offset = 320)]
    [XmlElement("MESSAGE_V2")]
    public string Message_V2
    { 
       get
       {
          return _Message_V2;
       }
       set
       {
          _Message_V2 = value;
       }
    }
    private string _Message_V2;

    [RfcField(AbapName = "MESSAGE_V3", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 50, Offset = 370)]
    [XmlElement("MESSAGE_V3")]
    public string Message_V3
    { 
       get
       {
          return _Message_V3;
       }
       set
       {
          _Message_V3 = value;
       }
    }
    private string _Message_V3;

    [RfcField(AbapName = "MESSAGE_V4", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 50, Offset = 420)]
    [XmlElement("MESSAGE_V4")]
    public string Message_V4
    { 
       get
       {
          return _Message_V4;
       }
       set
       {
          _Message_V4 = value;
       }
    }
    private string _Message_V4;

    [RfcField(AbapName = "PARAMETER", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 32, Offset = 470)]
    [XmlElement("PARAMETER")]
    public string Parameter
    { 
       get
       {
          return _Parameter;
       }
       set
       {
          _Parameter = value;
       }
    }
    private string _Parameter;

    [RfcField(AbapName = "ROW", RfcType = RFCTYPE.RFCTYPE_INT, Length = 4, Offset = 504)]
    [XmlElement("ROW")]
    public int Row
    { 
       get
       {
          return _Row;
       }
       set
       {
          _Row = value;
       }
    }
    private int _Row;

    [RfcField(AbapName = "FIELD", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 30, Offset = 508)]
    [XmlElement("FIELD")]
    public string Field
    { 
       get
       {
          return _Field;
       }
       set
       {
          _Field = value;
       }
    }
    private string _Field;

    [RfcField(AbapName = "SYSTEM", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Offset = 538)]
    [XmlElement("SYSTEM")]
    public string System
    { 
       get
       {
          return _System;
       }
       set
       {
          _System = value;
       }
    }
    private string _System;

  }

}
