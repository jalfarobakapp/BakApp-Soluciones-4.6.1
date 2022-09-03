 Private Sub MetroTileItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTileItem1.Click

        ' hacer una secuencia para llegar una tabla con los codigos madre, cada producto debe tenr su propio codigo madre.
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Truncate Table [@CODMADRE]"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Select KOPR,NOKOPR From MAEPR Where TIPR = 'FPN'"
        Dim _TblProducto As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _i = 1

        For Each _Fila As DataRow In _TblProducto.Rows

            Dim _Kopr As String = _Fila.Item("KOPR")
            Dim _Nokopr As String = Trim(_Fila.Item("NOKOPR"))

            Dim _Reg = _Sql.Fx_Cuenta_Registros("[@CODMADRE]", "KOPR = '" & _Kopr & "'")

            If Not CBool(_Reg) Then

                Consulta_sql = "Select Distinct KOPRREM From TABREMP Where KOPR = '" & _Kopr & "'"
                Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
                Dim _Consulta_sql = String.Empty

                For Each _Row As DataRow In _Tbl.Rows
                    Dim _Koprrem = _Row.Item("KOPRREM")
                    _Consulta_sql += "Insert Into [@CODMADRE] (CODMADRE, KOPR, NOKOPR) Values ('" & _Kopr & "','" & _Koprrem & "','" & _Nokopr & "')" & vbCrLf
                Next

                If Not String.IsNullOrEmpty(_Consulta_sql) Then
                    _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_Consulta_sql)
                End If

            End If

            System.Windows.Forms.Application.DoEvents()
            Frm_Menu.Text = _i & " de " & FormatNumber(_TblProducto.Rows.Count)
            MetroTileItem1.Text = _i & " de " & FormatNumber(_TblProducto.Rows.Count)
            _i += 1

        Next

        MessageBoxEx.Show(Me, "Listo", "Ok", MessageBoxButtons.OK)

    End Sub

    Private Sub MetroTileItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTileItem2.Click

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        _Sql.Sb_Eliminar_Tabla_De_Paso("Zw_Paso1")
        _Sql.Sb_Eliminar_Tabla_De_Paso("Zw_Paso2")

        Consulta_sql = My.Resources.Rs_Familias.SQLQuery_Conjunto_de_codigos_madre_Sierralta
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _i = 1

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Codigo_Madre = _Fila.Item("Codigo_Madre")
            Dim _Codmadre = _Fila.Item("CODMADRE")

            Consulta_sql = "Select Distinct Codigo_Madre,CODMADRE From Zw_Paso1 Where Codigo_Madre = '" & _Codigo_Madre & "'"
            Dim _Tbl1 As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Familia = 1

            If _Tbl1.Rows.Count = 1 Then
                Consulta_sql = "Update Zw_Paso1 Set Familia = '1' Where Codigo_Madre = '" & _Codigo_Madre & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)
            Else '--If _Tbl1.Rows.Count = 2 Then

                For Each _Row As DataRow In _Tbl1.Rows
                    Dim _Cdmd = _Row.Item("CODMADRE")
                    Consulta_sql = "Update Zw_Paso1 Set Familia = '" & _Familia & "' Where CODMADRE = '" & _Cdmd & "'"
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                    _Familia += 1
                Next

                'ElseIf _Tbl1.Rows.Count = 3 Then

                'For Each _Row As DataRow In _Tbl1.Rows
                'Dim _Cdmd = _Row.Item("CODMADRE")
                'Consulta_sql = "Update Zw_Paso1 Set Familia = '" & _Familia & "' Where CODMADRE = '" & _Cdmd & "'"
                '_Sql.Ej_consulta_IDU(Consulta_sql)
                '_Familia += 1
                'Next

            End If
            System.Windows.Forms.Application.DoEvents()

            MetroTileItem1.Text = FormatNumber(_i, 0) & " de " & FormatNumber(_Tbl.Rows.Count, 0)

            _i += 1

        Next
        MessageBoxEx.Show(Me, "Listo", "Ok", MessageBoxButtons.OK)

    End Sub
