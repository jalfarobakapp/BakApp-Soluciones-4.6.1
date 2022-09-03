Imports DevComponents.DotNetBar
Imports System.Windows.Forms

Public Class Class_Conectar_Base_BakApp

    Dim _Bk_BaseDeDatos As String
    Dim _Existe_Base As Boolean

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Formulario As Form
    Dim _Row_Tabcarac As DataRow

    Public ReadOnly Property Pro_Existe_Base() As Boolean
        Get
            Return _Existe_Base
        End Get
    End Property

    Public ReadOnly Property Pro_Row_Tabcarac() As DataRow
        Get
            Return _Row_Tabcarac
        End Get
    End Property

    Public Sub New(ByVal Formulario As Form)

        _Formulario = Formulario
        Consulta_sql = "Select Top 1 *,NOKOCARAC+'.dbo.' As Global_BaseBk From TABCARAC Where KOTABLA = 'BAKAPP' And KOCARAC = 'BASE'"
        _Row_Tabcarac = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Existe_Base = Fx_Existe_Base_En_SQLServer(_Row_Tabcarac)

    End Sub


    Private Function Fx_Existe_Base_En_SQLServer(ByVal _Row As DataRow) As Boolean

        Dim _Reg As Boolean

        If Not (_Row Is Nothing) Then

            Dim _Nombre_Base = _Row_Tabcarac.Item("NOKOCARAC")
            _Reg = CBool(_Sql.Fx_Cuenta_Registros("sys.databases", "name = '" & _Nombre_Base & "'"))

            If _Reg Then
                Dim _BaseBk = _Row_Tabcarac.Item("Global_BaseBk")
                Consulta_sql = "Select Top 1 * From " & _BaseBk & "Zw_Licencia"
                If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                    _Reg = False
                End If

            End If

        End If
        _Existe_Base = _Reg
        Return _Reg

    End Function

    Function Fx_Grabar_Base_Bakapp_En_Tabcarac() As Boolean

        Dim _Nokocarac As String


        _Nokocarac = InputBox("Base de datos BakApp", "Ingrese el nombre de la" & vbCrLf & "base de datos BakApp", "")
        ', "" InputBox_Bk(_Formulario, "Ingrese el nombre de la" & vbCrLf & "base de datos BakApp",
        '                          "Base de datos BakApp", "", False, _Tipo_Mayus_Minus.Normal, 0, True, _Tipo_Imagen.Texto, False)

        If Not String.IsNullOrEmpty(_Nokocarac) Then ' <> "@@Accion_Cancelada##" Then

            Dim _Reg As Boolean

            _Reg = CBool(_Sql.Fx_Cuenta_Registros("sys.databases", "name = '" & _Nokocarac & "'"))

            If _Reg Then

                Consulta_sql = "Delete TABCARAC Where KOTABLA = 'BAKAPP' And KOCARAC = 'BASE'" & vbCrLf &
                               "Insert Into TABCARAC (KOTABLA,NOKOTABLA,KOCARAC,NOKOCARAC) VALUES " &
                               "('BAKAPP','','BASE','" & _Nokocarac & "')"

                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    Consulta_sql = "Select Top 1 *,NOKOCARAC+'.dbo.' As Global_BaseBk From TABCARAC Where KOTABLA = 'BAKAPP' And KOCARAC = 'BASE'"
                    _Row_Tabcarac = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Return True
                End If

            End If

        Else
            Return False
        End If


    End Function

End Class
