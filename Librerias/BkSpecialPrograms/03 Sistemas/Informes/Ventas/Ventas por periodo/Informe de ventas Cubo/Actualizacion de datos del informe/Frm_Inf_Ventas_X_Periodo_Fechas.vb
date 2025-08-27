Imports DevComponents.DotNetBar

Public Class Frm_Inf_Ventas_X_Periodo_Fechas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Segundos As Integer
    Dim _Minutos As Integer
    Dim _Horas As Integer

    Dim _Nombre_Tabla_Paso As String '= "Zw_TblPaso" & FUNCIONARIO

    Dim _Informe_Actualizado As Boolean
    Dim _Cancelar As Boolean

    Dim _Tbl_Filtro_Entidad As DataTable
    Dim _Tbl_Filtro_Vendedor As DataTable
    Dim _Tbl_Filtro_Ciudad As DataTable
    Dim _Tbl_Filtro_Comunas As DataTable

    Dim _Tbl_Filtro_Productos As DataTable
    Dim _Tbl_Filtro_Super_Familias As DataTable
    Dim _Tbl_Filtro_Marcas As DataTable
    Dim _Tbl_Filtro_Rubro As DataTable
    Dim _Tbl_Filtro_Clalibpr As DataTable
    Dim _Tbl_Filtro_Zonas As DataTable

    Dim _Filtro_Entidad_Todas As Boolean
    Dim _Filtro_Vendedor_Todos As Boolean
    Dim _Filtro_Ciudad_Todas As Boolean
    Dim _Filtro_Comunas_Todas As Boolean
    Dim _Filtro_Productos_Todos As Boolean
    Dim _Filtro_Marcas_Todas As Boolean
    Dim _Filtro_Super_Familias_Todas As Boolean
    Dim _Filtro_Rubro_Todas As Boolean
    Dim _Filtro_Clalibpr_Todas As Boolean
    Dim _Filtro_Zonas_Todas As Boolean
    Dim _Filtro_Bodegas_Todas As Boolean

    Dim _Filtro_Extra_Productos,
        _Filtro_Extra_Super_Familias,
        _Filtro_Extra_Marcas,
        _Filtro_Extra_Rubro,
        _Filtro_Extra_Clalibpr,
        _Filtro_Extra_Zonas As String


    Dim _Fecha_Desde As Date
    Dim _Fecha_Hasta As Date

    Dim _Aceptar As Boolean
    Dim _Informe_Generado As Boolean


    Public ReadOnly Property Pro_Informe_Actualizado() As Boolean
        Get
            Return _Informe_Actualizado
        End Get
    End Property

    Public ReadOnly Property Pro_Aceptar() As Boolean
        Get
            Return _Aceptar
        End Get
    End Property

    Public Property Pro_Fecha_Desde() As Date
        Get
            Return Dtp_Fecha_Desde.Value
        End Get
        Set(value As Date)
            Dtp_Fecha_Desde.Value = value
        End Set
    End Property

    Public Property Pro_Fecha_Hasta() As Date
        Get
            Return Dtp_Fecha_Hasta.Value
        End Get
        Set(value As Date)
            Dtp_Fecha_Hasta.Value = value
        End Set
    End Property

    Public Property Nombre_Tabla_Paso As String
        Get
            Return _Nombre_Tabla_Paso
        End Get
        Set(value As String)
            _Nombre_Tabla_Paso = value
        End Set
    End Property

    Enum Enum_Acciones
        Actualizar_Informe_Automatico
        Actializar_Informe_Manual
        Crear_Informe
        Actualizar_Filtro
    End Enum

    Dim _Accion As Enum_Acciones

    Public Property ActualizarDocumentosUnoPorUno As Boolean

    Public Sub New(Accion As Enum_Acciones)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dtp_Fecha_Desde.Value = Primerdiadelmes(FechaDelServidor)
        Dtp_Fecha_Hasta.Value = ultimodiadelmes(FechaDelServidor)

        _Filtro_Entidad_Todas = True
        _Filtro_Ciudad_Todas = True
        _Filtro_Comunas_Todas = True
        _Filtro_Vendedor_Todos = True
        _Filtro_Productos_Todos = True
        _Filtro_Clalibpr_Todas = True
        _Filtro_Marcas_Todas = True
        _Filtro_Rubro_Todas = True
        _Filtro_Super_Familias_Todas = True
        _Filtro_Zonas_Todas = True

        _Accion = Accion

        Sb_Color_Botones_Barra(Bar2)

        Btn_Actualizar_Indices.Visible = False

    End Sub

    Private Sub Frm_Inf_Ventas_X_Periodo_Fechas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Lbl_Estado.Text = "Estado..."
        Lbl_Tiempo.Text = String.Empty
        Lbl_Doc_Insert.Text = String.Empty
        Tiempo.Enabled = True

    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs)
        _Aceptar = False
        Me.Close()
    End Sub

    Private Sub Btn_Filtrar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtrar.Click

        If _Accion = Enum_Acciones.Crear_Informe Then
            Sb_Crear_Nuevo_Informe(Dtp_Fecha_Desde.Value, Dtp_Fecha_Hasta.Value)
        ElseIf _Accion = Enum_Acciones.Actualizar_Filtro Then
            Sb_Actualizar_Filtros()
        Else
            Sb_Actualizar_Informe2(Dtp_Fecha_Desde.Value, Dtp_Fecha_Hasta.Value)
            ' Sb_Actualizar_Informe(Dtp_Fecha_Desde.Value, Dtp_Fecha_Hasta.Value)
        End If

    End Sub

    Private Sub Tiempo_Tick(sender As Object, e As EventArgs) Handles Tiempo.Tick

        Tiempo.Enabled = False

        'ActualizarDocumentosUnoPorUno = True

        If _Accion = Enum_Acciones.Actualizar_Informe_Automatico Then
            Sb_Actualizar_Informe2(Dtp_Fecha_Desde.Value, Dtp_Fecha_Hasta.Value)
            'Sb_Actualizar_Informe(Dtp_Fecha_Desde.Value, Dtp_Fecha_Hasta.Value)
        End If

    End Sub

    Sub Sb_Crear_Nuevo_Informe(_Fecha_Desde As Date,
                               _Fecha_Hasta As Date)

        Try

            _Cancelar = False
            Grupo_Fechas.Enabled = False
            Btn_Cancelar.Enabled = True
            Btn_Filtrar.Enabled = False
            Me.ControlBox = False

            Dim _Mostrar_Error As Boolean = True

            Dim _Reg As Boolean = _Sql.Fx_Existe_Tabla(_Nombre_Tabla_Paso)

            'CBool(_Sql.Fx_Cuenta_Registros("sysobjects", "type = 'U' And name = '" & _Nombre_Tabla_Paso & "'"))
            'SELECT * FROM sysobjects Where type = 'U' And name = 'Zw_TblPasoMAF'

            If Not _Reg Then

                Dim _Idmaeedo = _Sql.Fx_Trae_Dato("MAEEDO", "IDMAEEDO", "TIDO IN ('BLV','FCV','NCV')")

                Consulta_Sql = My.Resources.Recursos_Inf_Ventas.Informe_Ventas_x_Perido_Nivel_Detalle_Cubo
                Consulta_Sql = Replace(Consulta_Sql, "#Empresa#", Mod_Empresa)
                Consulta_Sql = Replace(Consulta_Sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
                Consulta_Sql = Replace(Consulta_Sql, "#Filtro_Externo#", "")
                Consulta_Sql = Replace(Consulta_Sql, "#Fecha_Inicio#", Format(Dtp_Fecha_Desde.Value, "yyyyMMdd"))
                Consulta_Sql = Replace(Consulta_Sql, "#Fecha_Fin#", Format(Dtp_Fecha_Desde.Value, "yyyyMMdd"))
                Consulta_Sql = Replace(Consulta_Sql, "#Idmaeedo#", _Idmaeedo)
                _Sql.Ej_consulta_IDU(Consulta_Sql)

                Consulta_Sql = "Delete " & _Nombre_Tabla_Paso & " Where IDMAEEDO = " & _Idmaeedo
                _Sql.Ej_consulta_IDU(Consulta_Sql)

                'Sb_Actualizar_Indices()

                Sb_Actualizar_Informe2(Dtp_Fecha_Desde.Value, Dtp_Fecha_Hasta.Value)
                'Sb_Actualizar_Informe(Dtp_Fecha_Desde.Value, Dtp_Fecha_Hasta.Value)

            End If

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

            Tiempo.Enabled = False
            _Cancelar = False
            Grupo_Fechas.Enabled = True
            Btn_Cancelar.Enabled = False
            Btn_Filtrar.Enabled = True
            Me.ControlBox = True

            Progreso_Porc.Value = 0
            Progreso_Cont_Productos.Value = 0

            Lbl_Estado.Text = "Estado..."
            Lbl_Tiempo.Text = String.Empty
            Lbl_Doc_Insert.Text = String.Empty
            Me.Refresh()

        End Try

    End Sub

    Sub Sb_Actualizar_Informe(_Fecha_Desde As Date,
                              _Fecha_Hasta As Date)

        Try
            _Cancelar = False
            Grupo_Fechas.Enabled = False
            Btn_Cancelar.Enabled = True
            Btn_Filtrar.Enabled = False
            Me.ControlBox = False

            Dim _Chk_Reingresar_Datos As Boolean

            Dim _Mostrar_Error As Boolean = True

            'Sb_Actualizar_Indices()

            Consulta_Sql = "Delete " & _Nombre_Tabla_Paso & vbCrLf &
                               "Where IDMAEDDO NOT IN (SELECT IDMAEDDO FROM MAEDDO" & Space(1) &
                               "Where FEEMLI = '" & Format(_Fecha_Desde, "yyyyMMdd") & "')" & vbCrLf &
                               "And FEEMLI = '" & Format(_Fecha_Hasta, "yyyyMMdd") & "'" & vbCrLf &
                               "And TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX',
	  			               'FVZ','FXV','FYV','NCE','NCV','NCX','NCZ','NEV')"
            _Sql.Ej_consulta_IDU(Consulta_Sql, False)

            Consulta_Sql = "Delete " & _Nombre_Tabla_Paso & "
                            Where TIDO = 'BLV' And NUDO Not In " &
                            "(Select NUDO From MAEEDO " &
                                "Where TIDO = 'BLV' And FEEMLI between '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "') 
                            And FEEMLI between '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "'

                            Delete " & _Nombre_Tabla_Paso & "
                            Where TIDO = 'FCV' And NUDO Not In " &
                            "(Select NUDO From MAEEDO " &
                                "Where TIDO = 'FCV' And FEEMLI between '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "') 
                            And FEEMLI between '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "'"
            _Sql.Ej_consulta_IDU(Consulta_Sql, False)

            Consulta_Sql = "Delete " & _Nombre_Tabla_Paso & vbCrLf &
                           "Where IDMAEEDO Not In (Select IDMAEEDO From MAEEDO) And FEEMLI between '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "'"
            _Sql.Ej_consulta_IDU(Consulta_Sql, False)

            Consulta_Sql = "Select Distinct FEEMLI From MAEDDO Where IDMAEDDO Not In (Select IDMAEDDO From " & _Nombre_Tabla_Paso & ")
                            And FEEMLI between '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "' 
                            And TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','FXV','FYV','NCE','NCV','NCX','NCZ','NEV')
						    Order by FEEMLI"

            Dim _TblFechas As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

            Progreso_Porc.Maximum = 100
            Progreso_Cont_Productos.Maximum = _TblFechas.Rows.Count

            Dim _Contador = 0

            Dim _Cronometro As New Class_Cronometro(Lbl_Tiempo)

            If CBool(_TblFechas.Rows.Count) Then

                _Cronometro.Sb_Iniciar()

                For Each _RowFecha As DataRow In _TblFechas.Rows

                    Dim _Fecha As Date = _RowFecha.Item("FEEMLI")

                    System.Windows.Forms.Application.DoEvents()

                    Consulta_Sql = "Delete " & _Nombre_Tabla_Paso & vbCrLf &
                                   "Where IDMAEDDO Not In (Select IDMAEDDO FROM MAEDDO
                                   Where FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "')
                                   And FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "'"
                    _Sql.Ej_consulta_IDU(Consulta_Sql)

                    Consulta_Sql = "Delete " & _Nombre_Tabla_Paso & vbCrLf &
                                   "Where FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "'"
                    _Sql.Ej_consulta_IDU(Consulta_Sql)

                    Consulta_Sql = "Select Distinct Top 100 Edo.IDMAEEDO,Edo.TIDO,Edo.NUDO,Edo.NUDONODEFI
                                From MAEDDO Ddo With (Nolock)
                                Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                                Where Ddo.FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "'
                                And Ddo.TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE',
                                'FEV','FVL','FVT','FVX','FVZ','FXV','FYV','NCE','NCV','NCX','NCZ','NEV') 
                                And Ddo.IDMAEDDO Not IN (Select IDMAEDDO From " & _Nombre_Tabla_Paso & " With (Nolock) Where FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "')
                                --And Edo.NUDONODEFI = 0"


                    'Consulta_Sql = "Select Distinct Edo.IDMAEEDO,Edo.TIDO,Edo.NUDO,Edo.NUDONODEFI
                    '                From MAEDDO Ddo
                    '                Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                    '                Where Edo.FEEMDO = '" & Format(_Fecha, "yyyyMMdd") & "'
                    '                And Edo.TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE',
                    '                'FEV','FVL','FVT','FVX','FVZ','FXV','FYV','NCE','NCV','NCX','NCZ','NEV') 
                    '                And Ddo.IDMAEEDO Not IN (Select IDMAEEDO From " & _Nombre_Tabla_Paso & " Where FEEMDO = '" & Format(_Fecha, "yyyyMMdd") & "')"

                    Dim _Tbl_Idmaeedo As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)


                    Lbl_Estado.Text = "Procesando informe, día " & _Contador + 1 & " de " & _TblFechas.Rows.Count & vbCrLf &
                                      "Ventas del: " & FormatDateTime(_Fecha, DateFormat.ShortDate)

                    ' Progreso_Cont_Productos.Maximum = _Tbl_Idmaeedo.Rows.Count

                    'If False Then
                    Dim _Filtro_Idmaeedo As String = Generar_Filtro_IN(_Tbl_Idmaeedo, "", "Idmaeedo", False, False, "")


                    If CBool(_Tbl_Idmaeedo.Rows.Count) Then

                        If Not ActualizarDocumentosUnoPorUno Then

                            Lbl_Doc_Insert.Text = "Insertando " & FormatNumber(_Tbl_Idmaeedo.Rows.Count, 0) & " documentos..." ', fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate)

                            Consulta_Sql = "Delete " & _Nombre_Tabla_Paso & " Where IDMAEEDO In " & _Filtro_Idmaeedo
                            _Sql.Ej_consulta_IDU(Consulta_Sql)

                            Consulta_Sql = My.Resources.Recursos_Inf_Ventas.Informe_Ventas_x_Perido_Nivel_Detalle_Cubo_Actualizacion2
                            Consulta_Sql = Replace(Consulta_Sql, "#Empresa#", Mod_Empresa)
                            Consulta_Sql = Replace(Consulta_Sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
                            Consulta_Sql = Replace(Consulta_Sql, "#Fecha_Inicio#", Format(_Fecha, "yyyyMMdd"))
                            Consulta_Sql = Replace(Consulta_Sql, "#Fecha_Fin#", Format(_Fecha, "yyyyMMdd"))
                            Consulta_Sql = Replace(Consulta_Sql, "#Filtro_Externo#", "")
                            Consulta_Sql = Replace(Consulta_Sql, "(#Idmaeedo#)", _Filtro_Idmaeedo)
                            _Sql.Ej_consulta_IDU(Consulta_Sql)

                            Lbl_Doc_Insert.Text = "Actualizando filtros..." ', fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate)
                            Consulta_Sql = My.Resources.Recursos_Inf_Ventas.Informe_Ventas_x_Perido_Nivel_Detalle_Cubo_Actualizacion3_Clasificaciones
                            Consulta_Sql = Replace(Consulta_Sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
                            Consulta_Sql = Replace(Consulta_Sql, "(#Idmaeedo#)", _Filtro_Idmaeedo)
                            _Sql.Ej_consulta_IDU(Consulta_Sql)

                        End If

                        If ActualizarDocumentosUnoPorUno Then

                            Progreso_Cont_Productos.Maximum = _Tbl_Idmaeedo.Rows.Count
                            Progreso_Cont_Productos.Value = 0

                            For Each _Filas_Edo As DataRow In _Tbl_Idmaeedo.Rows

                                Dim _Idmaeedo = _Filas_Edo.Item("IDMAEEDO")
                                Dim _Tido_Nudo = _Filas_Edo.Item("TIDO") & "-" & _Filas_Edo.Item("NUDO")
                                Dim _Nudonodefi = _Filas_Edo.Item("NUDONODEFI")
                                'Lbl_Estado.Text = "Procesando informe, días con diferencias " & _Contador + 1 & " de " & _TblFechas.Rows.Count & vbCrLf &
                                '                  "Ventas del: " & FormatDateTime(_Fecha, DateFormat.ShortDate) & vbCrLf &
                                '                  "Documento: " & _Tido_Nudo
                                Lbl_Doc_Insert.Text = "Insertando documentos " & FormatNumber(Progreso_Cont_Productos.Value + 1, 0) & " de " &
                                               FormatNumber(Progreso_Cont_Productos.Maximum, 0)

                                If Not _Nudonodefi Then

                                    System.Windows.Forms.Application.DoEvents()

                                    Consulta_Sql = My.Resources.Recursos_Inf_Ventas.Informe_Ventas_x_Perido_Nivel_Detalle_Cubo_Actualizacion2
                                    Consulta_Sql = Replace(Consulta_Sql, "#Empresa#", Mod_Empresa)
                                    Consulta_Sql = Replace(Consulta_Sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
                                    Consulta_Sql = Replace(Consulta_Sql, "#Fecha_Inicio#", Format(_Fecha, "yyyyMMdd"))
                                    Consulta_Sql = Replace(Consulta_Sql, "#Fecha_Fin#", Format(_Fecha, "yyyyMMdd"))
                                    Consulta_Sql = Replace(Consulta_Sql, "#Filtro_Externo#", "")
                                    Consulta_Sql = Replace(Consulta_Sql, "#Idmaeedo#", _Idmaeedo)
                                    _Sql.Ej_consulta_IDU(Consulta_Sql)

                                    Consulta_Sql = My.Resources.Recursos_Inf_Ventas.Informe_Ventas_x_Perido_Nivel_Detalle_Cubo_Actualizacion3_Clasificaciones
                                    Consulta_Sql = Replace(Consulta_Sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
                                    Consulta_Sql = Replace(Consulta_Sql, "#Idmaeedo#", _Idmaeedo)
                                    _Sql.Ej_consulta_IDU(Consulta_Sql)

                                End If

                                '_Contador += 1
                                Progreso_Cont_Productos.Value += 1 '_Contador ' ((_Contador * 100) / _TblFechas.Rows.Count) 'Mas

                                If _Cancelar Then
                                    Exit For
                                End If

                            Next

                        End If

                        'Progreso_Cont_Productos.Value = 0

                    End If


                    _Contador += 1
                    Progreso_Porc.Value = ((_Contador * 100) / _TblFechas.Rows.Count) 'Mas
                    'Progreso_Cont_Productos.Value = _Contador
                    'Progreso_Cont.Value = _Contador

                    If _Cancelar Then

                        _Cronometro.Sb_Detener()

                        If MessageBoxEx.Show(Me, "¿Desea detener el proceso?", "Detener proceso",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            _Mostrar_Error = False
                            _Informe_Actualizado = False
                            Exit For
                        Else
                            _Cancelar = False
                            _Cronometro.Sb_Iniciar()
                        End If

                    End If

                    If Not Bar2.Enabled Then Bar2.Enabled = True

                Next

            End If

            _Cronometro.Sb_Detener()


            If Not _Cancelar Then
                _Informe_Actualizado = True
                Me.Close()
            End If

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

            Tiempo.Enabled = False
            _Cancelar = False
            Grupo_Fechas.Enabled = True
            Btn_Cancelar.Enabled = False
            Btn_Filtrar.Enabled = True
            Me.ControlBox = True

            Progreso_Porc.Value = 0
            Progreso_Cont_Productos.Value = 0

            Lbl_Estado.Text = "Estado..."
            Lbl_Tiempo.Text = String.Empty
            Lbl_Doc_Insert.Text = String.Empty
            Me.Refresh()

        End Try

    End Sub


    Sub Sb_Actualizar_Informe2(_Fecha_Desde As Date,
                               _Fecha_Hasta As Date)

        Try
            _Cancelar = False
            Grupo_Fechas.Enabled = False
            Btn_Cancelar.Enabled = True
            Btn_Filtrar.Enabled = False
            Me.ControlBox = False

            Dim _Chk_Reingresar_Datos As Boolean

            Dim _Mostrar_Error As Boolean = True

            'Sb_Actualizar_Indices()

            'Consulta_Sql = "Delete " & _Nombre_Tabla_Paso & vbCrLf &
            '               "Where IDMAEDDO NOT IN (SELECT IDMAEDDO FROM MAEDDO With (Nolock)" & Space(1) &
            '               "Where FEEMLI = '" & Format(_Fecha_Desde, "yyyyMMdd") & "' " &
            '               "And TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','FXV','FYV','NCE','NCV','NCX','NCZ','NEV'))" & vbCrLf &
            '               "And FEEMLI = '" & Format(_Fecha_Desde, "yyyyMMdd") & "'"
            '_Sql.Ej_consulta_IDU(Consulta_Sql, False)

            Consulta_Sql = "Delete " & _Nombre_Tabla_Paso & "
                            Where TIDO = 'BLV' And NUDO Not In " &
                            "(Select NUDO From MAEEDO With (Nolock)" & Space(1) &
                                "Where TIDO = 'BLV' And FEEMLI between '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "') 
                            And FEEMLI between '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "'

                            Delete " & _Nombre_Tabla_Paso & "
                            Where TIDO = 'FCV' And NUDO Not In " &
                            "(Select NUDO From MAEEDO With (Nolock)" & Space(1) &
                                "Where TIDO = 'FCV' And FEEMLI between '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "') 
                            And FEEMLI between '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "'"
            _Sql.Ej_consulta_IDU(Consulta_Sql, False)

            Consulta_Sql = "Delete " & _Nombre_Tabla_Paso & vbCrLf &
                           "Where IDMAEEDO Not In (Select IDMAEEDO From MAEEDO With (Nolock)) And FEEMLI between '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "'"
            _Sql.Ej_consulta_IDU(Consulta_Sql, False)

            Consulta_Sql = "Select Distinct FEEMLI From MAEDDO With (Nolock) Where IDMAEDDO Not In (Select IDMAEDDO From " & _Nombre_Tabla_Paso & " With (Nolock))
                            And FEEMLI between '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "' 
                            And TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','FXV','FYV','NCE','NCV','NCX','NCZ','NEV')
						    Order by FEEMLI"

            Dim _TblFechas As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

            Progreso_Porc.Maximum = 100
            Progreso_Cont_Productos.Maximum = _TblFechas.Rows.Count

            Dim _Contador = 0

            Dim _Cronometro As New Class_Cronometro(Lbl_Tiempo)

            If CBool(_TblFechas.Rows.Count) Then

                _Cronometro.Sb_Iniciar()

                For Each _RowFecha As DataRow In _TblFechas.Rows

                    Dim _Fecha As Date = _RowFecha.Item("FEEMLI")

                    System.Windows.Forms.Application.DoEvents()

                    Consulta_Sql = "Delete " & _Nombre_Tabla_Paso & vbCrLf &
                                   "Where IDMAEDDO Not In (Select IDMAEDDO FROM MAEDDO With (Nolock)" & vbCrLf &
                                   "Where FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & Space(1) &
                                   "'And TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL'," &
                                   "'FVT','FVX','FVZ','FXV','FYV','NCE','NCV','NCX','NCZ','NEV')) And FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "'"
                    _Sql.Ej_consulta_IDU(Consulta_Sql)

                    'Consulta_Sql = "Delete " & _Nombre_Tabla_Paso & vbCrLf & "Where FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "'"
                    'Consulta_Sql = "Delete " & _Nombre_Tabla_Paso & " Where IDMAEDDO In (Select IDMAEDDO From " & _Nombre_Tabla_Paso & " Where FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "')"


                    ' Elimina registros por lotes de a 1000
                    Consulta_Sql = "-- Definir el tamaño del lote" & vbCrLf &
                                   "DECLARE @BatchSize INT = 1000;" & vbCrLf &
                                   "-- Contar el número total de registros que cumplen con la condición" & vbCrLf &
                                   "DECLARE @TotalRows INT;" & vbCrLf &
                                   "SELECT @TotalRows = COUNT(*)" & vbCrLf &
                                   "FROM " & _Nombre_Tabla_Paso & vbCrLf &
                                   "WHERE IDMAEDDO In (Select IDMAEDDO From " & _Nombre_Tabla_Paso & " Where FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "') -- Reemplaza 'Condicion' con la condición que necesitas" & vbCrLf &
                                   "-- Calcular el número de lotes necesarios" & vbCrLf &
                                   "DECLARE @TotalBatches INT;" & vbCrLf &
                                   "SET @TotalBatches = CEILING(@TotalRows / @BatchSize);" & vbCrLf &
                                   "-- Contador de filas afectadas" & vbCrLf &
                                   "DECLARE @RowsAffected INT;" & vbCrLf &
                                   "-- Bucle para eliminar registros en lotes" & vbCrLf &
                                   "WHILE (1 = 1)" & vbCrLf &
                                   "BEGIN" & vbCrLf &
                                   "    -- Eliminar un lote de registros" & vbCrLf &
                                   "    DELETE TOP (@BatchSize)" & vbCrLf &
                                   "    FROM " & _Nombre_Tabla_Paso & vbCrLf &
                                   "    WHERE IDMAEDDO In (Select IDMAEDDO From " & _Nombre_Tabla_Paso & " Where FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "') -- Reemplaza 'Condicion' con la condición que necesitas" & vbCrLf &
                                   "    -- Obtener el número de filas afectadas" & vbCrLf &
                                   "    SET @RowsAffected = @@ROWCOUNT;" & vbCrLf &
                                   "    -- Si no se eliminaron filas, salir del bucle" & vbCrLf &
                                   "    IF @RowsAffected = 0" & vbCrLf &
                                   "       BREAK;" & vbCrLf &
                                   "END"
                    '_Sql.Ej_consulta_IDU(Consulta_Sql)


                    Consulta_Sql = "Select Distinct Edo.IDMAEEDO,Edo.TIDO,Edo.NUDO,Edo.NUDONODEFI" & vbCrLf &
                                   "From MAEDDO Ddo With (Nolock)" & vbCrLf &
                                   "Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO" & vbCrLf &
                                   "Where Ddo.FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "'" & vbCrLf &
                                   "And Ddo.TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE'," &
                                   "'FEV','FVL','FVT','FVX','FVZ','FXV','FYV','NCE','NCV','NCX','NCZ','NEV')" & vbCrLf &
                                   "And Ddo.IDMAEDDO Not IN (Select IDMAEDDO From " & _Nombre_Tabla_Paso & " With (Nolock) Where FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "')"

                    Dim _Tbl_Idmaeedo As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)


                    Lbl_Estado.Text = "Procesando informe, día " & _Contador + 1 & " de " & _TblFechas.Rows.Count & vbCrLf &
                                      "Ventas del: " & FormatDateTime(_Fecha, DateFormat.ShortDate)

                    Dim _Filtro_Idmaeedo As String = Generar_Filtro_IN(_Tbl_Idmaeedo, "", "Idmaeedo", False, False, "")

                    Dim _Insertados = 0
                    Dim _Lotes = 100

                    If CBool(_Tbl_Idmaeedo.Rows.Count) Then

                        Dim _Paquetes = Math.Ceiling(_Tbl_Idmaeedo.Rows.Count / _Lotes)
                        Dim _ListaPaquetes As New List(Of DataTable)

                        For i As Integer = 0 To _Paquetes - 1
                            Dim _Paquete As DataTable = _Tbl_Idmaeedo.Clone()
                            For j As Integer = 0 To _Lotes - 1
                                Dim _Index As Integer = (i * _Lotes) + j
                                If _Index >= _Tbl_Idmaeedo.Rows.Count Then Exit For
                                _Paquete.ImportRow(_Tbl_Idmaeedo.Rows(_Index))
                            Next
                            _ListaPaquetes.Add(_Paquete)
                        Next

                        Progreso_Cont_Productos.Maximum = _Paquetes
                        Progreso_Cont_Productos.Value = 0

                        Dim _CtaPqte = 1

                        For Each _Paquete As DataTable In _ListaPaquetes

                            Dim _Filtro_Idmaeedo2 As String = Generar_Filtro_IN(_Paquete, "", "Idmaeedo", False, False, "")

                            If Not ActualizarDocumentosUnoPorUno Then

                                _Insertados += _Paquete.Rows.Count

                                Lbl_Doc_Insert.Text = "Documentos insertados: " & FormatNumber(_Insertados, 0) & "... paquete " & _CtaPqte & " de " & _Paquetes

                                System.Windows.Forms.Application.DoEvents()

                                If _Cancelar Then Exit For

                                Consulta_Sql = "Delete " & _Nombre_Tabla_Paso & " Where IDMAEEDO In " & _Filtro_Idmaeedo2
                                _Sql.Ej_consulta_IDU(Consulta_Sql)

                                System.Windows.Forms.Application.DoEvents()

                                Consulta_Sql = My.Resources.Recursos_Inf_Ventas.Informe_Ventas_x_Perido_Nivel_Detalle_Cubo_Actualizacion2
                                Consulta_Sql = Replace(Consulta_Sql, "#Empresa#", Mod_Empresa)
                                Consulta_Sql = Replace(Consulta_Sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
                                Consulta_Sql = Replace(Consulta_Sql, "#Fecha_Inicio#", Format(_Fecha, "yyyyMMdd"))
                                Consulta_Sql = Replace(Consulta_Sql, "#Fecha_Fin#", Format(_Fecha, "yyyyMMdd"))
                                Consulta_Sql = Replace(Consulta_Sql, "#Filtro_Externo#", "")
                                Consulta_Sql = Replace(Consulta_Sql, "(#Idmaeedo#)", _Filtro_Idmaeedo2)
                                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql)

                                System.Windows.Forms.Application.DoEvents()

                                Consulta_Sql = My.Resources.Recursos_Inf_Ventas.Informe_Ventas_x_Perido_Nivel_Detalle_Cubo_Actualizacion3_Clasificaciones
                                Consulta_Sql = Replace(Consulta_Sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
                                Consulta_Sql = Replace(Consulta_Sql, "(#Idmaeedo#)", _Filtro_Idmaeedo2)
                                _Sql.Ej_consulta_IDU(Consulta_Sql)

                            End If

                            If ActualizarDocumentosUnoPorUno Then

                                Progreso_Cont_Productos.Maximum = _Paquete.Rows.Count
                                Progreso_Cont_Productos.Value = 0

                                For Each _Filas_Edo As DataRow In _Paquete.Rows
                                    Dim _Idmaeedo = _Filas_Edo.Item("IDMAEEDO")
                                    Dim _Tido_Nudo = _Filas_Edo.Item("TIDO") & "-" & _Filas_Edo.Item("NUDO")
                                    Dim _Nudonodefi = _Filas_Edo.Item("NUDONODEFI")

                                    Lbl_Doc_Insert.Text = "Insertando documentos " & FormatNumber(Progreso_Cont_Productos.Value + 1, 0) & " de " & FormatNumber(Progreso_Cont_Productos.Maximum, 0)

                                    If Not _Nudonodefi Then
                                        System.Windows.Forms.Application.DoEvents()

                                        Consulta_Sql = My.Resources.Recursos_Inf_Ventas.Informe_Ventas_x_Perido_Nivel_Detalle_Cubo_Actualizacion2
                                        Consulta_Sql = Replace(Consulta_Sql, "#Empresa#", Mod_Empresa)
                                        Consulta_Sql = Replace(Consulta_Sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
                                        Consulta_Sql = Replace(Consulta_Sql, "#Fecha_Inicio#", Format(_Fecha, "yyyyMMdd"))
                                        Consulta_Sql = Replace(Consulta_Sql, "#Fecha_Fin#", Format(_Fecha, "yyyyMMdd"))
                                        Consulta_Sql = Replace(Consulta_Sql, "#Filtro_Externo#", "")
                                        Consulta_Sql = Replace(Consulta_Sql, "#Idmaeedo#", _Idmaeedo)
                                        _Sql.Ej_consulta_IDU(Consulta_Sql)

                                        Consulta_Sql = My.Resources.Recursos_Inf_Ventas.Informe_Ventas_x_Perido_Nivel_Detalle_Cubo_Actualizacion3_Clasificaciones
                                        Consulta_Sql = Replace(Consulta_Sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
                                        Consulta_Sql = Replace(Consulta_Sql, "#Idmaeedo#", _Idmaeedo)
                                        _Sql.Ej_consulta_IDU(Consulta_Sql)
                                    End If

                                    Progreso_Cont_Productos.Value += 1

                                    If _Cancelar Then Exit For
                                Next
                            End If

                            Progreso_Cont_Productos.Value += 1
                            _CtaPqte += 1

                        Next

                    End If


                    _Contador += 1
                    Progreso_Porc.Value = ((_Contador * 100) / _TblFechas.Rows.Count) 'Mas
                    'Progreso_Cont_Productos.Value = _Contador
                    'Progreso_Cont.Value = _Contador

                    If _Cancelar Then

                        _Cronometro.Sb_Detener()

                        If MessageBoxEx.Show(Me, "¿Desea detener el proceso?", "Detener proceso",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            _Mostrar_Error = False
                            _Informe_Actualizado = False
                            Exit For
                        Else
                            _Cancelar = False
                            _Cronometro.Sb_Iniciar()
                        End If

                    End If

                    If Not Bar2.Enabled Then Bar2.Enabled = True

                Next

            End If

            _Cronometro.Sb_Detener()


            If Not _Cancelar Then
                _Informe_Actualizado = True
                Me.Close()
            End If

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

            Tiempo.Enabled = False
            _Cancelar = False
            Grupo_Fechas.Enabled = True
            Btn_Cancelar.Enabled = False
            Btn_Filtrar.Enabled = True
            Me.ControlBox = True

            Progreso_Porc.Value = 0
            Progreso_Cont_Productos.Value = 0

            Lbl_Estado.Text = "Estado..."
            Lbl_Tiempo.Text = String.Empty
            Lbl_Doc_Insert.Text = String.Empty
            Me.Refresh()

        End Try

    End Sub

    Private Sub Btn_Actualizar_Indices_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar_Indices.Click
        Sb_Actualizar_Indices()
    End Sub

    Sub Sb_Actualizar_Informe_Por_Dia(_Fecha_Desde As Date,
                                     _Fecha_Hasta As Date)

        Try
            _Cancelar = False
            Grupo_Fechas.Enabled = False
            Btn_Cancelar.Enabled = True
            Btn_Filtrar.Enabled = False
            Me.ControlBox = False

            Dim _Mostrar_Error As Boolean = True

            'Sb_Actualizar_Indices()

            Consulta_Sql = "Delete " & _Nombre_Tabla_Paso & vbCrLf &
                           "Where IDMAEDDO NOT IN (SELECT IDMAEDDO FROM MAEDDO" & Space(1) &
                           "Where FEEMLI = '" & Format(_Fecha_Desde, "yyyyMMdd") & "')" & vbCrLf &
                           "And FEEMLI = '" & Format(_Fecha_Hasta, "yyyyMMdd") & "'" & vbCrLf &
                           "And TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX',
	  			           'FVZ','FXV','FYV','NCE','NCV','NCX','NCZ','NEV')"
            _Sql.Ej_consulta_IDU(Consulta_Sql, False)


            Consulta_Sql = "Select Distinct FEEMLI From MAEDDO
                           Where FEEMLI between '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And
                           '" & Format(_Fecha_Hasta, "yyyyMMdd") & "'
                           And TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX',
	  			           'FVZ','FXV','FYV','NCE','NCV','NCX','NCZ','NEV')
                           And IDMAEEDO Not In (Select IDMAEEDO From " & _Nombre_Tabla_Paso & ")
                           Order by FEEMLI"

            Dim _TblFechas As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

            Progreso_Porc.Maximum = 100
            Dim _Contador = 0

            Dim _Cronometro As New Class_Cronometro(Lbl_Tiempo)

            If CBool(_TblFechas.Rows.Count) Then

                _Cronometro.Sb_Iniciar()

                For Each _RowFecha As DataRow In _TblFechas.Rows

                    Dim _Fecha As Date = _RowFecha.Item("FEEMLI")

                    System.Windows.Forms.Application.DoEvents()

                    Consulta_Sql = "Delete " & _Nombre_Tabla_Paso & vbCrLf &
                                   "Where IDMAEDDO Not In (Select IDMAEDDO FROM MAEDDO
                                   Where FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "')
                                   And FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "'"
                    _Sql.Ej_consulta_IDU(Consulta_Sql)


                    Consulta_Sql = "Select Distinct Edo.IDMAEEDO,Edo.TIDO,Edo.NUDO,Edo.NUDONODEFI
                                From MAEDDO Ddo
                                Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO
                                Where Ddo.FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "'
                                And Ddo.TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE',
                                'FEV','FVL','FVT','FVX','FVZ','FXV','FYV','NCE','NCV','NCX','NCZ','NEV') 
                                And Ddo.IDMAEEDO Not IN (Select IDMAEEDO From " & _Nombre_Tabla_Paso & " Where FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "')
                                --And Edo.NUDONODEFI = 0"

                    Dim _Tbl_Idmaeedo As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)


                    Lbl_Estado.Text = "Procesando informe, día " & _Contador + 1 & " de " & _TblFechas.Rows.Count & vbCrLf &
                                      "Ventas del: " & FormatDateTime(_Fecha, DateFormat.ShortDate)

                    ' Progreso_Cont_Productos.Maximum = _Tbl_Idmaeedo.Rows.Count

                    Dim _Filtro_Idmaeedo As String = Generar_Filtro_IN(_Tbl_Idmaeedo, "", "Idmaeedo", False, False, "")
                    Progreso_Cont_Productos.Maximum = _Tbl_Idmaeedo.Rows.Count

                    For Each _Filas_Edo As DataRow In _Tbl_Idmaeedo.Rows

                        Dim _Idmaeedo = _Filas_Edo.Item("IDMAEEDO")
                        Dim _Tido_Nudo = _Filas_Edo.Item("TIDO") & "-" & _Filas_Edo.Item("NUDO")
                        Dim _Nudonodefi = _Filas_Edo.Item("NUDONODEFI")

                        Lbl_Estado.Text = "Procesando informe, días con diferencias " & _Contador + 1 & " de " & _TblFechas.Rows.Count & vbCrLf &
                                          "Ventas del: " & FormatDateTime(_Fecha, DateFormat.ShortDate) & vbCrLf &
                                          "Documento: " & _Tido_Nudo
                        Lbl_Doc_Insert.Text = "Insertando documentos " & FormatNumber(Progreso_Cont_Productos.Value + 1, 0) & " de " &
                                           FormatNumber(Progreso_Cont_Productos.Maximum, 0)

                        If Not _Nudonodefi Then

                            System.Windows.Forms.Application.DoEvents()

                            Consulta_Sql = My.Resources.Recursos_Inf_Ventas.Informe_Ventas_x_Perido_Nivel_Detalle_Cubo_Actualizacion2
                            Consulta_Sql = Replace(Consulta_Sql, "#Empresa#", Mod_Empresa)
                            Consulta_Sql = Replace(Consulta_Sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
                            Consulta_Sql = Replace(Consulta_Sql, "#Fecha_Inicio#", Format(_Fecha, "yyyyMMdd"))
                            Consulta_Sql = Replace(Consulta_Sql, "#Fecha_Fin#", Format(_Fecha, "yyyyMMdd"))
                            Consulta_Sql = Replace(Consulta_Sql, "#Filtro_Externo#", "")
                            Consulta_Sql = Replace(Consulta_Sql, "#Idmaeedo#", _Idmaeedo)
                            _Sql.Ej_consulta_IDU(Consulta_Sql)

                        End If

                        Progreso_Cont_Productos.Value += 1 '_Contador ' ((_Contador * 100) / _TblFechas.Rows.Count) 'Mas

                        If _Cancelar Then
                            Exit For
                        End If

                    Next

                    If CBool(_Tbl_Idmaeedo.Rows.Count) Then

                        Lbl_Doc_Insert.Text = "Actualizando filtros..." ', fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate)
                        Consulta_Sql = My.Resources.Recursos_Inf_Ventas.Informe_Ventas_x_Perido_Nivel_Detalle_Cubo_Actualizacion3_Clasificaciones
                        Consulta_Sql = Replace(Consulta_Sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
                        Consulta_Sql = Replace(Consulta_Sql, "(#Idmaeedo#)", _Filtro_Idmaeedo)
                        _Sql.Ej_consulta_IDU(Consulta_Sql)

                    End If

                    _Contador += 1
                    Progreso_Porc.Value = ((_Contador * 100) / _TblFechas.Rows.Count) 'Mas

                    If _Cancelar Then
                        _Cronometro.Sb_Detener()
                        If MessageBoxEx.Show(Me, "¿Desea detener el proceso?", "Detener proceso",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            _Mostrar_Error = False
                            _Informe_Actualizado = False
                            Exit For
                        Else
                            _Cancelar = False
                            _Cronometro.Sb_Iniciar()
                        End If
                    End If

                    If Not Bar2.Enabled Then Bar2.Enabled = True

                Next

            End If

            _Cronometro.Sb_Detener()


            If Not _Cancelar Then
                _Informe_Actualizado = True
                Me.Close()
            End If

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

            Tiempo.Enabled = False
            _Cancelar = False
            Grupo_Fechas.Enabled = True
            Btn_Cancelar.Enabled = False
            Btn_Filtrar.Enabled = True
            Me.ControlBox = True

            Progreso_Porc.Value = 0
            'Progreso_Cont.Value = 0
            Progreso_Cont_Productos.Value = 0

            Lbl_Estado.Text = "Estado..."
            Lbl_Tiempo.Text = String.Empty
            Lbl_Doc_Insert.Text = String.Empty
            Me.Refresh()
        End Try

    End Sub

    Sub Sb_Actualizar_Indices()

        Lbl_Estado.Text = "ACTUALIZANDO INDICES..."
        System.Windows.Forms.Application.DoEvents()

        'CREATE UNIQUE INDEX Ix_#Tabla_Paso#_01 ON #Tabla_Paso# (IDMAEDDO)

        ' Dim _Tabla_Paso As String = Replace(_Nombre_Tabla_Paso, _Global_BaseBk, "")

        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_01", _Nombre_Tabla_Paso, "IDMAEDDO", True)
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_02", _Nombre_Tabla_Paso, "ENDO,SUENDO")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_03", _Nombre_Tabla_Paso, "KOPRCT")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_04", _Nombre_Tabla_Paso, "SULIDO,BOSULIDO")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_05", _Nombre_Tabla_Paso, "KOFUDO")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_06", _Nombre_Tabla_Paso, "KOFULIDO")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_07", _Nombre_Tabla_Paso, "IDMAEEDO")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_08", _Nombre_Tabla_Paso, "FEEMLI")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_09", _Nombre_Tabla_Paso, "FMPR")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_10", _Nombre_Tabla_Paso, "FMPR, PFPR")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_11", _Nombre_Tabla_Paso, "FMPR, PFPR, HFPR")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_12", _Nombre_Tabla_Paso, "MRPR")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_13", _Nombre_Tabla_Paso, "RUPR")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_14", _Nombre_Tabla_Paso, "ZOPR")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_15", _Nombre_Tabla_Paso, "CLALIBPR")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_16", _Nombre_Tabla_Paso, "KOFUEN")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_17", _Nombre_Tabla_Paso, "ACTIEN")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_18", _Nombre_Tabla_Paso, "TIPOEN")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_19", _Nombre_Tabla_Paso, "TAMAEN")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_21", _Nombre_Tabla_Paso, "ZOEN")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_22", _Nombre_Tabla_Paso, "RUEN")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_23", _Nombre_Tabla_Paso, "IDMAEEDO,ENDO,SUENDO")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_24", _Nombre_Tabla_Paso, "KOLTPR")
        Fx_Crear_Indice("Ix_" & _Nombre_Tabla_Paso & "_25", _Nombre_Tabla_Paso, "LVEN")

    End Sub

    Sub Sb_Actualizar_Filtros()

        Dim _Filtros_Actualizados As Boolean

        Try
            _Cancelar = False
            Grupo_Fechas.Enabled = False
            Btn_Cancelar.Enabled = True
            Btn_Filtrar.Enabled = False
            Me.ControlBox = False

            Dim _Mostrar_Error As Boolean = True


            Dim _Row_Fechas As DataRow

            Consulta_Sql = "Select MIN(FEEMLI) As Fecha_Desde,MAX(FEEMLI) AS Fecha_Hasta From " & _Nombre_Tabla_Paso
            _Row_Fechas = _Sql.Fx_Get_DataRow(Consulta_Sql)

            Dim _Fecha_Desde As Date = FormatDateTime(_Row_Fechas.Item("Fecha_Desde"), DateFormat.ShortDate)
            Dim _Fecha_Hasta As Date = FormatDateTime(_Row_Fechas.Item("Fecha_Hasta"), DateFormat.ShortDate)

            _Fecha_Desde = Dtp_Fecha_Desde.Value
            _Fecha_Hasta = Dtp_Fecha_Hasta.Value

            Dim _Meses As Integer = DateDiff(DateInterval.Month, _Fecha_Desde, _Fecha_Hasta)

            Progreso_Porc.Maximum = 100
            Progreso_Cont_Productos.Maximum = _Meses

            Dim _Contador = 0
            Dim _Fecha As Date = Primerdiadelmes(_Fecha_Desde)

            If _Meses = 0 Then
                _Meses = 1
            End If

            For _Mes = 1 To _Meses

                Dim _Fecha_Primer_Dia = Primerdiadelmes(_Fecha)
                Dim _Fecha_Ultimo_Dia = ultimodiadelmes(_Fecha)

                Consulta_Sql = "Select Distinct IDMAEEDO 
                                From " & _Nombre_Tabla_Paso & "
                                Where FEEMLI Between '" & Format(_Fecha_Primer_Dia, "yyyyMMdd") & "' And '" & Format(_Fecha_Ultimo_Dia, "yyyyMMdd") & "' And EMPRESA = '" & Mod_Empresa & "'"

                Dim _Tbl_Idmaeedo As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

                Lbl_Estado.Text = "Actualizando filtros del mes " & _Contador + 1 & " de " & _Meses

                Application.DoEvents()

                If CBool(_Tbl_Idmaeedo.Rows.Count) Then

                    Dim _Filtro_Idmaeedo As String = Generar_Filtro_IN(_Tbl_Idmaeedo, "", "Idmaeedo", False, False, "")
                    Lbl_Doc_Insert.Text = "Actualizando filtros..."
                    Application.DoEvents()
                    Consulta_Sql = My.Resources.Recursos_Inf_Ventas.Informe_Ventas_x_Perido_Nivel_Detalle_Cubo_Actualizacion3_Clasificaciones
                    Consulta_Sql = Replace(Consulta_Sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
                    Consulta_Sql = Replace(Consulta_Sql, "(#Idmaeedo#)", _Filtro_Idmaeedo)
                    _Sql.Ej_consulta_IDU(Consulta_Sql)

                End If

                _Contador += 1

                Progreso_Porc.Value = ((_Contador * 100) / _Meses)
                Progreso_Cont_Productos.Value = _Contador

                _Fecha = DateAdd(DateInterval.Month, 1, _Fecha_Primer_Dia)

                If _Cancelar Then
                    Exit For
                End If

            Next

            If Not _Cancelar Then

                _Filtros_Actualizados = True
                _Informe_Actualizado = True
                _Global_Informe_Venta_Datos_Actualizados = True

                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Mantención de informe",
                             MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

            Tiempo.Enabled = False
            _Cancelar = False
            Grupo_Fechas.Enabled = True
            Btn_Cancelar.Enabled = False
            Btn_Filtrar.Enabled = True
            Me.ControlBox = True

            Progreso_Porc.Value = 0
            Progreso_Cont_Productos.Value = 0

            Lbl_Estado.Text = "Estado..."
            Lbl_Tiempo.Text = String.Empty
            Lbl_Doc_Insert.Text = String.Empty
            Me.Refresh()

        End Try

        If _Filtros_Actualizados Then
            Me.Close()
        End If

    End Sub

    Sub Sb_Actualizar_Filtros_Diariamente()

        Dim _Filtros_Actualizados As Boolean

        Try
            _Cancelar = False
            Grupo_Fechas.Enabled = False
            Btn_Cancelar.Enabled = True
            Btn_Filtrar.Enabled = False
            Me.ControlBox = False

            Dim _Mostrar_Error As Boolean = True


            Dim _Row_Fechas As DataRow

            Consulta_Sql = "Select MIN(FEEMLI) As Fecha_Desde,MAX(FEEMLI) AS Fecha_Hasta From " & _Nombre_Tabla_Paso
            _Row_Fechas = _Sql.Fx_Get_DataRow(Consulta_Sql)

            Dim _Fecha_Desde As Date = FormatDateTime(_Row_Fechas.Item("Fecha_Desde"), DateFormat.ShortDate)
            Dim _Fecha_Hasta As Date = FormatDateTime(_Row_Fechas.Item("Fecha_Hasta"), DateFormat.ShortDate)

            _Fecha_Desde = Dtp_Fecha_Desde.Value
            _Fecha_Hasta = Dtp_Fecha_Hasta.Value

            'Dim _Meses As Integer = DateDiff(DateInterval.Month, _Fecha_Desde, _Fecha_Hasta)
            Dim _Dias As Integer = DateDiff(DateInterval.Day, _Fecha_Desde, _Fecha_Hasta)

            Progreso_Porc.Maximum = 100
            Progreso_Cont_Productos.Maximum = _Dias

            Dim _Contador = 0
            Dim _Fecha As Date = _Fecha_Desde

            For _Dia = 0 To _Dias

                Application.DoEvents()

                'Dim _Fecha_Primer_Dia = Primerdiadelmes(_Fecha)
                'Dim _Fecha_Ultimo_Dia = ultimodiadelmes(_Fecha)

                Consulta_Sql = "Select Distinct IDMAEEDO 
                                From " & _Nombre_Tabla_Paso & "
                                Where FEEMLI = '" & Format(_Fecha, "yyyyMMdd") & "'"

                Dim _Tbl_Idmaeedo As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

                'Lbl_Estado.Text = "Actualizando filtros del mes " & MonthName(_Fecha.Month) & " día: " & _Contador + 1 & " de " & _Dias
                Lbl_Estado.Text = "Actualizando filtros del " & FormatDateTime(_Fecha, DateFormat.LongDate)

                If CBool(_Tbl_Idmaeedo.Rows.Count) Then

                    Dim _Filtro_Idmaeedo As String = Generar_Filtro_IN(_Tbl_Idmaeedo, "", "Idmaeedo", False, False, "")
                    Lbl_Doc_Insert.Text = "Actualizando filtros..." ', fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate)
                    Consulta_Sql = My.Resources.Recursos_Inf_Ventas.Informe_Ventas_x_Perido_Nivel_Detalle_Cubo_Actualizacion3_Clasificaciones
                    Consulta_Sql = Replace(Consulta_Sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)
                    Consulta_Sql = Replace(Consulta_Sql, "(#Idmaeedo#)", _Filtro_Idmaeedo)
                    _Sql.Ej_consulta_IDU(Consulta_Sql)

                End If

                _Contador += 1

                If _Dias = 0 Then
                    _Dias = 1
                End If

                Progreso_Porc.Value = ((_Contador * 100) / _Dias)
                Progreso_Cont_Productos.Value = _Contador

                _Fecha = DateAdd(DateInterval.Day, 1, _Fecha)

                If _Cancelar Then
                    Exit For
                End If

            Next

            If Not _Cancelar Then

                _Filtros_Actualizados = True
                _Informe_Actualizado = True
                _Global_Informe_Venta_Datos_Actualizados = True

                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Mantención de informe",
                             MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

            Tiempo.Enabled = False
            _Cancelar = False
            Grupo_Fechas.Enabled = True
            Btn_Cancelar.Enabled = False
            Btn_Filtrar.Enabled = True
            Me.ControlBox = True

            Progreso_Porc.Value = 0
            Progreso_Cont_Productos.Value = 0

            Lbl_Estado.Text = "Estado..."
            Lbl_Tiempo.Text = String.Empty
            Lbl_Doc_Insert.Text = String.Empty
            Me.Refresh()

        End Try

        If _Filtros_Actualizados Then
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cancelar.Click
        _Cancelar = True
    End Sub

    Function Fx_Crear_Indice(_Nombre_Indice As String,
                             _Nombre_Tabla As String,
                             _Campos As String,
                             Optional _Unico As Boolean = False) As Boolean

        Dim _Unique As String

        If _Unico Then _Unique = "UNIQUE"

        Lbl_Estado.Text = "ACTUALIZANDO INDICES... " & _Nombre_Indice & "(" & _Campos & ")"
        System.Windows.Forms.Application.DoEvents()

        If Not _Sql.Fx_Exite_Indice(_Nombre_Indice) Then
            Consulta_Sql = "CREATE " & _Unique & " INDEX " & _Nombre_Indice & " ON " & _Nombre_Tabla & " (" & _Campos & ")"
            _Sql.Ej_consulta_IDU(Consulta_Sql, False)
            If String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Return True
            End If
        End If

    End Function



End Class
