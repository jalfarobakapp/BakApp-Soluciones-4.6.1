Imports DevComponents.DotNetBar
Imports System.Drawing.Printing
Imports BkSpecialPrograms

Public Class Clas_Impirmir_Operaciones_OT_Barras

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Empresa, _Sucursal, _Bodega As String
    Dim _TblProductos As DataTable
    Private prtSettings As PrinterSettings
    Dim _Filas_X_Documento As Integer = 9
    Dim _Row_Comprobante As DataRow

    Dim _Item = 1
    Dim _Pagina = 1

    Dim _Nro_OT As String
    Dim _Sub_OT As String

    Dim _Ds_Ot As DataSet
    Dim _Tbl_00_Pote As DataTable
    Dim _Tbl_01_Potl As DataTable
    Dim _Tbl_02_Potd As DataTable
    Dim _Tbl_03_Potpr As DataTable

    Dim _Tbl_Productos_En_Meson As DataTable
    Dim _Row_Meson As DataRow

    Dim _Row_Entidad As DataRow

    Public Property Pro_Filas_X_Documento() As Integer
        Get
            Return _Filas_X_Documento
        End Get
        Set(value As Integer)
            _Filas_X_Documento = value
        End Set
    End Property
    Public Property Pro_Nro_OT() As String
        Get
            Return _Nro_OT
        End Get
        Set(value As String)
            _Nro_OT = value
            Sb_Traer_OT()
        End Set
    End Property
    Public Property Pro_Sub_OT() As String
        Get
            Return _Sub_OT
        End Get
        Set(value As String)
            _Sub_OT = value
        End Set
    End Property

