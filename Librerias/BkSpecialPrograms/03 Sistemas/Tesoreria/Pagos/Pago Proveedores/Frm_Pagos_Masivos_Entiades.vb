'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Pagos_Masivos_Entiades

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Dim _Id_Autoriza As Integer
    Dim _TblInforme As DataTable

    Dim _Id_Correo As Integer

    Public Sub New(ByVal Id_Autoriza As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Id_Autoriza = Id_Autoriza
       Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Pagos_Masivos_Entiades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "SELECT IDMAEVEN,IDMAEEDO As Id,CAST('' As Varchar(13)) As RTEN,CAST('' As Varchar(50)) As NOKOEN," & vbCrLf &
                       "VAVE,VAABVE,VAVE-VAABVE As SALDO,1 AS DOC" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "FROM MAEVEN WHERE IDMAEVEN IN (Select Idmaeven From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det" & Space(1) &
                       "Where Id_Autoriza = " & _Id_Autoriza & ")" & vbCrLf & vbCrLf &
                       "Update #Paso Set RTEN = (Select Top 1 RTEN From MAEEN Where KOEN In (Select ENDO From MAEEDO Where IDMAEEDO = Id))" & vbCrLf &
                       "Update #Paso Set NOKOEN = (Select Top 1 NOKOEN From MAEEN Where KOEN In (Select ENDO From MAEEDO Where IDMAEEDO = Id))" & vbCrLf & vbCrLf &
                       "Select RTEN,NOKOEN,SUM(VAVE) AS VAVE,SUM(VAABVE) AS VAABVE,SUM(SALDO) As SALDO,SUM(DOC) As DOC From #Paso" & vbCrLf &
                       "Group By RTEN,NOKOEN" & vbCrLf & vbCrLf &
                       "--Select SUM(SALDO) As Total From #Paso" & vbCrLf &
                       "Drop Table #Paso"

        _TblInforme = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _TblInforme
            OcultarEncabezadoGrilla(Grilla, True)

            Dim _Menos = 10

            .Columns("NOKOEN").Width = 280
            .Columns("NOKOEN").HeaderText = "Proveedor"
            .Columns("NOKOEN").Visible = True

            .Columns("VAVE").HeaderText = "Total Pagar"
            .Columns("VAVE").Width = 80
            .Columns("VAVE").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("VAVE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAVE").Visible = True

            .Columns("VAABVE").HeaderText = "Total Pagado"
            .Columns("VAABVE").Width = 80
            .Columns("VAABVE").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("VAABVE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAABVE").Visible = True

            .Columns("SALDO").HeaderText = "Saldo"
            .Columns("SALDO").Width = 80
            .Columns("SALDO").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO").Visible = True

            .Columns("DOC").HeaderText = "Doc."
            .Columns("DOC").Width = 40
            .Columns("DOC").DefaultCellStyle.Format = "###,##0"
            .Columns("DOC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DOC").Visible = True


        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Saldo As Double = _Fila.Cells("SALDO").Value

            If Not CBool(_Saldo) Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.ForeColor = Color.FromArgb(95, 95, 95)
                Else
                    _Fila.DefaultCellStyle.ForeColor = Color.Gray
                End If
            End If

        Next

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Saldo As Double = _Fila.Cells("SALDO").Value

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_01_Enc Where Id_Autoriza = " & _Id_Autoriza
        Dim _Row_Pago_Autorizado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Rten = _Fila.Cells("RTEN").Value
        Dim _Koen = _Sql.Fx_Trae_Dato("MAEEN", "KOEN", "RTEN = '" & _Rten & "'")

        Consulta_sql = "SELECT Min(FEVE) As Fecha_Inicio,MAX(FEVE) As Fecha_Fin" & vbCrLf &
                       "FROM MAEVEN WHERE IDMAEVEN IN (Select Idmaeven From " & vbCrLf &
                       _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where Id_Autoriza = " & _Id_Autoriza & ")"

        Dim _Row_Fechas As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Fecha_Inicio As Date = _Row_Fechas.Item("Fecha_Inicio")
        Dim _Fecha_Fin As Date = _Row_Fechas.Item("Fecha_Fin")

        Dim _Filtro_Adicional As String = "And IDMAEVEN In (Select Idmaeven" & Space(1) &
                                          "From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det" & Space(1) &
                                          "Where Id_Autoriza = " & _Id_Autoriza & Space(1) &
                                          "And Idmaeedo In (Select IDMAEEDO From MAEEDO Where ENDO = '" & _Koen & "'))"

        Dim Fm As New Frm_Pagos_Masivos_Detalle(Frm_Pagos_Masivos_Detalle.Enum_Tipo_Pago.Proveedores,
                                                 _Fecha_Inicio,
                                                 _Fecha_Fin,
                                                 _Id_Correo)
        Fm.Pro_Mostrar_Solo_Por_Pagar = False

        Fm.Pro_Row_Pago_Autorizado = _Row_Pago_Autorizado
        Fm.Pro_Filtro_Adicional = _Filtro_Adicional
        Fm.ShowDialog(Me)
        Fm.Dispose()


        Consulta_sql = "SELECT IDMAEVEN,IDMAEEDO As Id,CAST('' As Varchar(13)) As RTEN,CAST('' As Varchar(50)) As NOKOEN," & vbCrLf &
                       "VAVE,VAABVE,VAVE-VAABVE As SALDO" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "FROM MAEVEN WHERE IDMAEVEN IN (Select Idmaeven From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det" & Space(1) &
                       "Where Id_Autoriza = " & _Id_Autoriza & ")" & vbCrLf & vbCrLf &
                       "Update #Paso Set RTEN = (Select Top 1 RTEN From MAEEN Where KOEN In (Select ENDO From MAEEDO Where IDMAEEDO = Id))" & vbCrLf &
                       "Update #Paso Set NOKOEN = (Select Top 1 NOKOEN From MAEEN Where KOEN In (Select ENDO From MAEEDO Where IDMAEEDO = Id))" & vbCrLf & vbCrLf &
                       "Select Top 1 RTEN,NOKOEN,SUM(VAVE) AS VAVE,SUM(VAABVE) AS VAABVE,SUM(SALDO) As SALDO From #Paso" & vbCrLf &
                       "Where RTEN = '" & _Rten & "'" & vbCrLf &
                       "Group By RTEN,NOKOEN" & vbCrLf & vbCrLf &
                       "--Select SUM(SALDO) As Total From #Paso" & vbCrLf &
                       "Drop Table #Paso"

        Dim _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then

            Dim _Vave As Double = _Tbl.Rows(0).Item("VAVE")
            Dim _Vaabve As Double = _Tbl.Rows(0).Item("VAABVE")

            _Saldo = _Tbl.Rows(0).Item("SALDO")

            _Fila.Cells("VAVE").Value = _Vave
            _Fila.Cells("VAABVE").Value = _Vaabve
            _Fila.Cells("SALDO").Value = _Saldo

            If CBool(_Saldo) Then
                If Global_Thema <> Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.ForeColor = Color.Black
                End If
            Else
                _Fila.DefaultCellStyle.ForeColor = Color.Gray
            End If

        Else
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Frm_Pagos_Masivos_Entiades_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class
