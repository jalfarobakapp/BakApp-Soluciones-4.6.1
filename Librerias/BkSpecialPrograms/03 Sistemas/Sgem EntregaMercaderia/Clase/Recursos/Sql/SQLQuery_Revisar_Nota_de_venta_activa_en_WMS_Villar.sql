
declare @nv nvarchar(10)
set @nv='#Nudo#'

declare @pick_cmp int, @comandos int, @truck int
set @pick_cmp=(select count( distinct(pick_cmp)) AS pick_cmp from shipunit_f where ob_oid=@nv and pick_cmp = 'Y')
set @comandos =(select count(cm_rid) from cm_f where ob_oid=@nv)
set @truck =(select count(od_rid)
from od_f t0 inner join iv_f t1 on t0.sku=t1.sku 
where t1.ob_oid=@nv and t1.inv_stt='TRUCK')
declare @ticket_verde nvarchar(1)
if @pick_cmp=1 and @comandos=0 and @truck=0
begin 
 set @ticket_verde='Y'
end
else
begin
 set @ticket_verde='N'
end
select @ticket_verde as ticket_verde

Detalle:
select (case when (select loc from cn_f where cn_f.cont = i.cont) like 'CONS%' then 'PREDESPACHO'
	else 'PENDIENTE'
	end) as Status,
i.CONT, i.tag, i.sku, p.sku_desc, i.qty,Cast(i.qty As Float) As Saldo_qty, (select loc from cn_f where cn_f.cont = i.cont) as loc from iv_f i, pm_f p
where i.sku = p.sku and i.owner = p.owner and i.pkg = p.pkg
and i.whse_id = 'ALAMEDA'
and ob_oid = @nv

Cabecera:
select ord_date, ob_oid, ob_type, shipment, wave, bill_name,whse_id,ob_ord_stt
--,ord_date,request_date,ord_date,sched_date,ship_date,dtimecre,dtimemod,dtime_frlogic,latest_delv_date,dtimeorig -- Campos de tipo Fecha Hora
from om_f
where ob_oid = @nv
and om_f.whse_id = 'ALAMEDA'

Lineas:
select ob_oid, ob_type, ob_lno, sku, plan_qty, sched_qty, cmp_qty, ship_qty
from od_f
where plan_qty<>cmp_qty
and whse_id = 'ALAMEDA'
and ob_oid = @nv

Comandos:
select ob_oid, ob_type, ob_lno, cont, sku, COUNT(*) as comandos
from cm_f
where ob_oid = @nv
and cm_f.whse_id = 'ALAMEDA'
GROUP by ob_oid, ob_type, ob_lno, cont, sku 

FPickeo:
Select Top 1 dt_start
From history_master
Where oid = @nv AND (
                     (trans_class = 'CONT' AND trans_obj = 'OBO' AND trans_act = 'PICK' AND trans_act_mod = 'FINAL') or 
                     (trans_class = 'INVE' AND trans_obj = 'OBO' AND trans_act = 'PICK')
                    )
Order By trans_seq_num Desc
