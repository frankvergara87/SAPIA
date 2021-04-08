Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports System.Text.RegularExpressions
Imports System.IO

Public Class sisact_ifr_operador149
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlCanal As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPuntoVenta As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlVendedorSAP As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnPaso1 As System.Web.UI.WebControls.Button
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPuntosVentas As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPuntoVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidVendedorSAP As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidParamsListaVendedores As System.Web.UI.HtmlControls.HtmlInputHidden

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
       
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        If Request.QueryString("cu") Is Nothing Then
            Response.Write("<script language=javascript>validarUrl();</script>")
        Else
            Response.Write("<script language=javascript>restringirEventos();</script>")
        End If

        If (CheckStr(Session("codUsuarioSisact")).Equals(String.Empty) Or CheckStr(Session("CodVendedorSAP")).Equals(String.Empty)) Then
            Dim strUsuarioExt As String = Request.QueryString("cu") & String.Empty
            If Not AccesoUsuario.VerificarUsuario(strUsuarioExt, CheckStr(Session("codUsuario"))) Then
                Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
                Response.Redirect(strRutaSite)
                Response.End()
                Exit Sub
            End If
        End If

        If Not IsPostBack Then
            Inicio()
        End If

    End Sub

    Private Sub Inicio()

        Dim objFileLog As New SISACT_Log
        Dim nameFile As String = ConfigurationSettings.AppSettings("constNameLogRenovacion")
        Dim strArchivo As String = objFileLog.Log_CrearNombreArchivo(nameFile)
        Dim strIdentifyLog As String = Me.CurrentUser

        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")
        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio sisact_ifr_operador149 ")
        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")

        btnPaso1.Attributes.Add("OnClick", "return verificar();")
        Try
            ' Obtengo el usuario de sisact del usuario
            Dim objClienteNegocio As New ClienteNegocio
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Metodo registrarSolicitud()")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP CurrentUser: " & Me.CurrentUser())

            Dim usrSisact As String = objClienteNegocio.ObtieneUsrSisact(Me.CurrentUser())

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros OUT usrSisact: " & usrSisact)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo registrarSolicitud()")

            Session("USRSISACT") = usrSisact
            Session("TipoVentaExpress") = ConfigurationSettings.AppSettings("ExpressModoPrepagoRenovacion")
            Session("CanalSelected") = Nothing
            Session("PuntoVentaSelected") = Nothing
            Session("VendedorSelected") = Nothing
            Session("LineaSelected") = Nothing

            Dim pasosVenta(1) As String
            pasosVenta(1) = "4"

            Dim login As String = Me.CurrentUser
            Dim perfil148 As String = ConfigurationSettings.AppSettings("ExpressPerfil148")
            Dim perfil149 As String = ConfigurationSettings.AppSettings("ExpressPerfil149")
            Dim perfilPDV As String = ConfigurationSettings.AppSettings("ExpressAsesorPDV")
            Dim perfiles As String = ""
            Dim objLoginUsuario As New LoginUsuarioNegocios
            Dim codAplicacion As Int64 = CheckInt64(ConfigurationSettings.AppSettings("CodigoAplicacion"))

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Metodo ListarOpcionesPagina()")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP codUsuarioSisact: " & CheckStr(Session("codUsuarioSisact")))
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP codAplicacion: " & codAplicacion)

            Dim arrayOpciones As ArrayList = objLoginUsuario.ListarOpcionesPagina(CheckInt64(Session("codUsuarioSisact")), codAplicacion)

            For Each item As ItemGenerico In arrayOpciones
                perfiles &= "," & item.Descripcion
            Next

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros OUT perfiles: " & perfiles)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo ListarOpcionesPagina()")

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		perfil148: " & perfil148)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		perfil149: " & perfil149)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		perfilPDV: " & perfilPDV)

            If perfiles.IndexOf(perfil148) <> -1 Or perfiles.IndexOf(perfil149) <> -1 Then
                pasosVenta(0) = "1"
                CargarCanal(0)
                CargarPuntoVenta(0)
                CargarVendedor()
            Else
               If perfiles.IndexOf(perfilPDV) <> -1 Then
                    pasosVenta(0) = "1"
                    CargarCanal(1)
                    CargarPuntoVenta(1)
               Else                    
                    hidMsg.Value = "Error. Usted no cuenta con los perfiles para acceder a esta opción"
               End If
            End If
            Session("PasosVenta") = pasosVenta

        Catch ex As Exception
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		ERROR: " & ex.Message.ToString())
            hidMsg.Value = hidMsg.Value & " - Error. " & ex.Message
        Finally
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin sisact_ifr_operador149 ")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")
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

    Private Sub HabilitarControles(ByVal flag As Boolean)
        If flag Then
            btnPaso1.Attributes.Remove("disabled")
            ddlCanal.Attributes.Remove("disabled")
            ddlPuntoVenta.Attributes.Remove("disabled")
            ddlVendedorSAP.Attributes.Remove("disabled")
        Else
            btnPaso1.Attributes.Add("disabled", "disabled")
            ddlCanal.Attributes.Add("disabled", "disabled")
            ddlPuntoVenta.Attributes.Add("disabled", "disabled")
            ddlVendedorSAP.Attributes.Add("disabled", "disabled")
        End If
    End Sub

    Private Sub CargarCanal(ByVal valor As Integer)

        Dim objFileLog As New SISACT_Log
        Dim nameFile As String = ConfigurationSettings.AppSettings("constNameLogRenovacion")
        Dim strArchivo As String = objFileLog.Log_CrearNombreArchivo(nameFile)
        Dim strIdentifyLog As String = Me.CurrentUser

        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")
        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio CargarCanal ")
        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")

        Try
            Dim objConsumerNegocio As New ConsumerNegocio
            Dim objClienteNegocio As New ClienteNegocio
            Dim listaCanal As New ArrayList
            Dim usr As Long = CheckInt64(Session("USRSISACT"))

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		valor: " & valor)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		usr: " & usr)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Metodo ListarOpcionesPagina()")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP constCodTipoProductoCON: " & ConfigurationSettings.AppSettings("constCodTipoProductoCON"))

            If valor = 0 Then
                listaCanal = objConsumerNegocio.ListaCanales(0, ConfigurationSettings.AppSettings("constCodTipoProductoCON"))
                'Remuevo los item de CAC y Corporativas
                listaCanal.RemoveRange(0, 1)
                listaCanal.RemoveRange(2, 1)
            Else
                listaCanal = objConsumerNegocio.ListaCanales(usr, ConfigurationSettings.AppSettings("constCodTipoProductoCON"))
                ddlCanal.Enabled = False
            End If

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros OUT listaCanal.Count: " & listaCanal.Count.ToString())

            Dim oCanal As New Canal
            oCanal.CANAC_CODIGO = "00"
            oCanal.CANAV_DESCRIPCION = ConfigurationSettings.AppSettings("Seleccionar")
            listaCanal.Insert(0, oCanal)
            Dim vCanal As String
            With ddlCanal
                .DataSource = listaCanal
                .DataValueField = "CANAC_CODIGO"
                .DataTextField = "CANAV_DESCRIPCION"
                .DataBind()
                If valor <> 0 Then
                    .SelectedIndex = 1
                    vCanal = .SelectedValue.Trim()
                End If
            End With

            objConsumerNegocio = Nothing
            listaCanal = Nothing
            oCanal = Nothing
           
        Catch ex As Exception
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		ERROR: " & ex.Message.ToString())
        Finally
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin CargarCanal ")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")
        End Try

    End Sub

    Private Sub CargarPuntoVenta(ByVal valor As Integer)
        Dim oConsulta As New MaestroNegocio
        Dim listaPuntoVenta As New ArrayList
        Dim listaPuntoVentaSel As New ArrayList
        Dim strCadenaPuntoVenta As String
        Dim usr As Long = CheckInt64(Session("USRSISACT"))

        If valor = 0 Then
            listaPuntoVenta = oConsulta.ListaPDVUsuario(0, ConfigurationSettings.AppSettings("constCodTipoProductoCON"))
        Else
            listaPuntoVenta = oConsulta.ListaPDVUsuario(usr, ConfigurationSettings.AppSettings("constCodTipoProductoCON"))
            ddlPuntoVenta.Enabled = False
        End If

        Dim oPuntoVenta As New PuntoVenta
        oPuntoVenta.OVENC_CODIGO = "00"
        oPuntoVenta.OVENV_DESCRIPCION = ConfigurationSettings.AppSettings("Seleccionar")
        oPuntoVenta.TOFIC_CODIGO = "00"
        oPuntoVenta.CANAC_CODIGO = "00"
        listaPuntoVenta.Insert(0, oPuntoVenta)
        listaPuntoVentaSel.Insert(0, oPuntoVenta)

        'Dim listaPuntoVentaTMP As New ArrayList
        Dim vCorner As String
        'listaPuntoVentaTMP.Add(oPuntoVenta)

        With ddlPuntoVenta
            If ddlCanal.SelectedItem.Value = "00" Then
                .DataSource = listaPuntoVentaSel
            Else
            .DataSource = listaPuntoVenta 'listaPuntoVentaTMP
            End If
            .DataValueField = "OVENC_CODIGO"
            .DataTextField = "OVENV_DESCRIPCION"
            .DataBind()
            If valor <> 0 Then
                .SelectedIndex = 1
                vCorner = .SelectedValue.Trim()
            End If
        End With

        strCadenaPuntoVenta = ""
        For Each objPuntoVenta As PuntoVenta In listaPuntoVenta
            strCadenaPuntoVenta = strCadenaPuntoVenta & "|" & objPuntoVenta.OVENC_CODIGO & ";" & objPuntoVenta.OVENV_DESCRIPCION & ";" & objPuntoVenta.TOFIC_CODIGO & ";" & objPuntoVenta.CANAC_CODIGO
        Next objPuntoVenta

        'cargo todos los Puntos de venta en el hidPuntosVentas
        hidPuntosVentas.Value = strCadenaPuntoVenta.Substring(1)

        oConsulta = Nothing
        listaPuntoVenta = Nothing
        'listaPuntoVentaTMP = Nothing
        oPuntoVenta = Nothing

        If valor <> 0 Then
            Dim strScript2 As String = String.Format("cargarListaVendedores('" + vCorner + "');")
            RegisterStartupScript("script", "<script>" & strScript2 & "</script>")
        End If

    End Sub

    Private Sub CargarVendedor()
        Dim oConsulta As SapGeneralNegocios
        Dim ListVendedor As New ArrayList
        Dim iPdv As String = ddlPuntoVenta.SelectedValue.Trim()
        Dim oPuntoVenta As New Vendedor
        Dim listaVendedorTMP As New ArrayList
        Dim listaVendedor As New ArrayList

        If iPdv.Trim() <> "00" Then
            listaVendedor = oConsulta.ConsultarListaVendedores(iPdv)
        End If

        oPuntoVenta.Id_Distribuidor_Vendedor = "00"
        Dim ptoVenta As String = ConfigurationSettings.AppSettings("Seleccionar")
        oPuntoVenta.Nombre = ptoVenta
        listaVendedor.Insert(0, oPuntoVenta)

        listaVendedorTMP.Add(listaVendedor)

        If iPdv.Trim() <> "00" Then
            With ddlVendedorSAP
                .DataSource = listaVendedorTMP
                .DataValueField = "CODIGO"
                .DataTextField = "DESCRIPCION"
                .DataBind()
                .SelectedIndex = 1
            End With
        Else
            With ddlVendedorSAP
                .DataSource = listaVendedorTMP(0)
                .DataValueField = "Id_Distribuidor_Vendedor"
                .DataTextField = "Nombre"
                .DataBind()
            End With
        End If
        listaVendedor = Nothing
        listaVendedorTMP = Nothing
    End Sub

    Private Sub btnPaso1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPaso1.Click

        Try
            Dim pasosVenta() As String = CType(Session("PasosVenta"), String())
            pasosVenta(0) = CheckStr(CheckInt(pasosVenta(0)) + 1)
            Session("PasosVenta") = pasosVenta
            Dim oConsulta As SapGeneralNegocios

            '' Guardar los valores de PuntoVenta y Vendedor en sus respectivos DDL
            Dim listaVendedor As New ArrayList
            Dim listaVendedorTMP As New ArrayList
            Dim oVendedor As New Vendedor
            oVendedor.Id_Distribuidor_Vendedor = "00"
            Dim ptoVenta As String = ConfigurationSettings.AppSettings("Seleccionar")
            oVendedor.Nombre = ptoVenta
            listaVendedor.Insert(0, oVendedor)
            listaVendedorTMP.Add(listaVendedor)

            With ddlVendedorSAP
                .DataSource = listaVendedorTMP(0)
                .DataValueField = "Id_Distribuidor_Vendedor"
                .DataTextField = "Nombre"
                .DataBind()
            End With

            ddlVendedorSAP.SelectedItem.Value = hidVendedorSAP.Value.Split(";"c)(0)
            ddlVendedorSAP.SelectedItem.Text = hidVendedorSAP.Value.Split(";"c)(1)

            ddlPuntoVenta.SelectedItem.Value = hidPuntoVenta.Value.Split(";"c)(0)
            ddlPuntoVenta.SelectedItem.Text = hidPuntoVenta.Value.Split(";"c)(1)

            ' Guardar los datos escogidos a Session
            Dim oCanal As New Canal
            Dim puntosVenta() As String = hidPuntosVentas.Value.Split("|"c)
            For Each punto As String In puntosVenta
                Dim items() As String = punto.Split(";"c)
                If items(0) = ddlPuntoVenta.SelectedValue Then
                    oCanal.CANAC_CODIGO = items(2)
                    Exit For
                End If
            Next
            'oCanal.CANAC_CODIGO = ddlCanal.SelectedItem.Value
            oCanal.CANAV_DESCRIPCION = ddlCanal.SelectedItem.Text
            Session("CanalSelected") = oCanal

            'Aqui
            Dim oPuntoVenta As New PuntoVenta
            oPuntoVenta.OVENC_CODIGO = ddlPuntoVenta.SelectedItem.Value
            oPuntoVenta.OVENV_DESCRIPCION = ddlPuntoVenta.SelectedItem.Text
            oPuntoVenta.CANAC_CODIGO = oCanal.CANAC_CODIGO
            oPuntoVenta.TOFIC_CODIGO = ""
            Session("PuntoVentaSelected") = oPuntoVenta

            'Dim oVendedor As New Vendedor
            oVendedor.Id_Distribuidor_Vendedor = hidVendedorSAP.Value.Split(";"c)(0) 'ddlVendedorSAP.SelectedItem.Value
            oVendedor.Nombre = hidVendedorSAP.Value.Split(";"c)(1) 'ddlVendedorSAP.SelectedItem.Text
            Session("VendedorSelected") = oVendedor

            HabilitarControles(False)
            Refrescar()
        Catch ex As Exception
            HabilitarControles(True)
            hidMsg.Value = String.Format("Error preparando Siguiente Paso. {0}", ex.Message)
        End Try

    End Sub

End Class
