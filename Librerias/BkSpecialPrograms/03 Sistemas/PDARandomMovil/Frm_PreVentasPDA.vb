Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class Frm_PreVentasPDA

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Tbl_Preventas As DataTable
    Private _ProcessingActive As Boolean = False ' Flag para controlar si se está procesando

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

        ' NUEVO: Agregar evento para manejar el sorting y recargar iconos
        AddHandler Grilla.Sorted, AddressOf Grilla_Sorted
        AddHandler Grilla.DataBindingComplete, AddressOf Grilla_DataBindingComplete

        ' Configurar fechas por defecto: últimas 24 horas
        Dtp_Fecha_Emision_Hasta.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1) ' Hoy 23:59:59
        Dtp_Fecha_Emision_Desde.Value = DateTime.Now.Date.AddDays(-1) ' Ayer 00:00:00

        ' Configurar ProgressBar - asume que se llama ProgressBarItem1
        Progress_Bar_Estado.Minimum = 0
        Progress_Bar_Estado.Maximum = 100
        Progress_Bar_Estado.Value = 0
        Progress_Bar_Estado.Visible = False
        Progress_Bar_Estado.Refresh()


        ' Configurar Label de estado - asume que se llama LblEstadoProceso
        Lbl_Progress_B.Text = ""
        Lbl_Progress_B.Visible = False
        Lbl_Progress_B.Refresh()


        Sb_Actualizar_Grilla()

    End Sub

    ' NUEVO: Evento que se dispara cuando se completa el data binding
    Private Sub Grilla_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles Grilla.DataBindingComplete
        ' Recargar iconos después de que se complete el binding
        Sb_Cargar_Iconos_Estado()
    End Sub

    ' NUEVO: Evento que se dispara cuando se hace sorting
    Private Sub Grilla_Sorted(sender As Object, e As EventArgs)
        ' Recargar iconos después del sorting
        Sb_Cargar_Iconos_Estado()
    End Sub

    Sub Sb_Actualizar_Grilla()

        ' Verificar si se está procesando
        If _ProcessingActive Then
            Return
        End If

        ' ============================================
        ' VALIDACIÓN 1: Importar nuevas pre-ventas desde PDAENCA
        ' ============================================
        Consulta_sql = "Select Pda.NUDO, Pda. ENDO, Pda.SUENDO, Ent.NOKOEN, Pda.EMPRESA, Pda.SUDO,Pda.KOFUDO, GETDATE()," &
               " Pda.FEEMDO, Pda.VANEDO, Pda.VAIVDO, Pda.VABRDO, Pda.LINEAS, Pda.IDPDAENCA" & vbCrLf &
               "From PDAENCA Pda WITH (NOLOCK)" & vbCrLf &
               "Left Join MAEEN Ent ON Pda. ENDO = Ent.KOEN AND Pda.SUENDO = Ent.SUEN" & vbCrLf &
               "Where Pda.VALIDO = 'S' And Pda. EMPRESA = '" & Mod_Empresa & "'"
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

-- Actualizar campo VALIDO a 'B' para los registros traspasados
Update PDAENCA
Set VALIDO = 'B'
Where IDPDAENCA In {_Filtro_Pdaenca}"
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        End If

        ' ============================================
        ' VALIDACIÓN 2: Actualizar IDMAEEDO desde permisos remotos aprobados
        ' ============================================
        Consulta_sql = $"UPDATE Pda
SET Pda.Idmaeedo = Rm.Idmaeedo,
    Pda.Estado = 'NVVGenerada'
FROM {_Global_BaseBk}Zw_Pda2NVV Pda
LEFT JOIN {_Global_BaseBk}Zw_Remotas_En_Cadena_01_Enc Enc 
    ON Enc.Id_Enc = Pda.RCadena_Id_Enc
LEFT JOIN {_Global_BaseBk}Zw_Remotas Rm 
    ON Rm. RCadena_Id_Enc = Enc.Id_Enc
