'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_ImpBarras_PorDocumento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Dim _Datos_Documento As New DataSet
    Dim _TblEncabezado, _TblDetalle, _TblObservaciones As DataTable
    Dim _Puerto, _Etiqueta As String
    Dim _Idmaeedo As String

    Public Sub New(Idmaeedo As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(GrillaEncabezado, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        _Idmaeedo = Idmaeedo

        Sb_Color_Botones_Barra(Bar1)

    End Sub

#Region "PROCEDIMIENTOS"

#Region "IMPRIMIR ETIQUETAS"

    Sub Sb_Imprimir_Etiquetas()
        Try
            _Etiqueta = Cmbetiquetas.SelectedValue

            Dim _TblDetalle As DataTable = Grilla.DataSource

            Dim _Suma As Double = _TblDetalle.Compute("Sum(Cantidad)", "1>0")

            If Not CBool(_Suma) Then
                Beep()
                ToastNotification.Show(Me, "NO HAY CANTIDADES QUE IMPRIMIR",
                                      My.Resources.cross,
                                     1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return
            End If


            If MessageBoxEx.Show(Me, "¿Confirma impresión?" & vbCrLf & vbCrLf &
                                 "ETIQUETA : " & Cmbetiquetas.Text & vbCrLf & vbCrLf &
                                 "Aproximadamente " & _Suma & " etiquetas", "Imprimir",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                Dim _CantPorLinea As Integer
                Dim _Etiquetas_Imp = 0

                _CantPorLinea = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras", "CantPorLinea",
                                          "NombreEtiqueta = '" & Cmbetiquetas.SelectedValue & "'")

                If String.IsNullOrEmpty(_CantPorLinea) Then _CantPorLinea = 1


                For Each _Fila As DataRow In _TblDetalle.Rows

                    Dim CanXlinea As Double = _CantPorLinea
                    Dim Veces As Double = _Fila("Cantidad").ToString()

                    If CBool(Veces) Then

                        If CanXlinea = Veces Or CanXlinea > Veces Then
                            Veces = 1
                        Else
                            Dim _ModVeces = Veces Mod 2
                            Dim _ModCanXlinea = CanXlinea Mod 2

                            If CanXlinea <> 1 Then

                                If CBool(_ModVeces) Or CBool(_ModCanXlinea) Then

                                    Veces = Math.Round((Veces / CanXlinea), 5)
                                    Dim _Des = Split(Veces, ",")

                                    If _Des.Length = 2 Then
                                        Veces = _Des(0) + 1
                                    End If

                                Else
                                    Veces = Math.Round((Veces / CanXlinea), 0)
                                End If
                            End If
                        End If

                        If Veces < 1 Then Veces = 1

                        Dim _Idmaeddo = _Fila.Item("IDMAEDDO")

                        For w = 1 To Val(Veces)

                            Dim _Imp As New Class_Imprimir_Barras
                            _Imp.Sb_Imprimir_Documento(_Etiqueta, _Puerto, _Idmaeedo, _Idmaeddo)
                            _Etiquetas_Imp += 1

                        Next
                    End If
                Next

                Dim _EtiquetasImpresas As Integer = _CantPorLinea * _Etiquetas_Imp

                If CBool(_EtiquetasImpresas) Then

                    MessageBoxEx.Show(Me, _EtiquetasImpresas & " ETIQUETAS IMPRESAS", "IMPRIMIR BARRAS",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problemas de impresión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

#End Region

#Region "ACTUALIZAR GRILLA"

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = Replace(My.Resources.Recursos_Ver_Documento.Traer_Documento_Random,
                       "#Idmaeedo#", _Idmaeedo)


        _Datos_Documento = _Sql.Fx_Get_DataSet(Consulta_sql)

        _TblEncabezado = _Datos_Documento.Tables(0)
        _TblDetalle = _Datos_Documento.Tables(1)
        _TblObservaciones = _Datos_Documento.Tables(2)

        _Datos_Documento.Dispose()



        LblEntidadFisica.Text = _TblEncabezado.Rows(0).Item("ENT_FISICA") & " - " &
                                _TblEncabezado.Rows(0).Item("RAZON_FISICA")


        With GrillaEncabezado

            GrillaEncabezado.DataSource = _TblEncabezado
            OcultarEncabezadoGrilla(GrillaEncabezado, True)


            .Columns("EMPRESA").HeaderText = "Emp"
            .Columns("EMPRESA").Visible = True
            .Columns("EMPRESA").Width = 35
            .Columns("EMPRESA").DisplayIndex = 0

            .Columns("TIDO").HeaderText = "T.D."
            .Columns("TIDO").Visible = True
            .Columns("TIDO").Width = 30
            .Columns("TIDO").DisplayIndex = 1

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Visible = True
            .Columns("NUDO").Width = 70
            .Columns("NUDO").DisplayIndex = 2

            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Visible = True
            .Columns("ENDO").Width = 75
            .Columns("ENDO").DisplayIndex = 3

            .Columns("RAZON").HeaderText = "Razón Social"
            .Columns("RAZON").Visible = True
            .Columns("RAZON").Width = 260
            .Columns("RAZON").DisplayIndex = 4

            .Columns("SUDO").HeaderText = "Suc"
            .Columns("SUDO").Visible = True
            .Columns("SUDO").Width = 30
            .Columns("SUDO").DisplayIndex = 5

            .Columns("LUVTDO").HeaderText = "C.C."
            .Columns("LUVTDO").Visible = True
            .Columns("LUVTDO").Width = 40
            .Columns("LUVTDO").DisplayIndex = 6

            .Columns("FEEMDO").HeaderText = "Fecha"
            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").Width = 75
            .Columns("FEEMDO").DisplayIndex = 7
            .Columns("FEEMDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("KOFUDO").HeaderText = "Cod"
            .Columns("KOFUDO").Visible = True
            .Columns("KOFUDO").Width = 30
            .Columns("KOFUDO").DisplayIndex = 8

            .Columns("FUNCIONARIO").HeaderText = "Responzable"
            .Columns("FUNCIONARIO").Visible = True
            .Columns("FUNCIONARIO").Width = 150
            .Columns("FUNCIONARIO").DisplayIndex = 9

        End With

        _TblDetalle.Columns("CANTIDAD").ReadOnly = False

        With Grilla

            .DataSource = _TblDetalle

            OcultarEncabezadoGrilla(Grilla, True)

            '.Columns("ITEM").HeaderText = "Item"
            '.Columns("ITEM").Visible = True
            '.Columns("ITEM").Width = 40
            '.Columns("ITEM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("ITEM").DisplayIndex = 0

            .Columns("BOSULIDO").HeaderText = "Bod"
            .Columns("BOSULIDO").Visible = True
            .Columns("BOSULIDO").Width = 30
            .Columns("BOSULIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("BOSULIDO").DisplayIndex = 1
            .Columns("BOSULIDO").ReadOnly = True

            .Columns("KOFULIDO").HeaderText = "Ven"
            .Columns("KOFULIDO").Visible = True
            .Columns("KOFULIDO").Width = 30
            .Columns("KOFULIDO").DisplayIndex = 2
            .Columns("KOFULIDO").ReadOnly = True

            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").Visible = True
            .Columns("KOPRCT").Width = 95
            .Columns("KOPRCT").DisplayIndex = 3
            .Columns("KOPRCT").ReadOnly = True

            .Columns("ALTERNAT").HeaderText = "Cód. Alternativo"
            .Columns("ALTERNAT").Visible = True
            .Columns("ALTERNAT").Width = 100
            .Columns("ALTERNAT").DisplayIndex = 4
            .Columns("ALTERNAT").ReadOnly = True

            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").Width = 420
            .Columns("NOKOPR").DisplayIndex = 5
            .Columns("NOKOPR").ReadOnly = True

            .Columns("CANTIDAD").HeaderText = "Cantidad"
            .Columns("CANTIDAD").Visible = True
            .Columns("CANTIDAD").Width = 60
            .Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CANTIDAD").ReadOnly = False
            .Columns("CANTIDAD").DisplayIndex = 6

        End With

    End Sub
#End Region

#End Region

    Private Sub Frm_ImpBarras_PorDocumento__Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim Fm As New Frm_Barras_ConfPuerto("Configuracion_local.xml")

        _Puerto = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Puerto")
        _Etiqueta = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Etiqueta")

        caract_combo(Cmbetiquetas)
        Consulta_sql = "SELECT NombreEtiqueta AS Padre,NombreEtiqueta+', Cantidad de etiquetas por fila '+RTRIM(LTRIM(STR(CantPorLinea))) AS Hijo" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_Tbl_DisenoBarras order by NombreEtiqueta"
        Cmbetiquetas.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmbetiquetas.SelectedValue = _Etiqueta

        AddHandler Btnimprimiretiquetas.Click, AddressOf Sb_Imprimir_Etiquetas
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Grilla_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Grilla.EditingControlShowing
        ' referencia a la celda  
        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub validar_Keypress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress  

        ' obtener el nombre de la columna
        Dim _Columna = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Columna = "CANTIDAD" Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  
            If (Char.IsNumber(caracter)) Or
            (caracter = ChrW(Keys.Back)) Or
            (caracter = ",") And
            (txt.Text.Contains(",") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Frm_ImpBarras_PorDocumento_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    'Private Sub ButtonItem1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem1.Click
    '   ActualizarGrillaSQL()

    'Dim Ruta As String = AppPath(True)
    'Dim Archivo As String = "Archivo.txt"

    'Dim CodigoPrincipal As String
    'Dim CodigoProveedor As String
    'Dim Descripcion As String
    'Dim Detalle As String = ""

    '    Try

    '        Consulta_sql = "SELECT CodProducto,CodProductoProveedor,Descripcion,Cantidad,Ubicacion FROM " & TablaDePaso & vbCrLf & _
    '                       "WHERE Cantidad = 0"
    'Dim Tabla As New DataTable


    '        Tabla = _SQL.Fx_Get_Tablas(Consulta_sql)

    '        If Tabla.Rows.Count > 0 Then
    'Dim Fila As DataRow

    '            For i = 0 To Tabla.Rows.Count - 1
    '                Fila = Tabla.Rows(i)
    '                CodigoPrincipal = Fila.Item("CodProducto").ToString
    '                CodigoPrincipal = Rellenar(_Sql.Fx_Trae_Dato(, "KOPRTE", "MAEPR", "KOPR = '" & CodigoPrincipal & "'"), 20, " ")
    '                CodigoProveedor = Rellenar(Fila.Item("CodProductoProveedor").ToString, 20, " ")
    '                Descripcion = Rellenar(Mid(Fila.Item("Descripcion").ToString, 1, 43), 43, " ")
    '                Detalle = Detalle & "|  " & CodigoPrincipal & " | " & CodigoProveedor & " | " & Descripcion & "   | " & vbCrLf
    '            Next

    'Dim Encabezado As String = ""
    '            Encabezado = RazonEmpresa & vbCrLf & RutEmpresa & vbCrLf & vbCrLf & _
    '                         "Entidad: " & Rellenar(txtrazonsocial.Text, 58, " ") & _
    '                         "Tipo Doc. " & Txtipodocumento.Text & " Nro:" & Txtnrodocumento.Text & vbCrLf & _
    '                         vbCrLf & _
    '                         " +----------------------------------------------------------------------------------------------+" & vbCrLf & _
    '                         " |  CODIGO RANDOM        | CODIGO ENTIDAD       | DESCRIPCION                                   |" & vbCrLf & _
    '                         " +----------------------------------------------------------------------------------------------+" & vbCrLf

    'Dim Pie As String
    '            Pie = "+----------------------------------------------------------------------------------------------+"

    'Dim Cuerpo As String = ""
    '            Cuerpo = Chr(15) & Encabezado & Detalle & Pie & Chr(18)

    '            CrearArchivoTxt(Ruta, Archivo, Cuerpo)
    '            System.IO.File.Copy(Ruta & Archivo, CmbpuertoLPT.Text)

    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub



    Private Sub Btn_imprimir_Archivo_Click(sender As System.Object, e As System.EventArgs) Handles Btn_imprimir_Archivo.Click

        Dim _Filas_X_Documento As String = 10
        Dim _Aceptado As Boolean

        Try
            _Aceptado = InputBox_Bk(Me, "Indique la cantidad de productos por hoja", "Códigos por pagina",
                                         _Filas_X_Documento, False, _Tipo_Mayus_Minus.Normal, 0, True, _Tipo_Imagen.Barra,
                                         False, _Tipo_Caracter.Solo_Numeros_Enteros, False)

            If Not _Aceptado Or _Filas_X_Documento = 0 Then
                Exit Sub
            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End Try

        Dim _Tbl_Detalle As DataTable = Grilla.DataSource

        If CBool(_TblDetalle.Rows.Count) Then

            Dim _Codigos = Generar_Filtro_IN(_TblDetalle, "", "KOPRCT", False, False, "'")

            Consulta_sql = "Select CAST( 0 AS bit) AS Impreso,1 As Contador,* From MAEPR WHERE KOPR IN " & _Codigos
            _Tbl_Detalle = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _ClaImprimir_Barras As New Clas_Imprimir_Barras

            _ClaImprimir_Barras._Empresa = _TblDetalle.Rows(0).Item("EMPRESA") '_ESB(0)
            _ClaImprimir_Barras._Sucursal = _TblDetalle.Rows(0).Item("SULIDO") '_ESB(1)
            _ClaImprimir_Barras._Bodega = _TblDetalle.Rows(0).Item("BOSULIDO") '_ESB(2)
            _ClaImprimir_Barras._Filas_X_Documento = _Filas_X_Documento
            _ClaImprimir_Barras._TblProductos = _Tbl_Detalle
            _ClaImprimir_Barras.Fx_Imprimir_Archivo(Me, "Productos_Barras", "")

        Else

            Beep()
            ToastNotification.Show(Me, "NO HAY DATOS QUE IMPRIMIR",
                                  My.Resources.cross,
                                 1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

        End If

    End Sub

End Class
