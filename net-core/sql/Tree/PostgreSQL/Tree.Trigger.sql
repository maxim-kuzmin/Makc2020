-- Trigger

do $$
declare
	_action char := '';
begin
	create temp table _ids ("val" bigint);
	create temp table _idsAncestor ("val" bigint);
	create temp table _idsBroken ("val" bigint);
	create temp table _idsCalculated ("val" bigint);
	create temp table _idsDescendant ("val" bigint);
	create temp table _idsLinked ("val" bigint);		

	insert into _ids
	(
		"val"
	)
	select "id" from "public"."dummy_tree"
	;

	-- Добавляем узлы к разрушенным узлам.
	insert into _idsBroken
	(
		"val"
	)
	select
		"val"
	from
		_ids
	;

	-- Удаление или обновление.
	if (_action <> 'I') then	
		-- Запоминаем идентификаторы предков удалённых или обновлённых узлов.
		insert into _idsAncestor
		(
			"val"
		)
		select distinct
			"parent_id"
		from
			"public"."dummy_tree_link"
		where
			"parent_id" > 0
			and 
			"id" <> "parent_id"
			and
			"id" in (select "val" from _ids)
		;
	end if;

	-- Обновление.
	if (_action = 'U') then
		-- Запоминаем идентификаторы потомков обновлённых узлов.
		insert into _idsDescendant
		(
			"val"
		)
		select distinct
			"id"
		from
			"public"."dummy_tree_link"
		where
			"id" <> "parent_id"
			and
			"parent_id" in (select "val" from _ids)
		;

		-- Добавляем потомков обновлённых узлов к разрушенным узлам.
		insert into _idsBroken
		(
			"val"
		)
		select
			"val"
		from
			_idsDescendant
		;

		-- Добавляем потомков обновлённых узлов к связываемым узлам.
		insert into _idsLinked
		(
			"val"
		)
		select
			"val"
		from
			_idsDescendant
		;
	end if;

	-- Вставка или обновление.
	if (_action <> 'D') then
		-- Добавляем вставленные или обновлённые узлы к связываемым узлам.
		insert into _idsLinked
		(
			"val"
		)
		select
			"val"
		from
			_ids
		;

		-- Добавляем родителей вставленных или обновлённых узлов к вычисляемым узлам.
		insert into _idsCalculated
		(
			"val"
		)
		select distinct
			"parent_id"
		from
			"public"."dummy_tree"
		where
			"parent_id" is not null
			and
			"id" in (select "val" from _ids)
		;

		-- Запоминаем идентификаторы предков родителей вставленных или обновлённых узлов.
		insert into _idsAncestor
		(
			"val"
		)
		select distinct
			"parent_id"
		from
			"public"."dummy_tree_link"
		where
			"parent_id" > 0
			and
			"id" <> "parent_id"
			and
			"id" in (select "val" from _idsCalculated)
		;

		-- Добавляем вставленные или обновлённые узлы к вычисляемым узлам.
		insert into _idsCalculated
		(
			"val"
		)
		select
			"val"
		from
			_ids
		;
	end if;

	-- Добавляем предков к вычисляемым узлам.
	insert into _idsCalculated
	(
		"val"
	)
	select
		"val"
	from
		_idsAncestor
	;

	-- Обновление.
	if (_action = 'U') then
		-- Добавляем потомков обновлённых узлов к вычисляемым узлам.
		insert into _idsCalculated
		(
			"val"
		)
		select
			"val"
		from
			_idsDescendant
		;
	end if;

	-- Удаляем связи разрушенных узлов.
	delete from	"public"."dummy_tree_link"
	where
		"id" in (select "val" from _idsBroken)
	;		

	-- Добавляем связи разрушенных узлов.
	with recursive "cteForAncestors" as
	(
		select
			"aliasForTree"."id" "id",
			COALESCE("aliasForTree"."parent_id", 0) "parent_id"
		from
			"public"."dummy_tree" "aliasForTree"
			inner join _idsLinked "aliasForIds"
				on "aliasForTree"."id" = "aliasForIds"."val"
		union all
		select
			"aliasForAncestors"."id" "id",
			COALESCE("aliasForTree"."parent_id", 0) "parent_id"
		from 
			"public"."dummy_tree" "aliasForTree"
			inner join "cteForAncestors" "aliasForAncestors"
				on "aliasForTree"."id" = "aliasForAncestors"."parent_id"
	),
	"cteForAll" as 
	(
		select
			"aliasForTree"."id" "id",
			"aliasForTree"."id" "parent_id"
		from
			"public"."dummy_tree" "aliasForTree"
			inner join _idsLinked "aliasForIds"
				on "aliasForTree"."id" = "aliasForIds"."val"
		union all
		select
			"id", 
			"parent_id"
		from 
			"cteForAncestors"
	)
	insert into "public"."dummy_tree_link"
	(
		"id",
		"parent_id"
	)
	select
		"id", 
		"parent_id"
	from
		"cteForAll"
	;
end $$;
