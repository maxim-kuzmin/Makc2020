-- Calculate

do $$
begin
	update "public"."dummy_tree" set	
		"tree_child_count" = 0,
		"tree_descendant_count" = 0,
		"tree_path" = '',
		"tree_position" = 0,
		"tree_sort" = '';

	create temp table "_ids" ("val" bigint);

	--insert into "_ids" ("val") values (2), (4);
	insert into "_ids" ("val") select Id from "public"."dummy_tree";

	loop
		with cte as
		(
			select
				"id",
				"parent_id",
				"tree_position"
			from
				"public"."dummy_tree"
			where
				"tree_position" = 0
			limit 1
		)
		update "public"."dummy_tree" set
			"tree_position" = 
			(
				select
					MAX("aliasForTree"."tree_position") + 10
				from
					"public"."dummy_tree" "aliasForTree"
				where
					COALESCE("aliasForTree"."parent_id", 0) = COALESCE("cte"."parent_id", 0)
			)
		from
			"cte"
		where
			"public"."dummy_tree"."id" = "cte"."id"
		;

		if not FOUND then
			exit;
		end if;
	end loop;

	with "cte" as
	(
		select
			"id",
			"tree_child_count",
			"tree_descendant_count",
			"tree_level",
			"tree_path",
			"tree_sort"
		from
			"public"."dummy_tree"
	)
	update "public"."dummy_tree" set
		"tree_child_count" = 
		(
			select
				COUNT(*)
			from
				"public"."dummy_tree" "aliasForTree"
			where
				"aliasForTree"."parent_id" = "cte"."id"
		),
		"tree_descendant_count" = 
		(
			select
				COUNT(*)
			from
				"public"."dummy_tree_link" "aliasForLink"
			where
				"aliasForLink"."parent_id" = "cte"."id"
				and
				"aliasForLink"."parent_id" <> "aliasForLink"."id"
		),
		"tree_level" = 
		(
			select
				COUNT(*) - 1
			from
				"public"."dummy_tree_link" "aliasForLink"
			where
				"aliasForLink"."id" = "cte"."id"
		),
		"tree_path" =
		(
			select
				COALESCE("aliasForResult"."val", '')
			from
			(
				select
					"aliasForLink1"."id",
					(
						select
							STRING_AGG("aliasForLink2"."parent_id"::text, ',')
						from
							"public"."dummy_tree_link" "aliasForLink2"
						where
							"aliasForLink1"."id" = "aliasForLink2"."id"
							and
							"aliasForLink2"."parent_id" > 0
							and
							"aliasForLink2"."parent_id" <> "aliasForLink2"."id"
					) "val"
				from
					"public"."dummy_tree_link" "aliasForLink1"
				group by
					"aliasForLink1"."id"
			) "aliasForResult"
			where
				"aliasForResult"."id" = "cte"."id"
		),
		"tree_sort" =
		(
			select
				COALESCE("aliasForResult"."val", '')
			from
			(
				select
					"aliasForLink1"."id",
					(
						select
						STRING_AGG(RIGHT('0000000000' || "aliasForTree"."tree_position"::text || '.' || "aliasForLink2"."parent_id"::text, 10), ',')
						from
							"public"."dummy_tree_link" "aliasForLink2"
							inner join "public"."dummy_tree" "aliasForTree"
								on "aliasForLink2"."parent_id" = "aliasForTree"."id"
						where
							"aliasForLink1"."id" = "aliasForLink2"."id"
							and
							"aliasForLink2"."parent_id" > 0
					) "val"
				from
					"public"."dummy_tree_link" "aliasForLink1"
				group by
					"aliasForLink1"."id"
			) "aliasForResult"
			where
				"aliasForResult"."id" = "cte"."id"
		)
	from
		"cte"
	where
		"public"."dummy_tree"."id" = "cte"."id"
		and
		"cte"."id" in (select "val" from "_ids")
	;
end $$;