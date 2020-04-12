-- Select Descendant

declare @RootId bigint = 2;

select
	t.*
from
	dbo.DummyTree t
	inner join dbo.DummyTreeLink k 
		on t.Id = k.Id
where
	k.ParentId = @RootId
	and
	k.Id <> k.ParentId
order by
	t.TreeSort
;
