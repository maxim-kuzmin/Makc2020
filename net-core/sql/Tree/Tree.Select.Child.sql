use Test;

-- Корень: Id = 2

select
	t.*
from
	dbo.DummyTree t
where
	t.ParentId = 2
;