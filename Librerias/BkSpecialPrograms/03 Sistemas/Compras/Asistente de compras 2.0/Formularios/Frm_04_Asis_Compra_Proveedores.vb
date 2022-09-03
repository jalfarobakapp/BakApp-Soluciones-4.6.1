Imports DevComponents.DotNetBar

Public Class Frm_04_Asis_Compra_Proveedores

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Codigo As String
    Dim _RowProveedor As DataRow

    Public Enum TipoBusqueda
        Proveedores_Solo_Con_Codigo_Alternativo
        Proveedores_del_producto
        Proveedores_Seleccionados
        Todos_los_Proveedores
    End Enum

    Dim _Conficion_Adicional = String.Empty
    Dim _Tipo_De_Busqueda As TipoBusqueda
    Dim _Para_Generar_Occ As Boolean

    Public Property Pro_Conficion_Adicional() As String
        Get
            Return _Conficion_Adicional
        End Get
        Set(ByVal value As String)
            _Conficion_Adicional = value
        End Set
    End Property

    Public Property Pro_RowProveedor() As DataRow
        Get
            Return _RowProveedor
        End Get
        Set(ByVal value As DataRow)
            _RowProveedor = value
        End Set
    End Property

    Public Property Pro_Rd_Costo_Ultima_GRC() As Boolean
        Get
            Return Rd_Costo_Ultima_GRC.Checked
        End Get
        Set(ByVal value As Boolean)
            Rd_Costo_Ultima_GRC.Checked = value
        End Set
    End Property

    Public Property Pro_Rd_Costo_Lista_Proveedor() As Boolean
        Get
            Return Rd_Costo_Lista_Proveedor.Checked
        End Get
        Set(ByVal value As Boolean)
            Rd_Costo_Lista_Proveedor.Checked = value
        End Set
    End Property

    Public Sub New(_Tipo_De_Busqueda As TipoBusqueda,
                   _Codigo As String,
                   _Para_Generar_Occ As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(GrillaProveedores, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Me._Tipo_De_Busqueda = _Tipo_De_Busqueda
        Me._Codigo = _Codigo
        Me._Para_Generar_Occ = _Para_Generar_Occ

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Sub Sb_Actualizar_Grilla(Proveedor As String,
                             TipoBusqueda As TipoBusqueda)

        Dim _Cadena As String = CADENA_A_BUSCAR(Proveedor, "KOEN+NOKOEN LIKE '%")
        Dim _Filtro_Cadena = "(Select KOEN From MAEEN Where KOEN+NOKOEN Like '%" & _Cadena & "%')"


        Select Case _Tipo_De_Busqueda

            Case Frm_04_Asis_Compra_Proveedores.TipoBusqueda.Proveedores_Solo_Con_Codigo_Alternativo

                Consulta_Sql = "SELECT distinct Td.KOEN,Mn.NOKOEN as RAZON" & vbCrLf &
                               "FROM TABCODAL as Td INNER JOIN MAEEN Mn ON Mn.KOEN = Td.KOEN" & vbCrLf &
                               "And KOPR = '" & _Codigo & "' And KOEN In " & _Filtro_Cadena

            Case Frm_04_Asis_Compra_Proveedores.TipoBusqueda.Proveedores_del_producto

                If Rd_Costo_Lista_Proveedor.Checked Then

                    Consulta_Sql = "SELECT DISTINCT ENDO AS KOEN,(Select Top 1 NOKOEN From MAEEN Where KOEN = ENDO) As RAZON," & vbCrLf &
                                   "Isnull((Select Top 1 CostoUd1 From Zw_ListaPreCosto Where Proveedor = ENDO And Codigo = '" & _Codigo & "'),0) As Ud1," & vbCrLf &
                                   "Isnull((Select Top 1 CostoUd2 From Zw_ListaPreCosto Where Proveedor = ENDO And Codigo = '" & _Codigo & "'),0) As Ud2" & vbCrLf &
                                   "FROM MAEDDO Ddo WHERE KOPRCT = '" & _Codigo & "'" & vbCrLf &
                                   "AND ENDO NOT IN " & vbCrLf &
                                   "(Select DISTINCT KOEN" & vbCrLf &
                                   "From TABCODAL Td" & vbCrLf &
                                   "Where KOPR = '" & _Codigo & "' And Td.KOEN <> '')" & vbCrLf &
                                   "AND TIDO IN ('FCC','GRC','OCC') AND ENDOFI = '' And Ddo.ENDO In " & _Filtro_Cadena & vbCrLf &
                                   "UNION" & vbCrLf &
                                   "Select DISTINCT KOEN," & vbCrLf &
                                   "(Select Top 1 NOKOEN From MAEEN Where KOEN = Td.KOEN) As RAZON," & vbCrLf &
                                   "Isnull((Select Top 1 CostoUd1 From Zw_ListaPreCosto Where Proveedor = KOEN And Codigo = '" & _Codigo & "'),0) As Ud1," & vbCrLf &
                                   "Isnull((Select Top 1 CostoUd2 From Zw_ListaPreCosto Where Proveedor = KOEN And Codigo = '" & _Codigo & "'),0) As Ud2" & vbCrLf &
                                   "From TABCODAL Td" & vbCrLf &
                                   "Where KOPR = '" & _Codigo & "' And Td.KOEN <> '' And Td.KOEN In " & _Filtro_Cadena

                    If Chk_Solo_Proveedores_CodAlternativo.Checked Then

                        Consulta_Sql = "Select DISTINCT KOEN," & vbCrLf &
                                       "(Select Top 1 NOKOEN From MAEEN Where KOEN = Td.KOEN) As RAZON," & vbCrLf &
                                       "Isnull((Select Top 1 CostoUd1 From Zw_ListaPreCosto Where Proveedor = KOEN And Codigo = '" & _Codigo & "'),0) As Ud1," & vbCrLf &
                                       "Isnull((Select Top 1 CostoUd2 From Zw_ListaPreCosto Where Proveedor = KOEN And Codigo = '" & _Codigo & "'),0) As Ud2" & vbCrLf &
                                       "From TABCODAL Td" & vbCrLf &
                                       "Where KOPR = '" & _Codigo & "' And Td.KOEN <> '' And Td.KOEN In " & _Filtro_Cadena

                    End If

                ElseIf Rd_Costo_Ultima_GRC.Checked Then

                    Consulta_Sql = "SELECT DISTINCT ENDO AS KOEN,(Select Top 1 NOKOEN From MAEEN Where KOEN = ENDO) As RAZON," & vbCrLf &
                                   "Isnull((Select Top 1 PPPRNERE1 From MAEDDO Do Where Do.ENDO = Ddo.ENDO And Do.KOPRCT = '" & _Codigo & "' And Do.TIDO = 'GRC' Order by FEEMLI Desc),0) As Ud1," & vbCrLf &
                                   "Isnull((Select Top 1 PPPRNERE2 From MAEDDO Do Where Do.ENDO = Ddo.ENDO And Do.KOPRCT = '" & _Codigo & "' And Do.TIDO = 'GRC' Order by FEEMLI Desc),0) As Ud2" & vbCrLf &
                                   "FROM MAEDDO Ddo WHERE KOPRCT = '" & _Codigo & "'" & vbCrLf &
                                   "AND ENDO NOT IN " & vbCrLf &
                                   "(Select DISTINCT KOEN" & vbCrLf &
                                   "From TABCODAL Td" & vbCrLf &
                                   "Where KOPR = '" & _Codigo & "' And Td.KOEN <> '')" & vbCrLf &
                                   "AND TIDO IN ('FCC','GRC','OCC') AND ENDOFI = '' And Ddo.ENDO In " & _Filtro_Cadena & vbCrLf &
                                   "UNION" & vbCrLf &
                                   "Select DISTINCT KOEN," & vbCrLf &
                                   "(Select Top 1 NOKOEN From MAEEN Where KOEN = Td.KOEN) As RAZON," & vbCrLf &
                                   "Isnull((Select Top 1 PPPRNERE1 From MAEDDO Do Where Do.ENDO = Td.KOEN And Do.KOPRCT = '" & _Codigo & "' And Do.TIDO = 'GRC' Order by FEEMLI Desc),0) As Ud1," & vbCrLf &
                                   "Isnull((Select Top 1 PPPRNERE2 From MAEDDO Do Where Do.ENDO = Td.KOEN And Do.KOPRCT = '" & _Codigo & "' And Do.TIDO = 'GRC' Order by FEEMLI Desc),0) As Ud2" & vbCrLf &
                                   "From TABCODAL Td" & vbCrLf &
                                   "Where KOPR = '" & _Codigo & "' And Td.KOEN <> '' AND Td.KOEN In " & _Filtro_Cadena

                    If Chk_Solo_Proveedores_CodAlternativo.Checked Then

                        Consulta_Sql = "Select DISTINCT KOEN," & vbCrLf &
                                       "(Select Top 1 NOKOEN From MAEEN Where KOEN = Td.KOEN) As RAZON," & vbCrLf &
                                       "Isnull((Select Top 1 PPPRNERE1 From MAEDDO Do Where Do.ENDO = Td.KOEN And Do.KOPRCT = '" & _Codigo & "' And Do.TIDO = 'GRC' Order by FEEMLI Desc),0) As Ud1," & vbCrLf &
                                       "Isnull((Select Top 1 PPPRNERE2 From MAEDDO Do Where Do.ENDO = Td.KOEN And Do.KOPRCT = '" & _Codigo & "' And Do.TIDO = 'GRC' Order by FEEMLI Desc),0) As Ud2" & vbCrLf &
                                       "From TABCODAL Td" & vbCrLf &
                                       "Where KOPR = '" & _Codigo & "' And Td.KOEN <> '' AND Td.KOEN In " & _Filtro_Cadena

                    End If

                End If

            Case Frm_04_Asis_Compra_Proveedores.TipoBusqueda.Proveedores_Seleccionados

                Consulta_Sql = "SELECT DISTINCT CodProveedor as KOEN," & vbCrLf &
                               "(Select Top 1 NOKOEN From MAEEN Where KOEN = CodProveedor and SUEN = CodSucProveedor ) as RAZON," & vbCrLf &
                               "COUNT(Codigo) as Productos" & vbCrLf &
                               "FROM Zw_InfCompras01" & FUNCIONARIO & vbCrLf &
                               "WHERE CodProveedor <> '' AND CantComprar > 0 And OccGenerada = 0 And Comprar = 1" & vbCrLf &
                               "And CodProveedor In " & _Filtro_Cadena & vbCrLf &
                               _Conficion_Adicional &
                               "Group by CodProveedor,CodSucProveedor"

            Case Frm_04_Asis_Compra_Proveedores.TipoBusqueda.Todos_los_Proveedores

                Consulta_Sql = "SELECT DISTINCT KOEN,NOKOEN as RAZON" & vbCrLf &
                               "FROM MAEEN" & vbCrLf &
                               "WHERE TIEN IN ('P','A') And KOEN In " & _Filtro_Cadena

        End Select



        'Dim FiltroProveedor As String
        'FiltroProveedor = "And Mn.KOEN+Mn.NOKOEN LIKE '%" & cadena & "%'" & vbCrLf & " Order By Mn.NOKOEN"

        With GrillaProveedores

            .DataSource = _Sql.Fx_Get_Tablas(Consulta_Sql)

            .Columns("KOEN").Width = 100
            .Columns("KOEN").HeaderText = "Código"

            .Columns("RAZON").Width = 505
            .Columns("RAZON").HeaderText = "Razón social"

            If _Tipo_De_Busqueda = Frm_04_Asis_Compra_Proveedores.TipoBusqueda.Proveedores_del_producto Then

                .Columns("RAZON").Width = 345

                .Columns("Ud1").Width = 80
                .Columns("Ud1").HeaderText = "$ Ud1"
                .Columns("Ud1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Ud1").DefaultCellStyle.Format = "$ ###,##"

                .Columns("Ud2").Width = 80
                .Columns("Ud2").HeaderText = "$ Ud2"
                .Columns("Ud2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Ud2").DefaultCellStyle.Format = "$ ###,##"

            ElseIf _Tipo_De_Busqueda = Frm_04_Asis_Compra_Proveedores.TipoBusqueda.Proveedores_Seleccionados Then

                .Columns("RAZON").Width = 390

                .Columns("Productos").Width = 100
                .Columns("Productos").HeaderText = "Productos"
                .Columns("Productos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        End With
    End Sub

    Private Sub Frm_04_AsisCompra_Proveedores_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        AddHandler Rd_Costo_Lista_Proveedor.CheckedChanged, AddressOf Rd_CheckedChanged
        AddHandler Rd_Costo_Ultima_GRC.CheckedChanged, AddressOf Rd_CheckedChanged
        AddHandler Chk_Solo_Proveedores_CodAlternativo.CheckedChanged, AddressOf Rd_CheckedChanged
        AddHandler Btn_Actualizar.Click, AddressOf Rd_CheckedChanged

        Sb_Actualizar_Grilla("", _Tipo_De_Busqueda)

        Me.ActiveControl = Txtdescripcion

    End Sub

    Private Sub Txtdescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtdescripcion.KeyDown

        Select Case e.KeyValue
            Case Keys.Enter, Keys.Space
                Sb_Actualizar_Grilla(Txtdescripcion.Text, _Tipo_De_Busqueda)
        End Select

    End Sub

    Private Sub GrillaProveedores_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaProveedores.CellDoubleClick

        Dim _Fila As DataGridViewRow = GrillaProveedores.Rows(GrillaProveedores.CurrentRow.Index)

        Dim _Koen As String = _Fila.Cells("KOEN").Value

        _RowProveedor = Nothing

        Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        If _Tbl.Rows.Count = 1 Then

            _RowProveedor = _Tbl.Rows(0)

        ElseIf _Tbl.Rows.Count > 1 Then

            Dim Fm As New Frm_BuscarEntidad_MtSuc
            Fm.ShowDialog(Me)
            If Fm._Suc_Seleccionada Then
                _RowProveedor = Fm._Tbl_SucursalSelec(0)
            End If
            Fm.Dispose()

        End If

        If Not (_RowProveedor Is Nothing) Then
            Me.Close()
        End If


    End Sub

    Private Sub Txtdescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdescripcion.TextChanged
        If String.IsNullOrEmpty(Trim(Txtdescripcion.Text)) Then
            Sb_Actualizar_Grilla(Txtdescripcion.Text, _Tipo_De_Busqueda)
        End If
    End Sub


    Private Sub Frm_04_AsisCompra_Proveedores_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Rd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Sb_Actualizar_Grilla("", _Tipo_De_Busqueda)
    End Sub

End Class
