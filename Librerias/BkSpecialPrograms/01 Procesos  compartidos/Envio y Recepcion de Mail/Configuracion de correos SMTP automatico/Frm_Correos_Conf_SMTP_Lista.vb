Imports DevComponents.DotNetBar

Public Class Frm_Correos_Conf_SMTP_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Row_Cuenta As DataRow

    Dim _Accion As Enum_Accion

    Public Property Pro_Row_Cuenta As DataRow
        Get
            Return _Row_Cuenta
        End Get
        Set(value As DataRow)
            _Row_Cuenta = value
        End Set
    End Property

    Enum Enum_Accion
        Nuevo
        Seleccionar
    End Enum


    Public Sub New(Accion As Enum_Accion)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Accion = Accion
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)
    End Sub

    Private Sub Frm_Correos_Conf_SMTP_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Correos_Cuentas Order by Nombre_Usuario"

        With Grilla

            .DataSource = _Sql.Fx_Get_Tablas(Consulta_Sql)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Nombre_Usuario").Visible = True
            .Columns("Nombre_Usuario").HeaderText = "Cuenta"
            .Columns("Nombre_Usuario").Width = 280

        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Nombre_Usuario As String = _Fila.Cells("Nombre_Usuario").Value

        If _Accion = Enum_Accion.Nuevo Then

            Dim Fm As New Frm_Correos_Conf_SMTP(Frm_Correos_Conf_SMTP.Enum_Accion.Editar)
            Fm.Pro_Nombre_Usuario = _Nombre_Usuario
            Fm.ShowDialog(Me)
            If Fm.Pro_Grabar Then
                Sb_Actualizar_Grilla()
            End If
            Fm.Dispose()

        ElseIf _Accion = Enum_Accion.Seleccionar Then

            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Correos_Cuentas Where Nombre_Usuario = '" & _Nombre_Usuario & "'"
            _Row_Cuenta = _Sql.Fx_Get_DataRow(Consulta_Sql)
            Me.Close()

        End If

    End Sub

    Private Sub Btn_CrearCorreo_Click(sender As Object, e As EventArgs) Handles Btn_CrearCorreo.Click

        Dim Fm As New Frm_Correos_Conf_SMTP(Frm_Correos_Conf_SMTP.Enum_Accion.Nuevo)
        Fm.ShowDialog(Me)
        If Fm.Pro_Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

End Class
