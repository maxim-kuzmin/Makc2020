use Test;

insert into dbo.DummyTree
	(Id, ParentId, Name) 
values
	(1, null, '1'),
	(2, null, '2'),
	(3, null, '3'),
	(4, 2, '2-1'),
	(5, 2, '2-2'),
	(6, 4, '2-1-1'),
	(7, 4, '2-1-2')
;

insert into dbo.DummyTreeLink
	(Id, ParentId)
values
	(1, 1),
	(1, 0),

	(2, 2),
	(2, 0),

	(3, 3),
	(3, 0),

	(4, 2),
	(4, 0),
	(4, 4),

	(5, 2),
	(5, 0),
	(5, 5),

	(6, 4),
	(6, 2),
	(6, 0),
	(6, 6),

	(7, 4),
	(7, 2),
	(7, 0),
	(7, 7)
;