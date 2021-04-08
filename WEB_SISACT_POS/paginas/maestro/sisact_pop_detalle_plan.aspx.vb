Option Strict Off

Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades


Public Class sisact_pop_detalle_plan
    Inherits SisAct_WebBase
    Dim ListaDetalle As New ArrayList
#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnAgregarPdv As System.Web.UI.WebControls.Button
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents txtAccionGrabarPDV As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlTipoDocumentoMant As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlCuotas As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPlazoAcuerdo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtValorCuota As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents hidCuota As System.Web.UI.HtmlControls.HtmlInputHidden

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
        'Introducir aquí el código de usuario para inicializar la página
        If Not Session("ListaDetalle") Is Nothing Then ' Testing
            ListaDetalle = CType(Session("ListaDetalle"), ArrayList)
        End If
        If Not Page.IsPostBack Then
            'Dim objLServicio As LServicio

                llenarCombosConsulta()
                If Not Session("Coleccion") Is Nothing Then
                    Dim Coleccion() As String = CType(Session("Coleccion"), String()) ' Split(hidCodigo.Value.ToString(), ",")
                    Me.ddlTipoDocumento.SelectedValue = Coleccion(0)
                    Me.ddlPlazoAcuerdo.SelectedValue = Coleccion(1)
                    Me.ddlCuotas.SelectedValue = Coleccion(2)
                    Me.txtValorCuota.Text = CDec(Coleccion(3))
                    Me.hidCuota.Value = CDec(Coleccion(3))
                End If
                'RegisterStartupScript("script", "<script>f_Inicio()</script>")

        End If
        'btnCancelar
        'btnCancelar.Attributes.Add("onclick", "return window.close();")
        btnAgregarPdv.Attributes.Add("onclick", "return f_ValidarGrabar();")
    End Sub

    Sub llenarCombosConsulta()

        ddlCuotas.DataValueField = "CUOC_CODIGO"
        ddlCuotas.DataTextField = "CUOV_DESCRIPCION"
        Me.ddlCuotas.DataSource = New PlanTarifarioBusinessLogic().ListarCuotas() 'dtPlazoAcuerdo
        Me.ddlCuotas.DataBind()

        ddlTipoDocumento.DataValueField = "DOCC_CODIGO"
        ddlTipoDocumento.DataTextField = "DOCV_DESCRIPCION"
        ddlTipoDocumento.DataSource = New PlanTarifarioBusinessLogic().ListarTipoDocumento() 'dtTipoDocumento 'New PlanTarifarioBusinessLogic().ListarTipoDocumento()
        ddlTipoDocumento.DataBind()

        ddlPlazoAcuerdo.DataValueField = "PLZAC_CODIGO"
        ddlPlazoAcuerdo.DataTextField = "PLZAV_DESCRIPCION"
        ddlPlazoAcuerdo.DataSource = New PlanTarifarioBusinessLogic().ListarPlazoAcuerdo("01", "") 'dtPlazo 'New PlanTarifarioBusinessLogic().ListarPlazoAcuerdo("01", "")
        ddlPlazoAcuerdo.DataBind()

        
    End Sub

    Private Sub btnAgregarPdv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarPdv.Click

        Dim oDetallePlanTarifario As New DetallePlanTarifario        

        If Me.hidCuota.Value = "" Then
            RegisterStartupScript("script", "<script>alert('Ingrese valor de cuota');</script>")
            Exit Sub
        Else
            oDetallePlanTarifario.IdDocumento = Me.ddlTipoDocumento.SelectedValue.ToString
            oDetallePlanTarifario.DescripcionDocumento = ddlTipoDocumento.Items(ddlTipoDocumento.SelectedIndex).Text 'Me.ddlTipoDocumento.se
            oDetallePlanTarifario.IdPlazo = Me.ddlPlazoAcuerdo.SelectedValue
            oDetallePlanTarifario.DescripcionPlazo = ddlPlazoAcuerdo.Items(ddlPlazoAcuerdo.SelectedIndex).Text
            oDetallePlanTarifario.IdCuota = Me.ddlCuotas.SelectedValue
            oDetallePlanTarifario.DescripcionCuota = ddlCuotas.Items(ddlCuotas.SelectedIndex).Text
            oDetallePlanTarifario.ValorCuota = CDec(Me.hidCuota.Value)
        End If

        If Not existeRowDetalle(oDetallePlanTarifario) Then
            If Not Session("ListaDetalle") Is Nothing Then ' Testing  

                If Not Session("Coleccion") Is Nothing Then
                    Dim Coleccion() As String = CType(Session("Coleccion"), String()) ' Split(hidCodigo.Value.ToString(), ",")
                    Me.ddlTipoDocumento.SelectedValue = Coleccion(0)

                    Dim ArrayListTemporal As ArrayList = CType(Session("ListaDetalle"), ArrayList)
                    Session("ListaDetalle") = Nothing

                    Dim oArrayList As New ArrayList
                    For Each oDetallePlanTarifario1 As DetallePlanTarifario In ArrayListTemporal
                        If oDetallePlanTarifario1.IdDocumento = Coleccion(0) And _
                        oDetallePlanTarifario1.IdPlazo = Coleccion(1) And _
                        oDetallePlanTarifario1.IdCuota = Coleccion(2) Then
                        Else
                            oArrayList.Add(oDetallePlanTarifario1)
                        End If
                    Next
                    Session("ListaDetalle") = oArrayList
                End If

                ListaDetalle = CType(Session("ListaDetalle"), ArrayList)
                ListaDetalle.Add(oDetallePlanTarifario)
                Session("ListaDetalle") = ListaDetalle
                Session("Coleccion") = Nothing
                RegisterStartupScript("script", "<script>llamarPadre();</script>")
            Else
                ListaDetalle.Add(oDetallePlanTarifario)
                Session("ListaDetalle") = ListaDetalle
                Session("Coleccion") = Nothing
                RegisterStartupScript("script", "<script>llamarPadre();</script>")
                'RegisterStartupScript("script", "<script>alert('Debe seleccionar al menos un punto de venta');</script>")
            End If
        Else
            If Not Session("Coleccion") Is Nothing Then
                Dim Coleccion() As String = CType(Session("Coleccion"), String()) ' Split(hidCodigo.Value.ToString(), ",")
                Me.ddlTipoDocumento.SelectedValue = Coleccion(0)

                Dim ArrayListTemporal As ArrayList = CType(Session("ListaDetalle"), ArrayList)
                Session("ListaDetalle") = Nothing

                Dim oArrayList As New ArrayList
                For Each oDetallePlanTarifario1 As DetallePlanTarifario In ArrayListTemporal
                    If oDetallePlanTarifario1.IdDocumento = Coleccion(0) And _
                    oDetallePlanTarifario1.IdPlazo = Coleccion(1) And _
                    oDetallePlanTarifario1.IdCuota = Coleccion(2) Then
                    Else
                        oArrayList.Add(oDetallePlanTarifario1)
                    End If
                Next
                Session("ListaDetalle") = oArrayList
                Session("Coleccion") = Nothing
            Else
                'Session("Coleccion") = Nothing
                RegisterStartupScript("script", "<script>alert('El registro ya fué ingresado, seleccione otro');</script>")
            End If

        End If
        

    End Sub

    Function existeRowDetalle(ByVal obj As DetallePlanTarifario) As Boolean

        If Not Session("ListaDetalle") Is Nothing Then ' Testing
            'Dim lista As ArrayList = CType(Session("ListaDetalle"), ArrayList)
            'If Not Session("Coleccion") Is Nothing And lista.Count = 1 Then
            '    Return False
            'Else
                Dim ListaDetalleTemp As ArrayList = CType(Session("ListaDetalle"), ArrayList)
                If ListaDetalleTemp.Count > 0 Then
                    For Each oDetallePlanTarifario As DetallePlanTarifario In ListaDetalleTemp
                        If oDetallePlanTarifario.IdDocumento = obj.IdDocumento And _
                            oDetallePlanTarifario.IdPlazo = obj.IdPlazo And _
                            oDetallePlanTarifario.IdCuota = obj.IdCuota Then
                            Return True
                            Exit Function
                        End If
                    Next
                End If
            End If
        'End If
        Return False
    End Function

    Private Sub Page_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Session("Coleccion") = Nothing
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Session("Coleccion") = Nothing
        RegisterStartupScript("script", "<script>window.close();</script>")
    End Sub
End Class
