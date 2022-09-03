Imports DevComponents.DotNetBar
Imports System.Data.SqlClient

Public Class Frm_Despacho_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Ds_Despachos As DataSet
    Dim _Dv_Despachos As New DataView

    Dim _Despachos As New Clas_Despacho(True)
    Dim _Ver As Enum_Ver

    Dim _Ds As DataSet
    Dim _Dv As New DataView

    Enum Enum_Ver
        Ingresadas
        Proceso
        Buscar
    End Enum

    Public Sub New(Ver As Enum_Ver)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Despachos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Productos, 15, New Font("Tahoma", 7), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        _Ver = Ver

        Consulta_sql = "Select 'Todas' As Padre,'Todas...' As 'Hijo' Union Select EMPRESA+KOSU As Padre,NOKOSU As Hijo From TABSU"
        Consulta_sql = "Select EMPRESA+KOSU As Padre,NOKOSU As Hijo From TABSU"
        caract_combo(Cmb_Sucursal)
        Cmb_Sucursal.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        If _Ver = Enum_Ver.Ingresadas Then
            Cmb_Sucursal.SelectedValue = "Todas"
        Else
            Cmb_Sucursal.SelectedValue = ModEmpresa & ModSucursal
        End If

        Consulta_sql = "Select '' As Padre,'Todas...' As 'Hijo'" & vbCrLf &
                       "Union" & vbCrLf &
                       "Select Distinct CodFuncionario As Padre,NOKOFU As Hijo From " & _Global_BaseBk & "Zw_Despachos Left Join TABFU On KOFU = CodFuncionario Order By Padre"
        caract_combo(Cmb_Ejecutivo)
        Cmb_Ejecutivo.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Ejecutivo.SelectedValue = ""

        If _Ver = Enum_Ver.Ingresadas Then
            Cmb_Sucursal.SelectedValue = "Todas"
        Else
            Cmb_Sucursal.SelectedValue = ModEmpresa & ModSucursal
        End If

        Consulta_sql = "Select '' As Padre,'Todos...' As Hijo
                        Union
                        Select KORETI As Padre,NORETI As Hijo From TABRETI
                        Where KORETI In (Select CodTransportista From " & _Global_BaseBk & "Zw_Despachos_Transportistas Where Mostrar = 1)
                        Order By Padre"
        caract_combo(Cmb_Transportista)
        Cmb_Transportista.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Transportista.SelectedValue = ""

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Despacho_Clientes_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dtp_Fecha_Emision_Desde.Value = FechaDelServidor()
        Dtp_Fecha_Emision_Hasta.Value = Dtp_Fecha_Emision_Desde.Value

        Lbl_Responsable.Text = String.Empty
        Lbl_Nombre_Entidad.Text = String.Empty
        Lbl_Ciudad_Comuna.Text = String.Empty
        Lbl_Rut.Text = String.Empty
        Lbl_Telefono.Text = String.Empty
        Lbl_Direccion.Text = String.Empty
        Lbl_Email.Text = String.Empty

        Sb_Actualizar_Grilla(True)

        Btn_Nuevo_Despacho.Visible = (_Ver = Enum_Ver.Ingresadas)
        Me.Refresh()

        AddHandler Cmb_Sucursal.SelectedIndexChanged, AddressOf Cmb_Sucursal_SelectedIndexChanged
        AddHandler Cmb_Ejecutivo.SelectedIndexChanged, AddressOf Cmb_Sucursal_SelectedIndexChanged
        AddHandler Cmb_Transportista.SelectedIndexChanged, AddressOf Cmb_Sucursal_SelectedIndexChanged

        AddHandler Grilla_Despachos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Productos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    'Sub Sb_Actualizar_Grilla(_Mostrar_Informacion As Boolean)

    '    Dim _Fecha_Desde = Format(Dtp_Fecha_Emision_Desde.Value, "yyyy-MM-dd")
    '    Dim _Fecha_Hasta = Format(Dtp_Fecha_Emision_Hasta.Value, "yyyy-MM-dd")

    '    Dim _Filtro_Sucursal = String.Empty

    '    Dim _Clas_Despacho_Fx As New Clas_Despacho_Fx

    '    Dim _Fecha As Date = FechaDelServidor()

    '    Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

    '    _Ds = _Clas_Despacho_Fx.Fx_Buscar_Ordenes_De_Despacho(_Fecha_Desde, _Fecha_Hasta, Cmb_Sucursal.SelectedValue, _Ver, "", True)


    '    _Ds.Tables(0).TableName = "Ordenes"
    '    _Ds.Tables(1).TableName = "Despachos"
    '    _Ds.Tables(2).TableName = "Detalle"
    '    _Ds.Tables(3).TableName = "Productos"

    '    ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
    '    ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
    '    '_Ds.Relations.Add("Rel_Despachos_EncabezadoOrdenes",
    '    '                  _Ds.Tables("Ordenes").Columns("Nro_Despacho"),
    '    '                  _Ds.Tables("Despachos").Columns("Nro_Despacho"), False)

    '    _Ds.Relations.Add("Rel_Despachos_Detalle",
    '                      _Ds.Tables("Despachos").Columns("Id_Despacho"),
    '                      _Ds.Tables("Detalle").Columns("Id_Despacho"), False)

    '    _Ds.Relations.Add("Rel_Detalle_Productos",
    '                      _Ds.Tables("Detalle").Columns("IdD"),
    '                      _Ds.Tables("Productos").Columns("IdD"), False)

    '    Grilla_Despachos.DataSource = _Ds
    '    Grilla_Despachos.DataMember = "Despachos"

    '    Grilla_Detalle.DataSource = _Ds
    '    Grilla_Detalle.DataMember = "Despachos.Rel_Despachos_Detalle"

    '    Grilla_Productos.DataSource = _Ds
    '    Grilla_Productos.DataMember = "Despachos.Rel_Despachos_Detalle.Rel_Detalle_Productos"

    '    OcultarEncabezadoGrilla(Grilla_Ordenes, True)
    '    OcultarEncabezadoGrilla(Grilla_Despachos, True)
    '    OcultarEncabezadoGrilla(Grilla_Detalle, True)
    '    OcultarEncabezadoGrilla(Grilla_Productos, True)

    '    Lbl_Responsable.DataBindings.Clear()
    '    Lbl_Nombre_Entidad.DataBindings.Clear()
    '    Lbl_Ciudad_Comuna.DataBindings.Clear()
    '    Lbl_Rut.DataBindings.Clear()
    '    Lbl_Telefono.DataBindings.Clear()
    '    Lbl_Direccion.DataBindings.Clear()
    '    Lbl_Email.DataBindings.Clear()

    '    Lbl_Responsable.DataBindings.Add("text", _Ds, "Despachos.Responsable")
    '    Lbl_Nombre_Entidad.DataBindings.Add("text", _Ds, "Despachos.Nombre_Entidad")
    '    Lbl_Ciudad_Comuna.DataBindings.Add("text", _Ds, "Despachos.Ciudad_Comuna")
    '    Lbl_Rut.DataBindings.Add("text", _Ds, "Despachos.Rut")
    '    Lbl_Telefono.DataBindings.Add("text", _Ds, "Despachos.Telefono")
    '    Lbl_Direccion.DataBindings.Add("text", _Ds, "Despachos.Direccion")
    '    Lbl_Email.DataBindings.Add("text", _Ds, "Despachos.Email")

    '    Dim _DisplayIndex = 0

    '    With Grilla_Despachos

    '        .Columns("Nro_Despacho").Width = 70
    '        .Columns("Nro_Despacho").HeaderText = "Número"
    '        .Columns("Nro_Despacho").Visible = True
    '        .Columns("Nro_Despacho").ReadOnly = False
    '        .Columns("Nro_Despacho").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Nro_Sub").Width = 35
    '        .Columns("Nro_Sub").HeaderText = "Sub"
    '        .Columns("Nro_Sub").ReadOnly = True
    '        .Columns("Nro_Sub").Visible = True
    '        .Columns("Nro_Sub").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Sucursal").Width = 35
    '        .Columns("Sucursal").HeaderText = "Suc"
    '        .Columns("Sucursal").ReadOnly = True
    '        .Columns("Sucursal").Visible = True
    '        .Columns("Sucursal").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Estado").Width = 30
    '        .Columns("Estado").HeaderText = "Est."
    '        .Columns("Estado").ReadOnly = True
    '        .Columns("Estado").Visible = True
    '        .Columns("Estado").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Nom_Estado").Width = 150
    '        .Columns("Nom_Estado").HeaderText = "Estado"
    '        .Columns("Nom_Estado").ReadOnly = True
    '        .Columns("Nom_Estado").Visible = True
    '        .Columns("Nom_Estado").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Fecha_Emision").Width = 70
    '        .Columns("Fecha_Emision").HeaderText = "Fecha Emi."
    '        .Columns("Fecha_Emision").DefaultCellStyle.Format = "dd/MM/yyyy"
    '        .Columns("Fecha_Emision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        .Columns("Fecha_Emision").ReadOnly = True
    '        .Columns("Fecha_Emision").Visible = True
    '        .Columns("Fecha_Emision").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Rut").Width = 75
    '        .Columns("Rut").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '        .Columns("Rut").ReadOnly = True
    '        .Columns("Rut").Visible = True
    '        .Columns("Rut").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Nombre_Entidad").Width = 170
    '        .Columns("Nombre_Entidad").HeaderText = "Cliente"
    '        .Columns("Nombre_Entidad").ReadOnly = True
    '        .Columns("Nombre_Entidad").Visible = True
    '        .Columns("Nombre_Entidad").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Nom_Tipo_Envio").Width = 90
    '        .Columns("Nom_Tipo_Envio").HeaderText = "Tipo"
    '        .Columns("Nom_Tipo_Envio").ReadOnly = True
    '        .Columns("Nom_Tipo_Envio").Visible = True
    '        .Columns("Nom_Tipo_Envio").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Transportista").Width = 100
    '        .Columns("Transportista").HeaderText = "Transportista"
    '        .Columns("Transportista").ReadOnly = True
    '        .Columns("Transportista").Visible = True
    '        .Columns("Transportista").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Nombre_Crea").Width = 110
    '        .Columns("Nombre_Crea").HeaderText = "Ejecutivo"
    '        .Columns("Nombre_Crea").ReadOnly = True
    '        .Columns("Nombre_Crea").Visible = True
    '        .Columns("Nombre_Crea").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Refresh()

    '    End With

    '    _DisplayIndex = 0

    '    With Grilla_Detalle

    '        .Columns("Tido").Width = 30
    '        .Columns("Tido").HeaderText = "TD"
    '        .Columns("Tido").Visible = True
    '        .Columns("Tido").ReadOnly = False
    '        .Columns("Tido").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Nudo").Width = 80
    '        .Columns("Nudo").HeaderText = "Número"
    '        .Columns("Nudo").ReadOnly = True
    '        .Columns("Nudo").Visible = True
    '        .Columns("Nudo").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("FEEMDO").Width = 80
    '        .Columns("FEEMDO").HeaderText = "F.Emisión"
    '        .Columns("FEEMDO").ReadOnly = True
    '        .Columns("FEEMDO").Visible = True
    '        .Columns("FEEMDO").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("FEER").Width = 80
    '        .Columns("FEER").HeaderText = "F.Ret/Des"
    '        .Columns("FEER").ReadOnly = True
    '        .Columns("FEER").Visible = True
    '        .Columns("FEER").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Razon").Width = 300
    '        .Columns("Razon").HeaderText = "Razón Social"
    '        .Columns("Razon").ReadOnly = True
    '        .Columns("Razon").Visible = True
    '        .Columns("Razon").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Refresh()

    '    End With


    '    _DisplayIndex = 0

    '    With Grilla_Productos

    '        .Columns("Bodega").Width = 35
    '        .Columns("Bodega").HeaderText = "Bod"
    '        .Columns("Bodega").Visible = True
    '        .Columns("Bodega").ReadOnly = False
    '        .Columns("Bodega").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Codigo").Width = 85
    '        .Columns("Codigo").HeaderText = "Código"
    '        .Columns("Codigo").ReadOnly = True
    '        .Columns("Codigo").Visible = True
    '        .Columns("Codigo").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Descripcion").Width = 210
    '        .Columns("Descripcion").HeaderText = "Descripción"
    '        .Columns("Descripcion").ReadOnly = True
    '        .Columns("Descripcion").Visible = True
    '        .Columns("Descripcion").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("UdTrans").Width = 25
    '        .Columns("UdTrans").HeaderText = "Ud"
    '        .Columns("UdTrans").ReadOnly = True
    '        .Columns("UdTrans").Visible = True
    '        .Columns("UdTrans").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Cantidad").Width = 45
    '        .Columns("Cantidad").HeaderText = "Cant."
    '        .Columns("Cantidad").ReadOnly = True
    '        .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '        .Columns("Cantidad").Visible = True
    '        .Columns("Cantidad").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Despachado").Width = 45
    '        .Columns("Despachado").HeaderText = "Desp."
    '        .Columns("Despachado").ReadOnly = True
    '        .Columns("Despachado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '        .Columns("Despachado").Visible = True
    '        .Columns("Despachado").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Reasignado").Width = 45
    '        .Columns("Reasignado").HeaderText = "Reas."
    '        .Columns("Reasignado").ReadOnly = True
    '        .Columns("Reasignado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '        .Columns("Reasignado").Visible = True
    '        .Columns("Reasignado").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Columns("Saldo").Width = 45
    '        .Columns("Saldo").HeaderText = "Saldo"
    '        .Columns("Saldo").ReadOnly = True
    '        .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '        .Columns("Saldo").Visible = True
    '        .Columns("Saldo").DisplayIndex = _DisplayIndex
    '        _DisplayIndex += 1

    '        .Refresh()

    '    End With

    '    If _Mostrar_Informacion Then

    '        Dim _Suma_Dias_Pdte_Preparacion, _Suma_Dias_Pdte_Cierre, _Suma_Dias_Pdte_Despacho As Integer
    '        Dim _Msg_Pdte_Preparacion, _Msg_Pdte_Cierre, _Msg_Pdte_Despacho As String

    '        Dim _Rows_Pendientes = _Ds.Tables("Pendientes").Rows(0)

    '        _Suma_Dias_Pdte_Preparacion = _Rows_Pendientes.Item("Pdte_Preparacion")
    '        _Suma_Dias_Pdte_Despacho = _Rows_Pendientes.Item("Pdte_Despacho")
    '        _Suma_Dias_Pdte_Cierre = _Rows_Pendientes.Item("Pdte_Cierre")

    '        If _Ver <> Enum_Ver.Buscar Then

    '            If CBool(_Suma_Dias_Pdte_Preparacion + _Suma_Dias_Pdte_Cierre + _Suma_Dias_Pdte_Despacho) Then

    '                If CBool(_Suma_Dias_Pdte_Preparacion) Then
    '                    _Msg_Pdte_Preparacion = "*** EXISTEN ORDENES PENDIENTES DE PREPARACION" & vbCrLf & vbCrLf
    '                End If

    '                If CBool(_Suma_Dias_Pdte_Cierre) Then
    '                    _Msg_Pdte_Cierre = "*** EXISTEN ORDENES PENDIENTES DE CIERRE" & vbCrLf & vbCrLf
    '                End If

    '                If CBool(_Suma_Dias_Pdte_Despacho) Then
    '                    _Msg_Pdte_Despacho = "*** EXISTEN ORDENES PENDIENTES DE DESPACHO"
    '                End If

    '                MessageBoxEx.Show(Me, _Msg_Pdte_Preparacion & _Msg_Pdte_Despacho & _Msg_Pdte_Cierre, "Hay despachos pendientes de otras fechas...",
    '                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

    '            End If

    '        End If

    '    End If

    '    For Each _Fila As DataGridViewRow In Grilla_Despachos.Rows

    '        Sb_Marcar_Fila(_Fila)

    '    Next

    '    Me.Refresh()

    'End Sub

    Sub Sb_Actualizar_Grilla(_Mostrar_Informacion As Boolean)

        Try
            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor


            Dim _Fecha_Desde = Format(Dtp_Fecha_Emision_Desde.Value, "yyyy-MM-dd")
            Dim _Fecha_Hasta = Format(Dtp_Fecha_Emision_Hasta.Value, "yyyy-MM-dd")

            Dim _Filtro_Sucursal = String.Empty
            Dim _Filtro_Ejecutivo = String.Empty
            Dim _Filtro_Transportista = String.Empty

            Dim _Fecha As Date = FechaDelServidor()

            If Cmb_Sucursal.SelectedValue <> "Todas" Then
                _Filtro_Sucursal = " And Desp.Empresa+Desp.Sucursal = '" & Cmb_Sucursal.SelectedValue & "' "
            End If

            If Cmb_Transportista.SelectedValue <> "" Then
                _Filtro_Transportista = "Delete #Paso_Desp Where Transportista <> '" & Cmb_Transportista.SelectedValue.ToString.Trim & "'"
            End If

            If Cmb_Ejecutivo.SelectedValue <> "" Then
                _Filtro_Ejecutivo = "Delete #Paso_Desp Where CodFuncionario_Crea <> '" & Cmb_Ejecutivo.SelectedValue.ToString.Trim & "' "
            End If

            Consulta_sql = "Select Doc2.CodFuncionario As CodFuncionario_Crea,Tf2.NOKOFU As Nombre_Crea,Desp.*," &
                            "Case When Est_Desp.Fecha_Fijacion Is Null Then DATEDIFF(D,Desp.Fecha_Emision,Getdate()) Else DATEDIFF(D,Est_Desp.Fecha_Fijacion,Getdate()) End As Dias,
                        Tdesp.NombreTabla As Nom_Tipo_Despacho," &
                            "Case When Desp.Sucursal_Retiro = '' Then Tenvi.NombreTabla Else Tenvi.NombreTabla+' -> '+Ltrim(Rtrim(Desp.Sucursal_Retiro)) End As Nom_Tipo_Envio," &
                            "Tventa.NombreTabla As Nom_Tipo_Venta,Testa.NombreTabla As Nom_Estado,Rtrim(Ltrim(Desp.Ciudad))+', '+Rtrim(Ltrim(Desp.Comuna)) As Ciudad_Comuna,Tf1.NOKOFU As Responsable,
                        Cast(0 As Int) As Pdte_Preparacion,Cast(0 As Int) As Pdte_Despacho,Cast(0 As Int) As Pdte_Cierre
                        Into #Paso_Desp
                        From " & _Global_BaseBk & "Zw_Despachos Desp
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Testa On Testa.Tabla = 'SIS_DESPACHO_ESTADOS' And Desp.Estado = Testa.CodigoTabla 
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tdesp On Tdesp.Tabla = 'SIS_DESPACHO_TIPO_DESPACHO' And Desp.Tipo_Despacho = Tdesp.CodigoTabla 
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tenvi On Tenvi.Tabla = 'SIS_DESPACHO_TIPO_ENVIO' And Desp.Tipo_Envio = Tenvi.CodigoTabla 
                        Left Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Tventa On Tventa.Tabla = 'SIS_DESPACHO_TIPO_VENTA' And Desp.Tipo_Venta = Tventa.CodigoTabla                         
                        Left Join TABFU Tf1 On Tf1.KOFU = CodFuncionario    
                        Left Join " & _Global_BaseBk & "Zw_Despachos_Estados Est_Desp On Desp.Id_Despacho = Est_Desp.Id_Despacho And Est_Desp.Estado = 'DPR'
                        Left Join " & _Global_BaseBk & "Zw_Despachos Doc2 On Doc2.Id_Despacho = Desp.Id_Despacho_Padre
						Left Join TABFU Tf2 On Tf2.KOFU = Doc2.CodFuncionario    
                        Where 1 > 0 
                        And Desp.Confirmado In (1) 
                        And (Desp.Estado In ('CIN','CON','PRE','DPR','DPO') " & _Filtro_Sucursal & ")
						      Or Desp.Id_Despacho In (Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos 
						      Where Estado = 'CIE' And Nro_Sub <> '000' And Fecha_Cierre Between Convert(Datetime, '" & _Fecha_Desde & " 00:00:00',102) " &
                                  "And Convert(Datetime, '" & _Fecha_Hasta & " 23:59:59',102)" & _Filtro_Sucursal & ")

                        Delete #Paso_Desp Where Nro_Encomienda = 'XXX'    

                        " & _Filtro_Transportista & "
                        " & _Filtro_Ejecutivo & "

                        Select Doc.*,Edo.FEEMDO,Edo.FEER,Edo.ESPGDO,Ent.NOKOEN As Razon,
                        Rtrim(Ltrim(Str(Doc.Id_Despacho)))+Rtrim(Ltrim(Str(Doc.Idrst))) As IdD         
                        Into #Paso_Doc
                        From " & _Global_BaseBk & "Zw_Despachos_Doc Doc
							Left Join MAEEDO Edo On Edo.IDMAEEDO = Doc.Idrst And Doc.Archidrst = 'MAEEDO'
							Left Join MAEEN Ent On Edo.ENDO = Ent.KOEN And Edo.SUENDO = Ent.SUEN 

                        Where Id_Despacho In (Select Id_Despacho From #Paso_Desp) And Activo = 1

                        Select Det.*,
                        Case Untrans When 1 Then CantCUd1 Else CantCUd2 End As Cantidad,
						Case Untrans When 1 Then CantDUd1 Else CantDUd2 End As Despachado,
						Case Untrans When 1 Then CantEUd1 Else CantEUd2 End As DespachadoE,
						Case Untrans When 1 Then CantRUd1 Else CantRUd2 End As Reasignado,
						Case Untrans When 1 Then CantCUd1-(CantDUd1+CantEUd1+CantRUd1) Else CantCUd2-(CantDUd2+CantEUd2+CantRUd1) End As Saldo,
                        Rtrim(Ltrim(Str(Det.Id_Despacho)))+Rtrim(Ltrim(Str(Det.Idmaeedo))) As IdD,
                        Cast(0 As Int) As Id_Despacho_Hijo,	
						Cast('' As Varchar(3)) As Nro_Sub_Hijo
                        Into #Paso_Det
                        From " & _Global_BaseBk & "Zw_Despachos_Doc_Det Det
                        Where Id_Despacho In (Select Id_Despacho From #Paso_Desp)

                        Update #Paso_Det Set Id_Despacho_Hijo = Isnull((Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos_Doc_Det Desp 
										 Where Desp.Archirst = 'Id_Detalle' And Desp.Idrst = #Paso_Det.Id_Detalle),0)
                        From #Paso_Det

                        Update #Paso_Det Set Nro_Sub_Hijo = (Select Nro_Sub From " & _Global_BaseBk & "Zw_Despachos Where Id_Despacho = Id_Despacho_Hijo)


                        Update #Paso_Desp Set Pdte_Preparacion = 1 Where Dias > 0 And Estado = 'PRE'    
                        Update #Paso_Desp Set Pdte_Despacho = 1 Where Dias > 0 And Estado = 'DPR'
                        Update #Paso_Desp Set Pdte_Preparacion = 1 Where Dias > 0 And Estado = 'DPO'    
                        
                        Select * From #Paso_Desp Where Estado <> 'CIN' Order By Fecha_Emision,Nro_Despacho
                        Select * From #Paso_Doc
                        Select * From #Paso_Det 

                        Select Isnull(Sum(Pdte_Preparacion),0) As Pdte_Preparacion,Isnull(Sum(Pdte_Despacho),0) As Pdte_Despacho,Isnull(Sum(Pdte_Cierre),0) As Pdte_Cierre
                        From #Paso_Desp
    
                        Select Nro_Despacho,Nro_Sub,Sucursal,Estado,Nom_Estado,Fecha_Emision,Rut,Nombre_Entidad,Nom_Tipo_Envio,Transportista,Nombre_Crea From #Paso_Desp Where Estado <> 'CIN'    

                        Drop table #Paso_Desp
                        Drop table #Paso_Doc
                        Drop table #Paso_Det"

            _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

            _Ds.Tables(0).TableName = "Despachos"
            _Ds.Tables(1).TableName = "Detalle"
            _Ds.Tables(2).TableName = "Productos"
            _Ds.Tables(3).TableName = "Pendientes"
            _Ds.Tables(4).TableName = "Excel"

            ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
            '_Ds.Relations.Add("Rel_Despachos_EncabezadoOrdenes",
            '                  _Ds.Tables("Ordenes").Columns("Nro_Despacho"),
            '                  _Ds.Tables("Despachos").Columns("Nro_Despacho"), False)

            _Ds.Relations.Add("Rel_Despachos_Detalle",
                              _Ds.Tables("Despachos").Columns("Id_Despacho"),
                              _Ds.Tables("Detalle").Columns("Id_Despacho"), False)

            _Ds.Relations.Add("Rel_Detalle_Productos",
                              _Ds.Tables("Detalle").Columns("IdD"),
                              _Ds.Tables("Productos").Columns("IdD"), False)

            '_Dv.Table = _Ds.Tables("Despachos")

            'Grilla.DataSource = _Dv

            Grilla_Despachos.DataSource = _Ds
            Grilla_Despachos.DataMember = "Despachos"

            Grilla_Detalle.DataSource = _Ds
            Grilla_Detalle.DataMember = "Despachos.Rel_Despachos_Detalle"

            Grilla_Productos.DataSource = _Ds
            Grilla_Productos.DataMember = "Despachos.Rel_Despachos_Detalle.Rel_Detalle_Productos"

            OcultarEncabezadoGrilla(Grilla_Ordenes, True)
            OcultarEncabezadoGrilla(Grilla_Despachos, True)
            OcultarEncabezadoGrilla(Grilla_Detalle, True)
            OcultarEncabezadoGrilla(Grilla_Productos, True)

            Lbl_Responsable.DataBindings.Clear()
            Lbl_Nombre_Entidad.DataBindings.Clear()
            Lbl_Ciudad_Comuna.DataBindings.Clear()
            Lbl_Rut.DataBindings.Clear()
            Lbl_Telefono.DataBindings.Clear()
            Lbl_Direccion.DataBindings.Clear()
            Lbl_Email.DataBindings.Clear()

            Lbl_Responsable.DataBindings.Add("text", _Ds, "Despachos.Nombre_Crea")
            Lbl_Nombre_Entidad.DataBindings.Add("text", _Ds, "Despachos.Nombre_Entidad")
            Lbl_Ciudad_Comuna.DataBindings.Add("text", _Ds, "Despachos.Ciudad_Comuna")
            Lbl_Rut.DataBindings.Add("text", _Ds, "Despachos.Rut")
            Lbl_Telefono.DataBindings.Add("text", _Ds, "Despachos.Telefono")
            Lbl_Direccion.DataBindings.Add("text", _Ds, "Despachos.Direccion")
            Lbl_Email.DataBindings.Add("text", _Ds, "Despachos.Email")

            OcultarEncabezadoGrilla(Grilla_Despachos, True)

            Dim _DisplayIndex = 0

            With Grilla_Despachos

                .Columns("Nro_Despacho").Width = 70
                .Columns("Nro_Despacho").HeaderText = "Número"
                .Columns("Nro_Despacho").Visible = True
                .Columns("Nro_Despacho").ReadOnly = False
                .Columns("Nro_Despacho").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

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

                .Columns("Nom_Estado").Width = 80
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

                .Columns("Rut").Width = 75
                .Columns("Rut").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Rut").ReadOnly = True
                .Columns("Rut").Visible = True
                .Columns("Rut").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Nombre_Entidad").Width = 170 + 35
                .Columns("Nombre_Entidad").HeaderText = "Cliente"
                .Columns("Nombre_Entidad").ReadOnly = True
                .Columns("Nombre_Entidad").Visible = True
                .Columns("Nombre_Entidad").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Nom_Tipo_Envio").Width = 90
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

                .Columns("Nombre_Crea").Width = 110 + 30
                .Columns("Nombre_Crea").HeaderText = "Ejecutivo"
                .Columns("Nombre_Crea").ReadOnly = True
                .Columns("Nombre_Crea").Visible = True
                .Columns("Nombre_Crea").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Refresh()

            End With

            _DisplayIndex = 0

            With Grilla_Detalle

                .Columns("Tido").Width = 30
                .Columns("Tido").HeaderText = "TD"
                .Columns("Tido").Visible = True
                .Columns("Tido").ReadOnly = False
                .Columns("Tido").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Nudo").Width = 80
                .Columns("Nudo").HeaderText = "Número"
                .Columns("Nudo").ReadOnly = True
                .Columns("Nudo").Visible = True
                .Columns("Nudo").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("FEEMDO").Width = 80
                .Columns("FEEMDO").HeaderText = "F.Emisión"
                .Columns("FEEMDO").ReadOnly = True
                .Columns("FEEMDO").Visible = True
                .Columns("FEEMDO").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("FEER").Width = 80
                .Columns("FEER").HeaderText = "F.Ret/Des"
                .Columns("FEER").ReadOnly = True
                .Columns("FEER").Visible = True
                .Columns("FEER").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Razon").Width = 300
                .Columns("Razon").HeaderText = "Razón Social"
                .Columns("Razon").ReadOnly = True
                .Columns("Razon").Visible = True
                .Columns("Razon").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Refresh()

            End With

            _DisplayIndex = 0

            With Grilla_Productos

                .Columns("Bodega").Width = 35
                .Columns("Bodega").HeaderText = "Bod"
                .Columns("Bodega").Visible = True
                .Columns("Bodega").ReadOnly = False
                .Columns("Bodega").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Codigo").Width = 85
                .Columns("Codigo").HeaderText = "Código"
                .Columns("Codigo").ReadOnly = True
                .Columns("Codigo").Visible = True
                .Columns("Codigo").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Descripcion").Width = 210
                .Columns("Descripcion").HeaderText = "Descripción"
                .Columns("Descripcion").ReadOnly = True
                .Columns("Descripcion").Visible = True
                .Columns("Descripcion").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("UdTrans").Width = 25
                .Columns("UdTrans").HeaderText = "Ud"
                .Columns("UdTrans").ReadOnly = True
                .Columns("UdTrans").Visible = True
                .Columns("UdTrans").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Cantidad").Width = 45
                .Columns("Cantidad").HeaderText = "Cant."
                .Columns("Cantidad").ReadOnly = True
                .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Cantidad").Visible = True
                .Columns("Cantidad").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Despachado").Width = 45
                .Columns("Despachado").HeaderText = "Desp."
                .Columns("Despachado").ReadOnly = True
                .Columns("Despachado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Despachado").Visible = True
                .Columns("Despachado").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Reasignado").Width = 45
                .Columns("Reasignado").HeaderText = "Reas."
                .Columns("Reasignado").ReadOnly = True
                .Columns("Reasignado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Reasignado").Visible = True
                .Columns("Reasignado").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Columns("Saldo").Width = 45
                .Columns("Saldo").HeaderText = "Saldo"
                .Columns("Saldo").ReadOnly = True
                .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Saldo").Visible = True
                .Columns("Saldo").DisplayIndex = _DisplayIndex
                _DisplayIndex += 1

                .Refresh()

            End With


            If _Mostrar_Informacion Then

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

            End If

            For Each _Fila As DataGridViewRow In Grilla_Despachos.Rows
                Sb_Marcar_Fila(_Fila)
            Next

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Refresh()
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try

    End Sub

    Sub Sb_Pintar_Grilla_Despachos()

        For Each _Fila As DataGridViewRow In Grilla_Despachos.Rows

            Sb_Marcar_Fila(_Fila)

        Next

    End Sub

    Sub Sb_Marcar_Fila(_Fila As DataGridViewRow)

        Dim _Estado = _Fila.Cells("Estado").Value
        Dim _ForeColor As Color = Color.White
        Dim _BackColor As Color

        Dim _Pdte As Integer = _Fila.Cells("Pdte_Preparacion").Value + _Fila.Cells("Pdte_Despacho").Value + _Fila.Cells("Pdte_Cierre").Value

        If _Pdte > 0 Then
            _Fila.DefaultCellStyle.ForeColor = Rojo
        End If

        Dim _Dias = _Fila.Cells("Dias").Value

        Select Case _Estado
            Case "ING"
                _BackColor = Color.FromArgb(221, 81, 69)       ' Rojo
            Case "CON"
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

                Sb_Actualizar_Grilla(False)

            End If

        End If

    End Sub

    Private Sub Grilla_Despachos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Despachos.CellDoubleClick

        Dim _Cabeza = Grilla_Despachos.Columns(Grilla_Despachos.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Despachos.Rows(Grilla_Despachos.CurrentRow.Index)

        Dim _Id_Despacho As Integer = _Fila.Cells("Id_Despacho").Value

        Dim _Cl_Despacho As New Clas_Despacho(False)
        _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

        If _Cl_Despacho.Fx_Se_Puede_Editar_La_Orden(Me) Then

            Btn_Accion_Confirmar.Visible = False
            Btn_Accion_Preparar.Visible = False
            Btn_Accion_Despachar.Visible = False
            Btn_Accion_Cerrar.Visible = False

            Dim _Estado = _Cl_Despacho.Tbl_Despacho.Rows(0).Item("Estado")
            Dim _Estado_Fila = _Fila.Cells("Estado").Value

            If _Estado <> _Estado_Fila Then
                MessageBoxEx.Show(Me, "El estado de la orden ha cambiado en este intertanto, se actualizara el listado", "Orden gestionada",
                                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Sb_Actualizar_Grilla(False)
                Return
            End If

            If _Cabeza = "Nom_Estado" Or _Cabeza = "Estado" Then

                Select Case _Estado
                    Case "ING", "CIE"
                        Call Btn_Ver_Despacho_Click(Nothing, Nothing)
                    Case "CON"
                    Case "PRE"
                        Call Btn_Accion_Preparar_Click(Nothing, Nothing)
                    Case "DPR"
                        Call Btn_Accion_Despachar_Click(Nothing, Nothing)
                    Case "DPO"
                        Call Btn_Accion_Cerrar_Click(Nothing, Nothing)
                    Case Else
                        Beep()
                End Select

            Else

                Select Case _Estado
                    Case "ING"
                        Btn_Accion_Confirmar.Visible = True
                    Case "CON"
                    Case "PRE"
                        Btn_Accion_Preparar.Visible = True
                    Case "DPR"
                        Btn_Accion_Despachar.Visible = True
                    Case "DPO"
                        Btn_Accion_Cerrar.Visible = True
                    Case "CIE"
                    Case "NUL"
                End Select

                ShowContextMenu(Menu_Contextual_Productos)

            End If

        End If

    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click

        Dim Fm_Espera As New Frm_Form_Esperar
        Fm_Espera.BarraCircular.IsRunning = True
        Fm_Espera.Show()

        'Dim _Cl_Despacho As New Clas_Despacho_Fx
        '_Cl_Despacho.Sb_Actualizar_Despachos()
        Sb_Actualizar_Grilla(False)

        Fm_Espera.Dispose()

    End Sub

    Private Sub Btn_Ver_Despacho_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Despacho.Click

        Dim _Fila As DataGridViewRow = Grilla_Despachos.Rows(Grilla_Despachos.CurrentRow.Index)

        Dim _Id_Despacho As Integer = _Fila.Cells("Id_Despacho").Value

        Dim _Cl_Despacho As New Clas_Despacho(False)

        _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

        If _Cl_Despacho.Fx_Se_Puede_Editar_La_Orden(Me) Then

            Dim Fm As New Frm_Despacho
            Fm.No_Autorizar_Gestion = True
            Fm.Cl_Despacho = _Cl_Despacho
            Fm.ShowDialog(Me)

            _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

            If _Cl_Despacho.Estado <> _Fila.Cells("Estado").Value Then
                Sb_Actualizar_Grilla(False)
            End If

            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Accion_Confirmar_Click(sender As Object, e As EventArgs) Handles Btn_Accion_Confirmar.Click

        Dim _Fila As DataGridViewRow = Grilla_Despachos.Rows(Grilla_Despachos.CurrentRow.Index)

        Dim _Id_Despacho As Integer = _Fila.Cells("Id_Despacho").Value
        Dim _Nro_Despacho As String = _Fila.Cells("Nro_Despacho").Value

        Dim _Cl_Despacho As New Clas_Despacho(False)

        _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

        If _Cl_Despacho.Fx_Se_Puede_Confirmar_La_Orden(Me) Then

            If _Cl_Despacho.Fx_Se_Puede_Editar_La_Orden(Me) Then

                If _Cl_Despacho.Fx_Tomar_Orden_Despacho(_Id_Despacho, FUNCIONARIO) Then

                    Dim Fm As New Frm_Despacho
                    Fm.Cl_Despacho = _Cl_Despacho
                    Fm.ShowDialog(Me)

                    _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

                    If _Cl_Despacho.Estado <> _Fila.Cells("Estado").Value Then
                        Sb_Actualizar_Grilla(False)
                        BuscarDatoEnGrilla(_Nro_Despacho, "Nro_Despacho", Grilla_Despachos)
                    End If

                    Fm.Dispose()

                End If

            End If

        End If

    End Sub

    Private Sub Btn_Accion_Preparar_Click(sender As Object, e As EventArgs) Handles Btn_Accion_Preparar.Click

        If Cmb_Sucursal.SelectedValue <> ModEmpresa & ModSucursal Then

            MessageBoxEx.Show(Me, "Esta acción solo esta permitidad con la modalidad de la sucursal", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        If Fx_Tiene_Permiso(Me, "ODp00005") Then

            Try

                Dim _Fila As DataGridViewRow = Grilla_Despachos.Rows(Grilla_Despachos.CurrentRow.Index)

                Dim _Preparado As Boolean

                Dim _Id_Despacho As Integer = _Fila.Cells("Id_Despacho").Value
                Dim _Nro_Despacho As String = _Fila.Cells("Nro_Despacho").Value

                Dim _Cl_Despacho As New Clas_Despacho(False)
                _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

                If _Cl_Despacho.Fx_Se_Puede_Editar_La_Orden(Me) Then

                    Dim _Entregar_Con_Doc_Pagados As Boolean = _Cl_Despacho.Tbl_Despacho.Rows(0).Item("Entregar_Con_Doc_Pagados")

                    If _Entregar_Con_Doc_Pagados Then

                        Dim _Saldo As Double = _Sql.Fx_Trae_Dato("MAEEDO", "Sum(VABRDO)-Sum(VAABDO)",
                                                       "IDMAEEDO In (Select Idrst From " & _Global_BaseBk & "Zw_Despachos_Doc Where Id_Despacho = " & _Cl_Despacho.Id_Despacho & ")", True)

                        If _Saldo > 1 Then
                            MessageBoxEx.Show(Me, "No puede entregar estos productos" & vbCrLf &
                                              "Existen documentos sin pagar", "Validación",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return
                        End If

                    End If

                    If _Cl_Despacho.Fx_Tomar_Orden_Despacho(_Id_Despacho, FUNCIONARIO) Then

                        Dim Fm As New Frm_Desp_03_Preparar_Armar_Bulto
                        Fm.Text = "PREPARAR PEDIDO - ARMAR BULTO. Nro. Orden Despacho: " & _Cl_Despacho.Nro_Despacho
                        Fm.Despachos = _Cl_Despacho
                        Fm.ShowDialog(Me)
                        _Preparado = Fm.Preparado
                        Fm.Dispose()

                        If _Preparado Then

                            _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

                            Dim _Tipo_Envio = _Cl_Despacho.Row_Despacho.Item("Tipo_Envio").ToString.Trim

                            If _Tipo_Envio <> "RT" And _Tipo_Envio <> "RR" Then

                                'Dim _Cl_Imprimir_Despacho As New Clas_Imprimir_Despacho(_Cl_Despacho)
                                '_Cl_Imprimir_Despacho.Fx_Imprimir_Archivo_Tam_Carta(Me, "Letrero", "")
                                Dim _Cl_Imprimir_Despacho As New Clas_Imprimir_Despacho(_Cl_Despacho)
                                _Cl_Imprimir_Despacho.Sb_Imprimir_Letrero(Me)

                            End If

                            If _Cl_Despacho.Estado = "DPR" And (_Tipo_Envio = "RT" Or _Tipo_Envio = "RR") Then
                                Call Btn_Accion_Despachar_Click(Nothing, Nothing)
                            End If

                            Sb_Actualizar_Grilla(False)
                            BuscarDatoEnGrilla(_Nro_Despacho, "Nro_Despacho", Grilla_Despachos)

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub Btn_Accion_Despachar_Click(sender As Object, e As EventArgs) Handles Btn_Accion_Despachar.Click

        If Cmb_Sucursal.SelectedValue <> ModEmpresa & ModSucursal Then

            MessageBoxEx.Show(Me, "Esta acción solo esta permitidad con la modalidad de la sucursal", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        If Fx_Tiene_Permiso(Me, "ODp00006") Then

            Dim _Fila As DataGridViewRow = Grilla_Despachos.Rows(Grilla_Despachos.CurrentRow.Index)

            Dim _Id_Despacho As Integer = _Fila.Cells("Id_Despacho").Value
            Dim _Nro_Despacho As String = _Fila.Cells("Nro_Despacho").Value
            Dim _Despachado As Boolean
            Dim _Cl_Despacho As New Clas_Despacho(False)
            _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

            If _Cl_Despacho.Fx_Se_Puede_Editar_La_Orden(Me) Then

                If _Cl_Despacho.Fx_Se_Puede_Editar_La_Orden(Me) Then

                    If _Cl_Despacho.Fx_Tomar_Orden_Despacho(_Id_Despacho, FUNCIONARIO) Then

                        Dim Fm As New Frm_Desp_04_Depachar
                        Fm.Despachos = _Cl_Despacho
                        Fm.ShowDialog(Me)
                        _Despachado = Fm.Despachado
                        Fm.Dispose()

                        If _Despachado Then

                            MessageBoxEx.Show(Me, "Documento despachado, en espera de cierre.", "Despachado", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Sb_Actualizar_Grilla(False)
                            BuscarDatoEnGrilla(_Nro_Despacho, "Nro_Despacho", Grilla_Despachos)

                        End If

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub Btn_Accion_Cerrar_Click(sender As Object, e As EventArgs) Handles Btn_Accion_Cerrar.Click

        If Cmb_Sucursal.SelectedValue <> ModEmpresa & ModSucursal Then

            If Not Fx_Tiene_Permiso(Me, "ODp00015") Then
                Return
            End If

        End If

        If Fx_Tiene_Permiso(Me, "ODp00008") Then

            Dim _Fila As DataGridViewRow = Grilla_Despachos.Rows(Grilla_Despachos.CurrentRow.Index)

            Dim _Id_Despacho As Integer = _Fila.Cells("Id_Despacho").Value
            Dim _Nro_Despacho As String = _Fila.Cells("Nro_Despacho").Value
            Dim _Nro_Sub As String = _Fila.Cells("Nro_Sub").Value
            Dim _Cerrado As Boolean
            Dim _Cl_Despacho As New Clas_Despacho(False)

            _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

            If _Cl_Despacho.Fx_Se_Puede_Editar_La_Orden(Me) Then

                If _Cl_Despacho.Fx_Tomar_Orden_Despacho(_Id_Despacho, FUNCIONARIO) Then

                    Dim Fm As New Frm_Desp_05_Cerrar
                    Fm.Despachos = _Cl_Despacho

                    If Cmb_Sucursal.SelectedValue <> ModEmpresa & ModSucursal Then
                        Fm.Txt_Observaciones.Text = "CERRADO DESDE MODALIDAD " & Modalidad
                    End If

                    Fm.ShowDialog(Me)
                    _Cerrado = Fm.Cerrado
                    Fm.Dispose()

                    If _Cerrado Then

                        MessageBoxEx.Show(Me, "Documento cerrado" & vbCrLf & vbCrLf & "Orden Nro: " & _Nro_Despacho & " - Sub: " & _Nro_Sub, "Preparación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Sb_Actualizar_Grilla(False)
                        BuscarDatoEnGrilla(_Nro_Despacho, "Nro_Despacho", Grilla_Despachos)

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub Grilla_Detalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Detalle.CellDoubleClick

        Try
            Me.Enabled = False
            Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)
            Dim _Idmaeedo = _Fila.Cells("Idrst").Value

            Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
            Fm.Btn_Ver_Orden_de_despacho.Visible = False
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Catch ex As Exception
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub Cmb_Sucursal_SelectedIndexChanged(sender As Object, e As EventArgs)
        Sb_Actualizar_Grilla(False)
    End Sub

    Private Sub Grilla_Ordenes_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Ordenes.CellEnter
        Sb_Pintar_Grilla_Despachos()
    End Sub

    Private Sub Frm_Despacho_Lista_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Despachos_Tom Where NombreEquipo = '" & _NombreEquipo & "'"
        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

    End Sub

    Private Sub BtnExportarExcel_Click(sender As Object, e As EventArgs) Handles BtnExportarExcel.Click
        ExportarTabla_JetExcel_Tabla(_Ds.Tables("Excel"), Me, "Despachos")
    End Sub

    Private Sub Txt_Buscar_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Buscar.KeyDown
        If e.KeyValue = Keys.Enter Then
            _Dv.RowFilter = String.Format("Nro_Despacho+Transportista+Nombre_Crea Like '%{0}%'", Txt_Buscar.Text.Trim)
            'Nro_Despacho,Nro_Sub,Sucursal,Estado,Nom_Estado,Fecha_Emision,Rut,Nombre_Entidad,Nom_Tipo_Envio,Transportista,Nombre_Crea From #Paso_Desp Where Estado <> 'CIN'    
            '_Dv.RowFilter = String.Format("Descripcion Like '%{0}%' And Descripcion Like '%{1}%' And Descripcion Like '%{2}%'", _A, _B, _C)
        End If
    End Sub
End Class
