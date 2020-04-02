use Test;

-- Корень: Id = 7

select
	t.*
from
	dbo.DummyTree t
	inner join dbo.DummyTree k on k.ParentId = t.Id
where
	k.Id = 7
;