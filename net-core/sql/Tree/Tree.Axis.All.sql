-- Axis All

select
	t.*
from
	dbo.DummyTree t
	inner join dbo.DummyTreeLink k
		on t.Id = k.Id
where
	k.ParentId = 0	
order by
	t.TreeSort
;
