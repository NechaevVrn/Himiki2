CREATE TABLE [Measures]
(
  [ID] [int] IDENTITY(1,1) NOT NULL,
  [Name] [nvarchar](128) NOT NULL,
  [StartTime] [datetime] NOT NULL,
  [Description] [nvarchar](1024) NULL,
  [IsMeasured] [bit] NOT NULL CONSTRAINT [DF_Measures_IsMeasured]  DEFAULT ((1)),
  [GroupID] [int] NULL,
  [FullLength] [float] NOT NULL,
  [Interval] [float] NULL CONSTRAINT [DF_Measures_Interval]  DEFAULT ((1)),
  [DefaultMask] [int] NULL,
  CONSTRAINT [PK_Measures] PRIMARY KEY (  [ID] )
)