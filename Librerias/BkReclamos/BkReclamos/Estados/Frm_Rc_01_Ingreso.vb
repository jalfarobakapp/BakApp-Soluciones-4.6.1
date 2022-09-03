Imports DevComponents.DotNetBar
Imports BkSpecialPrograms
Imports BkReclamos
Imports System.Data.SqlClient

Public Class Frm_Rc_01_Ingreso

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Id_Reclamo As Integer
    Dim _Cl_Reclamo As New Cl_Reclamo
    Dim _Grabar As Boolean
    Dim _Tipo_Reclamo As String
    Dim _Sub_Tipo_Reclamos As String


    Property Pro_Cl_Reclamo As Cl_Reclamo
        Get
            Return _Cl_Reclamo
        End Get
        Set(value As Cl_Reclamo)
            _Cl_Reclamo = value
        End Set
    End Property
    Public ReadOnly Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
    End Property

    Public Sub New(Accion As Cl_Reclamo.Enum_Accion)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Cl_Reclamo.Pro_Accion = Accion

        caract_combo(Cmb_Tipo_Reclamo)
        Consulta_Sql = "Select '' As Padre,'' As Hijo,0 As Orden Union
                        SELECT CodigoTabla AS Padre,NombreTabla AS Hijo,Orden
                        FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones
                        WHERE Tabla = 'SIS_RECLAMOS_TIPO' ORDER BY Orden"
        Cmb_Tipo_Reclamo.DataSource = _Sql.Fx_Get_Tablas(Consulta_Sql)
        Cmb_Tipo_Reclamo.SelectedValue = String.Empty

        caract_combo(Cmb_Suc_Elaboracion)
        Consulta_Sql = "Select '' As Padre,'' As Hijo,0 As Orden Union
                        SELECT CodigoTabla AS Padre,NombreTabla AS Hijo,Orden
                        FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones
                        WHERE Tabla = 'SIS_RECLAMOS_SUCREC' And Padre_CodigoTabla = '" & ModEmpresa & "' ORDER BY Orden"
        Cmb_Suc_Elaboracion.DataSource = _Sql.Fx_Get_Tablas(Consulta_Sql)
        Cmb_Suc_Elaboracion.SelectedValue = String.Empty

        Sb_Formato_Generico_Grilla(Grilla_Preguntas, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then

            Btn_Cancelar.ForeColor = Color.White
            Btn_Archivos_Adjuntos.ForeColor = Color.White

            Txt_Cantidad.FocusHighlightEnabled = False
            Txt_Cliente.FocusHighlightEnabled = False
            Txt_Descripcion_Reclamo.FocusHighlightEnabled = False
            Txt_Direccion.FocusHighlightEnabled = False
            Txt_Email_Contacto.FocusHighlightEnabled = False
            Txt_Nombre_Contacto.FocusHighlightEnabled = False
            Txt_Producto.FocusHighlightEnabled = False
            Txt_Telefono_Contacto.FocusHighlightEnabled = False
            Txt_Vendedor.FocusHighlightEnabled = False


        End If

    End Sub

    Sub Sb_Insertar_Pregunta(_Row_Pregunta As DataRow, _Respuesta As String)

        Dim NewFila As DataRow
        NewFila = _Cl_Reclamo.Pro_Tbl_Preguntas.NewRow
        With NewFila

            .Item("Cod_Pregunta") = _Row_Pregunta.Item("CodigoTabla")
            .Item("Pregunta") = _Row_Pregunta.Item("NombreTabla")
            .Item("Respuesta") = _Respuesta

            _Cl_Reclamo.Pro_Tbl_Preguntas.Rows.Add(NewFila)

        End With

    End Sub

    Private Sub Frm_01_Ingreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Select Case _Cl_Reclamo.Pro_Accion

            Case Cl_Reclamo.Enum_Accion.Nuevo

                Me.ActiveControl = Txt_Nombre_Contacto
                Sb_Nuevo()

            Case Cl_Reclamo.Enum_Accion.Editar

                Txt_Descripcion_Reclamo.TabStop = False
                Sb_Edicion()

                Select Case _Cl_Reclamo.Estado
                    Case "ING", "RVE", "RCI", "RSL"
                        Btn_Editar.Visible = True
                        Btn_Archivos_Adjuntos.Visible = True
                    Case Else
                        Btn_Editar.Visible = False
                End Select

        End Select

        AddHandler Txt_Cliente.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Direccion.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Producto.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Vendedor.KeyPress, AddressOf Txt_KeyPress_Enter

        AddHandler Txt_Nombre_Contacto.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Telefono_Contacto.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Email_Contacto.KeyPress, AddressOf Txt_KeyPress_Enter

        AddHandler Txt_Cantidad.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Cantidad.KeyPress, AddressOf Txt_KeyPress_Solo_Numeros

        AddHandler Cmb_Tipo_Reclamo.SelectedIndexChanged, AddressOf Sb_Cmb_Tipo_Reclamo_SelectedIndexChanged

    End Sub

    Sub Sb_Nuevo()

        Dim _Random As New Random

        Dim _Id_Rcl As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Reclamo", "Max(Id_Reclamo)",, True)
        _Cl_Reclamo.Id_Reclamo = _Random.Next(_Id_Rcl + 100, _Id_Rcl + 900)

        Txt_Cliente.Text = _Cl_Reclamo.Pro_Row_Entidad.Item("Rut") & " - " & _Cl_Reclamo.Pro_Row_Entidad.Item("NOKOEN")
        Txt_Direccion.Text = _Cl_Reclamo.Pro_Row_Entidad.Item("DIEN")
        Txt_Vendedor.Tag = Trim(_Cl_Reclamo.Pro_Row_Entidad.Item("KOFUEN"))
        Txt_Vendedor.Text = Trim(_Cl_Reclamo.Pro_Row_Entidad.Item("Vendedor"))

        Sb_Llenar_Combo_Sub_Tipo_Reclamos("")

        Btn_Archivos_Adjuntos.Visible = True
        Sb_Habilitar_Controles(True)

    End Sub

    Sub Sb_Edicion()

        _Id_Reclamo = _Cl_Reclamo.Id_Reclamo

        Txt_Cliente.Text = _Cl_Reclamo.Pro_Row_Entidad.Item("Rut") & " - " & _Cl_Reclamo.Pro_Row_Entidad.Item("NOKOEN")
        Txt_Direccion.Text = _Cl_Reclamo.Pro_Row_Entidad.Item("DIEN")

        Txt_Nombre_Contacto.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Nombre_Contacto")
        Txt_Telefono_Contacto.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Telefono_Contacto")
        Txt_Email_Contacto.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Email_Contacto")

        Txt_Producto.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Codigo") & " - " & _Cl_Reclamo.Pro_Row_Reclamo.Item("Descripcion")
        Txt_Cantidad.Text = "KG " & FormatNumber(_Cl_Reclamo.Pro_Row_Reclamo.Item("Cantidad"), 0)
        Txt_Cantidad.Tag = _Cl_Reclamo.Pro_Row_Reclamo.Item("Cantidad")
        Dtp_Fecha_Elab.Value = _Cl_Reclamo.Pro_Row_Reclamo.Item("Fecha_Elab")
        Cmb_Tipo_Reclamo.SelectedValue = _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo")
        _Tipo_Reclamo = Cmb_Tipo_Reclamo.SelectedValue
        Sb_Llenar_Combo_Sub_Tipo_Reclamos(Cmb_Tipo_Reclamo.SelectedValue)
        Cmb_Sub_Tipo_Reclamos.SelectedValue = _Cl_Reclamo.Pro_Row_Reclamo.Item("Sub_Tipo_Reclamo")

        Cmb_Suc_Elaboracion.SelectedValue = _Cl_Reclamo.Pro_Row_Reclamo.Item("Suc_Elaboracion")

        Txt_Vendedor.Tag = _Cl_Reclamo.Pro_Row_Reclamo.Item("Cod_Vendedor")
        Txt_Vendedor.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Vendedor")

        Txt_Descripcion_Reclamo.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Descripcion_Reclamo")

        Btn_Editar.Visible = True

        Sb_Llenar_Grilla_Preguntas(_Cl_Reclamo.Pro_Row_Reclamo.Item("Id_Reclamo"), Cmb_Tipo_Reclamo.SelectedValue)
        Sb_Habilitar_Controles(False)

    End Sub

    Sub Sb_Llenar_Grilla_Preguntas(_Id_Reclamo As Integer, _Tipo_Reclamo As String)

        Consulta_Sql = "Select Cod_Pregunta,Isnull(NombreTabla,'...????...(no se encontro cód. pregunta ['+Cod_Pregunta+'])') As Pregunta, Respuesta
                        From " & _Global_BaseBk & "Zw_Reclamo_Preguntas Recl
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Carac On Recl.Cod_Pregunta = Carac.CodigoTabla
                        And Recl.Tipo_Reclamo = Carac.Padre_CodigoTabla
                        Where Id_Reclamo = " & _Id_Reclamo & "
                        Union
                        Select CodigoTabla As Cod_Pregunta,NombreTabla As Pregunta, '' As Respuesta 
                        From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
                        Where Tabla = 'SIS_RECLAMOS_PREG' And Padre_Tabla = 'SIS_RECLAMOS_TIPO'
                        And CodigoTabla Not In (Select Cod_Pregunta From " & _Global_BaseBk & "Zw_Reclamo_Preguntas Where Id_Reclamo = " & _Id_Reclamo & ")
                        And Padre_CodigoTabla = '" & _Tipo_Reclamo & "'"
        _Cl_Reclamo.Pro_Tbl_Preguntas = _Sql.Fx_Get_Tablas(Consulta_Sql)

        With Grilla_Preguntas

            .DataSource = _Cl_Reclamo.Pro_Tbl_Preguntas

            OcultarEncabezadoGrilla(Grilla_Preguntas)

            .Columns("Pregunta").Visible = True
            .Columns("Pregunta").HeaderText = "Pregunta"
            .Columns("Pregunta").Width = 350
            .Columns("Pregunta").DisplayIndex = 0

            .Columns("Respuesta").Visible = True
            .Columns("Respuesta").HeaderText = "Respuesta"
            .Columns("Respuesta").Width = 350
            .Columns("Respuesta").DisplayIndex = 1

        End With

        For Each _Fila As DataGridViewRow In Grilla_Preguntas.Rows
            _Fila.Cells("Pregunta").Style.BackColor = Color.LightGray
        Next

    End Sub
    Private Sub Btn_Buscar_Cliente_Click(sender As Object, e As EventArgs)

        Dim Fm_Ent As New Frm_BuscarEntidad_Mt(False)
        Fm_Ent.Text = "SELECCIONE EL CLIENTE"
        Fm_Ent.ShowDialog(Me)

        If Fm_Ent.Pro_Entidad_Seleccionada Then _Cl_Reclamo.Pro_Row_Reclamo = Fm_Ent.Pro_RowEntidad
        Fm_Ent.Dispose()

    End Sub

    Private Sub Txt_Cantidad_Validated(sender As Object, e As EventArgs) Handles Txt_Cantidad.Validated

        Txt_Cantidad.Tag = Val(Txt_Cantidad.Text)
        Txt_Cantidad.Text = "KG. " & FormatNumber(Txt_Cantidad.Tag, 0)

    End Sub

    Private Sub Txt_KeyPress_Solo_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If

    End Sub

    Private Sub Txt_KeyPress_Enter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Btn_Buscar_Cliente_Click_1(sender As Object, e As EventArgs) Handles Btn_Buscar_Cliente.Click

        Dim _RowEntidad As DataRow
        Dim Fm_Ent As New Frm_BuscarEntidad_Mt(False)
        Fm_Ent.Text = "SELECCIONE EL CLIENTE"
        Fm_Ent.ShowDialog(Me)

        If Fm_Ent.Pro_Entidad_Seleccionada Then _RowEntidad = Fm_Ent.Pro_RowEntidad

        Fm_Ent.Dispose()

        If Not IsNothing(_RowEntidad) Then

            _Cl_Reclamo.Pro_Row_Entidad = _RowEntidad
            Txt_Cliente.Text = _Cl_Reclamo.Pro_Row_Entidad.Item("Rut") & " - " & _Cl_Reclamo.Pro_Row_Entidad.Item("NOKOEN")
            Txt_Direccion.Text = _Cl_Reclamo.Pro_Row_Entidad.Item("DIEN")
            Txt_Vendedor.Tag = Trim(_Cl_Reclamo.Pro_Row_Entidad.Item("KOFUEN"))
            Txt_Vendedor.Text = Trim(_Cl_Reclamo.Pro_Row_Entidad.Item("Vendedor"))

            If String.IsNullOrEmpty(Txt_Vendedor.Text) Then
                Txt_Vendedor.Tag = String.Empty
            End If

            _Cl_Reclamo.Pro_Row_Producto = Nothing
            Txt_Producto.Tag = String.Empty
            Txt_Producto.Text = String.Empty

        End If

    End Sub

    Private Sub Btn_Buscar_Vendedor_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Vendedor.Click

        Dim _Kogru = "VENDEDOR"

        Dim _Sql_Filtro_Condicion_Extra = "And INACTIVO = 0 And (KOFU IN (Select KOFU From TABFUEM Where EMPRESA = '" & ModEmpresa & "')" & vbCrLf &
                 "And KOFU In (Select KOFU From TABFUGD Where KOGRU = '" & _Kogru & "'))"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, True) Then

            Dim _Tbl_Operacion As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Operacion.Rows(0)

            Txt_Vendedor.Tag = Trim(_Row.Item("Codigo"))
            Txt_Vendedor.Text = Trim(_Row.Item("Descripcion"))

        End If

    End Sub

    Private Sub Txt_Cantidad_Enter(sender As Object, e As EventArgs) Handles Txt_Cantidad.Enter

        If CBool(Txt_Cantidad.Tag) Then
            Txt_Cantidad.Text = Txt_Cantidad.Tag
        Else
            Txt_Cantidad.Text = String.Empty
        End If

    End Sub

    Private Sub Btn_Buscar_Producto_Click_1(sender As Object, e As EventArgs) Handles Btn_Buscar_Producto.Click

        If IsNothing(_Cl_Reclamo.Pro_Row_Entidad) Then

            MessageBoxEx.Show(Me, "Debe ingresar primero al cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        Dim _Filtro_Sql_Extra As String = "And Mp.KOPR In (Select KOPRCT From MAEDDO Where ENDO = '" & _Cl_Reclamo.Pro_Row_Entidad.Item("KOEN") & "')"

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt

        With Fm

            .Pro_Actualizar_Precios = False
            .Pro_Mostrar_Info = False
            .BtnBuscarAlternativos.Visible = True
            .Pro_Mostrar_Imagenes = True
            .BtnCrearProductos.Visible = True
            .Pro_Mostrar_Editar = True
            .Pro_Mostrar_Eliminar = True
            .BtnExportaExcel.Visible = True
            .Pro_Tipo_Lista = "C"
            .Pro_Maestro_Productos = False
            .Pro_Sucursal_Busqueda = ModSucursal
            .Pro_Bodega_Busqueda = ModBodega
            .Pro_Lista_Busqueda = ModListaPrecioVenta
            .Pro_Mostrar_Info = True
            .Pro_Filtro_Sql_Extra = _Filtro_Sql_Extra
            .ShowDialog(Me)

            _Cl_Reclamo.Pro_Row_Producto = .Pro_RowProducto
            Dim _Seleccionado = .Pro_Seleccionado
            .Dispose()

            If _Seleccionado Then

                Txt_Producto.Text = Trim(_Cl_Reclamo.Pro_Row_Producto.Item("KOPR")) & " - " & _Cl_Reclamo.Pro_Row_Producto.Item("NOKOPR")
                Txt_Producto.Tag = _Cl_Reclamo.Pro_Row_Producto.Item("KOPR")
                If _Cl_Reclamo.Pro_Accion = Cl_Reclamo.Enum_Accion.Editar Then
                    _Cl_Reclamo.Pro_Row_Reclamo.Item("Codigo") = _Cl_Reclamo.Pro_Row_Producto.Item("KOPR")
                    _Cl_Reclamo.Pro_Row_Reclamo.Item("Descripcion") = _Cl_Reclamo.Pro_Row_Producto.Item("NOKOPR")
                End If
                Txt_Cantidad.Focus()

            End If

        End With

    End Sub

    Sub Sb_Grabar_Nuevo_Reclamo()

        If Fx_Se_Puede_Grabar() Then

            Dim _Numero As String
            Dim _Id_Reclamo As Integer = Fx_Crear_Reclamo(_Numero)

            If CBool(_Id_Reclamo) Then

                MessageBoxEx.Show(Me, "Reclamo Nro: " & _Numero & " ingresado correctamente", "Grabar",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Reclamo Where Id_Reclamo = " & _Id_Reclamo
                _Cl_Reclamo.Pro_Row_Reclamo = _Sql.Fx_Get_DataRow(Consulta_Sql)

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set Estado = 'RVE' 
                                Where Id_Reclamo = " & _Cl_Reclamo.Pro_Row_Reclamo.Item("Id_Reclamo") & vbCrLf &
                               "Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario) Values " &
                               "(" & _Cl_Reclamo.Pro_Row_Reclamo.Item("Id_Reclamo") & ",'RVE','" & FUNCIONARIO & "')"

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then

                    ' ENVIAR CORREO
                    _Cl_Reclamo.Sb_Cargar_Reclamo(_Id_Reclamo)
                    _Cl_Reclamo.Sb_Enviar_Correo(Me, "RVE", _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo"), True)
                    _Grabar = CBool(_Id_Reclamo)
                    Me.Close()

                End If

            End If

        End If

    End Sub

    Function Fx_Nuevo_Nro_Reclamo() As String

        Dim _NvoNro_OT As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _TblPaso = _Sql.Fx_Get_Tablas("Select Max(Numero) As Ult_Nro_OT From " & _Global_BaseBk & "Zw_Reclamo")

        If CBool(_TblPaso.Rows.Count) Then

            Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("Ult_Nro_OT"), "")

            If String.IsNullOrEmpty(Trim(_Ult_Nro_OT)) Then
                _Ult_Nro_OT = 1
            Else
                _Ult_Nro_OT += 1
            End If
            _NvoNro_OT = numero_(Val(_Ult_Nro_OT), 10)
        Else
            _NvoNro_OT = numero_(1, 10)
        End If

        Return _NvoNro_OT

    End Function

    Function Fx_Crear_Reclamo(ByRef _Numero As String) As Integer

        Dim _Id_Reclamo As Integer

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Cn As New SqlConnection

        Try

            _Sql.Sb_Abrir_Conexion(_Cn)
            myTrans = _Cn.BeginTransaction()


            _Numero = Fx_Nuevo_Nro_Reclamo()

            Dim _Estado = "ING"
            Dim _Tipo_Reclamo = Cmb_Tipo_Reclamo.SelectedValue
            Dim _Sub_Tipo_Reclamo = Cmb_Sub_Tipo_Reclamos.SelectedValue
            Dim _Nombre_Contacto = Replace(Txt_Nombre_Contacto.Text, "'", "''")
            Dim _Email_Contacto = Replace(Txt_Email_Contacto.Text, "'", "''")
            Dim _Telefono_Contacto = Replace(Txt_Telefono_Contacto.Text, "'", "''")
            Dim _CodEntidad = _Cl_Reclamo.Pro_Row_Entidad.Item("KOEN")
            Dim _SucEntidad = _Cl_Reclamo.Pro_Row_Entidad.Item("SUEN")
            Dim _Rut_Entidad = _Cl_Reclamo.Pro_Row_Entidad.Item("Rut")
            Dim _Cod_Vendedor = Txt_Vendedor.Tag
            Dim _Codigo = _Cl_Reclamo.Pro_Row_Producto.Item("KOPR")
            Dim _Descripcion = _Cl_Reclamo.Pro_Row_Producto.Item("NOKOPR")
            Dim _Fecha_Elab = Format(Dtp_Fecha_Elab.Value, "yyyyMMdd")
            Dim _Cantidad = De_Txt_a_Num_01(Txt_Cantidad.Tag, 5)
            Dim _Descripcion_Reclamo = Replace(Txt_Descripcion_Reclamo.Text, "'", "''")
            Dim _Suc_Elaboracion = Cmb_Suc_Elaboracion.SelectedValue


            Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Reclamo" & Space(1) &
                           "(Empresa,Sucursal,Numero,Estado,Tipo_Reclamo,Sub_Tipo_Reclamo,Nombre_Contacto,Email_Contacto,Telefono_Contacto,
                            CodEntidad,SucEntidad,Rut_Entidad, 
                            Cod_Vendedor,Codigo,Descripcion,Fecha_Elab,Cantidad,Descripcion_Reclamo,Suc_Elaboracion) Values" & vbCrLf &
                            "('" & ModEmpresa & "','" & ModSucursal & "','" & _Numero & "','" & _Estado & "'" &
                            ",'" & _Tipo_Reclamo & "','" & _Sub_Tipo_Reclamo & "','" & _Nombre_Contacto & "','" & _Email_Contacto & "'" &
                            ",'" & _Telefono_Contacto & "'" &
                            ",'" & _CodEntidad & "','" & _SucEntidad & "'" &
                            ",'" & _Rut_Entidad & "','" & _Cod_Vendedor & "','" & _Codigo & "'" &
                            ",'" & _Descripcion & "','" & _Fecha_Elab & "'," &
                            _Cantidad & ",'" & _Descripcion_Reclamo & "','" & _Suc_Elaboracion & "')"


            Comando = New SqlClient.SqlCommand(Consulta_Sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            ' RESCATAMOS EL ID_OT 
            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", _Cn)
            Comando.Transaction = myTrans
            Dim dfd As SqlDataReader = Comando.ExecuteReader()
            While dfd.Read()
                _Id_Reclamo = dfd("Identity")
            End While
            dfd.Close()

            Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario) Values " &
                           "(" & _Id_Reclamo & ",'ING','" & FUNCIONARIO & "')"

            Comando = New SqlClient.SqlCommand(Consulta_Sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            For Each _Fila_Pre As DataRow In _Cl_Reclamo.Pro_Tbl_Preguntas.Rows

                Dim _Cod_Pregunta = _Fila_Pre.Item("Cod_Pregunta")
                Dim _Respuesta = Replace(_Fila_Pre.Item("Respuesta"), "'", "''")

                Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Reclamo_Preguntas (Id_Reclamo,Tipo_Reclamo,Cod_Pregunta,Respuesta) Values " &
                           "(" & _Id_Reclamo & ",'" & Cmb_Tipo_Reclamo.SelectedValue & "','" & _Cod_Pregunta & "','" & _Respuesta & "')"

                Comando = New SqlClient.SqlCommand(Consulta_Sql, _Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            Next

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Reclamo_Archivos Set Id_Reclamo = " & _Id_Reclamo & " Where Id_Reclamo = " & _Cl_Reclamo.Id_Reclamo
            Comando = New SqlClient.SqlCommand(Consulta_Sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            myTrans.Commit()
            _Sql.Sb_Cerrar_Conexion(_Cn)

            Return _Id_Reclamo

        Catch ex As Exception

            MsgBox(ex.Message)
            myTrans.Rollback()

            Return 0
        End Try

    End Function

    Sub Sb_Grabar_Edicion_Reclamo()

        If Fx_Se_Puede_Grabar() Then

            Dim _Id_Reclamo = _Cl_Reclamo.Pro_Row_Reclamo.Item("Id_Reclamo")

            Dim _Tipo_Reclamo = Cmb_Tipo_Reclamo.SelectedValue
            Dim _Sub_Tipo_Reclamo = Cmb_Sub_Tipo_Reclamos.SelectedValue
            Dim _Nombre_Contacto = Replace(Txt_Nombre_Contacto.Text, "'", "''")
            Dim _Email_Contacto = Replace(Txt_Email_Contacto.Text, "'", "''")
            Dim _Telefono_Contacto = Replace(Txt_Telefono_Contacto.Text, "'", "''")
            Dim _CodEntidad = _Cl_Reclamo.Pro_Row_Entidad.Item("KOEN")
            Dim _SucEntidad = _Cl_Reclamo.Pro_Row_Entidad.Item("SUEN")
            Dim _Rut_Entidad = _Cl_Reclamo.Pro_Row_Entidad.Item("Rut")
            Dim _Cod_Vendedor = Txt_Vendedor.Tag
            Dim _Codigo = _Cl_Reclamo.Pro_Row_Producto.Item("KOPR")
            Dim _Descripcion = _Cl_Reclamo.Pro_Row_Producto.Item("NOKOPR")
            Dim _Fecha_Elab = Format(Dtp_Fecha_Elab.Value, "yyyyMMdd")
            Dim _Cantidad = De_Txt_a_Num_01(Txt_Cantidad.Tag, 5)
            Dim _Descripcion_Reclamo = Replace(Txt_Descripcion_Reclamo.Text, "'", "''")
            Dim _Suc_Elaboracion = Cmb_Suc_Elaboracion.SelectedValue

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set
                            Tipo_Reclamo = '" & _Tipo_Reclamo & "',
                            Sub_Tipo_Reclamo = '" & _Sub_Tipo_Reclamo & "',
                            Nombre_Contacto = '" & _Nombre_Contacto & "',
                            Email_Contacto = '" & _Email_Contacto & "',
                            Telefono_Contacto = '" & _Telefono_Contacto & "',
                            CodEntidad = '" & _CodEntidad & "',
                            SucEntidad = '" & _SucEntidad & "',
                            Rut_Entidad = '" & _Rut_Entidad & "', 
                            Cod_Vendedor = '" & _Cod_Vendedor & "',
                            Codigo = '" & _Codigo & "',
                            Descripcion = '" & _Descripcion & "',
                            Fecha_Elab = '" & _Fecha_Elab & "',
                            Cantidad = '" & _Cantidad & "',
                            Descripcion_Reclamo = '" & _Descripcion_Reclamo & "',
                            Suc_Elaboracion = '" & _Suc_Elaboracion & "'
                            Where Id_Reclamo = " & _Id_Reclamo &
                            vbCrLf & vbCrLf & "
                            Delete " & _Global_BaseBk & "Zw_Reclamo_Preguntas Where Id_Reclamo = " & _Id_Reclamo & vbCrLf & vbCrLf

            For Each _Fila_Pre As DataRow In _Cl_Reclamo.Pro_Tbl_Preguntas.Rows

                Dim _Cod_Pregunta = _Fila_Pre.Item("Cod_Pregunta")
                Dim _Respuesta = Replace(_Fila_Pre.Item("Respuesta"), "'", "''")

                Consulta_Sql += "Insert Into " & _Global_BaseBk & "Zw_Reclamo_Preguntas (Id_Reclamo,Tipo_Reclamo,Cod_Pregunta,Respuesta) Values " &
                           "(" & _Id_Reclamo & ",'" & Cmb_Tipo_Reclamo.SelectedValue & "','" & _Cod_Pregunta & "','" & _Respuesta & "')"

            Next

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then

                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Ediar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _Grabar = True
                Me.Close()

            End If

        End If

    End Sub

    Function Fx_Se_Puede_Grabar() As Boolean

        If IsNothing(_Cl_Reclamo.Pro_Row_Entidad) Then
            Beep()
            ToastNotification.Show(Me, "FALTA INGRESAR EL CLIENTE",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Txt_Cliente.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Nombre_Contacto.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA NOMBRE DE CONTACTO",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Txt_Nombre_Contacto.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Telefono_Contacto.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA TELEFONO DE CONTACTO",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Txt_Telefono_Contacto.Focus()
            Return False
        End If

        If Not String.IsNullOrEmpty(Trim(Txt_Email_Contacto.Text)) Then

            If Not Fx_Validar_Email(Txt_Email_Contacto.Text) Then
                Beep()
                ToastNotification.Show(Me, "VALIDACION DE EMAIL" & vbCrLf &
                                       "Formato Ej: micorreo@correo.com",
                                       Imagenes_32x32.Images.Item("Warning.png"),
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
                Txt_Email_Contacto.Focus()
                Return False
            End If

        End If

        If IsNothing(_Cl_Reclamo.Pro_Row_Producto) Then

            Beep()
            ToastNotification.Show(Me, "FALTA INGRESAR EL PRODUCTO",
                                       Imagenes_32x32.Images.Item("Warning.png"),
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
            Txt_Producto.Focus()
            Return False
        End If

        If Txt_Cantidad.Tag = 0 Then
            Beep()
            ToastNotification.Show(Me, "FALTA LA CANTIDAD AFECTADA",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Txt_Cantidad.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Dtp_Fecha_Elab.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA LA FECHA DE ELABORACION DEL PRODUCTO",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Dtp_Fecha_Elab.Focus()
            Return False
        Else

            If Dtp_Fecha_Elab.Value > FechaDelServidor() Then
                Beep()
                ToastNotification.Show(Me, "LA FECHA NO PUEDER SER MAYOR A LA FECHA " & FormatDateTime(FechaDelServidor, DateFormat.ShortDate),
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
                Dtp_Fecha_Elab.Focus()
                Return False
            End If

        End If

        If String.IsNullOrEmpty(Trim(Cmb_Tipo_Reclamo.Text)) Then
            Beep()
            ToastNotification.Show(Me, "FALTA EL TIPO DE RECLAMO",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Cmb_Tipo_Reclamo.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Trim(Cmb_Sub_Tipo_Reclamos.Text)) Then
            Beep()
            ToastNotification.Show(Me, "FALTA EL SUB-TIPO DE RECLAMO",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Cmb_Sub_Tipo_Reclamos.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Trim(Cmb_Suc_Elaboracion.Text)) Then
            Beep()
            ToastNotification.Show(Me, "FALTA LA SUCURSAL DE ELEVAORACION",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Cmb_Suc_Elaboracion.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Trim(Txt_Vendedor.Text)) Then
            Beep()
            ToastNotification.Show(Me, "FALTA EL VENDEDOR",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Txt_Vendedor.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Trim(Txt_Descripcion_Reclamo.Text)) Then
            Beep()
            ToastNotification.Show(Me, "FALTA LA DESCRIPCION DEL RECLAMO",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Txt_Descripcion_Reclamo.Focus()
            Return False
        End If

        For Each _Fila As DataRow In _Cl_Reclamo.Pro_Tbl_Preguntas.Rows

            Dim _Pregunta = _Fila.Item("Pregunta")
            Dim _Respuesta = Trim(_Fila.Item("Respuesta"))

            If String.IsNullOrEmpty(Trim(_Respuesta)) Then
                Beep()
                ToastNotification.Show(Me, "FALTA RESPONDER LA PREGUNTA " & vbCrLf & UCase(_Pregunta),
                                       Imagenes_32x32.Images.Item("Warning.png"),
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
                Grilla_Preguntas.Focus()
                Return False
            End If

        Next

        Return True

    End Function

    Sub Sb_Habilitar_Controles(_Habilitar As Boolean)

        Btn_Buscar_Cliente.Enabled = _Habilitar
        Btn_Buscar_Producto.Enabled = _Habilitar
        Btn_Buscar_Vendedor.Enabled = _Habilitar

        Txt_Nombre_Contacto.ReadOnly = Not _Habilitar
        Txt_Telefono_Contacto.ReadOnly = Not _Habilitar
        Txt_Email_Contacto.ReadOnly = Not _Habilitar

        Cmb_Tipo_Reclamo.Enabled = _Habilitar
        Cmb_Sub_Tipo_Reclamos.Enabled = _Habilitar
        Cmb_Suc_Elaboracion.Enabled = _Habilitar

        Txt_Descripcion_Reclamo.ReadOnly = Not _Habilitar
        Dtp_Fecha_Elab.Enabled = _Habilitar

        Dim _BackColor As Color

        If _Habilitar Then

            AddHandler Grilla_Preguntas.CellBeginEdit, AddressOf Sb_Grilla_CellBeginEdit
            AddHandler Grilla_Preguntas.CellEndEdit, AddressOf Sb_Grilla_CellEndEdit
            AddHandler Grilla_Preguntas.KeyDown, AddressOf Sb_Grilla_KeyDown
            _BackColor = Color.FromArgb(Global_camvasColor)

        Else

            RemoveHandler Grilla_Preguntas.CellBeginEdit, AddressOf Sb_Grilla_CellBeginEdit
            RemoveHandler Grilla_Preguntas.CellEndEdit, AddressOf Sb_Grilla_CellEndEdit
            RemoveHandler Grilla_Preguntas.KeyDown, AddressOf Sb_Grilla_KeyDown
            _BackColor = Color.AliceBlue

        End If

        Txt_Cliente.BackColor = _BackColor
        Txt_Direccion.BackColor = _BackColor
        Txt_Nombre_Contacto.BackColor = _BackColor
        Txt_Telefono_Contacto.BackColor = _BackColor
        Txt_Email_Contacto.BackColor = _BackColor
        Txt_Producto.BackColor = _BackColor
        Txt_Cantidad.BackColor = _BackColor
        Dtp_Fecha_Elab.BackColor = _BackColor
        Cmb_Tipo_Reclamo.BackColor = _BackColor
        Cmb_Sub_Tipo_Reclamos.BackColor = _BackColor
        Cmb_Suc_Elaboracion.BackColor = _BackColor
        Txt_Vendedor.BackColor = _BackColor
        Txt_Descripcion_Reclamo.BackColor = _BackColor

        If Btn_Editar.Visible Then
            Btn_Editar.Enabled = Not _Habilitar
            Btn_Grabar.Enabled = _Habilitar
            Btn_Cancelar.Visible = _Habilitar
            Btn_Archivos_Adjuntos.Enabled = _Habilitar
        End If

        Me.Refresh()

    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click

        Sb_Habilitar_Controles(True)

        Beep()
        ToastNotification.Show(Me, "EDICION ACTIVA",
                               Btn_Editar.Image,
                               1 * 1000, eToastGlowColor.Green,
                               eToastPosition.MiddleCenter)
        Me.Refresh()

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click

        _Cl_Reclamo.Sb_Cargar_Reclamo(_Id_Reclamo)

        Beep()
        ToastNotification.Show(Me, "EDICION CANCELADA, LOS CAMBIOS SERAN REVERTIDOS",
                               Btn_Editar.Image,
                               1 * 1000, eToastGlowColor.Green,
                               eToastPosition.MiddleCenter)

        Sb_Edicion()
        Sb_Habilitar_Controles(False)
        Me.Refresh()

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Select Case _Cl_Reclamo.Pro_Accion

            Case Cl_Reclamo.Enum_Accion.Nuevo

                Sb_Grabar_Nuevo_Reclamo()

            Case Cl_Reclamo.Enum_Accion.Editar

                Sb_Grabar_Edicion_Reclamo()

        End Select

    End Sub

    Private Sub Sb_Grilla_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        Dim Grilla As DataGridView = CType(sender, DataGridView)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "Pregunta" Then
            e.Cancel = True
        End If

    End Sub

    Private Sub Sb_Grilla_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim Grilla As DataGridView = CType(sender, DataGridView)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Grilla.Columns(_Cabeza).ReadOnly = True

    End Sub

    Private Sub Sb_Grilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        Try

            Dim Grilla As DataGridView = CType(sender, DataGridView)
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            Dim _Key As Keys = e.KeyValue

            Select Case _Key

                Case Keys.Enter

                    'SendKeys.Send("{F2}")
                    'e.Handled = True
                    'Grilla.BeginEdit(True)
                    Grilla.Columns(_Cabeza).ReadOnly = False
                    Grilla.BeginEdit(True)

                    If Not IsNothing(e) Then
                        e.SuppressKeyPress = False
                        e.Handled = True
                    End If

            End Select

        Catch ex As Exception

        End Try
    End Sub

    Sub Sb_Llenar_Combo_Sub_Tipo_Reclamos(ByVal _Codigo As String)

        Consulta_Sql = "Select '' As Padre,'' As Hijo " & vbCrLf & "Union " & vbCrLf &
                       "SELECT CodigoTabla As Padre,NombreTabla As Hijo" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "WHERE Tabla = 'SIS_RECLAMOS_SUBTIPO' And Padre_Tabla = 'SIS_RECLAMOS_TIPO' And Padre_CodigoTabla = '" & Cmb_Tipo_Reclamo.SelectedValue & "'" & vbCrLf &
                       "Order by Padre"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        caract_combo(Cmb_Sub_Tipo_Reclamos)
        Cmb_Sub_Tipo_Reclamos.DataSource = _Tbl
        Cmb_Sub_Tipo_Reclamos.SelectedValue = _Codigo

    End Sub

    Private Sub Btn_Archivos_Adjuntos_Click(sender As Object, e As EventArgs) Handles Btn_Archivos_Adjuntos.Click

        Dim Fm As New Frm_Archivos_Adjuntos("ING", "")
        Fm.Pro_Cl_Reclamo = _Cl_Reclamo
        Fm.Pro_Editar = Btn_Grabar.Enabled
        Fm.Text = "ARCHIVOS ADJUNTOS (" & Me.Text & ")"
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Sb_Cmb_Tipo_Reclamo_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim _Id_Reclamo = _Cl_Reclamo.Id_Reclamo

        Dim _Tiene_Respuestas As Boolean

        For Each _Fila As DataGridViewRow In Grilla_Preguntas.Rows

            Dim _Respuesta = _Fila.Cells("Respuesta").Value
            If Not String.IsNullOrEmpty(_Respuesta) Then
                _Tiene_Respuestas = True
                Exit For
            End If

        Next

        If _Tipo_Reclamo <> Cmb_Tipo_Reclamo.SelectedValue Then

            If _Tiene_Respuestas Then

                If MessageBoxEx.Show(Me, "Tiene datos en las respuesta de las preguntas." & vbCrLf &
                                     "Si cambia el tipo de reclamo las respuesta se perderan." & vbCrLf &
                                     "¿Desea cambiar el tipo de reclamo de todas formas?",
                                     "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then

                    Cmb_Tipo_Reclamo.SelectedValue = _Tipo_Reclamo
                    Return

                End If

            End If

            _Tipo_Reclamo = Cmb_Tipo_Reclamo.SelectedValue
            Sb_Llenar_Grilla_Preguntas(_Id_Reclamo, _Tipo_Reclamo)
            Sb_Llenar_Combo_Sub_Tipo_Reclamos("")

        End If

    End Sub

    Private Sub Cmb_Sub_Tipo_Reclamos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Sub_Tipo_Reclamos.SelectedIndexChanged
        _Sub_Tipo_Reclamos = Cmb_Sub_Tipo_Reclamos.SelectedValue
    End Sub

End Class