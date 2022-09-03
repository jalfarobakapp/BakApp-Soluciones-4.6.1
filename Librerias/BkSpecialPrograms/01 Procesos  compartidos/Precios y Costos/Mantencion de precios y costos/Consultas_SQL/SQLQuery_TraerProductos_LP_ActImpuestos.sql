 

If #ValoresNetos# = 1 Begin
    Update #Tbl_Paso# Set Neto = Precio,
                                    Iva = Precio*Porc_Iva,
                                    Ila = Precio*Porc_Ila,
                                    Bruto = Precio*Impuestos 
  End                                                                  
  Else Begin
    Update #Tbl_Paso# Set Precio= CASE When Precio > 0 And Impuestos > 0 Then Precio / Impuestos Else 0 End
    Update #Tbl_Paso# Set Iva = Neto*Porc_Iva,
                                    Ila = Neto*Porc_Ila,
                                    Bruto = Neto*Impuestos 
End                                                                  









