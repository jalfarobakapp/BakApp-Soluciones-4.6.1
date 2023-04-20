Imports DevComponents.DotNetBar

Public Class Frm_St_Estado_05_Reparacion

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

    Dim _Editando_documento As Boolean

    Dim _Motivo_no_reparo As String

    Dim _Horas_Mano_de_Obra_Repara As Double
    Dim Imagenes_32x32 As ImageList

    Dim _Fijar_Estado As Boolean

    Dim _Accion As Accion

    Enum Accion
        Nuevo
        Editar
    End Enum

    Public Property CodTecnico_Repara As String

    Public Sub New(Accion As Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Accion = Accion
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_St_Estado_05_Reparacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        InsertarBotonenGrilla(Grilla, "BtnImagen", "Situación", "Solicitud", 0, _Tipo_Boton.Imagen)

        Dim _Tecnico As String

        AddHandler Txt_Horas_Mano_de_Obra.Validating, AddressOf Txt_Horas_Mano_de_Obra_Validating
        AddHandler Txt_Horas_Mano_de_Obra.Enter, AddressOf Txt_Horas_Mano_de_Obra_Enter
        AddHandler Txt_Horas_Mano_de_Obra.KeyPress, AddressOf Txt_Horas_Mano_de_Obra_KeyPress

        Btn_Grabar.Visible = False

        If _Accion = Accion.Nuevo Then

            _Tecnico = _Row_Encabezado.Item("CodTecnico_Asignado")

            If Not String.IsNullOrEmpty(CodTecnico_Repara) Then
                _Tecnico = CodTecnico_Repara
                Cmb_Tecnico.Enabled = False
            End If

            Sb_Cargar_Tecnicos(_Tecnico)
            Txt_Horas_Mano_de_Obra.Text = _Row_Encabezado.Item("Horas_Mano_de_Obra_Repara")
            Btn_Fijar_Estado.Visible = True

            AddHandler Grilla.KeyDown, AddressOf Grilla_KeyDown
            AddHandler Grilla.CellEndEdit, AddressOf Grilla_CellEndEdit
            AddHandler Grilla.EditingControlShowing, AddressOf Grilla_EditingControlShowing

            AddHandler Chk_No_se_pudo_reparar_el_equipo.CheckedChanged, AddressOf Chk_No_se_pudo_reparar_el_equipo_CheckedChanged

            AddHandler Cmb_Tecnico.SelectedValueChanged, AddressOf Cmb_Tecnico_SelectedValueChanged

        ElseIf _Accion = Accion.Editar Then

            _Tecnico = _Row_Encabezado.Item("CodTecnico_Repara")

            Sb_Cargar_Tecnicos(_Tecnico, True)

            Chk_No_se_pudo_reparar_el_equipo.Checked = _Row_Notas.Item("Chk_no_se_pudo_reparar")

            If Chk_No_se_pudo_reparar_el_equipo.Checked Then
                Txt_Reparacion_Realizada.Text = _Row_Notas.Item("Motivo_no_reparo")
            Else
                Txt_Reparacion_Realizada.Text = _Row_Notas.Item("Reparacion_Realizada")
            End If

            _Motivo_no_reparo = _Row_Notas.Item("Motivo_no_reparo")

            Chk_No_se_pudo_reparar_el_equipo.Enabled = False
            Txt_Nota.Text = _Row_Notas.Item("Nota_Etapa_05")
            Txt_Horas_Mano_de_Obra.Text = _Row_Encabezado.Item("Horas_Mano_de_Obra_Repara")

            Txt_Horas_Mano_de_Obra.Enabled = False

            Txt_Reparacion_Realizada.ReadOnly = True
            Txt_Reparacion_Realizada.BackColor = Color.LightGray
            Txt_Reparacion_Realizada.FocusHighlightEnabled = False

            Txt_Nota.ReadOnly = True
            Txt_Nota.BackColor = Color.LightGray
            Txt_Nota.FocusHighlightEnabled = False

            Btn_Fijar_Estado.Visible = False
            Btn_Editar.Visible = True

            If _Row_Encabezado.Item("CodEstado") = "CE" Then
                Btn_Editar.Visible = False
            End If

        End If

        If Not Chk_No_se_pudo_reparar_el_equipo.Checked Then
            Cmb_Tecnico_SelectedValueChanged()
        End If

        'AddHandler Chk_Taller_Externo.CheckedChanging, AddressOf Chk_Taller_Externo_CheckedChanging
        'AddHandler Chk_Tec_Domicilio.CheckedChanging, AddressOf Chk_Tec_Domicilio_CheckedChanging

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Cargar_Tecnicos(_Tecnico As String,
                           Optional _Solo_Este_Tecnico As Boolean = False)

        Dim _Condicion = String.Empty

        If _Solo_Este_Tecnico Then
            _Condicion = vbCrLf & "And CodFuncionario = '" & _Tecnico & "'" & vbCrLf
        End If

        caract_combo(Cmb_Tecnico)
        Consulta_sql = "SELECT CodFuncionario AS Padre,NomFuncionario AS Hijo" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_St_Conf_Tecnicos_Taller" & vbCrLf &
                       "WHERE 1 > 0" & _Condicion & " ORDER BY Hijo"
        Cmb_Tecnico.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Tecnico.SelectedValue = _Tecnico

        'SELECT     TOP (200) CodFuncionario,NomFuncionario,Star,Chk_Taller_Externo,Chk_Habilitado,Chk_Supervisor,Chk_Domicilio
        'FROM         Zw_St_Conf_Tecnicos_Taller

    End Sub

    Private Sub Cmb_Tecnico_SelectedValueChanged()

        RemoveHandler Chk_Taller_Externo.CheckedChanging, AddressOf Chk_Taller_Externo_CheckedChanging
        RemoveHandler Chk_Tec_Domicilio.CheckedChanging, AddressOf Chk_Tec_Domicilio_CheckedChanging

        Dim _CodFuncionario As String = Cmb_Tecnico.SelectedValue

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & " Zw_St_Conf_Tecnicos_Taller" & vbCrLf &
                       "Where CodFuncionario = '" & _CodFuncionario & "'"

        Dim _TblTecnico As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Rating_Star.Rating = NuloPorNro(_TblTecnico.Rows(0).Item("Star"), 0)
        'Txt_Informacion.Text = _TblTecnico.Rows(0).Item("Informacion")

        Chk_Taller_Externo.Checked = _TblTecnico.Rows(0).Item("Chk_Taller_Externo")
        Chk_Tec_Domicilio.Checked = _TblTecnico.Rows(0).Item("Chk_Domicilio")

        AddHandler Chk_Taller_Externo.CheckedChanging, AddressOf Chk_Taller_Externo_CheckedChanging
        AddHandler Chk_Tec_Domicilio.CheckedChanging, AddressOf Chk_Tec_Domicilio_CheckedChanging

    End Sub

    Private Sub Chk_Taller_Externo_CheckedChanging(sender As System.Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)
        e.Cancel = True
    End Sub

    Private Sub Chk_Tec_Domicilio_CheckedChanging(sender As System.Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)
        e.Cancel = True
    End Sub


    Sub Sb_Actualizar_Grilla()

        With Grilla

            .DataSource = _Tbl_DetProd_Cov

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("BtnImagen").Visible = True
            .Columns("BtnImagen").HeaderText = "Ev."
            .Columns("BtnImagen").Width = 30
            .Columns("BtnImagen").DisplayIndex = 0

            .Columns("Codigo").Visible = True
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 100
            .Columns("Codigo").DisplayIndex = 1
            .Columns("Codigo").ReadOnly = True

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripcion"
            .Columns("Descripcion").Width = 320
            .Columns("Descripcion").ReadOnly = True
            .Columns("Descripcion").DisplayIndex = 2

            .Columns("Ud").Visible = True
            .Columns("Ud").HeaderText = "UM"
            .Columns("Ud").Width = 30
            .Columns("Ud").ReadOnly = True
            .Columns("Ud").DisplayIndex = 3

            .Columns("Cantidad_Utilizada").Visible = True
            .Columns("Cantidad_Utilizada").HeaderText = "Cantidad Utilizada"
            .Columns("Cantidad_Utilizada").Width = 120
            .Columns("Cantidad_Utilizada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Cantidad").DefaultCellStyle.Format = "###,##.##"
            .Columns("Cantidad_Utilizada").ReadOnly = True
            .Columns("Cantidad_Utilizada").DisplayIndex = 4

        End With

        Sb_Marcar_Grilla()

    End Sub

#Region "PROPIEDADES"

    Public Property Pro_DsDocumento() As DataSet
        Get
            Return _DsDocumento
        End Get
        Set(value As DataSet)
            _DsDocumento = value
            _Row_Encabezado = _DsDocumento.Tables(0).Rows(0)
            _Tbl_DetProd = _DsDocumento.Tables(1)
            _Row_Notas = _DsDocumento.Tables(3).Rows(0)
            _Tbl_DetProd_Cov = _DsDocumento.Tables(7)
        End Set
    End Property

    Public Property Pro_RowEntidad() As DataRow
        Get
            Return _RowEntidad
        End Get
        Set(value As DataRow)
            _RowEntidad = value
        End Set
    End Property

    Public Property Pro_Id_Ot() As Integer
        Get
            Return _Id_Ot
        End Get
        Set(value As Integer)
            _Id_Ot = value
        End Set
    End Property

    Public Property Pro_Editando_Documento() As Boolean
        Get
            Return _Editando_documento
        End Get
        Set(value As Boolean)
            _Editando_documento = value
        End Set
    End Property

    Public Property Pro_Fijar_Estado() As Boolean
        Get
            Return _Fijar_Estado
        End Get
        Set(value As Boolean)
            _Fijar_Estado = value
        End Set
    End Property

    Public Property Pro_Imagenes_32x32() As ImageList
        Get
            Return Imagenes_32x32
        End Get
        Set(value As ImageList)
            Imagenes_32x32 = value
        End Set
    End Property


#End Region

#Region "EVENTOS TXT MANO DE OBRA"

    Private Sub Txt_Horas_Mano_de_Obra_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        _Horas_Mano_de_Obra_Repara = De_Txt_a_Num_01(Txt_Horas_Mano_de_Obra.Text, 2)
        Txt_Horas_Mano_de_Obra.Text = FormatNumber(_Horas_Mano_de_Obra_Repara, 2)
    End Sub

    Private Sub Txt_Horas_Mano_de_Obra_Enter(sender As System.Object, e As System.EventArgs)
        If CBool(_Horas_Mano_de_Obra_Repara) Then
            Txt_Horas_Mano_de_Obra.Text = _Horas_Mano_de_Obra_Repara
        Else
            Txt_Horas_Mano_de_Obra.Text = String.Empty
        End If
    End Sub

    Private Sub Txt_Horas_Mano_de_Obra_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)

        Dim _Texto = CType(sender, TextBox)

        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If

        Dim caracter As Char = e.KeyChar

        ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
        ' es el separador decimal, y que no contiene ya el separador  
        If (Char.IsNumber(caracter)) Or
        (caracter = ChrW(Keys.Back)) Or
        (caracter = ",") And
        (_Texto.Text.Contains(",") = False) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

