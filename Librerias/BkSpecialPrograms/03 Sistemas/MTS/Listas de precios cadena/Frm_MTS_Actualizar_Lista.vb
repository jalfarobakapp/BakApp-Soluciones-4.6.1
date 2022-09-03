'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Data.SqlClient

Public Class Frm_MTS_Actualizar_Lista

    Dim Datos_MTS As New Ds_MTS
    Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\MTS\Datos_MTS.xml"
    Dim _Proxima
    Dim _Directorio As String
    Dim _TablaDBF As String
    Dim _Cod_Lista As String
    Dim _Nom_Lista As String
    Dim _Guardar_Con_Dscto_Inc As Boolean
    Dim _Ejecutar As Boolean

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresa & "\MTS") Then
            System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresa & "\MTS")
        End If

        Datos_MTS.Clear()
        Dim exists = System.IO.File.Exists(_Path)

        If Not exists Then

            Dim NewFila As DataRow
            NewFila = Datos_MTS.Tables("Archivos_dbf").NewRow

            With NewFila
                .Item("Directorio_Ruta") = String.Empty
                .Item("Archivo_Dsctos") = String.Empty
            End With

            Datos_MTS.Tables("Archivos_dbf").Rows.Add(NewFila)

            Datos_MTS.WriteXml(_Path)
            'MessageBoxEx.Show("Arvhico XML creado correctamente", "Crear XML de Conexión", _
            '                  MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            Datos_MTS.ReadXml(_Path)
        End If


    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        '_MTS_Lista_activo = False
        Me.Close()
    End Sub

    Private Sub BtnActualizarInformacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizarInformacion.Click

        Switch_Activar.Value = False

        Dim Fm As New Frm_MTS_Actualizar_Lista_Parametros
        Fm.ShowDialog(Me)

        If Fm._Grabar Then

            Datos_MTS.Clear()
            Datos_MTS.ReadXml(_Path)

            _TablaDBF = Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Archivo_Dsctos")
            _Directorio = Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Directorio_Ruta")
            _Cod_Lista = Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Cod_Lista")
            _Nom_Lista = Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Nom_Lista")
            _Guardar_Con_Dscto_Inc = Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Guardar_Con_Dscto_Inc")

        End If
        Chk_GuardarConDsctos.Checked = _Guardar_Con_Dscto_Inc
        Switch_Activar.Value = True

    End Sub

    Private Sub Tiempo_Accion_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo_Accion.Tick

        Dim Hora_Actual = Format(Date.Now, "HH:mm:ss")

        For Each _Filas As DataRow In Datos_MTS.Tables("Conf_Ejecucion").Rows

            Dim _Nombre_Proceso As String = _Filas.Item("Accion")
            Dim _Hora = _Filas.Item("Hora_Ejecucion")
            Dim _Hora_tbl = Format(_Hora, "HH:mm:ss")

            If _Hora_tbl = Hora_Actual Then _Ejecutar = True

            If _Ejecutar Then
                TxtLog_.Text = String.Empty

                Sb_AddToLog("Iniciando proceso: " & _Nombre_Proceso, _
                "Hora de acción: [" & Date.Now.ToLongTimeString & "]", TxtLog_)

                Dim f_, f_2 As Date
                f_ = Now.Date
                f_2 = Now.Date

                Sb_Ejecutar_Proceso(_Hora, _
                                    _Nombre_Proceso, _
                                    _Directorio, _
                                    _TablaDBF, _
                                    _Cod_Lista, _
                                    _Nom_Lista, _
                                    TxtLog_, _
                                    Barra_Progreso, _
                                    Tiempo_Accion, _
                                    f_, _
                                    f_2)

                _Ejecutar = False
            End If

        Next


    End Sub

    Private Sub Switch_Activar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Switch_Activar.ValueChanged

        Circlar_Prog_Monitoreo.Visible = Switch_Activar.Value
        Circlar_Prog_Monitoreo.IsRunning = Switch_Activar.Value
        Tiempo_Accion.Enabled = Switch_Activar.Value

    End Sub

    Private Sub Tiempo_Hora_Actual_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo_Hora_Actual.Tick
        Me.Text = "Actualización lista MTS, Hora actual: " & Date.Now.ToLongTimeString

    End Sub

    Sub Sb_Enable_Botones(ByVal _Habilita As Boolean)
        If _Habilita Then
            BtnCancelar.Enabled = False
            BtnActualizarInformacion.Enabled = True
            BtnSalir.Enabled = True
            BtnEjecutarManualmente.Enabled = True
            Switch_Activar.Enabled = True
        Else
            BtnCancelar.Enabled = True
            BtnActualizarInformacion.Enabled = False
            BtnSalir.Enabled = False
            BtnEjecutarManualmente.Enabled = False
            Switch_Activar.Enabled = False
        End If
    End Sub

    Sub Sb_Ejecutar_Proceso(ByVal _Hora_Ejecucion As String, _
                            ByVal _Nombre_Proceso As String, _
                            ByVal _Directorio As String, _
                            ByVal _TablaDBF As String, _
                            ByVal _CodLista As String, _
                            ByVal _NomLista As String, _
                            ByVal _TxtLog As Object, _
                            ByVal _Bar As Object, _
                            ByVal Tiempo_Accion As Object, _
                            ByVal _Fecha_Desde As Date, _
                            ByVal _Fecha_Hasta As Date)

        _Cancelar_Proceso = False

        Sb_Enable_Botones(False)



        Tiempo_Accion.Enabled = False

        Dim _F_Fecha_Desde As String = Format(_Fecha_Desde, "dd-MM-yyyy")
        Dim _F_Fecha_Hasta As String = Format(_Fecha_Hasta, "dd-MM-yyyy")

        'Sb_AddToLog("Iniciando proceso: " & _Nombre_Proceso, _
        '            "Hora de acción: [" & Date.Now.ToLongTimeString & "]", _TxtLog)

        If Fx_LlenarTablaDeFamiliasDeConDescuentos(Barra_Progreso, LblEtiqueta, _TxtLog, _Directorio, _TablaDBF, Me) Then

            Dim Tbl_Proveedores As DataTable = Fx_Revisar_Cambios_Precios_MTS(_Directorio, _
                                                                              _TxtLog, _
                                                                              _F_Fecha_Desde, _
                                                                              _F_Fecha_Hasta)


            If (Tbl_Proveedores Is Nothing) Then

                Sb_AddToLog("Actualizando lista de proveedores, Lista " & _CodLista & "," & _Nom_Lista, _
                           "Proveedores encontrados: 0 [" & Date.Now.ToLongTimeString & "]", _TxtLog)

            Else

                Sb_AddToLog("Actualizando lista de proveedores, Lista " & _CodLista & "," & _Nom_Lista, _
                           "Proveedores encontrados: " & Tbl_Proveedores.Rows.Count & " [" & Date.Now.ToLongTimeString & "]", _TxtLog)

                Dim _CtaProveedores = 1
                For Each _Fila As DataRow In Tbl_Proveedores.Rows
                    Dim _Proveedor As String = _Fila.Item("Proveedor")
                    Dim _Fecha_Act = FechaDelServidor() '_Fila.Item("Fecha")

                    Fx_Actualizar_Lista_Por_Proveedor(_Bar, TxtLog_, _
                                                      LblEtiqueta, _
                                                      _Directorio, _
                                                      _Proveedor, _
                                                      "", _
                                                      _CodLista, _
                                                      _CtaProveedores, _
                                                      Tbl_Proveedores.Rows.Count, _
                                                      _Fecha_Act, _
                                                      _Guardar_Con_Dscto_Inc)

                    If _Cancelar_Proceso Then

                        Sb_AddToLog("Proceso cancelado por el usuario: " & _Nombre_Proceso, _
                      "Hora de termino: [" & Date.Now.ToLongTimeString & "]", _TxtLog)
                        Exit For
                    End If
                    _CtaProveedores += 1
                Next

            End If

            If Not _Cancelar_Proceso Then
                Sb_AddToLog("Proceso terminado: " & _Nombre_Proceso, _
                           "Hora de termino: [" & Date.Now.ToLongTimeString & "]", _TxtLog)
            End If

        End If
        ' _Cancelar_Proceso = False
        Sb_Enable_Botones(True)
        Tiempo_Accion.Enabled = True


    End Sub

    Sub Sb_Ejecutar_Proceso_Proveedor _
                           (ByVal _Proveedor As String, _
                            ByVal _Hora_Ejecucion As String, _
                            ByVal _Nombre_Proceso As String, _
                            ByVal _CodLista As String, _
                            ByVal _NomLista As String, _
                            ByVal _TxtLog As Object, _
                            ByVal _Bar As Object, _
                            ByVal Tiempo_Accion As Object)

        _Cancelar_Proceso = False

        Sb_Enable_Botones(False)



        Tiempo_Accion.Enabled = False

        'Sb_AddToLog("Iniciando proceso: " & _Nombre_Proceso, _
        '            "Hora de acción: [" & Date.Now.ToLongTimeString & "]", _TxtLog)
        Sb_AddToLog("Actualizando lista de proveedores, Lista " & _CodLista & "," & _Nom_Lista, _
                      "Proceso manual solo un proveedor [" & Date.Now.ToLongTimeString & "]", _TxtLog)

        Dim _CtaProveedores = 1
        Dim _Fecha_Act = Now.Date

        Fx_Actualizar_Lista_Por_Proveedor(_Bar, TxtLog_, _
                                          LblEtiqueta, _
                                          _Directorio, _
                                          _Proveedor, _
                                          "", _
                                          _CodLista, _
                                          _CtaProveedores, _
                                          1, _
                                          _Fecha_Act, _
                                          _Guardar_Con_Dscto_Inc)

        If _Cancelar_Proceso Then

            Sb_AddToLog("Proceso cancelado por el usuario: " & _Nombre_Proceso, _
            "Hora de termino: [" & Date.Now.ToLongTimeString & "]", _TxtLog)

        End If

        If Not _Cancelar_Proceso Then
            Sb_AddToLog("Proceso terminado: " & _Nombre_Proceso, _
                       "Hora de termino: [" & Date.Now.ToLongTimeString & "]", _TxtLog)
        End If

        ' _Cancelar_Proceso = False
        Sb_Enable_Botones(True)
        Tiempo_Accion.Enabled = True


    End Sub

    Private Sub Frm_MTS_Actualizar_Lista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _TablaDBF = Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Archivo_Dsctos")
        _Directorio = Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Directorio_Ruta")

        _Cod_Lista = Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Cod_Lista")
        _Nom_Lista = Datos_MTS.Tables("Archivos_dbf").Rows(0).Item("Nom_Lista")

        Chk_GuardarConDsctos.Checked = _Guardar_Con_Dscto_Inc

        _Ejecutar = False

        'Switch_Activar.Value = True
    End Sub

    Private Sub BtnEjecutarManualmente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEjecutarManualmente.Click

        Dim Fm As New Frm_MTS_Actualizar_Lista_Proceso_Manual
        Fm.Fecha_desde.Value = Now
        Fm.Fecha_hasta.Value = Now
        Fm.TxtRutaArchivosDBF.Text = _Directorio
        Fm.TxtArchivoDescuentos.Text = _TablaDBF
        Fm.TxtCodLista.Text = _Cod_Lista
        Fm.TxtNomLista.Text = _Nom_Lista
        Fm.Chk_GuardarConDsctos.Checked = _Guardar_Con_Dscto_Inc
        Fm.ShowDialog(Me)



        If Fm._Ejecutar Then


            TxtLog_.Text = String.Empty
            Dim Hora_Actual = Format(Date.Now, "HH:mm:ss")

            Sb_AddToLog("Iniciando proceso: Ejecución manual", _
              "Hora de acción: [" & Date.Now.ToLongTimeString & "]", TxtLog_)

            If Fm.Chk_Proveedor.Checked Then

                Sb_Ejecutar_Proceso_Proveedor(Fm._CodProveedor, _
                                              Hora_Actual, _
                                              "Ejecución manual", _
                                              _Cod_Lista, _
                                              _Nom_Lista, _
                                              TxtLog_, _
                                              Barra_Progreso, _
                                              Tiempo_Accion)

            Else
                Sb_Ejecutar_Proceso(Hora_Actual, _
                                    "Ejecución manual", _
                                    Fm.TxtRutaArchivosDBF.Text, _
                                    Fm.TxtArchivoDescuentos.Text, _
                                    Fm.TxtCodLista.Text, _
                                    Fm.TxtNomLista.Text, _
                                    TxtLog_, _
                                    Barra_Progreso, _
                                    Tiempo_Accion, _
                                    Fm.Fecha_desde.Value, _
                                    Fm.Fecha_hasta.Value)
            End If
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If MessageBoxEx.Show("¿Esta seguro de querer cancelar el proceso?", _
                                                     "Cancelar proceso", MessageBoxButtons.YesNo, _
                                                     MessageBoxIcon.Question) = DialogResult.Yes Then

            MessageBoxEx.Show(Me, "Proceso cancelado por el usuario", _
                              "Cancelar proceso", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            _Cancelar_Proceso = True

        End If

    End Sub

    Private Sub BtnMinimizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMinimizar.Click
        Me.Hide()
        NotifyIcon1.Visible = True
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        NotifyIcon1.Visible = False
        Me.Show()
    End Sub
End Class