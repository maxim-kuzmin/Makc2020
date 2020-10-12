-- Axis All

select
	"t".*
from
	"public"."dummy_tree" "t"
	inner join "public"."dummy_tree_link" "k"
		on "t"."id" = "k"."id"
where
	"k"."parent_id" = 0	
order by
	"t"."tree_sort"
;
