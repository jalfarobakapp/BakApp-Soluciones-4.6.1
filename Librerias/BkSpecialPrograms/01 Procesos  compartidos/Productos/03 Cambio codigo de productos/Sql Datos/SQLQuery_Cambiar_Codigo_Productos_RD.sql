
Declare @CodigoNew Char(13) = '#CodigoNew#', 
        @CodigoOld Char(13) = '#CodigoOld#'

UPDATE MAEPR    SET KOPR = @CodigoNew      WHERE KOPR = @CodigoOld 
UPDATE MAEPREM  SET KOPR = @CodigoNew      WHERE KOPR = @CodigoOld 
UPDATE MAEPR    SET KOGE = @CodigoNew      WHERE KOGE = @CodigoOld 
UPDATE TABBOPR  SET KOPR = @CodigoNew      WHERE KOPR = @CodigoOld 
UPDATE TABCODAL SET KOPR = @CodigoNew      WHERE KOPR = @CodigoOld 
UPDATE TABPRE   SET KOPR = @CodigoNew      WHERE KOPR = @CodigoOld 
UPDATE MAEST    SET KOPR = @CodigoNew      WHERE KOPR = @CodigoOld 
UPDATE TABIMPR  SET KOPR = @CodigoNew      WHERE KOPR = @CodigoOld 
UPDATE MAEELOTE SET KOPR = @CodigoNew      WHERE KOPR = @CodigoOld 
UPDATE MAELIFO  SET KOPR = @CodigoNew      WHERE KOPR = @CodigoOld 
UPDATE MAEFICHA SET KOPR = @CodigoNew      WHERE KOPR = @CodigoOld 
UPDATE MAEFICHD SET KOPR = @CodigoNew      WHERE KOPR = @CodigoOld 
UPDATE TABKOPRE SET ELEMENTO = @CodigoNew  WHERE ELEMENTO = @CodigoOld 
UPDATE MAEDDO   SET KOPRCT = @CodigoNew    WHERE KOPRCT = @CodigoOld 
UPDATE MAEERES  SET CODIGO = @CodigoNew    WHERE CODIGO = @CodigoOld 
UPDATE MAEDRES  SET CODIGO = @CodigoNew    WHERE CODIGO = @CodigoOld 
UPDATE MAEDRES  SET ELEMENTO = @CodigoNew  WHERE ELEMENTO = @CodigoOld 
UPDATE PDIMEN   SET CODIGO = @CodigoNew    WHERE CODIGO = @CodigoOld 
UPDATE POTL     SET CODIGO = @CodigoNew    WHERE CODIGO = @CodigoOld 
UPDATE PRELA    SET CODIGO = @CodigoNew    WHERE CODIGO = @CodigoOld 
UPDATE PDATFAD  SET CODIGO = @CodigoNew    WHERE CODIGO = @CodigoOld 
UPDATE PDIMOT   SET CODIGO = @CodigoNew    WHERE CODIGO = @CodigoOld 
UPDATE POTD     SET CODIGO = @CodigoNew    WHERE CODIGO = @CodigoOld 
UPDATE POTPR    SET CODIGO = @CodigoNew    WHERE CODIGO = @CodigoOld 
UPDATE PPLAND   SET CODIGO = @CodigoNew    WHERE CODIGO = @CodigoOld 
UPDATE PPLANPR  SET CODIGO = @CodigoNew    WHERE CODIGO = @CodigoOld 
UPDATE PPLAPRIO SET CODIGO = @CodigoNew    WHERE CODIGO = @CodigoOld 
UPDATE PPLAVST  SET CODIGO = @CodigoNew    WHERE CODIGO = @CodigoOld 
UPDATE PNPA     SET ELEMENTO = @CodigoNew  WHERE ELEMENTO = @CodigoOld 
UPDATE PNPD     SET ELEMENTO = @CodigoNew  WHERE ELEMENTO = @CodigoOld 
UPDATE PINSUPRO SET PRODUCTO = @CodigoNew  WHERE PRODUCTO = @CodigoOld 
UPDATE LORESCAD SET KOPR = @CodigoNew      WHERE KOPR = @CodigoOld 
UPDATE POTLCOM  SET CODIGO = @CodigoNew    WHERE CODIGO = @CodigoOld 
UPDATE PASPD    SET CODIGO = @CodigoNew    WHERE CODIGO = @CodigoOld 
UPDATE PRESERVA SET CODIGO = @CodigoNew    WHERE CODIGO = @CodigoOld 
UPDATE PPROTAR  SET KOPR  = @CodigoNew     WHERE KOPR  = @CodigoOld 
UPDATE CACTFI   SET KOPR  = @CodigoNew     WHERE KOPR  = @CodigoOld 
UPDATE MAELIFO  SET KOPR  = @CodigoNew     WHERE KOPR  = @CodigoOld 
UPDATE MAEPOSST SET KOPR  = @CodigoNew     WHERE KOPR  = @CodigoOld 
UPDATE MAEPROBS SET KOPR  = @CodigoNew     WHERE KOPR  = @CodigoOld 
UPDATE ELIDDO   SET KOPRCT = @CodigoNew    WHERE KOPRCT = @CodigoOld 
UPDATE KASIDDO  SET KOPRCT = @CodigoNew    WHERE KOPRCT = @CodigoOld 
UPDATE TABLOTES SET KOPR  = @CodigoNew     WHERE KOPR  = @CodigoOld 







