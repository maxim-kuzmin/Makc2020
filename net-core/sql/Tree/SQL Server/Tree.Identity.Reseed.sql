-- Identity Reseed

DBCC CHECKIDENT ('dbo.DummyTree', RESEED, 0);
DBCC CHECKIDENT ('dbo.DummyTreeLink', RESEED, 0);
