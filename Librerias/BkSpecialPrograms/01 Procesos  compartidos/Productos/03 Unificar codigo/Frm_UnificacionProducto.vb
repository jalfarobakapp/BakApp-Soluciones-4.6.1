Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc
Imports System.Data.SqlClient

Public Class Frm_UnificacionProducto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim Dts_Unificados As New Dt_UnifCod
    Dim _TIPR_Prod_Destino As String
    Dim _Cancelar_LevMasivo As Boolean

#Region "FUNCIONES"

    Sub BuscarProductos(ByVal Codigo As String,
                        ByVal TxtCodigo As TextBox,
                        ByVal TxtDescripcion As TextBox,
                        ByVal TxtRtu As TextBox,
                        ByVal TxtUd1 As TextBox,
                        ByVal TxtUd2 As TextBox,
                        ByVal _Tbl_InfProducto As DataTable)

        If Not _Tbl_InfProducto Is Nothing Then
            If CBool(_Tbl_InfProducto.Rows.Count) Then
                If Codigo <> "" Then
                    TxtCodigo.Text = _Tbl_InfProducto.Rows(0).Item("KOPR")
                    TxtRtu.Text = _Tbl_InfProducto.Rows(0).Item("RLUD")
                    TxtDescripcion.Text = _Tbl_InfProducto.Rows(0).Item("NOKOPR")
                    TxtUd1.Text = _Tbl_InfProducto.Rows(0).Item("UD01PR")
                    TxtUd2.Text = _Tbl_InfProducto.Rows(0).Item("UD02PR")
                    _TIPR_Prod_Destino = _Tbl_InfProducto.Rows(0).Item("TIPR")
                End If
            End If
        End If
    End Sub

    Public Function RevisarProducto(ByVal Codigo As String) As Boolean

        If _Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & Codigo & "'") > 0 Then
            TxtCodigoDestino.Text = Codigo
            TxtRtuDestino.Text = _Sql.Fx_Trae_Dato("MAEPR", "RLUD", "KOPR = '" & Codigo & "'")
            TxtDescripcionDestino.Text = _Sql.Fx_Trae_Dato("MAEPR", "NOKOPR", "KOPR = '" & Codigo & "'")
            Return True
        Else
            Return False
        End If

    End Function

    Private Function CambiarCodigo(ByVal CodigoNew As String,
                                   ByVal DescripcionNew As String,
                                   ByVal CodigoOld As String,
                                   ByVal DescripcionOld As String,
                                   ByVal RtuOld As String,
                                   ByVal Ud01Old As String,
                                   ByVal Ud02Old As String,
                                   ByVal Responzable As String,
                                   ByVal CambiarCodTecnico As Boolean,
                                   Optional ByVal Cambiar_la_Descripcion_original As Boolean = True) As Boolean

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        CodigoOld = Trim(CodigoOld)

        If Cambiar_la_Descripcion_original Then
            DescripcionNew = Trim(DescripcionOld)
        End If

        Dim Cn As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        Try

            SQL_ServerClass.Sb_Abrir_Conexion(Cn)
            myTrans = Cn.BeginTransaction()

            Consulta_Sql = "INSERT INTO " & _Global_BaseBk & "Zw_UnificadosHitory (CodNew, CodOld, DescripcionOld, Ud1Old, Ud2Old, RtuOld, Responzable,Fecha) VALUES " & vbCrLf &
                           "('" & CodigoNew & "','" & CodigoOld & "','" & DescripcionOld & "','" & Ud01Old &
                           "','" & Ud02Old & "'," & RtuOld & ",'" & Responzable & "',GetDate())"

            Comando = New SqlClient.SqlCommand(Consulta_Sql, Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            '"UPDATE MAEST    SET KOPR='" & CodigoNew & "'     WHERE KOPR='" & CodigoOld & "'" & vbCrLf & _

            Consulta_Sql = "DELETE TABPRE   WHERE KOPR = '" & CodigoNew & "'" & vbCrLf &
                           "DELETE TABBOPR  WHERE KOPR = '" & CodigoNew & "'" & vbCrLf &
                           "DELETE MAEFICHA WHERE KOPR = '" & CodigoOld & "'" & vbCrLf &
                           "DELETE MAEPREM  WHERE KOPR = '" & CodigoNew & "'" & vbCrLf &
                           "DELETE PDIMEN   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf &
                           "DELETE MAEPROBS WHERE KOPR='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE MAEPREM  SET KOPR='" & CodigoNew & "'     WHERE KOPR='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE TABBOPR  SET KOPR='" & CodigoNew & "'     WHERE KOPR='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE TABCODAL SET KOPR='" & CodigoNew & "',  NOKOPRAL = '" & DescripcionNew & "'    WHERE KOPR='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE TABPRE   SET KOPR='" & CodigoNew & "'     WHERE KOPR='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE TABIMPR  SET KOPR='" & CodigoNew & "'     WHERE KOPR='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE MAEELOTE SET KOPR='" & CodigoNew & "'     WHERE KOPR='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE MAELIFO  SET KOPR='" & CodigoNew & "'     WHERE KOPR='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE MAEFICHD SET KOPR='" & CodigoNew & "'     WHERE KOPR='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE TABKOPRE SET ELEMENTO='" & CodigoNew & "' WHERE ELEMENTO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE MAEDDO   SET KOPRCT='" & CodigoNew & "',NOKOPR = '" & DescripcionNew & "'   WHERE KOPRCT='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE MAEERES  SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE MAEDRES  SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE MAEDRES  SET ELEMENTO='" & CodigoNew & "' WHERE ELEMENTO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE POTL     SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE PRELA    SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE PDATFAD  SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE PDIMOT   SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE POTD     SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE POTPR    SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE PPLAND   SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE PPLANPR  SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE PPLAPRIO SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE PPLAVST  SET CODIGO='" & CodigoNew & "'   WHERE CODIGO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE PNPA     SET ELEMENTO='" & CodigoNew & "' WHERE ELEMENTO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE PNPD     SET ELEMENTO='" & CodigoNew & "' WHERE ELEMENTO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE PINSUPRO SET PRODUCTO='" & CodigoNew & "' WHERE PRODUCTO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE LORESCAD SET KOPR='" & CodigoNew & "' WHERE KOPR='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE POTLCOM  SET CODIGO='" & CodigoNew & "' WHERE CODIGO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE PASPD  SET CODIGO='" & CodigoNew & "' WHERE CODIGO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE PRESERVA SET CODIGO='" & CodigoNew & "' WHERE CODIGO='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE PPROTAR  SET KOPR  ='" & CodigoNew & "' WHERE KOPR  ='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE CACTFI   SET KOPR  ='" & CodigoNew & "' WHERE KOPR  ='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE MAELIFO  SET KOPR  ='" & CodigoNew & "' WHERE KOPR  ='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE MAEPOSST SET KOPR  ='" & CodigoNew & "' WHERE KOPR  ='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE ELIDDO   SET KOPRCT='" & CodigoNew & "' WHERE KOPRCT='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE KASIDDO  SET KOPRCT='" & CodigoNew & "' WHERE KOPRCT='" & CodigoOld & "'" & vbCrLf &
                           "UPDATE TABLOTES SET KOPR  ='" & CodigoNew & "' WHERE KOPR  ='" & CodigoOld & "'" & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Prod_Asociacion Set DescripcionBusqueda = '" & CodigoNew & "'+' '+" &
                           "(Select Top 1 NOKOPR From MAEPR Where KOPR = '" & CodigoOld & "')" & vbCrLf &
                           "Where Codigo = '" & CodigoOld & "' And Producto = 1"

            Comando = New SqlClient.SqlCommand(Consulta_Sql, Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            'Consulta_sql = "INSERT INTO MAEFICHA (KOPR,NOKOPR) VALUES ('" & CodigoNew & "','" & DescripcionNew & "')" & vbCrLf & _
            '               "DELETE MAEPR WHERE KOPR = '" & CodigoOld & "'"

            Consulta_Sql = "DELETE MAEPR WHERE KOPR = '" & CodigoOld & "'"

            Comando = New SqlClient.SqlCommand(Consulta_Sql, Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            If _Cancelar_LevMasivo Then
                Consulta_Sql = "INSERT INTO TABCODAL (KOPRAL,KOPR,NOKOPRAL) VALUES ('" & Trim(CodigoOld) & "','" & CodigoNew & "','" & DescripcionNew & "')"

                Comando = New SqlClient.SqlCommand(Consulta_Sql, Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()
            End If

            If CambiarCodTecnico = True Then
                Consulta_Sql = "UPDATE MAEPR SET KOPRTE='" & CodigoNew & "'   WHERE KOPRTE='" & CodigoOld & "'"
                Comando = New SqlClient.SqlCommand(Consulta_Sql, Cn)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()
            End If

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn)
            Return True
        Catch ex As Exception
            myTrans.Rollback()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn)
            If CambiarCodTecnico Then
                MsgBox(ex.Message)
                MsgBox("Transaccion desecha")
            End If
            Return False
        End Try

    End Function

    Sub CargarGrilla()

        Dts_Unificados.Clear()
        GrillaProductosCambiar.DataSource = Nothing


        With GrillaProductosCambiar



            .DataSource = Dts_Unificados '.Tables("TotalesDocumento")
            .DataMember = Dts_Unificados.Tables("Tmp_UnificadosHitory").TableName

            OcultarEncabezadoGrilla(GrillaProductosCambiar, False)

            .Columns("CodOld").HeaderText = "Código"
            .Columns("CodOld").Width = 100
            .Columns("CodOld").Visible = True

            .Columns("DescripcionOld").HeaderText = "Descripción"
            .Columns("DescripcionOld").Width = 320
            .Columns("DescripcionOld").Visible = True

            .Columns("Ud1Old").HeaderText = "UD1"
            .Columns("Ud1Old").Width = 60
            .Columns("Ud1Old").Visible = True

            .Columns("Ud2Old").HeaderText = "UD2"
            .Columns("Ud2Old").Width = 60
            .Columns("Ud2Old").Visible = True

            .Columns("RtuOld").HeaderText = "R.T.U."
            .Columns("RtuOld").Width = 60
            .Columns("RtuOld").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RtuOld").Visible = True

            .Columns("Unificado").HeaderText = "Unificado"
            .Columns("Unificado").Width = 80
            .Columns("Unificado").Visible = True

        End With


    End Sub

    Sub LimpiarTxt()

        TxtCodigoDestino.Text = String.Empty
        TxtDescripcionDestino.Text = String.Empty
        TxtRtuDestino.Text = String.Empty
        TxtUd1Destino.Text = String.Empty
        TxtUd2Destino.Text = String.Empty

    End Sub



#End Region



    Private Sub Unificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Unificar.Click


        If String.IsNullOrEmpty(Trim(TxtCodigoDestino.Text)) Or GrillaProductosCambiar.RowCount = 0 Then
            MessageBoxEx.Show("No existen datos que procesar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim info As New TaskDialogInfo("¡ADVERTENCIA!",
                                     eTaskDialogIcon.ShieldStop,
                                     "¡IMPORTANTE!",
                                     "Esta acción reemplaza el código antiguo por el nuevo en todos sus movimientos de existencia y a demas deja el código anterior como alternativo para el nuevo código, es decir, los códigos anteriores al leerlos con el sistema automaticamente te llevaran al nuevo código." & vbCrLf &
                                     "Esta acción requiere de mucha seguridad, ya que la transacción es irreversible" & vbCrLf & vbCrLf &
                                     "¿DESEA REALIZAR EL CAMBIO?" & vbCrLf,
                                     eTaskDialogButton.Yes + eTaskDialogButton.No _
                                     , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)

        If result = eTaskDialogResult.Yes Then

            Dim _Cambiar_Descripcion As Boolean = False

            Dim dlg As System.Windows.Forms.DialogResult =
                                MessageBoxEx.Show(Me,
                                "¿Desea reemplazar la[s] descripción[es] del [los] producto[s]?",
                                "Reemplazar descripción", MessageBoxButtons.YesNo)

            If dlg = System.Windows.Forms.DialogResult.Yes Then
                _Cambiar_Descripcion = True
            End If


            Dim CodigoMTS = ""
            Dim CodigoRandom = TxtRtuDestino.Text
            Dim DescripcionOld = _Sql.Fx_Trae_Dato("MAEPR", "NOKOPR", "KOPR = '" & CodigoRandom & "'")


            For Each Fila As DataRow In Dts_Unificados.Tables("Tmp_UnificadosHitory").Rows

                Dim CodNew = Fila.Item("CodNew").ToString
                Dim CodOld = Fila.Item("CodOld").ToString
                Dim Descrip = Fila.Item("DescripcionOld").ToString
                Dim RtuOld = De_Num_a_Tx_01(Fila.Item("RtuOld").ToString)
                Dim Ud1Old = Fila.Item("Ud1Old").ToString
                Dim Ud2Old = Fila.Item("Ud2Old").ToString
                Dim Responzable = Fila.Item("Responzable").ToString
                Dim _Cambiar As Boolean = True

                If Not Fila.Item("Unificado") Then
                    If Not ChkNoPreguntar.Checked Then
                        If MsgBox("Esta seguro de reemplazar este producto:" & vbCrLf & "Código: " & TxtCodigoDestino.Text & vbCrLf &
                             "Descripción: " & TxtDescripcionDestino.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            _Cambiar = False
                        End If
                    End If

                    If _Cambiar Then
                        If CambiarCodigo(CodNew, TxtDescripcionDestino.Text, CodOld, Descrip,
                                        RtuOld, Ud1Old, Ud2Old, Responzable, False, _Cambiar_Descripcion) = True Then

                            Fila.Item("Unificado") = True
                        Else
                            MessageBoxEx.Show("Producto " & Trim(CodOld) & ", " & Descrip & vbCrLf & "No fue reemplazado!",
                                              "No reemplazar producto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Next


            MessageBoxEx.Show("Productos unificados correctamente",
                              "Unificar producto", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub TxtCodigoDestino_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoDestino.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True

            Consulta_Sql = "Select * From MAEPR Where KOPR = '" & TxtCodigoDestino.Text & "'"
            Dim Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

            If Tbl.Rows.Count > 0 Then
                BuscarProductos(TxtCodigoDestino.Text, TxtCodigoDestino, TxtDescripcionDestino,
                               TxtRtuDestino, TxtUd1Destino, TxtUd2Destino, Tbl)
            Else

                Dim Fm As New Frm_BuscarXProducto_Mt
                Fm.CodProveedor_productos = String.Empty
                Fm.Tipo_Busqueda_Productos = Fm.Buscar_En.Maestro_de_Productos
                Fm.ListaDePrecio = ModListaPrecioVenta
                Fm.CodProveedor_productos = String.Empty
                Fm.MostrarOcultos = True
                Fm.BtnBusAlternativas.Visible = True
                Fm.ShowDialog(Me)

                Codigo_abuscar = Fm.CodigoPr_Sel
                Tbl = Fm._Tbl_Inf_Producto

                BuscarProductos(Codigo_abuscar, TxtCodigoDestino, TxtDescripcionDestino,
                                TxtRtuDestino, TxtUd1Destino, TxtUd2Destino, Tbl)

            End If
        End If
    End Sub


    Private Sub BtnAgregarCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarCodigo.Click


        Dim Fm As New Frm_BuscarXProducto_Mt
        Fm.CodProveedor_productos = String.Empty
        Fm.Tipo_Busqueda_Productos = Fm.Buscar_En.Maestro_de_Productos
        Fm.ListaDePrecio = ModListaPrecioVenta
        Fm.CodProveedor_productos = String.Empty
        Fm.MostrarOcultos = True
        Fm.BtnBusAlternativas.Visible = True
        Fm.ShowDialog(Me)
        Codigo_abuscar = Fm.CodigoPr_Sel

        Incorporar_Producto(Codigo_abuscar)

    End Sub

    Sub Incorporar_Producto(ByVal _Codigo As String)

        If Not String.IsNullOrEmpty(Trim(_Codigo)) Then

            If _Codigo = Trim(TxtCodigoDestino.Text) Then
                MessageBoxEx.Show("No puede asignar el mismo producto de destino en la lista",
                         "Unificar producto", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            Consulta_sql = "SELECT KOPR,NOKOPR,RLUD,UD01PR,UD02PR FROM MAEPR WHERE KOPR = '" & _Codigo & "'"
            Dim TblPr = _Sql.Fx_Get_Tablas(Consulta_Sql)

            Dim CodigoOld = _Codigo
            Dim DescripcionOld = TblPr.Rows(0).Item("NOKOPR")
            Dim RtuOld = TblPr.Rows(0).Item("RLUD")
            Dim Ud1Old = TblPr.Rows(0).Item("UD01PR")
            Dim Ud2Old = TblPr.Rows(0).Item("UD02PR")


            Dim _Inc_prod As Boolean = True

            If Not ChkPasarDifRTU.Checked Then
                If RtuOld = TxtRtuDestino.Text Then
                    _Inc_prod = True
                Else
                    _Inc_prod = False
                End If
            End If

            If _Inc_prod Then

                Dim NewFila As DataRow
                NewFila = Dts_Unificados.Tables("Tmp_UnificadosHitory").NewRow
                With NewFila

                    .Item("CodNew") = TxtCodigoDestino.Text
                    .Item("CodOld") = CodigoOld
                    .Item("DescripcionOld") = DescripcionOld
                    .Item("Ud1Old") = Ud1Old
                    .Item("Ud2Old") = Ud2Old
                    .Item("RtuOld") = RtuOld
                    .Item("Responzable") = FUNCIONARIO
                    .Item("Unificado") = False

                    Dts_Unificados.Tables("Tmp_UnificadosHitory").Rows.Add(NewFila)
                End With

                GrillaProductosCambiar.Refresh()

                Consulta_sql =
                "INSERT INTO Tmp_UnificadosHitory (CodNew, CodOld, DescripcionOld, Ud1Old, Ud2Old, RtuOld, Responzable)" & vbCrLf &
                "VALUES ('" & TxtCodigoDestino.Text & "','" & CodigoOld & "','" & DescripcionOld &
                "','" & Ud1Old & "','" & Ud2Old & "'," & RtuOld & ",'" & FUNCIONARIO & "')"

            Else

                MessageBoxEx.Show("Estos productos tienen distinta R.T.U." &
                         "Por lo tanto no pueden ser unificados",
                         "Unificar producto", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        End If
    End Sub


    Private Sub BtnLimpiarCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiarCodigo.Click
        LimpiarTxt()
        CargarGrilla()
    End Sub

    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiarGrilla.Click
        CargarGrilla()
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LimpiarTxt()
        Sb_Formato_Generico_Grilla(GrillaProductosCambiar, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
    End Sub

    Private Sub BtnCreaProducClassic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreaProducClassic.Click

        'If Fx_Tiene_Permiso(Me, "Prod013") Then

        'Dim Fm As New Frm_MtCreacionDeProducto(Frm_MtCreacionDeProducto.Enum_Accion.Nuevo, Nothing, True)
        'Fm.Btn_Codigo_Alternativo.Visible = False
        'Fm.Txtcodigoprincipal.Enabled = False
        'Fm._Mostrar_Leyed_Reg_Codigo = True
        'Fm._Crear = True
        'Fm.Btn_TablaClasificaciones.Visible = True
        'If Not Fx_Tiene_Permiso(Me, "Prod008", , True) Then

        'End If
        'Fm._Pedir_Alternativo = True
        'Fm.ShowDialog(Me)

        'If Fm.Pro_Grabar Then
        'Codigo_abuscar = Fm.Pro_RowProducto.Item("KOPR")
        'BuscarProductos(Codigo_abuscar, TxtCodigoDestino, TxtDescripcionDestino, _
        '                                TxtRtuDestino, TxtUd1Destino, TxtUd2Destino, Tbl)
        'End If
        'End If

    End Sub

    Private Sub BtnCreaProducMatriz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreaProducMatriz.Click
        Dim Nro As String = "Prod007"
        If Fx_Tiene_Permiso(Me, Nro) Then
            MessageBoxEx.Show(Me, "En construcción")
            '    Dim Fm As New Frm_CreaProductos_01
            '    Fm.VieneDesdeSolicitud = False
            '    Fm.Show()
        End If
    End Sub

    Private Sub Frm_UnificacionProducto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarGrilla()
    End Sub

    Private Sub BtnImportarProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportarProductos.Click

        Try
            _Cancelar_LevMasivo = False

            Dim _Levantado As Boolean = True
            Dim oFD As New OpenFileDialog
            Dim Nombre_Archivo As String
            Dim Ubicacion_File
            '.Filter = "Ficheros DBF (PFMDSP10.dbf)|PFMDSP10.dbf|Todos (*.*)|*.*"
            '.Filter = "Ficheros DBF (Productos_Aju.xls)|Productos_Aju.xls|Productos_Aju.xlsx"

            oFD.FileName = String.Empty

            If oFD.ShowDialog = DialogResult.OK Then
                Nombre_Archivo = oFD.SafeFileName
                Ubicacion_File = oFD.FileName
                BtnCancelarImp.Visible = True
            Else
                Return
            End If


            Dim ImpEx As New Class_Importar_Excel
            Dim Extencion As String = Replace(System.IO.Path.GetExtension(Nombre_Archivo), ".", "")
            Dim Arreglo = ImpEx.Importar_Excel_Array(Ubicacion_File, Extencion)

            Dim Filas = Arreglo.GetUpperBound(0)
            Dim RegInsert As Long = 0

            'Progreso_Porc.Maximum = 100
            'Progreso_Cont.Maximum = Filas 'Dst_Impotar.Tables("Inv_InvParcial").Rows.Count

            If Filas <= 1 Then
                MessageBoxEx.Show("No existen datos que levantar!!", "Unificar productos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim Contador As Integer = 0
            Progreso_Porc.Maximum = 100

            DeshabilitarObjetos(False)
            Progreso_Porc.Value = 0

            Dim _Unificados As Long = 0
            Dim _Problema As Long = 0


            For i = 1 To Filas
                'Zzz_TblPasoFO()
                System.Windows.Forms.Application.DoEvents()


                Dim _CodNew As String = Trim(Arreglo(i, 0))
                Dim _CodigoOld As String = Trim(Arreglo(i, 1))

                'Incorporar_Producto(_Codigo)

                Dim Reg As Integer = _Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & _CodNew & "'")

                If CBool(Reg) Then

                    If _Cancelar_LevMasivo Then

                        Dim dlg As System.Windows.Forms.DialogResult =
                                        MessageBoxEx.Show(Me,
                                        "¿Esta seguro de cancelar esta acción, esto quitara todo lo incorporado?",
                                        "Cancelar", MessageBoxButtons.YesNo)

                        If dlg = System.Windows.Forms.DialogResult.Yes Then
                            'CargarGrilla()
                            '_Levantado = False
                            DeshabilitarObjetos(True)
                            Exit For
                        Else
                            _Cancelar_LevMasivo = False
                        End If

                    End If

                    Consulta_sql = "SELECT KOPR,NOKOPR,RLUD,UD01PR,UD02PR" & vbCrLf &
                                   "FROM MAEPR WHERE KOPR = '" & _CodigoOld & "'"
                    Dim TblPr = _Sql.Fx_Get_Tablas(Consulta_Sql)

                    'Dim CodigoOld = _Codigo
                    Dim _DescripcionOld = TblPr.Rows(0).Item("NOKOPR")
                    Dim _RtuOld = TblPr.Rows(0).Item("RLUD")
                    Dim _Ud1Old = TblPr.Rows(0).Item("UD01PR")
                    Dim _Ud2Old = TblPr.Rows(0).Item("UD02PR")

                    If CambiarCodigo(_CodNew, TxtDescripcionDestino.Text, _CodigoOld, _DescripcionOld,
                                             _RtuOld, _Ud1Old, _Ud2Old, FUNCIONARIO, False, False) Then
                        _Unificados += 1
                    Else
                        _Problema += 1
                    End If

                    LblEstadoImp.Text = "Unificados " & FormatNumber(_Unificados, 0) & ", Con problemas " & FormatNumber(_Problema, 0)

                Else
                    _Problema += 1
                End If

                Contador += 1
                Progreso_Porc.Value = ((Contador * 100) / Filas)
            Next

            Progreso_Porc.Value = 0

            If _Levantado Then
                MessageBoxEx.Show(Filas & "Productos correctamente indorporados",
                                  "Unificar productos", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            DeshabilitarObjetos(True)

        Catch ex As Exception
            DeshabilitarObjetos(True)
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BtnCancelarImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelarImp.Click
        _Cancelar_LevMasivo = True
    End Sub


    Sub DeshabilitarObjetos(ByVal Estado As Boolean)

        GrupoDestino.Enabled = Estado
        GroupBox1.Enabled = Estado
        ChkNoPreguntar.Enabled = Estado
        ChkPasarDifRTU.Enabled = Estado
        Unificar.Enabled = Estado
        BtnImportarProductos.Enabled = Estado
        BtnLimpiarCodigo.Enabled = Estado
        BtnAgregarCodigo.Enabled = Estado
        BtnLimpiarGrilla.Enabled = Estado
        BtnAgregarCodigo.Enabled = Estado
        BtnCrearProductos.Enabled = Estado
        Me.ControlBox = Estado

        If Estado Then
            BtnCancelarImp.Visible = False
            LblEstadoImp.Visible = False
            Progreso_Porc.Visible = False
        Else
            BtnCancelarImp.Visible = True
            LblEstadoImp.Visible = True
            Progreso_Porc.Visible = True
        End If

    End Sub

End Class
