Imports System.Xml.XPath
Imports DevComponents.DotNetBar

Public Class Frm_Folios_Caf

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _AmbienteCertificacion As Integer

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim _Arr_Tido(,) As String = {{"", "Ver todas..."},
                                     {"33", "FACTURA"},
                                     {"34", "FACTURA EXENTA"},
                                     {"39", "BOLETA"},
                                     {"52", "GUIA DE DESPACHO"},
                                     {"46", "FACTURA DE COMPRA"},
                                     {"56", "NOTA DE DEBITO"},
                                     {"61", "NOTA DE CREDITO"}}
        Sb_Llenar_Combos(_Arr_Tido, Cmb_TipoDoc)
        Cmb_TipoDoc.SelectedValue = "33"

        'Return "FACTURA" 33
        'Return "FACTURA EXENTA" 34
        'Return "BOLETA" 39
        'Return "GUIA DE DESPACHO" 52
        'Return "FACTURA DE COMPRA" 46
        'Return "NOTA DE DEBITO" 56
        'Return "NOTA DE CREDITO" 61
        'Return "ORDEN DE COMPRA" 801

        Sb_Formato_Generico_Grilla(Grilla_Parejas, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Folios_Caf_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _AmbienteCertificacion = Convert.ToInt32(_Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion"))

        If CBool(_AmbienteCertificacion) Then
            Dim _BackColor_Tido As Color = Color.FromArgb(235, 81, 13)
            MStb_Barra.BackgroundStyle.BackColor = _BackColor_Tido
            Lbl_Etiqueta.Text = "Ambiente de Certificación y Prueba"
        End If

        Sb_Actualizar_Grilla()
        AddHandler Grilla_Parejas.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Cmb_TipoDoc.SelectedIndexChanged, AddressOf Sb_Actualizar_Grilla

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String

        If Cmb_TipoDoc.SelectedValue <> "" Then
            _Condicion = "And TD = " & Cmb_TipoDoc.SelectedValue
        End If

        Consulta_sql = "Select Empresa,Tido,RE,RS,TD,NOTIDO,RNG_D,RNG_H,FA,RSAPK_M,RSAPK_E,IDK,FRMA,RSASK,RSAPUBK,CAF" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_DTE_Caf" & vbCrLf &
                       "Left Join TABTIDO On Tido = TIDO" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion & vbCrLf & _Condicion & vbCrLf &
                       "Order By TD,RNG_D"
        Dim _Tbl_Inventarios As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Parejas

            .DataSource = _Tbl_Inventarios

            OcultarEncabezadoGrilla(Grilla_Parejas, True)

            Dim _DisplayIndex = 0

            .Columns("TD").Visible = True
            .Columns("TD").HeaderText = "Tipo"
            .Columns("TD").Width = 30
            .Columns("TD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tido").Visible = True
            .Columns("Tido").HeaderText = "TD"
            .Columns("Tido").Width = 40
            .Columns("Tido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RNG_D").Visible = True
            .Columns("RNG_D").HeaderText = "Desde"
            .Columns("RNG_D").Width = 80
            .Columns("RNG_D").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RNG_D").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RNG_H").Visible = True
            .Columns("RNG_H").HeaderText = "Hasta"
            .Columns("RNG_H").Width = 80
            .Columns("RNG_H").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RNG_H").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FA").Visible = True
            .Columns("FA").HeaderText = "Fecha"
            .Columns("FA").Width = 80
            .Columns("FA").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOTIDO").Visible = True
            .Columns("NOTIDO").HeaderText = "Descripción"
            .Columns("NOTIDO").Width = 250
            .Columns("NOTIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Subir_Folios_Click(sender As Object, e As EventArgs) Handles Btn_Subir_Folios.Click

        Try

            Dim _Tido As String

            Dim _OpenFileDialog As New OpenFileDialog

            _OpenFileDialog.Filter = "Archivos CAF|*.xml"

            If _OpenFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                Dim _Archivo As String = _OpenFileDialog.FileName

                Dim xmlDocumento As XmlDocument = New XmlDocument()
                xmlDocumento.PreserveWhitespace = True
                xmlDocumento.Load(_Archivo)

                Dim _Caf As New XDocument
                _Caf = XDocument.Load(_Archivo)

                Dim root As String = xmlDocumento.DocumentElement.Name
                If (root <> "AUTORIZACION") Then
                    Throw New Exception("El documento que intenta cargar no es un archivo CAF.")
                End If

                Dim _Re As String
                Dim _Rs As String
                Dim _Td As String
                Dim _Rng_d As String
                Dim _Rng_h As String
                Dim _Fa As DateTime
                Dim _Rsapk_m As String
                Dim _Rsapk_e As String
                Dim _Idk As String
                Dim _Frma As String
                Dim _Rsask As String
                Dim _Rsapubk As String
                Dim _CafStr As String

                Dim fileReader As String
                fileReader = My.Computer.FileSystem.ReadAllText(_Archivo)

                Try
                    _Re = _Caf.XPathSelectElement("AUTORIZACION/CAF/DA/RE").Value
                    _Rs = _Caf.XPathSelectElement("AUTORIZACION/CAF/DA/RS").Value
                    _Td = _Caf.XPathSelectElement("AUTORIZACION/CAF/DA/TD").Value
                    _Rng_d = _Caf.XPathSelectElement("AUTORIZACION/CAF/DA/RNG/D").Value
                    _Rng_h = _Caf.XPathSelectElement("AUTORIZACION/CAF/DA/RNG/H").Value
                    _Fa = Format(CDate(_Caf.XPathSelectElement("AUTORIZACION/CAF/DA/FA").Value), "dd/MM/yyyy")
                    _Rsapk_m = _Caf.XPathSelectElement("AUTORIZACION/CAF/DA/RSAPK/M").Value
                    _Rsapk_e = _Caf.XPathSelectElement("AUTORIZACION/CAF/DA/RSAPK/E").Value
                    _Idk = _Caf.XPathSelectElement("AUTORIZACION/CAF/DA/IDK").Value
                    _Frma = _Caf.XPathSelectElement("AUTORIZACION/CAF/FRMA").Value
                    _Rsask = _Caf.XPathSelectElement("AUTORIZACION/RSASK").Value
                    _Rsapubk = _Caf.XPathSelectElement("AUTORIZACION/RSAPUBK").Value
                    _CafStr = fileReader.ToString '_Caf.Document.ToString.Trim
                Catch ex As Exception
                    Throw New Exception("El documento que intenta cargar no es un archivo CAF.")
                End Try

                _Tido = Fx_Tipo_TIDO_VS_DTE(_Td)

                If String.IsNullOrEmpty(_Tido) Then
                    Throw New Exception("El documento que intenta cargar no es un archivo CAF.")
                End If

                Dim _Ref As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_DTE_Caf",
                                                               "TD = " & _Td & " And RNG_D = " & _Rng_d & " And RNG_H = " & _Rng_h & " And " &
                                      "AmbienteCertificacion = " & _AmbienteCertificacion)

                If CBool(_Ref) Then

                    Throw New Exception("Este archivo de folios ya esta levatado en la base")

                Else

                    Dim _Msg As String
                    Dim _Folios = (CDbl(_Rng_h) - CDbl(_Rng_d)) + 1
                    Dim _Notido As String = _Sql.Fx_Trae_Dato("TABTIDO", "NOTIDO", "TIDO = '" & _Tido & "'").ToString.Trim

                    _Msg = "Documento TD: " & _Tido & " (" & _Td & ") - " & _Notido.ToLower & vbCrLf &
                           "Folio inicial: " & _Rng_d & vbCrLf &
                           "Folio Final: " & _Rng_h & vbCrLf &
                           "Folios: " & FormatNumber(_Folios, 0)

                    If MessageBoxEx.Show(Me, "¿Confimra el levantamiento de este archivo CAF?" & vbCrLf & vbCrLf & _Msg, "Levantamiento de folios",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                        Return
                    End If

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DTE_Caf (Empresa,Tido,RE,RS,TD,RNG_D,RNG_H,FA,RSAPK_M,RSAPK_E,IDK,FRMA,RSASK,RSAPUBK,CAF,AmbienteCertificacion) Values " &
                                   "('" & ModEmpresa & "','" & _Tido & "','" & _Re & "','" & _Rs & "'," & _Td & "," & _Rng_d & "," & _Rng_h &
                                   ",'" & Format(_Fa, "yyyyMMdd") & "','" & _Rsapk_m & "','" & _Rsapk_e & "','" & _Idk & "','" & _Frma & "'" &
                                   ",'" & _Rsask & "','" & _Rsapubk & "','" & _CafStr & "'," & _AmbienteCertificacion & ")"

                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                        Cmb_TipoDoc.SelectedValue = _Td
                        MessageBoxEx.Show(Me, "Folios levantados correctamente", "Levantamiento de folios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Sb_Actualizar_Grilla()

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


End Class
