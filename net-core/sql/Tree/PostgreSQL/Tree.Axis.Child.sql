-- Axis Child

with "cte_input" as 
(
	select
		"id" "root_id"
	from
		"public"."dummy_tree"
	where
		"name" = 'Name-1-1-1'
)
select
	t.*
from
	"public"."dummy_tree" "t"
	cross join "cte_input"
where
	"t"."parent_id" = "cte_input"."root_id"
;