#Region "FUENTES"

    Dim DtFont As New Font("Arial", 9, FontStyle.Regular) ' Fuente del detalle
    Dim prFont As New Font("Arial", 9, FontStyle.Bold)
    Dim FontNro As New Font("Times New Roman", 14, FontStyle.Bold)
    Dim FontCon As New Font("Times New Roman", 11, FontStyle.Bold)

    Dim FteCourier_New_C_4 As New Font("Courier New", 4, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_6 As New Font("Courier New", 6, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_7 As New Font("Courier New", 7, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_8 As New Font("Courier New", 8, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_9 As New Font("Courier New", 9, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_10 As New Font("Courier New", 10, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_11 As New Font("Courier New", 11, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_12 As New Font("Courier New", 12, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_13 As New Font("Courier New", 13, FontStyle.Bold) ' Crea la fuente
    Dim FteCourier_New_C_14 As New Font("Courier New", 13, FontStyle.Bold) ' Crea la fuente

#End Region

    Public Sub New()

    End Sub

    Sub Sb_Traer_OT()

        Consulta_sql = My.Resources.Recursos_OT.SqlQuery_Traer_OT
        Consulta_sql = Replace(Consulta_sql, "#Numot#", _Nro_OT)

        _Ds_Ot = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Tbl_00_Pote = _Ds_Ot.Tables(0)
        _Tbl_01_Potl = _Ds_Ot.Tables(1)
        _Tbl_02_Potd = _Ds_Ot.Tables(2)
        _Tbl_03_Potpr = _Ds_Ot.Tables(3)

        Dim _Koen = _Tbl_00_Pote.Rows(0).Item("ENDO")
        Dim _Suen = _Tbl_00_Pote.Rows(0).Item("SUENDO")

        _Row_Entidad = Fx_Traer_Datos_Entidad(_Koen, _Suen)

    End Sub

    Sub Sb_Traer_Meson(_Codmeson As String)

        Consulta_sql = "Select Cast(0 As Bit) As Chk,IdMeson, Codmeson,Estado,Ms.Idpote,Idpotpr,Substring(Ms.Numot,6,10) As Numot,Nreg,
                        Rtrim(Ltrim(Nreg))+'-'+Rtrim(Ltrim(str(Orden_Potpr))) As SubOt,REFERENCIA As Referencia,Codigo,Operacion,Nombreop,Glosa,
                        FIOT as Fecha_Ot,Fecha_Asignacion As Fecha_Asignacion,
                        DATEDIFF(DD,FIOT,GETDATE()) As Dias,DATEDIFF(DD,Fecha_Asignacion,GETDATE()) As Dias_En_Meson,Fecha_Asignacion As Hora,
	                    Orden_Meson,Orden_Potpr,Fabricar,Fabricar-Fabricando As Fabricar_New,Fabricado,Fabricando,Saldo_Fabricar,Porc_Avance_Saldo_Fab,
                        Saldo_Fabricar-Fabricando As Saldo_Fabricar_New,Idpotl,Idpotpr,CODMAQOT,Cast('' As Varchar) As Tiempo_En_Meson,
                        Isnull(Pd.Grado,0) AS Grado,Case Grado When 0 Then 3 Else Grado End Orden,
                        1 as Contador,Cast(0 as Bit) As Impreso" & vbCrLf &
                        "From " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Ms" & vbCrLf &
                        "INNER JOIN POTPR ON Idpotpr=IDPOTPR" & vbCrLf &
                        "INNER JOIN POTE ON Idpote=IDPOTE" & vbCrLf &
                        "Left JOIN " & _Global_BaseBk & "Zw_Pdp_OT_Prioridad Pd ON Pd.Idpote=IDPOTE" & vbCrLf &
                        "WHERE --Ms.Codmeson='" & _Codmeson & "' AND Ms.Estado In ('PD','DM','MQ') And POTE.ESTADO In ('V','S')" & vbCrLf &
                        "(Ms.Codmeson='" & _Codmeson & "' AND Ms.Estado In ('PD','DM') And POTE.ESTADO In ('V','S'))" & vbCrLf &
                        "Or" & vbCrLf &
                        "(IdMeson In (Select IdMeson From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Where Codmeson='" & _Codmeson & "' AND Estado='EMQ') " &
                        "And Ms.Estado = 'MQ' And Ms.Codmeson='" & _Codmeson & "' And POTE.ESTADO In ('V','S'))" & vbCrLf &
                        "ORDER BY Orden_Meson"


        _Tbl_Productos_En_Meson = _Sql.Fx_Get_DataTable(Consulta_sql)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Codmeson = '" & _Codmeson & "'"
        _Row_Meson = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Enum _Enum_Tipo_Impresion
        Hoja_de_ruta
        Operarios
        Productos_En_Meson
        Portada_OT
        Vale_Comprante_EnvRec
    End Enum

    Public Function Fx_Imprimir_Archivo(_Formulario As Form,
                                        _Nombre_documento As String,
                                        ByRef _Impresora As String,
                                        _Tipo_Impresion As _Enum_Tipo_Impresion)

        Try

            ' ejemplo simple para imprimir en .NET
            ' Usamos una clase del tipo PrintDocument

            Dim printDoc As New PrintDocument

            'Dim pd As Printing.PrintDocument
            'pd = New Printing.PrintDocument

            'Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 100, 5000)
            'printDoc.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1

            'Dim pkCustomSize1 As New Printing.PaperSize(PaperKind.Legal, 850, 1400)

            ' CON ESTA CONFIGURACION PODEMOS PROPORCIONAR LAS DIMENCIONES Y ESTADO DE LA PAGINA, MARGENES, LARGO Y HORIENTACION

            Dim pkCustomSize1 As New Printing.PaperSize(PaperKind.Legal, 850, 1400)

            Dim PageSetupDialog1 As New PageSetupDialog

            PageSetupDialog1.Document = printDoc
            PageSetupDialog1.PageSettings.Landscape = False

            PageSetupDialog1.PageSettings.PaperSize = pkCustomSize1
            PageSetupDialog1.PageSettings.Margins.Left = 2
            PageSetupDialog1.PageSettings.Margins.Right = 2

            PageSetupDialog1.ShowDialog()

            'Dim PageSetupDialog1 As New PageSetupDialog

            'PageSetupDialog1.Document = printDoc
            'PageSetupDialog1.PageSettings.Landscape = False
            'PageSetupDialog1.PageSettings.PaperSize = pkCustomSize1

            ' asignamos el método de evento para cada página a imprimir

            Select Case _Tipo_Impresion
                Case _Enum_Tipo_Impresion.Hoja_de_ruta
                    Sb_Traer_OT()
                    AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Codigos_Barra
                Case _Enum_Tipo_Impresion.Operarios
                    AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Operarios_Codigos_Barra
                Case _Enum_Tipo_Impresion.Portada_OT
                    Sb_Traer_OT()
                    AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Portada_OT
                Case _Enum_Tipo_Impresion.Vale_Comprante_EnvRec
                    AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Comprante_EnvRec
            End Select

            ' indicamos que queremos imprimir

            printDoc.DocumentName = _Nombre_documento

            If String.IsNullOrEmpty(_Impresora) Then
                Dim prtDialog As New PrintDialog
                If prtSettings Is Nothing Then
                    prtSettings = New PrinterSettings
                End If

                With prtDialog
                    .AllowPrintToFile = False
                    .AllowSelection = False
                    .AllowSomePages = False
                    .PrintToFile = False
                    .ShowHelp = False
                    .ShowNetwork = True

                    .PrinterSettings = prtSettings

                    If .ShowDialog(_Formulario) = DialogResult.OK Then
                        _Impresora = .PrinterSettings.PrinterName
                    Else
                        Return False
                    End If

                End With
            End If

            printDoc.PrinterSettings.PrinterName = _Impresora
            printDoc.Print()

            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function Fx_Imprimir_Productos_En_Meson(_Formulario As Form,
                                                   _Nombre_documento As String,
                                                   ByRef _Impresora As String,
                                                   _Codmeson As String)
        Try

            If String.IsNullOrEmpty(_Nombre_documento) Then
                _Nombre_documento = "Meson_" & _Codmeson
            End If

            Sb_Traer_Meson(_Codmeson)

            If Not CBool(_Tbl_Productos_En_Meson.Rows.Count) Then
                MessageBoxEx.Show(_Formulario, "No existen datos que mostrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

            Dim printDoc As New PrintDocument

            printDoc.PrinterSettings.DefaultPageSettings.Landscape = True

            AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Productos_En_Meson

            ' CON ESTA CONFIGURACION PODEMOS PROPORCIONAR LAS DIMENCIONES Y ESTADO DE LA PAGINA, MARGENES, LARGO Y HORIENTACION

            Dim pkCustomSize1 As New Printing.PaperSize(PaperKind.A4, 850, 1400)

            Dim PageSetupDialog1 As New PageSetupDialog

            PageSetupDialog1.Document = printDoc
            PageSetupDialog1.PageSettings.Landscape = True

            PageSetupDialog1.PageSettings.PaperSize = pkCustomSize1
            PageSetupDialog1.PageSettings.Margins.Left = 2
            PageSetupDialog1.PageSettings.Margins.Right = 2

            PageSetupDialog1.ShowDialog()

            If String.IsNullOrEmpty(_Impresora) Then

                Dim prtDialog As New PrintDialog

                If prtSettings Is Nothing Then
                    prtSettings = New PrinterSettings
                End If

                With prtDialog

                    .AllowPrintToFile = False
                    .AllowSelection = False
                    .AllowSomePages = False
                    .PrintToFile = False
                    .ShowHelp = False
                    .ShowNetwork = True
                    .PrinterSettings = prtSettings

                    If .ShowDialog(_Formulario) = DialogResult.OK Then
                        _Impresora = .PrinterSettings.PrinterName
                    Else
                        Return False
                    End If

                End With

            End If

            _Filas_X_Documento = 16

            printDoc.PrinterSettings.PrinterName = _Impresora
            printDoc.PrinterSettings.DefaultPageSettings.Landscape = True

            printDoc.Print()

            Return True

        Catch ex As Exception

            Return False
            MsgBox(ex.Message)

        End Try

    End Function

    Function Fx_Llenar_Row_Comprobante(_Id_MesonVsEnvioRecibe As Integer) As DataRow

        Consulta_sql = "Select Id,Mspr.IdMeson,Mspr.Idpote,Mspr.Idpotl,Mspr.Idpotpr,Mspr.Numot,EnvRec.IdMaquina, 
		                        MsprEnv.Estado,IdMeson_Envia,Ms1.Nommeson As 'NommesonEnv',
		                        IdMeson_Recibe,Ms2.Nommeson As 'NommesonRec', 
		                        EnvRec.Codigo, CantEnvia,
		                        POTE.FIOT As 'Fecha_Creacion_Ot',Mspr.Fecha_Asignacion,FechaHoraEnvia, 
		                        EsReproceso, Codigoob,Isnull(NOMBREOB,'') As Operario,Mspr.Glosa, 
		                        CodFuncionario,Isnull(NOKOFU,'') As 'NomFuncionario', 
		                        EsMesonVirtual, EsMesonFinal, EnvRec.Idpotl_Padre,
                                Isnull(Mq.Observacion,'') As Observacion,
                                Isnull(POTE.REFERENCIA,'') As Referencia
                            From " & _Global_BaseBk & "Zw_Pdp_MesonVsEnvioRecibe EnvRec
                            Left Join " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Mspr On EnvRec.IdMeson_Envia = Mspr.IdMeson
                            Left Join POTE On IDPOTE = Mspr.Idpote
                            Left Join " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos MsprEnv On EnvRec.IdMeson_Envia = MsprEnv.IdMeson
                            Left Join " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos MsprRec On EnvRec.IdMeson_Recibe = MsprRec.IdMeson
                            Left Join " & _Global_BaseBk & "Zw_Pdc_Mesones Ms1 On Ms1.Codmeson = MsprEnv.Codmeson
                            Left Join " & _Global_BaseBk & "Zw_Pdc_Mesones Ms2 On Ms2.Codmeson = MsprRec.Codmeson
                            Left Join TABFU On KOFU = EnvRec.CodFuncionario
                            Left Join " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Mq On Mq.IdMaquina = EnvRec.IdMaquina
                            Left Join PMAEOB On CODIGOOB = EnvRec.Codigoob
                            
                            Where EnvRec.Id = " & _Id_MesonVsEnvioRecibe

        Dim _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

        Return _Row

    End Function

    Public Function Fx_Imprimir_Vale_Comprobante_Meson(_Formulario As Form,
                                                       ByRef _Impresora As String,
                                                       _Id_MesonVsEnvioRecibe As Integer)
        Try

            _Row_Comprobante = Fx_Llenar_Row_Comprobante(_Id_MesonVsEnvioRecibe)

            If IsNothing(_Row_Comprobante) Then
                MessageBoxEx.Show(_Formulario, "No existen datos que mostrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

            Dim printDoc As New PrintDocument

            printDoc.PrinterSettings.DefaultPageSettings.Landscape = True

            AddHandler printDoc.PrintPage, AddressOf Sb_Print_PrintPage_Comprante_EnvRec

            Dim _Doc_AnchoDoc = 295
            Dim _Doc_LargoDoc = 1095 / 2


            Dim _TamañoPersonal = New Printing.PaperSize("Personalizado", _Doc_AnchoDoc, _Doc_LargoDoc + 2)

            If String.IsNullOrEmpty(_Impresora) Then

                Dim prtDialog As New PrintDialog

                If prtSettings Is Nothing Then
                    prtSettings = New PrinterSettings
                End If

                With prtDialog

                    .AllowPrintToFile = False
                    .AllowSelection = False
                    .AllowSomePages = False
                    .PrintToFile = False
                    .ShowHelp = False
                    .ShowNetwork = True
                    .PrinterSettings = prtSettings


                    If .ShowDialog(_Formulario) = DialogResult.OK Then
                        _Impresora = .PrinterSettings.PrinterName
                    Else
                        Return False
                    End If

                End With

            End If

            printDoc.DefaultPageSettings.PaperSize = _TamañoPersonal
            printDoc.PrinterSettings.PrinterName = _Impresora
            printDoc.PrinterSettings.DefaultPageSettings.Landscape = True

            printDoc.Print()

            Return True

        Catch ex As Exception

            Return False
            MsgBox(ex.Message)

        End Try

    End Function

    Private Sub Sb_Print_PrintPage_Codigos_Barra(sender As Object,
                                                 e As PrintPageEventArgs)
        ' Este evento se producirá cada vez que se imprima una nueva página
        ' imprimir HOLA MUNDO en Arial tamaño 24 y negrita

        Try

            ' imprimimos la cadena en el margen izquierdo
            Dim _xPos As Single = 3 'e.MarginBounds.Left
            ' La fuente a usar


            ' la posición superior
            Dim _yPos As Single = prFont.GetHeight(e.Graphics) - 10

            _xPos = 20
            _yPos += 20

            Dim _Row_Pote As DataRow = _Tbl_00_Pote.Rows(0)

            Dim _Nro_Ot = _Row_Pote.Item("NUMOT")
            Dim _Referencia = _Row_Pote.Item("REFERENCIA")
            Dim _Nokoen As String

            Dim _Font_Enc_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 14, FontStyle.Bold)
            Dim _Font_Enc_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 12, FontStyle.Regular)

            e.Graphics.DrawString("HOJA DE RUTA", Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 18, FontStyle.Bold),
                                  Brushes.Black, _xPos + 300, _yPos)
            _yPos += 40

            e.Graphics.DrawString("ORDEN DE TRABAJO NRO: " & _Nro_Ot, _Font_Enc_1, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            If Not (_Row_Entidad Is Nothing) Then
                _Nokoen = _Row_Entidad.Item("NOKOEN")
                e.Graphics.DrawString("CLIENTE:" & _Nokoen, _Font_Enc_2, Brushes.Black, _xPos, _yPos)
                _yPos += 15
            End If

            e.Graphics.DrawString("REFERENCIA: " & _Referencia, _Font_Enc_2, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            Consulta_sql = "Select Top 1 * From POTL Where NUMOT = '" & _Nro_Ot & "' And NREG = '" & _Sub_OT & "'"
            Dim _Row_Sub_OT As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Glosa_Sub_Ot = _Row_Sub_OT.Item("GLOSA")

            e.Graphics.DrawString("SUB-OT: " & _Sub_OT & " - " & _Glosa_Sub_Ot, _Font_Enc_1, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            e.Graphics.DrawString("DETALLE", _Font_Enc_2, Brushes.Black, _xPos, _yPos)
            _yPos += 12

            e.Graphics.DrawString(StrDup(200, "_"), _Font_Enc_2, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            _xPos += 20

            Dim _Contador = 0

            Dim _Font_Detalle_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 8, FontStyle.Regular)
            Dim _Font_Detalle_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 10, FontStyle.Regular)

            e.Graphics.DrawString("CANTIDAD A FABRICAR", _Font_Detalle_1, Brushes.Black, _xPos + 630, _yPos)

            ' imprimimos la cadena

            Dim _Index As Integer = 0
            _Filas_X_Documento = 9

            Dim _Items As Integer = NuloPorNro(_Tbl_03_Potpr.Compute("Sum(Contador)", "NREGOTL = '" & _Sub_OT & "'"), 0)
            Dim _Paginas = Math.Ceiling(_Items / _Filas_X_Documento)

            For Each _Fila As DataRow In _Tbl_03_Potpr.Rows

                Dim _Nreglot As String = _Fila.Item("NREGOTL")
                Dim _Impreso As Boolean = _Fila.Item("Impreso")

                If _Nreglot = _Sub_OT Then

                    If Not _Impreso Then

                        Dim _Idpotpr = _Fila.Item("IDPOTPR")
                        Dim _Operacion = Trim(_Fila.Item("OPERACION"))
                        Dim _Nombreop = Trim(_Fila.Item("NOMBRE_OPERACION"))
                        Dim _CodMaqot = Trim(_Fila.Item("CODMAQOT"))
                        Dim _Fabricar = _Fila.Item("FABRICAR")

                        Dim _Stx = _Fila.Item("STX")
                        Dim _Etx = _Fila.Item("ETX")

                        'Código de barras 
                        Dim _Cod_Barras_STX As PictureBox = Fx_Codigo_Barras(_Stx)
                        Dim _Cod_Barras_ETX As PictureBox = Fx_Codigo_Barras(_Etx)

                        Dim _Descripcion = "Item: " & _Item & " - " & _Operacion & ": " & _Nombreop & " (" & LCase(_CodMaqot) & ")"

                        e.Graphics.DrawString(_Descripcion, _Font_Detalle_2, Brushes.Black, _xPos, _yPos)


                        _yPos += 25
                        e.Graphics.DrawImage(_Cod_Barras_STX.Image, _xPos + 10, _yPos, 100, 30)
                        e.Graphics.DrawImage(_Cod_Barras_ETX.Image, _xPos + 400, _yPos, 100, 30)
                        e.Graphics.DrawString(_Fabricar, Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 18, FontStyle.Regular), Brushes.Black, _xPos + 700, _yPos)

                        _yPos += 35
                        e.Graphics.DrawString("INICIO" & " - (stx;" & _Idpotpr & ")", _Font_Detalle_1, Brushes.Black, _xPos + 10, _yPos)
                        e.Graphics.DrawString("FIN" & " - (etx;" & _Idpotpr & ")", _Font_Detalle_1, Brushes.Black, _xPos + 400, _yPos)
                        _yPos += 15
                        e.Graphics.DrawString(StrDup(200, "_"), DtFont, Brushes.Black, _xPos - 40, _yPos)
                        _yPos += 20

                        _Fila.Item("Impreso") = True
                        _Contador += 1
                        _Item += 1

                        If _Contador = _Filas_X_Documento Then
                            Exit For
                        End If

                    End If

                End If

            Next

            ' indicamos que ya no hay nada más que imprimir
            ' (el valor predeterminado de esta propiedad es False)

            Dim _Saldo_Registros As Integer = NuloPorNro(_Tbl_03_Potpr.Compute("Sum(Contador)", "Impreso = 0 And NREGOTL = '" & _Sub_OT & "'"), 0)

            e.Graphics.DrawString("Página " & _Pagina & " de " & _Paginas, FontNro, Brushes.Black, _xPos, _yPos)

            If CBool(_Saldo_Registros) Then
                e.HasMorePages = True
            Else
                'e.Graphics.DrawString("FIN IMPRESION", FontNro, Brushes.Black, _xPos, _yPos)
                e.HasMorePages = False
            End If
            _Pagina += 1

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Private Sub Sb_Print_PrintPage_Productos_En_Meson(sender As Object, e As PrintPageEventArgs)

        Try

            ' imprimimos la cadena en el margen izquierdo
            Dim _xPos As Single = 5 'e.MarginBounds.Left
            ' La fuente a usar


            ' la posición superior
            Dim _yPos As Single = prFont.GetHeight(e.Graphics) - 10

            _xPos = 20
            _yPos += 20

            Dim _Codmeson = _Row_Meson.Item("Codmeson")
            Dim _Nommeson = _Row_Meson.Item("Nommeson")


            Dim _Font_Enc_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 14, FontStyle.Bold)
            Dim _Font_Enc_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 12, FontStyle.Regular)

            Dim _Font_Detalle_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 6, FontStyle.Regular)
            Dim _Font_Detalle_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 8, FontStyle.Regular)
            Dim _Font_Detalle_3 As Font = Fx_Fuente(_Enum_Fuentes.Arial, 8, FontStyle.Regular)

            Dim _Font_Detalle_Curr_1_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Regular)
            Dim _Font_Detalle_Curr_2_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular)

            Dim _Font_Detalle_Curr_1_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Bold)
            Dim _Font_Detalle_Curr_2_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold)


            e.Graphics.DrawString("MESON DE TRABAJO", Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 18, FontStyle.Bold),
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 40

            e.Graphics.DrawString(_Nommeson, _Font_Enc_1, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            Dim _Fecha_Act = DateTime.Now.ToShortDateString()
            Dim _Hora_Act = DateTime.Now.ToShortTimeString()

            e.Graphics.DrawString("Fecha:" & _Fecha_Act & ", Hora: " & _Hora_Act, _Font_Enc_2, Brushes.Black, _xPos, _yPos)
            _yPos += 15

            Dim _Largo_liena = 240
            e.Graphics.DrawString(StrDup(_Largo_liena, "_"), _Font_Detalle_2, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            '_xPos += 20

            Dim _Contador = 0


            'e.Graphics.DrawString("CANTIDAD A FABRICAR", _Font_Detalle_1, Brushes.Black, _xPos + 630, _yPos)

            ' imprimimos la cadena

            Dim _Index As Integer = 0


            Dim _Items As Integer = NuloPorNro(_Tbl_Productos_En_Meson.Compute("Sum(Contador)", "1 > 0"), 0)
            Dim _Paginas = Math.Ceiling(_Items / _Filas_X_Documento)

            Dim _Xsuma = 0

            e.Graphics.DrawString("OT", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + _Xsuma, _yPos)
            _Xsuma += 30 + 20
            e.Graphics.DrawString("SUB ot", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + _Xsuma, _yPos)
            _Xsuma += 35 + 20
            e.Graphics.DrawString("Imp", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + _Xsuma, _yPos)
            _Xsuma += 15 + 20
            e.Graphics.DrawString("REFERENCIA / CLIENTE", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + _Xsuma, _yPos)
            _Xsuma += 200 + 20
            e.Graphics.DrawString("FECHA OT", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + _Xsuma, _yPos)
            _Xsuma += 70 + 20
            e.Graphics.DrawString("CODIGO", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + _Xsuma, _yPos)
            _Xsuma += 70 + 20
            e.Graphics.DrawString("DESCRIPCION PRODUCTO", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + _Xsuma, _yPos)
            _Xsuma += 200
            e.Graphics.DrawString("   CANT.", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + _Xsuma, _yPos)
            _Xsuma += 60
            e.Graphics.DrawString("FECHA MESON", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + _Xsuma, _yPos)
            _Xsuma += 90
            e.Graphics.DrawString("OBSERVACIONES", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + _Xsuma, _yPos)


            _yPos += 30

            For Each _Fila As DataRow In _Tbl_Productos_En_Meson.Rows

                Dim _Impreso As Boolean = _Fila.Item("Impreso")

                If Not _Impreso Then

                    Dim _Numot = _Fila.Item("Numot")
                    Dim _Nreg = Trim(_Fila.Item("Nreg"))
                    Dim _SubOt = Trim(_Fila.Item("SubOt"))
                    Dim _Referencia = Trim(_Fila.Item("Referencia"))
                    Dim _Codigo = _Fila.Item("Codigo")
                    Dim _Glosa = _Fila.Item("Glosa")
                    Dim _Fecha_Ot = FormatDateTime(_Fila.Item("Fecha_Ot"), DateFormat.ShortDate)
                    Dim _Fecha_Asignacion = FormatDateTime(_Fila.Item("Fecha_Asignacion"), DateFormat.ShortDate)
                    Dim _Saldo_Fabricar = _Fila.Item("Saldo_Fabricar")
                    Dim _Grado = _Fila.Item("Grado")

                    Dim _Gr = String.Empty
                    Dim _Importancia As String
                    Dim _Fuente As Font

                    _Gr = Rellenar(_Gr, _Grado, "*")

                    Select Case _Grado
                        Case 0
                            _Gr = ""
                            _Fuente = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular)
                            _Importancia = "N"
                        Case 1
                            _Gr = "**"
                            _Fuente = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold)
                            _Importancia = "A"
                        Case 2
                            _Gr = "*"
                            _Fuente = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold)
                            _Importancia = "M"
                    End Select

                    'Código de barras 
                    'Dim _Cod_Barras_STX As PictureBox = Fx_Codigo_Barras(_Stx)
                    'Dim _Cod_Barras_ETX As PictureBox = Fx_Codigo_Barras(_Etx)

                    _Xsuma = 0

                    e.Graphics.DrawString(_Numot, _Fuente, Brushes.Black, _xPos + _Xsuma, _yPos)
                    _Xsuma += 30 + 20
                    e.Graphics.DrawString(_Nreg, _Fuente, Brushes.Black, _xPos + _Xsuma, _yPos)
                    _Xsuma += 40 + 20
                    e.Graphics.DrawString(_Importancia, _Fuente, Brushes.Black, _xPos + _Xsuma, _yPos)

                    _Xsuma += 10 + 20
                    e.Graphics.DrawString(_Referencia, _Fuente, Brushes.Black, _xPos + _Xsuma, _yPos)


                    _Xsuma += 200 + 20
                    e.Graphics.DrawString(_Fecha_Ot, _Font_Detalle_Curr_2_R, Brushes.Black, _xPos + _Xsuma, _yPos)
                    _Xsuma += 60 + 20

                    e.Graphics.DrawString(_Codigo, _Font_Detalle_Curr_2_R, Brushes.Black, _xPos + _Xsuma, _yPos)
                    _Xsuma += 70 + 30

                    Dim _Descripcion = _Gr & " " & _Glosa

                    e.Graphics.DrawString(Mid(_Descripcion, 1, 30), _Fuente, Brushes.Black, _xPos + _Xsuma, _yPos)
                    e.Graphics.DrawString(Mid(_Descripcion, 31, 20), _Fuente, Brushes.Black, _xPos + _Xsuma + 10, _yPos + 15)

                    _Xsuma += 200
                    Dim _Cantidad = Fx_Formato_Numerico(_Saldo_Fabricar, "999.999", False)
                    e.Graphics.DrawString(_Cantidad, _Fuente, Brushes.Black, _xPos + _Xsuma, _yPos)

                    _Xsuma += 60
                    e.Graphics.DrawString(_Fecha_Asignacion, _Font_Detalle_Curr_2_R, Brushes.Black, _xPos + _Xsuma, _yPos)
                    _Xsuma += 90
                    e.Graphics.DrawString(StrDup(45, "_"), _Font_Detalle_Curr_2_R, Brushes.Black, _xPos + _Xsuma, _yPos)

                    _yPos += 35

                    'e.Graphics.DrawString(StrDup(200, "_"), DtFont, Brushes.Black, _xPos - 40, _yPos)
                    '_yPos += 20

                    _Fila.Item("Impreso") = True
                    _Contador += 1
                    _Item += 1

                    If _Contador = _Filas_X_Documento Then
                        Exit For
                    End If

                End If

            Next

            ' indicamos que ya no hay nada más que imprimir
            ' (el valor predeterminado de esta propiedad es False)

            Dim _Saldo_Registros As Integer = NuloPorNro(_Tbl_Productos_En_Meson.Compute("Sum(Contador)", "Impreso = 0"), 0)
            _yPos += 15

            e.Graphics.DrawString("Imp = Importancia: N = Normal, M = Media, A = Alta ", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos, _yPos)
            _yPos += 15

            e.Graphics.DrawString(StrDup(_Largo_liena, "_"), _Font_Detalle_2, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            e.Graphics.DrawString("Página " & _Pagina & " de " & _Paginas, _Font_Detalle_3, Brushes.Black, _xPos, _yPos)

            If CBool(_Saldo_Registros) Then
                e.HasMorePages = True
            Else
                'e.Graphics.DrawString("FIN IMPRESION", FontNro, Brushes.Black, _xPos, _yPos)
                e.HasMorePages = False
            End If

            _Pagina += 1

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Private Sub Sb_Print_PrintPage_Operarios_Codigos_Barra(sender As Object,
                                                           e As PrintPageEventArgs)
        ' Este evento se producirá cada vez que se imprima una nueva página
        ' imprimir HOLA MUNDO en Arial tamaño 24 y negrita

        Try

            ' imprimimos la cadena en el margen izquierdo
            Dim _xPos As Single = 3 'e.MarginBounds.Left
            ' La fuente a usar

            Dim _Font_Enc_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 14, FontStyle.Bold)
            Dim _Font_Enc_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 12, FontStyle.Regular)

            ' la posición superior
            Dim _yPos As Single = _Font_Enc_1.GetHeight(e.Graphics) - 10

            '_xPos = 20
            _yPos += 20


            Consulta_sql = "SELECT CODIGOOB,RUTOB,NOMBREOB,TIFU,RTFU,CIFU,CMFU,DIFU,FOFU,PWFU,PLANO,VAHROB,CODRELCON,KOJORNADA," &
                           "VAHROBHE,INACTIVO,FECINACTIV,EMPRESA" & vbCrLf &
                           "FROM PMAEOB"
            Dim _Tbl_Operarios As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)


            e.Graphics.DrawString("OPERARIOS", Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 18, FontStyle.Bold),
                                  Brushes.Black, _xPos + 300, _yPos)
            _yPos += 40

            e.Graphics.DrawString("DETALLE", _Font_Enc_2, Brushes.Black, _xPos, _yPos)
            _yPos += 12

            e.Graphics.DrawString(StrDup(200, "_"), _Font_Enc_2, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            _xPos += 20

            Dim _Contador = 0


            Dim _Font_Detalle_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 8, FontStyle.Regular)
            Dim _Font_Detalle_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 10, FontStyle.Regular)

            e.Graphics.DrawString("CANTIDAD A FABRICAR", _Font_Detalle_1, Brushes.Black, _xPos + 630, _yPos)

            ' imprimimos la cadena
            For Each _Fila As DataRow In _Tbl_Operarios.Rows


                Dim _Codigoob = Trim(_Fila.Item("CODIGOOB"))
                Dim _Nombreob = Trim(_Fila.Item("NOMBREOB"))

                'Código de barras 
                Dim _Cod_Barras As PictureBox = Fx_Codigo_Barras(_Codigoob)

                Dim _Descripcion = "Item: " & _Item & " - " & _Codigoob & ": " & _Nombreob

                e.Graphics.DrawString(_Descripcion, _Font_Detalle_2, Brushes.Black, _xPos, _yPos)

                '_yPos += 25
                e.Graphics.DrawImage(_Cod_Barras.Image, _xPos + 600, _yPos, 200, 30)
                _yPos += 25

                e.Graphics.DrawString(StrDup(200, "_"), DtFont, Brushes.Black, _xPos - 40, _yPos)
                _yPos += 20

                '_Fila.Item("Impreso") = True
                _Contador += 1
                _Item += 1

                If _Contador = _Filas_X_Documento Then
                    Exit For
                End If

            Next

            ' indicamos que ya no hay nada más que imprimir
            ' (el valor predeterminado de esta propiedad es False)

            'Dim _Saldo_Registros As Integer = NuloPorNro(_TblProductos.Compute("Sum(Contador)", "Impreso = 0"), 0)

            'If CBool(_Saldo_Registros) Then
            'e.HasMorePages = True
            'Else
            ' e.Graphics.DrawString("FIN IMPRESION", FontNro, Brushes.Black, _xPos, _yPos)
            e.HasMorePages = False
            'End If


        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Private Sub Sb_Print_PrintPage_Portada_OT(sender As Object, e As PrintPageEventArgs)

        Try

            ' imprimimos la cadena en el margen izquierdo
            Dim _xPos As Single = 3 'e.MarginBounds.Left
            ' La fuente a usar


            ' la posición superior
            Dim _yPos As Single = prFont.GetHeight(e.Graphics) - 10

            _xPos = 20
            _yPos += 20

            Dim _Row_Pote As DataRow = _Tbl_00_Pote.Rows(0)

            Dim _Idpote = _Row_Pote.Item("IDPOTE")
            Dim _Numot = _Row_Pote.Item("NUMOT")
            Dim _Referencia = _Row_Pote.Item("REFERENCIA")
            Dim _Fiot = _Row_Pote.Item("FIOT")
            Dim _Ftespprod = _Row_Pote.Item("FTESPPROD")   'Fecha estimada entrega
            Dim _Fechaoc = _Row_Pote.Item("FECHAOC")        'Fecha de confirmación

            Dim _Nokoen As String

            Consulta_sql = "SELECT DISTINCT IDPOTE,EDO.IDMAEEDO,EDO.SUDO,POTLCOM.DESDE AS TIDOD, POTLCOM.NUMECOTI AS NUDOD,KOFUDO," &
                           "NOKOFU AS VENDEDOR,EDO.ENDO,EDO.SUENDO,NOKOEN,Isnull(OBS.OBDO,'') As OBDO,Isnull(OBS.OCDO,'') As OCDO" & vbCrLf &
                           "From POTL WITH ( NOLOCK )" & vbCrLf &
                           "Inner Join POTLCOM On POTLCOM.IDPOTL = POTL.IDPOTL" & vbCrLf &
                           "Left Outer Join MAEEDO EDO On EDO.TIDO = POTLCOM.DESDE AND POTLCOM.NUMECOTI = EDO.NUDO" & vbCrLf &
                           "Left Outer Join MAEEN On EDO.ENDO = KOEN AND EDO.SUENDO = SUEN" & vbCrLf &
                           "Left Outer Join TABFU On KOFU = KOFUDO" & vbCrLf &
                           "Left Join MAEEDOOB OBS On OBS.IDMAEEDO = EDO.IDMAEEDO" & vbCrLf &
                           "WHERE POTL.NUMOT='" & _Numot & "' AND POTL.EMPRESA = '" & ModEmpresa & "'"
            Dim _TblDocRela As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
            Dim _Row_DocRela As DataRow

            If CBool(_TblDocRela.Rows.Count) Then
                _Row_DocRela = _TblDocRela.Rows(0)
            End If

            Dim _Font_Enc_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 14, FontStyle.Bold)
            Dim _Font_Enc_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 12, FontStyle.Regular)
            Dim _Font_Enc_3 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 10, FontStyle.Regular)
            Dim _Font_Enc_4 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 8, FontStyle.Regular)

            Dim _Font_Detalle_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 6, FontStyle.Regular)
            Dim _Font_Detalle_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 8, FontStyle.Regular)
            Dim _Font_Detalle_3 As Font = Fx_Fuente(_Enum_Fuentes.Arial, 8, FontStyle.Regular)

            Dim _Font_Detalle_Curr_1_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Regular)
            Dim _Font_Detalle_Curr_2_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular)

            Dim _Font_Detalle_Curr_1_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Bold)
            Dim _Font_Detalle_Curr_2_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold)

            e.Graphics.DrawString("ORDEN DE TRABAJO", Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 18, FontStyle.Bold),
                                  Brushes.Black, _xPos + 300, _yPos)
            _yPos += 40

            e.Graphics.DrawString(RutEmpresa, _Font_Detalle_Curr_2_B, Brushes.Black, _xPos, _yPos)
            _yPos += 12
            e.Graphics.DrawString(RazonEmpresa, _Font_Detalle_Curr_2_B, Brushes.Black, _xPos, _yPos)

            e.Graphics.DrawString("NRO: " & _Nro_OT, _Font_Enc_1, Brushes.Black, _xPos + 600, _yPos)
            _yPos += 12

            e.Graphics.DrawString(StrDup(200, "_"), _Font_Enc_2, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            If Not (_Row_Entidad Is Nothing) Then
                _Nokoen = _Row_Entidad.Item("NOKOEN")
                e.Graphics.DrawString("CLIENTE: " & _Nokoen, _Font_Enc_3, Brushes.Black, _xPos, _yPos)
                _yPos += 30
            Else
                e.Graphics.DrawString("REFERENCIA: " & _Referencia, _Font_Enc_3, Brushes.Black, _xPos, _yPos)
                _yPos += 30
            End If

            e.Graphics.DrawString("Fecha OT", _Font_Enc_3, Brushes.Black, _xPos, _yPos)
            e.Graphics.DrawString(": " & _Fiot, _Font_Enc_3, Brushes.Black, _xPos + 180, _yPos)
            _yPos += 20
            e.Graphics.DrawString("Fecha confirmación OT", _Font_Enc_3, Brushes.Black, _xPos, _yPos)
            e.Graphics.DrawString(": " & _Fechaoc, _Font_Enc_3, Brushes.Black, _xPos + 180, _yPos)
            _yPos += 20
            e.Graphics.DrawString("Fecha compromiso de entrega", _Font_Enc_3, Brushes.Black, _xPos, _yPos)
            e.Graphics.DrawString(": " & _Ftespprod, _Font_Enc_3, Brushes.Black, _xPos + 180, _yPos)
            _yPos += 40

            If Not IsNothing(_Row_DocRela) Then

                Dim _Vendedor = _Row_DocRela.Item("VENDEDOR")
                Dim _Sudo = _Row_DocRela.Item("SUDO")
                Dim _Sucursal = _Sql.Fx_Trae_Dato("TABSU", "NOKOSU", "EMPRESA = '" & ModEmpresa & "' AND KOSU = '" & _Sudo & "'")
                Dim _Tidod = _Row_DocRela.Item("TIDOD")
                Dim _Nudod = _Row_DocRela.Item("NUDOD")
                Dim _Ocdo = _Row_DocRela.Item("OCDO")

                e.Graphics.DrawString("Solicitado por", _Font_Enc_3, Brushes.Black, _xPos, _yPos)
                e.Graphics.DrawString(": " & _Vendedor, _Font_Enc_3, Brushes.Black, _xPos + 180, _yPos)
                _yPos += 20
                e.Graphics.DrawString("Sucursal", _Font_Enc_3, Brushes.Black, _xPos, _yPos)
                e.Graphics.DrawString(": " & _Sudo & " - " & _Sucursal, _Font_Enc_3, Brushes.Black, _xPos + 180, _yPos)
                _yPos += 20
                e.Graphics.DrawString("Documento", _Font_Enc_3, Brushes.Black, _xPos, _yPos)
                e.Graphics.DrawString(": " & _Tidod & " - " & _Nudod, _Font_Enc_3, Brushes.Black, _xPos + 180, _yPos)
                _yPos += 20
                e.Graphics.DrawString("Orden de compra", _Font_Enc_3, Brushes.Black, _xPos, _yPos)
                e.Graphics.DrawString(": " & _Ocdo, _Font_Enc_3, Brushes.Black, _xPos + 180, _yPos)
                _yPos += 20

            End If

            e.Graphics.DrawString(StrDup(200, "_"), _Font_Enc_2, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            e.Graphics.DrawString("ITEM", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos, _yPos)
            e.Graphics.DrawString("CODIGO", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + 70, _yPos)
            e.Graphics.DrawString("DESCRIPCION", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + 200, _yPos)
            e.Graphics.DrawString("CANTIDAD", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + 580, _yPos)

            _yPos += 10

            e.Graphics.DrawString(StrDup(200, "_"), _Font_Enc_2, Brushes.Black, _xPos, _yPos)

            _yPos += 30
            _xPos += 20

            Dim _Contador = 0



            ' imprimimos la cadena

            Dim _Index As Integer = 0
            _Filas_X_Documento = 20

            Dim _Items As Integer = NuloPorNro(_Tbl_01_Potl.Compute("Sum(Contador)", "NUMOT = '" & _Numot & "'"), 0)
            Dim _Paginas = Math.Ceiling(_Items / _Filas_X_Documento)

            For Each _Fila As DataRow In _Tbl_01_Potl.Rows

                'Dim _Nreglot As String = _Fila.Item("NREGOTL")
                Dim _Impreso As Boolean = _Fila.Item("Impreso")

                'If _Nreglot = _Sub_OT Then

                If Not _Impreso Then

                    'Dim _Idpotpr = _Fila.Item("IDPOTPR")
                    'Dim _Operacion = Trim(_Fila.Item("OPERACION"))
                    'Dim _Nombreop = Trim(_Fila.Item("NOMBRE_OPERACION"))
                    'Dim _CodMaqot = Trim(_Fila.Item("CODMAQOT"))
                    Dim _Codigo = Trim(_Fila.Item("CODIGO"))
                    Dim _Glosa = Trim(_Fila.Item("GLOSA"))
                    Dim _Fabricar = _Fila.Item("FABRICAR")

                    'Dim _Stx = _Fila.Item("STX")
                    'Dim _Etx = _Fila.Item("ETX")

                    'Código de barras 
                    'Dim _Cod_Barras_STX As PictureBox = Fx_Codigo_Barras(_Stx)
                    'Dim _Cod_Barras_ETX As PictureBox = Fx_Codigo_Barras(_Etx)

                    'Dim _Descripcion = "Item: " & _Item & " - " & _Codigo & ": " & _Glosa

                    e.Graphics.DrawString(_Item, _Font_Detalle_Curr_2_R, Brushes.Black, _xPos, _yPos)
                    e.Graphics.DrawString(_Codigo, _Font_Detalle_Curr_2_R, Brushes.Black, _xPos + 50, _yPos)
                    e.Graphics.DrawString(_Glosa, _Font_Detalle_Curr_2_R, Brushes.Black, _xPos + 180, _yPos)

                    Dim _Cantidad = Fx_Formato_Numerico(_Fabricar, "999.999", False)
                    e.Graphics.DrawString(_Cantidad, _Font_Detalle_Curr_2_R, Brushes.Black, _xPos + 550, _yPos)

                    _yPos += 20

                    _Fila.Item("Impreso") = True
                    _Contador += 1
                    _Item += 1

                    If _Contador = _Filas_X_Documento Then
                        Exit For
                    End If

                End If

                'End If

            Next

            _xPos -= 20

            Consulta_sql = "Select * From MEVENTO Where IDRVE = " & _Idpote & " And ARCHIRVE = 'POTE' Order By IDEVENTO"
            Dim _TblMevento_Pote As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            _yPos += (20 - _Item) * 30

            e.Graphics.DrawString(StrDup(200, "_"), _Font_Enc_2, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            e.Graphics.DrawString("OBSERVACIONES:", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos, _yPos)
            _yPos += 15

            If CBool(_TblMevento_Pote.Rows.Count) Then

                For Each _Row_Mevento As DataRow In _TblMevento_Pote.Rows
                    Dim _Nokocarac = _Row_Mevento.Item("NOKOCARAC")
                    e.Graphics.DrawString(_Nokocarac, _Font_Detalle_Curr_2_R, Brushes.Black, _xPos, _yPos)
                    _yPos += 15
                Next

            End If

            _yPos += 90

            e.Graphics.DrawString(StrDup(20, "_"), _Font_Enc_2, Brushes.Black, _xPos, _yPos)
            e.Graphics.DrawString(StrDup(20, "_"), _Font_Enc_2, Brushes.Black, _xPos + 500, _yPos)
            _yPos += 20
            e.Graphics.DrawString("AUTORIZADO", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + 50, _yPos)
            e.Graphics.DrawString("FECHA ENTREGA", _Font_Detalle_Curr_2_B, Brushes.Black, _xPos + 50 + 500, _yPos)

            Dim _Saldo_Registros As Integer = NuloPorNro(_Tbl_01_Potl.Compute("Sum(Contador)", "Impreso = 0 And NUMOT = '" & _Numot & "'"), 0)

            If CBool(_Saldo_Registros) Then
                e.HasMorePages = True
            Else
                'e.Graphics.DrawString("FIN IMPRESION", FontNro, Brushes.Black, _xPos, _yPos)
                e.HasMorePages = False
            End If
            _Pagina += 1

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Private Sub Sb_Print_PrintPage_Comprante_EnvRec(sender As Object, e As PrintPageEventArgs)

        Try

            ' imprimimos la cadena en el margen izquierdo
            Dim _xPos As Single = 3 'e.MarginBounds.Left
            ' La fuente a usar

            ' la posición superior
            Dim _yPos As Single = prFont.GetHeight(e.Graphics) - 10

            _xPos = 5
            _yPos += 20

            Dim _Idpote = _Row_Comprobante.Item("Idpote")
            Dim _Numot = _Row_Comprobante.Item("Numot")

            Dim _Nokoen As String

            'Datos para ver documentos relacionados.
            Consulta_sql = "Select DISTINCT IDPOTE,EDO.IDMAEEDO,EDO.SUDO,POTLCOM.DESDE AS TIDOD, POTLCOM.NUMECOTI AS NUDOD,KOFUDO," &
                           "NOKOFU AS VENDEDOR,EDO.ENDO,EDO.SUENDO,NOKOEN,NOKOEN,Isnull(OBS.OBDO,'') As OBDO,Isnull(OBS.OCDO,'') As OCDO" & vbCrLf &
                           "From POTL WITH ( NOLOCK )" & vbCrLf &
                           "Inner Join POTLCOM On POTLCOM.IDPOTL = POTL.IDPOTL" & vbCrLf &
                           "Left Outer Join MAEEDO EDO On EDO.TIDO = POTLCOM.DESDE AND POTLCOM.NUMECOTI = EDO.NUDO" & vbCrLf &
                           "Left Outer Join MAEEN On EDO.ENDO = KOEN AND EDO.SUENDO = SUEN" & vbCrLf &
                           "Left Outer Join TABFU On KOFU = KOFUDO" & vbCrLf &
                           "Left Join MAEEDOOB OBS On OBS.IDMAEEDO = EDO.IDMAEEDO" & vbCrLf &
                           "WHERE POTL.NUMOT='" & _Numot & "' AND POTL.EMPRESA = '" & ModEmpresa & "'"
            Dim _TblDocRela As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
            Dim _Row_DocRela As DataRow

            If CBool(_TblDocRela.Rows.Count) Then
                _Row_DocRela = _TblDocRela.Rows(0)
            End If

            Dim _Id As String = numero_(_Row_Comprobante.Item("Id"), 6)
            Dim _Tido As String
            Dim _Nudo As String
            Dim _Nomcliente As String
            Dim _Referencia As String = _Row_Comprobante.Item("Referencia").ToString.Trim

            Dim _Codigo As String = _Row_Comprobante.Item("Codigo").ToString.Trim
            Dim _Descripcion As String = _Row_Comprobante.Item("Glosa").ToString.Trim

            Dim _NommesonEnv As String = _Row_Comprobante.Item("NommesonEnv").ToString.Trim
            Dim _NommesonRec As String = _Row_Comprobante.Item("NommesonRec").ToString.Trim

            Dim _CantEnvia As Double = _Row_Comprobante.Item("CantEnvia")

            Dim _Fecha_Creacion_Ot As DateTime = _Row_Comprobante.Item("Fecha_Creacion_Ot")
            Dim _Fecha_Asignacion As DateTime = _Row_Comprobante.Item("Fecha_Asignacion")
            Dim _FechaHoraEnvia As DateTime = _Row_Comprobante.Item("FechaHoraEnvia")

            Dim _EsReproceso As Boolean = _Row_Comprobante.Item("EsReproceso")
            Dim _EsMesonVirtual As Boolean = _Row_Comprobante.Item("EsMesonVirtual")
            Dim _EsMesonFinal As Boolean = _Row_Comprobante.Item("EsMesonFinal")

            Dim _Codigoob As String = _Row_Comprobante.Item("Codigoob").ToString.Trim
            Dim _Operario As String = _Row_Comprobante.Item("Operario").ToString.Trim

            Dim _CodFuncionario As String = _Row_Comprobante.Item("CodFuncionario").ToString.Trim
            Dim _NomFuncionario As String = _Row_Comprobante.Item("NomFuncionario").ToString.Trim

            Dim _Observacion As String = _Row_Comprobante.Item("Observacion").ToString.Trim

            Dim _Font_Enc_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 14, FontStyle.Bold)
            Dim _Font_Enc_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 12, FontStyle.Regular)
            Dim _Font_Enc_3 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 10, FontStyle.Regular)
            Dim _Font_Enc_4 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 8, FontStyle.Regular)

            Dim _Font_Detalle_1 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 6, FontStyle.Regular)
            Dim _Font_Detalle_2 As Font = Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 8, FontStyle.Regular)
            Dim _Font_Detalle_3 As Font = Fx_Fuente(_Enum_Fuentes.Arial, 8, FontStyle.Regular)

            Dim _Font_Detalle_Curr_6_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Regular)
            Dim _Font_Detalle_Curr_8_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Regular)
            Dim _Font_Detalle_Curr_10_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Regular)
            Dim _Font_Detalle_Curr_12_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 12, FontStyle.Regular)
            Dim _Font_Detalle_Curr_14_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 14, FontStyle.Regular)
            Dim _Font_Detalle_Curr_16_R As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 16, FontStyle.Regular)

            Dim _Font_Detalle_Curr_6_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 6, FontStyle.Bold)
            Dim _Font_Detalle_Curr_8_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 8, FontStyle.Bold)
            Dim _Font_Detalle_Curr_10_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 10, FontStyle.Bold)
            Dim _Font_Detalle_Curr_12_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 12, FontStyle.Bold)
            Dim _Font_Detalle_Curr_14_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 14, FontStyle.Bold)
            Dim _Font_Detalle_Curr_16_B As Font = Fx_Fuente(_Enum_Fuentes.Courier_New, 16, FontStyle.Bold)

            e.Graphics.DrawString("COMPROBANTE", Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 12, FontStyle.Bold),
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 12
            e.Graphics.DrawString("TRABAJO REALIZADO", Fx_Fuente(_Enum_Fuentes.Times_New_Roman, 12, FontStyle.Bold),
                                  Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString("NRO: " & _Id, _Font_Detalle_Curr_14_B, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            e.Graphics.DrawString(RutEmpresa, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
            _yPos += 12
            e.Graphics.DrawString(RazonEmpresa, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
            _yPos += 15
            e.Graphics.DrawString("NRO OT: " & _Numot, _Font_Detalle_Curr_14_B, Brushes.Black, _xPos, _yPos)
            _yPos += 12

            e.Graphics.DrawString(StrDup(200, "_"), _Font_Enc_2, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            If Not IsNothing(_Row_DocRela) Then

                _Tido = _Row_DocRela.Item("TIDOD")
                _Nudo = _Row_DocRela.Item("NUDOD")
                _Nomcliente = _Row_DocRela.Item("NOKOEN")

                e.Graphics.DrawString("CLIENTE: " & _Nomcliente, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
                _yPos += 30

            Else
                e.Graphics.DrawString("REFERENCIA: " & _Referencia, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
                _yPos += 30
            End If

            'e.Graphics.DrawString("OT: " & _Numot, _Font_Enc_3, Brushes.Black, _xPos, _yPos)
            '_yPos += 20
            e.Graphics.DrawString("Código: " & _Codigo, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
            _yPos += 20


            e.Graphics.DrawString(Mid(_Descripcion.Trim, 1, 31), _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            _Descripcion = Mid(_Descripcion.Trim, 32, 50)
            'If Mid(_Descripcion, 1, 1) = " " Then
            '    _Descripcion = Mid(_Descripcion.Trim, 2, 30)
            'End If

            e.Graphics.DrawString(_Descripcion, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            e.Graphics.DrawString("Cantidad enviada: " & _CantEnvia, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            e.Graphics.DrawString("Operario: " & _Operario, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            e.Graphics.DrawString("Fecha OT         : " & _Fecha_Creacion_Ot, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
            'e.Graphics.DrawString(": " & _Fecha_Creacion_Ot, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos + 180, _yPos)
            _yPos += 20
            e.Graphics.DrawString("Fecha asig. mesón: " & _Fecha_Asignacion, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
            'e.Graphics.DrawString(": " & _Fecha_Asignacion, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos + 180, _yPos)
            _yPos += 20
            e.Graphics.DrawString("Fecha envío      : " & _FechaHoraEnvia, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
            'e.Graphics.DrawString(": " & _FechaHoraEnvia, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos + 180, _yPos)
            _yPos += 40

            e.Graphics.DrawString(StrDup(200, "_"), _Font_Enc_2, Brushes.Black, _xPos, _yPos)
            _yPos += 30

            e.Graphics.DrawString("MESONES: ", _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
            _yPos += 20
            e.Graphics.DrawString("Envia : " & _NommesonEnv, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
            _yPos += 20
            e.Graphics.DrawString("Recibe: " & _NommesonRec, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            e.Graphics.DrawString("Observaciones: ", _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            e.Graphics.DrawString(Mid(_Observacion.Trim, 1, 31), _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            _Observacion = Mid(_Observacion.Trim, 32, 50)
            'If Mid(_Observacion, 1, 1) = " " Then
            '    _Observacion = Mid(_Observacion.Trim, 2, 30)
            'End If

            e.Graphics.DrawString(_Observacion, _Font_Detalle_Curr_8_B, Brushes.Black, _xPos, _yPos)
            _yPos += 20

            e.Graphics.DrawString(StrDup(200, "_"), _Font_Enc_2, Brushes.Black, _xPos, _yPos)


            e.HasMorePages = False

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("Log_Errores.log", ex.Message & vbCrLf & ex.StackTrace, False)
            MsgBox(ex.Message)
            MsgBox("Error lo puesde ver en archivo Log de errores")
        End Try

    End Sub

    Private Function Fx_Codigo_Barras(_Codigo As String) As PictureBox

        'Código de barras 
        Dim _Bmp As Bitmap = Nothing
        Dim _CodBarras As New PictureBox
        Dim _Imagen As New PictureBox

        Dim _iType As BarCode.Code128SubTypes =
        DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)

        _Bmp = BarCode.Code128(_Codigo, _iType, False)

        If Not IsNothing(_Bmp) Then
            _CodBarras.Image = _Bmp
        End If

        Return _CodBarras

    End Function

    Function Fx_Imprimir_Etiqueta_PRN(_Formulario As Form,
                                     _Id_MesonVsEnvioRecibe As Integer,
                                     _NombreEtiqueta As String,
                                     _Puerto As String)

        Dim _Fecha_impresion As Date = Now

        _Row_Comprobante = Fx_Llenar_Row_Comprobante(_Id_MesonVsEnvioRecibe)

        Dim _Texto As String

        _Texto = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Tbl_DisenoBarras", "FUNCION", "NombreEtiqueta = '" & _NombreEtiqueta & "'")

        If IsNothing(_Row_Comprobante) Then
            MessageBoxEx.Show(_Formulario, "No existen datos que mostrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Dim _Idpote = _Row_Comprobante.Item("Idpote")
        Dim _Numot = _Row_Comprobante.Item("Numot")

        Dim _Nokoen As String

        'Datos para ver documentos relacionados.
        Consulta_sql = "Select DISTINCT IDPOTE,EDO.IDMAEEDO,EDO.SUDO,POTLCOM.DESDE AS TIDOD, POTLCOM.NUMECOTI AS NUDOD,KOFUDO," &
                           "NOKOFU AS VENDEDOR,EDO.ENDO,EDO.SUENDO,NOKOEN,NOKOEN,Isnull(OBS.OBDO,'') As OBDO,Isnull(OBS.OCDO,'') As OCDO" & vbCrLf &
                           "From POTL WITH ( NOLOCK )" & vbCrLf &
                           "Inner Join POTLCOM On POTLCOM.IDPOTL = POTL.IDPOTL" & vbCrLf &
                           "Left Outer Join MAEEDO EDO On EDO.TIDO = POTLCOM.DESDE AND POTLCOM.NUMECOTI = EDO.NUDO" & vbCrLf &
                           "Left Outer Join MAEEN On EDO.ENDO = KOEN AND EDO.SUENDO = SUEN" & vbCrLf &
                           "Left Outer Join TABFU On KOFU = KOFUDO" & vbCrLf &
                           "Left Join MAEEDOOB OBS On OBS.IDMAEEDO = EDO.IDMAEEDO" & vbCrLf &
                           "WHERE POTL.NUMOT='" & _Numot & "' AND POTL.EMPRESA = '" & ModEmpresa & "'"
        Dim _TblDocRela As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
        Dim _Row_DocRela As DataRow

        If CBool(_TblDocRela.Rows.Count) Then
            _Row_DocRela = _TblDocRela.Rows(0)
        End If

        Dim _Id As String = numero_(_Row_Comprobante.Item("Id"), 6)
        Dim _Tido As String
        Dim _Nudo As String
        Dim _Nomcliente As String
        Dim _Referencia As String = _Row_Comprobante.Item("Referencia").ToString.Trim

        If Not IsNothing(_Row_DocRela) Then

            _Tido = _Row_DocRela.Item("TIDOD").ToString.Trim
            _Nudo = _Row_DocRela.Item("NUDOD").ToString.Trim
            _Nomcliente = _Row_DocRela.Item("NOKOEN").ToString.Trim

            _Referencia = _Tido & "-" & _Nudo & ", " & _Nomcliente

        End If

        Dim _Codigo As String = _Row_Comprobante.Item("Codigo").ToString.Trim
        Dim _Descripcion As String = _Row_Comprobante.Item("Glosa").ToString.Trim
        Dim _NommesonEnv As String = _Row_Comprobante.Item("NommesonEnv").ToString.Trim
        Dim _NommesonRec As String = _Row_Comprobante.Item("NommesonRec").ToString.Trim
        Dim _CantEnvia As Double = _Row_Comprobante.Item("CantEnvia")
        Dim _EtqCantEnvia As String = Fx_Formato_Numerico(_CantEnvia, "999.999", False)

        Dim _Fecha_Creacion_Ot As DateTime = _Row_Comprobante.Item("Fecha_Creacion_Ot")
        Dim _Fecha_Asignacion As DateTime = _Row_Comprobante.Item("Fecha_Asignacion")
        Dim _FechaHoraEnvia As DateTime = _Row_Comprobante.Item("FechaHoraEnvia")
        'Dim _EsReproceso As Boolean = _Row_Comprobante.Item("EsReproceso")
        'Dim _EsMesonVirtual As Boolean = _Row_Comprobante.Item("EsMesonVirtual")
        'Dim _EsMesonFinal As Boolean = _Row_Comprobante.Item("EsMesonFinal")
        Dim _Codigoob As String = _Row_Comprobante.Item("Codigoob").ToString.Trim
        Dim _Operario As String = _Row_Comprobante.Item("Operario").ToString.Trim
        Dim _CodFuncionario As String = _Row_Comprobante.Item("CodFuncionario").ToString.Trim
        Dim _NomFuncionario As String = _Row_Comprobante.Item("NomFuncionario").ToString.Trim
        Dim _Observacion As String = _Row_Comprobante.Item("Observacion").ToString.Trim

        _Texto = Replace(_Texto, "<ID>", _Id)
        _Texto = Replace(_Texto, "<NUMOT>", _Numot)
        _Texto = Replace(_Texto, "<IDPOTE>", _Idpote)

        _Texto = Replace(_Texto, "<CODIGO_PR>", _Codigo)
        _Texto = Replace(_Texto, "<DESCRIPCION>", _Descripcion)
        _Texto = Replace(_Texto, "<DESCRIPCION_1-25>", _Descripcion)
        _Texto = Replace(_Texto, "<DESCRIPCION_26-50>", _Descripcion)
        _Texto = Replace(_Texto, "<NOMMESONENV>", _NommesonEnv)
        _Texto = Replace(_Texto, "<NOMMESONREC>", _NommesonRec)
        _Texto = Replace(_Texto, "<CANTENVIA>", _EtqCantEnvia)

        _Texto = Replace(_Texto, "<FECHA_CREACION_OT>", FormatDateTime(_Fecha_Creacion_Ot, DateFormat.ShortDate))
        _Texto = Replace(_Texto, "<FECHA_ASIGNACION>", FormatDateTime(_Fecha_Asignacion, DateFormat.ShortDate))
        _Texto = Replace(_Texto, "<FECHAHORAENVIA>", _FechaHoraEnvia)

        _Texto = Replace(_Texto, "<CODIGOOB>", _Codigoob)
        _Texto = Replace(_Texto, "<OPERARIO>", _Operario)
        _Texto = Replace(_Texto, "<CODFUNCIONARIO>", _CodFuncionario)
        _Texto = Replace(_Texto, "<NOMFUNCIONARIO>", _NomFuncionario)
        _Texto = Replace(_Texto, "<OBSERVACION>", _Observacion)

        _Texto = Replace(_Texto, "<TIDO>", _Tido)
        _Texto = Replace(_Texto, "<NUDO>", _Nudo)
        _Texto = Replace(_Texto, "<NOMCLIENTE>", _Nomcliente)
        _Texto = Replace(_Texto, "<REFERENCIA>", _Referencia)

        '        'Dim _St_PU01_Neto As String = Fx_Formato_Numerico(_PU01_Neto, "9", False)
        'Dim _St_PU02_Neto As String = Fx_Formato_Numerico(_PU02_Neto, "9", False)
        'Dim _St_PU01_Bruto As String = Fx_Formato_Numerico(_PU01_Bruto, "9", False)
        'Dim _St_PU02_Bruto As String = Fx_Formato_Numerico(_PU02_Bruto, "9", False)

        'Dim _St_PU01_Neto_d1 As String = Fx_Formato_Numerico(_PU01_Neto, "9,9", False)
        'Dim _St_PU02_Neto_d1 As String = Fx_Formato_Numerico(_PU02_Neto, "9,9", False)
        'Dim _St_PU01_Bruto_d1 As String = Fx_Formato_Numerico(_PU01_Bruto, "9,9", False)
        'Dim _St_PU02_Bruto_d1 As String = Fx_Formato_Numerico(_PU02_Bruto, "9,9", False)

        'Dim _St_PU01_Neto_d2 As String = Fx_Formato_Numerico(_PU01_Neto, "9,99", False)
        'Dim _St_PU02_Neto_d2 As String = Fx_Formato_Numerico(_PU02_Neto, "9,99", False)
        'Dim _St_PU01_Bruto_d2 As String = Fx_Formato_Numerico(_PU01_Bruto, "9,99", False)
        'Dim _St_PU02_Bruto_d2 As String = Fx_Formato_Numerico(_PU02_Bruto, "9,99", False)

        'Dim _St_PU01_Neto2 As String = Fx_Formato_Numerico(_PU01_Neto, "99.999", False)
        'Dim _St_PU02_Neto2 As String = Fx_Formato_Numerico(_PU02_Neto, "99.999", False)
        'Dim _St_PU01_Bruto2 As String = Fx_Formato_Numerico(_PU01_Bruto, "99.999", False)
        'Dim _St_PU02_Bruto2 As String = Fx_Formato_Numerico(_PU02_Bruto, "99.999", False)

        'Dim _St_PU01_Neto3 As String = Fx_Formato_Numerico(_PU01_Neto, "999.999", False)
        'Dim _St_PU02_Neto3 As String = Fx_Formato_Numerico(_PU02_Neto, "999.999", False)
        'Dim _St_PU01_Bruto3 As String = Fx_Formato_Numerico(_PU01_Bruto, "999.999", False)
        'Dim _St_PU02_Bruto3 As String = Fx_Formato_Numerico(_PU02_Bruto, "999.999", False)

        'Dim _St_PU01_Neto4 As String = Fx_Formato_Numerico(_PU01_Neto, "9.999.999", False)
        'Dim _St_PU02_Neto4 As String = Fx_Formato_Numerico(_PU02_Neto, "9.999.999", False)
        'Dim _St_PU01_Bruto4 As String = Fx_Formato_Numerico(_PU01_Bruto, "9.999.999", False)
        'Dim _St_PU02_Bruto4 As String = Fx_Formato_Numerico(_PU02_Bruto, "9.999.999", False)


        Dim fic As String = AppPath(True) & "Barra.prn"

        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine(_Texto)
        sw.Close()

        System.IO.File.Copy("Barra.prn", _Puerto)

    End Function

End Class
