Imports DevComponents.DotNetBar

Public Class Frm_Formulario_Potencia

    Dim _PrecioBrutoUnitario As Double
    Dim _PorcentajeDescuentoOfrecido As Double
    Dim _RecargoConvenidoBruto As Double
    Dim _Impuestos As Double
    Dim _ValorImpuestos As Double
    Dim _PrecioNetoUnitario As Double
    Dim _DescuentoPorc As Double

    Dim _Untrasn As Integer
    Dim _PorIva As Double
    Dim _PorIla As Double
    Dim _Rtu As Double
    Dim _Potencia As Double

    Dim _Fila As DataGridViewRow
    Dim _Aceptar As Boolean

    Public Property Aceptar As Boolean
        Get
            Return _Aceptar
        End Get
        Set(value As Boolean)
            _Aceptar = value
        End Set
    End Property

    Public Sub New(ByVal Fila As DataGridViewRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fila = Fila

        _Untrasn = _Fila.Cells("Untrans").Value
        _PrecioNetoUnitario = _Fila.Cells("Precio").Value
        _PorIva = _Fila.Cells("PorIva").Value
        _PorIla = _Fila.Cells("PorIla").Value
        _Rtu = _Fila.Cells("Rtu").Value
        _Potencia = _Fila.Cells("Potencia").Value
        _DescuentoPorc = _Fila.Cells("DescuentoPorc").Value
        _Impuestos = (_PorIva + _PorIla) / 100

        If _Untrasn = 1 Then
            _RecargoConvenidoBruto = _Potencia
        Else
            _RecargoConvenidoBruto = _Rtu * _Potencia
        End If

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.None, False, False, False)

    End Sub

    Private Sub Frm_Formulario_Potencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Llenar_Variables()
        Sb_Calcular_Valores(True)

        AddHandler Grilla.CellBeginEdit, AddressOf Grilla_CellBeginEdit
        AddHandler Grilla.CellEndEdit, AddressOf Grilla_CellEndEdit

    End Sub

    Private Sub Grilla_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        Dim _Id As Integer = Grilla.CurrentRow.Index

        If _Id = 1 Or _Id = 2 Or _Id = 3 Then
            MessageBoxEx.Show(Me, "Celda no editable", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If

    End Sub

    Private Sub Grilla_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Grilla.Columns("Valores").ReadOnly = True

        With Grilla

            Dim _Id As Integer = .CurrentRow.Index

            If _Id = 0 Then ' Bruto

                Sb_Calcular_Valores(False)

            ElseIf _Id = 4 Then ' Neto

                Sb_Calcular_Valores(True)

            End If

        End With

    End Sub

    Sub Sb_Llenar_Variables()

        Dim dt As New DataTable("TblPotencia")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Codigo", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Descripcion", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Valores", System.Type.[GetType]("System.Double"))

        ',,,,,,

        dr = dt.NewRow() : dr("Codigo") = "01" : dr("Descripcion") = "Precio bruto unitario"
        dr("Valores") = _PrecioBrutoUnitario : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "02" : dr("Descripcion") = "Porcentaje de descuento ofrecido"
        dr("Valores") = _PorcentajeDescuentoOfrecido : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "03" : dr("Descripcion") = "Recargo convenido bruto"
        dr("Valores") = _RecargoConvenidoBruto : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "04" : dr("Descripcion") = "Impuestos (Iva/Ila)"
        dr("Valores") = _ValorImpuestos : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "05" : dr("Descripcion") = "Precio neto unitario"
        dr("Valores") = _PrecioNetoUnitario : dt.Rows.Add(dr)
        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        With Grilla

            .DataSource = Nothing
            .DataSource = dt

            .Columns("Codigo").Visible = False

            .Columns("Descripcion").Width = 215
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").ReadOnly = True

            .Columns("Valores").Width = 100
            .Columns("Valores").HeaderText = "Valores"
            .Columns("Valores").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Valores").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Valores").ReadOnly = True

        End With

        Grilla.CurrentCell = Grilla.Rows(4).Cells("Valores")

    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        _Fila.Cells("Precio").Value = _PrecioNetoUnitario
        _Aceptar = True
        Me.Close()
    End Sub

    Private Sub Frm_Formulario_Potencia_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Sub Sb_Calcular_Valores(_Neto As Boolean)

        If Not _Neto Then

            Dim _Total_Bruto As Double

            _Total_Bruto = Grilla.Rows(0).Cells("Valores").Value
            _PrecioBrutoUnitario = _Total_Bruto
            _PorcentajeDescuentoOfrecido = _Total_Bruto * (Math.Round(_DescuentoPorc, 2) / 100)
            _Total_Bruto -= _RecargoConvenidoBruto + _PorcentajeDescuentoOfrecido '_PorcentajeDescuentoOfrecido
            _PrecioNetoUnitario = Math.Round(_Total_Bruto / (_Impuestos + 1), 2)
            _ValorImpuestos = _PrecioNetoUnitario * _Impuestos

        Else

            _PrecioNetoUnitario = Grilla.Rows(4).Cells("Valores").Value
            _PrecioBrutoUnitario = Math.Round((_PrecioNetoUnitario * (_Impuestos + 1)) + _RecargoConvenidoBruto, 2)
            _PorcentajeDescuentoOfrecido = _PrecioBrutoUnitario * (_DescuentoPorc / 100)
            _PrecioBrutoUnitario += _PorcentajeDescuentoOfrecido
            _ValorImpuestos = _PrecioNetoUnitario * _Impuestos

        End If

        Grilla.Rows(0).Cells("Valores").Value = _PrecioBrutoUnitario
        Grilla.Rows(1).Cells("Valores").Value = _PorcentajeDescuentoOfrecido
        Grilla.Rows(2).Cells("Valores").Value = _RecargoConvenidoBruto
        Grilla.Rows(3).Cells("Valores").Value = _ValorImpuestos
        Grilla.Rows(4).Cells("Valores").Value = _PrecioNetoUnitario

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown

        If e.KeyValue = Keys.Enter Then

            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            If _Cabeza = "Valores" Then

                Dim _Id As Integer = Grilla.CurrentRow.Index

                If _Id = 0 Or _Id = 4 Then

                    Grilla.Columns(_Cabeza).ReadOnly = False
                    Grilla.BeginEdit(True)

                Else

                    Beep()

                End If

                e.SuppressKeyPress = False
                e.Handled = True

            End If

        End If

    End Sub

    Private Sub Sb_Validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' Obtener caracter  
        Dim _Caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim _Txt As TextBox = CType(sender, TextBox)

            If e.KeyChar = "."c Then
                ' si se pulsa la coma se convertirá en punto
                'e.Handled = True
                SendKeys.Send(",")
                e.KeyChar = ","c
                _Caracter = ","
            End If

            Dim _Caracter_Raro = ChrW(Keys.Back)
            Dim _EsNumero As Boolean = Char.IsNumber(_Caracter)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  
            If (Char.IsNumber(_Caracter)) Or
               (_Caracter = ChrW(Keys.Back)) Or
               (_Caracter = ",") And
               (_Txt.Text.Contains(",") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

    End Sub

    Private Sub Grilla_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Grilla.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        AddHandler validar.KeyPress, AddressOf Sb_Validar_Keypress
    End Sub

End Class