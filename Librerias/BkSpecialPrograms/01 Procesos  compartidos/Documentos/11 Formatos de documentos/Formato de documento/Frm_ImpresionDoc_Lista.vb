Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_ImpresionDoc_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _dv As New DataView

    Enum Enum_Tipo_Formato
        Documentos
        Cheques
    End Enum

    Dim _Tipo_Formato As Enum_Tipo_Formato

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Buscar_Formato.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_ImpresionDoc_Lista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla.MouseDown, AddressOf Grilla_MouseDown
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Me.ActiveControl = Txt_Buscar_Formato

    End Sub

    Sub Sb_Actualizar_Grilla()

        'Insertamos un tipo de documento comprobante de pago, si existe no lo crea
        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Format_01 (TipoDoc,NombreFormato,Cod_Pagina,LargoDoc," &
                       "AnchoDoc,NroLineasXpag,Fila_InicioDetalle,Fila_FinDetalle,Col_InicioDetalle,Col_FinDetalle,Emdp)" & vbCrLf &
                       "Values('CPG','Comprobante de pago ','CARTA',27.94,21.59,20,300,900,1,600,'zzz')"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        'Insertamos un tipo de documento solicitud de productos a bodega, si existe no lo crea
        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Format_01 (TipoDoc,NombreFormato,Cod_Pagina,LargoDoc," &
                       "AnchoDoc,NroLineasXpag,Fila_InicioDetalle,Fila_FinDetalle,Col_InicioDetalle,Col_FinDetalle,Emdp)" & vbCrLf &
                       "Values('SPB','X Defecto','CARTA',27.94,21.59,20,300,900,1,600,'')"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        'Insertamos un tipo de documento GDD-PRE, si existe no lo crea
        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Format_01 (TipoDoc,Subtido,NombreFormato,Cod_Pagina,LargoDoc," &
                       "AnchoDoc,NroLineasXpag,Fila_InicioDetalle,Fila_FinDetalle,Col_InicioDetalle,Col_FinDetalle,Emdp)" & vbCrLf &
                       "Values('GDD','PRE','X Defecto','CARTA',27.94,21.59,20,300,900,1,600,'')"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        'Insertamos un tipo de documento GDD-CON, si existe no lo crea
        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Format_01 (TipoDoc,Subtido,NombreFormato,Cod_Pagina,LargoDoc," &
                       "AnchoDoc,NroLineasXpag,Fila_InicioDetalle,Fila_FinDetalle,Col_InicioDetalle,Col_FinDetalle,Emdp)" & vbCrLf &
                       "Values('GDD','CON','X Defecto','CARTA',27.94,21.59,20,300,900,1,600,'')"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Format_01 (TipoDoc,NombreFormato,Cod_Pagina,LargoDoc,AnchoDoc,NroLineasXpag," &
                       "Fila_InicioDetalle, Fila_FinDetalle, Col_InicioDetalle, Col_FinDetalle)" & vbCrLf &
                       "Select TIDO,'X Defecto','CARTA',27.94,21.59,20,300,900,1,600 From TABTIDO" & vbCrLf &
                       "Where TIDO not in (Select TipoDoc From " & _Global_BaseBk & "Zw_Format_01)" &
                       vbCrLf &
                       vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_Format_01 (TipoDoc,NombreFormato,Cod_Pagina,LargoDoc,AnchoDoc,NroLineasXpag," &
                       "Fila_InicioDetalle, Fila_FinDetalle, Col_InicioDetalle, Col_FinDetalle,Emdp)" & vbCrLf &
                       "Select 'CHC','Cta.Cte: '+CTACTE,'CARTA',27.94,21.59,20,300,900,1,600,KOENDP From TABENDP" & vbCrLf &
                       "Where KOENDP not in (Select Emdp From " & _Global_BaseBk & "Zw_Format_01 Where TipoDoc = 'CHC')" & vbCrLf &
                       "And CTACTE <> '' AND TIDPEN = 'CH' And EMPRESA = '" & ModEmpresa & "'" &
                       vbCrLf &
                       vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_Format_01 (TipoDoc,NombreFormato,Cod_Pagina,LargoDoc,AnchoDoc,NroLineasXpag," &
                       "Fila_InicioDetalle, Fila_FinDetalle, Col_InicioDetalle, Col_FinDetalle,Emdp)" & vbCrLf &
                       "Select 'TJV',LTRIM(RTRIM(KOENDP))+'-'+LTRIM(RTRIM(NOKOENDP)),'CARTA',10,7.5,2,8,2,1,6,KOENDP From TABENDP" & vbCrLf &
                       "Where KOENDP not in (Select Emdp From " & _Global_BaseBk & "Zw_Format_01 Where TipoDoc = 'TJV')" & vbCrLf &
                       "And TIDPEN = 'TJ' And EMPRESA = '" & ModEmpresa & "'" &
                       vbCrLf &
                       vbCrLf &
                       "Select TipoDoc,Subtido,Cast(Case" & vbCrLf &
                       "When TipoDoc IN ('SOC','SOL') Then 'SOLICITUD DE COMPRA'" & vbCrLf &
                       "When TipoDoc = 'CHC' Then 'CHEQUE '+(SELECT Top 1 NOKOENDP FROM TABENDP WHERE KOENDP = Emdp)" & vbCrLf &
                       "When TipoDoc = 'TJV' Then 'TARJETA DEBITO/CREDITO'" & vbCrLf &
                       "When TipoDoc = 'VAL' Then 'VALE DESPACHO'" & vbCrLf &
                       "When TipoDoc = 'DIR' Then 'DIRECCION DESPACHO'" & vbCrLf &
                       "When TipoDoc = 'CPG' Then 'COMPROBANTE DE PAGO'" & vbCrLf &
                       "When TipoDoc = 'SPB' Then 'SOL. PRODUCTOS A BODEGA'" & vbCrLf &
                       "Else Isnull((Select Top 1 Ltrim(Rtrim(NOTIDO)) From TABTIDO Where TIDO = TipoDoc),'')" & vbCrLf &
                       "End As Varchar(200)) As 'NombreDocumento',NombreFormato,LargoDoc,AnchoDoc,Largo_Variable,Doc_Electronico,Emdp" & vbCrLf &
                       "Into #Paso_Fx" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                       "Order by Emdp,TipoDoc,Subtido,NombreFormato" & vbCrLf &
                       "Update #Paso_Fx Set NombreDocumento = NombreDocumento+' CONSIGNACION' Where TipoDoc = 'GDD' And Subtido = 'CON'
                        Update #Paso_Fx Set NombreDocumento = NombreDocumento+' PRESTAMO' Where TipoDoc = 'GDD' And Subtido = 'PRE'
                        Select * From #Paso_Fx
                        Drop Table #Paso_Fx"

        Dim _Ds As New DataSet
        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

        _dv.Table = _Ds.Tables(0)

        With Grilla

            .DataSource = _dv

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("TipoDoc").Visible = True
            .Columns("TipoDoc").Width = 35
            .Columns("TipoDoc").HeaderText = "Tipo"
            .Columns("TipoDoc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Subtido").Visible = True
            .Columns("Subtido").Width = 35
            .Columns("Subtido").HeaderText = "Sub TD"
            .Columns("Subtido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreDocumento").Visible = True
            .Columns("NombreDocumento").Width = 150
            .Columns("NombreDocumento").HeaderText = "Documento"
            .Columns("NombreDocumento").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreFormato").Visible = True
            .Columns("NombreFormato").Width = 280
            .Columns("NombreFormato").HeaderText = "Nombre formato"
            .Columns("NombreFormato").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Largo_Variable").Visible = True
            .Columns("Largo_Variable").Width = 50
            .Columns("Largo_Variable").HeaderText = "Largo Variable"
            .Columns("Largo_Variable").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Doc_Electronico").Visible = True
            .Columns("Doc_Electronico").Width = 70
            .Columns("Doc_Electronico").HeaderText = "Electrónico"
            .Columns("Doc_Electronico").ReadOnly = False
            .Columns("Doc_Electronico").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        _dv.RowFilter = String.Format("TipoDoc+NombreDocumento+NombreFormato Like '%{0}%'", Txt_Buscar_Formato.Text)

    End Sub

    Sub Sb_Llena_Combo_Tipo_Entidad()

        'caract_combo(CmbxTipoEntidad)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))
        ',,,,,,

        dr = dt.NewRow() : dr("Padre") = "C" : dr("Hijo") = "Cliente" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "P" : dr("Hijo") = "Proveedor" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "A" : dr("Hijo") = "Ambos" : dt.Rows.Add(dr)
        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        'With CmbxTipoEntidad
        '.DataSource = Nothing
        '.DataSource = dt
        'End With

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "NombreDocumento" Or _Cabeza = "TipoDoc" Then
            Sb_Configurar_Formato()
        Else
            Sb_Revisar_Fila()
        End If

    End Sub

    Private Sub Btn_NuevoFormato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim Fm As New Frm_Diseno_Doc_y_Ubic

        Fm.Pro_Nuevo_Formato = True
        Fm.Pro_TipoDoc = "DIR"
        Fm.Pro_NombreFormato = String.Empty
        Fm.ShowDialog(Me)

    End Sub



    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Frm_ImpresionDoc_Lista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Txt_Buscar_Formato_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Buscar_Formato.TextChanged
        _dv.RowFilter = String.Format("TipoDoc+NombreDocumento+NombreFormato Like '%{0}%'", Txt_Buscar_Formato.Text)
    End Sub

    Private Sub Btn_Crear_Funciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Funciones.Click
        ShowContextMenu(Menu_Contextual_Opciones_Crear_Funciones)
    End Sub

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Sb_Revisar_Fila()

                End If
            End With
        End If
    End Sub

    Sub Sb_Revisar_Fila()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _TipoDoc As String = _Fila.Cells("TipoDoc").Value
        Dim _NombreFormato As String = _Fila.Cells("NombreFormato").Value

        Dim _LargoDoc = _Fila.Cells("LargoDoc").Value
        Dim _AnchoDoc = _Fila.Cells("AnchoDoc").Value

        Btn_Tamano.Text = "Tamaño de hoja (Ancho = " & _AnchoDoc & " Cm - Alto = " & _LargoDoc & " Cm)"

        If _TipoDoc = "CHC" Or _TipoDoc = "CPG" Then
            Btn_Copiar_Formato.Enabled = False
            Btn_Eliminar_Formato.Enabled = False
        Else
            Btn_Copiar_Formato.Enabled = True
            Btn_Eliminar_Formato.Enabled = True
        End If

        ShowContextMenu(Menu_Contextual_Opciones_Formato)

    End Sub

    Private Sub Btn_Copiar_Formato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Copiar_Formato.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _TipoDoc = _Fila.Cells("TipoDoc").Value
        Dim _Subtido = _Fila.Cells("Subtido").Value
        Dim _NombreFormato = _Fila.Cells("NombreFormato").Value

        Dim Fm As New Frm_Formato_Diseno_Copiar_Formato(_TipoDoc, _NombreFormato, _Subtido)
        Fm.ShowDialog(Me)

        If Fm.Pro_Grabar Then
            Sb_Actualizar_Grilla()
        End If

        Fm.Dispose()

    End Sub

    Private Sub Btn_Configurar_Formato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Configurar_Formato.Click
        Sb_Configurar_Formato()
    End Sub

    Sub Sb_Configurar_Formato()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _TipoDoc As String = Trim(_Fila.Cells("TipoDoc").Value)
        Dim _NombreFormato As String = Trim(_Fila.Cells("NombreFormato").Value)
        Dim _Emdp As String = Trim(_Fila.Cells("Emdp").Value)
        Dim _Subtido As String = Trim(_Fila.Cells("Subtido").Value)

        Dim Fm As New Frm_ImpresionDoc_Configuracion(_TipoDoc, _NombreFormato, _Emdp, _Subtido)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Actualizar_Grilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar_Grilla.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_Tamano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Tamano.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _TipoDoc As String = _Fila.Cells("TipoDoc").Value
        Dim _NombreFormato As String = _Fila.Cells("NombreFormato").Value
        Dim _Emdp As String = _Fila.Cells("Emdp").Value

        Dim _LargoDoc = _Fila.Cells("LargoDoc").Value
        Dim _AnchoDoc = _Fila.Cells("AnchoDoc").Value

        Dim Fm As New Frm_Formato_Diseno_Editar_Posicion(99, 99, Me)
        Fm.Pro_Tamano_Hoja = True
        Fm.Pro_Alto_Y = _LargoDoc
        Fm.Pro_Ancho_X = _AnchoDoc

        Fm.ShowDialog(Me)

        _LargoDoc = Fm.Pro_Alto_Y
        _AnchoDoc = Fm.Pro_Ancho_X

        If Fm.Pro_Aceptar Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Format_01 Set LargoDoc = " & De_Num_a_Tx_01(_LargoDoc, False, 2) &
                           ",AnchoDoc = " & De_Num_a_Tx_01(_AnchoDoc, False, 2) & vbCrLf &
                           "Where" & Space(1) &
                           "TipoDoc = '" & _TipoDoc & "' And NombreFormato = '" & _NombreFormato & "' And Emdp = '" & _Emdp & "'"

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                _Fila.Cells("LargoDoc").Value = Fm.Pro_Alto_Y
                _Fila.Cells("AnchoDoc").Value = Fm.Pro_Ancho_X

                MessageBoxEx.Show(Me, "Tamaño de la hoja actualizado correctamente", "Tamaño hoja",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

        Fm.Dispose()

    End Sub


    Private Sub Grilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _TipoDoc As String = _Fila.Cells("TipoDoc").Value
        Dim _NombreFormato As String = _Fila.Cells("NombreFormato").Value
        Dim _Doc_Electronico = _Fila.Cells("Doc_Electronico").Value  'CInt(Chk_Doc_Electronico.Checked) * -1

        If _Cabeza = "Doc_Electronico" Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Format_01 Set Doc_Electronico = " & CInt(_Doc_Electronico) * -1 & vbCrLf &
                           "Where TipoDoc = '" & _TipoDoc & "' and NombreFormato = '" & _NombreFormato & "'"

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                If _Doc_Electronico Then
                    MessageBoxEx.Show(Me, "Se seleccionó documento como electrónico" & vbCrLf &
                                          "Esto hará que salgan 2 copias al momento de imprimir" & vbCrLf &
                                          "Recuerde incorporar la función [Texto CEDIBLE]", "Documento Electrónico",
                                          MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            End If

        End If

    End Sub

    Private Sub Grilla_CellMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Grilla_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < sender.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If sender.RowHeadersWidth < CInt(size.Width + 20) Then
                sender.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net",
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Grilla_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles Grilla.CellBeginEdit

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _TipoDoc As String = _Fila.Cells("TipoDoc").Value
        Dim _NombreFormato As String = _Fila.Cells("NombreFormato").Value
        Dim _Emdp As String = _Fila.Cells("Emdp").Value

        If _Cabeza = "Doc_Electronico" Then
            If _TipoDoc = "CHC" Or _TipoDoc = "CPG" Then
                Beep()
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Btn_Eliminar_Formato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar_Formato.Click
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _TipoDoc As String = _Fila.Cells("TipoDoc").Value
        Dim _NombreFormato As String = _Fila.Cells("NombreFormato").Value

        Dim _Sql_Eliminar_Format_01 = "Delete " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                                      "Where TipoDoc = '" & _TipoDoc & "' and NombreFormato = '" & _NombreFormato & "'" & vbCrLf

        If _NombreFormato = "X Defecto" Then

            _Sql_Eliminar_Format_01 = String.Empty

        End If

        If MessageBoxEx.Show(Me, "¿Está seguro de eliminar este formato?", "Eliminar formato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Consulta_sql = _Sql_Eliminar_Format_01 &
                           "Delete " & _Global_BaseBk & "Zw_Format_02" & vbCrLf &
                           "Where TipoDoc = '" & _TipoDoc & "' and NombreFormato = '" & _NombreFormato & "'"

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                Sb_Actualizar_Grilla()
            End If
        End If
    End Sub

    Private Sub Btn_Crear_Funcion_Documentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Funcion_Documentos.Click
        Dim Fm As New Frm_Formato_Sel_Funciones(Frm_Formato_Sel_Funciones._Enum_Seccion.Encabezado, "edit", Frm_Formato_Sel_Funciones._Enum_Accion.Editar)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Crear_Funcion_Cheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Funcion_Cheques.Click
        Dim Fm As New Frm_Formato_Sel_Funciones(Frm_Formato_Sel_Funciones._Enum_Seccion.Encabezado, "CHC", Frm_Formato_Sel_Funciones._Enum_Accion.Editar)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Imprimir_Regleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir_Regleta.Click
        Dim _Imprimir As New Clas_Imprimir_Documento(0, "", "Regleta", "Regleta", False, "", "")
        With _Imprimir
            .Fx_Imprimir_Regleta()
        End With
    End Sub

    Private Sub Btn_Crear_Funciones_Sol_Prod_Bodega_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Funciones_Sol_Prod_Bodega.Click
        Dim Fm As New Frm_Formato_Sel_Funciones(Frm_Formato_Sel_Funciones._Enum_Seccion.Encabezado, "SPB", Frm_Formato_Sel_Funciones._Enum_Accion.Editar)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

End Class
