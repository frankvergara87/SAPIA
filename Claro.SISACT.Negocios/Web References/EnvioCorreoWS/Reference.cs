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
namespace Claro.SisAct.Negocios.EnvioCorreoWS {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="envioCorreoWSPortSB11Binding", Namespace="http://claro.com.pe/eai/util/enviocorreo")]
    public class envioCorreoWSService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public envioCorreoWSService() {
            this.Url = "http://limdeseaiv28.tim.com.pe:8909/EnvioCorreoWS/envioCorreoWSPortSB11";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://claro.com.pe/eai/util/enviocorreo/enviarCorreo", RequestElementName="enviarCorreoRequest", RequestNamespace="http://claro.com.pe/eai/util/enviocorreo", ResponseNamespace="http://claro.com.pe/eai/util/enviocorreo", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("auditResponse")]
        public AuditTypeResponse enviarCorreo(AuditTypeRequest auditRequest, string remitente, string destinatario, string asunto, string mensaje, string htmlFlag, [System.Xml.Serialization.XmlArrayItemAttribute("ParametroComplexType", IsNullable=false)] ParametroOpcionalComplexType[] parametrosOpcionalesRequest, [System.Xml.Serialization.XmlArrayItemAttribute("ParametroComplexType", IsNullable=false)] out ParametroOpcionalComplexType[] parametrosOpcionalesResponse) {
            object[] results = this.Invoke("enviarCorreo", new object[] {
                        auditRequest,
                        remitente,
                        destinatario,
                        asunto,
                        mensaje,
                        htmlFlag,
                        parametrosOpcionalesRequest});
            parametrosOpcionalesResponse = ((ParametroOpcionalComplexType[])(results[1]));
            return ((AuditTypeResponse)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginenviarCorreo(AuditTypeRequest auditRequest, string remitente, string destinatario, string asunto, string mensaje, string htmlFlag, ParametroOpcionalComplexType[] parametrosOpcionalesRequest, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("enviarCorreo", new object[] {
                        auditRequest,
                        remitente,
                        destinatario,
                        asunto,
                        mensaje,
                        htmlFlag,
                        parametrosOpcionalesRequest}, callback, asyncState);
        }
        
        /// <remarks/>
        public AuditTypeResponse EndenviarCorreo(System.IAsyncResult asyncResult, out ParametroOpcionalComplexType[] parametrosOpcionalesResponse) {
            object[] results = this.EndInvoke(asyncResult);
            parametrosOpcionalesResponse = ((ParametroOpcionalComplexType[])(results[1]));
            return ((AuditTypeResponse)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/util/enviocorreo")]
    public class AuditTypeRequest {
        
        /// <remarks/>
        public string idTransaccion;
        
        /// <remarks/>
        public string codigoAplicacion;
        
        /// <remarks/>
        public string ipAplicacion;
        
        /// <remarks/>
        public string usrAplicacion;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/util/enviocorreo")]
    public class AuditTypeResponse {
        
        /// <remarks/>
        public string idTransaccion;
        
        /// <remarks/>
        public string codigoRespuesta;
        
        /// <remarks/>
        public string mensajeRespuesta;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/util/enviocorreo")]
    public class ParametroOpcionalComplexType {
        
        /// <remarks/>
        public string clave;
        
        /// <remarks/>
        public string valor;
    }
}
