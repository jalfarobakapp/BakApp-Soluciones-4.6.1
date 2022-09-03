Imports BkSpecialPrograms
Imports DevComponents.DotNetBar
Public Class Frm_Reprocesar_Ope

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Idpotl As Integer
    Dim _Tbl_Reprocesos As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla_Reporcesos, 20, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Reprocesar_Ope_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Cast(0 As Bit) As Chk,* From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos
                        Where Idpotl = " & _Idpotl & " And IdMeson Not In 
                        (Select IdMeson From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where Idpotl = " & _Idpotl & " And Estado = 'EMQ')
                        And Fabricado > 0"

    End Sub

End Class