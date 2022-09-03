Imports DevComponents.DotNetBar

Public Class Frm_Anotaciones_Ver_Anotaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Idrve As Integer
    Dim _Documento_En_Construccion As Boolean

    Dim _Tbl_Mevento As DataTable

    Dim _Fevento As Date

    Enum Tipo_Tabla
        MAEEDO
        MAEDDO
        MAEEN
        MAEDPCE
        POTE
        POTL
    End Enum

    Dim _Archive As String

    Public Property Tbl_Mevento As DataTable
        Get
            Return _Tbl_Mevento
        End Get
        Set(value As DataTable)
            _Tbl_Mevento = value
        End Set
    End Property

    Public Sub New(ByVal Idrve As Integer, ByVal Tabla As Tipo_Tabla)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        _Idrve = Idrve
        _Archive = Tabla.ToString

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Consulta_sql = "SELECT IDEVENTO,ARCHIRVE,IDRVE,KOFU," &
                       "Isnull((Select top 1 NOKOFU From TABFU Tf Where Tf.KOFU = Mv.KOFU),'') As 'Funcionario'," & vbCrLf &
                       "FEVENTO,FEVENTO AS Hora2,HORAGRAB,Convert(nvarchar, convert(datetime, (HORAGRAB*1.0/3600)/24), 108) As Hora,FECHAREF," & vbCrLf &
                       "KOTABLA,KOCARAC,(CASE WHEN LINK = '' THEN NOKOCARAC ELSE '(*) '+ NOKOCARAC END) AS 'NOKOCARAC'" & vbCrLf &
                       ",ISNULL(ARCHIRSE,'')AS ARCHIRSE,ISNULL(IDRSE,0) AS IDRSE,LINK,KOFUDEST" & vbCrLf &
                       "FROM MEVENTO Mv" & vbCrLf &
                       "WHERE ARCHIRVE='" & _Archive & "' AND IDRVE= " & _Idrve & vbCrLf &
                       "ORDER BY FEVENTO,HORAGRAB"

        _Tbl_Mevento = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Agregar_Anotacion.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Anotaciones_Ver_Anotaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _Fevento = FechaDelServidor() 'Format(FechaDelServidor, "yyyyMMdd")

        Btn_Ligar_traza_externa.Enabled = Convert.ToBoolean(_Idrve)
        Btn_Exportar_a_Excel.Enabled = Convert.ToBoolean(_Idrve)
        'Btn_Ver_Documento.Enabled = Convert.ToBoolean(_Idrve)

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        Sb_Actualizar_Grilla_Anotaciones_Eventos()

    End Sub

    Sub Sb_Actualizar_Grilla_Anotaciones_Eventos()

        If Convert.ToBoolean(_Idrve) Then

            Consulta_sql = "SELECT IDEVENTO,ARCHIRVE,IDRVE,KOFU," &
                       "Isnull((Select top 1 NOKOFU From TABFU Tf Where Tf.KOFU = Mv.KOFU),'') As 'Funcionario'," & vbCrLf &
                       "FEVENTO,FEVENTO AS Hora2,HORAGRAB,Convert(nvarchar, convert(datetime, (HORAGRAB*1.0/3600)/24), 108) As Hora,FECHAREF," & vbCrLf &
                       "KOTABLA,KOCARAC,(CASE WHEN LINK = '' THEN NOKOCARAC ELSE '(*) '+ NOKOCARAC END) AS 'NOKOCARAC'" & vbCrLf &
                       ",ISNULL(ARCHIRSE,'')AS ARCHIRSE,ISNULL(IDRSE,0) AS IDRSE,LINK" & vbCrLf &
                       "FROM MEVENTO Mv" & vbCrLf &
                       "WHERE ARCHIRVE='" & _Archive & "' AND IDRVE= " & _Idrve & vbCrLf &
                       "ORDER BY FEVENTO,HORAGRAB"

            _Tbl_Mevento = _Sql.Fx_Get_Tablas(Consulta_sql)

        End If

        With Grilla

            .DataSource = _Tbl_Mevento

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("KOFU").HeaderText = "Autor"
            .Columns("KOFU").Width = 40
            .Columns("KOFU").Visible = True

            .Columns("FEVENTO").HeaderText = "Fecha"
            .Columns("FEVENTO").Width = 80
            .Columns("FEVENTO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEVENTO").Visible = True

            .Columns("Hora2").HeaderText = "Hora"
            .Columns("Hora2").Width = 70
            .Columns("Hora2").DefaultCellStyle.Format = "hh:mm"
            .Columns("Hora2").Visible = True

            .Columns("KOTABLA").HeaderText = "Tabla"
            .Columns("KOTABLA").Width = 100
            .Columns("KOTABLA").Visible = True

            .Columns("KOCARAC").HeaderText = "Elemento"
            .Columns("KOCARAC").Width = 100
            .Columns("KOCARAC").Visible = True

            .Columns("NOKOCARAC").HeaderText = "Anotación"
            .Columns("NOKOCARAC").Width = 400
            .Columns("NOKOCARAC").Visible = True

        End With

    End Sub

    Private Sub Frm_Anotaciones_Ver_Anotaciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Sub Sb_Agregar_Anotacion_Simple()

        Dim _Insertar As Boolean

        If Convert.ToBoolean(_Idrve) Then
            _Insertar = Fx_Tiene_Permiso(Me, "Doc00001")
        Else
            _Insertar = True
        End If


        If _Insertar Then

            Dim _Nueva_Anotacion As String
            Dim _Aceptado As Boolean = InputBox_Bk(Me, "", "Nueva anotación/evento simple", _Nueva_Anotacion, True, _Tipo_Mayus_Minus.Normal, 200, True, _Tipo_Imagen.Texto)
            Dim _HoraGrab = Hora_Grab_fx(False)

            If _Aceptado Then

                If Convert.ToBoolean(_Idrve) Then

                    Consulta_sql = "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC," &
                                   "FECHAREF,HORAGRAB) VALUES " & vbCrLf &
                                   "('" & _Archive & "'," & _Idrve & ",'',0,'" & FUNCIONARIO &
                                   "','" & Format(FechaDelServidor, "yyyyMMdd") & "','','','" & _Nueva_Anotacion & "',GetDate()," & _HoraGrab & ")"

                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                        Sb_Actualizar_Grilla_Anotaciones_Eventos()

                        Beep()
                        ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.save,
                                               1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                    End If

                Else

                    Dim _Fecha_Hora As DateTime = Now '.GetDateTimeFormats() 'FechaDelServidor()

                    Fx_Row_Nueva_Linea(0, _Archive, 0, FUNCIONARIO, _Fecha_Hora, "", "", _Nueva_Anotacion, "", 0, _Fecha_Hora, "", "", _HoraGrab)

                End If

            End If

        End If

    End Sub

    Sub Sb_Agregar_Anotacion_Tabulada()

        Dim _Insertar As Boolean

        If Convert.ToBoolean(_Idrve) Then
            _Insertar = Fx_Tiene_Permiso(Me, "Doc00002")
        Else
            _Insertar = True
        End If

        If _Insertar Then

            'Me.WindowState = FormWindowState.Minimized

            Dim _Incorporar As Boolean

            Dim Fm As New Frm_Anotaciones_Tabuladas_01_Encabezados(
            Frm_Anotaciones_Tabuladas_01_Encabezados.Tipo_Apertura.Seleccion_tabla)
            Fm.Text = "Tabla de caracterizaciones, Selección de anotaciones/eventos"
            Fm.ShowDialog(Me)
            _Incorporar = Fm._Incorporar
            Fm.Dispose()

            'Me.WindowState = FormWindowState.Normal

            If _Incorporar Then

                Dim _TblDetalle As DataTable = Fm._TblDetalle

                Dim _Idrse As Integer
                Dim _Archirse As String
                Dim _Kotabla, _Kocarac, _Nokocarac As String

                Dim _HoraGrab = Hora_Grab_fx(False)
                Consulta_sql = String.Empty

                For Each _Fila As DataRow In _TblDetalle.Rows

                    If _Fila.Item("Chk") Then

                        _Kotabla = _Fila.Item("KOTABLA")
                        _Kocarac = _Fila.Item("KOCARAC")
                        _Nokocarac = _Fila.Item("NOKOCARAC")
                        _Idrse = _Fila.Item("IDRSE")
                        _Archirse = _Fila.Item("ARCHIRSE")

                        If CBool(_Idrse) Then
                            _Archirse = "MAEEDO"
                        End If

                        If Convert.ToBoolean(_Idrve) Then

                            Consulta_sql += "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC," &
                                        "FECHAREF,HORAGRAB) VALUES " & vbCrLf &
                                        "('" & _Archive & "'," & _Idrve & ",'" & _Archirse & "'," & _Idrse & ",'" & FUNCIONARIO &
                                        "','" & Format(_Fevento, "yyyyMMdd") &
                                        "','" & _Kotabla & "','" & _Kocarac & "','" & _Nokocarac &
                                        "',GetDate()," & _HoraGrab & ")" & vbCrLf

                        Else

                            Fx_Row_Nueva_Linea(0, _Archive, 0, FUNCIONARIO, _Fevento, _Kotabla, _Kocarac, _Nokocarac, _Archirse,
                                               _Idrse, _Fevento, "", "", _HoraGrab)
                            Consulta_sql = String.Empty

                        End If

                    End If

                Next



                If Not String.IsNullOrEmpty(Consulta_sql) Then

                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                        Sb_Actualizar_Grilla_Anotaciones_Eventos()

                        Beep()
                        ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.save,
                                               1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                    End If

                    Sb_Actualizar_Grilla_Anotaciones_Eventos()

                End If

            End If

        End If

    End Sub

    Sub Sb_Agregar_Anotacion_Link()

        Dim _Nombre_Archivo As String
        Dim _UbicArchivo As String

        Dim _Insertar As Boolean

        If Convert.ToBoolean(_Idrve) Then
            _Insertar = Fx_Tiene_Permiso(Me, "Doc00003")
        Else
            _Insertar = True
        End If

        If _Insertar Then

            Dim _OpenFileDialog As New OpenFileDialog

            With _OpenFileDialog
                '.Filter = "Ficheros DBF (PFMDSP10.dbf)|PFMDSP10.dbf|Todos (*.*)|*.*"
                .Filter = "Ficheros (*.*)|*.*"
                'Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
                .FileName = String.Empty
                '.ShowDialog(Me)

                If .ShowDialog(Me) = DialogResult.OK Then

                    _Nombre_Archivo = .SafeFileName
                    _UbicArchivo = .FileName
                    Dim _Aceptado As Boolean

                    _Aceptado = InputBox_Bk(Me, _UbicArchivo,
                                                         "Nueva anotación/evento simple", _Nombre_Archivo,
                                                         False, _Tipo_Mayus_Minus.Normal, 45, True, _Tipo_Imagen.Texto)

                    Dim _HoraGrab = Hora_Grab_fx(False)

                    If _Aceptado Then



                        If Convert.ToBoolean(_Idrve) Then

                            Consulta_sql = "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC," &
                                                                   "FECHAREF,HORAGRAB,LINK) VALUES " & vbCrLf &
                                                                   "('" & _Archive & "'," & _Idrve & ",'',0,'" & FUNCIONARIO &
                                                                   "','" & Format(FechaDelServidor, "yyyyMMdd") &
                                                                   "','','','" & _Nombre_Archivo & "',GetDate()," & _HoraGrab & ",'" & _UbicArchivo & "')"


                            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                                Sb_Actualizar_Grilla_Anotaciones_Eventos()

                                Beep()
                                ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.save,
                                                       1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                            End If

                        Else

                            Fx_Row_Nueva_Linea(0, _Archive, 0, FUNCIONARIO, _Fevento, "", "", _Nombre_Archivo, "", 0, _Fevento, _UbicArchivo, "", _HoraGrab)

                        End If

                    End If

                End If

            End With

        End If

    End Sub

    Sub Sb_Agregar_Anotacion_Ligar_traza_externa()

        If Fx_Tiene_Permiso(Me, "Doc00008") Then

            Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
            _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos, "")
            _Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos
            _Fm.ShowDialog(Me)

            If Not (_Fm.Pro_Row_Documento_Seleccionado Is Nothing) Then

                Dim _Idmaeedo_Liga As Integer = _Fm.Pro_Row_Documento_Seleccionado.Item("IDMAEEDO")


                Dim _Tido_Liga As String = _Fm.Pro_Row_Documento_Seleccionado.Item("TIDO")
                Dim _Nudo_Liga As String = _Fm.Pro_Row_Documento_Seleccionado.Item("NUDO")

                Dim _Reg As Boolean = CBool(_Sql.Fx_Trae_Dato("MEVENTO", "IDEVENTO",
                                                               "IDRVE = " & _Idrve & " And IDRSE = " & _Idmaeedo_Liga, True))

                If _Reg Then
                    MessageBoxEx.Show(Me, "DOCUMENTO " & _Tido_Liga & "-" & _Nudo_Liga & " YA ESTA LIGADO.",
                                      "VALIDACION",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                If _Idrve <> _Idmaeedo_Liga Then

                    Dim _Aceptado As Boolean
                    Dim _TidoNudo As String = "RELACIONADO A " & _Fm.Pro_Row_Documento_Seleccionado.Item("TIDO") & "-" &
                                              _Fm.Pro_Row_Documento_Seleccionado.Item("NUDO")

                    _Aceptado = InputBox_Bk(Me, "", "Nueva anotación/evento simple", _TidoNudo,
                                            False, _Tipo_Mayus_Minus.Normal, 50, True, _Tipo_Imagen.Texto)

                    If _Aceptado Then

                        Dim _HoraGrab = Hora_Grab_fx(False)

                        Dim _TidoNudo_Origen As String = _Sql.Fx_Trae_Dato("MAEEDO", "TIDO+'-'+NUDO", "IDMAEEDO = " & _Idrve)

                        Consulta_sql = "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC," &
                                       "FECHAREF,HORAGRAB) VALUES " & vbCrLf &
                                       "('" & _Archive & "'," & _Idrve & ",'MAEEDO'," & _Idmaeedo_Liga & ",'" & FUNCIONARIO &
                                       "','" & Format(FechaDelServidor, "yyyyMMdd") & "','ENLACE','EXTERNO','" & _TidoNudo & "',GetDate()," & _HoraGrab & ")" & vbCrLf &
                                       "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC," &
                                       "FECHAREF,HORAGRAB) VALUES " & vbCrLf &
                                       "('" & _Archive & "'," & _Idmaeedo_Liga & ",'MAEEDO'," & _Idrve & ",'" & FUNCIONARIO &
                                       "','" & Format(FechaDelServidor, "yyyyMMdd") & "','ENLACE','EXTERNO','LIGADO A DOCUMENTO " & _TidoNudo_Origen & "',GetDate()," & _HoraGrab & ")"


                        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                            Sb_Actualizar_Grilla_Anotaciones_Eventos()

                            Beep()
                            ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.save,
                                                   1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                        End If

                    End If

                Else
                    MessageBoxEx.Show(Me, "NO SE PUEDE LIGAR EL MISMO DOCUMENTO", "VALIDACION",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            End If

            _Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Editar_Anotacion_Evento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar_Anotacion_Evento.Click

        If Fx_Tiene_Permiso(Me, "Doc00005") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            If Fx_Se_Puede_Editar_La_Linea(_Fila) Then

                Dim _Idevento As Integer = _Fila.Cells("IDEVENTO").Value
                Dim _Anotacion As String = Replace(Trim(_Fila.Cells("NOKOCARAC").Value), "(*) ", "")
                Dim _Aceptado As Boolean

                _Aceptado = InputBox_Bk(Me, "", "Modificar evento", _Anotacion,
                                        True, _Tipo_Mayus_Minus.Normal, 200, True, _Tipo_Imagen.Texto)

                If _Aceptado Then

                    Dim _Idrse As Integer = _Fila.Cells("IDRSE").Value
                    Dim _Archirse As String = Trim(_Fila.Cells("ARCHIRSE").Value)

                    If _Archirse = _Archive And CBool(_Idrse) Then

                        Consulta_sql = "Update MEVENTO Set NOKOCARAC = '" & Trim(_Anotacion) & "' Where IDEVENTO = " & _Idevento
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                    End If

                    _Fila.Cells("NOKOCARAC").Value = _Anotacion

                    Beep()
                    ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.save,
                                           1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                End If

            End If

        End If

    End Sub

    Private Sub Btn_Eliminar_tabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar_tabla.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Idevento As Integer = _Fila.Cells("IDEVENTO").Value
        Dim _Anotacion As String = _Fila.Cells("NOKOCARAC").Value

        Dim _Idrve As Integer = _Fila.Cells("IDRVE").Value
        Dim _Archirse As String = Trim(_Fila.Cells("ARCHIRSE").Value)
        Dim _Idrse As Integer = _Fila.Cells("IDRSE").Value

        Dim _Insertar As Boolean

        If _Archirse = "MAEEDO" And CBool(_Idrse) Then

            If Convert.ToBoolean(_Idrve) Then
                _Insertar = Fx_Tiene_Permiso(Me, "Doc00009")
            Else
                _Insertar = True
            End If

            If _Insertar Then

                If Fx_Se_Puede_Editar_La_Linea(_Fila) Then

                    If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar esta anotación?" & vbCrLf & vbCrLf &
                                         "Esta acción desligara ambos documentos", "Eliminar anotación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        Dim _Idvento_Ligado As Integer = _Sql.Fx_Trae_Dato("MEVENTO", "IDEVENTO",
                                                                   "IDRVE = " & _Idrse & " And IDRSE = " & _Idrve, True)

                        Consulta_sql = "Delete MEVENTO Where IDEVENTO = " & _Idevento & vbCrLf &
                                       "Delete MEVENTO Where IDEVENTO = " & _Idvento_Ligado

                        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                            Beep()
                            ToastNotification.Show(Me, "ANOTACION ELIMINADA CORRECTAMENTE", My.Resources.cross,
                                                   1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                            Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                        End If

                    End If

                End If

            End If

        Else

            If Convert.ToBoolean(_Idrve) Then
                _Insertar = Fx_Tiene_Permiso(Me, "Doc00004")
            Else
                _Insertar = True
            End If

            If _Insertar Then

                If Fx_Se_Puede_Editar_La_Linea(_Fila) Then

                    If MessageBoxEx.Show(Me, "¿Esta seguro de eliminar esta anotación?", "Eliminar anotación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        If Convert.ToBoolean(_Idrve) Then

                            Consulta_sql = "Delete MEVENTO Where IDEVENTO = " & _Idevento

                            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                                Beep()
                                ToastNotification.Show(Me, "ANOTACION ELIMINADA CORRECTAMENTE", My.Resources.cross,
                                                       1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                                Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)

                            End If

                        Else

                            Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)

                        End If

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub Sb_Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Sb_Revisar_Menu_Contextual()

                End If
            End With

        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Sb_Revisar_Menu_Contextual()
    End Sub

    Sub Sb_Revisar_Menu_Contextual()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Link As String = Trim(_Fila.Cells("LINK").Value)

        Dim _Archise As String = Trim(_Fila.Cells("ARCHIRSE").Value)
        Dim _Idrse As Integer = _Fila.Cells("IDRSE").Value

        If String.IsNullOrEmpty(_Link) Then

            Btn_Opciones_Link.Visible = False

            If _Archise = "MAEEDO" Then
                Dim _TidoNudo As String = _Sql.Fx_Trae_Dato("MAEEDO", "TIDO+'-'+NUDO", "IDMAEEDO = " & _Idrse)
                Btn_Ver_Documento.Text = "Ver documento (ligado a traza externa) " & _TidoNudo
                Btn_Ver_Documento.Visible = True
            Else
                Btn_Ver_Documento.Visible = False
            End If

        Else

            Btn_Ver_Documento.Visible = False
            Btn_Opciones_Link.Visible = True
            Btn_Opciones_Link.Text = _Link

        End If

        ShowContextMenu(Menu_Contextual_01)

    End Sub

    Private Sub Btn_Exportar_a_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_a_Excel.Click

        Consulta_sql = "SELECT IDEVENTO,ARCHIRVE,IDRVE,KOFU," & _
                       "Isnull((Select top 1 NOKOFU From TABFU Tf Where Tf.KOFU = Mv.KOFU),'') As 'Funcionario'," & _
                       "FEVENTO,HORAGRAB,Convert(nvarchar, convert(datetime, (HORAGRAB*1.0/3600)/24), 108) As Hora,FECHAREF," & _
                       "KOTABLA,KOCARAC,NOKOCARAC,ARCHIRSE,IDRSE,LINK,KOFUDEST" & vbCrLf & _
                       "FROM MEVENTO Mv" & vbCrLf & _
                       "WHERE ARCHIRVE='" & _Archive & "' AND IDRVE= " & _Idrve & vbCrLf & _
                       "ORDER BY FEVENTO,HORAGRAB"

        Dim _TblAsociaciones As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        ExportarTabla_JetExcel_Tabla(_TblAsociaciones, Me, "Eventos del documento")

    End Sub

    Private Sub Btn_Agregar_Anotacion_Link_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Nombre_Archivo As String
        Dim _UbicArchivo As String

        Dim _Insertar As Boolean

        If Convert.ToBoolean(_Idrve) Then
            _Insertar = Fx_Tiene_Permiso(Me, "Doc00001")
        Else
            _Insertar = True
        End If

        If _Insertar Then

            Dim _OpenFileDialog As New OpenFileDialog

            With _OpenFileDialog
                '.Filter = "Ficheros DBF (PFMDSP10.dbf)|PFMDSP10.dbf|Todos (*.*)|*.*"
                .Filter = "Ficheros (*.*)|*.*"
                'Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
                .FileName = String.Empty
                '.ShowDialog(Me)

                If .ShowDialog(Me) = DialogResult.OK Then

                    _Nombre_Archivo = .SafeFileName
                    _UbicArchivo = .FileName
                    Dim _Aceptado As Boolean

                    _Aceptado = InputBox_Bk(Me, _UbicArchivo,
                                                         "Nueva anotación/evento simple", _Nombre_Archivo,
                                                         False, _Tipo_Mayus_Minus.Normal, 45, True, _Tipo_Imagen.Texto)

                    Dim _HoraGrab = Hora_Grab_fx(False)

                    If _Aceptado Then

                        If Convert.ToBoolean(_Idrve) Then

                            Consulta_sql = "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC," &
                                                                   "FECHAREF,HORAGRAB,LINK) VALUES " & vbCrLf &
                                                                   "('" & _Archive & "'," & _Idrve & ",'',0,'" & FUNCIONARIO &
                                                                   "','" & Format(FechaDelServidor, "yyyyMMdd") &
                                                                   "','','','" & _Nombre_Archivo & "',GetDate()," & _HoraGrab & ",'" & _UbicArchivo & "')"


                            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                                Sb_Actualizar_Grilla_Anotaciones_Eventos()

                                Beep()
                                ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.save,
                                                       1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                            End If

                        Else

                            Fx_Row_Nueva_Linea(0, _Archive, 0, FUNCIONARIO, _Fevento, "", "", _Nombre_Archivo, "", 0, _Fevento, _UbicArchivo, "", _HoraGrab)

                        End If

                    End If

                End If

            End With

        End If

    End Sub

    Private Sub Btn_Ver_Link_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Link.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Link As String = Trim(_Fila.Cells("LINK").Value)

        Try
            Dim psi As New ProcessStartInfo()
            psi.UseShellExecute = True
            psi.FileName = _Link
            Process.Start(psi)
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message)
        End Try

    End Sub

    Private Sub Btn_Ir_Ubicacion_Link_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ir_Ubicacion_Link.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Link As String = Trim(_Fila.Cells("LINK").Value)

        Dim _Directorio As String = IO.Path.GetDirectoryName(_Link)

        If System.IO.Directory.Exists(_Directorio) Then
            Try
                Process.Start("explorer.exe", _Directorio)
            Catch ex As Exception
                MessageBoxEx.Show(Me, ex.Message)
            End Try
        Else
            MessageBoxEx.Show(Me, "No existe el directorio: " & _Directorio, "Validación", MessageBoxButtons.OK,
                              MessageBoxIcon.Stop)
        End If

    End Sub


    Private Sub Btn_Ligar_traza_externa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Fx_Tiene_Permiso(Me, "Doc00008") Then

            Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)
            _Fm.Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos, "")
            _Fm.Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Todos
            _Fm.ShowDialog(Me)

            If Not (_Fm.Pro_Row_Documento_Seleccionado Is Nothing) Then

                Dim _Idmaeedo_Liga As Integer = _Fm.Pro_Row_Documento_Seleccionado.Item("IDMAEEDO")


                Dim _Tido_Liga As String = _Fm.Pro_Row_Documento_Seleccionado.Item("TIDO")
                Dim _Nudo_Liga As String = _Fm.Pro_Row_Documento_Seleccionado.Item("NUDO")

                Dim _Reg As Boolean = CBool(_Sql.Fx_Trae_Dato("MEVENTO", "IDEVENTO",
                                                               "IDRVE = " & _Idrve & " And IDRSE = " & _Idmaeedo_Liga, True))

                If _Reg Then
                    MessageBoxEx.Show(Me, "DOCUMENTO " & _Tido_Liga & "-" & _Nudo_Liga & " YA ESTA LIGADO.",
                                      "VALIDACION",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                If _Idrve <> _Idmaeedo_Liga Then

                    Dim _Aceptado As Boolean
                    Dim _TidoNudo As String = "RELACIONADO A " & _Fm.Pro_Row_Documento_Seleccionado.Item("TIDO") & "-" &
                                              _Fm.Pro_Row_Documento_Seleccionado.Item("NUDO")

                    _Aceptado = InputBox_Bk(Me, "", "Nueva anotación/evento simple", _TidoNudo,
                                            False, _Tipo_Mayus_Minus.Normal, 50, True, _Tipo_Imagen.Texto)

                    If _Aceptado Then

                        Dim _HoraGrab = Hora_Grab_fx(False)

                        Dim _TidoNudo_Origen As String = _Sql.Fx_Trae_Dato("MAEEDO", "TIDO+'-'+NUDO", "IDMAEEDO = " & _Idrve)

                        Consulta_sql = "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC," &
                                       "FECHAREF,HORAGRAB) VALUES " & vbCrLf &
                                       "('" & _Archive & "'," & _Idrve & ",'MAEEDO'," & _Idmaeedo_Liga & ",'" & FUNCIONARIO &
                                       "','" & Format(FechaDelServidor, "yyyyMMdd") & "','ENLACE','EXTERNO','" & _TidoNudo & "',GetDate()," & _HoraGrab & ")" & vbCrLf &
                                       "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC," &
                                       "FECHAREF,HORAGRAB) VALUES " & vbCrLf &
                                       "('" & _Archive & "'," & _Idmaeedo_Liga & ",'MAEEDO'," & _Idrve & ",'" & FUNCIONARIO &
                                       "','" & Format(FechaDelServidor, "yyyyMMdd") & "','ENLACE','EXTERNO','LIGADO A DOCUMENTO " & _TidoNudo_Origen & "',GetDate()," & _HoraGrab & ")"


                        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                            Sb_Actualizar_Grilla_Anotaciones_Eventos()

                            Beep()
                            ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.save,
                                                   1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                        End If

                    End If

                Else
                    MessageBoxEx.Show(Me, "NO SE PUEDE LIGAR EL MISMO DOCUMENTO", "VALIDACION",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            End If

            _Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Ver_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Documento.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Link As String = Trim(_Fila.Cells("LINK").Value)

        Dim _Archise As String = _Fila.Cells("ARCHIRSE").Value
        Dim _Idrse As String = _Fila.Cells("IDRSE").Value

        Dim Fm As New Frm_Ver_Documento(_Idrse, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Function Fx_Se_Puede_Editar_La_Linea(ByVal _Fila As DataGridViewRow) As Boolean

        Dim _Kofu As String = _Fila.Cells("KOFU").Value

        If FUNCIONARIO = _Kofu Then
            Return True
        Else

            If MessageBoxEx.Show(Me, "Evento solo puede ser editado o eliminado por el autor o el administrador del sistema Bakapp" & vbCrLf &
                                 "¿Desea ingresar la clave de administrador?", "Validación",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

                Dim _Autorizado As Boolean

                Dim Fm_Pass As New Frm_Clave_Administrador
                Fm_Pass.ShowDialog(Me)
                _Autorizado = Fm_Pass.Pro_Autorizado
                Fm_Pass.Dispose()

                Return _Autorizado

            End If

        End If

    End Function


    Function Fx_Row_Nueva_Linea(_Idevento As Integer,
                               _Archirve As String,
                               _Idrve As Integer,
                               _Kofu As String,
                               _Fevento As DateTime,
                               _Kotabla As String,
                               _Kocarac As String,
                               _Nokocarac As String,
                               _Archirse As String,
                               _Idrse As Integer,
                               _Fecharef As Date,
                               _Link As String,
                               _Kofudest As String,
                               _HoraGrab As Integer) As DataRow

        Dim NewFila As DataRow
        NewFila = _Tbl_Mevento.NewRow
        With NewFila

            .Item("IDEVENTO") = _Tbl_Mevento.Rows.Count + 1
            .Item("ARCHIRVE") = _Archirve
            .Item("IDRVE") = _Idrve
            .Item("KOFU") = _Kofu
            .Item("FEVENTO") = FormatDateTime(_Fevento, DateFormat.ShortDate)
            .Item("Hora2") = _Fevento
            .Item("KOTABLA") = _Kotabla
            .Item("KOCARAC") = _Kocarac
            .Item("NOKOCARAC") = _Nokocarac

            .Item("ARCHIRSE") = _Archirse
            .Item("IDRSE") = _Idrse
            .Item("HORAGRAB") = _HoraGrab
            .Item("FECHAREF") = _Fecharef
            .Item("LINK") = _Link
            .Item("HORAGRAB") = _HoraGrab
            '.Item("KOFUDEST") = _Kofudest

            _Tbl_Mevento.Rows.Add(NewFila)

        End With

        Return NewFila

    End Function

    Private Sub Btn_Agregar_Anotacion_Simple_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Anotacion_Simple.Click
        Sb_Agregar_Anotacion_Simple()
    End Sub

    Private Sub Btn_Agregar_Anotacion_Tabulada_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Anotacion_Tabulada.Click
        Sb_Agregar_Anotacion_Tabulada()
    End Sub

    Private Sub Btn_Agregar_Anotacion_Link_Click_1(sender As Object, e As EventArgs) Handles Btn_Agregar_Anotacion_Link.Click
        Sb_Agregar_Anotacion_Link()
    End Sub

    Private Sub Btn_Ligar_traza_externa_Click_1(sender As Object, e As EventArgs) Handles Btn_Ligar_traza_externa.Click
        Sb_Agregar_Anotacion_Ligar_traza_externa()
    End Sub

    Private Sub Btn_Agregar_Anotacion_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Anotacion.Click
        ShowContextMenu(Menu_Contextual_02)
    End Sub

    Private Sub Btn_Ver_Anotacion_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Anotacion.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Anotacion As String = Replace(Trim(_Fila.Cells("NOKOCARAC").Value), "(*) ", "")
        Dim _Kofu As String = _Fila.Cells("KOFU").Value

        _Kofu = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _Kofu & "'")

        MessageBoxEx.Show(Me, _Anotacion, "Anotación usuario: " & _Kofu.Trim, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

End Class
