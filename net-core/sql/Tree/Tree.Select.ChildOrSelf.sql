-- ChildOrSelf

declare @RootId bigint = 2;

select
	t.*
from
	dbo.DummyTree t
where
	t.ParentId = @RootId
	or
	t.Id = @RootId
;