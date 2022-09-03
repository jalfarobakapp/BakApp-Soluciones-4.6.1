'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.IO
Imports CrystalDecisions.[Shared]
Imports CrystalDecisions.CrystalReports.Engine

Public Class Clase_PDF

    Public Function Fx_Exportar_Crystal_a_PDF(ByVal _Rpt As ReportDocument, _
                                              ByVal _Directorio As String, _
                                              ByVal _Nombre_Archivo As String) As String
        Dim vFileName As String
        Dim diskOpts As New DiskFileDestinationOptions

        Try
            With _Rpt.ExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
            End With

            'Dim Directorio As String = Application.LocalUserAppDataPath

            vFileName = _Directorio & "\" & _Nombre_Archivo '_Direc_Y_Nombre_Archivo
            If File.Exists(vFileName) Then File.Delete(vFileName)
            diskOpts.DiskFileName = vFileName
            _Rpt.ExportOptions.DestinationOptions = diskOpts
            _Rpt.Export()
        Catch ex As Exception
            '            Throw ex
            MessageBoxEx.Show(ex.Message)
        End Try

        Return vFileName
    End Function

End Class
