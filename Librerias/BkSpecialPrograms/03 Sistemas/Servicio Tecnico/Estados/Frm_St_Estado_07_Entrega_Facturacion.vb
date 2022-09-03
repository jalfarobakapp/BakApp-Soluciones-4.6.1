Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc
'Imports BkSpecialPrograms


Public Class Frm_St_Estado_07_Entrega_Facturacion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Ot As Integer
    Dim _Grabar As Boolean
    Dim _DsDocumento As DataSet

    Dim _Row_Encabezado As DataRow
    Dim _Tbl_DetProd As DataTable
    Dim _Tbl_ChekIn As DataTable
    Dim _Row_Notas As DataRow
    Dim _RowEntidad As DataRow
    Dim _Tbl_DetProd_Cov As DataTable
    Dim _TblFacturas As DataTable

    Dim _Editando_documento As Boolean

    Dim _Motivo_no_reparo As String

    Dim _Horas_Mano_de_Obra As Double
    Dim Imagenes_32x32 As ImageList

    Dim _Fijar_Estado As Boolean

    Dim _Es_Garantia As Boolean

    Dim _Accion As Accion

    Enum Accion
        Nuevo
        Editar
    End Enum

    Public Sub New(ByVal Accion As Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Accion = Accion
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

    End Sub


    Private Sub Frm_St_Estado_07_Entrega_Facturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _Es_Garantia = _Row_Encabezado.Item("Chk_Serv_Garantia")
        InsertarBotonenGrilla(Grilla, "Btn_Ver", "Ver", "Ver", 0, _Tipo_Boton.Boton)

        Sb_Actualizar_Grilla()

        If _Es_Garantia Then
            Btn_Agregar_Factura.Tooltip = "Agregar Guía interna"
            Grupo_Documentos.Text = "Guías internas asociadas"
        Else
            Btn_Agregar_Factura.Tooltip = "Agregar Factura"
            Grupo_Documentos.Text = "Facturas/Guías asociadas"
        End If

        If _Accion = Accion.Nuevo Then
            Sb_Cargar_Combo("")
        ElseIf _Accion = Accion.Editar Then

            Dim _Cod_Estado_Entrega = _Row_Encabezado.Item("Cod_Estado_Entrega")

            Chk_Equipo_Abandonado_Por_El_Cliente.Checked = _Row_Encabezado.Item("Chk_Equipo_Abandonado_Por_El_Cliente")
            Chk_Equipo_Abandonado_Por_El_Cliente.Enabled = False

            Sb_Cargar_Combo(_Cod_Estado_Entrega)
            Btn_Fijar_Estado.Visible = False
            Btn_Agregar_Factura.Visible = False

            Txt_Nota.ReadOnly = True
            Txt_Nota.BackColor = Color.LightGray
            Txt_Nota.FocusHighlightEnabled = False

            Cmb_Estado_Entrega.Enabled = False

            Btn_Editar.Visible = True

            If Trim(_Row_Encabezado.Item("CodEstado")) = "CE" Then
                Btn_Editar.Visible = False
            End If

        End If

        Txt_Nota.Text = _Row_Notas.Item("Nota_Etapa_07")

        Me.Refresh()

    End Sub

    Sub Sb_Cargar_Combo(ByVal _Estado As String)

        caract_combo(Cmb_Estado_Entrega)
        Consulta_sql = "SELECT CodigoTabla AS Padre,NombreTabla AS Hijo" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "Where Tabla = 'ES_ENTREGA_ST' ORDER BY Padre" ' WHERE SEMILLA = " & Actividad
        Cmb_Estado_Entrega.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Estado_Entrega.SelectedValue = _Estado

    End Sub

    Private Sub Btn_Estado_Entrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Estado_Entrega.Click

        If Fx_Tiene_Permiso(Me, "Tbl00016") Then

            Dim _Estado As String = NuloPorNro(Cmb_Estado_Entrega.SelectedValue, "")

            Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(
               Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Estado_Entrega_ST,
               Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)

            Fm.Text = "Mantención de Estados de entrega Serv. Técnico"
            Fm.Pro_Cerrar_al_grabar = True
            Fm.ShowDialog(Me)

            Sb_Cargar_Combo(_Estado)

        End If

    End Sub

    Sub Sb_Actualizar_Grilla()


        With Grilla

            .DataSource = _TblFacturas

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Btn_Ver").Visible = True
            .Columns("Btn_Ver").HeaderText = "Ver"
            .Columns("Btn_Ver").Width = 30
            .Columns("Btn_Ver").DisplayIndex = 0

            .Columns("Tido").Visible = True
            .Columns("Tido").HeaderText = "Tipo"
            .Columns("Tido").Width = 40
            .Columns("Tido").DisplayIndex = 1
            .Columns("Tido").ReadOnly = True

            .Columns("Nudo").Visible = True
            .Columns("Nudo").HeaderText = "Número"
            .Columns("Nudo").Width = 70
            .Columns("Nudo").ReadOnly = True
            .Columns("Nudo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Nudo").DisplayIndex = 2

            .Columns("Cliente").Visible = True
            .Columns("Cliente").HeaderText = "Cliente"
            .Columns("Cliente").Width = 200
            .Columns("Cliente").DisplayIndex = 3
            .Columns("Cliente").ReadOnly = True

            .Columns("Fecha_Doc").Visible = True
            .Columns("Fecha_Doc").HeaderText = "Fecha"
            .Columns("Fecha_Doc").Width = 70
            .Columns("Fecha_Doc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Cantidad").DefaultCellStyle.Format = "###,##.##"
            .Columns("Fecha_Doc").ReadOnly = True
            .Columns("Fecha_Doc").DisplayIndex = 4

            .Columns("Total").Visible = True
            .Columns("Total").HeaderText = "Total"
            .Columns("Total").Width = 70
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Total").ReadOnly = True
            .Columns("Total").DisplayIndex = 5


        End With

        'Sb_Marcar_Grilla()



    End Sub

    Private Sub Btn_Agregar_Factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar_Factura.Click

        Dim _Filtro_Doc As String = Generar_Filtro_IN(_TblFacturas, "", "Idmaeedo", False, False, "")

        Dim _RowDocumento As DataRow

        Dim _Tipo As String

        If _Es_Garantia Then
            _Tipo = "('GDI','GDP','GDD')"
        Else
            _Tipo = "('FCV','GDV','GDP','GDD')"
        End If

        Dim Fm As New Frm_BusquedaDocumento_Filtro(False)
        Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, _Tipo, "Where TIDO IN " & _Tipo)
        Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado

        If _Filtro_Doc <> "()" Then
            Fm.Pro_Sql_Filtro_Otro_Filtro = "And IDMAEEDO not in " & _Filtro_Doc
        End If
        If Not _Es_Garantia Then
            Fm.Pro_Row_Entidad = _RowEntidad
        End If
        Fm.ShowDialog(Me)
        _RowDocumento = Fm.Pro_Row_Documento_Seleccionado
        Fm.Dispose()

        If Not (_RowDocumento Is Nothing) Then

            With _RowDocumento

                Dim _Id_Ot = _Row_Encabezado.Item("Id_Ot")
                Dim _Idmaeedo = .Item("IDMAEEDO")
                Dim _Tido = .Item("TIDO")
                Dim _Nudo = .Item("NUDO")
                Dim _Feemdo = .Item("FEEMDO")
                Dim _Vabrdo = .Item("VABRDO")

                Dim _Cliente = _Sql.Fx_Trae_Dato("MAEEN", "NOKOEN",
                                         "KOEN = '" & .Item("ENDO") & "' And SUEN = '" & .Item("SUENDO") & "'")

                Dim NewFila As DataRow
                NewFila = _TblFacturas.NewRow

                With NewFila

                    .Item("Id_Ot") = _Id_Ot
                    .Item("Idmaeedo") = _Idmaeedo
                    .Item("Tido") = _Tido
                    .Item("Nudo") = _Nudo
                    .Item("Cliente") = Trim(_Cliente)
                    .Item("Fecha_Doc") = _Feemdo
                    .Item("Total") = _Vabrdo
                    .Item("Fecha_Asociacion") = FechaDelServidor()

                    _TblFacturas.Rows.Add(NewFila)

                End With

            End With

        End If

    End Sub

