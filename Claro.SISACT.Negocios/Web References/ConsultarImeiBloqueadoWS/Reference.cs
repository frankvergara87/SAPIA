﻿//------------------------------------------------------------------------------
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
namespace Claro.SisAct.Negocios.ConsultarImeiBloqueadoWS {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ConsultarImeiBloqueadoWSPortTypeSOAP11Binding", Namespace="http://claro.com.pe/eai/ws/consultarImeiBloqueadows")]
    public class ConsultarImeiBloqueadoService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public ConsultarImeiBloqueadoService() {
            this.Url = "http://limdeseaiv19.tim.com.pe:8909/ConsultarImeiBloqueadoWS/ebsConsultarImeiBloq" +
"ueadoWSSB11";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://claro.com.pe/eai/ws/consultarImeiBloqueadows/consultarImeiBloqueado", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("consultarImeiBloqueadoResponse", Namespace="http://claro.com.pe/eai/ws/consultarImeiBloqueadows/types")]
        public consultarImeiBloqueadoResponse consultarImeiBloqueado([System.Xml.Serialization.XmlElementAttribute(Namespace="http://claro.com.pe/eai/ws/consultarImeiBloqueadows/types")] consultarImeiBloqueadoRequest consultarImeiBloqueadoRequest) {
            object[] results = this.Invoke("consultarImeiBloqueado", new object[] {
                        consultarImeiBloqueadoRequest});
            return ((consultarImeiBloqueadoResponse)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginconsultarImeiBloqueado(consultarImeiBloqueadoRequest consultarImeiBloqueadoRequest, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("consultarImeiBloqueado", new object[] {
                        consultarImeiBloqueadoRequest}, callback, asyncState);
        }
        
        /// <remarks/>
        public consultarImeiBloqueadoResponse EndconsultarImeiBloqueado(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((consultarImeiBloqueadoResponse)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ws/consultarImeiBloqueadows/types")]
    public class consultarImeiBloqueadoRequest {
        
        /// <remarks/>
        public auditRequestType auditRequest;
        
        /// <remarks/>
        public string numeroImei;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("objetoOpcional", Namespace="http://claro.com.pe/eai/ws/baseschema", IsNullable=false)]
        public parametrosTypeObjetoOpcional[] listaRequestOpcional;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ws/baseschema")]
    public class auditRequestType {
        
        /// <remarks/>
        public string idTransaccion;
        
        /// <remarks/>
        public string ipAplicacion;
        
        /// <remarks/>
        public string nombreAplicacion;
        
        /// <remarks/>
        public string usuarioAplicacion;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ws/baseschema")]
    public class auditResponseType {
        
        /// <remarks/>
        public string idTransaccion;
        
        /// <remarks/>
        public int codigoRespuesta;
        
        /// <remarks/>
        public string mensajeRespuesta;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ws/consultarImeiBloqueadows/types")]
    public class consultarImeiBloqueadoResponse {
        
        /// <remarks/>
        public auditResponseType auditResponse;
        
        /// <remarks/>
        public string codigoDesbloqueo;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("objetoOpcional", Namespace="http://claro.com.pe/eai/ws/baseschema", IsNullable=false)]
        public parametrosTypeObjetoOpcional[] listaResponseOpcional;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ws/baseschema")]
    public class parametrosTypeObjetoOpcional {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string campo;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string valor;
    }
}
