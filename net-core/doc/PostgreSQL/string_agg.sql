do $$
declare
  _str text;  
begin
	with "cte" as (
		select
			RIGHT('0000000000' || "t"."first"::text || '.' || "t"."second"::text, 10) "val"
		from
			(values(1, 100), (2, 200), (3, 300)) as "t"("first", "second")
		limit 10
	)
	select
		STRING_AGG("cte"."val", ',')
	from
		"cte"
	into
		_str
	;
	
	RAISE NOTICE '_str="%"', _str;
end $$