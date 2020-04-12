-- Select ParentOrSelf

declare @RootId bigint = 7;

select
	t1.*
from
	dbo.DummyTree t1
	inner join dbo.DummyTreeLink k
		on t1.Id = k.ParentId
	inner join dbo.DummyTree t2
		on k.Id = t2.Id
where
	k.Id = @RootId
	and
	(
		t1.TreeLevel = t2.TreeLevel
		or
		t1.TreeLevel = t2.TreeLevel - 1
	)
;