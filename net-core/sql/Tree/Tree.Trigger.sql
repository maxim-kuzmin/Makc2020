		declare @Ids TABLE ([Val] bigint);
		
		insert into @Ids ([Val]) select [Id] from [dbo].[DummyTree];

		with cte_Ids as 
		(
			select [Val] from @Ids
		),
		cte_Link as
		(
			select
				[Id] = t.[Id],
				[ParentId] = COALESCE(t.[ParentId], 0)
			from
				[dbo].[DummyTree] t
				inner join cte_Ids ids on ids.[Val] = t.[Id]
			union all
			select
				[Id] = k.[Id],
				[ParentId] = COALESCE(t.[ParentId], 0)
			from 
				[dbo].[DummyTree] t
				inner join cte_Link k on k.[ParentId] = t.[Id]			
		),
		cte_All as 
		(
			select
				[Id] = t.[Id],
				[ParentId] = t.[Id]
			from
				[dbo].[DummyTree] t
				inner join cte_Ids ids on ids.[Val] = t.[Id]
			union all
			select
				Id, 
				ParentId
			from 
				cte_Link
		)
		select Id, ParentId from cte_All order by Id, ParentId;