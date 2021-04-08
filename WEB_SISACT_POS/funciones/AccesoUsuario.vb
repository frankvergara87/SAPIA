Option Strict Off
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Common.Funciones
Imports System.EnterpriseServices
Imports System.Data.OleDb
Imports ADODB

Namespace Claro.SisAct.Web.Funciones
    Public Class AccesoUsuario

        Public Shared Function ObtenerUsuario(ByVal strLogin As String) As Usuario
            Dim codAplicacion As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Dim usr As New Usuario
            Dim oAuditoria As New AuditoriaNegocio
            Dim oAccesoResponse As New AuditoriaWS.AccesoResponse
            oAccesoResponse = oAuditoria.leerDatoUsuario(strLogin, codAplicacion)
            Dim eUsuario As New Usuario
            Dim objServAcceso As New GeneralNegocios
            If oAccesoResponse.resultado.estado = "1" Then
                usr.UsuarioId = oAccesoResponse.auditoria.AuditoriaItem.item(0).codigo
                usr.Perfil = oAccesoResponse.auditoria.AuditoriaItem.item(0).perfil

                    eUsuario = objServAcceso.DatosUsuario(usr.UsuarioId, strLogin)
                    If Not eUsuario Is Nothing Then
                        usr.NombreCompleto = (eUsuario.Nombre & " " & eUsuario.Apellidos).Trim.ToUpper
                        usr.Nombre = eUsuario.Nombre
                        usr.Apellidos = eUsuario.Apellidos
                        usr.AreaUsuario = eUsuario.AreaUsuario.ToUpper
                        usr.CodigoVendedor = eUsuario.CodigoVendedor
                        usr.Login = eUsuario.Login
                    End If
                    Return usr
                End If
            Return Nothing
        End Function

        Public Shared Function VerificarUsuario(ByVal strCodUsuario As String, ByVal strLogin As String) As Boolean
            Dim usr As Usuario = ObtenerUsuario(strLogin)
            If usr Is Nothing Then
                Return False
            End If
            If CheckStr(usr.UsuarioId) = strCodUsuario Then
                HttpContext.Current.Session("CodUsuario") = usr.UsuarioId
                HttpContext.Current.Session("CodUsuarioSisact") = strCodUsuario
                HttpContext.Current.Session("CODIGOSAP") = usr.CodigoVendedor
                HttpContext.Current.Session("CodVendedorSAP") = usr.CodigoVendedor
                HttpContext.Current.Session("CodPerfil") = usr.Perfil

                HttpContext.Current.Session("NOMBRECOMPLETO") = usr.NombreCompleto
                HttpContext.Current.Session("LOGIN") = usr.Login
                HttpContext.Current.Session("HOST") = (New SisAct_WebBase).CurrentTerminal   'PROY-24740
                'gaa20170215
                HttpContext.Current.Session("beUsuario") = usr
                'fin gaa20170215
                Return True
            End If
            Return False
        End Function

    End Class

End Namespace
