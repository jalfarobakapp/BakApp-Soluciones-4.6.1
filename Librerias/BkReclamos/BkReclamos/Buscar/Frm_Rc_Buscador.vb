Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
Public Class Frm_Rc_Buscador

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cl_Buscar As New Cl_Buscar_Reclamo

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Numero.FocusHighlightEnabled = False
            Btn_Filtrar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Rc_Buscador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Rdb_Numero_Uno.Checked = True
        Me.ActiveControl = Txt_Numero

        Dtp_Fecha_Emision_Desde.Value = Primerdiadelmes(FechaDelServidor)
        Dtp_Fecha_Emision_Hasta.Value = FechaDelServidor()

        Dtp_Fecha_Cierre_Desde.Value = Primerdiadelmes(FechaDelServidor)
        Dtp_Fecha_Cierre_Hasta.Value = FechaDelServidor()

    End Sub

    Private Sub Sb_Habilitar_Etiquetas()

        Lbl_FE_desde.Enabled = Rdb_Fecha_Emision_Rango.Checked
        Lbl_FE_hasta.Enabled = Rdb_Fecha_Emision_Rango.Checked
        Dtp_Fecha_Emision_Desde.Enabled = Rdb_Fecha_Emision_Rango.Checked
        Dtp_Fecha_Emision_Hasta.Enabled = Rdb_Fecha_Emision_Rango.Checked

        Lbl_FC_desde.Enabled = Rdb_Fecha_Cierre_Rango.Checked
        Lbl_FC_hasta.Enabled = Rdb_Fecha_Cierre_Rango.Checked
        Dtp_Fecha_Cierre_Desde.Enabled = Rdb_Fecha_Cierre_Rango.Checked
        Dtp_Fecha_Cierre_Hasta.Enabled = Rdb_Fecha_Cierre_Rango.Checked

        Txt_Numero.Enabled = Rdb_Numero_Uno.Checked

        Grupo_Otros_Filtros.Enabled = Rdb_Numero_Todos.Checked
        Grupo_Fechas.Enabled = Rdb_Numero_Todos.Checked

        If Rdb_Numero_Todos.Checked Then
            Txt_Numero.Text = String.Empty
        End If

    End Sub

    Private Sub Rdb_Numero_Uno_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Numero_Uno.CheckedChanged
        Sb_Habilitar_Etiquetas()
        If Rdb_Numero_Uno.Checked Then
            Txt_Numero.Focus()
        End If
    End Sub

    Private Sub Rdb_Entidades_Algunas_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Entidades_Algunas.CheckedChanged

        If Rdb_Entidades_Algunas.Checked Then

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            If _Filtrar.Fx_Filtrar(_Cl_Buscar.Tbl_Entidad,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Entidades, "",
                               False, False) Then

                _Cl_Buscar.Tbl_Entidad = _Filtrar.Pro_Tbl_Filtro
                If _Filtrar.Pro_Filtro_Todas Then
                    Rdb_Entidades_Todas.Checked = True
                    _Cl_Buscar.Tbl_Entidad = Nothing
                End If

            End If

        End If

    End Sub

    Private Sub Rdb_Producto_Algunos_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Producto_Algunos.CheckedChanged

        If Rdb_Producto_Algunos.Checked Then

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            If _Filtrar.Fx_Filtrar(_Cl_Buscar.Tbl_Producto,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, "",
                               False, False) Then

                _Cl_Buscar.Tbl_Producto = _Filtrar.Pro_Tbl_Filtro
                If _Filtrar.Pro_Filtro_Todas Then
                    Rdb_Producto_Todos.Checked = True
                    _Cl_Buscar.Tbl_Producto = Nothing
                End If

            End If

        End If

    End Sub

    Private Sub Rdb_Vendedor_Algunos_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Vendedor_Algunos.CheckedChanged

        If Rdb_Vendedor_Algunos.Checked Then

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            If _Filtrar.Fx_Filtrar(_Cl_Buscar.Tbl_Vendedor,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, "",
                               False, False) Then

                _Cl_Buscar.Tbl_Vendedor = _Filtrar.Pro_Tbl_Filtro
                If _Filtrar.Pro_Filtro_Todas Then
                    Rdb_Vendedor_Todos.Checked = True
                    _Cl_Buscar.Tbl_Vendedor = Nothing
                End If

            End If

        End If

    End Sub

    Private Sub Rdb_Suc_Elaboracion_Algunas_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Suc_Elaboracion_Algunas.CheckedChanged

        If Rdb_Suc_Elaboracion_Algunas.Checked Then

            Dim _Filtrar As New Clas_Filtros_Random(Me)

            If _Filtrar.Fx_Filtrar(_Cl_Buscar.Tbl_Suc_Elaboracion,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Sucursales, "",
                               False, False) Then

                _Cl_Buscar.Tbl_Suc_Elaboracion = _Filtrar.Pro_Tbl_Filtro
                If _Filtrar.Pro_Filtro_Todas Then
                    Rdb_Suc_Elaboracion_Todas.Checked = True
                    _Cl_Buscar.Tbl_Suc_Elaboracion = Nothing
                End If

            End If

        End If

    End Sub

    Private Sub Rdb_Estado_Algunos_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Estado_Algunos.CheckedChanged

        If Rdb_Estado_Algunos.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Otra)
            Fm.Pro_Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
            Fm.Pro_Campo = "CodigoTabla"
            Fm.Pro_Descripcion = "NombreTabla"
            Fm.Pro_Tbl_Filtro = _Cl_Buscar.Tbl_Estado
            Fm.Text = "ESTADOS"
            Fm.Pro_Sql_Filtro_Condicion_Extra = "And (Tabla = 'SIS_RECLAMOS_ESTADO')" & vbCrLf
            Fm.Pro_Orden_By = "ORDER BY Orden"
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _Cl_Buscar.Tbl_Estado = Fm.Pro_Tbl_Filtro
                If (_Cl_Buscar.Tbl_Estado Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Estado_Todos.Checked = True
                End If
            Else
                Rdb_Estado_Todos.Checked = True
            End If

        End If

    End Sub

    Private Sub Rdb_Sub_Estado_Algunos_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Sub_Estado_Algunos.CheckedChanged

        If Rdb_Sub_Estado_Algunos.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Otra)
            Fm.Pro_Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
            Fm.Pro_Campo = "CodigoTabla"
            Fm.Pro_Descripcion = "NombreTabla"
            Fm.Pro_Tbl_Filtro = _Cl_Buscar.Tbl_Sub_Estado
            Fm.Text = "SUB-ESTADOS"
            Fm.Pro_Sql_Filtro_Condicion_Extra = "And (Tabla = 'SIS_RECLAMOS_SUBESTADO')" & vbCrLf
            Fm.Pro_Orden_By = "ORDER BY Orden"
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _Cl_Buscar.Tbl_Sub_Estado = Fm.Pro_Tbl_Filtro
                If (_Cl_Buscar.Tbl_Sub_Estado Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Sub_Estado_Todos.Checked = True
                End If
            Else
                Rdb_Sub_Estado_Todos.Checked = True
            End If

        End If

    End Sub

    Private Sub Rdb_Accion_Algunos_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Accion_Algunos.CheckedChanged

        If Rdb_Accion_Algunos.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Otra)
            Fm.Pro_Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
            Fm.Pro_Campo = "CodigoTabla"
            Fm.Pro_Descripcion = "NombreTabla"
            Fm.Pro_Tbl_Filtro = _Cl_Buscar.Tbl_Accion
            Fm.Text = "ACCION"
            Fm.Pro_Sql_Filtro_Condicion_Extra = "And (Tabla = 'SIS_RECLAMOS_ACCION')" & vbCrLf
            Fm.Pro_Orden_By = "ORDER BY Orden"
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _Cl_Buscar.Tbl_Accion = Fm.Pro_Tbl_Filtro
                If (_Cl_Buscar.Tbl_Accion Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Accion_Todas.Checked = True
                End If
            Else
                Rdb_Accion_Todas.Checked = True
            End If

        End If

    End Sub

    Private Sub Rdb_Tipo_Algunos_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Tipo_Algunos.CheckedChanged

        If Rdb_Tipo_Algunos.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Otra)
            Fm.Pro_Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
            Fm.Pro_Campo = "CodigoTabla"
            Fm.Pro_Descripcion = "NombreTabla"
            Fm.Pro_Tbl_Filtro = _Cl_Buscar.Tbl_Tipo_Reclamo
            Fm.Text = "TIPO DE RECLAMO"
            Fm.Pro_Sql_Filtro_Condicion_Extra = "And (Tabla = 'SIS_RECLAMOS_TIPO')" & vbCrLf
            Fm.Pro_Orden_By = "ORDER BY Orden"
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _Cl_Buscar.Tbl_Tipo_Reclamo = Fm.Pro_Tbl_Filtro
                If (_Cl_Buscar.Tbl_Tipo_Reclamo Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Tipo_Todos.Checked = True
                End If
            Else
                Rdb_Tipo_Todos.Checked = True
            End If

        End If

    End Sub

    Private Sub Rdb_Sub_Tipo_Algunos_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Sub_Tipo_Algunos.CheckedChanged

        If Rdb_Tipo_Algunos.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Otra)
            Fm.Pro_Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
            Fm.Pro_Campo = "CodigoTabla"
            Fm.Pro_Descripcion = "NombreTabla"
            Fm.Pro_Tbl_Filtro = _Cl_Buscar.Tbl_Sub_Tipo_Reclamo
            Fm.Text = "SUB-TIPO DE RECLAMO"
            Fm.Pro_Sql_Filtro_Condicion_Extra = "And Tabla = 'SIS_RECLAMOS_SUBTIPO' And Padre_Tabla = 'SIS_RECLAMOS_TIPO'" & vbCrLf
            Fm.Pro_Orden_By = "ORDER BY Orden"
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _Cl_Buscar.Tbl_Sub_Tipo_Reclamo = Fm.Pro_Tbl_Filtro
                If (_Cl_Buscar.Tbl_Sub_Tipo_Reclamo Is Nothing) Or Fm.Pro_Filtrar_Todo Then
                    Rdb_Sub_Tipo_Todos.Checked = True
                End If
            Else
                Rdb_Sub_Tipo_Todos.Checked = True
            End If

        End If

    End Sub

    Private Sub Btn_Filtrar_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar.Click
        Sb_Filtrar()
    End Sub

    Private Sub Txt_Numero_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Numero.KeyDown
        If e.KeyValue = Keys.Enter Then
            Txt_Numero.Text = Fx_Rellena_ceros(Txt_Numero.Text, 10)
            Sb_Filtrar()
        End If
    End Sub

    Sub Sb_Filtrar()

        Dim _Filtro_Numero = String.Empty
        Dim _Filtro_Entidades = String.Empty
        Dim _Filtro_Productos = String.Empty
        Dim _Filtro_Vendedor = String.Empty
        Dim _Filtro_Sucursal_Elaboracion = String.Empty
        Dim _Filtro_Estado = String.Empty
        Dim _Filtro_Sub_Estado = String.Empty
        Dim _Filtro_Accion = String.Empty
        Dim _Filtro_Tipo = String.Empty
        Dim _Filtro_Sub_Tipo = String.Empty
        Dim _Filtro_Fecha_Emision = String.Empty
        Dim _Filtro_Fecha_Cierre = String.Empty

        If Rdb_Numero_Uno.Checked Then
            If String.IsNullOrEmpty(Trim(Txt_Numero.Text)) Then
                Beep()
                ToastNotification.Show(Me, "NUMERO NO PUEDE ESTAR VACIO", Imagenes_32x32.Images.Item("Warning 32 Yellow.png"),
                                           1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Txt_Numero.Focus()
                Return
            End If
        End If

        Txt_Numero.Tag = Val(Txt_Numero.Text)
        Dim _Filtro_SQl As String

        If Rdb_Numero_Uno.Checked Then
            Txt_Numero.Text = Fx_Rellena_ceros(Txt_Numero.Tag, 10)
            _Filtro_Numero = "And Numero = '" & Txt_Numero.Text & "'" & vbCrLf
        End If

        If Rdb_Numero_Todos.Checked Then

            If Rdb_Entidades_Algunas.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_Cl_Buscar.Tbl_Entidad, "Chk", "Codigo", False, True, "'")
                _Filtro_Entidades = "And CodEntidad in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Producto_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_Cl_Buscar.Tbl_Producto, "Chk", "Codigo", False, True, "'")
                _Filtro_Productos = "And Codigo in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Vendedor_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_Cl_Buscar.Tbl_Vendedor, "Chk", "Codigo", False, True, "'")
                _Filtro_Vendedor = "And Cod_Vendedor in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Suc_Elaboracion_Algunas.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_Cl_Buscar.Tbl_Suc_Elaboracion, "Chk", "Codigo", False, True, "'")
                _Filtro_Sucursal_Elaboracion = "And Suc_Elaboracion in " & _Filtro_SQl & vbCrLf
            End If

            ' MAQUINAS
            If Rdb_Estado_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_Cl_Buscar.Tbl_Estado, "Chk", "Codigo", False, True, "'")
                _Filtro_Estado = "And Estado in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Sub_Estado_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_Cl_Buscar.Tbl_Sub_Estado, "Chk", "Codigo", False, True, "'")
                _Filtro_Sub_Estado = "And Sub_Estado in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Accion_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_Cl_Buscar.Tbl_Accion, "Chk", "Codigo", False, True, "'")
                _Filtro_Accion = "And Codigo_Accion in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Tipo_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_Cl_Buscar.Tbl_Tipo_Reclamo, "Chk", "Codigo", False, True, "'")
                _Filtro_Tipo = "And Tipo_Reclamo in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Sub_Tipo_Algunos.Checked Then
                _Filtro_SQl = Generar_Filtro_IN(_Cl_Buscar.Tbl_Sub_Tipo_Reclamo, "Chk", "Codigo", False, True, "'")
                _Filtro_Tipo = "And Sub_Tipo_Reclamo in " & _Filtro_SQl & vbCrLf
            End If

            If Rdb_Fecha_Emision_Rango.Checked Then

                Dim Dia_1 As String = numero_(Dtp_Fecha_Emision_Desde.Value.Day, 2)
                Dim Mes_1 As String = numero_(Dtp_Fecha_Emision_Desde.Value.Month, 2)
                Dim Ano_1 As String = Dtp_Fecha_Emision_Desde.Value.Year

                Dim Dia_2 As String = numero_(Dtp_Fecha_Emision_Hasta.Value.Day, 2)
                Dim Mes_2 As String = numero_(Dtp_Fecha_Emision_Hasta.Value.Month, 2)
                Dim Ano_2 As String = Dtp_Fecha_Emision_Hasta.Value.Year

                _Filtro_Fecha_Emision = "And (Fecha_Emision BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                                        "And CONVERT(DATETIME, '" & Ano_2 & "-" & Mes_2 & "-" & Dia_2 & " 23:59:59', 102))" & vbCrLf


            End If

            If Rdb_Fecha_Cierre_Rango.Checked Then

                Dim Dia_1 As String = numero_(Dtp_Fecha_Cierre_Desde.Value.Day, 2)
                Dim Mes_1 As String = numero_(Dtp_Fecha_Cierre_Desde.Value.Month, 2)
                Dim Ano_1 As String = Dtp_Fecha_Cierre_Desde.Value.Year

                Dim Dia_2 As String = numero_(Dtp_Fecha_Cierre_Hasta.Value.Day, 2)
                Dim Mes_2 As String = numero_(Dtp_Fecha_Cierre_Hasta.Value.Month, 2)
                Dim Ano_2 As String = Dtp_Fecha_Cierre_Hasta.Value.Year

                _Filtro_Fecha_Cierre = "And (Fecha_Cierre BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                                        "And CONVERT(DATETIME, '" & Ano_2 & "-" & Mes_2 & "-" & Dia_2 & " 23:59:59', 102))" & vbCrLf


            End If

        End If

        _Filtro_SQl = _Filtro_Numero &
                      _Filtro_Entidades &
                      _Filtro_Productos &
                      _Filtro_Vendedor &
                      _Filtro_Sucursal_Elaboracion &
                      _Filtro_Estado &
                      _Filtro_Sub_Estado &
                      _Filtro_Accion &
                      _Filtro_Tipo &
                      _Filtro_Sub_Tipo &
                      _Filtro_Fecha_Emision &
                      _Filtro_Fecha_Cierre

        Dim _Tbl_Informe As DataTable

        Dim Fm As New Frm_Rc_Lista_Reclamos(Cl_Reclamo.Enum_Estados.Todos)
        Fm.Pro_Filtro_Externo = _Filtro_SQl
        Fm.Sb_Actualizar_Grilla()
        Fm.Btn_Crear_OT.Visible = False
        Fm.Btn_Buscar_Reclamo.Visible = False
        Fm.BtnActualizar.Visible = False
        _Tbl_Informe = Fm.Pro_Tbl_Reclamos


        If CBool(_Tbl_Informe.Rows.Count) Then

            Dim _Mostrar As Boolean

            If _Tbl_Informe.Rows.Count <= 20 Then
                _Mostrar = True
            Else

                If MessageBoxEx.Show(Me, _Tbl_Informe.Rows.Count & " registros encontrados" & vbCrLf & vbCrLf &
                                                "¿Desea ver la información?", "Filtrar",
                                              MessageBoxButtons.OKCancel,
                                              MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                    _Mostrar = True
                End If

            End If

            If _Mostrar Then
                Fm.ShowDialog(Me)
            End If

        Else
            Beep()
            ToastNotification.Show(Me, "NO EXISEN DATOS QUE MOSTRAR", Imagenes_32x32.Images.Item("multiply_filled_32px_Red.png"),
                                       1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            _Tbl_Informe = Nothing
        End If

        Fm.Dispose()

    End Sub

End Class