WHERE
    (
        (Pda.Estado = 'NVVGenerada' AND Enc.Estado IS NULL)
        OR
        (Pda.Estado = 'SolPermiso' AND Enc.Estado = 'A')
    )
    AND Pda.Idmaeedo = 0
    AND Rm.Idmaeedo <> 0"

        Dim _FilasActualizadas As Integer = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        ' Opcional: Mostrar mensaje si se actualizaron registros
        If _FilasActualizadas > 0 Then
            MessageBoxEx.Show(Me, $"Se actualizaron {_FilasActualizadas} registros con IDMAEEDO desde permisos remotos.",
                         "Sincronización", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ' ============================================
        ' PREPARAR CONSULTA PRINCIPAL DE LA GRILLA
        ' ============================================
        Dim _Estado As String
        Dim _EstadosEnc As String
        Dim _Tbas = Super_TabS.SelectedTab

        ' Mostrar botones según el tab seleccionado
        Btn_Procesar.Visible = (_Tbas.Name = "Tab_Pendientes")
        Chk_Marcar_Todas.Visible = (_Tbas.Name = "Tab_Pendientes")
        Bar2.RecalcLayout()
        Bar2.Refresh()

        ' Obtener las fechas siempre normalizadas
        Dim _FechaDesde As DateTime = Dtp_Fecha_Emision_Desde.Value.Date ' Siempre 00:00:00
        Dim _FechaHasta As DateTime = Dtp_Fecha_Emision_Hasta.Value.Date.AddDays(1).AddSeconds(-1) ' Siempre 23:59:59

        ' Formatear las fechas para SQL Server
        Dim _FechaDesdeStr As String = _FechaDesde.ToString("yyyyMMdd HH:mm:ss")
        Dim _FechaHastaStr As String = _FechaHasta.ToString("yyyyMMdd HH:mm:ss")

        ' Construir la consulta 
        Consulta_sql = "Select Cast(0 As Bit) As 'Chk', " & vbCrLf &
               "ISNULL(Enc.Estado, 'M') As 'EstadoEnc', " & vbCrLf &
               "Pda.*, " & vbCrLf &
               "Isnull(Edo. TIDO,'') As 'Tido', " & vbCrLf &
               "Isnull(Edo. NUDO,'') As 'Nudo', " & vbCrLf &
               "ISNULL(Conteo.CantidadPermisos, 0) AS CantidadPermisos" & vbCrLf &
               "From " & _Global_BaseBk & "Zw_Pda2NVV Pda" & vbCrLf &
               "Left Join MAEEDO Edo On Edo.IDMAEEDO = Pda. Idmaeedo" & vbCrLf &
               "Left Join " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc Enc On Enc.Id_Enc = Pda.RCadena_Id_Enc" & vbCrLf &
               "LEFT JOIN (" & vbCrLf &
               "    SELECT Id_Enc, COUNT(*) AS CantidadPermisos" & vbCrLf &
               "    FROM " & _Global_BaseBk & "[Zw_Remotas_En_Cadena_02_Det]" & vbCrLf &
               "    GROUP BY Id_Enc" & vbCrLf &
               ") Conteo ON Conteo.Id_Enc = Pda.RCadena_Id_Enc" & vbCrLf &
               "Where Pda.FechaEmision >= '" & _FechaDesdeStr & "' And Pda.FechaEmision <= '" & _FechaHastaStr & "'"

        ' Agregar condición específica según el tab
        Select Case _Tbas.Name
            Case "Tab_Pendientes"
                Consulta_sql &= vbCrLf & "AND Pda.Estado = 'Pendiente' OR Pda.Estado='Error'"
                GroupPanel1.Text = "Pre-ventas pendientes de procesar"
            Case "Tab_NvvGeneradas"
                ' NVVGenerada con NULL O SolPermiso con A
                Consulta_sql &= vbCrLf & "AND ((Pda.Estado = 'NVVGenerada' AND Enc.Estado IS NULL) OR (Pda.Estado = 'NVVGenerada' AND Enc.Estado = 'A'))"
                GroupPanel1.Text = "Notas de venta generadas"
            Case "Tab_SolPermiso"
                ' Solo SolPermiso con NULL o con '' o con 'R'
                Consulta_sql &= vbCrLf & "AND Pda.Estado = 'SolPermiso' And (Enc.Estado IN ('', 'R') OR Enc.Estado IS NULL)"
                GroupPanel1.Text = "Solicitudes de permiso pendientes"
        End Select

        _Tbl_Preventas = _Sql.Fx_Get_DataTable(Consulta_sql)

        ' ============================================
        ' CONFIGURACIÓN DE LA GRILLA
        ' ============================================
        With Grilla
            .DataSource = _Tbl_Preventas
            OcultarEncabezadoGrilla(Grilla)

            ' Agregar columna de imagen si no existe
            If Not .Columns.Contains("IconoEstado") Then
                Dim colIcono As New DataGridViewImageColumn()
                colIcono.Name = "IconoEstado"
                colIcono.HeaderText = "Est."
                colIcono.Width = 30
                colIcono.ReadOnly = True
                .Columns.Add(colIcono)
            End If

            ' Agregar columna de imagen EstadoNVV si no existe
            If Not .Columns.Contains("IconoEstado2") Then
                Dim colIcono As New DataGridViewImageColumn()
                colIcono.Name = "IconoEstado2"
                colIcono.HeaderText = "Est."
                colIcono.Width = 30
                colIcono.ReadOnly = True
                .Columns.Add(colIcono)
            End If

            Dim _DisplayIndex = 0



            ' Columna de Icono Estado
            .Columns("IconoEstado").Visible = Not (_Tbas.Name = "Tab_Pendientes")
            .Columns("IconoEstado").HeaderText = "Est."
            .Columns("IconoEstado").ToolTipText = "Estado del documento"
            .Columns("IconoEstado").Width = 30
            .Columns("IconoEstado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ' Checkbox de selección
            .Columns("Chk").Visible = (_Tbas.Name = "Tab_Pendientes")
            .Columns("Chk").HeaderText = "Sel."
            .Columns("Chk").ToolTipText = "Selección"
            .Columns("Chk").Width = 30
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ' Columna de Icono Estado NVV
            .Columns("IconoEstado2").Visible = (_Tbas.Name = "Tab_Pendientes")
            .Columns("IconoEstado2").HeaderText = "Est."
            .Columns("IconoEstado2").ToolTipText = "Estado de NVV"
            .Columns("IconoEstado2").Width = 30
            .Columns("IconoEstado2").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ' Ocultar columna de texto del estado
            .Columns("EstadoEnc").Visible = False

            ' Vendedor
            .Columns("CodFuncionario").Visible = True
            .Columns("CodFuncionario").HeaderText = "Ven"
            .Columns("CodFuncionario").ToolTipText = "Vendedor"
            .Columns("CodFuncionario").Width = 30
            .Columns("CodFuncionario").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ' Sucursal
            .Columns("Sucursal").Visible = True
            .Columns("Sucursal").HeaderText = "Suc"
            .Columns("Sucursal").Width = 30
            .Columns("Sucursal").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ' Número
            .Columns("Numero").Visible = True
            .Columns("Numero").HeaderText = "Número"
            .Columns("Numero").Width = 80
            .Columns("Numero").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ' Fecha Emisión
            .Columns("FechaEmision").Visible = True
            .Columns("FechaEmision").HeaderText = "Fecha"
            .Columns("FechaEmision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaEmision").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaEmision").Width = 70
            .Columns("FechaEmision").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ' Código Entidad
            .Columns("CodEntidad").Visible = True
            .Columns("CodEntidad").HeaderText = "Entidad"
            .Columns("CodEntidad").Width = 90
            .Columns("CodEntidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ' Sucursal Entidad
            .Columns("CodSucEntidad").Visible = True
            .Columns("CodSucEntidad").HeaderText = "Suc"
            .Columns("CodSucEntidad").ToolTipText = "Sucursal de la entidad"
            .Columns("CodSucEntidad").Width = 45
            .Columns("CodSucEntidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ' Nombre Entidad
            .Columns("Nombre_Entidad").Visible = True
            .Columns("Nombre_Entidad").HeaderText = "Razón Social"
            .Columns("Nombre_Entidad").Width = 300
            .Columns("Nombre_Entidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ' Bruto
            .Columns("Bruto").Visible = True
            .Columns("Bruto").HeaderText = "Total Bruto"
            .Columns("Bruto").Width = 100
            .Columns("Bruto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Bruto").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Bruto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ' Líneas
            .Columns("Lineas").Visible = True
            .Columns("Lineas").HeaderText = "Ítems"
            .Columns("Lineas").Width = 50
            .Columns("Lineas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Lineas").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ' Cantidad Permisos
            .Columns("CantidadPermisos").Visible = (_Tbas.Name = "Tab_SolPermiso")
            .Columns("CantidadPermisos").HeaderText = "Cant. Perm."
            .Columns("CantidadPermisos").ToolTipText = "Cantidad de permisos necesarios"
            .Columns("CantidadPermisos").Width = 60
            .Columns("CantidadPermisos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantidadPermisos").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ' Tipo Documento (solo en NVV Generadas)
            .Columns("Tido").Visible = (_Tbas.Name = "Tab_NvvGeneradas")
            .Columns("Tido").HeaderText = "TD"
            .Columns("Tido").Width = 30
            .Columns("Tido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ' Número Documento (solo en NVV Generadas)
            .Columns("Nudo").Visible = (_Tbas.Name = "Tab_NvvGeneradas")
            .Columns("Nudo").HeaderText = "Número"
            .Columns("Nudo").Width = 80
            .Columns("Nudo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ' Número Cadena (solo en Sol Permiso) - Verificar si existe la columna
            If .Columns.Contains("Nro_RCadena") Then
                .Columns("Nro_RCadena").Visible = (_Tbas.Name = "Tab_SolPermiso")
                .Columns("Nro_RCadena").HeaderText = "RCadena"
                .Columns("Nro_RCadena").Width = 100
                .Columns("Nro_RCadena").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1
            End If

            ' Número Cadena (solo en Sol Permiso) - Verificar si existe la columna
            If .Columns.Contains("Observaciones") Then
                .Columns("Observaciones").Visible = (_Tbas.Name = "Tab_Pendientes")
                .Columns("Observaciones").HeaderText = "Observaciones"
                .Columns("Observaciones").Width = 100
                .Columns("Observaciones").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1
            End If

        End With

        ' Los iconos se cargarán automáticamente a través del evento DataBindingComplete
        Me.Cursor = Cursors.Default

    End Sub

    ' NUEVO: Método separado para cargar iconos basado en los datos de cada fila
    Private Sub Sb_Cargar_Iconos_Estado()
        Try
            ' Verificar que la grilla tenga datos
            If Grilla.Rows.Count = 0 Then
                Return
            End If

            ' Verificar que las columnas de iconos existan
            If Not Grilla.Columns.Contains("IconoEstado") Then
                Return
            End If

            ' Obtener el tab actual para determinar la lógica de iconos
            Dim _Tbas = Super_TabS.SelectedTab

            For Each _Fila As DataGridViewRow In Grilla.Rows
                If _Fila.IsNewRow Then Continue For

                Try
                    ' ============================================
                    ' ICONO PRINCIPAL (IconoEstado)
                    ' ============================================
                    Dim _Icono As Image = Nothing

                    ' Verificar IDMAEEDO para casos especiales
                    Dim _Idmaeedo As Integer = 0
                    If _Fila.Cells("Idmaeedo")?.Value IsNot Nothing AndAlso Not IsDBNull(_Fila.Cells("Idmaeedo").Value) Then
                        Integer.TryParse(_Fila.Cells("Idmaeedo").Value.ToString(), _Idmaeedo)
                    End If

                    ' Obtener el estado desde los datos de la fila
                    Dim _EstadoCell As String = If(_Fila.Cells("EstadoEnc")?.Value IsNot Nothing,
                                              _Fila.Cells("EstadoEnc").Value.ToString().Trim(), "M")

                    ' Resetear color de fondo
                    _Fila.DefaultCellStyle.BackColor = Color.Empty

                    ' Si estamos en Tab_NvvGeneradas y falta IDMAEEDO, mostrar alerta
                    If _Tbas.Name = "Tab_NvvGeneradas" AndAlso _Idmaeedo = 0 Then
                        _Icono = Imagenes_16x16.Images.Item("warning.png")
                        _Fila.DefaultCellStyle.BackColor = Color.LightYellow
                    Else
                        ' Seleccionar icono según el estado
                        Select Case _EstadoCell.ToUpper()
                            Case "M"
                                _Icono = Imagenes_16x16.Images.Item("tag_green.png")
                            Case "", "R" ' Espacio vacío o "r" minúscula
                                _Icono = Imagenes_16x16.Images.Item("clock-import.png")
                            Case "P"
                                _Icono = Imagenes_16x16.Images.Item("clock-info.png")
                            Case "A"
                                _Icono = Imagenes_16x16.Images.Item("ok.png")
                            Case "N"
                                _Icono = Imagenes_16x16.Images.Item("cancel.png")
                            Case "R" ' "R" mayúscula
                                _Icono = Imagenes_16x16.Images.Item("delete_button_error.png")
                            Case Else
                                _Icono = Imagenes_16x16.Images.Item("clock.png")
                        End Select
                    End If

                    ' Asignar el icono principal
                    If Grilla.Columns.Contains("IconoEstado") AndAlso _Fila.Cells("IconoEstado") IsNot Nothing Then
                        _Fila.Cells("IconoEstado").Value = _Icono
                    End If

                    ' ============================================
                    ' ICONO SECUNDARIO (IconoEstado2) - Solo en Tab_Pendientes
                    ' ============================================
                    If _Tbas.Name = "Tab_Pendientes" AndAlso Grilla.Columns.Contains("IconoEstado2") Then

                        Dim _IconoEstadoNVV As Image = Nothing

                        ' Obtener el estado de la NVV
                        Dim _EstadoNVV As String = ""
                        If _Fila.Cells("Estado")?.Value IsNot Nothing AndAlso Not IsDBNull(_Fila.Cells("Estado").Value) Then
                            _EstadoNVV = _Fila.Cells("Estado").Value.ToString().Trim()
                        End If

                        Select Case _EstadoNVV.ToUpper()
                            Case "PENDIENTE"
                                _IconoEstadoNVV = Imagenes_16x16.Images.Item("clock.png")
                            Case "ERROR"
                                _IconoEstadoNVV = Imagenes_16x16.Images.Item("cancel.png")
                                _Fila.DefaultCellStyle.BackColor = Color.LightCoral ' Color para errores
                            Case "NVVGENERADA"
                                _IconoEstadoNVV = Imagenes_16x16.Images.Item("ok.png")
                            Case "SOLPERMISO"
                                _IconoEstadoNVV = Imagenes_16x16.Images.Item("clock-info.png")
                            Case Else
                                _IconoEstadoNVV = Imagenes_16x16.Images.Item("help.png")
                        End Select

                        ' Asignar el icono secundario
                        If _Fila.Cells("IconoEstado2") IsNot Nothing Then
                            _Fila.Cells("IconoEstado2").Value = _IconoEstadoNVV
                        End If
                    End If

                Catch ex As Exception
                    ' Si hay error en esta fila específica, continuar con la siguiente
                    System.Diagnostics.Debug.WriteLine($"Error al cargar icono en fila: {ex.Message}")
                    Continue For
                End Try
            Next

        Catch ex As Exception
            ' Error general al cargar iconos
            System.Diagnostics.Debug.WriteLine($"Error general al cargar iconos: {ex.Message}")
        End Try
    End Sub
    ' PSEUDOCÓDIGO (detalle de los pasos a implementar):
    ' 1) Verificar que el índice de fila (e. RowIndex) sea válido (>= 0). 
    ' 2) Obtener el DataBoundItem de la fila: TryCast(Grilla. Rows(e.RowIndex). DataBoundItem, DataRowView). 
    ' 3) Si se obtiene un DataRowView, extraer la DataRow con . Row.
    ' 4) Si DataRowView es Nothing, intentar obtener la fila desde _Tbl_Preventas usando el índice (fallback).
    ' 5) Usar la DataRow obtenida para leer columnas o para pasarla a la clase Cl_PDARandomMovil.
    ' 6) Manejar nulos/DBNull y casos en que la fila no exista. 
    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        ' Validar que sea una fila válida (no el encabezado)
        If e.RowIndex < 0 Then Return

        ' No permitir doble clic durante procesamiento
        If _ProcessingActive Then Return

        Dim _Fila As DataGridViewRow = Grilla.Rows(e.RowIndex)

        ' Validar que la celda Id exista y tenga valor
        If _Fila.Cells("Id") Is Nothing OrElse IsDBNull(_Fila.Cells("Id").Value) Then
            MessageBoxEx.Show("No se pudo obtener el ID del registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim _Id As Integer = Convert.ToInt32(_Fila.Cells("Id").Value)

        ' Comportamiento según la pestaña seleccionada
        Select Case Super_TabS.SelectedTab.Name
            Case "Tab_Pendientes"
            'Ejecutar el proceso de validación y creación de NVV

            Case "Tab_NvvGeneradas"
                'Validar que tenga IDMAEEDO antes de mostrar
                If _Fila.Cells("Idmaeedo") Is Nothing OrElse
               IsDBNull(_Fila.Cells("Idmaeedo").Value) OrElse
               Convert.ToInt32(_Fila.Cells("Idmaeedo").Value) = 0 Then

                    MessageBoxEx.Show(Me, "Este documento aún no tiene una Nota de Venta asociada." & vbCrLf &
                                 "El documento está en proceso de sincronización.",
                                 "Sin documento asociado",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
                    Return
                End If

                'Mostrar el detalle de la NVV generada
                Sb_Mostrar_Detalle_NVV(_Fila)

            Case "Tab_SolPermiso"
                'Mostrar permisos solicitados
                Sb_Mostrar_Permisos(_Fila)
        End Select
    End Sub

    Private Sub Sb_Mostrar_Permisos(_Fila As DataGridViewRow)

        Dim _Id_Enc = _Fila.Cells("RCadena_Id_Enc").Value

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc Where Id_Enc = " & _Id_Enc
        Dim _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Nro_RCadena = _Row.Item("Nro_RCadena").ToString.Trim
        Dim _CodEntidad = _Row.Item("CodEntidad").ToString.Trim
        Dim _Nombre_Entidad = _Row.Item("Nombre_Entidad").ToString.Trim
        Dim _Tido = _Row.Item("Tido").ToString.Trim

        Dim Fm As New Frm_Cadenas_Remotas_Det(_Row)
        Fm.Text = "Solicitud Nro: " & _Nro_RCadena & ", " & _CodEntidad & " - " & _Nombre_Entidad
        Fm.Btn_Anular_Solicitud.Visible = False
        Fm.Btn_Eliminar_Y_Reciclar.Visible = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Sb_Procesar_Preventa_Pendiente(_Id As Integer)

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Cl_PDARandomMovil As New Cl_PDARandomMovil
        Dim _Zw_Pda2NVV As New Zw_Pda2NVV

        _Mensaje = _Cl_PDARandomMovil.Fx_Llenar_Zw_Pda2NVV(_Id)

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(_Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        _Zw_Pda2NVV = _Mensaje.Tag

        _Mensaje = _Cl_PDARandomMovil.Fx_Crear_NVV_PDARandomMOVIL(_Zw_Pda2NVV, Mod_Modalidad)

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(_Mensaje.Mensaje, "Error al crear NVV", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBoxEx.Show("Nota de venta creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        _Cl_PDARandomMovil.Fx_Actualizar_Estado_Zw_Pda2NVV(_Zw_Pda2NVV)
        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Sb_Mostrar_Detalle_NVV(_Fila As DataGridViewRow)
        Try
            ' Obtener el IDMAEEDO (ya validado en el método anterior)
            Dim _Idmaeedo As Integer = Convert.ToInt32(_Fila.Cells("Idmaeedo").Value)

            ' Validar permisos del funcionario
            Dim _Msj As LsValiciones.Mensajes = Fx_FuncionarioPuedeVerDocumentoGrupo(_Idmaeedo, FUNCIONARIO)
            If Not _Msj.EsCorrecto Then
                MessageBoxEx.Show(Me, _Msj.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            ' Abrir el formulario de visualización del documento
            Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Catch ex As Exception
            MessageBoxEx.Show("Error al intentar mostrar el detalle: " & ex.Message,
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        ' No permitir actualizar durante procesamiento
        If _ProcessingActive Then Return
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Chk_Marcar_Todas_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Marcar_Todas.CheckedChanged
        ' No permitir cambios durante procesamiento
        If _ProcessingActive Then Return

        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Chk").Value = Chk_Marcar_Todas.Checked
        Next

    End Sub

    Private Sub Grilla_MouseUp(sender As Object, e As MouseEventArgs) Handles Grilla.MouseUp
        ' No permitir edición durante procesamiento
        If _ProcessingActive Then Return
        Grilla.EndEdit()
    End Sub

    Private Sub Btn_Procesar_Click(sender As Object, e As EventArgs) Handles Btn_Procesar.Click

        ' Verificar si ya se está procesando
        If _ProcessingActive Then
            MessageBoxEx.Show(Me, "Ya se está ejecutando un proceso.  Por favor espere a que termine.",
                             "Proceso en ejecución", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Asegurar que la edición en la grilla quede comprometida
        Try
            Grilla.EndEdit()
        Catch ex As Exception
            ' Ignorar si falla EndEdit por cualquier motivo
        End Try

        Dim haySeleccion As Boolean = False
        Dim preventasSeleccionadas As New List(Of Integer)

        ' Verificar selecciones y obtener IDs
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
                    preventasSeleccionadas.Add(Convert.ToInt32(_Fila.Cells("Id").Value))
                End If
            Catch ex As Exception
                ' Si CBool falla intentar interpretar como entero (1/0) o como texto
                Try
                    Dim _intVal As Integer = Convert.ToInt32(_Valor)
                    If _intVal <> 0 Then
                        haySeleccion = True
                        preventasSeleccionadas.Add(Convert.ToInt32(_Fila.Cells("Id").Value))
                    End If
                Catch
                    Dim _strVal As String = Convert.ToString(_Valor).ToLower().Trim()
                    If _strVal = "true" OrElse _strVal = "1" Then
                        haySeleccion = True
                        preventasSeleccionadas.Add(Convert.ToInt32(_Fila.Cells("Id").Value))
                    End If
                End Try
            End Try

        Next

        If Not haySeleccion Then
            MessageBoxEx.Show(Me, "No hay ninguna pre-venta seleccionada.  Marque al menos una para procesar.",
                             "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        ' Confirmación antes de procesar
        Dim cantidadSeleccionadas As Integer = preventasSeleccionadas.Count
        Dim resultado As DialogResult = MessageBoxEx.Show(Me,
            $"¿Está seguro que desea procesar {cantidadSeleccionadas} pre-venta(s) seleccionada(s)?" & vbCrLf & vbCrLf &
            "Esta acción generará las Notas de Venta correspondientes y no se puede deshacer.",
            "Confirmación de procesamiento",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2)

        If resultado <> DialogResult.Yes Then
            Return
        End If

        ' Iniciar procesamiento
        Sb_Iniciar_Procesamiento_Preventas(preventasSeleccionadas)

    End Sub

    Private Sub Sb_Iniciar_Procesamiento_Preventas(preventasIds As List(Of Integer))

        ' Activar flag de procesamiento
        _ProcessingActive = True

        ' Deshabilitar formulario completo
        Me.Enabled = False



        ' Buscar ProgressBar - asumiendo que se llama ProgressBarItem1 o similar

        Progress_Bar_Estado.Minimum = 0
        Progress_Bar_Estado.Maximum = preventasIds.Count
        Progress_Bar_Estado.Value = 0
        Progress_Bar_Estado.Visible = True
        Progress_Bar_Estado.Refresh()


        ' Buscar Label de estado - asumiendo que contiene "Estado" en el nombre

        Lbl_Progress_B.Text = "Preparando procesamiento..."
        Lbl_Progress_B.Visible = True
        Lbl_Progress_B.Refresh()


        ' Forzar actualización visual
        Me.Update()
        Application.DoEvents()
        System.Threading.Thread.Sleep(200) ' NUEVO - Pequeña pausa para asegurar que se vea

        Dim _Ls_Mensajes As New List(Of LsValiciones.Mensajes)
        Dim contador As Integer = 0

        Me.Refresh()

        Try

            For Each _Id As Integer In preventasIds

                ' Actualizar estado
                If Lbl_Progress_B IsNot Nothing Then
                    Lbl_Progress_B.Text = $"Procesando Preventa Nro {_Id} ({contador + 1} de {preventasIds.Count})"
                    Lbl_Progress_B.Refresh()
                End If
                ' Forzar actualización visual
                Me.Update()
                Application.DoEvents()

                Dim _Mensaje As New LsValiciones.Mensajes

                ' Crear instancia de la clase y pasar datos según su API
                Dim _Cl_PDARandomMovil As New Cl_PDARandomMovil
                Dim _Zw_Pda2NVV As New Zw_Pda2NVV

                _Mensaje = _Cl_PDARandomMovil.Fx_Llenar_Zw_Pda2NVV(_Id)

                If Not _Mensaje.EsCorrecto Then
                    ' Agregar mensaje de error pero continuar con los siguientes
                    _Ls_Mensajes.Add(_Mensaje)
                    Continue For
                End If

                _Zw_Pda2NVV = _Mensaje.Tag

                _Mensaje = _Cl_PDARandomMovil.Fx_Crear_NVV_PDARandomMOVIL(_Zw_Pda2NVV, Mod_Modalidad)

                If _Mensaje.HuboOtroError Then
                    _Zw_Pda2NVV.Estado = "Error"
                    _Zw_Pda2NVV.Observaciones = _Mensaje.Mensaje
                End If

                _Cl_PDARandomMovil.Fx_Actualizar_Estado_Zw_Pda2NVV(_Zw_Pda2NVV)
                _Ls_Mensajes.Add(_Mensaje)

                ' Pequeña pausa para evitar sobrecarga
                'System.Threading.Thread.Sleep(100)

                contador += 1



                ' Actualizar ProgressBar
                If Progress_Bar_Estado IsNot Nothing Then
                    Progress_Bar_Estado.Value = contador
                    Progress_Bar_Estado.Refresh()
                End If

                ' Forzar actualización visual
                Me.Update()
                Application.DoEvents()

            Next

        Catch ex As Exception
            ' En caso de error general durante el procesamiento
            MessageBoxEx.Show(Me, $"Error durante el procesamiento: {ex.Message}",
                             "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            ' Finalizar procesamiento
            Sb_Finalizar_Procesamiento(Progress_Bar_Estado, Lbl_Progress_B)

            ' Mostrar resultados
            Dim ListaQr As LsValiciones.Mensajes = _Ls_Mensajes.FirstOrDefault(Function(p) p.EsCorrecto = False)

            If Not IsNothing(ListaQr) Then
                MessageBoxEx.Show(Me, "Hay documentos con problemas.  Revise el detalle en la ventana de validaciones.",
                                 "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            ' Mostrar ventana de resultados
            Dim Fmv As New Frm_Validaciones
            Fmv.ListaMensajes = _Ls_Mensajes
            Fmv.ShowDialog(Me)
            Fmv.Dispose()

            ' Actualizar grilla
            Sb_Actualizar_Grilla()

        End Try

    End Sub

    Private Sub Sb_Finalizar_Procesamiento(progressBar As ProgressBarItem, lblEstado As LabelItem)

        Try
            ' Ocultar ProgressBar
            If progressBar IsNot Nothing Then
                progressBar.Visible = False
                progressBar.Value = 0
            End If

            ' Ocultar Label de estado
            If lblEstado IsNot Nothing Then
                lblEstado.Visible = False
                lblEstado.Text = ""
            End If

            ' Rehabilitar formulario
            Me.Enabled = True

            ' Desactivar flag de procesamiento
            _ProcessingActive = False

            ' Forzar actualización visual
            Me.Update()
            Application.DoEvents()

        Catch ex As Exception
            ' En caso de error al finalizar, al menos asegurar que se reactive el formulario
            Me.Enabled = True
            _ProcessingActive = False
        End Try

    End Sub

End Class
