Imports System.Security.Cryptography
Imports System.Web.Services
Imports System.Web.Services.Description
Imports NUnrar
Imports PdfSharp.Drawing

Public Class Frm_Demonio_New

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_ConfXEstacion As DataRow
    Dim _Tbl_Diablito As DataTable
    Dim _NombreEquipo As String

    Dim _DProgramaciones As DProgramaciones

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select Cast(1 As Bit) As Chk,Cast('' As Varchar(20)) As Nombre,Cast('' As Varchar(100)) As Programacion,Cast('' As Varchar(100)) As Resumen Where 1<0"
        _Tbl_Diablito = _Sql.Fx_Get_Tablas(Consulta_sql)

        _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        _DProgramaciones = New DProgramaciones

    End Sub

    Private Sub Frm_Demonio_New_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Load()



    End Sub

    Sub Sb_Load()

        Dim _Grb_Programacion As New Grb_Programacion

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_ConfXEstacion Where NombreEquipo = '" & _NombreEquipo & "'"
        _Row_ConfXEstacion = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Id As Integer = _Row_ConfXEstacion.Item("Id")

        If _Row_ConfXEstacion.Item("EnvioCorreo") Then

            Dim _Id_Prg As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion", "Id", "Id_Padre = " & _Id & " And Nombre = 'EnvioCorreo'", True)
            _DProgramaciones.Sp_EnvioCorreo = _Grb_Programacion.Fx_Llenar_Programacion(_Id_Prg)

            Dim _NewFila As ListViewItem = New ListViewItem("Envio de correos", 0)
            _NewFila.SubItems.Add("Se enviaran paquetes de " & _Row_ConfXEstacion.Item("CantCorreo") & " correos." & "; " & _DProgramaciones.Sp_EnvioCorreo.Resumen)
            Listv_Programaciones.Items.Add(_NewFila)

            Sb_Insertar_Registro("EnvioCorreo", "Envio de correos (Cant. " & _Row_ConfXEstacion.Item("CantCorreo") & ")", _DProgramaciones.Sp_EnvioCorreo.Resumen)

        End If

        If _Row_ConfXEstacion.Item("ColaImpDoc") Then

            Dim _Id_Prg As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion", "Id", "Id_Padre = " & _Id & " And Nombre = 'ColaImpDoc'", True)
            _DProgramaciones.Sp_ColaImpDoc = _Grb_Programacion.Fx_Llenar_Programacion(_Id_Prg)

            Dim _NewFila As ListViewItem = New ListViewItem("Monitoreo Cola Impresión Documentos", 4)
            _NewFila.SubItems.Add(_DProgramaciones.Sp_ColaImpDoc.Resumen)
            Listv_Programaciones.Items.Add(_NewFila)

            Sb_Insertar_Registro("ColaImpDoc", "Monitoreo Cola Impresión Documentos", _DProgramaciones.Sp_ColaImpDoc.Resumen)

        End If

        If _Row_ConfXEstacion.Item("ColaImpPick") Then

            Dim _Id_Prg As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_ConfProgramacion", "Id", "Id_Padre = " & _Id & " And Nombre = 'ColaImpPick'", True)
            _DProgramaciones.Sp_ColaImpPick = _Grb_Programacion.Fx_Llenar_Programacion(_Id_Prg)

            Dim _NewFila As ListViewItem = New ListViewItem("Monitoreo Cola Impresión Picking", 4)
            _NewFila.SubItems.Add(_DProgramaciones.Sp_ColaImpPick.Resumen)
            Listv_Programaciones.Items.Add(_NewFila)

            Sb_Insertar_Registro("ColaImpPick", "Monitoreo Cola Impresión Picking", _DProgramaciones.Sp_ColaImpPick.Resumen)

        End If

        If CBool(_Tbl_Diablito.Rows.Count) Then
            Lbl_Monitoreo.Text = "MONITOREO ACTIVO"
            Circular_Monitoreo.IsRunning = True
        Else
            Lbl_Monitoreo.Text = "MONITOREO INACTIVO"
            Circular_Monitoreo.IsRunning = False
        End If

    End Sub

    Sub Sb_Insertar_Registro(_Nombre As String, _Programacion As String, _Resumen As String)

        Dim NewFila As DataRow
        NewFila = _Tbl_Diablito.NewRow
        With NewFila

            .Item("Chk") = True
            .Item("Nombre") = _Nombre
            .Item("Programacion") = _Programacion
            .Item("Resumen") = _Resumen

            _Tbl_Diablito.Rows.Add(NewFila)

        End With

    End Sub

End Class
