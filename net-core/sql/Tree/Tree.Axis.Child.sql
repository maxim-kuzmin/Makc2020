-- Select Child

declare @RootId bigint = 2;

select
	t.*
from
	dbo.DummyTree t
where
	t.ParentId = @RootId
;
