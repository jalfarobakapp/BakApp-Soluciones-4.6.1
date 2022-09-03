Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Mt_InvParc_Actualizar_Foto_Stock

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Inventarios As DataTable
    Dim _Tbl_Productos_Contados As DataTable

    Dim _Tbl_Paso_Actualizacion As DataTable

    Dim _Empresa As String
    Dim _Sucursal As String
    Dim _Bodega As String

    Dim _Cancelar As Boolean

    Public Property Pro_Tbl_Inventarios() As DataTable
        Get
            Return _Tbl_Inventarios
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Inventarios = value
        End Set
    End Property

    Public Sub New(ByVal Empresa As String, ByVal Sucursal As String, ByVal Bodega As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Empresa = Empresa
        _Sucursal = Sucursal
        _Bodega = Bodega

        Consulta_sql = "Select Id,Ano,Mes,Dia,Fecha,Empresa,Sucursal,Bodega,Nombre_Ajuste,Funcionario,Estado," & vbCrLf & _
                       "(Select COUNT(Distinct CodigoPr) From " & _Global_BaseBk & "Zw_TmpInv_InvParcial " & _
                       "Where FechaInv = Fecha And DejaStockCero = 0) as 'Productos'" & vbCrLf & _
                       "From " & _Global_BaseBk & "Zw_TmpInv_InvParcial_Inventarios" & vbCrLf & _
                       "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & _
                       "' And Bodega = '" & _Bodega & "'" & vbCrLf & _
                       "Order by Fecha"

        _Tbl_Inventarios = _Sql.Fx_Get_Tablas(Consulta_sql)

        

    End Sub

    Private Sub Frm_Mt_InvParc_Actualizar_Foto_Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Procesando(False)
    End Sub

    Sub Sb_Procesando(ByVal _Procesando As Boolean)

        _Cancelar = False

        'If _Procesando Then
        '    Btn_Cancelar.Enabled = True
        '    BtnProcesar.Enabled = False
        '    Me.ControlBox = False
        'Else
        '    Btn_Cancelar.Enabled = False
        '    BtnProcesar.Enabled = True
        '    Me.ControlBox = True
        'End If

        Btn_Cancelar.Enabled = _Procesando
        BtnProcesar.Enabled = Not _Procesando
        Me.ControlBox = Not _Procesando

        Barra_Progreso.Value = 0
        Progreso_Cont.Value = 0
        Progreso_Porc.Value = 0

        Barra_Progreso.Text = String.Empty
        Lbl_Fecha_Inventario.Text = String.Empty
        Lbl_Producto.Text = String.Empty

        Me.Refresh()

    End Sub

    Private Sub BtnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesar.Click

        Try

            Sb_Procesando(True)

            Barra_Progreso.Maximum = _Tbl_Inventarios.Rows.Count
            Dim _Contador As Integer

            _Tbl_Paso_Actualizacion = New DataTable("Tabla1")

            'creamos las mismas columnas que hay en el dataset
            _Tbl_Paso_Actualizacion.Columns.Add("Semilla", System.Type.[GetType]("System.String"))
            _Tbl_Paso_Actualizacion.Columns.Add("Codigo", System.Type.[GetType]("System.String"))
            _Tbl_Paso_Actualizacion.Columns.Add("Descripcion", System.Type.[GetType]("System.String"))
            _Tbl_Paso_Actualizacion.Columns.Add("Foto_Stock_Ud1", System.Type.[GetType]("System.Double"))
            _Tbl_Paso_Actualizacion.Columns.Add("Foto_Stock_Ud2", System.Type.[GetType]("System.Double"))
            ',,,,,,

            For Each _Filas_Inventario As DataRow In _Tbl_Inventarios.Rows

                System.Windows.Forms.Application.DoEvents()

                Dim _Fecha As Date = _Filas_Inventario.Item("Fecha")
                Barra_Progreso.Text = "Inventario " & FormatNumber(Barra_Progreso.Value + 1, 0) & " de " & FormatNumber(_Tbl_Inventarios.Rows.Count, 0)

                Lbl_Fecha_Inventario.Text = "Fecha inventario: " & FormatDateTime(_Fecha, DateFormat.LongDate)

                _Tbl_Productos_Contados = Fx_Tbl_Productos_Contados(_Fecha)

                If CBool(_Tbl_Productos_Contados.Rows.Count) Then

                    Progreso_Porc.Maximum = 100
                    Progreso_Cont.Maximum = _Tbl_Productos_Contados.Rows.Count

                    _Contador = 0

                    For Each _Fila As DataRow In _Tbl_Productos_Contados.Rows

                        System.Windows.Forms.Application.DoEvents()

                        Dim _Codigo = _Fila.Item("CodigoPr")
                        Dim _Descripcion = _Fila.Item("Descripcion")
                        Dim _Semilla = _Fila.Item("Semilla")
                        Dim _RowStfi As DataRow = Fx_Saldo_Foto_Stock(_Fila, _Fecha)

                        Lbl_Producto.Text = "Producto: " & _Codigo & ", " & _Descripcion

                        Dim _Foto_Stock_Ud1 As Double = _RowStfi.Item("STFISICOUD1")
                        Dim _Foto_Stock_Ud2 As Double = _RowStfi.Item("STFISICOUD2")

                        Dim dr As DataRow
                        dr = _Tbl_Paso_Actualizacion.NewRow()

                        dr("Semilla") = _Semilla
                        dr("Codigo") = _Codigo
                        dr("Descripcion") = _Descripcion
                        dr("Foto_Stock_Ud1") = _Foto_Stock_Ud1
                        dr("Foto_Stock_Ud2") = _Foto_Stock_Ud2

                        _Tbl_Paso_Actualizacion.Rows.Add(dr)

                        _Contador += 1
                        Progreso_Porc.Value = ((_Contador * 100) / _Tbl_Productos_Contados.Rows.Count) 'Mas
                        Progreso_Cont.Value = _Contador

                        If Fx_Cancelar() Then
                            Throw New Exception("Acción cancelada por el usuario")
                        End If

                    Next

                End If

                Barra_Progreso.Value += 1

                If Fx_Cancelar() Then
                    Throw New Exception("Acción cancelada por el usuario")
                End If

            Next

            Sb_Procesando(False)
            Sb_Procesando(True)

            Progreso_Porc.Maximum = 100
            Progreso_Cont.Maximum = _Tbl_Paso_Actualizacion.Rows.Count
            Barra_Progreso.Maximum = _Tbl_Paso_Actualizacion.Rows.Count

            _Contador = 0

            For Each _Row As DataRow In _Tbl_Paso_Actualizacion.Rows

                System.Windows.Forms.Application.DoEvents()

                Barra_Progreso.Text = "Actualizando base de datos: " & _
                FormatNumber(Barra_Progreso.Value + 1, 0) & " de " & FormatNumber(_Tbl_Paso_Actualizacion.Rows.Count, 0)

                Dim _Codigo = _Row.Item("Codigo")
                Dim _Descripcion = _Row.Item("Descripcion")
                Dim _Semilla = _Row.Item("Semilla")

                Lbl_Fecha_Inventario.Text = "Actualizando producto en la base de datos..."
                Lbl_Producto.Text = "Producto: " & _Codigo & ", " & _Descripcion

                Dim _Foto_Stock_Ud1 As Double = _Row.Item("Foto_Stock_Ud1")
                Dim _Foto_Stock_Ud2 As Double = _Row.Item("Foto_Stock_Ud2")

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_TmpInv_InvParcial Set" & Space(1) & _
                               "Foto_Stock_Ud1 = " & De_Num_a_Tx_01(_Foto_Stock_Ud1, False, 5) & _
                               ",Foto_Stock_Ud2 = " & De_Num_a_Tx_01(_Foto_Stock_Ud2, False, 5) & vbCrLf & _
                               "Where Semilla = " & _Semilla

                _Sql.Ej_consulta_IDU(Consulta_sql)

                _Contador += 1
                Progreso_Porc.Value = ((_Contador * 100) / _Tbl_Paso_Actualizacion.Rows.Count) 'Mas
                Progreso_Cont.Value = _Contador
                Barra_Progreso.Value = _Contador

                If Fx_Cancelar() Then
                    Throw New Exception("Acción cancelada por el usuario" & vbCrLf & _
                                        "Se actualizarón " & _Contador & " registros")
                End If

            Next

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Actualizar foto stock", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

            Sb_Procesando(False)
            Me.Refresh()

        End Try

    End Sub

    Sub Sb_Crear_Tabla_Paso_Actualizacion()

        Dim dt As New DataTable("Tabla1")

        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Semilla", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Codigo", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Descripcion", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Foto_Stock_Ud1", System.Type.[GetType]("System.Double"))
        dt.Columns.Add("Foto_Stock_Ud2", System.Type.[GetType]("System.Double"))
        ',,,,,,

        _Tbl_Paso_Actualizacion = dt
        'Dim dr As DataRow
        'dr = dt.NewRow() : dr("Padre") = "C" : dr("Hijo") = "Cliente" : dt.Rows.Add(dr)
        'dr = dt.NewRow() : dr("Padre") = "P" : dr("Hijo") = "Proveedor" : dt.Rows.Add(dr)
        'dr = dt.NewRow() : dr("Padre") = "A" : dr("Hijo") = "Ambos" : dt.Rows.Add(dr)
        ''cerramos el datareader y la conexión
        ''añadimos la tabla al dataset
        'rs.Tables.Add(dt)

        'With CmbxTipoEntidad
        '.DataSource = Nothing
        '.DataSource = dt
        'End With

    End Sub

    Function Fx_Cancelar() As Boolean

        If _Cancelar Then
            If MessageBoxEx.Show(Me, "¿Desea cancelar la operación?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                _Tbl_Paso_Actualizacion = Nothing
                Return True
            Else
                _Cancelar = False
            End If
        End If

    End Function

    Function Fx_Tbl_Productos_Contados(ByVal _Fecha As Date)

        Consulta_sql = "Select *," & _
                       "CAST(0 as Bit) As GDI_Cero_Nula," & _
                       "CAST(0 as Bit) As GRI_Cero_Nula," & _
                       "CAST(0 as Bit) As GRI_Ajuste_Nula" & vbCrLf & _
                       "Into #Paso_Inv FROM " & _Global_BaseBk & "Zw_TmpInv_InvParcial" & vbCrLf & _
                       "Where FechaInv = '" & Format("yyyyMMdd", _Fecha) & "'" & vbCrLf & _
                       "And Levantado = 1" & vbCrLf & _
                       "And DejaStockCero = 0" & vbCrLf & _
                       "Order by CodigoPr,Semilla Desc" & vbCrLf & vbCrLf & _
                       "Update #Paso_Inv Set StockActual = Isnull((Select Top 1 STFI1 From MAEST" & Space(1) & _
                       "Where EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR = CodigoPr),0)" & vbCrLf & _
                       "Update #Paso_Inv Set GRI_Cero_Nula = Case When (Select COUNT(*) From MAEEDO Where IDMAEEDO = GRI_Idmaeedo_Aj) > 0 then 0 Else 1 End" & vbCrLf & _
                       "Update #Paso_Inv Set GDI_Cero_Nula = Case When (Select COUNT(*) From MAEEDO Where IDMAEEDO = GDI_Idmaeedo_Aj) > 0 then 0 Else 1 End" & vbCrLf & _
                       "Update #Paso_Inv Set GRI_Ajuste_Nula = Case When (Select COUNT(*) From MAEEDO Where IDMAEEDO = IDMAEEDO_Aj) > 0 then 0 Else 1 End" & vbCrLf & _
                       "Select * From #Paso_Inv" & vbCrLf & _
                       "Order by CodigoPr,Semilla Desc" & vbCrLf & _
                       "Drop Table #Paso_Inv"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Return _Tbl

    End Function

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        _Cancelar = True
    End Sub

    Function Fx_Saldo_Foto_Stock(ByVal _Row_Producto As DataRow,
                                 ByVal _Fecha_Inventario As Date) As DataRow

        Dim _Empresa As String = _Row_Producto.Item("Empresa")
        Dim _Sucursal As String = _Row_Producto.Item("Sucursal")
        Dim _Bodega As String = _Row_Producto.Item("Bodega")

        Dim _Idmaeedo_Gri_Cero = _Row_Producto.Item("IDMAEEDO_Aj")
        Dim _Idmaeedo_Gri = _Row_Producto.Item("GDI_Idmaeedo_Aj")
        Dim _Idmaeedo_Gdi = _Row_Producto.Item("GRI_Idmaeedo_Aj")

        Dim _IdMenor As String

        If _Idmaeedo_Gri_Cero > 0 Then _IdMenor = "And MAEDDO.IDMAEEDO < " & _Idmaeedo_Gri_Cero & vbCrLf
        If _Idmaeedo_Gri > 0 Then _IdMenor += "And MAEDDO.IDMAEEDO < " & _Idmaeedo_Gri & vbCrLf
        If _Idmaeedo_Gdi > 0 Then _IdMenor += "And MAEDDO.IDMAEEDO < " & _Idmaeedo_Gdi & vbCrLf

        Dim _Codigo = _Row_Producto.Item("CodigoPr")

        Dim _Filtro, _Filtro_A, _Filtro_Bodega As String
        Dim _Filtro_Condicion_Extra As String


        Dim _Fecha_Informe = Format(_Fecha_Inventario, "yyyyMMdd")

        _Filtro_Condicion_Extra = "And MAEDDO.IDMAEEDO Not In (" & _Idmaeedo_Gri_Cero & "," & _Idmaeedo_Gri & "," & _Idmaeedo_Gdi & ")" & vbCrLf &
                                  "And MAEDDO.FEEMLI <= '" & _Fecha_Informe & "'" & vbCrLf & _IdMenor

        Consulta_sql = My.Resources._23_ConsultasSQL.Foto_StockXProducto
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
        Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Codigo)
        Consulta_sql = Replace(Consulta_sql, "--Filtro_Condicion_Extra", _Filtro_Condicion_Extra)


        Dim _TblKardex As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql) '_SQL.Fx_Get_Tablas(Consulta_sql)

        Return _TblKardex.Rows(0)

    End Function

End Class