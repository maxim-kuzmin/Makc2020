use Test;

CREATE TABLE [dbo].[DummyTree](
	[Id] [bigint] NOT NULL,
	[ParentId] [bigint],
	[Name] [nvarchar](256) NOT NULL,
	[TreeChildCount] [bigint] NOT NULL DEFAULT (0),
	[TreeDescendantCount] [bigint] NOT NULL DEFAULT (0),
	[TreeLevel] [bigint] NOT NULL DEFAULT (0),
	[TreePath] nvarchar(max) NOT NULL DEFAULT (N''),
	[TreePosition] [int] NOT NULL DEFAULT (0),
	[TreeSort] nvarchar(max) NOT NULL DEFAULT (N''),
 CONSTRAINT [PK_DummyTree] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DummyTree]  WITH CHECK ADD  CONSTRAINT [FK_DummyTree_DummyTree_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[DummyTree] ([Id])
GO

ALTER TABLE [dbo].[DummyTree] CHECK CONSTRAINT [FK_DummyTree_DummyTree_ParentId]
GO

-----------------------------------------------

CREATE TABLE [dbo].[DummyTreeLink](
	[Id] [bigint] NOT NULL,
	[ParentId] [bigint] NOT NULL,	
 CONSTRAINT [PK_DummyTreeLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DummyTreeLink]  WITH CHECK ADD  CONSTRAINT [FK_DummyTreeLink_DummyTree_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[DummyTree] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DummyTreeLink] CHECK CONSTRAINT [FK_DummyTreeLink_DummyTree_Id]
GO
