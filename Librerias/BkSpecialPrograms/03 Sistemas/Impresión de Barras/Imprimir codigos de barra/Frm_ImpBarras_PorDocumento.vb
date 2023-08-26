'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_ImpBarras_PorDocumento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Dim _Datos_Documento As New DataSet
    Dim _TblEncabezado, _TblDetalle, _TblObservaciones As DataTable
    Dim _Puerto, _Etiqueta As String
    Dim _Idmaeedo As String

    Public Property CantidadCero As Boolean

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
                        Dim _Kopral = _Fila.Item("ALTERNAT").ToString.Trim

                        For w = 1 To Val(Veces)

                            Dim _Imp As New Class_Imprimir_Barras
                            _Imp.Sb_Imprimir_Documento(_Etiqueta, _Puerto, _Idmaeedo, _Idmaeddo, _Kopral)
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

        If CantidadCero Then
            For Each _Fila As DataRow In _TblDetalle.Rows
                _Fila.Item("CANTIDAD") = 0
            Next
        End If

        _TblDetalle.Columns("CANTIDAD").ReadOnly = False

        With Grilla

            .DataSource = _TblDetalle

            OcultarEncabezadoGrilla(Grilla, True)

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
            .Columns("ALTERNAT").Width = 120
            .Columns("ALTERNAT").DisplayIndex = 4
            .Columns("ALTERNAT").ReadOnly = True

            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").Width = 400
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

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "ALTERNAT" Then

            Dim _Codigo As String = _Fila.Cells("KOPRCT").Value
            Dim _Descripcion As String = _Fila.Cells("NOKOPR").Value.ToString.Trim
            Dim _Rtu As Double = _Fila.Cells("RLUDPR").Value
            Dim _RowTabcodal As DataRow

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("TABCODAL", "KOPR = '" & _Codigo & "'")

            If _Reg = 0 Then
                MessageBoxEx.Show(Me, "Este producto no tiene códigos alternativos asociados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim Fm As New Frm_CodAlternativo_Ver
            Fm.TxtCodigo.Text = _Codigo
            Fm.Txtdescripcion.Text = _Descripcion
            Fm.TxtRTU.Text = _Rtu
            Fm.ModoSeleccion = True
            Fm.ShowDialog(Me)
            _RowTabcodal = Fm.RowTabcodalSeleccionado
            Fm.Dispose()

            If Not IsNothing(_RowTabcodal) Then
                _Fila.Cells("ALTERNAT").Value = _RowTabcodal.Item("KOPRAL")
            End If

        End If

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
