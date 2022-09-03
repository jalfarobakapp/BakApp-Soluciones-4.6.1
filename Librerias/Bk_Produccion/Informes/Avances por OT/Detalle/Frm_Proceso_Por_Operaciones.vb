Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_Proceso_Por_Operaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Nro_Ot As String

    Dim _Tbl_Productos As DataTable
    Dim _Tbl_Operaciones As DataTable

    Public Sub New(ByVal Nro_Ot As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Nro_Ot = Nro_Ot

        Sb_Formato_Generico_Grilla(Grilla_Productos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Operaciones, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Proceso_Por_Operaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "SELECT POTPR.*,CAST('' AS VARCHAR(50)) AS DESCRIPCION_PR,POPER.NOMBREOP,POPER.UDAD,POPER.OBREROS,POPER.CODMAQ,PVELPROP.NOOPPR," &
                       "PVELPROP.CODMAQOPPR,Cast('' As varchar(50)) As NOMBREMAQ " & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "FROM POTPR WITH ( NOLOCK ) " & vbCrLf &
                       "LEFT OUTER JOIN POPER ON POTPR.OPERACION=POPER.OPERACION " & vbCrLf &
                       "LEFT OUTER JOIN PVELPROP ON POTPR.OPERACION=PVELPROP.OPERACION AND POTPR.CODIGO = PVELPROP.KOPR" & vbCrLf &
                       "WHERE POTPR.NUMOT='" & _Nro_Ot & "'" &
                       vbCrLf &
                       "Update #Paso Set DESCRIPCION_PR = (Select Top 1 NOKOPR From MAEPR Where KOPR = CODIGO)" & vbCrLf &
                       "Update #Paso Set NOMBREMAQ = (Select Top 1 NOMBREMAQ From PMAQUI Z2 Where Z2.CODMAQ = Z1.CODMAQ) From #Paso Z1" & vbCrLf &
                       "Select Distinct IDPOTL,NUMOT,NREGOTL,CODIGO,DESCRIPCION_PR,Round(Sum(REALIZADO)/Sum(FABRICAR),2) As Porc_Avance" & vbCrLf &
                       "Into #Paso2" & vbCrLf &
                       "From #Paso" & vbCrLf &
                       "Group By IDPOTL,NUMOT,NREGOTL,CODIGO,DESCRIPCION_PR" & vbCrLf &
                       "Order By NREGOTL" & vbCrLf &
                       "Select * From #Paso2" & vbCrLf &
                       "Select IDPOTPR,IDPOTL,EMPRESA,NUMOT,NREGOTL,CODIGO,DESCRIPCION_PR,ORDEN,OPERACION,NOMBREOP," &
                       "CODMAQ,NOMBREMAQ,FABRICAR,REALIZADO" & vbCrLf &
                       "From #Paso" & vbCrLf &
                       "Order By NREGOTL,ORDEN" & vbCrLf &
                       "Drop Table #Paso" & vbCrLf &
                       "Drop Table #Paso2"

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
        ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
        _Ds.Relations.Add("Rel_Detalle_Productos",
                          _Ds.Tables("Table").Columns("IDPOTL"),
                          _Ds.Tables("Table1").Columns("IDPOTL"), False)

        _Tbl_Productos = _Ds.Tables(0)
        _Tbl_Operaciones = _Ds.Tables(1)

        Grilla_Productos.DataSource = _Ds
        Grilla_Productos.DataMember = "Table"

        'Muestra segunda relacion
        Grilla_Operaciones.DataSource = _Ds
        Grilla_Operaciones.DataMember = "Table.Rel_Detalle_Productos"

        OcultarEncabezadoGrilla(Grilla_Productos, True)
        OcultarEncabezadoGrilla(Grilla_Operaciones, True)

        With Grilla_Productos

            .Columns("NUMOT").Width = 80
            .Columns("NUMOT").HeaderText = "Número OT"
            .Columns("NUMOT").Visible = True
            .Columns("NUMOT").DisplayIndex = 0

            .Columns("NREGOTL").Width = 60
            .Columns("NREGOTL").HeaderText = "Sub OT"
            .Columns("NREGOTL").Visible = True
            .Columns("NREGOTL").DisplayIndex = 1

            .Columns("CODIGO").Width = 100
            .Columns("CODIGO").HeaderText = "Código"
            .Columns("CODIGO").Visible = True
            '.Columns("CODIGO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("CODIGO").DisplayIndex = 2

            .Columns("DESCRIPCION_PR").Width = 480
            .Columns("DESCRIPCION_PR").HeaderText = "Descripción"
            .Columns("DESCRIPCION_PR").Visible = True
            '.Columns("DESCRIPCION_PR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DESCRIPCION_PR").DisplayIndex = 3

            .Columns("Porc_Avance").Width = 60
            .Columns("Porc_Avance").HeaderText = "% Avance"
            .Columns("Porc_Avance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Avance").DefaultCellStyle.Format = "% #0.##"
            .Columns("Porc_Avance").Visible = True
            .Columns("Porc_Avance").DisplayIndex = 4

        End With


        With Grilla_Operaciones

            .Columns("ORDEN").Width = 50
            .Columns("ORDEN").HeaderText = "Orden"
            .Columns("ORDEN").Visible = True
            .Columns("ORDEN").DisplayIndex = 0

            .Columns("OPERACION").Width = 70
            .Columns("OPERACION").HeaderText = "Operación"
            .Columns("OPERACION").Visible = True
            .Columns("OPERACION").DisplayIndex = 1

            .Columns("NOMBREOP").Width = 240
            .Columns("NOMBREOP").HeaderText = "Nombre operación"
            .Columns("NOMBREOP").Visible = True
            .Columns("NOMBREOP").DisplayIndex = 2

            .Columns("CODMAQ").Width = 80
            .Columns("CODMAQ").HeaderText = "Máquina"
            .Columns("CODMAQ").Visible = True
            .Columns("CODMAQ").DisplayIndex = 3

            .Columns("NOMBREMAQ").Width = 240
            .Columns("NOMBREMAQ").HeaderText = "Nombre máquina"
            .Columns("NOMBREMAQ").Visible = True
            .Columns("NOMBREMAQ").DisplayIndex = 4

            .Columns("FABRICAR").Width = 50
            .Columns("FABRICAR").HeaderText = "Fabr."
            .Columns("FABRICAR").Visible = True
            .Columns("FABRICAR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FABRICAR").DisplayIndex = 5

            .Columns("REALIZADO").Width = 50
            .Columns("REALIZADO").HeaderText = "Reali."
            .Columns("REALIZADO").Visible = True
            .Columns("REALIZADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("REALIZADO").DisplayIndex = 6

        End With

    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Btn_Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

End Class
