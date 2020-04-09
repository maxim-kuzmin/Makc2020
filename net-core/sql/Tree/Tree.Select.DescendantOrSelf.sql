-- Select DescendantOrSelf

declare @RootId bigint = 2;

select
	t.*
from
	dbo.DummyTree t
	inner join dbo.DummyTreeLink k
		on t.Id = k.Id
where
	k.ParentId = @RootId
order by
	t.TreeSort
;
