//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=1.1.4322.573.
// 
namespace Claro.SisAct.Negocios.ReglasCrediticiaWS {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ReglasEvaluacionCrediticiaWSBinding", Namespace="http://claro.com.pe/eai/ebs/ws/ReglasEvaluacionCrediticia")]
    public class ReglasEvaluacionCrediticiaWS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public ReglasEvaluacionCrediticiaWS() {
            this.Url = "http://limdeseaiv13.tim.com.pe:7909/ReglasEvaluacionCrediticiaApp/ReglasEvaluacio" +
"nCrediticiaWSPort";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://claro.com.pe/eai/ebs/ws/ReglasEvaluacionCrediticia/consultarReglas", RequestElementName="consultarReglasRequest", RequestNamespace="http://claro.com.pe/eai/ebs/ws/ReglasEvaluacionCrediticia", ResponseNamespace="http://claro.com.pe/eai/ebs/ws/ReglasEvaluacionCrediticia", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("codigoRespuesta")]
        public string consultarReglas(
                    ref string idTransaccion, 
                    string ipAplicacion, 
                    string aplicacion, 
                    string usrApp, 
                    string tipoDespacho, 
                    string tipoProducto, 
                    string canal, 
                    string pdv, 
                    string tipoCliente, 
                    string tipoDocumento, 
                    string departamento, 
                    string provincia, 
                    string distrito, 
                    string casoEspecial, 
                    string factorEndeudamiento, 
                    string tipoOperacion, 
                    string oferta, 
                    string grupoPlanTarifario, 
                    System.Double cargoFijo, 
                    string plazoAcuerdo, 
                    string campania, 
                    string control, 
                    string factorSubsidio, 
                    string porcentajeCuotaInicial, 
                    string cuotas, 
                    string kit, 
                    string riesgo, 
                    string score, 
                    int edad, 
                    string cantidadRRLL, 
                    string publicar, 
                    out string mensajeRespuesta, 
                    [System.Xml.Serialization.XmlArrayItemAttribute("regla", IsNullable=false)] out ReglaType[] reglas) {
            object[] results = this.Invoke("consultarReglas", new object[] {
                        idTransaccion,
                        ipAplicacion,
                        aplicacion,
                        usrApp,
                        tipoDespacho,
                        tipoProducto,
                        canal,
                        pdv,
                        tipoCliente,
                        tipoDocumento,
                        departamento,
                        provincia,
                        distrito,
                        casoEspecial,
                        factorEndeudamiento,
                        tipoOperacion,
                        oferta,
                        grupoPlanTarifario,
                        cargoFijo,
                        plazoAcuerdo,
                        campania,
                        control,
                        factorSubsidio,
                        porcentajeCuotaInicial,
                        cuotas,
                        kit,
                        riesgo,
                        score,
                        edad,
                        cantidadRRLL,
                        publicar});
            idTransaccion = ((string)(results[1]));
            mensajeRespuesta = ((string)(results[2]));
            reglas = ((ReglaType[])(results[3]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginconsultarReglas(
                    string idTransaccion, 
                    string ipAplicacion, 
                    string aplicacion, 
                    string usrApp, 
                    string tipoDespacho, 
                    string tipoProducto, 
                    string canal, 
                    string pdv, 
                    string tipoCliente, 
                    string tipoDocumento, 
                    string departamento, 
                    string provincia, 
                    string distrito, 
                    string casoEspecial, 
                    string factorEndeudamiento, 
                    string tipoOperacion, 
                    string oferta, 
                    string grupoPlanTarifario, 
                    System.Double cargoFijo, 
                    string plazoAcuerdo, 
                    string campania, 
                    string control, 
                    string factorSubsidio, 
                    string porcentajeCuotaInicial, 
                    string cuotas, 
                    string kit, 
                    string riesgo, 
                    string score, 
                    int edad, 
                    string cantidadRRLL, 
                    string publicar, 
                    System.AsyncCallback callback, 
                    object asyncState) {
            return this.BeginInvoke("consultarReglas", new object[] {
                        idTransaccion,
                        ipAplicacion,
                        aplicacion,
                        usrApp,
                        tipoDespacho,
                        tipoProducto,
                        canal,
                        pdv,
                        tipoCliente,
                        tipoDocumento,
                        departamento,
                        provincia,
                        distrito,
                        casoEspecial,
                        factorEndeudamiento,
                        tipoOperacion,
                        oferta,
                        grupoPlanTarifario,
                        cargoFijo,
                        plazoAcuerdo,
                        campania,
                        control,
                        factorSubsidio,
                        porcentajeCuotaInicial,
                        cuotas,
                        kit,
                        riesgo,
                        score,
                        edad,
                        cantidadRRLL,
                        publicar}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndconsultarReglas(System.IAsyncResult asyncResult, out string idTransaccion, out string mensajeRespuesta, out ReglaType[] reglas) {
            object[] results = this.EndInvoke(asyncResult);
            idTransaccion = ((string)(results[1]));
            mensajeRespuesta = ((string)(results[2]));
            reglas = ((ReglaType[])(results[3]));
            return ((string)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ebs/ws/ReglasEvaluacionCrediticia")]
    public class ReglaType {
        
        /// <remarks/>
        public string restriccion;
        
        /// <remarks/>
        public string tipoGarantia;
        
        /// <remarks/>
        public string absolutoReferencial;
        
        /// <remarks/>
        public string montoGarantia;
        
        /// <remarks/>
        public string costoInstalacion;
        
        /// <remarks/>
        public string cantidadProductoMax;
        
        /// <remarks/>
        public string publicar;
        
        /// <remarks/>
        public string prioridadPublicacion;
        
        /// <remarks/>
        public string factorEndeudamiento;
        
        /// <remarks/>
        public string grupoPlanTarifario;
        
        /// <remarks/>
        public string cargoFijoMinimo;
        
        /// <remarks/>
        public string cargoFijoMaximo;
    }
}
