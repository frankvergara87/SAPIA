Imports Claro.SisAct.Entidades
Namespace Claro.SisAct.Web.Funciones
    Public Class sisact_session
        Private Const K_CLAVE_DATOS_CLIENTE As String = "K_CLAVE_DATOS_CLIENTE"
        Private Const K_CLAVE_DATOS_LINEA As String = "K_CLAVE_DATOS_LINEA"

        Public Shared Property Usuario() As Usuario
            Get
                Dim salida As New Usuario
                If Not HttpContext.Current.Session("UsuarioInfo") Is Nothing Then
                    salida = CType(HttpContext.Current.Session("UsuarioInfo"), Usuario)
                End If
                Return salida
            End Get
            Set(ByVal Value As Usuario)
                If Value Is Nothing Then
                    HttpContext.Current.Session.Remove("UsuarioInfo")
                Else
                    HttpContext.Current.Session("UsuarioInfo") = Value
                End If
            End Set
        End Property
        Public Shared Property ObtenerListaOpciones() As String
            Get
                Dim salida As String = ""
                If Not HttpContext.Current.Session("ListaOpciones") Is Nothing Then
                    salida = CType(HttpContext.Current.Session("ListaOpciones"), String)
                End If
                Return salida
            End Get
            Set(ByVal Value As String)
                If Value Is Nothing Then
                    HttpContext.Current.Session.Remove("ListaOpciones")
                Else
                    HttpContext.Current.Session("ListaOpciones") = Value
                End If
            End Set
        End Property
        Public Shared Property IngresoPorLogin() As String
            Get
                Dim salida As String
                If Not HttpContext.Current.Session("IngresoPorLogin") Is Nothing Then
                    salida = CType(HttpContext.Current.Session("IngresoPorLogin"), String)
                End If
                Return salida
            End Get
            Set(ByVal Value As String)
                If Value Is Nothing Then
                    HttpContext.Current.Session.Remove("IngresoPorLogin")
                Else
                    HttpContext.Current.Session("IngresoPorLogin") = Value
                End If
            End Set
        End Property

        Public Shared Property ErrorPagina() As ErrorInfo
            Get
                Dim salida As New ErrorInfo
                If Not HttpContext.Current.Session("ErrorPagina") Is Nothing Then
                    salida = CType(HttpContext.Current.Session("ErrorPagina"), ErrorInfo)
                End If
                Return salida
            End Get
            Set(ByVal Value As ErrorInfo)
                If Value Is Nothing Then
                    HttpContext.Current.Session.Remove("ErrorPagina")
                Else
                    HttpContext.Current.Session("ErrorPagina") = Value
                End If
            End Set
        End Property

        '/////////////////////////////////////////////////////////////////////////////////////////////////

        Public Shared Property DatosCliente() As Claro.SisAct.Entidades.Cliente
            Get
                Dim salida As New Claro.SisAct.Entidades.Cliente
                If Not HttpContext.Current.Session(K_CLAVE_DATOS_CLIENTE) Is Nothing Then
                    salida = CType(HttpContext.Current.Session(K_CLAVE_DATOS_CLIENTE), Claro.SisAct.Entidades.Cliente)
                End If
                Return salida
            End Get
            Set(ByVal Value As Claro.SisAct.Entidades.Cliente)
                If Value Is Nothing Then
                    HttpContext.Current.Session.Remove(K_CLAVE_DATOS_CLIENTE)
                Else
                    HttpContext.Current.Session(K_CLAVE_DATOS_CLIENTE) = Value
                End If
            End Set
        End Property

        Public Shared Property DatosLinea() As Claro.SisAct.Entidades.Linea
            Get
                Dim salida As New Claro.SisAct.Entidades.Linea
                If Not HttpContext.Current.Session(K_CLAVE_DATOS_LINEA) Is Nothing Then
                    salida = CType(HttpContext.Current.Session(K_CLAVE_DATOS_LINEA), Claro.SisAct.Entidades.Linea)
                End If
                Return salida
            End Get
            Set(ByVal Value As Claro.SisAct.Entidades.Linea)
                If Value Is Nothing Then
                    HttpContext.Current.Session.Remove(K_CLAVE_DATOS_LINEA)
                Else
                    HttpContext.Current.Session(K_CLAVE_DATOS_LINEA) = Value
                End If
            End Set
        End Property
    End Class
End Namespace