use Test;

declare @Ids table (Val bigint);
declare @IdsAncestor table (Val bigint);
declare @IdsBroken table (Val bigint);
declare @IdsCalculated table (Val bigint);
declare @IdsDescendant table (Val bigint);
declare @IdsLinked table (Val bigint);		

--declare @Action char = 'D';
--insert into @Ids (Val) values (4);
--delete from dbo.DummyTree where Id in (select Val from @Ids);
declare @Action char = '';

insert into @Ids
(
	Val
)
select Id from dbo.DummyTree
;

-- Добавляем узлы к разрушенным узлам.
insert into @IdsBroken
(
	Val
)
select Val from @Ids
;

-- Удаление или обновление.
if @Action <> 'I'
begin;
	-- Запоминаем идентификаторы предков удалённых или обновлённых узлов.
	insert into @IdsAncestor
	(
		Val
	)
	select distinct
		ParentId
	from
		dbo.DummyTreeLink
	where
		ParentId > 0
		and
		Id <> ParentId
		and
		Id in (select Val from @Ids)
	;
end;

-- Обновление.
if @Action = 'U'
begin;
	-- Запоминаем идентификаторы потомков обновлённых узлов.
	insert into @IdsDescendant
	(
		Val
	)
	select distinct
		Id
	from
		dbo.DummyTreeLink
	where
		Id <> ParentId
		and 
		ParentId in (select Val from @Ids)
	;

	-- Добавляем потомков обновлённых узлов к разрушенным узлам.
	insert into @IdsBroken
	(
		Val
	)
	select
		Val
	from
		@IdsDescendant
	;

	-- Добавляем потомков обновлённых узлов к связываемым узлам.
	insert into @IdsLinked
	(
		Val
	)
	select
		Val
	from
		@IdsDescendant
	;
end;

-- Вставка или обновление.
if @Action <> 'D'
begin;
	-- Добавляем вставленные или обновлённые узлы к связываемым узлам.
	insert into @IdsLinked
	(
		Val
	)
	select
		Val
	from
		@Ids
	;

	-- Добавляем родителей вставленных или обновлённых узлов к вычисляемым узлам.
	insert into @IdsCalculated
	(
		Val
	)
	select distinct
		ParentId
	from
		dbo.DummyTree
	where
		ParentId is not null
		and Id in (select Val from @Ids)
	;

	-- Запоминаем идентификаторы предков родителей вставленных или обновлённых узлов.
	insert into @IdsAncestor
	(
		Val
	)
	select distinct
		ParentId
	from
		dbo.DummyTreeLink
	where
		ParentId > 0
		and Id <> ParentId
		and Id in (select Val from @IdsCalculated)
	;

	-- Добавляем вставленные или обновлённые узлы к вычисляемым узлам.
	insert into @IdsCalculated
	(
		Val
	)
	select
		Val
	from
		@Ids
	;
end;

-- Добавляем предков к вычисляемым узлам.
insert into @IdsCalculated
(
	Val
)
select
	Val
from
	@IdsAncestor
;

-- Обновление.
if @Action = 'U'
begin;
	-- Добавляем потомков обновлённых узлов к вычисляемым узлам.
	insert into @IdsCalculated
	(
		Val
	)
	select
		Val
	from
		@IdsDescendant
	;
end;

-- Удаляем связи разрушенных узлов.
delete from	dbo.DummyTreeLink
where
	Id in (select Val from @IdsBroken)
;		

-- Добавляем связи разрушенных узлов.
with cteForAncestors as
(
	select
		Id = aliasForTree.Id,
		ParentId = COALESCE(aliasForTree.ParentId, 0)
	from
		dbo.DummyTree aliasForTree
		inner join @IdsLinked aliasForIds
            on aliasForTree.Id = aliasForIds.Val
	union all
	select
		Id = aliasForAncestors.Id,
		ParentId = COALESCE(aliasForTree.ParentId, 0)
	from 
		dbo.DummyTree aliasForTree
		inner join cteForAncestors aliasForAncestors
            on aliasForTree.Id = aliasForAncestors.ParentId
),
cteForAll as 
(
	select
		Id = aliasForTree.Id,
		ParentId = aliasForTree.Id
	from
		dbo.DummyTree aliasForTree
		inner join @IdsLinked aliasForIds
			on aliasForTree.Id = aliasForIds.Val
	union all
	select
		Id, 
		ParentId
	from 
		cteForAncestors
)
insert into dbo.DummyTreeLink
(
	Id,
	ParentId
)
select
	Id,
	ParentId
from
	cteForAll
;

select distinct * from @IdsCalculated;