Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones.Comunes
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Web.Funciones.LoginUsuario

Public Class sisact_verifica_evaluacion_consumer
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hidFlagTop As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodSolicitud As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodEstado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodTipoEvaluacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNumeroDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRazonSocial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagTerminado As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected constcodEstadoAPR As String = ConfigurationSettings.AppSettings("constcodEstadoAPR")
    Protected constcodEstadoPOOLEVALUADOR As String = ConfigurationSettings.AppSettings("constcodEstadoPOOLEVALUADORCONSUMER")
    Protected constcodEstadoOBSERVADO As String = ConfigurationSettings.AppSettings("constcodEstadoOBSERVADO")
    Protected constCodEvaluacionConsumer As String = ConfigurationSettings.AppSettings("constCodEvaluacionConsumer")
    Protected WithEvents hidFlagPermiteIngresar As System.Web.UI.HtmlControls.HtmlInputHidden
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            BuscarEvaluacion(Request("strCodSolicitud"))
        End If
    End Sub
    Sub BuscarEvaluacion(ByVal strCodSolicitud As String)
        Dim oConsulta As New SolicitudNegocios
        Dim ListaSolicitud As ArrayList
        ListaSolicitud = oConsulta.ObtenerConsultaSolicitudCons(strCodSolicitud, "", "")
        If ListaSolicitud.Count > 0 Then
            Dim oSolicitud As ConsultaSolicitud = CType(ListaSolicitud(0), ConsultaSolicitud)
            Dim estado As String = oSolicitud.ESTAC_CODIGO
            hidCodSolicitud.Value = oSolicitud.SOLIN_CODIGO
            hidCodEstado.Value = oSolicitud.ESTAC_CODIGO
            hidNumeroDocumento.Value = oSolicitud.CLIEC_NUM_DOC
            hidCodTipoEvaluacion.Value = oSolicitud.SOLIC_TIPO_EVALUACION
            hidFlagTerminado.Value = oSolicitud.SOLIC_FLA_TER
            hidRazonSocial.Value = oSolicitud.CLIEV_RAZ_SOC

            Select Case estado

                Case ConfigurationSettings.AppSettings("constcodEstadoPOOLEVALUADORCONSUMER")
                    hidFlagTerminado.Value = "N"
                Case ConfigurationSettings.AppSettings("constcodEstadoSECCONADJARCHIVOS")
                    hidFlagPermiteIngresar.Value = "S"
                Case ConfigurationSettings.AppSettings("constcodEstadoRECHAZADOEVALUACION")
                    hidFlagPermiteIngresar.Value = "S"
                    hidFlagTerminado.Value = "N"
                Case ConfigurationSettings.AppSettings("constcodEstadoRECHAZADOXNOADJSUSTENTO")
                    hidFlagPermiteIngresar.Value = "S"

            End Select

        End If
    End Sub
End Class
