Option Strict Off
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports System.Collections
Imports System.Xml
Imports System.Configuration
Imports System.Web.Mail
Imports System.Text

Public Class ConsultaCreditosEbs
    Inherits SisAct_WebBase

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

    Dim flagAuditoria As Integer = ConfigurationSettings.AppSettings("CONS_COD_FLAG_AUDIT")
    Dim objLog As New SISACT_Log
    'gaa20170215
    'Dim strArchivoDC As String = New SISACT_Log().Log_CrearNombreArchivo("LOG_TIEMPOS_DATACREDITO")
    Dim strArchivoDC As String = New SISACT_Log().Log_CrearNombreArchivo("LOG_TIEMPOS_EbsCreditosWS")
    'fin gaa20170215
    Dim strNroDocumento As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then

            Dim strLog As StringBuilder = New StringBuilder
            Dim oDataCreditoIN As New DataCreditoIN
            Dim flagEssalud, flagSunat, controlConsumo, tipoActivacion, formaPago, tipoVenta, plazoAcuerdo, tipoCliente_Venta, tipoSEC, planesEscogidos As String

            'gaa20170215
            'Dim strArchivoLOG As String = New SISACT_Log().Log_CrearNombreArchivo("Log_ErrorConsultaDC")
            Dim strArchivoLOG As String = New SISACT_Log().Log_CrearNombreArchivo("Log_Error_EbsCreditosWS")
            'FIN gaa20170215
            Try
                oDataCreditoIN.istrSecuencia = CheckStr(Request.QueryString("istrSecuencia"))
                oDataCreditoIN.istrTipoDocumento = CheckStr(Request.QueryString("istrTipoDocumento"))
                oDataCreditoIN.istrNumeroDocumento = CheckStr(Request.QueryString("istrNumeroDocumento"))
                oDataCreditoIN.istrAPELLIDOPATERNO = CheckStr(Request.QueryString("istrApellidoPaterno"))
                oDataCreditoIN.istrAPELLIDOMATERNO = CheckStr(Request.QueryString("istrApellidoMaterno"))
                oDataCreditoIN.istrNOMBRES = CheckStr(Request.QueryString("istrNombres"))
                oDataCreditoIN.istrDatoEntrada = CheckInt(Request.QueryString("istrDatoEntrada"))
                oDataCreditoIN.istrDatoComplemento = CheckStr(Request.QueryString("istrDatoComplemento"))
                oDataCreditoIN.istrTIPOPRODUCTO = CheckStr(Request.QueryString("istrTipoProducto"))
                oDataCreditoIN.istrTIPOCLIENTE = CheckStr(Request.QueryString("istrTipoCliente"))
                oDataCreditoIN.istrEDAD = CheckStr(Request.QueryString("istrEdad"))
                oDataCreditoIN.istrIngresoOLineaCredito = CheckStr(Request.QueryString("istrIngresoOLineaCredito"))
                oDataCreditoIN.istrTIPOTARJETA = CheckStr(Request.QueryString("istrTIPOTARJETA"))
                oDataCreditoIN.istrRUC = CheckStr(Request.QueryString("istrRUC"))
                oDataCreditoIN.istrANTIGUEDADLABORAL = CheckStr(Request.QueryString("istrANTIGUEDADLABORAL"))
                oDataCreditoIN.istrNumOperaPVU = CheckStr(Request.QueryString("istrNumOperaPVU"))
                oDataCreditoIN.istrRegion = CheckStr(Request.QueryString("istrRegion"))
                oDataCreditoIN.istrArea = CheckStr(Request.QueryString("istrArea"))
                oDataCreditoIN.istrCanal = CheckStr(Request.QueryString("istrCanal"))
                oDataCreditoIN.istrPuntoVenta = CheckStr(Request.QueryString("istrPuntoVenta"))
                oDataCreditoIN.istrIDCanal = CheckStr(Request.QueryString("istrIDCanal"))
				'gaa20170529
				'oDataCreditoIN.istrIDTerminal = CheckStr(Request.QueryString("istrIDTerminal"))
                oDataCreditoIN.istrIDTerminal = CurrentTerminal
				'fin gaa20170529
                oDataCreditoIN.istrUsuarioACC = CurrentUser
                oDataCreditoIN.ostrNumOperaEFT = CheckStr(Request.QueryString("ostrNumOperaEFT"))
                oDataCreditoIN.istrNUMCUENTAS = CheckStr(Request.QueryString("istrNUMCUENTAS"))
                oDataCreditoIN.strEstadoCivil = CheckStr(Request.QueryString("strEstadoCivil"))

                strNroDocumento = oDataCreditoIN.istrNumeroDocumento & "-" & oDataCreditoIN.istrPuntoVenta
                'gaa20170215
                'objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " -------------------- Inicio Proceso Datacredito --------------------")
                objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " -------------------- Inicio Proceso EbsCreditosWS --------------------")
                'fin gaa20170215
                Dim cadEstadoCivil As String = ConfigurationSettings.AppSettings("consCodEstadoCivilSapDC")
                Dim arrayEstadoCivil As String() = Split(cadEstadoCivil, "|")

                ' Equivalencia Cod. Estado Civil SAP-Datacredito
                For Each strEstado As String In arrayEstadoCivil
                    Dim strDetalle As String() = Split(CheckStr(strEstado), ";")
                    If oDataCreditoIN.strEstadoCivil = CheckStr(strDetalle(0)) Then
                        oDataCreditoIN.strEstadoCivil = CheckStr(strDetalle(1))
                        Exit For
                    End If
                Next

                flagEssalud = CheckStr(Request.QueryString("flagEssalud"))
                flagSunat = CheckStr(Request.QueryString("flagSunat"))
                controlConsumo = CheckStr(Request.QueryString("controlConsumo"))
                tipoActivacion = CheckStr(Request.QueryString("tipoActivacion"))
                formaPago = CheckStr(Request.QueryString("formaPago"))
                tipoVenta = CheckStr(Request.QueryString("tipoVenta")).Split("|"c)(0)
                plazoAcuerdo = CheckStr(Request.QueryString("plazoAcuerdo"))
                tipoCliente_Venta = CheckStr(Request.QueryString("tipoCliente"))
                tipoSEC = CheckStr(Request.QueryString("tipoSEC"))
                planesEscogidos = CheckStr(Request.QueryString("planesEscogidos"))

                strLog.Append(" |Se obtuvieron parametros ")
            Catch ex As Exception
                ' Guardar LOG
                'gaa20170215
                'GuardarLogErrorDC(strArchivoLOG, flagEssalud, flagSunat, oDataCreditoIN, "DataCredito Error: Variables de Entrada no adecuadas. " & ex.Message)
                GuardarLogErrorDC(strArchivoLOG, flagEssalud, flagSunat, oDataCreditoIN, "EbsCreditosWS Error: Variables de Entrada no adecuadas. " & ex.Message)
                'fin gaa20170215
                strLog.Append(" |Error.Se obtuvieron parametros: " & ex.Message)
                'gaa20170215
                'Dim msjError As String = "DataCredito Error: No se realizo consulta debido a variables de Entrada inadecuadas. " & ex.Message
                Dim msjError As String = "EbsCreditosWS Error: No se realizo consulta debido a variables de Entrada inadecuadas. " & ex.Message
                'fin gaa20170215
                RegisterStartupScript("script", "<script>self.parent.retornarConsultaDataCredito('" & msjError & "');</script>")
                Exit Sub
            End Try
            'gaa20170215
            'Dim oDCconsulta As New DataCreditoNegocios
            Dim oDCconsulta As CreditosWSNegocios
            'fin gaa20170215
            Dim mensajeError As String = String.Empty

            Dim paramEntradas As String = String.Empty
            Dim paramSalidas As String = String.Empty
            Dim oDataCreditoOUT As New DataCreditoOUT
            Dim ObjDataCreditoLocalOUT As New DataCreditoOUT
            'gaa20170215
            'Dim msgOrigenExito = "Consulta EXITOSA - DataCredito."
            Dim msgOrigenExito = "Consulta EXITOSA - EbsCreditosWS."
            'fin gaa20170215
            Dim FuenteConsulta As String = "DataCredito"

            Try

                paramEntradas &= oDataCreditoIN.istrSecuencia & "|" & oDataCreditoIN.istrTipoDocumento & "|" & oDataCreditoIN.istrNumeroDocumento & _
                                "|" & oDataCreditoIN.istrAPELLIDOPATERNO & "|" & oDataCreditoIN.istrAPELLIDOMATERNO & "|" & oDataCreditoIN.istrNOMBRES & _
                                "|" & oDataCreditoIN.istrDatoEntrada & "|" & oDataCreditoIN.istrDatoComplemento & "|" & oDataCreditoIN.istrTIPOPRODUCTO & _
                                "|" & oDataCreditoIN.istrTIPOCLIENTE & "|" & oDataCreditoIN.istrEDAD & "|" & oDataCreditoIN.istrIngresoOLineaCredito & _
                                "|" & oDataCreditoIN.istrTIPOTARJETA & "|" & oDataCreditoIN.istrRUC & "|" & oDataCreditoIN.istrANTIGUEDADLABORAL & _
                                "|" & oDataCreditoIN.istrNumOperaPVU & "|" & oDataCreditoIN.istrRegion & "|" & oDataCreditoIN.istrArea & _
                                "|" & oDataCreditoIN.istrPuntoVenta & "|" & oDataCreditoIN.istrIDTerminal & "|" & oDataCreditoIN.istrUsuarioACC & _
                                "|" & oDataCreditoIN.ostrNumOperaEFT & "|" & oDataCreditoIN.istrNUMCUENTAS & "|" & oDataCreditoIN.strEstadoCivil


                strLog.Append(" |paramEntradas: " & paramEntradas)
                'INICIO E75786 - Repositorio de Consulta Datacredito Local

                objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Input  --> " & paramEntradas)
                'gaa20170215
                'objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Inicio Consulta Repositorio")

                'Dim iParametro As Integer = 0
                'If oDCconsulta.ConsultaDataCreditoRepositorioLocal(oDataCreditoIN, ObjDataCreditoLocalOUT, mensajeError, tipoSEC, iParametro) Then
                '    strLog.Append(" | Consulta Repositorio Local ")
                '    oDataCreditoOUT = ObjDataCreditoLocalOUT
                '    Dim paramConsultaTablaMasivo As String = "Consulta Tabla masiva Exitosa. (" & _
                '        oDataCreditoOUT.NUMEROOPERACION & ";" & oDataCreditoIN.istrTipoDocumento & ";" & oDataCreditoIN.istrNumeroDocumento & ";" & _
                '        oDataCreditoIN.istrPuntoVenta & ";" & tipoActivacion & ";" & tipoCliente_Venta & ";" & oDataCreditoOUT.ACCION & ";" & _
                '        oDataCreditoOUT.respuesta & ";" & oDataCreditoOUT.APELLIDO_PATERNO & ";" & _
                '        oDataCreditoOUT.APELLIDO_MATERNO & ";" & oDataCreditoOUT.NOMBRES & ";" & tipoSEC & ";" & oDataCreditoIN.strEstadoCivil & ";" & _
                '        oDataCreditoOUT.RAZONES & ";" & oDataCreditoOUT.ANALISIS & ";" & oDataCreditoOUT.SCORE_RANKIN_OPERATIVO & ";" & _
                '        oDataCreditoOUT.NUMERO_ENTIDADES_RANKIN_OPERATIVO & ";" & oDataCreditoOUT.PUNTAJE & ";" & oDataCreditoOUT.limiteCreditoDataCredito & _
                '        ";" & oDataCreditoOUT.limiteCreditoBaseExterna & ";" & oDataCreditoOUT.limiteCreditoClaro & ";" & oDataCreditoOUT.fechanacimiento & _
                '        ";" & oDataCreditoOUT.CodigoBuro & ")"

                '    strLog.Append(" | paramConsultaTablaMasivo: " & paramConsultaTablaMasivo)

                '    FuenteConsulta = "MasivoLocal"
                '    AuditoriaGuardarConsultaTMasiva(paramConsultaTablaMasivo, oDataCreditoIN, oDataCreditoOUT)
                '    msgOrigenExito = "Consulta EXITOSA - Tabla Masiva."

                '    objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Fin Consulta Repositorio")
                'Else
                'objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Inicio Consulta DataCredito")
                objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Inicio Consulta EbsCreditosWS")
                'fin gaa20170215
                'gaa20170215
                'oDataCreditoOUT = oDCconsulta.ConsultaBuroCrediticio(oDataCreditoIN, mensajeError)
                Dim intNumeroIntentos As Integer = Convert.ToInt32(ConfigurationSettings.AppSettings("numeroIntentosBuro"))
                For i As Integer = 0 To intNumeroIntentos - 1
                    Try
                        oDCconsulta = New CreditosWSNegocios
                        oDataCreditoOUT = oDCconsulta.EvaluarCredito(oDataCreditoIN, Session("beUsuario"), mensajeError)
                    Catch ex As Exception

                    End Try
                    If Not oDataCreditoOUT Is Nothing Then
                        Exit For
                    End If
                Next
                'fin gaa20170215
                objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Output  --> " & mensajeError)
                objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Fin Consulta DataCredito")

                Dim regladura As String
                If oDataCreditoOUT.fechanacimiento = "" Then
                    oDataCreditoOUT.fechanacimiento = "01/01/1900"
                End If

                Dim mensajeRespuesta As String
                'gaa20170215
                'Dim body As String = ""
                'If oDataCreditoOUT.respuesta.Equals(ConfigurationSettings.AppSettings("strConstanteTipo1").ToString()) Or oDataCreditoOUT.respuesta = "14" Then
                '    If CheckStr(oDataCreditoOUT.RAZONES) <> "" Then
                '        regladura = oDataCreditoOUT.RAZONES.Substring(0, 1)
                '        If (regladura.Equals("Z") Or regladura.Equals("R") Or regladura.Equals("X") Or regladura.Equals("Q") Or regladura.Equals("V")) And _
                '            mensajeError.Equals(String.Empty) And (oDataCreditoOUT.respuesta = "13" Or oDataCreditoOUT.respuesta = "14") Then

                '            objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Inicio Graba Repositorio")

                '            ' Graba Repositorio
                '            oDCconsulta.GuardarDatosDataCredito(oDataCreditoIN, oDataCreditoOUT)

                '            objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Fin Graba Repositorio")

                '            Dim paramTablaMasivo As String = "Almacenamiento exitoso de Inf. de DC. (" & _
                '                oDataCreditoOUT.NUMEROOPERACION & ";" & oDataCreditoIN.istrTipoDocumento & ";" & oDataCreditoIN.istrNumeroDocumento & ";" & _
                '                oDataCreditoIN.istrPuntoVenta & ";" & tipoSEC & ";" & iParametro & _
                '            ";" & oDataCreditoIN.strEstadoCivil & ";" & oDataCreditoOUT.RAZONES & ";" & _
                '            oDataCreditoOUT.ANALISIS & ";" & oDataCreditoOUT.SCORE_RANKIN_OPERATIVO & ";" & oDataCreditoOUT.NUMERO_ENTIDADES_RANKIN_OPERATIVO & ";" & _
                '            oDataCreditoOUT.PUNTAJE & ";" & oDataCreditoOUT.limiteCreditoDataCredito & ";" & oDataCreditoOUT.limiteCreditoBaseExterna & ";" & oDataCreditoOUT.limiteCreditoClaro & ";" & _
                '            oDataCreditoOUT.fechanacimiento & oDataCreditoOUT.CodigoBuro & ")"
                '            FuenteConsulta = "DataCredito"

                '            objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Inicio Graba Auditoria Repositorio")

                '            AuditoriaGuardarTablaMasivo(paramTablaMasivo, oDataCreditoIN, oDataCreditoOUT)

                '            objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Fin Graba Auditoria Repositorio")
                '        Else
                '            mensajeError = "DataCredito Error: Devolución de datos de datacredito no son correctos. Comunicarse con Créditos y Activaciones."
                '            strLog.Append(" | mensajeError: " & mensajeError)
                '        End If
                '    Else
                '        mensajeError = "DataCredito Error: El campo Razones no tiene información. Comunicarse con Créditos y Activaciones."
                '        strLog.Append(" | mensajeError: " & mensajeError)
                '    End If
                'End If
                'fin gaa20170215
                'End If
                'FIN E75786 - Repositorio de Consulta Datacredito Local

                ' Guardar los parametros ORIGINALES de salida concatenados
                paramSalidas &= oDataCreditoOUT.ACCION & ";" & oDataCreditoOUT.LC_DISPONIBLE & ";" & oDataCreditoOUT.CLASE_DE_CLIENTE & _
                                ";" & oDataCreditoOUT.NUMEROOPERACION & ";" & oDataCreditoOUT.TIPO_DE_CLIENTE & ";" & oDataCreditoOUT.INGRESO_O_LC & _
                                ";" & oDataCreditoOUT.EXPLICACION & ";" & oDataCreditoOUT.CREDIT_SCORE & ";" & oDataCreditoOUT.SCORE & _
                                ";" & oDataCreditoOUT.APELLIDO_PATERNO & ";" & oDataCreditoOUT.APELLIDO_MATERNO & ";" & oDataCreditoOUT.NOMBRES & _
                                ";" & oDataCreditoOUT.respuesta & ";" & oDataCreditoOUT.TIPO_DE_TARJETA & ";" & oDataCreditoOUT.NUMERO_DOCUMENTO & _
                                ";" & oDataCreditoOUT.RAZONES & ";" & oDataCreditoOUT.ANALISIS & ";" & oDataCreditoOUT.SCORE_RANKIN_OPERATIVO & _
                                ";" & oDataCreditoOUT.NUMERO_ENTIDADES_RANKIN_OPERATIVO & ";" & oDataCreditoOUT.PUNTAJE & _
                                ";" & oDataCreditoOUT.limiteCreditoDataCredito & ";" & oDataCreditoOUT.limiteCreditoBaseExterna & _
                                ";" & oDataCreditoOUT.limiteCreditoClaro & ";" & oDataCreditoOUT.fechanacimiento & ";" & oDataCreditoOUT.CodigoBuro

                objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - paramSalidas --> " & paramSalidas)

                strLog.Append(" | paramSalidas: " & paramSalidas)
                If Not mensajeError.Equals(String.Empty) Then
                    Throw New Exception
                End If

                ' Registrar Auditoria DataCredito
                Dim mensaje As String = msgOrigenExito & " (" & _
                    oDataCreditoOUT.NUMEROOPERACION & ";" & oDataCreditoIN.istrTipoDocumento & ";" & oDataCreditoIN.istrNumeroDocumento & ";" & _
                    oDataCreditoIN.istrPuntoVenta & ";" & tipoActivacion & ";" & tipoCliente_Venta & ";" & oDataCreditoOUT.ACCION & ";" & _
                    oDataCreditoOUT.INGRESO_O_LC & ";" & oDataCreditoOUT.SCORE & ";" & oDataCreditoOUT.CREDIT_SCORE & ";" & _
                    oDataCreditoOUT.respuesta & ";" & oDataCreditoOUT.SCORE & ";" & oDataCreditoOUT.APELLIDO_PATERNO & ";" & _
                    oDataCreditoOUT.APELLIDO_MATERNO & ";" & oDataCreditoOUT.NOMBRES & ";" & tipoSEC & ";" & oDataCreditoIN.strEstadoCivil & ";" & _
                    oDataCreditoOUT.RAZONES & ";" & oDataCreditoOUT.ANALISIS & ";" & oDataCreditoOUT.SCORE_RANKIN_OPERATIVO & ";" & _
                    oDataCreditoOUT.NUMERO_ENTIDADES_RANKIN_OPERATIVO & ";" & oDataCreditoOUT.PUNTAJE & ";" & oDataCreditoOUT.limiteCreditoDataCredito & ";" & _
                    oDataCreditoOUT.limiteCreditoBaseExterna & ";" & oDataCreditoOUT.limiteCreditoClaro & ";" & _
                    oDataCreditoOUT.fechanacimiento & oDataCreditoOUT.CodigoBuro & ")"
                'gaa20170215
                'objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Inicio Graba Auditoria DataCredito")
                objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Inicio Graba Auditoria EbsCreditosWS")
                'fin gaa20170215
                AuditoriaConsultaDC(mensaje, tipoSEC, oDataCreditoIN, oDataCreditoOUT)
                'gaa20170215
                'objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Fin Graba Auditoria DataCredito")
                objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Fin Graba Auditoria EbsCreditosWS")
                'fin gaa20170215
                strLog.Append(" | mensaje1: " & mensaje)
            Catch ex As Exception
                    ' Registrar Auditoria DataCredito
                    Dim mensaje As String
                    If Not IsNothing(oDataCreditoOUT) Then
                        'gaa20170215
                        'mensaje = "Consulta DataCredito CON ERROR. (" & _
                        mensaje = "Consulta EbsCreditoWS CON ERROR. (" & _
                            oDataCreditoOUT.NUMEROOPERACION & ";" & oDataCreditoIN.istrTipoDocumento & ";" & oDataCreditoIN.istrNumeroDocumento & ";" & _
                            oDataCreditoIN.istrPuntoVenta & ";" & tipoActivacion & ";" & tipoCliente_Venta & ";" & oDataCreditoOUT.ACCION & ";" & _
                            oDataCreditoOUT.INGRESO_O_LC & ";" & oDataCreditoOUT.SCORE & ";" & oDataCreditoOUT.CREDIT_SCORE & ";" & _
                            oDataCreditoOUT.respuesta & ";" & oDataCreditoOUT.SCORE & ";" & oDataCreditoOUT.APELLIDO_PATERNO & ";" & _
                            oDataCreditoOUT.APELLIDO_MATERNO & ";" & oDataCreditoOUT.NOMBRES & ";" & tipoSEC & ";" & oDataCreditoIN.strEstadoCivil & ";" & _
                            oDataCreditoOUT.RAZONES & ";" & oDataCreditoOUT.ANALISIS & ";" & oDataCreditoOUT.SCORE_RANKIN_OPERATIVO & ";" & _
                            oDataCreditoOUT.NUMERO_ENTIDADES_RANKIN_OPERATIVO & ";" & oDataCreditoOUT.PUNTAJE & ";" & oDataCreditoOUT.limiteCreditoDataCredito & ";" & _
                            oDataCreditoOUT.limiteCreditoBaseExterna & ";" & oDataCreditoOUT.limiteCreditoClaro & ";" & _
                            oDataCreditoOUT.fechanacimiento & oDataCreditoOUT.CodigoBuro & ")"
                    End If

                    strLog.Append(" | mensaje2: " & mensaje)
                    AuditoriaConsultaDC(mensaje, tipoSEC, oDataCreditoIN, oDataCreditoOUT)

                    If mensajeError.Equals(String.Empty) Then
                        'gaa20170215
                        'mensajeError = "DataCredito Error: Consulta no realizada."
                        mensajeError = "EbsCreditosWS Error: Consulta no realizada."
                        'fin gaa20170215
                    End If
                    ' Guardar LOG
                    GuardarLogErrorDC(strArchivoLOG, flagEssalud, flagSunat, oDataCreditoIN, mensajeError & " " & ex.Message)

                    Dim script As String
                    script = "<script>"
                    script += "alert('" & mensajeError & "');"
                    script += "</script>"
                    RegisterStartupScript("script", "<script>self.parent.retornarConsultaDataCredito('" & mensajeError & "');</script>")
                    Exit Sub
                End Try
                Try
                    ' Validaciones
                    strLog.Append(" | oDataCreditoOUT.SCORE: " & oDataCreditoOUT.SCORE & "- oDataCreditoOUT.respuesta: " & oDataCreditoOUT.respuesta)
                    If oDataCreditoOUT.SCORE > 99 Then oDataCreditoOUT.SCORE = 99
                    If oDataCreditoOUT.respuesta = "14" Then
                        oDataCreditoOUT.respuesta = "13"
                    End If

                    If oDataCreditoOUT.APELLIDO_MATERNO.Trim().Equals(String.Empty) Then oDataCreditoOUT.APELLIDO_MATERNO = ConfigurationSettings.AppSettings("CONS_SIN_APMATERNO_DEFAULT").ToString()

                    objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - FuenteConsulta = DataCredito")

                    ' Grabar los parametros de entrada y salida - Solo consultas a DC
                    'gaa20170215
                    'If FuenteConsulta = "DataCredito" Then
                    If FuenteConsulta = "EbsCreditosWS" Then
                        'fin gaa20170215
                        strLog.Append(" | FuenteConsulta: " & FuenteConsulta)
                        Dim bean As New DataCredito_Input_Output

                        bean.IODCV_NUM_OPERACION = CheckStr(oDataCreditoOUT.NUMEROOPERACION)
                        bean.IODCV_INPUT_VALORES = CheckStr(paramEntradas)
                        bean.IODCV_OUTPUT_VALORES = CheckStr(paramSalidas)
                        bean.IODCV_TIPO_DOCUMENTO = CheckStr(oDataCreditoIN.istrTipoDocumento)
                        bean.IODCV_NUM_DOCUMENTO = CheckStr(oDataCreditoIN.istrNumeroDocumento)
                        bean.IODCV_USUARIO_REGISTRO = CheckStr(oDataCreditoIN.istrUsuarioACC)
                        bean.IODCV_COD_PUNTO_VENTA = CheckStr(oDataCreditoIN.istrPuntoVenta)
                        bean.IODCC_FORMA_PAGO = CheckStr(formaPago)
                        bean.IODCC_TIPO_ACTIVACION = CheckStr(tipoActivacion)
                        bean.IODCC_TIPO_CLIENTE = CheckStr(tipoCliente_Venta)
                        bean.IODCC_TIPO_VENTA = CheckStr(tipoVenta)
                        bean.IODCC_PLAZO_ACUERDO = CheckStr(plazoAcuerdo)
                        bean.IODCC_PLAN1 = ""
                        bean.IODCC_PLAN2 = ""
                        bean.IODCC_PLAN3 = ""
                        Dim conta As Integer = 0

                        objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - planesEscogidos : " & planesEscogidos)

                        If CheckStr(planesEscogidos).Length > 2 Then
                            planesEscogidos = CheckStr(planesEscogidos).Substring(1, planesEscogidos.Length - 2)
                            Dim arrayPlanes As String() = planesEscogidos.Split(","c)

                            For Each x As String In arrayPlanes
                                If conta = 0 Then
                                    bean.IODCC_PLAN1 = x
                                ElseIf conta = 1 Then
                                    bean.IODCC_PLAN2 = x
                                ElseIf conta = 2 Then
                                    bean.IODCC_PLAN3 = x
                                End If
                                conta = conta + 1
                            Next
                        End If

                        bean.IODCC_CONTROL_CONSUMO = CheckStr(controlConsumo)
                        bean.IODCC_FLAG_ESSALUD = CheckStr(flagEssalud)
                        bean.IODCC_FLAG_SUNAT = CheckStr(flagSunat)
                        bean.IODCC_RIESGO = CheckStr(oDataCreditoOUT.ACCION)
                        bean.IODCC_LIMITE_CREDITO = CheckStr(oDataCreditoOUT.INGRESO_O_LC)
                        bean.IODCC_SCORE_TEXTO = CheckStr(oDataCreditoOUT.CREDIT_SCORE)
                        bean.IODCC_SCORE_NUMERO = CheckStr(oDataCreditoOUT.SCORE)
                        bean.IODCC_RESPUESTA_DC = CheckStr(oDataCreditoOUT.respuesta)
                        bean.IODCV_APE_PATERNO = CheckStr(oDataCreditoOUT.APELLIDO_PATERNO)
                        bean.IODCV_APE_MATERNO = CheckStr(oDataCreditoOUT.APELLIDO_MATERNO)
                        bean.IODCV_NOMBRES = CheckStr(oDataCreditoOUT.NOMBRES)
                        'E76009 Inicio
                        bean.IODCV_UBIGEO = CheckStr(oDataCreditoIN.istrRegion).Substring(1, 4)
                        bean.IODCC_TIPO_CLIENTE_DC = CheckStr(oDataCreditoIN.istrArea)
                        bean.IODCC_ESTADO_CIVIL_DC = CheckStr(oDataCreditoIN.strEstadoCivil)
                        bean.IODCC_ORIGEN_LC_DC = CheckStr(oDataCreditoOUT.TOP_10000)
                        bean.IODCC_ANALISIS_DC = CheckStr(oDataCreditoOUT.ANALISIS)
                        bean.IODCC_SCORE_RANKING_OPER_DC = CheckStr(oDataCreditoOUT.SCORE_RANKIN_OPERATIVO)

                        Dim puntaje As Double
                        If CheckStr(oDataCreditoOUT.PUNTAJE) = "" Then
                            puntaje = 0
                        Else
                            puntaje = CheckDbl(oDataCreditoOUT.PUNTAJE)
                        End If

                        bean.IODCN_PUNTAJE_DC = Int(puntaje)
                        bean.IODCN_LC_DATA_CREDITO_DC = CheckDbl(oDataCreditoOUT.limiteCreditoDataCredito)
                        bean.IODCN_LC_BASE_EXTERNA_DC = CheckDbl(oDataCreditoOUT.limiteCreditoBaseExterna)
                        bean.IODCN_LC_CLARO_DC = CheckDbl(oDataCreditoOUT.limiteCreditoClaro)
                        bean.IODCC_RAZONES_DC = CheckStr(oDataCreditoOUT.RAZONES)
                        bean.IODCD_FECHA_NACE_CLIENTE_DC = CheckStr(oDataCreditoOUT.fechanacimiento)

                        'E76009 Fin
                        'gaa20170215
                        'Dim negocioReporte As New SolicitudDC_ReporteNegocio

                        'objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Inicio Graba Input_Output")

                        'negocioReporte.Insertar_DC_Parametros(bean)

                        'objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Fin Graba Input_Output")

                        'negocioReporte = Nothing
                        'fin gaa20170215
                    End If
                    'gaa20170215
                    'objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Fin FuenteConsulta = DataCredito")
                    objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Fin FuenteConsulta = EbsCreditosWS")
                    'fin gaa20170215
                    ' Enviar Correo
                    'gaa20170215
                    Dim mensajeRespuesta As String = String.Empty

                    'Dim body As String = ""
                    'If oDataCreditoOUT.respuesta.Equals(ConfigurationSettings.AppSettings("strConstanteTipo1").ToString()) _
                    'Or oDataCreditoOUT.respuesta.Equals(ConfigurationSettings.AppSettings("strConstanteTipo6").ToString()) _
                    'Or oDataCreditoOUT.respuesta.Equals(ConfigurationSettings.AppSettings("strConstanteTipo7").ToString()) Then
                    '    mensajeRespuesta = ""
                    'Else
                    '    'Dim arrayRespuesta As ArrayList = New RespuestaDataCreditoNegocio().ListarRespuestaDC()
                    '    'For Each item As RespuestaDataCredito In arrayRespuesta
                    '    '    If item.RDCV_TIPO_RESP_CODIGO.Equals(oDataCreditoOUT.respuesta) Then
                    '    '        mensajeRespuesta = item.RDCV_DESCRIPCION
                    '    '        Exit For
                    '    '    End If
                    '    'Next
                    '    body = Body_Correo_DC(mensajeRespuesta, oDataCreditoIN, oDataCreditoOUT)
                    '    EnviarCorreos(body)
                    'End If
                    'fin gaa20170215
                    ' Concatenar datos de salida para enviar a Parent
                    Dim cadenaResultado As String = ""
                    cadenaResultado &= "'" & convertirRiesgo(oDataCreditoOUT.ACCION) & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.ACCION & "',"
                    cadenaResultado &= "'" & CheckDbl(oDataCreditoOUT.LC_DISPONIBLE) & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.CLASE_DE_CLIENTE & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.NUMEROOPERACION & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.TIPO_DE_CLIENTE & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.INGRESO_O_LC & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.EXPLICACION & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.CREDIT_SCORE & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.SCORE & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.APELLIDO_PATERNO.Replace("'", "\'") & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.APELLIDO_MATERNO.Replace("'", "\'") & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.NOMBRES.Replace("'", "\'") & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.respuesta & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.TIPO_DE_TARJETA & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.NUMERO_DOCUMENTO & "',"
                    cadenaResultado &= "'" & mensajeRespuesta & "',"
                    'E76009 Inicio
                    cadenaResultado &= "'" & oDataCreditoOUT.TOP_10000 & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.ANALISIS & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.SCORE_RANKIN_OPERATIVO & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.PUNTAJE & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.limiteCreditoDataCredito & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.limiteCreditoBaseExterna & "',"
                    cadenaResultado &= "'" & CheckDbl(oDataCreditoOUT.limiteCreditoClaro) & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.RAZONES & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.fechanacimiento & "',"
                    cadenaResultado &= "'" & oDataCreditoOUT.CodigoBuro & "'"
                    'E76009Fin
                    'gaa20170215
                    cadenaResultado &= ",'" & oDataCreditoOUT.BUROCONSULTADO & "'"
                    'fin gaa20170215
                    strLog.Append(" | cadenaResultado: " & cadenaResultado)
                    If oDataCreditoOUT.NUMEROOPERACION.Equals(String.Empty) Or oDataCreditoOUT.NUMEROOPERACION.Equals(Nothing) Then
                        Dim objLog As New SISACT_Log
                        'gaa20170215
                        'objLog.Log_WriteLog(strArchivoLOG, "**************************** INCIDENCIA DATACREDITO ****************************")
                        objLog.Log_WriteLog(strArchivoLOG, "**************************** INCIDENCIA EbsCreditosWS ****************************")
                        'fin gaa20170215
                        objLog.Log_WriteLog(strArchivoLOG, "Nro.Operacion: " & oDataCreditoOUT.NUMEROOPERACION & " LC: " & oDataCreditoOUT.INGRESO_O_LC & " CS: " & oDataCreditoOUT.CREDIT_SCORE & " SCORE: " & oDataCreditoOUT.SCORE)
                        objLog.Log_WriteLog(strArchivoLOG, strLog.ToString)
                        'gaa20170215
                        'Dim msjError As String = "DataCredito Error: Ocurrió un error con el Número de Operación, por favor intenté la evaluación nuevamente."
                        Dim msjError As String = "EbsCreditosWS Error: Ocurrió un error con el Número de Operación, por favor intenté la evaluación nuevamente."
                        'fin gaa20170215
                        RegisterStartupScript("script", "<script>self.parent.retornarConsultaDataCredito('" & msjError & "');</script>")
                        Exit Sub
                    End If
                    'gaa20170215
                    '' Grabar historico de consultas a DC - Solo consultas a DC
                    'If FuenteConsulta = "DataCredito" Then
                    '    Dim vista As New VistaSolicitudDC_Historico
                    '    vista.HISTV_NUM_OPERACION = oDataCreditoOUT.NUMEROOPERACION
                    '    vista.HISTC_TIPO_DOCUMENTO = ""
                    '    If oDataCreditoIN.istrTipoDocumento.Length = 1 Then
                    '        vista.HISTC_TIPO_DOCUMENTO = "0" & oDataCreditoIN.istrTipoDocumento
                    '    End If
                    '    vista.HISTV_NUM_DOCUMENTO = oDataCreditoIN.istrNumeroDocumento
                    '    vista.HISTV_APELLIDO_PAT = oDataCreditoIN.istrAPELLIDOPATERNO.ToUpper()
                    '    vista.HISTV_APELLIDO_MAT = oDataCreditoIN.istrAPELLIDOMATERNO.ToUpper()
                    '    vista.HISTV_NOMBRE = oDataCreditoIN.istrNOMBRES.ToUpper()
                    '    vista.HISTC_TIPO_RESPUESTA = oDataCreditoOUT.respuesta
                    '    vista.HISTC_TIPO_RIESGO = oDataCreditoOUT.ACCION
                    '    If vista.HISTC_TIPO_RIESGO.Equals(String.Empty) Then
                    '        vista.HISTC_TIPO_RIESGO = "S"
                    '    End If
                    '    vista.HISTN_CANT_INTENTOS = 1
                    '    vista.HISTV_OVEN_CODIGO = oDataCreditoIN.istrPuntoVenta
                    '    vista.HISTV_TERMINAL_ID = System.Net.Dns.GetHostName
                    '    vista.HISTN_USUARIO_REG = oDataCreditoIN.istrUsuarioACC
                    '    Dim negocioHistorico As New SolicitudDC_HistoricoNegocio

                    '    objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Inicio Graba Historio DC")

                    '    negocioHistorico.Insertar_DC_Historico(vista)

                    '    objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Fin Graba Historio DC")

                    '    negocioHistorico = Nothing
                    'End If
                    'fin gaa20170215
                    HttpContext.Current.Session("FuenteConsulta") = FuenteConsulta

                    Session("DataCreditoOUT") = oDataCreditoOUT
                    Session("DataCreditoIN") = oDataCreditoIN

                    If Not Session("FormularioSEC") Is Nothing Then
                        Dim oDatosFormulario As FormularioSEC = CType(Session("FormularioSEC"), FormularioSEC)

                        If CheckInt(oDataCreditoOUT.respuesta) = DataCreditoOUT.TIPO_RESPUESTA.TIPO09 Then
                            oDatosFormulario.ContadorIntentosTipo09 += 1
                        End If
                        If CheckInt(oDataCreditoOUT.respuesta) = DataCreditoOUT.TIPO_RESPUESTA.TIPO10 Then
                            oDatosFormulario.ContadorIntentosTipo10 += 1
                        End If
                        If CheckInt(oDataCreditoOUT.respuesta) = DataCreditoOUT.TIPO_RESPUESTA.TIPO13 Then
                            oDatosFormulario.ContadorIntentosTipo13 += 1
                        End If
                        Session("FormularioSEC") = oDatosFormulario
                    End If
                    'gaa20170215
                    'objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " -------------------- Fin Proceso Datacredito --------------------")
                    objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " -------------------- Fin Proceso EbsCreditosWS --------------------")
                    'fin gaa20170215
                    RegisterStartupScript("script", "<script>self.parent.f_ConsultaRegla_Previo_DataCredito(" & cadenaResultado & ");</script>")

                Catch ex As Exception
                    ' Guardar LOG
                    GuardarLogErrorDC(strArchivoLOG, flagEssalud, flagSunat, oDataCreditoIN, "DataCredito Error: " & ex.Message)
                    objLog.Log_WriteLog(strArchivoDC, strNroDocumento & " - Excepcion: " & ex.Message)
                    Dim msjError As String = "DataCredito Error: " & ex.Message
                    RegisterStartupScript("script", "<script>self.parent.retornarConsultaDataCredito('" & msjError & "');</script>")
                End Try

        End If
    End Sub

    Private Function Body_Correo_DC(ByVal mensajeRespuesta As String, ByRef oDataCreditoIN As DataCreditoIN, ByRef oDataCreditoOUT As DataCreditoOUT) As String
        Dim cuerpo As New StringBuilder
        Dim flag As String = ConfigurationSettings.AppSettings("FlagPrueba").ToString()
        If flag.Equals("0") Then
            cuerpo.Append("AMBIENTE DE PRODUCCION - CORREO DE ALERTA - DATACREDITO")
        Else
            cuerpo.Append("PRUEBAS EN DESARROLLO O EN QA - CORREO DE ALERTA - DATACREDITO")
        End If
        cuerpo.Append("<br><hr align='left' style='height:1px;width:550px;border:1px solid #000;'>")
        cuerpo.Append("Consulta a DataCredito Nº " & oDataCreditoOUT.NUMEROOPERACION)
        cuerpo.Append("<br><br><hr align='left' style='height:1px;width:550px;border:1px solid #000;'>")
        cuerpo.Append("Respuesta devuelta:")
        cuerpo.Append("<br><br>")
        cuerpo.Append("&nbsp;&nbsp;Mensaje : " & mensajeRespuesta)
        cuerpo.Append("<br>")
        cuerpo.Append("&nbsp;&nbsp;Codigo  : " & oDataCreditoOUT.respuesta)
        cuerpo.Append("<br><hr align='left' style='height:1px;width:550px;border:1px solid #000;'>")
        cuerpo.Append("Datos del Cliente:")
        cuerpo.Append("<br><br>")
        cuerpo.Append("&nbsp;&nbsp;Tipo Documento   : " & oDataCreditoIN.istrTipoDocumento)
        cuerpo.Append("<br>")
        cuerpo.Append("&nbsp;&nbsp;Numero Documento : " & oDataCreditoIN.istrNumeroDocumento)
        cuerpo.Append("<br>")
        cuerpo.Append("&nbsp;&nbsp;Nombre           : " & oDataCreditoOUT.NOMBRES)
        cuerpo.Append("<br>")
        cuerpo.Append("&nbsp;&nbsp;Apellido Paterno : " & oDataCreditoOUT.APELLIDO_PATERNO)
        cuerpo.Append("<br>")
        cuerpo.Append("&nbsp;&nbsp;Apellido Materno : " & oDataCreditoOUT.APELLIDO_MATERNO)
        cuerpo.Append("<br><hr align='left' style='height:1px;width:550px;border:1px solid #000;'>")
        cuerpo.Append("Código de Punto de Venta que realizó la consulta: " & oDataCreditoIN.istrPuntoVenta)
        Return cuerpo.ToString
    End Function

    Private Function convertirRiesgo(ByVal strRiesgo As String) As String
        If strRiesgo Is Nothing Then
            strRiesgo = "S"
        End If

        If strRiesgo.Equals("A") Then
            Return "APROBAR"
        ElseIf strRiesgo.Equals("B") Then
            Return "APROBAR__VERIFICAR"
        ElseIf strRiesgo.Equals("C") Then
            Return "OBSERVAR"
        ElseIf strRiesgo.Equals("D") Then
            Return "ALTO_RIESGO"
        Else
            Return "SIN_HISTORIAL"
        End If
    End Function

    Public Sub EnviarCorreos(ByVal mensaje As String)
        Dim MyMail As MailMessage = New MailMessage
        MyMail.From = ConfigurationSettings.AppSettings("DcEmailRemitente").ToString()
        MyMail.Subject = "Informe Consulta DataCredito"
        MyMail.Body = Trim(mensaje)
        MyMail.BodyFormat = MailFormat.Html
        SmtpMail.SmtpServer = ConfigurationSettings.AppSettings("DcEmailSmtpServer").ToString()

        Try
            Dim FlagPrueba As String = ConfigurationSettings.AppSettings("FlagPrueba").ToString()
            If FlagPrueba.Equals("0") Then
                MyMail.To = ConfigurationSettings.AppSettings("DcEmailDestinatarioPRD").ToString()
                SmtpMail.Send(MyMail)
            End If
            MyMail.To = ConfigurationSettings.AppSettings("DcEmailDestinatarioDES").ToString()
            SmtpMail.Send(MyMail)
        Catch ex As Exception

        Finally
            MyMail = Nothing

        End Try

    End Sub

    Public Sub AuditoriaConsultaDC(ByVal mensaje As String, ByVal tipoSEC As String, ByRef oDataCreditoIN As DataCreditoIN, ByRef oDataCreditoOUT As DataCreditoOUT)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal

            Dim strCodAplica As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")

            Dim strCodTrans As String = ConfigurationSettings.AppSettings("DcAuditConsultaDataCredito" & tipoSEC)

            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", mensaje)
            If Not auditoriaGrabado Then
                Throw New Exception("Error. No se registro en Auditoria la Consulta a DataCredito (OficinaVenta: " & oDataCreditoIN.istrPuntoVenta & " | Nro Operacion: " & oDataCreditoOUT.NUMEROOPERACION & ").")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub GuardarLogErrorDC(ByVal strArchivo As String, ByVal flagEssalud As String, ByVal flagSunat As String, ByRef oDataCreditoIN As DataCreditoIN, ByVal mensajeError As String)
        Dim objLog As New SISACT_Log
        'gaa20170215
        'objLog.Log_WriteLog(strArchivo, "**************************** ERROR CONSULTA DATACREDITO ****************************")
        objLog.Log_WriteLog(strArchivo, "**************************** ERROR CONSULTA EbsCreditosWS ****************************")
        'fin gaa20170215
        objLog.Log_WriteLog(strArchivo, "  PARAMETROS")
        objLog.Log_WriteLog(strArchivo, "  Tipo de Documento                 : " & oDataCreditoIN.istrTipoDocumento)
        objLog.Log_WriteLog(strArchivo, "  Numero de Documento de Identidad  : " & oDataCreditoIN.istrNumeroDocumento)
        If flagEssalud Is Nothing Then
            flagEssalud = ""
        End If
        If flagSunat Is Nothing Then
            flagSunat = ""
        End If
        If Not flagEssalud.Equals(String.Empty) Then
            objLog.Log_WriteLog(strArchivo, "  Tipo de Validación                : " & IIf(flagEssalud.Equals("P"), "ESSALUD ACTIVO", "ESSALUD INACTIVO"))
        ElseIf Not flagSunat.Equals(String.Empty) Then
            objLog.Log_WriteLog(strArchivo, "  Tipo de Validación                : " & IIf(flagSunat.Equals("P"), "SUNAT ACTIVO", "SUNAT BAJA"))
        Else
            objLog.Log_WriteLog(strArchivo, "  Tipo de Validación                : " & "SIN VALIDACION")
        End If
        objLog.Log_WriteLog(strArchivo, "  ----------------------------------------------------------------------------------")
        objLog.Log_WriteLog(strArchivo, "  RESPUESTA")
        objLog.Log_WriteLog(strArchivo, "  Descripcion Error                 : " & mensajeError)
        objLog.Log_WriteLog(strArchivo, "************************************************************************************")

        objLog = Nothing
    End Sub
    Public Sub AuditoriaGuardarTablaMasivo(ByVal mensaje As String, ByVal oDataCreditoIN As DataCreditoIN, ByVal oDataCreditoOUT As DataCreditoOUT)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal

            Dim strCodAplica As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")

            Dim strCodTrans As String = ConfigurationSettings.AppSettings("DcAuditGuardarDCMasivo")

            If flagAuditoria = 1 Then
                Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", mensaje)
                If Not auditoriaGrabado Then
                    Throw New Exception("Error. No se registro en Auditoria el almacenamiento en la tabla masiva(OficinaVenta: " & oDataCreditoIN.istrPuntoVenta & " | Nro Operacion: " & oDataCreditoOUT.NUMEROOPERACION & ").")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AuditoriaGuardarConsultaTMasiva(ByVal mensaje As String, ByVal oDataCreditoIN As DataCreditoIN, ByVal oDataCreditoOUT As DataCreditoOUT)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal

            Dim strCodAplica As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")

            Dim strCodTrans As String = ConfigurationSettings.AppSettings("DcAuditGuardarConsultaTMasivo")

            If flagAuditoria = 1 Then
                Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", mensaje)
                If Not auditoriaGrabado Then
                    Throw New Exception("Error. No se registro en Auditoria la Consulta a Tabla Masiva (OficinaVenta: " & oDataCreditoIN.istrPuntoVenta & " | Nro Operacion: " & oDataCreditoOUT.NUMEROOPERACION & ").")
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

End Class
