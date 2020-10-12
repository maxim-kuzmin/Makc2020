-- Axis ParentOrSelf

with "cte_input" as 
(
	select
		"id" "root_id"
	from
		"public"."dummy_tree"
	where
		"name" = 'Name-1-1'
)
select
	"t1".*
from
	"public"."dummy_tree" "t1"
	inner join "public"."dummy_tree_link" "k"
		on "t1"."id" = "k"."parent_id"
	inner join "public"."dummy_tree" "t2"
		on "k"."id" = "t2"."id"
	cross join "cte_input"
where
	"k"."id" = "cte_input"."root_id"
	and
	(
		"t1"."tree_level" = "t2"."tree_level"
		or
		"t1"."tree_level" = "t2"."tree_level" - 1
	)
;