Imports DevComponents.DotNetBar

Public Class Frm_Sol_Recom_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_Solicitudes As DataTable

    Enum Enum_Vista_Solicitudes
        Mis_Solicitudes
        Todas
    End Enum

    Dim _Vista_Solicitudes As Enum_Vista_Solicitudes = Enum_Vista_Solicitudes.Mis_Solicitudes

    Public Sub New(Vista_Solicitudes As Enum_Vista_Solicitudes)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Vista_Solicitudes = Vista_Solicitudes

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Solicitud.ForeColor = Color.White
        End If

    End Sub
    Private Sub Frm_Sol_Recom_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        csNotificaciones.Notificacion._Revisando_SolComProd = True

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        Sb_Actualizar_Grilla()

        Btn_Solicitud.Enabled = (_Vista_Solicitudes = Enum_Vista_Solicitudes.Mis_Solicitudes)

    End Sub
    Sub Sb_Actualizar_Grilla()

        Dim _Filtro_Solicitudes = String.Empty

        Dim _Fecha_Tope = Format(DateAdd(DateInterval.Day, -3, FechaDelServidor), "yyyyMMdd")
        _Fecha_Tope = Format(FechaDelServidor, "yyyyMMdd")

        If _Vista_Solicitudes = Enum_Vista_Solicitudes.Mis_Solicitudes Then

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Prod_SolCompra Set Visto = 1,Fecha_Visto = Getdate()
                            Where CodFun_Solicita = '" & FUNCIONARIO & "' And Visto = 0 And Estado = 'RPD' And Para_Stock = 1"
            _Sql.Ej_consulta_IDU(Consulta_Sql)

            _Filtro_Solicitudes = "And Soc.CodFun_Solicita = '" & FUNCIONARIO & "' 
                                   And ((Soc.Estado In ('PDT','REV') Or Visto = 0) Or (Fecha_Visto >= '" & _Fecha_Tope & "'))  
                                  --And Soc.Estado In ('PDT','REV')
                                  --Or Soc.Id_SCom In (Select Id_SCom From " & _Global_BaseBk & "Zw_Prod_SolCompra_Resp 
                                  -- Where CodFun_Solicita = '" & FUNCIONARIO & "' And Fecha >= '" & _Fecha_Tope & "' And Estado = 'RPD')"
        Else


            _Filtro_Solicitudes = "And Soc.Estado In ('PDT','REV')
                                    Or Soc.Id_SCom In (Select Id_SCom From " & _Global_BaseBk & "Zw_Prod_SolCompra_Resp 
                                       Where CodFun_Responde = '" & FUNCIONARIO & "' And Fecha >= '" & _Fecha_Tope & "' And Estado = 'RPD')"


        End If

        Consulta_Sql = "Select Soc.*,Isnull(Cli.NOKOEN,'') As Razon_Cliente,TABSU.NOKOSU,
                        Case Soc.Estado When 'PDT' Then 'Pendiente' When 'RPD' Then 'Respondido' When 'REV' Then 'Pendiente' End As Nom_Estado,
                        Case Para_Stock When 1 Then 'Stock' else 'Venta Calzada' End As Stock_Calzada,T1.NOKOFU As NomFun_solicita,
                        Resp.Fecha As Fecha_Respuesta                      
                        From " & _Global_BaseBk & "Zw_Prod_SolCompra Soc
                        Left Join MAEEN Cli ON Cli.KOEN = CodCliente AND Cli.SUEN = CodSucCliente
                        Inner Join TABSU ON EMPRESA = Empresa AND KOSU = Sucursal
                        Left Join TABFU T1 On CodFun_Solicita = T1.KOFU
                        Left Join " & _Global_BaseBk & "Zw_Prod_SolCompra_Resp Resp On Resp.Id_SCom = Soc.Id_SCom And Resp.Estado = 'RPD'
                        Where 1 > 0 " & Environment.NewLine & _Filtro_Solicitudes
        _Tbl_Solicitudes = _Sql.Fx_Get_Tablas(Consulta_Sql)

        With Grilla

            .DataSource = _Tbl_Solicitudes

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _Index As Integer = 0

            .Columns("Numero").Visible = True
            .Columns("Numero").HeaderText = "Número"
            .Columns("Numero").Width = 80
            .Columns("Numero").DisplayIndex = _Index
            _Index += 1

            .Columns("Fecha_Envio").Visible = True
            .Columns("Fecha_Envio").HeaderText = "Fecha Envio"
            .Columns("Fecha_Envio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Envio").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha_Envio").Width = 70
            .Columns("Fecha_Envio").DisplayIndex = _Index
            _Index += 1

            .Columns("Nom_Estado").Visible = True
            .Columns("Nom_Estado").HeaderText = "Estado"
            .Columns("Nom_Estado").Width = 80
            .Columns("Nom_Estado").DisplayIndex = _Index
            _Index += 1

            .Columns("Fecha_Respuesta").Visible = True
            .Columns("Fecha_Respuesta").HeaderText = "Fecha Respuesta"
            .Columns("Fecha_Respuesta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha_Respuesta").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha_Respuesta").Width = 70
            .Columns("Fecha_Respuesta").DisplayIndex = _Index
            _Index += 1

            If _Vista_Solicitudes = Enum_Vista_Solicitudes.Todas Then

                .Columns("NomFun_solicita").Visible = True
                .Columns("NomFun_solicita").HeaderText = "Solicita"
                .Columns("NomFun_solicita").Width = 150
                .Columns("NomFun_solicita").DisplayIndex = _Index
                _Index += 1

            End If

            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Codigo").DisplayIndex = _Index
            _Index += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 250
            .Columns("Descripcion").DisplayIndex = _Index
            _Index += 1

            .Columns("Stock_Calzada").Visible = True
            .Columns("Stock_Calzada").HeaderText = "Tipo pedido"
            .Columns("Stock_Calzada").Width = 100
            .Columns("Stock_Calzada").DisplayIndex = _Index
            _Index += 1

            .Columns("Razon_Cliente").Visible = True
            .Columns("Razon_Cliente").HeaderText = "Cliente"
            .Columns("Razon_Cliente").Width = 250
            .Columns("Razon_Cliente").DisplayIndex = _Index
            _Index += 1

        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Try

                Dim _Nom_Estado = _Fila.Cells("Nom_Estado").Value
                Dim _Visto = _Fila.Cells("Visto").Value

                If _Nom_Estado = "Pendiente" Then
                    '_Fila.DefaultCellStyle.ForeColor = Color.Red
                    _Fila.Cells("Nom_Estado").Style.ForeColor = Rojo
                ElseIf _Nom_Estado = "Pendiente (R)" Then
                    '_Fila.DefaultCellStyle.ForeColor = Color.Coral
                    _Fila.Cells("Nom_Estado").Style.ForeColor = Color.Coral
                ElseIf _Nom_Estado = "Respondido" Then

                    _Fila.Cells("Nom_Estado").Style.ForeColor = Verde

                    If _Vista_Solicitudes = Enum_Vista_Solicitudes.Mis_Solicitudes Then

                        If Not _Visto Then
                            _Fila.Cells("Numero").Style.ForeColor = Rojo
                        End If

                    ElseIf _Vista_Solicitudes = Enum_Vista_Solicitudes.Todas Then

                        _Fila.DefaultCellStyle.ForeColor = Color.Gray

                    End If

                End If
            Catch ex As Exception

            End Try

        Next

    End Sub

    Private Sub Btn_Solicitud_Click(sender As Object, e As EventArgs) Handles Btn_Solicitud.Click

        ShowContextMenu(Menu_Contextual_SOL)

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Id_SCom = _Fila.Cells("Id_SCom").Value
        Dim _Cl_Sol_Recom_Compra_Pr As Cl_Sol_Recom_Compra_Pr
        Dim _Grabar As Boolean

        Dim Fm As New Frm_Sol_Recom_Respuesta(_Id_SCom)
        Fm.ShowDialog(Me)
        _Cl_Sol_Recom_Compra_Pr = Fm.Pro_Cl_Sol_Recom_Compra_Pr
        _Grabar = Fm.Pro_Grabar
        Fm.Dispose()

        If Not _Grabar Then

            If _Cl_Sol_Recom_Compra_Pr.Estado = Cl_Sol_Recom_Compra_Pr.Enum_Estados.Pendiente And
                _Cl_Sol_Recom_Compra_Pr.Row_Prod_SolCompra.Item("CodFun_Solicita") <> FUNCIONARIO Then

                Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_SolCompra_Resp",
                                                    "Id_SCom = " & _Id_SCom & " And Estado = 'REV'")

                If Not Convert.ToBoolean(_Reg) Then

                    _Cl_Sol_Recom_Compra_Pr.Fx_Insertar_Respuesta(FUNCIONARIO, Cl_Sol_Recom_Compra_Pr.Enum_Estados.Revisado, "", False, False)

                End If

            End If

        End If

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_Sol_Compra_Pr_Existente_Click(sender As Object, e As EventArgs) Handles Btn_Sol_Compra_Pr_Existente.Click
        Sb_Solicitar_Compra_De_Producto(True)
    End Sub

    Private Sub Btn_Sol_Compra_Pr_No_Existente_Click(sender As Object, e As EventArgs) Handles Btn_Sol_Compra_Pr_No_Existente.Click
        Sb_Solicitar_Compra_De_Producto(False)
    End Sub

    Sub Sb_Solicitar_Compra_De_Producto(_Existe As Boolean)

        Dim _RowProducto As DataRow

        If _Existe Then

            _RowProducto = Fx_Buscar_Producto(Me, "", "", Enum_Tipo_Lista.Venta, False, "", False)

            If IsNothing(_RowProducto) Then
                Return
            End If

        End If

        Dim Fm As New Frm_Sol_Recom_Compra_Pr(0)
        Fm.Pro_Row_Producto = _RowProducto
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click

        ExportarTabla_JetExcel_Tabla(_Tbl_Solicitudes, Me, "Productos solicitados")

    End Sub

    Private Sub Frm_Sol_Recom_Lista_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Sol_Recom_Lista_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        csNotificaciones.Notificacion._Revisando_SolComProd = False
    End Sub

    Private Sub Chk_Mostrar_Respondidas_CheckedChanged(sender As Object, e As EventArgs)
        Sb_Actualizar_Grilla()
    End Sub
End Class
