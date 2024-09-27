Imports DevComponents.DotNetBar

Public Class Frm_Despacho_Ordenes

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Ds_Despachos As DataSet
    Dim _Dv_Despachos As New DataView

    Dim _Ds As DataSet

    Dim _Ver As Enum_Ver

    Public Property Ds As DataSet
        Get
            Return _Ds
        End Get
        Set(value As DataSet)
            _Ds = value
        End Set
    End Property

    Public Property _Correr_a_la_derecha As Boolean

    Enum Enum_Ver
        Todas
        Proceso
        Buscar
    End Enum

    Public Sub New(Ver As Enum_Ver)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me._Ver = Ver

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Ordenes_Despacho, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Sub_Ordenes, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Documentos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Doc_Productos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        _Ver = Ver

        Consulta_sql = "Select 'Todas' As Padre,'Todas...' As 'Hijo' Union Select EMPRESA+KOSU As Padre,NOKOSU As Hijo From TABSU"
        caract_combo(Cmb_Sucursal)
        Cmb_Sucursal.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

        If _Ver = Enum_Ver.Todas Then
            Cmb_Sucursal.SelectedValue = "Todas"
        Else
            Cmb_Sucursal.SelectedValue = ModEmpresa & ModSucursal
            Cmb_Sucursal.Enabled = False
        End If

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Despacho_Ordenes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If _Correr_a_la_derecha Then
            Me.Top += 20
            Me.Left += 20
        End If

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        If _Ver <> Enum_Ver.Buscar Then

            Dim _Clas_Despacho_Fx As New Clas_Despacho_Fx

            Dim _Fecha As Date = FechaDelServidor()

            _Ds = _Clas_Despacho_Fx.Fx_Buscar_Ordenes_De_Despacho(_Fecha, _Fecha, Cmb_Sucursal.SelectedValue, _Ver, "", True)

        End If

        _Ds.Tables(0).TableName = "Ordenes"
        _Ds.Tables(1).TableName = "SubOrdenes"
        _Ds.Tables(2).TableName = "Detalle"
        _Ds.Tables(3).TableName = "Productos"
        _Ds.Tables(4).TableName = "Pendientes"

        ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
        ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
        _Ds.Relations.Add("Rel_Despachos_SubOrdenes",
                          _Ds.Tables("Ordenes").Columns("Nro_Despacho"),
                          _Ds.Tables("SubOrdenes").Columns("Nro_Despacho"), False)

        '_Ds.Relations.Add("Rel_Despachos_Detalle",
        '                  _Ds.Tables("SubOrdenes").Columns("Id_Despacho"),
        '                  _Ds.Tables("Detalle").Columns("Id_Despacho"), False)

        '_Ds.Relations.Add("Rel_Detalle_Productos",
        '                  _Ds.Tables("Detalle").Columns("IdD"),
        '                  _Ds.Tables("Productos").Columns("IdD"), False)

        _Ds.Relations.Add("Rel_Despachos_Doc_Detalle",
                          _Ds.Tables("SubOrdenes").Columns("Id_Despacho"),
                          _Ds.Tables("Productos").Columns("Id_Despacho"), False)

        Grilla_Ordenes_Despacho.DataSource = _Ds
        Grilla_Ordenes_Despacho.DataMember = "Ordenes"

        Grilla_Sub_Ordenes.DataSource = _Ds
        Grilla_Sub_Ordenes.DataMember = "Ordenes.Rel_Despachos_SubOrdenes"

        'Grilla_Documentos.DataSource = _Ds
        'Grilla_Documentos.DataMember = "Ordenes.Rel_Despachos_SubOrdenes.Rel_Despachos_Detalle"

        Grilla_Doc_Productos.DataSource = _Ds
        Grilla_Doc_Productos.DataMember = "Ordenes.Rel_Despachos_SubOrdenes.Rel_Despachos_Doc_Detalle"

        OcultarEncabezadoGrilla(Grilla_Ordenes_Despacho, True)
        OcultarEncabezadoGrilla(Grilla_Sub_Ordenes, True)
        OcultarEncabezadoGrilla(Grilla_Documentos, True)
        OcultarEncabezadoGrilla(Grilla_Doc_Productos, True)

        Dim _DisplayIndex = 0

        With Grilla_Ordenes_Despacho

            .Columns("Nro_Despacho").Width = 75
            .Columns("Nro_Despacho").HeaderText = "Número"
            .Columns("Nro_Despacho").Visible = True
            .Columns("Nro_Despacho").ReadOnly = False
            .Columns("Nro_Despacho").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha_Emision").Width = 70
            .Columns("Fecha_Emision").HeaderText = "Fecha Emi."
            .Columns("Fecha_Emision").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha_Emision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Emision").ReadOnly = True
            .Columns("Fecha_Emision").Visible = True
            .Columns("Fecha_Emision").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Rut").Width = 80
            .Columns("Rut").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Rut").ReadOnly = True
            .Columns("Rut").Visible = True
            .Columns("Rut").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombre_Entidad").Width = 350
            .Columns("Nombre_Entidad").HeaderText = "Cliente"
            .Columns("Nombre_Entidad").ReadOnly = True
            .Columns("Nombre_Entidad").Visible = True
            .Columns("Nombre_Entidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Sucursal").Width = 50
            '.Columns("Sucursal").HeaderText = "Sucursal"
            '.Columns("Sucursal").ReadOnly = True
            '.Columns("Sucursal").Visible = True
            '.Columns("Sucursal").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Nom_Tipo_Venta").Width = 150
            .Columns("Nom_Tipo_Venta").HeaderText = "Tipo de venta"
            .Columns("Nom_Tipo_Venta").ReadOnly = True
            .Columns("Nom_Tipo_Venta").Visible = True
            .Columns("Nom_Tipo_Venta").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Refresh()

        End With

        For Each _Fl As DataGridViewRow In Grilla_Ordenes_Despacho.Rows

            Dim _Marcar = _Fl.Cells("Marcar").Value

            If _Marcar Then

                _Fl.DefaultCellStyle.ForeColor = Rojo

            End If

        Next


        _DisplayIndex = 0

        With Grilla_Sub_Ordenes

            .Columns("Nro_Sub").Width = 35
            .Columns("Nro_Sub").HeaderText = "Sub"
            .Columns("Nro_Sub").ReadOnly = True
            .Columns("Nro_Sub").Visible = True
            .Columns("Nro_Sub").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sucursal").Width = 35
            .Columns("Sucursal").HeaderText = "Suc"
            .Columns("Sucursal").ReadOnly = True
            .Columns("Sucursal").Visible = True
            .Columns("Sucursal").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Estado").Width = 30
            .Columns("Estado").HeaderText = "Est."
            .Columns("Estado").ReadOnly = True
            .Columns("Estado").Visible = True
            .Columns("Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nom_Estado").Width = 155
            .Columns("Nom_Estado").HeaderText = "Estado"
            .Columns("Nom_Estado").ReadOnly = True
            .Columns("Nom_Estado").Visible = True
            .Columns("Nom_Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha_Emision").Width = 70
            .Columns("Fecha_Emision").HeaderText = "Fecha Emi."
            .Columns("Fecha_Emision").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha_Emision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Emision").ReadOnly = True
            .Columns("Fecha_Emision").Visible = True
            .Columns("Fecha_Emision").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha_Cierre").Width = 70
            .Columns("Fecha_Cierre").HeaderText = "Fecha Cierre"
            .Columns("Fecha_Cierre").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha_Cierre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Cierre").ReadOnly = True
            .Columns("Fecha_Cierre").Visible = True
            .Columns("Fecha_Cierre").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nom_Tipo_Envio").Width = 110
            .Columns("Nom_Tipo_Envio").HeaderText = "Tipo"
            .Columns("Nom_Tipo_Envio").ReadOnly = True
            .Columns("Nom_Tipo_Envio").Visible = True
            .Columns("Nom_Tipo_Envio").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Transportista").Width = 100
            .Columns("Transportista").HeaderText = "Transportista"
            .Columns("Transportista").ReadOnly = True
            .Columns("Transportista").Visible = True
            .Columns("Transportista").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nro_Encomienda").Width = 120
            .Columns("Nro_Encomienda").HeaderText = "Nro Encomienda"
            .Columns("Nro_Encomienda").ReadOnly = True
            .Columns("Nro_Encomienda").Visible = True
            .Columns("Nro_Encomienda").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Refresh()

        End With

        _DisplayIndex = 0

        With Grilla_Doc_Productos

            .Columns("Tido").Width = 40
            .Columns("Tido").HeaderText = "TD"
            .Columns("Tido").Visible = True
            .Columns("Tido").ReadOnly = False
            .Columns("Tido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nudo").Width = 80
            .Columns("Nudo").HeaderText = "Número"
            .Columns("Nudo").Visible = True
            .Columns("Nudo").ReadOnly = False
            .Columns("Nudo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bodega").Width = 40
            .Columns("Bodega").HeaderText = "Bod"
            .Columns("Bodega").Visible = True
            .Columns("Bodega").ReadOnly = False
            .Columns("Bodega").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").ReadOnly = True
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Width = 235 - 50
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UdTrans").Width = 30
            .Columns("UdTrans").HeaderText = "Ud"
            .Columns("UdTrans").ReadOnly = True
            .Columns("UdTrans").Visible = True
            .Columns("UdTrans").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantidad").Width = 50
            .Columns("Cantidad").HeaderText = "Cant."
            .Columns("Cantidad").ReadOnly = True
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Despachado").Width = 50
            .Columns("Despachado").HeaderText = "Desp."
            .Columns("Despachado").ReadOnly = True
            .Columns("Despachado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Despachado").Visible = True
            .Columns("Despachado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Reasignado").Width = 50
            .Columns("Reasignado").HeaderText = "Reas."
            .Columns("Reasignado").ReadOnly = True
            .Columns("Reasignado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Reasignado").Visible = True
            .Columns("Reasignado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nro_Sub_Hijo").Width = 50
            .Columns("Nro_Sub_Hijo").HeaderText = "NSub->."
            .Columns("Nro_Sub_Hijo").ReadOnly = True
            .Columns("Nro_Sub_Hijo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Nro_Sub_Hijo").Visible = True
            .Columns("Nro_Sub_Hijo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Saldo").Width = 50
            .Columns("Saldo").HeaderText = "Saldo"
            .Columns("Saldo").ReadOnly = True
            .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo").Visible = True
            .Columns("Saldo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Refresh()

        End With

        Dim _Suma_Dias_Pdte_Preparacion, _Suma_Dias_Pdte_Cierre, _Suma_Dias_Pdte_Despacho As Integer
        Dim _Msg_Pdte_Preparacion, _Msg_Pdte_Cierre, _Msg_Pdte_Despacho As String

        Dim _Rows_Pendientes = _Ds.Tables("Pendientes").Rows(0)

        _Suma_Dias_Pdte_Preparacion = _Rows_Pendientes.Item("Pdte_Preparacion")
        _Suma_Dias_Pdte_Despacho = _Rows_Pendientes.Item("Pdte_Despacho")
        _Suma_Dias_Pdte_Cierre = _Rows_Pendientes.Item("Pdte_Cierre")

        If _Ver <> Enum_Ver.Buscar Then

            If CBool(_Suma_Dias_Pdte_Preparacion + _Suma_Dias_Pdte_Cierre + _Suma_Dias_Pdte_Despacho) Then

                If CBool(_Suma_Dias_Pdte_Preparacion) Then
                    _Msg_Pdte_Preparacion = "*** EXISTEN ORDENES PENDIENTES DE PREPARACION" & vbCrLf & vbCrLf
                End If

                If CBool(_Suma_Dias_Pdte_Cierre) Then
                    _Msg_Pdte_Cierre = "*** EXISTEN ORDENES PENDIENTES DE CIERRE" & vbCrLf & vbCrLf
                End If

                If CBool(_Suma_Dias_Pdte_Despacho) Then
                    _Msg_Pdte_Despacho = "*** EXISTEN ORDENES PENDIENTES DE DESPACHO"
                End If

                MessageBoxEx.Show(Me, _Msg_Pdte_Preparacion & _Msg_Pdte_Despacho & _Msg_Pdte_Cierre, "Hay despachos pendientes de otras fechas...",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        End If

        Sb_Pintar_Grilla_Sub_Ordenes()

        Me.Refresh()

    End Sub

    Sub Sb_Marcar_Fila(_Fila As DataGridViewRow)

        Dim _Estado = _Fila.Cells("Estado").Value

        Dim _Pdte As Integer = _Fila.Cells("Pdte_Preparacion").Value + _Fila.Cells("Pdte_Despacho").Value + _Fila.Cells("Pdte_Cierre").Value

        If _Pdte > 0 Then
            _Fila.DefaultCellStyle.ForeColor = Rojo
        End If

        Dim _ForeColor As Color = Color.White
        Dim _BackColor As Color

        Dim _Dias = _Fila.Cells("Dias").Value

        Select Case _Estado
            Case "ING"
                _BackColor = Color.FromArgb(221, 81, 69)       ' Rojo
            Case "CON", "CIN"
                _ForeColor = Color.Black
                _BackColor = Color.FromArgb(255, 187, 0)       ' Amarillo
            Case "PRE"
                _ForeColor = Color.Black
                _BackColor = Color.FromArgb(255, 187, 0)       ' Amarillo
            Case "DPR"
                _BackColor = Color.FromArgb(138, 43, 226)      ' Morado
            Case "DPO"
                _BackColor = Color.FromArgb(65, 105, 225)      ' Azul
                If _Dias > 1 Then
                    _BackColor = Color.FromArgb(220, 20, 60)   ' Rojo
                End If
            Case "CIE"
                _ForeColor = Color.Black
                _BackColor = Color.FromArgb(30, 215, 96)       ' Morado
            Case "NUL"
                _BackColor = Color.Gray
        End Select

        _Fila.Cells("Nom_Estado").Style.ForeColor = _ForeColor
        _Fila.Cells("Nom_Estado").Style.BackColor = _BackColor

        _Fila.Cells("Estado").Style.ForeColor = _ForeColor
        _Fila.Cells("Estado").Style.BackColor = _BackColor

    End Sub

    Sub Sb_Pintar_Grilla_Sub_Ordenes()

        For Each _Fila As DataGridViewRow In Grilla_Sub_Ordenes.Rows

            Dim _Estado = NuloPorNro(_Fila.Cells("Estado").Value, "")

            If Not String.IsNullOrEmpty(_Estado) Then Sb_Marcar_Fila(_Fila)

        Next

    End Sub

    Private Sub Grilla_Ordenes_Despacho_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Ordenes_Despacho.CellEnter
        Sb_Pintar_Grilla_Sub_Ordenes()
    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Dim _Cl_Despacho As New Clas_Despacho_Fx
        _Cl_Despacho.Sb_Actualizar_Despachos()
        '_Cl_Despacho.Sb_Preparacion_Correo_Por_Ordenes_De_Despacho()
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Grilla_Sub_Ordenes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Sub_Ordenes.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Sub_Ordenes.Rows(Grilla_Sub_Ordenes.CurrentRow.Index)

        Dim _Id_Despacho As Integer = _Fila.Cells("Id_Despacho").Value

        Dim _Cl_Despacho As New Clas_Despacho(False)

        _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

        Dim Fm As New Frm_Despacho
        Fm.Bloquear_Gestion = True
        Fm.Cl_Despacho = _Cl_Despacho
        Fm.ShowDialog(Me)

        _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

        If _Cl_Despacho.Estado <> _Fila.Cells("Estado").Value Then
            Sb_Actualizar_Grilla()
        End If

        Fm.Dispose()

    End Sub

    Private Sub Grilla_Doc_Productos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Doc_Productos.CellDoubleClick
        Try
            Me.Enabled = False
            Dim _Fila As DataGridViewRow = Grilla_Doc_Productos.Rows(Grilla_Doc_Productos.CurrentRow.Index)
            Dim _Idmaeedo = _Fila.Cells("Idmaeedo").Value

            Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
            Fm.Btn_Ver_Orden_de_despacho.Visible = False
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Catch ex As Exception
        Finally
            Me.Enabled = True
        End Try
    End Sub

    Private Sub Btn_Nuevo_Despacho_Click(sender As Object, e As EventArgs) Handles Btn_Nuevo_Despacho.Click

        Dim _Grabar As Boolean

        Dim _RowEntidad As DataRow
        Dim Fm_Ent As New Frm_BuscarEntidad_Mt(False)
        Fm_Ent.Text = "SELECCIONE EL CLIENTE"
        Fm_Ent.ShowDialog(Me)
        If Fm_Ent.Pro_Entidad_Seleccionada Then _RowEntidad = Fm_Ent.Pro_RowEntidad
        Fm_Ent.Dispose()

        If Not IsNothing(_RowEntidad) Then

            Dim _Cl_Despacho As New Clas_Despacho(False)
            _Cl_Despacho.Sb_Nuevo_Despacho()

            _Cl_Despacho.Tbl_Despacho.Rows(0).Item("Empresa") = ModEmpresa
            _Cl_Despacho.Tbl_Despacho.Rows(0).Item("Sucursal") = ModSucursal

            _Cl_Despacho.Row_Entidad = _RowEntidad

            Dim Fm As New Frm_Desp_01_Ingreso
            Fm.Cl_Despacho = _Cl_Despacho
            Fm.ShowDialog(Me)
            _Grabar = Fm.Grabar
            Fm.Dispose()

            If _Grabar Then

                Sb_Actualizar_Grilla()

            End If

        End If

    End Sub

    Private Sub Btn_Buscar_Despacho_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Despacho.Click

        Dim Fm As New Frm_Buscar_Orden_Despacho
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

End Class
