'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_02_BodegasInv

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim CodEmpresa As String
    Dim CodSucursal As String
    Dim CodBodega As String

    Private Sub Frm_BodegasInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Function AgregarBodega() As Boolean
        Try
            Dim Registros As Long =_Sql.Fx_Cuenta_Registros("ZW_TmpInvBodegasInventario", _
                                                     "Empresa = '" & CodEmpresa & _
                                                     "' and Sucursal = '" & CodSucursal & _
                                                     "' and Bodega = '" & CodBodega & "'")

            If Registros = 0 Then
                Dim NombreBodega As String
                NombreBodega = _Sql.Fx_Trae_Dato("TABBO", "NOKOBO", "EMPRESA = '" & CodEmpresa &
                                         "' AND KOSU = '" & CodSucursal & "' AND KOBO ='" & CodBodega & "'")
                NombreBodega = InputBox("Descripción de bodega", "Creación de bodega", NombreBodega)

                If Trim(NombreBodega) <> "" Then

                    Dim CodigoBodega As String = Trim(CodEmpresa) & Trim(CodSucursal) & Trim(CodBodega)

                    Consulta_sql = "INSERT INTO ZW_TmpInvBodegasInventario (Empresa, Sucursal, Bodega,CodBodega, NombreBodega) VALUES " & vbCrLf & _
                                   "('" & CodEmpresa & "','" & CodSucursal & "','" & CodBodega & "','" & CodigoBodega & "','" & NombreBodega & "')"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    Consulta_sql = "INSERT INTO ZW_Permisos (CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso) VALUES " & _
                                   "('" & CodigoBodega & "Inv','Inv. " & NombreBodega & _
                                   "','1','Inventario')"
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                    Return True
                End If
            Else
                MsgBox("¡La bodega ya existe en la lista!" & vbCrLf & _
                       "Debe seleccionar otra bodega", MsgBoxStyle.Critical, "Mantención de bodegas")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

End Class