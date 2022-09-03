Imports DevComponents.DotNetBar

Public Class Frm_Cadenas_Remotas_Buscador


    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Cadenas_Remotas_Buscador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Buscar_Click(sender As Object, e As EventArgs) Handles Btn_Buscar.Click

    End Sub

    'Sub Sb_Filtrar()

    '    Dim _Filtro_Numero = String.Empty
    '    Dim _Filtro_Entidades = String.Empty
    '    Dim _Filtro_Productos = String.Empty
    '    Dim _Filtro_Vendedor = String.Empty
    '    Dim _Filtro_Sucursal_Elaboracion = String.Empty
    '    Dim _Filtro_Estado = String.Empty
    '    Dim _Filtro_Sub_Estado = String.Empty
    '    Dim _Filtro_Accion = String.Empty
    '    Dim _Filtro_Tipo = String.Empty
    '    Dim _Filtro_Sub_Tipo = String.Empty
    '    Dim _Filtro_Fecha_Emision = String.Empty
    '    Dim _Filtro_Fecha_Cierre = String.Empty

    '    If Rdb_Numero_Uno.Checked Then
    '        If String.IsNullOrEmpty(Trim(Txt_Numero.Text)) Then
    '            Beep()
    '            ToastNotification.Show(Me, "NUMERO NO PUEDE ESTAR VACIO", Imagenes_32x32.Images.Item("Warning 32 Yellow.png"),
    '                                       1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
    '            Txt_Numero.Focus()
    '            Return
    '        End If
    '    End If

    '    Txt_Numero.Tag = Val(Txt_Numero.Text)
    '    Dim _Filtro_SQl As String

    '    If Rdb_Numero_Uno.Checked Then
    '        Txt_Numero.Text = Fx_Rellena_ceros(Txt_Numero.Tag, 10)
    '        _Filtro_Numero = "And Numero = '" & Txt_Numero.Text & "'" & vbCrLf
    '    End If

    '    If Rdb_Numero_Todos.Checked Then

    '        If Rdb_Entidades_Algunas.Checked Then
    '            _Filtro_SQl = Generar_Filtro_IN(_Cl_Buscar.Tbl_Entidad, "Chk", "Codigo", False, True, "'")
    '            _Filtro_Entidades = "And CodEntidad in " & _Filtro_SQl & vbCrLf
    '        End If

    '        If Rdb_Producto_Algunos.Checked Then
    '            _Filtro_SQl = Generar_Filtro_IN(_Cl_Buscar.Tbl_Producto, "Chk", "Codigo", False, True, "'")
    '            _Filtro_Productos = "And Codigo in " & _Filtro_SQl & vbCrLf
    '        End If

    '        If Rdb_Vendedor_Algunos.Checked Then
    '            _Filtro_SQl = Generar_Filtro_IN(_Cl_Buscar.Tbl_Vendedor, "Chk", "Codigo", False, True, "'")
    '            _Filtro_Vendedor = "And Cod_Vendedor in " & _Filtro_SQl & vbCrLf
    '        End If


    '        If Rdb_Fecha_Emision_Rango.Checked Then

    '            Dim Dia_1 As String = numero_(Dtp_Fecha_Emision_Desde.Value.Day, 2)
    '            Dim Mes_1 As String = numero_(Dtp_Fecha_Emision_Desde.Value.Month, 2)
    '            Dim Ano_1 As String = Dtp_Fecha_Emision_Desde.Value.Year

    '            Dim Dia_2 As String = numero_(Dtp_Fecha_Emision_Hasta.Value.Day, 2)
    '            Dim Mes_2 As String = numero_(Dtp_Fecha_Emision_Hasta.Value.Month, 2)
    '            Dim Ano_2 As String = Dtp_Fecha_Emision_Hasta.Value.Year

    '            _Filtro_Fecha_Emision = "And (Fecha_Emision BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
    '                                    "And CONVERT(DATETIME, '" & Ano_2 & "-" & Mes_2 & "-" & Dia_2 & " 23:59:59', 102))" & vbCrLf


    '        End If

    '        If Rdb_Fecha_Cierre_Rango.Checked Then

    '            Dim Dia_1 As String = numero_(Dtp_Fecha_Cierre_Desde.Value.Day, 2)
    '            Dim Mes_1 As String = numero_(Dtp_Fecha_Cierre_Desde.Value.Month, 2)
    '            Dim Ano_1 As String = Dtp_Fecha_Cierre_Desde.Value.Year

    '            Dim Dia_2 As String = numero_(Dtp_Fecha_Cierre_Hasta.Value.Day, 2)
    '            Dim Mes_2 As String = numero_(Dtp_Fecha_Cierre_Hasta.Value.Month, 2)
    '            Dim Ano_2 As String = Dtp_Fecha_Cierre_Hasta.Value.Year

    '            _Filtro_Fecha_Cierre = "And (Fecha_Cierre BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
    '                                    "And CONVERT(DATETIME, '" & Ano_2 & "-" & Mes_2 & "-" & Dia_2 & " 23:59:59', 102))" & vbCrLf


    '        End If

    '    End If

    '    _Filtro_SQl = _Filtro_Numero &
    '                  _Filtro_Entidades &
    '                  _Filtro_Productos &
    '                  _Filtro_Vendedor &
    '                  _Filtro_Sucursal_Elaboracion &
    '                  _Filtro_Estado &
    '                  _Filtro_Sub_Estado &
    '                  _Filtro_Accion &
    '                  _Filtro_Tipo &
    '                  _Filtro_Sub_Tipo &
    '                  _Filtro_Fecha_Emision &
    '                  _Filtro_Fecha_Cierre

    '    Dim _Tbl_Informe As DataTable

    '    Dim Fm As New Frm_Rc_Lista_Reclamos(Cl_Reclamo.Enum_Estados.Todos)
    '    Fm.Pro_Filtro_Externo = _Filtro_SQl
    '    Fm.Sb_Actualizar_Grilla()
    '    Fm.Btn_Crear_OT.Visible = False
    '    Fm.Btn_Buscar_Reclamo.Visible = False
    '    Fm.BtnActualizar.Visible = False
    '    _Tbl_Informe = Fm.Pro_Tbl_Reclamos


    '    If CBool(_Tbl_Informe.Rows.Count) Then

    '        Dim _Mostrar As Boolean

    '        If _Tbl_Informe.Rows.Count <= 20 Then
    '            _Mostrar = True
    '        Else

    '            If MessageBoxEx.Show(Me, _Tbl_Informe.Rows.Count & " registros encontrados" & vbCrLf & vbCrLf &
    '                                            "¿Desea ver la información?", "Filtrar",
    '                                          MessageBoxButtons.OKCancel,
    '                                          MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
    '                _Mostrar = True
    '            End If

    '        End If

    '        If _Mostrar Then
    '            Fm.ShowDialog(Me)
    '        End If

    '    Else
    '        Beep()
    '        ToastNotification.Show(Me, "NO EXISEN DATOS QUE MOSTRAR", Imagenes_32x32.Images.Item("multiply_filled_32px_Red.png"),
    '                                   1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
    '        _Tbl_Informe = Nothing
    '    End If

    '    Fm.Dispose()

    'End Sub

End Class