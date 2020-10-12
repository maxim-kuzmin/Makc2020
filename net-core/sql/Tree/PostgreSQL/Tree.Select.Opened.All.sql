-- Select Opened All

with cte_input_ids_opened as
(
	select
		"id" "val"
	from
		"public"."dummy_tree"
	where
		"name" in
		(
			'Name-1',
			'Name-1-1-2-1-1',
			'Name-1-1-1',
			'Name-1-1-1-2'
		)
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
where
	"k"."parent_id" = 0
	and
	(
		"ids"."val" is null and "t"."tree_level" = 1
		or
		"ids"."val" is not null
	)
order by
	"t"."tree_sort"
;
