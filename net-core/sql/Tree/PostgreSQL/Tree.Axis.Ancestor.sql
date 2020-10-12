-- Axis Ancestor

with "cte_input" as 
(
	select
		"id" "root_id"
	from
		"public"."dummy_tree"
	where
		"name" = 'Name-1-1-1-3-2'
)
select
	"t".*
from
	"public"."dummy_tree" "t"
	inner join "public"."dummy_tree_link" "k"
		on "t"."id" = "k"."parent_id"
	cross join "cte_input"
where
	"k"."id" = "cte_input"."root_id"
	and
	"k"."id" <> "k"."parent_id"
;
