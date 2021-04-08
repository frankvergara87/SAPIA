Option Strict Off
Imports System.Data.OleDb
Imports System.Web.Security
Imports ADODB
Imports System.Text

Imports Claro.sisact.Entidades
Imports Claro.SisAct.Negocios
Imports Claro.sisact.Common.Funciones
Imports Claro.sisact.Web.Funciones
Imports System
Imports System.IO

Public Class Acceso
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hidCodUsuario As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodVendedorSAP As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lblNombreCompleto As System.Web.UI.WebControls.Label
    Protected WithEvents lblArea As System.Web.UI.WebControls.Label
    Protected WithEvents imgIngresar As System.Web.UI.WebControls.ImageButton

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
        Dim codAplicacion As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
        Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")

        Response.Buffer = True ' Contenido sera bufferizado
        Response.Clear()  ' Se limpia el buffer
        Response.Expires = 0   ' Se obliga a recargar ASP
        Session.Timeout = 60   ' Tiempo de duración de la sesión

        Dim strRutaActual As String = Request.ServerVariables("HTTP_REFERER").Substring(0, Request.ServerVariables("HTTP_REFERER").LastIndexOf("/"))
        strRutaActual = strRutaActual.PadRight(strRutaSite.Length, "/")

        If Not strRutaSite.ToLower.Equals(strRutaActual.ToLower) Then
            Response.Redirect("Include/ErrorIngreso.html")
            Exit Sub
        End If

        '*****************************************************'
        '*** Declaración de Constantes y Variables Locales ***'
        '*****************************************************'
        Dim objAcceso, objEmpleado, objOpcionesPagina As Object
        Dim rsVerificaAccesoAplicaciones As Object
        Dim rsDatosUsuario, rsOpcionesPagina, rsPerfilesUsuario As Object

        Dim strDomainUser, strUsuario, strCodUsuario, strCodPerfil, strCodVendedorSAP As String
        Dim strNombreCompleto, strCodArea, strArea As String
        Dim strOpcionesPagina, strClavesPagina, strCadenaPerfiles As String
        Dim objHost, strIP, strHost As String

        '***********************************'
        '*** Capturamos el Usuario de NT ***'
        '***********************************'
        strDomainUser = Request.ServerVariables("LOGON_USER")
        strUsuario = Trim(Mid(strDomainUser, InStr(1, strDomainUser, "\", vbTextCompare) + 1, 20))

        '''Inicio Componente
        '**********************************************************************'
        '*** COM Recordset: APLICACIONES: Devuelve los Perfiles del Usuario ***'
        '**********************************************************************'
        Dim daRecord As New OleDbDataAdapter
        Dim daRecordNombre As New OleDbDataAdapter
        Dim dsRecord As New DataSet
        Dim dsRecordNombre As New DataSet

        objAcceso = CreateObject("Segu_DB.Acceso")
        rsVerificaAccesoAplicaciones = CreateObject("ADODB.Recordset")
        rsVerificaAccesoAplicaciones = objAcceso.GetVerificaUsuario(CStr(strUsuario), CInt(codAplicacion))
        objAcceso = Nothing
        daRecord.MissingSchemaAction = MissingSchemaAction.AddWithKey
        daRecord.Fill(dsRecord, rsVerificaAccesoAplicaciones, "Usuario")

        Dim eUsuario As New Usuario
        Dim objServAcceso As New GeneralNegocios

        If Not rsVerificaAccesoAplicaciones Is Nothing Then
            ' Usuario Correcto
            If dsRecord.Tables(0).Rows.Count > 0 Then
                Session("codUsuario") = dsRecord.Tables(0).Rows(0).Item("USUAC_COD")
                Session("codPerfil") = dsRecord.Tables(0).Rows(0).Item("PERFC_COD")

                'objEmpleado = CreateObject("IntraTim_DB.Empleado")
                'rsDatosUsuario = CreateObject("ADODB.Recordset")
                'rsDatosUsuario = objEmpleado.GetDatosUsuario(Session("codUsuario"))
                'objEmpleado = Nothing
                'daRecordNombre.MissingSchemaAction = MissingSchemaAction.AddWithKey
                'daRecordNombre.Fill(dsRecordNombre, rsDatosUsuario, "Nombres")

                'strNombreCompleto = dsRecordNombre.Tables(0).Rows(0).Item("NOMBRE") & " " & dsRecordNombre.Tables(0).Rows(0).Item("APELLIDO")
                'Session("NOMBRECOMPLETO") = strNombreCompleto
                'lblNombreCompleto.Text = strNombreCompleto
                'strCodArea = dsRecordNombre.Tables(0).Rows(0).Item("ID_AREA")
                'strArea = dsRecordNombre.Tables(0).Rows(0).Item("AREA")
                'Session("CODIGOAREA") = strCodArea
                'lblArea.Text = strArea
                'Session("CODIGOSAP") = CheckStr(dsRecordNombre.Tables(0).Rows(0).Item("COD_VENDEDOR"))
                'Session("CodVendedorSAP") = CheckStr(dsRecordNombre.Tables(0).Rows(0).Item("COD_VENDEDOR"))
                'Session("LOGIN") = dsRecordNombre.Tables(0).Rows(0).Item("LOGIN")


                eUsuario = objServAcceso.DatosUsuario(Session("codUsuario"), strUsuario)

                If eUsuario Is Nothing Then

                    Response.Redirect("Include/ErrorIngreso.html")

                Else
                    lblNombreCompleto.Text = (eUsuario.Nombre & " " & eUsuario.Apellidos).Trim.ToUpper
                    lblArea.Text = IIf(eUsuario Is Nothing, "TODOS", eUsuario.AreaUsuario.ToUpper)

                    HttpContext.Current.Session("IdUsuario") = eUsuario.UsuarioId

                    HttpContext.Current.Session("NOMBRECOMPLETO") = lblNombreCompleto.Text
                    '    HttpContext.Current.Session("EmailUsuario") = oUsuario.empleado.correo
                    HttpContext.Current.Session("CODIGOAREA") = eUsuario.OficinaId

                    HttpContext.Current.Session("Area") = Me.lblArea.Text

                    Session("CODIGOSAP") = eUsuario.CodigoVendedor

                    Session("CodVendedorSAP") = eUsuario.CodigoVendedor
                    Session("LOGIN") = eUsuario.Login
                    Session("HOST") = CurrentTerminal 'PROY-24740
                    strCodVendedorSAP = Session("CodigoSAP")

                    Session("HOST") = CurrentTerminal 'PROY-24740

                    strCodVendedorSAP = Session("CodigoSAP")

                End If
               
                rsVerificaAccesoAplicaciones = Nothing
            Else
                rsVerificaAccesoAplicaciones = Nothing
                Response.Redirect("Include/ErrorIngreso.html")
            End If
        End If

    End Sub


    Private Sub imgIngresar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgIngresar.Click
        Response.Redirect("Inicio.aspx")
    End Sub
End Class
