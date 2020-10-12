-- Select Opened All

declare @IdsOpened table (Val bigint);

insert into @IdsOpened
	(Val)
values
	(1),
	(18),
	(3),
	(8)
;

select
	t.*
from
	dbo.DummyTree t
	inner join dbo.DummyTreeLink k
		on t.Id = k.Id
	left join
	(
		select
			tt.Id Val
		from
			dbo.DummyTree tt
		where
			tt.ParentId in (select Val from @IdsOpened)
			or
			tt.Id in (select Val from @IdsOpened)
	) ids
		on t.Id = ids.Val
where
	k.ParentId = 0
	and
	(
		ids.Val is null and t.TreeLevel = 1
		or
		ids.Val is not null
	)
order by
	t.TreeSort
;
