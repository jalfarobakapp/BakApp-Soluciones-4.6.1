Imports DevComponents.DotNetBar
Public Class Frm_PrecioLCFuturo2

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_PreciosFuturo As DataTable
    Dim _Dv_PreciosFuturo As DataView

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_PrecioLCFuturo2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Dtp_FechaInicio.Text = String.Empty
        Dtp_FechaTope.Text = String.Empty

        Sb_Llenar_Combos()
        Sb_ActualizarGrilla()

        CmbLista.Enabled = False

    End Sub


    Sub Sb_ActualizarGrilla()

        Dim _FechaServidor As String = Format(FechaDelServidor, "yyyyMMdd")

        Dim _TextoBuscador As String = Txt_Buscador.Text
        Dim _SuperFamilia As String = Fx_Traer_Valor_Combo(Cmb_SuperFamilia)
        Dim _Marca As String = Fx_Traer_Valor_Combo(Cmb_Marca)
        Dim _Zona As String = Fx_Traer_Valor_Combo(Cmb_Zona)

        Dim _UsarFechaInicio As Boolean = Not String.IsNullOrWhiteSpace(Dtp_FechaInicio.Text)
        Dim _UsarFechaTope As Boolean = Not String.IsNullOrWhiteSpace(Dtp_FechaTope.Text)

        Dim _FechaInicio As Date = Dtp_FechaInicio.Value
        Dim _FechaTope As Date = Dtp_FechaTope.Value

        Dim _IdFilaActual As Integer = 0

        If Not IsNothing(Grilla.CurrentRow) Then
            If Not IsDBNull(Grilla.CurrentRow.Cells("Id").Value) Then
                _IdFilaActual = Grilla.CurrentRow.Cells("Id").Value
            End If
        End If

        Consulta_sql = $"
