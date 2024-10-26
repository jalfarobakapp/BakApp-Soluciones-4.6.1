Imports BkSpecialPrograms
Public Class Cl_ArmaGDIConsumo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Ls_Productos As New List(Of ArmaGDIConsumo.ProductosGDI)

    Public Sub New()

    End Sub

    Function Fx_CrearDetalle(_Idpotl As Integer, _Fabricado As Double) As DataTable

        Consulta_sql = "Select * From POTL Where IDPOTL = " & _Idpotl
        Dim _Row_POTL As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Codnomen As String = _Row_POTL("CODNOMEN")
        Dim _Fabricar As Double = _Row_POTL("FABRICAR")
        Dim _Nreg As String = _Row_POTL("NREG")

        Consulta_sql = "Select * From PNPE Where CODIGO = '" & _Codnomen & "'"
        Dim _Row_PNPE As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Cantidad As Double = _Row_PNPE("CANTIDAD")

        Consulta_sql = "Declare @CantMomencla as float = " & De_Num_a_Tx_01(_Cantidad, False, 5) & vbCrLf &
                       "Declare @CantFabricar as float = " & De_Num_a_Tx_01(_Fabricar, False, 5) & vbCrLf &
                       "Declare @Fabricado as float" & vbCrLf &
                       "Declare @aFabricar as float" & vbCrLf &
                       "" & vbCrLf &
                       "Set @aFabricar = @CantFabricar/@CantMomencla" & vbCrLf &
                       "Set @Fabricado = " & De_Num_a_Tx_01(_Fabricado, False, 5) & vbCrLf &
                       "" & vbCrLf &
                       "Select POTD.*,POTD.CANTIDADF/@aFabricar As 'FF',((POTD.CANTIDADF/@aFabricar)/25) As 'RESUL'," &
                       "((POTD.CANTIDADF/@aFabricar)/25)*@Fabricado As 'Cantidad',POTD.SULIOTD As 'Sucursal',POTD.BOLIOTD As 'Bodega'," & vbCrLf &
                       "MAEPR.TIPR,MAEPR.POIVPR,MAEPR.RLUD,MAEPR.UD01PR,MAEPR.UD02PR,MAEPR.NUIMPR,MAEPR.NMARCA,Op.CODMAQ" & vbCrLf &
                       "From POTD WITH ( NOLOCK )" & vbCrLf &
                       "Left Outer Join MAEPR On POTD.CODIGO = MAEPR.KOPR" & vbCrLf &
                       "Left Join POPER Op On Op.OPERACION = POTD.OPERACION" & vbCrLf &
                       "Where POTD.IDPOTL = " & _Idpotl & vbCrLf &
                       "And POTD.LILG <> 'IM'" & vbCrLf &
                       "And POTD.CALIDAD <> 'D'" & vbCrLf &
                       "And POTD.CALIDAD <> 'R'" & vbCrLf &
                       "And POTD.PERTENECE = '" & _Nreg & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Return _Tbl

    End Function

    Function Fx_CrearGDI(_Formulario As Form,
                         _Idpotl As Integer,
                         _Fabricado As Double,
                         _Row_Entidad As DataRow,
                         _FechaEmision As DateTime,
                         _Observaciones As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _Tbl_Productos As DataTable = Fx_CrearDetalle(_Idpotl, _Fabricado)

        Dim Fm As New Frm_Formulario_Documento("GDI", csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Despacho_Interna,
                                               False, False, False, False, False, False)

        Fm.Pro_RowEntidad = _Row_Entidad
        Fm.Sb_Crear_Documento_Interno_Con_Tabla3Potl(_Formulario,
                                                     _Tbl_Productos,
                                                     _FechaEmision,
                                                     "CODIGO", "Cantidad", "", _Observaciones, False, True, 1, "02C", "IDPOTD")
        _Mensaje = Fm.Fx_Grabar_Documento(False)
        Fm.Dispose()

        Return _Mensaje

    End Function

End Class

Namespace ArmaGDIConsumo
    Public Class ProductosGDI
        Public Property Codigo As String
        Public Property Descripcion As String
        Public Property Cantidad As Double
        Public Property Udm As String
        Public Property Precio As Double
        Public Property Empresa As String
        Public Property Sucursal As String
        Public Property Bodega As String
        Public Property Operacion As String
        Public Property Codmaq As String

    End Class
End Namespace
