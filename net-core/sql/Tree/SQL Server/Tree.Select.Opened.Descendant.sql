-- Select Opened Descendant

declare @IdsOpened table (Val bigint);

insert into @IdsOpened
	(Val)
values
	(1),
	(18)
;

declare @RootId bigint = 1;

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
			tt.ParentId in (select Val from @IdsOpened)
			or
			tt.Id in (select Val from @IdsOpened)
	) ids
		on t.Id = ids.Val
	cross join
	(
		select
			TreeLevel
		from
			dbo.DummyTree
		where
			Id = @RootId
	) t1
where
	k.ParentId = @RootId
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
