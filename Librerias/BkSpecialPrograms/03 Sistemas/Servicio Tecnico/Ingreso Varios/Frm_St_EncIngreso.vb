Imports DevComponents.DotNetBar

Public Class Frm_St_EncIngreso


    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    'Public Property DsDocumento As DataSet
    'Public Property RowEntidad As DataRow

    Dim _Cl_OrdenServicio As Cl_OrdenServicio
    Dim _Nro_GRP As String

    Public Property Cl_OrdenServicio As Cl_OrdenServicio
        Get
            Return _Cl_OrdenServicio
        End Get
        Set(value As Cl_OrdenServicio)
            _Cl_OrdenServicio = value
        End Set
    End Property

    Public Sub New(_RowEntidad As DataRow)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Cl_OrdenServicio = New Cl_OrdenServicio
        _Cl_OrdenServicio.RowEntidad = _RowEntidad
        _Cl_OrdenServicio.Sb_New_OT_Nueva_OT()

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.None, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Productos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_St_EncIngreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "CREACION DE NUEVA ORDEN DE TRABAJO... EN PROCESO"

        AddHandler Grilla_Productos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla_Encabezado()
        Sb_Actualizar_Grilla_Productos()

    End Sub

    Sub Sb_Actualizar_Grilla_Encabezado()

        With Grilla

            .DataSource = _Cl_OrdenServicio.DsDocumento.Tables(0)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Nro_Ot").ReadOnly = True
            .Columns("Nro_Ot").Width = 80
            .Columns("Nro_Ot").HeaderText = "Nro O.T."
            .Columns("Nro_Ot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Nro_Ot").Visible = True

            .Columns("Rut").ReadOnly = True
            .Columns("Rut").Width = 90
            .Columns("Rut").HeaderText = "Rut"
            .Columns("Rut").Visible = True

            .Columns("Cliente").ReadOnly = True
            .Columns("Cliente").Width = 270
            .Columns("Cliente").HeaderText = "Nombre del cliente"
            .Columns("Cliente").Visible = True

            .Columns("Fecha_Ingreso").ReadOnly = True
            .Columns("Fecha_Ingreso").Width = 100
            .Columns("Fecha_Ingreso").HeaderText = "Fecha Ingreso"
            .Columns("Fecha_Ingreso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Ingreso").Visible = True

            .Columns("Fecha_Entrega").Visible = True
            .Columns("Fecha_Entrega").HeaderText = "Fecha Cierre"
            .Columns("Fecha_Entrega").Width = 100
            .Columns("Fecha_Entrega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Estado").ReadOnly = True
            .Columns("Estado").Width = 100
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Estado").Visible = True

        End With

    End Sub

    Sub Sb_Actualizar_Grilla_Productos()

        With Grilla_Productos

            .DataSource = _Cl_OrdenServicio.DsDocumento.Tables(0)

            OcultarEncabezadoGrilla(Grilla_Productos, True)

            Dim _DisplayIndex = 0

            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").Width = 430
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NroSerie").ReadOnly = True
            .Columns("NroSerie").Width = 120
            .Columns("NroSerie").HeaderText = "Nro. Serie"
            .Columns("NroSerie").Visible = True
            .Columns("NroSerie").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantidad").ReadOnly = True
            .Columns("Cantidad").Width = 60
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Chk_Serv_Garantia").ReadOnly = True
            .Columns("Chk_Serv_Garantia").Width = 50
            .Columns("Chk_Serv_Garantia").HeaderText = "Garantía"
            .Columns("Chk_Serv_Garantia").Visible = True
            .Columns("Chk_Serv_Garantia").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1


        End With

    End Sub

    Private Sub Btn_Contacto_Click(sender As Object, e As EventArgs) Handles Btn_Contacto.Click

        Dim _Koen As String = _Cl_OrdenServicio.RowEntidad.Item("KOEN")
        Dim _Suen As String = _Cl_OrdenServicio.RowEntidad.Item("SUEN")

        Dim _RowContacto As DataRow

        Dim Fm As New Frm_Crear_Entidad_Mt_Lista_contactos(True)
        Fm.Text = "SELECCIONE UN CONTACTO"
        Fm.Pro_CodEntidad = _Koen
        Fm.Pro_SucEntidad = _Suen
        Fm.ShowDialog(Me)

        If Fm.Pro_ContactoSeleccionado Then
            _RowContacto = Fm.Pro_Tbl_DatosContacto.Rows(0)
            Txt_Email_Contacto.Text = _RowContacto.Item("EMAILCON").ToString.Trim
            Txt_Nombre_Contacto.Text = _RowContacto.Item("NOKOCON").ToString.Trim
            Txt_Telefono_Contacto.Text = _RowContacto.Item("FONOCON").ToString.Trim
        Else
            MessageBoxEx.Show(Me, "No se seleccionó ningún contacto", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Fm.Dispose()

    End Sub

    Private Sub Btn_Agregar_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Producto.Click

        If Grilla.RowCount = 8 Then
            MessageBoxEx.Show(Me, "No es posible ingresar mas productos, máximo 8", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _RowProducto As DataRow

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt

        With Fm

            '.Pro_Actualizar_Precios = False
            '.Pro_Mostrar_Info = False
            '.BtnBuscarAlternativos.Visible = True
            '.Pro_Mostrar_Imagenes = True
            '.BtnCrearProductos.Visible = True
            '.Pro_Mostrar_Editar = True
            '.Pro_Mostrar_Eliminar = True
            '.BtnExportaExcel.Visible = True
            '.Pro_Tipo_Lista = "C"
            '.Pro_Maestro_Productos = False
            '.Pro_Sucursal_Busqueda = ModSucursal
            '.Pro_Bodega_Busqueda = ModBodega
            '.Pro_Lista_Busqueda = ModListaPrecioVenta
            '.Pro_Mostrar_Info = True

            .Pro_Actualizar_Precios = False
            .Pro_Mostrar_Info = False
            .BtnBuscarAlternativos.Visible = True
            .Pro_Mostrar_Imagenes = True
            .BtnCrearProductos.Visible = True
            .Pro_Mostrar_Editar = True
            .Pro_Mostrar_Eliminar = True
            .BtnExportaExcel.Visible = True
            .Pro_Tipo_Lista = "P"
            .Pro_Sucursal_Busqueda = ModSucursal
            .Pro_Bodega_Busqueda = ModBodega
            .Pro_Lista_Busqueda = ModListaPrecioVenta
            .Mnu_Btn_Cambiar_Codigo_Producto.Visible = True
            .MostrarSoloServTecnico_ProIngreso = True
            .ShowDialog(Me)
            _RowProducto = .Pro_RowProducto
            Dim _Seleccionado = .Pro_Seleccionado
            .Dispose()

            If Not _Seleccionado Then
                Return
            End If

            Dim _Descripcion As String = _RowProducto.Item("NOKOPR").ToString.Trim

            Dim _Id_Ot As Integer
            Dim _Codigo As String = NuloPorNro(Grilla.Rows(Grilla_Productos.RowCount - 1).Cells("Codigo").Value, "")

            If String.IsNullOrEmpty(_Codigo) Then
                _Id_Ot = Grilla.Rows(Grilla_Productos.RowCount - 1).Cells("Id_Ot").Value
            Else
                _Id_Ot = Grilla_Productos.RowCount + 1
            End If

            'Dim _Aceptar As Boolean = InputBox_Bk(Me, "Descripción del producto", "Producto a reparar",
            '                                      _Descripcion, False,
            '                                      _Tipo_Mayus_Minus.Mayusculas, 50, True, _Tipo_Imagen.Texto)

            'If Not _Aceptar Then
            '    Return
            'End If

            Dim _Grabar As Boolean

            Dim Fm2 As New Frm_St_DetIngreso(_Id_Ot)
            Fm2.Cl_OrdenServicio = Me._Cl_OrdenServicio
            Fm2.Codigo = _RowProducto.Item("KOPR").ToString.Trim
            Fm2.Descripcion = _Descripcion
            Fm2.ShowDialog(Me)
            _Grabar = Fm2.Grabar
            Fm2.Dispose()

            Sb_Actualizar_Grilla_Productos()

            If _Grabar Then

                Grilla.CurrentCell = Grilla.Rows(Grilla.RowCount - 1).Cells(1)
                Grilla.Rows(Grilla.RowCount - 1).Selected = True

                Call Grilla_Productos_CellEnter(Nothing, Nothing)
            End If

        End With

    End Sub

    Private Sub Grilla_Productos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Productos.CellEnter

        Dim _Fila As DataGridViewRow

        _Fila = Grilla_Productos.CurrentRow

        If IsNothing(_Fila) And CBool(Grilla.Rows.Count) Then
            _Fila = Grilla.Rows(0)
        End If

        Try

            Dim _Id_Ot As Integer = _Fila.Cells("Id_Ot").Value

            Txt_Defecto_segun_cliente.Text = String.Empty
            Txt_Nota_Etapa_01.Text = String.Empty

            For Each _Fl As DataRow In Cl_OrdenServicio.DsDocumento.Tables(3).Rows
                If _Fl.Item("Id_Ot") = _Id_Ot Then
                    Txt_Defecto_segun_cliente.Text = _Fl.Item("Defecto_segun_cliente")
                    Txt_Nota_Etapa_01.Text = _Fl.Item("Nota_Etapa_01")
                    Exit For
                End If
            Next

        Catch ex As Exception
            Txt_Defecto_segun_cliente.Text = String.Empty
            Txt_Nota_Etapa_01.Text = String.Empty
        End Try

    End Sub

    Private Sub Grilla_Productos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Productos.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Id_Ot As Integer = _Fila.Cells("Id_Ot").Value
        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Descripcion As String = _Fila.Cells("Descripcion").Value

        If String.IsNullOrEmpty(_Codigo) Then
            MessageBoxEx.Show(Me, "Debe ingresar un producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Grabar As Boolean


        Dim Fm2 As New Frm_St_DetIngreso(_Id_Ot)
        Fm2.Cl_OrdenServicio = Me._Cl_OrdenServicio
        Fm2.Codigo = _Codigo
        Fm2.Descripcion = _Descripcion
        Fm2.Editar = True
        Fm2.ShowDialog(Me)
        _Grabar = Fm2.Grabar
        Fm2.Dispose()

        'Sb_Actualizar_Grilla_Productos()

        If _Grabar Then
            Call Grilla_Productos_CellEnter(Nothing, Nothing)
        End If

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Cl_OrdenServicio.DsDocumento.Tables(0).Rows(0).Item("Codigo")) Then
            MessageBoxEx.Show(Me, "DEBE INGRESAR POR LO MENOS UN PRODUCTO EN LA ORDEN DE SERVICIO", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_Nombre_Contacto.Text) Then
            MessageBoxEx.Show(Me, "FALTA NOMBRE DE CONTACTO", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_Telefono_Contacto.Text) Then
            MessageBoxEx.Show(Me, "FALTA TELEFONO DE CONTACTO", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Not String.IsNullOrEmpty(Trim(Txt_Email_Contacto.Text)) Then

            If Not Fx_Validar_Email(Txt_Email_Contacto.Text) Then
                MessageBoxEx.Show(Me, "MAIL INVALIDO", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End If

        Dim _Bloqueada = Cl_OrdenServicio.RowEntidad.Item("BLOQUEADO")

        If Not Fx_Entidad_Tiene_Deudas_CtaCte(Me, Cl_OrdenServicio.RowEntidad, False, False, _Bloqueada) Then

            If Not Fx_Tiene_Permiso(Me, "Stec0020",,,,, Cl_OrdenServicio.RowEntidad.Item("KOEN"), Cl_OrdenServicio.RowEntidad.Item("SUEN")) Then
                Return
            End If

        End If

        _Nro_GRP = String.Empty

        If Not Fx_Ingresar_NroGRP Then
            Return
        End If


        Dim _Id_Ot_Padre As Integer = 0
        Dim _Id_Ot As Integer = 0
        Dim _Nro_Ot As String = String.Empty
        Dim _Sub_Ot As String = String.Empty

        Dim _Contador = 1

        For Each _Fila As DataRow In Cl_OrdenServicio.DsDocumento.Tables(0).Rows

            Dim _Cantidad = _Fila.Item("Cantidad")
            Dim _Pertenece = String.Empty

            For i = 1 To _Cantidad

                _Sub_Ot = numero_(_Contador, 3)

                If Cl_OrdenServicio.DsDocumento.Tables(0).Rows.Count = 1 And _Cantidad = 1 Then
                    _Sub_Ot = ""
                End If

                If _Cantidad > 1 Then
                    If String.IsNullOrEmpty(_Pertenece) Then
                        _Pertenece = _Sub_Ot
                    End If
                End If

                _Id_Ot = _Fila.Item("Id_Ot")

                Dim _Row_Encabezado = Cl_OrdenServicio.Fx_Trae_Datarow(_Id_Ot, 0)

                _Row_Encabezado.Item("Nombre_Contacto") = Txt_Nombre_Contacto.Text.Trim
                _Row_Encabezado.Item("Telefono_Contacto") = Txt_Telefono_Contacto.Text.Trim
                _Row_Encabezado.Item("Email_Contacto") = Txt_Email_Contacto.Text.Trim

                Dim _Row_Notas = Cl_OrdenServicio.Fx_Trae_Datarow(_Id_Ot, 3)
                Dim _Row_Garantia = Cl_OrdenServicio.Fx_Trae_Datarow(_Id_Ot, 6)

                Dim _NuevaOt As NuevaOt = Cl_OrdenServicio.Fx_Crear_OT(_Nro_Ot,
                                                                       _Id_Ot_Padre,
                                                                       _Sub_Ot,
                                                                       _Pertenece,
                                                                       _Row_Encabezado,
                                                                       _Row_Notas,
                                                                       _Row_Garantia)

                If Not _NuevaOt.EsCorrecto Then
                    MessageBoxEx.Show(Me, _NuevaOt.ErrorGrabar, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                If _Id_Ot_Padre = 0 And _Id_Ot = 1 And i = 1 Then
                    _Id_Ot_Padre = _NuevaOt.Id_Ot
                    _Nro_Ot = _NuevaOt.Nro_Ot
                End If

                _Contador += 1

            Next

        Next

        Cl_OrdenServicio.OrdenGrabada = True

        '_Id_Ot_Padre = _Id_Ot

        'If Cl_OrdenServicio.DsDocumento.Tables(0).Rows.Count = 1 Then
        '    _Id_Ot = _Id_Ot_Padre
        '    _Id_Ot_Padre = 0
        'End If

        Sb_Agregar_GRP(_Id_Ot_Padre, _Id_Ot, _Nro_Ot)

        Me.Close()

    End Sub


    Sub Sb_Agregar_GRP(_Id_Ot_Padre As Integer, _Id_Ot As Integer, _Nro_Ot As String)

        'Dim _Nro_GRP As String
        'Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese Nro Interno/Guía o Factura del cliente", "Recepción de producto", _Nro_GRP,
        '                                      False, _Tipo_Mayus_Minus.Mayusculas, 10)

        'If Not _Aceptar Then
        '    Sb_Agregar_GRP(_Id_Ot_Padre, _Id_Ot, _Nro_Ot)
        '    Return
        'End If

        'If _Aceptar Then

        'Dim _Endo = _Cl_OrdenServicio.RowEntidad.Item("KOEN")
        'Dim _Suen = _Cl_OrdenServicio.RowEntidad.Item("SUEN")

        'Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEEDO",
        '                                    "TIDO = 'GRP' And NUDO = '" & numero_(_Nro_GRP, 10) & "' And ENDO = '" & _Endo & "' And SUENDO = '" & _Suen & "'")

        'If CBool(_Reg) Then
        '    MessageBoxEx.Show(Me, "Ya existe una GRP con el Nro: " & _Nro_GRP & vbCrLf &
        '                      "No se puede ingresar otra GRP con el mismo número", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Sb_Agregar_GRP(_Id_Ot_Padre, _Id_Ot, _Nro_Ot)
        '    Return
        'End If

        Dim _Idmaeedo As Integer = Fx_Crear_GRP_PRE(_Id_Ot_Padre, _Id_Ot, _Nro_Ot, _Nro_GRP)

        If Convert.ToBoolean(_Idmaeedo) Then

            MessageBoxEx.Show(Me, "Guía de recepción por prestamos creada correctamente", "Guía de recpción",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

            '_Idmaeedo = 339712 ' _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_St_OT_Encabezado", "Idmaeedo_GRP_PRE", "Id_Ot = " & _Id_Ot)

            Dim Fm As New Frm_Seleccionar_Formato("GRP")

            If CBool(Fm.Tbl_Formatos.Rows.Count) Then

                Dim _NombreFormato = String.Empty
                Fm.ShowDialog(Me)

                If Fm.Formato_Seleccionado Then
                    _NombreFormato = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
                    Dim _Imprime As String = Fx_Enviar_A_Imprimir_Documento(Me, _NombreFormato, _Idmaeedo,
                                                                       False, True, "", False, 0, False, "")

                    If Not String.IsNullOrEmpty(Trim(_Imprime)) Then
                        MessageBox.Show(Me, _Imprime, "Problemas al Imprimir",
                                       MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

            Else

                MessageBoxEx.Show(Me, "No existen formatos adicionales para este documento", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

            Fm.Dispose()

        End If

        'End If

    End Sub

    Function Fx_Ingresar_NroGRP() As Boolean

        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese Nro Interno/Guía o Factura del cliente",
                                      "Recepción de producto", _Nro_GRP, False, _Tipo_Mayus_Minus.Mayusculas, 10, True)

        If Not _Aceptar Then
            Return False
        End If

        Dim _Endo = _Cl_OrdenServicio.RowEntidad.Item("KOEN")
        Dim _Suen = _Cl_OrdenServicio.RowEntidad.Item("SUEN")

        Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEEDO",
                                            "TIDO = 'GRP' And NUDO = '" & numero_(_Nro_GRP, 10) & "' And ENDO = '" & _Endo & "' And SUENDO = '" & _Suen & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Ya existe una GRP con el Nro: " & _Nro_GRP & vbCrLf &
                              "No se puede ingresar otra GRP con el mismo número", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            If Not Fx_Ingresar_NroGRP() Then
                Return False
            End If
        End If

        Return True

    End Function

    Function Fx_Crear_GRP_PRE(_Id_Ot_Padre As Integer, _Id_Ot As Integer, _Nro_OT As String, _Nro_GRP As String) As Integer

        Dim _ServTecnico_Empresa As String = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Empresa").ToString.Trim
        Dim _ServTecnico_Sucursal As String = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Sucursal").ToString.Trim
        Dim _ServTecnico_Bodega As String = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Bodega").ToString.Trim

        If String.IsNullOrEmpty(_ServTecnico_Empresa.Trim) Then

            MessageBoxEx.Show(Me, "Debe seleccionar la bodega por defecto para Servicio Técnico",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Dim _Row_Bodega As DataRow

            Dim Fmb As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Bodega)
            Fmb.Pro_Empresa = ModEmpresa
            Fmb.Pro_Sucursal = ModSucursal
            Fmb.Pro_Bodega = ModBodega
            Fmb.ShowDialog(Me)
            _Row_Bodega = Fmb.Pro_RowBodega

            If Fmb.Pro_Seleccionado Then

                _Global_Row_Configuracion_Estacion.Item("ServTecnico_Empresa") = _Row_Bodega.Item("EMPRESA")
                _Global_Row_Configuracion_Estacion.Item("ServTecnico_Sucursal") = _Row_Bodega.Item("KOSU")
                _Global_Row_Configuracion_Estacion.Item("ServTecnico_Bodega") = _Row_Bodega.Item("KOBO")

                _ServTecnico_Empresa = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Empresa")
                _ServTecnico_Sucursal = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Sucursal")
                _ServTecnico_Bodega = _Global_Row_Configuracion_Estacion.Item("ServTecnico_Bodega")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Configuracion Set 
                                ServTecnico_Empresa = '" & _ServTecnico_Empresa & "',
                                ServTecnico_Sucursal = '" & _ServTecnico_Sucursal & "',
                                ServTecnico_Bodega = '" & _ServTecnico_Bodega & "' 
                                Where Empresa = '" & ModEmpresa & "' And Modalidad = '" & Modalidad & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            Else

                MessageBoxEx.Show(Me, "No puede generar una Guía si no ingresa la bodega por defecto", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return 0

            End If

        End If

        Dim _NroDocumento = Fx_Rellena_ceros(_Nro_GRP, 10)
        Dim _Contador = 1

        Dim _SqlQuery = String.Empty


        'Consulta_sql = "Select Ots.Id_Ot_Padre,Ots.Nro_Ot,Ots.Codigo,Ots.Descripcion,Ots.NroSerie,Nts.Defecto_segun_cliente,SUM(1) As Cantidad" & vbCrLf &
        '               "From " & _Global_BaseBk & "Zw_St_OT_Encabezado Ots" & vbCrLf &
        '               "Left Join " & _Global_BaseBk & "Zw_St_OT_Notas Nts On Ots.Id_Ot = Nts.Id_Ot" & vbCrLf &
        '               "Where Id_Ot_Padre = " & _Id_Ot_Padre & vbCrLf &
        '               "Group by Ots.Id_Ot_Padre,Ots.Nro_Ot,Ots.Codigo,Ots.Descripcion,Ots.NroSerie,Nts.Defecto_segun_cliente"

        Consulta_sql = "Select Ots.Id_Ot,Ots.Id_Ot_Padre,Ots.Nro_Ot,Ots.Sub_Ot,Ots.Codigo,Ots.Descripcion,Ots.NroSerie,Nts.Defecto_segun_cliente" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_St_OT_Encabezado Ots" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_St_OT_Notas Nts On Ots.Id_Ot = Nts.Id_Ot" & vbCrLf &
                       "Where Id_Ot_Padre = " & _Id_Ot_Padre

        Dim _Tbl_Ots As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tbl_Ots.Rows 'Cl_OrdenServicio.DsDocumento.Tables(0).Rows

            Consulta_sql = "Insert Into MAEST (EMPRESA,KOSU,KOBO,KOPR) Values " &
                "('" & ModEmpresa & "','" & _ServTecnico_Sucursal & "','" & _ServTecnico_Bodega & "','" & _Fila.Item("Codigo") & "')"
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            Dim _Cantidad As Double = 1 '_Fila.Item("Cantidad")
            Dim _Costo As Double = _Sql.Fx_Trae_Dato("TABPRE", "PP01UD",
                                                     "KOLT = '" & ModListaPrecioVenta & "' And KOPR = '" & _Fila.Item("Codigo") & "'", True)

            If _Costo = 0 Then _Costo = 1

            Dim _Observa As String = _Fila.Item("Id_Ot")

            _SqlQuery += "Select '" & _ServTecnico_Sucursal & "' As Sucursal,'" & _ServTecnico_Bodega & "' As Bodega" &
                         ",'" & _Fila.Item("Codigo") & "' As Codigo,'" & _Fila.Item("Descripcion") & "' As Descripcion," &
                         _Cantidad & " As Cantidad," & De_Num_a_Tx_01(_Costo, False, 5) & " As Costo,'" & _Observa & "' As Observa" & vbCrLf

            If _Contador <> _Tbl_Ots.Rows.Count Then
                _SqlQuery += "Union" & vbCrLf
            End If

            _Contador += 1

        Next

        Dim _Observaciones As String = "Documento generado desde Sis. Servicio técnico Bakapp" & vbCrLf & "Nro OT: " & _Nro_OT

        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(_SqlQuery)

        Dim Fm As New Frm_Formulario_Documento("GRP", csGlobales.Enum_Tipo_Documento.Guia_Recepcion_Prestamos_GRP_PRE,
                                               False, True, False, False, False)
        Fm.Pro_RowEntidad = Cl_OrdenServicio.RowEntidad
        Fm.Sb_Crear_Documento_Interno_Con_Tabla2(Me, _Tbl_Productos, FechaDelServidor,
                                                     "Codigo", "Cantidad", "Costo", _Observaciones, False, False, _NroDocumento)
        Dim _Mensaje As LsValiciones.Mensajes = Fm.Fx_Grabar_Documento(False,, False)
        Fm.Dispose()

        Consulta_sql = "Select IDMAEEDO,IDMAEDDO,OBSERVA,TIDO,NUDO From MAEDDO Where IDMAEEDO = " & _Mensaje.Id
        Dim _Tbl_DetalleGrc As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Consulta_sql = String.Empty

        For Each _Fl As DataRow In _Tbl_DetalleGrc.Rows

            Dim _Idmaeddo As Integer = _Fl.Item("IDMAEDDO")
            _Id_Ot = _Fl.Item("OBSERVA")

            For Each _Flst As DataRow In _Tbl_Ots.Rows

                If _Id_Ot = _Flst.Item("Id_Ot") Then

                    Dim _Observa As String = "OTS: " & _Flst.Item("Nro_Ot") & " - SubOt: " & _Flst.Item("Sub_Ot") & ", Serie: " & _Flst.Item("NroSerie") & ", " & _Flst.Item("Defecto_segun_cliente")

                    Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set Idmaeedo_GRP_PRE = " & _Mensaje.Id & ", Idmaeddo_GRP_PRE = " & _Idmaeddo &
                                    " Where Id_Ot = " & _Id_Ot & vbCrLf &
                                    "Update MAEDDO Set OBSERVA = '" & Mid(_Observa, 1, 200) & "' Where IDMAEDDO = " & _Idmaeddo & vbCrLf

                End If

            Next

        Next

        'If CBool(_Id_Ot_Padre) Then
        '    Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set Idmaeedo_GRP_PRE = " & _Idmaeedo & " 
        '                Where Id_Ot_Padre = " & _Id_Ot_Padre & vbCrLf &
        '               "Update MAEEDOOB Set OCDO = '" & _Nro_OT & "',TEXTO1 = '" & Txt_Nombre_Contacto.Text & "'
        '                Where IDMAEEDO = " & _Idmaeedo
        'Else
        '    Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set Idmaeedo_GRP_PRE = " & _Idmaeedo & " 
        '                Where Id_Ot = " & _Id_Ot & vbCrLf &
        '               "Update MAEEDOOB Set OCDO = '" & _Nro_OT & "',TEXTO1 = '" & Txt_Nombre_Contacto.Text & "'
        '                Where IDMAEEDO = " & _Idmaeedo
        'End If

        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        If _Mensaje.EsCorrecto Then

            Dim _Koen = Cl_OrdenServicio.RowEntidad.Item("KOEN")
            Dim _Suen = Cl_OrdenServicio.RowEntidad.Item("SUEN")

            Consulta_sql = "Update MAEEN Set TIEN = 'A' Where KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        Return _Mensaje.Id

    End Function

End Class
