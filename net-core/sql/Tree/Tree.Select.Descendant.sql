use Test;

-- ���

select
	t.*
from
	dbo.DummyTree t
	inner join dbo.DummyTreeLink k on k.Id = t.Id
where
	k.ParentId = 0
order by
	t.TreeSort
;

-- ������: Id = 2

select
	t.*
from
	dbo.DummyTree t
	inner join dbo.DummyTreeLink k on k.Id = t.Id
where
	k.ParentId = 2
order by
	t.TreeSort
;

-- ������: Id = 2. ��� �����.

select
	t.*
from
	dbo.DummyTree t
	inner join dbo.DummyTreeLink k on k.Id = t.Id
where
	k.ParentId = 2
	and k.Id <> k.ParentId
order by
	t.TreeSort
;