#Region "PROPIEDADES"

    Public Property Pro_DsDocumento() As DataSet
        Get
            Return _DsDocumento
        End Get
        Set(ByVal value As DataSet)
            _DsDocumento = value

            _Row_Encabezado = _DsDocumento.Tables(0).Rows(0)
            _Row_Notas = _DsDocumento.Tables(3).Rows(0)
            _TblFacturas = _DsDocumento.Tables(8)

        End Set
    End Property

    Public Property Pro_RowEntidad() As DataRow
        Get
            Return _RowEntidad
        End Get
        Set(ByVal value As DataRow)
            _RowEntidad = value
        End Set
    End Property

    Public Property Pro_Id_Ot() As Integer
        Get
            Return _Id_Ot
        End Get
        Set(ByVal value As Integer)
            _Id_Ot = value
        End Set
    End Property

    Public Property Pro_Fijar_Estado() As Boolean
        Get
            Return _Fijar_Estado
        End Get
        Set(ByVal value As Boolean)
            _Fijar_Estado = value
        End Set
    End Property

    Public Property Pro_Editando_Documento() As Boolean
        Get
            Return _Editando_documento
        End Get
        Set(ByVal value As Boolean)
            _Editando_documento = value
        End Set
    End Property

    Public Property Pro_Imagenes_32x32() As ImageList
        Get
            Return Imagenes_32x32
        End Get
        Set(ByVal value As ImageList)
            Imagenes_32x32 = value
        End Set
    End Property


