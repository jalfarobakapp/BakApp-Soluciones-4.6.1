Imports DevComponents.DotNetBar

Public Class Frm_Operadores_Crear

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Operador As DataRow
    Dim _Id_Inventario As Integer
    Dim _Id_Operador As Integer
    Dim _Grabar As Boolean
    Dim _Eliminado As Boolean

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Eliminado As Boolean
        Get
            Return _Eliminado
        End Get
        Set(value As Boolean)
            _Eliminado = value
        End Set
    End Property

    Public Sub New(_Id_Inventario As Integer, _Id_Operador As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Inventario = _Id_Inventario
        Me._Id_Operador = _Id_Operador

        If CBool(_Id_Operador) Then
            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Operadores Where Id_Operador = " & _Id_Operador
            _Row_Operador = _Sql.Fx_Get_DataRow(Consulta_sql)
        End If

    End Sub

    Private Sub Frm_Operadores_Crear_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not IsNothing(_Row_Operador) Then

            Txt_Codigo.Text = numero_(_Row_Operador.Item("Id_Operador"), 5)
            Txt_Rut.Text = _Row_Operador.Item("Rut")
            Txt_Direccion.Text = _Row_Operador.Item("Direccion")
            Txt_Nombre.Text = _Row_Operador.Item("Nombre")
            Txt_Telefono.Text = _Row_Operador.Item("Telefono")
            Txt_Email.Text = _Row_Operador.Item("Email")
            Sw_Habilitado.Value = _Row_Operador.Item("Habilitado")
            Btn_Eliminar.Visible = True
            AddHandler Sw_Habilitado.ValueChanged, AddressOf Sw_Habilitado_ValueChanged

        Else

            Sw_Habilitado.Value = True
            Sw_Habilitado.Enabled = False
            Btn_Eliminar.Visible = False

        End If


    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_Rut.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el Rut", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Rut.Focus()
            Return
        End If

        Dim _Ref As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Operadores",
                                                       "Id_Inventario = " & _Id_Inventario & " And Id_Operador <> " & _Id_Operador & " And Rut = '" & Txt_Rut.Text.Trim & "'")

        If CBool(_Ref) Then
            MessageBoxEx.Show(Me, "Ya existe un operador con el mismo Rut", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Rut.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Nombre.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el Nombre", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Rut.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Direccion.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta la Dirección", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Direccion.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Telefono.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el Teléfono", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Telefono.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Email.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el Email", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Email.Focus()
            Return
        End If


        If IsNothing(_Row_Operador) Then

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Inv_Operadores (Id_Inventario,FechaCreacion,Habilitado) Values (" & _Id_Inventario & ",Getdate(),1)"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Operador)

        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Inv_Operadores Set " &
                       "Rut = '" & Txt_Rut.Text.Trim & "'" &
                       ",Nombre = '" & Txt_Nombre.Text.Trim & "'" &
                       ",Direccion = '" & Txt_Direccion.Text.Trim & "'" &
                       ",Telefono = '" & Txt_Telefono.Text.Trim & "'" &
                       ",Email = '" & Txt_Email.Text.Trim & "'" &
                       ",Habilitado = " & Convert.ToInt32(Sw_Habilitado.Value) & vbCrLf &
                       "Where Id_Operador = " & _Id_Operador
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            _Grabar = True
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        End If

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        'If Fx_Tiene_Permiso(Me, "") Then

        If Not Fx_Se_Puede_Eliminar_Operador(_Id_Operador) Then
            MessageBoxEx.Show(Me, "No se puede eliminar a este operador, ya que tiene datos en procesos de inventarios" & vbCrLf &
                              "Se recomienda deshabilitar al operador", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Esta seguro de querer eliminar este operador?", "Eliminar operador", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Inv_Operadores Where Id_Operador = " & _Id_Operador

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                _Grabar = True
                _Eliminado = True
                MessageBoxEx.Show(Me, "Operador eliminado correctamente", "Eliminar operador", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If

        End If

        'End If

    End Sub

    Function Fx_Se_Puede_Eliminar_Operador(_Id_Operador As Integer) As Boolean

        Dim _Ref As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Parejas", "Id_Operador1 = " & _Id_Operador & " Or Id_Operador2 = " & _Id_Operador)

        If CBool(_Ref) Then
            Return False
        End If

        _Ref = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Toma", "Id_Operador1 = " & _Id_Operador & " Or Id_Operador2 = " & _Id_Operador)

        If CBool(_Ref) Then
            Return False
        End If

        Return True

    End Function

    Function Fx_Se_Puede_Deshabilitar_Operador(_Id_Operador As Integer) As Boolean

        Consulta_sql = "Select Count(*) As Cuenta From " & _Global_BaseBk & "Zw_Inv_Plan" & vbCrLf &
                        "Where" & vbCrLf &
                        "Id_Pareja In (Select Id_Pareja From " & _Global_BaseBk & "Zw_Inv_Parejas " &
                        "Where Id_Operador1 = " & _Id_Operador & " Or Id_Operador2 = " & _Id_Operador & ")" & vbCrLf &
                        "And Id_Inventario In (Select Id_Inventario From " & _Global_BaseBk & "Zw_Inv_Inventario Where Activo = 1)"

        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Ref As Integer = _Row.Item("Cuenta")

        If CBool(_Ref) Then
            Return False
        End If

        Return True

    End Function

    Private Sub Sw_Habilitado_ValueChanged(sender As Object, e As EventArgs)

        If Not Sw_Habilitado.Value Then

            If Not Fx_Se_Puede_Deshabilitar_Operador(_Id_Operador) Then
                Sw_Habilitado.Value = True
                MessageBoxEx.Show(Me, "No se puede deshabilitar a este operador ya que se encuentra en una pareja de un Inventario activo", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub
End Class
