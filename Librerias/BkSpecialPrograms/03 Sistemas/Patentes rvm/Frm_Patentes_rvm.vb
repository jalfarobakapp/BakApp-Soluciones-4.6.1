Imports DevComponents.DotNetBar

Public Class Frm_Patentes_rvm

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Id As Integer
    Dim _Row_Patente_rvm As DataRow

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Txt_Patente.Text = String.Empty

    End Sub

    Private Sub Frm_Patentes_rvm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Btn_Eliminar.Visible = False
        Me.ActiveControl = Txt_Patente
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_Patente.Text) Then
            MessageBoxEx.Show(Me, "Falta la patente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Patente.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Marca.Text) Then
            MessageBoxEx.Show(Me, "Falta la marca", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Marca.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Modelo.Text) Then
            MessageBoxEx.Show(Me, "Falta el modelo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Modelo.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_ModeloBusqueda.Text) Then
            MessageBoxEx.Show(Me, "Falta el modelo de busqueda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_ModeloBusqueda.Focus()
            Return
        End If

        If Not CBool(Input_AFabricacion.Value) Then
            MessageBoxEx.Show(Me, "Falta el año", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Input_AFabricacion.Focus()
            Return
        End If

        If IsNothing(_Row_Patente_rvm) Then
            Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Patentes_rvm (Patente) Values ('" & Txt_Patente.Text & "')"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_Sql, _Id)
        End If

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Patentes_rvm Set " &
                       "Marca = '" & Txt_Marca.Text & "'" &
                       ",Modelo = '" & Txt_Modelo.Text & "'" &
                       ",AFabricacion = " & Input_AFabricacion.Value &
                       ",ModeloBusqueda = '" & Txt_ModeloBusqueda.Text & "'" & vbCrLf &
                       "Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call Txt_Patente_ButtonCustom2Click(Nothing, Nothing)
        End If

    End Sub


    Function Fx_Buscar_Patente() As Boolean

        Txt_Patente.ReadOnly = False
        'Txt_Patente.Text = String.Empty
        Btn_Eliminar.Visible = False
        _Id = 0

        If String.IsNullOrEmpty(Txt_Patente.Text) Then
            'Txt_Patente.ButtonCustom.Visible = True
            'Txt_Patente.ButtonCustom2.Visible = False
            _Row_Patente_rvm = Nothing
            Return False
        End If

        Consulta_Sql = "Select *,Marca+' '+Modelo+' año: '+AFabricacion As Descripcion,Marca+' '+ModeloBusqueda+' '+AFabricacion As DescripcionBusqueda" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Patentes_rvm Where Patente = '" & Txt_Patente.Text & "'"
        _Row_Patente_rvm = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If IsNothing(_Row_Patente_rvm) Then
            Txt_Patente.Text = String.Empty
            'Txt_Patente.ButtonCustom.Visible = True
            'Txt_Patente.ButtonCustom2.Visible = False
            Return False
        End If

        If Not IsNothing(_Row_Patente_rvm) Then
            'Txt_Patente.ButtonCustom.Visible = False
            Txt_Patente.ButtonCustom2.Visible = True
            Txt_Patente.ReadOnly = True
            Btn_Eliminar.Visible = True
            _Id = _Row_Patente_rvm.Item("Id")
            Txt_Marca.Text = _Row_Patente_rvm.Item("Marca")
            Txt_Modelo.Text = _Row_Patente_rvm.Item("Modelo")
            Txt_ModeloBusqueda.Text = _Row_Patente_rvm.Item("ModeloBusqueda")
            Input_AFabricacion.Value = _Row_Patente_rvm.Item("AFabricacion")
            Me.Refresh()
        End If

        Return True

    End Function

    Private Sub Txt_Patente_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Patente.KeyDown
        If e.KeyValue = Keys.Enter Then

            If String.IsNullOrEmpty(Txt_Patente.Text) Then
                MessageBoxEx.Show(Me, "La patente no puede estar vacía", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Patente.Focus()
                Return
            End If

            Dim _Patente As String = Txt_Patente.Text

            If Fx_Buscar_Patente() Then
                Txt_Modelo.Focus()
            Else
                If MessageBoxEx.Show(Me, "Patente " & _Patente & " no encontrada." & vbCrLf &
                                     "¿Desea crearla?", "Patente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Txt_Patente.ReadOnly = True
                    Txt_Patente.ButtonCustom2.Visible = True
                    Txt_Patente.Text = _Patente
                    Txt_Marca.Focus()
                Else
                    Txt_Patente.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Txt_Patente_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Patente.ButtonCustom2Click
        Txt_Patente.ReadOnly = False
        Txt_Patente.Text = String.Empty
        Txt_Marca.Text = String.Empty
        Txt_Modelo.Text = String.Empty
        Txt_ModeloBusqueda.Text = String.Empty
        Btn_Eliminar.Visible = False
        Txt_Patente.Focus()
    End Sub
End Class
