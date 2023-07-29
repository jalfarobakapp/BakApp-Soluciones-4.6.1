Imports DevComponents.DotNetBar
Public Class Frm_ConfTidoXModal

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tido As String
    Dim _Nudo As String
    Dim _Modalidad As String
    Dim _NombreEquipo As String
    Dim _RowFormato As DataRow
    Dim _Grabar As Boolean

    Public Property Modalidad_General As Boolean

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property RowFormato As DataRow
        Get
            Return _RowFormato
        End Get
        Set(value As DataRow)
            _RowFormato = value
        End Set
    End Property

    Public Sub New(_Tido As String, _Nudo As String, _Modalidad As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._Tido = _Tido
        Me._Nudo = _Nudo
        Me._Modalidad = _Modalidad
        Me._NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_ConfTidoXModal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Consulta_sql = "Select ZConf.*,Td.*" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad ZConf" & vbCrLf &
                       "Left Join TABTIDO Td On Td.TIDO = ZConf.TipoDoc" & vbCrLf &
                       "Where ZConf.Empresa = '" & ModEmpresa & "' And ZConf.Modalidad = '" & _Modalidad & "' And ZConf.TipoDoc = '" & _Tido & "'"

        _RowFormato = _Sql.Fx_Get_DataRow(Consulta_sql)

        Txt_Numero.Text = _Nudo
        Lbl_Tipo.Text = _Tido & " - " & _RowFormato.Item("NOTIDO")

        Txt_Nombreformato.Text = _RowFormato.Item("Nombreformato")
        Txt_NombreFormato_PDF.Text = _RowFormato.Item("NombreFormato_PDF")

        Sw_Grabar_Con_Huella.Value = _RowFormato.Item("Grabar_Con_Huella")
        Sw_Guarda_PDF_Auto.Value = _RowFormato.Item("Guardar_PDF_Auto")
        Sw_Obliga_Despacho.Value = _RowFormato.Item("Obliga_Despacho")
        Sw_Obliga_Despacho_BodDistintas.Value = _RowFormato.Item("Obliga_Despacho_BodDistintas")
        Sw_Obliga_Transportista.Value = _RowFormato.Item("Obliga_Transportista")
        Sw_Sugiere_Despacho.Value = _RowFormato.Item("Sugiere_Despacho")

        Sw_Enviar_Correo.Value = _RowFormato.Item("Enviar_Correo")
        Txt_Id_Correo.Tag = _RowFormato.Item("Id_Correo")
        Txt_Id_Correo.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Correos", "Nombre_Correo", "Id = " & Txt_Id_Correo.Tag)
        Txt_NombreFormato_Correo.Text = _RowFormato.Item("NombreFormato_Correo")

        Rdb_TimbrarXRandom.Value = _RowFormato.Item("TimbrarXRandom")

        If Modalidad_General Then
            Input_AvisoSaldoFolios.Value = NuloPorNro(_RowFormato.Item("AvisoSaldoFolios"), 10)
            Input_DiasAvisoExpiraFolio.Value = NuloPorNro(_RowFormato.Item("DiasAvisoExpiraFolio"), 14)
        Else

            '"Where Modalidad = '  '"

            Input_AvisoSaldoFolios.MinValue = 0
            Input_AvisoSaldoFolios.Value = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad",
                                                             "AvisoSaldoFolios",
                                                             "Empresa = '" & ModEmpresa & "' And Modalidad = '  ' And TipoDoc = '" & _Tido & "'")
            Input_AvisoSaldoFolios.Enabled = False
            Lbl_AvisoSaldoFolios.Enabled = False

            Input_DiasAvisoExpiraFolio.MinValue = 0
            Input_DiasAvisoExpiraFolio.Value = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad",
                                                             "DiasAvisoExpiraFolio",
                                                             "Empresa = '" & ModEmpresa & "' And Modalidad = '  ' And TipoDoc = '" & _Tido & "'")
            Input_DiasAvisoExpiraFolio.Enabled = False
            Lbl_DiasAvisoExpiraFolio.Enabled = False
        End If

        If Modalidad_General Then
            Rdb_TimbrarXRandom.Enabled = False
            Rdb_TimbrarXRandom.Value = False
            LabelX16.Text = "Timbrar eléct. siempre por Random (SOLO PARA MODALIDADES DE ESTACION)"
            LabelX16.Enabled = False

        Else

            If _Tido = "GRC" Or _Tido = "GRD" Then
                Txt_Numero.Enabled = False
                Txt_Numero.Visible = False
                LabelX3.Visible = False
                Btn_InfNumeracion.Visible = False
            End If

            Select Case _Tido
                Case "BLV", "FCV", "GDV", "FDV", "NCV", "GDP", "GDD", "GTI"
                    Rdb_TimbrarXRandom.Enabled = True
                Case Else
                    Rdb_TimbrarXRandom.Enabled = False
            End Select

        End If

    End Sub

    Private Sub Btn_BuscarFormatoImpNormal_Click(sender As Object, e As EventArgs) Handles Btn_BuscarFormatoImpNormal.Click
        Dim _Formato As String
        If Fx_Buscar_Formato(_Formato) Then
            Txt_Nombreformato.Text = _Formato
        End If
    End Sub

    Private Sub Btn_BuscarFormatoImpPDF_Click(sender As Object, e As EventArgs) Handles Btn_BuscarFormatoImpPDF.Click
        Dim _Formato As String
        If Fx_Buscar_Formato(_Formato) Then
            Txt_NombreFormato_PDF.Text = _Formato
        End If
    End Sub

    Private Sub Btn_InfNumeracion_Click(sender As Object, e As EventArgs) Handles Btn_InfNumeracion.Click

        MessageBoxEx.Show(Me, "[0000000000] = Obtiene el número mas alto grabado en el sistema y coloca el siguiente." & vbCrLf &
                              "[          ] (dejar vacio) = Obtine la númeración desde la modalidad general." & vbCrLf &
                              "[0000122354] (Ej. poner un número fijo) = toma esta numeración", "Como funciona la númeración",
                               MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Numero = Txt_Numero.Text.Trim
        Dim _Nombreformato = Txt_Nombreformato.Text
        Dim _Nombreformato_PDF = Txt_NombreFormato_PDF.Text
        Dim _Grabar_Con_Huella = Convert.ToInt32(Sw_Grabar_Con_Huella.Value)
        Dim _Sugiere_Despacho = Convert.ToInt32(Sw_Sugiere_Despacho.Value)
        Dim _Obliga_Transportista = Convert.ToInt32(Sw_Obliga_Transportista.Value)
        Dim _Obliga_Despacho = Convert.ToInt32(Sw_Obliga_Despacho.Value)
        Dim _Obliga_Despacho_BodDistintas = Convert.ToInt32(Sw_Obliga_Despacho_BodDistintas.Value)
        Dim _Guardar_PDF_Auto = Convert.ToInt32(Sw_Guarda_PDF_Auto.Value)
        Dim _Envia_Correo = Convert.ToInt32(Sw_Enviar_Correo.Value)
        Dim _Id_Correo = Txt_Id_Correo.Tag
        Dim _NombreFormato_Correo = Txt_NombreFormato_Correo.Text
        Dim _TimbrarXRandom = Convert.ToInt32(Rdb_TimbrarXRandom.Value)
        Dim _DiasAvisoExpiraFolio = Input_DiasAvisoExpiraFolio.Value
        Dim _AvisoSaldoFolios = Input_AvisoSaldoFolios.Value

        If Not String.IsNullOrEmpty(_Numero) Then

            _Numero = Fx_Rellena_ceros(_Numero, 10)

            'Revisamos si contiene numeros
            Dim result As String = String.Empty

            For Each i As Char In _Numero

                If Char.IsNumber(i) Then
                    result += CStr(i)
                End If

            Next

            Dim _UltDig = Mid(_Numero, _Numero.Length, 1)

            If String.IsNullOrEmpty(result) Or Not IsNumeric(_UltDig) Then
                MessageBoxEx.Show(Me, "La numeración: " & _Numero & " no esta permitida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End If

        Dim _Filtro_Tido As String = "('" & _Tido & "')"

        If Not String.IsNullOrEmpty(_Numero) And _Numero <> "0000000000" Then

            If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then
                _Filtro_Tido = "('GDV','GTI','GDP','GDD')"
            End If

            Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEEDO",
                                        "EMPRESA = '" & ModEmpresa & "' And TIDO In " & _Filtro_Tido & " And NUDO = '" & _Numero & "'"))

            If _Reg Then

                If MessageBoxEx.Show(Me, "El documento Nro: " & _Tido & "-" & _Nudo & " ya existe en el sistema" & vbCrLf &
                                      "¿Confirma la grabación omitiendo la advertencia?", "Validación",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Stop) <> DialogResult.Yes Then
                    Return
                End If

            End If

        End If

        Consulta_sql = String.Empty

        If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then
            Consulta_sql += "Update CONFIEST Set GDV = '" & _Numero & "' Where EMPRESA = '" & ModEmpresa & "' And MODALIDAD = '" & _Modalidad & "'" & vbCrLf
            Consulta_sql += "Update CONFIEST Set GTI = '" & _Numero & "' Where EMPRESA = '" & ModEmpresa & "' And MODALIDAD = '" & _Modalidad & "'" & vbCrLf
            Consulta_sql += "Update CONFIEST Set GDP = '" & _Numero & "' Where EMPRESA = '" & ModEmpresa & "' And MODALIDAD = '" & _Modalidad & "'" & vbCrLf
            Consulta_sql += "Update CONFIEST Set GDD = '" & _Numero & "' Where EMPRESA = '" & ModEmpresa & "' And MODALIDAD = '" & _Modalidad & "'" & vbCrLf & vbCrLf
        Else

            If Txt_Numero.Visible Then
                Consulta_sql += "Update CONFIEST Set " & _Tido & " = '" & _Numero & "' Where EMPRESA = '" & ModEmpresa & "' And MODALIDAD = '" & _Modalidad & "'" & vbCrLf & vbCrLf
            End If

        End If

        Consulta_sql += "Update " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad Set" & vbCrLf &
                   " NombreFormato = '" & Txt_Nombreformato.Text & "'" &
                   ",NombreFormato_PDF = '" & Txt_NombreFormato_PDF.Text & "'" & vbCrLf &
                   ",Grabar_Con_Huella = " & _Grabar_Con_Huella & vbCrLf &
                   ",Sugiere_Despacho = " & _Sugiere_Despacho & vbCrLf &
                   ",Obliga_Transportista = " & _Obliga_Transportista & vbCrLf &
                   ",Obliga_Despacho = " & _Obliga_Despacho & vbCrLf &
                   ",Obliga_Despacho_BodDistintas = " & _Obliga_Despacho_BodDistintas & vbCrLf &
                   ",Guardar_PDF_Auto = " & _Guardar_PDF_Auto & vbCrLf &
                   ",Enviar_Correo = " & _Envia_Correo & vbCrLf &
                   ",Id_Correo = " & _Id_Correo & vbCrLf &
                   ",NombreFormato_Correo = '" & _NombreFormato_Correo & "'" & vbCrLf &
                   ",TimbrarXRandom = '" & _TimbrarXRandom & "'" & vbCrLf &
                   ",DiasAvisoExpiraFolio = " & _DiasAvisoExpiraFolio & vbCrLf &
                   ",AvisoSaldoFolios = " & _AvisoSaldoFolios & vbCrLf &
                   "Where Empresa = '" & ModEmpresa & "' And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'" 'In " & _Filtro_Tido

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            Consulta_sql = "Select ZConf.*,Td.*" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad ZConf" & vbCrLf &
                       "Left Join TABTIDO Td On Td.TIDO = ZConf.TipoDoc" & vbCrLf &
                       "Where ZConf.Empresa = '" & ModEmpresa & "' And ZConf.Modalidad = '" & _Modalidad & "' And ZConf.TipoDoc = '" & _Tido & "'"

            _RowFormato = _Sql.Fx_Get_DataRow(Consulta_sql)

            Txt_Numero.Text = _Numero

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Grabar = True
            Me.Close()
        Else
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Function Fx_Buscar_Formato(ByRef _New_NombreFormato As String) As Boolean

        Dim _Seleccionado As Boolean
        _New_NombreFormato = String.Empty

        Dim Fm As New Frm_Seleccionar_Formato(_Tido)

        If CBool(Fm.Tbl_Formatos.Rows.Count) Then

            Fm.ShowDialog(Me)
            If Fm.Formato_Seleccionado Then
                _New_NombreFormato = Fm.Row_Formato_Seleccionado.Item("NombreFormato").ToString.Trim
                _Seleccionado = True
            End If

        Else

            MessageBoxEx.Show(Me, "No existen formatos adicionales para este documento", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        Fm.Dispose()

        Return _Seleccionado

    End Function

    Private Sub Btn_BuscarFormatoCorreo_Click(sender As Object, e As EventArgs) Handles Btn_BuscarFormatoCorreo.Click
        Dim _Formato As String
        If Fx_Buscar_Formato(_Formato) Then
            Txt_NombreFormato_Correo.Text = _Formato
        End If
    End Sub

    Private Sub Btn_BuscarCorreo_Click(sender As Object, e As EventArgs) Handles Btn_BuscarCorreo.Click

        Dim Fm As New Frm_Correos_SMTP
        Fm.Pro_Seleccionar = True
        Fm.ShowDialog(Me)

        If Fm.Pro_Seleccionado Then
            Txt_Id_Correo.Tag = Fm.Pro_Row_Fila_Seleccionada.Item("Id")
            Txt_Id_Correo.Text = Fm.Pro_Row_Fila_Seleccionada.Item("Nombre_Correo")
        End If
        Fm.Dispose()

    End Sub

    Private Sub BuscarFormatoImpNormal_Quitar_Click(sender As Object, e As EventArgs) Handles BuscarFormatoImpNormal_Quitar.Click
        If MessageBoxEx.Show(Me, "Confirma quitar el formato", "Quitar formato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Txt_Nombreformato.Text = String.Empty
        End If
    End Sub

    Private Sub Btn_BuscarFormatoImpPDF_Quitar_Click(sender As Object, e As EventArgs) Handles Btn_BuscarFormatoImpPDF_Quitar.Click
        If MessageBoxEx.Show(Me, "Confirma quitar el formato", "Quitar formato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Txt_NombreFormato_PDF.Text = String.Empty
        End If
    End Sub

    Private Sub Btn_BuscarCorreo_Quitar_Click(sender As Object, e As EventArgs) Handles Btn_BuscarCorreo_Quitar.Click
        If MessageBoxEx.Show(Me, "Confirma quitar el correo", "Quitar correo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Txt_Id_Correo.Tag = 0
            Txt_Id_Correo.Text = String.Empty
        End If
    End Sub

    Private Sub Btn_BuscarFormatoCorreo_Quitar_Click(sender As Object, e As EventArgs) Handles Btn_BuscarFormatoCorreo_Quitar.Click
        If MessageBoxEx.Show(Me, "Confirma quitar el formato para archivos adjuntos", "Quitar formato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Txt_NombreFormato_Correo.Text = String.Empty
        End If
    End Sub

End Class
