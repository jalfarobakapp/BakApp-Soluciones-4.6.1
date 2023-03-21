Imports System.Web.Services
Imports DevComponents.DotNetBar
Public Class Frm_St_OperacionesCrear

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Operacion As Integer
    Dim _Operacion As String
    Dim _RowOperacion As DataRow

    Dim _Nuevo, _Editar As Boolean
    Public Property Grabar As Boolean
    Public Property Eliminar As Boolean

    Public Property RowOperacion As DataRow
        Get
            Return _RowOperacion
        End Get
        Set(value As DataRow)
            _RowOperacion = value
        End Set
    End Property

    Public Sub New(_Operacion As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Operacion = _Operacion

        If Not String.IsNullOrEmpty(_Operacion) Then
            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_Operaciones Where Operacion = '" & _Operacion & "'"
            _RowOperacion = _Sql.Fx_Get_DataRow(Consulta_sql)
        End If

        If IsNothing(_RowOperacion) Then
            _Nuevo = True
        Else
            _Editar = True
            _Id_Operacion = _RowOperacion.Item("Id")
        End If

    End Sub
    Private Sub Frm_St_OperacionesCrear_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Txt_Precio.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros
        AddHandler Txt_Precio.Validated, AddressOf Sb_Txt_Nros_Validated

        Txt_Precio.Tag = 0
        Txt_Precio.Enabled = True

        If _Editar Then
            Txt_Operacion.Text = _RowOperacion.Item("Operacion")
            Txt_Operacion.Enabled = False
            Txt_Descripcion.Text = _RowOperacion.Item("Descripcion")
            Txt_Precio.Tag = _RowOperacion.Item("Precio")
            Txt_Precio.Text = FormatNumber(Txt_Precio.Tag, 0)
            Rdb_CantMayor1.Checked = _RowOperacion.Item("CantMayor1")
            Rdb_Externa.Checked = _RowOperacion.Item("Externa")
            ActiveControl = Txt_Descripcion
        End If

        If _Nuevo Then
            Txt_Operacion.Enabled = True
            ActiveControl = Txt_Operacion
        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_St_OT_Recetas_Ope", "Operacion  = '" & Txt_Operacion.Text & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Esta operación esta asociada a (" & _Reg & ") receta(s)" & vbCrLf &
                              "Debe quitar la operación de todas las recetas en las que esta para poder eliminarla", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar esta operación?", "Eliminar operación",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Consulta_sql = "Delete Update " & _Global_BaseBk & "Zw_St_OT_Operaciones" & vbCrLf &
                           "Where Id = " & _Id_Operacion
            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                Eliminar = True
                Me.Close()
            End If

        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Operacion As String = Txt_Operacion.Text
        Dim _Descripcion As String = Txt_Descripcion.Text
        Dim _Precio As String = De_Num_a_Tx_01(Txt_Precio.Tag, False, 5)
        Dim _Externa As Integer = Convert.ToInt32(Rdb_Externa.Checked)
        Dim _CantMayor1 As Integer = Convert.ToInt32(Rdb_CantMayor1.Checked)

        If String.IsNullOrEmpty(Txt_Operacion.Text) Then
            MessageBoxEx.Show(Me, "Falta el código de la operación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Operacion.Focus()
            Return
        End If

        If Txt_Operacion.Text.Trim.Length < 5 Then
            MessageBoxEx.Show(Me, "El código de la operación debe tener 5 caracteres", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Operacion.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Descripcion.Text) Then
            MessageBoxEx.Show(Me, "Falta la descripción de la operación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Descripcion.Focus()
            Return
        End If

        If Not CBool(Txt_Precio.Tag) Then
            MessageBoxEx.Show(Me, "Falta el precio de la operación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Descripcion.Focus()
            Return
        End If

        If _Nuevo Then

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_St_OT_Operaciones (Operacion,Descripcion,Precio,Externa,CantMayor1) Values " &
                           "('" & _Operacion & "','" & _Descripcion & "'," & _Precio & "," & _Externa & "," & _CantMayor1 & ")"
            If Not _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Operacion) Then
                Return
            End If
        End If

        If _Editar Then
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Operaciones Set " & vbCrLf &
                           "Descripcion = ''" &
                           ",Precio = 0" &
                           ",Externa = 0" &
                           ",CantMayor1 = 0" & vbCrLf &
                           "Where Id = " & _Id_Operacion
            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Return
            End If
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_Operaciones Where Id = " & _Id_Operacion
        _RowOperacion = _Sql.Fx_Get_DataRow(Consulta_sql)

        Grabar = True
        Me.Close()

    End Sub

    Private Sub Sb_Txt_Nros_Validated(sender As Object, e As EventArgs)
        CType(sender, Controls.TextBoxX).Tag = Val(CType(sender, Controls.TextBoxX).Text)
        CType(sender, Controls.TextBoxX).Text = FormatNumber(CType(sender, Controls.TextBoxX).Tag, 0)
    End Sub

End Class
