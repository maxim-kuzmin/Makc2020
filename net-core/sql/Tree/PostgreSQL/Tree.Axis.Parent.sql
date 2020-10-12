-- Axis Parent

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
	inner join "public"."dummy_tree" "t2"
		on "t1"."id" = "t2"."parent_id"
	cross join "cte_input"
where
	"t2"."id" = "cte_input"."root_id"
;
