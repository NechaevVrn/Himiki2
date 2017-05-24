CREATE TABLE [GroupTree]
(
  [ID] [int] IDENTITY(1,1) NOT NULL,
  [ParentID] [int] NULL,
  [Name] nvarchar(128) NOT NULL,
  [Description] nvarchar(1024) NULL,
  CONSTRAINT [PK_GroupTree] PRIMARY KEY ([ID])
)