Select Cast(0 As Bit) As Chk,LcDet.Id,Id_Enc,Lista,NombreLista,LcDet.Codigo,Mp.NOKOPR,PrecioUd1,PrecioUd2,LcEnt.FechaCreacion,LcEnt.FechaProgramada,
LcEnt.FechaAplica,LcEnt.Funcionario,EcuacionUd1,EcuacionUd2,Rtu,MargenPorc,VarMcosto,VarPm,VarUc,VarFlete,VarIva,VarIla,VarNetoDigit,VarValorDigit,
LcDet.Eliminada,LcDet.FuncionarioElimina,LcDet.FechaEliminacion,Cast(1 As Int) As Cantidad,
Isnull(Tcz.KOCARAC,'') As 'CosZona',Isnull(Tcz.NOKOCARAC,'') As 'Zona',
Isnull(Spf.KOFM,'') As 'CodSuperFm',Isnull(Spf.NOKOFM,'') As 'SuperFamilia',Isnull(Fm.KOPF,'') As 'CodFm',Isnull(Fm.NOKOPF,'') As 'Familia',Isnull(Hf.KOHF,'') As 'CodSubFm',Isnull(Hf.NOKOHF,'') As 'SubFamilia',
Isnull(Mrc.KOMR,'') As 'CodMarca',Isnull(Mrc.NOKOMR,'') As 'Marca'
From {_Global_BaseBk}Zw_ListaLC_Programadas_Detalles LcDet
Inner Join {_Global_BaseBk}Zw_ListaLC_Programadas LcEnt On LcEnt.Id = LcDet.Id_Enc
Left Join MAEPR Mp On KOPR = LcDet.Codigo
Left Join TABCARAC Tcz On KOTABLA = 'ZONAPRODUC' And Tcz.KOCARAC = Mp.ZONAPR
Left Join TABFM Spf On Spf.KOFM = Mp.FMPR
Left Join TABPF Fm On Fm.KOFM = Mp.FMPR And Fm.KOPF = Mp.PFPR
Left Join TABHF Hf On Hf.KOFM = Mp.FMPR And Hf.KOPF = Mp.PFPR And Hf.KOHF = Mp.HFPR
Left Join TABMR Mrc On Mrc.KOMR = Mp.MRPR 
Where LcEnt.Activo = 1 And LcDet.Eliminada = 0 And Lista = '{CmbLista.SelectedValue}'
And LcEnt.FechaProgramada > '{_FechaServidor}'
Order By LcEnt.FechaProgramada,Id_Enc,LcDet.Codigo"

        _Tbl_PreciosFuturo = _Sql.Fx_Get_DataTable(Consulta_sql)
        _Dv_PreciosFuturo = New DataView(_Tbl_PreciosFuturo)

        _Cargando_Filtros = True

        Try

            Sb_Llenar_Combos_Filtros()

            Txt_Buscador.Text = _TextoBuscador

            If _UsarFechaInicio Then
                Dtp_FechaInicio.Value = _FechaInicio
            Else
                Dtp_FechaInicio.Text = String.Empty
            End If

            If _UsarFechaTope Then
                Dtp_FechaTope.Value = _FechaTope
            Else
                Dtp_FechaTope.Text = String.Empty
            End If

            Fx_Seleccionar_Valor_Combo(Cmb_SuperFamilia, _SuperFamilia)
            Fx_Seleccionar_Valor_Combo(Cmb_Marca, _Marca)
            Fx_Seleccionar_Valor_Combo(Cmb_Zona, _Zona)

        Finally
            _Cargando_Filtros = False
        End Try

        With Grilla

            .DataSource = _Dv_PreciosFuturo

            OcultarEncabezadoGrilla(Grilla, False)

            Dim _DisplayIndex = 0

            .Columns("Chk").Width = 30
            .Columns("Chk").HeaderText = "Sel"
            .Columns("Chk").Visible = True
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").Width = 300
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Funcionario").Width = 30
            .Columns("Funcionario").HeaderText = "Fun"
            .Columns("Funcionario").Visible = True
            .Columns("Funcionario").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Zona").Width = 100
            .Columns("Zona").HeaderText = "Zona"
            .Columns("Zona").Visible = True
            .Columns("Zona").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SuperFamilia").Width = 100
            .Columns("SuperFamilia").HeaderText = "Super Familia"
            .Columns("SuperFamilia").Visible = True
            .Columns("SuperFamilia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Marca").Width = 100
            .Columns("Marca").HeaderText = "Marca"
            .Columns("Marca").Visible = True
            .Columns("Marca").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaCreacion").Width = 70
            .Columns("FechaCreacion").HeaderText = "F.creación"
            .Columns("FechaCreacion").Visible = True
            .Columns("FechaCreacion").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaCreacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaProgramada").Width = 70
            .Columns("FechaProgramada").HeaderText = "F.activación"
            .Columns("FechaProgramada").Visible = True
            .Columns("FechaProgramada").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaProgramada").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PrecioUd1").Width = 70
            .Columns("PrecioUd1").HeaderText = "Precio Ud1"
            .Columns("PrecioUd1").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PrecioUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PrecioUd1").Visible = True

            .Columns("Cantidad").Width = 60
            .Columns("Cantidad").HeaderText = "Cant.Imp"
            .Columns("Cantidad").ToolTipText = "Cantidad a imprimir"
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##"
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").ReadOnly = False
            .Columns("Cantidad").Visible = True

            .Refresh()

        End With

        Sb_Filtrar_Grilla()
        Fx_Restaurar_Fila_Seleccionada(_IdFilaActual)

    End Sub

    Private Sub Grilla_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Btnimprimir_Click(sender As Object, e As EventArgs) Handles Btnimprimir.Click

        'Sb_Imprimir_Etiquetas()
        Sb_Imprimir_Etiquetas_Orden_Grilla()

    End Sub

#Region "LLENAR COMBOS"

    Sub Sb_Llenar_Combos()

        caract_combo(CmbPuerto)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))
        ',,,,,,

        dr = dt.NewRow() : dr("Padre") = "LPT1" : dr("Hijo") = "Puerto LPT1" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "LPT2" : dr("Hijo") = "Puerto LPT2" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "LPT3" : dr("Hijo") = "Puerto LPT3" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "LPT4" : dr("Hijo") = "Puerto LPT4" : dt.Rows.Add(dr)
        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        With CmbPuerto
            .DataSource = Nothing
            .DataSource = dt
        End With

        Consulta_sql = "Select NombreEtiqueta As Padre,NombreEtiqueta As Hijo from " & _Global_BaseBk & "Zw_Tbl_DisenoBarras"
        Dim _TblEtiquetas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        caract_combo(CmbEtiqueta)
        With CmbEtiqueta
            .DataSource = Nothing
            .DataSource = _TblEtiquetas
        End With


        Dim Fm As New Frm_Barras_ConfPuerto("Configuracion_local.xml")

        Dim _Puerto = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Puerto")
        Dim _Etiqueta = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Etiqueta")

        CmbPuerto.SelectedValue = _Puerto
        CmbEtiqueta.SelectedValue = _Etiqueta

        caract_combo(CmbLista)
        Consulta_sql = "Select 'PM' As Padre,'PM' As Hijo Union" & vbCrLf &
                       "Select 'UC' As Padre,'ULTIMA COMPRA' As Hijo Union" & vbCrLf &
                       "SELECT KOLT As Padre,KOLT+'-'+NOKOLT AS Hijo FROM TABPP"
        CmbLista.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        CmbLista.SelectedValue = Mod_ListaPrecioVenta

    End Sub

