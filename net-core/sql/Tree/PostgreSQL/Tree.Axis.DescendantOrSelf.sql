-- Axis DescendantOrSelf

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
	"t".*
from
	"public"."dummy_tree" "t"
	inner join "public"."dummy_tree_link" "k" 
		on "t"."id" = "k"."id"
	cross join "cte_input"
where
	"k"."parent_id" = "cte_input"."root_id"
order by
	"t"."tree_sort"
;
