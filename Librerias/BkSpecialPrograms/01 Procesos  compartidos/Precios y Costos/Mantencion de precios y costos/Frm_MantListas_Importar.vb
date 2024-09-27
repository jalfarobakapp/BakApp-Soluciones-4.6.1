Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc
Imports System.Data.SqlClient

Public Class Frm_MantListas_Importar

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Emp, _Suc, _Bod As String
    Dim _Nombre_Archivo As String
    Dim _Archivo_Importado_correctamente As Boolean
    Dim _Datos_Lp As New DsListasPC
    'Public _Datos_Lp As Object
    Public _TipoLista As String
    Public _Tabla_Listas As String
    Public _TblPaso As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnAyuda_.ForeColor = Color.White
            BtnImportarDatos.ForeColor = Color.White
        End If

    End Sub

    Public Property Pro_Emp As String
        Get
            Return _Emp
        End Get
        Set(value As String)
            _Emp = value
        End Set
    End Property

    Public Property Pro_Suc As String
        Get
            Return _Suc
        End Get
        Set(value As String)
            _Suc = value
        End Set
    End Property

    Public Property Pro_Bod As String
        Get
            Return _Bod
        End Get
        Set(value As String)
            _Bod = value
        End Set
    End Property

    Public Property Pro_Archivo_Importado_correctamente As Boolean
        Get
            Return _Archivo_Importado_correctamente
        End Get
        Set(value As Boolean)
            _Archivo_Importado_correctamente = value
        End Set
    End Property

    Private Sub BtnAbrir_Archivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAbrir_Archivo.Click


        With OpenFileDialog1
            '.Filter = "Ficheros DBF (PFMDSP10.dbf)|PFMDSP10.dbf|Todos (*.*)|*.*"
            .Filter = "Ficheros (*.xls)|*.xlsx|Todos los archivos (*.*)|*.*"
            'Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
            .FileName = String.Empty
            '.ShowDialog(Me)

            If .ShowDialog(Me) = DialogResult.OK Then
                _Nombre_Archivo = .SafeFileName
                TxtNombreArchivo.Text = .FileName
            Else
                TxtNombreArchivo.Text = String.Empty
            End If
        End With

    End Sub

    Private Sub BtnImportarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportarDatos.Click

        If Not String.IsNullOrEmpty(TxtNombreArchivo.Text) Then

            If _TipoLista = "P" Then
                _Archivo_Importado_correctamente = Importar_LcPrecio(TxtNombreArchivo.Text, 0)
            ElseIf _TipoLista = "C" Then
                _Archivo_Importado_correctamente = Importar_LcCosto(TxtNombreArchivo.Text, 0)
            End If

            If _Archivo_Importado_correctamente Then

                _Sql.Ej_consulta_IDU(Consulta_sql)

                Me.Close()
            Else
                MessageBoxEx.Show(Me, "Problemas de lectura de archivo de origen" & vbCrLf &
                                  "No fue posible crear archivo de paso", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else

            MessageBoxEx.Show(Me, "Debe seleccionar un archivo", "Importar datos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub



    Private Function Importar_LcPrecio(ByVal Ubic_Archivo As String,
                                       ByVal Nro_Hoja As Integer) As Boolean
        Try


            Dim ImpEx As New Class_Importar_Excel
            Dim Extencion As String = Replace(System.IO.Path.GetExtension(_Nombre_Archivo), ".", "")

            Dim Arreglo = ImpEx.Importar_Excel_Array(Ubic_Archivo, Extencion, Nro_Hoja)

            Dim Filas = Arreglo.GetUpperBound(0)
            Dim RegInsert As Long = 0

            Progreso_Porc.Maximum = 100
            Progreso_Cont.Maximum = Filas
            Dim Contador As Integer = 0

            Consulta_sql = String.Empty

            For i = 1 To Filas

                System.Windows.Forms.Application.DoEvents()

                Dim _Lista As String = NuloPorNro(Arreglo(i, 0), "")
                Dim _Codigo As String = NuloPorNro(Arreglo(i, 1), "")
                Dim _Descripcion As String
                Dim _Rtu As Double
                Dim _Ud1 As String '= NuloPorNro(Arreglo(i, 2), 0)
                Dim _Ud2 As String '= NuloPorNro(Arreglo(i, 3), 0)
                Dim _Precio As Double = NuloPorNro(Arreglo(i, 2), 0)
                Dim _Margen As Double = NuloPorNro(Arreglo(i, 3), 0)
                Dim _Margen_Adicional As Double = NuloPorNro(Arreglo(i, 4), 0)
                Dim _Precio2 As Double = NuloPorNro(Arreglo(i, 5), 0)
                Dim _Margen2 As Double = NuloPorNro(Arreglo(i, 6), 0)
                Dim _Margen_Adicional2 As Double = NuloPorNro(Arreglo(i, 7), 0)
                Dim _DsctoMax As Double = NuloPorNro(Arreglo(i, 8), 0)
                Dim _Dscto1 As Double = NuloPorNro(Arreglo(i, 9), 0)
                Dim _Dscto2 As Double = NuloPorNro(Arreglo(i, 10), 0)
                Dim _Dscto3 As Double = NuloPorNro(Arreglo(i, 11), 0)
                Dim _Dscto4 As Double = NuloPorNro(Arreglo(i, 12), 0)
                Dim _Dscto5 As Double = NuloPorNro(Arreglo(i, 13), 0)
                Dim _Flete As Double = NuloPorNro(Arreglo(i, 14), 0)

                Dim Existe_Pr As Boolean
                Existe_Pr = CBool(_Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & _Codigo & "'"))

                If Existe_Pr Then

                    Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"

                    Dim Tb_ = _Sql.Fx_Get_DataTable(Consulta_sql)
                    _Descripcion = Trim(Tb_.Rows(0).Item("NOKOPR")) '_Sql.Fx_Trae_Dato(, "NOKOPR", "MAEPR", "KOPR = '" & _Codigo & "'")
                    _Rtu = Tb_.Rows(0).Item("RLUD") '_Sql.Fx_Trae_Dato(, "RLUD", "MAEPR", "KOPR = '" & _Codigo & "'")
                    _Ud1 = Tb_.Rows(0).Item("UD01PR")
                    _Ud2 = Tb_.Rows(0).Item("UD02PR")
                    '_Cod_Barras = _Sql.Fx_Trae_Dato(, "KOPRAL", "TABCODAL", "KOPR = '" & _Codigo & "' AND KOEN = ''")
                Else
                    _Descripcion = "#NO EXISTE#"
                End If

                Consulta_sql += "Insert Into " & _TblPaso & " (Lista,Codigo,Descripcion,Rtu,Ud1,Ud2,Precio,Margen," &
                                "Margen_Adicional,Precio2,Margen2,Margen_Adicional2,DsctoMax,Dscto1,Dscto2,Dscto3," &
                                "Dscto4,Dscto5,Flete) Values " &
                                "('" & _Codigo & "','" & _Descripcion & "'," & _Rtu & ",'" & _Ud1 & "','" & _Ud2 & "'," &
                                _Precio & "," & _Margen & "," & _Margen_Adicional & "," & _Precio2 &
                                "," & _Margen2 & "," & _Margen_Adicional2 & "," & _DsctoMax & "," & _Dscto1 &
                                "," & _Dscto2 & "," & _Dscto3 & "," & _Dscto4 & "," & _Dscto5 & ")" & vbCrLf

                'Dim NewFila As DataRow
                'NewFila = _Datos_Lp.Tables("LcPrecios").NewRow
                'With NewFila

                '.Item("IdLista") = i
                '.Item("Lista") = _Lista
                '.Item("Codigo") = _Codigo
                '.Item("Descripcion") = _Descripcion
                '.Item("Rtu") = _Rtu
                '.Item("Ud1") = _Ud1
                '.Item("Ud2") = _Ud2
                '.Item("Precio") = _Precio
                '.Item("Margen") = _Margen
                '.Item("Margen_Adicional") = _Margen_Adicional
                '.Item("Precio2") = _Precio2
                '.Item("Margen2") = _Margen2
                '.Item("Margen_Adicional2") = _Margen_Adicional2
                '.Item("DsctoMax") = _DsctoMax
                '.Item("Dscto1") = _Dscto1
                '.Item("Dscto2") = _Dscto2
                '.Item("Dscto3") = _Dscto3
                '.Item("Dscto4") = _Dscto4
                '.Item("Dscto5") = _Dscto5
                '.Item("Flete") = _Flete

                '_Datos_Lp.Tables("LcPrecios").Rows.Add(NewFila)
                'End With

                System.Windows.Forms.Application.DoEvents()
                Contador += 1
                Progreso_Porc.Value = ((Contador * 100) / Filas) 'Mas
                Progreso_Cont.Value += 1

            Next
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Private Function Importar_LcCosto(ByVal Ubic_Archivo As String,
                                      ByVal Nro_Hoja As Integer) As Boolean

        Dim i As Integer

        Dim _Lista As String
        Dim _Codigo As String
        Dim _Cod_Barras As String
        Dim _Ud1, _Ud2 As String
        Dim _Rtu As Double
        Dim _CostoUd1 As Double
        Dim _CostoUd2 As Double
        Dim _Descripcion As String
        Dim _Desc1 As Double
        Dim _Desc2 As Double
        Dim _Desc3 As Double
        Dim _Desc4 As Double
        Dim _Desc5 As Double
        Dim _Flete As Double

        Try

            Dim ImpEx As New Class_Importar_Excel
            Dim Extencion As String = Replace(System.IO.Path.GetExtension(_Nombre_Archivo), ".", "")


            Dim Arreglo = ImpEx.Importar_Excel_Array(Ubic_Archivo, Extencion, Nro_Hoja)

            Dim Filas = Arreglo.GetUpperBound(0)
            Dim RegInsert As Long = 0

            Progreso_Porc.Maximum = 100
            Progreso_Cont.Maximum = Filas 'Dst_Impotar.Tables("Inv_InvParcial").Rows.Count
            Dim Contador As Integer = 0

            For i = 1 To Filas
                'Zzz_TblPasoFO()
                System.Windows.Forms.Application.DoEvents()

                ' Codigo,CantidadUd1,CostoUd1

                _Lista = Arreglo(i, 0)
                _Codigo = Arreglo(i, 1)
                _Cod_Barras = String.Empty    '= Arreglo(i, 2)
                _Rtu = 0
                _CostoUd1 = NuloPorNro(Arreglo(i, 2), 0)
                _CostoUd2 = NuloPorNro(Arreglo(i, 3), 0)
                _Descripcion = String.Empty
                _Desc1 = NuloPorNro(Arreglo(i, 4), 0)
                _Desc2 = NuloPorNro(Arreglo(i, 5), 0)
                _Desc3 = NuloPorNro(Arreglo(i, 6), 0)
                _Desc4 = NuloPorNro(Arreglo(i, 7), 0)
                _Desc5 = NuloPorNro(Arreglo(i, 8), 0)
                _Flete = NuloPorNro(Arreglo(i, 9), 0)
                'Dim _StockUd1 As Double = 0

                Dim _Dscto As Double = 100 * (1 - (
                                             (1 - (_Desc1 / 100.0)) *
                                             (1 - (_Desc2 / 100.0)) *
                                             (1 - (_Desc3 / 100.0)) *
                                             (1 - (_Desc4 / 100.0)) *
                                             (1 - (_Desc5 / 100.0))))

                _Dscto = Math.Round(_Dscto, 2)

                Dim Existe_Pr As Boolean
                Existe_Pr = CBool(_Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & _Codigo & "'"))

                If Existe_Pr Then
                    Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
                    Dim Tbl_Pro As DataTable = _SQL.Fx_Get_DataTable(Consulta_sql)
                    _Descripcion = Tbl_Pro.Rows(0).Item("NOKOPR")
                    _Rtu = Tbl_Pro.Rows(0).Item("RLUD")
                    _Ud1 = Tbl_Pro.Rows(0).Item("UD01PR")
                    _Ud2 = Tbl_Pro.Rows(0).Item("UD02PR")

                    _Cod_Barras = _Sql.Fx_Trae_Dato("TABCODAL", "KOPRAL", "KOPR = '" & _Codigo & "' AND KOEN = ''")
                Else
                    _Descripcion = "#NO EXISTE#"
                End If


                'Dim NewFila As DataRow
                'NewFila = _Datos_Lp.Tables("LcCosto").NewRow
                'With NewFila

                '.Item("IdLista") = i
                '.Item("Lista") = _Lista
                '.Item("CodAlternativo") = _Cod_Barras
                '.Item("Codigo") = _Codigo
                '.Item("Descripcion") = _Descripcion
                '.Item("Rtu") = _Rtu
                '.Item("CostoUd1") = _CostoUd1
                '.Item("CostoUd2") = _CostoUd2
                '.Item("Desc1") = _Desc1
                '.Item("Desc2") = _Desc2
                '.Item("Desc3") = _Desc3
                '.Item("Desc4") = _Desc4
                '.Item("Desc5") = _Desc5
                '.Item("DescSuma") = _Dscto
                '.Item("Flete") = _Flete
                '.Item("Nuevo_Item") = False

                '_Datos_Lp.Tables("LcCosto").Rows.Add(NewFila)
                'End With

                System.Windows.Forms.Application.DoEvents()
                Contador += 1
                Progreso_Porc.Value = ((Contador * 100) / Filas) 'Mas
                Progreso_Cont.Value += 1

                Consulta_sql = "Insert Into " & _TblPaso &
                         " (Lista,Codigo,CodAlternativo,Descripcion,CostoUd1,CostoUd2,Rtu,Ud1,Ud2,FechaVigencia," &
                           "Desc1,Desc2,Desc3,Desc4,Desc5,DescSuma,Flete) Values " &
                           "('" & _Lista & "','" & _Codigo & "','" & _Cod_Barras & "','" & _Descripcion & "'," & De_Num_a_Tx_01(_CostoUd1, False, 5) &
                           "," & De_Num_a_Tx_01(_CostoUd2, False, 5) & "," & De_Num_a_Tx_01(_Rtu, False, 5) &
                           ",'" & _Ud1 & "','" & _Ud2 & "',GetDate()," & De_Num_a_Tx_01(_Desc1, False, 5) &
                           "," & De_Num_a_Tx_01(_Desc2, False, 5) & "," & De_Num_a_Tx_01(_Desc3, False, 5) &
                           "," & De_Num_a_Tx_01(_Desc4, False, 5) & "," & De_Num_a_Tx_01(_Desc5, False, 5) &
                           "," & De_Num_a_Tx_01(_Dscto, False, 5) & "," & _Flete & ")" & vbCrLf

                If Not _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                    MessageBoxEx.Show(Me, "Problema en la fila N° " & i,
                             "Problema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    Consulta_sql = "Truncate table " & _TblPaso
                    _Sql.Ej_consulta_IDU(Consulta_sql, False)

                    Progreso_Porc.Value = 0
                    Progreso_Cont.Value = 0

                    Return False
                End If

            Next



            Return True
        Catch ex As Exception
            MessageBoxEx.Show(Me, "Problema en la fila N° " & i & vbCrLf & ex.Message,
                              "Problema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Consulta_sql = "Truncate table " & _TblPaso
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            Return False
        End Try

    End Function

    Private Sub Frm_MantListas_Importar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '_Datos_Lp.Clear()

        'Dim daAuthors As New SqlDataAdapter(Consulta_sql, cn1)
        'daAuthors.Fill(_Datos_Lp, _Tabla_Listas)

    End Sub

    Sub Sb_Insertar_Linea_Error()

        Dim NewFila As DataRow
        NewFila = _Datos_Lp.Tables(_Tabla_Listas).NewRow

        With NewFila
            .Item("Lista") = ""
        End With

        _Datos_Lp.Tables(_Tabla_Listas).Rows.Add(NewFila)

    End Sub



End Class
