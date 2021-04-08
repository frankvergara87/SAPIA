Option Strict Off
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Common.Funciones

Public Class sisact_registro_dol
    Inherits SisAct_WebBase

    Dim strEstadoServicioHLR As String = ConfigurationSettings.AppSettings("strEstadoWSServicioHLR")
    Private strHLR1User As String
    Private strHLR1Password As String
    Private strHLR1Server As String
    Private strHLR2User As String
    Private strHLR2Password As String
    Private strHLR2Server As String
    Private strHLR3User As String
    Private strHLR3Password As String
    Protected WithEvents hidContactoId As System.Web.UI.HtmlControls.HtmlInputHidden
    Private strHLR3Server As String

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hidAccionConsulta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTest As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents hidUsuarioExt As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtNroTelefono As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents hidNroTelefono As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIN As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIMSI As System.Web.UI.HtmlControls.HtmlInputHidden

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

        Response.Write("<script language='javascript' src='../../script/funciones_sec.js'></script>")
        If Request.QueryString("cu") Is Nothing Then
            Response.Write("<script language=javascript>validarUrl();</script>")
        Else
            Response.Write("<script language=javascript>restringirEventos();</script>")
        End If

        If (CheckStr(Session("codUsuarioSisact")).Equals(String.Empty)) Then
            Dim strUsuarioExt As String = Request.QueryString("cu") & String.Empty
            If Not AccesoUsuario.VerificarUsuario(strUsuarioExt, CurrentUser) Then
                Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
                Response.Redirect(strRutaSite)
                Response.End()
                Exit Sub
            Else
                hidUsuarioExt.Value = strUsuarioExt
            End If
        End If

        If Page.IsPostBack Then

            Dim strNumTlf As String = hidNroTelefono.Value
            If LeerDatosLinea(strNumTlf) Then 'Validar si el número es Prepago
                If EjecutarConsulta_WS_NEWUDB(strNumTlf) Then 'Validar si el número tiene DOL
                    RegisterStartupScript("script", "<script>f_Enviar('" & strNumTlf & "','');</script>")
                End If
            End If
        End If
    End Sub
    Private Sub ValidarIN(ByVal strAcc As String)
        Dim strIN As String = ""
        Try
            If strAcc = "41" Then
                strIN = ConfigurationSettings.AppSettings("strRangoIN41")
            ElseIf strAcc = "42" Then
                strIN = ConfigurationSettings.AppSettings("strRangoIN42")
            ElseIf strAcc = "43" Then
                strIN = ConfigurationSettings.AppSettings("strRangoIN43")
            ElseIf strAcc = "44" Then
                strIN = ConfigurationSettings.AppSettings("strRangoIN44")
            ElseIf strAcc = "45" Then
                strIN = ConfigurationSettings.AppSettings("strRangoIN45")
            Else
                strIN = strAcc
            End If
            hidIN.Value = strIN
        Catch ex As Exception
            Me.ManejaError(ex)
            hidIN.Value = ""
        End Try
    End Sub
    Private Function EjecutarConsulta_WS_NEW(ByVal strTelefono As String) As Boolean

            Dim objResultado As ItemGenerico
            Dim arrResultado As ArrayList
            Dim i As Integer
            Dim strMSGError As String = ""
            Dim strRC As String = ""
            Dim strIMSI As String = ""
            Dim posicion As Integer
            Dim blnSuscriber As Boolean = False
            Dim blnRouting As Boolean = False
            Dim strCodError As String = ""
            Dim strInfComando As String = ""
            Dim strLinea As String = ""
            Dim strRangoIN As String = ConfigurationSettings.AppSettings("strRangoIN")
            Dim arrRangoIn As String() = strRangoIN.Split(";")
            Dim blnRangoIN As Boolean = False

            arrResultado = EjecutaComandoHLRv10(strTelefono, strMSGError, strCodError, strInfComando)
            If strMSGError = "OK" Then
                If arrResultado.Count > 0 Then
                    For i = 0 To arrResultado.Count - 1
                        objResultado = CType(arrResultado(i), ItemGenerico)
                        strLinea = objResultado.Descripcion
                        If InStr(strLinea, "INTERNATIONAL MOBILE SUBSCRIBER IDENTITY") > 0 Then
                            strIMSI = Trim(Mid(strLinea, InStr(1, strLinea, ".") + 3))
                            blnSuscriber = True
                        End If
                        posicion = InStr(1, strLinea, "ROUTING CATEGORY ")
                        If posicion > 0 Then
                            strLinea = Mid(strLinea, posicion + 18, Len(strLinea))
                            strLinea = Mid(strLinea, Len(strLinea) - 3, Len(strLinea) - 1)
                            strRC = Trim(strLinea)
                            strRC = Trim(strRC.Replace(".", ""))
                            blnRouting = True
                        End If
                        If blnSuscriber And blnRouting Then
                            Exit For
                        End If
                    Next

                    ValidarIN(strRC)

                    For i = 0 To arrRangoIn.Length - 1
                        If (arrRangoIn(i).Equals(strRC)) Then
                            blnRangoIN = True
                        End If
                    Next

                    If Not (blnRangoIN) Then
                        RegisterStartupScript("script", "<script>alert('El número de teléfono ya cuenta con Registro DOL');</script>")
                        Return False
                    End If
                    hidRC.Value = strRC
                    hidIMSI.Value = strIMSI

                    obtieneIdCliente(strTelefono)
                    Return True
                End If
            End If
 
        Return False
    End Function

    Private Function EjecutaComandoHLRv10(ByVal strValor As String, _
                                            ByRef strError As String, _
                                            ByRef strCodError As String, _
                                            ByRef strInfComando As String) As ArrayList
        Dim objComandoHLR As New ComandoHLRNegocios
        Dim arrResultado As ArrayList
        Try
            arrResultado = objComandoHLR.HLR_Consulta(strValor, strError, strCodError, strInfComando)
            Return arrResultado
        Catch ex As Exception
            strError = "Error EjecutaComandoHLR(): " & ex.Message
        End Try
    End Function


    Private Function EjecutarConsulta_WS_NEWUDB(ByVal strTelefono As String) As Boolean

        Try
            Dim strMSGError As String = String.Empty
            Dim strCodError As String = String.Empty
            Dim strRC As String = String.Empty
            Dim strIMSI As String = String.Empty
            Dim strRangoIN As String = ConfigurationSettings.AppSettings("strRangoIN")
            Dim arrRangoIn As String() = strRangoIN.Split(";")
            Dim blnRangoIN As Boolean = False
            Dim i As Integer

            Dim objItemGenerico As ItemGenerico
            objItemGenerico = EjecutaComandoUDB(strTelefono, strMSGError, strCodError)

            If strCodError = "0" Then
                strIMSI = objItemGenerico.Codigo
                strRC = objItemGenerico.Codigo2

                ValidarIN(strRC)

                For i = 0 To arrRangoIn.Length - 1
                    If (arrRangoIn(i).Equals(strRC)) Then
                        blnRangoIN = True
                    End If
                Next

                If Not (blnRangoIN) Then
                    RegisterStartupScript("script", "<script>alert('El número de teléfono ya cuenta con Registro DOL');</script>")
                    Return False
                End If
                hidRC.Value = strRC
                hidIMSI.Value = strIMSI

                obtieneIdCliente(strTelefono)
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return False
    End Function


    Private Function EjecutaComandoUDB(ByVal strValor As String, _
                                            ByRef strError As String, _
                                            ByRef strCodError As String) As ItemGenerico
        Dim objComandoUDB As New ComandoHLRNegocios
        Dim objItemGenerico As ItemGenerico

        Try
            objItemGenerico = objComandoUDB.UDB_Consulta(strValor, strError, strCodError)
            Return objItemGenerico
        Catch ex As Exception
            strError = "Error EjecutaComandoUDB(): " & ex.Message
        End Try
    End Function


    Private Function LeerDatosLinea(ByVal nroLinea As String) As Boolean
        Dim oPrepagoNegocios As New DatosPrepagoNegocios

        Dim providerIdPrepago As String = ConfigurationSettings.AppSettings("ProviderIdPrepago").ToString()
        Dim providerIdControl As String = ConfigurationSettings.AppSettings("ProviderIdControl").ToString()
        Dim mensajeError As String = ""
        Dim datosLinea As ItemGenerico = Nothing
        Dim strMensaje As String = ""

        datosLinea = oPrepagoNegocios.LeerDatosPrepago(nroLinea, providerIdPrepago, providerIdControl, mensajeError)
        If datosLinea Is Nothing Then
            strMensaje = mensajeError
        Else
            If Not datosLinea.estado.ToUpper().Equals("P") Then
                strMensaje = "El número de teléfono no es Prepago."
            End If
        End If
        If strMensaje <> "" Then
            RegisterStartupScript("script", "<script>alert('" & strMensaje & "');</script>")
            Return False
        End If
        Return True
    End Function

    Sub obtieneIdCliente(ByVal strTelefono As String)
        Dim objCliente As New ClienteNegocio
        Dim eCliente As Cliente
        eCliente = objCliente.ObtenerCliente(strTelefono, "", "", "1", "", "")
        hidContactoId.Value = eCliente.OBJID_CONTACTO
    End Sub
End Class
