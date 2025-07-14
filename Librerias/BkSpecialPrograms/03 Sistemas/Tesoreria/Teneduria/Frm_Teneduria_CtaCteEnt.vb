Imports DevComponents.DotNetBar

Public Class Frm_Teneduria_CtaCteEnt

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Koen As String
    Dim _Suen As String

    Dim _Tbl_Maedpcde_CtaCte As DataTable
    Dim _Row_Maedpcde_CtaCte As DataRow
    Dim _Tbl_Maedpce_Pago As DataTable

    Dim _Solo_Ver As Boolean

    Public Property Tbl_Maedpcde_CtaCte As DataTable
        Get
            Return _Tbl_Maedpcde_CtaCte
        End Get
        Set(value As DataTable)
            _Tbl_Maedpcde_CtaCte = value
        End Set
    End Property

    Public Property Row_Maedpcde_CtaCte As DataRow
        Get
            Return _Row_Maedpcde_CtaCte
        End Get
        Set(value As DataRow)
            _Row_Maedpcde_CtaCte = value
        End Set
    End Property

    Public Property Solo_Ver As Boolean
        Get
            Return _Solo_Ver
        End Get
        Set(value As Boolean)
            _Solo_Ver = value
        End Set
    End Property

    Public Sub New(Koen As String, Suen As String, Tbl_Maedpce_Pago As DataTable)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        _Koen = Koen
        _Suen = Suen

        _Tbl_Maedpce_Pago = Tbl_Maedpce_Pago

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Maedpce, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Llenar_Tabla(Koen)

    End Sub

    Private Sub Frm_Teneduria_CtaCteEnt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Datos_Grilla()

    End Sub

    Sub Sb_Actualizar_Datos_Grilla()

        With Grilla_Maedpce

            .DataSource = _Tbl_Maedpcde_CtaCte

            OcultarEncabezadoGrilla(Grilla_Maedpce, True)

            .Columns("TIDP").HeaderText = "TD"
            .Columns("TIDP").Width = 30
            .Columns("TIDP").Visible = True

            .Columns("NUCUDP").HeaderText = "Número doc."
            .Columns("NUCUDP").Width = 80
            .Columns("NUCUDP").Visible = True

            .Columns("FEEMDP").HeaderText = "F.Emisión"
            .Columns("FEEMDP").Width = 80
            .Columns("FEEMDP").Visible = True

            .Columns("FEVEDP").HeaderText = "F.venci."
            .Columns("FEVEDP").Width = 80
            .Columns("FEVEDP").Visible = True

            .Columns("MODP").HeaderText = "Mon"
            .Columns("MODP").Width = 20
            .Columns("MODP").Visible = True

            .Columns("VADP").HeaderText = "Monto"
            .Columns("VADP").Width = 80
            .Columns("VADP").Visible = True
            .Columns("VADP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VADP").DefaultCellStyle.Format = "$ ###,##.##"

            .Columns("VAASDP").HeaderText = "Asignado"
            .Columns("VAASDP").Width = 80
            .Columns("VAASDP").Visible = True
            .Columns("VAASDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAASDP").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("VAASDP").ReadOnly = _Solo_Ver

            .Columns("SALDO").HeaderText = "Saldo a Favor"
            .Columns("SALDO").Width = 90
            .Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("SALDO").Visible = True

            .Columns("REFANTI").HeaderText = "Referencia"
            .Columns("REFANTI").Width = 190
            .Columns("REFANTI").Visible = True

        End With

        Dim _Rojo, _Azul, _Verde As Color

        If Global_Thema = Enum_Themas.Oscuro Then

            _Rojo = Color.FromArgb(220, 78, 66)
            _Azul = Color.FromArgb(37, 136, 213)
            _Verde = Color.FromArgb(30, 215, 96)

        Else

            _Rojo = Color.Red
            _Azul = Color.Blue
            _Verde = Color.Green

        End If

        For Each _Fila As DataGridViewRow In Grilla_Maedpce.Rows

            _Fila.Cells("SALDO").Style.ForeColor = _Verde

            Dim _Idmaedpce_Gr As Integer = _Fila.Cells("IDMAEDPCE").Value

            If Not _Solo_Ver Then

                For Each _Fl As DataRow In _Tbl_Maedpce_Pago.Rows

                    Dim _Idmaedpce_Tb As Integer = _Fl.Item("IDMAEDPCE")
                    Dim _Vadp As Double = _Fl.Item("VADP")

                    If _Idmaedpce_Gr = _Idmaedpce_Tb Then

                        _Fila.Cells("VAASDP").Value = _Vadp
                        _Fila.Cells("Utilizado").Value = True
                        _Fila.Cells("SALDO").Value -= _Vadp

                        If _Fila.Cells("SALDO").Value = 0 Then
                            _Fila.Visible = False
                        End If

                        _Fila.Cells("SALDO").Style.ForeColor = _Rojo

                    End If

                Next

            End If

        Next

    End Sub

    Sub Sb_Llenar_Tabla(_Koen As String)

        Consulta_sql = "Select Cast(0 As Bit) As Utilizado,DPCE.IDMAEDPCE,DPCE.EMPRESA,DPCE.TIDP,DPCE.NUDP,DPCE.ENDP,DPCE.EMDP,DPCE.SUEMDP,DPCE.CUDP,DPCE.NUCUDP,DPCE.FEEMDP, 
                        DPCE.FEVEDP,DPCE.MODP,DPCE.TIMODP,DPCE.TAMODP,DPCE.VADP,DPCE.VAABDP,DPCE.VAASDP,DPCE.VADP-DPCE.VAASDP As SALDO,DPCE.VAVUDP,DPCE.ESPGDP,DPCE.REFANTI, 
                        Isnull(DPCE.ARCHIRSD,'') As ARCHIRSD,Isnull(DPCE.IDRSD,0) As IDRSD    
                        From MAEDPCE AS DPCE  WITH ( NOLOCK )  
                        Where DPCE.ENDP = '" & _Koen & "' AND 
                              DPCE.TIDP IN ('ATB','CHV','CPV','CRV','DEP','EFV','LTV','PAV','RBV','RGV','RIV','TJV','VUE') AND 
                              DPCE.ESASDP = 'P' AND DPCE.ESPGDP<> 'N'  AND DPCE.EMPRESA = '" & Mod_Empresa & "' And DPCE.VADP-DPCE.VAASDP > 0"
        _Tbl_Maedpcde_CtaCte = _Sql.Fx_Get_DataTable(Consulta_sql)

    End Sub

    Private Sub Grilla_Maedpce_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Maedpce.CellDoubleClick

        If _Solo_Ver Then
            Beep()
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

        Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value
        Dim _Utilizado As Boolean = _Fila.Cells("Utilizado").Value

        If _Utilizado Then

            MessageBoxEx.Show(Me, "Este registro ya esta siendo utilizado para pagar el documento." & vbCrLf &
                              "Si quiere cambiar el valor a utilizar debe eliminar la fila desde el formulario de pagos para soltar el registro y volverlo a utilizar",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        Dim _Saldo As Double = _Fila.Cells("SALDO").Value
        Dim _Saldo_Utilizar As Double = _Saldo

        Dim _Aceptar As Boolean = InputBox_Bk(Me, "Confirme la cantidad a utilizar", "Saldo a favor", _Saldo_Utilizar, False, _Tipo_Mayus_Minus.Normal,, True,
                                              _Tipo_Imagen.Transferencia_bancaria, , _Tipo_Caracter.Moneda, False)

        If _Aceptar Then

            If _Saldo_Utilizar > _Saldo Then

                MessageBoxEx.Show(Me, "La cantidad ingresada no puede ser mayor al saldo a favor " & FormatCurrency(_Saldo, 0), "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

            Consulta_sql = "Select *," & De_Num_a_Tx_01(_Saldo_Utilizar, False, 5) & " As SALDO From MAEDPCE Where IDMAEDPCE = " & _Idmaedpce
            _Row_Maedpcde_CtaCte = _Sql.Fx_Get_DataRow(Consulta_sql)

            Me.Close()

        End If

    End Sub

    Private Sub Frm_Teneduria_CtaCteEnt_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyValue = Keys.Escape Then

            Me.Close()

        End If

    End Sub

    Private Sub Grilla_Maedpce_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla_Maedpce.KeyDown

        Dim _Cabeza = Grilla_Maedpce.Columns(Grilla_Maedpce.CurrentCell.ColumnIndex).Name
        Dim _Tecla As Keys = e.KeyValue

        If _Tecla = Keys.Enter Then

            Call Grilla_Maedpce_CellDoubleClick(Nothing, Nothing)

            e.SuppressKeyPress = False
            e.Handled = True

        End If

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Call Grilla_Maedpce_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Grilla_Maedpce_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Maedpce.CellEnter

        Lbl_Banco_Cta_Cte.Text = String.Empty

        Try
            Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

            Dim _Tidp = _Fila.Cells("TIDP").Value
            Dim _Emdp = _Fila.Cells("EMDP").Value
            Dim _Cudp = _Fila.Cells("CUDP").Value
            Dim _Nucudp = _Fila.Cells("NUCUDP").Value

            Dim _Archirsd = _Fila.Cells("ARCHIRSD").Value
            Dim _Idrsd = _Fila.Cells("IDRSD").Value

            Dim _Nokoendp = String.Empty
            Dim _Doc_Asociado = _Sql.Fx_Trae_Dato("MAEEDO", "'Documento asociado: '+TIDO+'-'+NUDO", "IDMAEEDO = " & _Idrsd)

            If Not String.IsNullOrEmpty(_Doc_Asociado) Then
                _Doc_Asociado = Space(5) & "(" & _Doc_Asociado & ")"
            End If

            If _Tidp = "DEP" Or _Tidp = "ATB" Then
                Consulta_sql = "Select Top 1 * From TABENDP Where TIDPEN = 'CH' And KOENDP = '" & _Emdp & "' And CTACTE = '" & _Cudp & "'"
            Else
                Consulta_sql = "Select Top 1 * From TABENDP Where TIDPEN = 'CH' And KOENDP = '" & _Emdp & "'"
            End If

            Dim _Row_Cuenta As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Cuenta) Then
                _Nokoendp = _Row_Cuenta.Item("NOKOENDP").ToString.Trim
                Lbl_Banco_Cta_Cte.Text = _Nokoendp & ", Cta. Cte: " & _Cudp & ", Nro: " & _Nucudp & _Doc_Asociado
            End If
        Catch ex As Exception

        End Try

    End Sub

End Class
