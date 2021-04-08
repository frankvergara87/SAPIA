Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports System.Text.RegularExpressions
Imports System.IO

Public Class sisact_ifr_detalle_cliente
    'Inherits System.Web.UI.Page
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtApPat As System.Web.UI.WebControls.TextBox    
    Protected WithEvents txtApMat As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblTipoDoc As System.Web.UI.WebControls.Label
    Protected WithEvents txtNumDoc As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDireccionCliente As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReferenciaCliente As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDepartamentoCliente As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtProvinciaCliente As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDistritoCliente As System.Web.UI.WebControls.TextBox
    Protected WithEvents trNombre As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trDocIdentidad As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trDireccion As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trReferencia As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trUbigeo As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtDireccionFactura As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReferenciaFactura As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDepartamentoFactura As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtProvinciaFactura As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDistritoFactura As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFormaPago As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTipoGarantia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMontoGarantia As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnPaso3 As System.Web.UI.WebControls.Button
    Protected WithEvents trCliente As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trFacturacion As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trPago As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trGarantia As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtTipoDoc As System.Web.UI.WebControls.TextBox

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        Response.Write("<script language=javascript>validarUrl();</script>")
        If (Session("codUsuarioSisact") Is Nothing Or Session("CodVendedorSAP") Is Nothing) Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        End If

        If Not IsPostBack Then
            Inicio()
        End If
    End Sub

    Private Sub Inicio()
        Try
            If Session("SolicitudSelected") Is Nothing Then
                HabilitarControles(False)
                hidMsg.Value = "Error. No existen datos de CLIENTE / SEC."
                Exit Sub
            End If
            Dim oSolicitud As SolicitudPersona = CType(Session("SolicitudSelected"), SolicitudPersona)

            txtNombre.Text = oSolicitud.CLIEV_NOMBRE
            If txtNombre.Text = "" Then
                txtNombre.Text = oSolicitud.CLIEV_RAZ_SOC
            End If
            txtApPat.Text = oSolicitud.CLIEV_APE_PAT            
            txtApMat.Text = oSolicitud.CLIEV_APE_MAT
            'lblTipoDoc.Text = oSolicitud.TDOCV_DESCRIPCION
            txtTipoDoc.Text = oSolicitud.TDOCV_DESCRIPCION
            txtNumDoc.Text = oSolicitud.CLIEC_NUM_DOC

            Dim tipoDoc As String = oSolicitud.TDOCC_CODIGO
            Dim puntoVentaCod As String = oSolicitud.OVENC_CODIGO

            txtReferenciaCliente.Text = oSolicitud.CLIEV_REF_DIR
            txtDepartamentoCliente.Text = oSolicitud.DEPAV_DESCRIPCION
            txtProvinciaCliente.Text = oSolicitud.PROVV_DESCRIPCION
            txtDistritoCliente.Text = oSolicitud.DISTV_DESCRIPCION

            If (oSolicitud.TVENC_CODIGO = ConfigurationSettings.AppSettings("constCodTipoVentaPrepago")) Then
                ' No existe SEC (Venta Prepago)
                trReferencia.Visible = False
                trUbigeo.Visible = False

                trFacturacion.Visible = False
                trPago.Visible = False
                trGarantia.Visible = False
            Else
                trReferencia.Visible = True
                trUbigeo.Visible = True

                trFacturacion.Visible = True
                trPago.Visible = True
                trGarantia.Visible = True

                txtDireccionFactura.Text = oSolicitud.CLIEV_PRE_DIR_FAC & " - " & oSolicitud.CLIEV_DIR_FAC
                txtReferenciaFactura.Text = oSolicitud.CLIEV_REF_DIR_FAC
                txtDepartamentoFactura.Text = oSolicitud.DEPAV_DESCRIPCION_FAC
                txtProvinciaFactura.Text = oSolicitud.PROVV_DESCRIPCION_FAC
                txtDistritoFactura.Text = oSolicitud.DISTV_DESCRIPCION_FAC

                txtFormaPago.Text = oSolicitud.FPAGV_DESCRIPCION

                txtTipoGarantia.Text = oSolicitud.TCARV_DESCRIPCION
                txtMontoGarantia.Text = String.Format("{0:#,#,0.00}", CheckDbl(oSolicitud.SOLIN_IMP_DG))
                If CheckDbl(oSolicitud.SOLIN_IMP_DG_MAN) >= 0 Then
                    txtTipoGarantia.Text = oSolicitud.TIPO_GARANTIA_DES
                    txtMontoGarantia.Text = String.Format("{0:#,#,0.00}", CheckDbl(oSolicitud.SOLIN_IMP_DG_MAN))
                End If
                ' DG/RA - Dato final contienen los campos *_MAN

            End If
            HabilitarControles(True)
        Catch ex As Exception
            HabilitarControles(True)
            hidMsg.Value = String.Format("Error. {0}", ex.Message)
        End Try
    End Sub

    Private Sub HabilitarControles(ByVal flag As Boolean)
        If flag Then
            btnPaso3.Attributes.Remove("disabled")
        Else
            btnPaso3.Attributes.Add("disabled", "disabled")
        End If
    End Sub

    Private Function VerificarCliente(ByVal puntoVenta As String, ByVal tipoDoc As String, ByVal numeroDoc As String) As Boolean
        Dim respuesta As Boolean = True

        Dim oConsultaSap As New SapGeneralNegocios
        Dim dsDatosSAP As DataSet = oConsultaSap.Get_ConsultaCliente(puntoVenta, tipoDoc, numeroDoc)
        Dim dtCliente As System.Data.DataTable = dsDatosSAP.Tables(0)
        If dtCliente.Rows.Count = 0 Then
            ' No existe cliente
            respuesta = False
        End If

        Return respuesta
    End Function

    Private Sub btnPaso3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPaso3.Click
        Try
            Dim pasosVenta() As String = CType(Session("PasosVenta"), String())
            pasosVenta(0) = CheckStr(CheckInt(pasosVenta(0)) + 1)
            Session("PasosVenta") = pasosVenta

            HabilitarControles(False)
            Refrescar()
        Catch ex As Exception
            HabilitarControles(True)
            hidMsg.Value = String.Format("Error preparando Siguiente Paso. {0}", ex.Message)
        End Try
    End Sub

    Private Sub Refrescar()
        Try
            Dim pasosVenta() As String = CType(Session("PasosVenta"), String())

            Dim strScript As String = String.Format("window.parent.refrescar({0},{1});", pasosVenta(0), pasosVenta(1))
            RegisterStartupScript("script", "<script>" & strScript & "</script>")
        Catch ex As Exception
            hidMsg.Value = String.Format("Error. No se pudo continuar con Siguiente Paso. {0}", ex.Message)
        End Try
    End Sub
End Class
