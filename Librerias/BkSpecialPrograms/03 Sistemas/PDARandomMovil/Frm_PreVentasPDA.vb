Imports DevComponents.DotNetBar

Public Class Frm_PreVentasPDA

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Tbl_Preventas As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, True, False)
        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_PreVentasPDA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Tab_Pendientes.Click, AddressOf Sb_Actualizar_Grilla
        AddHandler Tab_NvvGeneradas.Click, AddressOf Sb_Actualizar_Grilla
        AddHandler Tab_SolPermiso.Click, AddressOf Sb_Actualizar_Grilla

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Pda.NUDO, Pda.ENDO, Pda.SUENDO, Ent.NOKOEN, Pda.EMPRESA, Pda.SUDO,Pda.KOFUDO, GETDATE()," &
                       " Pda.FEEMDO, Pda.VANEDO, Pda.VAIVDO, Pda.VABRDO, Pda.LINEAS, Pda.IDPDAENCA" & vbCrLf &
                       "From PDAENCA Pda WITH (NOLOCK)" & vbCrLf &
                       "Left Join MAEEN Ent ON Pda.ENDO = Ent.KOEN AND Pda.SUENDO = Ent.SUEN" & vbCrLf &
                       "Where Pda.VALIDO = 'S' And Pda.EMPRESA = '" & Mod_Empresa & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then

            Dim _Filtro_Pdaenca As String = Generar_Filtro_IN(_Tbl, "", "IDPDAENCA", True, False, "")

            If _Filtro_Pdaenca = "()" Then
                _Filtro_Pdaenca = "(0)"
            End If

            Consulta_sql = $"Insert Into {_Global_BaseBk}Zw_Pda2NVV (
        Numero, CodEntidad, CodSucEntidad, Nombre_Entidad, Empresa, Sucursal,
        CodFuncionario, FechaImporta, FechaEmision, Neto, Iva, Bruto, Lineas, Idpdaenca, Estado
    )
    Select 
        Pda.NUDO, Pda.ENDO, Pda.SUENDO, Ent.NOKOEN, Pda.EMPRESA, Pda.SUDO,
        Pda.KOFUDO, GETDATE(), Pda.FEEMDO, Pda.VANEDO, Pda.VAIVDO, Pda.VABRDO,
        Pda.LINEAS, Pda.IDPDAENCA, 'Pendiente'
    From PDAENCA Pda WITH (NOLOCK)
    Left Join MAEEN Ent On Pda.ENDO = Ent.KOEN AND Pda.SUENDO = Ent.SUEN
    Where IDPDAENCA In {_Filtro_Pdaenca};

    -- 2. Actualizar campo VALIDO a 'B' para los registros traspasados
    Update PDAENCA
    Set VALIDO = 'B'
    Where IDPDAENCA In {_Filtro_Pdaenca}"
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        End If

        Dim _Estado As String
        Dim _Tbas = Super_TabS.SelectedTab

        Select Case _Tbas.Name
            Case "Tab_Pendientes"
                _Estado = "Pendiente"
            Case "Tab_NvvGeneradas"
                _Estado = "NVVGenerada"
            Case "Tab_SolPermiso"
                _Estado = "SolPermiso"
        End Select


        Consulta_sql = "Select Cast(0 As Bit) As 'Chk',* From " & _Global_BaseBk & "Zw_Pda2NVV Where Estado = '" & _Estado & "'"
        _Tbl_Preventas = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Preventas

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            '.Columns("BtnImagen_Estado").Width = 30
            '.Columns("BtnImagen_Estado").HeaderText = "Est."
            '.Columns("BtnImagen_Estado").Visible = _MostrarImagenes
            '.Columns("BtnImagen_Estado").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Chk").Visible = True
            .Columns("Chk").HeaderText = "Sel."
            .Columns("Chk").ToolTipText = "Selección"
            .Columns("Chk").Width = 30
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").Visible = (_Tbas.Name = "Tab_Pendientes")
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodFuncionario").Visible = True
            .Columns("CodFuncionario").HeaderText = "Ven"
            .Columns("CodFuncionario").ToolTipText = "Vendedor"
            .Columns("CodFuncionario").Width = 30
            .Columns("CodFuncionario").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sucursal").Visible = True
            .Columns("Sucursal").HeaderText = "Suc"
            .Columns("Sucursal").Width = 30
            .Columns("Sucursal").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Numero").Visible = True
            .Columns("Numero").HeaderText = "Número"
            .Columns("Numero").Width = 90
            .Columns("Numero").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaEmision").Visible = True
            .Columns("FechaEmision").HeaderText = "Fecha"
            .Columns("FechaEmision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaEmision").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaEmision").Width = 70
            .Columns("FechaEmision").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodEntidad").Visible = True
            .Columns("CodEntidad").HeaderText = "Entidad"
            .Columns("CodEntidad").Width = 90
            .Columns("CodEntidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CodSucEntidad").Visible = True
            .Columns("CodSucEntidad").HeaderText = "Suc"
            .Columns("CodSucEntidad").ToolTipText = "Sucursal de la entidad"
            .Columns("CodSucEntidad").Width = 50
            .Columns("CodSucEntidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombre_Entidad").Visible = True
            .Columns("Nombre_Entidad").HeaderText = "Razón Social"
            .Columns("Nombre_Entidad").Width = 400
            .Columns("Nombre_Entidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bruto").Width = 100
            .Columns("Bruto").HeaderText = "Total Bruto"
            .Columns("Bruto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Bruto").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Bruto").Visible = True
            .Columns("Bruto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Lineas").Width = 50
            .Columns("Lineas").HeaderText = "Ítems"
            .Columns("Lineas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Lineas").Visible = True
            .Columns("Lineas").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        Me.Cursor = Cursors.Default

    End Sub

    ' PSEUDOCÓDIGO (detalle de los pasos a implementar):
    ' 1) Verificar que el índice de fila (e.RowIndex) sea válido (>= 0).
    ' 2) Obtener el DataBoundItem de la fila: TryCast(Grilla.Rows(e.RowIndex).DataBoundItem, DataRowView).
    ' 3) Si se obtiene un DataRowView, extraer la DataRow con .Row.
    ' 4) Si DataRowView es Nothing, intentar obtener la fila desde _Tbl_Preventas usando el índice (fallback).
    ' 5) Usar la DataRow obtenida para leer columnas o para pasarla a la clase Cl_PDARandomMovil.
    ' 6) Manejar nulos/DBNull y casos en que la fila no exista.
    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Return
        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        Dim _Mensaje As New LsValiciones.Mensajes

        ' Crear instancia de la clase y pasar datos según su API
        Dim _Cl_PDARandomMovil As New Cl_PDARandomMovil
        Dim _Zw_Pda2NVV As New Zw_Pda2NVV

        _Mensaje = _Cl_PDARandomMovil.Fx_Llenar_Zw_Pda2NVV(_Id)

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(_Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Zw_Pda2NVV = _Mensaje.Tag

        _Mensaje = _Cl_PDARandomMovil.Fx_Crear_NVV_PDARandomMOVIL(_Zw_Pda2NVV, Mod_Modalidad)

        ''_Mensaje = _Cl_PDARandomMovil.Fx_RevisarSituacionComercialCliente(_FilaDataRow, Date.Now)

        'If _Mensaje.EsCorrecto Then

        'Else

        'End If

        _Cl_PDARandomMovil.Fx_Actualizar_Estado_Zw_Pda2NVV(_Zw_Pda2NVV)

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Chk_Marcar_Todas_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Marcar_Todas.CheckedChanged

        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Chk").Value = Chk_Marcar_Todas.Checked
        Next

    End Sub

    Private Sub Grilla_MouseUp(sender As Object, e As MouseEventArgs) Handles Grilla.MouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Btn_Procesar_Click(sender As Object, e As EventArgs) Handles Btn_Procesar.Click

        ' Asegurar que la edición en la grilla quede comprometida
        Try
            Grilla.EndEdit()
        Catch ex As Exception
            ' Ignorar si falla EndEdit por cualquier motivo
        End Try

        Dim haySeleccion As Boolean = False

        For Each _Fila As DataGridViewRow In Grilla.Rows

            ' Evitar filas de nueva entrada o nulas
            If _Fila Is Nothing OrElse _Fila.IsNewRow Then
                Continue For
            End If

            Dim _Valor = _Fila.Cells("Chk").Value

            If _Valor Is Nothing OrElse IsDBNull(_Valor) Then
                Continue For
            End If

            Try
                If CBool(_Valor) Then
                    haySeleccion = True
                    Exit For
                End If
            Catch ex As Exception
                ' Si CBool falla intentar interpretar como entero (1/0) o como texto
                Try
                    Dim _intVal As Integer = Convert.ToInt32(_Valor)
                    If _intVal <> 0 Then
                        haySeleccion = True
                        Exit For
                    End If
                Catch
                    Dim _strVal As String = Convert.ToString(_Valor).ToLower().Trim()
                    If _strVal = "true" OrElse _strVal = "1" Then
                        haySeleccion = True
                        Exit For
                    End If
                End Try
            End Try

        Next

        If Not haySeleccion Then
            MessageBoxEx.Show("No hay ninguna pre-venta seleccionada. Marque al menos una para procesar.", "Atención",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Ls_Mensajes As New List(Of LsValiciones.Mensajes)

        For Each _Fila As DataGridViewRow In Grilla.Rows

            ' Evitar filas de nueva entrada o nulas
            If _Fila Is Nothing OrElse _Fila.IsNewRow Then
                Continue For
            End If
            Dim _Valor = _Fila.Cells("Chk").Value
            If _Valor Is Nothing OrElse IsDBNull(_Valor) Then
                Continue For
            End If
            Dim _EstaSeleccionada As Boolean = False
            Try
                _EstaSeleccionada = CBool(_Valor)
            Catch ex As Exception
                ' Si CBool falla intentar interpretar como entero (1/0) o como texto
                Try
                    Dim _intVal As Integer = Convert.ToInt32(_Valor)
                    _EstaSeleccionada = (_intVal <> 0)
                Catch
                    Dim _strVal As String = Convert.ToString(_Valor).ToLower().Trim()
                    _EstaSeleccionada = (_strVal = "true" OrElse _strVal = "1")
                End Try
            End Try

            If _EstaSeleccionada Then

                Dim _Id As Integer = _Fila.Cells("Id").Value
                Dim _Mensaje As New LsValiciones.Mensajes

                ' Crear instancia de la clase y pasar datos según su API
                Dim _Cl_PDARandomMovil As New Cl_PDARandomMovil
                Dim _Zw_Pda2NVV As New Zw_Pda2NVV

                _Mensaje = _Cl_PDARandomMovil.Fx_Llenar_Zw_Pda2NVV(_Id)

                If Not _Mensaje.EsCorrecto Then
                    MessageBoxEx.Show(_Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                _Zw_Pda2NVV = _Mensaje.Tag

                _Mensaje = _Cl_PDARandomMovil.Fx_Crear_NVV_PDARandomMOVIL(_Zw_Pda2NVV, Mod_Modalidad)

                If _Mensaje.HuboOtroError Then
                    _Zw_Pda2NVV.Estado = "Error"
                    _Zw_Pda2NVV.Observaciones = _Mensaje.Mensaje
                End If

                _Cl_PDARandomMovil.Fx_Actualizar_Estado_Zw_Pda2NVV(_Zw_Pda2NVV)
                _Ls_Mensajes.Add(_Mensaje)

            End If

        Next

        Dim ListaQr As LsValiciones.Mensajes = _Ls_Mensajes.FirstOrDefault(Function(p) p.EsCorrecto = False)

        If Not IsNothing(ListaQr) Then

            MessageBoxEx.Show(Me, "Hay documentos con problemas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        Dim Fmv As New Frm_Validaciones
        Fmv.ListaMensajes = _Ls_Mensajes
        Fmv.ShowDialog(Me)
        Fmv.Dispose()

        Sb_Actualizar_Grilla()

    End Sub

End Class
