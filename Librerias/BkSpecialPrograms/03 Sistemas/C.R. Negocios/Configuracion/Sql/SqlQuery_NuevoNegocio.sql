
Select '#NroNegocio#' As 'NroNegocio',GetDate() As 'FechaEmision','#CodFuncionario#' As 'CodFuncionario',
       '#NomFuncionario#' As 'NomFuncionario','#Empresa#' As 'Empresa','#Sucursal#' As 'Sucursal', '#NomSucursal#' as 'NomSucursal'
       
Select * From MAEEN Where KOEN = @CodEntidad And SUEN = @CodSucursal

         