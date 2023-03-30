Imports BkSpecialPrograms.Bk_Comporamiento_UdMedidas
Imports DevComponents.DotNetBar
Public Class Frm_PrecioLCFuturo2

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_PreciosFuturo As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.None, True, False, False)

    End Sub

    Private Sub Frm_PrecioLCFuturo2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Llenar_Puertos()
        Sb_ActualizarGrilla()

    End Sub


    Sub Sb_ActualizarGrilla()

        Consulta_sql = "Select Cast(0 As Bit) As Chk,LcDet.Id,Id_Enc,Lista,NombreLista,LcDet.Codigo,NOKOPR,PrecioUd1,PrecioUd2,LcEnt.FechaCreacion,LcEnt.FechaProgramada," &
                       "LcEnt.FechaAplica,LcEnt.Funcionario,EcuacionUd1,EcuacionUd2,Rtu,MargenPorc,VarMcosto,VarPm,VarUc,VarFlete,VarIva,VarIla,VarNetoDigit," &
                       "VarValorDigit,LcDet.Eliminada,LcDet.FuncionarioElimina,LcDet.FechaEliminacion,Cast(1 As Int) As Cantidad" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_ListaLC_Programadas_Detalles LcDet" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_ListaLC_Programadas LcEnt On LcEnt.Id = LcDet.Id_Enc And LcEnt.Activo = 1" & vbCrLf &
                       "Left Join MAEPR On KOPR = LcDet.Codigo" & vbCrLf &
                       "Order By LcDet.Codigo,LcEnt.FechaProgramada"
        _Tbl_PreciosFuturo = _Sql.Fx_Get_Tablas(Consulta_sql)

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

            .Columns("Lista").Width = 30
            .Columns("Lista").HeaderText = "LP"
            .Columns("Lista").Visible = True
            .Columns("Lista").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreLista").Width = 150
            .Columns("NombreLista").HeaderText = "Nombre Lista"
            .Columns("NombreLista").Visible = True
            .Columns("NombreLista").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

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

            .Columns("PrecioUd2").Width = 80
            .Columns("PrecioUd2").HeaderText = "Precio Ud2"
            .Columns("PrecioUd2").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PrecioUd2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PrecioUd2").Visible = True

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

    Sub Sb_Llenar_Puertos()

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
        Dim _TblEtiquetas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

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

    End Sub

#End Region


    Sub Sb_Imprimir_Etiquetas()

        Try

            Dim _Contador = 0

            For Each _Fila As DataRow In _Tbl_PreciosFuturo.Rows

                Dim _Estado = _Fila.RowState

                If _Estado <> DataRowState.Deleted Then

                    If _Fila.Item("Chk") Then
                        _Contador += 1
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
                                                  _Id)

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

End Class
