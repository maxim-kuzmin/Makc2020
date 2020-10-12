-- Select Opened Descendant

with cte_Input_IdsOpened as
(
	select
		Id Val
	from
		dbo.DummyTree
	where
		[Name] in
		(
			'Name-1',
			'Name-1-1-2-1-1'
		)
),
cte_Input as 
(
	select
		Id RootId
	from
		dbo.DummyTree
	where
		[Name] = 'Name-1'
)
select
	t.*
from
	dbo.DummyTree t
	inner join dbo.DummyTreeLink k
		on t.Id = k.Id
	left join
	(
		select
			tt.Id Val
		from
			dbo.DummyTree tt
		where
			tt.ParentId in (select Val from cte_Input_IdsOpened)
			or
			tt.Id in (select Val from cte_Input_IdsOpened)
	) ids
		on t.Id = ids.Val
	cross join
	(
		select
			TreeLevel
		from
			dbo.DummyTree
			cross join cte_Input
		where
			Id = cte_Input.RootId
	) t1
	cross join cte_Input
where
	k.ParentId = cte_Input.RootId
	and
	k.Id <> k.ParentId
	and
	(
		ids.Val is null and t.TreeLevel = t1.TreeLevel
		or
		ids.Val is not null
	)
order by
	t.TreeSort
;
