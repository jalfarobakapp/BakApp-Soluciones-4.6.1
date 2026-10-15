Imports System.IO
Imports BkSpecialPrograms
Imports BkSpecialPrograms.Frm_Filtro_Especial_Informes
Imports BkSpecialPrograms.LsValiciones
Imports DevComponents.DotNetBar
Imports Newtonsoft.Json

Public Class Frm_Configuracion

#Region "Declaraciones y Propiedades"
    Dim _SqlRandom As Class_SQL
    Private _Cl_ConfiguracionLocal As New Cl_ConfiguracionLocal
    Private _BindingSource As New BindingSource()
    Private _BindingSourceRelaciones As New BindingSource()
    Public FuncionarioNom As String
    Dim Funcionario As String



    Public Property Ls_Programaciones As New List(Of Cl_NewProgramacion)
    Public Property Programacion As New Cl_NewProgramacion
#End Region

#Region "Inicialización"
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Frm_Conexiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _Mensaje = _Cl_ConfiguracionLocal.Fx_LeerArchivoConexionJson(False)
        SuperTabControl1.SelectedTab = SuperTabItem2

        If Not _Mensaje.EsCorrecto OrElse _Mensaje.Id = 0 Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Arr_Relacionado(,) As String = {{"", ""}, {"BLV", "BOLETA"}, {"FCV", "FACTURA"}}
        Sb_Llenar_Combos(_Arr_Relacionado, Cmb_DocEmitir)
        Cmb_DocEmitir.SelectedValue = ""
        TxtBakApp.Text = _Cl_ConfiguracionLocal.Configuracion.Global_BaseBk

        With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(0)
            .NombreConexion = String.Empty
            Txt_Rd_Host.Text = .Host
            Txt_Rd_Puerto.Text = .Puerto
            Txt_Rd_Usuario.Text = .Usuario
            Txt_Rd_Password.Text = .Password
            Txt_Rd_Basededatos.Text = .Basededatos
            Cadena_ConexionSQL_Server = _Cl_ConfiguracionLocal.Fx_CadenaConexion(.Host, .Puerto, .Basededatos, .Usuario, .Password)
        End With

        Txt_Empresa.Tag = String.Empty
        Txt_Empresa.Text = String.Empty
        Empresas.Visible = False
        Equivalencia.Visible = False
        If Not String.IsNullOrEmpty(Cadena_ConexionSQL_Server) Then
            Ls_Programaciones = CargarProgramaciones("ConfHoras.json")
            If Ls_Programaciones Is Nothing Then Ls_Programaciones = New List(Of Cl_NewProgramacion)()
            _BindingSource.DataSource = Ls_Programaciones
            Empresas.Visible = True
            Equivalencia.Visible = True
            Dim _MensajeEntidades As LsValiciones.Mensajes = Fx_LeerArchivoEntidadesJson()

            If Not _MensajeEntidades.EsCorrecto Then
                MessageBoxEx.Show(Me, _MensajeEntidades.Mensaje, "Validación de Entidades", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ' Si falla, priorizamos llevar al usuario a la pestaña de entidades
                SuperTabControl1.SelectedTab = Empresas
            Else
                Dim dict As EntidadesDiccionario = CType(_MensajeEntidades.Tag, EntidadesDiccionario)

                ' Asignamos los objetos completos deserializados a las propiedades del formulario
                Frm_Sincronizador.Empresa01 = dict.Empresa01
                Frm_Sincronizador.Empresa02 = dict.Empresa02
                Txt_Empresa01.Text = Frm_Sincronizador.Empresa01.EntidadDeVenta.Rows(0).Item("Codigo").ToString.Trim & " - " & Frm_Sincronizador.Empresa01.EntidadDeVenta.Rows(0).Item("Descripcion").ToString.Trim
                Txt_Empresa02.Text = Frm_Sincronizador.Empresa02.EntidadDeVenta.Rows(0).Item("Codigo").ToString.Trim & " - " & Frm_Sincronizador.Empresa02.EntidadDeVenta.Rows(0).Item("Descripcion").ToString.Trim
                Dim _MensajeEntidades2 As LsValiciones.Mensajes = Fx_LeerArchivoEntidadesJsonfuncionario()
                If Not _MensajeEntidades2.EsCorrecto Then
                    MessageBoxEx.Show(Me, _MensajeEntidades2.Mensaje, "Validación de Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ' Si falla, priorizamos llevar al usuario a la pestaña de entidades
                    SuperTabControl1.SelectedTab = Empresas
                Else
                    Dim dict2 As EntidadesDiccionario = CType(_MensajeEntidades2.Tag, EntidadesDiccionario)
                    Frm_Sincronizador._Funcionario = dict2.Funcionario
                    FuncionarioNom = dict2.FuncionarioNom

                    Lbl_NombreF.Text = FuncionarioNom
                    Txt_Funcionario.Text = Frm_Sincronizador._Funcionario

                    FuncionarioNom = dict2.FuncionarioNom
                    Funcionario = dict2.Funcionario
                End If

            End If
            Sb_ActualizarGrilla()
        Else
            Empresas.Visible = False
            Equivalencia.Visible = False

        End If
        Sb_ActualizarGrillaRelaciones()
        Sb_Formato_Generico_Grilla(Grilla_Tareas, 30, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        AddHandler Grilla_Tareas.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        Sb_Formato_Generico_Grilla(Data_Equivalencia, 30, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        AddHandler Data_Equivalencia.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
    End Sub
#End Region


#Region "Grilla y Programación de Tareas"
    Private Sub Btn_Programacion_Click(sender As Object, e As EventArgs) Handles Btn_Programacion.Click
        configurarProgramacion(-1)
    End Sub

    Private Sub configurarProgramacion(Optional indexEdit As Integer = -1)
        Dim progActual = If(indexEdit >= 0, Ls_Programaciones(indexEdit), New Cl_NewProgramacion() With {.Validada = True})
        Dim validacionOk As Boolean = False

        Do
            Using Fm2 As New Frm_Demonio_ConfProgramacion(True, True, True, "")
                Fm2.Text = If(indexEdit >= 0, "Editar Programación de SincroStock", "Nueva Programación de SincroStock")
                Fm2.Programacion = progActual
                Fm2.ShowDialog(Me)

                If Fm2.Grabar Then
                    Dim mensajeError As String = Fx_ValidarProgramacion(Fm2.Programacion)

                    If String.IsNullOrEmpty(mensajeError) Then
                        If indexEdit >= 0 Then Ls_Programaciones(indexEdit) = Fm2.Programacion Else Ls_Programaciones.Add(Fm2.Programacion)
                        GuardarProgramaciones(Ls_Programaciones, "ConfHoras.json")
                        Sb_ActualizarGrilla()
                        validacionOk = True
                    Else
                        MessageBoxEx.Show(Me, mensajeError, "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        progActual = Fm2.Programacion
                    End If
                Else
                    validacionOk = True
                End If
            End Using
        Loop Until validacionOk
    End Sub

    Private Function Fx_ValidarProgramacion(prog As Cl_NewProgramacion) As String
        If String.IsNullOrWhiteSpace(prog.Nombre) Then Return "Debe ingresar un Nombre para la programación."
        If Not prog.FrecuDiaria AndAlso Not prog.FrecuSemanal Then Return "Debe seleccionar una frecuencia (Diaria o Semanal)."

        If prog.FrecuSemanal Then
            If Not (prog.Lunes OrElse prog.Martes OrElse prog.Miercoles OrElse prog.Jueves OrElse prog.Viernes OrElse prog.Sabado OrElse prog.Domingo) Then
                Return "Debe seleccionar al menos un día de la semana."
            End If
        End If

        If Not prog.SucedeUnaVez AndAlso Not prog.SucedeCada Then Return "Debe configurar a qué hora o cada cuánto tiempo sucede la tarea."

        If prog.SucedeCada AndAlso prog.IntervaloCada <= 0 Then Return "Debe configurar un intervalo mayor a 0 para las tareas recurrentes."

        Return String.Empty
    End Function

    Private Sub Sb_ActualizarGrilla()
        If Grilla_Tareas.Columns.Count = 0 Then
            Sb_FormatoGrilla()
            Grilla_Tareas.DataSource = _BindingSource
        End If
        _BindingSource.ResetBindings(False)
    End Sub

    Private Sub Sb_ActualizarGrillaRelaciones()
        Try
            ' 1. Instanciar la clase SQL con la cadena de conexión actual (si no está instanciada ya)
            If _SqlRandom Is Nothing Then
                _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
            End If

            ' 2. Definir tu consulta SQL
            ' IMPORTANTE: Reemplaza "NombreDeTuTabla" por el nombre real de tu tabla en la base de datos.
            ' Las columnas en el SELECT deben llamarse "Bodega1" y "Bodega2" para que coincidan 
            ' con el DataPropertyName que definiste en Sb_FormatoGrillaRelaciones.
            Dim Consulta_sql As String = $"select Empresa_A, Sucursal_A, Bodega_A, Empresa_B,Sucursal_B,Bodega_B from {Frm_Sincronizador._Global_BaseBk}Zw_InterStock_Equivalencia where Activo2 = 1 "

            ' 3. Ejecutar la consulta y obtener el DataTable
            ' (Se asume que tu Class_SQL tiene un método como Fx_Get_DataTable para traer datos)
            Dim Tbl_Relaciones As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

            ' 4. Configurar las columnas de la grilla si aún no se han creado
            If Data_Equivalencia.Columns.Count = 0 Then
                Sb_FormatoGrillaRelaciones()
            End If

            ' 5. Asignar los datos a la grilla
            Data_Equivalencia.DataSource = Tbl_Relaciones

        Catch ex As Exception
            MessageBoxEx.Show(Me, "Error al cargar las equivalencias desde la base de datos:" & vbCrLf & ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Sb_FormatoGrilla()
        Grilla_Tareas.AutoGenerateColumns = False
        Grilla_Tareas.Columns.Clear()

        Grilla_Tareas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Grilla_Tareas.RowTemplate.Height = 60

        Grilla_Tareas.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Nombre", .HeaderText = "Nombre Programación", .Name = "Col_Nombre", .ReadOnly = True, .Width = 200})
        Grilla_Tareas.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Resumen", .HeaderText = "Resumen", .Name = "Col_Resumen", .ReadOnly = True, .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill})

        Dim colBotonEditar As New DataGridViewImageColumn() With {
            .HeaderText = "Editar",
            .Name = "Col_BtnEditar",
            .ImageLayout = DataGridViewImageCellLayout.Zoom,
            .Width = 100,
            .Resizable = DataGridViewTriState.False
        }
        If AUX_btn.Image IsNot Nothing Then colBotonEditar.Image = AUX_btn.Image
        colBotonEditar.DefaultCellStyle.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Grilla_Tareas.Columns.Add(colBotonEditar)

        Dim colBotonEliminar As New DataGridViewImageColumn() With {
            .HeaderText = "Eliminar",
            .Name = "Col_BtnEliminar",
            .ImageLayout = DataGridViewImageCellLayout.Zoom,
            .Width = 100,
            .Resizable = DataGridViewTriState.False
        }
        If Btn_Eliminar_AUX.Image IsNot Nothing Then colBotonEliminar.Image = Btn_Eliminar_AUX.Image
        colBotonEliminar.DefaultCellStyle.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Grilla_Tareas.Columns.Add(colBotonEliminar)

        Grilla_Tareas.Columns.Add(New DataGridViewTextBoxColumn() With {
            .HeaderText = "",
            .Name = "Col_Margen",
            .ReadOnly = True,
            .Width = 20,
            .Resizable = DataGridViewTriState.False
        })
    End Sub
    Private Sub Sb_FormatoGrillaRelaciones()
        Data_Equivalencia.AutoGenerateColumns = False
        Data_Equivalencia.Columns.Clear()

        Data_Equivalencia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Data_Equivalencia.RowTemplate.Height = 25 ' Sugiero 25 para ver más filas, 60 es muy alto para datos planos.

        ' --- COLUMNAS DE LA EMPRESA A ---
        Data_Equivalencia.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Empresa_A",
            .HeaderText = "Empresa A",
            .Name = "Col_Empresa_A",
            .ReadOnly = True,
            .Width = 80
        })

        Data_Equivalencia.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Sucursal_A",
            .HeaderText = "Sucursal A",
            .Name = "Col_Sucursal_A",
            .ReadOnly = True,
            .Width = 80
        })

        Data_Equivalencia.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Bodega_A",
            .HeaderText = "Bodega A",
            .Name = "Col_Bodega_A",
            .ReadOnly = True,
            .Width = 120
        })

        ' --- COLUMNAS DE LA EMPRESA B ---
        Data_Equivalencia.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Empresa_B",
            .HeaderText = "Empresa B",
            .Name = "Col_Empresa_B",
            .ReadOnly = True,
            .Width = 80
        })

        Data_Equivalencia.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Sucursal_B",
            .HeaderText = "Sucursal B",
            .Name = "Col_Sucursal_B",
            .ReadOnly = True,
            .Width = 80
        })

        Data_Equivalencia.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Bodega_B",
            .HeaderText = "Bodega B",
            .Name = "Col_Bodega_B",
            .ReadOnly = True,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill ' Esta columna llenará el espacio restante
        })

        ' Columna final de margen (Opcional, la mantenemos como lo tenías)
        Data_Equivalencia.Columns.Add(New DataGridViewTextBoxColumn() With {
            .HeaderText = "",
            .Name = "Col_Margen",
            .ReadOnly = True,
            .Width = 20,
            .Resizable = DataGridViewTriState.False
        })
    End Sub

    Private Sub Grilla_Tareas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Tareas.CellContentClick
        If e.RowIndex >= 0 Then
            Dim nombreColumna As String = Grilla_Tareas.Columns(e.ColumnIndex).Name

            If nombreColumna = "Col_BtnEditar" Then
                configurarProgramacion(e.RowIndex)
            ElseIf nombreColumna = "Col_BtnEliminar" Then
                If MessageBoxEx.Show(Me, "¿Está seguro de que desea eliminar esta tarea de la programación?", "Eliminar Tarea", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Ls_Programaciones.RemoveAt(e.RowIndex)
                    GuardarProgramaciones(Ls_Programaciones, "ConfHoras.json")
                    Sb_ActualizarGrilla()
                End If
            End If
        End If
    End Sub
#End Region

#Region "Conexiones y Base de Datos"
    Private Sub Btn_ProbarConexionRd_Click(sender As Object, e As EventArgs) Handles Btn_ProbarConexionRd.Click
        If Fx_ProbarConexionRd() Then
            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(0)
                Cadena_ConexionSQL_Server = _Cl_ConfiguracionLocal.Fx_CadenaConexion(.Host, .Puerto, .Basededatos, .Usuario, .Password)
            End With
        Else
            Cadena_ConexionSQL_Server = String.Empty
        End If
    End Sub

    Function Fx_ProbarConexionRd() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False
            Dim _Cadena = _Cl_ConfiguracionLocal.Fx_CadenaConexion(Txt_Rd_Host.Text, Txt_Rd_Puerto.Text, Txt_Rd_Basededatos.Text, Txt_Rd_Usuario.Text, Txt_Rd_Password.Text)
            Dim _Mensaje = _Cl_ConfiguracionLocal.Fx_Conectar(_Cadena)

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, Fx_AjustarTexto(_Mensaje.Mensaje, 100), _Mensaje.Detalle & " (Base de datos RANDOM/BAKAPP)", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Rd_Host.Focus()
                Return False
            End If

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle & " Base de datos " & Txt_Rd_Basededatos.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            With _Cl_ConfiguracionLocal.Configuracion.Ls_Conexiones.Item(0)
                .NombreConexion = "RandomBakapp" : .Host = Txt_Rd_Host.Text : .Puerto = Txt_Rd_Puerto.Text
                .Usuario = Txt_Rd_Usuario.Text : .Password = Txt_Rd_Password.Text : .Basededatos = Txt_Rd_Basededatos.Text
            End With
        Finally
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try
        Return True
    End Function

    Function Fx_ProbarConexionBaseBakapp() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False
            Dim _Cadena = _Cl_ConfiguracionLocal.Fx_CadenaConexion(Txt_Rd_Host.Text, Txt_Rd_Puerto.Text, Txt_Rd_Basededatos.Text, Txt_Rd_Usuario.Text, Txt_Rd_Password.Text)
            Dim _Mensaje = _Cl_ConfiguracionLocal.Fx_ConfirmardbBakapp(TxtBakApp.Text, Txt_Rd_Usuario.Text, _Cadena)

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, Fx_AjustarTexto(_Mensaje.Mensaje, 100), _Mensaje.Detalle & " (Nombre de base de datos de BAKAPP)", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtBakApp.Focus()
                Return False
            End If

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle & " Base de datos " & Txt_Rd_Basededatos.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try
        Return True
    End Function

    Private Sub Conexion_TextChanged(sender As Object, e As EventArgs) Handles Txt_Rd_Host.TextChanged, Txt_Rd_Puerto.TextChanged, Txt_Rd_Usuario.TextChanged, Txt_Rd_Password.TextChanged, Txt_Rd_Basededatos.TextChanged, TxtBakApp.TextChanged
        If Empresas IsNot Nothing AndAlso Empresas.Visible Then
            Empresas.Visible = False
            Equivalencia.Visible = False
        End If
    End Sub
#End Region

#Region "Gestión de Entidades y JSON (Guardar/Cargar)"
    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click
        If String.IsNullOrEmpty(TxtBakApp.Text) Then
            MessageBoxEx.Show(Me, "Debe ingresar el nombre de la base de datos de BAKAPP", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TxtBakApp.Focus()
            Return
        End If

        If Not Fx_ProbarConexionRd() OrElse Not Fx_ProbarConexionBaseBakapp() Then Return

        _Cl_ConfiguracionLocal.Configuracion.Global_BaseBk = TxtBakApp.Text
        Dim _Mensaje = _Cl_ConfiguracionLocal.Fx_GrabarConexiones()

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        GuardarProgramaciones(Ls_Programaciones, "ConfHoras.json")

        If Not Empresas.Visible Then
            Empresas.Visible = True
            Equivalencia.Visible = True
            SuperTabControl1.SelectedTab = Empresas
            Sb_ActualizarGrillaRelaciones()
            Sb_Formato_Generico_Grilla(Data_Equivalencia, 30, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
            AddHandler Data_Equivalencia.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
            Return
        Else


            Sb_Guardar_Entidades_JSON()
        End If
        MessageBoxEx.Show(Me, "Configuraciones, tareas y conexiones guardadas exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Dispose()
    End Sub
    Function Fx_LeerArchivoEntidadesJsonfuncionario() As LsValiciones.Mensajes
        Dim _Mensaje As New LsValiciones.Mensajes

        Try
            Dim rutaArchivo As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Entidades.json")

            If Not File.Exists(rutaArchivo) Then
                _Mensaje.Detalle = "Falta archivo de configuración"
                Throw New System.Exception("Debe configurar la asignación de entidades (Compra y Venta).")
            End If

            Dim jsonString As String = File.ReadAllText(rutaArchivo)
            Dim miConfig As EntidadesDiccionario = JsonConvert.DeserializeObject(Of EntidadesDiccionario)(jsonString)

            ' Validamos exhaustivamente la nueva estructura jerárquica
            If miConfig.Empresa01 Is Nothing OrElse miConfig.Empresa02 Is Nothing OrElse
           miConfig.Empresa01.EntidadDeCompra Is Nothing OrElse miConfig.Empresa01.EntidadDeCompra.Rows.Count = 0 OrElse
           miConfig.Empresa01.EntidadDeVenta Is Nothing OrElse miConfig.Empresa01.EntidadDeVenta.Rows.Count = 0 OrElse
           miConfig.Empresa02.EntidadDeCompra Is Nothing OrElse miConfig.Empresa02.EntidadDeCompra.Rows.Count = 0 OrElse
           miConfig.Empresa02.EntidadDeVenta Is Nothing OrElse miConfig.Empresa02.EntidadDeVenta.Rows.Count = 0 OrElse
           miConfig.Empresa01.ModalidadOCC Is Nothing OrElse miConfig.Empresa01.ModalidadOCC.Rows.Count = 0 OrElse
           miConfig.Empresa01.ModalidadFCV Is Nothing OrElse miConfig.Empresa01.ModalidadFCV.Rows.Count = 0 OrElse
           miConfig.Empresa01.ModalidadNVV Is Nothing OrElse miConfig.Empresa01.ModalidadNVV.Rows.Count = 0 OrElse
           miConfig.Empresa01.ModalidadFCC Is Nothing OrElse miConfig.Empresa01.ModalidadFCC.Rows.Count = 0 OrElse
           miConfig.Empresa02.ModalidadOCC Is Nothing OrElse miConfig.Empresa02.ModalidadOCC.Rows.Count = 0 OrElse
           miConfig.Empresa02.ModalidadFCV Is Nothing OrElse miConfig.Empresa02.ModalidadFCV.Rows.Count = 0 OrElse
           miConfig.Empresa02.ModalidadNVV Is Nothing OrElse miConfig.Empresa02.ModalidadNVV.Rows.Count = 0 OrElse
           miConfig.Empresa02.ModalidadFCC Is Nothing OrElse miConfig.Empresa02.ModalidadFCC.Rows.Count = 0 Then

                _Mensaje.Detalle = "Datos incompletos"
                Throw New System.Exception("Faltan entidades o modalidades por configurar. Por favor, asigne las entidades correspondientes.")
            End If

            If miConfig.Funcionario Is Nothing OrElse String.IsNullOrEmpty(miConfig.Funcionario) Then
                _Mensaje.Detalle = "Funcionario no configurado"
                Throw New System.Exception("El funcionario no está configurado en el archivo de entidades. Por favor, configure el funcionario.")
            End If
            If miConfig.FuncionarioNom Is Nothing OrElse String.IsNullOrEmpty(miConfig.FuncionarioNom) Then
                _Mensaje.Detalle = "Nombre del funcionario no configurado"
                Throw New System.Exception("El nombre del funcionario no está configurado en el archivo de entidades. Por favor, configure el nombre del funcionario.")
            End If

            _Mensaje.Tag = miConfig
            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Entidades leídas correctamente"


        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Id = 0
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje
    End Function
    Function Fx_LeerArchivoEntidadesJson() As LsValiciones.Mensajes
        Dim _Mensaje As New LsValiciones.Mensajes

        Try
            Dim rutaArchivo As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Entidades.json")

            If Not File.Exists(rutaArchivo) Then
                _Mensaje.Detalle = "Falta archivo de configuración"
                Throw New System.Exception("Debe configurar la asignación de entidades (Compra y Venta).")
            End If

            Dim jsonString As String = File.ReadAllText(rutaArchivo)
            Dim miConfig As EntidadesDiccionario = JsonConvert.DeserializeObject(Of EntidadesDiccionario)(jsonString)

            ' Validamos exhaustivamente la nueva estructura jerárquica
            If miConfig.Empresa01 Is Nothing OrElse miConfig.Empresa02 Is Nothing OrElse
           miConfig.Empresa01.EntidadDeCompra Is Nothing OrElse miConfig.Empresa01.EntidadDeCompra.Rows.Count = 0 OrElse
           miConfig.Empresa01.EntidadDeVenta Is Nothing OrElse miConfig.Empresa01.EntidadDeVenta.Rows.Count = 0 OrElse
           miConfig.Empresa02.EntidadDeCompra Is Nothing OrElse miConfig.Empresa02.EntidadDeCompra.Rows.Count = 0 OrElse
           miConfig.Empresa02.EntidadDeVenta Is Nothing OrElse miConfig.Empresa02.EntidadDeVenta.Rows.Count = 0 OrElse
           miConfig.Empresa01.ModalidadOCC Is Nothing OrElse miConfig.Empresa01.ModalidadOCC.Rows.Count = 0 OrElse
           miConfig.Empresa01.ModalidadFCV Is Nothing OrElse miConfig.Empresa01.ModalidadFCV.Rows.Count = 0 OrElse
           miConfig.Empresa01.ModalidadNVV Is Nothing OrElse miConfig.Empresa01.ModalidadNVV.Rows.Count = 0 OrElse
           miConfig.Empresa01.ModalidadFCC Is Nothing OrElse miConfig.Empresa01.ModalidadFCC.Rows.Count = 0 OrElse
           miConfig.Empresa02.ModalidadOCC Is Nothing OrElse miConfig.Empresa02.ModalidadOCC.Rows.Count = 0 OrElse
           miConfig.Empresa02.ModalidadFCV Is Nothing OrElse miConfig.Empresa02.ModalidadFCV.Rows.Count = 0 OrElse
           miConfig.Empresa02.ModalidadNVV Is Nothing OrElse miConfig.Empresa02.ModalidadNVV.Rows.Count = 0 OrElse
           miConfig.Empresa02.ModalidadFCC Is Nothing OrElse miConfig.Empresa02.ModalidadFCC.Rows.Count = 0 Then

                _Mensaje.Detalle = "Datos incompletos"
                Throw New System.Exception("Faltan entidades o modalidades por configurar. Por favor, asigne las entidades correspondientes.")
            End If



            _Mensaje.Tag = miConfig
            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Entidades leídas correctamente"


        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Id = 0
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje
    End Function

    Private Sub Sb_Guardar_Entidades_JSON()
        Try
            Dim miConfig As New EntidadesDiccionario With {
            .Empresa01 = Frm_Sincronizador.Empresa01,
            .Empresa02 = Frm_Sincronizador.Empresa02,
            .Funcionario = Funcionario,
            .FuncionarioNom = FuncionarioNom
        }

            Dim jsonString As String = JsonConvert.SerializeObject(miConfig, Formatting.Indented)
            Dim rutaArchivo As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Entidades.json")
            File.WriteAllText(rutaArchivo, jsonString)
        Catch ex As Exception
            ' Manejo silencioso o puedes registrar el error en un log si lo requieres
        End Try
    End Sub

    Public Shared Sub GuardarProgramaciones(programaciones As List(Of Cl_NewProgramacion), rutaArchivo As String)
        Try
            File.WriteAllText(rutaArchivo, JsonConvert.SerializeObject(programaciones, Formatting.Indented))
        Catch ex As Exception
            Throw New Exception("Error al guardar el archivo JSON: " & ex.Message)
        End Try
    End Sub

    Public Shared Function CargarProgramaciones(rutaArchivo As String) As List(Of Cl_NewProgramacion)
        Try
            Return If(File.Exists(rutaArchivo), JsonConvert.DeserializeObject(Of List(Of Cl_NewProgramacion))(File.ReadAllText(rutaArchivo)), New List(Of Cl_NewProgramacion)())
        Catch ex As Exception
            Throw New Exception("Error al cargar el archivo JSON: " & ex.Message)
        End Try
    End Function
#End Region

#Region "Eventos sin uso"
    Private Sub Bar1_ItemClick(sender As Object, e As EventArgs) Handles Bar1.ItemClick

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub SuperTabControlPanel6_Click(sender As Object, e As EventArgs) Handles SuperTabControlPanel6.Click

    End Sub

    Private Sub LabelX8_Click(sender As Object, e As EventArgs) Handles LabelX8.Click

    End Sub



    Private Sub Txt_Empresa01_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Empresa01.ButtonCustomClick
        ' Enviamos el objeto Empresa01 y especificamos que pertenece a la empresa "01"



        Dim Fm As New Frm_Entidad(Frm_Sincronizador.Empresa01)
        Fm.Text = "Configuración Parámetros - Empresa 01"
        Fm.ShowDialog(Me)

        If Fm.DialogResult = DialogResult.OK Then
            Sb_Guardar_Entidades_JSON()
            Txt_Empresa01.Text = Frm_Sincronizador.Empresa01.EntidadDeVenta.Rows(0).Item("Codigo").ToString.Trim & " - " & Frm_Sincronizador.Empresa01.EntidadDeVenta.Rows(0).Item("Descripcion").ToString.Trim

        End If
        Fm.Dispose()
    End Sub

    Private Sub Txt_Empresa02_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Empresa02.ButtonCustomClick
        ' Enviamos el objeto Empresa02 y especificamos que pertenece a la empresa "02"
        Dim Fm As New Frm_Entidad(Frm_Sincronizador.Empresa02)
        Fm.Text = "Configuración Parámetros - Empresa 02"
        Fm.ShowDialog(Me)

        If Fm.DialogResult = DialogResult.OK Then
            Txt_Empresa02.Text = Frm_Sincronizador.Empresa02.EntidadDeVenta.Rows(0).Item("Codigo").ToString.Trim & " - " & Frm_Sincronizador.Empresa02.EntidadDeVenta.Rows(0).Item("Descripcion").ToString.Trim
            Sb_Guardar_Entidades_JSON()

        End If
        Fm.Dispose()
    End Sub

    Private Sub Txt_Empresa01_TextChanged(sender As Object, e As EventArgs) Handles Txt_Empresa01.TextChanged

    End Sub

    Private Sub Txt_Empresa02_TextChanged(sender As Object, e As EventArgs) Handles Txt_Empresa02.TextChanged

    End Sub

    Private Sub Btn_Equivalencia_Click(sender As Object, e As EventArgs) Handles Btn_Equivalencia.Click
        Dim Fm As New Frm_Bodega()
        Fm.Text = "Configuración de equivalencias"
        Fm.ShowDialog(Me)

        If Fm.DialogResult = DialogResult.OK Then
            Sb_ActualizarGrillaRelaciones()

        End If
        Fm.Dispose()
    End Sub

    Private Sub Data_Equivalencia_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Data_Equivalencia.CellContentClick

    End Sub


    Private Sub Data_Equivalencia_KeyDown(sender As Object, e As KeyEventArgs) Handles Data_Equivalencia.KeyDown
        ' Verificamos si el usuario presionó la combinación Ctrl + C
        If e.Control AndAlso e.KeyCode = Keys.C Then

            ' Validamos que exista una celda activa y que no esté vacía
            If Data_Equivalencia.CurrentCell IsNot Nothing AndAlso Data_Equivalencia.CurrentCell.Value IsNot Nothing Then

                ' Copiamos únicamente el texto de la celda actual al portapapeles
                Clipboard.SetText(Data_Equivalencia.CurrentCell.Value.ToString())

                ' Marcamos el evento como manejado para que el DataGridView 
                ' no ejecute su acción de copiado por defecto (que copiaría la fila entera)
                e.Handled = True

            End If
        End If
    End Sub

    Private Sub TextBoxX1_TextChanged(sender As Object, e As EventArgs) Handles Txt_Funcionario.TextChanged

    End Sub

    Private Function Fx_Abrir_Filtro(tipoFiltro As Object, condicionExtra As String, tablaSql As String, campoCodigo As String, campoDescripcion As String, esModalidad As Boolean) As DataTable
        Dim _Tbl_Filtro As New DataTable()
        _Tbl_Filtro.Columns.Add("ChkV", GetType(Boolean))
        _Tbl_Filtro.Columns.Add("Codigo", GetType(String))
        _Tbl_Filtro.Columns.Add("Descripcion", GetType(String))

        If esModalidad Then
            _Tbl_Filtro.Columns.Add("MODALIDAD", GetType(String))
        End If

        Dim Fm As New Frm_Filtro_Especial_Informes(tipoFiltro,, condicionExtra, tablaSql, campoCodigo, campoDescripcion)
        Fm.Pro_Tbl_Filtro = _Tbl_Filtro
        Fm.Pro_Seleccionar_Solo_Uno = True
        Fm.ShowDialog(Me)

        Dim _Tbl_Resultado As DataTable = Nothing

        If Fm.DialogResult = DialogResult.OK Then
            If Fm.Pro_Tbl_Filtro IsNot Nothing AndAlso Fm.Pro_Tbl_Filtro.Rows.Count > 0 Then
                _Tbl_Resultado = Fm.Pro_Tbl_Filtro
            End If
        End If

        Fm.Dispose()
        Return _Tbl_Resultado
    End Function

    Private Sub TextBoxX1_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Funcionario.ButtonCustomClick
        Dim tbl As DataTable = Fx_Abrir_Filtro(_Tabla_Fl._Funcionarios_Random, "", "TABFU", "KOFU", "NOKOFU", False)

        If tbl IsNot Nothing Then
            Funcionario = tbl.Rows(0).Item("Codigo").ToString.Trim
            Txt_Funcionario.Text = Funcionario
            Lbl_NombreF.Text = tbl.Rows(0).Item("Descripcion").ToString.Trim
            FuncionarioNom = tbl.Rows(0).Item("Descripcion").ToString.Trim
            Sb_Guardar_Entidades_JSON()
        End If
    End Sub
#End Region




End Class
