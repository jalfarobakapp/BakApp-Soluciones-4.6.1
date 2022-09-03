Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports Funciones_BakApp
Public Class Frm_ImpBarrasDisenoDeFormatos


    Private Sub Frm_ImpBarrasDisenoDeFormatos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActualizarGrilla(Grilla)
        CargarEtiqueta()
    End Sub


    Function CargarEtiqueta()
        Txtextobarra.Text = trae_dato(tb, cn1, "FUNCION", "Zw_Tbl_DisenoBarras", "Semilla = " & CodEtiqueta)
        TxtNombreEtiqueta.Text = trae_dato(tb, cn1, "NombreEtiqueta", "Zw_Tbl_DisenoBarras", "Semilla = " & CodEtiqueta)
        ComboBox1.Text = trae_dato(tb, cn1, "CantPorLinea", "Zw_Tbl_DisenoBarras", "Semilla = " & CodEtiqueta)
    End Function

    Function ActualizarGrilla(ByVal Grilla As DataGridView)
        Consulta_sql = "SELECT CodigoTabla as Codigo, NombreTabla as Funcion FROM Zw_TablaDeCaracterizaciones WHERE Tabla = 'ETIQUETASDEBARRA'"
        'ConsultaSQLGrilla = Consulta_sql

        Ejecutar_consulta_SQL(Consulta_sql, cn1)
        tb = New DataTable
        da.Fill(tb)
        Grilla.DataSource = tb

        Grilla.AutoSizeColumnsMode = _
        DataGridViewAutoSizeColumnsMode.AllCells

    End Function

    Function COPIA_ETIQUETA(ByVal etiqueta As String) As String
        Clipboard.Clear()
        Clipboard.SetText(etiqueta) 'Txtleyenda
        MsgBox("El texto se encuentra en el portapapeles", vbInformation, "Copiar")
    End Function

    Private Sub Btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Function GuardarEtiquetaDeBarras()
        Try
            Consulta_sql = "UPDATE TABCOBAR SET FUNCION = '" & Txtextobarra.Text & "' WHERE BARNAME = '" & Nombre_barra & "'"

            Dim cmd As System.Data.SqlClient.SqlCommand
            cmd = New System.Data.SqlClient.SqlCommand()
            cmd.Connection = cn1
            cmd.CommandText = _
                Consulta_sql
            cmd.ExecuteNonQuery()

            MsgBox("Etiqueta actualizada correctamente...")
        Catch ex As Exception
            MsgBox("Problema inesperado...")
        End Try
    End Function


    Private Sub GuardarToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarToolStripButton.Click
        GrabarEtiqueta(CodEtiqueta, TxtNombreEtiqueta.Text, Txtextobarra.Text, ComboBox1.Text)
    End Sub


    Function GrabarEtiqueta(ByVal Semilla As String, _
                            ByVal NombreEtiqueta As String, _
                            ByVal Funcion As String, _
                            ByVal CantPorLinea As String)

        Dim Cadena_Conexion As String = _
                     Ruta_conexion(AppPath(True) & "Cadena_conexion.txt")
        Conectar_SQL("", "", "", "", cn2, Cadena_Conexion)


        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand
        Dim NewSemilla As String

        Try
            myTrans = cn2.BeginTransaction()

            'CrearEncabezadoInsertar(EMPRESA, TIDO, NUDO, ENDO)
            Consulta_sql = "DELETE Zw_Tbl_DisenoBarras WHERE Semilla = " & Semilla
            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Consulta_sql = "INSERT INTO Zw_Tbl_DisenoBarras (NombreEtiqueta,FUNCION,CantPorLinea) VALUES ('" & _
                           NombreEtiqueta & "','" & Funcion & "'," & CantPorLinea & ")"
            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                NewSemilla = dfd1("Identity")
            End While
            dfd1.Close()

            myTrans.Commit()
            cn2.Close()
            Return NewSemilla

        Catch ex As Exception
            MsgBox(ex.Message)
            'myTrans.Rollback()
            MsgBox("Transaccion desecha")
            cn2.Close()
            Return ""
        End Try




    End Function


    Private Sub NuevoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripButton.Click
        Txtextobarra.Text = ""
    End Sub


End Class