﻿Imports System.Data.SqlClient
Imports System.IO
Imports BkSpecialPrograms
Imports Newtonsoft.Json
Public Class Cl_ConfiguracionLocal

    Public Property DirectorioActual As String
    Public Property NombreArchivo_Configuracion As String
    Public Property Configuracion As New Configuracion

    Public Sub New()

        DirectorioActual = Application.StartupPath & "\Data"
        NombreArchivo_Configuracion = "ConfLocal_Meli2Bakapp.json"

    End Sub

    Function Fx_LeerArchivoConexionJson(_ProbarConexion As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            If Not Directory.Exists(DirectorioActual) Then

                Directory.CreateDirectory(DirectorioActual)

                DirectorioActual = Application.StartupPath & "\Data\Tmp"

                If Not Directory.Exists(DirectorioActual) Then
                    Directory.CreateDirectory(DirectorioActual)
                End If

            Else
                DirectorioActual = Application.StartupPath & "\Data\Tmp"
            End If

            _Mensaje.Id = 1

            Dim json As String

            If Not File.Exists(DirectorioActual & "\" & NombreArchivo_Configuracion) Then

                Dim _Conexion1 As New Conexion With {.NombreConexion = "RandomBakapp", .Host = "", .Puerto = "", .Usuario = "", .Password = "", .Basededatos = ""}
                Dim _Conexion2 As New Conexion With {.NombreConexion = "Meli", .Host = "", .Puerto = "", .Usuario = "", .Password = "", .Basededatos = ""}

                Configuracion.Ls_Conexiones = New List(Of Conexion)

                Configuracion.Ls_Conexiones.Add(_Conexion1)
                Configuracion.Ls_Conexiones.Add(_Conexion2)

                Configuracion.Global_BaseBk = String.Empty
                Configuracion.BodegaFacturacion = New BodegaFacturacion With {.Empresa = "", .Razon = "", .Kosu = "", .Nokosu = "", .Kobo = "", .Nokobo = ""}
                Configuracion.Pago = New Pago With {.Modalidad = "", .Empresa = "", .Sucursal = "", .Caja = "", .TipoPago = "TJV", .Funcionario = "", .NomFuncionario = "", .Banco = "", .NomBanco = "", .PagarAuto = False}

                json = Newtonsoft.Json.JsonConvert.SerializeObject(Configuracion)

                Dim _Mensaje2 As New LsValiciones.Mensajes

                _Mensaje2 = Fx_GrabarConexiones()

                _Mensaje.Detalle = "Falta datos en la configuración"
                Throw New System.Exception("Debe ingresar la configuración de conexión a las bases de datos.")

            End If

            json = File.ReadAllText(DirectorioActual & "\" & NombreArchivo_Configuracion)
            Configuracion = JsonConvert.DeserializeObject(Of Configuracion)(json)

            Dim Ls_Conexiones As List(Of Conexion) = Configuracion.Ls_Conexiones

            If _Mensaje.Id = 1 Then

                If _ProbarConexion Then

                    Dim _Cadena As String

                    _Cadena = Fx_CadenaConexion(Ls_Conexiones(0).Host,
                                                Ls_Conexiones(0).Puerto,
                                                Ls_Conexiones(0).Basededatos,
                                                Ls_Conexiones(0).Usuario,
                                                Ls_Conexiones(0).Password)

                    Dim _Ms = Fx_Conectar(_Cadena)

                    If Not _Ms.EsCorrecto Then
                        _Mensaje.Detalle = _Ms.Detalle
                        Throw New System.Exception(_Ms.Mensaje)
                    End If

                    _Cadena = Fx_CadenaConexion(Ls_Conexiones(1).Host,
                                                Ls_Conexiones(1).Puerto,
                                                Ls_Conexiones(1).Basededatos,
                                                Ls_Conexiones(1).Usuario,
                                                Ls_Conexiones(1).Password)


                    _Ms = Fx_Conectar(_Cadena)

                    If Not _Ms.EsCorrecto Then
                        _Mensaje.Detalle = _Ms.Detalle
                        Throw New System.Exception(_Ms.Mensaje)
                    End If

                End If

            End If

            If String.IsNullOrEmpty(Configuracion.Global_BaseBk) Then
                _Mensaje.Detalle = "Falta datos en la configuración"
                Throw New System.Exception("Debe ingresar el nombre de la base de datos de BAKAPP")
            End If

            _Global_BaseBk = Configuracion.Global_BaseBk & ".dbo."

            If IsNothing(Configuracion.ModalidadFac) Then
                _Mensaje.Detalle = "Falta datos en la configuración"
                Throw New System.Exception("Debe ingresar los datos de la modalidad de facturación")
            End If

            If IsNothing(Configuracion.BodegaFacturacion) Then
                _Mensaje.Detalle = "Falta datos en la configuración"
                Throw New System.Exception("Debe ingresar los datos de la bodega de facturación")
            End If

            If Not Directory.Exists(Configuracion.RutaEtiquetas) Then
                _Mensaje.Detalle = "Falta datos en la configuración"
                Throw New System.Exception("Debe ingresar la ruta de las etiquetas")
            End If

            If Not Directory.Exists(Configuracion.RutaEtiquetas) Then
                _Mensaje.Detalle = "Falta datos en la configuración"
                Throw New System.Exception("Debe ingresar la ruta de las etiquetas")
            End If

            If String.IsNullOrEmpty(Configuracion.DocEmitir) Then
                Configuracion.DocEmitir = String.Empty
                Configuracion.Facturar = False
            End If

            With Configuracion.BodegaFacturacion

                If String.IsNullOrEmpty(.Empresa) Or
                   String.IsNullOrEmpty(.Razon) Or
                   String.IsNullOrEmpty(.Kosu) Or
                   String.IsNullOrEmpty(.Nokosu) Or
                   String.IsNullOrEmpty(.Kobo) Or
                   String.IsNullOrEmpty(.Nokobo) Then
                    _Mensaje.Detalle = "Falta datos en la configuración"
                    Throw New System.Exception("Debe ingresar los datos de la bodega de facturación")
                End If

            End With

            If IsNothing(Configuracion.Vendedor) OrElse String.IsNullOrEmpty(Configuracion.Vendedor) Then
                _Mensaje.Detalle = "Falta datos en la configuración"
                Throw New System.Exception("Debe ingresar los datos del vendedor")
            End If

            If IsNothing(Configuracion.Responsable) OrElse String.IsNullOrEmpty(Configuracion.Responsable) Then
                _Mensaje.Detalle = "Falta datos en la configuración"
                Throw New System.Exception("Debe ingresar los datos del responsable de la factura/boleta")
            End If

            If IsNothing(Configuracion.Concepto_R) OrElse String.IsNullOrEmpty(Configuracion.Concepto_R) Then
                _Mensaje.Detalle = "Falta datos en la configuración"
                Throw New System.Exception("Debe ingresar un concepto de Recargo")
            End If

            If IsNothing(Configuracion.Concepto_D) OrElse String.IsNullOrEmpty(Configuracion.Concepto_D) Then
                _Mensaje.Detalle = "Falta datos en la configuración"
                Throw New System.Exception("Debe ingresar un concepto de Descuento")
            End If

            If IsNothing(Configuracion.Pago) Then
                Configuracion.Pago = New Pago With {.Modalidad = "", .Empresa = "", .RutEmpresa = "", .Sucursal = "", .Caja = "", .TipoPago = "TJV", .Funcionario = "", .NomFuncionario = "", .Banco = "", .NomBanco = "", .PagarAuto = False}
            End If

            If Configuracion.Pago.PagarAuto Then
                If String.IsNullOrEmpty(Configuracion.Pago.Modalidad) Or
                    String.IsNullOrEmpty(Configuracion.Pago.Empresa) Or
                    String.IsNullOrEmpty(Configuracion.Pago.RutEmpresa) Or
                    String.IsNullOrEmpty(Configuracion.Pago.Sucursal) Or
                    String.IsNullOrEmpty(Configuracion.Pago.Caja) Or
                    String.IsNullOrEmpty(Configuracion.Pago.TipoPago) Or
                    String.IsNullOrEmpty(Configuracion.Pago.Funcionario) Or
                    String.IsNullOrEmpty(Configuracion.Pago.NomFuncionario) Or
                    String.IsNullOrEmpty(Configuracion.Pago.Banco) Or
                    String.IsNullOrEmpty(Configuracion.Pago.NomBanco) Then
                    _Mensaje.Detalle = "Falta datos en la configuración"
                    Throw New System.Exception("Debe ingresar los datos de pago automático")
                End If
            End If

            _Mensaje.Detalle = "Archivo leido correctamente"
            _Mensaje.Mensaje = "El archivo contiene las conexiones a las bases de datos"

            _Mensaje.EsCorrecto = True
            _Mensaje.Resultado = json

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Id = 0
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Function Fx_GrabarConexiones() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            DirectorioActual = Application.StartupPath & "\Data\Tmp"

            Dim json As String

            json = JsonConvert.SerializeObject(Configuracion, Formatting.Indented)
            File.WriteAllText(DirectorioActual & "\" & NombreArchivo_Configuracion, json)

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Archivo grabado correctamente"
            _Mensaje.Mensaje = "Ruta de archivo: " & DirectorioActual & "\" & NombreArchivo_Configuracion
            _Mensaje.Resultado = json

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Problema"
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Function Fx_CadenaConexion(_Host As String,
                               _Puerto As String,
                               _Basededatos As String,
                               _Usuario As String,
                               _Password As String) As String

        Dim Cadena = "data source = #SV#; initial catalog = #BD#; user id = #US#; password = #PW#"

        If Trim(_Puerto) <> "" Then
            _Host = Trim(_Host & "," & _Puerto)
        End If

        Cadena = Replace(Cadena, "#SV#", _Host)
        Cadena = Replace(Cadena, "#BD#", _Basededatos)
        Cadena = Replace(Cadena, "#US#", _Usuario)
        Cadena = Replace(Cadena, "#PW#", _Password)

        Return Cadena

    End Function

    Function Fx_Conectar(_CadenaDeConexion As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _Sql As New Class_SQL(_CadenaDeConexion)

        Try

            Dim _Cn As New SqlConnection
            _Sql.Sb_Abrir_Conexion(_Cn, False)

            If Not String.IsNullOrWhiteSpace(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Conexión"
            _Mensaje.Mensaje = "La conexión a la base de datos ha resultado exitosa"

        Catch ex As Exception
            _Mensaje.Detalle = "Problema al conectar"
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Function Fx_ConfirmardbBakapp(_BaseDatosBakapp As String, _Usuario As String,_CadenaDeConexion As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim Consulta_Sql As String

        Try

            Dim _Sql As New Class_SQL(_CadenaDeConexion)

            Consulta_Sql = "USE [" & _BaseDatosBakapp & "];
Declare @Usuario As Varchar(20) = '" & _Usuario & "';

SELECT 
    dp.name AS Usuario,
    dp.type_desc AS Tipo,
    dp.create_date AS FechaCreacion,
    dp.modify_date AS FechaModificacion,
    p.permission_name AS Permiso,
    p.state_desc AS Estado
FROM 
    sys.database_principals dp
LEFT JOIN 
    sys.database_permissions p ON dp.principal_id = p.grantee_principal_id
WHERE 
    dp.name = @Usuario;
"
            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql, False)

            If Not String.IsNullOrWhiteSpace(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Base de datos aceptada"
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message & vbCrLf & vbCrLf & "Revise el nombre de la base de datos de Bakapp"
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function


End Class

