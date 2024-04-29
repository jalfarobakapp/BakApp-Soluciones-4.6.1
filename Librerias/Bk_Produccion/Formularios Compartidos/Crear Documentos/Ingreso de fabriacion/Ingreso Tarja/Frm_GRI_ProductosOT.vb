Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_GRI_ProductosOT

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Tbl_Productos As DataTable
    Public Property FilaSeleccionada As DataRow
    Public Property MarcarFilasSinSaldo As Boolean
    Public Property CreaNuevaOTExtra As Boolean
    Public Property Numot_Extra As String
    Public Property ModoSeleccion As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_GRI_ProductosOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

        Btn_CrearOTExtra.Visible = Not ModoSeleccion

    End Sub

    Sub Sb_Actualizar_Grilla()

        With Grilla

            .DataSource = Tbl_Productos

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            Sb_InsertarBotonenGrilla(Grilla, "Btn_Opciones", "Opciones...", "Opciones", 0, _Tipo_Boton.Boton)

            .Columns("NREG").Width = 50
            .Columns("NREG").HeaderText = "SubOt"
            .Columns("NREG").ReadOnly = True
            .Columns("NREG").Visible = True
            .Columns("NREG").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CODIGO").Width = 100
            .Columns("CODIGO").HeaderText = "Producto"
            .Columns("CODIGO").ReadOnly = True
            .Columns("CODIGO").Visible = True
            .Columns("CODIGO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("GLOSA").Width = 280
            .Columns("GLOSA").HeaderText = "Nombre producto"
            .Columns("GLOSA").ReadOnly = True
            .Columns("GLOSA").Visible = True
            .Columns("GLOSA").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FABRICAR").Visible = True
            .Columns("FABRICAR").HeaderText = "Fabricar"
            .Columns("FABRICAR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("FABRICAR").Width = 80
            .Columns("FABRICAR").DefaultCellStyle.Format = "###,##0.##"
            .Columns("FABRICAR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("REALIZADO").Visible = True
            .Columns("REALIZADO").HeaderText = "Realizado"
            .Columns("REALIZADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("REALIZADO").Width = 80
            .Columns("REALIZADO").DefaultCellStyle.Format = "###,##0.##"
            .Columns("REALIZADO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SALDO").Visible = True
            .Columns("SALDO").HeaderText = "Saldo KG"
            .Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO").Width = 80
            .Columns("SALDO").DefaultCellStyle.Format = "###,##0.##"
            .Columns("SALDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SALDO2").Visible = True
            .Columns("SALDO2").HeaderText = "Saldo SC"
            .Columns("SALDO2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO2").Width = 80
            .Columns("SALDO2").DefaultCellStyle.Format = "###,###.##"
            .Columns("SALDO2").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Btn_Edit").DisplayIndex = True

        End With

        If MarcarFilasSinSaldo Then

            For Each row As DataGridViewRow In Grilla.Rows

                Dim _Saldo As Double = row.Cells("SALDO").Value

                If _Saldo = 0 Then
                    row.DefaultCellStyle.ForeColor = Color.Gray
                End If

            Next

        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Idpotl As Integer = _Fila.Cells("IDPOTL").Value

        Consulta_sql = "Select * From POTL Where IDPOTL = " & _Idpotl

        Consulta_sql = "Select POTL.*,(FABRICAR-REALIZADO) As SALDO,Case RLUD When 1 Then 0 Else (FABRICAR-REALIZADO)/RLUD End As SALDO2,RLUD" & vbCrLf &
                       "From POTL" & vbCrLf &
                       "Inner Join MAEPR On KOPR = CODIGO" & vbCrLf &
                       "Where IDPOTL = " & _Idpotl

        FilaSeleccionada = _Sql.Fx_Get_DataRow(Consulta_sql)

        Me.Close()

    End Sub

    Private Sub Frm_GRI_ProductosOT_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyValue = Keys.F5 Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True ' Evita que la tecla ENTER se propague y active la siguiente fila
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)

            If dgv.CurrentRow IsNot Nothing Then
                ' Selecciona toda la fila actual
                dgv.CurrentRow.Selected = True
                Call Grilla_CellDoubleClick(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub Btn_CrearOTExtra_Click(sender As Object, e As EventArgs) Handles Btn_CrearOTExtra.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Codigo As String = _Fila.Cells("CODIGO").Value
        Dim _Descripcion As String = _Fila.Cells("GLOSA").Value.ToString.Trim
        Dim _NumOtRef As String = _Fila.Cells("NUMOT").Value
        Dim _SubOt As String = _Fila.Cells("NREG").Value
        Dim _Kilos As Integer
        Dim _Idpote As Integer = _Fila.Cells("IDPOTE").Value
        Dim _Idpotl As Integer = _Fila.Cells("IDPOTL").Value
        Dim _Realizado As Integer = _Fila.Cells("REALIZADO").Value
        Dim _Cargo As String = _Fila.Cells("CARGO").Value.ToString.Trim

        If _Cargo = "H" Then
            MessageBoxEx.Show(Me, "No se puede crear una OT a partir de un registro tipo ""Hijo""" & vbCrLf &
                              "Solo es posible crear OT de un regitro ""Madre"".", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If _Realizado = 0 Then
            MessageBoxEx.Show(Me, "Solo se puede crear una OT Extra a productos que tengan el campo REALIZADO mayor a cero",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Aceptar As Boolean

        Dim _Maxscoteextra As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones",
                                                          "Valor",
                                                          "Tabla = 'TARJA_MAXSCOTEXTRA' And CodigoTabla = 'MAXSCOCEXTRA'", True)
        Dim _MsgMax As String

        If CBool(_Maxscoteextra) Then
            _MsgMax = vbCrLf & "Cantidad máxima a fabricar: " & FormatNumber(_Maxscoteextra, 0) & " Kilos"
        End If

        _Aceptar = InputBox_Bk(Me, "Ingrese la cantidad de kilos a fabricar" & vbCrLf &
                               "Sub-OT: " & _SubOt & vbCrLf & "Producto: " & _Codigo & " - " & _Descripcion & _MsgMax,
                               "Crear nueva OT por saldo de fabricación.", _Kilos, False, ,,
                               True, _Tipo_Imagen.Product,, _Tipo_Caracter.Solo_Numeros_Enteros, False)

        If Not _Aceptar Then
            Return
        End If

        If CBool(_Maxscoteextra) Then

            If _Kilos > _Maxscoteextra Then
                MessageBoxEx.Show(Me, "No puede exceder la cantidad máxima para crear OT por diferencias" & vbCrLf &
                                  "Cantidad máxima autorizada es de : " & FormatNumber(_Maxscoteextra, 0) & " Kilos",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Call Btn_CrearOTExtra_Click(Nothing, Nothing)
                Return
            End If

        End If

        If MessageBoxEx.Show(Me, "Confirma crear una nueva OT" & vbCrLf & vbCrLf &
                             "Producto: " & _Codigo.Trim & " - " & _Descripcion.Trim & vbCrLf &
                             "Cantidad: " & FormatNumber(_Kilos, 0) & " Kilos",
                             "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _Fecha As DateTime = _Sql.Fx_Trae_Dato("POTE", "FIOT", "IDPOTE = " & _Idpote) 'FechaDelServidor()


        Consulta_sql = "EXEC Genero_OT_Diferencia  '" & _NumOtRef & "','" & FUNCIONARIO & "','" & Format(_Fecha, "dd/MM/yyyy") & "'," & _Kilos & "," & _Idpotl

        Dim _Row_Respuesta As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

        If IsNothing(_Row_Respuesta) Then
            MessageBoxEx.Show(Me, _Sql.Pro_Error & vbCrLf &
                              "Consulta: " & Consulta_sql, "Problema al llamar al procedimiento almacenado",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        CreaNuevaOTExtra = True
        Numot_Extra = _Row_Respuesta.Item("RESULTADO")

        Dim _Mensaje1 = "Se creo la OT " & Numot_Extra
        Dim _Mensaje2 = "Nueva OT por Saldo de fabricación" & vbCrLf & vbCrLf &
                        "Producto: " & _Codigo.Trim & " - " & _Descripcion.Trim & vbCrLf &
                        "Cantidad: " & FormatNumber(_Kilos, 0)

        Dim iconoAlerta As Icon = SystemIcons.Warning
        Dim _ImagenFoot As Image = iconoAlerta.ToBitmap()

        ' Cambiar el tamaño del icono a 64x64 píxeles (puedes ajustar el tamaño según tus necesidades)
        Dim nuevoTamaño As New Size(16, 16)
        Dim iconoRedimensionado As Image = _ImagenFoot.GetThumbnailImage(nuevoTamaño.Width, nuevoTamaño.Height, Nothing, IntPtr.Zero)

        _ImagenFoot = iconoRedimensionado

        Dim _Info As New TaskDialogInfo("Alerta",
                   eTaskDialogIcon.Information2,
                  _Mensaje1, _Mensaje2,
                  eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red, Nothing, Nothing,
                  Nothing, "Se cerrara este formulario y se gestionara la nueva OT", _ImagenFoot, True)

        Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

        Me.Close()

    End Sub

    Private Sub Grilla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellClick

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        If _Cabeza = "Btn_Opciones" Then
            ShowContextMenu(Menu_Contextual_01)
        End If

    End Sub

    Private Sub Btn_Fabricar_Click(sender As Object, e As EventArgs) Handles Btn_Fabricar.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub
End Class