#End Region

    Private Sub Btn_Ver_documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_documento.Click
        Sb_Ver_Documento()
    End Sub

    Sub Sb_Ver_Documento()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaeedo As Integer = _Fila.Cells("Idmaeedo").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Quitar_documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quitar_documento.Click
        Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
        Grilla.Refresh()
    End Sub

    Private Sub Frm_St_Estado_07_Entrega_Facturacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "Btn_Ver" Then
            If _Accion = Accion.Nuevo Then
                ShowContextMenu(Menu_Contextual_Ver_Quitar)
            Else
                If _Editando_documento Then
                    ShowContextMenu(Menu_Contextual_Ver_Quitar)
                Else
                    Sb_Ver_Documento()
                End If
            End If
        End If

    End Sub

    Private Sub Btn_Fijar_Estado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Fijar_Estado.Click

        If Fx_Se_Puede_Grabar() Then

            If Fx_Fijar_Estado() Then

                _Row_Encabezado.Item("Estado_Entrega") = Trim(Cmb_Estado_Entrega.Text)

                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Fijar estado", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                _Fijar_Estado = True
                Me.Close()
            End If

        End If

    End Sub

    Function Fx_Se_Puede_Grabar() As Boolean

        If String.IsNullOrEmpty(Txt_Nota.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA INFORMACION DE LA ENTREGA", _
                                   Imagenes_32x32.Images.Item("warning.png"), _
                                   2 * 1000, eToastGlowColor.Red, _
                                   eToastPosition.MiddleCenter)
            'Super_Tab.SelectedTabIndex = 1
            Txt_Nota.Focus()
            Return False
        End If

        Dim _Estado = NuloPorNro(Cmb_Estado_Entrega.SelectedValue, "")

        If String.IsNullOrEmpty(_Estado) Then
            Beep()
            ToastNotification.Show(Me, "FALTA ESTADO DE LA ENTREGA", _
                                   Imagenes_32x32.Images.Item("warning.png"), _
                                   2 * 1000, eToastGlowColor.Red, _
                                   eToastPosition.MiddleCenter)
            'Super_Tab.SelectedTabIndex = 1
            Cmb_Estado_Entrega.Focus()
            Return False
        End If

        If Not CBool(_TblFacturas.Rows.Count) Then

            If MessageBoxEx.Show(Me, "No ingreso ninguna factura asociada a la reparación." & vbCrLf & _
                                 "Desea agregar facturas asociadas al servicio", _
                                             "Asociación de facturas", MessageBoxButtons.YesNoCancel, _
                                             MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Return False
            End If

        End If

        Return True

    End Function

    Function Fx_Fijar_Estado() As Boolean

        Consulta_sql = String.Empty

        Dim _Abandonado As Integer = CInt(Chk_Equipo_Abandonado_Por_El_Cliente.Checked) * -1

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set" & Space(1) & _
                       "Fecha_Entrega = Getdate()," & vbCrLf & _
                       "Chk_Equipo_Abandonado_Por_El_Cliente = " & _Abandonado & _
                       ",Cod_Estado_Entrega = '" & Cmb_Estado_Entrega.SelectedValue & "'" & vbCrLf & _
                       "Where Id_Ot  = " & _Id_Ot & vbCrLf & vbCrLf



        If _Accion = Accion.Nuevo Then
            ' ACTUALIZAR ENCABEZADO DE DOCUMENTO

            Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " & _
                           "CodEstado = 'E'" & vbCrLf & _
                           "Where Id_Ot  = " & _Id_Ot & vbCrLf & vbCrLf


            ' ACTUALIZAR ESTADO

            Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_Estados " & _
                           "(Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " & _
                           "(" & _Id_Ot & ",'F',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')" & vbCrLf & vbCrLf

            Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_Estados " & _
                          "(Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " & _
                          "(" & _Id_Ot & ",'E',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')" & vbCrLf & vbCrLf


            '**********************************'**********************************
        End If


        ' -----------------------------------------------------  FACTURAS ASOCIADAS ------------------------------------------------


        Consulta_sql += "Delete " & _Global_BaseBk & "Zw_St_OT_Doc_Asociados" & Space(1) &
                        "Where Id_Ot = " & _Id_Ot & " And Tido IN ('FCV','GDI','GDV','GDP','GDD') And Garantia = 0" & vbCrLf & vbCrLf


        For Each _Fila As DataRow In _TblFacturas.Rows

            If _Fila.RowState <> DataRowState.Deleted Then

                Dim _Idmaeedo = _Fila.Item("Idmaeedo")
                Dim _Tido = _Fila.Item("Tido")
                Dim _Nudo = _Fila.Item("Nudo")
                Dim _Estado = ""
                Dim _Fecha_Doc = Format(_Fila.Item("Fecha_Doc"), "yyyyMMdd")

                Consulta_sql += "Insert Into " & _Global_BaseBk & _
                               "Zw_St_OT_Doc_Asociados (Id_Ot,Idmaeedo,Tido,Nudo,Estado,Fecha_Asociacion,Fecha_Doc) Values " & _
                               "(" & _Id_Ot & "," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "','" & _Estado & _
                               "',GetDate(),'" & _Fecha_Doc & "')" & vbCrLf & vbCrLf


            End If

        Next

        '**********************************'***********************************************************************

        ' --------------------------------------------------- NOTAS ---------------------------------------

        Dim _Nota_Etapa_07 As String = Txt_Nota.Text

        For _i = 0 To 31
            _Nota_Etapa_07 = Replace(_Nota_Etapa_07, Chr(_i), " ")
        Next

        Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Notas Set " & vbCrLf & _
                       "Nota_Etapa_07 = '" & _Nota_Etapa_07 & "'" & vbCrLf & _
                       "Where Id_Ot = " & _Id_Ot & vbCrLf & vbCrLf


        '**********************************'**********************************

       

         Fx_Fijar_Estado = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

    End Function

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click

        _Editando_documento = True
        
        Beep()
        ToastNotification.Show(Me, "AHORA ES POSIBLE ACTUALIZAR EL DOCUMENTO", _
                               Btn_Editar.Image, _
                               1 * 1000, eToastGlowColor.Green, _
                               eToastPosition.MiddleCenter)

        Chk_Equipo_Abandonado_Por_El_Cliente.Enabled = True

        Btn_Grabar.Visible = True
        Btn_Cancelar.Visible = True
        Btn_Agregar_Factura.Visible = True
        Btn_Editar.Visible = False
        Me.ControlBox = False

        Txt_Nota.ReadOnly = False
        Txt_Nota.BackColor = Color.White
        Txt_Nota.FocusHighlightEnabled = True

        Cmb_Estado_Entrega.Enabled = True

        Txt_Nota.Focus()

        Me.Refresh()

    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click
        If Fx_Se_Puede_Grabar() Then

            If Fx_Fijar_Estado() Then

                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Fijar estado", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.Close()
            End If

        End If
    End Sub
End Class