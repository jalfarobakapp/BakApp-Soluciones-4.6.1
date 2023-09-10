Imports DevComponents.DotNetBar

Public Class Frm_ImpBarras_PorOT

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Idpote As Integer
    Dim _Idpotl As Integer

    Dim _Datos_Documento As DataSet
    Dim _Tbl_Pote As DataTable
    Dim _Tbl_Potl As DataTable

    Dim _Puerto, _Etiqueta As String
    Dim _Idmaeedo As String

    Public Sub New(_Idpote As Integer, _Idpotl As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(GrillaEncabezado, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Me._Idpote = _Idpote
        Me._Idpotl = _Idpotl

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_ImpBarras_PorOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim Fm As New Frm_Barras_ConfPuerto("Configuracion_local.xml")

        _Puerto = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Puerto")
        _Etiqueta = Fm.Ds_ConfBarras.Tables("Tbl_Configuracion").Rows(0).Item("Etiqueta")

        Dim _Arr_Filtro(,) As String

        _Arr_Filtro = {{"LPT1", "Puerto LPT1"},
                       {"LPT2", "Puerto LPT2"},
                       {"LPT3", "Puerto LPT3"},
                       {"LPT4", "Puerto LPT4"}}
        Sb_Llenar_Combos(_Arr_Filtro, CmbPuerto)
        CmbPuerto.SelectedValue = "LPT1"

        caract_combo(Cmbetiquetas)
        Consulta_sql = "SELECT NombreEtiqueta AS Padre,NombreEtiqueta+', Cantidad de etiquetas por fila '+RTRIM(LTRIM(STR(CantPorLinea))) AS Hijo" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_Tbl_DisenoBarras order by NombreEtiqueta"
        Cmbetiquetas.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmbetiquetas.SelectedValue = _Etiqueta

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Cmbetiquetas.SelectedIndexChanged, AddressOf Sb_Cmbetiquetas_SelectedIndexChanged

        Call Sb_Cmbetiquetas_SelectedIndexChanged(Nothing, Nothing)

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion_Potl As String

        If CBool(_Idpotl) Then
            _Condicion_Potl = vbCrLf & "And IDPOTL = " & _Idpotl
        End If

        Consulta_sql = "Select * From POTE Where IDPOTE = " & _Idpote & vbCrLf &
                       "Select *,Cast('' As Varchar(21)) As ALTERNAT,Cast(0 As Int) As CANTIDAD From POTL Where IDPOTE = " & _Idpote & _Condicion_Potl

        Consulta_sql = "Select * From POTE Where IDPOTE = " & _Idpote & vbCrLf &
                       "Select POTL.*,Ltd.NroLote,Lte.FechaVenci,Cast('' As Varchar(21)) As ALTERNAT,Cast(0 As Int) As CANTIDAD" & vbCrLf &
                       "From POTL" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Lotes_Det Ltd On IDPOTL = IdTabla" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Lotes_Enc Lte On Ltd.Id_Lote = Lte.Id_Lote" & vbCrLf &
                       "Where IDPOTE = " & _Idpote & _Condicion_Potl

        _Datos_Documento = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Tbl_Pote = _Datos_Documento.Tables(0)
        _Tbl_Potl = _Datos_Documento.Tables(1)

        _Datos_Documento.Dispose()

        Dim _DisplayIndex = 0

        With GrillaEncabezado

            GrillaEncabezado.DataSource = _Tbl_Pote
            OcultarEncabezadoGrilla(GrillaEncabezado, True)

            .Columns("NUMOT").Visible = True
            .Columns("NUMOT").HeaderText = "Nro. OT"
            .Columns("NUMOT").Width = 75
            .Columns("NUMOT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("ESTADO_OT").Visible = True
            '.Columns("ESTADO_OT").HeaderText = "Estado"
            '.Columns("ESTADO_OT").Width = 70
            '.Columns("ESTADO_OT").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("REFERENCIA").Visible = True
            .Columns("REFERENCIA").HeaderText = "Referencia"
            .Columns("REFERENCIA").Width = 305
            .Columns("REFERENCIA").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FIOT").Visible = True
            .Columns("FIOT").HeaderText = "Fecha"
            .Columns("FIOT").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FIOT").Width = 65
            .Columns("FIOT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        'If CantidadCero Then
        '    For Each _Fila As DataRow In _TblDetalle.Rows
        '        _Fila.Item("CANTIDAD") = 0
        '    Next
        'End If

        _DisplayIndex = 0

        _Tbl_Potl.Columns("CANTIDAD").ReadOnly = False

        With Grilla

            .DataSource = _Tbl_Potl

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("NREG").Visible = True
            .Columns("NREG").HeaderText = "SubOt"
            .Columns("NREG").Width = 45
            .Columns("NREG").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CODIGO").Visible = True
            .Columns("CODIGO").HeaderText = "Código"
            .Columns("CODIGO").Width = 100
            .Columns("CODIGO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ALTERNAT").HeaderText = "Cód. Alternativo"
            .Columns("ALTERNAT").Visible = True
            .Columns("ALTERNAT").Width = 120
            .Columns("ALTERNAT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("GLOSA").Visible = True
            .Columns("GLOSA").HeaderText = "Descripción"
            .Columns("GLOSA").Width = 280
            .Columns("GLOSA").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NroLote").Visible = True
            .Columns("NroLote").HeaderText = "Nro. Lote"
            .Columns("NroLote").Width = 60
            .Columns("NroLote").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaVenci").Visible = True
            .Columns("FechaVenci").HeaderText = "F.Vencimiento"
            .Columns("FechaVenci").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaVenci").Width = 70
            .Columns("FechaVenci").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CANTIDAD").HeaderText = "Cantidad"
            .Columns("CANTIDAD").Visible = True
            .Columns("CANTIDAD").Width = 60
            .Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CANTIDAD").ReadOnly = False
            .Columns("CANTIDAD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Sb_Cmbetiquetas_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Dim _Semilla As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras", "Semilla",
                                                    "NombreEtiqueta = '" & Cmbetiquetas.SelectedValue & "'", True)
        Dim _Puerto As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras_SalPtoxEstacion", "Puerto",
                                                  "Semilla_Padre = " & _Semilla & " And NombreEquipo = '" & _NombreEquipo & "'")

        If Not String.IsNullOrEmpty(_Puerto) Then
            CmbPuerto.SelectedValue = _Puerto
        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "ALTERNAT" Then

            Dim _Codigo As String = _Fila.Cells("CODIGO").Value

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
            Dim _Row_Maepr As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Descripcion As String = _Row_Maepr.Item("NOKOPR").Trim
            Dim _Rtu As Double = _Row_Maepr.Item("RLUD")
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

    Private Sub Btnimprimiretiquetas_Click(sender As Object, e As EventArgs) Handles Btnimprimiretiquetas.Click
        Sb_Imprimir_Etiquetas()
    End Sub

    Private Sub Btn_ConfPuertoXEtiquetaXEquipo_Click(sender As Object, e As EventArgs) Handles Btn_ConfPuertoXEtiquetaXEquipo.Click
        If Not Fx_Tiene_Permiso(Me, "7Brr0008") Then Return

        Dim _Grabar As Boolean

        Dim Fm As New Frm_PuertosXEtiquetaXEstacion
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Call Sb_Cmbetiquetas_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub Btn_Conf_PuertoEtiqueta_Click(sender As Object, e As EventArgs) Handles Btn_Conf_PuertoEtiqueta.Click
        If Not Fx_Tiene_Permiso(Me, "7Brr0006") Then Return

        Dim Fm As New Frm_Barras_ConfPuerto("Configuracion_local.xml")
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            CmbPuerto.SelectedValue = Fm.Puerto
            Cmbetiquetas.SelectedValue = Fm.Etiqueta
        End If
        Fm.Dispose()
    End Sub

    Private Sub Btn_Conf_ConfEstacion_Click(sender As Object, e As EventArgs) Handles Btn_Conf_ConfEstacion.Click
        Dim _Autorizado As Boolean

        Dim Fm_Pass As New Frm_Clave_Administrador
        Fm_Pass.ShowDialog(Me)
        _Autorizado = Fm_Pass.Pro_Autorizado
        Fm_Pass.Dispose()

        If _Autorizado Then

            Dim _Grabar As Boolean

            Dim _Id = _Global_Row_EstacionBk.Item("Id")
            Dim Fm As New Frm_RegistrarEquipo(Frm_RegistrarEquipo.Enum_Accion.Editar, _Id, False)
            Fm.ShowDialog(Me)
            _Grabar = Fm.Grabar
            Fm.Dispose()

            Dim _Mod As New Clas_Modalidades

            _Mod.Sb_Actualiza_Formatos_X_Modalidad()
            _Mod.Sb_Actualizar_Variables_Modalidad(Modalidad)

            Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_EstacionesBkp Where NombreEquipo = '" & _NombreEquipo & "'"
            _Global_Row_EstacionBk = _Sql.Fx_Get_DataRow(Consulta_sql)

            If _Grabar Then
                CerrarPorConfigurar = True
                Me.Close()
            End If

        End If
    End Sub

    Sub Sb_Imprimir_Etiquetas()
        Try
            _Etiqueta = Cmbetiquetas.SelectedValue

            'Dim _TblDetalle As DataTable = Grilla.DataSource

            Dim _Suma As Double = _Tbl_Potl.Compute("Sum(CANTIDAD)", "1>0")

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


                For Each _Row_Potl As DataRow In _Tbl_Potl.Rows

                    Dim CanXlinea As Double = _CantPorLinea
                    Dim Veces As Double = _Row_Potl("CANTIDAD").ToString()

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

                        Dim _IdpotlPrint = _Row_Potl.Item("IDPOTL")
                        Dim _Kopral = _Row_Potl.Item("ALTERNAT").ToString.Trim

                        For w = 1 To Val(Veces)

                            Dim _Imp As New Class_Imprimir_Barras

                            _Imp.Sb_Imprimir_Etiqueta_OT(_Puerto, Cmbetiquetas.SelectedValue, _Idpote, _Row_Potl)

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

End Class
