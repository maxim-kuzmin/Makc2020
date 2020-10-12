-- Axis ParentOrSelf

with cte_Input as 
(
	select
		Id RootId
	from
		dbo.DummyTree
	where
		[Name] = 'Name-1-1'
)
select
	t1.*
from
	dbo.DummyTree t1
	inner join dbo.DummyTreeLink k
		on t1.Id = k.ParentId
	inner join dbo.DummyTree t2
		on k.Id = t2.Id
	cross join cte_Input
where
	k.Id = cte_Input.RootId
	and
	(
		t1.TreeLevel = t2.TreeLevel
		or
		t1.TreeLevel = t2.TreeLevel - 1
	)
;