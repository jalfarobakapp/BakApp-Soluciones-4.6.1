Imports DevComponents.DotNetBar

Public Class Frm_BuscarCtasContables

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowCtaSeleccionada As DataRow
    Dim _CtaBuscar As String

    Public Property RowCtaSeleccionada As DataRow
        Get
            Return _RowCtaSeleccionada
        End Get
        Set(value As DataRow)
            _RowCtaSeleccionada = value
        End Set
    End Property

    Public Property CtaBuscar As String
        Get
            Return _CtaBuscar
        End Get
        Set(value As String)
            _CtaBuscar = value
            Txt_Descripcion.Text = _CtaBuscar
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_BuscarCtasContables_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

        Me.ActiveControl = Txt_Descripcion

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Percontact As String = _Sql.Fx_Trae_Dato("TABFU", "PERCONTACT", "KOFU = '" & FUNCIONARIO & "'")
        Dim _Texto_Busqueda As String = Txt_Descripcion.Text.Trim

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "GRANCUE+MAYOR+CUENTA+NOCUENTA LIKE '%")

        Consulta_sql = "Select *,GRANCUE+MAYOR+CUENTA As CtaOrigen," & vbCrLf &
                       "Case When TCC = 'SI' Then 'Si' Else 'No' End As 'Con_Cc',		-- Tiene centro de costo" & vbCrLf &
                       "Case When TIENESUB = 'SI' Then 'Si' Else 'No' End As 'Con_Sub', -- Tiene Sub auxiliar" & vbCrLf &
                       "Case When ESBANCO = 1 Then 'Si' Else 'No' End As 'Es_Bco',		-- Es Cuenta de banco" & vbCrLf &
                       "Case When ESACTFI = 1 Then 'Si' Else 'No' End As 'Es_AF',		-- Es Activo fijo" & vbCrLf &
                       "Case When ESEXIST = 1 Then 'Si' Else 'No' End As 'Es_Exi',		-- Es existencia" & vbCrLf &
                       "Case When ESFJEF = 1 Then 'Si' Else 'No' End As 'Fl_Efe',		-- Es flujo efectivo" & vbCrLf &
                       "Case When ESAJUINF = 1 Then 'Si' Else 'No' End As 'Ti_AjuInf',	-- Tiene ajuste por inflación" & vbCrLf &
                       "Case When CONANALISI = 1 Then 'Si' Else 'No' End As 'Con_Ana'	-- Posee análisis" & vbCrLf &
                       "From CCUENTAS" & vbCrLf &
                       "Where PERIODO = '" & _Percontact & "' And 1>0" & vbCrLf &
                       "And GRANCUE+MAYOR+CUENTA+NOCUENTA LIKE '%" & _Cadena & "%'" & vbCrLf &
                       "Order By PERIODO,GRANCUE,MAYOR,CUENTA"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("GRANCUE").Width = 30
            .Columns("GRANCUE").HeaderText = "Gr"
            .Columns("GRANCUE").Visible = True
            .Columns("GRANCUE").ToolTipText = "Gran cuenta"
            .Columns("GRANCUE").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MAYOR").Width = 30
            .Columns("MAYOR").HeaderText = "Suc."
            .Columns("MAYOR").Visible = True
            .Columns("MAYOR").ToolTipText = "May"
            .Columns("MAYOR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CUENTA").Width = 30
            .Columns("CUENTA").HeaderText = "Cta"
            .Columns("CUENTA").Visible = True
            .Columns("CUENTA").ToolTipText = "Gran cuenta"
            .Columns("CUENTA").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOCUENTA").Width = 200
            .Columns("NOCUENTA").HeaderText = "Nombre de la cuenta"
            .Columns("NOCUENTA").Visible = True
            '.Columns("NOCUENTA").ToolTipText = "Gran cuenta"
            .Columns("NOCUENTA").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Con_Cc").Width = 60
            .Columns("Con_Cc").HeaderText = "Con C.C."
            .Columns("Con_Cc").Visible = True
            .Columns("Con_Cc").ToolTipText = "Tiene centro de costo"
            .Columns("Con_Cc").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Con_Sub").Width = 60
            .Columns("Con_Sub").HeaderText = "Con Sub"
            .Columns("Con_Sub").Visible = True
            .Columns("Con_Sub").ToolTipText = "Tiene Sub auxiliar"
            .Columns("Con_Sub").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Es_Bco").Width = 60
            .Columns("Es_Bco").HeaderText = "Es Bco"
            .Columns("Es_Bco").Visible = True
            .Columns("Es_Bco").ToolTipText = "Es Cuenta de banco"
            .Columns("Es_Bco").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Es_AF").Width = 60
            .Columns("Es_AF").HeaderText = "Es A.F."
            .Columns("Es_AF").Visible = True
            .Columns("Es_AF").ToolTipText = "Es Activo fijo"
            .Columns("Es_AF").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Es_Exi").Width = 60
            .Columns("Es_Exi").HeaderText = "Es Exi"
            .Columns("Es_Exi").Visible = True
            .Columns("Es_Exi").ToolTipText = "Es existencia"
            .Columns("Es_Exi").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fl_Efe").Width = 60
            .Columns("Fl_Efe").HeaderText = "Fl Efe"
            .Columns("Fl_Efe").Visible = True
            .Columns("Fl_Efe").ToolTipText = "Es flujo efectivo"
            .Columns("Fl_Efe").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Descripcion.KeyDown

        If e.KeyValue = Keys.Down Then

            e.Handled = True
            Grilla.Focus()

        ElseIf e.KeyValue = Keys.Space And Not String.IsNullOrEmpty(Txt_Descripcion.Text.Trim) Then

            Sb_Actualizar_Grilla()

        ElseIf e.KeyValue = Keys.Enter Then

            Sb_Actualizar_Grilla()

            If CBool(Grilla.Rows.Count) Then
                Grilla.Focus()
            Else
                Beep()
                ToastNotification.Show(Me, "NO SE ENCONTRARON REGISTROS CON ESA DEFINICION", My.Resources.cross,
                                       2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            End If

        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Periodo = _Fila.Cells("PERIODO").Value
        Dim _Grancue = _Fila.Cells("GRANCUE").Value
        Dim _Mayor = _Fila.Cells("MAYOR").Value
        Dim _Cuenta = _Fila.Cells("CUENTA").Value

        Consulta_sql = "Select *,GRANCUE+MAYOR+CUENTA As CtaOrigen From CCUENTAS" & vbCrLf &
                       "Where PERIODO = '" & _Periodo & "' And GRANCUE = '" & _Grancue & "' And MAYOR = '" & _Mayor & "' And CUENTA = '" & _Cuenta & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row) Then
            _RowCtaSeleccionada = _Row
            Me.Close()
        End If

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown

        If CBool(Grilla.RowCount) Then

            Dim _Key As Keys = e.KeyValue

            Select Case _Key

                Case Keys.Enter

                    SendKeys.Send("{LEFT}")
                    e.Handled = True
                    Call Grilla_CellDoubleClick(Nothing, Nothing)

            End Select

        End If

    End Sub
End Class
