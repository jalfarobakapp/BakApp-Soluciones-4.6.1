Imports DevComponents.DotNetBar

Public Class Frm_PreVentasPDA

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Tbl_Preventas As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, True, False)
        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_PreVentasPDA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "SELECT Pda.IDPDAENCA,Pda.KOFUDO,Pda.NUDO,Pda.SUDO,Pda.VALIDO,Pda.FEEMDO,Pda.HORAFIN,Pda.ENDO,Pda.SUENDO,Ent.NOKOEN," &
                       "Pda.VABRDO,Pda.OBS,Pda.FECULTSIN,Pda.HORULTSIN,Pda.TPOGRAB,Pda.TPOPROTRA,Pda.EMPRESA,Pda.LINEAS," & vbCrLf &
                       "CAST(0 AS BIT) AS TRASPASAR," &
                       "CAST(0 AS BIT) AS NOPDA," &
                       "CAST(0 AS FLOAT) AS CRSD," &
                       "CAST(0 AS FLOAT) AS CRLT," &
                       "CAST(0 AS FLOAT) AS CRCH," &
                       "CAST(0 AS FLOAT) AS CRPA," &
                       "CAST(0 AS BIT) AS STOCKSUP," &
                       "CAST(0 AS BIT) AS DSCTOSUP," &
                       "CAST(0 AS BIT) AS CRDTOSUP," &
                       "CAST(0 AS BIT) AS MOROSISUP," &
                       "Ent.KOFUEN,Ent.RUTALUN,Ent.RUTAMAR,Ent.RUTAMIE,Ent.RUTAJUE,Ent.RUTAVIE,Ent.RUTASAB,Ent.RUTADOM" & vbCrLf &
                       "FROM PDAENCA Pda WITH (NOLOCK)" & vbCrLf &
                       "LEFT JOIN MAEEN Ent ON Pda.ENDO = Ent.KOEN AND Pda.SUENDO = Ent.SUEN" & vbCrLf &
                       "WHERE VALIDO='S' AND EMPRESA='" & Mod_Empresa & "'" & vbCrLf &
                       "ORDER BY KOFUDO,TIDO,NUDO,ENDO"
        _Tbl_Preventas = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Preventas

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            '.Columns("BtnImagen_Estado").Width = 30
            '.Columns("BtnImagen_Estado").HeaderText = "Est."
            '.Columns("BtnImagen_Estado").Visible = _MostrarImagenes
            '.Columns("BtnImagen_Estado").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("KOFUEN").Visible = True
            .Columns("KOFUEN").HeaderText = "Ven"
            .Columns("KOFUEN").ToolTipText = "Vendedor"
            .Columns("KOFUEN").Width = 30
            .Columns("KOFUEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").Visible = True
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 70
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUDO").Visible = True
            .Columns("SUDO").HeaderText = "Suc"
            .Columns("SUDO").Width = 30
            .Columns("SUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nudo").Visible = True
            .Columns("Nudo").HeaderText = "Número"
            .Columns("Nudo").Width = 90
            .Columns("Nudo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMDO").Visible = True '(_Tbas.Name = "Tab_Completadas")
            .Columns("FEEMDO").HeaderText = "Fecha"
            .Columns("FEEMDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEEMDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMDO").Width = 70
            .Columns("FEEMDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ENDO").Visible = True
            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Width = 80
            .Columns("ENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SUENDO").Visible = True
            .Columns("SUENDO").HeaderText = "Suc.Ent"
            .Columns("SUENDO").ToolTipText = "Sucursal de la entidad"
            .Columns("SUENDO").Width = 80
            .Columns("SUENDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").HeaderText = "Razón Social"
            '.Columns("NOKOEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NOKOEN").Width = 350
            .Columns("NOKOEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("VABRDO").Width = 100
            .Columns("VABRDO").HeaderText = "Total Bruto"
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VABRDO").DefaultCellStyle.Format = "###,##0.##"
            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("LINEAS").Width = 50
            .Columns("LINEAS").HeaderText = "Ítems"
            .Columns("LINEAS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("LINEAS").Visible = True
            .Columns("LINEAS").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1


        End With

        Me.Cursor = Cursors.Default

    End Sub

    ' PSEUDOCÓDIGO (detalle de los pasos a implementar):
    ' 1) Verificar que el índice de fila (e.RowIndex) sea válido (>= 0).
    ' 2) Obtener el DataBoundItem de la fila: TryCast(Grilla.Rows(e.RowIndex).DataBoundItem, DataRowView).
    ' 3) Si se obtiene un DataRowView, extraer la DataRow con .Row.
    ' 4) Si DataRowView es Nothing, intentar obtener la fila desde _Tbl_Preventas usando el índice (fallback).
    ' 5) Usar la DataRow obtenida para leer columnas o para pasarla a la clase Cl_PDARandomMovil.
    ' 6) Manejar nulos/DBNull y casos en que la fila no exista.
    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        ' 1) Validar índice
        If e.RowIndex < 0 Then
            Return
        End If

        ' 2) Intentar obtener DataRowView a partir de DataBoundItem
        Dim drv As DataRowView = TryCast(Grilla.Rows(e.RowIndex).DataBoundItem, DataRowView)

        Dim _FilaDataRow As DataRow = Nothing

        If drv IsNot Nothing Then
            ' 3) Sacar DataRow directamente
            _FilaDataRow = drv.Row
        Else
            ' 4) Fallback: intentar obtener desde la tabla enlazada si existe y el índice es válido
            If _Tbl_Preventas IsNot Nothing AndAlso e.RowIndex >= 0 AndAlso e.RowIndex < _Tbl_Preventas.Rows.Count Then
                _FilaDataRow = _Tbl_Preventas.Rows(e.RowIndex)
            End If
        End If

        ' 5) Si no se obtuvo ninguna DataRow, salir
        If _FilaDataRow Is Nothing Then
            Return
        End If

        '' 6) Ejemplo de uso: leer campos con manejo de DBNull y crear/usar la clase Cl_PDARandomMovil
        'Dim _KOFUDO As String = String.Empty
        'If Not IsDBNull(_FilaDataRow("KOFUDO")) Then
        '    _KOFUDO = _FilaDataRow.Field(Of String)("KOFUDO")
        'End If

        Dim _Mensaje As New LsValiciones.Mensajes


        ' Crear instancia de la clase y pasar datos según su API
        Dim _Cl_PDARandomMovil As New Cl_PDARandomMovil

        '_Mensaje = _Cl_PDARandomMovil.Fx_Importar_NVV_Desde_PDARandomMOVIL_NVVAuto(_FilaDataRow)

        'If Not _Mensaje.EsCorrecto Then
        '    MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        _Mensaje = _Cl_PDARandomMovil.Fx_Crear_NVV_PDARandomMOVIL(_FilaDataRow, Mod_Modalidad)

        '_Mensaje = _Cl_PDARandomMovil.Fx_RevisarSituacionComercialCliente(_FilaDataRow, Date.Now)

        If _Mensaje.EsCorrecto Then

        End If

    End Sub

End Class
