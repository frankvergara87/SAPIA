
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

  [RfcStructure(AbapName ="ZST_PV_DOCUMENTO" , Length = 832)]
  public class ZST_PV_DOCUMENTO : SAPStructure
  {
    
    [RfcField(AbapName = "DOCUMENTO", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 10, Offset = 0)]
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

    [RfcField(AbapName = "TIPO_DOCUMENTO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 10)]
    [XmlElement("TIPO_DOCUMENTO")]
    public string Tipo_Documento
    { 
       get
       {
          return _Tipo_Documento;
       }
       set
       {
          _Tipo_Documento = value;
       }
    }
    private string _Tipo_Documento;

    [RfcField(AbapName = "OFICINA_VENTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 14)]
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

    [RfcField(AbapName = "FECHA_DOCUMENTO", RfcType = RFCTYPE.RFCTYPE_DATE, Length = 8, Offset = 18)]
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

    [RfcField(AbapName = "TIPO_DOC_CLIENTE", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 2, Offset = 26)]
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

    [RfcField(AbapName = "CLIENTE", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 16, Offset = 28)]
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

    [RfcField(AbapName = "AUGRU", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 3, Offset = 44)]
    [XmlElement("AUGRU")]
    public string Augru
    { 
       get
       {
          return _Augru;
       }
       set
       {
          _Augru = value;
       }
    }
    private string _Augru;

    [RfcField(AbapName = "MONEDA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 47)]
    [XmlElement("MONEDA")]
    public string Moneda
    { 
       get
       {
          return _Moneda;
       }
       set
       {
          _Moneda = value;
       }
    }
    private string _Moneda;

    [RfcField(AbapName = "TIPO_OPERACION", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 2, Offset = 48)]
    [XmlElement("TIPO_OPERACION")]
    public string Tipo_Operacion
    { 
       get
       {
          return _Tipo_Operacion;
       }
       set
       {
          _Tipo_Operacion = value;
       }
    }
    private string _Tipo_Operacion;

    [RfcField(AbapName = "TOTAL_MERCADERIA", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Decimals = 2, Offset = 50)]
    [XmlElement("TOTAL_MERCADERIA")]
    public Decimal Total_Mercaderia
    { 
       get
       {
          return _Total_Mercaderia;
       }
       set
       {
          _Total_Mercaderia = value;
       }
    }
    private Decimal _Total_Mercaderia;

    [RfcField(AbapName = "TOTAL_IMPUESTO", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Decimals = 2, Offset = 57)]
    [XmlElement("TOTAL_IMPUESTO")]
    public Decimal Total_Impuesto
    { 
       get
       {
          return _Total_Impuesto;
       }
       set
       {
          _Total_Impuesto = value;
       }
    }
    private Decimal _Total_Impuesto;

    [RfcField(AbapName = "TOTAL_DOCUMENTO", RfcType = RFCTYPE.RFCTYPE_BCD, Length = 7, Decimals = 2, Offset = 64)]
    [XmlElement("TOTAL_DOCUMENTO")]
    public Decimal Total_Documento
    { 
       get
       {
          return _Total_Documento;
       }
       set
       {
          _Total_Documento = value;
       }
    }
    private Decimal _Total_Documento;

    [RfcField(AbapName = "FECHA_REGISTRO", RfcType = RFCTYPE.RFCTYPE_DATE, Length = 8, Offset = 71)]
    [XmlElement("FECHA_REGISTRO")]
    public string Fecha_Registro
    { 
       get
       {
          return _Fecha_Registro;
       }
       set
       {
          _Fecha_Registro = value;
       }
    }
    private string _Fecha_Registro;

    [RfcField(AbapName = "IMPRESO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 79)]
    [XmlElement("IMPRESO")]
    public string Impreso
    { 
       get
       {
          return _Impreso;
       }
       set
       {
          _Impreso = value;
       }
    }
    private string _Impreso;

    [RfcField(AbapName = "OBSERVACION1", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 200, Offset = 80)]
    [XmlElement("OBSERVACION1")]
    public string Observacion1
    { 
       get
       {
          return _Observacion1;
       }
       set
       {
          _Observacion1 = value;
       }
    }
    private string _Observacion1;

    [RfcField(AbapName = "OBSERVACION2", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 200, Offset = 280)]
    [XmlElement("OBSERVACION2")]
    public string Observacion2
    { 
       get
       {
          return _Observacion2;
       }
       set
       {
          _Observacion2 = value;
       }
    }
    private string _Observacion2;

    [RfcField(AbapName = "TIPO_VENTA", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 2, Offset = 480)]
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

    [RfcField(AbapName = "NUMERO_CONTRATO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 12, Offset = 482)]
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

    [RfcField(AbapName = "NRO_REFERENCIA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 16, Offset = 494)]
    [XmlElement("NRO_REFERENCIA")]
    public string Nro_Referencia
    { 
       get
       {
          return _Nro_Referencia;
       }
       set
       {
          _Nro_Referencia = value;
       }
    }
    private string _Nro_Referencia;

    [RfcField(AbapName = "USUARIO_REGISTRO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 12, Offset = 510)]
    [XmlElement("USUARIO_REGISTRO")]
    public string Usuario_Registro
    { 
       get
       {
          return _Usuario_Registro;
       }
       set
       {
          _Usuario_Registro = value;
       }
    }
    private string _Usuario_Registro;

    [RfcField(AbapName = "ANULADO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 522)]
    [XmlElement("ANULADO")]
    public string Anulado
    { 
       get
       {
          return _Anulado;
       }
       set
       {
          _Anulado = value;
       }
    }
    private string _Anulado;

    [RfcField(AbapName = "DOCUMENTO_ORIGEN", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 10, Offset = 523)]
    [XmlElement("DOCUMENTO_ORIGEN")]
    public string Documento_Origen
    { 
       get
       {
          return _Documento_Origen;
       }
       set
       {
          _Documento_Origen = value;
       }
    }
    private string _Documento_Origen;

    [RfcField(AbapName = "FECHA_VTA_ORIGEN", RfcType = RFCTYPE.RFCTYPE_DATE, Length = 8, Offset = 533)]
    [XmlElement("FECHA_VTA_ORIGEN")]
    public string Fecha_Vta_Origen
    { 
       get
       {
          return _Fecha_Vta_Origen;
       }
       set
       {
          _Fecha_Vta_Origen = value;
       }
    }
    private string _Fecha_Vta_Origen;

    [RfcField(AbapName = "NRO_REFER_ORIGEN", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 16, Offset = 541)]
    [XmlElement("NRO_REFER_ORIGEN")]
    public string Nro_Refer_Origen
    { 
       get
       {
          return _Nro_Refer_Origen;
       }
       set
       {
          _Nro_Refer_Origen = value;
       }
    }
    private string _Nro_Refer_Origen;

    [RfcField(AbapName = "NRO_CUOTAS", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 2, Offset = 557)]
    [XmlElement("NRO_CUOTAS")]
    public string Nro_Cuotas
    { 
       get
       {
          return _Nro_Cuotas;
       }
       set
       {
          _Nro_Cuotas = value;
       }
    }
    private string _Nro_Cuotas;

    [RfcField(AbapName = "NRO_CLARIFY", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 10, Offset = 559)]
    [XmlElement("NRO_CLARIFY")]
    public string Nro_Clarify
    { 
       get
       {
          return _Nro_Clarify;
       }
       set
       {
          _Nro_Clarify = value;
       }
    }
    private string _Nro_Clarify;

    [RfcField(AbapName = "ESTADO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 569)]
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

    [RfcField(AbapName = "VENDEDOR", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Offset = 570)]
    [XmlElement("VENDEDOR")]
    public string Vendedor
    { 
       get
       {
          return _Vendedor;
       }
       set
       {
          _Vendedor = value;
       }
    }
    private string _Vendedor;

    [RfcField(AbapName = "MALA_VENTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 580)]
    [XmlElement("MALA_VENTA")]
    public string Mala_Venta
    { 
       get
       {
          return _Mala_Venta;
       }
       set
       {
          _Mala_Venta = value;
       }
    }
    private string _Mala_Venta;

    [RfcField(AbapName = "CLASE_VENTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 2, Offset = 581)]
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

    [RfcField(AbapName = "DES_CLASE_VENTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 30, Offset = 583)]
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

    [RfcField(AbapName = "MOT_MALA_VENTA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 40, Offset = 613)]
    [XmlElement("MOT_MALA_VENTA")]
    public string Mot_Mala_Venta
    { 
       get
       {
          return _Mot_Mala_Venta;
       }
       set
       {
          _Mot_Mala_Venta = value;
       }
    }
    private string _Mot_Mala_Venta;

    [RfcField(AbapName = "TELEFONO", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 15, Offset = 653)]
    [XmlElement("TELEFONO")]
    public string Telefono
    { 
       get
       {
          return _Telefono;
       }
       set
       {
          _Telefono = value;
       }
    }
    private string _Telefono;

    [RfcField(AbapName = "REFERENCIA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 18, Offset = 668)]
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

    [RfcField(AbapName = "HISTORICO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 686)]
    [XmlElement("HISTORICO")]
    public string Historico
    { 
       get
       {
          return _Historico;
       }
       set
       {
          _Historico = value;
       }
    }
    private string _Historico;

    [RfcField(AbapName = "NUMERO_HDC", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 10, Offset = 687)]
    [XmlElement("NUMERO_HDC")]
    public string Numero_Hdc
    { 
       get
       {
          return _Numero_Hdc;
       }
       set
       {
          _Numero_Hdc = value;
       }
    }
    private string _Numero_Hdc;

    [RfcField(AbapName = "NRO_PCS_ASOCIADO", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 30, Offset = 697)]
    [XmlElement("NRO_PCS_ASOCIADO")]
    public string Nro_Pcs_Asociado
    { 
       get
       {
          return _Nro_Pcs_Asociado;
       }
       set
       {
          _Nro_Pcs_Asociado = value;
       }
    }
    private string _Nro_Pcs_Asociado;

    [RfcField(AbapName = "NRO_PED_TG", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Offset = 727)]
    [XmlElement("NRO_PED_TG")]
    public string Nro_Ped_Tg
    { 
       get
       {
          return _Nro_Ped_Tg;
       }
       set
       {
          _Nro_Ped_Tg = value;
       }
    }
    private string _Nro_Ped_Tg;

    [RfcField(AbapName = "NRO_ACUER_ALQU", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 30, Offset = 737)]
    [XmlElement("NRO_ACUER_ALQU")]
    public string Nro_Acuer_Alqu
    { 
       get
       {
          return _Nro_Acuer_Alqu;
       }
       set
       {
          _Nro_Acuer_Alqu = value;
       }
    }
    private string _Nro_Acuer_Alqu;

    [RfcField(AbapName = "TRANS_GRATUITA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 767)]
    [XmlElement("TRANS_GRATUITA")]
    public string Trans_Gratuita
    { 
       get
       {
          return _Trans_Gratuita;
       }
       set
       {
          _Trans_Gratuita = value;
       }
    }
    private string _Trans_Gratuita;

    [RfcField(AbapName = "FIDELIZACION", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 1, Offset = 768)]
    [XmlElement("FIDELIZACION")]
    public string Fidelizacion
    { 
       get
       {
          return _Fidelizacion;
       }
       set
       {
          _Fidelizacion = value;
       }
    }
    private string _Fidelizacion;

    [RfcField(AbapName = "VENDEDOR_DNI", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 11, Offset = 769)]
    [XmlElement("VENDEDOR_DNI")]
    public string Vendedor_Dni
    { 
       get
       {
          return _Vendedor_Dni;
       }
       set
       {
          _Vendedor_Dni = value;
       }
    }
    private string _Vendedor_Dni;

    [RfcField(AbapName = "NRO_SOLICITUD", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Offset = 780)]
    [XmlElement("NRO_SOLICITUD")]
    public string Nro_Solicitud
    { 
       get
       {
          return _Nro_Solicitud;
       }
       set
       {
          _Nro_Solicitud = value;
       }
    }
    private string _Nro_Solicitud;

    [RfcField(AbapName = "SERIE_RECIBIDA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 18, Offset = 790)]
    [XmlElement("SERIE_RECIBIDA")]
    public string Serie_Recibida
    { 
       get
       {
          return _Serie_Recibida;
       }
       set
       {
          _Serie_Recibida = value;
       }
    }
    private string _Serie_Recibida;

    [RfcField(AbapName = "OPERADOR", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 2, Offset = 808)]
    [XmlElement("OPERADOR")]
    public string Operador
    { 
       get
       {
          return _Operador;
       }
       set
       {
          _Operador = value;
       }
    }
    private string _Operador;

    [RfcField(AbapName = "TIPO_PROD_OPERAD", RfcType = RFCTYPE.RFCTYPE_NUM, Length = 2, Offset = 810)]
    [XmlElement("TIPO_PROD_OPERAD")]
    public string Tipo_Prod_Operad
    { 
       get
       {
          return _Tipo_Prod_Operad;
       }
       set
       {
          _Tipo_Prod_Operad = value;
       }
    }
    private string _Tipo_Prod_Operad;

    [RfcField(AbapName = "CLASE_PED_DEVOL", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 812)]
    [XmlElement("CLASE_PED_DEVOL")]
    public string Clase_Ped_Devol
    { 
       get
       {
          return _Clase_Ped_Devol;
       }
       set
       {
          _Clase_Ped_Devol = value;
       }
    }
    private string _Clase_Ped_Devol;

    [RfcField(AbapName = "NRO_FACTURA", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 10, Offset = 816)]
    [XmlElement("NRO_FACTURA")]
    public string Nro_Factura
    { 
       get
       {
          return _Nro_Factura;
       }
       set
       {
          _Nro_Factura = value;
       }
    }
    private string _Nro_Factura;

    [RfcField(AbapName = "ORGVNT", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 4, Offset = 826)]
    [XmlElement("ORGVNT")]
    public string Orgvnt
    { 
       get
       {
          return _Orgvnt;
       }
       set
       {
          _Orgvnt = value;
       }
    }
    private string _Orgvnt;

    [RfcField(AbapName = "CANAL", RfcType = RFCTYPE.RFCTYPE_CHAR, Length = 2, Offset = 830)]
    [XmlElement("CANAL")]
    public string Canal
    { 
       get
       {
          return _Canal;
       }
       set
       {
          _Canal = value;
       }
    }
    private string _Canal;

  }

}
