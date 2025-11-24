Public Class Cl_SobreStockXClas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property TablaPasoRotacion As String
    Public Property TablaPasoRotacion_Productos As String

    Public Sub New()

        TablaPasoRotacion = "TablaPasoRotacion_" & FUNCIONARIO
        TablaPasoRotacion_Productos = "TablaPasoRotacion_Productos" & FUNCIONARIO

    End Sub

    Function Fx_CrearTablaPaso_TablaPasoRotacionXClasificaciones() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Sb_Eliminar_TablasDePasoRotacion()

        Try

            Consulta_sql = $"-- Crear la tabla con la estructura
CREATE TABLE {TablaPasoRotacion}(
    Codigo_Nodo VARCHAR(50),
    Codigo_Nodo_Madre VARCHAR(50),
    Producto VARCHAR(200),
    StockUd1 INT,
    StockEnTransitoUd1 INT,
    StockPedidoUd1 INT,
    StockDisponible INT,
    RotM1 FLOAT,
    RotM2 FLOAT,
    RotM3 FLOAT,
    RotM4 FLOAT,
    RotCalculo VARCHAR(10),
    Rotacion FLOAT,
    Duracion_Stock_Meses FLOAT,
    MesesSobreStock INT,
    Syncro Float,
    KilosXPallet Float,
    PalletSY Float,
    SobreStock VARCHAR(2)
);"

            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                ' Lanzar error aquí con información útil para depuración
                Throw New Exception(String.Format("Error al ejecutar la consulta para crear la tabla '{0}'. Consulta: {1}", TablaPasoRotacion, Consulta_sql))
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Tabla temporal creada correctamente."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Crear tabla de paso: " & TablaPasoRotacion

        Catch ex As Exception
            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
            'Throw
        End Try

        Return _Mensaje

    End Function

    Function Fx_InsertarDetalleEn_TablaPasoRotacionXClasificaciones(_Tbl_Asc_02_Asociaciones As String,
                                                    _SumarStockDisponible As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _StockPedidoUd1 = String.Empty

        If _SumarStockDisponible Then
            _StockPedidoUd1 = " + StockPedidoUd1"
        End If

        Try

            Consulta_sql = $"-- Insertar los datos en la tabla recién creada
INSERT INTO {TablaPasoRotacion} (
    Codigo_Nodo,
    Codigo_Nodo_Madre,
    Producto,
    StockUd1,
    StockEnTransitoUd1,
    StockPedidoUd1,
    StockDisponible,
    RotM1,
    RotM2,
    RotM3,
    RotM4,
    RotCalculo,
    Rotacion,
    Duracion_Stock_Meses,
    MesesSobreStock,
    SobreStock,
	KilosXPallet
)
SELECT  
    Codigo_Nodo,
    Codigo_Nodo_Madre,
    Producto,
    StockUd1,
    StockEnTransitoUd1,
    StockPedidoUd1,
    StockUd1 + StockEnTransitoUd1{_StockPedidoUd1} AS StockDisponible,
    RotMensualUd1 AS RotM1,
    Promedio_Mensual AS RotM2,
    Promedio_UltMesMasPromUlt3Mes AS RotM3,
    Promedio_3Mes AS RotM4,
    -- Nombre del campo que resultó mayor
    CASE 
        WHEN RotMensualUd1 >= Promedio_Mensual 
             AND RotMensualUd1 >= Promedio_UltMesMasPromUlt3Mes 
             AND RotMensualUd1 >= Promedio_3Mes 
        THEN 'RotM1'
        WHEN Promedio_Mensual >= RotMensualUd1 
             AND Promedio_Mensual >= Promedio_UltMesMasPromUlt3Mes 
             AND Promedio_Mensual >= Promedio_3Mes 
        THEN 'RotM2'
        WHEN Promedio_UltMesMasPromUlt3Mes >= RotMensualUd1 
             AND Promedio_UltMesMasPromUlt3Mes >= Promedio_Mensual 
             AND Promedio_UltMesMasPromUlt3Mes >= Promedio_3Mes 
        THEN 'RotM3'
        ELSE 'RotM4'
    END AS RotCalculo,
	    -- Valor máximo
    (SELECT MAX(v) 
     FROM (VALUES (RotMensualUd1), (Promedio_Mensual), 
                  (Promedio_UltMesMasPromUlt3Mes), (Promedio_3Mes)) AS value(v)
    ) AS Rotacion,
    Duracion_Stock AS Duracion_Stock_Meses,
    MesesSobreStock+2,
    SobreStock,
	600
FROM {_Tbl_Asc_02_Asociaciones}
WHERE StockUd1 + StockEnTransitoUd1 > 0

Update {_TablaPasoRotacion} Set Duracion_Stock_Meses = StockDisponible/Rotacion
Update {_TablaPasoRotacion} Set Syncro = (Duracion_Stock_Meses-MesesSobreStock)*Rotacion
Update {_TablaPasoRotacion} Set SobreStock = 'No' Where Duracion_Stock_Meses <= MesesSobreStock
Update {_TablaPasoRotacion} Set SobreStock = 'Si' Where Duracion_Stock_Meses > MesesSobreStock
Update {_TablaPasoRotacion} Set PalletSY = Floor(Syncro/KilosXPallet)
"
            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                ' Lanzar error aquí con información útil para depuración
                Throw New Exception(String.Format("Error al ejecutar la consulta para insertar datos en la tabla '{0}'. Consulta: {1}", _TablaPasoRotacion, Consulta_sql))
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Datos insertados correctamente en la tabla temporal."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Insertar detalle en tabla de paso: " & _TablaPasoRotacion

        Catch ex As Exception
            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
            'Throw
        End Try

        Return _Mensaje

    End Function

    Sub Sb_Eliminar_TablasDePasoRotacion()
        Try
            Consulta_sql = "DROP TABLE " & TablaPasoRotacion
            _Sql.Ej_consulta_IDU(Consulta_sql, False)
            Consulta_sql = "DROP TABLE " & TablaPasoRotacion_Productos
            _Sql.Ej_consulta_IDU(Consulta_sql, False)
        Catch ex As Exception
        End Try
    End Sub

    Function Fx_CrearTablaPaso_TablaPasoRotacionXProductos() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        'Sb_Eliminar_TablasDePasoRotacion()

        Try

            Consulta_sql = $"-- Crear la tabla con la estructura
    CREATE TABLE {TablaPasoRotacion_Productos}(
    Codigo VARCHAR(50),
    Descripcion VARCHAR(200),
    Codigo_Nodo VARCHAR(50),
    Codigo_Nodo_Madre VARCHAR(50),
    Producto VARCHAR(200),
    UD1 VARCHAR(50),
    Rtu FLOAT,
    StockUd1 INT,
    StockEnTransitoUd1 INT,
    StockDisponible INT,
    RotM1 FLOAT,
    RotM2 FLOAT,
    RotM3 FLOAT,
    RotM4 FLOAT,
    RotCalculo VARCHAR(10),
    Rotacion FLOAT,
    Duracion_Stock_Meses FLOAT,
    MesesSobreStock INT,
    Syncro FLOAT,
    KilosXPallet FLOAT,
    PalletSY FLOAT,
    SobreStock VARCHAR(2)
);"

            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                ' Lanzar error aquí con información útil para depuración
                Throw New Exception(String.Format("Error al ejecutar la consulta para crear la tabla '{0}'. Consulta: {1}", TablaPasoRotacion_Productos, Consulta_sql))
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Tabla temporal creada correctamente."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Crear tabla de paso: " & TablaPasoRotacion_Productos

        Catch ex As Exception
            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
            'Throw
        End Try

        Return _Mensaje

    End Function

    Function Fx_InsertarDetalleEn_TablaPasoRotacionXProductos(_Tbl_Asc_01_Productos As String,
                                                             _SumarStockDisponible As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _StockPedidoUd1 = String.Empty

        If _SumarStockDisponible Then
            _StockPedidoUd1 = " + StockPedidoUd1"
        End If

        Try

            Consulta_sql = $"-- Insertar los datos en la tabla recién creada
INSERT INTO {TablaPasoRotacion_Productos} (
    Codigo,
    Descripcion,
    Codigo_Nodo,
    Codigo_Nodo_Madre,
    Producto,
    UD1,
    Rtu,
    StockUd1,
    StockEnTransitoUd1,
    StockDisponible,
    RotM1,
    RotM2,
    RotM3,
    RotM4,
    RotCalculo,
    Rotacion,
    Duracion_Stock_Meses,
    MesesSobreStock,
    SobreStock,
    KilosXPallet
)
SELECT
    Codigo,
    Descripcion,
    Codigo_Nodo,
    Codigo_Nodo_Madre,
    Producto,
    UD1,
    Rtu,
    StockUd1,
    StockEnTransitoUd1,
    StockUd1 + StockEnTransitoUd1 AS StockDisponible,
    RotMensualUd1 AS RotM1,
    RotMensualUd1_Prod AS RotM2,
    Promedio_MensualUd1_Prod AS RotM3,
    PromMensualUd1_Ul3Mes_Prod AS RotM4,
    CASE
        WHEN RotMensualUd1 >= RotMensualUd1_Prod
             AND RotMensualUd1 >= Promedio_MensualUd1_Prod
             AND RotMensualUd1 >= PromMensualUd1_Ul3Mes_Prod
        THEN 'RotM1'
        WHEN RotMensualUd1_Prod >= RotMensualUd1
             AND RotMensualUd1_Prod >= Promedio_MensualUd1_Prod
             AND RotMensualUd1_Prod >= PromMensualUd1_Ul3Mes_Prod
        THEN 'RotM2'
        WHEN Promedio_MensualUd1_Prod >= RotMensualUd1
             AND Promedio_MensualUd1_Prod >= RotMensualUd1_Prod
             AND Promedio_MensualUd1_Prod >= PromMensualUd1_Ul3Mes_Prod
        THEN 'RotM3'
        ELSE 'RotM4'
    END AS RotCalculo,
    (SELECT MAX(v)
     FROM (VALUES (RotMensualUd1), (RotMensualUd1_Prod),
                  (Promedio_MensualUd1_Prod), (PromMensualUd1_Ul3Mes_Prod)) AS value(v)
    ) AS Rotacion,
    Duracion_Stock AS Duracion_Stock_Meses,
    MesesSobreStock + 2,
    SobreStock,
    600
FROM {_Tbl_Asc_01_Productos}
WHERE StockUd1 + StockEnTransitoUd1 > 0;

-- Duración de stock en meses
UPDATE {TablaPasoRotacion_Productos}
SET Duracion_Stock_Meses = StockDisponible / NULLIF(Rotacion,0);

-- Cálculo de Syncro
UPDATE {TablaPasoRotacion_Productos}
SET Syncro = (Duracion_Stock_Meses - MesesSobreStock) * Rotacion;

-- SobreStock
UPDATE {TablaPasoRotacion_Productos}
SET SobreStock = 'No'
WHERE Duracion_Stock_Meses <= MesesSobreStock;

UPDATE {TablaPasoRotacion_Productos}
SET SobreStock = 'Si'
WHERE Duracion_Stock_Meses > MesesSobreStock;

-- Pallets calculados hacia abajo
UPDATE {TablaPasoRotacion_Productos}
SET PalletSY = FLOOR(Syncro / NULLIF(KilosXPallet,0));
"
            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                ' Lanzar error aquí con información útil para depuración
                Throw New Exception(String.Format("Error al ejecutar la consulta para insertar datos en la tabla '{0}'. Consulta: {1}", TablaPasoRotacion_Productos, Consulta_sql))
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Datos insertados correctamente en la tabla temporal."
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Detalle = "Insertar detalle en tabla de paso: " & TablaPasoRotacion_Productos

        Catch ex As Exception
            ' (Opcional) Registrar o asignar información al objeto _Mensaje si la estructura lo permite
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
            ' Volver a lanzar la excepción para que el llamador la maneje y preserve la pila
            'Throw
        End Try

        Return _Mensaje

    End Function

End Class
