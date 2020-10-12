do $$
declare
  _id bigint;
  _row_count bigint := 0;
begin
	loop
		with "cte" as
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
					MAX("TreeCalculate_t"."tree_position") + 10
				from
					"public"."dummy_tree" "TreeCalculate_t"
				where
					COALESCE("TreeCalculate_t"."parent_id", 0) = COALESCE("cte"."parent_id", 0)
			)
		from
			"cte"
		where
			"public"."dummy_tree"."id" = "cte"."id"
		;
		
		get diagnostics _row_count = row_count;

		RAISE NOTICE '_row_count=%', _row_count;
		
		if (_row_count < 1) then
			exit;
		end if;
	end loop;
	
	RAISE NOTICE '_count=%', _count;
end$$;