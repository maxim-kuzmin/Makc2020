use Test;

-- ������: Id = 7

select
	t.*
from
	dbo.DummyTree t
	inner join dbo.DummyTreeLink k on k.ParentId = t.Id
where
	k.Id = 7
;

-- ������: Id = 7. ��� �����.

select
	t.*
from
	dbo.DummyTree t
	inner join dbo.DummyTreeLink k on k.ParentId = t.Id
where
	k.Id = 7
	and k.Id <> k.ParentId
;