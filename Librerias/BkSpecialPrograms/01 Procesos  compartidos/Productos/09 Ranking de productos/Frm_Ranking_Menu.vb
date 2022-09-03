Imports DevComponents.DotNetBar
'Imports BkSpecialPrograms
'Imports Lib_Bakapp_VarClassFunc


Public Class Frm_Ranking_Menu

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim TablaRanking_Paso As String = "TblPasoRanking" & FUNCIONARIO
    Dim Ds_Rk As New DsRanking
    Dim _Cancelar As Boolean

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        caract_combo(CmbListaDeCostos)
        Consulta_sql = "SELECT KOLT AS Padre,KOLT+'-'+NOKOLT AS Hijo FROM TABPP WHERE TILT = 'C'"
        CmbListaDeCostos.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)


    End Sub

    Private Sub Frm_Ranking_Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Ds_Rk.Clear()
        Dim exists = System.IO.File.Exists(AppPath() & "\Data\" & RutEmpresa & "\DsRanking.xml")

        If Not exists Then
            Ds_Rk.WriteXml(AppPath() & "\Data\" & RutEmpresa & "\DsRanking.xml")
            'MessageBoxEx.Show("Arvhico XML creado correctamente", "Crear XML de Conexión", _
            '                  MessageBoxButtons.OK, MessageBoxIcon.Information)

            Fecha_Estudio_desde.Value = Primerdiadelmes(Now.Date)
            Fecha_Estudio_hasta.Value = ultimodiadelmes(Now.Date)

            Fecha_Desde_Desc.Value = Primerdiadelmes(Now.Date)
            Fecha_Hasta_Desc.Value = ultimodiadelmes(Now.Date)

            ActualizarParametrosDeFiltro()

        Else
            Ds_Rk.ReadXml(AppPath() & "\Data\" & RutEmpresa & "\DsRanking.xml")
        End If

        Dim _TblRk As DataTable

        _TblRk = Ds_Rk.Tables("Conf_Ranking")
        Dim Fila As DataRow
        Fila = _TblRk.Rows(0)
        With Fila

            Fecha_Estudio_desde.Value = .Item("Fecha_Desde")
            Fecha_Estudio_hasta.Value = .Item("Fecha_Hasta")

            RdPmTrans.Checked = .Item("PPM_X_Trans")
            RdPM.Checked = .Item("PPM")
            RdUC.Checked = .Item("UC")
            RdLP.Checked = .Item("Lcostos")
            CmbListaDeCostos.SelectedValue = .Item("Lista")

            Fecha_Desde_Desc.Value = .Item("Fecha_Desde_Desc")
            Fecha_Hasta_Desc.Value = .Item("Fecha_Desde")

        End With

    End Sub


    Sub ActualizarParametrosDeFiltro()
        Dim NewFila As DataRow
        NewFila = Ds_Rk.Tables("Conf_Ranking").NewRow
        With NewFila

            .Item("Fecha_Desde") = Fecha_Estudio_desde.Value
            .Item("Fecha_Hasta") = Fecha_Estudio_hasta.Value

            .Item("PPM_X_Trans") = RdPmTrans.Checked
            .Item("PPM") = RdPM.Checked
            .Item("UC") = RdUC.Checked
            .Item("Lcostos") = RdLP.Checked
            .Item("Lista") = CmbListaDeCostos.SelectedValue

            .Item("Fecha_Desde_Desc") = Fecha_Desde_Desc.Value
            .Item("Fecha_Hasta_Desc") = Fecha_Hasta_Desc.Value

            Ds_Rk.Tables("Conf_Ranking").Rows.Add(NewFila)
        End With

        Ds_Rk.WriteXml(AppPath() & "\Data\" & RutEmpresa & "\DsRanking.xml")

    End Sub


    Private Sub BtnProcesarInf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesarInf.Click
        _Cancelar = False

        Dim _TblProductos As DataTable

        _TblProductos = Sb_Procesar_Nuevo_Informe()

        If Not (_TblProductos Is Nothing) Then

            Dim Fm As New Frm_Ranking_Resultado(_TblProductos)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Function Sb_Procesar_Nuevo_Informe() As DataTable

        ' Solo productos que manejan Stock
        Me.Enabled = False
        System.Windows.Forms.Application.DoEvents()
        Dim Fm As New Frm_Form_Esperar
        Fm.BarraCircular.IsRunning = True
        Fm.Show()

        Consulta_sql = "Select KOPR,KOPRTE,KOPRRA,NOKOPR From MAEPR WHERE TIPR IN ('FPN','FIN','FPS','FUN','FUS')"
        Dim _Tbl_Producto As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
        Dim Filas_t As Long = _Tbl_Producto.Rows.Count

        If Not CBool(Filas_t) Then
            MessageBoxEx.Show(Me, "No hay producto en la base de datos que procesar",
                              "Seleccionar productos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return Nothing
        End If

        Try

            Dim OpcionCosto As Integer
            If RdPmTrans.Checked Then
                OpcionCosto = 0
            ElseIf RdPM.Checked Then
                OpcionCosto = 1
            ElseIf RdUC.Checked Then
                OpcionCosto = 2
            ElseIf RdLP.Checked Then
                OpcionCosto = 3
            End If


            Consulta_sql = "DROP TABLE Zw_TblMargen"
            _Sql.Ej_consulta_IDU(Consulta_sql, False)
            Consulta_sql = "DROP TABLE Zw_TblMrgImp"
            _Sql.Ej_consulta_IDU(Consulta_sql, False)
            Consulta_sql = "DROP TABLE " & TablaRanking_Paso
            _Sql.Ej_consulta_IDU(Consulta_sql, False)


            Consulta_sql = My.Resources.Consultas.Ranking_productos_01
            _Sql.Ej_consulta_IDU(Consulta_sql)

            System.Windows.Forms.Application.DoEvents()
            Consulta_sql = My.Resources.Consultas.Ranking_productos_02

            Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
            Consulta_sql = Replace(Consulta_sql, "#FechaDesde#", Format(Fecha_Estudio_desde.Value, "yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "#FechaHasta#", Format(Fecha_Estudio_hasta.Value, "yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)
            Consulta_sql = Replace(Consulta_sql, "Zw_TblInf_EntExcluidas", _Global_BaseBk & "Zw_TblInf_EntExcluidas")

            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Return Nothing
            End If


            Consulta_sql = My.Resources.Consultas.Ranking_productos_03
            Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
            Consulta_sql = Replace(Consulta_sql, "#FechaDesde#", Format(Fecha_Estudio_desde.Value, "yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "#FechaHasta#", Format(Fecha_Estudio_hasta.Value, "yyyyMMdd"))
            Consulta_sql = Replace(Consulta_sql, "#Funcionario#", FUNCIONARIO)
            Consulta_sql = Replace(Consulta_sql, "#Opcion#", OpcionCosto)
            Consulta_sql = Replace(Consulta_sql, "#ListaCostos#", CmbListaDeCostos.SelectedValue)
            Consulta_sql = Replace(Consulta_sql, "Zw_TblInf_EntExcluidas", _Global_BaseBk & "Zw_TblInf_EntExcluidas")

            Dim DD = Format(Fecha_Estudio_desde.Value, "yyyyMMdd")

            Consulta_sql = Replace(Consulta_sql, "TblPasoRanking", TablaRanking_Paso) 'Zw_ProdRanking
            ' If Not  _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            'Return Nothing
            'End If
            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Fm.Close()
            Fm.Dispose()


            MessageBoxEx.Show(Me, "Informe generado correctamente", "Generar reporte",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)



            Return _Tbl

        Catch ex As Exception
            'MsgBox(ex.Message)
            'myTrans.Rollback()
            MessageBoxEx.Show(Me, ex.Message, "Transaccion desecha", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Consulta_sql = "DROP TABLE Zw_TblMargen"
            _Sql.Ej_consulta_IDU(Consulta_sql, False)
            Consulta_sql = "DROP TABLE Zw_TblMrgImp"
            _Sql.Ej_consulta_IDU(Consulta_sql, False)
            Consulta_sql = "DROP TABLE " & TablaRanking_Paso
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            'SQL_ServerClass.Sb_Cerrar_Conexion(cn2)
            Return Nothing
        Finally
            Me.Enabled = True
        End Try
    End Function

    Sub Clasificar_Rk(ByVal CampoRk As String,
                      ByVal CampoTop As String,
                      ByVal ColAnalizando As String,
                      ByVal Estado As Object)

        Dim Porcent_Max As Double

        Porcent_Max = InputBox("1", "Ingrese %")


        Consulta_sql = "Select  Codigo,Descripcion," & CampoRk & " from TblPasoRanking" & vbCrLf &
                       "Order by " & CampoRk & " Desc"

        Dim Tabla As DataTable
        Tabla = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim Suma As Double = 0
        Dim NroFila = 0
        Dim Porcentaje As Double

        Estado.text = "Analizando " & ColAnalizando

        For Each Fila As DataRow In Tabla.Rows
            Dim Codigo = Trim(Fila.Item("Codigo").ToString)
            Porcentaje = Fila.Item(CampoRk).ToString
            Suma += Porcentaje

            Estado.text = "Analizando " & ColAnalizando & vbCrLf &
                          "Fila N° " & NroFila & vbCrLf &
                          "Porcentaje acumulado " & Suma & "%"

            Consulta_sql = "Update Zw_Prod_Ranking Set " & CampoTop & " = 'X' Where Codigo = '" & Codigo & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Dim Diferencia As Double = Math.Round(Suma - Porcent_Max, 5)

            If Diferencia > 0.5 Then
                Exit For
            End If
        Next


    End Sub

    Private Sub BtnEntExcluidas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEntExcluidas.Click

        Dim Fm As New Frm_EntExcluidas
        Fm.ShowInTaskbar = False
        Fm.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        Fm.ShowDialog(Me)

    End Sub

    Private Sub Btn_Ver_Ranking_Actual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Ranking_Actual.Click

        Consulta_sql = "Select *,Cast('' As Varchar(5)) As Star2 From " & _Global_BaseBk & "Zw_Prod_Ranking" & vbCrLf &
                      "Order by Ranking_Top"

        Dim _TblProductos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim Fm As New Frm_Ranking_Resultado(_TblProductos)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Frm_Ranking_Menu_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Ranking_Menu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Ds_Rk.Clear()
        ActualizarParametrosDeFiltro()
    End Sub
End Class


