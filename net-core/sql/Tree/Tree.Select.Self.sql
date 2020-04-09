-- Select Self

declare @RootId bigint = 2;

select
	t.*
from
	dbo.DummyTree t
where
	t.Id = @RootId
;
