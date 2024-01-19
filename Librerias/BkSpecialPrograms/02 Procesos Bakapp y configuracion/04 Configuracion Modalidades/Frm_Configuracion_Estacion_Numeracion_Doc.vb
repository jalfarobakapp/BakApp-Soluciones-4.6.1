Imports DevComponents.DotNetBar

Public Class Frm_Configuracion_Estacion_Numeracion_Doc

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _dv As New DataView
    Dim _Row_Modalidad As DataRow
    Dim _Modalidad As String

    Dim _Grabado As Boolean

    Public ReadOnly Property Pro_Grabado() As Boolean
        Get
            Return _Grabado
        End Get
    End Property

    Public Property Modalidad_General As Boolean

    Public Sub New(Row_Modalidad As DataRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Row_Modalidad = Row_Modalidad
        _Modalidad = _Row_Modalidad.Item("MODALIDAD")

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, False, False)

    End Sub

    Private Sub Frm_Configuracion_Estacion_Numeracion_Doc_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Me.Text = "Configuración Modalidad " & _Modalidad

        Sb_Actualizar_Grilla()

        AddHandler Grilla.CellDoubleClick, AddressOf Grilla_CellDoubleClick
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Private Sub Grilla_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellClick

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Editado As Boolean = _Fila.Cells("Editado").Value
        Dim _Tido = _Fila.Cells("Tido").Value
        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        If _Cabeza = "Btn_Edit" Then
            Sb_Editar()
        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Tido = _Fila.Cells("Tido").Value
        Dim _Numero = _Fila.Cells("Numero").Value

        If _Cabeza = "Numero" Or _Cabeza = "NombreFormato" Or _Cabeza = "NombreFormato_PDF" Or _Cabeza = "NombreDocumento" Then
            Sb_Editar()
        End If

    End Sub

    Sub Sb_Editar()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Tido = _Fila.Cells("Tido").Value
        Dim _Numero = _Fila.Cells("Numero").Value

        Dim _Grabar As Boolean
        Dim _RowFormato As DataRow

        Dim Fm As New Frm_ConfTidoXModal(_Tido, _Numero, _Modalidad)
        Fm.Modalidad_General = Modalidad_General
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Numero = Fm.Txt_Numero.Text
        _RowFormato = Fm.RowFormato
        Fm.Dispose()

        If _Grabar Then
            _Fila.Cells("NombreFormato").Value = _RowFormato.Item("NombreFormato")
            _Fila.Cells("Numero").Value = _Numero
            _Fila.Cells("Grabar_Con_Huella").Value = _RowFormato.Item("Grabar_Con_Huella")
            _Fila.Cells("Sugiere_Despacho").Value = _RowFormato.Item("Sugiere_Despacho")
            _Fila.Cells("Obliga_Despacho").Value = _RowFormato.Item("Obliga_Despacho")
            _Fila.Cells("NombreFormato_PDF").Value = _RowFormato.Item("NombreFormato_PDF")
            _Fila.Cells("Guardar_PDF_Auto").Value = _RowFormato.Item("Guardar_PDF_Auto")
            _Fila.Cells("Obliga_Transportista").Value = _RowFormato.Item("Obliga_Transportista")
            _Fila.Cells("Obliga_Despacho_BodDistintas").Value = _RowFormato.Item("Obliga_Despacho_BodDistintas")
            _Fila.Cells("Enviar_Correo").Value = _RowFormato.Item("Enviar_Correo")
            _Fila.Cells("TimbrarXRandom").Value = _RowFormato.Item("TimbrarXRandom")

            If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then

                For Each _Fl As DataRow In _dv.Table.Rows
                    _Tido = _Fl.Item("Tido")
                    If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then
                        _Fl.Item("Numero") = _Numero
                    End If
                Next

            End If

        End If


    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Tido As String = _Fila.Cells("Tido").Value

        If e.KeyValue = Keys.Enter Then

            If _Cabeza = "Numero" Then

                If _Tido = "GRC" Or _Tido = "GRD" Then
                    MessageBoxEx.Show(Me, "Este documento no puede contener numeración", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Grilla.Columns(_Cabeza).ReadOnly = False
                Grilla.BeginEdit(True)

                e.SuppressKeyPress = False
                e.Handled = True

            End If

        End If

    End Sub

    Private Sub Grilla_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Edit As Boolean

        Select Case _Cabeza

            Case "Numero"

                Dim _Tido = _Fila.Cells("Tido").Value
                Dim _Nudo As String = NuloPorNro(_Fila.Cells("Numero").Value, "").ToString.Trim
                Dim _Numero_Old As String = _Fila.Cells("Numero_Old").Value

                If Not String.IsNullOrEmpty(_Nudo) Then
                    _Nudo = Fx_Rellena_ceros(_Nudo, 10)
                End If

                If Not String.IsNullOrEmpty(_Nudo) And _Nudo <> "0000000000" Then

                    If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then
                        _Tido = "('GDV','GTI','GDP','GDD')"
                    Else
                        _Tido = "('" & _Tido & "')"
                    End If

                    Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("MAEEDO",
                                                                         "EMPRESA = '" & ModEmpresa & "' And TIDO In " & _Tido & " And NUDO = '" & _Nudo & "'"))

                    If _Reg Then

                        MessageBoxEx.Show(Me, "Esta número ya existe en el sistema" & vbCrLf &
                                           "No puede poner este Nro " & _Nudo, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        _Nudo = _Numero_Old

                    End If

                End If

                _Fila.Cells("Numero").Value = _Nudo

                If _Nudo <> _Numero_Old Then
                    _Fila.Cells("Edit_" & _Cabeza).Value = True
                End If

            Case "Grabar_Con_Huella", "Sugiere_Despacho", "Obliga_Despacho", "Obliga_Despacho_BodDistintas", "Guardar_PDF_Auto", "Obliga_Transportista"

                _Fila.Cells("Edit_" & _Cabeza).Value = True

        End Select

        _Edit = _Fila.Cells("Edit_" & _Cabeza).Value

        If _Edit Then
            _Fila.Cells("Btn_Cmb").Value = Img_Imagenes.Images("Grabar_True")
            _Fila.Cells("Editado").Value = True
        End If

        Grilla.Columns(_Cabeza).ReadOnly = False

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select TIDO,NOTIDO From TABTIDO Where TIGEDO = 'I' Or TIDO In ('GRC','GRD')"

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _Tbl_Tido As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Consulta_sql = String.Empty

        Dim _Contador = 1

        For Each _Fila As DataRow In _Tbl_Tido.Rows

            Dim _Tido = _Fila.Item("TIDO")
            Dim _Notido = _Fila.Item("NOTIDO")

            Dim _Sql1, _Sql2 As String

            If _Tido = "GRC" Or _Tido = "GRD" Then
                _Sql1 = "SELECT Cast(0 As Bit) As Editado,
                            '" & _Tido & "' As Tido,'" & _Notido & "' As 'NombreDocumento'," & vbCrLf &
                            "'' As Numero," &
                            "Cast(0 As Bit) As Edit_Numero," & vbCrLf
                _Sql2 = "'' As Numero_Old,'A' as Cmb" & vbCrLf
            Else
                _Sql1 = "SELECT Cast(0 As Bit) As Editado,
                            '" & _Tido & "' As Tido,'" & _Notido & "' As 'NombreDocumento'," & vbCrLf &
                        "Isnull((Select " & _Tido & " From CONFIEST Where EMPRESA = '" & ModEmpresa & "' And MODALIDAD = '" & _Modalidad & "'),'') As Numero," &
                        "Cast(0 As Bit) As Edit_Numero," & vbCrLf
                _Sql2 = "Isnull((Select " & _Tido & " From CONFIEST Where EMPRESA = '" & ModEmpresa & "' And MODALIDAD = '" & _Modalidad & "'),'') As Numero_Old,'A' as Cmb" & vbCrLf
            End If

            Consulta_sql += _Sql1 & vbCrLf &
                            vbCrLf &
                            "Isnull((Select Top 1 NombreFormato From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),'') As NombreFormato," &
                            vbCrLf &
                            "Isnull((Select Top 1 NombreFormato_PDF From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),'') As NombreFormato_PDF," &
                            vbCrLf &
                            "Isnull((Select Top 1 Grabar_Con_Huella From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),0) As Grabar_Con_Huella," &
                            vbCrLf &
                            "Isnull((Select Top 1 Sugiere_Despacho From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),0) As Sugiere_Despacho," &
                            vbCrLf &
                            "Isnull((Select Top 1 Obliga_Despacho From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),0) As Obliga_Despacho," &
                            vbCrLf &
                            "Isnull((Select Top 1 Obliga_Despacho_BodDistintas From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),0) As Obliga_Despacho_BodDistintas," &
                            vbCrLf &
                            "Isnull((Select Top 1 Obliga_Transportista From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),0) As Obliga_Transportista," &
                            vbCrLf &
                            "Isnull((Select Top 1 Guardar_PDF_Auto From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),0) As Guardar_PDF_Auto," &
                            vbCrLf &
                            "Isnull((Select Top 1 Enviar_Correo From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),0) As Enviar_Correo," &
                            vbCrLf &
                            "Isnull((Select Top 1 Guardar_PDF_Auto From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),0) As Guardar_PDF_Auto," &
                            vbCrLf &
                             "Isnull((Select Top 1 TimbrarXRandom From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),0) As TimbrarXRandom," &
                            vbCrLf &
                            _Sql2

            If _Contador <> _Tbl_Tido.Rows.Count Then
                Consulta_sql += "Union" & vbCrLf
            End If
            _Contador += 1

        Next

        Consulta_sql += "Order by Tido, NombreFormato"


        Dim _Ds As New DataSet
        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

        _dv.Table = _Ds.Tables(0)

        Dim _DisplayIndex = 0

        With Grilla ' ancho 853

            .DataSource = _dv

            OcultarEncabezadoGrilla(Grilla, True)

            Sb_InsertarBotonenGrilla(Grilla, "Btn_Edit", "Editar", "Editar", 0, _Tipo_Boton.Boton)

            _DisplayIndex = 1
            .Columns("Btn_Edit").Frozen = True

            .Columns("Tido").Visible = True
            .Columns("Tido").Width = 30
            .Columns("Tido").HeaderText = "TD"
            .Columns("Tido").Frozen = True
            .Columns("Tido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreDocumento").Visible = True
            .Columns("NombreDocumento").Width = 190
            .Columns("NombreDocumento").HeaderText = "Documento"
            .Columns("NombreDocumento").Frozen = True
            .Columns("NombreDocumento").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreFormato").Visible = True
            .Columns("NombreFormato").Width = 140
            .Columns("NombreFormato").HeaderText = "Nombre formato normal"
            .Columns("NombreFormato").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreFormato_PDF").Visible = True
            .Columns("NombreFormato_PDF").Width = 100
            .Columns("NombreFormato_PDF").HeaderText = "Nombre formato para PDF"
            .Columns("NombreFormato_PDF").ToolTipText = "Nombre formato para PDF"
            .Columns("NombreFormato_PDF").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Numero").Visible = True
            .Columns("Numero").Width = 80
            .Columns("Numero").HeaderText = "Número"
            .Columns("Numero").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Guardar_PDF_Auto").Visible = True
            .Columns("Guardar_PDF_Auto").Width = 45
            .Columns("Guardar_PDF_Auto").HeaderText = "Gra." & vbCrLf & "PDF"
            .Columns("Guardar_PDF_Auto").ToolTipText = "Guardar automáticamente una copia en PDF al momento de grabar el documento"
            .Columns("Guardar_PDF_Auto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Grabar_Con_Huella").Visible = True
            .Columns("Grabar_Con_Huella").Width = 45
            .Columns("Grabar_Con_Huella").HeaderText = "Gra." & vbCrLf & "Huella"
            .Columns("Grabar_Con_Huella").ToolTipText = "Grabar con huella"
            .Columns("Grabar_Con_Huella").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Obliga_Despacho").Visible = True
            .Columns("Obliga_Despacho").Width = 45
            .Columns("Obliga_Despacho").HeaderText = "Obl." & vbCrLf & "Desp."
            .Columns("Obliga_Despacho").ToolTipText = "Obliga despacho (Sistema de despacho)"
            .Columns("Obliga_Despacho").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sugiere_Despacho").Visible = True
            .Columns("Sugiere_Despacho").Width = 45
            .Columns("Sugiere_Despacho").HeaderText = "Sug." & vbCrLf & "Desp."
            .Columns("Sugiere_Despacho").ToolTipText = "Sugire despacho (Sistema de despacho)"
            .Columns("Sugiere_Despacho").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Obliga_Despacho_BodDistintas").Visible = True
            .Columns("Obliga_Despacho_BodDistintas").Width = 45
            .Columns("Obliga_Despacho_BodDistintas").HeaderText = "Obl." & vbCrLf & "BDesp"
            .Columns("Obliga_Despacho_BodDistintas").ToolTipText = "Obliga despacho con bod. distintas (Sistema de despacho)"
            .Columns("Obliga_Despacho_BodDistintas").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Obliga_Transportista").Visible = True
            .Columns("Obliga_Transportista").Width = 45
            .Columns("Obliga_Transportista").HeaderText = "Obli." & vbCrLf & "Trans."
            .Columns("Obliga_Transportista").ToolTipText = "Obliga el ingreso del transportista"
            .Columns("Obliga_Transportista").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Enviar_Correo").Visible = True
            .Columns("Enviar_Correo").Width = 45
            .Columns("Enviar_Correo").HeaderText = "Env." & vbCrLf & "Email"
            .Columns("Enviar_Correo").ToolTipText = "Enviar correo despues de grabar un documento"
            .Columns("Enviar_Correo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TimbrarXRandom").Visible = Not Modalidad_General
            .Columns("TimbrarXRandom").Width = 45
            .Columns("TimbrarXRandom").HeaderText = "T." & vbCrLf & "Elec.XRANDOM"
            .Columns("TimbrarXRandom").ToolTipText = "Enviar a timbrar electrónicamente por Random"
            .Columns("TimbrarXRandom").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1



        End With

        _DisplayIndex += 1


    End Sub

    Sub Sb_Actualizar_Grilla_Old()

        Consulta_sql = "Select TIDO,NOTIDO From TABTIDO Where TIGEDO = 'I' Or TIDO In ('GRC','GRD')"

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _Tbl_Tido As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Consulta_sql = String.Empty

        Dim _Contador = 1

        For Each _Fila As DataRow In _Tbl_Tido.Rows

            Dim _Tido = _Fila.Item("TIDO")
            Dim _Notido = _Fila.Item("NOTIDO")

            Dim _Sql1, _Sql2 As String

            If _Tido = "GRC" Or _Tido = "GRD" Then
                _Sql1 = "SELECT Cast(0 As Bit) As Editado,
                            '" & _Tido & "' As Tido,'" & _Notido & "' As 'NombreDocumento'," & vbCrLf &
                            "'' As Numero," &
                            "Cast(0 As Bit) As Edit_Numero," & vbCrLf
                _Sql2 = "'' As Numero_Old,'A' as Cmb" & vbCrLf
            Else
                _Sql1 = "SELECT Cast(0 As Bit) As Editado,
                            '" & _Tido & "' As Tido,'" & _Notido & "' As 'NombreDocumento'," & vbCrLf &
                        "Isnull((Select " & _Tido & " From CONFIEST Where EMPRESA = '" & ModEmpresa & "' And MODALIDAD = '" & _Modalidad & "'),'') As Numero," &
                        "Cast(0 As Bit) As Edit_Numero," & vbCrLf
                _Sql2 = "Isnull((Select " & _Tido & " From CONFIEST Where EMPRESA = '" & ModEmpresa & "' And MODALIDAD = '" & _Modalidad & "'),'') As Numero_Old,'A' as Cmb" & vbCrLf
            End If

            Consulta_sql += _Sql1 & vbCrLf &
                            vbCrLf &
                            "Isnull((Select Top 1 NombreFormato From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),'') As NombreFormato," &
                            "Cast(0 As Bit) As Edit_NombreFormato," & vbCrLf &
                            vbCrLf &
                            "Isnull((Select Top 1 NombreFormato_PDF From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),'') As NombreFormato_PDF," &
                            "Cast(0 As Bit) As Edit_NombreFormato_PDF," & vbCrLf &
                            vbCrLf &
                            "Isnull((Select Top 1 Grabar_Con_Huella From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),0) As Grabar_Con_Huella," &
                            "Cast(0 As Bit) As Edit_Grabar_Con_Huella," & vbCrLf &
                            vbCrLf &
                            "Isnull((Select Top 1 Sugiere_Despacho From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),0) As Sugiere_Despacho," &
                            "Cast(0 As Bit) As Edit_Sugiere_Despacho," & vbCrLf &
                            vbCrLf &
                            "Isnull((Select Top 1 Obliga_Despacho From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),0) As Obliga_Despacho," &
                            "Cast(0 As Bit) As Edit_Obliga_Despacho," &
                            vbCrLf &
                            "Isnull((Select Top 1 Obliga_Despacho_BodDistintas From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),0) As Obliga_Despacho_BodDistintas," &
                            "Cast(0 As Bit) As Edit_Obliga_Despacho_BodDistintas," &
                            vbCrLf &
                            "Isnull((Select Top 1 Obliga_Transportista From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),0) As Obliga_Transportista," &
                            "Cast(0 As Bit) As Edit_Obliga_Transportista," &
                            vbCrLf &
                            "Isnull((Select Top 1 Guardar_PDF_Auto From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _Tido & "'),0) As Guardar_PDF_Auto," &
                            "Cast(0 As Bit) As Edit_Guardar_PDF_Auto," & vbCrLf &
                            "Isnull((Select Top 1 Ruta_PDF From " & _Global_BaseBk & "Zw_Estaciones_Ruta_PDF " & vbCrLf &
                            "Where Empresa = '" & ModEmpresa & "'  And Modalidad = '" & _Modalidad & "' And Tido = '" & _Tido & "' And NombreEquipo = '" & _NombreEquipo & "'),0) As Ruta_PDF," & vbCrLf &
                            vbCrLf &
                            _Sql2

            If _Contador <> _Tbl_Tido.Rows.Count Then
                Consulta_sql += "Union" & vbCrLf
            End If
            _Contador += 1

        Next

        Consulta_sql += "Order by Tido, NombreFormato"


        Dim _Ds As New DataSet
        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

        _dv.Table = _Ds.Tables(0)

        Dim _DisplayIndex = 0

        With Grilla ' ancho 853

            .DataSource = _dv

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Tido").Visible = True
            .Columns("Tido").Width = 30
            .Columns("Tido").HeaderText = "TD"
            .Columns("Tido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreDocumento").Visible = True
            .Columns("NombreDocumento").Width = 190
            .Columns("NombreDocumento").HeaderText = "Documento"
            .Columns("NombreDocumento").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreFormato").Visible = True
            .Columns("NombreFormato").Width = 145
            .Columns("NombreFormato").HeaderText = "Nombre formato normal"
            .Columns("NombreFormato").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreFormato_PDF").Visible = True
            .Columns("NombreFormato_PDF").Width = 145
            .Columns("NombreFormato_PDF").HeaderText = "Nombre formato para PDF"
            .Columns("NombreFormato_PDF").ToolTipText = "Nombre formato para PDF"
            .Columns("NombreFormato_PDF").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Numero").Visible = True
            .Columns("Numero").Width = 80
            .Columns("Numero").HeaderText = "Número"
            .Columns("Numero").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Grabar_Con_Huella").Visible = True
            .Columns("Grabar_Con_Huella").Width = 60
            .Columns("Grabar_Con_Huella").HeaderText = "G.Huella"
            .Columns("Grabar_Con_Huella").ToolTipText = "Grabar con huella"
            .Columns("Grabar_Con_Huella").DisplayIndex = _DisplayIndex
            .Columns("Grabar_Con_Huella").ReadOnly = False
            _DisplayIndex += 1

            .Columns("Sugiere_Despacho").Visible = True
            .Columns("Sugiere_Despacho").Width = 50
            .Columns("Sugiere_Despacho").HeaderText = "S.Desp."
            .Columns("Sugiere_Despacho").ToolTipText = "Sugire despacho (Sistema de despacho)"
            .Columns("Sugiere_Despacho").DisplayIndex = _DisplayIndex
            .Columns("Sugiere_Despacho").ReadOnly = False
            _DisplayIndex += 1

            .Columns("Obliga_Despacho").Visible = True
            .Columns("Obliga_Despacho").Width = 50
            .Columns("Obliga_Despacho").HeaderText = "O.Desp."
            .Columns("Obliga_Despacho").ToolTipText = "Obliga despacho (Sistema de despacho)"
            .Columns("Obliga_Despacho").DisplayIndex = _DisplayIndex
            .Columns("Obliga_Despacho").ReadOnly = False
            _DisplayIndex += 1

            .Columns("Obliga_Despacho_BodDistintas").Visible = True
            .Columns("Obliga_Despacho_BodDistintas").Width = 50
            .Columns("Obliga_Despacho_BodDistintas").HeaderText = "OBDesp"
            .Columns("Obliga_Despacho_BodDistintas").ToolTipText = "Obliga despacho con bod. distintas (Sistema de despacho)"
            .Columns("Obliga_Despacho_BodDistintas").DisplayIndex = _DisplayIndex
            .Columns("Obliga_Despacho_BodDistintas").ReadOnly = False
            _DisplayIndex += 1

            .Columns("Obliga_Transportista").Visible = True
            .Columns("Obliga_Transportista").Width = 50
            .Columns("Obliga_Transportista").HeaderText = "O.Trans."
            .Columns("Obliga_Transportista").ToolTipText = "Obliga el ingreso del transportista"
            .Columns("Obliga_Transportista").DisplayIndex = _DisplayIndex
            .Columns("Obliga_Transportista").ReadOnly = False
            _DisplayIndex += 1

            .Columns("Guardar_PDF_Auto").Visible = True
            .Columns("Guardar_PDF_Auto").Width = 50
            .Columns("Guardar_PDF_Auto").HeaderText = "G.PDF"
            .Columns("Guardar_PDF_Auto").ToolTipText = "Guardar automáticamente una copia en PDF al momento de grabar el documento"
            .Columns("Guardar_PDF_Auto").DisplayIndex = _DisplayIndex
            .Columns("Guardar_PDF_Auto").ReadOnly = False
            _DisplayIndex += 1

        End With

        Sb_InsertarBotonenGrilla(Grilla, "Btn_Folder", "...", "Carpe..", _DisplayIndex, _Tipo_Boton.Imagen)
        _DisplayIndex += 1
        Sb_InsertarBotonenGrilla(Grilla, "Btn_Cmb", "Grabar", "Grabar", _DisplayIndex, _Tipo_Boton.Imagen)

        For Each _Row As DataGridViewRow In Grilla.Rows

            _Row.Cells("Btn_Cmb").Value = Img_Imagenes.Images("Grabar_False")

            Dim _Guardar_PDF_Auto As Boolean = _Row.Cells("Guardar_PDF_Auto").Value

            If _Guardar_PDF_Auto Then
                _Row.Cells("Btn_Folder").Value = Img_Imagenes.Images("folder_open_true.png")
            Else
                _Row.Cells("Btn_Folder").Value = Img_Imagenes.Images("folder_open_false.png")
            End If

        Next

    End Sub

    Private Sub Frm_Configuracion_Estacion_Numeracion_Doc_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Grilla_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter
        Return
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Ruta_PDF As String = _Fila.Cells("Ruta_PDF").Value

        If _Ruta_PDF = "0" Then _Ruta_PDF = String.Empty

        Txt_Ruta_PDF.Text = _Ruta_PDF

    End Sub

End Class
