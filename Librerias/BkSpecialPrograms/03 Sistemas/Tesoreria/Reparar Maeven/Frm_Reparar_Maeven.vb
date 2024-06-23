'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Reparar_Maeven

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Documentos As DataTable
    Dim _Row_Entidad As DataRow

    Public Sub New(Row_Entidad As DataRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Row_Entidad = Row_Entidad

    End Sub

    Private Sub Frm_Reparar_Maeven_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Function Fx_Reparar_Maeven(ByVal _Formulario As Form) As Boolean

        Progreso_Kardex.Value = 0

        Try

            Dim _SqlQuery = String.Empty

            Dim _Filtro_Entidad As String

            If (_Row_Entidad Is Nothing) Then
                _Filtro_Entidad = String.Empty
            Else
                _Filtro_Entidad = "And ENDO = '" & _Row_Entidad.Item("KOEN") & "'"
            End If

            Consulta_sql = My.Resources.Recursos_Reparar_Maeven.SQLQuery_Reparar_Maeven
            Consulta_sql = Replace(Consulta_sql, "#Filtro_Entidad#", _Filtro_Entidad)
            _Tbl_Documentos = _Sql.Fx_Get_DataTable(Consulta_sql)

            Progreso_Kardex.Maximum = 100

            Dim i = 0

            For Each _Fila As DataRow In _Tbl_Documentos.Rows

                Dim _Idmaeedo = _Fila.Item("_ID")
                Dim _Abonar As Double = _Fila.Item("ABONAR")

                Consulta_sql = "Select * From MAEVEN Where IDMAEEDO = " & _Idmaeedo
                Dim _Tbl_Maeven As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                For Each _Fila_Mv As DataRow In _Tbl_Maeven.Rows

                    Dim _Idmaeven = _Fila_Mv.Item("IDMAEVEN")
                    Dim _Vave = _Fila_Mv.Item("VAVE")
                    Dim _Vaabve = _Fila_Mv.Item("VAABVE")

                    Dim _Saldo As Double = _Vave - _Vaabve

                    If CBool(_Saldo) Then
                        If _Saldo > _Abonar Then
                            _SqlQuery += "UPDATE MAEVEN SET VAABVE += " & De_Num_a_Tx_01(_Abonar, False, 5) & Space(1) &
                                         "WHERE IDMAEVEN = " & _Idmaeven & vbCrLf
                        Else
                            _SqlQuery += "UPDATE MAEVEN SET VAABVE += " & De_Num_a_Tx_01(_Saldo, False, 5) & Space(1) &
                                         "WHERE IDMAEVEN = " & _Idmaeven & vbCrLf
                        End If
                    End If

                    _Abonar = _Abonar - _Saldo
                    If _Abonar <= 0 Then Exit For

                Next

                _SqlQuery += vbCrLf

                i += 1
                System.Windows.Forms.Application.DoEvents()

                Progreso_Kardex.Value = ((i * 100) / _Tbl_Documentos.Rows.Count) 'Mas
                Progreso_Kardex.Text = FormatNumber(i, 0) & " de " & FormatNumber(_Tbl_Documentos.Rows.Count, 0)

            Next

            _SqlQuery += vbCrLf & "UPDATE MAEVEN SET ESPGVE = 'C' WHERE ESPGVE = '' AND ROUND(VAVE,0) - ROUND(VAABVE,0) = 0"

            '-- Esta consulta libera los documentos con saldo pendiente, pero no aparecen en Random para pagar
            'UPDATE MAEEDO SET ESPGDO = 'P'
            'WHERE  VAABDO - VABRDO < 0 AND TIDO IN ('FCC') AND ESPGDO = 'C'

            Progreso_Kardex.Value = 0

            Return _Sql.Ej_consulta_IDU(_SqlQuery)

        Catch ex As Exception
            MessageBoxEx.Show(_Formulario, ex.Message, "BakApp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally

        End Try

    End Function

    Private Sub Btn_Procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Procesar.Click

        If Fx_Reparar_Maeven(Me) Then

        End If

    End Sub


End Class
