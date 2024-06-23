Imports DevComponents.DotNetBar
Public Class Frm_PrecioLCFuturo2

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_PreciosFuturo As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_PrecioLCFuturo2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Llenar_Combos()
        Sb_ActualizarGrilla()

        CmbLista.Enabled = False

    End Sub


    Sub Sb_ActualizarGrilla()

        Dim _FechaServidor As String = Format(FechaDelServidor, "yyyyMMdd")

        Consulta_sql = "Select Cast(0 As Bit) As Chk,LcDet.Id,Id_Enc,Lista,NombreLista,LcDet.Codigo,NOKOPR,PrecioUd1,PrecioUd2,LcEnt.FechaCreacion,LcEnt.FechaProgramada," &
                       "LcEnt.FechaAplica,LcEnt.Funcionario,EcuacionUd1,EcuacionUd2,Rtu,MargenPorc,VarMcosto,VarPm,VarUc,VarFlete,VarIva,VarIla,VarNetoDigit," &
                       "VarValorDigit,LcDet.Eliminada,LcDet.FuncionarioElimina,LcDet.FechaEliminacion,Cast(1 As Int) As Cantidad" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_ListaLC_Programadas_Detalles LcDet" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_ListaLC_Programadas LcEnt On LcEnt.Id = LcDet.Id_Enc" & vbCrLf &
                       "Left Join MAEPR On KOPR = LcDet.Codigo" & vbCrLf &
                       "Where LcEnt.Activo = 1 And LcDet.Eliminada = 0 And Lista = '" & CmbLista.SelectedValue & "'" & vbCrLf &
                       "And LcEnt.FechaProgramada > '" & _FechaServidor & "'" & vbCrLf &
                       "Order By LcEnt.FechaProgramada,Id_Enc,LcDet.Codigo"
        _Tbl_PreciosFuturo = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_PreciosFuturo

            OcultarEncabezadoGrilla(Grilla, True)

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

            '.Columns("Lista").Width = 30
            '.Columns("Lista").HeaderText = "LP"
            '.Columns("Lista").Visible = True
            '.Columns("Lista").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("NombreLista").Width = 150
            '.Columns("NombreLista").HeaderText = "Nombre Lista"
            '.Columns("NombreLista").Visible = True
            '.Columns("NombreLista").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Funcionario").Width = 30
            .Columns("Funcionario").HeaderText = "Fun"
            .Columns("Funcionario").Visible = True
            .Columns("Funcionario").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaCreacion").Width = 80
            .Columns("FechaCreacion").HeaderText = "F.creación"
            .Columns("FechaCreacion").Visible = True
            .Columns("FechaCreacion").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaCreacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaProgramada").Width = 80
            .Columns("FechaProgramada").HeaderText = "F.activación"
            .Columns("FechaProgramada").Visible = True
            .Columns("FechaProgramada").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaProgramada").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PrecioUd1").Width = 80
            .Columns("PrecioUd1").HeaderText = "Precio Ud1"
            .Columns("PrecioUd1").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PrecioUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PrecioUd1").Visible = True

            '.Columns("PrecioUd2").Width = 80
            '.Columns("PrecioUd2").HeaderText = "Precio Ud2"
            '.Columns("PrecioUd2").DefaultCellStyle.Format = "$ ###,##"
            '.Columns("PrecioUd2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("PrecioUd2").Visible = True

            .Columns("Cantidad").Width = 60
            .Columns("Cantidad").HeaderText = "Cant.Imp"
            .Columns("Cantidad").ToolTipText = "Cantidad a imprimir"
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##"
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").ReadOnly = False
            .Columns("Cantidad").Visible = True

            .Refresh()

        End With

    End Sub

    Private Sub Grilla_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Btnimprimir_Click(sender As Object, e As EventArgs) Handles Btnimprimir.Click

        Sb_Imprimir_Etiquetas()

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
        CmbLista.SelectedValue = ModListaPrecioVenta

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
                                                  ModEmpresa,
                                                  ModSucursal,
                                                  ModBodega,
                                                  "",
                                                  False,
                                                  True,
                                                  _Id,
                                                  "")

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

    Private Sub Chk_Marcar_todo_Click(sender As Object, e As EventArgs) Handles Chk_Marcar_todo.Click

        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Chk").Value = Chk_Marcar_todo.Checked
        Next

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

End Class
