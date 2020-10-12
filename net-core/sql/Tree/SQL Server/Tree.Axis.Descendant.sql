-- Axis Descendant

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
	t.*
from
	dbo.DummyTree t
	inner join dbo.DummyTreeLink k 
		on t.Id = k.Id
	cross join cte_Input
where
	k.ParentId = cte_Input.RootId
	and
	k.Id <> k.ParentId
order by
	t.TreeSort
;
