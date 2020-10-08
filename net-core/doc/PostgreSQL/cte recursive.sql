with recursive cte as
(
	select
		1 n,
		1 m
	union
	select
		n + 1 n,
		m + n + 1 m from cte where n < 10
)
select * from cte