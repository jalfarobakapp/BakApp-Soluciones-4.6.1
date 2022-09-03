Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.Data.SqlClient

Public Class Frm_CreaProductos_01

    Dim SqlEmpresa As String
    Dim SqlListas As String
    Dim SqlBodegas As String
    Dim SqlImpuestos As String

    Public VieneDesdeSolicitud As Boolean
    Public _Crear As Boolean

    Dim CambioDeCodigo As Boolean = False
    Dim CambiarDescripcion As Boolean = False
    Dim CodigoCambioDescripcion As String

    Dim _Datos_Producto As New Ds_Producto


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Grilla.RowTemplate.Height = 18
        Limpiar()

        Sb_CargarGrillas()
        CargarCombos()

        Txtrtu.Text = 1

        Cmblista.SelectedValue = "TABPP" & ModListaPrecioCosto

       Sb_Formato_Generico_Grilla(GrillaBodegas, 20, New Font("Tahoma", 7), Color.PaleGoldenrod, ScrollBars.Vertical, False, False, False)
       Sb_Formato_Generico_Grilla(GrillaEmpresa, 20, New Font("Tahoma", 7), Color.PaleGoldenrod, ScrollBars.Vertical, False, False, False)
       Sb_Formato_Generico_Grilla(GrillaListaDePrecios, 20, New Font("Tahoma", 6), Color.PaleGoldenrod, ScrollBars.Vertical, False, False, False)

       Sb_Formato_Generico_Grilla(GrillaImpuestos, 20, New Font("Tahoma", 7), Color.PaleGoldenrod, ScrollBars.Vertical, False, False, False)
       Sb_Formato_Generico_Grilla(GrillProdBuscados, 20, New Font("Tahoma", 7), Color.PaleGoldenrod, ScrollBars.Vertical, False, False, False)

        EstiloFormulario(StyleManager1)

    End Sub

    Function TraeDescrip(ByVal Txt As Object, _
                         ByVal Chk As CheckBox, ByVal Tipo As Integer) As String

        Dim Cod = CType(Txt, Control).Text

        If Chk.Checked Then
            Return Cod
        Else
            If Tipo = 1 Then
                Return "00"
            Else
                Return "000"
            End If
        End If

    End Function

    Sub Actualizar_Grilla()

        Consulta_sql = "SELECT * FROM Tmp_MatrizCreacionCodigos"
        Ejecutar_consulta_SQLaccess(Consulta_sql)

        tb = New DataTable
        dbD.Fill(tb) ' ---  aca se carga la tabla de la base access completa

        With Grilla

            .DataSource = tb ' -- Se asigna la tabla al datagridview

            '.Columns("Cod_Class").Visible = False
            .Columns("Cod_NomClass").Visible = False
            .Columns("OrdenCodigo").Visible = False
            .Columns("CaracteresCod").Visible = False

            .Columns("Cod_Class").ReadOnly = True
            .Columns("Cod_Class").HeaderText = "Cod."
            .Columns("Cod_Class").Width = 40

            .Columns("Nom_Class").ReadOnly = True
            .Columns("Nom_Class").HeaderText = "Clasificación"
            .Columns("Nom_Class").Width = 120

            .Columns("Descripcion_Class").ReadOnly = True
            .Columns("Descripcion_Class").HeaderText = "Descripción clasificación"
            .Columns("Descripcion_Class").Width = 200


            .Columns("MostrarEnDescripcion").HeaderText = "Incorporar Detalle"
            .Columns("MostrarEnDescripcion").Width = 60

            .Columns("Orden").HeaderText = "Orden"
            .Columns("Orden").Width = 50


            .Columns("MostraDescipcionOpcional").HeaderText = "Mostrar descripción alternativa"
            .Columns("MostraDescipcionOpcional").Width = 67

            .Columns("Descripcion_Opcional").ReadOnly = True
            .Columns("Descripcion_Opcional").HeaderText = "Descripción opcional"
            .Columns("Descripcion_Opcional").Width = 190

            '.Columns("Orden").HeaderText = "%Dscto"

            'Columns("Descuento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            '.Columns("CostoNetoUnit").Width = 70
            '.Columns("CostoNetoUnit").HeaderText = "Costo Ud."
            '.Columns("CostoNetoUnit").DefaultCellStyle.Format = "$ ###,##"
            '.Columns("CostoNetoUnit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            .Refresh()

        End With
    End Sub

    Function CrearCodigoProducto() As String

        Consulta_sql = "SELECT Cod_Class" & vbCrLf & _
                       "FROM Tmp_MatrizCreacionCodigos" & vbCrLf & _
                       "Order by OrdenCodigo"


        Dim CodigoDef As String

        Ejecutar_consulta_SQLaccess(Consulta_sql)

        tb = New DataTable
        dbD.Fill(tb) ' 

        For Each Fila As DataRow In tb.Rows
            Dim Des1 = Fila.Item("Cod_Class").ToString
            CodigoDef = Trim(CodigoDef & "" & Des1)
        Next

        Return CodigoDef

    End Function

    Function CrearDetalleProducto() As String

        Consulta_sql = "SELECT Descripcion_Class,Descripcion_Opcional,MostraDescipcionOpcional" & vbCrLf & _
                       "FROM Tmp_MatrizCreacionCodigos" & vbCrLf & _
                       "where MostrarEnDescripcion = True" & vbCrLf & _
                       "Order by Orden"

        'MostraDescipcionOpcional

        Dim DescripcionDef As String

        Ejecutar_consulta_SQLaccess(Consulta_sql)

        tb = New DataTable
        dbD.Fill(tb) ' 

        For Each Fila As DataRow In tb.Rows

            Dim Des1 = Fila.Item("Descripcion_Class").ToString
            Dim Des2 = Fila.Item("Descripcion_Opcional").ToString
            Dim Mostrar = Fila.Item("MostraDescipcionOpcional").ToString

            If Mostrar = False Then
                DescripcionDef = DescripcionDef & Des1 & " "
            Else
                DescripcionDef = DescripcionDef & Des2 & " "
            End If

        Next

        Return LTrim(Replace(DescripcionDef, "  ", " "))

    End Function

    Sub Limpiar()
        Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                       "Cod_Class = ''," & vbCrLf & _
                       "Descripcion_Class=''," & vbCrLf & _
                       "Descripcion_Opcional=''"
        Ej_consulta_IDUaccess(Consulta_sql)

        Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                       "Cod_Class = 'XXXX'" & vbCrLf & _
                       "Where Cod_NomClass = '03' or Cod_NomClass ='04' or Cod_NomClass ='05' or Cod_NomClass = '06'"
        Ej_consulta_IDUaccess(Consulta_sql)

        Consulta_sql = "Delete * from Tmp_MatrizCreacionCodigos_Aplica"
        Ej_consulta_IDUaccess(Consulta_sql)

        TxtCodigoPro.Text = ""
        TxtDescripcionProducto.Text = ""
        TxtDescripcionWeb.Text = ""

        Actualizar_Grilla()

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim Cod_NomClass = Grilla.Rows(e.RowIndex).Cells(0).Value
        Dim NomClass = Grilla.Rows(e.RowIndex).Cells(1).Value


        Dim CdClass = Grilla.Rows(e.RowIndex).Cells(2).Value


        If CdClass <> "X" And CdClass <> "XXXX" Then

            If NomClass = "COLOR" Or _
               NomClass = "MODELO" Or _
               NomClass = "MEDIDA" Or _
               NomClass = "CQ_FABRICA" Then

                If Validar() = True Then
                    ProcersarClase(Cod_NomClass, NomClass, e.RowIndex)
                End If
            Else
                ProcersarClase(Cod_NomClass, NomClass, e.RowIndex)
            End If
            Actualizar_Grilla()
        Else
            MsgBox("!Esta clasificación no aplica en este tipo de articulo!", MsgBoxStyle.Critical, "Validación")
        End If



    End Sub

    Sub ProcersarClase(ByVal Cod_NomClass As String, ByVal NomClass As String, ByVal IndiceGrilla As Integer)

        Dim Fr As New Frm_CreaProductos_02_BuscarListado
        'Fr.CodClass = CodClass
        Fr.CodTablaClass = NomClass
        Fr.TxtDescripcion.Focus()
        Fr.ShowDialog(Me)

        Dim CodCl = Trim(Fr.CodClass)
        Dim De1Cl = Trim(Fr.DesClassOrigen)
        Dim De2Cl = Trim(Fr.DesClassAltern)

        With Grilla.Rows.Item(IndiceGrilla).Cells
            .Item(2).Value = CodCl
            .Item(3).Value = De1Cl
            .Item(6).Value = De2Cl
        End With

        If CodCl = "" Or CodCl = Nothing Then Exit Sub

        Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                       "Cod_Class = '" & CodCl & "'," & vbCrLf & _
                       "Descripcion_Class='" & De1Cl & "'," & vbCrLf & _
                       "Descripcion_Opcional='" & De2Cl & "'" & vbCrLf & _
                       "Where Cod_NomClass = '" & Cod_NomClass & "'"
        Ej_consulta_IDUaccess(Consulta_sql)

        TxtCodigoPro.Text = CrearCodigoProducto()
        TxtDescripcionProducto.Text = CrearDetalleProducto()
        TxtDescripcionWeb.Text = TxtDescripcionProducto.Text

