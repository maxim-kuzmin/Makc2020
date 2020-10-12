-- Axis ChildOrSelf

with cte_Input as 
(
	select
		Id RootId
	from
		dbo.DummyTree
	where
		[Name] = 'Name-1-1-1'
)
select
	t.*
from
	dbo.DummyTree t
	cross join cte_Input
where
	t.ParentId = cte_Input.RootId
	or
	t.Id = cte_Input.RootId
;