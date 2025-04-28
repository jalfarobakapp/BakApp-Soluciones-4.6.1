Imports DevComponents.DotNetBar

Public Class Frm_RevMayMin

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_RevMayMin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Panel_Fechas.Enabled = False
        Lbl_Holding.Enabled = False
        Txt_Cliente.Enabled = False

    End Sub

    Private Sub Btn_Procesar_Click(sender As Object, e As EventArgs) Handles Btn_Procesar.Click

        Dim _FechaServidor As Date = FechaDelServidor()
        Dim _Tbl As DataTable

        Try

            Consulta_sql = Fx_ConsultaSql()

            If String.IsNullOrEmpty(Consulta_sql) Then
                Return
            End If

            _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _Cl_DocListaSuperior As New Cl_DocListaSuperior

            Circular_Progres_Porc.Maximum = 100
            Circular_Progres_Val.Maximum = _Tbl.Rows.Count

            Dim _Contador As Integer = 0

            TxtLog.Text = String.Empty

            For Each _Fila As DataRow In _Tbl.Rows

                Dim _Lista As String = _Fila.Item("Lista")
                Dim _ListaSuperior As String = _Fila.Item("ListaSuperior")
                Dim _ListaInferior As String = _Fila.Item("ListaInferior")
                Dim _EsListaSuperior As Boolean = _Fila.Item("EsListaSuperior")
                Dim _EsListaInferior As Boolean = _Fila.Item("EsListaInferior")
                Dim _CodHolding As String = _Fila.Item("CodHolding")
                Dim _Koen As String = _Fila.Item("Koen")
                Dim _Suen As String = _Fila.Item("Suen")
                Dim _Nokoen As String = _Fila.Item("Nokoen")
                Dim _VentaMinVencLP As Integer = _Fila.Item("VentaMinVencLP")

                Lbl_Estado.Text = "Revisando " & FormatNumber(_Contador + 1, 0) & " de " & FormatNumber(_Tbl.Rows.Count, 0)

                System.Windows.Forms.Application.DoEvents()

                If _EsListaSuperior Or _EsListaInferior Then

                    Dim _Mensaje As New LsValiciones.Mensajes

                    If _Koen.Trim = "76694946" Then
                        Dim a = 1
                    End If

                    _Mensaje = _Cl_DocListaSuperior.Fx_RevisarSiMantieneLista(_Koen.Trim, _Lista, _VentaMinVencLP)

                    Dim _Cumple As Boolean = _Mensaje.EsCorrecto

                    _Fila.Item("Cumple") = _Cumple

                    _Mensaje.Mensaje = _Mensaje.Detalle

                    If _Cumple And _EsListaInferior Then
                        _Fila.Item("CambiarLista") = True
                        _Fila.Item("NewLista") = _ListaSuperior
                    ElseIf Not _Cumple And _EsListaSuperior Then
                        _Fila.Item("CambiarLista") = True
                        _Fila.Item("NewLista") = _ListaInferior
                    Else
                        _Mensaje.Mensaje = "Entidad: " & _Koen & " - " & _Nokoen & ", mantiene su lista de precios (" & _Lista & ")"
                    End If

                    AddToLog("Rev.Entidad", _Koen.Trim & " - " & _Nokoen.Trim & ": " & _Mensaje.Mensaje)

                Else

                    AddToLog("Rev.Entidad", "Entidad: " & _Koen.Trim & " - " & _Nokoen.Trim & ", Lista: " & _Lista)

                End If

                System.Windows.Forms.Application.DoEvents()
                _Contador += 1
                Circular_Progres_Porc.Value = ((_Contador * 100) / _Tbl.Rows.Count) 'Mas
                Circular_Progres_Val.Value += 1

            Next

            ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Minoristas Mayoristas")

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Lbl_Estado.Text = String.Empty

        End Try

    End Sub

    Function Fx_ConsultaSql() As String

        Dim _Consulta_Sql As String = String.Empty

        If Rdb_RevTodosClientes.Checked Then

            _Consulta_Sql = "Select Distinct KOEN As Koen,SUEN As Suen,NOKOEN As Nokoen,TIEN,Isnull(CodHolding,'') As CodHolding,Substring(LVEN,6,3) As Lista,Lp.EsListaSuperior," & vbCrLf &
                           "Cast(Case When Lp.ListaSuperior <> '' Then 1 Else 0 End As bit) As 'EsListaInferior',Lp.ListaSuperior," & vbCrLf &
                           "Lp.ListaInferior,Cast(Case When Lp.ListaSuperior <> '' Then Lp2.VentaMinVencLP Else Lp.VentaMinVencLP End As Float) As 'VentaMinVencLP'," & vbCrLf &
                           "CAST(0 As Bit) As 'Cumple',CAST(0 As Bit) As 'CambiarLista',CAST('' As varchar(3)) As NewLista" & vbCrLf &
                           "From MAEEN" & vbCrLf &
                           "Inner Join " & _Global_BaseBk & "Zw_ListaPreGlobal Lp On Lp.Lista = Substring(LVEN,6,3)" & vbCrLf &
                           "Left Join " & _Global_BaseBk & "Zw_ListaPreGlobal Lp2 On Lp2.Lista = Lp.ListaSuperior" & vbCrLf &
                           "Left Join " & _Global_BaseBk & "Zw_Entidades Ent On Ent.CodEntidad = KOEN And Ent.CodSucEntidad = SUEN"

        End If

        If Rdb_RevVentasRangoFecha.Checked Then

            _Consulta_Sql = "Select Distinct ENDO As Koen,SUENDO As Suen,NOKOEN As Nokoen,Isnull(CodHolding,'') As CodHolding,Substring(LVEN,6,3) As Lista,Lp.EsListaSuperior," & vbCrLf &
                           "Cast(Case When Lp.ListaSuperior <> '' Then 1 Else 0 End As bit) As 'EsListaInferior',Lp.ListaSuperior," & vbCrLf &
                           "Lp.ListaInferior,Cast(Case When Lp.ListaSuperior <> '' Then Lp2.VentaMinVencLP Else Lp.VentaMinVencLP End As Float) As 'VentaMinVencLP'," & vbCrLf &
                           "CAST(0 As Bit) As 'Cumple',CAST(0 As Bit) As 'CambiarLista',CAST('' As varchar(3)) As NewLista " & vbCrLf &
                           "From MAEEDO" & vbCrLf &
                           "Inner Join MAEEN On KOEN = ENDO And SUEN = SUENDO" & vbCrLf &
                           "Inner Join " & _Global_BaseBk & "Zw_ListaPreGlobal Lp On Lp.Lista = Substring(LVEN,6,3)" & vbCrLf &
                           "Left Join " & _Global_BaseBk & "Zw_ListaPreGlobal Lp2 On Lp2.Lista = Lp.ListaSuperior" & vbCrLf &
                           "Left Join " & _Global_BaseBk & "Zw_Entidades Ent On Ent.CodEntidad = ENDO And Ent.CodSucEntidad = SUENDO" & vbCrLf &
                           "Where TIDO = 'FCV' And FEEMDO between '" & Format(Dtp_Fecha_Vta_Desde.Value, "yyyyMMdd") & "' And '" & Format(Dtp_Fecha_Vta_Hasta.Value, "yyyyMMdd") & "'"

        End If

        If Rdb_Cliente.Checked Then

            Dim _Row_Cliente As DataRow = Txt_Cliente.Tag

            If IsNothing(_Row_Cliente) Then
                MessageBoxEx.Show(Me, "Debe seleccionar un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return String.Empty
            End If

            _Consulta_Sql = "Select Distinct KOEN As Koen,SUEN As Suen,NOKOEN As Nokoen,TIEN,Isnull(CodHolding,'') As CodHolding,Substring(LVEN,6,3) As Lista,Lp.EsListaSuperior," & vbCrLf &
                            "Cast(Case When Lp.ListaSuperior <> '' Then 1 Else 0 End As bit) As 'EsListaInferior',Lp.ListaSuperior," & vbCrLf &
                            "Lp.ListaInferior,Cast(Case When Lp.ListaSuperior <> '' Then Lp2.VentaMinVencLP Else Lp.VentaMinVencLP End As Float) As 'VentaMinVencLP'," & vbCrLf &
                            "CAST(0 As Bit) As 'Cumple',CAST(0 As Bit) As 'CambiarLista',CAST('' As varchar(3)) As NewLista" & vbCrLf &
                            "From MAEEN" & vbCrLf &
                            "Inner Join " & _Global_BaseBk & "Zw_ListaPreGlobal Lp On Lp.Lista = Substring(LVEN,6,3)" & vbCrLf &
                            "Left Join " & _Global_BaseBk & "Zw_ListaPreGlobal Lp2 On Lp2.Lista = Lp.ListaSuperior" & vbCrLf &
                            "Left Join " & _Global_BaseBk & "Zw_Entidades Ent On Ent.CodEntidad = KOEN And Ent.CodSucEntidad = SUEN" & vbCrLf &
                            "Where KOEN = '" & _Row_Cliente.Item("KOEN") & "' And SUEN = '" & _Row_Cliente.Item("SUEN") & "'"

        End If

        Return _Consulta_Sql

    End Function

    Private Sub AddToLog(Accion As String,
                     Descripcion As String)
        TxtLog.Text += DateTime.Now.ToString() & " - " & Accion & " (" & Descripcion & ")" & vbCrLf
        TxtLog.Select(TxtLog.Text.Length - 1, 0)
        TxtLog.ScrollToCaret()
    End Sub

    Private Sub Rdb_RevVentasRangoFecha_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_RevVentasRangoFecha.CheckedChanged
        Panel_Fechas.Enabled = Rdb_RevVentasRangoFecha.Checked
    End Sub

    Private Sub Rdb_Cliente_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Cliente.CheckedChanged
        Lbl_Holding.Enabled = Rdb_Cliente.Checked
        Txt_Cliente.Enabled = Rdb_Cliente.Checked
    End Sub

    Private Sub Txt_Cliente_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Cliente.ButtonCustomClick

        Dim _Row_Cliente As DataRow

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.ShowInTaskbar = False
        Fm.ShowDialog(Me)

        If Fm.Pro_Entidad_Seleccionada Then

            _Row_Cliente = Fm.Pro_RowEntidad

            Dim _Koen As String = _Row_Cliente.Item("KOEN")
            Dim _Suen As String = _Row_Cliente.Item("SUEN")

            Txt_Cliente.Text = _Row_Cliente.Item("KOEN").ToString.Trim & " - " & _Row_Cliente.Item("NOKOEN").ToString.Trim
            Txt_Cliente.Tag = _Row_Cliente

            Consulta_sql = "Select CodHolding,NombreTabla From " & _Global_BaseBk & "Zw_Entidades" & vbCrLf &
                           "Inner Join " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones On " &
                           "Tabla = 'ENTIDADES_HOLDING' And CodigoTabla = CodHolding" & vbCrLf &
                           "Where CodEntidad= '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"
            Dim _Row_Holding As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Holding) Then
                Lbl_Holding.Text = "Holding: No pertenece a ningún Holding."
            Else
                Lbl_Holding.Text = "Holding: " & _Row_Holding.Item("CodHolding").ToString.Trim & " - " & _Row_Holding.Item("NombreTabla")
            End If

            Btn_Procesar.Focus()

        End If

        Fm.Dispose()

    End Sub
End Class
