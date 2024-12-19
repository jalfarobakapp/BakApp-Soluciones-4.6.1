Public Class Cl_ListaMayoristaMinorista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Private _MesesVenListaPrecios As Integer
    Public Sub New()

        _MesesVenListaPrecios = _Global_Row_Configuracion_General.Item("MesesVenListaPrecios")

    End Sub

    Sub Sb_LlenarCorreosNuevosMayoristas()

        Dim _Fecha As Date = FechaDelServidor()
        Dim _PrimerDiaMes As Date = DateSerial(Year(_Fecha), Month(_Fecha), 1)
        Dim _UltimoDiaMes As Date = DateSerial(Year(_Fecha), Month(_Fecha) + 1, 0)

        _PrimerDiaMes = Primerdiadelmes(_Fecha)
        _UltimoDiaMes = ultimodiadelmes(_Fecha)

        Consulta_Sql = "Select Distinct KOEN,SUEN,NOKOEN,LCEN,SUBSTRING(LVEN,6,3) As LVEN,Lista As ListaSuperior,Lp.*" & vbCrLf &
                       "From MAEEDO" & vbCrLf &
                       "Inner Join MAEEN On KOEN = ENDO And SUEN = SUENDO" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_ListaPreGlobal Lp On Lp.ListaInferior = SUBSTRING(LVEN,6,3)" & vbCrLf &
                       "Where TIDO = 'FCV' And FEEMDO Between '" & Format(_PrimerDiaMes, "yyyyMMdd") & "' And '" & Format(_UltimoDiaMes, "yyyyMMdd") & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Dim _Lista As New List(Of NewDatosEntidad)

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _CodEntidad = _Fila.Item("KOEN")
            Dim _CodSucEntidad = _Fila.Item("SUEN")
            Dim _ListaSuperior = _Fila.Item("ListaSuperior")

            Dim _Msj As LsValiciones.Mensajes

            _Msj = Fx_RevisarSiCumpleConTenerListaSuperior(_CodEntidad, _ListaSuperior)

            If _Msj.EsCorrecto Then

                Dim _CodHolding As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Entidades", "CodHolding", "CodEntidad = '" & _CodEntidad & "'")
                Dim _FiltroEntidades As String

                If String.IsNullOrWhiteSpace(_CodHolding) Then
                    _FiltroEntidades = "('" & _CodEntidad & "')"
                Else
                    Consulta_Sql = "Select CodEntidad From " & _Global_BaseBk & "Zw_Entidades Where CodHolding = '" & _CodHolding & "'"
                    Dim _TblHolding As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)
                    _FiltroEntidades = Generar_Filtro_IN(_TblHolding, "", "CodEntidad", False, False, "'")
                End If

                Dim _NewDatosEntidad As New NewDatosEntidad

                _NewDatosEntidad.CodEntidad = _CodEntidad
                _NewDatosEntidad.CodSucEntidad = _CodSucEntidad
                _NewDatosEntidad.Old_Lista = _Fila.Item("LVEN")
                _NewDatosEntidad.New_Lista = _ListaSuperior
                _NewDatosEntidad.Para = _Sql.Fx_Trae_Dato("MAEEN", "EMAIL", "KOEN = '" & _CodEntidad & "' And SUEN = '" & _CodSucEntidad & "'")

                _Lista.Add(_NewDatosEntidad)

            End If

        Next

        Dim _ListaCorreos As New List(Of LsValiciones.Mensajes)

        For Each _Msj As NewDatosEntidad In _Lista

            Dim _Para As String = _Msj.Para
            Dim _Cc As String = _Msj.Cc
            Dim _CodEntidad As String = _Msj.CodEntidad
            Dim _CodSucEntidad As String = _Msj.CodSucEntidad

            '_Para = "jalfaro@bakapp.cl"

            Dim _CorreoMsj As LsValiciones.Mensajes = Fx_EnviarCorreosMayoristaMinorista(_CodEntidad, _CodSucEntidad, 2, _Para, _Msj.Cc)

            _ListaCorreos.Add(_CorreoMsj)

            If _CorreoMsj.EsCorrecto Then

            End If

        Next


    End Sub

    Function Fx_EnviarCorreosMayoristaMinorista(_CodEntidad As String, _CodSucEntidad As String, _Id_Correo As Integer, _Para As String, _Cc As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes


        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Correos Where Id = " & _Id_Correo
        Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If IsNothing(_Row_Correo) Then
            Throw New System.Exception("No existe configuración para el envio de correos")
        End If

        Dim _Nombre_Correo As String = _Row_Correo.Item("Nombre_Correo")
        Dim _Asunto As String = _Row_Correo.Item("Asunto")
        Dim _CuerpoMensaje As String = _Row_Correo.Item("CuerpoMensaje")

        If String.IsNullOrEmpty(_Asunto) Then
            _Asunto = "Correo de notificación de pedido " & RazonEmpresa
        End If

        _CuerpoMensaje = Replace(_CuerpoMensaje, "&lt;", "<")
        _CuerpoMensaje = Replace(_CuerpoMensaje, "&gt;", ">")
        _CuerpoMensaje = Replace(_CuerpoMensaje, "&quot;", """")

        _CuerpoMensaje = Replace(_CuerpoMensaje, "'", "''")

        If Not String.IsNullOrEmpty(_Nombre_Correo) Then

            Dim _Fecha = "Getdate()"
            Dim _Adjuntar_Documento As Boolean = False

            'If _Enviar_al_otro_dia Then
            '    _Fecha = "DATEADD(D,1,Getdate())"
            'End If

            Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (Id_Correo,Nombre_Correo,CodFuncionario,Asunto," &
                            "Para,Cc,Idmaeedo,Tido,Nudo,NombreFormato,Enviar,Mensaje,Fecha,Adjuntar_Documento,Doc_Adjuntos,Adjuntar_DTE,Id_Dte,Id_Trackid,CodEntidad,CodSucEntidad)" &
                            vbCrLf &
                            "Values (" & _Id_Correo & ",'" & _Nombre_Correo & "','','" & _Asunto & "','" & _Para & "','" & _Cc &
                            "',0,'','','',1,'" & _CuerpoMensaje & "'," & _Fecha & "," & Convert.ToInt32(_Adjuntar_Documento) & ",'',0,0,0,'" & _CodEntidad & "','" & _CodSucEntidad & "')"

            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

        End If

        Return _Mensaje

    End Function

    Function Fx_RevisarSiCumpleConTenerListaSuperior(_Endo As String, _ListaSuperior As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            _Mensaje = Fx_Llenar_ListaBk(_ListaSuperior)

            If Not _Mensaje.EsCorrecto Then
                _Mensaje.Detalle = "No cumple con la condición para tener una lista superior"
                _Mensaje.Mensaje = "No se encontro el registro en la tabla Zw_ListaPreGlobal con la Lista = '" & _ListaSuperior & "'"
                Return _Mensaje
            End If

            Dim _PreMayMinXHolding As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Entidades", "PreMayMinXHolding", "CodEntidad = '" & _Endo & "'",,,, True)
            Dim _CodHolding As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Entidades", "CodHolding", "CodEntidad = '" & _Endo & "'")
            Dim _FiltroEntidades As String

            If Not _PreMayMinXHolding Then
                _CodHolding = String.Empty
            End If

            If String.IsNullOrWhiteSpace(_CodHolding) Then
                _FiltroEntidades = "('" & _Endo & "')"
            Else
                Consulta_Sql = "Select CodEntidad From " & _Global_BaseBk & "Zw_Entidades Where CodHolding = '" & _CodHolding & "'"
                Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)
                _FiltroEntidades = Generar_Filtro_IN(_Tbl, "", "CodEntidad", False, False, "'")
            End If

            Dim _VentaMinVencLP As Double = _Mensaje.Tag.VentaMinVencLP

            Consulta_Sql = My.Resources.Recuros_ListaSuperior.RevisarSumpliminetoDeMinoristaMayorista
            Consulta_Sql = Replace(Consulta_Sql, "{VentaMinima}", _VentaMinVencLP)
            Consulta_Sql = Replace(Consulta_Sql, "{Endo}", _Endo)
            Consulta_Sql = Replace(Consulta_Sql, "#FiltroEntidades#", _FiltroEntidades)
            Consulta_Sql = Replace(Consulta_Sql, "{Meses}", _MesesVenListaPrecios)
            Consulta_Sql = Replace(Consulta_Sql, "{VentaEnCurso}", 0)
            Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql)

            If Not CBool(_Ds.Tables(3).Rows.Count) Then
                _Mensaje.EsCorrecto = False
                _Mensaje.Mensaje = "No cumple con la condición para tener una lista superior"
                _Mensaje.Icono = MessageBoxIcon.Stop
                Return _Mensaje
            End If

            Dim _Row As DataRow = _Ds.Tables(3).Rows(0)

            If _Row.Item("Cumple") Then
                _Mensaje.EsCorrecto = True
                _Mensaje.Mensaje = "Cliente cumple con la condición para mantenerse en la lista superior"
                _Mensaje.Icono = MessageBoxIcon.Information
            Else
                _Mensaje.EsCorrecto = False
                _Mensaje.Mensaje = "No cumple con la condición para tener una lista superior"
                _Mensaje.Icono = MessageBoxIcon.Stop
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

    Function Fx_Llenar_ListaBk(_Lista As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_ListaPreGlobal Where Lista = '" & _Lista & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If IsNothing(_Row) Then

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "No se encontro el registro en la tabla Zw_ListaPreGlobal con la Lista = '" & _Lista & "'"

            Return _Mensaje

        End If

        Dim Zw_ListaActCliente As New Zw_ListaPreGlobal

        With Zw_ListaActCliente

            .Tipo = _Row.Item("Tipo")
            .Moneda = _Row.Item("Moneda")
            .Permiso = _Row.Item("Permiso")
            .Lista = _Row.Item("Lista")
            .Nombre_Lista = _Row.Item("Nombre_Lista")
            .FormulaPrecio = _Row.Item("FormulaPrecio")
            .Redondear = _Row.Item("Redondear")
            .FormulaGrabarRD = _Row.Item("FormulaGrabarRD")
            .ListaCostoxDefecto = _Row.Item("ListaCostoxDefecto")
            .TipoValor = _Row.Item("TipoValor")
            .ValoresNetos = _Row.Item("ValoresNetos")
            .Margen_Ud1 = _Row.Item("Margen_Ud1")
            .Margen_Ud2 = _Row.Item("Margen_Ud2")
            .FormulaPrecio2 = _Row.Item("FormulaPrecio2")
            .Ej_Fx_documento = _Row.Item("Ej_Fx_documento")
            .Ej_Fx_documento2 = _Row.Item("Ej_Fx_documento2")
            .DsctoMax = _Row.Item("DsctoMax")
            .Flete = _Row.Item("Flete")
            .ListaSuperior = _Row.Item("ListaSuperior")
            .ListaInferior = _Row.Item("ListaInferior")
            .VentaMinVencLP = _Row.Item("VentaMinVencLP")

        End With

        _Mensaje.EsCorrecto = True
        _Mensaje.Mensaje = "Registro encontrado."
        _Mensaje.Tag = Zw_ListaActCliente

        Return _Mensaje

    End Function

End Class

Class NewDatosEntidad
    Public Property CodEntidad As String
    Public Property CodSucEntidad As String
    Public Property Old_Lista As String
    Public Property New_Lista As String
    Public Property Para As String
    Public Property Cc As String
End Class
