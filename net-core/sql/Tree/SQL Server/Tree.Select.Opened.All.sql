-- Select Opened All

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
			'Name-1-1-2-1-1',
			'Name-1-1-1',
			'Name-1-1-1-2'
		)
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
where
	k.ParentId = 0
	and
	(
		ids.Val is null and t.TreeLevel = 1
		or
		ids.Val is not null
	)
order by
	t.TreeSort
;
