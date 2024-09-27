Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Formato_Sel_Funciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Accion As _Enum_Accion
    Enum _Enum_Accion
        Seleccionar
        Editar
    End Enum

    Enum _Enum_Seccion
        Encabezado
        Detalle
        Pie
    End Enum

    Dim _Seccion As String
    Dim _Tido As String

    Dim _RowFormato As DataRow
    Private _dv As New DataView

    Dim _RowDocumento As DataRow

    Public Property Pro_RowDocumento() As DataRow
        Get
            Return _RowDocumento
        End Get
        Set(ByVal value As DataRow)
            _RowDocumento = value
        End Set
    End Property
    Public ReadOnly Property Pro_RowFormato() As DataRow
        Get
            Return _RowFormato
        End Get
    End Property

    Public Sub New(ByVal Seccion As _Enum_Seccion,
                   ByVal Tido As String,
                   ByVal Accion As _Enum_Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Select Case Seccion
            Case _Enum_Seccion.Encabezado
                _Seccion = "And Seccion In ('E','P')"
            Case _Enum_Seccion.Detalle
                _Seccion = "And Seccion = 'D'"
            Case _Enum_Seccion.Pie
                _Seccion = "And Seccion = 'P'"
        End Select

        _Accion = Accion

        If _Accion = _Enum_Accion.Editar Then
            _Seccion = String.Empty
        End If

        Select Case Tido
            Case "CHC"
                _Seccion += " And Cheque = 1 And Sol_Bodega = 0"
                Me.Text = "FUNCIONES DEL SISTEMA PARA CHEQUES Y LETRAS"
            Case "TJV"
                _Seccion += " And Cheque = 1 And Sol_Bodega = 0"
                Me.Text = "FUNCIONES DEL SISTEMA PARA VOUCHER TARJETAS DEBITO/CREDITO"
            Case "CPG"
                _Seccion += " And Cheque = 1 And Sol_Bodega = 0"
                Me.Text = "FUNCIONES DEL SISTEMA PARA COMPROBATE DE PAGO"
            Case "SPB"
                _Seccion += " And Sol_Bodega = 1"
                Me.Text = "FUNCIONES DEL SISTEMA PARA SOLICITUD DE PRODUTOS A BODEGA"
            Case Else
                _Seccion += " And Cheque = 0 And Sol_Bodega = 0"
                Me.Text = "FUNCIONES DEL SISTEMA PARA DOCUMENTOS DE VENTA Y COMPRA E INTERNOS"
        End Select

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, False, False)

        _Tido = Tido

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Crear_Funciones.ForeColor = Color.White
            Txt_Buscar_Formato.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_Formato_Sel_Funciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()
        Me.ActiveControl = Txt_Buscar_Formato

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "SELECT *," &
                       "Case Tipo_de_dato" & vbCrLf &
                       "When 'C' Then 'Carácter'" & vbCrLf &
                       "When 'N' Then 'Númerico'" & vbCrLf &
                       "When 'F' Then 'Fecha'" & vbCrLf &
                       "When '$' Then 'Modena'" & vbCrLf &
                       "Else '???' End As Dato,Formato" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_Format_Fx" & vbCrLf &
                       "Where 1 > 0" & vbCrLf & _Seccion & vbCrLf &
                       "Order By Seccion,Nombre_Funcion"

        Dim _Ds As New DataSet
        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

        _dv.Table = _Ds.Tables(0)

        Grilla.DataSource = _dv

        With Grilla ' ancho 853

            .DataSource = _dv

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("Nombre_Funcion").Visible = True
            .Columns("Nombre_Funcion").Width = 250
            .Columns("Nombre_Funcion").HeaderText = "Nombre formato"
            .Columns("Nombre_Funcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Seccion").Visible = True
            .Columns("Seccion").Width = 30
            .Columns("Seccion").HeaderText = "Sec."
            .Columns("Seccion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Dato").Visible = True
            .Columns("Dato").Width = 100
            .Columns("Dato").HeaderText = "Tipo dato"
            .Columns("Dato").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Formato").Visible = True
            .Columns("Formato").Width = 350
            .Columns("Formato").HeaderText = "Formato"
            .Columns("Formato").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Campo").Visible = True
            .Columns("Campo").Width = 150
            .Columns("Campo").HeaderText = "Campo"
            .Columns("Campo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SqlQuery").Visible = True
            .Columns("SqlQuery").Width = 300
            .Columns("SqlQuery").HeaderText = "Sql Query"
            .Columns("SqlQuery").DisplayIndex = _DisplayIndex

        End With

    End Sub

    Private Sub Txt_Buscar_Formato_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Buscar_Formato.TextChanged
        Try
            _dv.RowFilter = String.Format("Nombre_Funcion+Campo Like '%{0}%'", Txt_Buscar_Formato.Text)
        Catch ex As Exception
            MessageBoxEx.Show(ex.Message)
        End Try
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Nombre_Funcion As String = _Fila.Cells("Nombre_Funcion").Value
        Dim _Id = _Fila.Cells("Id").Value

        If _Accion = _Enum_Accion.Seleccionar Then

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Format_Fx Where Id = " & _Id
            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If CBool(_Tbl.Rows.Count) Then
                _RowFormato = _Tbl.Rows(0)
                Me.Close()
            End If

        ElseIf _Accion = _Enum_Accion.Editar Then

            Dim _Editar As Boolean

            Dim _IdDoc As Integer
            Dim _Es_Cheque As Boolean = False
            Dim _Sol_Prod_Bodega As Boolean = False


            Select Case _Tido
                Case "SPB"
                    _Editar = True
                    _Sol_Prod_Bodega = True
                Case "CHC"
                    If _RowDocumento Is Nothing Then
                        Dim _Fm_Chc As New Frm_Tenerduria_Buscar_Documento_Pago(Frm_Tenerduria_Buscar_Documento_Pago.Enum_Tipo_Pago.Ambos, True) ' (Frm_Tenerduria_Buscar_Documento_Pago.Enum_Tipo_Pago.Proveedores, True)
                        _Fm_Chc.ShowDialog(Me)
                        _RowDocumento = _Fm_Chc.Pro_Row_Documento_Seleccionado
                        _Fm_Chc.Dispose()
                    End If

                    If Not _RowDocumento Is Nothing Then
                        _Es_Cheque = True
                        _IdDoc = _RowDocumento.Item("IDMAEDPCE") '273739 '_RowDocumento.Item("IDMAEDPCE")
                        _Editar = True
                    End If
                Case ""
                Case Else

                    If Not IsNothing(_RowDocumento) Then

                        Dim _Tido = _RowDocumento.Item("TIDO")
                        Dim _Nudo = _RowDocumento.Item("NUDO")

                        Dim _Consulta = MessageBoxEx.Show(Me, "¿Desea utilizar el mismo documento para imprimir?" & vbCrLf &
                                     "Documento: " & _Tido & "-" & _Nudo,
                                     "Imprimir", MessageBoxButtons.YesNoCancel)

                        If _Consulta = Windows.Forms.DialogResult.Yes Then
                            _IdDoc = _RowDocumento.Item("IDMAEEDO")
                            _Editar = True
                        ElseIf _Consulta = Windows.Forms.DialogResult.No Then
                            _Editar = Fx_Buscar_Documento()
                        Else
                            Return
                        End If
                    Else
                        _Editar = Fx_Buscar_Documento()
                    End If

                    If _Editar Then _IdDoc = _RowDocumento.Item("IDMAEEDO")

            End Select

            If _Editar Then

                Dim Fm As New Frm_Formato_Creador_Funciones(_IdDoc, _Es_Cheque)
                Fm.Pro_Editar_Funcion = _Nombre_Funcion
                Fm.Pro_Sol_Prod_Bodega = _Sol_Prod_Bodega
                Fm.Pro_Cerra_Al_Grabar = True
                Fm.ShowDialog(Me)
                Fm.Dispose()

                If Fm.Pro_Grabar Then

                    _Fila.Cells("Dato").Value = Fm.Cmb_Tipo_Dato.Text
                    _Fila.Cells("Formato").Value = Fm.Txt_Formato.Text

                    Beep()
                    ToastNotification.Show(Me, "FUNCION ACTUALIZADA CORRECTAMENTE",
                                          My.Resources.save,
                                         2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                End If

                Fm.Dispose()

            End If

        End If

    End Sub

    Private Sub Btn_Crear_Funciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Funciones.Click

        Dim _Crear As Boolean

        Dim _Id As Integer
        Dim _Es_Cheque As Boolean
        Dim _Sol_Prod_Bodega As Boolean

        If _Tido = "SPB" Then
            _Crear = True
            _Sol_Prod_Bodega = True
        Else
            If _Tido = "CHC" Or _Tido = "CPG" Then
                _Es_Cheque = True
                '_Id = 273739 '_RowDocumento.Item("IDMAEDPCE")

                If _RowDocumento Is Nothing Then
                    Dim _Fm_Chc As New Frm_Tenerduria_Buscar_Documento_Pago(Frm_Tenerduria_Buscar_Documento_Pago.Enum_Tipo_Pago.Ambos, True) ' (Frm_Tenerduria_Buscar_Documento_Pago.Enum_Tipo_Pago.Proveedores, True)
                    _Fm_Chc.ShowDialog(Me)
                    _RowDocumento = _Fm_Chc.Pro_Row_Documento_Seleccionado
                    _Fm_Chc.Dispose()
                End If

                If Not _RowDocumento Is Nothing Then
                    _Es_Cheque = True
                    _Id = _RowDocumento.Item("IDMAEDPCE") '273739 '_RowDocumento.Item("IDMAEDPCE")
                    _Crear = True
                End If
            Else
                _Crear = Fx_Buscar_Documento()
                If _Crear Then _Id = _RowDocumento.Item("IDMAEEDO")
            End If
        End If

        If _Crear Then
            Dim Fm As New Frm_Formato_Creador_Funciones(_Id, _Es_Cheque)
            Fm.Pro_Sol_Prod_Bodega = _Sol_Prod_Bodega
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

        Sb_Actualizar_Grilla()

    End Sub

    Function Fx_Buscar_Documento() As Boolean

        If (_RowDocumento Is Nothing) Then

            MessageBoxEx.Show(Me, "Debe seleccionar un documento para la revisión de los datos", "Información",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

            'If _Tido = "edit" Then _Tido = String.Empty

            Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)

            _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos, _Tido)
            _Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado

            _Fm.Rdb_Tipo_Documento_Algunos.Checked = False
            _Fm.Rdb_Tipo_Documento_Uno.Checked = True

            _Fm.ShowDialog(Me)
            _RowDocumento = _Fm.Pro_Row_Documento_Seleccionado
            _Fm.Dispose()

            If Not (_RowDocumento Is Nothing) Then Return True

        Else

            Return True

        End If

    End Function

End Class
