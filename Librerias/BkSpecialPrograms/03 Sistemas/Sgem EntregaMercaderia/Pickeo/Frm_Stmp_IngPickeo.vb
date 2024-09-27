Imports System.ComponentModel
Imports DevComponents.DotNetBar
Imports Limilabs.Mail.Appointments

Public Class Frm_Stmp_IngPickeo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _CodFuncionario_Pickea As String
    Dim _Row_Entidad As DataRow

    Public Property Cl_Stmp As Cl_Stmp
    Public Property ConfirmaDespacho As Boolean

    ' Crear un BindingSource y enlazarlo al DataGridView
    Dim _Source As BindingSource
    Dim _ContieneRtuVariable As Boolean

    Public Sub New(_Id_Enc As Integer, _CodFuncionario_Pickea As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._CodFuncionario_Pickea = _CodFuncionario_Pickea
        Cl_Stmp = New Cl_Stmp

        _Cl_Stmp.Fx_Llenar_Encabezado(_Id_Enc)
        _Cl_Stmp.Fx_Llenar_Detalle(_Id_Enc)
        _Cl_Stmp.Fx_Llenar_Detalle_Pickeo(_Id_Enc)

        _Row_Entidad = Fx_Traer_Datos_Entidad(Cl_Stmp.Zw_Stmp_Enc.Endo, Cl_Stmp.Zw_Stmp_Enc.Suendo)

        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Stmp_IngPickeo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Txt_Numero.Text = Cl_Stmp.Zw_Stmp_Enc.Numero.ToString.Trim
        Txt_TidoNudo.Text = Cl_Stmp.Zw_Stmp_Enc.Tido.ToString.Trim & " - " & Cl_Stmp.Zw_Stmp_Enc.Nudo.ToString.Trim
        Txt_Entidad.Text = _Row_Entidad.Item("NOKOEN").ToString.Trim

        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        '' Crear un BindingList a partir de la lista
        Dim bindingList As New BindingList(Of Zw_Stmp_Det)(_Cl_Stmp.Zw_Stmp_Det)

        ' Crear un BindingSource y enlazarlo al DataGridView
        _Source = New BindingSource(bindingList, Nothing)

        Dim _DisplayIndex = 0

        With Grilla_Detalle

            .DataSource = _Source

            OcultarEncabezadoGrilla(Grilla_Detalle, True)

            .Columns("Pickeado").Width = 40
            .Columns("Pickeado").HeaderText = "Pick."
            .Columns("Pickeado").ReadOnly = True
            .Columns("Pickeado").Visible = True
            .Columns("Pickeado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Width = 250
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UdMedida").Width = 30
            .Columns("UdMedida").HeaderText = "UM"
            .Columns("UdMedida").ReadOnly = True
            .Columns("UdMedida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("UdMedida").Visible = True
            .Columns("UdMedida").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Caprco1_Ori").Width = 60
            .Columns("Caprco1_Ori").HeaderText = "Cant.Ori"
            .Columns("Caprco1_Ori").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Caprco1_Ori").DefaultCellStyle.Format = "###,##0.#####"
            .Columns("Caprco1_Ori").Visible = True
            .Columns("Caprco1_Ori").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantidad").Width = 60
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##0.#####"
            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Refresh()

        End With

    End Sub

    Private Sub Btn_Marcar_Todo_Click(sender As Object, e As EventArgs)

        For Each _Fila As Zw_Stmp_Det In _Cl_Stmp.Zw_Stmp_Det

            Dim _Codigo = _Fila.Codigo

        Next

    End Sub

    Private Sub Grilla_Detalle_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla_Detalle.KeyDown

        Dim _Cabeza = Grilla_Detalle.Columns(Grilla_Detalle.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)

        Dim _Index As Integer = _Fila.Index

        Dim _Caprco1_Real As Double = _Fila.Cells("Caprco1_Real").Value
        Dim _Caprco2_Real As Double = _Fila.Cells("Caprco2_Real").Value
        Dim _Caprco1_Ori As Double = _Fila.Cells("Caprco1_Ori").Value
        Dim _Caprco2_Ori As Double = _Fila.Cells("Caprco2_Ori").Value
        Dim _Ud01pr As String = _Fila.Cells("Ud01pr").Value
        Dim _Ud02pr As String = _Fila.Cells("Ud02pr").Value

        Dim _RtuVariable As Boolean = _Fila.Cells("RtuVariable").Value

        Select Case e.KeyValue

            Case Keys.Enter

                If _Cabeza = "Cantidad" Then

                    If Not _RtuVariable Then

                        SendKeys.Send("{F2}")
                        e.Handled = True
                        Grilla_Detalle.Columns(_Cabeza).ReadOnly = False
                        Grilla_Detalle.BeginEdit(True)

                    Else

                        Dim Fm As New Frm_Stmp_IngCantVar(_Caprco1_Ori, _Caprco2_Ori)
                        Fm.Cantidad_Ud1 = _Caprco1_Real
                        Fm.Cantidad_Ud2 = _Caprco2_Real
                        Fm.LblUnidad1.Text = _Ud01pr
                        Fm.LblUnidad2.Text = _Ud02pr
                        Fm.ShowDialog(Me)

                        If Fm.Aceptar Then

                            _Fila.Cells("Cantidad").Value = Fm.Cantidad_Ud1
                            _Fila.Cells("Caprco1_Real").Value = Fm.Cantidad_Ud1
                            _Fila.Cells("Caprco2_Real").Value = Fm.Cantidad_Ud2

                            _Fila.Cells("CodFuncionario_Pickea").Value = _CodFuncionario_Pickea

                            If _Fila.Cells("Caprco2_Real").Value = 0 Then
                                _Fila.Cells("Rlud_Real").Value = 0
                            Else
                                _Fila.Cells("Rlud_Real").Value = Math.Round(_Fila.Cells("Caprco1_Real").Value / _Fila.Cells("Caprco2_Real").Value, 5)
                            End If

                            _Fila.Cells("Pickeado").Value = True
                            _Fila.Cells("EnProceso").Value = False

                        End If

                        Fm.Dispose()

                    End If

                End If

            Case Keys.Delete

                Grilla_Detalle.Rows.RemoveAt(_Index)

                MessageBoxEx.Show(Me, "Fila eliminada", "Eliminar Fila", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End Select

        Dim _ss = _Cl_Stmp.Zw_Stmp_Det

    End Sub

    Private Sub Grilla_Detalle_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Detalle.CellEndEdit

        Dim _Cabeza = Grilla_Detalle.Columns(Grilla_Detalle.CurrentCell.ColumnIndex).Name

        Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)
        Dim _Indice As Integer = Grilla_Detalle.CurrentRow.Index

        Grilla_Detalle.Columns(_Cabeza).ReadOnly = True

        Dim _Cantidad As Double = _Fila.Cells("Cantidad").Value
        Dim _Cantidad_Ori As Double
        Dim _Udtrpr As Integer = _Fila.Cells("Udtrpr").Value
        Dim _Rludpr As Double = _Fila.Cells("Rludpr").Value

        _Cantidad_Ori = _Fila.Cells("Caprco" & _Udtrpr & "_Ori").Value

        If _Cantidad > _Cantidad_Ori Then

            MessageBoxEx.Show(Me, "No puede despachar una cantidad mayor a la del documento", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

            _Fila.Cells("Cantidad").Value = 0
            _Fila.Cells("CodFuncionario_Pickea").Value = String.Empty
            _Fila.Cells("Caprco1_Real").Value = 0
            _Fila.Cells("Caprco2_Real").Value = 0
            _Fila.Cells("Rlud_Real").Value = 0
            _Fila.Cells("Pickeado").Value = False
            _Fila.Cells("EnProceso").Value = True

        Else

            If _Cantidad = 0 Then

                If MessageBoxEx.Show(Me, "¿Confirma el valor cero para esta línea?", "Validación",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
                    _Fila.Cells("Pickeado").Value = False
                    Return
                End If

            End If

            _Fila.Cells("CodFuncionario_Pickea").Value = _CodFuncionario_Pickea
            _Fila.Cells("Caprco1_Real").Value = _Cantidad
            _Fila.Cells("Caprco2_Real").Value = _Cantidad / _Rludpr

            If _Cantidad = 0 Then
                _Fila.Cells("Rlud_Real").Value = 0
            Else
                _Fila.Cells("Rlud_Real").Value = _Fila.Cells("Caprco2_Real").Value / _Fila.Cells("Caprco1_Real").Value
            End If

            _Fila.Cells("Pickeado").Value = True
            _Fila.Cells("EnProceso").Value = False

        End If

        Me.Refresh()

    End Sub

    Private Sub Btn_Confirmar_Click(sender As Object, e As EventArgs) Handles Btn_Confirmar.Click

        For Each _Fila As Zw_Stmp_Det In _Cl_Stmp.Zw_Stmp_Det

            If Not _Fila.Pickeado Then
                MessageBoxEx.Show(Me, "Existen registros que aun no han sido confirmados", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        Next

        _Cl_Stmp.Zw_Stmp_Enc.Estado = "COMPL"

        Dim _Mensaje As New LsValiciones.Mensajes
        _Mensaje = _Cl_Stmp.Fx_Confirmar_Picking

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Confirmar Picking", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Confirmar Picking", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

        ConfirmaDespacho = True

    End Sub


End Class
