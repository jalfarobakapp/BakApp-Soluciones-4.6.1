

Public Class Clas_Estructura_Base_De_Datos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_Informe As DataTable
    Dim _Tbl_Tablas As DataTable

    Dim _Base_Corresponde_a_Version As Boolean


    Public Sub New()

        Consulta_Sql = "Select Cast('' As Varchar(30)) As Tabla,
                               Cast('' As Varchar(30)) As Campo,
                               Cast('' As Varchar(30)) As Descripcion,
                               Cast('' As Text) As Accion,
                               Cast('' As Bit) As Reparado
                               Where 1<0"
        _Tbl_Informe = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Consulta_Sql = "Select Cast('' As Varchar(100)) As Tabla,Cast('' As Text) As Estructura,Cast(0 As bit) as Con_Problema Where 1<0"
        _Tbl_Tablas = _Sql.Fx_Get_DataTable(Consulta_Sql)

    End Sub

    Public Property Pro_Tbl_Informe As DataTable
        Get
            Return _Tbl_Informe
        End Get
        Set(value As DataTable)
            _Tbl_Informe = value
        End Set
    End Property

    Public Property Pro_Base_Corresponde_a_Version As Boolean
        Get

            For Each _Fila As DataRow In _Tbl_Tablas.Rows
                Dim _Con_Problema As Boolean
                _Con_Problema = _Fila.Item("Con_Problema")
                If _Con_Problema Then
                    Return False
                End If
            Next

            Return True
        End Get
        Set(value As Boolean)
            _Base_Corresponde_a_Version = value
        End Set
    End Property

    Sub Sb_Revisar_Tabla(_Formulario As Form,
                         _Tabla As String,
                         _Modificar As Boolean,
                         Optional ByRef _Label1 As Object = Nothing,
                         Optional ByRef _Label2 As Object = Nothing)

        Dim _Base = Replace(_Global_BaseBk, ".dbo.", "")
        _Base = Replace(_Base, "[", "")
        _Base = Replace(_Base, "]", "")

        Consulta_Sql = "USE [" & _Base & "]" & vbCrLf &
                       "Select TABLE_NAME From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = '" & _Tabla & "'"

        Dim _TblTablasSis As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Dim _R1 As DataRow

        If Not IsNothing(_Label1) Then
            _Label1.text = "Revisando tabla: " & _Tabla
        End If

        Dim _Row_Tabla_Actual As DataRow
        _Row_Tabla_Actual = Fx_Buscar_Tabla_En_Tablas(Trim(_Tabla))

        If Not IsNothing(_Row_Tabla_Actual) Then
            If _Row_Tabla_Actual.Item("Con_Problema") = False Then
                Return
            Else
                _Row_Tabla_Actual.Item("Con_Problema") = False
            End If
        Else
            _Row_Tabla_Actual = Fx_Nueva_Tabla(Trim(_Tabla), False)
        End If

        Consulta_Sql = Fx_Trae_Estructura_Tabla(_Tabla)
        Consulta_Sql = Replace(Consulta_Sql, "#Base#", _Base)
        Consulta_Sql = Replace(Consulta_Sql, UCase("#Base#"), _Base)

        _Row_Tabla_Actual.Item("Estructura") = Consulta_Sql

        If CBool(_TblTablasSis.Rows.Count) Then

            'Creo una tabla en la base de datos con la nueva estructura

            Dim _Nombre_Tabla_Paso As String = "TblPaso_Rev"

            Consulta_Sql = "Drop Table " & _Global_BaseBk & _Nombre_Tabla_Paso
            _Sql.Ej_consulta_IDU(Consulta_Sql, False)

            Consulta_Sql = Fx_Trae_Estructura_Tabla(_Tabla)
            Consulta_Sql = Replace(Consulta_Sql, _Tabla, _Nombre_Tabla_Paso)
            Consulta_Sql = Replace(Consulta_Sql, "#Base#", _Base)
            Consulta_Sql = Replace(Consulta_Sql, UCase("#Base#"), _Base)

            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                Consulta_Sql = "USE [" & _Base & "]" & vbCrLf & "
                            SELECT TABLE_NAME AS TABLA,
                            COLUMN_NAME AS Campo,
                            DATA_TYPE AS Tipo_De_Campo,
                            CHARACTER_OCTET_LENGTH AS Valor_Maximo,
                            COLUMN_DEFAULT AS Valor_Por_Defecto,
                            IS_NULLABLE AS Acepta_Nulos,
                            ORDINAL_POSITION AS Posicion
             
                            FROM INFORMATION_SCHEMA.COLUMNS
                            Where TABLE_NAME = '" & _Nombre_Tabla_Paso & "'
                            ORDER BY TABLE_NAME,ORDINAL_POSITION"

                Dim _Tbl_Campos_Originales As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)


                For Each _Fila_Campo As DataRow In _Tbl_Campos_Originales.Rows

                    Dim _Campo As String = _Fila_Campo.Item("Campo")
                    Dim _Tipo_De_Campo As String = _Fila_Campo.Item("Tipo_De_Campo")
                    Dim _Valor_Maximo As String = NuloPorNro(_Fila_Campo.Item("Valor_Maximo"), "Nulo")
                    Dim _Valor_Por_Defecto As String = NuloPorNro(_Fila_Campo.Item("Valor_Por_Defecto"), "Nulo")
                    Dim _Acepta_Nulos As String = _Fila_Campo.Item("Acepta_Nulos")
                    Dim _Posicion As Integer = _Fila_Campo.Item("Posicion")

                    If Not IsNothing(_Label1) Then
                        _Label1.text = "Revisando tabla: " & _Tabla & ", Campo: " & _Campo
                    End If

                    Application.DoEvents()

                    Consulta_Sql = "USE [" & _Base & "]" & vbCrLf & "
                                    SELECT TABLE_NAME AS TABLA,
                                    COLUMN_NAME AS Campo,
                                    DATA_TYPE AS Tipo_De_Campo,
                                    CHARACTER_OCTET_LENGTH AS Valor_Maximo,
                                    COLUMN_DEFAULT AS Valor_Por_Defecto,
                                    IS_NULLABLE AS Acepta_Nulos,
                                    ORDINAL_POSITION AS Posicion
             
                                    FROM INFORMATION_SCHEMA.COLUMNS
                                    Where 
                                    TABLE_NAME = '" & _Tabla & "' And COLUMN_NAME = '" & _Campo & "'
                                    ORDER BY TABLE_NAME,ORDINAL_POSITION"
                    Dim _Fila_Revisa As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    Dim _Problema As String = String.Empty
                    Dim _Insertar_Accion = False

                    If Not IsNothing(_Fila_Revisa) Then

                        Dim _Campo2 As String = _Fila_Revisa.Item("Campo")
                        Dim _Tipo_De_Campo2 As String = _Fila_Revisa.Item("Tipo_De_Campo")
                        Dim _Valor_Maximo2 As String = NuloPorNro(_Fila_Revisa.Item("Valor_Maximo"), "Nulo")
                        Dim _Valor_Por_Defecto2 As String = NuloPorNro(_Fila_Revisa.Item("Valor_Por_Defecto"), "Nulo")
                        Dim _Acepta_Nulos2 As String = _Fila_Revisa.Item("Acepta_Nulos")
                        Dim _Posicion2 As Integer = _Fila_Revisa.Item("Posicion")

                        If _Tipo_De_Campo <> _Tipo_De_Campo2 Then
                            _R1 = Fx_Nueva_Linea(_Tbl_Informe)
                            _R1.Item("Tabla") = _Tabla
                            _R1.Item("Campo") = _Campo
                            _R1.Item("Descripcion") = "Tipo de campo distinto " & _Tipo_De_Campo
                            _Insertar_Accion = True

                            _Row_Tabla_Actual.Item("Con_Problema") = True
                        End If
                        If _Valor_Maximo <> _Valor_Maximo2 Then
                            _R1 = Fx_Nueva_Linea(_Tbl_Informe)
                            _R1.Item("Tabla") = _Tabla
                            _R1.Item("Campo") = _Campo
                            _R1.Item("Descripcion") = "Largo distinto al valor máximo " & _Valor_Maximo

                            Consulta_Sql = Fx_Editar_Campo(_Tabla, _Fila_Campo)
                            If _Modificar Then
                                _Sql.Ej_consulta_IDU(Consulta_Sql)
                                _R1.Item("Accion") = String.Empty
                            Else
                                _R1.Item("Accion") = Consulta_Sql
                                _Row_Tabla_Actual.Item("Con_Problema") = True
                            End If
                        End If
                        If _Valor_Por_Defecto <> _Valor_Por_Defecto2 Then
                            _R1 = Fx_Nueva_Linea(_Tbl_Informe)
                            _R1.Item("Tabla") = _Tabla
                            _R1.Item("Campo") = _Campo
                            _R1.Item("Descripcion") = "Valor por defecto distinto " & _Valor_Por_Defecto

                            Consulta_Sql = "USE [" & _Base & "]" & vbCrLf & "
                                            SELECT *
                                            FROM sys.default_constraints
                                            Where [object_id] = (SELECT default_object_id
                                            FROM sys.columns Where [name] = '" & _Campo & "' And 
                                            [object_id] = (SELECT object_id FROM sys.tables Where [name] = '" & _Tabla & "'))"
                            Dim _Row_Default2 As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                            Consulta_Sql = String.Empty

                            If Not IsNothing(_Row_Default2) Then
                                Dim _Name = _Row_Default2.Item("name")
                                Consulta_Sql = "ALTER TABLE " & _Global_BaseBk & "[" & _Tabla & "] DROP [" & _Name & "]" & vbCrLf
                            End If

                            Consulta_Sql += "ALTER TABLE " & _Global_BaseBk & "[" & _Tabla & "] ADD" & Space(1) &
                                            "CONSTRAINT [DF_" & _Tabla & "_" & _Campo & "]  DEFAULT " & _Valor_Por_Defecto & " FOR [" & _Campo & "]" 'Fx_Editar_Campo(_Tabla, _Fila_Campo)
                            If _Modificar Then
                                _Sql.Ej_consulta_IDU(Consulta_Sql)
                                _R1.Item("Accion") = String.Empty
                            Else
                                _R1.Item("Accion") = Consulta_Sql
                                _Row_Tabla_Actual.Item("Con_Problema") = True
                            End If
                        End If

                        If _Posicion <> _Posicion2 Then
                            _R1 = Fx_Nueva_Linea(_Tbl_Informe)
                            _R1.Item("Tabla") = _Tabla
                            _R1.Item("Campo") = _Campo
                            _R1.Item("Descripcion") = "Campo en orden incorrecto. Posición original = " & _Posicion
                            _Row_Tabla_Actual.Item("Con_Problema") = True
                        End If

                    Else
                        _R1 = Fx_Nueva_Linea(_Tbl_Informe)
                        _R1.Item("Tabla") = _Tabla
                        _R1.Item("Campo") = _Campo
                        _R1.Item("Descripcion") = "Falta el campo (" & _Campo & ")"

                        Consulta_Sql = Fx_Agregar_Campo(_Tabla, _Fila_Campo)

                        If _Modificar Then
                            _Sql.Ej_consulta_IDU(Consulta_Sql)
                            _R1.Item("Accion") = String.Empty
                        Else
                            _R1.Item("Accion") = Consulta_Sql
                            _Row_Tabla_Actual.Item("Con_Problema") = True
                        End If

                    End If

                Next

            End If

            Consulta_Sql = "USE [" & _Base & "]" & vbCrLf & "
                            SELECT TABLE_NAME AS TABLA,
                            COLUMN_NAME AS Campo,
                            DATA_TYPE AS Tipo_De_Campo,
                            CHARACTER_OCTET_LENGTH AS Valor_Maximo,
                            COLUMN_DEFAULT AS Valor_Por_Defecto,
                            IS_NULLABLE AS Acepta_Nulos,
                            ORDINAL_POSITION AS Posicion
             
                            FROM INFORMATION_SCHEMA.COLUMNS
                            Where 
                            TABLE_NAME = '" & _Tabla & "' And 
                                COLUMN_NAME Not in (Select COLUMN_NAME From INFORMATION_SCHEMA.COLUMNS
                                Where TABLE_NAME = '" & _Nombre_Tabla_Paso & "')
                            ORDER BY TABLE_NAME,ORDINAL_POSITION"

            Dim _Tbl_Campos_sobrantes As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

            For Each _Fl As DataRow In _Tbl_Campos_sobrantes.Rows
                Dim _Campo = _Fl.Item("Campo")
                _R1 = Fx_Nueva_Linea(_Tbl_Informe)
                _R1.Item("Tabla") = _Tabla
                _R1.Item("Campo") = _Campo
                _R1.Item("Descripcion") = "Sobra el campo (" & _Campo & ")"
            Next

            Consulta_Sql = "Drop Table " & _Global_BaseBk & _Nombre_Tabla_Paso
            _Sql.Ej_consulta_IDU(Consulta_Sql)

        Else

            _R1 = Fx_Nueva_Linea(_Tbl_Informe)
            _R1.Item("Tabla") = _Tabla
            _R1.Item("Campo") = ""
            _R1.Item("Descripcion") = "Falta la tabla (" & _Tabla & ")"

            Consulta_Sql = Fx_Trae_Estructura_Tabla(_Tabla)
            Consulta_Sql = Replace(Consulta_Sql, "#Base#", _Base)
            Consulta_Sql = Replace(Consulta_Sql, UCase("#Base#"), _Base)

            _Row_Tabla_Actual.Item("Estructura") = Consulta_Sql

            If _Modificar Then
                If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                    Consulta_Sql = String.Empty
                End If
            End If

            _R1.Item("Accion") = Consulta_Sql

        End If

    End Sub

    Sub Sb_Revisar_Tabla2(_Formulario As Form,
                         _Tabla As String,
                         _Modificar As Boolean,
                         Optional ByRef _Label1 As Object = Nothing,
                         Optional ByRef _Label2 As Object = Nothing)

        Dim _Base = Replace(_Global_BaseBk, ".dbo.", "")
        _Base = Replace(_Base, "[", "")
        _Base = Replace(_Base, "]", "")

        Consulta_Sql = "USE [" & _Base & "]" & vbCrLf &
                       "Select TABLE_NAME From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = '" & _Tabla & "'"

        Dim _TblTablasSis As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Dim _R1 As DataRow

        If Not IsNothing(_Label1) Then
            _Label1.text = "Revisando tabla: " & _Tabla
        End If

        Dim _Row_Tabla_Actual As DataRow
        _Row_Tabla_Actual = Fx_Buscar_Tabla_En_Tablas(Trim(_Tabla))

        If Not IsNothing(_Row_Tabla_Actual) Then
            If _Row_Tabla_Actual.Item("Con_Problema") = False Then
                Return
            Else
                _Row_Tabla_Actual.Item("Con_Problema") = False
            End If
        Else
            _Row_Tabla_Actual = Fx_Nueva_Tabla(Trim(_Tabla), False)
        End If

        Consulta_Sql = Fx_Trae_Estructura_Tabla(_Tabla)
        Consulta_Sql = Replace(Consulta_Sql, "#Base#", _Base)
        Consulta_Sql = Replace(Consulta_Sql, UCase("#Base#"), _Base)

        _Row_Tabla_Actual.Item("Estructura") = Consulta_Sql

        If CBool(_TblTablasSis.Rows.Count) Then

            'Creo una tabla en la base de datos con la nueva estructura

            Dim _Nombre_Tabla_Paso As String = "TblPaso_Rev"

            Consulta_Sql = "Drop Table " & _Global_BaseBk & _Nombre_Tabla_Paso
            _Sql.Ej_consulta_IDU(Consulta_Sql, False)

            Consulta_Sql = Fx_Trae_Estructura_Tabla(_Tabla)
            Consulta_Sql = Replace(Consulta_Sql, _Tabla, _Nombre_Tabla_Paso)
            Consulta_Sql = Replace(Consulta_Sql, "#Base#", _Base)
            Consulta_Sql = Replace(Consulta_Sql, UCase("#Base#"), _Base)

            If _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                Consulta_Sql = "USE [" & _Base & "]" & vbCrLf & "
                            SELECT TABLE_NAME AS TABLA,
                            COLUMN_NAME AS Campo,
                            DATA_TYPE AS Tipo_De_Campo,
                            CHARACTER_OCTET_LENGTH AS Valor_Maximo,
                            COLUMN_DEFAULT AS Valor_Por_Defecto,
                            IS_NULLABLE AS Acepta_Nulos,
                            ORDINAL_POSITION AS Posicion
             
                            FROM INFORMATION_SCHEMA.COLUMNS
                            Where TABLE_NAME = '" & _Nombre_Tabla_Paso & "'
                            ORDER BY TABLE_NAME,ORDINAL_POSITION"

                Dim _Tbl_Tabla_Original As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

                Consulta_Sql = "USE [" & _Base & "]" & vbCrLf & "
                                    SELECT TABLE_NAME AS TABLA,
                                    COLUMN_NAME AS Campo,
                                    DATA_TYPE AS Tipo_De_Campo,
                                    CHARACTER_OCTET_LENGTH AS Valor_Maximo,
                                    COLUMN_DEFAULT AS Valor_Por_Defecto,
                                    IS_NULLABLE AS Acepta_Nulos,
                                    ORDINAL_POSITION AS Posicion
             
                                    FROM INFORMATION_SCHEMA.COLUMNS
                                    Where 
                                    TABLE_NAME = '" & _Tabla & "'
                                    ORDER BY TABLE_NAME,ORDINAL_POSITION"

                Dim _Tbl_Tabla_A_Revisar As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)


                For Each _Fila_Campo As DataRow In _Tbl_Tabla_Original.Rows

                    Dim _Campo As String = _Fila_Campo.Item("Campo")
                    Dim _Tipo_De_Campo As String = _Fila_Campo.Item("Tipo_De_Campo")
                    Dim _Valor_Maximo As String = NuloPorNro(_Fila_Campo.Item("Valor_Maximo"), "Nulo")
                    Dim _Valor_Por_Defecto As String = NuloPorNro(_Fila_Campo.Item("Valor_Por_Defecto"), "Nulo")
                    Dim _Acepta_Nulos As String = _Fila_Campo.Item("Acepta_Nulos")
                    Dim _Posicion As Integer = _Fila_Campo.Item("Posicion")

                    If Not IsNothing(_Label1) Then
                        _Label1.text = "Revisando tabla: " & _Tabla & ", Campo: " & _Campo
                    End If

                    Application.DoEvents()


                    Dim _Tbl_Revisa As DataTable = Fx_Crea_Tabla_Con_Filtro(_Tbl_Tabla_A_Revisar, "Campo = '" & _Campo & "'", "Posicion")

                    Dim _Fila_Revisa As DataRow = Nothing

                    If _Tbl_Revisa.Rows.Count Then
                        _Fila_Revisa = _Tbl_Revisa.Rows(0)
                    End If

                    Dim _Problema As String = String.Empty
                    Dim _Insertar_Accion = False

                    If Not IsNothing(_Fila_Revisa) Then

                        Dim _Campo2 As String = _Fila_Revisa.Item("Campo")
                        Dim _Tipo_De_Campo2 As String = _Fila_Revisa.Item("Tipo_De_Campo")
                        Dim _Valor_Maximo2 As String = NuloPorNro(_Fila_Revisa.Item("Valor_Maximo"), "Nulo")
                        Dim _Valor_Por_Defecto2 As String = NuloPorNro(_Fila_Revisa.Item("Valor_Por_Defecto"), "Nulo")
                        Dim _Acepta_Nulos2 As String = _Fila_Revisa.Item("Acepta_Nulos")
                        Dim _Posicion2 As Integer = _Fila_Revisa.Item("Posicion")

                        If _Tipo_De_Campo <> _Tipo_De_Campo2 Then
                            _R1 = Fx_Nueva_Linea(_Tbl_Informe)
                            _R1.Item("Tabla") = _Tabla
                            _R1.Item("Campo") = _Campo
                            _R1.Item("Descripcion") = "Tipo de campo distinto " & _Tipo_De_Campo
                            _Insertar_Accion = True

                            _Row_Tabla_Actual.Item("Con_Problema") = True
                        End If
                        If _Valor_Maximo <> _Valor_Maximo2 Then
                            _R1 = Fx_Nueva_Linea(_Tbl_Informe)
                            _R1.Item("Tabla") = _Tabla
                            _R1.Item("Campo") = _Campo
                            _R1.Item("Descripcion") = "Largo distinto al valor máximo " & _Valor_Maximo

                            Consulta_Sql = Fx_Editar_Campo(_Tabla, _Fila_Campo)
                            If _Modificar Then
                                _Sql.Ej_consulta_IDU(Consulta_Sql)
                                _R1.Item("Accion") = String.Empty
                            Else
                                _R1.Item("Accion") = Consulta_Sql
                                _Row_Tabla_Actual.Item("Con_Problema") = True
                            End If
                        End If
                        If _Valor_Por_Defecto <> _Valor_Por_Defecto2 Then
                            _R1 = Fx_Nueva_Linea(_Tbl_Informe)
                            _R1.Item("Tabla") = _Tabla
                            _R1.Item("Campo") = _Campo
                            _R1.Item("Descripcion") = "Valor por defecto distinto " & _Valor_Por_Defecto

                            Consulta_Sql = "USE [" & _Base & "]" & vbCrLf & "
                                            SELECT *
                                            FROM sys.default_constraints
                                            Where [object_id] = (SELECT default_object_id
                                            FROM sys.columns Where [name] = '" & _Campo & "' And 
                                            [object_id] = (SELECT object_id FROM sys.tables Where [name] = '" & _Tabla & "'))"
                            Dim _Row_Default2 As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                            Consulta_Sql = String.Empty

                            If Not IsNothing(_Row_Default2) Then
                                Dim _Name = _Row_Default2.Item("name")
                                Consulta_Sql = "ALTER TABLE " & _Global_BaseBk & "[" & _Tabla & "] DROP [" & _Name & "]" & vbCrLf
                            End If

                            Consulta_Sql += "ALTER TABLE " & _Global_BaseBk & "[" & _Tabla & "] ADD" & Space(1) &
                                            "CONSTRAINT [DF_" & _Tabla & "_" & _Campo & "]  DEFAULT " & _Valor_Por_Defecto & " FOR [" & _Campo & "]" 'Fx_Editar_Campo(_Tabla, _Fila_Campo)
                            If _Modificar Then
                                _Sql.Ej_consulta_IDU(Consulta_Sql)
                                _R1.Item("Accion") = String.Empty
                            Else
                                _R1.Item("Accion") = Consulta_Sql
                                _Row_Tabla_Actual.Item("Con_Problema") = True
                            End If
                        End If

                        If _Posicion <> _Posicion2 Then
                            _R1 = Fx_Nueva_Linea(_Tbl_Informe)
                            _R1.Item("Tabla") = _Tabla
                            _R1.Item("Campo") = _Campo
                            _R1.Item("Descripcion") = "Campo en orden incorrecto. Posición original = " & _Posicion
                            _Row_Tabla_Actual.Item("Con_Problema") = True
                        End If

                    Else
                        _R1 = Fx_Nueva_Linea(_Tbl_Informe)
                        _R1.Item("Tabla") = _Tabla
                        _R1.Item("Campo") = _Campo
                        _R1.Item("Descripcion") = "Falta el campo (" & _Campo & ")"

                        Consulta_Sql = Fx_Agregar_Campo(_Tabla, _Fila_Campo)

                        If _Modificar Then
                            _Sql.Ej_consulta_IDU(Consulta_Sql)
                            _R1.Item("Accion") = String.Empty
                        Else
                            _R1.Item("Accion") = Consulta_Sql
                            _Row_Tabla_Actual.Item("Con_Problema") = True
                        End If

                    End If

                Next

            End If

            Consulta_Sql = "USE [" & _Base & "]" & vbCrLf & "
                            SELECT TABLE_NAME AS TABLA,
                            COLUMN_NAME AS Campo,
                            DATA_TYPE AS Tipo_De_Campo,
                            CHARACTER_OCTET_LENGTH AS Valor_Maximo,
                            COLUMN_DEFAULT AS Valor_Por_Defecto,
                            IS_NULLABLE AS Acepta_Nulos,
                            ORDINAL_POSITION AS Posicion
             
                            FROM INFORMATION_SCHEMA.COLUMNS
                            Where 
                            TABLE_NAME = '" & _Tabla & "' And 
                                COLUMN_NAME Not in (Select COLUMN_NAME From INFORMATION_SCHEMA.COLUMNS
                                Where TABLE_NAME = '" & _Nombre_Tabla_Paso & "')
                            ORDER BY TABLE_NAME,ORDINAL_POSITION"

            Dim _Tbl_Campos_sobrantes As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

            For Each _Fl As DataRow In _Tbl_Campos_sobrantes.Rows
                Dim _Campo = _Fl.Item("Campo")
                _R1 = Fx_Nueva_Linea(_Tbl_Informe)
                _R1.Item("Tabla") = _Tabla
                _R1.Item("Campo") = _Campo
                _R1.Item("Descripcion") = "Sobra el campo (" & _Campo & ")"
            Next

            Consulta_Sql = "Drop Table " & _Global_BaseBk & _Nombre_Tabla_Paso
            _Sql.Ej_consulta_IDU(Consulta_Sql)

        Else

            _R1 = Fx_Nueva_Linea(_Tbl_Informe)
            _R1.Item("Tabla") = _Tabla
            _R1.Item("Campo") = ""
            _R1.Item("Descripcion") = "Falta la tabla (" & _Tabla & ")"

            Consulta_Sql = Fx_Trae_Estructura_Tabla(_Tabla)
            Consulta_Sql = Replace(Consulta_Sql, "#Base#", _Base)
            Consulta_Sql = Replace(Consulta_Sql, UCase("#Base#"), _Base)

            _Row_Tabla_Actual.Item("Estructura") = Consulta_Sql

            If _Modificar Then
                If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                    Consulta_Sql = String.Empty
                End If
            End If

            _R1.Item("Accion") = Consulta_Sql

        End If

    End Sub

    Function Fx_Buscar_Tabla_En_Tablas(_Tabla As String) As DataRow

        Dim _Row As DataRow

        For Each _Fila As DataRow In _Tbl_Tablas.Rows

            Dim _Tb As String = Trim(_Fila.Item("Tabla"))

            If _Tb = _Tabla Then
                _Row = _Fila
                Exit For
            End If

        Next

        Return _Row

    End Function

    Private Function Fx_Nueva_Linea(ByRef _Tbl As DataTable) As DataRow

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow
        With NewFila

            .Item("Tabla") = ""
            .Item("Campo") = ""
            .Item("Descripcion") = ""

            _Tbl.Rows.Add(NewFila)

        End With

        Return NewFila

    End Function

    Private Function Fx_Trae_Estructura_Tabla(_Tabla As String) As String

        Dim Consulta_Sql As String

        Select Case _Tabla
            Case "Zw_CashDro_Operaciones"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_CashDro_Operaciones
            Case "Zw_CashDro_Transbank_Cierre"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_CashDro_Transbank_Cierre
            Case "Zw_CashDro_Transbank_Log"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_CashDro_Transbank_Log

            Case "Zw_Casi_DocArc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Casi_DocArc
            Case "Zw_Casi_DocDet"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Casi_DocDet
            Case "Zw_Casi_DocDsc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Casi_DocDsc
            Case "Zw_Casi_DocEnc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Casi_DocEnc
            Case "Zw_Casi_DocImp"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Casi_DocImp
            Case "Zw_Casi_DocObs"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Casi_DocObs
            Case "Zw_Casi_DocTom"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Casi_DocTom
            Case "Zw_Casi_DocPer"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Casi_DocPer
            Case "Zw_Casi_DocTag"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Casi_DocTag

            Case "Zw_Chilexpress_Conf"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Chilexpress_Conf
            Case "Zw_Chilexpress_Env"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Chilexpress_Env
            Case "Zw_Chilexpress_Res"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Chilexpress_Res

            Case "Zw_Conceptos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Conceptos

            Case "Zw_Compras_en_SII"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Compras_en_SII
            Case "Zw_Configuracion"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Configuracion
            Case "Zw_Configuracion_Formatos_X_Modalidad"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Configuracion_Formatos_X_Modalidad
            Case "Zw_Correos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Correos
            Case "Zw_CorreosEnvioRecepcion"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_CorreosEnvioRecepcion
            Case "Zw_Configuracion_Formatos_X_Modalidad"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Configuracion_Formatos_X_Modalidad
            Case "Zw_Correos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Correos
            Case "Zw_CorreosEnvioRecepcion"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_CorreosEnvioRecepcion
            Case "Zw_Correos_Cuentas"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Correos_Cuentas
            Case "Zw_CRV_Viajes"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_CRV_Viajes

            Case "Zw_DbExt_Conexion"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_DbExt_Conexion
            Case "Zw_DbExt_Maest"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_DbExt_Maest

            Case "Zw_Docu_Ent"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Docu_Ent

            Case "Zw_Demonio_Archivador"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Demonio_Archivador
            Case "Zw_Demonio_Cof_Estacion"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Demonio_Cof_Estacion
            Case "Zw_Demonio_Doc_Emitidos_Aviso_Correo"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Demonio_Doc_Emitidos_Aviso_Correo
            Case "Zw_Demonio_Doc_Emitidos_Aviso_Correo_Adjuntos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Demonio_Doc_Emitidos_Aviso_Correo_Adjuntos
            Case "Zw_Demonio_Doc_Emitidos_Cola_Impresion"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Demonio_Doc_Emitidos_Cola_Impresion
            Case "Zw_Demonio_Filtros_X_Estacion"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Demonio_Filtros_X_Estacion
            Case "Zw_Demonio_Prestashop"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Demonio_Prestashop
            Case "Zw_Demonio_Wordpress"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Demonio_Wordpress
            Case "Zw_Demonio_FacAuto"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Demonio_FacAuto
            Case "Zw_Demonio_AcpAuto"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Demonio_AcpAuto
            Case "Zw_Demonio_ConfAcpAuto"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Demonio_ConfAcpAuto
            Case "Zw_Demonio_ConfProgramacion"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Demonio_ConfProgramacion
            Case "Zw_Demonio_NVVAuto"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Demonio_NVVAuto
            Case "Zw_Demonio_NVVAutoDet"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Demonio_NVVAutoDet


            Case "Zw_Docu_Archivos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Docu_Archivos
            Case "Zw_Docu_ObligPg"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Docu_ObligPg


            Case "Zw_Docu_Ent"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Docu_Ent
            Case "Zw_Docu_Det"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Docu_Det


            Case "Zw_DTE_Aec"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_DTE_Aec
            Case "Zw_DTE_Caf"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_DTE_Caf
            Case "Zw_DTE_Configuracion"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_DTE_Configuracion
            Case "Zw_DTE_Documentos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_DTE_Documentos
            Case "Zw_DTE_NotifxCorreo"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_DTE_NotifxCorreo
            Case "Zw_DTE_Trackid"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_DTE_Trackid
            Case "Zw_DTE_Firmar"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_DTE_Firmar
            Case "Zw_DTE_ReccEnc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_DTE_ReccEnc
            Case "Zw_DTE_ReccDet"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_DTE_ReccDet
            Case "Zw_DTE_ListaEventosDoc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_DTE_ListaEventosDoc

            Case "Zw_Empresas"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Empresas

            Case "Zw_Entidades"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Entidades
            Case "Zw_Entidad_Cia_Seguros"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Entidad_Cia_Seguros
            Case "Zw_Entidades_ProdExcluidos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Entidades_ProdExcluidos
            Case "Zw_Entidades_ProdMinCompra"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Entidades_ProdMinCompra

            Case "Zw_Estaciones_Poswi"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Estaciones_Poswi
            Case "Zw_Estaciones_CashDro"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Estaciones_CashDro
            Case "Zw_EstacionesBkp"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_EstacionesBkp
            Case "Zw_EstacionesBkp_Configuracion_Local"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_EstacionesBkp_Configuracion_Local
            Case "Zw_Estaciones_Impresoras"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Estaciones_Impresoras
            Case "Zw_Estaciones_Ruta_PDF"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Estaciones_Ruta_PDF

            Case "Zw_Fincred_Config"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Fincred_Config
            Case "Zw_Fincred_Documentos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Fincred_Documentos
            Case "Zw_Fincred_TramaRespuesta"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Fincred_TramaRespuesta

            Case "Zw_Format_01"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Format_01
            Case "Zw_Format_02"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Format_02
            Case "Zw_Format_Fx"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Format_Fx
            Case "Zw_Format_Pag"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Format_Pag
            Case "Zw_Fuentes_Conf"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Fuentes_Conf
            Case "Zw_Ftp_Conexiones"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Ftp_Conexiones

            Case "Zw_Inv_Contador"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Inv_Contador
            Case "Zw_Inv_FotoInventario"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Inv_FotoInventario
            Case "Zw_Inv_Hoja"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Inv_Hoja
            Case "Zw_Inv_HojaEli"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Inv_HojaEli
            Case "Zw_Inv_HojaEli_Detalle"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Inv_HojaEli_Detalle
            Case "Zw_Inv_Hoja_Detalle"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Inv_Hoja_Detalle
            Case "Zw_Inv_Inventario"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Inv_Inventario
            Case "Zw_Inv_Sector"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Inv_Sector


            Case "Zw_Licencia"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Licencia
            Case "Zw_Licencia_Mod"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Licencia_Mod
            Case "Zw_Linea_Oferta"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Linea_Oferta

            Case "Zw_ListaPreCosto"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_ListaPreCosto
            Case "Zw_ListaPreCosto_Enc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_ListaPreCosto_Enc
            Case "Zw_ListaPreGlobal"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_ListaPreGlobal
            Case "Zw_ListaPreProducto"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_ListaPreProducto
            Case "Zw_ListaPreHistorico"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_ListaPreHistorico

            Case "Zw_ListaLC_Programadas"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_ListaLC_Programadas
            Case "Zw_ListaLC_Programadas_Detalles"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_ListaLC_Programadas_Detalles

            Case "Zw_Log_Gestiones"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Log_Gestiones

            Case "Zw_Lotes_Enc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Lotes_Enc
            Case "Zw_Lotes_Det"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Lotes_Det

            Case "Zw_MrVsPro"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_MrVsPro
            Case "Zw_Negocios_01_Enc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Negocios_01_Enc
            Case "Zw_Negocios_02_Det"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Negocios_02_Det
            Case "Zw_Negocios_02_Fun"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Negocios_02_Fun
            Case "Zw_Negocios_03_Apr"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Negocios_03_Apr
            Case "Zw_Negocios_04_Doc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Negocios_04_Doc
            Case "Zw_Notificaciones"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Notificaciones
            Case "Zw_Pago_Prov_Autoriza_01_Enc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Pago_Prov_Autoriza_01_Enc
            Case "Zw_Pago_Prov_Autoriza_02_Det"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Pago_Prov_Autoriza_02_Det
            Case "Zw_Pago_Prov_Autoriza_02_Det_Eli"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Pago_Prov_Autoriza_02_Det_Eli
            Case "Zw_Patentes_rvm"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Patentes_rvm
            Case "Zw_Pdc_Mesones"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Pdc_Mesones
            Case "Zw_Pdc_MesonVsMaquina"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Pdc_MesonVsMaquina
            Case "Zw_Pdc_MesonVsOperario"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Pdc_MesonVsOperario
            Case "Zw_Pdp_CPT_Tarja"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Pdp_CPT_Tarja
            Case "Zw_Pdp_CPT_Tarja_Det"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Pdp_CPT_Tarja_Det
            Case "Zw_Pdp_MaquinaVsProductos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Pdp_MaquinaVsProductos
            Case "Zw_Pdp_MesonVsProductos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Pdp_MesonVsProductos
            Case "Zw_Pdp_MesonVsProductos_Repro"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Pdp_MesonVsProductos_Repro
            Case "Zw_Pdp_OT_Prioridad"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Pdp_OT_Prioridad
            Case "Zw_Pdp_MesonVsAlertas"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Pdp_MesonVsAlertas
            Case "Zw_Pdp_MesonVsAlertas_Lectura"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Pdp_MesonVsAlertas_Lectura
            Case "Zw_Pdp_MesonVsEnvioRecibe"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Pdp_MesonVsEnvioRecibe

            Case "ZW_Permisos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.ZW_Permisos
            Case "ZW_PermisosADM"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.ZW_PermisosADM
            Case "ZW_PermisosVsUsuarios"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.ZW_PermisosVsUsuarios
            Case "Zw_Picking"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Picking
            Case "Zw_Picking_Doc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Picking_Doc
            Case "Zw_PrestaShop"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_PrestaShop
            Case "Zw_Prod_Archivos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_Archivos
            Case "Zw_Prod_Asociacion"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_Asociacion
            Case "Zw_Prod_Asociacion_Respaldo"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_Asociacion_Respaldo
            Case "Zw_Prod_Imagenes"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_Imagenes
            Case "Zw_Prod_Log_Compras"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_Log_Compras
            Case "Zw_Prod_Padres"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_Padres
            Case "Zw_Prod_PrestaShop"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_PrestaShop
            Case "Zw_Prod_Ranking"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_Ranking
            Case "Zw_Prod_Reemplazos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_Reemplazos
            Case "Zw_Prod_SolBodega"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_SolBodega
            Case "Zw_Prod_Stock_Enc_History"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_Stock_Enc_History
            Case "Zw_Prod_Ubicacion"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_Ubicacion
            Case "Zw_Prod_SolCompra"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_SolCompra
            Case "Zw_Prod_SolCompra_Resp"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_SolCompra_Resp
            Case "Zw_Prod_Stock"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_Stock
            Case "Zw_Prod_Usuario_Validador"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_Usuario_Validador
            Case "Zw_Prod_Doc_Ult_Ventas"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_Doc_Ult_Ventas
            Case "Zw_Prod_Dimensiones"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_Dimensiones
            Case "Zw_Prod_CodQR"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_CodQR
            Case "Zw_Prod_CodQRLogDoc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_CodQRLogDoc
            Case "Zw_Prod_ImpAdicional"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Prod_ImpAdicional
            Case "Zw_Productos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Productos

            Case "Zw_PtsVta_Configuracion"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_PtsVta_Configuracion
            Case "Zw_PtsVta_Doc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_PtsVta_Doc

            Case "Zw_Reclamo"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Reclamo
            Case "Zw_Reclamo_Archivos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Reclamo_Archivos
            Case "Zw_Reclamo_Email_Aviso"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Reclamo_Email_Aviso
            Case "Zw_Reclamo_Estados"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Reclamo_Estados
            Case "Zw_Reclamo_Preguntas"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Reclamo_Preguntas
            Case "Zw_Reclamo_Resolucion"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Reclamo_Resolucion


            Case "Zw_Despachos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Despachos
            Case "Zw_Despachos_Doc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Despachos_Doc
            Case "Zw_Despachos_Doc_Det"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Despachos_Doc_Det
            Case "Zw_Despachos_Estados"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Despachos_Estados
            Case "Zw_Despachos_Email_Aviso"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Despachos_Email_Aviso
            Case "Zw_Despachos_Email_Envios"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Despachos_Email_Envios
            Case "Zw_Despachos_Tom"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Despachos_Tom
            Case "Zw_Despachos_Direcc_Cli"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Despachos_Direcc_Cli
            Case "Zw_Despachos_Configuracion"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Despachos_Configuracion
            Case "Zw_Despachos_Transportistas"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Despachos_Transportistas
            Case "Zw_Despachos_MiniCompXProd"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Despachos_MiniCompXProd

            Case "Zw_Despacho_Simple"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Despacho_Simple

            Case "Zw_Remotas"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Remotas
            Case "Zw_Remotas_En_Cadena_01_Enc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Remotas_En_Cadena_01_Enc
            Case "Zw_Remotas_En_Cadena_02_Det"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Remotas_En_Cadena_02_Det
            Case "Zw_Remotas_En_Cadena_03_Usu"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Remotas_En_Cadena_03_Usu
            Case "Zw_Remotas_Notif"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Remotas_Notif

            Case "Zw_Referencias_Dte"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Referencias_Dte

            Case "ZW_SOC_Detalle"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.ZW_SOC_Detalle
            Case "ZW_SOC_Encabezado"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.ZW_SOC_Encabezado
            Case "ZW_SOC_Ent_Cadena"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.ZW_SOC_Ent_Cadena
            Case "ZW_SOC_Log"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.ZW_SOC_Log
            Case "ZW_SOC_Obs"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.ZW_SOC_Obs

            Case "Zw_SQL_Querys"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_SQL_Querys
            Case "Zw_St_Conf_Info_Reportes"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_St_Conf_Info_Reportes
            Case "Zw_St_Conf_Tecnicos_Taller"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_St_Conf_Tecnicos_Taller
            Case "Zw_St_OT_Accesorios"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_St_OT_Accesorios
            Case "Zw_St_OT_CheckIn"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_St_OT_CheckIn
            Case "Zw_St_OT_DetProd"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_St_OT_DetProd
            Case "Zw_St_OT_Doc_Asociados"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_St_OT_Doc_Asociados
            Case "Zw_St_OT_Encabezado"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_St_OT_Encabezado
            Case "Zw_St_OT_Estados"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_St_OT_Estados
            Case "Zw_St_OT_Notas"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_St_OT_Notas
            Case "Zw_St_OT_Operaciones"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_St_OT_Operaciones
            Case "Zw_St_OT_Operaciones_Precios"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_St_OT_Operaciones_Precios
            Case "Zw_St_OT_OpeXServ"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_St_OT_OpeXServ
            Case "Zw_St_OT_Recetas_Enc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_St_OT_Recetas_Enc
            Case "Zw_St_OT_Recetas_Ope"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_St_OT_Recetas_Ope
            Case "Zw_St_OT_Recetas_OpePre"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_St_OT_Recetas_OpePre
            Case "Zw_St_OT_Recetas_Prod"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_St_OT_Recetas_Prod

            Case "Zw_Stk_Agentes"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stk_Agentes
            Case "Zw_Stk_AgentesVsTipos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stk_AgentesVsTipos
            Case "Zw_Stk_Areas"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stk_Areas
            Case "Zw_Stk_Grupos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stk_Grupos
            Case "Zw_Stk_GrupoVsAgente"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stk_GrupoVsAgente
            Case "Zw_Stk_Tickets"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stk_Tickets
            Case "Zw_Stk_Tickets_Acciones"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stk_Tickets_Acciones
            Case "Zw_Stk_Tickets_Archivos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stk_Tickets_Archivos
            Case "Zw_Stk_Tickets_Asignado"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stk_Tickets_Asignado
            Case "Zw_Stk_Tickets_PorDefecto"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stk_Tickets_PorDefecto
            Case "Zw_Stk_Tickets_Producto"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stk_Tickets_Producto
            Case "Zw_Stk_Tipos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stk_Tipos
            Case "Zw_Stk_Tipos_Grupos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stk_Tipos_Grupos
            Case "Zw_Stk_Tickets_Toma"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stk_Tickets_Toma

            Case "Zw_Stmp_Enc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stmp_Enc
            Case "Zw_Stmp_Det"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stmp_Det
            Case "Zw_Stmp_DetPick"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stmp_DetPick
            Case "Zw_Stmp_Enc_Permisos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stmp_Enc_Permisos
            Case "Zw_Stmp_SalaEspera"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Stmp_SalaEspera

            Case "Zw_TablaDeCaracterizaciones"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_TablaDeCaracterizaciones
            Case "Zw_Tablas_Equivalentes_Rd_Bk"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Tablas_Equivalentes_Rd_Bk
            Case "Zw_Tbl_DisenoBarras"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Tbl_DisenoBarras
            Case "Zw_Tbl_DisenoBarras_SalPtoxEstacion"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Tbl_DisenoBarras_SalPtoxEstacion

            Case "Zw_Tbl_Reemplazos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Tbl_Reemplazos
            Case "Zw_TblArbol_Asociaciones"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_TblArbol_Asociaciones
            Case "Zw_TblChoferes_Empresa"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_TblChoferes_Empresa
            Case "Zw_TblFiltro_InfxUs"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_TblFiltro_InfxUs
            Case "Zw_TblInf_EntExcluidas"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_TblInf_EntExcluidas
            Case "Zw_TblTipoDocumentos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_TblTipoDocumentos
            Case "Zw_TblVehiculos_Empresa"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_TblVehiculos_Empresa
            Case "Zw_TblVehiculos_Empresa_Imagenes"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_TblVehiculos_Empresa_Imagenes
            Case "Zw_Tmp_Filtros_Busqueda"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Tmp_Filtros_Busqueda
            Case "Zw_Tmp_Prm_Informes"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Tmp_Prm_Informes
            Case "Zw_TmpInv_InvParcial"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_TmpInv_InvParcial
            Case "Zw_TmpInv_InvParcial_Inventarios"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_TmpInv_InvParcial_Inventarios
            Case "Zw_TmpInv_InvParcialConf"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_TmpInv_InvParcialConf
            Case "Zw_Turnos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Turnos
            Case "Zw_UnificadosHitory"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_UnificadosHitory

            Case "Zw_Usuarios"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Usuarios
            Case "Zw_Usuarios_Huellas"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Usuarios_Huellas
            Case "Zw_Usuarios_Email"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Usuarios_Email
            Case "Zw_Usuarios_VS_Jefes"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Usuarios_VS_Jefes
            Case "Zw_Usuarios_Impresion"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Usuarios_Impresion

            Case "Zw_Vales_Enc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Vales_Enc
            Case "Zw_Vales_Obs"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Vales_Obs

            Case "Zw_Version"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Version
            Case "Zw_WMS_Ingreso_Det"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_WMS_Ingreso_Det
            Case "Zw_WMS_Ingreso_Enc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_WMS_Ingreso_Enc
            Case "Zw_WMS_Ubicaciones_Bodega"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_WMS_Ubicaciones_Bodega
            Case "Zw_WMS_Ubicaciones_Mapa_Det"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_WMS_Ubicaciones_Mapa_Det
            Case "Zw_WMS_Ubicaciones_Mapa_Enc"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_WMS_Ubicaciones_Mapa_Enc
            Case "Zw_WMS_Ubicaciones_Stock_X_Producto"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_WMS_Ubicaciones_Stock_X_Producto

            Case "Zw_Wordpress"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Wordpress
            Case "Zw_Wordpress_Productos"
                Consulta_Sql = My.Resources.Recursos_Inst_Tablas.Zw_Wordpress_Productos

            Case Else
                Consulta_Sql = ""
        End Select

        Return Consulta_Sql


    End Function

    Private Function Fx_Agregar_Campo(_Tabla As String, _Fila_Campo As DataRow) As String

        Dim _Campo = _Fila_Campo.Item("Campo")
        Dim _Tipo_De_Campo = _Fila_Campo.Item("Tipo_De_Campo")
        Dim _Valor_Maximo = NuloPorNro(_Fila_Campo.Item("Valor_Maximo"), "")
        Dim _Valor_Por_Defecto = NuloPorNro(_Fila_Campo.Item("Valor_Por_Defecto"), "")
        Dim _Acepta_Nulos = _Fila_Campo.Item("Acepta_Nulos")
        Dim _Posicion = _Fila_Campo.Item("Posicion")

        Dim _Msg As String

        Select Case _Acepta_Nulos
            Case "SI", "YES"
                _Acepta_Nulos = "Null"
                _Valor_Por_Defecto = String.Empty
            Case Else
                _Acepta_Nulos = "Not Null"

                If _Acepta_Nulos = "Not Null" And Not String.IsNullOrEmpty(_Valor_Por_Defecto) Then
                    _Valor_Por_Defecto = "Default " & _Valor_Por_Defecto
                End If
        End Select

        If Not String.IsNullOrEmpty(_Valor_Maximo) Then
            _Tipo_De_Campo = _Tipo_De_Campo & " (" & _Valor_Maximo & ")"
        End If

        Consulta_Sql = "ALTER TABLE " & _Global_BaseBk & _Tabla & " ADD [" & _Campo & "] " & _Tipo_De_Campo & " " & _Acepta_Nulos & " " & _Valor_Por_Defecto
        Return Consulta_Sql

    End Function

    Private Function Fx_Editar_Campo(_Tabla As String, _Fila_Campo As DataRow) As String

        Dim _Campo = _Fila_Campo.Item("Campo")
        Dim _Tipo_De_Campo = _Fila_Campo.Item("Tipo_De_Campo")
        Dim _Valor_Maximo = NuloPorNro(_Fila_Campo.Item("Valor_Maximo"), "")
        Dim _Acepta_Nulos = _Fila_Campo.Item("Acepta_Nulos")
        Dim _Posicion = _Fila_Campo.Item("Posicion")

        Dim _Msg As String

        Select Case _Acepta_Nulos
            Case "SI", "YES"
                _Acepta_Nulos = "Null"
            Case Else
                _Acepta_Nulos = "Not Null"
        End Select

        If Not String.IsNullOrEmpty(_Valor_Maximo) Then
            _Tipo_De_Campo = _Tipo_De_Campo & " (" & _Valor_Maximo & ")"
        End If

        Consulta_Sql = "ALTER TABLE " & _Global_BaseBk & "[" & _Tabla & "] ALTER COLUMN [" & _Campo & "] " & _Tipo_De_Campo & " " & _Acepta_Nulos

        Return Consulta_Sql

    End Function

    Private Function Fx_Nueva_Tabla(_Tabla As String, _Con_Problema As Boolean) As DataRow

        Dim NewFila As DataRow
        NewFila = _Tbl_Tablas.NewRow
        With NewFila

            .Item("Tabla") = _Tabla
            .Item("Con_Problema") = _Con_Problema

            _Tbl_Tablas.Rows.Add(NewFila)

        End With

        Return NewFila

    End Function

End Class
