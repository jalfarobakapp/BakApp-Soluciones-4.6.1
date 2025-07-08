Imports DevComponents.DotNetBar

Public Class Frm_Modalidades

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Dv As New DataView
    Dim _Ds As DataSet

    Dim _Modalidad_Seleccionada As Boolean
    Dim _Preguntar_Por_Bodega As Boolean
    Dim _Configuracion_Modalidad As Boolean

    Public Property Modalidad_Seleccionada As Boolean
        Get
            Return _Modalidad_Seleccionada
        End Get
        Set(value As Boolean)
            _Modalidad_Seleccionada = value
        End Set
    End Property

    Public Property Configuracion_Modalidad As Boolean
        Get
            Return _Configuracion_Modalidad
        End Get
        Set(value As Boolean)
            _Configuracion_Modalidad = value
        End Set
    End Property

    Public Sub New(_Preguntar_Por_Bodega As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Modalidades, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, True, False)
        Me._Preguntar_Por_Bodega = _Preguntar_Por_Bodega
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Modalidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        caract_combo(Cmb_Modalidades)

        GroupPanel1.Text = "Se muestran solo las Modalidades asignadas al usurio"

        Consulta_Sql = "Select Distinct Ce.EMPRESA As Padre,Ce.EMPRESA+' - '+Cp.RAZON As Hijo
                        Into #Paso
                        From CONFIEST Ce WITH (NOLOCK)
                        Inner Join CONFIGP Cp On Cp.EMPRESA = Ce.EMPRESA 
                        Where MODALIDAD <> '  '
                        Order by Ce.EMPRESA

                        Select Ce.EMPRESA,Cp.RAZON,'MO-' + MODALIDAD As PERMISO,MODALIDAD,Ts.NOKOSU,Tb.NOKOBO,ESUCURSAL,EBODEGA,ECAJA,ELISTAVEN,
                               NLISTAVEN,ELISTACOM,NLISTACOM,ELISTAINT,NLISTAINT
                        Into #Paso1
                        From CONFIEST Ce WITH (NOLOCK)
                        Inner Join CONFIGP Cp On Cp.EMPRESA = Ce.EMPRESA 
                        Left Join TABSU Ts On Ts.EMPRESA = Ce.EMPRESA And Ts.KOSU = Ce.ESUCURSAL
                        Left Join TABBO Tb On Tb.EMPRESA = Ce.EMPRESA And Tb.KOSU = Ce.ESUCURSAL And Tb.KOBO = Ce.EBODEGA
                        Where MODALIDAD <> '  '
                        Order by Ce.EMPRESA,MODALIDAD

                        Select * From #Paso
                        Where Padre In (Select EMPRESA From #Paso1
                        Where PERMISO In (Select KOOP From MAEUS Where KOUS = '" & FUNCIONARIO & "' And KOOP Like 'MO-%'))

                        --Select * From #Paso1
                        --Where PERMISO In (Select KOOP From MAEUS Where KOUS = '" & FUNCIONARIO & "' And KOOP Like 'MO-%')

                        Drop Table #Paso
                        Drop Table #Paso1"

        If _Configuracion_Modalidad Then

            GroupPanel1.Text = "Modalidades"

            Consulta_Sql = "Select Distinct Ce.EMPRESA As Padre,Ce.EMPRESA+' - '+Cp.RAZON As Hijo
                            Into #Paso
                            From CONFIEST Ce WITH (NOLOCK)
                            Inner Join CONFIGP Cp On Cp.EMPRESA = Ce.EMPRESA 
                            Where MODALIDAD <> '  '
                            Order by Ce.EMPRESA

                            Select Ce.EMPRESA,Cp.RAZON,'MO-' + MODALIDAD As PERMISO,MODALIDAD,Ts.NOKOSU,Tb.NOKOBO,ESUCURSAL,EBODEGA,ECAJA,ELISTAVEN,
                                   NLISTAVEN,ELISTACOM,NLISTACOM,ELISTAINT,NLISTAINT
                            Into #Paso1
                            From CONFIEST Ce WITH (NOLOCK)
                            Inner Join CONFIGP Cp On Cp.EMPRESA = Ce.EMPRESA 
                            Left Join TABSU Ts On Ts.EMPRESA = Ce.EMPRESA And Ts.KOSU = Ce.ESUCURSAL
                            Left Join TABBO Tb On Tb.EMPRESA = Ce.EMPRESA And Tb.KOSU = Ce.ESUCURSAL And Tb.KOBO = Ce.EBODEGA
                            Where MODALIDAD <> '  '
                            Order by Ce.EMPRESA,MODALIDAD

                            Select * From #Paso
                            
                            Drop Table #Paso
                            Drop Table #Paso1"

        End If

        Cmb_Modalidades.DataSource = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Modalidad = _Sql.Fx_Trae_Dato("TABFU", "MODALIDAD", "KOFU = '" & FUNCIONARIO & "'")
        Dim _Emp As String = ModEmpresa '_Sql.Fx_Trae_Dato("CONFIEST", "EMPRESA", "MODALIDAD = '" & Modalidad & "'")

        Cmb_Modalidades.SelectedValue = _Emp

        Sb_Actualizar_Grilla()

        AddHandler Cmb_Modalidades.SelectedIndexChanged, AddressOf Sb_Actualizar_Grilla

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_Sql = "Select Ce.EMPRESA,Cp.RAZON,'MO-' + MODALIDAD As PERMISO,MODALIDAD,Ts.NOKOSU,Tb.NOKOBO,ESUCURSAL,EBODEGA,ECAJA,ELISTAVEN,
                        NLISTAVEN,ELISTACOM,NLISTACOM,ELISTAINT,NLISTAINT
                        Into #Paso1
                        From CONFIEST Ce WITH (NOLOCK)
                        Inner Join CONFIGP Cp On Cp.EMPRESA = Ce.EMPRESA 
                        Left Join TABSU Ts On Ts.EMPRESA = Ce.EMPRESA And Ts.KOSU = Ce.ESUCURSAL
                        Left Join TABBO Tb On Tb.EMPRESA = Ce.EMPRESA And Tb.KOSU = Ce.ESUCURSAL And Tb.KOBO = Ce.EBODEGA
                        Where MODALIDAD <> '  ' And Ce.EMPRESA = '" & Cmb_Modalidades.SelectedValue & "'
                        Order by Ce.EMPRESA,MODALIDAD

                        Select * From #Paso1
                        Where PERMISO In (Select KOOP From MAEUS Where KOUS = '" & FUNCIONARIO & "' And KOOP Like 'MO-%') 

                        Drop Table #Paso
                        Drop Table #Paso1"

        If _Configuracion_Modalidad Then

            Consulta_Sql = "Select Ce.EMPRESA,Cp.RAZON,'MO-' + MODALIDAD As PERMISO,MODALIDAD,Ts.NOKOSU,Tb.NOKOBO,ESUCURSAL,EBODEGA,ECAJA,ELISTAVEN,
                            NLISTAVEN,ELISTACOM,NLISTACOM,ELISTAINT,NLISTAINT
                            Into #Paso1
                            From CONFIEST Ce WITH (NOLOCK)
                            Inner Join CONFIGP Cp On Cp.EMPRESA = Ce.EMPRESA 
                            Left Join TABSU Ts On Ts.EMPRESA = Ce.EMPRESA And Ts.KOSU = Ce.ESUCURSAL
                            Left Join TABBO Tb On Tb.EMPRESA = Ce.EMPRESA And Tb.KOSU = Ce.ESUCURSAL And Tb.KOBO = Ce.EBODEGA
                            Where MODALIDAD <> '  ' And Ce.EMPRESA = '" & Cmb_Modalidades.SelectedValue & "'
                            Order by Ce.EMPRESA,MODALIDAD

                            Select * From #Paso1
                            
                            Drop Table #Paso
                            Drop Table #Paso1"

        End If

        Dim _Tbl_Modalidades As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        With Grilla_Modalidades

            .DataSource = _Tbl_Modalidades

            OcultarEncabezadoGrilla(Grilla_Modalidades, True)

            Dim _DisplayIndex = 0
            Dim _Columna As String

            _Columna = "MODALIDAD"
            .Columns(_Columna).HeaderText = "Mod."
            .Columns(_Columna).Width = 50
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Columna = "EMPRESA"
            .Columns(_Columna).HeaderText = "Emp."
            .Columns(_Columna).Width = 40
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Columna = "ESUCURSAL"
            .Columns(_Columna).HeaderText = "Suc."
            .Columns(_Columna).Width = 40
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Columna = "NOKOSU"
            .Columns(_Columna).HeaderText = "Sucursal"
            .Columns(_Columna).Width = 235
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Columna = "EBODEGA"
            .Columns(_Columna).HeaderText = "Bod."
            .Columns(_Columna).Width = 40
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Columna = "ECAJA"
            .Columns(_Columna).HeaderText = "Caja"
            .Columns(_Columna).Width = 40
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Columna = "ELISTAVEN"
            .Columns(_Columna).HeaderText = "L.Venta"
            .Columns(_Columna).Width = 70
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            _Columna = "ELISTACOM"
            .Columns(_Columna).HeaderText = "L.Compra"
            .Columns(_Columna).Width = 70
            .Columns(_Columna).Visible = True
            .Columns(_Columna).DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        BuscarDatoEnGrilla(Modalidad, "MODALIDAD", Grilla_Modalidades)

        Me.ActiveControl = Grilla_Modalidades

    End Sub

    Private Sub Grilla_Modalidades_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Modalidades.CellDoubleClick

        Dim _Cambiar_Modalidad As Boolean = True

        Try

            Dim _Fila As DataGridViewRow = Grilla_Modalidades.Rows(Grilla_Modalidades.CurrentRow.Index)

            If _Configuracion_Modalidad Then

                Dim _Modalidad_Conf As String = _Fila.Cells("MODALIDAD").Value

                Dim _Clas_Mod As New Clas_Modalidades
                Dim _RowModalidad As DataRow = _Clas_Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, _Modalidad_Conf)

                If IsNothing(_RowModalidad) Then
                    MessageBoxEx.Show(Me, "Cierre el sistema y vuelva a ingresar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Dim Fm As New Frm_Configuracion_Gral(_RowModalidad, False)
                Fm.ShowDialog(Me)
                Fm.Dispose()
                Return

            End If

            Modalidad = _Fila.Cells("MODALIDAD").Value

            If _Preguntar_Por_Bodega Then

                Dim _Empresa As String = _Fila.Cells("EMPRESA").Value
                Dim _Sucursal As String = _Fila.Cells("ESUCURSAL").Value
                Dim _Bodega As String = _Fila.Cells("EBODEGA").Value

                Dim _Permiso = "Bo" & _Empresa & _Sucursal & _Bodega

                If Not Fx_Tiene_Permiso(Me, _Permiso) Then

                    _Cambiar_Modalidad = False

                    MessageBoxEx.Show(Me, "LA MODALIDAD NO FUE CAMBIADA", "VALIDACION",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Me.TopMost)

                End If

            End If

            If _Cambiar_Modalidad Then

                ModEmpresa = _Fila.Cells("EMPRESA").Value

                Consulta_Sql = "Select top 1 Cest.*,Cfgp.RAZON" & vbCrLf &
                               "From CONFIEST Cest WITH (NOLOCK) Inner Join CONFIGP Cfgp On Cest.EMPRESA = Cfgp.EMPRESA" & vbCrLf &
                               "Where MODALIDAD = '" & Modalidad & "'  And Cest.EMPRESA = '" & ModEmpresa & "'"
                _Global_Row_Modalidad = _Sql.Fx_Get_DataRow(Consulta_Sql)

                ModEmpresa = _Global_Row_Modalidad.Item("EMPRESA")
                ModSucursal = _Global_Row_Modalidad.Item("ESUCURSAL")
                ModBodega = _Global_Row_Modalidad.Item("EBODEGA")
                ModCaja = _Global_Row_Modalidad.Item("ECAJA")
                ModListaPrecioVenta = Mid(_Global_Row_Modalidad.Item("ELISTAVEN"), 6, 3)
                ModListaPrecioCosto = Mid(_Global_Row_Modalidad.Item("ELISTACOM"), 6, 3)

                _Modalidad_Seleccionada = True


                If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Empresas") Then

                    Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Empresas Where Empresa = '" & ModEmpresa & "'"
                    _Global_Row_Empresa = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    If IsNothing(_Global_Row_Empresa) Then

                        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Empresas (Empresa,Rut,Razon,Ncorto,Direccion,Pais,Ciudad,Giro)" & vbCrLf &
                                       "Select EMPRESA,RUT,RAZON,NCORTO,DIRECCION,PAIS,CIUDAD,GIRO From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
                        _Sql.Ej_consulta_IDU(Consulta_Sql)

                        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Empresas Where Empresa = '" & ModEmpresa & "'"
                        _Global_Row_Empresa = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    End If

                    RazonEmpresa = _Global_Row_Empresa.Item("Razon").ToString.Trim
                    DireccionEmpresa = _Global_Row_Empresa.Item("Direccion").ToString.Trim
                    RutEmpresaActiva = _Global_Row_Empresa.Item("Rut").ToString.Trim
                    RutEmpresa = RutEmpresaActiva

                End If

                Me.Close()

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Plop!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Call Grilla_Modalidades_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Grilla_Modalidades_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla_Modalidades.KeyDown

        Dim _Key As Keys = e.KeyValue

        Select Case _Key

            Case Keys.Enter

                SendKeys.Send("{LEFT}")
                e.Handled = True
                Call Grilla_Modalidades_CellDoubleClick(Nothing, Nothing)

        End Select

    End Sub

    Private Sub Grilla_Empresas_KeyDown(sender As Object, e As KeyEventArgs)

        Dim _Key As Keys = e.KeyValue

        Select Case _Key

            Case Keys.Enter, Keys.Right

                e.Handled = True
                Grilla_Modalidades.Focus()

        End Select

    End Sub

End Class
