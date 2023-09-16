Imports DevComponents.DotNetBar

Public Class Frm_St_DetIngreso

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowProducto As DataRow
    Dim _Row_Doc_Garantia As DataRow

    Public Property Cl_OrdenServicio As Cl_OrdenServicio
    Public Property Grabar As Boolean
    Public Property Codigo As String
    Public Property Descripcion As String
    Public Property Editar As Boolean

    Dim _Id_Ot As Integer

    Dim _Row0 As DataRow
    Dim _Row3 As DataRow
    Dim _Row6 As DataRow

    Public Sub New(_Id_Ot As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Ot = _Id_Ot

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_St_DetIngreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Btn_Eliminar.Visible = Editar
        Input_Cantidad.Value = 0

        Consulta_sql = My.Resources.Recursos_Info_Producto.SQLQuery_DatosDelProducto
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Codigo)

        _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

        Lbl_Marca.Text = _RowProducto.Item("Marca")
        Lbl_Rubro.Text = _RowProducto.Item("Rubro")
        Lbl_Super_Familia.Text = _RowProducto.Item("SuperFamilia")
        Lbl_Familia.Text = _RowProducto.Item("Familia")
        Lbl_Sub_Familia.Text = _RowProducto.Item("SubFamilia")

        Lbl_Clas_Libre.Text = _Sql.Fx_Trae_Dato("TABCARAC", "NOKOCARAC",
                                      "KOTABLA = 'CLALIBPR' and KOCARAC = '" & _RowProducto.Item("CLALIBPR") & "'")

        Txt_Producto.Text = _Codigo & " - " & _Descripcion

        If Editar Then

            _Row0 = Cl_OrdenServicio.Fx_Trae_Datarow(_Id_Ot, 0) ' Sub-Orden
            _Row3 = Cl_OrdenServicio.Fx_Trae_Datarow(_Id_Ot, 3) ' Notas
            _Row6 = Cl_OrdenServicio.Fx_Trae_Datarow(_Id_Ot, 6) ' Garantias

            Txt_NroSerie.Text = _Row0.Item("NroSerie")
            Chk_Serv_Domicilio.Checked = _Row0.Item("Chk_Serv_Domicilio")
            Chk_Serv_Reparacion_Stock.Checked = _Row0.Item("Chk_Serv_Reparacion_Stock")
            Chk_Serv_Mantenimiento_Correctivo.Checked = _Row0.Item("Chk_Serv_Mantenimiento_Correctivo")
            Chk_Serv_Presupuesto_Pre_Aprobado.Checked = _Row0.Item("Chk_Serv_Presupuesto_Pre_Aprobado")
            Chk_Serv_Recoleccion.Checked = _Row0.Item("Chk_Serv_Recoleccion")
            Chk_Serv_Mantenimiento_Preventivo.Checked = _Row0.Item("Chk_Serv_Mantenimiento_Preventivo")
            Chk_Serv_Garantia.Checked = _Row0.Item("Chk_Serv_Garantia")
            Chk_Serv_Demostracion_Maquina.Checked = _Row0.Item("Chk_Serv_Demostracion_Maquina")
            Txt_Defecto_segun_cliente.Text = _Row3.Item("Defecto_segun_cliente")
            Txt_Nota_Etapa_01.Text = _Row3.Item("Nota_Etapa_01")
            Input_Cantidad.Value = _Row0.Item("Cantidad")

        End If

        'Input_Cantidad.Value = 1
        'Input_Cantidad.Enabled = False

        Btn_Direccion_Servicio.Enabled = Chk_Serv_Domicilio.Checked

        Me.ActiveControl = Txt_NroSerie
        'LabelX12.Visible = False
        'Input_Cantidad.Visible = False

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If Chk_SinNroSerie.Checked And Input_Cantidad.Value <= 0 Then
            MessageBoxEx.Show(Me, "Debe ingresar la cantidad de piezas a reparar", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Input_Cantidad.Focus()
            Return
        End If


        If Not Chk_Serv_Domicilio.Checked _
           And Not Chk_Serv_Reparacion_Stock.Checked _
           And Not Chk_Serv_Mantenimiento_Correctivo.Checked _
           And Not Chk_Serv_Presupuesto_Pre_Aprobado.Checked _
           And Not Chk_Serv_Recoleccion.Checked _
           And Not Chk_Serv_Mantenimiento_Preventivo.Checked _
           And Not Chk_Serv_Garantia.Checked _
           And Not Chk_Serv_Demostracion_Maquina.Checked Then

            MessageBoxEx.Show(Me, "Debe marcar por lo menos un Tipo de Reparación", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        If Not Chk_SinNroSerie.Checked AndAlso Input_Cantidad.Value > 1 And Not String.IsNullOrEmpty(Txt_NroSerie.Text.Trim) Then
            MessageBoxEx.Show(Me, "No puede agregar un número de serie cuando la cantidad es mayor que 1." & vbCrLf & vbCrLf &
                "Opciones:" & vbCrLf & vbCrLf &
                "1.- Agregar producto con cantidad igual a 1 e ingresar su número de serie" & vbCrLf &
                "2.- Agregar productos con cantidad mayor a 1, pero el número de serie debe quedar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Input_Cantidad.Focus()
            Return
        End If

        If Not Chk_SinNroSerie.Checked Then
            Input_Cantidad.Value = 1
        End If

        If Input_Cantidad.Value = 1 And String.IsNullOrEmpty(Txt_NroSerie.Text.Trim) Then
            MessageBoxEx.Show(Me, "FALTA DEL NUMERO DE SERIE", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_NroSerie.Focus()
            Return
        End If

        For Each _Fl As DataRow In Cl_OrdenServicio.DsDocumento.Tables(0).Rows

            If Input_Cantidad.Value = 1 AndAlso Codigo = _Fl.Item("Codigo").ToString.Trim And _Fl.Item("NroSerie").ToString.Trim = Txt_NroSerie.Text.Trim Then
                MessageBoxEx.Show(Me, "ESTE PRODUCTO Y NUMERO DE SERIE YA SE ENCUENTRA EN LA LISTA", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_NroSerie.Focus()
                Return
            End If

        Next

        If String.IsNullOrEmpty(Txt_Defecto_segun_cliente.Text.Trim) Then
            MessageBoxEx.Show(Me, "DEBE INGRESAR EL DEFECTO SEGUN EL CLIENTE", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Defecto_segun_cliente.Focus()
            Return
        End If

        If Chk_Serv_Garantia.Checked Then

            _Row6 = Cl_OrdenServicio.Fx_Trae_Datarow(_Id_Ot, 6)

            If IsNothing(_Row6) Then
                MessageBoxEx.Show(Me, "FALTA ADJUNTAR DOCUMENTO DE GARANTIA", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        Else

            Cl_OrdenServicio.Fx_Borrar_Fila(_Id_Ot, 6)

        End If


        Dim _Existe As Boolean

        For Each _Fila As DataRow In Cl_OrdenServicio.DsDocumento.Tables(0).Rows
            If _Fila.Item("Id_Ot") = _Id_Ot Then
                _Existe = True
                Exit For
            End If
        Next

        If Not _Existe Then
            Cl_OrdenServicio.Sb_New_OT_Agregar_Filas(_Id_Ot)
        End If

        If Editar Then

            _Row0.Item("NroSerie") = Txt_NroSerie.Text
            _Row0.Item("Chk_Serv_Domicilio") = Chk_Serv_Domicilio.Checked
            _Row0.Item("Chk_Serv_Reparacion_Stock") = Chk_Serv_Reparacion_Stock.Checked
            _Row0.Item("Chk_Serv_Mantenimiento_Correctivo") = Chk_Serv_Mantenimiento_Correctivo.Checked
            _Row0.Item("Chk_Serv_Presupuesto_Pre_Aprobado") = Chk_Serv_Presupuesto_Pre_Aprobado.Checked
            _Row0.Item("Chk_Serv_Recoleccion") = Chk_Serv_Recoleccion.Checked
            _Row0.Item("Chk_Serv_Mantenimiento_Preventivo") = Chk_Serv_Mantenimiento_Preventivo.Checked
            _Row0.Item("Chk_Serv_Garantia") = Chk_Serv_Garantia.Checked
            _Row0.Item("Chk_Serv_Demostracion_Maquina") = Chk_Serv_Demostracion_Maquina.Checked
            _Row3.Item("Defecto_segun_cliente") = Txt_Defecto_segun_cliente.Text
            _Row3.Item("Nota_Etapa_01") = Txt_Nota_Etapa_01.Text

        Else

            If Chk_Serv_Garantia.Checked Then
                If Not Fx_Tiene_Permiso(Me, "Stec0005") Then
                    Return
                End If
            End If

            Cl_OrdenServicio.Sb_Agregar_Producto(_Id_Ot,
                                                 _Codigo,
                                                 _Descripcion,
                                                 Txt_NroSerie.Text,
                                                 Chk_Serv_Domicilio.Checked,
                                                 Chk_Serv_Reparacion_Stock.Checked,
                                                 Chk_Serv_Mantenimiento_Correctivo.Checked,
                                                 Chk_Serv_Presupuesto_Pre_Aprobado.Checked,
                                                 Chk_Serv_Recoleccion.Checked,
                                                 Chk_Serv_Mantenimiento_Preventivo.Checked,
                                                 Chk_Serv_Garantia.Checked,
                                                 Chk_Serv_Demostracion_Maquina.Checked,
                                                 Txt_Defecto_segun_cliente.Text.Trim,
                                                 Txt_Nota_Etapa_01.Text.Trim,
                                                 Input_Cantidad.Value)

        End If

        'Dim Fm As New Frm_St_Estado_01_Ingreso_Check_In(_Id_Ot, Frm_St_Estado_01_Ingreso_Check_In.Accion.Nuevo)
        'Fm.Pro_DsDocumento2 = Cl_OrdenServicio.DsDocumento
        ''Fm.Pro_Imagenes_32x32 = Imagenes_32x32
        'Fm.ShowDialog(Me)
        'Fm.Dispose()

        Grabar = True
        Me.Close()

    End Sub

    Private Sub Txt_Producto_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Producto.ButtonCustomClick

        Dim _Descripcion As String = Descripcion

        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Ingrese la descripción del producto", "Editar descripción",
                                              _Descripcion, False, _Tipo_Mayus_Minus.Mayusculas, 50, True, _Tipo_Imagen.Texto)

        If Not _Aceptar Then
            Return
        End If

        Descripcion = _Descripcion

        Txt_Producto.Text = _Codigo & " - " & Descripcion

    End Sub

    Private Sub Frm_St_DetIngreso_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar esta Sub-Orden?", "Eliminar Sub-Orden",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If Cl_OrdenServicio.Fx_Eliminar_SubOrden(_Id_Ot) Then
                Me.Close()
            End If
        End If

    End Sub

    Private Sub Btn_Documento_Garantia_Click(sender As Object, e As EventArgs) Handles Btn_Documento_Garantia.Click
        ShowContextMenu(Menu_Contextual_Documentos_Grarantia)
    End Sub

    Private Sub Btn_Documento_Sistema_Click(sender As Object, e As EventArgs) Handles Btn_Documento_Sistema.Click

        Dim _RowDocumento = Fx_Garantia_Traer_Documento()

        If Not (_RowDocumento Is Nothing) Then

            Dim _Idmaeedo = _RowDocumento.Item("IDMAEEDO")

            Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEDDO", "IDMAEEDO = " & _Idmaeedo & " And KOPRCT = '" & Txt_Producto.Tag & "'")

            If CBool(_Reg) Then

                _Row_Doc_Garantia = _RowDocumento

                Cl_OrdenServicio.Sb_Agregar_Garantia(_Id_Ot,
                                                     _Row_Doc_Garantia.Item("IDMAEEDO"),
                                                     _Row_Doc_Garantia.Item("TIDO"),
                                                     _Row_Doc_Garantia.Item("NUDO"), _Row_Doc_Garantia.Item("FEEMDO"), False)

                MessageBoxEx.Show(Me, "Documento adjuntado correctamente", "Garantia",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)


            Else
                MessageBoxEx.Show(Me, "El producto " & Txt_Producto.Text & " no se encuentra en el documento de referencia para la garantía",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub

    Function Fx_Garantia_Traer_Documento() As DataRow

        Dim Fm As New Frm_BusquedaDocumento_Filtro(False)
        Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, "FCV", "Where TIDO IN ('FCV','BLV')")
        Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado

        If Not (_Row_Doc_Garantia Is Nothing) Then
            Fm.Pro_Sql_Filtro_Otro_Filtro = "And IDMAEEDO <> " & _Row_Doc_Garantia.Item("IDMAEEDO")
        End If

        Fm.Pro_Row_Entidad = Cl_OrdenServicio.RowEntidad
        Fm.ShowDialog(Me)
        Fx_Garantia_Traer_Documento = Fm.Pro_Row_Documento_Seleccionado
        Fm.Dispose()

    End Function

    Private Sub Btn_Doc_Externo_Boleta_Click(sender As Object, e As EventArgs) Handles Btn_Doc_Externo_Boleta.Click
        Sb_Incorporar_Numero_Documento_Externo("Boleta")
    End Sub

    Private Sub Btn_Doc_Externo_Factura_Click(sender As Object, e As EventArgs) Handles Btn_Doc_Externo_Factura.Click
        Sb_Incorporar_Numero_Documento_Externo("Factura")
    End Sub

    Sub Sb_Incorporar_Numero_Documento_Externo(_Tipo_Documento As String)

        Dim _Tido As String = String.Empty

        Select Case _Tipo_Documento
            Case "Boleta"
                _Tido = "BLV"
            Case "Factura"
                _Tido = "FCV"
        End Select

        Dim _Aceptado As Boolean
        Dim _Nro_Documento As String

        _Row6 = Cl_OrdenServicio.Fx_Trae_Datarow(_Id_Ot, 6) ' Garantias

        If Not IsNothing(_Row6) Then
            _Nro_Documento = _Row6.Item("Nudo")
        End If

        _Aceptado = InputBox_Bk(Me, "Escriba el número de la " & _Tipo_Documento,
                         _Tipo_Documento & " del cliente",
                         _Nro_Documento,
                         False, _Tipo_Mayus_Minus.Mayusculas, 15,
                         True, _Tipo_Imagen.Texto, False, _Tipo_Caracter.Solo_Numeros_Enteros, False)

        If _Aceptado Then

            If IsNothing(_Row6) Then
                Cl_OrdenServicio.Sb_Agregar_Garantia(_Id_Ot, 0, _Tido, _Nro_Documento, Date.Now, True)
            Else
                _Row6.Item("Idmaeedo") = 0
                _Row6.Item("Tido") = _Tido
                _Row6.Item("Nudo") = _Nro_Documento
                _Row6.Item("Documento_Externo") = True
            End If

        End If

    End Sub

    Private Sub Chk_Serv_Garantia_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Serv_Garantia.CheckedChanged
        Btn_Documento_Garantia.Enabled = Chk_Serv_Garantia.Checked
    End Sub

    Private Sub Btn_Direccion_Servicio_Click(sender As Object, e As EventArgs) Handles Btn_Direccion_Servicio.Click

        Dim _Row_Encabezado = Cl_OrdenServicio.Fx_Trae_Datarow(_Id_Ot, 0)

        Dim Fm As New Frm_St_Documento_Dir_Serv_Domicilio
        Fm.Row_Encabezado = _Row_Encabezado
        Fm.Pro_Editar = Chk_Serv_Domicilio.Enabled
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Chk_Serv_Domicilio_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Serv_Domicilio.CheckedChanged
        Btn_Direccion_Servicio.Enabled = Chk_Serv_Domicilio.Checked
    End Sub

    Private Sub Chk_SinNroSerie_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_SinNroSerie.CheckedChanged

        LabelX12.Visible =  Chk_SinNroSerie.Checked
        Input_Cantidad.Visible = Chk_SinNroSerie.Checked
        Txt_NroSerie.Enabled = Not Chk_SinNroSerie.Checked

        If Chk_SinNroSerie.Checked Then
            Input_Cantidad.Value = 0
            Txt_NroSerie.Text = "S/N"
        Else
            If Txt_NroSerie.Text = "S/N" Then
                Txt_NroSerie.Text = String.Empty
            End If
            Txt_NroSerie.Focus()
        End If

    End Sub

End Class
