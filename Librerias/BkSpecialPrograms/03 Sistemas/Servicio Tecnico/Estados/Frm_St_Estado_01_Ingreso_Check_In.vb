Imports DevComponents.DotNetBar
Imports System.Data.SqlClient

Public Class Frm_St_Estado_01_Ingreso_Check_In

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Ot As Integer
    Dim _Grabar As Boolean
    Dim _Editando_documento As Boolean
    Dim _DsDocumento As DataSet

    Dim _Row_Encabezado As DataRow
    Dim _Tbl_DetProd As DataTable
    Dim _Tbl_ChekIn As DataTable
    Dim _Tbl_Accesorios As DataTable
    Dim _Row_Notas As DataRow

    Dim _Accion As Accion

    Enum Accion
        Nuevo
        Editar
    End Enum

    Dim Imagenes_32x32 As ImageList

    Public Sub New(Id_Ot As Integer, Accion As Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Accion = Accion
        _Id_Ot = Id_Ot

    End Sub
    Private Sub Frm_St_Estado_01_Asignacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Sb_InsertarBotonenGrilla(Grill_Check_In, "BtnImagen", "Situación", "Solicitud", 0, _Tipo_Boton.Imagen)
        Sb_InsertarBotonenGrilla(Grilla_Accesorios, "BtnImagen", "Situación", "Solicitud", 0, _Tipo_Boton.Imagen)

        Sb_Formato_Generico_Grilla(Grill_Check_In, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Accesorios, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Dim _Solo_Lectura As Boolean

        If _Accion = Accion.Editar Then

            Btn_Aceptar.Visible = False
            Btn_Grabar.Visible = True
            Btn_Grabar.Enabled = False
            Btn_Editar.Visible = True

            Me.ControlBox = True
            _Solo_Lectura = True
            Btn_Agregar_Check_In.Enabled = False
            Btn_Agregar_Accesorios.Enabled = False

            If _Row_Encabezado.Item("CodEstado") = "CE" Then
                Btn_Editar.Visible = False
            End If

        ElseIf _Accion = Accion.Nuevo Then

            Btn_Aceptar.Visible = True
            Btn_Grabar.Visible = False
            Btn_Editar.Visible = False
            Me.ControlBox = False

        End If

        Grill_Check_In.DataSource = _Tbl_ChekIn
        Grilla_Accesorios.DataSource = _Tbl_Accesorios

        AddHandler Grill_Check_In.KeyDown, AddressOf Grilla_Check_In_KeyDown
        AddHandler Grill_Check_In.CellBeginEdit, AddressOf Grilla_Check_In_CellBeginEdit
        AddHandler Grill_Check_In.CellEndEdit, AddressOf Grilla_Check_In_CellEndEdit

        AddHandler Grilla_Accesorios.KeyDown, AddressOf Grilla_Accesorios_KeyDown
        AddHandler Grilla_Accesorios.CellBeginEdit, AddressOf Grilla_Accesorios_CellBeginEdit
        AddHandler Grilla_Accesorios.CellEndEdit, AddressOf Grilla_Accesorios_CellEndEdit

        Sb_Formato_Grillas(_Solo_Lectura)

        Sb_Marcar_Grillas(Grill_Check_In, Imagenes_16x16.Images.Item("Check_in"))
        Sb_Marcar_Grillas(Grilla_Accesorios, Imagenes_16x16.Images.Item("Accesorios"))

    End Sub

    Sub Sb_Formato_Grillas(_Solo_Lectura As Boolean)

        With Grill_Check_In

            OcultarEncabezadoGrilla(Grill_Check_In, True)

            .Columns("BtnImagen").Visible = True
            .Columns("BtnImagen").HeaderText = "Chk"
            .Columns("BtnImagen").Width = 30
            .Columns("BtnImagen").DisplayIndex = 0

            .Columns("Check_In").Visible = True
            .Columns("Check_In").HeaderText = "Check-In"
            .Columns("Check_In").Width = 200
            .Columns("Check_In").DisplayIndex = 1
            .Columns("Check_In").ReadOnly = _Solo_Lectura

            .Columns("Nota").Visible = True
            .Columns("Nota").HeaderText = "Nota"
            .Columns("Nota").Width = 410
            .Columns("Nota").DisplayIndex = 2
            .Columns("Nota").ReadOnly = _Solo_Lectura

        End With

        With Grilla_Accesorios


            OcultarEncabezadoGrilla(Grilla_Accesorios, True)

            .Columns("BtnImagen").Visible = True
            .Columns("BtnImagen").HeaderText = "Art"
            .Columns("BtnImagen").Width = 30
            .Columns("BtnImagen").DisplayIndex = 0

            .Columns("Articulo").Visible = True
            .Columns("Articulo").HeaderText = "Articulo"
            .Columns("Articulo").Width = 190
            .Columns("Articulo").DisplayIndex = 1
            .Columns("Articulo").ReadOnly = _Solo_Lectura

            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").HeaderText = "Cant."
            .Columns("Cantidad").Width = 45
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").DisplayIndex = 2
            .Columns("Cantidad").ReadOnly = _Solo_Lectura

            .Columns("NroSerie").Visible = True
            .Columns("NroSerie").HeaderText = "Nro Serie"
            .Columns("NroSerie").Width = 160
            .Columns("NroSerie").DisplayIndex = 3
            .Columns("NroSerie").ReadOnly = _Solo_Lectura

            .Columns("Nota").Visible = True
            .Columns("Nota").HeaderText = "Nota"
            .Columns("Nota").Width = 220
            .Columns("Nota").DisplayIndex = 4
            .Columns("Nota").ReadOnly = _Solo_Lectura

        End With

    End Sub

    Sub Sb_Marcar_Grillas(_Grilla As DataGridView, _Imagen As Image)

        For Each _Fila As DataGridViewRow In _Grilla.Rows
            _Fila.Cells("BtnImagen").Value = _Imagen
        Next

        If _Accion = Accion.Editar Then

            Dim _Color As Color

            If _Editando_documento Then
                _Color = Color.White
            Else
                _Color = Color.LightGray
            End If

            For Each _Fila As DataGridViewRow In _Grilla.Rows
                _Fila.DefaultCellStyle.BackColor = _Color
            Next
        End If

    End Sub

#Region "PROPIEDADES"

    Public Property Pro_DsDocumento() As DataSet
        Get
            Return _DsDocumento
        End Get
        Set(value As DataSet)
            _DsDocumento = value

            _Row_Encabezado = _DsDocumento.Tables(0).Rows(0)
            _Tbl_DetProd = _DsDocumento.Tables(1)
            _Tbl_ChekIn = _DsDocumento.Tables(2)
            _Row_Notas = _DsDocumento.Tables(3).Rows(0)
            _Tbl_Accesorios = _DsDocumento.Tables(5)

        End Set
    End Property

    Public Property Pro_DsDocumento2() As DataSet
        Get
            Return _DsDocumento
        End Get
        Set(value As DataSet)
            _DsDocumento = value
        End Set
    End Property

    Public Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Pro_Imagenes_32x32() As ImageList
        Get
            Return Imagenes_32x32
        End Get
        Set(value As ImageList)
            Imagenes_32x32 = value
        End Set
    End Property

    Public Property Pro_Editando_Documento() As Boolean
        Get
            Return _Editando_documento
        End Get
        Set(value As Boolean)
            _Editando_documento = value
        End Set
    End Property

#End Region


    Sub Sb_New_OT_Agregar_Fila_Accesorios(Optional _Codigo As String = "",
                                          Optional _Articulo As String = "")

        Dim NewFila As DataRow
        NewFila = _Tbl_Accesorios.NewRow
        With NewFila

            .Item("Nuevo_Item") = False
            .Item("Codigo") = _Codigo
            .Item("Articulo") = _Articulo
            .Item("Cantidad") = 0
            .Item("NroSerie") = String.Empty
            .Item("Nota") = String.Empty

            _Tbl_Accesorios.Rows.Add(NewFila)

        End With

    End Sub

    Sub Sb_New_OT_Agregar_Fila_Check_In(Optional _Codigo As String = "",
                                        Optional _Check_In As String = "")

        Dim NewFila As DataRow
        NewFila = _Tbl_ChekIn.NewRow
        With NewFila

            .Item("Nuevo_Item") = False
            .Item("Codigo") = _Codigo
            .Item("Check_In") = _Check_In
            .Item("Nota") = String.Empty

            _Tbl_ChekIn.Rows.Add(NewFila)

        End With

    End Sub

#Region "EVENTOS GRILLA CHECK-IN"

    Private Sub Grilla_Check_In_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        Dim Grilla As DataGridView = CType(sender, DataGridView)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Nuevo_Item As Boolean = _Fila.Cells("Nuevo_Item").Value
        Dim _Nota As String = NuloPorNro(_Fila.Cells("Nota").Value, "")

        If _Cabeza = "Nota" Then
            If _Nuevo_Item Then
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub Grilla_Check_In_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim Grilla As DataGridView = CType(sender, DataGridView)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Nuevo_Item As Boolean = _Fila.Cells("Nuevo_Item").Value
        Dim _Check_In As String = _Fila.Cells("Check_In").Value

        If _Cabeza = "Check_In" Then
            If _Nuevo_Item Then
                If Not String.IsNullOrEmpty(_Check_In) Then
                    _Fila.Cells("Nuevo_Item").Value = False
                    Grilla.CurrentCell = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Check_In")
                End If
            End If
        End If

    End Sub

    Private Sub Grilla_Check_In_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If CBool(_Tbl_ChekIn.Rows.Count) Then
            Dim Grilla As DataGridView = CType(sender, DataGridView)

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            Dim _Nuevo_Item As Boolean = _Fila.Cells("Nuevo_Item").Value
            '        Dim _Codigo As String = _Fila.Cells("Codigo").Value

            Dim _Key As Keys = e.KeyValue

            Select Case _Key

                Case Keys.Enter

                    'If _Nuevo_Item Then
                    SendKeys.Send("{F2}")
                    e.Handled = True
                    Grilla.BeginEdit(True)
                    'End If

                    'Case Keys.Down

                    'If Not _Nuevo_Item Then
                    'With Grill_Check_In

                    'Dim Filas As Integer = .Rows.Count - 1
                    'Dim Columna As Integer = .CurrentCellAddress.X
                    'Dim Fila As Integer = .CurrentCellAddress.Y

                    'If Filas = Fila Then '.CurrentRow.Index Then

                    'Sb_New_OT_Agregar_Fila_Check_In()
                    '.CurrentCell = .Rows(Fila + 1).Cells("Check_In")
                    'End If
                    'End With
                    'End If

                Case Keys.Delete

                    If Not _Nuevo_Item Then
                        If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar la(s) fila(s) seleccionada(s)?",
                                                 "Eliminar fila", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                            Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                            Grilla.Refresh()

                        End If
                    End If

            End Select
        End If


    End Sub

#End Region

#Region "EVENTOS GRILLA ACCESORIOS"

    Private Sub Grilla_Accesorios_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        Dim Grilla As DataGridView = CType(sender, DataGridView)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Nuevo_Item As Boolean = _Fila.Cells("Nuevo_Item").Value
        Dim _Cantidad = _Fila.Cells("Cantidad").Value
        Dim _NroSerie = _Fila.Cells("NroSerie").Value
        Dim _Nota = _Fila.Cells("Nota").Value

        If _Cabeza = "Cantidad" Or _Cabeza = "NroSerie" Or _Cabeza = "Nota" Then
            If _Nuevo_Item Then
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub Grilla_Accesorios_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim Grilla As DataGridView = CType(sender, DataGridView)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Nuevo_Item As Boolean = _Fila.Cells("Nuevo_Item").Value
        Dim _Articulo As String = _Fila.Cells("Articulo").Value

        If _Cabeza = "Articulo" Then
            If _Nuevo_Item Then
                If Not String.IsNullOrEmpty(_Articulo) Then
                    _Fila.Cells("Nuevo_Item").Value = False
                    Grilla.CurrentCell = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Articulo")
                End If
            End If
        End If

    End Sub

    Private Sub Grilla_Accesorios_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)

        Try

            If CBool(_Tbl_Accesorios.Rows.Count) Then

                Dim Grilla As DataGridView = CType(sender, DataGridView)

                Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
                Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

                Dim _Nuevo_Item As Boolean = _Fila.Cells("Nuevo_Item").Value

                Dim _Key As Keys = e.KeyValue

                Select Case _Key

                    Case Keys.Enter

                        SendKeys.Send("{F2}")
                        e.Handled = True
                        Grilla.BeginEdit(True)

                    Case Keys.Delete

                        If Not _Nuevo_Item Then

                            If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar la(s) fila(s) seleccionada(s)?",
                                                     "Eliminar fila", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                                Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                                Grilla.Refresh()

                            End If

                        End If

                End Select

            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region
    Private Sub Grilla_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        Dim validar As TextBox = CType(e.Control, TextBox)
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub validar_Keypress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress  
        ' obtener indice de la columna

        With sender

            Dim columna As Integer = Grilla_Accesorios.CurrentCellAddress.X 'Current.ColumnIndex
            Dim fila As Integer = Grilla_Accesorios.CurrentCellAddress.Y 'Current.ColumnIndex

            Dim Cabeza = Grilla_Accesorios.Columns(columna).Name
            Dim Codigo = Grilla_Accesorios.Rows(fila).Cells("Codigo").Value
            Dim Descripcion = Grilla_Accesorios.Rows(fila).Cells("Descripcion").Value

            ' comprobar si la celda en edición corresponde a la columna 1 o 2
            If Cabeza = "Cantidad" Or
               Cabeza = "Precio" Or
               Cabeza = "DescuentoPorc" Or
               Cabeza = "DescuentoValor" Then

                ' Obtener caracter  
                Dim caracter As Char = e.KeyChar

                ' referencia a la celda  
                Dim txt As TextBox = CType(sender, TextBox)

                If e.KeyChar = "."c Then
                    ' si se pulsa la coma se convertirá en punto
                    'e.Handled = True
                    SendKeys.Send(",")
                    e.KeyChar = ","c
                    caracter = ","
                End If

                Dim Caracter_Raro = ChrW(Keys.Back)
                Dim EsNumero As Boolean = Char.IsNumber(caracter)

                ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
                ' es el separador decimal, y que no contiene ya el separador  
                If (Char.IsNumber(caracter)) Or
                (caracter = ChrW(Keys.Back)) Or
                (caracter = ",") And
                (txt.Text.Contains(",") = False) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If

            End If

        End With

    End Sub


    Private Sub Btn_Agregar_Check_In_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Agregar_Check_In.Click

        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Check_in_ST,
                                                            Frm_Tabla_Caracterizaciones_01_Listado.Accion.Multiseleccion)
        Fm.Pro_TblFilasSeleccionadas = _Tbl_ChekIn
        Fm.Text = "Lista de detalle detectados en el ingreso sin seleccionar"
        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccion_Realizada Then

            Dim _Tbl As DataTable = Fm.Pro_TblFilasSeleccionadas

            For Each _Fila As DataRow In _Tbl.Rows
                If _Fila.RowState <> DataRowState.Deleted Then
                    Dim _Chk = NuloPorNro(_Fila.Item("Chk"), False)
                    If _Chk Then
                        Dim _Codigo = _Fila.Item("CodigoTabla")
                        Dim _Check_In = _Fila.Item("NombreTabla")
                        Sb_New_OT_Agregar_Fila_Check_In(_Codigo, _Check_In)
                    End If
                End If
            Next

            Sb_Marcar_Grillas(Grill_Check_In, Imagenes_16x16.Images.Item("Check_in"))

        End If
        Fm.Dispose()

    End Sub



    Private Sub Btn_Agregar_Accesorios_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Agregar_Accesorios.Click

        Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Accesorios_ST,
                                                            Frm_Tabla_Caracterizaciones_01_Listado.Accion.Multiseleccion)
        Fm.Pro_TblFilasSeleccionadas = _Tbl_Accesorios
        Fm.Text = "Lista de accesorios sin seleccionar"
        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccion_Realizada Then

            Dim _Tbl As DataTable = Fm.Pro_TblFilasSeleccionadas

            For Each _Fila As DataRow In _Tbl.Rows
                If _Fila.RowState <> DataRowState.Deleted Then
                    Dim _Chk = NuloPorNro(_Fila.Item("Chk"), False)
                    If _Chk Then
                        Dim _Codigo = _Fila.Item("CodigoTabla")
                        Dim _Articulo = _Fila.Item("NombreTabla")
                        Sb_New_OT_Agregar_Fila_Accesorios(_Codigo, _Articulo)
                    End If
                End If
            Next

            Sb_Marcar_Grillas(Grilla_Accesorios, Imagenes_16x16.Images.Item("Accesorios"))

        End If

        Fm.Dispose()

    End Sub


    Private Sub Btn_Aceptar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Aceptar.Click

        If CBool(Grilla_Accesorios.Rows.Count) Then

            For Each _Fila As DataGridViewRow In Grilla_Accesorios.Rows
                Dim _Cantidad = _Fila.Cells("Cantidad").Value
                If _Cantidad <= 0 Then
                    Beep()
                    ToastNotification.Show(Me, "LAS CANTIDADES DE LOS ARTICULOS NO PUEDEN ESTAR EN CERO",
                                           Btn_Cancelar.Image,
                                           2 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)
                    Return
                End If
            Next

        End If

        Grill_Check_In.EndEdit()
        Grilla_Accesorios.EndEdit()

        Me.Close()

    End Sub

    Private Sub Frm_St_Estado_01_Ingreso_Check_In_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Sub Btn_Editar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Editar.Click

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_St_OT_Estados", "Id_Ot = " & _Id_Ot & " And CodEstado = 'A'")

        Dim _Editar As Boolean

        If CBool(_Reg) Then
            If MessageBoxEx.Show(Me, "No se puede modificar el estado, ya que existe un estado posterior" & vbCrLf &
                                 "¿Desea editar igualmemnte el Chek-In?", "Validación",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                _Editar = Fx_Tiene_Permiso(Me, "Stec0017")
            End If
        Else
            _Editar = True
        End If

        If _Editar Then

            _Editando_documento = True
            Beep()
            ToastNotification.Show(Me, "AHORA ES POSIBLE ACTUALIZAR EL DOCUMENTO",
                                   Btn_Editar.Image,
                                   1 * 1000, eToastGlowColor.Green,
                                   eToastPosition.MiddleCenter)

            Sb_Formato_Grillas(False)
            Btn_Grabar.Enabled = True
            Btn_Grabar.Visible = True
            Btn_Cancelar.Visible = True
            Btn_Editar.Visible = False
            Me.ControlBox = False

            Btn_Agregar_Accesorios.Enabled = True
            Btn_Agregar_Check_In.Enabled = True

            Sb_Marcar_Grillas(Grill_Check_In, Imagenes_16x16.Images.Item("Check_in"))
            Sb_Marcar_Grillas(Grilla_Accesorios, Imagenes_16x16.Images.Item("Accesorios"))

        End If

        Me.Refresh()

    End Sub

    Private Sub Btn_Grabar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Grabar.Click

        If CBool(Grilla_Accesorios.Rows.Count) Then
            For Each _Fila As DataGridViewRow In Grilla_Accesorios.Rows
                Dim _Cantidad = _Fila.Cells("Cantidad").Value
                If _Cantidad <= 0 Then
                    Beep()
                    ToastNotification.Show(Me, "LAS CANTIDADES DE LOS ARTICULOS NO PUEDEN ESTAR EN CERO",
                                           Btn_Cancelar.Image,
                                           2 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)
                    Return
                End If
            Next
        End If

        Pro_Grabar = True
        Me.Close()
    End Sub

    Private Sub Btn_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub
End Class
