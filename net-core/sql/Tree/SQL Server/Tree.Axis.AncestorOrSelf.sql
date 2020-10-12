-- Axis AncestorOrSelf

with cte_Input as 
(
	select
		Id RootId
	from
		dbo.DummyTree
	where
		[Name] = 'Name-1-1-1-3-2'
)
select
	t.*
from
	dbo.DummyTree t
	inner join dbo.DummyTreeLink k
		on t.Id = k.ParentId
	cross join cte_Input
where
	k.Id = cte_Input.RootId
;
