Imports DevComponents.DotNetBar

Public Class Frm_Despacho

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Info_Estado_A_Realizar As String

    Dim _Cl_Despacho As Clas_Despacho
    Dim _No_Autorizar_Gestion

    Public Property Cl_Despacho As Clas_Despacho
        Get
            Return _Cl_Despacho
        End Get
        Set(value As Clas_Despacho)
            _Cl_Despacho = value
        End Set
    End Property

    Public Property Correr_a_la_derecha As Boolean
    Public Property Bloquear_Gestion As Boolean

    Public Property No_Autorizar_Gestion As Object
        Get
            Return _No_Autorizar_Gestion
        End Get
        Set(value As Object)
            _No_Autorizar_Gestion = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Txt_Datos_Entidad_Direccion.Text = String.Empty

        Sb_Formato_Generico_Grilla(Grilla_Documentos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Productos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Lbl_Transporte.Text = String.Empty
        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Despacho_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Correr_a_la_derecha Then
            Me.Top += 20
            Me.Left += 20
        End If

        Sb_Cargar_Despacho()

        SuperTabItem2.Visible = _Cl_Despacho.Row_Despacho.Item("Confirmado")
        SuperTabItem3.Visible = _Cl_Despacho.Row_Despacho.Item("Confirmado")

    End Sub

    Sub Sb_Cargar_Despacho()

        Dim _Row_Despacho As DataRow = _Cl_Despacho.Tbl_Despacho(0)

        Me.Text = "ORDEN DE DESPACHO (Id: " & _Cl_Despacho.Id_Despacho & ")"

        Txt_Datos_Entidad_Direccion.Text = _Cl_Despacho.Row_Entidad.Item("NOKOEN") & vbCrLf &
                               _Cl_Despacho.Row_Entidad.Item("Rut") & vbCrLf & vbCrLf &
                               _Row_Despacho.Item("Direccion") & vbCrLf &
                               _Row_Despacho.Item("Ciudad") & vbCrLf &
                               _Row_Despacho.Item("Comuna") & vbCrLf &
                               _Row_Despacho.Item("Telefono")

        Lbl_Tipo_Despacho.Text = _Row_Despacho.Item("Nom_Tipo_Despacho")
        Lbl_Tipo_Envio.Text = _Row_Despacho.Item("Nom_Tipo_Envio")
        Lbl_Tipo_Venta.Text = _Row_Despacho.Item("Nom_Tipo_Venta")

        Dim _Transportista As String = _Row_Despacho.Item("Transportista")

        Consulta_Sql = "Select * From TABRETI Where KORETI = '" & _Transportista & "'"
        Dim _Row_Transportista As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not IsNothing(_Row_Transportista) Then
            Lbl_Transporte.Text = _Row_Transportista.Item("NORETI").ToString.Trim
        End If

        Lbl_Nro_Despacho.Text = _Row_Despacho.Item("Nro_Despacho")
        Lbl_Nro_Sub.Text = _Row_Despacho.Item("Nro_Sub")
        Lbl_Estado.Text = _Row_Despacho.Item("ESTADO").ToString.Trim & " - " & _Row_Despacho.Item("Nom_Estado").ToString.Trim

        If Not _Row_Despacho.Item("Confirmado") Then
            Lbl_Estado.Text += Space(1) & "¡POR CONFIRMAR!"
        End If

        Sb_Imagen_Estado()

        Lbl_Nombre_Entidad.Text = _Cl_Despacho.Row_Entidad.Item("Rut") & " - " & _Cl_Despacho.Row_Entidad.Item("NOKOEN")
        Lbl_Referencia.Text = _Row_Despacho.Item("Referencia")
        Lbl_Responsable.Text = _Row_Despacho.Item("CodFuncionario_Crea").ToString.Trim & " - " & _Row_Despacho.Item("Nombre_Funcionario_Crea").ToString.Trim
        Lbl_Nro_Encomienda.Text = _Row_Despacho.Item("Nro_Encomienda")

        Dim _Entregar_Con_Doc_Pagados As String

        If _Row_Despacho.Item("Entregar_Con_Doc_Pagados") Then
            _Entregar_Con_Doc_Pagados = "** Entregar solo con documentos pagados" & vbCrLf
        End If

        Dim _Transpor_Por_Pagar As String

        If _Row_Despacho.Item("Transpor_Por_Pagar") Then
            _Transpor_Por_Pagar = "** Transporte POR PAGAR" & vbCrLf
        End If

        Lbl_Fecha_Emision.Text = FormatDateTime(_Row_Despacho.Item("Fecha_Emision"), DateFormat.ShortDate)

        Dim _Observaciones = _Cl_Despacho.Row_Despacho.Item("Observaciones")

        If Not String.IsNullOrEmpty(_Observaciones) Then
            _Observaciones = "Obs: " & _Observaciones
        End If

        Dim _Contacto = String.Empty

        If Not String.IsNullOrEmpty(_Row_Despacho.Item("Telefono")) Then
            _Contacto = "Contacto: " & _Row_Despacho.Item("Nombre_Contacto") & vbCrLf
        End If

        If _Row_Despacho.Item("EntregaPaletizada") Then
            _Observaciones = vbCrLf & "*** ENTREGA PALETIZADA ***" & _Observaciones
        End If

        Txt_Datos_Entidad_Direccion.Text = _Cl_Despacho.Row_Entidad.Item("NOKOEN") & vbCrLf &
                           _Cl_Despacho.Row_Entidad.Item("Rut") & vbCrLf & vbCrLf &
                           _Row_Despacho.Item("Direccion") & vbCrLf &
                           _Row_Despacho.Item("Ciudad") & vbCrLf &
                           _Row_Despacho.Item("Comuna") & vbCrLf &
                           _Contacto &
                            _Row_Despacho.Item("Telefono") & vbCrLf &
                           _Row_Despacho.Item("Email") & vbCrLf & vbCrLf &
                           _Entregar_Con_Doc_Pagados &
                           _Transpor_Por_Pagar & vbCrLf &
                           _Observaciones


        Sb_Actualizar_Grillas()
        Sb_Actualizar_WockFlow()
        Me.Refresh()

    End Sub

    Sub Sb_Imagen_Estado()

        Dim _Row_Despacho As DataRow = _Cl_Despacho.Tbl_Despacho(0)

        Dim _Estado = _Row_Despacho.Item("Estado")

        Dim _ForeColor As Color = Color.White
        Dim _BackColor As Color

        Dim _Imagen As Image

        Select Case _Estado
            Case "ING"
                _Imagen = Imagenes_48x48.Images.Item(0)
                Btn_Imprimir.Enabled = False
            Case "CON"
                _Imagen = Imagenes_48x48.Images.Item(0)
                Btn_Imprimir.Enabled = False
            Case "PRE"
                _Imagen = Imagenes_48x48.Images.Item(1)
                Btn_Imprimir.Enabled = False
            Case "DPR"
                _Imagen = Imagenes_48x48.Images.Item(2)
            Case "DPO"
                _Imagen = Imagenes_48x48.Images.Item(4)
                Btn_Modificar_Direccion.Enabled = False
            Case "CIE"
                _Imagen = Imagenes_48x48.Images.Item(5)
                Btn_Cambiar_Tipo_Envio.Enabled = False
                Btn_Cambiar_Transporte.Enabled = False
                Btn_Modificar_Direccion.Enabled = False
            Case "NUL"
                _Imagen = Imagenes_48x48.Images.Item(0)
                Btn_Cambiar_Tipo_Envio.Enabled = False
                Btn_Cambiar_Transporte.Enabled = False
                Btn_Modificar_Direccion.Enabled = False
        End Select

        Rimg_Estado.Image = _Imagen

    End Sub

    Sub Sb_Actualizar_Grillas()

        Sb_Actualizar_Grilla_Documentos()
        Sb_Actualizar_Grilla_Productos()

    End Sub

    Sub Sb_Actualizar_Grilla_Documentos()

        Dim _Filtro_Idmaeedo = Generar_Filtro_IN(_Cl_Despacho.Tbl_Despacho_Doc, "", "Idrst", False, False, "")

        If CBool(_Cl_Despacho.Tbl_Despacho_Doc.Rows.Count) Then
            _Filtro_Idmaeedo = "Where IDMAEEDO In " & _Filtro_Idmaeedo
        Else
            _Filtro_Idmaeedo = "Where 1 < 0"
        End If

        Consulta_Sql = "Select IDMAEEDO,TIDO,NUDO,ENDO,SUENDO,NOKOEN,FEEMDO,FEER 
                        From MAEEDO 
                        Left Join MAEEN On KOEN = ENDO And SUEN = SUENDO" & vbCrLf & _Filtro_Idmaeedo

        Dim _Tbl_Documentos As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Dim _DisplayIndex = 0

        With Grilla_Documentos

            .DataSource = _Tbl_Documentos

            OcultarEncabezadoGrilla(Grilla_Documentos, False)

            .Columns("TIDO").Width = 35
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Visible = True
            .Columns("TIDO").ReadOnly = False
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").Width = 75
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").ReadOnly = True
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ENDO").Width = 80
            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").ReadOnly = True
            .Columns("ENDO").Visible = True
            .Columns("ENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUENDO").Width = 50
            .Columns("SUENDO").HeaderText = "Suc"
            .Columns("SUENDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SUENDO").ReadOnly = True
            .Columns("SUENDO").Visible = True
            .Columns("SUENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOEN").Width = 250
            .Columns("NOKOEN").HeaderText = "Razón Social"
            .Columns("NOKOEN").ReadOnly = True
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMDO").Width = 80
            .Columns("FEEMDO").HeaderText = "Fecha E."
            .Columns("FEEMDO").ReadOnly = True
            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Sub Sb_Actualizar_Grilla_Productos()

        Dim _Filtro_Idmaeedo = Generar_Filtro_IN(_Cl_Despacho.Tbl_Despacho_Doc, "", "Idrst", False, False, "")

        If CBool(_Cl_Despacho.Tbl_Despacho_Doc.Rows.Count) Then
            _Filtro_Idmaeedo = "Where IDMAEEDO In " & _Filtro_Idmaeedo
        Else
            _Filtro_Idmaeedo = "Where 1 < 0"
        End If

        Dim _Empresa = _Cl_Despacho.Tbl_Despacho.Rows(0).Item("Empresa")
        Dim _Sucursal = _Cl_Despacho.Tbl_Despacho.Rows(0).Item("Sucursal")

        Consulta_Sql = "Select KOPRCT,NOKOPR,Case UDTRPR When 1 Then UD01PR Else UD02PR End As UD," &
                       "Case UDTRPR When 1 Then Sum(CAPRCO1) Else Sum(CAPRCO1) End As CANTIDAD" & vbCrLf &
                       "From MAEDDO" & vbCrLf & _Filtro_Idmaeedo & vbCrLf &
                       "And EMPRESA = '" & _Empresa & "' And SULIDO = '" & _Sucursal & "' " & vbCrLf &
                       "Group By KOPRCT,NOKOPR,UDTRPR,UD01PR,UD02PR"

        Consulta_Sql = "Select Det.*,
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
                        Where Id_Despacho = " & _Cl_Despacho.Id_Despacho & "

                        Update #Paso_Det Set Id_Despacho_Hijo = Isnull((Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos_Doc_Det Desp 
										 Where Desp.Archirst = 'Id_Detalle' And Desp.Idrst = #Paso_Det.Id_Detalle),0)
                        From #Paso_Det

                        Update #Paso_Det Set Nro_Sub_Hijo = (Select Nro_Sub From " & _Global_BaseBk & "Zw_Despachos Where Id_Despacho = Id_Despacho_Hijo)

                        Select * From #Paso_Det

                        Drop table #Paso_Det"

        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Dim _DisplayIndex = 0

        With Grilla_Productos

            .DataSource = _Tbl_Productos

            OcultarEncabezadoGrilla(Grilla_Productos, False)

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

            .Columns("Descripcion").Width = 280
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

        Return
        With Grilla_Productos

            .DataSource = _Tbl_Productos

            OcultarEncabezadoGrilla(Grilla_Productos, False)

            .Columns("KOPRCT").Width = 100
            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").Visible = True
            .Columns("KOPRCT").ReadOnly = False
            .Columns("KOPRCT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").Width = 360
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").ReadOnly = True
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UD").Width = 30
            .Columns("UD").HeaderText = "Ud"
            .Columns("UD").ReadOnly = True
            .Columns("UD").Visible = True
            .Columns("UD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CANTIDAD").Width = 80
            .Columns("CANTIDAD").HeaderText = "Cantidad"
            .Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CANTIDAD").ReadOnly = True
            .Columns("CANTIDAD").Visible = True
            .Columns("CANTIDAD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With


    End Sub


    Sub Sb_Actualizar_WockFlow()

        Dim _Proximo_Estado As StepItem

        Dim _Row_Despacho As DataRow = _Cl_Despacho.Tbl_Despacho.Rows(0)

        Select Case _Row_Despacho.Item("Estado")

            Case "ING"

                _Info_Estado_A_Realizar = "Confirmar despacho"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ver_Ingreso
                AddHandler Estado_02_Confirmacion.Click, AddressOf Sb_Estado_02_Confirmar

                AddHandler Estado_03_Preparacion.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_04_Despachar_Despachado.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_05_Cerrar_Despacho.Click, AddressOf Sb_Info_Estado_a_realizar

                Estado_02_Confirmacion.Image = Imagenes_20x20.Images.Item(1)
                Estado_03_Preparacion.Image = Imagenes_20x20.Images.Item(2)
                Estado_04_Despachar_Despachado.Image = Imagenes_20x20.Images.Item(3)
                Estado_05_Cerrar_Despacho.Image = Imagenes_20x20.Images.Item(4)

                _Proximo_Estado = Estado_02_Confirmacion

                AddHandler Estado_01_Ingreso.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_01_Ingreso.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_02_Confirmacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_02_Confirmacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_03_Preparacion.MouseEnter, AddressOf Estado_NO_Cursor_MouseEnter
                AddHandler Estado_03_Preparacion.MouseLeave, AddressOf Estado_NO_Cursor_MouseLeave

                AddHandler Estado_04_Despachar_Despachado.MouseEnter, AddressOf Estado_NO_Cursor_MouseEnter
                AddHandler Estado_04_Despachar_Despachado.MouseLeave, AddressOf Estado_NO_Cursor_MouseLeave

                AddHandler Estado_05_Cerrar_Despacho.MouseEnter, AddressOf Estado_NO_Cursor_MouseEnter
                AddHandler Estado_05_Cerrar_Despacho.MouseLeave, AddressOf Estado_NO_Cursor_MouseLeave

            Case "CON" ' Confirmacion

                _Info_Estado_A_Realizar = "Confirmar"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ver_Ingreso
                AddHandler Estado_02_Confirmacion.Click, AddressOf Sb_Estado_02_Confirmar

                AddHandler Estado_03_Preparacion.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_04_Despachar_Despachado.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_05_Cerrar_Despacho.Click, AddressOf Sb_Info_Estado_a_realizar

                Estado_03_Preparacion.Image = Imagenes_20x20.Images.Item(2)
                Estado_04_Despachar_Despachado.Image = Imagenes_20x20.Images.Item(3)
                Estado_05_Cerrar_Despacho.Image = Imagenes_20x20.Images.Item(4)

                _Proximo_Estado = Estado_02_Confirmacion

                AddHandler Estado_01_Ingreso.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_01_Ingreso.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_02_Confirmacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_02_Confirmacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_03_Preparacion.MouseEnter, AddressOf Estado_NO_Cursor_MouseEnter
                AddHandler Estado_03_Preparacion.MouseLeave, AddressOf Estado_NO_Cursor_MouseLeave

                AddHandler Estado_04_Despachar_Despachado.MouseEnter, AddressOf Estado_NO_Cursor_MouseEnter
                AddHandler Estado_04_Despachar_Despachado.MouseLeave, AddressOf Estado_NO_Cursor_MouseLeave

                AddHandler Estado_05_Cerrar_Despacho.MouseEnter, AddressOf Estado_NO_Cursor_MouseEnter
                AddHandler Estado_05_Cerrar_Despacho.MouseLeave, AddressOf Estado_NO_Cursor_MouseLeave

            Case "PRE" ' Preparación

                _Info_Estado_A_Realizar = "En preparación..."

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ver_Ingreso
                AddHandler Estado_03_Preparacion.Click, AddressOf Sb_Estado_03_Preparacion_Armar_Bulto
                AddHandler Estado_04_Despachar_Despachado.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_05_Cerrar_Despacho.Click, AddressOf Sb_Info_Estado_a_realizar

                Estado_03_Preparacion.Image = Imagenes_20x20.Images.Item(5)
                Estado_04_Despachar_Despachado.Image = Imagenes_20x20.Images.Item(3)
                Estado_05_Cerrar_Despacho.Image = Imagenes_20x20.Images.Item(4)

                _Proximo_Estado = Estado_03_Preparacion

                AddHandler Estado_01_Ingreso.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_01_Ingreso.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_02_Confirmacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_02_Confirmacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_03_Preparacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_03_Preparacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_04_Despachar_Despachado.MouseEnter, AddressOf Estado_NO_Cursor_MouseEnter
                AddHandler Estado_04_Despachar_Despachado.MouseLeave, AddressOf Estado_NO_Cursor_MouseLeave

                AddHandler Estado_05_Cerrar_Despacho.MouseEnter, AddressOf Estado_NO_Cursor_MouseEnter
                AddHandler Estado_05_Cerrar_Despacho.MouseLeave, AddressOf Estado_NO_Cursor_MouseLeave


            Case "DPR"

                _Info_Estado_A_Realizar = "Despachar"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ver_Ingreso
                AddHandler Estado_04_Despachar_Despachado.Click, AddressOf Sb_Estado_04_Despachar
                AddHandler Estado_05_Cerrar_Despacho.Click, AddressOf Sb_Info_Estado_a_realizar

                Estado_04_Despachar_Despachado.Image = Imagenes_20x20.Images.Item(6)
                Estado_05_Cerrar_Despacho.Image = Imagenes_20x20.Images.Item(4)

                _Proximo_Estado = Estado_04_Despachar_Despachado

                AddHandler Estado_01_Ingreso.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_01_Ingreso.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_02_Confirmacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_02_Confirmacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_03_Preparacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_03_Preparacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_04_Despachar_Despachado.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_04_Despachar_Despachado.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_05_Cerrar_Despacho.MouseEnter, AddressOf Estado_NO_Cursor_MouseEnter
                AddHandler Estado_05_Cerrar_Despacho.MouseLeave, AddressOf Estado_NO_Cursor_MouseLeave

            Case "DPO"

                _Info_Estado_A_Realizar = "Despachado"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ver_Ingreso
                AddHandler Estado_05_Cerrar_Despacho.Click, AddressOf Sb_Estado_05_Cerrar

                Estado_05_Cerrar_Despacho.Image = Imagenes_20x20.Images.Item(7)

                _Proximo_Estado = Estado_05_Cerrar_Despacho

                AddHandler Estado_01_Ingreso.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_01_Ingreso.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_02_Confirmacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_02_Confirmacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_03_Preparacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_03_Preparacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_04_Despachar_Despachado.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_04_Despachar_Despachado.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_05_Cerrar_Despacho.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_05_Cerrar_Despacho.MouseLeave, AddressOf Estado_Cursor_MouseLeave

            Case "CIE"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ver_Ingreso
                'AddHandler Estado_02_Confirmacion.Click, AddressOf Sb_Estado_02_Informacion_Aceptar_Estado
                'AddHandler Estado_03_Preparacion.Click, AddressOf Sb_Estado_03_Revisar_Recopilar_Informacion
                'AddHandler Estado_04_Despachado.Click, AddressOf Sb_Estado_04_Ver_Resolucion
                'AddHandler Estado_05_Cerrar_Despacho.Click, AddressOf Sb_Estado_05_Revisar_Validacion


                AddHandler Estado_01_Ingreso.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_01_Ingreso.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_02_Confirmacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_02_Confirmacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_03_Preparacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_03_Preparacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_04_Despachar_Despachado.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_04_Despachar_Despachado.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_05_Cerrar_Despacho.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_05_Cerrar_Despacho.MouseLeave, AddressOf Estado_Cursor_MouseLeave

            Case Else

                _Proximo_Estado = Nothing 'Estado_01_Ingreso

        End Select


        Sb_Actualizar_Estados()

        If Not (_Proximo_Estado Is Nothing) Then

            _Proximo_Estado.TextColor = Color.Black
            _Proximo_Estado.ProgressColors = New System.Drawing.Color() {Color.Yellow, Color.Yellow} '{Color.GreenYellow, Color.GreenYellow}
            _Proximo_Estado.Value = 100
            _Proximo_Estado.HotTracking = True

            'AddHandler _Proximo_Estado.MouseEnter, AddressOf Estado_MouseEnter
            'AddHandler _Proximo_Estado.MouseLeave, AddressOf Estado_MouseLeave

        End If

    End Sub


    Sub Sb_Actualizar_Estados()

        For Each _Fila As DataRow In _Cl_Despacho.Tbl_Despacho_Estados.Rows

            Dim _CodEstado = _Fila.Item("Estado")
            Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
            Dim _Observacion As String = _Fila.Item("Observacion")

            Dim _Nro_Archivos As Integer

            Select Case _CodEstado

                Case "ING"

                    Fx_Estados(Estado_01_Ingreso, "Ingresado", "Revisión",
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "CON"

                    Fx_Estados(Estado_02_Confirmacion, "Confirmación", "Activado",
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "PRE"

                    Fx_Estados(Estado_03_Preparacion, "Preparación", "Documentos: " & _Cl_Despacho.Tbl_Despacho_Doc.Rows.Count,
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "DPR"

                    Fx_Estados(Estado_04_Despachar_Despachado, "Despachado", "Entregado a: xxZZZssXXX",
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "CIE"

                    Fx_Estados(Estado_05_Cerrar_Despacho, "Cierre", "",
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

            End Select

        Next

    End Sub

    Function Fx_Estados(ByVal _St_Etapa As StepItem,
                        ByVal _Encabezado As String,
                        ByVal _Espera As String,
                        ByVal _Etapa As String,
                        ByVal _Color_Arriba As Color,
                        ByVal _Color_Abajo As Color,
                        ByVal _Valor As Integer)

        Dim _Leyenda As String = "<font size=" & Chr(34) & "+2" & Chr(34) & "><b>" & _Encabezado &
                              "</b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">" & _Espera & "<br/>" & _Etapa & "</font>"

        With _St_Etapa
            .Text = _Leyenda
            .Value = _Valor
            .TextColor = Color.Black
            .ProgressColors = New System.Drawing.Color() {_Color_Arriba, _Color_Abajo} '{Color.GreenYellow, Color.GreenYellow}
            .HotTracking = True
        End With

    End Function

    Private Sub Estado_Cursor_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Hand
        sender.VALUE = 0
    End Sub

    Private Sub Estado_Cursor_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
        sender.VALUE = 100
    End Sub

    Private Sub Estado_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.VALUE = 0
    End Sub

    Private Sub Estado_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.VALUE = 100
    End Sub

    Private Sub Estado_NO_Cursor_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.No
    End Sub

    Private Sub Estado_NO_Cursor_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
    End Sub

    Sub Sb_Info_Estado_a_realizar()
        MessageBoxEx.Show(Me, "Debe: " & _Info_Estado_A_Realizar, "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End Sub

#Region "ESTADOS"

    Sub Sb_Estado_01_Ver_Ingreso()

        Dim _Id_Despacho As Integer = _Cl_Despacho.Id_Despacho
        Dim _Grabar As Boolean

        _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

        Dim Fm As New Frm_Desp_01_Ingreso
        Fm.Cl_Despacho = _Cl_Despacho
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar

        If _Grabar Then

            _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)
            Sb_Cargar_Despacho()

        End If

    End Sub

    Sub Sb_Estado_02_Confirmar()

        If No_Autorizar_Gestion Then
            MessageBoxEx.Show(Me, "Esta acción solo esta permitidad con la modalidad de la sucursal", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Fx_Autorizado_Gestion() Then

            If _Cl_Despacho.Fx_Se_Puede_Confirmar_La_Orden(Me) Then

                If _Cl_Despacho.Fx_Se_Puede_Editar_La_Orden(Me) Then

                    Dim _Id_Despacho As Integer = _Cl_Despacho.Id_Despacho
                    Dim _Confirmado As Boolean

                    Dim Fm As New Frm_Desp_02_Confirmacion
                    Fm.Despachos = _Cl_Despacho
                    Fm.ShowDialog(Me)
                    _Confirmado = Fm.Confirmado
                    Fm.Dispose()

                    If _Confirmado Then

                        MessageBoxEx.Show(Me, "Productos enviados.", "Preparación", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)
                        Sb_Cargar_Despacho()

                    End If

                End If

            End If

        End If

    End Sub

    Sub Sb_Estado_03_Preparacion_Armar_Bulto()

        If No_Autorizar_Gestion Then
            MessageBoxEx.Show(Me, "Esta acción solo esta permitidad con la modalidad de la sucursal", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Fx_Autorizado_Gestion() Then

            Dim _Id_Despacho As Integer = _Cl_Despacho.Id_Despacho
            Dim _Preparado As Boolean

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

            Dim Fm As New Frm_Desp_03_Preparar_Armar_Bulto
            Fm.Despachos = _Cl_Despacho
            Fm.ShowDialog(Me)
            _Preparado = Fm.Preparado
            Fm.Dispose()

            If _Preparado Then

                MessageBoxEx.Show(Me, "Productos preparados conformo", "Preparación", MessageBoxButtons.OK, MessageBoxIcon.Information)

                _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)
                Sb_Cargar_Despacho()

            End If

        End If

    End Sub

    Sub Sb_Estado_04_Despachar()

        If No_Autorizar_Gestion Then
            MessageBoxEx.Show(Me, "Esta acción solo esta permitidad con la modalidad de la sucursal", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Fx_Autorizado_Gestion() Then

            Dim _Id_Despacho As Integer = _Cl_Despacho.Id_Despacho
            Dim _Despachado As Boolean

            Dim Fm As New Frm_Desp_04_Depachar
            Fm.Despachos = _Cl_Despacho
            Fm.ShowDialog(Me)
            _Despachado = Fm.Despachado
            Fm.Dispose()

            If _Despachado Then

                MessageBoxEx.Show(Me, "Productos preparados conformo", "Preparación", MessageBoxButtons.OK, MessageBoxIcon.Information)

                _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)
                Sb_Cargar_Despacho()

            End If

        End If

    End Sub

    Sub Sb_Estado_05_Cerrar()

        Dim _Id_Despacho As Integer = _Cl_Despacho.Id_Despacho
        Dim _Cerrado As Boolean

        Dim Fm As New Frm_Desp_05_Cerrar
        Fm.Despachos = _Cl_Despacho
        Fm.ShowDialog(Me)
        _Cerrado = Fm.Cerrado
        Fm.Dispose()

        If _Cerrado Then

            MessageBoxEx.Show(Me, "Documento cerrado", "Preparación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)
            Me.Close()

        End If

    End Sub

    Private Function Fx_Autorizado_Gestion() As Boolean

        If Bloquear_Gestion Then
            MessageBoxEx.Show(Me, "Esta gestión solo se puede hacer desde el modulo de gestión de despachos en bodega", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Return True

    End Function

    Private Sub Grilla_Documentos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Documentos.CellDoubleClick

        Me.Enabled = False

        Dim _Fila As DataGridViewRow = Grilla_Documentos.Rows(Grilla_Documentos.CurrentRow.Index)
        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.Btn_Ver_Orden_de_despacho.Visible = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Me.Enabled = True

    End Sub

    Private Sub Frm_Despacho_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _Cl_Despacho.Fx_Soltar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO)
    End Sub

    Private Sub Btn_Imprimir_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir.Click

        If _Cl_Despacho.Estado = "ING" Or _Cl_Despacho.Estado = "PRE" Then
            MessageBoxEx.Show(Me, "No es posible imprimir el letrero ya que aun no estan armados los bultos", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Barras_ConfPuerto_OD

        Dim _Puerto = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Puerto")
        Dim _Etiqueta = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Etiqueta")

        Dim _Imp_Barras As Boolean = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Imp_Barras")
        Dim _Imp_Laser As Boolean = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Imp_Laser")
        Dim _Imp_Termica As Boolean = Fm.Ds_ConfBarras.Tables("Tbl_Conf_Orden_Despacho").Rows(0).Item("Imp_Termica")

        If Fx_Tiene_Permiso(Me, "ODp00012") Then

            Dim _Cl_Imprimir_Despacho As New Clas_Imprimir_Despacho(_Cl_Despacho)
            _Cl_Imprimir_Despacho.Sb_Imprimir_Letrero(Me)

        End If

    End Sub

    Private Sub Btn_Anular_Click(sender As Object, e As EventArgs) Handles Btn_Anular.Click

        If Fx_Tiene_Permiso(Me, "ODp00009") Then
            If _Cl_Despacho.Fx_Anular_Documento() Then

                MessageBoxEx.Show(Me, "Documento Anulado correctamente", "Anular", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close()

            End If
        End If

    End Sub

    Private Sub Grilla_Productos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Productos.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Productos.Rows(Grilla_Productos.CurrentRow.Index)

        Dim _Id_Despacho As Integer = _Fila.Cells("Id_Despacho_Hijo").Value

        If CBool(_Id_Despacho) Then

            Dim _Cl_Despacho As New Clas_Despacho(False)

            _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

            Dim Fm As New Frm_Despacho
            Fm._Correr_a_la_derecha = True
            Fm.Cl_Despacho = _Cl_Despacho
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Cambiar_Tipo_Envio_Click(sender As Object, e As EventArgs) Handles Btn_Cambiar_Tipo_Envio.Click

        If Fx_Es_Chilexpress() Then Return

        If FUNCIONARIO <> _Cl_Despacho.Row_Despacho.Item("CodFuncionario") Then
            If Not Fx_Tiene_Permiso(Me, "ODp00011") Then
                Return
            End If
        End If

        If Not _Cl_Despacho.Fx_Se_Puede_Editar_La_Orden(Me) Then
            Return
        End If

        If Not _Cl_Despacho.Fx_Tomar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO) Then
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
        _Filtrar.Campo = "CodigoTabla"
        _Filtrar.Descripcion = "NombreTabla"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "TRANSPORTISTA"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And Tabla = 'SIS_DESPACHO_TIPO_ENVIO'",
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Codigo = _Row.Item("Codigo")
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Despachos Set Tipo_Envio = '" & _Row.Item("Codigo").ToString.Trim & "' 
                            Where Id_Despacho = " & _Cl_Despacho.Id_Despacho

            If _Codigo = "RT" Then

                Consulta_Sql += vbCrLf & "Update " & _Global_BaseBk & "Zw_Despachos Set Transportista = '' 
                                         Where Id_Despacho = " & _Cl_Despacho.Id_Despacho
                _Cl_Despacho.Row_Despacho.Item("Transportista") = String.Empty
                Lbl_Transporte.Text = String.Empty
                Btn_Cambiar_Transporte.Enabled = False

            Else

                If String.IsNullOrEmpty(Lbl_Transporte.Text) Then

                    MessageBoxEx.Show(Me, "Debe indicar el transporte", "Transporte", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Call Btn_Cambiar_Transporte_Click(Nothing, Nothing)

                    If String.IsNullOrEmpty(_Cl_Despacho.Row_Despacho.Item("Transportista")) Then
                        MessageBoxEx.Show(Me, "No se puede cambiar el tipo de envío sin asignar un transportista", "Validación",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If

                    Btn_Cambiar_Transporte.Enabled = True

                End If

            End If

            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                MessageBoxEx.Show(Me, "Datos actualizados correctamente" & vbCrLf &
                                  "No es necesario volver a grabar la orden", "Cambiar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Lbl_Tipo_Envio.Text = _Descripcion
            End If

        End If

        _Cl_Despacho.Fx_Soltar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO)

    End Sub

    Private Sub Btn_Cambiar_Transporte_Click(sender As Object, e As EventArgs) Handles Btn_Cambiar_Transporte.Click

        If Fx_Es_Chilexpress() Then Return

        If Not IsNothing(sender) Then
            If FUNCIONARIO <> _Cl_Despacho.Row_Despacho.Item("CodFuncionario") Then
                If Not Fx_Tiene_Permiso(Me, "ODp00011") Then
                    Return
                End If
            End If
        End If

        If Not _Cl_Despacho.Fx_Se_Puede_Editar_La_Orden(Me) Then
            Return
        End If

        If Not _Cl_Despacho.Fx_Tomar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO) Then
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = "TABRETI"
        _Filtrar.Campo = "KORETI"
        _Filtrar.Descripcion = "NORETI"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "TRANSPORTISTA"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And DIRETI <> ''",
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Codigo = _Row.Item("Codigo")
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Despachos Set Transportista = '" & _Row.Item("Codigo").ToString.Trim & "' 
                            Where Id_Despacho = " & _Cl_Despacho.Id_Despacho

            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                _Cl_Despacho.Row_Despacho.Item("Transportista") = _Codigo

                If Not IsNothing(sender) Then

                    MessageBoxEx.Show(Me, "Datos actualizados correctamente" & vbCrLf &
                                  "No es necesario volver a grabar la orden", "Cambiar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

                Lbl_Transporte.Text = _Descripcion

            End If

        End If

        _Cl_Despacho.Fx_Soltar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO)

    End Sub

    Private Sub Btn_Modificar_Direccion_Click(sender As Object, e As EventArgs) Handles Btn_Modificar_Direccion.Click

        If Fx_Es_Chilexpress() Then Return

        If FUNCIONARIO <> _Cl_Despacho.Row_Despacho.Item("CodFuncionario_Crea") Then
            If Not Fx_Tiene_Permiso(Me, "ODp00011") Then
                Return
            End If
        End If

        If Not _Cl_Despacho.Fx_Se_Puede_Editar_La_Orden(Me) Then
            Return
        End If

        If Not _Cl_Despacho.Fx_Tomar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO) Then
            Return
        End If

        Dim _Grabar As Boolean

        Dim _Row_Despacho As DataRow = _Cl_Despacho.Row_Despacho

        Dim Fm As New Frm_Direccion_Desp
        Fm.CodPais = _Row_Despacho.Item("CodPais")
        Fm.CodCiudad = _Row_Despacho.Item("CodCiudad")
        Fm.CodComuna = _Row_Despacho.Item("CodComuna")
        Fm.Direccion = _Row_Despacho.Item("Direccion")
        Fm.Telefono = _Row_Despacho.Item("Telefono")
        Fm.Email = _Row_Despacho.Item("Email")
        Fm.Observaciones = _Row_Despacho.Item("Observaciones")
        Fm.Txt_Nombre_Contacto.Text = _Row_Despacho.Item("Nombre_Contacto")
        Fm.ShowDialog(Me)

        _Grabar = Fm.Grabar

        If _Grabar Then

            _Row_Despacho.Item("CodPais") = Fm.CodPais
            _Row_Despacho.Item("CodCiudad") = Fm.CodCiudad
            _Row_Despacho.Item("CodComuna") = Fm.CodComuna
            _Row_Despacho.Item("Direccion") = Fm.Direccion
            _Row_Despacho.Item("Telefono") = Fm.Telefono
            _Row_Despacho.Item("Email") = Fm.Email
            _Row_Despacho.Item("Observaciones") = Fm.Observaciones
            _Row_Despacho.Item("Nombre_Contacto") = Fm.Txt_Nombre_Contacto.Text

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Despachos Set " &
                           "Pais = '" & Fm.Pais & "'," &
                           "Ciudad = '" & Fm.Ciudad & "'," &
                           "Comuna = '" & Fm.Comuna & "'," &
                           "Direccion = '" & Fm.Direccion & "'," &
                           "Nombre_Contacto = '" & Fm.Txt_Nombre_Contacto.Text & "'," &
                           "Telefono = '" & Fm.Telefono & "'," &
                           "Email = '" & Fm.Email & "'," &
                           "Observaciones = '" & Fm.Observaciones & "' " &
                           "Where Id_Despacho = " & _Cl_Despacho.Id_Despacho

            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Modificar datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Dim _Entregar_Con_Doc_Pagados As String

            If _Row_Despacho.Item("Entregar_Con_Doc_Pagados") Then
                _Entregar_Con_Doc_Pagados = "** Entregar solo con documentos pagados" & vbCrLf
            End If

            Dim _Transpor_Por_Pagar As String

            If _Row_Despacho.Item("Transpor_Por_Pagar") Then
                _Transpor_Por_Pagar = "** Transporte POR PAGAR" & vbCrLf
            End If

            Dim _Observaciones = Fm.Observaciones

            If Not String.IsNullOrEmpty(_Observaciones) Then
                _Observaciones = "Obs: " & _Observaciones
            End If

            Dim _Contacto = String.Empty

            If Not String.IsNullOrEmpty(Fm.Txt_Nombre_Contacto.Text) Then
                _Contacto = "Contacto: " & Fm.Txt_Nombre_Contacto.Text & vbCrLf
            End If

            If _Row_Despacho.Item("EntregaPaletizada") Then
                _Observaciones = vbCrLf & "*** ENTREGA PALETIZADA ***" & _Observaciones
            End If

            Txt_Datos_Entidad_Direccion.Text = _Cl_Despacho.Row_Entidad.Item("NOKOEN") & vbCrLf &
                               _Cl_Despacho.Row_Entidad.Item("Rut") & vbCrLf & vbCrLf &
                               Fm.Direccion & vbCrLf &
                               Fm.Ciudad & vbCrLf &
                               Fm.Comuna & vbCrLf &
                               _Contacto &
                               Fm.Telefono & vbCrLf &
                               Fm.Email & vbCrLf & vbCrLf &
                               _Entregar_Con_Doc_Pagados &
                               _Transpor_Por_Pagar & vbCrLf &
                               _Observaciones


        End If

        Fm.Dispose()

        _Cl_Despacho.Fx_Soltar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO)

    End Sub

    Sub Sb_Reenviar_Correos()

        Dim _Codigo As String
        Dim _Descripcion As String

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
        _Filtrar.Campo = "CodigoTabla"
        _Filtrar.Descripcion = "NombreTabla"

        _Filtrar.Pro_Nombre_Encabezado_Informe = "ESTADOS DESPACHO"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra, "And Tabla = 'SIS_DESPACHO_ESTADOS'",
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            _Codigo = _Row.Item("Codigo")
            _Descripcion = _Row.Item("Descripcion").ToString.Trim
        Else
            Return
        End If

        Dim _Estado As String = _Codigo

        Dim _Row_Despacho As DataRow = _Cl_Despacho.Row_Despacho

        Dim _Destinatarios As String = _Row_Despacho.Item("Email")

        Dim _Para, _Cc As String

        Dim _Aceptar As Boolean = InputBox_Bk(Me, "correo destinatario", "Reenviar correo", _Destinatarios, False,,, True, _Tipo_Imagen.Correo)

        If _Aceptar Then

            Dim _Desti = Split(_Destinatarios, ";", 2)

            _Para = _Desti(0)
            Try
                _Cc = _Desti(1)
            Catch ex As Exception
                _Cc = String.Empty
            End Try

            Dim _Error As String

            Dim _Cldespacho_Fx As New Clas_Despacho_Fx
            _Error = _Cldespacho_Fx.Fx_Reenviar_Correo_Al_Diablito(_Cl_Despacho.Id_Despacho, _Row_Despacho, _Estado, _Para, _Cc)

            If String.IsNullOrEmpty(_Error) Then
                MessageBoxEx.Show(Me, "Correo reenviado", "Reenviar correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBoxEx.Show(Me, _Error, "Correo no enviado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub Btn_Reenviar_Correos_Click(sender As Object, e As EventArgs) Handles Btn_Reenviar_Correos.Click

        Sb_Reenviar_Correos()

    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click

        ExportarTabla_JetExcel_Tabla(_Cl_Despacho.Ds_Despacho.Tables("Zw_Despachos"), Me, "Despacho")

    End Sub

#End Region

    Function Fx_Es_Chilexpress() As Boolean
        Dim _Clas_CliexpressAPI As New Clas_CliexpressAPI()
        Dim _Row_Envio As DataRow = _Clas_CliexpressAPI.Fx_Trae_Row_Envio(0, _Cl_Despacho.Id_Despacho)

        If Not IsNothing(_Row_Envio) Then
            MessageBoxEx.Show(Me, "No se puede modificar esta orden, ya que existe una orden en CHILEXPRESS",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return True
        End If
        Return False
    End Function

    Private Sub Btn_Reenviar_Chilexpress_Click(sender As Object, e As EventArgs) Handles Btn_Reenviar_Chilexpress.Click

        Dim _Cl_DespachoFx As New Clas_Despacho_Fx
        _Cl_DespachoFx.Sb_Actualizar_Despachos(_Cl_Despacho.Id_Despacho)
        If _Cl_DespachoFx.Fx_Enviar_Despacho_Chilexpress(_Cl_Despacho.Id_Despacho) Then
            MessageBoxEx.Show(Me, "Documento reenviado a Chilexpress", "Reenviar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBoxEx.Show(Me, "Respuestas Chilexpress: " & vbCrLf & _Cl_DespachoFx.Error, "Problema al reenviar documento", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

End Class
