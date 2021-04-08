Option Strict Off

Imports System.DirectoryServices
Imports Claro.SisAct.Negocios

Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Common
Imports Claro.SisAct.Web.Funciones
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.DateTime
Imports System.TimeSpan


Public Class sisact_validar
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblTitulo As System.Web.UI.WebControls.Label
    Protected WithEvents txtUsuario As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPass As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPagina As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMonto As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidUnidad As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoValidacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPerfiles As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidtipoMensaje As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOpcion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDescripcionProceso As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidConcepto As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidModalidad As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidUserValidator As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidAccionDetEnt As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnValidar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnCancelar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidTelefono As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLogin As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCO As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidVeces As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents hidMensaje As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPerfilesAValidar As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidperfil As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents HidVerificar As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidflgCerrarSoles As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Dim oLog As New SISACT_Log
    Dim nameFile As String = ConfigurationSettings.AppSettings("constNameLogRepPostpago")
    Dim oFile As String = oLog.Log_CrearNombreArchivo(nameFile)
    Dim strIdentifyLog As String = "AUTENTIFICAR USUARIO"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Response.Write("<script language='javascript' src='../../script/funciones_sec.js'></script>")

        oLog.Log_WriteLog(oFile, strIdentifyLog & "- validar usuario codUsuarioSisact:" & Session("codUsuarioSisact"))
        oLog.Log_WriteLog(oFile, strIdentifyLog & "- validar usuario CodVendedorSAP:" & Session("CodVendedorSAP"))

        If Session("codUsuarioSisact") Is Nothing Or Session("CodVendedorSAP") Is Nothing Then
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- error usuario")
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        End If

        If Request.QueryString("v_pag") Is Nothing Or Request.QueryString("v_pag") = "" Then
            Response.Write("<script language='javascript'>window.close();</script>") 'parent.top.location.href = '../../inicio.htm'
        End If

        If Not IsPostBack Then
            hidPagina.Value = Trim(Request.QueryString("v_pag"))
            hidOpcion.Value = Trim(Request.QueryString("v_opcion"))
            hidMensaje.Value = Request.QueryString("v_mensaje")
            hidMonto.Value = Trim(Request.QueryString("v_monto"))
            hidDescripcionProceso.Value = Trim(Request.QueryString("v_descripcion"))
            txtPass.Attributes.Add("onkeypress", "return FC_Enter(event)")

            preValidacion()

            If Trim(Request.QueryString("v_tipotx")) = "L" Then
                lblTitulo.Text = "AUTORIZACIÓN LÍNEA"
            ElseIf Trim(Request.QueryString("v_tipotx")) = "E" Then
                lblTitulo.Text = "AUTORIZACIÓN DE DESCUENTO"
            ElseIf Trim(Request.QueryString("v_tipotx")) = "M" Then
                lblTitulo.Text = "AUTORIZACIÓN"
            End If
        End If

        If Me.hidAccion.Value = "V" Then
            Me.hidAccion.Value = ""
            Validar()
        End If
    End Sub

    Private Function preValidacion() As Boolean

        If (Trim(hidPagina.Value) = "1") Then

            Dim strTipo As String = ConfigurationSettings.AppSettings("constTipoNivelSoles")
            Dim vMonto As Double = Double.Parse(hidMonto.Value)
            Dim sPerfilDeAutorizacion As String = ""
            Dim strPerfilCodigo As String
            Dim obj As New NivelAprobacionNegocio
            Dim strScript As String
            Dim listPerfiles As New ArrayList
            hidflgCerrarSoles.Value = "1"

            Try
                listPerfiles = obj.ConsultarPerfilesMonto(strTipo, vMonto)
                If listPerfiles.Count > 0 Then
                    lblMensaje.Text = "Se requiere la autorización del Jefe/Supervisor"
                    Session("PerfilesMonto") = listPerfiles
                        Return True
                Else
                    hidAccion.Value = "E_MONTO_INACEPTABLE"
                    Return False
                End If
            Catch ex As Exception
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & ex.Message)
            End Try

        ElseIf (Trim(hidPagina.Value) = "2") Then

            Dim strTipo As String = ConfigurationSettings.AppSettings("constTipoNivelMeses")
            Dim vMonto As Integer = Integer.Parse(hidMonto.Value)

            Dim sPerfilDeAutorizacion As String = ""
            Dim strPerfilCodigo As String

            Dim obj As New NivelAprobacionNegocio

            Dim strScript As String
            Dim listPerfiles As New ArrayList
            hidflgCerrarSoles.Value = "-1"

            Try
                listPerfiles = obj.ConsultarPerfilesMontoMeses(strTipo, vMonto)
                If listPerfiles.Count > 0 Then
                    lblMensaje.Text = "Se requiere la autorización del Jefe/Supervisor"
                    Session("PerfilesMonto") = listPerfiles
                        Return True
                    'SD820360 - INICIO
                ElseIf strTipo = ConfigurationSettings.AppSettings("constTipoNivelMeses") Then
                    lblMensaje.Text = "Se requiere la autorización del Jefe/Supervisor"
                    Session("PerfilesMonto") = listPerfiles
                    Return True
                    'SD820360 - FIN
                Else
                    hidAccion.Value = "E_MESES_INACEPTABLE"
                    Return False
                End If
            Catch ex As Exception
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & ex.Message)
            End Try
        End If
    End Function

    Private Sub Validar()
        Try
            oLog.Log_WriteLog(oFile, strIdentifyLog & "  *** Inicio  Validar() " & " ")
            Dim blnCorrecto As Boolean = False
            Dim sUsuario As String = Trim(txtUsuario.Text)
            Dim sContrasena As String = Trim(txtPass.Text)
            Dim sPagina As String = Trim(hidPagina.Value)
            Dim sMonto As String = Trim(hidMonto.Value)
            Dim resultado As Boolean = False
            Dim sCodPerfil As String = ""
            'FAGP - SD820360 - Inicio
            Dim oNivelAprovacion As New NivelAprobacionNegocio
            Dim ListPerfil As ArrayList = CType(Session("PerfilesMonto"), ArrayList)
            Dim vMonto As Double = Double.Parse(hidMonto.Value)
            'FAGP - SD820360 - Fin

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- sUsuario " & sUsuario)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- sContrasena " & sContrasena)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- sPagina " & sPagina)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- sMonto " & sMonto)

            'Para:  Renovación de Equipo Postpago CAC - Autorizar Descuento
            If sPagina = "1" Then

                blnCorrecto = False

                sCodPerfil = ConsultarPerfiles(sUsuario, sContrasena, hidPerfilesAValidar.Value)
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- sCodPerfil " & sCodPerfil)
                If sCodPerfil <> "-1" Then
                    blnCorrecto = True
                    Session("UsuarioValidadorDescuento") = Trim(txtUsuario.Text)
                    oLog.Log_WriteLog(oFile, strIdentifyLog & "- UsuarioValidadorDescuento " & Convert.ToString(Session("UsuarioValidadorDescuento")))
                End If

                If blnCorrecto Then
                    hidAccion.Value = "G"
                Else
                    hidAccion.Value = "F"
                End If
            ElseIf sPagina = "2" Then
                'Para:  Renovación de Equipo Postpago CAC - Autorizar Renovación Adelantada

                Dim resultadoV As Boolean = IsAuthenticated(sUsuario, sContrasena)
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- resultadoV " & resultadoV)
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- hidPerfilesAValidar " & hidPerfilesAValidar.Value)

                blnCorrecto = False

                If resultadoV Then
                sCodPerfil = oNivelAprovacion.ValidarPerfilesMeses(sUsuario, sContrasena, hidPerfilesAValidar.Value, vMonto)
                    oLog.Log_WriteLog(oFile, strIdentifyLog & "- sCodPerfil " & sCodPerfil)
                If sCodPerfil <> "-1" Then
                    blnCorrecto = True
                    Session("UsuarioValidadorDescuento") = Trim(txtUsuario.Text)
                End If

                    oLog.Log_WriteLog(oFile, strIdentifyLog & "- blnCorrecto " & blnCorrecto.ToString())

                If blnCorrecto Then
                    hidAccion.Value = "G"
                Else
                    hidAccion.Value = "F"
                End If


                Else
                    hidAccion.Value = "F"

            End If

            End If
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- hidAccion " & hidAccion.Value)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "  *** FIN A Validar() **** " & " ")
        Catch ex As Exception
            hidAccion.Value = "E"
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- hidAccion " & hidAccion.Value)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "  *** Fin a Validar() **** " & " ")
        End Try
    End Sub

    Private Function IsAuthenticated(ByVal vUsuario As String, ByVal vClave As String) As Boolean

        oLog.Log_WriteLog(oFile, strIdentifyLog & "  *** Inicio a IsAuthenticated() **** " & " ")

        Dim strDominio As String = ConfigurationSettings.AppSettings("DominioLDAP")
        oLog.Log_WriteLog(oFile, strIdentifyLog & " - strDominio " & strDominio)
        Dim entry As New DirectoryEntry(strDominio, vUsuario, vClave)

        oLog.Log_WriteLog(oFile, strIdentifyLog & " - strDominio " & strDominio)
        oLog.Log_WriteLog(oFile, strIdentifyLog & " - vUsuario " & vUsuario)
        oLog.Log_WriteLog(oFile, strIdentifyLog & " - vClave " & vClave)

        Try
            Dim obj As Object = entry.NativeObject()
            Dim search As New DirectorySearcher(entry)
            search.Filter = "(SAMAccountName=" + vUsuario + ")"
            search.PropertiesToLoad.Add("cn")
            Dim resul As SearchResult
            resul = search.FindOne()
            If (resul Is Nothing) Then
                oLog.Log_WriteLog(oFile, strIdentifyLog & "  *** resul Is Nothing **** " & " ")
                oLog.Log_WriteLog(oFile, strIdentifyLog & "  *** Fin a IsAuthenticated() **** " & " ")
                Return False
            End If
            oLog.Log_WriteLog(oFile, strIdentifyLog & "  *** resul Not Is Nothing **** " & " ")
            oLog.Log_WriteLog(oFile, strIdentifyLog & "  *** Fin a IsAuthenticated() **** " & " ")
            Return True
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, strIdentifyLog & "  *** Exception **** " & ex.ToString())
            oLog.Log_WriteLog(oFile, strIdentifyLog & "  *** Fin a IsAuthenticated() **** " & " ")
            Return False
        End Try
    End Function

    Private Function ConsultarPerfiles(ByVal pUsuario As String, ByVal pClave As String, ByVal pCadenaPerfiles As String) As String

        Dim ListPerfil As ArrayList = CType(Session("PerfilesMonto"), ArrayList)

        oLog.Log_WriteLog(oFile, strIdentifyLog & "- pUsuario " & pUsuario)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "- pCadenaPerfiles a Verificar  => " & Funciones.CheckStr(ListPerfil.Count))

            Dim resultado As Boolean = IsAuthenticated(pUsuario, pClave)
            Dim strCodPerfil As String = ""
            Dim arrPerfiles As String() = Trim(pCadenaPerfiles).Split(","c) ' cadena de perfiles jerárquicos configurada en el SIACPOConfig.config
            Dim sArrayPerfiles As String()
            Dim strcodAplicacion As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
            Dim sPerfilAutorizado As String = ""

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- IsAuthenticated -resultado :" & resultado.ToString)

            If resultado = True Then ' Or resultado = False Then
                resultado = False

                oLog.Log_WriteLog(oFile, strIdentifyLog & "- Inicio -ConsulSeguridad ")
                Dim cs As New Claro.SisAct.Negocios.ConsulSeguridad
                Dim idTrans As String
                Dim errorMsg As String
                Dim CodError As String
                Dim codApp As Long = Integer.Parse(ConfigurationSettings.AppSettings("CodigoAplicacion"))
                Dim ipApp As String = ConfigurationSettings.AppSettings("strWebIpCod")
                Dim nomApp As String = ConfigurationSettings.AppSettings("NombreAplicacion")
                Dim lista As ArrayList

                oLog.Log_WriteLog(oFile, strIdentifyLog & "- Inicio -verificaUsuario ")

                oLog.Log_WriteLog(oFile, strIdentifyLog & "- idTrans " & idTrans)
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- ipApp " & ipApp)
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- nomApp " & nomApp)
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- pUsuario " & pUsuario)
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- codApp " & codApp)


                lista = cs.verificaUsuario(idTrans, ipApp, nomApp, Trim(pUsuario), codApp, errorMsg, CodError)

                oLog.Log_WriteLog(oFile, strIdentifyLog & "- errorMsg =>" & errorMsg)
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- CodError =>" & CodError)
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- Fin -verificaUsuario ")
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- lista cantidad :  " & lista.Count().ToString)
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- Fin -ConsulSeguridad ")

                If lista.Count() > 0 Then
                    Dim item As New Claro.SisAct.Entidades.ConsulSeguridad
                    For i As Integer = 0 To lista.Count - 1
                        item = CType(lista.Item(i), Claro.SisAct.Entidades.ConsulSeguridad)
                        strCodPerfil = strCodPerfil & item.PERFCCOD & ","
                    Next
                Else
                    strCodPerfil = ""
                End If

                If strCodPerfil = "" Then
                    sPerfilAutorizado = "-1"
                    Return sPerfilAutorizado
                End If

                strCodPerfil = strCodPerfil.Substring(0, strCodPerfil.Length - 1)

                oLog.Log_WriteLog(oFile, strIdentifyLog & "- strCodPerfil " & strCodPerfil)

                If strCodPerfil.Length > 0 Then
                    sArrayPerfiles = strCodPerfil.Split(","c)
                    For Each sPerfilJerarquico As ItemGenerico In ListPerfil ' cada perfil en la cadena de perfiles jerárquicos configurada en el SIACPOConfig.config
                        Dim strPerfArray As String() = Trim(sPerfilJerarquico.Descripcion2).Split(","c)
                        For Each sPerOri As String In strPerfArray
                        For Each sPerfil As String In sArrayPerfiles ' cada perfil que tiene el usuario que ha puesto su clave
                                If sPerOri = sPerfil Then
                                    sPerfilAutorizado = sPerOri
                                    Exit For
                                End If
                            Next
                            If sPerfilAutorizado <> "" Then
                                Exit For
                            End If
                        Next
                        If sPerfilAutorizado <> "" Then
                            Exit For
                        End If
                    Next

                    oLog.Log_WriteLog(oFile, strIdentifyLog & "- sPerfilAutorizado " & sPerfilAutorizado)

                    If sPerfilAutorizado = "" Then
                        sPerfilAutorizado = "-1"
                    End If
                Else
                    sPerfilAutorizado = "-1"
                End If

                Return sPerfilAutorizado
            Else
                Return "-1"
            End If

    End Function
End Class
