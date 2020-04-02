use Test;

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
			dbo.DummyTree k
		where
			k.ParentId = cte.Id
	),
	TreeDescendantCount = 
	(
		select
			COUNT_BIG(*)
		from
			dbo.DummyTree t
			inner join dbo.DummyTreeLink k on k.Id = t.Id
		where
			k.ParentId = cte.Id
			and k.Id <> k.ParentId
	),
	TreeLevel = 
	(
		select
			COUNT_BIG(*) - 1
		from
			dbo.DummyTreeLink k
		where
			k.Id = cte.Id
	),
	TreePath =
	(
		select
			COALESCE(TreePath, N'')
		from
		(
			select
				t1.Id,
				STUFF
				(
					(
						select
							',' + CONVERT(varchar(max), t2.ParentId)
						from
							dbo.DummyTreeLink t2
						where
							t1.Id = t2.Id
							and t2.ParentId > 0
							and t2.ParentId <> t1.Id
							for xml path(''), type
					).value('.', 'varchar(max)'),
					1,
					1,
					''
				) TreePath
			from
				dbo.DummyTreeLink t1
			group by
				t1.Id
		) k
		where
			k.Id = cte.Id
	),
	TreeSort =
	(
		select
			COALESCE(TreePath, N'')
		from
		(
			select
				t1.Id,
				STUFF
				(
					(
						select
							'.' + RIGHT('0000000000' + CONVERT(varchar(max), t2.ParentId), 10)
						from
							dbo.DummyTreeLink t2
						where
							t1.Id = t2.Id
							and t2.ParentId > 0
							for xml path(''), type
					).value('.', 'varchar(max)'),
					1,
					1,
					''
				) TreePath
			from
				dbo.DummyTreeLink t1
			group by
				t1.Id
		) k
		where
			k.Id = cte.Id
	);
