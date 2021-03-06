//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2503
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.2503.
// 
namespace Claro.SisAct.Negocios.WSConsultaCuotaCliente {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ConsultarCuotaClienteSOAP", Namespace="http://claro.com.pe/eai/oacservices/inquiry/consultacuotacliente/")]
    public class ConsultaCuotaCliente : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public ConsultaCuotaCliente() {
            this.Url = "http://172.19.74.141:8901/OAC_Services2/Inquiry/ConsultaCuotaCliente/";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://claro.com.pe/eai/oacservices/inquiry/consultacuotacliente/consultarCuotaCl" +
"iente", RequestElementName="consultaCuotaClienteRequest", RequestNamespace="http://claro.com.pe/eai/oacservices/inquiry/consultacuotacliente/", ResponseElementName="consultaCuotaClienteResponse", ResponseNamespace="http://claro.com.pe/eai/oacservices/inquiry/consultacuotacliente/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("auditResponse")]
        public AuditTypeResponse consultarCuotaCliente(AuditTypeRequest auditRequest, string tipoDocumento, string numeroDocumento, string lineaDelCliente, [System.Xml.Serialization.XmlArrayItemAttribute("requestOpcional", IsNullable=false)] ListaRequestOpcional[] listaRequestOpcional, out string totalPendCuo, out string CantLineasCuoPend, out string CantCuoPend, out string CantCuoPendLinea, out string MontoPendCuoLinea, out string estado, out string mensaje, [System.Xml.Serialization.XmlArrayItemAttribute("responseOpcional", IsNullable=false)] out ListaResponseOpcional[] listaResponseOpcional) {
            object[] results = this.Invoke("consultarCuotaCliente", new object[] {
                        auditRequest,
                        tipoDocumento,
                        numeroDocumento,
                        lineaDelCliente,
                        listaRequestOpcional});
            totalPendCuo = ((string)(results[1]));
            CantLineasCuoPend = ((string)(results[2]));
            CantCuoPend = ((string)(results[3]));
            CantCuoPendLinea = ((string)(results[4]));
            MontoPendCuoLinea = ((string)(results[5]));
            estado = ((string)(results[6]));
            mensaje = ((string)(results[7]));
            listaResponseOpcional = ((ListaResponseOpcional[])(results[8]));
            return ((AuditTypeResponse)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginconsultarCuotaCliente(AuditTypeRequest auditRequest, string tipoDocumento, string numeroDocumento, string lineaDelCliente, ListaRequestOpcional[] listaRequestOpcional, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("consultarCuotaCliente", new object[] {
                        auditRequest,
                        tipoDocumento,
                        numeroDocumento,
                        lineaDelCliente,
                        listaRequestOpcional}, callback, asyncState);
        }
        
        /// <remarks/>
        public AuditTypeResponse EndconsultarCuotaCliente(System.IAsyncResult asyncResult, out string totalPendCuo, out string CantLineasCuoPend, out string CantCuoPend, out string CantCuoPendLinea, out string MontoPendCuoLinea, out string estado, out string mensaje, out ListaResponseOpcional[] listaResponseOpcional) {
            object[] results = this.EndInvoke(asyncResult);
            totalPendCuo = ((string)(results[1]));
            CantLineasCuoPend = ((string)(results[2]));
            CantCuoPend = ((string)(results[3]));
            CantCuoPendLinea = ((string)(results[4]));
            MontoPendCuoLinea = ((string)(results[5]));
            estado = ((string)(results[6]));
            mensaje = ((string)(results[7]));
            listaResponseOpcional = ((ListaResponseOpcional[])(results[8]));
            return ((AuditTypeResponse)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/oacservices/inquiry/consultacuotacliente/")]
    public class AuditTypeRequest {
        
        /// <remarks/>
        public string idTransaccion;
        
        /// <remarks/>
        public string ipAplicacion;
        
        /// <remarks/>
        public string aplicacion;
        
        /// <remarks/>
        public string usrAplicacion;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/oacservices/inquiry/consultacuotacliente/")]
    public class ListaResponseOpcional {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string campo;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string valor;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/oacservices/inquiry/consultacuotacliente/")]
    public class AuditTypeResponse {
        
        /// <remarks/>
        public string idTransaccion;
        
        /// <remarks/>
        public string codigoRespuesta;
        
        /// <remarks/>
        public string mensajeRespuesta;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/oacservices/inquiry/consultacuotacliente/")]
    public class ListaRequestOpcional {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string campo;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string valor;
    }
}
