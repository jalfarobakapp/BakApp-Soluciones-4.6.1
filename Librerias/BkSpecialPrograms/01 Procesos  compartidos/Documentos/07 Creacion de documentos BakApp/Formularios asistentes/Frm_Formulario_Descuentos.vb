Imports DevComponents.DotNetBar

Public Class Frm_Formulario_Descuentos

    Dim _Ds_Matriz_Documentos As DataSet
    Dim _Id As Integer
    Dim _Precio As Double
    Dim _Total_Valor As Double
    Dim _Total_Pc As Double
    Dim _Total_Descuento As Double
    Dim _NroDscto As Integer
    Dim _Formulario_Padre As Form
    Dim _Fila As DataGridViewRow
    Dim _Vizado As Boolean
    Dim _Redondear_Dscto As Boolean

    Public Property Pro_Redondear_Dscto() As Boolean
        Get
            Return _Redondear_Dscto
        End Get
        Set(ByVal value As Boolean)
            _Redondear_Dscto = value
        End Set
    End Property

    Public ReadOnly Property Pro_Total_Valor() As Double
        Get
            Return _Total_Valor
        End Get
    End Property

    Public ReadOnly Property Pro_Total_Pc() As Double
        Get
            Return _Total_Pc
        End Get
    End Property

    Public ReadOnly Property Pro_Total_Descuento() As Double
        Get
            Return _Total_Descuento
        End Get
    End Property

    Public ReadOnly Property Pro_NroDscto() As Integer
        Get
            Return _NroDscto
        End Get
    End Property

    Public Sub New(_Ds_Matriz_Documentos As DataSet,
                   _Fila As DataGridViewRow,
                   _Precio As Double)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._Fila = _Fila
        Me._Precio = _Precio
        Me._Ds_Matriz_Documentos = _Ds_Matriz_Documentos

        _Id = _Fila.Cells("Id").Value

        Lbl_Codigo.Text = "Código: " & _Fila.Cells("Codigo").Value
        Lbl_Descripcion.Text = _Fila.Cells("Descripcion").Value

        _Vizado = _Ds_Matriz_Documentos.Tables("Encabezado_Doc").Rows(0).Item("Vizado")

        Sb_Formato_Generico_Grilla(Grilla_Descuentos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

    End Sub

    Private Sub Frm_Formulario_Descuentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Llenar_Grilla()

        AddHandler Grilla_Descuentos.CellBeginEdit, AddressOf Grilla_Descuentos_CellBeginEdit
        AddHandler Grilla_Descuentos.CellEndEdit, AddressOf Grilla_Descuentos_CellEndEdit

        AddHandler Grilla_Descuentos.RowValidating, AddressOf Grilla_Descuentos_RowValidating

        If _Vizado Then
            Me.Text += Space(1) & "(Documento Visado)"
        Else
            AddHandler Grilla_Descuentos.KeyDown, AddressOf Grilla_Descuentos_KeyDown
        End If

        Grilla_Descuentos.CurrentCell = Grilla_Descuentos.Rows(0).Cells("Podt")

    End Sub

    Private Sub Grilla_Descuentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        With Grilla_Descuentos

            Dim NroFila As Integer = .CurrentRow.Index
            Dim CantFilas As Integer = .Rows.Count

            If .Rows(.CurrentRow.Index).IsNewRow Then Return

            If e.KeyValue = Keys.Delete Then
                If NroFila = CantFilas - 2 Then

                    e.Handled = True

                    If .Rows(.CurrentRow.Index).IsNewRow Then
                        Return
                    End If

                    If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar la(s) fila(s) seleccionada(s)?",
                                     "Eliminar fila", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        .Rows.RemoveAt(.CurrentRow.Index)
                    End If
                Else
                    MessageBoxEx.Show(Me, "Esta linea no se puede eliminar, debe empezar de abajo hacia arriba",
                                      "Eliminar fila", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                Sb_Sumar_Totales()
            End If

        End With

    End Sub

    Private Sub Grilla_Descuentos_RowValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        Dim Podt = NuloPorNro(sender.Rows(sender.CurrentRow.Index).Cells("Podt").VALUE, 0)
        Dim Vadt = sender.Rows(sender.CurrentRow.Index).Cells("Vadt").VALUE

        If Grilla_Descuentos.Rows(e.RowIndex).IsNewRow Then
            e.Cancel = False
            Return
        End If

        If Podt = 0 And Vadt = 0 Then
            Beep()
            e.Cancel = True
        End If

        sender.Rows(sender.CurrentRow.Index).Cells(0).VALUE = "D_SIN_TIPO"

    End Sub

    Private Sub Grilla_Descuentos_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Podt As Double
        Dim _Vadt As Double
        Dim _Podt_Original As Double

        Dim _Valor As Double
        Dim _Cancelar As Boolean

        Dim _Fila As DataGridViewRow = Grilla_Descuentos.Rows(Grilla_Descuentos.CurrentRow.Index)

        With Grilla_Descuentos

            Dim _IndexFila As Integer = .CurrentRow.Index
            Dim _Cabeza = .Columns(e.ColumnIndex).Name

            _Podt = NuloPorNro(_Fila.Cells("Podt").Value, 0)
            _Vadt = NuloPorNro(_Fila.Cells("Vadt").Value, 0)
            _Podt_Original = NuloPorNro(_Fila.Cells("Podt").Value, 5)

            If .Rows(.CurrentRow.Index).IsNewRow Then Return

            Dim NroFila As Integer = Grilla_Descuentos.CurrentRow.Index
            Dim CantFilas As Integer = Grilla_Descuentos.Rows.Count

            If Grilla_Descuentos.Rows(_IndexFila + 1).IsNewRow Then

                If (_Cabeza = "Podt" And _Podt = 0) Or (_Cabeza = "Vadt" And _Vadt = 0) Then
                    If Not Grilla_Descuentos.Rows(e.RowIndex).IsNewRow Then
                        Grilla_Descuentos.Rows.RemoveAt(_IndexFila)
                        Sb_Sumar_Totales()
                        Return
                    End If
                End If

            End If

            If _Cabeza = "Podt" Then
                If _Podt = 0 Then
                    If Grilla_Descuentos.RowCount = 2 Then

                    End If
                    _Cancelar = True
                End If
            ElseIf _Cabeza = "Vadt" Then
                If _Vadt = 0 Then _Cancelar = True
            End If

            If _Cancelar Then
                MessageBoxEx.Show(Me, "No se puede ingresar un valor 0" & vbCrLf &
                                  "Debe eliminar las líneas", "Restricción", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                _Vadt = _Fila.Cells("UltDscto").Value
                _Podt = 0
                _Podt_Original = 0
                _Cabeza = "Vadt"

            End If

            _Fila.Cells("Podt").Value = 0
            _Fila.Cells("Vadt").Value = 0

            Sb_Sumar_Totales()
            _Valor = _Precio - _Total_Descuento

            If _Cabeza = "Podt" Then

                If _Podt <> 0 Then
                    _Vadt = Math.Round((_Podt / 100) * _Valor, 0)
                    If _Redondear_Dscto Then _Vadt = Fx_Redondeo_Descuento(_Vadt, _Redondear_Dscto)
                    _Podt = Math.Round((_Vadt / _Valor) * 100, 5)
                Else
                    _Vadt = 0
                End If

            ElseIf _Cabeza = "Vadt" Then

                If _Vadt <> 0 Then
                    If _Redondear_Dscto Then _Vadt = Fx_Redondeo_Descuento(_Vadt, _Redondear_Dscto)

                    _Podt = Math.Round((_Vadt / _Valor) * 100, 5)
                Else
                    _Podt = 0
                End If

            End If

            _Fila.Cells("Podt").Value = _Podt
            _Fila.Cells("Vadt").Value = _Vadt
            _Fila.Cells("UltDscto").Value = _Vadt
            _Fila.Cells("Podt_Original").Value = _Podt_Original
            _Fila.Cells("CodDscto").Value = "D_SIN_TIPO"

        End With

        Sb_Sumar_Totales()
        Sb_Llenar_Tabla_Paso()

    End Sub

    Sub Sb_Llenar_Grilla()

        Grilla_Descuentos.AllowUserToAddRows = Not _Vizado

        Dim _Tbl = _Ds_Matriz_Documentos.Tables("Descuentos_Doc").Select("Id = " & _Id)

        For Each _Fila As DataRow In _Tbl

            Dim _Orden As Integer = NuloPorNro(_Fila("Orden"), 0)
            Dim _Podt As Double = NuloPorNro(_Fila("Podt"), 0)
            Dim _Vadt As Double = NuloPorNro(_Fila("Vadt"), 0)
            Dim _Podt_Original As Double = NuloPorNro(_Fila("Podt_Original"), 0)

            If _Podt <> 0 Then
                Grilla_Descuentos.Rows.Add("D_SIN_TIPO", _Podt, _Vadt, _Vadt, _Podt_Original)
            End If

        Next

        Grilla_Descuentos.Columns("Podt").ReadOnly = _Vizado
        Grilla_Descuentos.Columns("Vadt").ReadOnly = _Vizado

        Sb_Sumar_Totales()

    End Sub

    Sub Sb_Sumar_Totales()

        _Total_Descuento = 0
        _Total_Pc = 0

        For Each _Fila As DataGridViewRow In Grilla_Descuentos.Rows

            Dim _Podt As Double = NuloPorNro(_Fila.Cells("PODT").Value, 0)
            Dim _Vadt As Double = NuloPorNro(_Fila.Cells("VADT").Value, 0)

            _Total_Descuento += _Vadt

        Next

        _Total_Descuento = Math.Round(_Total_Descuento, 0)

        If _Total_Descuento <> 0 Then
            _Total_Pc = _Total_Descuento / _Precio
        End If

        Lbl_DescuentoPorc.Text = FormatPercent(_Total_Pc, 5)
        Lbl_DescuentoValor.Text = FormatCurrency(_Total_Descuento, 2)
        Lbl_Total.Text = FormatCurrency(_Precio - _Total_Descuento, 2)

    End Sub

    Sub Sb_Llenar_Tabla_Paso()

        _NroDscto = 0
        Eliminar_Campos(_Ds_Matriz_Documentos.Tables("Descuentos_Doc"), _Id)

        For Each _Fila As DataGridViewRow In Grilla_Descuentos.Rows

            Dim _Podt As Double = NuloPorNro(_Fila.Cells("PODT").Value, 0)
            Dim _Vadt As Double = NuloPorNro(_Fila.Cells("VADT").Value, 0)
            Dim _Podt_Original As Double = NuloPorNro(_Fila.Cells("Podt_Original").Value, 0)

            If _Podt <> 0 Then

                Dim NewFila As DataRow
                NewFila = _Ds_Matriz_Documentos.Tables("Descuentos_Doc").NewRow
                With NewFila
                    .Item("Id") = _Id
                    .Item("Podt") = _Podt
                    .Item("Vadt") = _Vadt
                    .Item("Podt_Original") = _Podt_Original
                    _Ds_Matriz_Documentos.Tables("Descuentos_Doc").Rows.Add(NewFila)
                End With

                _NroDscto += 1

            End If
        Next

    End Sub

    Private Sub Frm_Formulario_Descuentos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Formulario_Descuentos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Sb_Llenar_Tabla_Paso()
    End Sub

    Private Sub Grilla_Descuentos_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)

        Dim _Fila As DataGridViewRow = Grilla_Descuentos.Rows(Grilla_Descuentos.CurrentRow.Index)
        Dim _Cabeza = Grilla_Descuentos.Columns(e.ColumnIndex).Name

        Dim NroFila As Integer = Grilla_Descuentos.CurrentRow.Index
        Dim CantFilas As Integer = Grilla_Descuentos.Rows.Count

        If _Cabeza = "CodDscto" Then
            If Not Grilla_Descuentos.Rows(e.RowIndex).IsNewRow Then
                e.Cancel = True
                Return
            End If
        End If

        If NroFila <> CantFilas - 2 Then
            If Not _Fila.IsNewRow Then
                MessageBoxEx.Show(Me, "Las modificaciones deben ser de abajo hacia arriba" & vbCrLf &
                              "Debe eliminar las líneas", "Restricción", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                e.Cancel = True
            End If
        End If

    End Sub

End Class
