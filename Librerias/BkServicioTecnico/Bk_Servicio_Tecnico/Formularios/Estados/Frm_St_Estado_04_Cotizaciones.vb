Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc
Imports BkSpecialPrograms
Imports System.Data.SqlClient


Public Class Frm_St_Estado_04_Cotizaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _DsDocumento As DataSet
    Dim _Row_Encabezado As DataRow
    Dim _RowEntidad As DataRow
    Dim _TblDetalle_Cov As DataTable
    Dim _Row_Notas As DataRow

    Dim _Id_Ot As Integer
    Dim _TblCotizaciones As DataTable

    Dim _Editando_documento As Boolean

    Dim _Fijar_Estado As Boolean

    Dim _Estado_Fijar As Estado_Fijar

    Enum Estado_Fijar
        Aceptado
        Rechazado
        Evaluacion
    End Enum

    Dim _Accion As Accion

    Enum Accion
        Nuevo
        Editar
    End Enum

    Public Sub New(ByVal Accion As Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Accion = Accion

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_St_Estado_04_Cotizaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InsertarBotonenGrilla(Grilla, "Btn_Ver", "Ver", "Ver", 0, _Tipo_Boton.Boton)
        InsertarBotonenGrilla(Grilla, "Btn_Accion", "Cambiar estado", "", 1, _Tipo_Boton.Boton)
        Sb_Actualizar_Grilla()

        If _Accion = Accion.Editar Then

            Btn_Agregar_Cotizacion.Visible = False
            Btn_Fijar_Estado.Visible = False
            Btn_Editar.Visible = True

            Btn_Presupues_Aceptado.Enabled = False
            Btn_Presupuesto_Rechazado.Enabled = False
            Btn_Presupuestos_Evaluacion.Enabled = False

            Txt_Nota.ReadOnly = True
            Txt_Nota.BackColor = Color.LightGray
            Txt_Nota.FocusHighlightEnabled = False

            Chk_No_Existe_COV_Ni_NVV.Enabled = False

            If _Row_Encabezado.Item("CodEstado") = "CE" Then
                Btn_Editar.Visible = False
            End If

        End If

        Me.Refresh()
        ' InsertarBotonenGrilla(Grilla, "Btn_Rechazado", "Rechazado", "Rechazar", 6, _Tipo_Boton.Boton)

    End Sub

    Sub Sb_Actualizar_Grilla()


        With Grilla

            .DataSource = _TblCotizaciones

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Btn_Ver").Visible = True
            .Columns("Btn_Ver").HeaderText = "Ver"
            .Columns("Btn_Ver").Width = 30
            .Columns("Btn_Ver").DisplayIndex = 0

            .Columns("Tido").Visible = True
            .Columns("Tido").HeaderText = "Tipo"
            .Columns("Tido").Width = 40
            .Columns("Tido").DisplayIndex = 1
            .Columns("Tido").ReadOnly = True

            .Columns("Nudo").Visible = True
            .Columns("Nudo").HeaderText = "Número"
            .Columns("Nudo").Width = 70
            .Columns("Nudo").ReadOnly = True
            .Columns("Nudo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Nudo").DisplayIndex = 2

            .Columns("Estado_D").Visible = True
            .Columns("Estado_D").HeaderText = "Estado"
            .Columns("Estado_D").Width = 120
            .Columns("Estado_D").ReadOnly = True
            .Columns("Estado_D").DisplayIndex = 3

            .Columns("Fecha_Doc").Visible = True
            .Columns("Fecha_Doc").HeaderText = "Fecha"
            .Columns("Fecha_Doc").Width = 70
            .Columns("Fecha_Doc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Cantidad").DefaultCellStyle.Format = "###,##.##"
            .Columns("Fecha_Doc").ReadOnly = True
            .Columns("Fecha_Doc").DisplayIndex = 4

            'If _Accion = Accion.Nuevo Then
            .Columns("Btn_Accion").Visible = True
            .Columns("Btn_Accion").HeaderText = "Acción"
            .Columns("Btn_Accion").Width = 120
            .Columns("Btn_Accion").DisplayIndex = 5
            'End If

        End With

        Sb_Marcar_Grilla()



    End Sub

    Private Sub Btn_Agregar_Cotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar_Cotizacion.Click

        Dim _Filtro_Doc As String = Generar_Filtro_IN(_TblCotizaciones, "", "Idmaeedo", False, False, "")

        Dim _RowDocumento As DataRow

        Dim Fm As New Frm_BusquedaDocumento_Filtro(False)
        Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, "COV", "Where TIDO IN ('COV','NVV')")
        Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado

        If _Filtro_Doc <> "()" Then
            Fm.Pro_Sql_Filtro_Otro_Filtro = "And IDMAEEDO not in " & _Filtro_Doc
        End If

        Fm.Pro_RowEntidad = _RowEntidad
        Fm.ShowDialog(Me)
        _RowDocumento = Fm.Pro_Row_Documento_Seleccionado
        Fm.Dispose()

        If Not (_RowDocumento Is Nothing) Then

            With _RowDocumento
                Dim _Idmaeedo = .Item("IDMAEEDO")
                Dim _Tido = .Item("TIDO")
                Dim _Nudo = .Item("NUDO")
                Dim _Feemdo = .Item("FEEMDO")


                Dim NewFila As DataRow
                NewFila = _TblCotizaciones.NewRow
                With NewFila

                    .Item("Idmaeedo") = _Idmaeedo
                    .Item("Tido") = _Tido
                    .Item("Nudo") = _Nudo
                    .Item("Estado") = "E"
                    .Item("Estado_D") = "En Evaluación..."
                    .Item("Fecha_Doc") = _Feemdo

                    _TblCotizaciones.Rows.Add(NewFila)

                End With
            End With

            Chk_No_Existe_COV_Ni_NVV.Enabled = False

        Else

            Chk_No_Existe_COV_Ni_NVV.Enabled = True

        End If

        Sb_Marcar_Grilla()
        'Btn_Grabar.Visible = True

    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Sub Sb_Marcar_Grilla()

        Dim _Activos = 0

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Estado = _Fila.Cells("Estado").Value

            Select Case _Estado
                Case "E"
                    Btn_Agregar_Cotizacion.Enabled = False
                    _Fila.DefaultCellStyle.BackColor = Color.Yellow
                Case "A" ' Evaluación, Aprobado
                    Btn_Agregar_Cotizacion.Enabled = False
                    _Fila.DefaultCellStyle.BackColor = Color.LightGreen
                Case "R" ' Rechazado
                    Btn_Agregar_Cotizacion.Enabled = True
                    _Fila.DefaultCellStyle.BackColor = Color.LightGray
            End Select

        Next

        For Each _Row As DataRow In _TblCotizaciones.Rows
            If _Row.RowState <> DataRowState.Deleted Then
                _Activos += 1
            End If
        Next

        Btn_Fijar_Estado.Visible = CBool(_Activos)

    End Sub


    Private Sub Grilla_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Estado = _Fila.Cells("Estado").Value

        Select Case _Cabeza
            Case "Btn_Ver"

                If _Accion = Accion.Nuevo Then
                    Select Case _Estado
                        Case "E"
                            Btn_Quitar_documento.Enabled = True
                        Case Else
                            Btn_Quitar_documento.Enabled = False
                    End Select

                    ShowContextMenu(Menu_Contextual_Ver_Quitar)
                ElseIf _Accion = Accion.Editar Then
                    Sb_Ver_Documento()
                End If

            Case "Btn_Accion"

                Select Case _Estado
                    Case "E"
                        Btn_Presupues_Aceptado.Enabled = True
                        Btn_Presupuesto_Rechazado.Enabled = True
                        Btn_Presupuestos_Evaluacion.Visible = False
                    Case Else
                        Btn_Presupues_Aceptado.Enabled = False
                        Btn_Presupuesto_Rechazado.Enabled = False
                        Btn_Presupuestos_Evaluacion.Visible = True
                End Select

                ShowContextMenu(Menu_Contextual_Accion)

        End Select


    End Sub


    Function Fx_Fijar_Estado() As Boolean

        Dim _Fijar As Boolean

        ' ----------------------------------------------------- COTIZACIONES ASOCIADAS ------------------------------------------------
        Consulta_sql = String.Empty

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados Where Id_Ot = " & _Id_Ot & " And Tido = 'COV'" & vbCrLf & vbCrLf

        If CBool(Grilla.Rows.Count) Then

            For Each _Fila As DataRow In _TblCotizaciones.Rows

                Dim _Idmaeedo = _Fila.Item("Idmaeedo")
                Dim _Tido = _Fila.Item("Tido")
                Dim _Nudo = _Fila.Item("Nudo")
                Dim _Estado = _Fila.Item("Estado")
                Dim _Fecha_Doc = Format(_Fila.Item("Fecha_Doc"), "yyyyMMdd")

                Consulta_sql += "Insert Into " & _Global_BaseBk & _
                               "Zw_St_OT_Doc_Asociados (Id_Ot,Idmaeedo,Tido,Nudo,Estado,Fecha_Asociacion,Fecha_Doc) Values " & _
                               "(" & _Id_Ot & "," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "','" & _Estado & _
                               "',GetDate(),'" & _Fecha_Doc & "')" & vbCrLf

            Next

        End If

        '**********************************'***********************************************************************

        ' --------------------------------------------------- NOTAS ---------------------------------------

        Dim _Nota_Etapa_04 As String = Txt_Nota.Text

        Consulta_sql += vbCrLf & vbCrLf & _
                       "Update " & _Global_BaseBk & "Zw_St_OT_Notas Set " & vbCrLf & _
                       "Nota_Etapa_04 = '" & _Nota_Etapa_04 & "'" & vbCrLf & _
                       "Where Id_Ot = " & _Id_Ot & vbCrLf & vbCrLf
        '**********************************'**********************************

        If Chk_No_Existe_COV_Ni_NVV.Checked Then

            Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " & _
                            "CodEstado = 'R',Chk_No_Existe_COV_Ni_NVV = 1" & vbCrLf & _
                            "Where Id_Ot  = " & _Id_Ot & vbCrLf & vbCrLf

            If _Accion = Accion.Nuevo Then

                Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_Estados " & _
                                "(Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " & _
                                "(" & _Id_Ot & ",'C',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')" & vbCrLf & vbCrLf

            End If


        Else


            If _Estado_Fijar = Estado_Fijar.Aceptado Or _Estado_Fijar = Estado_Fijar.Rechazado Then

                ' ACTUALIZAR ENCABEZADO DE DOCUMENTO


                Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " & _
                                 "CodEstado = 'R'" & vbCrLf & _
                                 "Where Id_Ot  = " & _Id_Ot & vbCrLf & vbCrLf

                ' ACTUALIZAR ESTADO

                Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_Estados " & _
                               "(Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " & _
                               "(" & _Id_Ot & ",'C',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')" & vbCrLf & vbCrLf


                If _Estado_Fijar = Estado_Fijar.Aceptado Then

                    Consulta_sql += "Delete " & _Global_BaseBk & "Zw_St_OT_DetProd Where Desde_COV = 1 And Id_Ot = " & _Id_Ot & vbCrLf & vbCrLf

                    For Each _Fila_Cov As DataRow In _TblDetalle_Cov.Rows

                        ',,,UD02PR,,,,,,
                        Dim _Idmaeedo = _Fila_Cov.Item("IDMAEEDO")
                        Dim _Idmaeddo = _Fila_Cov.Item("IDMAEDDO")
                        Dim _Codigo = _Fila_Cov.Item("KOPRCT")
                        Dim _Descripcion = _Fila_Cov.Item("NOKOPR")

                        Dim _Un As Integer = _Fila_Cov.Item("UDTRPR")

                        Dim _Ud = _Fila_Cov.Item("UD0" & _Un & "PR")

                        Dim _Cantidad = _Fila_Cov.Item("CAPRCO" & _Un)
                        Dim _CantUd1 = _Fila_Cov.Item("CAPRCO1")
                        Dim _CantUd2 = _Fila_Cov.Item("CAPRCO2")
                        Dim _Precio = _Fila_Cov.Item("PPPRNE")
                        Dim _Neto_Linea = _Fila_Cov.Item("VANELI")
                        Dim _Iva_Linea = _Fila_Cov.Item("VAIVLI")
                        Dim _Total_Linea = _Fila_Cov.Item("VABRLI")

                        Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_DetProd (Id_Ot,Utilizado,Codigo,Descripcion," & _
                                       "Cantidad,Cantidad_Utilizada,Ud,Un," & _
                                       "CantUd1,CantUd2,Precio,Neto_Linea,Iva_Linea,Total_Linea,Desde_COV,Idmaeedo_Cov,Idmaeddo_Cov) Values " & _
                                       "(" & _Id_Ot & ",0,'" & _Codigo & "','" & _Descripcion & _
                                       "'," & De_Num_a_Tx_01(_Cantidad, False, 5) & _
                                       "," & De_Num_a_Tx_01(_Cantidad, False, 5) & _
                                       ",'" & _Ud & "'," & _Un & _
                                       "," & De_Num_a_Tx_01(_CantUd1, False, 5) & _
                                       "," & De_Num_a_Tx_01(_CantUd2, False, 5) & _
                                       "," & De_Num_a_Tx_01(_Precio, False, 5) & _
                                       "," & De_Num_a_Tx_01(_Neto_Linea, False, 5) & _
                                       "," & De_Num_a_Tx_01(_Iva_Linea, False, 5) & _
                                       "," & De_Num_a_Tx_01(_Total_Linea, False, 5) & ",1," & _Idmaeedo & "," & _Idmaeddo & ")" & vbCrLf

                    Next

                End If

            End If

        End If
        '**********************************'**********************************


        _Fijar = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)
        Return _Fijar

    End Function

    Private Sub Btn_Fijar_Estado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Fijar_Estado.Click

        Dim _Rechazados = 0
        Dim _Aprobados = 0
        Dim _Evaluacion = 0

        Dim _Idmaeedo As Integer

        For Each _Fila As DataRow In _TblCotizaciones.Rows

            Dim _Estado = _Fila.Item("Estado")

            If _Estado = "E" Then _Evaluacion += 1

            If _Estado = "A" Then
                _Idmaeedo = _Fila.Item("Idmaeedo")
                _Aprobados += 1
            End If

            If _Estado = "R" Then _Rechazados += 1

        Next

        If _Evaluacion = 1 Then
            _Estado_Fijar = Estado_Fijar.Evaluacion
        Else
            If _Aprobados > 0 Then
                _Estado_Fijar = Estado_Fijar.Aceptado

                Consulta_sql = "Select * From MAEDDO Where IDMAEEDO = " & _Idmaeedo & " And TIPR <> 'SSN' Order By IDMAEDDO"
                _TblDetalle_Cov = _Sql.Fx_Get_Tablas(Consulta_sql)


            ElseIf _Rechazados > 0 Then

                If MessageBoxEx.Show(Me, "Acaba de marcar las cotizaciones como RECHAZADA." & vbCrLf & _
                                     "El sistema no trasladara ningún producto al cierre de esta Orden de Trabajo." & vbCrLf & vbCrLf & _
                                     "¿Desea seguir con esta acción?", "Cotizaciones Rechazadas", _
                                     MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.OK Then
                    _Estado_Fijar = Estado_Fijar.Rechazado
                Else
                    Return
                End If

            End If
        End If


        If Fx_Fijar_Estado() Then

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Fijar estado", _
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Fijar_Estado = True
            Me.Close()
        End If
    End Sub

#Region "PROPIEDADES"

    Public Property Pro_DsDocumento() As DataSet
        Get
            Return _DsDocumento
        End Get
        Set(ByVal value As DataSet)
            _DsDocumento = value
            _Row_Encabezado = _DsDocumento.Tables(0).Rows(0)
            _TblCotizaciones = _DsDocumento.Tables(6)
            _Row_Notas = _DsDocumento.Tables(3).Rows(0)
            Txt_Nota.Text = _Row_Notas.Item("Nota_Etapa_04")
            Chk_No_Existe_COV_Ni_NVV.Checked = _Row_Encabezado.Item("Chk_No_Existe_COV_Ni_NVV")
        End Set
    End Property

    Public Property Pro_RowEntidad() As DataRow
        Get
            Return _RowEntidad
        End Get
        Set(ByVal value As DataRow)
            _RowEntidad = value
        End Set
    End Property

    Public Property Pro_Id_Ot() As Integer
        Get
            Return _Id_Ot
        End Get
        Set(ByVal value As Integer)
            _Id_Ot = value
        End Set
    End Property

    Public Property Pro_Editando_Documento() As Boolean
        Get
            Return _Editando_documento
        End Get
        Set(ByVal value As Boolean)
            _Editando_documento = value
        End Set
    End Property

    Public Property Pro_Fijar_Estado() As Boolean
        Get
            Return _Fijar_Estado
        End Get
        Set(ByVal value As Boolean)
            _Fijar_Estado = value
        End Set
    End Property


#End Region


    Private Sub Btn_Presupues_Aceptado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Presupues_Aceptado.Click

        For Each _Row As DataGridViewRow In Grilla.Rows
            _Row.Cells("Seleccionado").Value = False
        Next

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        _Fila.Cells("Estado").Value = "A"
        _Fila.Cells("Estado_D").Value = "ACEPTADO"
        _Fila.Cells("Seleccionado").Value = True

        Btn_Agregar_Cotizacion.Enabled = False
        Sb_Marcar_Grilla()
        Me.Refresh()

    End Sub

    Private Sub Btn_Presupuesto_Rechazado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Presupuesto_Rechazado.Click

        For Each _Row As DataGridViewRow In Grilla.Rows
            _Row.Cells("Seleccionado").Value = False
        Next

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        _Fila.Cells("Estado").Value = "R"
        _Fila.Cells("Estado_D").Value = "RECHAZADO"
        _Fila.Cells("Seleccionado").Value = True

        Btn_Agregar_Cotizacion.Enabled = True
        Sb_Marcar_Grilla()
        Me.Refresh()
    End Sub

    Private Sub Btn_Presupuestos_Evaluacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Presupuestos_Evaluacion.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Id = _Fila.Cells("Idmaeedo").Value

        For Each _Row As DataRow In _TblCotizaciones.Rows

            Dim _Idmaeedo = _Row.Item("Idmaeedo")
            Dim _Estado = _Row.Item("Estado")

            If _Idmaeedo <> _Id Then
                If _Estado = "E" Then
                    MessageBoxEx.Show(Me, "Hay otra cotización en evaluación." & vbCrLf & _
                                      "No puede tener mas de 1 cotizacion en evaluación para una misma OT", "Validación", _
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                ElseIf _Estado = "A" Then
                    MessageBoxEx.Show(Me, "Hay otra cotización que ya esta aceptada." & vbCrLf & _
                                      "No puede tener mas de 1 cotizacion en evaluación para una misma OT", "Validación", _
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If
            End If

        Next


        _Fila.Cells("Estado").Value = "E"
        _Fila.Cells("Estado_D").Value = "En Evaluación.."
        Sb_Marcar_Grilla()
        Btn_Agregar_Cotizacion.Enabled = False

        Me.Refresh()

    End Sub

    Private Sub Btn_Ver_documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_documento.Click
        Sb_Ver_Documento()
    End Sub

    Sub Sb_Ver_Documento()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaeedo As Integer = _Fila.Cells("Idmaeedo").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Quitar_documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quitar_documento.Click

        Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
        Grilla.Refresh()

        Dim _Agregar_COV As Boolean

        If CBool(Grilla.Rows.Count) Then

            For Each _Fila As DataRow In _TblCotizaciones.Rows
                If _Fila.RowState <> DataRowState.Deleted Then
                    Dim _Estado = _Fila.Item("Estado")
                End If
            Next
        Else
            _Agregar_COV = True
            Btn_Fijar_Estado.Visible = False
        End If

        Btn_Agregar_Cotizacion.Enabled = _Agregar_COV
        Me.Refresh()

    End Sub

    Private Sub Frm_St_Estado_04_Cotizaciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_St_OT_Estados", "Id_Ot = " & _Id_Ot & " And CodEstado = 'R'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se puede modificar el estado, ya que existe un estado posterior", "Validación", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else

            Btn_Editar.Visible = False

            If Chk_No_Existe_COV_Ni_NVV.Checked Then
                Grilla.Enabled = False
                Btn_Fijar_Estado.Visible = True
                Btn_Agregar_Cotizacion.Visible = False
                _Editando_documento = True
                Chk_No_Existe_COV_Ni_NVV.Enabled = True
            Else
                If MessageBoxEx.Show(Me, "¿Esta seguro de dejar los documentos en evaluación?", "Dejar documentos en evaluación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_St_OT_Estados Where Id_Ot = " & _Id_Ot & " And CodEstado = 'C'" & vbCrLf & _
                                   "Update " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados Set Estado = 'E',Seleccionado = 0" & vbCrLf & _
                                   "Where Id_Ot = " & _Id_Ot & " And Tido = 'COV' And Seleccionado = 1" & vbCrLf & _
                                   "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " & _
                                   "CodEstado = 'P',Estado = 'PRESUPUESTO'" & vbCrLf & _
                                   "Where Id_Ot  = " & _Id_Ot

                    If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                        _Editando_documento = True
                    End If

                    Me.Close()

                End If
            End If

            Txt_Nota.ReadOnly = False
            Txt_Nota.BackColor = Color.White
            Txt_Nota.FocusHighlightEnabled = True


            Me.Refresh()

        End If

    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    
    Private Sub Chk_No_Existe_COV_Ni_NVV_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Chk_No_Existe_COV_Ni_NVV.Validating

        If CBool(Grilla.Rows.Count) Then
            e.Cancel = True
        End If

    End Sub


    Private Sub Chk_No_Existe_COV_Ni_NVV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_No_Existe_COV_Ni_NVV.CheckedChanged

        If Chk_No_Existe_COV_Ni_NVV.Checked Then
            Grilla.Enabled = False
            Btn_Fijar_Estado.Visible = True
            Btn_Agregar_Cotizacion.Visible = False
        Else
            Grilla.Enabled = True
            Btn_Fijar_Estado.Visible = False
            Btn_Agregar_Cotizacion.Visible = True
        End If

        Me.Refresh()

    End Sub

End Class