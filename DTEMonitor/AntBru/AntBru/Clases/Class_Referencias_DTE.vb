Imports DevComponents.DotNetBar

Public Class Class_Referencias_DTE

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Idmaeedo As Integer
    Dim _Tbl_Referencias As DataTable

    Public Property Idmaeedo As Integer
        Get
            Return _Idmaeedo
        End Get
        Set(value As Integer)
            _Idmaeedo = value
        End Set
    End Property

    Public Property Tbl_Referencias As DataTable
        Get
            Return _Tbl_Referencias
        End Get
        Set(value As DataTable)
            _Tbl_Referencias = value
        End Set
    End Property

    Public Sub New(Idmaeedo As Integer)

        _Idmaeedo = Idmaeedo
        Sb_Llenar_Referencias()

    End Sub

    Sub Sb_Llenar_Referencias()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Referencias_Dte Where Id_Doc = " & _Idmaeedo
        _Tbl_Referencias = _Sql.Fx_Get_DataTable(Consulta_sql)
        _Tbl_Referencias.TableName = "Referencias_DTE"

    End Sub

    Function Fx_Row_Nueva_Referencia(_Id_Ref As Integer,
                                     _Id_Doc As Integer,
                                     _Tido As String,
                                     _Nudo As String,
                                     _NroLinRef As Integer,
                                     _TpoDocRef As String,
                                     _FolioRef As String,
                                     _RUTOt As String,
                                     _IdAdicOtr As String,
                                     _FchRef As Date,
                                     _CodRef As Integer,
                                     _RazonRef As String) As DataRow

        Dim NewFila As DataRow
        NewFila = _Tbl_Referencias.NewRow
        With NewFila

            .Item("Id_Ref") = _Id_Ref
            .Item("Id_Doc") = _Id_Doc
            .Item("Tido") = _Tido
            .Item("Nudo") = _Nudo
            .Item("NroLinRef") = _NroLinRef
            .Item("TpoDocRef") = _TpoDocRef
            .Item("FolioRef") = _FolioRef
            .Item("RUTOt") = _RUTOt
            .Item("IdAdicOtr") = _IdAdicOtr
            .Item("FchRef") = _FchRef
            .Item("CodRef") = _CodRef
            .Item("RazonRef") = _RazonRef

            _Tbl_Referencias.Rows.Add(NewFila)

        End With

        Return NewFila

    End Function


    'Function Fx_Incorporar_Tipo_NC(_Formulario As Form) As DataRow

    '    Dim _Sql_Filtro_Condicion_Extra = "And Tabla = 'CODREF_SII_NCV'  --And Equiv_Kotabla = 'SET-FE'"

    '    Dim _Filtrar As New Clas_Filtros_Random(_Formulario)
    '    Dim _Codigo As String
    '    Dim _Nombre As String

    '    _Filtrar.Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
    '    _Filtrar.Campo = "CodigoTabla"
    '    _Filtrar.Descripcion = "NombreTabla"

    '    If _Filtrar.Fx_Filtrar(Nothing,
    '                           Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Sql_Filtro_Condicion_Extra,
    '                           Nothing, False, True) Then

    '        Dim _Tbl_Operacion As DataTable = _Filtrar.Pro_Tbl_Filtro

    '        Dim _Row As DataRow = _Tbl_Operacion.Rows(0)

    '        _Codigo = Trim(_Row.Item("Codigo"))
    '        _Nombre = Trim(_Row.Item("Descripcion"))

    '        Return _Row

    '    End If

    'End Function

    Sub Sb_Eliminar_Referencias_NCV(ByRef _Tbl_Mevento_Edo As DataTable)

        Dim _IndicesRowsEliminar As New List(Of Integer)
        Dim _Index = 0

        For Each _Fl As DataRow In _Tbl_Mevento_Edo.Rows

            Dim _Kotabla = _Fl.Item("KOTABLA")

            If _Kotabla = "SET-FE" Then
                _IndicesRowsEliminar.Add(_Index)
            End If

            _Index += 1

        Next

        For Each _Id As Integer In _IndicesRowsEliminar
            _Tbl_Mevento_Edo.Rows.RemoveAt(_Id)
        Next

        _IndicesRowsEliminar.Clear()
        _Index = 0

        For Each _Fl As DataRow In Tbl_Referencias.Rows

            Dim _CodRef = _Fl.Item("CodRef")

            If _CodRef = 1 Or _CodRef = 2 Or _CodRef = 3 Then
                _IndicesRowsEliminar.Add(_Index)
            End If

            _Index += 1

        Next

        For Each _Id As Integer In _IndicesRowsEliminar
            Tbl_Referencias.Rows.RemoveAt(_Id)
        Next

    End Sub

    Sub Sb_Eliminar_Todas_Las_Referencias()

        Dim _IndicesRowsEliminar As New List(Of Integer)
        Dim _Index = 0

        For Each _Fl As DataRow In Tbl_Referencias.Rows

            _IndicesRowsEliminar.Add(_Index)
            _Index += 1

        Next

        For Each _Id As Integer In _IndicesRowsEliminar
            Tbl_Referencias.Rows.RemoveAt(_Id)
        Next

    End Sub

    'Function Fx_Insertar_Referencias_NCV_FDV(_Formulario As Form,
    '                                         _TblDetalle As DataTable,
    '                                         ByRef _Tbl_Mevento_Edo As DataTable,
    '                                         _RowEntidad As DataRow) As Boolean

    '    Dim _Idmaeddo_Dori As Integer

    '    Sb_Eliminar_Referencias_NCV(_Tbl_Mevento_Edo)

    '    Dim _Row_Mevento As DataRow = Fx_Incorporar_Tipo_NC(_Formulario)

    '    Dim _Fecha = FechaDelServidor()

    '    If Not IsNothing(_Row_Mevento) Then

    '        For Each _Fl As DataRow In _TblDetalle.Rows

    '            Dim _Estado As DataRowState = _Fl.RowState

    '            If Not _Estado = DataRowState.Deleted Then

    '                Dim _CodigoTabla = _Row_Mevento.Item("Codigo")
    '                Dim _NombreTabla = _Row_Mevento.Item("Descripcion").ToString.Trim

    '                Dim _Tidopa = _Fl.Item("Tidopa")
    '                Dim _Idrse = _Fl.Item("Idmaeedo_Dori")

    '                _Idmaeddo_Dori = _Fl.Item("Idmaeddo_Dori")

    '                If Not Convert.ToBoolean(_Idmaeddo_Dori) Then

    '                    MessageBoxEx.Show(_Formulario, "Debe seleccionar documento de referencia", "Validación",
    '                                      MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '                    Dim _Fmr As New Frm_BusquedaDocumento_Filtro(False)

    '                    With _Fmr

    '                        .Pro_Sql_Filtro_Otro_Filtro = "And Edo.NUDONODEFI = 0"
    '                        .Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado
    '                        .Rdb_Tipo_Documento_Uno.Checked = True
    '                        .Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, "FCV", "Where TIDO In ('FCV','BLV')")
    '                        .Rdb_Estado_Vigente.Checked = True

    '                        .Rdb_Estado_Todos.Checked = True
    '                        .Grupo_Funcionario.Enabled = True
    '                        .Grupo_Producto.Enabled = False
    '                        .Rdb_Fecha_Emision_Cualquiera.Checked = True
    '                        .Pro_Row_Entidad = _RowEntidad
    '                        .Rdb_Entidad_Una.Checked = True

    '                        .ShowDialog(_Formulario)

    '                        If Not (_Fmr.Pro_Row_Documento_Seleccionado Is Nothing) Then
    '                            _Idmaeddo_Dori = _Fmr.Pro_Row_Documento_Seleccionado.Item("IDMAEEDO")
    '                            _Tidopa = _Fmr.Pro_Row_Documento_Seleccionado.Item("TIDO")
    '                            _Idrse = _Idmaeddo_Dori
    '                        End If

    '                        _Fmr.Dispose()

    '                    End With

    '                End If

    '                If Convert.ToBoolean(_Idmaeddo_Dori) Then

    '                    Dim _InsertarRegistro = True

    '                    If _Tidopa = "GRD" Then

    '                        Dim _Idrst = _Sql.Fx_Trae_Dato("MAEDDO", "IDRST", "IDMAEDDO = " & _Idmaeddo_Dori)

    '                        _Idrse = _Sql.Fx_Trae_Dato("MAEDDO", "IDMAEEDO", "IDMAEDDO = " & _Idrst, True)
    '                        _Tidopa = _Sql.Fx_Trae_Dato("MAEEDO", "TIDO", "IDMAEEDO = " & _Idrse, False)

    '                        _InsertarRegistro = CBool(_Idrse)

    '                    End If

    '                    If CBool(_Tbl_Mevento_Edo.Rows.Count) Then
    '                        For Each _FlMv As DataRow In _Tbl_Mevento_Edo.Rows
    '                            If _FlMv.Item("ARCHIRSE") = "MAEEDO" And _FlMv.Item("IDRSE") = _Idrse Then
    '                                _InsertarRegistro = False
    '                                Exit For
    '                            End If
    '                        Next
    '                    End If

    '                    If _InsertarRegistro Then

    '                        Consulta_sql = "Select Isnull(KOTABLA,'??') As KOTABLA,Isnull(KOCARAC,'??') As KOCARAC,Isnull(NOKOCARAC,'??') As NOKOCARAC,Z1.* 
    '                                From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Z1
    '                                Left Join TABCARAC 
    '                                On Equiv_Kotabla = KOTABLA And Equiv_Kocarac = KOCARAC
    '                                Where Tabla = 'CODREF_SII_NCV' And CodigoTabla = '" & _CodigoTabla & "'"

    '                        Dim _Row_RefCarac As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

    '                        Dim _Kotabla = Trim(_Row_RefCarac.Item("KOTABLA")) '"SET-FE"
    '                        Dim _Kocarac = Trim(_Row_RefCarac.Item("KOCARAC"))
    '                        Dim _Nokocarac = Trim(_Row_RefCarac.Item("NOKOCARAC"))

    '                        Consulta_sql = "Select TIDO,NUDO,FEEMDO From MAEEDO Where IDMAEEDO = " & _Idrse
    '                        Dim _FlRef As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

    '                        Dim _Nudopa = String.Empty
    '                        Dim _NroLinRef = Tbl_Referencias.Rows.Count + 1
    '                        Dim _TpoDocRef = Fx_Tipo_DTE_VS_TIDO(_FlRef.Item("TIDO"))
    '                        Dim _FolioRef = Convert.ToInt32(_FlRef.Item("NUDO"))
    '                        Dim _RUTOt = String.Empty
    '                        Dim _IdAdicOtr = String.Empty
    '                        Dim _FchRef = _FlRef.Item("FEEMDO")
    '                        Dim _CodRef = Val(_CodigoTabla)
    '                        Dim _RazonRef = _NombreTabla

    '                        Fx_Row_Nueva_Referencia(0, 0, "", _Nudopa,
    '                                                     _NroLinRef, _TpoDocRef, _FolioRef, _RUTOt, _IdAdicOtr, _FchRef, _CodRef, _RazonRef)

    '                        Fx_Row_Nueva_Linea_Mevento(0, "MAEEDO", 0, FUNCIONARIO, _Fecha, _Kotabla, _Kocarac, _Nokocarac,
    '                                               "MAEEDO", _Idrse, _Fecha, "", "", _Tbl_Mevento_Edo)

    '                    End If

    '                End If

    '            End If

    '        Next

    '    Else

    '        MessageBoxEx.Show(_Formulario, "Debe incorporar el motivo por el cual esta generando la nota de crédito", "Validación",
    '                      MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, _Formulario.TopMost)

    '    End If

    '    Return Convert.ToBoolean(_Idmaeddo_Dori)

    'End Function

    Function Fx_Insertar_Referencias_Para_Facturas_FCV(_Formulario As Form,
                                                       _TblDetalle As DataTable) As Boolean

        'Dim _Idmaeddo_Dori As Integer

        'Sb_Eliminar_Referencias_NCV(_Tbl_Mevento_Edo)

        'Dim _Row_Mevento As DataRow = Fx_Incorporar_Tipo_NC(_Formulario)

        Dim _Fecha = FechaDelServidor()

        'If Not IsNothing(_Row_Mevento) Then

        For Each _Fl As DataRow In _TblDetalle.Rows

            Dim _Estado As DataRowState = _Fl.RowState

            If Not _Estado = DataRowState.Deleted Then

                Dim _Tidopa = _Fl.Item("Tidopa")
                Dim _Idrse = _Fl.Item("Idmaeedo_Dori")

                '_Idmaeddo_Dori = _Fl.Item("Idmaeddo_Dori")

                If Convert.ToBoolean(_Idrse) Then

                    'If _Tidopa = "GRD" Or _Tidopa = "GDV" Then

                    '    Dim _Idrst = _Sql.Fx_Trae_Dato("MAEDDO", "IDRST", "IDMAEDDO = " & _Idmaeddo_Dori)
                    '    _Idrse = _Sql.Fx_Trae_Dato("MAEDDO", "IDMAEEDO", "IDMAEDDO = " & _Idrst)

                    '    _Tidopa = _Sql.Fx_Trae_Dato("MAEEDO", "TIDO", "IDMAEEDO = " & _Idrse)

                    'End If

                    Consulta_sql = "Select TIDO,NUDO,FEEMDO From MAEEDO Where IDMAEEDO = " & _Idrse
                    Dim _FlRef As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Dim _Nudopa = String.Empty
                    Dim _NroLinRef = Tbl_Referencias.Rows.Count + 1
                    Dim _TpoDocRef = Fx_Tipo_DTE_VS_TIDO(_FlRef.Item("TIDO"))
                    Dim _FolioRef = Convert.ToInt32(_FlRef.Item("NUDO"))
                    Dim _RUTOt = String.Empty
                    Dim _IdAdicOtr = String.Empty
                    Dim _FchRef = _FlRef.Item("FEEMDO")
                    'Dim _CodRef = _CodigoTabla
                    'Dim _RazonRef = _NombreTabla

                    Fx_Row_Nueva_Referencia(0, 0, "", _Nudopa,
                                                     _NroLinRef, _TpoDocRef, _FolioRef, _RUTOt, _IdAdicOtr, _FchRef, "", "")

                    'Fx_Row_Nueva_Linea_Mevento(0, "MAEEDO", 0, FUNCIONARIO, _Fecha, _Kotabla, _Kocarac, _Nokocarac,
                    '                           "MAEEDO", _Idrse, _Fecha, "", "", _Tbl_Mevento_Edo)

                End If

            End If

        Next

        'Else

        '    MessageBoxEx.Show(_Formulario, "Debe incorporar el motivo por el cual esta generando la nota de crédito", "Validación",
        '                  MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, _Formulario.TopMost)

        'End If

        Return True 'Convert.ToBoolean(_Idmaeddo_Dori)

    End Function

    Private Function Fx_Row_Nueva_Linea_Mevento(_Idevento As Integer,
                                                _Archirve As String,
                                                _Idrve As Integer,
                                                _Kofu As String,
                                                _Fevento As Date,
                                                _Kotabla As String,
                                                _Kocarac As String,
                                                _Nokocarac As String,
                                                _Archirse As String,
                                                _Idrse As Integer,
                                                _Fecharef As Date,
                                                _Link As String,
                                                _Kofudest As String,
                                                ByRef _Tbl_Mevento As DataTable) As DataRow

        Dim NewFila As DataRow
        NewFila = _Tbl_Mevento.NewRow
        With NewFila

            .Item("IDEVENTO") = _Tbl_Mevento.Rows.Count + 1
            .Item("ARCHIRVE") = _Archirve
            .Item("IDRVE") = _Idrve
            .Item("KOFU") = _Kofu
            .Item("FEVENTO") = FormatDateTime(_Fevento, DateFormat.ShortDate)
            .Item("KOTABLA") = _Kotabla
            .Item("KOCARAC") = _Kocarac
            .Item("NOKOCARAC") = _Nokocarac

            .Item("ARCHIRSE") = _Archirse
            .Item("IDRSE") = _Idrse
            .Item("HORAGRAB") = 0
            .Item("FECHAREF") = _Fecharef
            .Item("LINK") = _Link
            '.Item("KOFUDEST") = _Kofudest

            _Tbl_Mevento.Rows.Add(NewFila)

        End With

        Return NewFila

    End Function

End Class
