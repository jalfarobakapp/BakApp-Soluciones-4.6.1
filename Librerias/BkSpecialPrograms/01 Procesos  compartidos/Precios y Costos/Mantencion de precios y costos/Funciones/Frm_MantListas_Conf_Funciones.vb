Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_MantListas_Conf_Funciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Formula, _Texto_Original As String
    Dim _Grabar As Boolean
    Dim _CodLista As String
    Dim _Lista_En_Neto As Boolean


    Public ReadOnly Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
    End Property
    Public ReadOnly Property Pro_Formula() As String
        Get
            Return Trim(Txt_Formula_Fx.Text)
        End Get
    End Property

    Public Sub New(ByVal New_Formula As String,
                   ByVal New_Chk_Aplica_FX_Documento As Boolean,
                   ByVal Lista_En_Neto As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        _Formula = New_Formula
        Chk_Aplica_FX_Documento.Checked = New_Chk_Aplica_FX_Documento

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Lista_En_Neto = Lista_En_Neto

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_MantListas_Conf_Funciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = "Edición de formula" 'Texto

        Dim _Fx = Split(_Formula, "#")

        Txt_Formula_Fx.Text = Trim(_Fx(0)) '_Sql.Fx_Trae_Dato(, Campo, Tabla, Condicion)
        _Texto_Original = _Formula

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8.5), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Consulta_sql = "Select * From PNOMDIM Where DEPENDENCI In ('Por_maepr','Por_tabpp','Valor_docud','Valor_docue','Valor_propio','Por_maepr','Por_producto') "
        Dim _Tbl_Campos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Campos

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("CODIGO").Width = 100
            .Columns("CODIGO").HeaderText = "Código Variable"
            .Columns("CODIGO").Visible = True

            .Columns("NOMBRE").Width = 300
            .Columns("NOMBRE").HeaderText = "Descripción"
            .Columns("NOMBRE").Visible = True

            .Columns("DEPENDENCI").Width = 90
            .Columns("DEPENDENCI").HeaderText = "Dependencia"
            .Columns("DEPENDENCI").Visible = True

            .Columns("VALOR").Width = 80
            .Columns("VALOR").HeaderText = "Valor propio"
            .Columns("VALOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VALOR").DefaultCellStyle.Format = "###,##.##"
            .Columns("VALOR").Visible = True

        End With

        Txt_Formula_Fx.Select(Txt_Formula_Fx.TextLength, 0)

    End Sub

    Function Fx_Crear_Tabla_Campos_Funciones()

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Codigo", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Descripcion", System.Type.[GetType]("System.String"))

        ',,,,,,

        dr = dt.NewRow() : dr("Codigo") = "RLUD" : dr("Descripcion") = "Razón de transformación" : dt.Rows.Add(dr)
        'dr = dt.NewRow() : dr("Codigo") = "Flete" : dr("Descripcion") = "Valor flete" : dt.Rows.Add(dr)
        'dr = dt.NewRow() : dr("Codigo") = "Ila" : dr("Descripcion") = "Porcentaje de Ila del producto" : dt.Rows.Add(dr)
        'dr = dt.NewRow() : dr("Codigo") = "Iva" : dr("Descripcion") = "Porcentaje de Iva del producto" : dt.Rows.Add(dr)
        'dr = dt.NewRow() : dr("Codigo") = "Costo" : dr("Descripcion") = "Costo Ud1" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "PM" : dr("Descripcion") = "Precio promedio ponderado" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "PPUL01" : dr("Descripcion") = "Precio última compra 1ra unidad" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "PPUL02" : dr("Descripcion") = "Precio última compra 2da unidad" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "MG01UD" : dr("Descripcion") = "Margen Ud1" : dt.Rows.Add(dr)
        'dr = dt.NewRow() : dr("Codigo") = "MG01UD" : dr("Descripcion") = "Margen adicional Ud1" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Codigo") = "MG02UD" : dr("Descripcion") = "Margen Ud2" : dt.Rows.Add(dr)
        'dr = dt.NewRow() : dr("Codigo") = "Margen_Adicional2" : dr("Descripcion") = "Margen adicional Ud2" : dt.Rows.Add(dr)

        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset

        rs.Tables.Add(dt)

        Return dt

    End Function

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Trim(Txt_Formula_Fx.Text)) Then

            _Grabar = True
            Me.Close()

        Else

            If Fx_Revisar_Formula() Then

                Dim Fm As New Frm_MantListas_Redondeo(_Lista_En_Neto)
                Fm.ShowDialog(Me)

                If Fm.Pro_Seleccionar Then

                    Dim _Formula As String = Trim(Txt_Formula_Fx.Text)
                    Txt_Formula_Fx.Text = _Formula & "#" & Fm.Pro_Redondeo

                    _Grabar = True
                    Me.Close()
                Else
                    Txt_Formula_Fx.Focus()
                End If

                Fm.Dispose()

            End If

        End If

    End Sub

    Private Sub Frm_MantListas_Conf_Funciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Probar_Funcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Probar_Funcion.Click
        Fx_Revisar_Formula(True)
    End Sub

    Function Fx_Revisar_Formula(Optional ByVal _Mostrar_error As Boolean = False)

        Dim _Fx As String = UCase(Txt_Formula_Fx.Text)
        Dim _Ecuacion As String = Txt_Formula_Fx.Text

        Try

            Consulta_sql = "Select COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS Where TABLE_NAME = 'TABPRE'"
            Dim _Tbl_Campos_Tabpre As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            For Each _FColumnas As DataRow In _Tbl_Campos_Tabpre.Rows

                Dim _Columna As String = _FColumnas.Item("COLUMN_NAME").ToString.Trim
                _Fx = Replace(_Fx, _Columna, 1 & " ")

            Next

            Consulta_sql = "Select CODIGO From PNOMDIM Where DEPENDENCI In ('Por_maepr','Por_tabpp','Valor_docud','Valor_docue','Valor_propio','Por_maepr','Por_producto') "
            Dim _Tbl_Campos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            For Each _FColumnas As DataRow In _Tbl_Campos.Rows

                Dim _Columna As String = _FColumnas.Item("CODIGO").ToString.Trim
                _Fx = Replace(_Fx, _Columna, 1 & " ")

            Next

            '_Fx = Replace(_Fx, "RLUD", 1 & " ")
            '_Fx = Replace(_Fx, "PM", 1 & " ")
            '_Fx = Replace(_Fx, "PP01UD", 1 & " ")
            '_Fx = Replace(_Fx, "PP02UD", 1 & " ")
            '_Fx = Replace(_Fx, "PPUL01", 1 & " ")
            '_Fx = Replace(_Fx, "PPUL02", 1 & " ")
            '_Fx = Replace(_Fx, "MG01UD", 1 & " ")
            '_Fx = Replace(_Fx, "MG02UD", 1 & " ")
            '_Fx = Replace(_Fx, "CAPRCO1", 1 & " ")
            '_Fx = Replace(_Fx, "CAPRCO2", 1 & " ")

            _Fx = Replace(_Fx, "<", "")
            _Fx = Replace(_Fx, ">", "")

            If _Fx.Contains("--") Then
                _Fx = _Ecuacion
                Throw New System.Exception(vbCrLf & vbCrLf & "No puede poner mas de un '-'")
            End If

            Dim _Tiene_Cor As Boolean = InStr(1, _Ecuacion, "[")

            If _Tiene_Cor Then

                If _Fx.Contains("-[") Then
                    _Fx = _Ecuacion
                    Throw New System.Exception(vbCrLf & vbCrLf & "Esto no esta permitido -> '-['")
                End If

                If _Fx.Contains("]-") Then
                    _Fx = _Ecuacion
                    Throw New System.Exception(vbCrLf & vbCrLf & "Esto no esta permitido -> ']-'")
                End If

                Dim _Corchete1 = Split(_Ecuacion, "[")
                Dim _Corchete2 = Split(_Ecuacion, "]")
                Dim _Corchete3 = Split(_Ecuacion, "][")

                If _Corchete1.Length > _Corchete2.Length Then
                    Throw New System.Exception(vbCrLf & vbCrLf & "Falta un cierre de corchetes")
                End If

                If _Corchete1.Length < _Corchete2.Length Then
                    Throw New System.Exception(vbCrLf & vbCrLf & "Falta una apertura de corchetes")
                End If

                Dim _Ecuacion_Copy = Replace(_Ecuacion, "]", "")
                Dim _Ecuacion_1 = Split(_Ecuacion_Copy, "#")
                Dim _Ecuacion_2 = Split(_Ecuacion_1(0), "[")

                Dim _Ecuacion_Ok = True

                If Not String.IsNullOrEmpty(_Ecuacion_2(0).Trim) Then
                    _Fx = _Ecuacion
                    Throw New System.Exception(vbCrLf & vbCrLf & "Error cerca de " & _Ecuacion_2(0).Trim)
                End If

                If Not String.IsNullOrEmpty(_Corchete2(_Corchete2.Length - 1).Trim) Then
                    _Fx = _Ecuacion
                    Throw New System.Exception(vbCrLf & vbCrLf & "Error cerca de " & _Corchete2(_Corchete2.Length - 1).Trim)
                End If

                If _Corchete3.Length <> _Ecuacion_2.Length - 1 Then
                    Throw New System.Exception(vbCrLf & vbCrLf & "Error en un cierre y apertura de corchetes")
                End If

                For i = 1 To _Ecuacion_2.Length - 1

                    Dim _Ecuacion_3

                    Try
                        _Ecuacion_3 = Split(_Ecuacion_2(i), ",")
                    Catch ex As Exception
                        Exit For
                    End Try

                    Dim _Cant1_Ecu As Double = _Ecuacion_3(0)
                    Dim _Cant2_Ecu As Double = _Ecuacion_3(1)
                    Dim _Campo_Ecu As String = _Ecuacion_3(2).ToString.ToUpper

                    Dim _Calculo = _Ecuacion_3(3).ToString.ToUpper

                    For Each _FColumnas As DataRow In _Tbl_Campos.Rows
                        Dim _Columna As String = _FColumnas.Item("CODIGO").ToString.Trim
                        _Calculo = Replace(_Calculo, _Columna, 1 & " ")
                    Next

                    _Calculo = Replace(_Calculo, "<", "")
                    _Calculo = Replace(_Calculo, ">", "")

                    Dim _Reg = _Sql.Fx_Cuenta_Registros("PNOMDIM",
                                                        "DEPENDENCI In ('Por_maepr','Por_tabpp','Valor_docud','Valor_docue','Valor_propio'," &
                                                        "'Por_maepr','Por_producto') And CODIGO = '" & _Campo_Ecu & "'")

                    If Not CBool(_Reg) Then
                        _Fx = _Ecuacion
                        Throw New System.Exception(vbCrLf & vbCrLf & "El campo " & _Campo_Ecu.ToString.ToUpper & " no existe")
                    End If

                    _Calculo = Replace(_Calculo.ToString.ToUpper, _Campo_Ecu, 1)

                    Consulta_sql = "Select KOLT From TABPP"
                    Dim _TblLtas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                    For Each _Fila As DataRow In _TblLtas.Rows
                        _Calculo = Replace(_Calculo, _Fila.Item("KOLT"), "")
                    Next

                    Consulta_sql = "Select " & _Calculo & " As Prueba"
                    If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                        'End If
                        'If Not IsNumeric(_Calculo) Then
                        _Fx = _Calculo
                        _Ecuacion_Ok = False
                        Exit For
                        'Else
                        '    _Precio = _Ecuacion_3(3)
                        '    If _Precio < 0 Then

                        '    End If
                    End If

                Next

                If _Ecuacion_Ok Then _Fx = 1

            End If

            Consulta_sql = "Select KOLT From TABPP"
            Dim _TblListas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            For Each _Fila As DataRow In _TblListas.Rows
                _Fx = Replace(_Fx, _Fila.Item("KOLT"), "")
            Next

            Consulta_sql = "Select " & _Fx & " As Prueba"

            If _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                If _Mostrar_error Then
                    Beep()
                    ToastNotification.Show(Me, "LA CONSULTA NO PRESENTA ERRORES", My.Resources.ok_button,
                                          2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                End If
                Return True
            Else
                _Fx = _Ecuacion
                Throw New System.Exception(vbCrLf & vbCrLf & Consulta_sql & " --> " & _Sql.Pro_Error)
            End If

        Catch ex As Exception
            Clipboard.SetText(ex.Message)
            MessageBoxEx.Show(Me, "La función tiene errores" & vbCrLf & vbCrLf & _Fx & ex.Message, "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Function

    Private Sub Btn_Ayuda_Click(sender As Object, e As EventArgs) Handles Btn_Ayuda.Click

        Dim Fmx As New Frm_Archivo_TXT
        Fmx.Texto_Chico = True
        Fmx.Pro_Nombre_Archivo = "Ayuda_LP.txt"
        Fmx.Pro_Texto_Log = My.Resources.Recursos_LP.Leyenda_ayuda_lista_de_precios
        Fmx.ShowDialog(Me)
        Fmx.Dispose()

    End Sub

    Private Sub Chk_Aplica_FX_Documento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Aplica_FX_Documento.CheckedChanged

        If Chk_Aplica_FX_Documento.Checked Then
            Txt_Formula_Fx.CharacterCasing = CharacterCasing.Lower
        Else
            Txt_Formula_Fx.CharacterCasing = CharacterCasing.Upper
        End If

    End Sub


End Class
