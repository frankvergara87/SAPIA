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
namespace Claro.SisAct.Negocios.WSEnvioSMS {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="bsEnvioSmsServiceSoapBinding", Namespace="http://pe/com/claro/eai/ws/postventa/enviosms")]
    public class bsEnvioSmsService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public bsEnvioSmsService() {
            this.Url = "http://172.19.74.141:8901/Messaging_Services/SMSC/Transaction/proxy_services/Envi" +
"oSms";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://pe/com/claro/eai/ws/postventa/enviosms", ResponseNamespace="http://pe/com/claro/eai/ws/postventa/enviosms", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("EnvioSMSResponse", Namespace="http://claro.com.pe/eai/bs/xsd/postventa/EnvioSms")]
        public EnvioSMSResponseType enviarSms([System.Xml.Serialization.XmlElementAttribute(Namespace="http://claro.com.pe/eai/bs/xsd/postventa/EnvioSms")] EnvioSMSRequestType EnvioSMSRequest) {
            object[] results = this.Invoke("enviarSms", new object[] {
                        EnvioSMSRequest});
            return ((EnvioSMSResponseType)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginenviarSms(EnvioSMSRequestType EnvioSMSRequest, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("enviarSms", new object[] {
                        EnvioSMSRequest}, callback, asyncState);
        }
        
        /// <remarks/>
        public EnvioSMSResponseType EndenviarSms(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((EnvioSMSResponseType)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/bs/xsd/postventa/EnvioSms")]
    public class EnvioSMSRequestType {
        
        /// <remarks/>
        public string idTransaccion;
        
        /// <remarks/>
        public string ipAplicacion;
        
        /// <remarks/>
        public string usuarioApp;
        
        /// <remarks/>
        public string mensaje;
        
        /// <remarks/>
        public string identificadorMAS;
        
        /// <remarks/>
        public string msisdn;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/bs/xsd/postventa/EnvioSms")]
    public class EnvioSMSResponseType {
        
        /// <remarks/>
        public string idTransaccion;
        
        /// <remarks/>
        public string codigoError;
        
        /// <remarks/>
        public string mensajeError;
    }
}