fin:
        Actualizar_Grilla()
    End Sub

    Function Validar() As Boolean

        Dim Registros =_Sql.Fx_Cuenta_RegistrosAccess("Tmp_MatrizCreacionCodigos_Aplica", "Codigo")
        If Registros > 0 Then
            Return True
        Else

            Dim info As New TaskDialogInfo("Validar ingreso", _
                              eTaskDialogIcon.ShieldStop, _
                              "Debe ingresar MARCA y ARTICULO antes de poner los demas valores", _
                              "Faltan datos que ingresar", _
                              eTaskDialogButton.Ok _
                              , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)

            Return False
        End If

    End Function

    Private Sub Grilla_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellValueChanged
        Try
            Dim Cod As String = Grilla.Rows(e.RowIndex).Cells(0).Value
            Dim ChkMostrar As Boolean = Grilla.Rows(e.RowIndex).Cells(4).Value
            Dim ChkMostrarDesOpt As Boolean = Grilla.Rows(e.RowIndex).Cells(5).Value
            Dim Orden As String = Grilla.Rows(e.RowIndex).Cells(7).Value

            Consulta_sql = "Update Tmp_MatrizCreacionCodigos Set MostrarEnDescripcion = " & ChkMostrar & _
                           ",MostraDescipcionOpcional = " & ChkMostrarDesOpt & ",Orden = " & Orden & vbCrLf & _
                           "Where Cod_NomClass = '" & Cod & "'"
            Ej_consulta_IDUaccess(Consulta_sql)

            TxtCodigoPro.Text = CrearCodigoProducto()
            TxtDescripcionProducto.Text = CrearDetalleProducto()
        Catch ex As Exception

        End Try


    End Sub

    

    Private Sub Grilla_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles Grilla.CellFormatting
        If Grilla.Columns(e.ColumnIndex).Name.Equals("Cod_Class") Then
            Dim Codd = (Grilla.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

            If Codd = "X" Or Codd = "XXXX" Then
                Grilla.Rows.Item(e.RowIndex).DefaultCellStyle.BackColor = Color.Gainsboro ' Color.Coral
                Grilla.Rows.Item(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
                'e.CellStyle.ForeColor = Color.White
                'e.CellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            Else
                Grilla.Rows.Item(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                Grilla.Rows.Item(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
                'e.CellStyle.ForeColor = Color.Black 'Color.DarkGreen
                'e.CellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            End If
        End If
    End Sub

    Private Sub TxtDescripcionProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescripcionProducto.TextChanged

        If Len(TxtDescripcionProducto.Text) > 50 Then
            TxtDescripcionProducto.ForeColor = Color.Red
        Else
            TxtDescripcionProducto.ForeColor = Color.Black
        End If

        LblCaracteres.Text = "Caracteres: " & Len(TxtDescripcionProducto.Text)

    End Sub

    Private Sub TxtDescripcionProducto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescripcionProducto.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            e.Handled = True
            TxtDescripcionWeb.Text = TxtDescripcionProducto.Text
        End If
    End Sub

    

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        If SwCambiarCod.Value = True Then

            Dim Registros =_Sql.Fx_Cuenta_Registros("MAEPR", "KOPRTE = '" & TxtCodigoPro.Text & "'")

            If Registros = 0 Then

                Consulta_sql = "UPDATE MAEPR SET KOPRTE = '" & TxtCodigoPro.Text & _
                               "', NOKOPR = '" & TxtDescripcionProducto.Text & _
                               "' WHERE KOPR = '" & CodigoCambioDescripcion & "'" & vbCrLf & _
                               "UPDATE TABCODAL SET  NOKOPRAL = '" & TxtDescripcionProducto.Text & _
                               "' WHERE KOPR = '" & CodigoCambioDescripcion & "'"

            Else

                Consulta_sql = "UPDATE MAEPR SET NOKOPR = '" & Trim(TxtDescripcionProducto.Text) & _
                               "' WHERE KOPR = '" & Trim(CodigoCambioDescripcion) & "'" & vbCrLf & _
                               "UPDATE TABCODAL SET  NOKOPRAL = '" & TxtDescripcionProducto.Text & _
                               "' WHERE KOPR = '" & CodigoCambioDescripcion & "'"
                'MsgBox("Código técnico ya exite", MsgBoxStyle.Critical, "Cambiar descripción")
            End If

            If  _Sql.Ej_consulta_IDU(Consulta_Sql) = True Then
                MsgBox("Descripción del producto " & CodigoCambioDescripcion & vbCrLf & _
                       "Cambiada correctamente", MsgBoxStyle.Information, "Cambio de descripción")
                CodigoCambioDescripcion = ""
                
            End If
            SwCambiarCod.Value = False
            CambioDescr(SwCambiarCod.Value)
        Else


        End If


    End Sub

    Private Function Chks(ByVal Chk As CheckBox) As Integer
        Dim Nro As Integer = 0
        If Chk.Checked = True Then Nro = 1
        Return Nro
    End Function

    Function CargarCombos()

        caract_combo(Cmbmarcas)
        Consulta_sql = "SELECT KOMR AS Padre,NOKOMR AS Hijo FROM TABMR ORDER BY NOKOMR" ' WHERE SEMILLA = " & Actividad
        Cmbmarcas.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmbrubros)
        Consulta_sql = "SELECT KORU AS Padre,NOKORU AS Hijo FROM TABRU ORDER BY NOKORU" ' WHERE SEMILLA = " & Actividad
        Cmbrubros.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmbclalibpr)
        Consulta_sql = "SELECT KOCARAC AS Padre,NOKOCARAC AS Hijo FROM TABCARAC WHERE KOTABLA = 'CLALIBPR' ORDER BY NOKOCARAC" ' WHERE SEMILLA = " & Actividad
        Cmbclalibpr.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmbunidad1)
        Consulta_sql = "SELECT CodigoTabla AS Padre,CodigoTabla AS Hijo FROM Zw_TablaDeCaracterizaciones WHERE Tabla = 'RTU' ORDER BY Orden"
        Cmbunidad1.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmbunidad2)
        Consulta_sql = "SELECT CodigoTabla AS Padre,CodigoTabla AS Hijo FROM Zw_TablaDeCaracterizaciones WHERE Tabla = 'RTU' ORDER BY Orden"
        Cmbunidad2.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)

        caract_combo(CmbBloqueoproducto)
        Consulta_sql = "SELECT CodigoTabla AS Padre,NombreTabla AS Hijo FROM Zw_TablaDeCaracterizaciones WHERE Tabla = 'BLOQUEOPR' ORDER BY Orden"
        CmbBloqueoproducto.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmbtipoproductos)
        Consulta_sql = "SELECT CodigoTabla AS Padre,NombreTabla AS Hijo FROM Zw_TablaDeCaracterizaciones WHERE Tabla = 'TIPR' ORDER BY Orden"
        Cmbtipoproductos.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)

        caract_combo(Cmblista)
        Consulta_sql = "SELECT 'TABPP'+KOLT AS Padre,KOLT+'-'+NOKOLT AS Hijo FROM TABPP"
        Cmblista.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)


        caract_combo(CmbJefeProducto)
        Consulta_sql = "SELECT KOFU AS Padre,NOKOFU AS Hijo FROM TABFU"
        CmbJefeProducto.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)
        CmbJefeProducto.SelectedValue = ""

        caract_combo(CmbZonaProducto)
        Consulta_sql = "SELECT 'TABPP'+KOLT AS Padre,KOLT+'-'+NOKOLT AS Hijo FROM TABPP"
        CmbZonaProducto.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)
        CmbZonaProducto.SelectedValue = ""

    End Function


    Sub Sb_CargarGrillas()

        Consulta_sql = "SELECT EMPRESA AS Codigo,RAZON as Descripcion FROM CONFIGP"
        Sb_Actualizar_Grillas_Seleccion("Tbl_Empresa", Consulta_sql, GrillaEmpresa)
        'SqlEmpresa = Consulta_sql

        Consulta_sql = "SELECT EMPRESA+'-'+KOSU+'-'+KOBO as Codigo,NOKOBO as Descripcion FROM TABBO"
        Sb_Actualizar_Grillas_Seleccion("Tbl_Bodegas", Consulta_sql, GrillaBodegas)
        'SqlBodegas = Consulta_sql

        Consulta_sql = "SELECT KOLT as Codigo,NOKOLT as Descripcion FROM TABPP"
        Sb_Actualizar_Grillas_Seleccion("Tbl_Listas", Consulta_sql, GrillaListaDePrecios)
        'SqlListas = Consulta_sql

        Consulta_sql = "SELECT KOIM as Codigo,NOKOIM as Descripcion FROM TABIM"
        Sb_Actualizar_Grillas_Seleccion("Tbl_Impuestos", Consulta_sql, GrillaImpuestos)
        'SqlImpuestos = Consulta_sql

    End Sub

    Sub Sb_Actualizar_Grillas_Seleccion(ByVal Tabla As String, _
                                        ByVal SQL As String, _
                                        ByVal Grilla As DataGridView)

        With Grilla
            '_Datos_Producto.Clear()
            .DataSource = Nothing

            Dim daAuthors As New SqlDataAdapter(Consulta_sql, cn1)
            daAuthors.Fill(_Datos_Producto, Tabla)

            .DataSource = _Datos_Producto
            .DataMember = _Datos_Producto.Tables(Tabla).TableName

            .Columns("Select").HeaderText = "Sel."
            .Columns("Select").Width = 50
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 235

        End With

    End Sub


    Private Sub ChkSelTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSelTodo.CheckedChanged
        ChkSelEmpresas.Checked = ChkSelTodo.Checked
        ChkSelBodegas.Checked = ChkSelTodo.Checked
        ChkSelListas.Checked = ChkSelTodo.Checked
    End Sub

    Private Sub ChkSelEmpresas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSelEmpresas.CheckedChanged
        ChequearTodo(GrillaEmpresa, ChkSelEmpresas, "Empresa")
    End Sub

    Private Sub ChkSelBodegas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSelBodegas.CheckedChanged
        ChequearTodo(GrillaBodegas, ChkSelBodegas, "Bodega")
    End Sub

    Private Sub ChkSelListas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSelListas.CheckedChanged
        ChequearTodo(GrillaListaDePrecios, ChkSelListas, "Listas")
    End Sub

    Private Function ChequearTodo(ByVal Grilla As DataGridView, _
                                  ByVal Chk As CheckBox, _
                                  ByVal NombreTabla As String)

        Dim Chequeo As Boolean
        Chequeo = Chk.Checked

        For i As Integer = 0 To Grilla.Rows.Count - 1
            Grilla.Rows(i).Cells(1).Value = Chequeo
        Next

        Consulta_sql = "UPDATE TmpTablasDeSeleccion SET Seleccion = " & Chequeo & vbCrLf & _
                       "WHERE Tabla = '" & NombreTabla & "'"
        Ej_consulta_IDUaccess(Consulta_sql)

        Grilla.Refresh()
    End Function

    Sub Actualizar_Grilla_Productos_Buscados()

        Consulta_sql = "SELECT KOPR,KOPRTE,NOKOPR FROM MAEPR WHERE KOPRTE LIKE '" & TxtCodigoPro.Text & "%'"


        With GrillProdBuscados

            .DataSource = _SQL.Fx_Get_Tablas(Consulta_sql) ' -- Se asigna la tabla al datagridview

            .Columns("KOPR").HeaderText = "Código"
            .Columns("KOPR").Width = 100

            .Columns("KOPRTE").HeaderText = "Código Téc."
            .Columns("KOPRTE").Width = 150

            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Width = 500

            .Refresh()

        End With

        Consulta_sql = "SELECT KOPR,KOPRTE,NOKOPR FROM MAEPR WHERE KOPR LIKE '" & Mid(TxtCodigoPro.Text, 1, 3) & "%'" & vbCrLf & _
                       "ORDER BY KOPR DESC"


        With GrillaProductosMarca

            .DataSource = _SQL.Fx_Get_Tablas(Consulta_sql) ' -- Se asigna la tabla al datagridview

            .Columns("KOPR").HeaderText = "Código"
            .Columns("KOPR").Width = 100

            .Columns("KOPRTE").HeaderText = "Código Téc."
            .Columns("KOPRTE").Width = 150

            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Width = 500

            .Refresh()

        End With

    End Sub

    Private Sub TxtCodigoPro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoPro.TextChanged
        Actualizar_Grilla_Productos_Buscados()
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub GrillProdBuscados_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles GrillProdBuscados.CellFormatting
        Dim Cll = GrillProdBuscados.Columns(e.ColumnIndex).Name.ToString
        If GrillProdBuscados.Columns(e.ColumnIndex).Name.Equals("KOPRTE") Then
            Dim Codd = (GrillProdBuscados.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
            If Trim(Codd) = Trim(TxtCodigoPro.Text) Then
                GrillProdBuscados.Rows.Item(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
                GrillProdBuscados.Rows.Item(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
            End If
        End If
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub Grilla_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla.KeyDown
        Try
            If e.KeyValue = Keys.Delete Then
                e.Handled = True

                Dim CdClass As String = Convert.ToString(Grilla.Rows(Grilla.CurrentRow.Index).Cells(2).Value)
                Dim NomClass As String = Convert.ToString(Grilla.Rows(Grilla.CurrentRow.Index).Cells(1).Value)

                If CdClass <> "X" And CdClass <> "" Then


                    Dim Cod_NomClass As String = Convert.ToString(Grilla.Rows(Grilla.CurrentRow.Index).Cells(0).Value)

                    If MessageBox.Show("¿Esta seguro de eliminar la línea ", "Eliminar línea", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        'Actualizar_Grilla()

                        With Grilla.Rows.Item(Grilla.CurrentRow.Index).Cells
                            .Item(2).Value = ""
                            .Item(3).Value = ""
                            .Item(6).Value = ""
                        End With

                        Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                                       "Cod_Class = ''," & vbCrLf & _
                                       "Descripcion_Class=''," & vbCrLf & _
                                       "Descripcion_Opcional=''" & vbCrLf & _
                                       "Where Cod_NomClass = '" & Cod_NomClass & "'"
                        Ej_consulta_IDUaccess(Consulta_sql)

                        TxtCodigoPro.Text = CrearCodigoProducto()
                        TxtDescripcionProducto.Text = CrearDetalleProducto()
                        TxtDescripcionWeb.Text = TxtDescripcionProducto.Text
                        'Actualizar_Grilla()
                    End If
                End If

            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnCodAlternativo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCodAlternativo.Click
        Dim Fr As New Frm_CreaProductos_04_CodAlternativo
        Fr.ShowDialog(Me)

    End Sub

    

    Private Function CambiarCodigo(ByVal CodigoNew As String, _
                                   ByVal CodigoOld As String, _
                                   ByVal DescripPro As String, _
                                   ByVal CambiarCodTecnico As Boolean, _
                                   ByVal Cn As SqlClient.SqlConnection) As Boolean

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        CodigoOld = Trim(CodigoOld)

        Try

            SQL_ServerClass.AbrirConexion_SQLServer(Cn)
            myTrans = Cn.BeginTransaction()

            'Dim DescripPro = _Sql.Fx_Trae_Dato(, "NOKOPR", "MAEPR", "KOPR = '" & CodigoNew & "'")

            '"UPDATE MAEPR SET KOPR='" & CodigoNew & "' WHERE KOPR='" & CodigoOld & "'" & vbCrLf & _
            '"UPDATE MAEPR    SET KOGE='" & CodigoNew & "'     WHERE KOGE='" & CodigoOld & "'" & vbCrLf & _

            Consulta_sql = "UPDATE MAEPREM  SET KOPR='" & CodigoNew & "'     WHERE KOPR='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE TABBOPR  SET KOPR='" & CodigoNew & "'     WHERE KOPR='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE TABCODAL SET KOPR='" & CodigoNew & "',  NOKOPRAL = '" & DescripPro & "'    WHERE KOPR='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE TABPRE   SET KOPR='" & CodigoNew & "'     WHERE KOPR='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE MAEST    SET KOPR='" & CodigoNew & "'     WHERE KOPR='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE TABIMPR  SET KOPR='" & CodigoNew & "'     WHERE KOPR='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE MAEELOTE SET KOPR='" & CodigoNew & "'     WHERE KOPR='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE MAELIFO  SET KOPR='" & CodigoNew & "'     WHERE KOPR='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE MAEFICHD SET KOPR='" & CodigoNew & "'     WHERE KOPR='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE TABKOPRE SET ELEMENTO='" & CodigoNew & "' WHERE ELEMENTO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE MAEDDO   SET KOPRCT='" & CodigoNew & "',NOKOPR = '" & DescripPro & "'   WHERE KOPRCT='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE MAEERES  SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE MAEDRES  SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE MAEDRES  SET ELEMENTO='" & CodigoNew & "' WHERE ELEMENTO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE PDIMEN   SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE POTL     SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE PRELA    SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE PDATFAD  SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE PDIMOT   SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE POTD     SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE POTPR    SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE PPLAND   SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE PPLANPR  SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE PPLAPRIO SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE PPLAVST  SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE PNPA     SET ELEMENTO='" & CodigoNew & "' WHERE ELEMENTO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE PNPD     SET ELEMENTO='" & CodigoNew & "' WHERE ELEMENTO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE PINSUPRO SET PRODUCTO='" & CodigoNew & "' WHERE PRODUCTO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE LORESCAD SET KOPR='" & CodigoNew & "' WHERE KOPR='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE POTLCOM  SET CODIGO='" & CodigoNew & "' WHERE CODIGO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE PASPD  SET CODIGO='" & CodigoNew & "' WHERE CODIGO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE PRESERVA SET CODIGO='" & CodigoNew & "' WHERE CODIGO='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE PPROTAR  SET KOPR  ='" & CodigoNew & "' WHERE KOPR  ='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE CACTFI   SET KOPR  ='" & CodigoNew & "' WHERE KOPR  ='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE MAELIFO  SET KOPR  ='" & CodigoNew & "' WHERE KOPR  ='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE MAEPOSST SET KOPR  ='" & CodigoNew & "' WHERE KOPR  ='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE MAEPROBS SET KOPR  ='" & CodigoNew & "' WHERE KOPR  ='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE ELIDDO   SET KOPRCT='" & CodigoNew & "' WHERE KOPRCT='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE KASIDDO  SET KOPRCT='" & CodigoNew & "' WHERE KOPRCT='" & CodigoOld & "'" & vbCrLf & _
                           "UPDATE TABLOTES SET KOPR  ='" & CodigoNew & "' WHERE KOPR  ='" & CodigoOld & "'"

            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()




            Consulta_sql = "INSERT INTO MAEFICHA (KOPR,NOKOPR) VALUES ('" & CodigoNew & "','" & DescripPro & "')" & vbCrLf & _
                           "DELETE MAEPR WHERE KOPR = '" & CodigoOld & "'"

            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Consulta_sql = "INSERT INTO TABCODAL (KOPRAL,KOPR,NOKOPRAL) VALUES ('" & Trim(CodigoOld) & "','" & CodigoNew & "','" & DescripPro & "')"

            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()



            If CambiarCodTecnico = True Then
                Consulta_sql = "UPDATE MAEPR SET KOPRTE='" & CodigoNew & "'   WHERE KOPRTE='" & CodigoOld & "'"
                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()
            End If

            myTrans.Commit()
            SQL_ServerClass.CerrarConexion(Cn)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            myTrans.Rollback()
            MsgBox("Transaccion desecha")
            SQL_ServerClass.CerrarConexion(Cn)
            Return False
        End Try

    End Function



    Private Function GetRadioButtons() As Command()
        Return New Command() {RdC2V1, RdC1V2}
    End Function

    

    


    Sub CambiatelaDescricion(ByVal Cambiar As Boolean)

        BtnCodAlternativo.Enabled = Cambiar
        BtnCambiarCodigo.Enabled = Cambiar

    End Sub


    Function CambioDescr(ByVal CambiarDescripcion As Boolean) As Boolean

        If CambiarDescripcion = True Then
            CambiatelaDescricion(False)
            Return True
        Else
            CambiatelaDescricion(True)
            Me.Text = "Asistente de Creación de productos"
            Limpiar()
            Return False
        End If

    End Function


    Private Sub SwCambiarCod_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SwCambiarCod.ValueChanged

        If CambioDescr(SwCambiarCod.Value) Then

            Dim Fm As New Frm_BuscarXProducto_Mt
            Fm.BtnBusAlternativas.Visible = True
            'Frm_BuscaPR
            Fm.ShowDialog(Me)
            CodigoMTS = ""
            CodigoRandom = Codigo_abuscar
            CodigoCambioDescripcion = Codigo_abuscar

            If CodigoCambioDescripcion = "" Then
                SwCambiarCod.Value = False
                CambioDescr(SwCambiarCod.Value)
                Exit Sub
            End If

            Dim CodTecnico = _Sql.Fx_Trae_Dato(, "KOPRTE", "MAEPR", "KOPR = '" & Codigo_abuscar & "'")
            Dim DescripcionPro = _Sql.Fx_Trae_Dato(, "NOKOPR", "MAEPR", "KOPR = '" & Codigo_abuscar & "'")
            Me.Text = "Cambiando descripción del producto: " & Trim(CodigoCambioDescripcion) & "," & DescripcionPro

            Dim Marca, Articulo As String

            Marca = Mid(CodTecnico, 1, 3)
            Dim De1Cl = _Sql.Fx_Trae_Dato(, "DescripcionTabla", "Zw_TablaDeCaracterizaciones", _
                                  "Tabla = 'MARCAS' AND CodigoTabla = '" & Marca & "'")

            Dim De2Cl = _Sql.Fx_Trae_Dato(, "NombreTabla", "Zw_TablaDeCaracterizaciones", _
                                  "Tabla = 'MARCAS' AND CodigoTabla = '" & Marca & "'")

            Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                          "Cod_Class = '" & Marca & "'," & vbCrLf & _
                          "Descripcion_Class='" & De1Cl & "'," & vbCrLf & _
                          "Descripcion_Opcional='" & De2Cl & "'" & vbCrLf & _
                          "Where Cod_NomClass = '01'"
            Ej_consulta_IDUaccess(Consulta_sql)

            Dim NewCdTtec = CodTecnico 'Replace(CodTecnico, "X", "XXXX")

            Articulo = Mid(CodTecnico, 4, 4)
            Dim ArticuloCd = Articulo
            Dim MarcaCd = Marca

            Dim ColorCd = Mid(NewCdTtec, 8, 4)
            Dim MedidaCd = Mid(NewCdTtec, 12, 4)
            Dim ModeloCd = Mid(NewCdTtec, 16, 4)



            De1Cl = _Sql.Fx_Trae_Dato(, "DescripcionTabla", "Zw_TablaDeCaracterizaciones", _
                                  "Tabla = 'ARTICULO' AND CodigoTabla = '" & Articulo & "'")

            De2Cl = _Sql.Fx_Trae_Dato(, "NombreTabla", "Zw_TablaDeCaracterizaciones", _
                                  "Tabla = 'ARTICULO' AND CodigoTabla = '" & Articulo & "'")

            Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                          "Cod_Class = '" & Articulo & "'," & vbCrLf & _
                          "Descripcion_Class='" & De1Cl & "'," & vbCrLf & _
                          "Descripcion_Opcional='" & De2Cl & "'" & vbCrLf & _
                          "Where Cod_NomClass = '02'"
            Ej_consulta_IDUaccess(Consulta_sql)


            Consulta_sql = "DELETE * FROM Tmp_MatrizCreacionCodigos_Aplica"
            Ej_consulta_IDUaccess(Consulta_sql)


            Dim Color = _Sql.Fx_Trae_Dato(, "ApColor", "Zw_TablaDeCaracterizaciones", _
                                  "Tabla = 'ARTICULO' And CodigoTabla = '" & Articulo & "'")
            Dim Modelo = _Sql.Fx_Trae_Dato(, "ApModelo", "Zw_TablaDeCaracterizaciones", _
                                  "Tabla = 'ARTICULO' And CodigoTabla = '" & Articulo & "'")
            Dim Medida = _Sql.Fx_Trae_Dato(, "ApMedida", "Zw_TablaDeCaracterizaciones", _
                                  "Tabla = 'ARTICULO' And CodigoTabla = '" & Articulo & "'")

            Consulta_sql = "INSERT INTO Tmp_MatrizCreacionCodigos_Aplica (Codigo,COLOR,MEDIDA,MODELO) VALUES " & vbCrLf & _
                           "('CodClass'," & Color & "," & Medida & "," & Modelo & ")"
            Ej_consulta_IDUaccess(Consulta_sql)

            If Color = True Then


                De1Cl = _Sql.Fx_Trae_Dato(, "DescripcionTabla", "Zw_TablaDeCaracterizaciones", _
                                  "Tabla = 'COLOR' AND CodigoTabla = '" & ColorCd & "'")

                De2Cl = _Sql.Fx_Trae_Dato(, "NombreTabla", "Zw_TablaDeCaracterizaciones", _
                                   "Tabla = 'COLOR' AND CodigoTabla = '" & ColorCd & "'")



                Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                               "Cod_Class = '" & ColorCd & "'," & vbCrLf & _
                               "Descripcion_Class='" & De1Cl & "'," & vbCrLf & _
                               "Descripcion_Opcional='" & De2Cl & "'" & vbCrLf & _
                               "Where Nom_Class = 'COLOR'"
            Else
                Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                               "Cod_Class = 'XXXX'," & vbCrLf & _
                               "Descripcion_Class=''," & vbCrLf & _
                               "Descripcion_Opcional=''" & vbCrLf & _
                               "Where Nom_Class = 'COLOR'"
            End If
            Ej_consulta_IDUaccess(Consulta_sql)

            If Modelo = True Then



                De1Cl = _Sql.Fx_Trae_Dato(, "DescripcionTabla", "Zw_TablaDeCaracterizaciones", _
                                  "Tabla = 'MODELO' AND CodigoTabla = '" & ModeloCd & "'")

                De2Cl = _Sql.Fx_Trae_Dato(, "NombreTabla", "Zw_TablaDeCaracterizaciones", _
                                   "Tabla = 'MODELO' AND CodigoTabla = '" & ModeloCd & "'")

                Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                               "Cod_Class = '" & ModeloCd & "'," & vbCrLf & _
                               "Descripcion_Class='" & De1Cl & "'," & vbCrLf & _
                               "Descripcion_Opcional='" & De2Cl & "'" & vbCrLf & _
                               "Where Nom_Class = 'MODELO'"
            Else
                Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                               "Cod_Class = 'XXXX'," & vbCrLf & _
                               "Descripcion_Class=''," & vbCrLf & _
                               "Descripcion_Opcional=''" & vbCrLf & _
                               "Where Nom_Class = 'MODELO'"
            End If
            Ej_consulta_IDUaccess(Consulta_sql)

            If Medida = True Then


                De1Cl = _Sql.Fx_Trae_Dato(, "DescripcionTabla", "Zw_TablaDeCaracterizaciones", _
                                 "Tabla = 'MEDIDA' AND CodigoTabla = '" & MedidaCd & "'")

                De2Cl = _Sql.Fx_Trae_Dato(, "NombreTabla", "Zw_TablaDeCaracterizaciones", _
                                   "Tabla = 'MEDIDA' AND CodigoTabla = '" & MedidaCd & "'")

                Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                               "Cod_Class = '" & MedidaCd & "'," & vbCrLf & _
                               "Descripcion_Class='" & De1Cl & "'," & vbCrLf & _
                               "Descripcion_Opcional='" & De2Cl & "'" & vbCrLf & _
                               "Where Nom_Class = 'MEDIDA'"


            Else
                Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                               "Cod_Class = 'XXXX'," & vbCrLf & _
                               "Descripcion_Class=''," & vbCrLf & _
                               "Descripcion_Opcional=''" & vbCrLf & _
                               "Where Nom_Class = 'MEDIDA'"
            End If
            Ej_consulta_IDUaccess(Consulta_sql)


            Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                               "Cod_Class = 'XXXX'," & vbCrLf & _
                               "Descripcion_Class=''," & vbCrLf & _
                               "Descripcion_Opcional=''" & vbCrLf & _
                               "Where Nom_Class = 'CQ_FABRICA'"

            Ej_consulta_IDUaccess(Consulta_sql)




            TxtCodigoPro.Text = CrearCodigoProducto()
            TxtDescripcionProducto.Text = CrearDetalleProducto()
            TxtDescripcionWeb.Text = TxtDescripcionProducto.Text

            Actualizar_Grilla()

        End If
    End Sub

   
    Private Sub BtnRTUclas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRTUclas.Click

        Dim Nro = "Prod005"
        If TienePermiso(Nro) Then
            Dim Frm_MatRTU_01 As New Frm_MatRTU_01
            Frm_MatRTU_01.ShowDialog(Me)

            caract_combo(Cmbunidad1)
            Consulta_sql = "SELECT CodigoTabla AS Padre,CodigoTabla AS Hijo FROM Zw_TablaDeCaracterizaciones WHERE Tabla = 'RTU' ORDER BY Orden"
            Cmbunidad1.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)

            caract_combo(Cmbunidad2)
            Consulta_sql = "SELECT CodigoTabla AS Padre,CodigoTabla AS Hijo FROM Zw_TablaDeCaracterizaciones WHERE Tabla = 'RTU' ORDER BY Orden"
            Cmbunidad2.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)


        Else
            MensajeSinPermiso(Nro)
        End If

    End Sub

    Private Sub BtnCambiarCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCambiarCodigo.Click
        Dim Nro As String = "Prod006"
        If TienePermiso(Nro) Then
            Dim Frm_UnificacionProducto As New Frm_UnificacionProducto
            Frm_UnificacionProducto.ShowInTaskbar = False
            Frm_UnificacionProducto.ShowDialog(Me)
        Else
            MensajeSinPermiso(Nro)
        End If
    End Sub

    Private Sub GrillProdBuscados_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillProdBuscados.CellContentClick

    End Sub
End Class













