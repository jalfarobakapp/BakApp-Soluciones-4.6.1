﻿Imports BkSpecialPrograms.LsValiciones
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports MySql.Data.Authentication

Public Class Frm_Cantidades_Ud_Disintas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim Fr_Alerta_Stock As DevComponents.DotNetBar.Balloon

    Dim _Bodega As String
    Dim _Codigo As String
    Dim _Rtu As Double
    Dim _Rtu_Ori As Double
    Dim _UnTrans As Integer
    Dim _Cantidad_Original As Double
    Dim _Tido As String

    Private _NecesitaPermisoCambiarRTU As Boolean = False

    Dim _Fila As DataGridViewRow
    Dim _RowProducto As DataRow

    Dim _ValidarApiWMSBosOne = False
    Public Property RevisarRtuVariable As Boolean
    Public Property RtuVariable As Boolean
    Public Property Cantidad_Ud1 As Double
    Public Property Cantidad_Ud2 As Double
    Public Property Aceptado As Boolean
    Public Property DesdeContenedor As Boolean
    Public Property IdCont As Integer

    Public Sub New(Fila As DataGridViewRow, _Tido As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Tido = _Tido
        _Fila = Fila

        _Bodega = _Fila.Cells("Bodega").Value
        _Codigo = _Fila.Cells("Codigo").Value
        _Rtu = _Fila.Cells("Rtu").Value
        _Rtu_Ori = _Fila.Cells("Rtu").Value
        _UnTrans = _Fila.Cells("UnTrans").Value

        Consulta_sql = "Select Top 1 KOPR,NOKOPR,RLUD,DIVISIBLE,DIVISIBLE2,NMARCA From MAEPR Where KOPR = '" & _Codigo & "'"
        _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

        Fr_Alerta_Stock = New AlertCustom(_Codigo, _UnTrans)

        If Global_Thema = Enum_Themas.Oscuro Then
            TxtCantUD1.FocusHighlightEnabled = False
            TxtCantUD2.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_SolicitudDeCompraCantProductos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AddHandler Chk_DesacRazTransf.CheckedChanged, AddressOf Chk_DesacRazTransf_CheckedChanged

        TxtRTU.Text = _Rtu

        If RevisarRtuVariable Then

            If _Fila.Cells("Nmarca").Value = "¡" Then

                Dim _Cl_Producto As Cl_Producto = New Cl_Producto()
                _Cl_Producto.Fx_Llenar_Zw_Producto(_Codigo)

                RtuVariable = True

                'If Not _Cl_Producto.Zw_Producto.RtuXWms Then

                '    Chk_RtuVariable.Checked = RtuVariable

                '    If Not RtuVariable AndAlso Not CBool(Cantidad_Ud1) AndAlso Not CBool(Cantidad_Ud2) Then
                '        Chk_RtuVariable.Checked = True
                '    End If

                'End If

                _ValidarApiWMSBosOne = True

                Dim _Habpesovariable As Boolean = CBool(_Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "Valor",
                                                                    "Tabla = 'BODONE_CONF' And CodigoTabla = 'Habpesovariable'", True, False, 0))

                If Not _Habpesovariable Then
                    _ValidarApiWMSBosOne = False
                End If

                'If RtuVariable And Chk_DesacRazTransf.Checked Then
                '    Chk_DesacRazTransf.Enabled = False
                'End If

            End If

        End If

        Img_RtuAPI.Visible = _ValidarApiWMSBosOne
        'TxtCantUD1.Enabled = Chk_DesacRazTransf.Checked

        'Chk_RtuVariable.Enabled = (_Fila.Cells("Nmarca").Value = "¡")

        If Chk_DesacRazTransf.Checked Then
            Label3.Text = "R.T.U.  (" & _Rtu & ")"
        End If

        If _Rtu = 1 Then TxtCantUD2.Enabled = False

        If _UnTrans = 1 Then
            TxtCantUD1.Text = Cantidad_Ud1
            TxtCantUD2.Text = Math.Round(Cantidad_Ud1 / _Rtu, 3)
            Me.ActiveControl = TxtCantUD1
        Else
            TxtCantUD2.Text = Cantidad_Ud2
            TxtCantUD1.Text = Math.Round(Cantidad_Ud2 * _Rtu, 3)
            Me.ActiveControl = TxtCantUD2
        End If

        If Not TxtCantUD1.Enabled Then
            TxtCantUD2.Text = Cantidad_Ud2
            TxtCantUD1.Text = Math.Round(Cantidad_Ud2 * _Rtu, 3)
            Me.ActiveControl = TxtCantUD2
        End If

        If RtuVariable Then
            TxtCantUD1.Text = Math.Round(Cantidad_Ud1, 3)
            TxtCantUD2.Text = Math.Round(Cantidad_Ud2, 3)
        End If

        _Cantidad_Original = _Fila.Cells("CantUd" & _UnTrans & "_Dori").Value

        TxtCantUD1.Tag = _Cantidad_Ud1
        TxtCantUD2.Tag = _Cantidad_Ud2

        Sb_Ver_Alerta_Stock()

        If _ValidarApiWMSBosOne And Not Chk_DesacRazTransf.Checked Then
            Sb_Rtu_WMSBodOne()
        End If

        Me.Refresh()

    End Sub

    Sub Sb_Rtu_WMSBodOne()

        'warning.png
        Dim _Icono As Image

        Dim _Imagenes_List As ImageList
        If Global_Thema = Enum_Themas.Oscuro Then
            _Imagenes_List = Imagenes_16x16_Dark
        Else
            _Imagenes_List = Imagenes_16x16
        End If

        _Icono = Nothing

        Dim _BodegaRevWMS As String = _Bodega

        '_NecesitaPermisoCambiarRTU = True
        'Chk_RtuVariable.Enabled = False
        If RutEmpresa = "77988832-0" Then
            Try
                Dim EmpSucBod As String = Mod_Empresa & ";" & Mod_Sucursal & ";" & _Bodega

                Consulta_sql = "Select Tabla, DescripcionTabla, CodigoTabla, NombreTabla" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                               "Where Tabla = 'SEA2MEATGARDEN' And NombreTabla = '" & EmpSucBod & "'"
                Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row) Then
                    Dim _ESB = _Row.Item("CodigoTabla").ToString.Split(";"c)
                    '_Empresa = _ESB(0).Trim
                    '_Sucursal = _ESB(1).Trim
                    _BodegaRevWMS = _ESB(2).Trim
                End If
            Catch ex As Exception
                _BodegaRevWMS = _Bodega
            End Try
        End If

        ' Llama a la función para encontrar el producto en las bodegas
        Dim RtuBodegas As LsValiciones.Mensajes = Fx_Consultar_RTU_xBodegas(_BodegaRevWMS, _Codigo)

        ' Muestra el resultado final en el textbox e impide la edición de Cantidad 1
        If RtuBodegas.EsCorrecto Then

            TxtRTU.Text = RtuBodegas.Resultado
            _Rtu = De_Txt_a_Num_01(RtuBodegas.Resultado, 5)
            _Rtu_Ori = _Rtu
            Label3.Text = "R.T.U.  (" & _Rtu & ")"
            Chk_DesacRazTransf.Checked = False
            _Fila.Cells("Rtu").Value = _Rtu
            Me.ActiveControl = TxtCantUD2

            _Icono = _Imagenes_List.Images.Item("ok.png")

        Else

            _Icono = _Imagenes_List.Images.Item("warning.png")

        End If

        Img_RtuAPI.Image = _Icono

    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click

        Fr_Alerta_Stock.Close()

        Dim _Oferta = _Fila.Cells("Oferta").Value
        Dim _Padre_Oferta = _Fila.Cells("Padre_Oferta").Value
        Dim _Cantidad_Oferta = _Fila.Cells("Cantidad_Oferta").Value
        Dim _Aplica_Oferta = _Fila.Cells("Aplica_Oferta").Value
        Dim _Rtu = _Fila.Cells("Rtu").Value

        If _Cantidad_Ud1 <> 0 Then

            If Fx_Solo_Enteros(_Cantidad_Ud1, _RowProducto.Item("DIVISIBLE")) Then
                MessageBoxEx.Show(Me, "Primera Unidad solo permite cantidades enteras", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtCantUD1.Focus()
                Return
            End If

            If Fx_Solo_Enteros(_Cantidad_Ud2, _RowProducto.Item("DIVISIBLE2")) Then
                MessageBoxEx.Show(Me, "Segunda Unidad solo permite cantidades enteras", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                TxtCantUD2.Focus()
                Return
            End If

        End If

        If _Aplica_Oferta Then

            Dim _Cantidad As Double
            Dim _Txt As TextBoxX

            If _UnTrans = 1 Then
                _Cantidad = _Cantidad_Ud1 / _Cantidad_Oferta
                _Txt = TxtCantUD1
            Else
                _Cantidad = (_Cantidad_Ud2 * _Rtu) / _Cantidad_Oferta
                _Txt = TxtCantUD2
            End If

            Dim _Volver As Boolean

            If _Cantidad = 0 Then

                MessageBoxEx.Show(Me, "La cantidad no puede ser 0 cuando el producto es una oferta", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Volver = True

            End If

            If IsNumeric(_Cantidad) Then

                If CInt(_Cantidad) <> _Cantidad Then

                    MessageBoxEx.Show(Me, "La cantidad debe ser multiplo de " & _Cantidad_Oferta, "Validación, producto oferta",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    _Volver = True

                End If

            End If

            Dim _Idmaeddo_Dori As Integer = _Fila.Cells("Idmaeddo_Dori").Value

            If _Txt.Text > _Cantidad_Original And CBool(_Idmaeddo_Dori) Then
                MessageBoxEx.Show(Me, "La cantidad no puede ser mayor a " & FormatNumber(_Cantidad_Original, 0),
                                  "Validación, producto oferta", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Volver = True
            End If

            If _Volver Then

                _Cantidad_Ud1 = TxtCantUD1.Tag
                _Cantidad_Ud2 = TxtCantUD2.Tag

                TxtCantUD1.Text = TxtCantUD1.Tag
                TxtCantUD2.Text = TxtCantUD2.Tag

                _Txt.Focus()

                Return

            End If

        End If

        _Aceptado = True
        'RtuVariable = Chk_RtuVariable.Checked

        Me.Close()

    End Sub

    Private Sub TxtCantUD2_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCantUD2.KeyDown
        If e.KeyValue = Keys.Up Then
            e.Handled = True
            TxtCantUD1.Focus()
        End If
    End Sub

    Private Sub TxtCantUD2_Leave(sender As System.Object, e As System.EventArgs) Handles TxtCantUD2.Leave
        TxtCantUD2.Text = Math.Round(_Cantidad_Ud2, 3)
    End Sub

    Private Sub TxtCantUD1_Leave(sender As System.Object, e As System.EventArgs) Handles TxtCantUD1.Leave
        TxtCantUD1.Text = Math.Round(_Cantidad_Ud1, 3)
    End Sub

    Private Sub TxtCantUD1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCantUD1.KeyDown
        If e.KeyValue = Keys.Down Then
            e.Handled = True
            TxtCantUD2.Focus()
        End If
    End Sub

    Private Sub TxtCantUD1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantUD1.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            Dim _C1 As Double = Math.Round(De_Txt_a_Num_01(TxtCantUD1.Text, 5), 5)

            If Chk_DesacRazTransf.Checked Then

                _Cantidad_Ud1 = _C1

                Try
                    TxtRTU.Text = Math.Round(_Cantidad_Ud1 / _Cantidad_Ud2, 5)
                Catch ex As Exception
                    TxtRTU.Text = 0
                End Try

                TxtCantUD2.Focus()

            Else

                e.Handled = True

                If _C1 <> _Cantidad_Ud1 Then
                    _Cantidad_Ud1 = _C1
                    _Cantidad_Ud2 = Math.Round(_Cantidad_Ud1 / _Rtu, 5)

                    TxtCantUD2.Text = Math.Round(_Cantidad_Ud2, 3)
                End If

                BtnAceptar.Focus()

            End If

        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If

    End Sub

    Private Sub TxtCantUD2_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantUD2.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            Dim _C2 As Double = De_Txt_a_Num_01(TxtCantUD2.Text, 5)

            If Chk_DesacRazTransf.Checked Then

                _Cantidad_Ud2 = _C2

                Try
                    TxtRTU.Text = Math.Round(_Cantidad_Ud1 / _Cantidad_Ud2, 5)
                Catch ex As Exception
                    TxtRTU.Text = 0
                End Try

            Else

                e.Handled = True

                If _C2 <> _Cantidad_Ud2 Then
                    _Cantidad_Ud2 = _C2
                    _Cantidad_Ud1 = Math.Round(_Cantidad_Ud2 * _Rtu, 5)
                    TxtCantUD1.Text = Math.Round(_Cantidad_Ud1, 3)
                End If

            End If

            BtnAceptar.Focus()

        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If

    End Sub

    Private Sub TxtCantUD1_Enter(sender As System.Object, e As System.EventArgs) Handles TxtCantUD1.Enter
        _UnTrans = 1
        TxtCantUD1.Text = Math.Round(_Cantidad_Ud1, 5)
    End Sub

    Private Sub TxtCantUD2_Enter(sender As System.Object, e As System.EventArgs) Handles TxtCantUD2.Enter
        _UnTrans = 2
        TxtCantUD2.Text = Math.Round(_Cantidad_Ud2, 5)
    End Sub

    Private Sub Btn_Ver_Stock_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_Stock.Click
        Sb_Ver_Alerta_Stock()
    End Sub

    Sub Sb_Ver_Alerta_Stock()

        If Fr_Alerta_Stock.Visible Then
            Fr_Alerta_Stock.Close()
        End If

        Fr_Alerta_Stock = New AlertCustom(_Codigo, _UnTrans)
        CType(Fr_Alerta_Stock, AlertCustom).Tido = _Tido
        ShowLoadAlert(Fr_Alerta_Stock, Me,,,, DesdeContenedor, IdCont)

    End Sub

    ''' <summary>
    ''' Itera sobre las bodegas para consultar la API hasta obtener una respuesta válida
    ''' </summary>
    ''' <param name="apiUrl">URL de la API</param>
    ''' <param name="authorizationToken">Token de autorización</param>
    ''' <param name="_Codigo">SKU del producto</param>
    ''' <returns>Un objeto de tipo Mensajes con el resultado de la operación</returns>
    Private Function Fx_Consultar_RTU_xBodegas(_Bodega As String, _Codigo As String) As LsValiciones.Mensajes

        Dim mensaje As LsValiciones.Mensajes

        Try

            Dim apiUrl As String = "http://190.151.101.156:82/BodONEWSR/Api/ConsultarRTU"
            Dim authorizationToken As String = "Token 06389de2-5ed5-11ed-9b6a-0242ac120002"
            Dim bodegas As String = Fx_Bodegas(_Bodega) '= "1, 2, 3, 4, 5, 8, 10, 41, 42, 21, 22, 23, 24, 25, 26"

            Dim apiClient As New Cl_Api_BodOne()


            ' Lista de bodegas a iterar obtenida del TextBox
            Dim bodegasArray As Integer() = bodegas.Split(",").Select(Function(b) Convert.ToInt32(b.Trim())).ToArray()

            ' Itera sobre las bodegas definidas
            For Each bodega In bodegasArray
                Dim requestBody As New Dictionary(Of String, Object) From {
                {"SKU", _Codigo},
                {"Bodega", bodega}
            }

                ' Realiza la consulta a la API
                mensaje = apiClient.Post(Of Decimal)(apiUrl, requestBody, authorizationToken)

                ' Si se obtiene un resultado válido, detiene la iteración
                If mensaje.EsCorrecto AndAlso mensaje.Resultado IsNot Nothing AndAlso Val(mensaje.Resultado) <> -1 Then
                    mensaje.Detalle = $"Consulta exitosa en la Bodega {bodega} WMS."
                    mensaje.Mensaje = "Se encontró un resultado válido."
                    Return mensaje
                End If
            Next

            ' Si no se encontró un resultado válido, retorna un mensaje de error
            mensaje = New LsValiciones.Mensajes With {
            .EsCorrecto = False,
            .Detalle = "No se encontró un resultado válido después de consultar todas las bodegas.",
            .Mensaje = "Consulta fallida en todas las bodegas.",
            .Icono = MessageBoxIcon.Warning
        }

        Catch ex As Exception
            mensaje = New LsValiciones.Mensajes With {
            .EsCorrecto = False,
            .Detalle = "Error inesperado",
            .Mensaje = ex.Message,
            .Icono = MessageBoxIcon.Stop}
        End Try

        Return mensaje
    End Function

    Function Fx_Bodegas(_Bodega As String) As String

        Dim _Bodegas As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", "NombreTabla",
                                                   "Tabla = 'BODONE_BOD' And CodigoTabla = '" & _Bodega & "'")

        Return _Bodegas

        'Select Case _Bodega
        '    Case "001"
        '        Return "1, 2, 3, 4, 5, 8, 10"
        '    Case "004"
        '        Return "41, 42"
        '    Case "006"
        '        Return "21, 22, 23, 24, 25, 26"
        'End Select

    End Function

    Private Sub Chk_DesacRazTransf_CheckedChanged(sender As Object, e As EventArgs) 'Handles Chk_RtuVariable.CheckedChanged

        TxtCantUD1.Enabled = Chk_DesacRazTransf.Checked

        If Chk_DesacRazTransf.Checked Then
            TxtCantUD1.Focus()
        Else
            TxtCantUD2.Focus()
            _Rtu = _Rtu_Ori
            TxtRTU.Text = _Rtu
            TxtCantUD2.Text = 0
            Dim eKeyPress As New KeyPressEventArgs(Convert.ToChar(Keys.Return))
            TxtCantUD2_KeyPress(TxtCantUD2, eKeyPress)
        End If

    End Sub

End Class
