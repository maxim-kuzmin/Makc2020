-- Axis Parent

declare @RootId bigint = 7;

select
	t1.*
from
	dbo.DummyTree t1
	inner join dbo.DummyTree t2
		on t1.Id = t2.ParentId
where
	t2.Id = @RootId
;
