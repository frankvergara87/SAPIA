Option Strict Off
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports System.Data.OleDb

Public Class ctr_Menu
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Dim listaPortal As ArrayList
    Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
    Dim codAplicacion As Integer

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim ImagenIzq As String ', lRsPerfil, wObjPerf, objMenu, RutaCompleta, , nAux as 
            Dim FlagHijos As String
            Dim strMenu As String
            'Dim sqlConsulta4, sqlConsulta3, sqlConsulta2, sqlConsulta1 As String
            'Dim rsConsulta4, rsConsulta3, rsConsulta2, rsConsulta1
            'Dim cmConsulta3, cmConsulta2
            'Dim cmConsulta4, cmConsulta1

            Dim cont, cont2, cont3, cont4 As Integer
            Dim ContadorNivel1, ContadorNivel2, ContadorNivel3, ContadorNivel4 As Integer
            'Introducir aquí el código de usuario para inicializar la página
            Dim strcad As String
            codAplicacion = ConfigurationSettings.AppSettings("CodigoAplicacion")
            cargarPortal()

            Session("flag_menu_usuario") = CInt(Request.Form.Get("flag_menu_usuario"))
            Session("menu_usuario") = Request.Form.Get("menu_usuario")

            cont = 1
            cont2 = 1
            cont3 = 1
            cont4 = 1

            ContadorNivel1 = 0
            ContadorNivel2 = 0
            ContadorNivel3 = 0
            ContadorNivel4 = 0
            ImagenIzq = "" '"<img src='" & strRutaSite & "/images/mnu_cuadrado.gif' border=0> "

            Page.Response.Write("<table height='100%' width='100%'>" & Chr(13) & Chr(10))
            Page.Response.Write("<tr>" & Chr(13) & Chr(10))
            Page.Response.Write("<td width='170' valign='top'>" & Chr(13) & Chr(10))

            strcad = "<script language='JavaScript1.2'>" & Chr(13) & Chr(10)
            strcad = strcad & "if(window.event + '' == 'undefined') event = null;" & Chr(13) & Chr(10)
            strcad = strcad & "function HM_f_PopUp(){return false};" & Chr(13) & Chr(10)

            strcad = strcad & "function HM_f_PopDown(){return false};" & Chr(13) & Chr(10)
            strcad = strcad & "popUp = HM_f_PopUp;" & Chr(13) & Chr(10)
            strcad = strcad & "popDown = HM_f_PopDown;" & Chr(13) & Chr(10) & Chr(13) & Chr(10)

            strcad = strcad & "HM_PG_MenuWidth = 170;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_FontFamily = 'Verdana';" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_FontSize = 7.5;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_FontBold = 1;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_FontItalic = 0;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_FontColor = 'white';" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_FontColorOver = 'white';" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_ItemPadding = 3;" & Chr(13) & Chr(10) & Chr(13) & Chr(10)

            strcad = strcad & "HM_PG_BorderWidth = 1;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_BorderColor = 'black';" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_BorderStyle = 'solid';" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_SeparatorSize = 1;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_ImageSrc = '" & strRutaSite & "/images/mnu_flecha_abajo.gif';" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_ImageSrcLeft = '" & strRutaSite & "/include/mnu_flecha_abajo.gif';" & Chr(13) & Chr(10) & Chr(13) & Chr(10)

            strcad = strcad & "HM_PG_ImageSize = 7;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_ImageHorizSpace = 0;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_ImageVertSpace = 3;" & Chr(13) & Chr(10) & Chr(13) & Chr(10)

            strcad = strcad & "HM_PG_KeepHilite = true; " & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_ClickStart = 0;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_ClickKill = false;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_ChildOverlap = 1; //adentro" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_ChildOffset = 0; //arriba" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_ChildPerCentOver = null;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_TopSecondsVisible = .3;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_StatusDisplayBuild =0;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_StatusDisplayLink = 0;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_UponDisplay = null;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_UponHide = null;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_RightToLeft = false;" & Chr(13) & Chr(10) & Chr(13) & Chr(10)

            strcad = strcad & "HM_PG_ShowLinkCursor = 1;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_PG_NSFontOver = true;" & Chr(13) & Chr(10) & Chr(13) & Chr(10)

            strcad = strcad & "var iWidth= 175;" & Chr(13) & Chr(10)
            strcad = strcad & "var iTopPos= 50;" & Chr(13) & Chr(10)
            strcad = strcad & "var iLeftPos= 56;" & Chr(13) & Chr(10)
            strcad = strcad & "var sFontColor= '#FFFFFF';" & Chr(13) & Chr(10)
            strcad = strcad & "var sFontHighColor= '#FFFFFF';" & Chr(13) & Chr(10)
            strcad = strcad & "var sBackgroundColor= '#3767b6';" & Chr(13) & Chr(10)
            strcad = strcad & "var sBackgroundColor_1= '#2989ae';" & Chr(13) & Chr(10)
            strcad = strcad & "var sBackgroundHighColor= '#00007b';" & Chr(13) & Chr(10)
            strcad = strcad & "var sTableBorderColor= '#EFEFEF';" & Chr(13) & Chr(10)
            strcad = strcad & "var sLineColor= '#ffffff';" & Chr(13) & Chr(10) & Chr(13) & Chr(10)

            strcad = strcad & "var intRows= 13;" & Chr(13) & Chr(10)
            strcad = strcad & "var intHeight= 23.9;" & Chr(13) & Chr(10)
            strcad = strcad & "var iBlankspace= 14;" & Chr(13) & Chr(10)
            strcad = strcad & "//Fin de Variables" & Chr(13) & Chr(10) & Chr(13) & Chr(10)

            strcad = strcad & "HM_DOM = (document.getElementById) ? true : false;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_NS4 = (document.layers) ? true : false;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_IE = (document.all) ? true : false;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_IE4 = HM_IE && !HM_DOM;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_Mac = (navigator.appVersion.indexOf('Mac') != -1);" & Chr(13) & Chr(10)
            strcad = strcad & "HM_IE4M = HM_IE4 && HM_Mac;" & Chr(13) & Chr(10)
            strcad = strcad & "HM_IsMenu = (HM_DOM || HM_NS4 || (HM_IE4 && !HM_IE4M));" & Chr(13) & Chr(10) & Chr(13) & Chr(10)

            strcad = strcad & "HM_BrowserString = HM_NS4 ? 'NS4' : HM_DOM ? 'DOM' : 'IE4';" & Chr(13) & Chr(10) & Chr(13) & Chr(10)

            strcad = strcad & "if(window.event + '' == 'undefined') event = null;" & Chr(13) & Chr(10)
            strcad = strcad & "function HM_f_PopUp(){return false};" & Chr(13) & Chr(10)
            strcad = strcad & "function HM_f_PopDown(){return false};" & Chr(13) & Chr(10)
            strcad = strcad & "popUp = HM_f_PopUp;" & Chr(13) & Chr(10)
            strcad = strcad & "popDown = HM_f_PopDown;" & Chr(13) & Chr(10) & Chr(13) & Chr(10)
            strcad = strcad & "if(HM_IsMenu) {" & Chr(13) & Chr(10)
            strcad = strcad & "	//Inicio de Opciones" & Chr(13) & Chr(10)
            '1,	0, 0, 1, 1, 1,
            strcad = strcad & "	HM_Array1= [ [iWidth,  iLeftPos, iTopPos, sFontColor, sFontHighColor, sBackgroundColor, sBackgroundHighColor, sTableBorderColor, sLineColor, 1,	1, 0, 1, 1, 1, 'null', 'null'," & Chr(13) & Chr(10)
            strcad = strcad & ", sBackgroundColor_1	]," & Chr(13) & Chr(10)


            '''Inicio Componente
            Dim objAcceso, objAcceso2, objAcceso3, objAcceso4 As Object
            Dim rsConsulta1, rsConsulta2, rsConsulta3, rsConsulta4 As Object
            Dim dsRecord As New DataSet
            Dim dsRecord2 As New DataSet
            Dim dsRecord3 As New DataSet
            Dim dsRecord4 As New DataSet
            Dim daRecord As New OleDbDataAdapter
            Dim daRecord2 As New OleDbDataAdapter
            Dim daRecord3 As New OleDbDataAdapter
            Dim daRecord4 As New OleDbDataAdapter

            objAcceso = CreateObject("Segu_DB.Acceso")
            rsConsulta1 = CreateObject("ADODB.Recordset")
            rsConsulta1 = objAcceso.GetOpcionesMenu(Trim(Session("CodUsuario")), codAplicacion, 2, 0)
            objAcceso = Nothing

            daRecord.MissingSchemaAction = MissingSchemaAction.AddWithKey
            daRecord.Fill(dsRecord, rsConsulta1, "Menu")
            strMenu = ""
            Dim ArrOpcionN1(100), ArrOpcionN2(100), ArrOpcionN3(100), ArrOpcionN4(100) As String
            Dim ArrHijosN1(100), ArrHijosN2(100), ArrHijosN3(100), ArrHijosN4(100) As String
            Dim contNivel1, contNivel2, contNivel3, contNivel4 As Int16
            Dim strPagina As String

            'Inicio Nivel 1******************************************************************
            If Not rsConsulta1 Is Nothing Then
                If dsRecord.Tables(0).Rows.Count > 0 Then
                    For contNivel1 = 0 To dsRecord.Tables(0).Rows.Count - 1
                        strPagina = CheckStr(dsRecord.Tables(0).Rows(contNivel1).Item("OPCIC_NOMPAG"))
                        If Trim(strPagina & " ") <> "" Then
                            FlagHijos = "0"
                        Else
                            FlagHijos = "1"
                        End If
                        strMenu = strMenu & "[""" & dsRecord.Tables(0).Rows(contNivel1).Item("OPCIC_DES") & """,""" & getPagina(strPagina, dsRecord.Tables(0).Rows(contNivel1).Item("OPCIC_COD")) & """,1,0," & FlagHijos & "]" & vbCrLf
                        strMenu = strMenu & " , " & vbCrLf
                        ArrOpcionN1(contNivel1) = dsRecord.Tables(0).Rows(contNivel1).Item("OPCIC_COD")
                        ArrHijosN1(contNivel1) = FlagHijos
                    Next
                End If

                strMenu = strMenu.Substring(0, strMenu.Length - 4)
                strMenu = strMenu & "]" & vbCrLf
            End If

            'Inicio Nivel 2******************************************************************
            For cont = 0 To contNivel1 - 1
                contNivel2 = 0

                objAcceso2 = CreateObject("Segu_DB.Acceso")
                rsConsulta2 = CreateObject("ADODB.Recordset")
                rsConsulta2 = objAcceso2.GetOpcionesMenu(Trim(Session("CodUsuario")), codAplicacion, 3, ArrOpcionN1(cont))
                daRecord2 = New OleDbDataAdapter
                dsRecord2 = New DataSet
                daRecord2.MissingSchemaAction = MissingSchemaAction.AddWithKey
                daRecord2.Fill(dsRecord2, rsConsulta2, "Menu")

                If ArrHijosN1(cont) = "1" Then
                    strMenu = strMenu & "HM_Array1_" & (cont + 1) & " = [" & vbCrLf
                    strMenu = strMenu & vbTab & "[]," & vbCrLf

                    For contNivel2 = 0 To dsRecord2.Tables(0).Rows.Count - 1
                        strPagina = CheckStr(dsRecord2.Tables(0).Rows(contNivel2).Item("OPCIC_NOMPAG"))
                        If Trim(strPagina & " ") <> "" Then
                            FlagHijos = "0"
                        Else
                            FlagHijos = "1"
                        End If
                        strMenu = strMenu & "[""" & dsRecord2.Tables(0).Rows(contNivel2).Item("OPCIC_DES") & """,""" & getPagina(strPagina, dsRecord2.Tables(0).Rows(contNivel2).Item("OPCIC_COD")) & """,1,0," & FlagHijos & "]" & vbCrLf
                        ArrOpcionN2(contNivel2) = dsRecord2.Tables(0).Rows(contNivel2).Item("OPCIC_COD")
                        ArrHijosN2(contNivel2) = FlagHijos

                        strMenu = strMenu & vbCrLf
                        strMenu = strMenu & " , " & vbCrLf
                    Next
                    strMenu = strMenu.Substring(0, strMenu.Length - 4)

                    strMenu = strMenu & "]" & vbCrLf

                    'Inicio Nivel 3******************************************************************

                    For cont2 = 0 To contNivel2
                        contNivel3 = 0

                        objAcceso3 = CreateObject("Segu_DB.Acceso")
                        rsConsulta3 = CreateObject("ADODB.Recordset")
                        rsConsulta3 = objAcceso3.GetOpcionesMenu(Trim(Session("CodUsuario")), codAplicacion, 4, ArrOpcionN2(cont2))
                        daRecord3 = New OleDbDataAdapter
                        dsRecord3 = New DataSet
                        daRecord3.MissingSchemaAction = MissingSchemaAction.AddWithKey
                        daRecord3.Fill(dsRecord3, rsConsulta3, "Menu")

                        If ArrHijosN2(cont2) = "1" Then
                            strMenu = strMenu & "HM_Array1_" & (cont + 1) & "_" & (cont2 + 1) & " = [" & vbCrLf
                            strMenu = strMenu & vbTab & "[]," & vbCrLf

                            For contNivel3 = 0 To dsRecord3.Tables(0).Rows.Count - 1
                                strPagina = CheckStr(dsRecord3.Tables(0).Rows(contNivel3).Item("OPCIC_NOMPAG"))
                                If Trim(strPagina & " ") <> "" Then
                                    FlagHijos = "0"
                                Else
                                    FlagHijos = "1"
                                End If
                                strMenu = strMenu & "[""" & dsRecord3.Tables(0).Rows(contNivel3).Item("OPCIC_DES") & """,""" & getPagina(strPagina, dsRecord3.Tables(0).Rows(contNivel3).Item("OPCIC_COD")) & """,1,0," & FlagHijos & "]" & vbCrLf
                                ArrOpcionN3(contNivel3) = dsRecord3.Tables(0).Rows(contNivel3).Item("OPCIC_COD")
                                ArrHijosN3(contNivel3) = FlagHijos

                                strMenu = strMenu & vbCrLf
                                strMenu = strMenu & " , " & vbCrLf
                            Next
                            strMenu = strMenu.Substring(0, strMenu.Length - 4)

                            strMenu = strMenu & "]" & vbCrLf
                        End If

                        'Inicio Nivel 4******************************************************************
                        For cont3 = 1 To contNivel3
                            contNivel3 = 0

                            objAcceso4 = CreateObject("Segu_DB.Acceso")
                            rsConsulta4 = CreateObject("ADODB.Recordset")
                            rsConsulta4 = objAcceso4.GetOpcionesMenu(Trim(Session("CodUsuario")), codAplicacion, 5, ArrOpcionN3(cont3))
                            daRecord4 = New OleDbDataAdapter
                            dsRecord4 = New DataSet
                            daRecord4.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            daRecord4.Fill(dsRecord4, rsConsulta4, "Menu")

                            If ArrHijosN3(cont3) = "1" Then
                                strMenu = strMenu & "HM_Array1_" & (cont + 1) & "_" & (cont2 + 1) & "_" & (cont3 + 1) & " = [" & vbCrLf
                                strMenu = strMenu & "[]," & vbCrLf

                                For contNivel4 = 0 To dsRecord4.Tables(0).Rows.Count - 1
                                    strPagina = CheckStr(dsRecord4.Tables(0).Rows(contNivel4).Item("OPCIC_NOMPAG"))
                                    If Trim(strPagina & " ") <> "" Then
                                        FlagHijos = "0"
                                    Else
                                        FlagHijos = "1"
                                    End If
                                    strMenu = strMenu & "[""" & dsRecord4.Tables(0).Rows(contNivel4).Item("OPCIC_DES") & """,""" & getPagina(strPagina, dsRecord4.Tables(0).Rows(contNivel4).Item("OPCIC_COD")) & """,1,0," & FlagHijos & "]" & vbCrLf
                                    ArrOpcionN4(contNivel4) = dsRecord4.Tables(0).Rows(contNivel4).Item("OPCIC_COD")
                                    ArrHijosN4(contNivel4) = FlagHijos

                                    strMenu = strMenu & vbCrLf
                                    strMenu = strMenu & " , " & vbCrLf
                                Next
                                strMenu = strMenu.Substring(0, strMenu.Length - 4)

                                strMenu = strMenu & "]" & vbCrLf
                            End If
                        Next
                    Next
                End If
            Next

            '''Fin Componente

            Session("flag_menu_usuario") = 1
            Session("menu_usuario") = Replace(strMenu, Chr(34), Chr(39))

            strcad += Replace(strMenu, Chr(39), Chr(34))
            strcad += "document.write(" & Chr(34) & "<SCRIPT LANGUAGE='JavaScript1.2' SRC='" & strRutaSite & "/include/incScript" & Chr(34) & "+ HM_BrowserString + " & Chr(34) & ".js' TYPE='text/javascript'><\/SCRIPT>" & Chr(34) & ");"
            strcad += "}" & Chr(10) & Chr(13) & "</SCRIPT>" & Chr(10) & Chr(13)
            strcad += "</td>" & Chr(10) & Chr(13)
            strcad += "	</tr>" & Chr(10) & Chr(13)
            strcad += "</table>" & Chr(10) & Chr(13)
            Page.Response.Write(strcad)
        Catch ex As Exception
            Session("Error") = ex.Message
            Session("DetalleError") = ex.StackTrace
            'Response.Redirect(PRO_Constantes.PaginaError)
        End Try
    End Sub

    Private Sub cargarPortal()
        Dim oTabla As New TablaNegocio
        listaPortal = oTabla.Listar_Portal()
    End Sub

    Private Function getPortal(ByVal strPagina As String) As String
        Dim codPerfil As Int16
        Dim pag As String = strPagina.Substring(strPagina.IndexOf("?") + 1)
        Dim arr1 As Array
        If strPagina.IndexOf("&") <> -1 Then
            arr1 = Split(pag, "&")
            Dim cont As Int16
            Dim arr2 As Array
            For cont = 0 To arr1.Length - 1
                arr2 = Split(arr1(cont), "=")
                If arr2(0) = "id_portal" Then
                    codPerfil = arr2(1)
                    Exit For
                End If
            Next
        Else
            arr1 = Split(pag, "=")
            codPerfil = arr1(1)
        End If

        If Not listaPortal Is Nothing Then
            For Each item As ItemGenerico In listaPortal
                If item.Codigo = codPerfil Then
                    Return item.Descripcion2
                End If
            Next
        End If

        Return strRutaSite
    End Function

    Private Function getPagina(ByVal strPagina As String, ByVal opc_cod As String) As String
        If strPagina <> "" Then
            Dim strAcceso As String = "cu=" & Session("codUsuario") & "&co=" & opc_cod & "&ca=" & codAplicacion & "&cp=" & Session("codPerfil")

            Dim strPagina2 As String = strRutaSite
            If InStr(1, Trim(strPagina), "?") <> 0 Then

                If InStr(1, Trim(strPagina), "id_portal") Then
                    Dim codPortal As Int16
                    Dim pag As String = strPagina.Substring(strPagina.IndexOf("?") + 1)

                    Dim arr1 As Array
                    If strPagina.IndexOf("&") <> -1 Then
                        arr1 = Split(pag, "&")
                        Dim cont As Int16
                        Dim arr2 As Array
                        For cont = 0 To arr1.Length - 1
                            arr2 = Split(arr1(cont), "=")
                            If arr2(0) = "id_portal" Then
                                codPortal = arr2(1)
                                Exit For
                            End If
                        Next
                    Else
                        arr1 = Split(pag, "=")
                        codPortal = arr1(1)
                    End If

                    If Not listaPortal Is Nothing Then
                        For Each item As ItemGenerico In listaPortal
                            If item.Codigo = codPortal Then
                                strPagina2 = item.Descripcion2
                            End If
                        Next
                    End If
                End If
                strPagina2 = strPagina2 & strPagina & "&" & strAcceso
            Else
                strPagina2 = strPagina2 & strPagina & "?" & strAcceso
            End If
            strPagina2 = Replace(strPagina2 & " ", "\", "/")
            Return strPagina2
        Else
            Return ""
        End If
    End Function

End Class