#End Region

    Private Sub Btn_Fijar_Estado_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Fijar_Estado.Click

        Dim _Fijar As Boolean

        If Fx_Se_Puede_Grabar() Then

            If Not Chk_No_se_pudo_reparar_el_equipo.Checked Then

                _Fijar = Fx_Fijar_Estado()

            Else

                If MessageBoxEx.Show(Me, "Marco la casilla <<NO SE PUDO REPARAR EL EQUIPO>>" & vbCrLf &
                                     "¿Está seguro de fijar el estado?", "Equipo No reparado", MessageBoxButtons.YesNoCancel,
                                     MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    _Fijar = Fx_Fijar_Estado_No_Se_Pudo_Reparar()


                End If

            End If

            If _Fijar Then

                _Row_Encabezado.Item("CodEstado") = "V"
                _Row_Encabezado.Item("CodTecnico_Repara") = Cmb_Tecnico.SelectedValue
                _Row_Encabezado.Item("Tecnico_Repara") = Trim(Cmb_Tecnico.Text)

                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Fijar estado",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                _Fijar_Estado = True
                Me.Close()

            End If

        End If

    End Sub

    Function Fx_Se_Puede_Grabar() As Boolean

        If String.IsNullOrWhiteSpace(Txt_Reparacion_Realizada.Text) Then
            MessageBoxEx.Show(Me, "FALTA INFORME DE REPARACION REALIZADA", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Reparacion_Realizada.Text = String.Empty
            Txt_Reparacion_Realizada.Focus()
            Return False
        End If

        If Not Chk_No_se_pudo_reparar_el_equipo.Checked Then
            If CBool(_Tbl_DetProd_Cov.Rows.Count) Then

                For Each _Fila As DataRow In _Tbl_DetProd_Cov.Rows

                    Dim _Utilizado As Boolean = _Fila.Item("Utilizado")
                    Dim _Chk_Validado As Boolean = _Fila.Item("Chk_Validado")

                    If Not _Chk_Validado Then
                        MessageBoxEx.Show(Me, "confirmar las cantidades utilizadas en la reparación" & vbCrLf &
                                            "reingresando las cantidades de cada producto utilizado.",
                                                        "Faltan productos por validar", MessageBoxButtons.OK,
                                                        MessageBoxIcon.Stop)

                        Return False
                    End If
                Next

            End If
        End If

        Return True

    End Function

    Private Sub Grilla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

            Dim _Key As Keys = e.KeyValue

            Select Case _Key

                Case Keys.Enter

                    If _Cabeza = "Cantidad_Utilizada" Then
                        Grilla.Columns(_Cabeza).ReadOnly = False
                        SendKeys.Send("{F2}")
                        e.Handled = True
                        Grilla.BeginEdit(True)
                    End If

                Case Else
                    Grilla.Columns(_Cabeza).ReadOnly = True
            End Select


        Catch ex As Exception

        Finally
            Bar2.Enabled = True
        End Try

    End Sub

    Private Sub Grilla_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "Cantidad_Utilizada" Then

            Dim _Cantidad As Double = _Fila.Cells("Cantidad").Value
            Dim _Cantidad_Utilizada As Double = _Fila.Cells("Cantidad_Utilizada").Value

            If _Cantidad_Utilizada = 0 Then
                _Fila.Cells("Utilizado").Value = False
                _Fila.Cells("Chk_Validado").Value = True
            Else
                If _Cantidad_Utilizada < 0 Then
                    MessageBoxEx.Show(Me, "La cantidad ingresada no puede ser negativa", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    _Fila.Cells("Cantidad_Utilizada").Value = _Cantidad
                    _Fila.Cells("Utilizado").Value = False
                    _Fila.Cells("Chk_Validado").Value = False
                    Return
                Else
                    If _Cantidad_Utilizada > _Cantidad Then
                        MessageBoxEx.Show(Me, "La cantidad ingresada no puede ser mayor a la cantidad del documento", "Validación",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        _Fila.Cells("Cantidad_Utilizada").Value = _Cantidad
                        _Fila.Cells("Utilizado").Value = False
                        _Fila.Cells("Chk_Validado").Value = False
                    Else
                        _Fila.Cells("Utilizado").Value = True
                        _Fila.Cells("Chk_Validado").Value = True
                    End If
                End If
            End If

        End If

        Grilla.Columns(_Cabeza).ReadOnly = True

        Sb_Marcar_Grilla()

        Me.Refresh()
        'Grilla.AllowUserToAddRows = True
    End Sub

    Private Sub Grilla_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "Cantidad_Utilizada" Then
            Dim validar As TextBox = CType(e.Control, TextBox)
            AddHandler validar.KeyPress, AddressOf Validar_Keypress_Nros_Grilla
        End If


    End Sub

    Sub Sb_Marcar_Grilla()

        For Each _Fila As DataGridViewRow In _Grilla.Rows

            Dim _Chk_Validado As Boolean = _Fila.Cells("Chk_Validado").Value
            Dim _Utilizado As Boolean = _Fila.Cells("Utilizado").Value

            If Not _Editando_documento Then
                If _Accion = Accion.Editar Then _Chk_Validado = True
            End If

            _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)

            If _Chk_Validado Then
                If _Utilizado Then
                    _Fila.Cells("BtnImagen").Value = Imagenes_16x16.Images.Item("OK")
                Else
                    _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
                    _Fila.Cells("BtnImagen").Value = Imagenes_16x16.Images.Item("NO")
                End If
            Else
                _Fila.Cells("BtnImagen").Value = Imagenes_16x16.Images.Item("WARNING")
            End If

            _Fila.Cells("Codigo").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)
            _Fila.Cells("Cantidad_Utilizada").Style.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)

        Next

    End Sub

    Private Sub Chk_No_se_pudo_reparar_el_equipo_CheckedChanged(sender As System.Object, e As System.EventArgs)

        If Chk_No_se_pudo_reparar_el_equipo.Checked Then

            Dim _Aceptado As Boolean
            Dim _Motivo As String = _Motivo_no_reparo

            _Aceptado = InputBox_Bk(Me, "Motivo del problema", "",
                                   _Motivo, True, _Tipo_Mayus_Minus.Mayusculas, 300,
                                   True, _Tipo_Imagen.Texto, False)

            If _Aceptado Then

                _Motivo_no_reparo = _Motivo
                Txt_Reparacion_Realizada.Text = "NO SE PUDO REALIZAR LA REPARACION."
                Txt_Reparacion_Realizada.ReadOnly = True
                Txt_Reparacion_Realizada.BackColor = Color.LightGray
                Txt_Reparacion_Realizada.FocusHighlightEnabled = False

                Txt_Nota.Text = "NO SE PUDO REALIZAR LA REPARACION."
                Txt_Nota.ReadOnly = True
                Txt_Nota.BackColor = Color.LightGray
                Txt_Nota.FocusHighlightEnabled = False

                Grupo_Asignacion_Tecnico.Enabled = False

            Else
                Chk_No_se_pudo_reparar_el_equipo.Checked = False
                Txt_Reparacion_Realizada.Focus()
            End If

        Else

            Txt_Reparacion_Realizada.Text = String.Empty
            Txt_Reparacion_Realizada.ReadOnly = False
            Txt_Reparacion_Realizada.BackColor = Color.White
            Txt_Reparacion_Realizada.FocusHighlightEnabled = True

            Txt_Nota.Text = String.Empty
            Txt_Nota.ReadOnly = False
            Txt_Nota.BackColor = Color.White
            Txt_Nota.FocusHighlightEnabled = True

            Grupo_Asignacion_Tecnico.Enabled = True

        End If

    End Sub


    Function Fx_Fijar_Estado() As Boolean


        If Not Chk_No_se_pudo_reparar_el_equipo.Checked Then
            _Motivo_no_reparo = String.Empty
        End If

        ' --------------------------------------------------- NOTAS ---------------------------------------

        Dim _Reparacion_Realizada = Trim(Txt_Reparacion_Realizada.Text)

        For _i = 0 To 31
            _Reparacion_Realizada = Replace(_Reparacion_Realizada, Chr(_i), " ")
        Next

        Dim _Nota_Etapa_05 As String = Txt_Nota.Text
        Dim _Chk_no_se_pudo_reparar = CInt(Chk_No_se_pudo_reparar_el_equipo.Checked) * -1

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Notas Set " & vbCrLf &
                       "Nota_Etapa_05 = '" & _Nota_Etapa_05 &
                       "',Chk_no_se_pudo_reparar = " & _Chk_no_se_pudo_reparar & vbCrLf &
                       ",Reparacion_Realizada = '" & _Reparacion_Realizada & "'" & vbCrLf &
                       ",Motivo_no_reparo = '" & _Motivo_no_reparo & "'" & vbCrLf &
                       "Where Id_Ot = " & _Id_Ot & vbCrLf & vbCrLf

        'Reparacion_Realizada, Chk_no_se_pudo_reparar, Motivo_no_reparo

        '**********************************'**********************************
        'CodTecnico_Repara

        Dim _HH As String = De_Num_a_Tx_01(_Horas_Mano_de_Obra_Repara, False, 5)


        ' ACTUALIZAR ENCABEZADO DE DOCUMENTO
        Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " &
                       "CodTecnico_Repara = '" & Cmb_Tecnico.SelectedValue & "'," & vbCrLf &
                       "Horas_Mano_de_Obra_Repara = " & _HH & vbCrLf &
                       "Where Id_Ot  = " & _Id_Ot & vbCrLf & vbCrLf


        If _Accion = Accion.Nuevo Then

            ' ACTUALIZAR ENCABEZADO DE DOCUMENTO
            Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set " &
                           "CodEstado = 'V'" & vbCrLf &
                           "Where Id_Ot  = " & _Id_Ot & vbCrLf & vbCrLf


            ' ACTUALIZAR ESTADO
            Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_Estados " &
                           "(Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " &
                           "(" & _Id_Ot & ",'R',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')" & vbCrLf & vbCrLf

        End If


        Consulta_sql += "Delete " & _Global_BaseBk & "Zw_St_OT_DetProd Where Desde_COV = 1 And Id_Ot = " & _Id_Ot & vbCrLf & vbCrLf


        For Each _Fila_Cov As DataRow In _Tbl_DetProd_Cov.Rows


            Dim _Utilizado = CInt(_Fila_Cov.Item("Utilizado")) * -1

            Dim _Desde_COV = CInt(_Fila_Cov.Item("Desde_COV")) * -1
            Dim _Idmaeedo_Cov = _Fila_Cov.Item("Idmaeedo_Cov")
            Dim _Idmaeddo_Cov = _Fila_Cov.Item("Idmaeddo_Cov")

            Dim _Codigo = _Fila_Cov.Item("Codigo")
            Dim _Descripcion = _Fila_Cov.Item("Descripcion")

            Dim _Un As Integer = _Fila_Cov.Item("Un")

            Dim _Ud = _Fila_Cov.Item("Ud")

            Dim _Cantidad = _Fila_Cov.Item("Cantidad")
            Dim _Cantidad_Utilizada = _Fila_Cov.Item("Cantidad_Utilizada")

            Dim _CantUd1 = _Fila_Cov.Item("CantUd1")
            Dim _CantUd2 = _Fila_Cov.Item("CantUd2")
            Dim _Precio = _Fila_Cov.Item("Precio")
            Dim _Neto_Linea = _Fila_Cov.Item("Neto_Linea")
            Dim _Iva_Linea = _Fila_Cov.Item("Iva_Linea")
            Dim _Total_Linea = _Fila_Cov.Item("Total_Linea")

            Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_DetProd (Id_Ot,Utilizado,Codigo,Descripcion," &
                           "Cantidad,Cantidad_Utilizada,Ud,Un," &
                           "CantUd1,CantUd2,Precio,Neto_Linea,Iva_Linea,Total_Linea,Desde_COV,Idmaeedo_Cov,Idmaeddo_Cov) Values " &
                           "(" & _Id_Ot & "," & _Utilizado & ",'" & _Codigo & "','" & _Descripcion &
                           "'," & De_Num_a_Tx_01(_Cantidad, False, 5) &
                           "," & De_Num_a_Tx_01(_Cantidad_Utilizada, False, 5) &
                           ",'" & _Ud & "'," & _Un &
                           "," & De_Num_a_Tx_01(_CantUd1, False, 5) &
                           "," & De_Num_a_Tx_01(_CantUd2, False, 5) &
                           "," & De_Num_a_Tx_01(_Precio, False, 5) &
                           "," & De_Num_a_Tx_01(_Neto_Linea, False, 5) &
                           "," & De_Num_a_Tx_01(_Iva_Linea, False, 5) &
                           "," & De_Num_a_Tx_01(_Total_Linea, False, 5) &
                           ",1," & _Idmaeedo_Cov & "," & _Idmaeddo_Cov & ")" & vbCrLf



        Next


        '**********************************'**********************************

        Fx_Fijar_Estado = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)


    End Function

    Function Fx_Fijar_Estado_No_Se_Pudo_Reparar() As Boolean

        ' --------------------------------------------------- NOTAS ---------------------------------------

        Dim _Texto = "NO SE PUDO REPARAR EL EQUIPO"

        Dim _Chk_no_se_pudo_reparar = 1

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_St_OT_Encabezado Set" & Space(1) &
                       "CodEstado = 'V'," & vbCrLf &
                       "CodTecnico_Repara = '" & Cmb_Tecnico.SelectedValue & "'," & vbCrLf &
                       "Horas_Mano_de_Obra_Repara = 0," & vbCrLf &
                       "Fecha_Cierre = Getdate()" & vbCrLf &
                       "Where Id_Ot = " & _Id_Ot & vbCrLf & vbCrLf

        Consulta_sql += "Update " & _Global_BaseBk & "Zw_St_OT_Notas Set " & vbCrLf &
                        "Nota_Etapa_05 = '" & _Texto & "'" & vbCrLf &
                        ",Motivo_no_reparo = '" & _Motivo_no_reparo & "'" & vbCrLf &
                        ",Chk_no_se_pudo_reparar = " & _Chk_no_se_pudo_reparar & vbCrLf &
                        ",Nota_Etapa_06 = '" & _Texto & "'" & vbCrLf &
                        ",Nota_Etapa_07 = '" & _Texto & "'" & vbCrLf &
                        "Where Id_Ot = " & _Id_Ot & vbCrLf & vbCrLf

        Consulta_sql += "Delete " & _Global_BaseBk & "Zw_St_OT_Estados Where Id_Ot = " & _Id_Ot & " And CodEstado in ('R','V','F')" & vbCrLf & vbCrLf

        Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_St_OT_Estados " &
                     "(Id_Ot,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario) Values " &
                     "(" & _Id_Ot & ",'R',GetDate(),'" & FUNCIONARIO & "','" & Nombre_funcionario_activo & "')" & vbCrLf & vbCrLf

        Fx_Fijar_Estado_No_Se_Pudo_Reparar = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)


    End Function

    Private Sub Frm_St_Estado_05_Reparacion_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Sub Btn_Editar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Editar.Click

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_St_OT_Estados", "Id_Ot = " & _Id_Ot & " And CodEstado = 'E'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se puede modificar el estado, ya que existe un estado posterior", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else

            _Editando_documento = True
            Sb_Marcar_Grilla()

            Beep()
            ToastNotification.Show(Me, "AHORA ES POSIBLE ACTUALIZAR EL DOCUMENTO",
                                   Btn_Editar.Image,
                                   1 * 1000, eToastGlowColor.Green,
                                   eToastPosition.MiddleCenter)

            Chk_No_se_pudo_reparar_el_equipo.Enabled = True

            Btn_Grabar.Visible = True
            Btn_Cancelar.Visible = True
            Btn_Editar.Visible = False
            Me.ControlBox = False

            Txt_Reparacion_Realizada.ReadOnly = False
            Txt_Reparacion_Realizada.BackColor = Color.White
            Txt_Reparacion_Realizada.FocusHighlightEnabled = True

            Txt_Nota.ReadOnly = False
            Txt_Nota.BackColor = Color.White
            Txt_Nota.FocusHighlightEnabled = True

            Txt_Horas_Mano_de_Obra.Enabled = True

            AddHandler Grilla.KeyDown, AddressOf Grilla_KeyDown
            AddHandler Grilla.CellEndEdit, AddressOf Grilla_CellEndEdit
            AddHandler Grilla.EditingControlShowing, AddressOf Grilla_EditingControlShowing

            AddHandler Chk_No_se_pudo_reparar_el_equipo.CheckedChanged, AddressOf Chk_No_se_pudo_reparar_el_equipo_CheckedChanged

            AddHandler Cmb_Tecnico.SelectedValueChanged, AddressOf Cmb_Tecnico_SelectedValueChanged

            Sb_Cargar_Tecnicos(Cmb_Tecnico.SelectedValue)

            Txt_Reparacion_Realizada.Focus()

        End If

        Me.Refresh()

    End Sub

    Private Sub Btn_Grabar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Grabar.Click
        If Fx_Se_Puede_Grabar() Then
            If Fx_Fijar_Estado() Then

                MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Editar",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.Close()

            End If
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub
End Class