#End Region


    Sub Sb_Imprimir_Etiquetas()

        Try

            Dim _Contador = 0

            For Each _Fila As DataRow In _Tbl_PreciosFuturo.Rows

                Dim _Estado = _Fila.RowState

                If _Estado <> DataRowState.Deleted Then

                    If _Fila.Item("Chk") Then

                        If _Fila.Item("Lista") = CmbLista.SelectedValue Then
                            _Contador += 1
                        Else
                            _Fila.Item("Chk") = False
                        End If

                    End If

                End If

            Next

            If _Contador = 0 Then
                MessageBoxEx.Show(Me, "No hay registros seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If


            Dim _Puerto = CmbPuerto.SelectedValue


            Dim _CantPorLinea As Integer

            If IsNothing(CmbEtiqueta.SelectedValue) Then
                Throw New System.Exception("Debe seleccionar un formato de impresión")
            End If

            If String.IsNullOrEmpty(CmbEtiqueta.SelectedValue) Then
                Throw New System.Exception("Debe seleccionar un formato de impresión")
            End If

            _CantPorLinea = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras", "CantPorLinea", "NombreEtiqueta = '" & CmbEtiqueta.SelectedValue & "'")

            If _CantPorLinea = 0 Then _CantPorLinea = 1


            Dim _Suma As Double = NuloPorNro(_Tbl_PreciosFuturo.Compute("Sum(Cantidad)", "1>0"), 0)

            If Not CBool(_Suma) Then

                Beep()
                ToastNotification.Show(Me, "NO HAY DATOS QUE IMPRIMIR",
                                      My.Resources.cross,
                                     1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return

            End If


            For Each _Fila As DataRow In _Tbl_PreciosFuturo.Rows

                Dim CanXlinea As Double = _CantPorLinea
                Dim Veces As Double = _Fila("Cantidad").ToString()

                Dim _Id = _Fila.Item("Id")
                Dim _Codigo = _Fila.Item("Codigo")
                Dim _Descripcion = _Fila.Item("NOKOPR")
                Dim _Lista = _Fila.Item("Lista")

                If _Fila.Item("Chk") Then

                    If CBool(Veces) Then

                        If CanXlinea = Veces Or CanXlinea > Veces Then
                            Veces = 1
                        Else
                            Dim _ModVeces = Veces Mod 2
                            Dim _ModCanXlinea = CanXlinea Mod 2

                            If CanXlinea <> 1 Then

                                If CBool(_ModVeces) Or CBool(_ModCanXlinea) Then

                                    Veces = Math.Round((Veces / CanXlinea), 5)
                                    Dim _Des = Split(Veces, ",")

                                    If _Des.Length = 2 Then
                                        Veces = _Des(0) + 1
                                    End If

                                Else
                                    Veces = Math.Round((Veces / CanXlinea), 0)
                                End If
                            End If
                        End If

                        If Veces < 1 Then Veces = 1

                        For w = 1 To Veces

                            If _Fila.Item("Chk") Then

                                Dim _Imp As New Class_Imprimir_Barras

                                _Imp.Sb_Imprimir_Producto(CmbEtiqueta.SelectedValue,
                                                          _Puerto,
                                                          _Codigo,
                                                          _Lista,
                                                          Mod_Empresa,
                                                          Mod_Sucursal,
                                                          Mod_Bodega,
                                                          "",
                                                          False,
                                                          True,
                                                          _Id,
                                                          "",
                                                          False, False, False)

                                If Not String.IsNullOrEmpty(_Imp.Error) Then
                                    If MessageBoxEx.Show(Me, _Imp.Error, "Error al imprimir", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) <> DialogResult.OK Then
                                        Return
                                    End If
                                End If

                            End If

                        Next

                    Else
                        MessageBoxEx.Show(Me, "Debe poner la cantidad a imprimir" & vbCrLf & vbCrLf &
                                          "Producto: " & _Codigo.ToString.Trim & "-" & _Descripcion.ToString.Trim, "Validación",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

            Next

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema al imprimir", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Function Fx_Calcular_Veces_Impresion(_Cantidad As Integer,
                                                 _CantPorLinea As Integer) As Integer

        If _CantPorLinea <= 0 Then
            _CantPorLinea = 1
        End If

        If _Cantidad <= 0 Then
            Return 0
        End If

        Return CInt(Math.Ceiling(_Cantidad / CDbl(_CantPorLinea)))

    End Function

    Sub Sb_Imprimir_Etiquetas_Orden_Grilla()

        Try

            Grilla.EndEdit()

            If IsNothing(CmbEtiqueta.SelectedValue) Then
                Throw New System.Exception("Debe seleccionar un formato de impresión")
            End If

            Dim _NombreEtiqueta As String = CmbEtiqueta.SelectedValue.ToString.Trim

            If String.IsNullOrEmpty(_NombreEtiqueta) Then
                Throw New System.Exception("Debe seleccionar un formato de impresión")
            End If

            Dim _Puerto As String = String.Empty

            If Not IsNothing(CmbPuerto.SelectedValue) Then
                _Puerto = CmbPuerto.SelectedValue.ToString.Trim
            End If

            Dim _ListaSeleccionada As String = String.Empty

            If Not IsNothing(CmbLista.SelectedValue) Then
                _ListaSeleccionada = CmbLista.SelectedValue.ToString.Trim
            End If

            Dim _CantPorLinea As Integer =
                _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras",
                                  "CantPorLinea",
                                  "NombreEtiqueta = '" & _NombreEtiqueta & "'")

            If _CantPorLinea <= 0 Then
                _CantPorLinea = 1
            End If

            Dim _FilasSeleccionadas As New List(Of DataGridViewRow)

            For Each _FilaGrilla As DataGridViewRow In Grilla.Rows

                If _FilaGrilla.IsNewRow Then
                    Continue For
                End If

                Dim _Marcada As Boolean = False

                If Not IsDBNull(_FilaGrilla.Cells("Chk").Value) Then
                    _Marcada = CBool(_FilaGrilla.Cells("Chk").Value)
                End If

                If Not _Marcada Then
                    Continue For
                End If

                Dim _ListaFila As String = String.Empty

                If Not IsDBNull(_FilaGrilla.Cells("Lista").Value) Then
                    _ListaFila = _FilaGrilla.Cells("Lista").Value.ToString.Trim
                End If

                If _ListaFila <> _ListaSeleccionada Then
                    _FilaGrilla.Cells("Chk").Value = False
                    Continue For
                End If

                _FilasSeleccionadas.Add(_FilaGrilla)

            Next

            If _FilasSeleccionadas.Count = 0 Then
                MessageBoxEx.Show(Me, "No hay registros seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            For Each _FilaGrilla As DataGridViewRow In _FilasSeleccionadas

                Dim _Cantidad As Integer = 0

                If Not IsDBNull(_FilaGrilla.Cells("Cantidad").Value) Then
                    Integer.TryParse(_FilaGrilla.Cells("Cantidad").Value.ToString(), _Cantidad)
                End If

                Dim _Id As Integer = 0
                Dim _Codigo As String = String.Empty
                Dim _Descripcion As String = String.Empty
                Dim _Lista As String = String.Empty

                If Not IsDBNull(_FilaGrilla.Cells("Id").Value) Then
                    _Id = CInt(_FilaGrilla.Cells("Id").Value)
                End If

                If Not IsDBNull(_FilaGrilla.Cells("Codigo").Value) Then
                    _Codigo = _FilaGrilla.Cells("Codigo").Value.ToString.Trim
                End If

                If Not IsDBNull(_FilaGrilla.Cells("NOKOPR").Value) Then
                    _Descripcion = _FilaGrilla.Cells("NOKOPR").Value.ToString.Trim
                End If

                If Not IsDBNull(_FilaGrilla.Cells("Lista").Value) Then
                    _Lista = _FilaGrilla.Cells("Lista").Value.ToString.Trim
                End If

                If _Cantidad <= 0 Then
                    MessageBoxEx.Show(Me, "Debe poner la cantidad a imprimir" & vbCrLf & vbCrLf &
                                      "Producto: " & _Codigo & "-" & _Descripcion,
                                      "Validación",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Stop)
                    Continue For
                End If

                Dim _Veces As Integer = Fx_Calcular_Veces_Impresion(_Cantidad, _CantPorLinea)

                If _Veces < 1 Then
                    _Veces = 1
                End If

                For _Indice = 1 To _Veces

                    Dim _SigueMarcada As Boolean = False

                    If Not IsDBNull(_FilaGrilla.Cells("Chk").Value) Then
                        _SigueMarcada = CBool(_FilaGrilla.Cells("Chk").Value)
                    End If

                    If Not _SigueMarcada Then
                        Exit For
                    End If

                    Dim _Imp As New Class_Imprimir_Barras

                    _Imp.Sb_Imprimir_Producto(_NombreEtiqueta,
                                              _Puerto,
                                              _Codigo,
                                              _Lista,
                                              Mod_Empresa,
                                              Mod_Sucursal,
                                              Mod_Bodega,
                                              "",
                                              False,
                                              True,
                                              _Id,
                                              "",
                                              False,
                                              False,
                                              False)

                    If Not String.IsNullOrEmpty(_Imp.Error) Then
                        If MessageBoxEx.Show(Me, _Imp.Error, "Error al imprimir", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) <> DialogResult.OK Then
                            Return
                        End If
                    End If

                Next

            Next

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema al imprimir", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub validar_Keypress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress  

        ' obtener el nombre de la columna
        Dim _Columna = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Columna = "Cantidad" Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  
            If (Char.IsNumber(caracter)) Or
            (caracter = ChrW(Keys.Back)) And
            (txt.Text.Contains(",") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Grilla_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Grilla.EditingControlShowing
        ' referencia a la celda  
        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub Chk_Marcar_todo_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Marcar_todo.CheckedChanged

        Dim _Marcar As Boolean = Chk_Marcar_todo.Checked

        Grilla.EndEdit()

        For Each _Fila As DataGridViewRow In Grilla.Rows

            If _Fila.IsNewRow Then
                Continue For
            End If

            _Fila.Cells("Chk").Value = _Marcar

        Next

        Grilla.EndEdit()

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        Dim _FilasSeleccionadas = 0

        For Each _Fila As DataRow In _Tbl_PreciosFuturo.Rows
            If _Fila.Item("Chk") Then
                _FilasSeleccionadas += 1
            End If
        Next

        If Not CBool(_FilasSeleccionadas) Then
            MessageBoxEx.Show(Me, "No hay filas seleccionadas", "Eliminar marcadas", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿confirma la eliminación de estas listas programadas?", "Eliminar marcadas",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = String.Empty

        For Each _Fila As DataRow In _Tbl_PreciosFuturo.Rows

            If _Fila.Item("Chk") Then

                Dim _Id = _Fila.Item("Id")

                Consulta_sql += "Update " & _Global_BaseBk & "Zw_ListaLC_Programadas_Detalles Set " &
                                "Eliminada = 1,FuncionarioElimina = '" & FUNCIONARIO & "'" & vbCrLf &
                                "Where Id = " & _Id & vbCrLf

            End If

        Next

        If Not String.IsNullOrEmpty(Consulta_sql) Then
            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Registros eliminados correctamente", "Eliminar marcadas",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                Sb_ActualizarGrilla()
            Else
                MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If

    End Sub

    Private Sub Btn_ListaLc_Click(sender As Object, e As EventArgs) Handles Btn_ListaLc.Click
        If Fx_Tiene_Permiso(Me, "Pre0002") Then
            Dim Fm As New Frm_PreciosLC_Mt01
            Fm.ShowDialog(Me)
            Fm.Dispose()
            Sb_ActualizarGrilla()
        End If
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        'Dim _Codigo As String = _Fila.Cells("Codigo").Value

        'Dim Fm As New Frm_PrecioLCFuturoListaXProd(_Codigo)
        'Fm.ShowDialog(Me)
        'Fm.Dispose()


        Dim _Codigo = _Fila.Cells("Codigo").Value
        Dim _Id_Enc As Integer = _Fila.Cells("Id_Enc").Value
        Dim _FechaProgramada As DateTime = _Fila.Cells("FechaProgramada").Value
        Dim _Grabar As Boolean

        Consulta_sql = "Select Cast(0 As bit) As Chk,* From " & _Global_BaseBk & "Zw_ListaLC_Programadas_Detalles" & vbCrLf &
                       "Where Id_Enc = " & _Id_Enc & " And Eliminada = 0"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim Fm As New Frm_PrecioLCFuturoGrabar(_Codigo, _Tbl, 0)
        Fm.Id_Enc = _Id_Enc
        Fm.Editar = True
        Fm.Dtp_FechaProgramada.Value = _FechaProgramada
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_ActualizarGrilla()
        End If

        Sb_ActualizarGrilla()

        'BuscarDatoEnGrilla(_Codigo, "Codigo", Grilla)

        'Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_ListaLC_Programadas", "Codigo = '" & _Codigo & "' " &
        '                                "And FechaProgramada > '" & Format(FechaDelServidor, "yyyyMMdd") & "' " &
        '                                "And Activo = 1 And Eliminada = 0")

    End Sub

    Private Sub BtnActualizarLista_Click(sender As Object, e As EventArgs) Handles BtnActualizarLista.Click
        Sb_ActualizarGrilla()
    End Sub

    Private Sub Grilla_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "Chk" Then
            If _Fila.Cells("Chk").Value And _Fila.Cells("Lista").Value <> CmbLista.SelectedValue Then
                _Fila.Cells("Chk").Value = False
                MessageBoxEx.Show(Me, "Solo puede marcar documentos de la lista de precios: " & CmbLista.SelectedValue & "-" & CmbLista.Text, "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

    End Sub


    Sub Sb_Grabar_Listas_Programadas(_FechaProgramacion As DateTime)

        Dim _Str_FechaProgramacion = Format(_FechaProgramacion, "yyyyMMdd")

        Consulta_sql = "Select Id,Codigo,NombreProgramacion,FechaCreacion,FechaProgramada,Aplicado,Funcionario," &
                       "Activo,Id_Padre,Editada,Eliminada,FuncionarioElimina,FechaEliminacion,ValDigitado" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_ListaLC_Programadas" & vbCrLf &
                       "Where FechaProgramada = '" & _Str_FechaProgramacion & "' And Activo = 1 And Aplicado = 0 And Eliminada = 0 "

        Dim _Tbl_ListasProgramadas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Not CBool(_Tbl_ListasProgramadas.Rows.Count) Then
            MessageBoxEx.Show(Me, "No hay registros programados pendientes de actualizar para la fecha: " & _FechaProgramacion.ToShortDateString,
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If


        Dim _Filtros_Id = Generar_Filtro_IN(_Tbl_ListasProgramadas, "", "Id", True, False, "")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaLC_Programadas Set Activo = 0 Where Id In " & _Filtros_Id
        _Sql.Ej_consulta_IDU(Consulta_sql)


        For Each _Fila As DataRow In _Tbl_ListasProgramadas.Rows

            Dim _SqlQuery = String.Empty

            Dim _Id_Enc = _Fila.Item("Id")
            Dim _ValDigitado As Double = _Fila.Item("ValDigitado")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_ListaLC_Programadas_Detalles Where Id_Enc = " & _Id_Enc
            Dim _Tbl_ListasProgramadas_Detalle As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            _SqlQuery += "Update " & _Global_BaseBk & "Zw_ListaLC_Programadas Set " &
                         "Aplicado = 1,FechaAplica = Getdate(),Informacion = 'Ok.',ErrorAlGrabar = 0" & vbCrLf &
                         "Where Id = " & _Id_Enc & vbCrLf & vbCrLf

            If CBool(_ValDigitado) Then

                Dim _Codigo As String = _Fila.Item("Codigo")
                _SqlQuery += "Update " & _Global_BaseBk & "Zw_ListaLC_ValPro Set ValDigitado = " & De_Num_a_Tx_01(_ValDigitado, False, 5) & vbCrLf &
                             "Where Codigo = '" & _Codigo & "'" & vbCrLf

            End If

            For Each _FilaDet As DataRow In _Tbl_ListasProgramadas_Detalle.Rows

                Dim _Kolt As String = _FilaDet.Item("Lista")
                Dim _Kopr As String = _FilaDet.Item("Codigo")
                Dim _Pp01ud As Double = _FilaDet.Item("PrecioUd1")
                Dim _Pp02ud As Double = _FilaDet.Item("PrecioUd2")
                Dim _Mg01ud As Double = _FilaDet.Item("MargenPorc")
                Dim _Ecuacion As String = _FilaDet.Item("EcuacionUd1")
                Dim _Ecuacion2 As String = _FilaDet.Item("EcuacionUd2")

                _SqlQuery += "Update TABPRE Set " &
                             "PP01UD = " & De_Num_a_Tx_01(_Pp01ud, False, 5) & "," &
                             "PP02UD = " & De_Num_a_Tx_01(_Pp02ud, False, 5) & "," &
                             "MG01UD = " & De_Num_a_Tx_01(_Mg01ud, False, 5) & "," &
                             "ECUACION = '" & _Ecuacion & "'," &
                             "ECUACIONU2 = '" & _Ecuacion2 & "'" & Space(1) &
                             "Where KOLT = '" & _Kolt & "' And KOPR = '" & _Kopr & "'" & vbCrLf

            Next

            _SqlQuery += vbCrLf

            If Not String.IsNullOrEmpty(_SqlQuery) Then

                If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery) Then

                    _Filtros_Id = Generar_Filtro_IN(_Tbl_ListasProgramadas, "", "Id", True, False, "")
                    Dim _Error = Replace(_Sql.Pro_Error, "'", "''")

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_ListaLC_Programadas Set " &
                                   "Activo = 0,ErrorAlGrabar = 1,Informacion = '" & Mid(_Error.ToString.Trim, 1, 2000) & "'" & vbCrLf &
                                   "Where Id = " & _Id_Enc
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            End If

        Next

        Sb_ActualizarGrilla()
        MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        ExportarTabla_JetExcel_Tabla(_Tbl_ListasProgramadas, Me, "Cambio_precios_" & _FechaProgramacion.ToShortDateString)

    End Sub

    Private Sub Btn_Grabar_Programacion_Click(sender As Object, e As EventArgs) Handles Btn_Grabar_Programacion.Click

        Dim _FechaServidor = FechaDelServidor()

        '_FechaServidor = DateAdd(DateInterval.Day, 1, _FechaServidor)

        Sb_Grabar_Listas_Programadas(_FechaServidor)

    End Sub

    Private Sub Btn_CambiarLista_Click(sender As Object, e As EventArgs) Handles Btn_CambiarLista.Click

        If Fx_Tiene_Permiso(Me, "Pre0025") Then
            Btn_CambiarLista.Enabled = False
            CmbLista.Enabled = True
        End If

    End Sub

    Dim _Cargando_Filtros As Boolean

    Sub Sb_Llenar_Combos_Filtros()

        Sb_Llenar_Combo_Filtro(Cmb_SuperFamilia, "SuperFamilia")
        Sb_Llenar_Combo_Filtro(Cmb_Marca, "Marca")
        Sb_Llenar_Combo_Filtro(Cmb_Zona, "Zona")

    End Sub

    Sub Sb_Llenar_Combo_Filtro(_Combo As DevComponents.DotNetBar.Controls.ComboBoxEx,
                           _Campo As String)

        Dim _Tbl_Combo As New DataTable
        _Tbl_Combo.Columns.Add("Padre", GetType(String))
        _Tbl_Combo.Columns.Add("Hijo", GetType(String))

        Dim _Fila As DataRow = _Tbl_Combo.NewRow()
        _Fila("Padre") = String.Empty
        _Fila("Hijo") = "Todas..."
        _Tbl_Combo.Rows.Add(_Fila)

        If Not IsNothing(_Tbl_PreciosFuturo) AndAlso _Tbl_PreciosFuturo.Rows.Count > 0 Then

            Dim _Vista As New DataView(_Tbl_PreciosFuturo)
            _Vista.Sort = _Campo

            Dim _Tbl_Distintos As DataTable = _Vista.ToTable(True, _Campo)

            For Each _FilaDato As DataRow In _Tbl_Distintos.Rows

                Dim _Valor As String = String.Empty

                If Not IsDBNull(_FilaDato.Item(_Campo)) Then
                    _Valor = _FilaDato.Item(_Campo).ToString.Trim
                End If

                If Not String.IsNullOrEmpty(_Valor) Then
                    _Fila = _Tbl_Combo.NewRow()
                    _Fila("Padre") = _Valor
                    _Fila("Hijo") = _Valor
                    _Tbl_Combo.Rows.Add(_Fila)
                End If

            Next

        End If

        With _Combo
            .DataSource = Nothing
            .ValueMember = "Padre"
            .DisplayMember = "Hijo"
            .DataSource = _Tbl_Combo
            .SelectedValue = String.Empty
        End With

    End Sub

    Private Sub Txt_Buscador_TextChanged(sender As Object, e As EventArgs) Handles Txt_Buscador.TextChanged
        If _Cargando_Filtros Then Return
        Sb_Filtrar_Grilla()
    End Sub

    Private Sub Cmb_SuperFamilia_SelectedValueChanged(sender As Object, e As EventArgs) Handles Cmb_SuperFamilia.SelectedValueChanged
        If _Cargando_Filtros Then Return
        Sb_Filtrar_Grilla()
    End Sub

    Private Sub Cmb_Marca_SelectedValueChanged(sender As Object, e As EventArgs) Handles Cmb_Marca.SelectedValueChanged
        If _Cargando_Filtros Then Return
        Sb_Filtrar_Grilla()
    End Sub

    Private Sub Cmb_Zona_SelectedValueChanged(sender As Object, e As EventArgs) Handles Cmb_Zona.SelectedValueChanged
        If _Cargando_Filtros Then Return
        Sb_Filtrar_Grilla()
    End Sub

    Private Sub Dtp_FechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FechaInicio.ValueChanged
        If _Cargando_Filtros Then Return
        Sb_Filtrar_Grilla()
    End Sub

    Private Sub Dtp_FechaTope_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FechaTope.ValueChanged
        If _Cargando_Filtros Then Return
        Sb_Filtrar_Grilla()
    End Sub

    Sub Sb_Filtrar_Grilla()

        If IsNothing(_Dv_PreciosFuturo) Then
            Return
        End If

        Dim _Filtro = String.Empty

        If Not String.IsNullOrWhiteSpace(Txt_Buscador.Text) Then

            Dim _Texto = Replace(Txt_Buscador.Text.Trim, "'", "''")

            _Filtro &= "(Codigo Like '%" & _Texto & "%' " &
                       "Or NOKOPR Like '%" & _Texto & "%')"

        End If

        If Not IsNothing(Cmb_SuperFamilia.SelectedValue) Then

            Dim _SuperFamilia = Cmb_SuperFamilia.SelectedValue.ToString.Trim

            If Not String.IsNullOrEmpty(_SuperFamilia) Then
                If Not String.IsNullOrEmpty(_Filtro) Then _Filtro &= " And "
                _Filtro &= "SuperFamilia = '" & Replace(_SuperFamilia, "'", "''") & "'"
            End If

        End If

        If Not IsNothing(Cmb_Marca.SelectedValue) Then

            Dim _Marca = Cmb_Marca.SelectedValue.ToString.Trim

            If Not String.IsNullOrEmpty(_Marca) Then
                If Not String.IsNullOrEmpty(_Filtro) Then _Filtro &= " And "
                _Filtro &= "Marca = '" & Replace(_Marca, "'", "''") & "'"
            End If

        End If

        If Not IsNothing(Cmb_Zona.SelectedValue) Then

            Dim _Zona = Cmb_Zona.SelectedValue.ToString.Trim

            If Not String.IsNullOrEmpty(_Zona) Then
                If Not String.IsNullOrEmpty(_Filtro) Then _Filtro &= " And "
                _Filtro &= "Zona = '" & Replace(_Zona, "'", "''") & "'"
            End If

        End If

        If Not String.IsNullOrWhiteSpace(Dtp_FechaInicio.Text) Then
            If Not String.IsNullOrEmpty(_Filtro) Then _Filtro &= " And "
            _Filtro &= "(CONVERT(FechaCreacion, 'System.DateTime') >= #" & Dtp_FechaInicio.Value.Date.ToString("MM/dd/yyyy") & "# " &
                       "And CONVERT(FechaCreacion, 'System.DateTime') < #" & Dtp_FechaInicio.Value.Date.AddDays(1).ToString("MM/dd/yyyy") & "#)"
        End If

        If Not String.IsNullOrWhiteSpace(Dtp_FechaTope.Text) Then
            If Not String.IsNullOrEmpty(_Filtro) Then _Filtro &= " And "
            _Filtro &= "(CONVERT(FechaProgramada, 'System.DateTime') >= #" & Dtp_FechaTope.Value.Date.ToString("MM/dd/yyyy") & "# " &
                       "And CONVERT(FechaProgramada, 'System.DateTime') < #" & Dtp_FechaTope.Value.Date.AddDays(1).ToString("MM/dd/yyyy") & "#)"
        End If

        _Dv_PreciosFuturo.RowFilter = _Filtro

    End Sub

    Function Fx_Traer_Valor_Combo(_Combo As DevComponents.DotNetBar.Controls.ComboBoxEx) As String

        If IsNothing(_Combo.SelectedValue) Then
            Return String.Empty
        End If

        If TypeOf _Combo.SelectedValue Is DataRowView Then
            Return String.Empty
        End If

        Return _Combo.SelectedValue.ToString.Trim

    End Function

    Sub Fx_Seleccionar_Valor_Combo(_Combo As DevComponents.DotNetBar.Controls.ComboBoxEx,
                               _Valor As String)

        If IsNothing(_Combo.DataSource) Then
            Return
        End If

        If String.IsNullOrEmpty(_Valor) Then
            _Combo.SelectedValue = String.Empty
            Return
        End If

        For Each _Item As DataRowView In _Combo.Items
            If _Item("Padre").ToString.Trim = _Valor Then
                _Combo.SelectedValue = _Valor
                Return
            End If
        Next

        _Combo.SelectedValue = String.Empty

    End Sub

    Sub Fx_Restaurar_Fila_Seleccionada(_Id As Integer)

        If Not CBool(_Id) Then
            Return
        End If

        For Each _Fila As DataGridViewRow In Grilla.Rows

            If _Fila.IsNewRow Then
                Continue For
            End If

            If Not IsDBNull(_Fila.Cells("Id").Value) Then
                If _Fila.Cells("Id").Value = _Id Then
                    Grilla.CurrentCell = _Fila.Cells("Codigo")
                    _Fila.Selected = True
                    Exit For
                End If
            End If

        Next

    End Sub
End Class
