-- Axis Parent

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
	inner join dbo.DummyTree t2
		on t1.Id = t2.ParentId
	cross join cte_Input
where
	t2.Id = cte_Input.RootId
;
