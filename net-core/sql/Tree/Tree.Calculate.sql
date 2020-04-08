use Test;

update dbo.DummyTree set	
	TreeChildCount = 0,
	TreeDescendantCount = 0,
	TreePath = N'',
	TreePosition = 0,
	TreeSort = N'';

declare @Ids TABLE (Val bigint);

--insert into @Ids (Val) values (2), (4);
insert into @Ids (Val) select Id from dbo.DummyTree;

while 1 = 1
begin;
	with cte as
	(
		select top 1
			Id,
			ParentId,
			TreePosition
		from
			dbo.DummyTree
		where
			TreePosition = 0
	)
	update cte set
		TreePosition = 
		(
			select
				MAX(aliasForTree.TreePosition) + 10
			from
				dbo.DummyTree aliasForTree
			where
				COALESCE(aliasForTree.ParentId, 0) = COALESCE(cte.ParentId, 0)
		)
	;

	if @@ROWCOUNT < 1 break;
end;

with cte as
(
	select
		Id,
		TreeChildCount,
		TreeDescendantCount,
		TreeLevel,
		TreePath,
		TreeSort
	from
		dbo.DummyTree
)
update cte set
	TreeChildCount = 
	(
		select
			COUNT_BIG(*)
		from
			dbo.DummyTree aliasForTree
		where
			aliasForTree.ParentId = cte.Id
	),
	TreeDescendantCount = 
	(
		select
			COUNT_BIG(*)
		from
			dbo.DummyTreeLink aliasForLink
		where
			aliasForLink.ParentId = cte.Id
			and
			aliasForLink.ParentId <> aliasForLink.Id
	),
	TreeLevel = 
	(
		select
			COUNT_BIG(*) - 1
		from
			dbo.DummyTreeLink aliasForLink
		where
			aliasForLink.Id = cte.Id
	),
	TreePath =
	(
		select
			COALESCE(aliasForResult.Val, N'')
		from
		(
			select
				aliasForLink1.Id,
				STUFF
				(
					(
						select
							',' + CONVERT(varchar(max), aliasForLink2.ParentId)
						from
							dbo.DummyTreeLink aliasForLink2
						where
							aliasForLink1.Id = aliasForLink2.Id
							and
							aliasForLink2.ParentId > 0
							and
							aliasForLink2.ParentId <> aliasForLink2.Id
							for xml path(''), type
					).value('.', 'varchar(max)'),
					1,
					1,
					''
				) Val
			from
				dbo.DummyTreeLink aliasForLink1
			group by
				aliasForLink1.Id
		) aliasForResult
		where
			aliasForResult.Id = cte.Id
	),
	TreeSort =
	(
		select
			COALESCE(aliasForResult.Val, N'')
		from
		(
			select
				aliasForLink1.Id,
				STUFF
				(
					(
						select
							',' + RIGHT('0000000000' + CONVERT(varchar(max), aliasForTree.TreePosition) + '.' + CONVERT(varchar(max), aliasForLink2.ParentId), 10)
						from
							dbo.DummyTreeLink aliasForLink2
							inner join dbo.DummyTree aliasForTree
								on aliasForLink2.ParentId = aliasForTree.Id
						where
							aliasForLink1.Id = aliasForLink2.Id
							and
							aliasForLink2.ParentId > 0
							for xml path(''), type
					).value('.', 'varchar(max)'),
					1,
					1,
					''
				) Val
			from
				dbo.DummyTreeLink aliasForLink1
			group by
				aliasForLink1.Id
		) aliasForResult
		where
			aliasForResult.Id = cte.Id
	)
where
	cte.Id in (select Val from @Ids)
;
