Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Diagnostics

Public Class Frm_Archivador_Buscador

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Private _Cancelar As Boolean = False

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Archivador_Buscador_Load(sender As Object, e As EventArgs) Handles Me.Load

        With My.Settings
            'If .Location.X > -1 Then
            '    Me.Location = .Location
            '    Me.Size = .Size
            'End If
            Me.txtDir.Text = .Archivador_Ruta

            Me.txtFiltro.Text = .Archivador_Filtro_Arch
            'Me.txtFiltro.Text = "*"
        End With
        With My.Application.Info
            Me.LabelInfo.Text = .Title & " v" & .Version.ToString & " - " & .Copyright
        End With
        Me.txtFiltro.Enabled = True
        Btn_Abrir_Archivo.Enabled = False
        Btn_Abrir_Directorio.Enabled = False
        Btn_Abrir_Documento.Enabled = False
        Btn_Integrar_Archivos.Enabled = False

    End Sub

    Private Sub Btn_Examinar_Click(sender As Object, e As EventArgs) Handles Btn_Examinar.Click

        Dim oFD As New FolderBrowserDialog
        With oFD
            .Description = "Seleccionar el directorio de búsqueda"
            .RootFolder = Environment.SpecialFolder.MyComputer
            .SelectedPath = Me.txtDir.Text
            If .ShowDialog = DialogResult.OK Then
                Me.txtDir.Text = .SelectedPath
            End If
        End With

    End Sub

    Private Sub Btn_Buscar_Click(sender As Object, e As EventArgs) Handles Btn_Buscar.Click

        ' Buscar de forma recursiva (si es necesario)

        Btn_Abrir_Archivo.Enabled = False
        Btn_Abrir_Directorio.Enabled = False
        Btn_Abrir_Documento.Enabled = False

        Static yaEstoy As Boolean

        If yaEstoy Then
            _Cancelar = True
            Btn_Buscar.Text = "Cancelando..."
            Application.DoEvents()
            Exit Sub
        End If
        yaEstoy = True

        With My.Settings
            '.Location = Me.Location
            '.Size = Me.Size
            .Archivador_Ruta = Me.txtDir.Text
            .Archivador_Filtro_Arch = Me.txtFiltro.Text
            '.Filtro = Me.txtFiltro.Text
            '.conSubDir = Me.chkConSubDir.Checked
            '.IgnorarError = Me.chkIgnorarError.Checked
            .Save()

            Dim di As New DirectoryInfo(.Archivador_Ruta)
            Dim di2 As String = .Archivador_Ruta
            Me.lvFics.Items.Clear()

            LabelInfo.Text = "Buscando los ficheros..."
            Me.Cursor = Cursors.AppStarting
            Btn_Buscar.Text = "Buscando..."
            Me.Refresh()

            Sb_Recorrer_Dir(di)
            ' Sb_Recorrer_Dir_2(di2)

        End With

        Me.Cursor = Cursors.Default
        Me.LabelInfo.Text = "Se han hallado " & Me.lvFics.Items.Count & " ficheros"
        Btn_Buscar.Text = "Buscar"

        If Me.lvFics.Items.Count > 0 Then
            Btn_Abrir_Archivo.Enabled = True
            Btn_Abrir_Directorio.Enabled = True
            Btn_Abrir_Documento.Enabled = True
            Btn_Integrar_Archivos.Enabled = True
            Lbl_Progress.Text = "Haga Click En Integrar Archivos Para Comenzar..."
            ProgressBar1.Value = 0
        Else
            Btn_Abrir_Archivo.Enabled = False
            Btn_Abrir_Directorio.Enabled = False
            Btn_Abrir_Documento.Enabled = False
            Btn_Integrar_Archivos.Enabled = False
            Lbl_Progress.Text = "No se encontraron archivos para integrar"
            ProgressBar1.Value = 0
        End If

        Me.Refresh()

        _Cancelar = False

        yaEstoy = False

    End Sub
    Private Sub Sb_Recorrer_Dir_2(di2 As String)

        Application.DoEvents()
        If _Cancelar Then Exit Sub

        Me.LabelInfo.Text = di2 & "..."
        Me.LabelInfo.Refresh()
        Try
            Dim files() As String = Directory.GetFiles(di2)
            For Each file As String In files
                Dim item As New ListViewItem()
                lvFics.Items.Add(item)

                item.Text = Replace(file, di2 & "\", "")
                item.SubItems.Add(di2)
            Next
            If chkConSubDir.Checked Then

                Dim dirs() As String = Directory.GetDirectories(di2)
                For Each directory As String In dirs
                    Sb_Recorrer_Dir_2(directory)
                Next
            End If
        Catch ex As Exception
            If chkIgnorarError.Checked Then
                Exit Sub
            End If

            If MessageBox.Show("Error: " & ex.Message & vbCrLf &
                               "¿Quieres cancelar o continuar?",
                               "Buscar en directorios",
                               MessageBoxButtons.OKCancel,
                               MessageBoxIcon.Exclamation
                               ) = DialogResult.Cancel Then
                _Cancelar = True
                Application.DoEvents()
            End If
        End Try
    End Sub
    Private Sub Sb_Recorrer_Dir(ByVal di As DirectoryInfo)
        ' Recorrer los ficheros de este directorio
        ' añadir al listview si se encuentra alguno
        Dim fics() As FileInfo
        Dim dirs() As DirectoryInfo

        Application.DoEvents()
        If _Cancelar Then Exit Sub

        Me.LabelInfo.Text = di.FullName & "..."
        Me.LabelInfo.Refresh()

        With My.Settings
            Try
                'fics = di.GetFiles(Me.txtFiltro.Text, SearchOption.TopDirectoryOnly)
                fics = di.GetFiles(.Archivador_Filtro_Arch, SearchOption.TopDirectoryOnly)
                With Me.lvFics
                    For Each fi As FileInfo In fics
                        Dim lvi As ListViewItem = .Items.Add(fi.Name)
                        lvi.SubItems.Add(fi.DirectoryName)
                    Next
                    '.Refresh()
                End With

                If chkConSubDir.Checked Then

                    dirs = di.GetDirectories()
                    For Each dir As DirectoryInfo In dirs
                        Sb_Recorrer_Dir(dir)
                    Next
                End If


            Catch ex As Exception
                If chkIgnorarError.Checked Then
                    Exit Sub
                End If

                If MessageBox.Show("Error: " & ex.Message & vbCrLf &
                                   "¿Quieres cancelar o continuar?",
                                   "Buscar en directorios",
                                   MessageBoxButtons.OKCancel,
                                   MessageBoxIcon.Exclamation
                                   ) = DialogResult.Cancel Then
                    _Cancelar = True
                    Application.DoEvents()
                End If
            End Try
        End With
    End Sub

    Private Sub lvFics_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvFics.MouseDoubleClick

        With lvFics
            If .SelectedIndices.Count = 0 Then
                Exit Sub
            End If

            ' Comprobar en que columna se ha hecho doble clic
            ' El valor de e.X es relativo al control,
            ' por tanto, no hace falta añadir nada más.
            If e.X < .Columns(0).Width Then
                ' El nombre

                ' Abrir el fichero indicado
                ' Combinar los paths para que se agregue el separador de directorio
                ' si así hiciera falta
                Dim _Archivo As String = Path.Combine(.SelectedItems(0).SubItems(1).Text,
                                                 .SelectedItems(0).SubItems(0).Text)
                'Process.Start(fic)

                Sb_Abrir_Archivo(_Archivo)

            Else
                ' El directorio

                ' Abrir la ventana con el directorio del fichero indicado
                Dim dir As String = .SelectedItems(0).SubItems(1).Text
                Process.Start("explorer.exe", dir)
            End If

        End With

    End Sub

    Sub Sb_Abrir_Archivo(_Archivo As String)

        Dim Extencion As String = LCase(Replace(System.IO.Path.GetExtension(_Archivo), ".", ""))

        If Extencion = "xml" Then

            Dim _Validacion As String

            If String.IsNullOrEmpty(_Validacion) Then

                Dim Ds_Xml As New DataSet

                Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
                Dim Consulta_Sql As String

                Consulta_Sql = "Select * From MAEEDO Where 1<0
                                Select * From MAEDDO Where 1<0
                                Select * From MAEIMLI Where 1<0
                                Select * From MAEDTLI Where 1<0
                                Select * From MAEEDOOB Where 1<0
                                Select * From MAEVEN Where 1<0"

                Ds_Xml = _Sql.Fx_Get_DataSet(Consulta_Sql, True)

                Ds_Xml.Tables(0).TableName = "Maeedo"
                Ds_Xml.Tables(1).TableName = "Maeddo"
                Ds_Xml.Tables(2).TableName = "Maeimli"
                Ds_Xml.Tables(3).TableName = "Maedtli"
                Ds_Xml.Tables(4).TableName = "Maeedoob"
                Ds_Xml.Tables(5).TableName = "Maeven"

                Ds_Xml.Clear()
                Ds_Xml.ReadXml(_Archivo, XmlReadMode.Auto)

                Dim _Error As String

                Dim Fm As New Frm_Ver_Documento(0, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Arcvhivador_XML)
                Fm.Datos_Documento = Ds_Xml

                If String.IsNullOrEmpty(Fm.Error) Then
                    Fm.ShowDialog(Me)
                Else
                    MessageBoxEx.Show(Me, Fm.Error, "No se puede abrir el documento", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                Fm.Dispose()

            End If

        End If


    End Sub

    Private Sub Btn_Abrir_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Abrir_Documento.Click

        With lvFics
            If .SelectedIndices.Count = 0 Then
                Exit Sub
            End If

            ' Abrir el fichero indicado
            ' Combinar los paths para que se agregue el separador de directorio
            ' si así hiciera falta
            Dim _Archivo As String = Path.Combine(.SelectedItems(0).SubItems(1).Text,
                                                 .SelectedItems(0).SubItems(0).Text)
            'Process.Start(fic)

            Sb_Abrir_Archivo(_Archivo)

        End With

    End Sub

    Private Sub Btn_Abrir_Archivo_Click(sender As Object, e As EventArgs) Handles Btn_Abrir_Archivo.Click

        With lvFics
            If .SelectedIndices.Count = 0 Then
                Exit Sub
            End If

            ' Abrir el fichero indicado
            ' Combinar los paths para que se agregue el separador de directorio
            ' si así hiciera falta
            Dim _Archivo As String = Path.Combine(.SelectedItems(0).SubItems(1).Text,
                                                 .SelectedItems(0).SubItems(0).Text)
            Process.Start(_Archivo)

        End With

    End Sub

    Private Sub Btn_Abrir_Directorio_Click(sender As Object, e As EventArgs) Handles Btn_Abrir_Directorio.Click

        With lvFics
            If .SelectedIndices.Count = 0 Then
                Exit Sub
            End If

            ' Abrir la ventana con el directorio del fichero indicado
            Dim dir As String = .SelectedItems(0).SubItems(1).Text
            Process.Start("explorer.exe", dir)

        End With

    End Sub

    Private Sub Btn_Integrar_Archivos_Click(sender As Object, e As EventArgs) Handles Btn_Integrar_Archivos.Click

        Dim TipoArchivo As String

        Btn_Abrir_Archivo.Enabled = False
        Btn_Abrir_Directorio.Enabled = False
        Btn_Abrir_Documento.Enabled = False
        Btn_Integrar_Archivos.Enabled = False

        If lvFics.Items.Count > 0 Then

            Lbl_Progress.Text = "Proceso de Integracion de Archivos: " & ProgressBar1.Value & "%"
            ProgressBar1.Value = 0

            For i = 0 To lvFics.Items.Count - 1
                TipoArchivo = Mid(lvFics.Items(i).Text, 1, 3)
                If TipoArchivo = "FCV" Or TipoArchivo = "GDV" Then
                    IntegrarArchivos(i)
                ElseIf TipoArchivo = "Pag" Then
                    IntegrarPagos(i)
                End If

            Next

            If ProgressBar1.Value < 100 Then

                ProgressBar1.Value = 100
                Lbl_Progress.Text = "Proceso Completado"

                Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Log_Archivador"
                Dim _TblLog As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

                ExportarTabla_JetExcel_Tabla(_TblLog, Me, "Log_Archivador")

                Btn_Abrir_Archivo.Enabled = True
                Btn_Abrir_Directorio.Enabled = True
                Btn_Abrir_Documento.Enabled = True
                Btn_Integrar_Archivos.Enabled = True

            End If

        Else
            MessageBoxEx.Show(Me, "No hay archivos para Integrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub IntegrarArchivos(i As Integer)

        Dim PasoProgreso As Double = 50 / (lvFics.Items.Count * 3)
        Dim EditDesign As DataSet

        ProgressBar1.Step = PasoProgreso

        'Dim consulta As String = "DECLARE @id int;"

        EditDesign = New DataSet
        Dim url As String = lvFics.Items(i).SubItems(1).Text & "\" & lvFics.Items(i).Text
        Dim TipoArchivo As String = Mid(lvFics.Items(i).Text, 1, 3)
        Dim NudoArchivo As String = Mid(lvFics.Items(i).Text, 5, 10)
        Dim IdArchivo As String = ""
        Dim IdOldArchivo As String = ""
        Dim Respuesta As String
        Dim MensajeLog As String = ""
        ' Dim consulta As String = "DECLARE @id int;"
        Dim consulta As String = ""
        'MsgBox("Tipo: " & TipoArchivo & vbCrLf & "Nudo: " & NudoArchivo)

        'Revisar si el archivo existe, si no, se va al siguiente archivo
        If Not VerificarArchivo(TipoArchivo, NudoArchivo) Then
            'Si no existe el archivo, integrar a la bd
            'MsgBox("Archivo no existe")
            'Exit Sub

            EditDesign.ReadXml(url)
            'Aumentar Progress
            ProgressBar1.PerformStep()
            Lbl_Progress.Text = "Proceso de Integracion de Archivos: " & ProgressBar1.Value & "%"
            Application.DoEvents()
            'MsgBox("Archivo no existe")

            For Each Tabla As DataTable In EditDesign.Tables

                consulta = consulta & "INSERT [" & Tabla.TableName.ToUpper & "] ("

                For Each Columna As DataColumn In EditDesign.Tables(Tabla.TableName).Columns
                    If Not (Tabla.TableName.ToUpper = "MAEEDO" And Columna.ColumnName = "IDMAEEDO" Or Columna.ColumnName = "FECREEN" Or Columna.ColumnName = "IDMAEDDO" Or Columna.ColumnName = "IDMAEVEN" Or Columna.ColumnName = "IDMAEEN") Then
                        consulta = consulta & Columna.ColumnName & ","
                    End If
                Next

                consulta = consulta & ") VALUES "

                For Each Fila As DataRow In EditDesign.Tables(Tabla.TableName).Rows

                    consulta = consulta & "("

                    For Each Columna As DataColumn In EditDesign.Tables(Tabla.TableName).Columns

                        If Tabla.TableName.ToUpper = "MAEEDO" And Columna.ColumnName = "IDMAEEDO" Then
                            IdOldArchivo = Fila(Columna.ColumnName)
                        End If

                        If Not (Tabla.TableName.ToUpper = "MAEEDO" And Columna.ColumnName = "IDMAEEDO" Or Columna.ColumnName = "FECREEN" Or Columna.ColumnName = "IDMAEDDO" Or Columna.ColumnName = "IDMAEVEN" Or Columna.ColumnName = "IDMAEEN") Then
                            If Columna.ColumnName = "FEEMDO" Or
                                Columna.ColumnName = "FE01VEDO" Or
                                Columna.ColumnName = "FEULVEDO" Or
                                Columna.ColumnName = "FEER" Or
                                Columna.ColumnName = "LAHORA" Or
                                Columna.ColumnName = "FLIQUIFCV" Or
                                Columna.ColumnName = "FEEMLI" Or
                                Columna.ColumnName = "FEERLI" Or
                                Columna.ColumnName = "FECHAE" Or
                                Columna.ColumnName = "FECHAD" Or
                                Columna.ColumnName = "FEVE" Or Columna.ColumnName = "FECREEN" Or Columna.ColumnName = "FEVECREN" Or Columna.ColumnName = "FEULTR" Then
                                consulta = consulta & "'" & DateTime.Parse(Fila(Columna.ColumnName)).ToString("yyyy-MM-ddTHH:mm:ss") & "',"
                            ElseIf Columna.ColumnName = "IDMAEEDO" Then
                                'consulta = consulta & "@id,"
                                consulta = consulta & "'" & IdArchivo & "',"
                            Else
                                consulta = consulta & "'" & Fila(Columna.ColumnName) & "',"
                            End If
                            ' consulta = consulta & "'" & Fila(Columna.ColumnName) & "',"
                        End If

                    Next
                    consulta = consulta & "),"
                Next

                consulta = consulta & ";"

                If Tabla.TableName.ToUpper = "MAEEDO" Then

                    consulta = consulta & "SELECT SCOPE_IDENTITY();"
                    consulta = Replace(consulta, ",)", ")")
                    consulta = Replace(consulta, ",;", ";")
                    IdArchivo = ObtenerIDArchivo(consulta)
                    consulta = ""

                End If

            Next

            consulta = Replace(consulta, ",)", ")")
            consulta = Replace(consulta, ",;", ";")

            'Txt_Consulta.Text = consulta
            Respuesta = _Sql.Fx_Ejecutar_Consulta(consulta)
            'Aumentar Progress
            ProgressBar1.PerformStep()
            Lbl_Progress.Text = "Proceso de Integracion de Archivos: " & ProgressBar1.Value & "%"

            Application.DoEvents()

            If Respuesta = "OK" Then
                MensajeLog = "Se ha recuperado el archivo: " & TipoArchivo & "-" & NudoArchivo & "."
                RegistrarLog(MensajeLog, IdOldArchivo, IdArchivo, "MAEEDO")

            ElseIf Respuesta.Contains("Infracción de la restricción PRIMARY KEY") Then
                MensajeLog = "Se ha recuperado el archivo: " & TipoArchivo & "-" & NudoArchivo & ". Pero el Cliente ya se encontraba registrado."
                RegistrarLog(MensajeLog, IdOldArchivo, IdArchivo, "MAEEDO")
            Else
                MensajeLog = "Se ha intentado recuperar el archivo: " & TipoArchivo & "-" & NudoArchivo & ". Con inconvenientes en el proceso, favor de intentar nuevamente."
                RegistrarLog(MensajeLog, IdOldArchivo, IdArchivo, "MAEEDO")
            End If
            'Aumentar Progress
            ProgressBar1.PerformStep()
            Lbl_Progress.Text = "Proceso de Integracion de Archivos: " & ProgressBar1.Value & "%"
            Application.DoEvents()

        Else

            'Aumentar Progress
            ProgressBar1.PerformStep()
            Lbl_Progress.Text = "Proceso de Integracion de Archivos: " & ProgressBar1.Value & "%"
            Application.DoEvents()
            'Aumentar Progress
            ProgressBar1.PerformStep()
            Lbl_Progress.Text = "Proceso de Integracion de Archivos: " & ProgressBar1.Value & "%"
            Application.DoEvents()
            'MsgBox("Archivo Si existe. Brinca al siguiente")
            MensajeLog = "Se ha intentado recuperar pero ya existe el archivo: " & TipoArchivo & "-" & NudoArchivo & "."
            RegistrarLog(MensajeLog, IdOldArchivo, IdArchivo, "MAEEDO")
            'Aumentar Progress
            ProgressBar1.PerformStep()
            Lbl_Progress.Text = "Proceso de Integracion de Archivos: " & ProgressBar1.Value & "%"
            Application.DoEvents()

        End If

        If ProgressBar1.Value < 100 Then
            Lbl_Progress.Text = "Proceso Completado"
        End If

    End Sub

    Private Sub IntegrarPagos(i As Integer)

        Dim PasoProgreso As Double = 50 / (lvFics.Items.Count * 4)
        ProgressBar1.Step = PasoProgreso
        Dim EditDesign As DataSet
        'Dim consulta As String = "DECLARE @id int;"
        EditDesign = New DataSet
        Dim url As String = lvFics.Items(i).SubItems(1).Text & "\" & lvFics.Items(i).Text

        'MsgBox("Tipo: " & TipoArchivo & vbCrLf & "Nudo: " & NudoArchivo)
        'Revisar si el archivo existe, si no, se va al siguiente archivo

        'Si no existe el archivo, integrar a la bd
        'MsgBox("Archivo no existe")
        'Exit Sub

        EditDesign.ReadXml(url)
        'Aumentar Progress
        ProgressBar1.PerformStep()
        Lbl_Progress.Text = "Proceso de Integracion de Pagos: " & ProgressBar1.Value & "%"
        Application.DoEvents()
        'MsgBox("Archivo no existe")
        For Each Tabla As DataTable In EditDesign.Tables
            'Aqui poner la validacion de si el pago maedpce existe o no

            If Tabla.TableName.ToUpper = "MAEDPCE" Then
                IntegrarPagoMaedpce(EditDesign, Tabla.TableName.ToUpper)

            End If
            If Tabla.TableName.ToUpper = "MAEDPCD" Then
                IntegrarPagoMaedpcd(EditDesign, Tabla.TableName.ToUpper)
                ProgressBar1.PerformStep()
            End If

            If ProgressBar1.Value >= 100 Then
                Lbl_Progress.Text = "Proceso Completado"
            End If

        Next

    End Sub

    Private Sub IntegrarPagoMaedpce(EditDesign As DataSet, Tabla As String)

        Dim TipoPago As String = String.Empty
        Dim NudoPago As String = String.Empty
        Dim IdArchivo As String = String.Empty
        Dim IdOldArchivo As String = String.Empty
        Dim Respuesta As String = String.Empty
        Dim MensajeLog As String = String.Empty

        Consulta_Sql = String.Empty

        For Each Fila As DataRow In EditDesign.Tables(Tabla).Rows

            TipoPago = Fila("TIDP")
            NudoPago = Fila("NUDP")

            If Not VerificarPago(TipoPago, NudoPago) Then

                Consulta_Sql = Consulta_Sql & "INSERT [" & Tabla & "] ("
                For Each Columna As DataColumn In EditDesign.Tables(Tabla).Columns
                    If Not (Columna.ColumnName = "IDMAEDPCD" Or Columna.ColumnName = "IDMAEDPCE") Then
                        Consulta_Sql = Consulta_Sql & Columna.ColumnName & ","
                    End If
                Next

                Consulta_Sql = Consulta_Sql & ") VALUES "
                Consulta_Sql = Consulta_Sql & "("

                For Each Columna As DataColumn In EditDesign.Tables(Tabla).Columns

                    If Not (Columna.ColumnName = "IDMAEDPCD") Then
                        If Columna.ColumnName = "FEEMDP" Or
                        Columna.ColumnName = "FEVEDP" Or
                        Columna.ColumnName = "LAHORA" Or
                        Columna.ColumnName = "FEASDP" Or
                        Columna.ColumnName = "LAHORA" Then
                            Consulta_Sql = Consulta_Sql & "'" & DateTime.Parse(Fila(Columna.ColumnName)).ToString("yyyy-MM-ddTHH:mm:ss") & "',"
                        ElseIf Columna.ColumnName = "IDMAEDPCE" Then
                            IdOldArchivo = Fila(Columna.ColumnName)
                            'Consulta_Sql = Consulta_Sql & "@id,"
                        Else
                            Consulta_Sql = Consulta_Sql & "'" & Fila(Columna.ColumnName) & "',"
                        End If
                        ' Consulta_Sql = Consulta_Sql & "'" & Fila(Columna.ColumnName) & "',"
                    End If

                Next

                Consulta_Sql = Consulta_Sql & "),"
                'ESTA VEZ LA Consulta_Sql SE EJECUTA POR CADA PAGO ENCONTRADO EN MAEDPCE
                Consulta_Sql = Consulta_Sql & ";"

                Consulta_Sql = Consulta_Sql & "SELECT SCOPE_IDENTITY();"
                Consulta_Sql = Replace(Consulta_Sql, ",)", ")")
                Consulta_Sql = Replace(Consulta_Sql, ",;", ";")
                IdArchivo = ObtenerIDArchivo(Consulta_Sql)
                'consulta = ""

                'consulta = Replace(consulta, ",)", ")")
                'consulta = Replace(consulta, ",;", ";")
                'Txt_Consulta.Text = Txt_Consulta.Text & consulta
                If IdArchivo.Length = 6 Then
                    Respuesta = "OK"
                Else
                    Respuesta = ""
                End If

                'Respuesta = _Sql.Fx_Ejecutar_Consulta(consulta)

                'Aumentar Progress
                ProgressBar1.PerformStep()
                Lbl_Progress.Text = "Proceso de Integracion de Pagos: " & ProgressBar1.Value & "%"
                Application.DoEvents()
                If Respuesta = "OK" Then
                    MensajeLog = "Se ha recuperado el Pago: " & TipoPago & "-" & NudoPago & "."
                    RegistrarLog(MensajeLog, IdOldArchivo, IdArchivo, "MAEDPCE")

                ElseIf Respuesta.Contains("Infracción de la restricción PRIMARY KEY") Then
                    MensajeLog = "Se ha intentado recuperar el Pago: " & TipoPago & "-" & NudoPago & ". Pero ya se encontraba registrado."
                    RegistrarLog(MensajeLog, IdOldArchivo, IdArchivo, "MAEDPCE")
                Else
                    MensajeLog = "Se ha intentado recuperar el pago: " & TipoPago & "-" & NudoPago & ". Con inconvenientes en el proceso, favor de intentar nuevamente."
                    RegistrarLog(MensajeLog, IdOldArchivo, IdArchivo, "MAEDPCE")
                End If
                'Aumentar Progress
                ProgressBar1.PerformStep()
                Lbl_Progress.Text = "Proceso de Integracion de Pagos: " & ProgressBar1.Value & "%"
                Application.DoEvents()

            Else

                'Aumentar Progress
                ProgressBar1.PerformStep()
                Lbl_Progress.Text = "Proceso de Integracion de Pagos: " & ProgressBar1.Value & "%"
                Application.DoEvents()
                'Aumentar Progress
                ProgressBar1.PerformStep()
                Lbl_Progress.Text = "Proceso de Integracion de Pagos: " & ProgressBar1.Value & "%"
                Application.DoEvents()
                'MsgBox("Archivo Si existe. Brinca al siguiente")
                MensajeLog = "Se ha intentado recuperar pero ya existe el pago: " & TipoPago & "-" & NudoPago & "."
                RegistrarLog(MensajeLog, IdOldArchivo, IdArchivo, "MAEDPCE")
                'Aumentar Progress
                ProgressBar1.PerformStep()
                Lbl_Progress.Text = "Proceso de Integracion de Pagos: " & ProgressBar1.Value & "%"
                Application.DoEvents()

            End If

        Next

    End Sub

    Private Sub IntegrarPagoMaedpcd(EditDesign As DataSet, Tabla As String)

        Dim Respuesta As String
        Dim MensajeLog As String = String.Empty
        Consulta_Sql = String.Empty

        Consulta_Sql = Consulta_Sql & "INSERT [" & Tabla & "] ("

        For Each Columna As DataColumn In EditDesign.Tables(Tabla).Columns
            If Not (Columna.ColumnName = "IDMAEDPCD") Then
                Consulta_Sql = Consulta_Sql & Columna.ColumnName & ","
            End If
        Next

        Consulta_Sql = Consulta_Sql & ") VALUES "
        Consulta_Sql = Consulta_Sql & "("

        For Each Fila As DataRow In EditDesign.Tables(Tabla).Rows

            For Each Columna As DataColumn In EditDesign.Tables(Tabla).Columns

                If Not (Columna.ColumnName = "IDMAEDPCD") Then

                    If Columna.ColumnName = "FEEMDP" Or
                        Columna.ColumnName = "FEVEDP" Or
                        Columna.ColumnName = "LAHORA" Or
                        Columna.ColumnName = "FEASDP" Or
                        Columna.ColumnName = "LAHORA" Then
                        Consulta_Sql = Consulta_Sql & "'" & DateTime.Parse(Fila(Columna.ColumnName)).ToString("yyyy-MM-ddTHH:mm:ss") & "',"

                    ElseIf Columna.ColumnName = "IDMAEDPCE" Then

                        Dim nuevoIDRST As String = VerificarArchivoID(Fila("IDMAEDPCE"), "MAEDPCE")
                        Consulta_Sql = Consulta_Sql & "'" & nuevoIDRST & "',"
                        'consulta = consulta & "@id,"

                    ElseIf Columna.ColumnName = "IDRST" Then

                        Dim nuevoIDRST As String = VerificarArchivoID(Fila("IDRST"), "MAEEDO")
                        Consulta_Sql = Consulta_Sql & "'" & nuevoIDRST & "',"

                    Else

                        Consulta_Sql = Consulta_Sql & "'" & Fila(Columna.ColumnName) & "',"

                    End If
                    ' Consulta_Sql = Consulta_Sql & "'" & Fila(Columna.ColumnName) & "',"

                End If

            Next

            Consulta_Sql = Consulta_Sql & "),"
            'ESTA VEZ LA Consulta_Sql SE EJECUTA POR CADA PAGO ENCONTRADO EN MAEDPCE
            Consulta_Sql = Consulta_Sql & ";"

            'Consulta_Sql = Consulta_Sql & "SET @id=SCOPE_IDENTITY();"
            Consulta_Sql = Replace(Consulta_Sql, ",)", ")")
            Consulta_Sql = Replace(Consulta_Sql, ",;", ";")
            'IdArchivo = ObtenerIDArchivo(Consulta_Sql)
            'Consulta_Sql = ""

            Consulta_Sql = Replace(Consulta_Sql, ",)", ")")
            Consulta_Sql = Replace(Consulta_Sql, ",;", ";")
            'Txt_Consulta_Sql.Text = Txt_Consulta_Sql.Text & Consulta_Sql
            Respuesta = _Sql.Fx_Ejecutar_Consulta(Consulta_Sql)

        Next
    End Sub
    Private Function VerificarPago(Tipo As String, Nudo As String) As Boolean
        Try
            Consulta_Sql = "SELECT [IDMAEDPCE] FROM [MAEDPCE] WHERE TIDP='" & Tipo & "' AND NUDP='" & Nudo & "';"
            Dim Archivo As String() = _Sql.Fx_Obtener_Valores(Consulta_Sql, 1)

            If Archivo(0) = Nothing Or IsDBNull(Archivo(0)) Or Archivo(0) = "" Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function VerificarArchivo(Tipo As String, Nudo As String) As Boolean
        Try
            Consulta_Sql = "SELECT [IDMAEEDO] FROM [MAEEDO] WHERE TIDO='" & Tipo & "' AND NUDO='" & Nudo & "';"
            Dim Archivo As String() = _Sql.Fx_Obtener_Valores(Consulta_Sql, 1)

            If Archivo(0) = Nothing Or IsDBNull(Archivo(0)) Or Archivo(0) = "" Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function VerificarArchivoID(oldid As String, tabla As String) As String
        Try
            Consulta_Sql = "SELECT [Newidlog] FROM " & _Global_BaseBk & "Zw_Log_Archivador WHERE Oldidlog='" & oldid & "' AND Tablalog='" & tabla & "';"
            Dim Archivo As String() = _Sql.Fx_Obtener_Valores(Consulta_Sql, 1)

            If Archivo(0) = Nothing Or IsDBNull(Archivo(0)) Or Archivo(0) = "" Then
                Return oldid
            Else
                Return Archivo(0)
            End If
        Catch ex As Exception
            Return oldid
        End Try
    End Function

    Private Function ObtenerIDArchivo(Consulta) As String
        Try
            Dim Archivo As String() = _Sql.Fx_Obtener_Valores(Consulta, 1)

            If Archivo(0) = Nothing Or IsDBNull(Archivo(0)) Or Archivo(0) = "" Then
                    Return ""
                Else
                    Return Archivo(0)
                End If


        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub RegistrarLog(Mensaje As String, oldid As String, newid As String, tabla As String)
        Try
            Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Log_Archivador ([Fechalog],[Mensajelog],[Usuariolog],[Oldidlog],[Newidlog],[Tablalog]) VALUES ('" & Now.ToString("yyyy-MM-ddTH:mm:ss") & "','" & Mensaje & "','" & FUNCIONARIO & "','" & oldid & "','" & newid & "','" & tabla & "');"
            Dim Respuesta As String = _Sql.Fx_Ejecutar_Consulta(Consulta_Sql)
        Catch ex As Exception

        End Try
    End Sub
End Class
