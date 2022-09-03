Imports Funciones_BakApp


Public Class Frm_Filtro_ProductosClass
    Public CodInforme As String
    Public Para_Seleccion_Tablas As Boolean = False
    Public Tabla_Seleccionada As String

    Private Sub BtnRubros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRubros.Click
        If Para_Seleccion_Tablas Then
            Tabla_Seleccionada = "Rubro"
            Me.Close()
        Else
            Rev_ChkBtn(sender, CargarFiltro("RUPR", CodInforme, "Filtro Rubros", Me, True))
        End If
    End Sub

    Private Sub BtnClasLibre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClasLibre.Click
        If Para_Seleccion_Tablas Then
            Tabla_Seleccionada = "Clasificacion_Libre"
            Me.Close()
        Else
            Rev_ChkBtn(sender, CargarFiltro("CLALIBPR", CodInforme, "Filtro Clasificación libre", Me, True))
        End If
    End Sub

    Private Sub BtnMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMarca.Click
        If Para_Seleccion_Tablas Then
            Tabla_Seleccionada = "Marca"
            Me.Close()
        Else
            Rev_ChkBtn(sender, CargarFiltro("MRPR", CodInforme, "Filtro Marcas", Me, True))
        End If
    End Sub

    Private Sub BtnZona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZona.Click
        If Para_Seleccion_Tablas Then
            Tabla_Seleccionada = "Zona"
        Else
            Rev_ChkBtn(sender, CargarFiltro("ZONAPR", CodInforme, "Filtro Zonas", Me, True))
        End If
    End Sub

    Private Sub BtnFamilias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFamilias.Click
        If Para_Seleccion_Tablas Then
            Tabla_Seleccionada = "Super_Familia"
        Else
            Rev_ChkBtn(sender, CargarFiltro("FMPR", CodInforme, "Filtro Super Familias", Me, True))
        End If
    End Sub

    Private Sub BtnRubros_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnRubros.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Para_Seleccion_Tablas Then
                Consulta_sql = "Select KORU as 'Código', NOKORU As 'Descripción' From TABRU"
                Mostra_Tabla(Consulta_sql)
            Else
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    BtnRubros.Checked = True
                    MarcarTodosLosFiltro(CodInforme, "RUPR")
                    BtnRubros.TitleText = "Mostrar todo"
                End If
            End If
        End If
    End Sub

    Sub Mostra_Tabla(ByVal Sql As String)

        Dim _Tbl As DataTable = get_Tablas(Sql, cn1)

        Dim Fm As New Frm_CargarTablasDePaso
        Fm._Tabla_de_Paso = _Tbl
        Fm.ShowDialog(Me)

    End Sub

    Private Sub BtnClasLibre_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnClasLibre.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Para_Seleccion_Tablas Then
                Consulta_sql = "select KOCARAC AS 'Código',NOKOCARAC as 'Descripción' From TABCARAC WHERE KOTABLA = 'CLALIBPR'"
                Mostra_Tabla(Consulta_sql)
            Else
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    BtnClasLibre.Checked = True
                    MarcarTodosLosFiltro(CodInforme, "CLALIBPR")
                    BtnClasLibre.TitleText = "Mostrar todo"
                End If
            End If
        End If
    End Sub

    Private Sub BtnMarca_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnMarca.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Para_Seleccion_Tablas Then
                Consulta_sql = "select KOMR AS  'Código',NOKOMR as 'Descripción' From TABMR"
                Mostra_Tabla(Consulta_sql)
            Else
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    BtnMarca.Checked = True
                    MarcarTodosLosFiltro(CodInforme, "MRPR")
                    BtnMarca.TitleText = "Mostrar todo"
                End If
            End If
        End If
    End Sub

    Private Sub BtnZona_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnZona.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Para_Seleccion_Tablas Then
                Consulta_sql = "select KOZO AS 'Código',NOKOZO as 'Descripción' From TABZO"
                Mostra_Tabla(Consulta_sql)
            Else
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    BtnZona.Checked = True
                    MarcarTodosLosFiltro(CodInforme, "ZONAPR")
                    BtnZona.TitleText = "Mostrar todo"
                End If
            End If
        End If
    End Sub

    Private Sub BtnFamilias_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnFamilias.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Para_Seleccion_Tablas Then
                Consulta_sql = "select KOFM AS 'Código',NOKOFM as 'Descripción' From TABFM"
                Mostra_Tabla(Consulta_sql)
            Else
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    BtnFamilias.Checked = True
                    MarcarTodosLosFiltro(CodInforme, "FMPR")
                    BtnFamilias.TitleText = "Mostrar todo"
                End If
            End If
        End If
    End Sub

    Private Sub Frm_06_AsisCompra_Filtros_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Para_Seleccion_Tablas Then
            Rev_ChkBtn(BtnClasLibre, CBool(trae_dato(tb, cn1, "MarcarTodo", _
                                                   _Global_BaseBk & "Zw_TblFiltro_InfxUs", _
                                                     "Funcionario = '" & FUNCIONARIO & _
                                                     "' And Informe = '" & CodInforme & "' And Tabla = 'CLALIBPR'")))

            Rev_ChkBtn(BtnFamilias, CBool(trae_dato(tb, cn1, "MarcarTodo", _
                                                     _Global_BaseBk & "Zw_TblFiltro_InfxUs", _
                                                     "Funcionario = '" & FUNCIONARIO & _
                                                     "' And Informe = '" & CodInforme & "' And Tabla = 'FMPR'")))

            Rev_ChkBtn(BtnMarca, CBool(trae_dato(tb, cn1, "MarcarTodo", _
                                                     _Global_BaseBk & "Zw_TblFiltro_InfxUs", _
                                                     "Funcionario = '" & FUNCIONARIO & _
                                                     "' And Informe = '" & CodInforme & "' And Tabla = 'MRPR'")))

            Rev_ChkBtn(BtnRubros, CBool(trae_dato(tb, cn1, "MarcarTodo", _
                                                     _Global_BaseBk & "Zw_TblFiltro_InfxUs", _
                                                     "Funcionario = '" & FUNCIONARIO & _
                                                     "' And Informe = '" & CodInforme & "' And Tabla = 'RUPR'")))

            Rev_ChkBtn(BtnZona, CBool(trae_dato(tb, cn1, "MarcarTodo", _
                                                     _Global_BaseBk & "Zw_TblFiltro_InfxUs", _
                                                     "Funcionario = '" & FUNCIONARIO & _
                                                     "' And Informe = '" & CodInforme & "' And Tabla = 'ZONAPR'")))
        End If
    End Sub

    Sub Rev_ChkBtn(ByVal Boton As Object, ByVal Chekeo As Boolean)
        Boton.Checked = Chekeo
        If Chekeo Then
            Boton.TitleText = "Mostrar todo"
        Else
            Boton.TitleText = "Algunas seleccionadas..."
        End If
    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        Tabla_Seleccionada = String.Empty
        Me.Close()
    End Sub

    Private Sub Frm_Filtro_ProductosClass_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        ' Tabla_Seleccionada = String.Empty
    End Sub
End Class