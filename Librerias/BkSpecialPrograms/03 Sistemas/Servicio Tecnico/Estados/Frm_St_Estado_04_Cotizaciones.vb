Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc
'Imports BkSpecialPrograms


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

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_St_Estado_04_Cotizaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InsertarBotonenGrilla(Grilla, "Btn_Ver", "Ver", "Ver", 0, _Tipo_Boton.Boton)
        InsertarBotonenGrilla(Grilla, "Btn_Accion", "Cambiar estado", "", 1, _Tipo_Boton.Boton)
        Sb_Actualizar_Grilla()

        If _Accion = Accion.Nuevo Then
            Btn_EditarPresupuesto.Visible = True
        End If

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

        Chk_No_Existe_COV_Ni_NVV.Enabled = Not CBool(Grilla.RowCount)

    End Sub

    Private Sub Btn_Agregar_Cotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar_Cotizacion.Click
        ShowContextMenu(Menu_Contextual_COV)
    End Sub

    Sub Sb_Marcar_Grilla()

        Dim _Activos = 0

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Estado = _Fila.Cells("Estado").Value

            Select Case _Estado
                Case "E"
                    Btn_Agregar_Cotizacion.Enabled = False
                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Fila.DefaultCellStyle.ForeColor = Amarillo
                    Else
                        _Fila.DefaultCellStyle.BackColor = Color.Yellow
                    End If
                Case "A" ' Evaluación, Aprobado
                    Btn_Agregar_Cotizacion.Enabled = False
                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Fila.DefaultCellStyle.ForeColor = Verde
                    Else
                        _Fila.DefaultCellStyle.BackColor = Color.LightGreen
                    End If
                Case "R" ' Rechazado
                    Btn_Agregar_Cotizacion.Enabled = True
                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Fila.DefaultCellStyle.ForeColor = Rojo
                    Else
                        _Fila.DefaultCellStyle.BackColor = Color.LightGray
                    End If
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

                Btn_Quitar_documento.Enabled = (_Estado = "E")
                Btn_Correo_Outlook.Enabled = Not (_Estado = "R")

                ShowContextMenu(Menu_Contextual_Ver_Quitar)

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

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados Where Id_Ot = " & _Id_Ot & " And Tido In ('COV','NVV')" & vbCrLf & vbCrLf

        If CBool(Grilla.Rows.Count) Then

            For Each _Fila As DataRow In _TblCotizaciones.Rows

                Dim _Idmaeedo = _Fila.Item("Idmaeedo")
                Dim _Tido = _Fila.Item("Tido")
                Dim _Nudo = _Fila.Item("Nudo")
                Dim _Estado = _Fila.Item("Estado")
                Dim _Fecha_Doc = Format(_Fila.Item("Fecha_Doc"), "yyyyMMdd")

                Consulta_sql += "Insert Into " & _Global_BaseBk &
                               "Zw_St_OT_Doc_Asociados (Id_Ot,Idmaeedo,Tido,Nudo,Estado,Fecha_Asociacion,Fecha_Doc) Values " &
                               "(" & _Id_Ot & "," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "','" & _Estado &
                               "',GetDate(),'" & _Fecha_Doc & "')" & vbCrLf

            Next

        End If

        '**********************************'***********************************************************************

        ' --------------------------------------------------- NOTAS ---------------------------------------

        Dim _Nota_Etapa_04 As String = Txt_Nota.Text

        Consulta_sql += vbCrLf & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_St_OT_Notas Set " & vbCrLf &
                       "Nota_Etapa_04 = '" & _Nota_Etapa_04 & "'" & vbCrLf &
                       "Where Id_Ot = " & _Id_Ot & vbCrLf & vbCrLf
        '**********************************'**********************************

        If Chk_No_Existe_COV_Ni_NVV.Checked Then

            Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " &
                            "CodEstado = 'R',Chk_No_Existe_COV_Ni_NVV = 1" & vbCrLf &
                            "Where Id_Ot  = " & _Id_Ot & vbCrLf & vbCrLf

            If _Accion = Accion.Nuevo Then

                Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_Estados " &
                                "(Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " &
                                "(" & _Id_Ot & ",'C',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')" & vbCrLf & vbCrLf

            End If


        Else


            If _Estado_Fijar = Estado_Fijar.Aceptado Or _Estado_Fijar = Estado_Fijar.Rechazado Then

                ' ACTUALIZAR ENCABEZADO DE DOCUMENTO

                Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " &
                                 "CodEstado = 'R'" & vbCrLf &
                                 "Where Id_Ot  = " & _Id_Ot & vbCrLf & vbCrLf

                ' ACTUALIZAR ESTADO

                Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_Estados " &
                               "(Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " &
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

                        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_St_OT_DetProd", "Idmaeddo_Cov = " & _Idmaeddo)

                        If Not CBool(_Reg) Then

                            Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_DetProd (Id_Ot,Utilizado,Codigo,Descripcion," &
                                               "Cantidad,Cantidad_Utilizada,Ud,Un," &
                                               "CantUd1,CantUd2,Precio,Neto_Linea,Iva_Linea,Total_Linea,Desde_COV,Idmaeedo_Cov,Idmaeddo_Cov) Values " &
                                               "(" & _Id_Ot & ",0,'" & _Codigo & "','" & _Descripcion &
                                               "'," & De_Num_a_Tx_01(_Cantidad, False, 5) &
                                               "," & De_Num_a_Tx_01(_Cantidad, False, 5) &
                                               ",'" & _Ud & "'," & _Un &
                                               "," & De_Num_a_Tx_01(_CantUd1, False, 5) &
                                               "," & De_Num_a_Tx_01(_CantUd2, False, 5) &
                                               "," & De_Num_a_Tx_01(_Precio, False, 5) &
                                               "," & De_Num_a_Tx_01(_Neto_Linea, False, 5) &
                                               "," & De_Num_a_Tx_01(_Iva_Linea, False, 5) &
                                               "," & De_Num_a_Tx_01(_Total_Linea, False, 5) & ",1," & _Idmaeedo & "," & _Idmaeddo & ")" & vbCrLf

                        End If

                    Next

                End If

            End If

        End If
        '**********************************'**********************************

        _Fijar = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)
        Return _Fijar

    End Function

    Function Fx_Fijar_Estado2(_Id_Ot As Integer, _Idmaeedo As Integer, _Estado As String, _Estado_Fijar As Estado_Fijar) As String

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        Dim _RowDocumento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Tido As String = _RowDocumento.Item("TIDO")
        Dim _Nudo As String = _RowDocumento.Item("NUDO")
        Dim _Feemdo As Date = _RowDocumento.Item("FEEMDO")

        ' ----------------------------------------------------- COTIZACIONES ASOCIADAS ------------------------------------------------
        Consulta_sql = String.Empty

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados " &
                       "Where Id_Ot = " & _Id_Ot & " And Tido In ('COV','NVV')" & vbCrLf

        Consulta_sql += "Insert Into " & _Global_BaseBk &
                        "Zw_St_OT_Doc_Asociados (Id_Ot,Idmaeedo,Tido,Nudo,Estado,Fecha_Asociacion,Fecha_Doc,MovTodasSubOT) Values " &
                        "(" & _Id_Ot & "," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "','" & _Estado &
                        "',GetDate(),'" & Format(_Feemdo, "yyyyMMdd") & "',1)" & vbCrLf & vbCrLf


        '**********************************'***********************************************************************

        ' --------------------------------------------------- NOTAS ---------------------------------------

        Dim _Nota_Etapa_04 As String = Txt_Nota.Text

        Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Notas Set " &
                       "Nota_Etapa_04 = '" & _Nota_Etapa_04 & "'" & vbCrLf &
                       "Where Id_Ot = " & _Id_Ot & vbCrLf
        '**********************************'**********************************

        If Chk_No_Existe_COV_Ni_NVV.Checked Then

            Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " &
                            "CodEstado = 'R',Chk_No_Existe_COV_Ni_NVV = 1" & vbCrLf &
                            "Where Id_Ot = " & _Id_Ot & vbCrLf

            If _Accion = Accion.Nuevo Then

                Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_Estados " &
                                "(Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " &
                                "(" & _Id_Ot & ",'C',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')" & vbCrLf

            End If

        Else

            If _Estado_Fijar = Estado_Fijar.Aceptado Or _Estado_Fijar = Estado_Fijar.Rechazado Then

                ' ACTUALIZAR ENCABEZADO DE DOCUMENTO

                Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " &
                                 "CodEstado = 'R'" & vbCrLf &
                                 "Where Id_Ot  = " & _Id_Ot & vbCrLf

                ' ACTUALIZAR ESTADO

                Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_Estados " &
                "(Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " &
                "(" & _Id_Ot & ",'C',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')" & vbCrLf

                'If _Estado_Fijar = Estado_Fijar.Aceptado Then

                '    Consulta_sql += "Delete " & _Global_BaseBk & "Zw_St_OT_DetProd Where Desde_COV = 1 And Id_Ot = " & _Id_Ot & vbCrLf & vbCrLf

                '    For Each _Fila_Cov As DataRow In _TblDetalle_Cov.Rows

                '        ',,,UD02PR,,,,,,
                '        'Dim _Idmaeedo = _Fila_Cov.Item("IDMAEEDO")
                '        Dim _Idmaeddo = _Fila_Cov.Item("IDMAEDDO")
                '        Dim _Codigo = _Fila_Cov.Item("KOPRCT")
                '        Dim _Descripcion = _Fila_Cov.Item("NOKOPR")

                '        Dim _Un As Integer = _Fila_Cov.Item("UDTRPR")

                '        Dim _Ud = _Fila_Cov.Item("UD0" & _Un & "PR")

                '        Dim _Cantidad = _Fila_Cov.Item("CAPRCO" & _Un)
                '        Dim _CantUd1 = _Fila_Cov.Item("CAPRCO1")
                '        Dim _CantUd2 = _Fila_Cov.Item("CAPRCO2")
                '        Dim _Precio = _Fila_Cov.Item("PPPRNE")
                '        Dim _Neto_Linea = _Fila_Cov.Item("VANELI")
                '        Dim _Iva_Linea = _Fila_Cov.Item("VAIVLI")
                '        Dim _Total_Linea = _Fila_Cov.Item("VABRLI")

                '        Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_DetProd (Id_Ot,Utilizado,Codigo,Descripcion," &
                '                       "Cantidad,Cantidad_Utilizada,Ud,Un," &
                '                       "CantUd1,CantUd2,Precio,Neto_Linea,Iva_Linea,Total_Linea,Desde_COV,Idmaeedo_Cov,Idmaeddo_Cov) Values " &
                '                       "(" & _Id_Ot & ",0,'" & _Codigo & "','" & _Descripcion &
                '                       "'," & De_Num_a_Tx_01(_Cantidad, False, 5) &
                '                       "," & De_Num_a_Tx_01(_Cantidad, False, 5) &
                '                       ",'" & _Ud & "'," & _Un &
                '                       "," & De_Num_a_Tx_01(_CantUd1, False, 5) &
                '                       "," & De_Num_a_Tx_01(_CantUd2, False, 5) &
                '                       "," & De_Num_a_Tx_01(_Precio, False, 5) &
                '                       "," & De_Num_a_Tx_01(_Neto_Linea, False, 5) &
                '                       "," & De_Num_a_Tx_01(_Iva_Linea, False, 5) &
                '                       "," & De_Num_a_Tx_01(_Total_Linea, False, 5) & ",1," & _Idmaeedo & "," & _Idmaeddo & ")" & vbCrLf

                '    Next

                'End If

            End If

        End If
        '**********************************'**********************************

        Return Consulta_sql & vbCrLf

        '_Fijar = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)
        'Return _Fijar

    End Function

    Private Sub Btn_Fijar_Estado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Fijar_Estado.Click

        Dim _Rechazados = 0
        Dim _Aprobados = 0
        Dim _Evaluacion = 0

        Dim _Idmaeedo As Integer
        Dim _Estado As String

        For Each _Fila As DataRow In _TblCotizaciones.Rows

            _Estado = _Fila.Item("Estado")

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

                Consulta_sql = "Select * From MAEDDO Where IDMAEEDO = " & _Idmaeedo & " Order By IDMAEDDO"
                _TblDetalle_Cov = _Sql.Fx_Get_Tablas(Consulta_sql)


            ElseIf _Rechazados > 0 Then

                If MessageBoxEx.Show(Me, "Acaba de marcar los documentos como RECHAZADA." & vbCrLf &
                                     "El sistema no trasladara ningún producto al cierre de esta Orden de Trabajo." & vbCrLf & vbCrLf &
                                     "¿Desea seguir con esta acción?", "Cotizaciones Rechazadas",
                                     MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.OK Then
                    _Estado_Fijar = Estado_Fijar.Rechazado
                Else
                    Return
                End If

            End If
        End If

        Dim _Nro_Ot = _Row_Encabezado.Item("Nro_Ot")



        If Fx_Fijar_Estado() Then

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Fijar estado", MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Fijar_Estado = True
            Me.Close()

        End If

        Return

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_St_OT_Doc_Asociados",
                                            "Id_Ot In (Select Id_Ot From " & _Global_BaseBk & "Zw_St_OT_Encabezado Where Nro_Ot = '" & _Nro_Ot & "') " &
                                            "And Idmaeedo = " & _Idmaeedo & " And MovTodasSubOT = 1")

        If _Reg > 1 Then

            MessageBoxEx.Show(Me, "Existente " & _Reg & " Sub-Ot Asociadas a esta cotización" & vbCrLf &
                              "Se fijara el estado para todas", "Fijar estado a todas la Sub-Ot de la OT: " & _Nro_Ot,
                                                                MessageBoxButtons.OK, MessageBoxIcon.Information)

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_DetProd " & vbCrLf &
                   "Where Id_Ot In (Select Id_Ot From " & _Global_BaseBk & "Zw_St_OT_Encabezado Where Nro_Ot = '" & _Nro_Ot & "')"
            Dim _Tbl_SubOt As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
            Dim _SqlQuery = String.Empty

            For Each _Fila As DataRow In _Tbl_SubOt.Rows

                Dim _Id_Ot = _Fila.Item("Id_Ot")

                _SqlQuery += Fx_Fijar_Estado2(_Id_Ot, _Idmaeedo, _Estado, _Estado_Fijar)

            Next

            If Not String.IsNullOrEmpty(_SqlQuery) Then

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery) Then

                    MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Fijar estado", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    _Fijar_Estado = True
                    Me.Close()

                End If

            End If

        Else

            If Fx_Fijar_Estado() Then

                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Fijar estado", MessageBoxButtons.OK, MessageBoxIcon.Information)

                _Fijar_Estado = True
                Me.Close()

            End If

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

        Dim _Idmaeedo = _Fila.Cells("Idmaeedo").Value

        'Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados Where Idmaeedo = " & _Idmaeedo
        'Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        'If _Tbl.Rows.Count > 1 Then

        '    MessageBoxEx.Show(Me, "Existen mas Sub-OT asociadas a esta cotización" & vbCrLf &
        '                      "Se [ACEPTARA] el presupuesto para todas", "Sub-OT asociadas", MessageBoxButtons.OK, MessageBoxIcon.Information)


        'End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados Set Estado = 'A' Where Idmaeedo = " & _Idmaeedo
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Presupuesto marcada como [ACEPTADO] correctamente", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'If MessageBoxEx.Show(Me, "¿Desea Fijar el estado?", "Aceptar y fijar estado", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
        Call Btn_Fijar_Estado_Click(Nothing, Nothing)
        'Else
        'Btn_Agregar_Cotizacion.Enabled = False
        'Sb_Marcar_Grilla()
        'Me.Refresh()
        'End If

    End Sub

    Private Sub Btn_Presupuesto_Rechazado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Presupuesto_Rechazado.Click

        For Each _Row As DataGridViewRow In Grilla.Rows
            _Row.Cells("Seleccionado").Value = False
        Next

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        _Fila.Cells("Estado").Value = "R"
        _Fila.Cells("Estado_D").Value = "RECHAZADO"
        _Fila.Cells("Seleccionado").Value = True

        Dim _Id = _Fila.Cells("Id").Value
        Dim _Idmaeedo = _Fila.Cells("Idmaeedo").Value

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados Where Idmaeedo = " & _Idmaeedo
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If _Tbl.Rows.Count > 1 Then

            MessageBoxEx.Show(Me, "Existen mas Sub-OT asociadas a esta cotización" & vbCrLf &
                              "Se [RECHAZARA] el presupuesto para todas", "Sub-OT asociadas", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If

        'If Fx_Revisar_Documento_Cerrado(_Idmaeedo, False) Then
        Consulta_sql = "Select * From MAEDDO Where IDMAEEDO = " & _Idmaeedo
        Dim _Tbl_Maeddo As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim Cerrar_Doc As New Clas_Cerrar_Documento

        If Cerrar_Doc.Fx_Cerrar_Documento(_Idmaeedo, _Tbl_Maeddo) Then
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados Set Estado = 'R' Where Idmaeedo = " & _Idmaeedo
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Presupuesto marcada como [RECHAZADO] correctamente", "Rechazar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        Btn_Agregar_Cotizacion.Enabled = True
        Btn_EditarPresupuesto.Visible = True
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
            Dim _Tido As String = _Row.Item("TIDO")
            _Tido = _Sql.Fx_Trae_Dato("TABTIDO", "NOTIDO", "TIDO = '" & _Tido & "'")

            If _Idmaeedo <> _Id Then
                If _Estado = "E" Then
                    MessageBoxEx.Show(Me, "HAY OTRA " & _Tido.ToUpper.Trim & " EN EVALUACION." & vbCrLf &
                                      "NO PUEDE TENER MAS DE UN DOCUMENTO EN EVALUACION PARA LA MISMA OT", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                ElseIf _Estado = "A" Then
                    MessageBoxEx.Show(Me, "Hay otra " & _Tido.ToUpper.Trim & " que ya esta aceptada." & vbCrLf &
                                      "NO PUEDE TENER MAS DE UN DOCUMENTO EN EVALUACION PARA LA MISMA OT", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If
            End If

        Next

        Dim _Idmaeedov = _Fila.Cells("Idmaeedo").Value

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados Where Idmaeedo = " & _Idmaeedov
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If _Tbl.Rows.Count > 1 Then

            MessageBoxEx.Show(Me, "Existen mas Sub-OT asociadas a esta cotización" & vbCrLf &
                              "Se dejara como [EVALUACION] el presupuesto para todas", "Sub-OT asociadas", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados Set Estado = 'E' Where Idmaeedo = " & _Idmaeedov
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            MessageBoxEx.Show(Me, "Presupuesto marcada como [En Evaluación..] correctamente", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

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


        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        Dim _Row_Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Maeedo) Then

            Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Else

            MessageBoxEx.Show(Me, "No se encontro el documento", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub Btn_Quitar_documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quitar_documento.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id_Ot = _Fila.Cells("Id_Ot").Value
        Dim _Idmaeedo = _Fila.Cells("Idmaeedo").Value

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados Where Id_Ot = " & _Id_Ot & " And Idmaeedo = " & _Idmaeedo

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
            Grilla.Refresh()
        End If

        Dim _Agregar_COV As Boolean

        If CBool(Grilla.Rows.Count) Then

            For Each _Fl As DataRow In _TblCotizaciones.Rows
                If _Fl.RowState <> DataRowState.Deleted Then
                    Dim _Estado = _Fl.Item("Estado")
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
            MessageBoxEx.Show(Me, "No se puede modificar el estado, ya que existe un estado posterior", "Validación",
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

                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_St_OT_Estados Where Id_Ot = " & _Id_Ot & " And CodEstado = 'C'" & vbCrLf &
                                   "Update " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados Set Estado = 'E',Seleccionado = 0" & vbCrLf &
                                   "Where Id_Ot = " & _Id_Ot & " And Tido = 'COV' And Seleccionado = 1" & vbCrLf &
                                   "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " &
                                   "CodEstado = 'P'" & vbCrLf &
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

    Private Sub Btn_Correo_Outlook_Click(sender As Object, e As EventArgs) Handles Btn_Correo_Outlook.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaeedo As Integer = _Fila.Cells("Idmaeedo").Value

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        Dim _Row_Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Maeedo) Then

            Dim _Koen As String = _Row_Maeedo.Item("ENDO")
            Dim _Suen As String = _Row_Maeedo.Item("SUENDO")
            Dim _Tido As String = _Row_Maeedo.Item("TIDO")
            Dim _Nudo As String = _Row_Maeedo.Item("NUDO")

            Dim _Email_Para As String = _Row_Encabezado.Item("Email_Contacto") 'Trim(_Sql.Fx_Trae_Dato("MAEEN", "EMAIL", "KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'"))

            Dim _Archivo_PDF_Adjunto As String

            Dim _NombreFormato As String

            Dim Fm As New Frm_Seleccionar_Formato(_Tido)

            If CBool(Fm.Tbl_Formatos.Rows.Count) Then
                Fm.ShowDialog(Me)
            End If

            If Fm.Formato_Seleccionado Then

                _NombreFormato = Fm.Row_Formato_Seleccionado.Item("NombreFormato")

                Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Tmp"
                Dim _Doc_Electronico As Boolean = _Row_Maeedo.Item("TIDOELEC")

                Dim _Pdf_Adjunto As New Clas_PDF_Crear_Documento(_Idmaeedo,
                                                                         _Tido,
                                                                         _NombreFormato,
                                                                         _Tido & "-" & _Nudo,
                                                                         _Path, _Tido & "-" & _Nudo, False)
                _Pdf_Adjunto.Sb_Crear_PDF("", False, _Pdf_Adjunto.Pro_Nombre_Archivo)
                Dim _Error_Pdf = _Pdf_Adjunto.Pro_Error

                Dim _Existe_File = System.IO.File.Exists(_Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf")

                If _Existe_File Then

                    _Archivo_PDF_Adjunto = _Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf"

                    Dim _Envio_Occ_Mail As New Class_Outlook

                    Dim _Asunto As String = _Tido & " Nro:" & _Nudo
                    Dim _Para As String = _Email_Para
                    Dim _Cuerpo As String = String.Empty

                    _Envio_Occ_Mail.Sb_Crear_Correo_Outlook(_Para, _Archivo_PDF_Adjunto, _Asunto, _Cuerpo, True)

                End If

            End If

            Fm.Dispose()
        Else

            MessageBoxEx.Show(Me, "No se encontro el documento", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If



    End Sub

    Private Sub Btn_AgregarCOVExistente_Click(sender As Object, e As EventArgs) Handles Btn_AgregarCOVExistente.Click

        Dim _Filtro_Doc As String = Generar_Filtro_IN(_TblCotizaciones, "", "Idmaeedo", False, False, "")

        Dim _RowDocumento As DataRow

        Dim Fm As New Frm_BusquedaDocumento_Filtro(False)
        Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, "COV", "Where TIDO IN ('COV','NVV')")
        Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado

        If _Filtro_Doc <> "()" Then
            Fm.Pro_Sql_Filtro_Otro_Filtro = "And IDMAEEDO not in " & _Filtro_Doc
        End If

        Fm.Pro_Row_Entidad = _RowEntidad
        Fm.ShowDialog(Me)
        _RowDocumento = Fm.Pro_Row_Documento_Seleccionado
        Fm.Dispose()

        If Not (_RowDocumento Is Nothing) Then

            With _RowDocumento

                Dim _Id_Ot = _Row_Encabezado.Item("Id_Ot")
                Dim _Idmaeedo = .Item("IDMAEEDO")
                Dim _Tido = .Item("TIDO")
                Dim _Nudo = .Item("NUDO")
                Dim _Feemdo = .Item("FEEMDO")

                Dim NewFila As DataRow
                NewFila = _TblCotizaciones.NewRow
                With NewFila

                    .Item("Id_Ot") = _Id_Ot
                    .Item("Idmaeedo") = _Idmaeedo
                    .Item("Tido") = _Tido
                    .Item("Nudo") = _Nudo
                    .Item("Estado") = "E"
                    .Item("Estado_D") = "En Evaluación..."
                    .Item("Fecha_Doc") = _Feemdo
                    .Item("Fecha_Asociacion") = FechaDelServidor()
                    .Item("Garantia") = False
                    .Item("Seleccionado") = True
                    .Item("Documento_Externo") = False

                    _TblCotizaciones.Rows.Add(NewFila)

                End With

            End With

            Chk_No_Existe_COV_Ni_NVV.Enabled = False

        Else

            Chk_No_Existe_COV_Ni_NVV.Enabled = True

        End If

        Sb_Marcar_Grilla()

    End Sub

    Private Sub Btn_CrearCOVdesdePresupuesto_Click(sender As Object, e As EventArgs) Handles Btn_CrearCOVdesdePresupuesto.Click

        Dim _Tido As String = "COV"
        Dim _Fecha_Emision As Date = FechaDelServidor()

        Dim _Nro_Ot = _Row_Encabezado.Item("Nro_Ot")

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_St_OT_DetProd",
                                            "Id_Ot In (Select Id_Ot From " & _Global_BaseBk & "Zw_St_OT_Encabezado Where Nro_Ot = '" & _Nro_Ot & "')")

        If Not CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No existen productos asociados al detalle de los presupuestos de la OT para poder genarar una cotización",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Reg = 1

        Dim _COV_Solo_Esta_SubOT As Boolean
        Dim _Id_Ot_Padre As Integer = _Row_Encabezado.Item("Id_Ot_Padre")

        If _Reg = 1 Then
            Consulta_sql = "Select Det.*,Enc.Nro_Ot,Enc.Sub_Ot,Enc.Empresa,Enc.Sucursal,Enc.Bodega,'ODST OT: '+Enc.Nro_Ot+'-'+Enc.Sub_Ot As 'Observa'" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_St_OT_DetProd Det" & vbCrLf &
                           "Left Join " & _Global_BaseBk & "Zw_St_OT_Encabezado Enc On Enc.Id_Ot = Det.Id_Ot" & vbCrLf &
                           "Where Det.Id_Ot = " & _Id_Ot
        Else

            Dim Chk_Genarar_COV_Solo_Esta_SubOT As New Command
            Chk_Genarar_COV_Solo_Esta_SubOT.Checked = False
            Chk_Genarar_COV_Solo_Esta_SubOT.Name = "Chk_Genarar_COV_Solo_Esta_SubOT"
            Chk_Genarar_COV_Solo_Esta_SubOT.Text = "Generar cotización solo con servicios de esta Sub-Ot"

            Dim Chk_Genarar_COV_Todas_Las_OT As New Command
            Chk_Genarar_COV_Todas_Las_OT.Checked = True
            Chk_Genarar_COV_Todas_Las_OT.Name = "Chk_Genarar_COV_Todas_Las_OT"
            Chk_Genarar_COV_Todas_Las_OT.Text = "Generar cotización con todos los servicios" & vbCrLf &
                                                "de todas las Sub-Ot de la OT: " & _Nro_Ot

            Dim _Opciones() As Command = {Chk_Genarar_COV_Solo_Esta_SubOT, Chk_Genarar_COV_Todas_Las_OT}

            Dim _Koen = _RowEntidad.Item("KOEN")
            Dim _Suen = _RowEntidad.Item("SUEN")

            Dim _Info As New TaskDialogInfo("Crear cotización desde presupuesto de Sub-Ot",
                      eTaskDialogIcon.Bulb,
                      "Existen mas SubOt de esta OT con presupuestos",
                      "Confirme su opción",
                      eTaskDialogButton.Ok + eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Default, _Opciones, Nothing, Nothing, Nothing, Nothing)

            Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)


            If _Resultado <> eTaskDialogResult.Ok Then
                Return
            End If

            If Chk_Genarar_COV_Solo_Esta_SubOT.Checked Then

                Consulta_sql = "Select Det.*,Enc.Nro_Ot,Enc.Sub_Ot,Enc.Empresa,Enc.Sucursal,Enc.Bodega,'ODST OT: '+Enc.Nro_Ot+'-'+Enc.Sub_Ot As 'Observa'" & vbCrLf &
               "From " & _Global_BaseBk & "Zw_St_OT_DetProd Det" & vbCrLf &
               "Left Join " & _Global_BaseBk & "Zw_St_OT_Encabezado Enc On Enc.Id_Ot = Det.Id_Ot" & vbCrLf &
               "Where Det.Id_Ot = " & _Id_Ot

                _COV_Solo_Esta_SubOT = True

            End If

            If Chk_Genarar_COV_Todas_Las_OT.Checked Then
                Consulta_sql = "Select Det.*,Enc.Nro_Ot,Enc.Sub_Ot,Enc.Empresa,Enc.Sucursal,Enc.Bodega,'ODST OT: '+Enc.Nro_Ot+'-'+Enc.Sub_Ot As 'Observa'" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_St_OT_DetProd Det" & vbCrLf &
                               "Left Join " & _Global_BaseBk & "Zw_St_OT_Encabezado Enc On Enc.Id_Ot = Det.Id_Ot" & vbCrLf &
                               "Where Det.Id_Ot In (Select Id_Ot From " & _Global_BaseBk & "Zw_St_OT_Encabezado Where Nro_Ot = '" & _Nro_Ot & "')" & vbCrLf &
                               "And Det.Id_Ot Not In (Select Id_Ot From " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados Where Tido = 'COV' And Estado In ('A','E'))"
            End If

        End If

        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Not CBool(_Tbl_Productos.Rows.Count) Then
            MessageBoxEx.Show(Me, "No existen productos o servicios en la Orden para poder hacer la cotización", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Aplicar_Precio_De_Listas As Boolean = False

        Me.Enabled = False

        Dim Fm As New Frm_Formulario_Documento(_Tido,
                                               csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta,
                                               False, True, False, False, False)

        Fm.Pro_RowEntidad = _RowEntidad
        Fm.Sb_Crear_Documento_Interno_Con_Tabla2(Me, _Tbl_Productos, _Fecha_Emision, "Codigo", "Cantidad", "Precio", "", False, _Aplicar_Precio_De_Listas)
        Fm.ShowDialog(Me)
        Dim _New_Idmaeedo = Fm.Pro_Idmaeedo
        Fm.Dispose()

        Me.Enabled = True

        '_New_Idmaeedo = 339727

        If CBool(_New_Idmaeedo) Then

            MessageBoxEx.Show(Me, "Cotización creada correctamente" & vbCrLf & "Se adjuntara a la orden de servicio",
                              "Crear cotización", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If _COV_Solo_Esta_SubOT Then
                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_DetProd " & vbCrLf &
                               "Where Id_Ot = " & _Id_Ot
            Else
                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_DetProd " & vbCrLf &
                               "Where Id_Ot In (Select Id_Ot From " & _Global_BaseBk & "Zw_St_OT_Encabezado Where Nro_Ot = '" & _Nro_Ot & "')"
            End If


            Dim _Tbl_SubOt As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
            Dim _SqlQuery = String.Empty

            For Each _Fila As DataRow In _Tbl_SubOt.Rows

                Dim _Id_Ot = _Fila.Item("Id_Ot")

                _SqlQuery += Fx_Fijar_Estado2(_Id_Ot, _New_Idmaeedo, "E", _Estado_Fijar.Evaluacion)

            Next

            If Not String.IsNullOrEmpty(_SqlQuery) Then

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery) Then

                    MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Fijar estado", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    _Fijar_Estado = True
                    Me.Close()

                End If

            End If

        End If

    End Sub

    Private Sub Btn_EditarPresupuesto_Click(sender As Object, e As EventArgs) Handles Btn_EditarPresupuesto.Click

        'Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        'Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        'Dim _Id = _Fila.Cells("Idmaeedo").Value

        For Each _Row As DataRow In _TblCotizaciones.Rows

            Dim _Idmaeedo = _Row.Item("Idmaeedo")
            Dim _Estado = _Row.Item("Estado")
            Dim _Tido As String = _Row.Item("TIDO")
            _Tido = _Sql.Fx_Trae_Dato("TABTIDO", "NOTIDO", "TIDO = '" & _Tido & "'")

            If _Estado = "E" Then
                MessageBoxEx.Show(Me, "HAY OTRA " & _Tido.ToUpper.Trim & " EN EVALUACION." & vbCrLf &
                                  "NO PUEDE EDITAR EL PRESUPUESTO, DEBE RECHAZAR LA COTIZACION ANTERIOR PARA PODER HACER ESTA GESTION", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            ElseIf _Estado = "A" Then
                MessageBoxEx.Show(Me, "Hay otra " & _Tido.ToUpper.Trim & " que ya esta aceptada." & vbCrLf &
                          "NO PUEDE EDITAR EL PRESUPUESTO, DEBE RECHAZAR LA COTIZACION ANTERIOR PARA PODER HACER ESTA GESTION", "Validación",
                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        Next

        Dim Fm0 As New Frm_St_Estado_03_Presupuesto2(_Id_Ot, Frm_St_Estado_03_Presupuesto.Accion.Editar)
        Fm0.Pro_DsDocumento = _DsDocumento
        Fm0.ShowDialog(Me)
        If Fm0.Pro_Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm0.Dispose()

    End Sub

End Class
