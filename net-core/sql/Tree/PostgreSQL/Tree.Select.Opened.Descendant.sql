-- Select Opened Descendant

with "cte_input_ids_opened" as
(
	select
		"id" "val"
	from
		"public"."dummy_tree"
	where
		"name" in
		(
			'Name-1',
			'Name-1-1-2-1-1'
		)
),
"cte_input" as 
(
	select
		"id" "root_id"
	from
		"public"."dummy_tree"
	where
		"name" = 'Name-1'
)
select
	"t".*
from
	"public"."dummy_tree" "t"
	inner join "public"."dummy_tree_link" "k"
		on "t"."id" = "k"."id"
	left join
	(
		select
			"tt"."id" "val"
		from
			"public"."dummy_tree" "tt"
		where
			"tt"."parent_id" in (select "val" from "cte_input_ids_opened")
			or
			"tt"."id" in (select "val" from "cte_input_ids_opened")
	) "ids"
		on "t"."id" = "ids"."val"
	cross join
	(
		select
			"tree_level"
		from
			"public"."dummy_tree"
			cross join "cte_input"
		where
			"id" = "cte_input"."root_id"
	) t1
	cross join "cte_input"
where
	"k"."parent_id" = "cte_input"."root_id"
	and
	"k"."id" <> "k"."parent_id"
	and
	(
		"ids"."val" is null and "t"."tree_level" = "t1"."tree_level"
		or
		"ids"."val" is not null
	)
order by
	"t"."tree_sort"
;
