Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports System.Configuration
Public Class WebComunes

#Region " PROY-25335 | Contratación Electrónica - Release 0 | Bryan Chumbes Lizarraga "
    Public Shared Sub CargarAppSettings()
        Try
            Dim Key_ContratacionElectronica As Int64 = 0
            Dim valor1 As String = String.Empty
            Dim valor As String = String.Empty

            Key_ContratacionElectronica = Funciones.CheckInt64(ConfigurationSettings.AppSettings("Key_ContratacionElectronica").ToString())
            Dim listParametros As ArrayList = New MaestroNegocio().ListaParametrosGrupo(Key_ContratacionElectronica)

            For Each oItem As Parametro In listParametros
                valor1 = oItem.Valor1
                valor = oItem.Valor
                Select Case valor1
                    Case "Key_documentoDNI"
                        AppSettings.Key_documentoDNI = valor
                    Case "Key_documentoPermitido"
                        AppSettings.Key_documentoPermitido = valor
                    Case "Key_HuelleroPostpago"
                        AppSettings.Key_HuelleroPostpago = valor
                    Case "Key_DNIVencido"
                        AppSettings.Key_DNIVencido = valor
                    Case "Key_validacionBioExitosa"
                        AppSettings.Key_validacionBioExitosa = valor
                    Case "Key_errorHuellaDNI"
                        AppSettings.Key_errorHuellaDNI = valor
                    Case "Key_errorReniec"
                        AppSettings.Key_errorReniec = valor
                    Case "Key_errorSixBio"
                        AppSettings.Key_errorSixBio = valor
                    Case "Key_clienteDiscapacidad"
                        AppSettings.Key_clienteDiscapacidad = valor
                    Case "Key_cancelacionBiometria"
                        AppSettings.Key_cancelacionBiometria = valor
                    Case "Key_msjErrorCalidadHuella"
                        AppSettings.Key_msjErrorCalidadHuella = valor
                    Case "Key_mensajeErrorMaximoIntentos"
                        AppSettings.Key_mensajeErrorMaximoIntentos = valor
                    Case "Key_canalesPermitidosCP"
                        AppSettings.Key_canalesPermitidosCP = valor
                    Case "Key_validarDNIVencido"
                        AppSettings.Key_validarDNIVencido = valor
                    Case "Key_canalesPermitidosBiometria"
                        AppSettings.Key_canalesPermitidosBiometria = valor
                    Case "Key_TipoOperacionPermitidoReno"
                        AppSettings.Key_TipoOperacionPermitidoReno = valor
                End Select
            Next

            'Inicio PROY-31636 - RENTESEG

            Dim key_ParanGrupoRenteseg As Int64 = 0

            key_ParanGrupoRenteseg = Funciones.CheckInt64(ConfigurationSettings.AppSettings("key_ParanGrupoRenteseg").ToString())
            Dim listParametrosRenteseg As ArrayList = New MaestroNegocio().ListaParametrosGrupo(key_ParanGrupoRenteseg)

            For Each oItem As Parametro In listParametrosRenteseg
                valor1 = oItem.Valor1
                valor = oItem.Valor
                Select Case valor1
                    Case "Key_codigoDocMigratorios"
                        AppSettings.Key_codigoDocMigratorios = valor
                    Case "Key_codigoDocMigraYPasaporte"
                        AppSettings.Key_codigoDocMigraYPasaporte = valor
                    Case "Key_codDocMigra_Pasaporte_CE"
                        AppSettings.Key_codDocMigra_Pasaporte_CE = valor
                    Case "Key_codigoDocCIRE"
                        AppSettings.Key_codigoDocCIRE = valor
                    Case "Key_codigoDocCIE"
                        AppSettings.Key_codigoDocCIE = valor
                    Case "Key_codigoDocCPP"
                        AppSettings.Key_codigoDocCPP = valor
                    Case "Key_codigoDocCTM"
                        AppSettings.Key_codigoDocCTM = valor
                    Case "Key_minLengthDocMigratorios"
                        AppSettings.Key_minLengthDocMigratorios = valor
                    Case "Key_maxLengthDocMigratorios"
                        AppSettings.Key_maxLengthDocMigratorios = valor
                    Case "Key_codigoDocPasaporte07"
                        AppSettings.Key_codigoDocPasaporte07 = valor
                    Case "Key_codigoDocPasaporte08"
                        AppSettings.Key_codigoDocPasaporte08 = valor
                    Case "Key_flagPermitirProductosLTE"
                        AppSettings.Key_flagPermitirProductosLTE = valor
                    Case "Key_docsExistEvaluacionPost"
                        AppSettings.Key_docsExistEvaluacionPost = valor
                    Case "Key_tipoDocPermitidoPostCAC"
                        AppSettings.Key_tipoDocPermitidoPostCAC = valor
                    Case "Key_tipoDocPermitidoPostDAC"
                        AppSettings.Key_tipoDocPermitidoPostDAC = valor
                    Case "Key_tipoDocPermitidoPostCAD"
                        AppSettings.Key_tipoDocPermitidoPostCAD = valor
                    Case "Key_lineaNoCoincide"
                        AppSettings.Key_lineaNoCoincide = valor
                    Case "Key_ExpressTipoDocVentaPreRen"
                        AppSettings.Key_ExpressTipoDocVentaPreRen = valor
                    Case "Key_ExpressTipoDocVentaPos"
                        AppSettings.Key_ExpressTipoDocVentaPos = valor
                End Select
            Next
            'Fin PROY-31636 - RENTESEG

        Catch e As Exception
        End Try
    End Sub
#End Region

End Class
