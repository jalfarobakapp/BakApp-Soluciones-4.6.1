Imports DevComponents.DotNetBar

Public Class Frm_Conf_Importar_Compras_SII

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Conf_Importar_Compras_SII_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim _Periodo = Year(Now.Date)

        Input_Periodo.Value = _Periodo
        Input_Periodo.MaxValue = _Periodo

        Dim _Fecha As Date = Now.Date
        Dim _Mes = Month(_Fecha)

        Select Case _Mes
            Case 1
                Rdb_01_Enero.Checked = True
            Case 2
                Rdb_02_Febrero.Checked = True
            Case 3
                Rdb_03_Marzo.Checked = True
            Case 4
                Rdb_04_Abril.Checked = True
            Case 5
                Rdb_05_Mayo.Checked = True
            Case 6
                Rdb_06_Junio.Checked = True
            Case 7
                Rdb_07_Julio.Checked = True
            Case 8
                Rdb_08_Agosto.Checked = True
            Case 9
                Rdb_09_Septiembre.Checked = True
            Case 10
                Rdb_10_Octubre.Checked = True
            Case 11
                Rdb_11_Noviembre.Checked = True
            Case 12
                Rdb_12_Diciembre.Checked = True
        End Select

    End Sub

    Private Sub Btn_Libro_SII_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cargar_Libro_SII.Click

        If Fx_Tiene_Permiso(Me, "RSii00002") Then

            Dim _Periodo = Input_Periodo.Value
            Dim _Mes = Fx_Mes_Rdb()

            Dim Fm As New Frm_Importar_Compras_SII(_Periodo, _Mes)
            Fm.Text = "Importar compras desde SII (" & UCase(MonthName(_Mes)) & ")"
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Compras_en_SII", "Periodo = " & _Periodo & " And Mes = " & _Mes)

            If CBool(_Reg) Then
                Dim Fm_SII As New Frm_Libro_Compras_Ventas(_Periodo, _Mes)
                Fm_SII.ShowDialog(Me)
                Fm_SII.Dispose()
            Else
                MessageBoxEx.Show(Me, "No existen datos para este periodo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If

    End Sub

    Sub Sb_Crear_Tabla_De_Paso_SII(ByRef _Tabla_Paso As String)

        _Tabla_Paso = "Zz_Compras_en_SII_" & FUNCIONARIO

        _Sql.Sb_Eliminar_Tabla_De_Paso(_Global_BaseBk & _Tabla_Paso)

        Consulta_sql = "CREATE TABLE " & _Global_BaseBk & "[" & _Tabla_Paso & "](" & vbCrLf &
                       "[Id]                       [int]          IDENTITY(1,1) NOT NULL," & vbCrLf &
                       "[Idmaeedo]                 [int]          Default(0)," & vbCrLf &
                       "[TipoDoc]                  [int]          Default(0)," & vbCrLf &
                       "[Tido]                     [char](3)      Default('')," & vbCrLf &
                       "[Nudo]                     [char](10)     Default('')," & vbCrLf &
                       "[Endo]                     [char](13)     Default('')," & vbCrLf &
                       "[Libro]                    [char](14)     Default('')," & vbCrLf &
                       "[Rut_Proveedor]            [varchar](15)  Default('')," & vbCrLf &
                       "[Razon_Social]             [varchar](100) Default('')," & vbCrLf &
                       "[Folio]                    [varchar](10)  Default('')," & vbCrLf &
                       "[Idmaeedo_Sugerido]        [int]          Default(0)," & vbCrLf &
                       "[Tido_Sugerido]            [char](3)      Default('')," & vbCrLf &
                       "[Nudo_Sugerido]            [varchar](10)  Default('')," & vbCrLf &
                       "[Libro_Sugerido]           [char](14)     Default('')," & vbCrLf &
                       "[Fecha_Docto]              [date]         NULL," & vbCrLf &
                       "[Fecha_Recepcion]          [date]         NULL," & vbCrLf &
                       "[Fecha_Acuse]              [date]         NULL," & vbCrLf &
                       "[Monto_Exento]             [float]        Default(0)," & vbCrLf &
                       "[Monto_Neto]               [float]        Default(0)," & vbCrLf &
                       "[Monto_Iva_Recuperable]    [float]        Default(0)," & vbCrLf &
                       "[Monto_Iva_No_Recuperable] [float]        Default(0)," & vbCrLf &
                       "[Monto_Total]              [float]        Default(0)," & vbCrLf &
                       "[Valor_Otro_impuesto]      [float]        Default(0)," & vbCrLf &
                       "[Vanedo]                   [float]        Default(0)," & vbCrLf &
                       "[Vaivdo]                   [float]        Default(0)," & vbCrLf &
                       "[Vabrdo]                   [float]        Default(0)," & vbCrLf &
                       "[Diferencia]               [float]        Default(0)," & vbCrLf &
                       ") ON [PRIMARY]"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "Select Cast(Case When object_id('" & _Global_BaseBk & _Tabla_Paso & "') > 0 Then 1 Else 0 End As Bit) As Existe"
        Dim _RowExiste As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not (_RowExiste.Item("Existe")) Then
            _Tabla_Paso = String.Empty
        End If

        _Tabla_Paso = _Global_BaseBk & _Tabla_Paso

    End Sub

    Function Fx_Mes_Rdb() As Integer

        If Rdb_01_Enero.Checked Then Return 1
        If Rdb_02_Febrero.Checked Then Return 2
        If Rdb_03_Marzo.Checked Then Return 3
        If Rdb_04_Abril.Checked Then Return 4
        If Rdb_05_Mayo.Checked Then Return 5
        If Rdb_06_Junio.Checked Then Return 6
        If Rdb_07_Julio.Checked Then Return 7
        If Rdb_08_Agosto.Checked Then Return 8
        If Rdb_09_Septiembre.Checked Then Return 9
        If Rdb_10_Octubre.Checked Then Return 10
        If Rdb_11_Noviembre.Checked Then Return 11
        If Rdb_12_Diciembre.Checked Then Return 12

    End Function

    Private Sub Btn_Abrir_Libro_SII_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Abrir_Libro_SII.Click

        Dim _Periodo = Input_Periodo.Value
        Dim _Mes = Fx_Mes_Rdb()

        'Dim _Clas_Hefesto_Dte_Libro As New Clas_Hefesto_Dte_Libro

        '_Clas_Hefesto_Dte_Libro.Circular_Progres_Porc = Circular_Progres_Porc
        '_Clas_Hefesto_Dte_Libro.Circular_Progres_Val = Circular_Progres_Val

        'If System.IO.File.Exists(_Clas_Hefesto_Dte_Libro.Directorio_Hefesto & "\SISTEMA\HEFESTO_LIBROS.exe") Then 'Application.StartupPath & "\BakApp_Demonio.exe") Then

        '    Dim _Cadena_ConexionSQL_Server_Actual As String = Replace(Cadena_ConexionSQL_Server, " ", "@")
        '    Dim _Ejecutar As String = _Clas_Hefesto_Dte_Libro.Directorio_Hefesto & "\SISTEMA\HEFESTO_LIBROS.exe" & Space(1) & RutEmpresa & Space(1) & _Periodo & "-" & numero_(_Mes, 2)

        '    Try
        '        Shell(_Ejecutar, AppWinStyle.NormalFocus, True)
        '    Catch ex As Exception
        '        MessageBoxEx.Show(Me,
        '                ex.Message, "Libro de compras...", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '        Return
        '    End Try

        'Else

        '    MessageBoxEx.Show(Me,
        '                "No se encontro el archivo HEFESTO_LIBROS.exe en el directorio (" & _Clas_Hefesto_Dte_Libro.Directorio_Hefesto & "\SISTEMA)",
        '                "Hefesto_DTE", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return

        'End If

        'If _Clas_Hefesto_Dte_Libro.Fx_Importar_Archivo_SII_Compras_Desde_XML(_Periodo, _Mes) Then

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Compras_en_SII", "Periodo = " & _Periodo & " And Mes = " & _Mes)

        If CBool(_Reg) Then
            Dim Fm_SII As New Frm_Libro_Compras_Ventas(_Periodo, _Mes)
            Fm_SII.ShowDialog(Me)
            Fm_SII.Dispose()
        Else
            MessageBoxEx.Show(Me, "No existen datos para este periodo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        'End If

    End Sub

End Class
