﻿-- Init

insert into dbo.DummyTree
	(Id, ParentId, Name) 
values
	(1, null, '1'),
	(2, null, '2'),
	(3, null, '3'),
	(4, 2, '2-1'),
	(5, 2, '2-2'),
	(6, 4, '2-1-1'),
	(7, 4, '2-1-2'),
	(8, 3, '3-1'),
	(9, 3, '3-2'),
	(10, 8, '3-1-1'),
	(11, 8, '3-1-2'),
	(12, 8, '3-1-3'),
	(13, 5, '2-2-1'),
	(14, 5, '2-2-2'),
	(15, 5, '2-2-3'),
	(16, 6, '2-1-1-1'),
	(17, 6, '2-1-1-2'),
	(18, 1, '1-1'),
	(19, 1, '1-2'),
	(20, 1, '1-3'),
	(21, 18, '1-1-1'),
	(22, 18, '1-1-2'),
	(23, 18, '1-1-3'),
	(24, 19, '1-2-1'),
	(25, 19, '1-2-2'),
	(26, 19, '1-2-3'),
	(27, 20, '1-3-1'),
	(28, 20, '1-3-2'),
	(29, 20, '1-3-3'),
	(30, 27, '1-3-1-1'),
	(31, 27, '1-3-1-2'),
	(32, 27, '1-3-1-3'),
	(33, 28, '1-3-2-1'),
	(34, 28, '1-3-2-2'),
	(35, 28, '1-3-2-3'),
	(36, 29, '1-3-3-1'),
	(37, 29, '1-3-3-2'),
	(38, 29, '1-3-3-3'),
	(39, 30, '1-3-1-1-1'),
	(40, 30, '1-3-1-1-2'),
	(41, 30, '1-3-1-1-3')
;

--insert into dbo.DummyTreeLink
--	(Id, ParentId)
--values
--	(1, 1),
--	(1, 0),

--	(2, 2),
--	(2, 0),

--	(3, 3),
--	(3, 0),

--	(4, 2),
--	(4, 0),
--	(4, 4),

--	(5, 2),
--	(5, 0),
--	(5, 5),

--	(6, 4),
--	(6, 2),
--	(6, 0),
--	(6, 6),

--	(7, 4),
--	(7, 2),
--	(7, 0),
--	(7, 7)
--;