-- Axis Ancestor

declare @RootId bigint = 7;

select
	t.*
from
	dbo.DummyTree t
	inner join dbo.DummyTreeLink k
		on t.Id = k.ParentId
where
	k.Id = @RootId
	and
	k.Id <> k.ParentId
;
